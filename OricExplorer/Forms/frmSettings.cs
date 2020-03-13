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
        private List<string> mlstTapeFolders;
        private List<string> mlstDiskFolders;
        private List<string> mlstRomFolders;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            btnAddFolder.Enabled = false;
            btnUpdateFolder.Enabled = false;
            btnRemoveFolder.Enabled = false;

            mlstTapeFolders = Configuration.Persistent.TapeFolders.ToList();
            mlstDiskFolders = Configuration.Persistent.DiskFolders.ToList();
            mlstRomFolders = Configuration.Persistent.RomFolders.ToList();

            BuildFoldersList();

            optTape.Checked = true;

            txtEmulatorExecutable.Text = Configuration.Persistent.EmulatorExecutable;
            (Configuration.Persistent.DefaultMachineForTape == Machine.Oric1 ? optDefaultMachineOric1 : (Configuration.Persistent.DefaultMachineForTape == Machine.Atmos ? optDefaultMachineAtmos : optDefaultMachinePravetz)).Checked = true;

            txtDirListingFolder.Text = Configuration.Persistent.DirectoryListingsFolder;

            chkCheckForUpdatesOnStartup.Checked = Configuration.Persistent.CheckForUpdatesOnStartup;
            chkTapeIndex.Checked = Configuration.Persistent.TapeIndex;

            Configuration.ListOfFoldersModified = false;
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            // Add new folder to list
            if (txtSelectedFolder.Text.Length > 0)
            {
                if (optTape.Checked)
                {
                    mlstTapeFolders.Add(txtSelectedFolder.Text);
                }
                else if(optDisk.Checked)
                {
                    mlstDiskFolders.Add(txtSelectedFolder.Text);
                }
                else
                {
                    mlstRomFolders.Add(txtSelectedFolder.Text);
                }

                // Rebuild folder list
                BuildFoldersList();

                Configuration.ListOfFoldersModified = true;
            }
        }

        private void btnUpdateFolder_Click(object sender, EventArgs e)
        {
            if(txtSelectedFolder.Text.Length > 0)
            {
                // Replace the selected item
                ListView.SelectedListViewItemCollection lvItem = lvwFolderList.SelectedItems;

                // Remove selected item for tape/disk list
                string folder = lvItem[0].SubItems[1].Text;

                if (lvItem[0].Text.Equals("Tape"))
                {
                    mlstTapeFolders.Remove(folder);
                }
                else if(lvItem[0].Text.Equals("Disk"))
                {
                    mlstDiskFolders.Remove(folder);
                }
                else
                {
                    mlstRomFolders.Remove(folder);
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

                    if(selectedItem.Text.Equals("Tape"))
                    {
                        mlstTapeFolders.Remove(folder);
                    }
                    else if(selectedItem.Text.Equals("Disk"))
                    {
                        mlstDiskFolders.Remove(folder);
                    }
                    else
                    {
                        mlstRomFolders.Remove(folder);
                    }
                }

                BuildFoldersList();

                Configuration.ListOfFoldersModified = true;
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
            Text = "Oric Explorer Settings - Saving settings...";

            Configuration.Persistent.TapeFolders = mlstTapeFolders;
            Configuration.Persistent.DiskFolders = mlstDiskFolders;
            Configuration.Persistent.RomFolders = mlstRomFolders;

            Configuration.Persistent.EmulatorExecutable = txtEmulatorExecutable.Text;
            Configuration.Persistent.DefaultMachineForTape = (optDefaultMachineOric1.Checked ? Machine.Oric1 : (optDefaultMachineAtmos.Checked ? Machine.Atmos : Machine.Pravetz));

            Configuration.Persistent.DirectoryListingsFolder = txtDirListingFolder.Text;

            Configuration.Persistent.CheckForUpdatesOnStartup = chkCheckForUpdatesOnStartup.Checked;
            Configuration.Persistent.TapeIndex = chkTapeIndex.Checked;

            Configuration.Persistent.Save();

            this.DialogResult = DialogResult.OK;

            Text = "Oric Explorer Settings - Settings saved";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Configuration.ListOfFoldersModified = false;
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
            else
            {
                optROM.Checked = true;
            }

            txtSelectedFolder.Text = folder;
        }

        private void BuildFoldersList()
        {
            // Disable updates
            lvwFolderList.BeginUpdate();

            // Clear any items
            lvwFolderList.Items.Clear();

            // Add tape folders to list
            AddTapeFoldersToList();

            // Add disk folders to list
            AddDiskFoldersToList();

            // Add rom folders to list
            AddROMFoldersToList();

            // Enable updates
            lvwFolderList.EndUpdate();

            UpdateButtonsStatus();
        }

        private void AddTapeFoldersToList()
        {
            foreach (string tapeFolder in mlstTapeFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Tape";
                listViewItem.SubItems.Add(tapeFolder);

                lvwFolderList.Items.Add(listViewItem);
            }
        }

        private void AddDiskFoldersToList()
        {
            foreach (string diskFolder in mlstDiskFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Disk";
                listViewItem.SubItems.Add(diskFolder);

                lvwFolderList.Items.Add(listViewItem);
            }
        }

        private void AddROMFoldersToList()
        {
            foreach (string romFolder in mlstRomFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "ROM";
                listViewItem.SubItems.Add(romFolder);

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
                else
                {
                    folderBrowser.Description = "Select ROM Folder";
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
    }
}