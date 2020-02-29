namespace OricExplorer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        //private Configuration configuration;

        private List<string> tapeFolders;
        private List<string> diskFolders;
        private List<string> romFolders;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            buttonAddFolder.Enabled = false;
            buttonUpdateFolder.Enabled = false;
            buttonRemoveFolder.Enabled = false;

            tapeFolders = Configuration.Persistent.TapeFolders;
            diskFolders = Configuration.Persistent.DiskFolders;
            romFolders = Configuration.Persistent.RomFolders;

            BuildFoldersList();

            radioButtonTapes.Checked = true;

            textBoxEmulatorExecutable.Text = Configuration.Persistent.EmulatorExecutable;
            textBoxDirListingFolder.Text = Configuration.Persistent.DirectoryListingsFolder;

            checkBoxCheckForUpdatesOnStartup.Checked = Configuration.Persistent.CheckForUpdatesOnStartup;
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            // Add new folder to list
            if (textBoxSelectedFolder.Text.Length > 0)
            {
                if (radioButtonTapes.Checked)
                {
                    tapeFolders.Add(textBoxSelectedFolder.Text);
                }
                else if(radioButtonDisks.Checked)
                {
                    diskFolders.Add(textBoxSelectedFolder.Text);
                }
                else
                {
                    romFolders.Add(textBoxSelectedFolder.Text);
                }

                // Rebuild folder list
                BuildFoldersList();
            }
        }

        private void buttonUpdateFolder_Click(object sender, EventArgs e)
        {
            if(textBoxSelectedFolder.Text.Length > 0)
            {
                // Replace the selected item
                ListView.SelectedListViewItemCollection lvItem = listViewFolderList.SelectedItems;

                // Remove selected item for tape/disk list
                string folder = lvItem[0].SubItems[1].Text;

                if (lvItem[0].Text.Equals("Tape"))
                {
                    tapeFolders.Remove(folder);
                }
                else if(lvItem[0].Text.Equals("Disk"))
                {
                    diskFolders.Remove(folder);
                }
                else
                {
                    romFolders.Remove(folder);
                }

                buttonAddFolder.PerformClick();
            }
        }

        private void buttonRemoveFolder_Click(object sender, EventArgs e)
        {
            if (listViewFolderList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewFolderList.SelectedItems)
                {
                    string folder = selectedItem.SubItems[1].Text;

                    if(selectedItem.Text.Equals("Tape"))
                    {
                        tapeFolders.Remove(folder);
                    }
                    else if(selectedItem.Text.Equals("Disk"))
                    {
                        diskFolders.Remove(folder);
                    }
                    else
                    {
                        romFolders.Remove(folder);
                    }
                }

                BuildFoldersList();
            }
        }

        private void buttonEmulatorExecutable_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select the Emulator executable";
                fileDialog.DefaultExt = "exe";
                fileDialog.Filter = "Executables (*.exe)|*.exe";
                fileDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();

                DialogResult drResult = fileDialog.ShowDialog();

                if (drResult == DialogResult.OK)
                {
                    // New folder selected
                    textBoxEmulatorExecutable.Text = fileDialog.FileName;
                }
            }
        }

        private void buttonDirListingsFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (textBoxDirListingFolder.TextLength > 0 && Directory.Exists(textBoxDirListingFolder.Text))
                {
                    folderDialog.SelectedPath = textBoxDirListingFolder.Text;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDirListingFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            Text = "Oric Explorer Settings - Saving settings...";

            Configuration.Persistent.TapeFolders = tapeFolders;
            Configuration.Persistent.DiskFolders = diskFolders;
            Configuration.Persistent.RomFolders = romFolders;

            Configuration.Persistent.EmulatorExecutable = textBoxEmulatorExecutable.Text;
            Configuration.Persistent.DirectoryListingsFolder = textBoxDirListingFolder.Text;

            Configuration.Persistent.CheckForUpdatesOnStartup = checkBoxCheckForUpdatesOnStartup.Checked;

            Configuration.Persistent.Save();

            this.DialogResult = DialogResult.OK;

            Text = "Oric Explorer Settings - Settings saved";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Text = "Oric Explorer Settings - Applying settings...";

            Configuration.Persistent.TapeFolders = tapeFolders;
            Configuration.Persistent.DiskFolders = diskFolders;
            Configuration.Persistent.RomFolders = romFolders;

            Configuration.Persistent.EmulatorExecutable = textBoxEmulatorExecutable.Text;
            Configuration.Persistent.DirectoryListingsFolder = textBoxDirListingFolder.Text;

            Configuration.Persistent.CheckForUpdatesOnStartup = checkBoxCheckForUpdatesOnStartup.Checked;

            Configuration.Persistent.Save();

            Text = "Oric Explorer Settings - Settings applied";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void listViewFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsStatus();
        }

        private void listViewFolderList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItem = listViewFolderList.SelectedItems;

            string folder = selectedItem[0].SubItems[1].Text;

            if (selectedItem[0].Text.Equals("Tape"))
            {
                radioButtonTapes.Checked = true;
            }
            else if(selectedItem[0].Text.Equals("Disk"))
            {
                radioButtonDisks.Checked = true;
            }
            else
            {
                radioButtonROMs.Checked = true;
            }

            textBoxSelectedFolder.Text = folder;
        }

        private void BuildFoldersList()
        {
            // Disable updates
            listViewFolderList.BeginUpdate();

            // Clear any items
            listViewFolderList.Items.Clear();

            // Add tape folders to list
            AddTapeFoldersToList();

            // Add disk folders to list
            AddDiskFoldersToList();

            // Add rom folders to list
            AddROMFoldersToList();

            // Enable updates
            listViewFolderList.EndUpdate();

            UpdateButtonsStatus();
        }

        private void AddTapeFoldersToList()
        {
            foreach (string tapeFolder in tapeFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Tape";
                listViewItem.SubItems.Add(tapeFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void AddDiskFoldersToList()
        {
            foreach (string diskFolder in diskFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Disk";
                listViewItem.SubItems.Add(diskFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void AddROMFoldersToList()
        {
            foreach (string romFolder in romFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "ROM";
                listViewItem.SubItems.Add(romFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void buttonBrowseForFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (radioButtonTapes.Checked)
            {
                folderBrowser.Description = "Select Tape Folder";
            }
            else if(radioButtonDisks.Checked)
            {
                folderBrowser.Description = "Select Disk Folder";
            }
            else
            {
                folderBrowser.Description = "Select ROM Folder";
            }

            folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowser.ShowNewFolderButton = false;

            if (textBoxSelectedFolder.TextLength > 0 && Directory.Exists(textBoxSelectedFolder.Text))
            {
                folderBrowser.SelectedPath = textBoxSelectedFolder.Text;
            }

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                // Add new folder to list
                if (folderBrowser.SelectedPath.Length > 0)
                {
                    textBoxSelectedFolder.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void textBoxSelectedFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonsStatus();
        }

        private void UpdateButtonsStatus()
        {
            buttonAddFolder.Enabled = (textBoxSelectedFolder.Text.Length > 0);
            buttonUpdateFolder.Enabled = (textBoxSelectedFolder.Text.Length > 0 && listViewFolderList.SelectedItems.Count > 0);
            buttonRemoveFolder.Enabled = (listViewFolderList.SelectedItems.Count > 0);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.Action == TabControlAction.Selecting && e.TabPage == tabPageDirListings)
            {
                Console.Beep();
                e.Cancel = true;
            }
        }
    }
}