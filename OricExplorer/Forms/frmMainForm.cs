namespace OricExplorer
{
    using global::OricExplorer.Forms;
    using global::OricExplorer.User_Controls;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmMainForm : Form
    {
        private TreeNode rootNode;
        private TreeNode tapeTreeNode;
        private TreeNode diskTreeNode;
        private TreeNode romTreeNode;
        private TreeNode otherFileTreeNode;

        // Tree nodes for disk groups
        private TreeNode oricDosGroupNode;
        private TreeNode sedOricGroupNode;
        private TreeNode ftDosGroupNode;
        private TreeNode stratSedGroupNode;
        private TreeNode xlDosGroupNode;
        private TreeNode unknownGroupNode;

        private StreamWriter dirListing = null;

        private frmMainView mainViewControl;
        private OricProgram loadedProgram;

        private frmFileList fileListForm;
        public frmProgramInfo programInfoForm;

        private frmScreenshoterOricutron screenshoterOricutron;

        public frmMainForm()
        {
            InitializeComponent();

            Version version = new Version(Application.ProductVersion);
            int copyrightYear = 2017;
            try
            {
                var copyright = ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(System.Reflection.AssemblyCopyrightAttribute))).Copyright;

                Match match = new Regex(".*(?<year>[0-9]{4}).*").Match(copyright);

                if (match.Success)
                {
                    copyrightYear = int.Parse(match.Groups["year"].Value);
                }
            } catch { }
            this.Text = string.Format(this.Text, $"{version.Major}.{version.Minor}{(version.Build + version.Revision > 0 ? $".{version.Build}{(version.Revision > 0 ? $".{version.Revision}" : string.Empty)}" : string.Empty)}", copyrightYear);

            fileListForm = new frmFileList(this);

            programInfoForm = new frmProgramInfo();

            loadedProgram = new OricProgram();

            mnuToolsScreenshoterForOricutron.Enabled = Environment.OSVersion.Platform.Equals(PlatformID.Win32NT);
        }

        private void frmMainForm_Load(object sender, System.EventArgs e)
        {
            if (!Configuration.Persistent.MainWindowSize.IsEmpty)
            {
                this.Size = Configuration.Persistent.MainWindowSize;
            }
            if (!Configuration.Persistent.MainWindowLocation.IsEmpty)
            {
                this.Location = Configuration.Persistent.MainWindowLocation;
            }
            else
            {
                this.CenterToScreen();
            }
            if (Configuration.Persistent.MainWindowMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            if (string.IsNullOrEmpty(Configuration.Persistent.DockPanelLayout))
            {
                fileListForm.Show(dkpPanel, DockState.DockLeft);
                programInfoForm.Show(dkpPanel, DockState.DockRight);
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(Configuration.Persistent.DockPanelLayout)))
                {
                    dkpPanel.LoadFromXml(ms, new DeserializeDockContent(GetContentFromPersistString));

                    if (dkpPanel.Contents.Count() == 0)
                    {
                        fileListForm.Show(dkpPanel, DockState.DockLeft);
                        programInfoForm.Show(dkpPanel, DockState.DockRight);
                    }
                }
            }

            Show();
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(frmFileList).ToString())
            {
                return fileListForm;
            }
            else if (persistString == typeof(frmProgramInfo).ToString())
            {
                return programInfoForm;
            }

            return null;
        }

        private void frmMainForm_Shown(object sender, EventArgs e)
        {
            bool boolCloseApp = false;

            // check for updates first if option is enabled
            if (Configuration.Persistent.CheckForUpdatesOnStartup)
            {
                using (frmCheckForUpdate checkForUpdateForm = new frmCheckForUpdate(true))
                {
                    boolCloseApp = (checkForUpdateForm.ShowDialog() == DialogResult.OK);
                }
            }

            // restart and close the application if the update was successful
            if (boolCloseApp)
            {
                Process.Start(Assembly.GetExecutingAssembly().Location);
                Application.Exit();
            }
            else
            {
                // open the settings dialog if configuration contains no media folder
                if (Configuration.Persistent.TapeFolders.Count + Configuration.Persistent.DiskFolders.Count + Configuration.Persistent.RomFolders.Count + Configuration.Persistent.OtherFilesFolders.Count == 0)
                {
                    using (frmSettings settingsForm = new frmSettings())
                    {
                        settingsForm.ShowDialog();
                    }
                }

                // Build the file tree
                BuildFileTree();
            }
        }

        private void frmMainForm_Closing(object sender, CancelEventArgs e)
        {
            Configuration.Persistent.MainWindowMaximized = (this.WindowState == FormWindowState.Maximized);
            this.WindowState = FormWindowState.Normal;
            Configuration.Persistent.MainWindowSize = this.Size;
            Configuration.Persistent.MainWindowLocation = this.Location;

            using (MemoryStream ms = new MemoryStream())
            {
                dkpPanel.SaveAsXml(ms, Encoding.Default);
                Configuration.Persistent.DockPanelLayout = Encoding.Default.GetString(ms.ToArray());
            }

            Configuration.Persistent.Save();
        }

        #region MainForm Menu Functions
        #region File Menu
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit Oric Explorer?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }
        #endregion

        #region View Menu
        private void mnuView_DropDownOpening(object sender, EventArgs e)
        {
            mnuViewClose.Enabled = (dkpPanel.ActiveDocument != null);
            mnuViewCloseAll.Enabled = (dkpPanel.DocumentsCount > 0);
            mnuViewCloseAllButThisOne.Enabled = (dkpPanel.DocumentsCount > 1) && (dkpPanel.ActiveDocument != null);
        }

        private void mnuViewClose_Click(object sender, EventArgs e)
        {
            dkpPanel.ActiveDocument.DockHandler.Close();
        }

        private void mnuViewCloseAll_Click(object sender, EventArgs e)
        {
            for (int index = dkpPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (dkpPanel.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)dkpPanel.Contents[index];

                    if (content.GetType() == typeof(frmMainView))
                    {
                        content.DockHandler.Close();
                    }
                }
            }
        }

        private void mnuViewCloseAllButThisOne_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dkpPanel.DocumentsToArray())
            {
                if (document.GetType() == typeof(frmMainView))
                {
                    if (!document.DockHandler.IsActivated)
                    {
                        document.DockHandler.Close();
                    }
                }
            }
        }

        private void mnuViewSortDiskDirectory_DropDownOpening(object sender, EventArgs e)
        {
            mnuViewSortDiskDirectoryByName.Checked = (fileListForm.tvwFileList.TreeViewNodeSorter is NodeSortedByName);
            mnuViewSortDiskDirectoryByExtension.Checked = (fileListForm.tvwFileList.TreeViewNodeSorter is NodeSortedByExtension);
            mnuViewSortDiskDirectoryByType.Checked = (fileListForm.tvwFileList.TreeViewNodeSorter is NodeSortedByType);
        }

        private void mnuViewSortDiskDirectoryByName_Click(object sender, EventArgs e)
        {
            fileListForm.tvwFileList.TreeViewNodeSorter = new NodeSortedByName();
            fileListForm.tvwFileList.Sort();
        }

        private void mnuViewSortDiskDirectoryByExtension_Click(object sender, EventArgs e)
        {
            fileListForm.tvwFileList.TreeViewNodeSorter = new NodeSortedByExtension();
            fileListForm.tvwFileList.Sort();
        }

        private void mnuViewSortDiskDirectoryByType_Click(object sender, EventArgs e)
        {
            fileListForm.tvwFileList.TreeViewNodeSorter = new NodeSortedByType();
            fileListForm.tvwFileList.Sort();
        }

        private void mnuViewRefresh_Click(object sender, EventArgs e)
        {
            RebuildTree();
        }

        private void RebuildTree()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Position = Cursor.Position;

            // Setup messages for the status labels
            tsslStatusMain.Text = "Refreshing the file list...";

            // Clear all the current nodes from the file tree
            fileListForm.tvwFileList.Nodes.Clear();

            // Clear out the currently loaded program
            loadedProgram.New();

            Application.DoEvents();

            fileListForm.txtFilter.Clear();

            // Rebuild the file tree
            BuildFileTree();
        
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Tools Menu
        private void mnuToolsImportAtmosBasicFile_Click(object sender, EventArgs e)
        {
            using (frmImportAtmosBasicFile importTextFileForm = new frmImportAtmosBasicFile())
            {
                importTextFileForm.ShowDialog();
            }
        }

        private void mnuToolsSyntaxHighlighting_Click(object sender, EventArgs e)
        {
            using (frmSyntaxHighlighting syntaxHighlightingForm = new frmSyntaxHighlighting())
            {
                syntaxHighlightingForm.ShowDialog();
            }
        }

        private void mnuToolsScreenshoterForOricutron_Click(object sender, EventArgs e)
        {
            if (screenshoterOricutron == null)
            {
                screenshoterOricutron = new frmScreenshoterOricutron(this);
                screenshoterOricutron.Icon = this.Icon;
            }

            screenshoterOricutron.Show();
        }

        private void mnuToolsSettings_Click(object sender, EventArgs e)
        {
            // Show settings dialog
            using (frmSettings settingsForm = new frmSettings())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK && Configuration.ListOfFoldersModified)
                {
                    RebuildTree();
                }
            }
        }
        #endregion

        #region Help Menu
        private void mnuHelpCheckForUpdates_Click(object sender, EventArgs e)
        {
            bool boolCloseApp = false;

            using (frmCheckForUpdate checkForUpdateForm = new frmCheckForUpdate(false))
            {
                boolCloseApp = (checkForUpdateForm.ShowDialog() == DialogResult.OK);
            }

            // restart and close the application if the update was successful
            if (boolCloseApp)
            {
                Process.Start(Assembly.GetExecutingAssembly().Location);
                Application.Exit();
            }
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            frmAboutBox aboutBox = new frmAboutBox();
            aboutBox.ShowDialog();
        }
        #endregion
        #endregion

        #region Common Context Menu
        private void cmnuDiskRename_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

            if (!selectedNode.IsEditing)
            {
                fileListForm.tvwFileList.LabelEdit = true;
                selectedNode.BeginEdit();
            }
        }

        internal void treeFileList_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Label))
            {
                string oldFileName;
                string mediaType;
                string extension;

                TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

                if (selectedNode.Tag.GetType() == typeof(OricDiskInfo))
                {
                    OricDiskInfo diskInfo = (OricDiskInfo)selectedNode.Tag;
                    oldFileName = diskInfo.FullName;
                    mediaType = "disk";
                    extension = ".dsk";
                }
                else
                {
                    TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;
                    oldFileName = tapeInfo.FullName;
                    mediaType = "tape";
                    extension = ".tap";
                }

                try
                {
                    string newName = e.Label + (e.Label.EndsWith(extension, StringComparison.InvariantCultureIgnoreCase) ? string.Empty : extension);

                    // prepare the new name
                    string newFileName = Path.Combine(Path.GetDirectoryName(oldFileName), newName);
                    
                    // rename the file
                    File.Move(oldFileName, newFileName);

                    // update the node (delete the old one and re-create the new one causes a display problem which I did not manage to solve)
                    if (selectedNode.Tag.GetType() == typeof(OricDiskInfo))
                    {
                        OricDiskInfo diskInfo = (OricDiskInfo)selectedNode.Tag;
                        diskInfo.UpdateFullName(newFileName);

                        selectedNode.Tag = diskInfo;
                    }
                    else
                    {
                        TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;
                        tapeInfo.UpdateFullName(newFileName);

                        selectedNode.Tag = tapeInfo;
                    }
                    selectedNode.Text = newName;

                    fileListForm.tvwFileList.SelectedNode = selectedNode;
                    fileListForm.tvwFileList.SelectedNode.EnsureVisible();

                    // Remember entire tree for filter
                    fileListForm.tvwFileList.Tag = rootNode.Clone();

                    // Display warning if operation is made on filtered list
                    fileListForm.FilteredListWarning();

                    tmrAfterLabelEdit.Tag = Tuple.Create(selectedNode, newName);
                    tmrAfterLabelEdit.Start();
                }
                catch (Exception ex)
                {
                    e.CancelEdit = true;
                    MessageBox.Show($"Failed to rename {mediaType}.\r\n\r\n{ex.Message}", $"Rename {mediaType}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                e.CancelEdit = true;
            }

            fileListForm.tvwFileList.LabelEdit = false;
        }
        private void tmrAfterLabelEdit_Tick(object sender, EventArgs e)
        {
            tmrAfterLabelEdit.Stop();

            Tuple<TreeNode, string> tup = (Tuple<TreeNode, string>)tmrAfterLabelEdit.Tag;
            tup.Item1.Text = tup.Item2;
        }
        #endregion

        #region Disk Context Menu
        private void cmnuDisk_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void cmnuDiskCreateNewDisk_Click(object sender, EventArgs e)
        {

        }

        private void cmnuDiskFormatDisk_Click(object sender, EventArgs e)
        {

        }

        private void cmnuDiskConvertToTape_Click(object sender, EventArgs e)
        {
            
        }

        private void cmnuDiskCopy_Click(object sender, EventArgs e)
        {
            try
            {
                // retrieve disk info of selected node
                OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;

                // determine source and target paths
                string source = diskInfo.FullName;
                string target = Path.Combine(Path.GetDirectoryName(diskInfo.FullName), Path.GetFileNameWithoutExtension(diskInfo.FullName) + " (copy)" + Path.GetExtension(diskInfo.FullName));

                // copy file
                File.Copy(source, target);

                // Add copied file to the tree
                FileInfo fiNewFile = new FileInfo(target);
                TreeNode newNode = AddDiskToTree(fiNewFile, null, fileListForm.tvwFileList.SelectedNode.Parent);

                // open and select the updated node
                fileListForm.tvwFileList.SelectedNode = newNode;
                fileListForm.tvwFileList.SelectedNode.EnsureVisible();

                // Remember entire tree for filter
                fileListForm.tvwFileList.Tag = rootNode.Clone();

                // Display warning if operation is made on filtered list
                fileListForm.FilteredListWarning();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy file.\r\n\r\n{ex.Message}", "Disk copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmnuDiskDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;
            OricDiskInfo diskInfo = (OricDiskInfo)selectedNode.Tag;

            string confirmMessage = $"Are you sure you want to delete {diskInfo.FullName}?";

            if (MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(diskInfo.FullName);

                    // Remove item from the tree
                    selectedNode.Remove();

                    // Remember entire tree for filter
                    fileListForm.tvwFileList.Tag = rootNode.Clone();

                    // Display warning if operation is made on filtered list
                    fileListForm.FilteredListWarning();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete disk.\r\n\r\n{ex.Message}", "Delete Disk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmnuDiskOutputDirectory_Click(object sender, EventArgs e)
        {
            // Get selected node
            TreeNode diskNode = fileListForm.tvwFileList.SelectedNode;

            string outputFile = Path.Combine(Configuration.Persistent.DirectoryListingsFolder, diskNode.Text + ".txt");

            try
            {
                // Open output file
                dirListing = File.CreateText(outputFile);

                // Output directory listing of selected disk
                OutputDiskDirectory(diskNode);

                // Close the writer and underlying file
                dirListing.Close();

                MessageBox.Show("Directory listing sent to " + outputFile, "Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmnuDiskOutputDirectoryToPDF_Click(object sender, EventArgs e)
        {

        }

        private void cmnuDiskOutputDirectoryToTextFile_Click(object sender, EventArgs e)
        {

        }

        private void cmnuDiskOutputDirectoryToPrinter_Click(object sender, EventArgs e)
        {

        }

        private void cmnuDiskScreenViewer_Click(object sender, EventArgs e)
        {
            using (frmScreenViewer slideshowViewerForm = new frmScreenViewer())
            {
                OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;
                slideshowViewerForm.diskInfo = diskInfo;

                slideshowViewerForm.ShowDialog();
            }
        }

        private void cmnuDiskDiskInformation_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;
            DisplayDiskInformation(diskInfo);
        }

        private void cmnuDiskLoadIntoEmulator_Click(object sender, EventArgs e)
        {
            LoadDiskInEmulator();
        }

        public void LoadDiskInEmulator(Machine? machineType = null)
        {
            tsslStatusMain.Text = "Starting emulator...";
            Application.DoEvents();

            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;

            if (!machineType.HasValue)
            {
                switch (diskInfo.DOSFormat.ToString().ToLower())
                {
                    case "stratsed":
                        machineType = Machine.Telestrat;
                        break;

                    default:
                        machineType = Machine.Atmos;
                        break;
                }
            }

            string machineName;

            switch (machineType.Value)
            {
                case Machine.Pravetz:
                    machineName = "pravetz";
                    break;

                case Machine.Oric1:
                    machineName = "oric1";
                    break;

                case Machine.Telestrat:
                    machineName = "telestrat";
                    break;

                default:
                    machineName = "atmos";
                    break;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Configuration.Persistent.EmulatorExecutable,
                    WorkingDirectory = Path.GetDirectoryName(Configuration.Persistent.EmulatorExecutable),
                    WindowStyle = ProcessWindowStyle.Normal,
                    Arguments = string.Format("--machine {0} --disk \"{1}\"", machineName, diskInfo.FullName)
                };

                Process.Start(startInfo);
            }
            catch (Exception)
            {
                string errorMessage = "Failed to start the Emulator.\r\n\r\nPlease check the Emulator location in Settings.";
                MessageBox.Show(errorMessage, "Run in Emulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tsslStatusMain.Text = "Ready.";
        }

        private void cmnuDiskRawDataViewer_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;
            DisplayUnknownDisk(diskInfo);
        }

        private void cmnuDiskRefresh_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Tape Context Menu
        private void cmnuTapeViewFiles_Click(object sender, EventArgs e)
        {
            foreach (TreeNode fileNode in fileListForm.tvwFileList.SelectedNode.Nodes)
            {
                DisplayFileContents((OricFileInfo)fileNode.Tag);
            }
        }

        private void cmnuTapeEditTape_Click(object sender, EventArgs e)
        {
            TapeInfo tapeInfo = (TapeInfo)fileListForm.tvwFileList.SelectedNode.Tag;

            using (frmEditTape editTapeForm = new frmEditTape())
            {
                // Setup parameters
                editTapeForm.TapeFolder = Path.GetDirectoryName(tapeInfo.FullName);
                editTapeForm.TapeName = Path.GetFileName(tapeInfo.FullName);

                FileInfo tapeFileInfo = new FileInfo(tapeInfo.FullName);

                OricTape oricTape = new OricTape();
                OricFileInfo[] tapeCatalog = oricTape.Catalog(tapeFileInfo);
                OricProgram[] programs = new OricProgram[tapeCatalog.Length];
                Enumerable.Range(0, programs.Length).Select(i => programs[i] = tapeCatalog[i].LoadFile()).ToList();

                editTapeForm.TapeCatalog = tapeCatalog;

                // Show edit form
                if (editTapeForm.ShowDialog() == DialogResult.OK)
                {
                    OricTape newTape = new OricTape();
                    newTape.TapeName = tapeInfo.FullName;

                    ArrayList programList = new ArrayList();

                    foreach (OricFileInfo programInfo in editTapeForm.TapeCatalog)
                    {
                        // prepare the program contents from the original tape
                        OricProgram program = programs[programInfo.ProgramIndex];
                        program.ProgramName = programInfo.ProgramName;
                        program.AutoRun = programInfo.AutoRun;
                        program.StartAddress = programInfo.StartAddress;
                        program.EndAddress = programInfo.EndAddress;

                        programList.Add(program);
                    }

                    // write tape
                    newTape.WriteFiles(programList, FileMode.Create);

                    // add the updated tape to the tree list and expand it to display content
                    TreeNode newNode = AddTapeToTree(tapeFileInfo, null, fileListForm.tvwFileList.SelectedNode.Parent);

                    // remove tape from tree list
                    fileListForm.tvwFileList.SelectedNode.Remove();

                    // open and select the updated node
                    fileListForm.tvwFileList.SelectedNode = newNode;
                    fileListForm.tvwFileList.SelectedNode.Expand();
                    fileListForm.tvwFileList.SelectedNode.EnsureVisible();

                    // Remember entire tree for filter
                    fileListForm.tvwFileList.Tag = rootNode.Clone();

                    // Display warning if operation is made on filtered list
                    fileListForm.FilteredListWarning();
                }
            }
        }

        private void cmnuTapeOutputDirectory_Click(object sender, EventArgs e)
        {
            // Get selected node
            TreeNode tapeNode = fileListForm.tvwFileList.SelectedNode;

            string outputFile = Path.Combine(Configuration.Persistent.DirectoryListingsFolder, tapeNode.Text + ".txt");

            try
            {
                // Open output file
                dirListing = File.CreateText(outputFile);

                // Output directory listing of selected tape
                OutputTapeDirectory(tapeNode);

                // Close the writer and underlying file
                dirListing.Close();

                MessageBox.Show("Directory listing sent to " + outputFile, "Output Directory",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmnuTapeCopy_Click(object sender, EventArgs e)
        {
            try
            {
                // retrieve tape info of selected node
                TapeInfo tapeInfo = (TapeInfo)fileListForm.tvwFileList.SelectedNode.Tag;

                // determine source and target paths
                string source = tapeInfo.FullName;
                string target = Path.Combine(Path.GetDirectoryName(tapeInfo.FullName), Path.GetFileNameWithoutExtension(tapeInfo.FullName) + " (copy)" + Path.GetExtension(tapeInfo.FullName));

                // copy file
                File.Copy(source, target);

                // add copied file to the tree
                FileInfo fiNewFile = new FileInfo(target);
                TreeNode newNode = AddTapeToTree(fiNewFile, null, fileListForm.tvwFileList.SelectedNode.Parent);

                // open and select the updated node
                fileListForm.tvwFileList.SelectedNode = newNode;
                fileListForm.tvwFileList.SelectedNode.EnsureVisible();
                
                // Remember entire tree for filter
                fileListForm.tvwFileList.Tag = rootNode.Clone();

                // Display warning if operation is made on filtered list
                fileListForm.FilteredListWarning();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy file.\r\n\r\n{ex.Message}", "Tape copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmnuTapeDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;
            TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;

            string confirmMessage = $"Are you sure you want to delete {tapeInfo.FullName}?";

            if (MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(tapeInfo.FullName);

                    // Remove item from the tree
                    selectedNode.Remove();

                    // Remember entire tree for filter
                    fileListForm.tvwFileList.Tag = rootNode.Clone();

                    // Display warning if operation is made on filtered list
                    fileListForm.FilteredListWarning();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete tape.\r\n\r\n{ex.Message}", "Delete Tape", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmnuTapeLoadIntoEmulator_DropDownOpening(object sender, EventArgs e)
        {
            cmnuTapeLoadIntoEmulatorPravetz.Font = new Font(cmnuTapeLoadIntoEmulatorPravetz.Font, (Configuration.Persistent.DefaultMachineForTape == Machine.Pravetz ? FontStyle.Bold : FontStyle.Regular));
            cmnuTapeLoadIntoEmulatorOric1.Font = new Font(cmnuTapeLoadIntoEmulatorOric1.Font, (Configuration.Persistent.DefaultMachineForTape == Machine.Oric1 ? FontStyle.Bold : FontStyle.Regular));
            cmnuTapeLoadIntoEmulatorAtmos.Font = new Font(cmnuTapeLoadIntoEmulatorAtmos.Font, (Configuration.Persistent.DefaultMachineForTape == Machine.Atmos ? FontStyle.Bold : FontStyle.Regular));
        }

        private void cmnuTapeLoadIntoEmulatorPravetz_Click(object sender, EventArgs e)
        {
            LoadTapeInEmulator(Machine.Pravetz);
        }

        private void cmnuTapeLoadIntoEmulatorOric1_Click(object sender, EventArgs e)
        {
            LoadTapeInEmulator(Machine.Oric1);
        }

        private void cmnuTapeLoadIntoEmulatorAtmos_Click(object sender, EventArgs e)
        {
            LoadTapeInEmulator(Machine.Atmos);
        }

        public void LoadTapeInEmulator(Machine machineType)
        {
            TapeInfo tapeInfo = (TapeInfo)fileListForm.tvwFileList.SelectedNode.Tag;

            string machineName = "";

            if (machineType == Machine.Oric1)
            {
                machineName = "oric1";
            }
            else if (machineType == Machine.Atmos)
            {
                machineName = "atmos";
            }
            else if (machineType == Machine.Pravetz)
            {
                machineName = "pravetz";
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Configuration.Persistent.EmulatorExecutable,
                    WorkingDirectory = Path.GetDirectoryName(Configuration.Persistent.EmulatorExecutable),
                    WindowStyle = ProcessWindowStyle.Normal,
                    Arguments = string.Format("--machine {0} --tape \"{1}\"", machineName, tapeInfo.FullName)
                };

                Process.Start(startInfo);
            }
            catch (Exception)
            {
                string errorMessage = "Failed to start the Emulator.\r\n\r\nPlease check the Emulator location in Settings.";
                MessageBox.Show(errorMessage, "Run in Emulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Rom Context Menu
        private void cmnuRomViewRom_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

            if (selectedNode == null || selectedNode.Tag == null)
                return;

            DisplayROMContents((RomInfo)selectedNode.Tag);
        }
        #endregion

        #region Program Context Menu
        private void cmnuProgram_Opening(object sender, CancelEventArgs e)
        {
            // Check we have a valid node
            if(fileListForm.tvwFileList.SelectedNode.Tag == null)
                return;

            // Retrieve program information for the selected node
            OricFileInfo ProgramInfo = (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag;

            if (ProgramInfo.MediaType == ConstantsAndEnums.MediaType.TapeFile)
            {
                //TapeInfo TapeDetails = (TapeInfo)fileListForm.treeFileList.SelectedNode.Parent.Tag;

                /*if (TapeDetails.FileCount == 1)
                {
                    progContextMenuStrip.Items[11].Enabled = false;
                }
                else
                {
                    progContextMenuStrip.Items[11].Enabled = true;
                }*/
            }

            //progContextMenuStrip.Items[3].Enabled = true;
            //progContextMenuStrip.Items[4].Enabled = false;

            // Enable or Disable the Edit file menu option
            /*switch (ProgramInfo.Format)
            {
                case OricProgram.ProgramFormat.BasicProgram:
                    progContextMenuStrip.Items[4].Text = "Open BASIC Editor...";
                    progContextMenuStrip.Items[4].Enabled = true;
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                case OricProgram.ProgramFormat.HelpFile:
                    progContextMenuStrip.Items[4].Text = "Open Text Screen Editor...";
                    progContextMenuStrip.Items[4].Enabled = true;
                    break;

                default:
                    progContextMenuStrip.Items[4].Text = "Open Editor...";
                    progContextMenuStrip.Items[4].Enabled = false;
                    break;
            }*/

            // Enable/Disable the 'Delete' option
            //progContextMenuStrip.Items[7].Enabled = false;

            /*if (ProgramInfo.AutoRun == OricProgram.AutoRunFlag.Enabled)
            {
                enableToolStripMenuItem.Enabled = false;
                disableToolStripMenuItem.Enabled = true;
            }
            else
            {
                enableToolStripMenuItem.Enabled = true;
                disableToolStripMenuItem.Enabled = false;
            }*/
        }

        private void cmnuProgramViewFile_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

            if (selectedNode == null || selectedNode.Tag == null)
                return;

            DisplayFileContents((OricFileInfo)selectedNode.Tag);
        }

        private void cmnuProgramOpenDataViewer_Click(object sender, EventArgs e)
        {
            OricFileInfo oricFileInfo = (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag;

            OricProgram loadedProgram = new OricProgram();
            loadedProgram.New();

            switch (oricFileInfo.MediaType)
            {
                case ConstantsAndEnums.MediaType.TapeFile:
                    // Load the selected program from Tape
                    OricTape oricTape = new OricTape();
                    loadedProgram = oricTape.Load(Path.Combine(oricFileInfo.Folder, oricFileInfo.ParentName),
                                                  oricFileInfo.ProgramName, oricFileInfo.ProgramIndex);
                    break;

                case ConstantsAndEnums.MediaType.DiskFile:
                    loadedProgram = oricFileInfo.LoadFile();
                    break;

                default:
                    break;
            }

            frmDataViewer dataViewerForm = new frmDataViewer(oricFileInfo, loadedProgram);
            dataViewerForm.ShowDialog();
        }

        private void cmnuProgramOpenEditor_Click(object sender, EventArgs e)
        {
            // Determine what type of file has been selected and open the required Editor
            OricFileInfo fileInfo = (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag;
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Parent.Tag;

            switch (fileInfo.Format)
            {
                case OricProgram.ProgramFormat.BasicProgram:
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    break;

                case OricProgram.ProgramFormat.BinaryFile:
                    break;

                case OricProgram.ProgramFormat.DirectAccessFile:
                    break;

                case OricProgram.ProgramFormat.HiresScreen:
                    break;

                case OricProgram.ProgramFormat.SequentialFile:
                    break;

                case OricProgram.ProgramFormat.HelpFile:
                case OricProgram.ProgramFormat.TextScreen:
                case OricProgram.ProgramFormat.WindowFile:
                    using (frmTextScreenEditor textEditor = new frmTextScreenEditor())
                    {
                        textEditor.fileInfo = fileInfo;
                        textEditor.diskInfo = diskInfo;
                        textEditor.mediaType = ConstantsAndEnums.MediaType.DiskFile;

                        DialogResult dialogResult = textEditor.ShowDialog();
                    }
                    break;

                case OricProgram.ProgramFormat.UnknownFile:
                    break;

                default:
                    break;
            }
        }

        private void cmnuProgramDelete_Click(object sender, EventArgs e)
        {
            // Check that we have actually selected a file first
            if (fileListForm.tvwFileList.SelectedNode.Tag == null)
            {
                return;
            }

            // Take a copy of the selected node
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

            // Get response from the user to check that they really do want to delete the file
            string strMessage = string.Format("Are you sure you want to delete the file '{0}' from the Disk?", selectedNode.Text);
            DialogResult dialogResult = MessageBox.Show(strMessage, "Confirm Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Users wants to delete the selected file
            if (dialogResult == DialogResult.Yes)
            {
                // Tag contains details of the selected file
                OricFileInfo programInfo = (OricFileInfo)selectedNode.Tag;

                // Check what it is we are trying to delete
                switch (programInfo.MediaType)
                {
                    case ConstantsAndEnums.MediaType.TapeFile:
                        // Not currently implemented
                        break;

                    case ConstantsAndEnums.MediaType.DiskFile:
                        OricDiskInfo diskInfo = new OricDiskInfo(programInfo.ParentName);

                        if (diskInfo.DeleteFile(programInfo.ParentName, programInfo.ProgramName))
                        {
                            string message = string.Format("File {0} was deleted successfully", programInfo.Name);
                            MessageBox.Show(message, "Delete File", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            selectedNode.Remove();

                            // Update the disk in the tree
                            //UpdateTreeNode(selectedNode);

                            /*TreeNode parentNode = selectedNode.Parent;
                            foreach (TreeNode childNode in parentNode.Nodes)
                            {
                                childNode.Remove();

                                lblStatusMain.Text = "D
                            }*/
                        }
                        else
                        {
                            string message = string.Format("Failed to deleted {0}", programInfo.Name);
                            MessageBox.Show(message, "Delete File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void cmnuProgramExtractToTapeFile_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Tape, (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag);
        }

        private void cmnuProgramExtractToTextFile_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Text, (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag);
        }

        private void cmnuProgramExtractToRawFile_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Raw, (OricFileInfo)fileListForm.tvwFileList.SelectedNode.Tag);
        }

        private void exportFile(ExportTo exportTo, OricFileInfo fileInfo)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Export file to",
                FileName = Path.GetFileNameWithoutExtension(fileInfo.ProgramName)
            };

            switch (exportTo)
            {
                case ExportTo.Tape:
                    saveFileDialog.Filter = "Tape file|*.tap";
                    break;

                case ExportTo.Text:
                    saveFileDialog.Filter = "Text file|*.txt";
                    break;

                case ExportTo.Raw:
                    saveFileDialog.Filter = "Data file|*.dat|Binary file|*.bin";
                    break;

                default:
                    saveFileDialog.Filter = "All files|*.*";
                    break;

            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load into memory
                OricProgram program = fileInfo.LoadFile();

                switch (exportTo)
                {
                    case ExportTo.Tape:
                        {
                            // Setup name of the Tape
                            if (string.IsNullOrEmpty(fileInfo.Name))
                            {
                                program.ProgramName = "NONAME";
                            }
                            else
                            {
                                program.ProgramName = string.Format("{0}.{1}", fileInfo.Name, fileInfo.Extension);
                            }

                            // Create a new tape file
                            OricTape tape = new OricTape
                            {
                                TapeName = saveFileDialog.FileName
                            };
                            tape.SaveFile(program);
                        }
                        break;

                    case ExportTo.Text:
                        using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                        {
                            if (program.Format == OricProgram.ProgramFormat.BasicProgram)
                            {
                                sw.Write(program.ListBasicSourceAsText());
                            }
                            else
                            {
                                sw.Write(program.HexDump());
                            }
                        }
                        break;

                    case ExportTo.Raw:
                        Encoding utf8 = Encoding.UTF8;

                        // Create a new binary file
                        using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create), utf8))
                        {
                            bw.Write(program.ProgramData);
                        }
                        break;

                    default:
                        break;
                }

                MessageBox.Show("Exported successfully", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Unknown Disk Context Menu
        private void cmnuUnknownDiskRawDataViewer_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.tvwFileList.SelectedNode.Tag;
            DisplayUnknownDisk(diskInfo);
        }

        private void cmnuUnknownDiskLoadIntoEmulatorPravetz_Click(object sender, EventArgs e)
        {
            LoadDiskInEmulator(Machine.Pravetz);
        }

        private void cmnuUnknownDiskLoadIntoEmulatorOric1_Click(object sender, EventArgs e)
        {
            LoadDiskInEmulator(Machine.Oric1);
        }

        private void cmnuUnknownDiskLoadIntoEmulatorAtmos_Click(object sender, EventArgs e)
        {
            LoadDiskInEmulator(Machine.Atmos);
        }

        private void cmnuUnknownDiskLoadIntoEmulatorTelestrat_Click(object sender, EventArgs e)
        {
            LoadDiskInEmulator(Machine.Telestrat);
        }
        #endregion

        #region Other Files Context Menu
        private void cmnuOtherFilesViewFile_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;

            if (selectedNode == null || selectedNode.Tag == null)
                return;

            DisplayOtherFileContents((OtherFileInfo)selectedNode.Tag);
        }
        #endregion

        #region Folder Context Menu
        private void cmnuFolderOpenInExplorer_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.tvwFileList.SelectedNode;
            Process.Start(Environment.ExpandEnvironmentVariables(@"%windir%\explorer.exe"), $"\"{selectedNode.ToolTipText}\"");
        }
        #endregion

        #region File Tree Functions
        // Create a node sorter that implements the IComparer interface.
        public class NodeSortedByName : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                if (tx.Tag != null && ty.Tag != null)
                {
                    if (tx.Tag.GetType() == typeof(OricFileInfo))
                    {
                        OricFileInfo catalogX = (OricFileInfo)tx.Tag;

                        if (catalogX.MediaType == MediaType.TapeFile)
                        {
                            return 0;
                        }

                        return -string.Compare(ty.Text, tx.Text);
                    }

                    return -string.Compare(ty.Text, tx.Text);
                }

                return 0;
            }
        }

        public class NodeSortedByExtension : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                if (tx.Tag != null && ty.Tag != null)
                {
                    if (tx.Tag.GetType() == typeof(OricFileInfo))
                    {
                        OricFileInfo catalogX = (OricFileInfo)tx.Tag;

                        if (catalogX.MediaType == MediaType.TapeFile)
                        {
                            return 0;
                        }

                        OricFileInfo catalogY = (OricFileInfo)ty.Tag;

                        string textX = catalogX.Extension + catalogX.ProgramName;
                        string textY = catalogY.Extension + catalogY.ProgramName;

                        return -string.Compare(textY, textX);
                    }

                    return -string.Compare(ty.Text, tx.Text);
                }

                return 0;
            }
        }

        public class NodeSortedByType : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                if (tx.Tag != null && ty.Tag != null)
                {
                    if (tx.Tag.GetType() == typeof(OricFileInfo))
                    {
                        OricFileInfo catalogX = (OricFileInfo)tx.Tag;

                        if (catalogX.MediaType == MediaType.TapeFile)
                        {
                            return 0;
                        }

                        OricFileInfo catalogY = (OricFileInfo)ty.Tag;

                        string textX = catalogX.Format.ToString();
                        string textY = catalogY.Format.ToString();

                        return -string.Compare(textY, textX);
                    }

                    return -string.Compare(ty.Text, tx.Text);
                }

                return 0;
            }
        }

        private TreeNode AddNodeToTree(string newNodeText, TreeNode parentNode, int nodeImage, string nodeTooltip)
        {
            TreeNode newNode = parentNode.Nodes.Add(newNodeText);
            newNode.Name = newNodeText;
            newNode.ImageIndex = nodeImage;
            newNode.SelectedImageIndex = nodeImage;
            newNode.ToolTipText = nodeTooltip;
            newNode.ForeColor = Color.White;

            return newNode;
        }

        private TreeNode AddNodeToTree(string newNodeText, TreeNode parentNode, int nodeImage, string nodeTooltip, Color nodeColor)
        {
            TreeNode newNode = parentNode.Nodes.Add(newNodeText);
            newNode.Name = newNodeText;
            newNode.ImageIndex = nodeImage;
            newNode.SelectedImageIndex = nodeImage;
            newNode.ToolTipText = nodeTooltip;
            newNode.ForeColor = nodeColor;

            return newNode;
        }

        private void BuildFileTree()
        {
            Stopwatch processTimer = new Stopwatch();
            processTimer.Start();

            // Disable tree updates
            fileListForm.tvwFileList.BeginUpdate();

            // Add the root node to the tree
            rootNode = fileListForm.tvwFileList.Nodes.Add("Oric Files");
            rootNode.ImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("root");//0

            // Add file type nodes to the tree
            diskTreeNode = AddNodeToTree("Disks", rootNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk"), "Oric Disks");
            tapeTreeNode = AddNodeToTree("Tapes", rootNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("tape"), "Oric Tapes");
            romTreeNode = AddNodeToTree("ROM's", rootNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("rom"), "ROM Files");
            otherFileTreeNode = AddNodeToTree("Other files", rootNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("other_file"), "Other Files");

            if (!Configuration.Persistent.DisksTree)
            {
                ftDosGroupNode = AddNodeToTree("FT-Dos", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "FT-Dos Disks");
                oricDosGroupNode = AddNodeToTree("OricDOS", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "OricDOS Disks");
                sedOricGroupNode = AddNodeToTree("SedOric", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "SedOric Disks");
                stratSedGroupNode = AddNodeToTree("Stratsed", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "Stratsed Disks");
                xlDosGroupNode = AddNodeToTree("XL-Dos", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "XL-Dos Disks");
                unknownGroupNode = AddNodeToTree("Unknown", diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "Unknown disk formats", Color.FromArgb(246, 174, 1));
            }

            if (Configuration.Persistent.TapesIndex)
            {
                // Add tape grouping nodes to the tree
                AddNodeToTree("0-9", tapeTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "");

                // Adds alphabetic grouping to the tree
                for (int iIndex = 0; iIndex < 26; iIndex++)
                {
                    char ch = (char)(iIndex + 65);
                    AddNodeToTree(ch.ToString(), tapeTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "");
                }

                // Add tape grouping nodes to the tree
                AddNodeToTree("Other", tapeTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), "Tapes that don't fit anywhere else.");
            }

            // Create instance of the scanner form and initialise settings
            using (frmFileScan fileScanForm = new frmFileScan(this))
            {
                // Display the Scanner form
                fileScanForm.ShowDialog();
                fileScanForm.Dispose();
            }


            // remove empty nodes
            List<TreeNode> nodContainers = new List<TreeNode>() { ftDosGroupNode, xlDosGroupNode, sedOricGroupNode, stratSedGroupNode, oricDosGroupNode, unknownGroupNode, diskTreeNode, romTreeNode, otherFileTreeNode };
            if (Configuration.Persistent.TapesIndex)
            {
                nodContainers.AddRange(tapeTreeNode.Nodes.Cast<TreeNode>());
            }
            nodContainers.Add(tapeTreeNode);
            foreach (TreeNode node in nodContainers)
            {
                if (node != null && node.Nodes.Count == 0)
                {
                    node.Remove();
                }
            }

            // Expand all of the TreeView nodes.
            rootNode.Expand();

            // Resume tree updates
            fileListForm.tvwFileList.EndUpdate();

            processTimer.Stop();

            TimeSpan timeSpan = processTimer.Elapsed;

            string oTimeSpan;

            if (timeSpan.Minutes < 1)
            {
                oTimeSpan = string.Format("Media scanned in {0}.{1,2} seconds", timeSpan.Seconds, timeSpan.Milliseconds);
            }
            else
            {
                oTimeSpan = string.Format("Media scanned in {0} mins {1,2}.{2,2} seconds", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            }

            // Remember entire tree for filter
            fileListForm.tvwFileList.Tag = rootNode.Clone();

            tsslStatusMain.Text = oTimeSpan;
        }

        public TreeNode AddDiskToTree(FileInfo fileInfo, string baseFolder = null, TreeNode sourceNode = null)
        {
            TreeNode parentNode;
            int nodeImageIndex;

            OricDiskInfo diskInfo = new OricDiskInfo(fileInfo.FullName);

            if (sourceNode != null)
            {
                parentNode = sourceNode;
            }
            else if (Configuration.Persistent.DisksTree)
            {
                if (Configuration.Persistent.DiskFolders.Count > 1)
                {
                    if (diskTreeNode.Nodes.ContainsKey(baseFolder))
                    {
                        parentNode = diskTreeNode.Nodes[baseFolder];
                    }
                    else
                    {
                        parentNode = AddNodeToTree(baseFolder, diskTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), baseFolder);
                        parentNode.ContextMenuStrip = cmnuFolder;
                    }
                }
                else
                {
                    parentNode = diskTreeNode;
                }

                string strPath = fileInfo.DirectoryName.Substring(baseFolder.Length);

                if (strPath.Length > 0)
                {
                    string strFullpath = baseFolder;
                    string[] folders = strPath.TrimStart(new char[] { '\\' }).Split(new char[] { '\\' });
                    foreach (string folder in folders)
                    {
                        strFullpath = Path.Combine(strFullpath, folder);

                        if (parentNode.Nodes.ContainsKey(folder))
                        {
                            parentNode = parentNode.Nodes[folder];
                        }
                        else
                        {
                            parentNode = AddNodeToTree(folder, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), strFullpath);
                            parentNode.ContextMenuStrip = cmnuFolder;
                        }
                    }
                }
            }
            else
            {
                switch (diskInfo.DOSFormat)
                {
                    case OricDisk.DOSFormats.TDOS:
                        parentNode = ftDosGroupNode;
                        break;

                    case OricDisk.DOSFormats.OricDOS:
                        parentNode = oricDosGroupNode;
                        break;

                    case OricDisk.DOSFormats.SedOric:
                        parentNode = sedOricGroupNode;
                        break;

                    case OricDisk.DOSFormats.StratSed:
                        parentNode = stratSedGroupNode;
                        break;

                    case OricDisk.DOSFormats.XLDos:
                        parentNode = xlDosGroupNode;
                        break;

                    default:
                        parentNode = unknownGroupNode;
                        break;
                }
            }
            

            if (diskInfo.DOSFormat == OricDisk.DOSFormats.Unknown)
            {
                nodeImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk_hs");
            }
            else
            {
                switch (diskInfo.DiskType)
                {
                    case OricDisk.DiskTypes.Master:
                        nodeImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk_master");
                        break;

                    case OricDisk.DiskTypes.Slave:
                        nodeImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk_slave");
                        break;

                    case OricDisk.DiskTypes.Game:
                        nodeImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk_game");
                        break;

                    default:
                        nodeImageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("disk_unknown");
                        break;
                }
            }

            TreeNode newDiskTreeNode = AddNodeToTree(fileInfo.Name, parentNode, nodeImageIndex, "");

            if (newDiskTreeNode != null)
            {
                newDiskTreeNode.Tag = diskInfo;

                if (diskInfo.DOSFormat == OricDisk.DOSFormats.Unknown)
                {
                    // Add rightclick context menu to disk
                    newDiskTreeNode.ContextMenuStrip = cmnuUnknownDisk;
                }
                else
                {
                    // Add rightclick context menu to disk
                    newDiskTreeNode.ContextMenuStrip = cmnuDisk;

                    // Add files to disk branch
                    OricFileInfo[] fileList = diskInfo.GetFiles();

                    if (fileList.Length > 0)
                    {
                        AddDirectoryToDiskBranch(newDiskTreeNode, fileList);
                    }

                    // Build the Tooltip string
                    StringBuilder stbToolTip = new StringBuilder();

                    stbToolTip.AppendFormat("Filename\t: {0}\r\n", Path.GetFileName(fileInfo.FullName));
                    stbToolTip.AppendFormat("Folder\t\t: {0}\r\n\r\n", Path.GetDirectoryName(fileInfo.FullName));

                    stbToolTip.AppendFormat("Disk name\t: {0}\r\n", diskInfo.DiskName);
                    stbToolTip.AppendFormat("Disk type\t: {0}\r\n", diskInfo.DiskType.ToString());
                    stbToolTip.AppendFormat("DOS Format\t: {0}\r\n", diskInfo.DOSFormat.ToString());
                    stbToolTip.AppendFormat("DOS Version\t: {0}\r\n\r\n", diskInfo.DosVersion());

                    if (diskInfo.Sides == 1)
                    {
                        stbToolTip.Append("Structure\t: Single sided, ");
                    }
                    else
                    {
                        stbToolTip.Append("Structure\t: Double sided, ");
                    }

                    stbToolTip.AppendFormat("{0} tracks per side, {1} sectors per track\r\n", diskInfo.TracksPerSide, diskInfo.SectorsPerTrack);
                    stbToolTip.Append("Usage\t\t: ");

                    if (fileList.Length > 0)
                    {
                        stbToolTip.AppendFormat("{0} files, ", fileList.Length);
                    }

                    stbToolTip.AppendFormat("{0:N0} sectors used, {1:N0} free, out of {2:N0}\r\n",
                                            diskInfo.SectorsUsed, diskInfo.SectorsFree, diskInfo.Sectors);

                    if (diskInfo.Sectors > 0)
                    {
                        float flPercentageFree = diskInfo.SectorsFree;
                        flPercentageFree = (float)(flPercentageFree / diskInfo.Sectors);
                        flPercentageFree *= 100;

                        stbToolTip.AppendFormat("Percent Free\t: {0:N0}%\r\n", flPercentageFree);
                    }

                    stbToolTip.AppendFormat("\r\nCreated\t\t: {0}, {1}\r\n", fileInfo.CreationTime.ToLongDateString(), fileInfo.CreationTime.ToLongTimeString());
                    stbToolTip.AppendFormat("Modified\t: {0}, {1}", fileInfo.LastWriteTime.ToLongDateString(), fileInfo.LastWriteTime.ToLongTimeString());

                    newDiskTreeNode.ToolTipText = stbToolTip.ToString();
                }
            }

            return newDiskTreeNode;
        }

        private void AddDirectoryToDiskBranch(TreeNode diskNode, OricFileInfo[] Directory)
        {
            foreach (OricFileInfo programInfo in Directory)
            {
                int imageIndex = DetermineIcon(programInfo);

                TreeNode ProgramNode = AddNodeToTree(programInfo.ProgramName, diskNode, imageIndex, "");
                ProgramNode.Tag = programInfo;
                //ProgramNode.ImageIndex = imageIndex;
                ProgramNode.ContextMenuStrip = cmnuProgram;

                StringBuilder stbToolTip = new StringBuilder();
                stbToolTip.AppendFormat("Name\t: {0}\r\n", programInfo.ProgramName);
                stbToolTip.AppendFormat("Format\t: {0}\r\n", programInfo.FormatToString());

                if (programInfo.Format == OricProgram.ProgramFormat.DirectAccessFile)
                {
                    stbToolTip.AppendFormat("Records\t: {0:N0}\r\n", programInfo.NoOfRecords);
                    stbToolTip.AppendFormat("Length\t: {0:N0}\r\n", programInfo.RecordLength);
                }
                else
                {
                    stbToolTip.AppendFormat("Address\t: ${0:X4} - ${1:X4}\r\n", programInfo.StartAddress, programInfo.EndAddress);

                    if (programInfo.StartAddress > programInfo.EndAddress)
                    {
                        // Problem with address values
                        stbToolTip.Append("Length\t: Address Error\r\n");
                    }
                    else
                    {
                        if (programInfo.LengthBytes >= 1024)
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes ({1:N1} KB)\r\n", programInfo.LengthBytes, (float)programInfo.LengthBytes / 1024);
                        }
                        else
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes\r\n", programInfo.LengthBytes);
                        }
                    }

                    stbToolTip.AppendFormat("Size\t: {0} sectors\r\n", programInfo.LengthSectors);
                }

                stbToolTip.AppendFormat("Status\t: {0}", programInfo.Protection.ToString());

                if (programInfo.Format == OricProgram.ProgramFormat.BasicProgram ||
                    programInfo.Format == OricProgram.ProgramFormat.BinaryFile)
                {
                    stbToolTip.AppendFormat("\r\nAuto\t: {0}", programInfo.AutoRun.ToString());
                }

                ProgramNode.ToolTipText = stbToolTip.ToString();
            }
        }

        private int DetermineIcon(OricFileInfo FileInfo)
        {
            int imageIndex;

            switch (FileInfo.Format)
            {
                case OricProgram.ProgramFormat.BasicProgram:
                case OricProgram.ProgramFormat.HyperbasicProgram:
                case OricProgram.ProgramFormat.TeleassSource:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("text");
                    break;
                case OricProgram.ProgramFormat.BinaryFile:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("binary");
                    break;
                case OricProgram.ProgramFormat.CharacterSet:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("font");
                    break;
                case OricProgram.ProgramFormat.DirectAccessFile:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("direct");
                    break;
                case OricProgram.ProgramFormat.HiresScreen:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("image_hires");
                    break;
                case OricProgram.ProgramFormat.SequentialFile:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("sequential");
                    break;
                case OricProgram.ProgramFormat.TextScreen:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("image_text");
                    break;
                case OricProgram.ProgramFormat.WindowFile:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("image_text");
                    break;
                case OricProgram.ProgramFormat.HelpFile:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("helpdoc");
                    break;
                default:
                    imageIndex = fileListForm.tvwFileList.ImageList.Images.IndexOfKey("image_unknown");
                    break;
            }

            return imageIndex;
        }

        public TreeNode AddTapeToTree(FileInfo fileInfo, string baseFolder = null, TreeNode sourceNode = null)
        {
            TreeNode tapeNode = null;

            OricTape oricTape = new OricTape();
            OricFileInfo[] tapeCatalog = oricTape.Catalog(fileInfo);

            if (tapeCatalog.Length > 0)
            {
                TreeNode parentNode;

                if (sourceNode != null)
                {
                    parentNode = sourceNode;
                }
                else if (Configuration.Persistent.TapesTree)
                {
                    if (Configuration.Persistent.TapeFolders.Count > 1)
                    {
                        if (tapeTreeNode.Nodes.ContainsKey(baseFolder))
                        {
                            parentNode = tapeTreeNode.Nodes[baseFolder];
                        }
                        else
                        {
                            parentNode = AddNodeToTree(baseFolder, tapeTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), baseFolder);
                            parentNode.ContextMenuStrip = cmnuFolder;
                        }
                    }
                    else
                    {
                        parentNode = tapeTreeNode;
                    }

                    string strPath = fileInfo.DirectoryName.Substring(baseFolder.Length);

                    if (strPath.Length > 0)
                    {
                        string strFullpath = baseFolder;
                        string[] folders = strPath.TrimStart(new char[] { '\\' }).Split(new char[] { '\\' });
                        foreach (string folder in folders)
                        {
                            strFullpath = Path.Combine(strFullpath, folder);
                            
                            if (parentNode.Nodes.ContainsKey(folder))
                            {
                                parentNode = parentNode.Nodes[folder];
                            }
                            else
                            {
                                parentNode = AddNodeToTree(folder, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), strFullpath);
                                parentNode.ContextMenuStrip = cmnuFolder;
                            }
                        }
                    }
                }
                else if (Configuration.Persistent.TapesIndex)
                {
                    char firstCharacter = Convert.ToChar(fileInfo.Name.Substring(0, 1));

                    if (Char.IsLetter(firstCharacter))
                    {
                        parentNode = tapeTreeNode.Nodes[firstCharacter.ToString()];
                    }
                    else if (Char.IsDigit(firstCharacter))
                    {
                        parentNode = tapeTreeNode.Nodes["0-9"];
                    }
                    else
                    {
                        parentNode = tapeTreeNode.Nodes["Other"];
                    }
                }
                else
                {
                    parentNode = tapeTreeNode;
                }

                if (parentNode != null)
                {
                    tapeNode = AddNodeToTree(fileInfo.Name, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("tape"), "");
                }

                if (tapeNode != null)
                {
                    tapeNode.ContextMenuStrip = cmnuTape;

                    StringBuilder stbToolTip = new StringBuilder();
                    stbToolTip.AppendFormat("Name\t\t: {0}\r\n", fileInfo.Name);
                    stbToolTip.AppendFormat("Folder\t\t: {0}\r\n\r\n", fileInfo.DirectoryName);
                    stbToolTip.AppendFormat("No. of files\t: {0}\r\n", tapeCatalog.Length);

                    if (fileInfo.Length >= 1024)
                    {
                        stbToolTip.AppendFormat("Length\t\t: {0:N0} bytes ({1:N1} KB)\r\n", fileInfo.Length, (float)fileInfo.Length / 1024);
                    }
                    else
                    {
                        stbToolTip.AppendFormat("Length\t\t: {0:N0} bytes\r\n", fileInfo.Length);
                    }

                    stbToolTip.AppendFormat("\r\nLast modified\t: {0}, {1}",
                                                 fileInfo.LastWriteTime.ToLongDateString(),
                                                 fileInfo.LastWriteTime.ToLongTimeString());

                    tapeNode.ToolTipText = stbToolTip.ToString();

                    TapeInfo tapeInfo = new TapeInfo(fileInfo.FullName)
                    {
                        FileCount = (ushort)tapeCatalog.Length,
                    };

                    tapeNode.Tag = tapeInfo;

                    foreach (OricFileInfo programInfo in tapeCatalog)
                    {
                        int imageIndex = DetermineIcon(programInfo);

                        TreeNode progNode = AddNodeToTree(programInfo.ProgramName, tapeNode, imageIndex, "");
                        progNode.Tag = programInfo;
                        //progNode.ImageIndex = imageIndex;
                        progNode.ContextMenuStrip = cmnuProgram;

                        stbToolTip.Length = 0;

                        stbToolTip.AppendFormat("Name\t: {0}\r\n", programInfo.ProgramName);
                        stbToolTip.AppendFormat("Format\t: {0}\r\n", programInfo.FormatToString());
                        stbToolTip.AppendFormat("Address\t: ${0:X4} - ${1:X4}\r\n", programInfo.StartAddress, programInfo.EndAddress);

                        if (programInfo.LengthBytes >= 1024)
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes ({1:N1} KB)\r\n", programInfo.LengthBytes, (float)programInfo.LengthBytes / 1024);
                        }
                        else
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes\r\n", programInfo.LengthBytes, programInfo.LengthBytes / 1024);
                        }

                        stbToolTip.AppendFormat("Status\t: Auto Run is {0}", programInfo.AutoRun.ToString());

                        progNode.ToolTipText = stbToolTip.ToString();
                    }
                }
            }

            return tapeNode;
        }

        public TreeNode AddRomToTree(FileInfo fileInfo, string baseFolder)
        {
            TreeNode parentNode;

            if (Configuration.Persistent.ROMsTree)
            {
                if (Configuration.Persistent.RomFolders.Count > 1)
                {
                    if (romTreeNode.Nodes.ContainsKey(baseFolder))
                    {
                        parentNode = romTreeNode.Nodes[baseFolder];
                    }
                    else
                    {
                        parentNode = AddNodeToTree(baseFolder, romTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), baseFolder);
                        parentNode.ContextMenuStrip = cmnuFolder;
                    }
                }
                else
                {
                    parentNode = romTreeNode;
                }

                string strPath = fileInfo.DirectoryName.Substring(baseFolder.Length);

                if (strPath.Length > 0)
                {
                    string strFullpath = baseFolder;
                    string[] folders = strPath.TrimStart(new char[] { '\\' }).Split(new char[] { '\\' });
                    foreach (string folder in folders)
                    {
                        strFullpath = Path.Combine(strFullpath, folder);

                        if (parentNode.Nodes.ContainsKey(folder))
                        {
                            parentNode = parentNode.Nodes[folder];
                        }
                        else
                        {
                            parentNode = AddNodeToTree(folder, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), strFullpath);
                            parentNode.ContextMenuStrip = cmnuFolder;
                        }
                    }
                }
            }
            else
            {
                parentNode = romTreeNode;
            }

            TreeNode romNode = AddNodeToTree(fileInfo.Name, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("rom"), "");

            if (romNode != null)
            {
                romNode.ContextMenuStrip = cmnuRom;

                StringBuilder romToolTipText = new StringBuilder();
                romToolTipText.AppendFormat("Name\t\t: {0}\r\n", fileInfo.Name);
                romToolTipText.AppendFormat("Folder\t\t: {0}\r\n\r\n", fileInfo.DirectoryName);

                if (fileInfo.Length >= 1024)
                {
                    romToolTipText.AppendFormat("Length\t\t: {0:N0} bytes ({1:N1} KB)\r\n", fileInfo.Length, (float)fileInfo.Length / 1024);
                }
                else
                {
                    romToolTipText.AppendFormat("Length\t\t: {0:N0} bytes\r\n", fileInfo.Length);
                }

                romToolTipText.AppendFormat("\r\nLast modified\t: {0}, {1}",
                                                fileInfo.LastWriteTime.ToLongDateString(),
                                                fileInfo.LastWriteTime.ToLongTimeString());

                romNode.ToolTipText = romToolTipText.ToString();

                RomInfo romInfo = new RomInfo(fileInfo.FullName);

                romNode.Tag = romInfo;
            }

            return romNode;
        }

        public TreeNode AddOtherFileToTree(FileInfo fileInfo, string baseFolder)
        {
            TreeNode parentNode;

            if (Configuration.Persistent.OtherFilesTree)
            {
                if (Configuration.Persistent.OtherFilesFolders.Count > 1)
                {
                    if (otherFileTreeNode.Nodes.ContainsKey(baseFolder))
                    {
                        parentNode = otherFileTreeNode.Nodes[baseFolder];
                    }
                    else
                    {
                        parentNode = AddNodeToTree(baseFolder, otherFileTreeNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), baseFolder);
                        parentNode.ContextMenuStrip = cmnuFolder;
                    }
                }
                else
                {
                    parentNode = otherFileTreeNode;
                }

                string strPath = fileInfo.DirectoryName.Substring(baseFolder.Length);

                if (strPath.Length > 0)
                {
                    string strFullpath = baseFolder;
                    string[] folders = strPath.TrimStart(new char[] { '\\' }).Split(new char[] { '\\' });
                    foreach (string folder in folders)
                    {
                        strFullpath = Path.Combine(strFullpath, folder);

                        if (parentNode.Nodes.ContainsKey(folder))
                        {
                            parentNode = parentNode.Nodes[folder];
                        }
                        else
                        {
                            parentNode = AddNodeToTree(folder, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("folder"), strFullpath);
                            parentNode.ContextMenuStrip = cmnuFolder;
                        }
                    }
                }
            }
            else
            {
                parentNode = otherFileTreeNode;
            }
            
            TreeNode otherFileNode = AddNodeToTree(fileInfo.Name, parentNode, fileListForm.tvwFileList.ImageList.Images.IndexOfKey("other_file"), "");

            if (otherFileNode != null)
            {
                OtherFileInfo otherFileInfo = new OtherFileInfo(fileInfo.FullName);

                otherFileNode.ContextMenuStrip = cmnuOtherFiles;

                StringBuilder stbToolTipText = new StringBuilder();
                stbToolTipText.Append($"Name\t\t: {fileInfo.Name}\r\n");
                stbToolTipText.Append($"Folder\t\t: {fileInfo.DirectoryName}\r\n\r\n");
                stbToolTipText.Append($"Format\t\t: {otherFileInfo.Format}\r\n");

                ushort ushStartAddress = otherFileInfo.StartAddress;
                ushort ushLength = otherFileInfo.Length;

                if (otherFileInfo.Format == OricProgram.ProgramFormat.OrixProgram)
                {
                    ushStartAddress += OtherFileInfo.ORIX_HEADER_LENGTH;
                    stbToolTipText.Append($"Address\t\t: {ushStartAddress:X4}-{ushStartAddress + ushLength - 1:X4}\r\n");
                }

                if (fileInfo.Length >= 1024)
                {
                    stbToolTipText.Append($"Length\t\t: {ushLength:N0} bytes ({(float)ushLength / 1024:N1} KB)\r\n");
                }
                else
                {
                    stbToolTipText.Append($"Length\t\t: {ushLength:N0} bytes\r\n");
                }

                stbToolTipText.AppendFormat($"\r\nLast modified\t: {fileInfo.LastWriteTime.ToLongDateString()}, {fileInfo.LastWriteTime.ToLongTimeString()}");

                otherFileNode.ToolTipText = stbToolTipText.ToString();

                otherFileNode.Tag = otherFileInfo;
            }

            return otherFileNode;
        }

        /*private void UpdateTreeNode(TreeNode parentNode, OricExplorer.MediaType mediaType)
        {
            parentNode.Remove();

            TreeNode treeNode = new TreeNode();
            FileInfo fiFileInfo;

            if (mediaType == OricExplorer.MediaType.TapeFile)
            {
                fiFileInfo = new FileInfo(Path.Combine(tapeFolder, parentNode.Text));
                treeNode = AddTapeToTree(fiFileInfo);
            }

            treeNode.Expand();
            fileListForm.treeFileList.SelectedNode = treeNode;
        }*/

        /*private void treeFileList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lblStatusMain.Text = "Ready.";

            TreeNode selectedNode = e.Node;
            fileListForm.treeFileList.SelectedNode = selectedNode;

            if ((e.Button != MouseButtons.Left) || (selectedNode == null || selectedNode.Tag == null))
                return;

            string nodeTag = selectedNode.Tag.GetType().ToString();

            switch (nodeTag)
            {
                // Tape display will have it's own user control (yet to be defined)
                case "OricExplorer.TapeInfo":
                    break;

                // Program has been selected display source code
                case "OricExplorer.Catalog":
                    break;

                default:
                    // Unknown type so do nothing
                    break;
            }
        }*/
        #endregion

        #region Disk and Tape Functions
        private void OutputDiskDirectory(TreeNode diskNode)
        {
            // Get DiskInfo
            OricDiskInfo diskInfo = (OricDiskInfo)diskNode.Tag;

            dirListing.WriteLine($"Directory of {Path.GetFileName(diskInfo.FullName)} [{diskInfo.DiskName}]");
            dirListing.WriteLine();

            int totalBytes = 0;

            foreach (TreeNode fileNode in diskNode.Nodes)
            {
                OricFileInfo fileInfo = (OricFileInfo)fileNode.Tag;

                dirListing.WriteLine("{0,-16} {1,-20} {2,10:N0}",
                                     fileInfo.ProgramName, fileInfo.FormatToString(),
                                     fileInfo.LengthBytes);

                totalBytes += fileInfo.LengthBytes;
            }

            dirListing.WriteLine("{0} file(s)    {1:N0} bytes",
                                 diskInfo.FileCount, totalBytes);

            dirListing.WriteLine();
        }

        private void OutputTapeDirectory(TreeNode tapeNode)
        {
            // Get DiskInfo
            TapeInfo tapeInfo = (TapeInfo)tapeNode.Tag;

            dirListing.WriteLine($"Directory of {Path.GetFileName(tapeInfo.FullName)}");
            dirListing.WriteLine();

            int totalBytes = 0;

            foreach (TreeNode fileNode in tapeNode.Nodes)
            {
                OricFileInfo fileInfo = (OricFileInfo)fileNode.Tag;

                dirListing.WriteLine("{0,-16} {1,-20} {2,10:N0}",
                                     fileInfo.ProgramName, fileInfo.FormatToString(),
                                     fileInfo.LengthBytes);

                totalBytes += fileInfo.LengthBytes;
            }

            dirListing.WriteLine("{0} file(s)    {1:N0} bytes",
                                 tapeInfo.FileCount, totalBytes);

            dirListing.WriteLine();
        }

        private bool FindRecursive(TreeNode treeNode, string strSearchString)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                // if the text properties match, color the item
                if (tn.Text == strSearchString)
                {
                    // Remove node
                    tn.Remove();
                    return true;
                }

                FindRecursive(tn, strSearchString);
            }

            return false;
        }

        //private void CopyTapeFilesToTape(TreeNode SourceNode, TreeNode DestNode)
        //{
        //    // Retrieve details of the destination Tape
        //    /*TapeInfo DestTapeInfo = (TapeInfo)DestNode.Tag;

        //    OricTape DestTape = new OricTape();
        //    DestTape.TapeName = tapeFolder + "\\" + DestTapeInfo.Name;

        //    // Copy a file from a Tape
        //    if(SourceNode.Tag.GetType().ToString().Equals("OricExplorer.Catalog"))
        //    {
        //        // Retrieve program information from the source node
        //        OricFileInfo ProgramInfo = (OricFileInfo)SourceNode.Tag;

        //        // Load the program contents from the source tape
        //        OricProgram Program = new OricProgram();
        //        Program = oricTape.Load(tapeFolder + "\\" + ProgramInfo.ParentName,
        //                                ProgramInfo.ProgramName, ProgramInfo.ProgramIndex);

        //        // Copy file to the end of the destination tape
        //        DestTape.SaveFile(Program);
        //    }

        //    // Copy a whole Tape
        //    if(SourceNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
        //    {
        //        // Retrieve information about the source Tape
        //        TapeInfo SourceTapeInfo = (TapeInfo)SourceNode.Tag;

        //        OricTape SourceTape = new OricTape();
        //        SourceTape.TapeName = tapeFolder + "\\" + SourceTapeInfo.Name;

        //        FileInfo fiTapeFile = new FileInfo(SourceTape.TapeName);

        //        // Retrieve a catalog of all the programs on the source Tape
        //        OricFileInfo[] TapeCatalog = SourceTape.Catalog(fiTapeFile);

        //        foreach (OricFileInfo ProgramInfo in TapeCatalog)
        //        {
        //            // Load the program contents from the source tape
        //            OricProgram Program = new OricProgram();
        //            Program = SourceTape.Load(tapeFolder + "\\" + ProgramInfo.ParentName,
        //                                      ProgramInfo.ProgramName, ProgramInfo.ProgramIndex);

        //            // Copy file to the end of the destination tape
        //            DestTape.SaveFile(Program);
        //        }
        //    }

        //    // Get full pathname of the updated destination Tape
        //    FileInfo fiTape = new FileInfo(tapeFolder + "\\" + DestNode.Text);

        //    // Remove destination Tape from Tree list
        //    DestNode.Remove();

        //    // Add the updated Tape to the Tree list and display the files in the Tape
        //    TreeNode NewNode = AddTapeToTree(fiTape);
        //    NewNode.Expand();*/
        //}
        #endregion

        #region Information Display Functions
        private void SetupUserControl(UserControls userControl, bool showSourceCode, OricFileInfo programInfo)
        {
            mainViewControl = new frmMainView(this);

            if (programInfo.MediaType.In(MediaType.DiskFile, MediaType.TapeFile))
            {
                mainViewControl.Text = string.Format("{0} [{1}]", programInfo.ProgramName, programInfo.ParentName);
            }
            else
            {
                mainViewControl.Text = string.Format("{0} [{1}]", Path.GetFileName(programInfo.Name), Path.GetDirectoryName(programInfo.Name));
            }

            mainViewControl.Show(dkpPanel, DockState.Document);

            mainViewControl.UserControl = userControl;
            mainViewControl.ShowSourceCode = showSourceCode;
            mainViewControl.InitialiseView();
        }

        //private void DisplayTapeDetails(TapeInfo tapeInfo)
        //{
        //    StringBuilder stbText = new StringBuilder();
        //    stbText.AppendFormat("{0:N0} files (Tape uses : {1:N0} KB)", tapeInfo.FileCount, (float)tapeInfo.Length / 1024);

        //    lblStatusMain.Text = stbText.ToString();
        //}

        public void DisplayDiskInformation(OricDiskInfo diskInfo)
        {
            using (frmDiskInfoViewer diskInfoViewer = new frmDiskInfoViewer(this))
            {
                diskInfoViewer.DiskPath = diskInfo.FullName;
                diskInfoViewer.ShowDialog();
            }
        }

        public void DisplayUnknownDisk(OricDiskInfo diskInfo)
        {
            using (frmDiskData diskDataForm = new frmDiskData())
            {
                diskDataForm.DiskInfo = diskInfo;
                diskDataForm.ShowDialog();
            }
        }

        public void DisplayROMContents(RomInfo romInfo)
        {
            bool documentOpen = false;

            // Display wait cursor
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;

            //string romName = romInfo.FullName;

            if (dkpPanel.Contents.Count > 1)
            {
                string matchingName = $"{Path.GetFileName(romInfo.FullName)} [{Path.GetDirectoryName(romInfo.FullName)}]";

                foreach (IDockContent item in dkpPanel.Contents)
                {
                    if (item.DockHandler.Form.Text.Equals(matchingName))
                    {
                        item.DockHandler.Activate(); // this will re active if the form already Docked
                        documentOpen = true;
                    }
                }
            }

            if (!documentOpen)
            {
                tsslStatusMain.Text = string.Format("Loading {0}, please wait...", romInfo.FullName);
                Application.DoEvents();

                byte[] romData = File.ReadAllBytes(romInfo.FullName);

                OricFileInfo fileInfo = new OricFileInfo
                {
                    Name = romInfo.FullName,

                    StartAddress = 0xC000,
                    EndAddress = (ushort)(0xC000 + (ushort)(romData.Length - 1)),
                    Format = OricProgram.ProgramFormat.BinaryFile,
                    MediaType = ConstantsAndEnums.MediaType.ROMFile
                };

                SetupUserControl(UserControls.DataViewer, true, fileInfo);

                OricProgram prog = new OricProgram
                {
                    ProgramData = romData,
                    StartAddress = 0xC000,
                    EndAddress = (ushort)(0xC000 + (ushort)(romData.Length - 1)),
                    Format = OricProgram.ProgramFormat.BinaryFile
                };

                mainViewControl.ProgramData = prog;
                mainViewControl.ProgramInfo = fileInfo;
                mainViewControl.DisplayData();

                tsslStatusMain.Text = "Ready.";
            }

            // Display default cursor
            Application.UseWaitCursor = false;
        }

        public void DisplayFileContents(OricFileInfo programInfo, OricProgram.SpecialMode specialMode = OricProgram.SpecialMode.None)
        {
            bool documentOpen = false;

            // Display wait cursor
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;

            if (dkpPanel.Contents.Count > 1)
            {
                // iterate on each mainview object
                foreach (frmMainView mainView in dkpPanel.Contents.OfType<frmMainView>())
                {
                    // is current mainView corresponds to the program to display?
                    if (mainView.ProgramInfo == programInfo)
                    {
                        // yes... so reactive the form already Docked
                        mainView.DockHandler.Activate();
                        documentOpen = true;
                    }
                }
            }

            if (!documentOpen)
            {
                tsslStatusMain.Text = string.Format("Loading {0}, please wait...", programInfo.ProgramName);
                Application.DoEvents();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                // Initialise program settings
                OricProgram loadedProgram = new OricProgram();
                loadedProgram.New();

                switch (programInfo.MediaType)
                {
                    case ConstantsAndEnums.MediaType.TapeFile:
                        // Load the selected program from Tape
                        OricTape oricTape = new OricTape();
                        loadedProgram = oricTape.Load(Path.Combine(programInfo.Folder, programInfo.ParentName),
                                                      programInfo.ProgramName, programInfo.ProgramIndex);
                        break;

                    case ConstantsAndEnums.MediaType.DiskFile:
                        loadedProgram = programInfo.LoadFile();
                        break;

                    default:
                        break;
                }

                stopWatch.Stop();
                TimeSpan loadTime = stopWatch.Elapsed;

                // Determine how we are going to display the file data
                switch (loadedProgram.Format)
                {
                    case OricProgram.ProgramFormat.BasicProgram:
                        SetupUserControl(UserControls.DataViewer, true, programInfo);
                        break;

                    case OricProgram.ProgramFormat.TeleassSource:
                        SetupUserControl(UserControls.DataViewer, true, programInfo);
                        break;

                    case OricProgram.ProgramFormat.HyperbasicProgram:
                        SetupUserControl(UserControls.DataViewer, true, programInfo);
                        break;

                    case OricProgram.ProgramFormat.CharacterSet:
                        SetupUserControl(UserControls.CharacterSetViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.BinaryFile:
                        SetupUserControl(UserControls.DataViewer, true, programInfo);
                        break;

                    case OricProgram.ProgramFormat.DirectAccessFile:
                        SetupUserControl(UserControls.DataFileViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.HiresScreen:
                        SetupUserControl(UserControls.ScreenViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        SetupUserControl(UserControls.SequentialFileViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.TextScreen:
                    case OricProgram.ProgramFormat.HelpFile:
                        SetupUserControl(UserControls.ScreenViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.WindowFile:
                        SetupUserControl(UserControls.ScreenViewer, false, programInfo);
                        break;

                    default:
                        SetupUserControl(UserControls.None, false, programInfo);
                        break;
                }

                mainViewControl.ProgramData = loadedProgram;
                mainViewControl.ProgramInfo = programInfo;

                stopWatch.Reset();
                stopWatch.Start();

                mainViewControl.DisplayData(specialMode);

                stopWatch.Stop();
                TimeSpan displayTime = stopWatch.Elapsed;

                TimeSpan totaltime = loadTime + displayTime;

                if (loadTime.TotalSeconds > 1)
                {
                    tsslLoadTime.ForeColor = Color.Red;
                }
                else
                {
                    tsslLoadTime.ForeColor = Color.Green;
                }

                if (displayTime.TotalSeconds > 1)
                {
                    tsslDisplayTime.ForeColor = Color.Red;
                }
                else
                {
                    tsslDisplayTime.ForeColor = Color.Green;
                }

                if (totaltime.TotalSeconds > 1.5)
                {
                    tsslOverallTime.ForeColor = Color.Red;
                }
                else
                {
                    tsslOverallTime.ForeColor = Color.Green;
                }

                tsslLoadTime.Text = string.Format("Load time {0:N2} secs", loadTime.TotalSeconds);
                tsslDisplayTime.Text = string.Format("Display time {0:N2} secs", displayTime.TotalSeconds);
                tsslOverallTime.Text = string.Format("Overall time {0:N2} secs", totaltime.TotalSeconds);

                tsslStatusMain.Text = "Ready.";
            }

            // Display default cursor
            Application.UseWaitCursor = false;
        }

        public void DisplayOtherFileContents(OtherFileInfo otherFileInfo)
        {
            bool documentOpen = false;

            // Display wait cursor
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;

            string otherFileName = otherFileInfo.FullName;

            if (dkpPanel.Contents.Count > 1)
            {
                string matchingName = $"{Path.GetFileName(otherFileInfo.FullName)} [{Path.GetDirectoryName(otherFileInfo.FullName)}]";

                foreach (IDockContent item in dkpPanel.Contents)
                {
                    if (item.DockHandler.Form.Text.Equals(matchingName))
                    {
                        item.DockHandler.Activate(); // this will re active if the form already Docked
                        documentOpen = true;
                    }
                }
            }

            if (!documentOpen)
            {
                tsslStatusMain.Text = string.Format("Loading {0}, please wait...", otherFileName);
                Application.DoEvents();

                OricFileInfo fileInfo = new OricFileInfo
                {
                    Name = otherFileName,

                    StartAddress = otherFileInfo.StartAddress,
                    EndAddress = (ushort)(otherFileInfo.StartAddress + (ushort)(otherFileInfo.Length - 1)),
                    Format = otherFileInfo.Format,
                    MediaType = ConstantsAndEnums.MediaType.UnknownMedia
                };

                SetupUserControl(UserControls.DataViewer, true, fileInfo);

                OricProgram prog = new OricProgram
                {
                    ProgramData = File.ReadAllBytes(otherFileInfo.FullName),
                    StartAddress = otherFileInfo.StartAddress,
                    EndAddress = (ushort)(otherFileInfo.StartAddress + (ushort)(otherFileInfo.Length - 1)),
                    Format = otherFileInfo.Format
                };

                OricProgram.SpecialMode specialMode = (otherFileInfo.Format == OricProgram.ProgramFormat.OrixProgram ? OricProgram.SpecialMode.Telestrat : OricProgram.SpecialMode.None);

                mainViewControl.ProgramData = prog;
                mainViewControl.ProgramInfo = fileInfo;
                mainViewControl.DisplayData(specialMode);

                tsslStatusMain.Text = "Ready.";
            }

            // Display default cursor
            Application.UseWaitCursor = false;
        }
        #endregion

        #region Print Functions
        private void printImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (prtDialog.ShowDialog() == DialogResult.OK)
            {
                prtDocument.Print();
            }
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prtPageSetupDialog.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prtPreviewDialog.ShowDialog();
        }
        #endregion

        private void dkpPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            int documentCount = dkpPanel.DocumentsCount;

            if (documentCount > 0)
            {
                if (dkpPanel.ActiveDocument != null)
                {
                    if (dkpPanel.ActiveDocument.GetType() == typeof(frmMainView))
                    {
                        frmMainView document = (frmMainView)dkpPanel.ActiveDocument;

                        if (document != null && document.ProgramInfo != null)
                        {
                            programInfoForm.DisplayProgramInformation(document.ProgramInfo);
                        }
                    }
                }
            }
            else
            {
                programInfoForm.ClearInfo();
            }
        }


        /*private void saveAsTAPFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            if (selectedNode.Tag == null)
            {
                // Node does contain any tag info so just exit
                return;
            }

            if (selectedNode.Tag.GetType().ToString().Equals("OricExplorer.OricFileInfo"))
            {
                OricFileInfo selectedFile = (OricFileInfo)selectedNode.Tag;

                string strTapeFilename = string.Format("{0}.TAP", selectedFile.ProgramName);

                SaveFileDialog saveAsTapDialog = new SaveFileDialog
                {
                    InitialDirectory = "C:\\",
                    FileName = strTapeFilename,
                    OverwritePrompt = true,
                    Title = "Save as TAP file",
                    Filter = "tap files (*.tap)|*.tap"
                };

                if (saveAsTapDialog.ShowDialog() == DialogResult.OK)
                {
                    OricProgram newProgram = new OricProgram();

                    switch (selectedFile.MediaType)
                    {
                        case ConstantsAndEnums.MediaType.TapeFile:
                            // Load the selected program from Tape
                            OricTape oricTape = new OricTape();
                            newProgram = oricTape.Load("C:\\" + selectedFile.ParentName,
                                                       selectedFile.ProgramName, selectedFile.ProgramIndex);
                            break;

                        case ConstantsAndEnums.MediaType.DiskFile:
                            OricFileInfo fileInfo = (OricFileInfo)selectedNode.Tag;
                            newProgram = fileInfo.LoadFile();
                            break;

                        default:
                            break;
                    }

                    OricTape newTape = new OricTape
                    {
                        TapeName = saveAsTapDialog.FileName
                    };

                    ArrayList programList = new ArrayList
                    {
                        (OricProgram)newProgram
                    };

                    newTape.WriteFiles(programList, FileMode.Create);

                    // Add new Tape to the tree
                    string strNodeToMatch = Path.GetFileName(saveAsTapDialog.FileName);

                    TreeNodeCollection nodes = fileListForm.treeFileList.Nodes;

                    foreach (TreeNode n in nodes)
                    {
                        if (FindRecursive(n, strNodeToMatch))
                            break;
                    }

                    FileInfo fiNewFile = new FileInfo(saveAsTapDialog.FileName);
                    _ = AddTapeToTree(fiNewFile);
                }
            }
        }*/

        /*private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get details of the selected program
            OricFileInfo temp = (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag;

            // Load the selected file
            OricProgram program = new OricProgram();
            program = temp.LoadFile();

            OricDisk disk = new OricDisk(temp.ParentName);
            disk.SaveFile(temp.ParentName, "NEWPR2.DAT", program);
        }*/
    }
}
