namespace OricExplorer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmSettings : Form
    {
        private List<string> mlstDiskFolders;
        private List<string> mlstTapeFolders;
        private List<string> mlstRomFolders;
        private List<string> mlstOtherFilesFolders;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            btnAddFolder.Enabled = false;
            btnUpdateFolder.Enabled = false;
            btnRemoveFolder.Enabled = false;

            mlstDiskFolders = Configuration.Persistent.DiskFolders.ToList();
            mlstTapeFolders = Configuration.Persistent.TapeFolders.ToList();
            mlstRomFolders = Configuration.Persistent.RomFolders.ToList();
            mlstOtherFilesFolders = Configuration.Persistent.OtherFilesFolders.ToList();

            BuildFoldersList();

            optDisk.Checked = true;

            txtEmulatorExecutable.Text = Configuration.Persistent.EmulatorExecutable;
            (Configuration.Persistent.DefaultMachineForTape == Machine.Oric1 ? optDefaultMachineOric1 : (Configuration.Persistent.DefaultMachineForTape == Machine.Atmos ? optDefaultMachineAtmos : optDefaultMachinePravetz)).Checked = true;

            txtDirListingFolder.Text = Configuration.Persistent.DirectoryListingsFolder;

            chkCheckForUpdatesOnStartup.Checked = Configuration.Persistent.CheckForUpdatesOnStartup;
            chkDisksTree.Checked = Configuration.Persistent.DisksTree;
            chkTapesIndex.Checked = Configuration.Persistent.TapesIndex;
            chkTapesTree.Checked = Configuration.Persistent.TapesTree;
            chkROMsTree.Checked = Configuration.Persistent.ROMsTree;
            chkOtherFilesTree.Checked = Configuration.Persistent.OtherFilesTree;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (optTape.Checked)
            {
                mlstTapeFolders.Add(txtSelectedFolder.Text);
            }
            else if(optDisk.Checked)
            {
                mlstDiskFolders.Add(txtSelectedFolder.Text);
            }
            else if (optRom.Checked)
            {
                mlstRomFolders.Add(txtSelectedFolder.Text);
            }
            else
            {
                mlstOtherFilesFolders.Add(txtSelectedFolder.Text);
            }

            // Rebuild folder list
            BuildFoldersList();
        }

        private void btnUpdateFolder_Click(object sender, EventArgs e)
        {
            if(txtSelectedFolder.Text.Length > 0)
            {
                // Replace the selected item
                ListView.SelectedListViewItemCollection lvItem = lvwFolderList.SelectedItems;

                // Remove selected item for tape/disk list
                string folder = lvItem[0].SubItems[1].Text;

                if(lvItem[0].Text.Equals("Disk"))
                {
                    mlstDiskFolders.Remove(folder);
                }
                else if (lvItem[0].Text.Equals("Tape"))
                {
                    mlstTapeFolders.Remove(folder);
                }
                else if (lvItem[0].Text.Equals("ROM"))
                {
                    mlstRomFolders.Remove(folder);
                }
                else
                {
                    mlstOtherFilesFolders.Remove(folder);
                }

                btnAddFolder.PerformClick();
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            if (lvwFolderList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in lvwFolderList.SelectedItems)
                {
                    string folder = selectedItem.SubItems[1].Text;

                    if(selectedItem.Text.Equals("Disk"))
                    {
                        mlstDiskFolders.Remove(folder);
                    }
                    else if(selectedItem.Text.Equals("Tape"))
                    {
                        mlstTapeFolders.Remove(folder);
                    }
                    else if (selectedItem.Text.Equals("ROM"))
                    {
                        mlstRomFolders.Remove(folder);
                    }
                    else 
                    {
                        mlstOtherFilesFolders.Remove(folder);
                    }
                }

                BuildFoldersList();
            }
        }

        private void btnBrowseForEmulatorExecutable_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select the Emulator executable";
                fileDialog.DefaultExt = "exe";
                fileDialog.Filter = "Executables (*.exe)|*.exe";

                if (txtEmulatorExecutable.TextLength > 0 && File.Exists(txtEmulatorExecutable.Text))
                {
                    fileDialog.InitialDirectory = Path.GetDirectoryName(txtEmulatorExecutable.Text);
                }
                else
                {
                    fileDialog.InitialDirectory = Application.ExecutablePath;
                }

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // New folder selected
                    txtEmulatorExecutable.Text = fileDialog.FileName;
                }
            }
        }

        private void btnBrowserForDirListingsFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder for Output Directory functions";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (txtDirListingFolder.TextLength > 0 && Directory.Exists(txtDirListingFolder.Text))
                {
                    folderDialog.SelectedPath = txtDirListingFolder.Text;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirListingFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEmulatorExecutable.TextLength == 0 && MessageBox.Show("The path of the emulator has not yet been defined.\r\n\r\nDo you want to configure it now?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                tabSettings.SelectedTab = tabpEmulator;
                txtEmulatorExecutable.Focus();
                return;
            }

            Text = "Oric Explorer Settings - Saving settings...";

            Configuration.ListOfFoldersModified = (
                !Configuration.Persistent.DiskFolders.SequenceEqual(mlstDiskFolders) ||
                !Configuration.Persistent.TapeFolders.SequenceEqual(mlstTapeFolders) ||
                !Configuration.Persistent.RomFolders.SequenceEqual(mlstRomFolders) ||
                !Configuration.Persistent.OtherFilesFolders.SequenceEqual(mlstOtherFilesFolders) ||
                Configuration.Persistent.DisksTree != chkDisksTree.Checked ||
                Configuration.Persistent.TapesIndex != chkTapesIndex.Checked ||
                Configuration.Persistent.TapesTree != chkTapesTree.Checked ||
                Configuration.Persistent.ROMsTree != chkROMsTree.Checked ||
                Configuration.Persistent.OtherFilesTree != chkOtherFilesTree.Checked
            );

            Configuration.Persistent.DiskFolders = mlstDiskFolders;
            Configuration.Persistent.TapeFolders = mlstTapeFolders;
            Configuration.Persistent.RomFolders = mlstRomFolders;
            Configuration.Persistent.OtherFilesFolders = mlstOtherFilesFolders;

            Configuration.Persistent.EmulatorExecutable = txtEmulatorExecutable.Text;
            Configuration.Persistent.DefaultMachineForTape = (optDefaultMachineOric1.Checked ? Machine.Oric1 : (optDefaultMachineAtmos.Checked ? Machine.Atmos : Machine.Pravetz));

            Configuration.Persistent.DirectoryListingsFolder = txtDirListingFolder.Text;

            Configuration.Persistent.CheckForUpdatesOnStartup = chkCheckForUpdatesOnStartup.Checked;
            Configuration.Persistent.DisksTree = chkDisksTree.Checked;
            Configuration.Persistent.TapesIndex = chkTapesIndex.Checked;
            Configuration.Persistent.TapesTree = chkTapesTree.Checked;
            Configuration.Persistent.ROMsTree = chkROMsTree.Checked;
            Configuration.Persistent.OtherFilesTree = chkOtherFilesTree.Checked;

            Configuration.Persistent.Save();

            this.DialogResult = DialogResult.OK;

            Text = "Oric Explorer Settings - Settings saved";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lvwFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsStatus();
        }

        private void lvwFolderList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItem = lvwFolderList.SelectedItems;

            string folder = selectedItem[0].SubItems[1].Text;

            if (selectedItem[0].Text.Equals("Tape"))
            {
                optTape.Checked = true;
            }
            else if(selectedItem[0].Text.Equals("Disk"))
            {
                optDisk.Checked = true;
            }
            else if (selectedItem[0].Text.Equals("ROM"))
            {
                optRom.Checked = true;
            }
            else
            {
                optOtherFiles.Checked = true;
            }

            txtSelectedFolder.Text = folder;
        }

        private void BuildFoldersList()
        {
            // Disable updates
            lvwFolderList.BeginUpdate();

            // Clear any items
            lvwFolderList.Items.Clear();

            // Add disk folders to list
            AddFoldersToList(mlstDiskFolders, "Disk");

            // Add tape folders to list
            AddFoldersToList(mlstTapeFolders, "Tape");

            // Add rom folders to list
            AddFoldersToList(mlstRomFolders, "ROM");

            // Add other files folders to list
            AddFoldersToList(mlstOtherFilesFolders, "Other files");

            // Enable updates
            lvwFolderList.EndUpdate();

            UpdateButtonsStatus();
        }

        private void AddFoldersToList(List<string> folders, string type)
        {
            foreach (string folder in folders)
            {
                ListViewItem listViewItem = new ListViewItem(new string[lvwFolderList.Columns.Count]);
                listViewItem.Text = type;
                listViewItem.SubItems[colFolderName.Index].Text = folder;

                lvwFolderList.Items.Add(listViewItem);
            }
        }

        private void btnBrowseForFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (optTape.Checked)
                {
                    folderBrowser.Description = "Select Tape Folder";
                }
                else if (optDisk.Checked)
                {
                    folderBrowser.Description = "Select Disk Folder";
                }
                else if (optRom.Checked)
                {
                    folderBrowser.Description = "Select Rom Folder";
                }
                else 
                {
                    folderBrowser.Description = "Select Other Files Folder";
                }

                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowser.ShowNewFolderButton = false;

                if (txtSelectedFolder.TextLength > 0 && Directory.Exists(txtSelectedFolder.Text))
                {
                    folderBrowser.SelectedPath = txtSelectedFolder.Text;
                }

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    // Add new folder to list
                    if (folderBrowser.SelectedPath.Length > 0)
                    {
                        txtSelectedFolder.Text = folderBrowser.SelectedPath;
                    }
                }
            }
        }

        private void txtSelectedFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonsStatus();
        }

        private void UpdateButtonsStatus()
        {
            btnAddFolder.Enabled = (txtSelectedFolder.Text.Length > 0);
            btnUpdateFolder.Enabled = (txtSelectedFolder.Text.Length > 0 && lvwFolderList.SelectedItems.Count > 0);
            btnRemoveFolder.Enabled = (lvwFolderList.SelectedItems.Count > 0);
        }

        private void chkTapesIndex_CheckedChanged(object sender, EventArgs e)
        {
            chkTapesTree.Enabled = !chkTapesIndex.Checked;

            if (chkTapesIndex.Checked)
            {
                chkTapesTree.Checked = false;
            }
        }

        private void chkTapesTree_CheckedChanged(object sender, EventArgs e)
        {
            chkTapesIndex.Enabled = !chkTapesTree.Checked;

            if (chkTapesTree.Checked)
            {
                chkTapesIndex.Checked = false;
            }
        }
    }
}