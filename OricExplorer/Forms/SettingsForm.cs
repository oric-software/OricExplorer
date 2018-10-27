using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Collections.Specialized;

namespace OricExplorer
{
    public partial class SettingsForm : Form
    {
        private Configuration configuration;

        private StringCollection tapeFolders;
        private StringCollection diskFolders;
        private StringCollection romFolders;

        public SettingsForm()
        {
            InitializeComponent();

            tapeFolders = new StringCollection();
            diskFolders = new StringCollection();
            romFolders = new StringCollection();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Load in current settings from configuration file
            configuration = new Configuration();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            buttonAddFolder.Enabled = false;
            buttonUpdateFolder.Enabled = false;
            buttonRemoveFolder.Enabled = false;

            tapeFolders = configuration.TapeFolders;
            diskFolders = configuration.DiskFolders;
            romFolders = configuration.ROMFolders;

            BuildFoldersList();

            radioButtonTapes.Checked = true;

            textBoxEmulatorExecutable.Text = configuration.EmulatorExecutable;
            textBoxDirListingFolder.Text = configuration.DirListingsFolder;

            checkBoxCheckForUpdatesOnStartup.Checked = configuration.CheckForUpdatesOnStartup;
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
                String folder = lvItem[0].SubItems[1].Text;

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

                buttonAddFolder_Click(sender, e);
            }
        }

        private void buttonRemoveFolder_Click(object sender, EventArgs e)
        {
            if (listViewFolderList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewFolderList.SelectedItems)
                {
                    String folder = selectedItem.SubItems[1].Text;

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
                DialogResult dialogResult = folderDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    textBoxDirListingFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            Text = "Oric Explorer Settings - Saving settings...";

            configuration.TapeFolders = tapeFolders;
            configuration.DiskFolders = diskFolders;
            configuration.ROMFolders = romFolders;

            configuration.EmulatorExecutable = textBoxEmulatorExecutable.Text;
            configuration.DirListingsFolder = textBoxDirListingFolder.Text;

            configuration.CheckForUpdatesOnStartup = checkBoxCheckForUpdatesOnStartup.Checked;

            configuration.SaveSettings();

            this.DialogResult = DialogResult.OK;

            Text = "Oric Explorer Settings - Settings saved";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Text = "Oric Explorer Settings - Applying settings...";

            configuration.TapeFolders = tapeFolders;
            configuration.DiskFolders = diskFolders;
            configuration.ROMFolders = romFolders;

            configuration.EmulatorExecutable = textBoxEmulatorExecutable.Text;
            configuration.DirListingsFolder = textBoxDirListingFolder.Text;

            configuration.CheckForUpdatesOnStartup = checkBoxCheckForUpdatesOnStartup.Checked;

            configuration.SaveSettings();

            Text = "Oric Explorer Settings - Settings applied";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void listViewFolderList_Click(object sender, EventArgs e)
        {
            if (listViewFolderList.SelectedItems.Count > 0)
            {
                buttonRemoveFolder.Enabled = true;
            }
            else
            {
                buttonRemoveFolder.Enabled = false;
            }
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
        }

        private void AddTapeFoldersToList()
        {
            foreach (String tapeFolder in tapeFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Tape";
                listViewItem.SubItems.Add(tapeFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void AddDiskFoldersToList()
        {
            foreach (String diskFolder in diskFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "Disk";
                listViewItem.SubItems.Add(diskFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void AddROMFoldersToList()
        {
            foreach (String romFolder in romFolders)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "ROM";
                listViewItem.SubItems.Add(romFolder);

                listViewFolderList.Items.Add(listViewItem);
            }
        }

        private void listViewFolderList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItem = listViewFolderList.SelectedItems;

            String folder = selectedItem[0].SubItems[1].Text;

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

            DialogResult drResult = folderBrowser.ShowDialog();

            if (drResult == DialogResult.OK)
            {
                // Add new folder to list
                if (folderBrowser.SelectedPath.Length > 0)
                {
                    if (radioButtonTapes.Checked)
                    {
                        tapeFolders.Add(folderBrowser.SelectedPath);
                    }
                    else if(radioButtonDisks.Checked)
                    {
                        diskFolders.Add(folderBrowser.SelectedPath);
                    }
                    else
                    {
                        romFolders.Add(folderBrowser.SelectedPath);
                    }
                }

                // Rebuild folder list
                BuildFoldersList();
            }

        }

        private void textBoxSelectedFolder_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSelectedFolder.Text.Length > 0)
            {
                buttonAddFolder.Enabled = true;
                buttonUpdateFolder.Enabled = true;
                buttonRemoveFolder.Enabled = true;
            }
            else
            {
                buttonAddFolder.Enabled = true;
                buttonUpdateFolder.Enabled = true;
                buttonRemoveFolder.Enabled = true;
            }
        }
    }
}