using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System;
using System.Drawing.Drawing2D;
using System.Collections;
using OricExplorer.Forms;
using System.Xml;
using Be.Windows.Forms;
using System.Diagnostics;
using OricExplorer.User_Controls;
using WeifenLuo.WinFormsUI.Docking;
using static OricExplorer.Configuration;
using FastColoredTextBoxNS;

namespace OricExplorer
{
    public partial class MainForm : Form
    {
        public enum Machine {Oric_1, Oric_Atmos};
        public enum UserControls { MainView, DataViewer, SectorViewer, ScreenViewer, CharacterSetViewer, DataFileViewer, SequentialFileViewer, None };
        public enum ExportTo { Tape, Text, Raw};

        TreeNode rootNode;
        TreeNode tapeTreeNode;
        TreeNode diskTreeNode;
        TreeNode romTreeNode;

        // Tree nodes for disk groups
        TreeNode oricDosGroupNode;
        TreeNode sedOricGroupNode;
        TreeNode ftDosGroupNode;
        TreeNode stratSedGroupNode;
        TreeNode xlDosGroupNode;
        TreeNode unknownGroupNode;

        StreamWriter dirListing = null;

        public Boolean flashFlag = false;

        private MainView mainViewControl;
        private OricProgram loadedProgram;

        FileListForm fileListForm;
        public ProgramInfoForm programInfoForm;

        private DeserializeDockContent m_deserializeDockContent;

        public MainForm()
        {
            InitializeComponent();

            fileListForm = new FileListForm(this);
            fileListForm.Show(dockPanel1, DockState.DockLeft);
            fileListForm.treeFileList.TreeViewNodeSorter = new NodeSortedByType();

            programInfoForm = new ProgramInfoForm();
            programInfoForm.Show(dockPanel1, DockState.DockRight);

            loadedProgram = new OricProgram();

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            OricExplorer.GetFormPosition(this);
            Show();

            String fName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.xml");

            if (File.Exists(fName))
            {
                fileListForm.DockPanel = null;
                programInfoForm.DockPanel = null;

                dockPanel1.LoadFromXml(fName, m_deserializeDockContent);
            }
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FileListForm).ToString())
            {
                return fileListForm;
            }
            else if (persistString == typeof(ProgramInfoForm).ToString())
            {
                return programInfoForm;
            }

            return null;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration();

            if (configuration.TapeFolders.Count == 0 && configuration.DiskFolders.Count == 0)
            {
                // Open the settings dialog
                using (SettingsForm settingsForm = new SettingsForm())
                {
                    settingsForm.ShowDialog();
                }
            }

            // Check for updates first
            if (configuration.CheckForUpdatesOnStartup)
            {
                if (getVersionFromWebsite())
                {
                    using (CheckForUpdateForm checkForUpdateForm = new CheckForUpdateForm())
                    {
                        checkForUpdateForm.ShowDialog();
                    }
                }
            }

            // Build the file tree
            BuildFileTree();
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            OricExplorer.SaveFormPosition(this);

            dockPanel1.SaveAsXml("Layout.xml");
        }

        #region Information Display Functions
        private void SetupUserControl(UserControls userControl, Boolean showSourceCode, OricFileInfo programInfo)
        {
            mainViewControl = new MainView(this);

            if (programInfo.MediaType != OricExplorer.MediaType.ROMFile)
            {
                mainViewControl.Text = String.Format("{0} [{1}]", programInfo.ProgramName, programInfo.ParentName);
            }
            else
            {
                mainViewControl.Text = String.Format("{0} [{1}]", Path.GetFileName(programInfo.Name), Path.GetDirectoryName(programInfo.Name));
            }

            mainViewControl.Show(dockPanel1, DockState.Document);

            mainViewControl.userControl = userControl;
            mainViewControl.showSourceCode = showSourceCode;
            mainViewControl.InitialiseView();
        }

        private void DisplayTapeDetails(TapeInfo tapeInfo)
        {
            StringBuilder stbText = new StringBuilder();
            stbText.AppendFormat("{0:N0} files (Tape uses : {1:N0} KB)", tapeInfo.FileCount, (float)tapeInfo.Length / 1024);

            lblStatusMain.Text = stbText.ToString();
        }

        public void DisplayDiskInformation(OricDiskInfo diskInfo)
        {
            using (DiskInfoViewerControl diskInfoViewer = new DiskInfoViewerControl(this))
            {
                diskInfoViewer.DiskPath = diskInfo.FullName;
                diskInfoViewer.ShowDialog();
            }
        }

        public void DisplayUnknownDisk(OricDiskInfo diskInfo)
        {
            using (DiskDataForm diskDataForm = new DiskDataForm())
            {
                diskDataForm.diskInfo = diskInfo;
                diskDataForm.ShowDialog();
            }
        }

        public void DisplayROMContents(String romName)
        {
            Boolean documentOpen = false;

            // Display wait cursor
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;

            if (dockPanel1.Contents.Count > 1)
            {
                String matchingName = String.Format("{0}", romName);

                foreach (IDockContent item in dockPanel1.Contents)
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
                lblStatusMain.Text = String.Format("Loading {0}, Please wait...", romName);
                Application.DoEvents();

                Byte[] romData = File.ReadAllBytes(romName);

                OricFileInfo fileInfo = new OricFileInfo();
                fileInfo.Name = romName;

                fileInfo.StartAddress = 0xC000;
                fileInfo.EndAddress = (UInt16)(0xC000 + (UInt16)(romData.Length - 1));
                fileInfo.Format = OricProgram.ProgramFormat.CodeFile;
                fileInfo.MediaType = OricExplorer.MediaType.ROMFile;

                SetupUserControl(UserControls.DataViewer, true, fileInfo);

                OricProgram prog = new OricProgram();
                prog.m_programData = romData;
                prog.StartAddress = 0xC000;
                prog.EndAddress = (UInt16)(0xC000 + (UInt16)(romData.Length - 1));
                prog.Format = OricProgram.ProgramFormat.CodeFile;

                mainViewControl.programData = prog;
                mainViewControl.programInfo = fileInfo;
                mainViewControl.DisplayData();

                lblStatusMain.Text = "Ready.";
            }

            // Display default cursor
            Application.UseWaitCursor = false;
        }

        public void DisplayFileContents(OricFileInfo programInfo)
        {
            Boolean documentOpen = false;

            // Display wait cursor
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;

            if (dockPanel1.Contents.Count > 1)
            {
                String matchingName = String.Format("{0} [{1}]", programInfo.ProgramName, programInfo.ParentName);

                foreach (IDockContent item in dockPanel1.Contents)
                {
                    if (item.DockHandler.Form.Text.Equals(matchingName))
                    {
                        item.DockHandler.Activate(); // this will re active if the form already Docked
                        documentOpen = true;
                    }
                }
            }

            if(!documentOpen)
            {
                lblStatusMain.Text = String.Format("Loading {0}, Please wait...", programInfo.ProgramName);
                Application.DoEvents();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                // Initialise program settings
                OricProgram loadedProgram = new OricProgram();
                loadedProgram.New();

                switch (programInfo.MediaType)
                {
                    case OricExplorer.MediaType.TapeFile:
                        // Load the selected program from Tape
                        OricTape oricTape = new OricTape();
                        loadedProgram = oricTape.Load(Path.Combine(programInfo.Folder, programInfo.ParentName),
                                                      programInfo.ProgramName, programInfo.ProgramIndex);
                        break;

                    case OricExplorer.MediaType.DiskFile:
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

                    case OricProgram.ProgramFormat.CharacterSet:
                        SetupUserControl(UserControls.CharacterSetViewer, false, programInfo);
                        break;

                    case OricProgram.ProgramFormat.CodeFile:
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

                mainViewControl.programData = loadedProgram;
                mainViewControl.programInfo = programInfo;

                stopWatch.Reset();
                stopWatch.Start();

                mainViewControl.DisplayData();

                stopWatch.Stop();
                TimeSpan displayTime = stopWatch.Elapsed;

                TimeSpan totaltime = loadTime + displayTime;

                if (loadTime.TotalSeconds > 1)
                {
                    toolStripStatusLabelLoadTime.ForeColor = Color.Red;
                }
                else
                {
                    toolStripStatusLabelLoadTime.ForeColor = Color.Green;
                }

                if (displayTime.TotalSeconds > 1)
                {
                    toolStripStatusLabelDisplayTime.ForeColor = Color.Red;
                }
                else
                {
                    toolStripStatusLabelDisplayTime.ForeColor = Color.Green;
                }

                if (totaltime.TotalSeconds > 1.5)
                {
                    toolStripStatusLabelOverallTime.ForeColor = Color.Red;
                }
                else
                {
                    toolStripStatusLabelOverallTime.ForeColor = Color.Green;
                }

                toolStripStatusLabelLoadTime.Text = String.Format("Load time {0:N2} secs", loadTime.TotalSeconds);
                toolStripStatusLabelDisplayTime.Text = String.Format("Display time {0:N2} secs", displayTime.TotalSeconds);
                toolStripStatusLabelOverallTime.Text = String.Format("Overall time {0:N2} secs", totaltime.TotalSeconds);

                lblStatusMain.Text = "Ready.";
            }

            // Display default cursor
            Application.UseWaitCursor = false;
        }
        #endregion

        #region MainForm Menu Functions
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Show settings dialog
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Reset the applications title text
            Text = "Oric Explorer";

            // Setup messages for the status labels
            lblStatusMain.Text = "Refreshing the file list...";

            // Clear all the current nodes from the file tree
            fileListForm.treeFileList.Nodes.Clear();

            // Clear out the currently loaded program
            loadedProgram.New();

            Application.DoEvents();

            // Rebuild the file tree
            BuildFileTree();
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check that we have actually selected a file first
            if (fileListForm.treeFileList.SelectedNode.Tag == null)
            {
                return;
            }

            // Take a copy of the selected node
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            // Get response from the user to check that they really do want to delete the file
            String strMessage = String.Format("Are you sure you want to delete the file '{0}' from the Disk?", selectedNode.Text);
            DialogResult dialogResult = MessageBox.Show(strMessage, "Confirm Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Users wants to delete the selected file
            if (dialogResult == DialogResult.Yes)
            {
                // Tag contains details of the selected file
                OricFileInfo programInfo = (OricFileInfo)selectedNode.Tag;

                // Check what it is we are trying to delete
                switch (programInfo.MediaType)
                {
                    case OricExplorer.MediaType.TapeFile:
                        // Not currently implemented
                        break;

                    case OricExplorer.MediaType.DiskFile:
                        OricDiskInfo diskInfo = new OricDiskInfo(programInfo.ParentName);

                        if (diskInfo.DeleteFile(programInfo.ParentName, programInfo.ProgramName))
                        {
                            String message = String.Format("File {0} was deleted successfully", programInfo.Name);
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
                            String message = String.Format("Failed to deleted {0}", programInfo.Name);
                            MessageBox.Show(message, "Delete File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            if(selectedNode.IsExpanded)
                selectedNode.Collapse();
            else
                selectedNode.Expand();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            OricExplorer.MediaType fileType = OricExplorer.MediaType.UnknownMedia;

            String strFolder = "";

            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            if(selectedNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
            {
                fileType = OricExplorer.MediaType.OricTape;
                TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;
                strFolder = tapeInfo.Folder;
            }

            String sourceFileName = String.Format("{0}\\{1}", strFolder, selectedNode.Text);
            String destFileName = "";

            UInt16 ui16Index = 0;

            Boolean bFileCopied = false;

            while(!bFileCopied)
            {
                try
                {
                    if(ui16Index == 0)
                    {
                        destFileName = String.Format("{0}\\Copy of {1}", strFolder, selectedNode.Text);
                    }
                    else
                    {
                        destFileName = String.Format("{0}\\Copy ({1}) of {2}", strFolder, ui16Index, selectedNode.Text);
                    }

                    File.Copy(sourceFileName, destFileName);

                    bFileCopied = true;

                    TreeNode newNode = null;

                    // Add copied file to the tree
                    FileInfo fiNewFile = new FileInfo(destFileName);

                    if(fileType == OricExplorer.MediaType.OricTape)
                    {
                        newNode = AddTapeToTree(fiNewFile);
                    }

                    fileListForm.treeFileList.SelectedNode = newNode;
                }
                catch(IOException ex)
                {
                    String strMessage = ex.Message;
                    ui16Index++;
                }
                catch(Exception ex2)
                {
                    MessageBox.Show("Failed to copy file.\n{0}", ex2.Message);
                    return;
                }
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            String strFolder = "";

            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            if(selectedNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
            {
                TapeInfo tapeInfo = (TapeInfo)selectedNode.Tag;
                strFolder = tapeInfo.Folder;
            }

            String sourceFileName = String.Format("{0}\\{1}", strFolder, selectedNode.Text);
            String confirmMessage = String.Format("Are you sure you want to delete {0}?", selectedNode.Text);

            DialogResult dialogResult = MessageBox.Show(confirmMessage, "Confirm Delete",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    File.Delete(sourceFileName);

                    // Remove item from the tree
                    selectedNode.Remove();
                }
                catch(Exception ex)
                {
                    String errorMessage = String.Format("Failed to delete {0}.\n\n{1}", sourceFileName, ex.Message);

                    MessageBox.Show(errorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            fileListForm.treeFileList.LabelEdit = true;

            if(!selectedNode.IsEditing)
            {
                selectedNode.BeginEdit();
            }
        }

        private void aboutOricExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit Oric Explorer?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            closeToolStripMenuItem.Enabled = (dockPanel1.ActiveDocument != null);
            closeAllToolStripMenuItem.Enabled = (dockPanel1.DocumentsCount > 0);
            closeAllButThisOneToolStripMenuItem.Enabled = (dockPanel1.DocumentsCount > 1) && (dockPanel1.ActiveDocument != null);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            // Get directory listing folder from configuration settings
            Configuration configuration = new Configuration();

            TapeInfo tapeInfo = (TapeInfo)fileListForm.treeFileList.SelectedNode.Tag;
            String outputFile = Path.Combine(configuration.DirListingsFolder, Path.GetFileNameWithoutExtension(tapeInfo.Name) + ".txt");

            try
            {
                // Open output file
                dirListing = File.CreateText(outputFile);

                // Get selected node
                TreeNode tapeNode = fileListForm.treeFileList.SelectedNode;

                // Output directory listing of selected disk
                OutputTapeDirectory(tapeNode);

                // Close the writer and underlying file
                dirListing.Close();

                MessageBox.Show("Directory listing sent to " + outputFile, "Output Directory",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Directory Listing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsTAPFileToolStripMenuItem_Click(object sender, EventArgs e)
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

                String strTapeFilename = String.Format("{0}.TAP", selectedFile.ProgramName);

                SaveFileDialog saveAsTapDialog = new SaveFileDialog();

                saveAsTapDialog.InitialDirectory = "C:\\";
                saveAsTapDialog.FileName = strTapeFilename;
                saveAsTapDialog.OverwritePrompt = true;
                saveAsTapDialog.Title = "Save as TAP file";
                saveAsTapDialog.Filter = "tap files (*.tap)|*.tap";

                DialogResult dialogResult = saveAsTapDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    OricProgram newProgram = new OricProgram();

                    switch (selectedFile.MediaType)
                    {
                        case OricExplorer.MediaType.TapeFile:
                            // Load the selected program from Tape
                            OricTape oricTape = new OricTape();
                            newProgram = oricTape.Load("C:\\" + selectedFile.ParentName,
                                                       selectedFile.ProgramName, selectedFile.ProgramIndex);
                            break;

                        case OricExplorer.MediaType.DiskFile:
                            OricFileInfo fileInfo = (OricFileInfo)selectedNode.Tag;
                            newProgram = fileInfo.LoadFile();
                            break;

                        default:
                            break;
                    }

                    OricTape newTape = new OricTape();
                    newTape.TapeName = saveAsTapDialog.FileName;

                    ArrayList programList = new ArrayList();
                    programList.Add((OricProgram)newProgram);

                    newTape.WriteFiles(programList, FileMode.Create);

                    // Add new Tape to the tree
                    String strNodeToMatch = Path.GetFileName(saveAsTapDialog.FileName);

                    TreeNodeCollection nodes = fileListForm.treeFileList.Nodes;

                    foreach (TreeNode n in nodes)
                    {
                        if (FindRecursive(n, strNodeToMatch))
                            break;
                    }

                    FileInfo fiNewFile = new FileInfo(saveAsTapDialog.FileName);
                    TreeNode newNode = AddTapeToTree(fiNewFile);
                }
            }
        }

        private void outputDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get directory listing folder from configuration settings
            Configuration configuration = new Configuration();

            TapeInfo tapeInfo = (TapeInfo)fileListForm.treeFileList.SelectedNode.Tag;
            String outputFile = Path.Combine(configuration.DirListingsFolder, Path.GetFileNameWithoutExtension(tapeInfo.Name) + ".txt");

            try
            {
                // Open output file
                dirListing = File.CreateText(outputFile);

                // Output directory listing of all tapes
                DirectoryOfTapes();

                // Close the writer and underlying file
                dirListing.Close();

                MessageBox.Show("Directory listing sent to " + outputFile, "Output Directory",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Directory Listing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CheckForUpdateForm checkForUpdateForm = new CheckForUpdateForm())
            {
                checkForUpdateForm.ShowDialog();
            }
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

                if (tx.Tag != null)
                {
                    if (tx.Tag.GetType().ToString().Equals("OricExplorer.OricFileInfo"))
                    {
                        OricFileInfo catalog = new OricFileInfo();
                        catalog = (OricFileInfo)tx.Tag;

                        if (catalog.MediaType == OricExplorer.MediaType.TapeFile)
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

        public class NodeSortedByType : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;

                if (tx.Tag != null && ty.Tag != null)
                {
                    if (tx.Tag.GetType().ToString().Equals("OricExplorer.OricFileInfo"))
                    {
                        OricFileInfo catalog = new OricFileInfo();
                        catalog = (OricFileInfo)tx.Tag;

                        if (catalog.MediaType == OricExplorer.MediaType.TapeFile)
                        {
                            return 0;
                        }

                        OricFileInfo catalogY = new OricFileInfo();
                        catalogY = (OricFileInfo)ty.Tag;

                        String textX = catalog.Format.ToString();
                        String textY = catalogY.Format.ToString();

                        return -string.Compare(textY, textX);
                    }

                    return -string.Compare(ty.Text, tx.Text);
                }

                return 0;
            }
        }

        private TreeNode AddNodeToTree(String newNodeText, TreeNode parentNode, int nodeImage, String nodeTooltip)
        {
            TreeNode newNode = null;
            newNode = parentNode.Nodes.Add(newNodeText);

            newNode.Name = newNodeText;
            newNode.ImageIndex = nodeImage;
            newNode.SelectedImageIndex = nodeImage;
            newNode.ToolTipText = nodeTooltip;
            newNode.ForeColor = Color.White;

            return newNode;
        }

        private TreeNode AddNodeToTree(String newNodeText, TreeNode parentNode, int nodeImage, String nodeTooltip, Color nodeColor)
        {
            TreeNode newNode = null;
            newNode = parentNode.Nodes.Add(newNodeText);

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
            fileListForm.treeFileList.BeginUpdate();

            // Add the root node to the tree
            rootNode = fileListForm.treeFileList.Nodes.Add("Oric Files");
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;

            // Add file type nodes to the tree
            diskTreeNode = AddNodeToTree("Disks", rootNode, 4, "Oric Disks");
            tapeTreeNode = AddNodeToTree("Tapes", rootNode, 2, "Oric Tapes");
            romTreeNode = AddNodeToTree("ROM's", rootNode, 3, "ROM Files");

            ftDosGroupNode = AddNodeToTree("FT-Dos", diskTreeNode, 1, "FT-Dos Disks");
            oricDosGroupNode = AddNodeToTree("OricDOS", diskTreeNode, 1, "OricDOS Disks");
            sedOricGroupNode = AddNodeToTree("SedOric", diskTreeNode, 1, "SedOric Disks");
            stratSedGroupNode = AddNodeToTree("Stratsed", diskTreeNode, 1, "Stratsed Disks");
            xlDosGroupNode = AddNodeToTree("XL-Dos", diskTreeNode, 1, "XL-Dos Disks");
            unknownGroupNode = AddNodeToTree("Unknown", diskTreeNode, 1, "Unknown disk formats", Color.FromArgb(246, 174, 1));

            // Add tape grouping nodes to the tree
            AddNodeToTree("0-9", tapeTreeNode, 1, "");

            // Adds alphabetic grouping to the tree
            for (int iIndex = 0; iIndex < 26; iIndex++)
            {
                char ch = (char)(iIndex + 65);
                AddNodeToTree(ch.ToString(), tapeTreeNode, 1, "");
            }

            // Add tape grouping nodes to the tree
            AddNodeToTree("Other", tapeTreeNode, 1, "Tapes that don't fit anywhere else.");

            // Create instance of the scanner form and initialise settings
            using (FileScanForm fileScanForm = new FileScanForm(this))
            {
                // Display the Scanner form
                fileScanForm.ShowDialog();
                fileScanForm.Dispose();
            }

            // Expand all of the TreeView nodes.
            rootNode.Expand();

            // Resume tree updates
            fileListForm.treeFileList.EndUpdate();

            processTimer.Stop();

            TimeSpan timeSpan = processTimer.Elapsed;

            String oTimeSpan = "";

            if (timeSpan.Minutes < 1)
            {
                oTimeSpan = String.Format("Media scanned in {0}.{1,2} seconds", timeSpan.Seconds, timeSpan.Milliseconds);
            }
            else
            {
                oTimeSpan = String.Format("Media scanned in {0} mins {1,2}.{2,2} seconds", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            }

            lblStatusMain.Text = oTimeSpan;
        }

        public TreeNode AddDiskToTree(FileInfo fileInfo)
        {
            int nodeImageIndex = 0;

            TreeNode groupTreeNode = null;
            TreeNode newDiskTreeNode = null;

            OricDiskInfo diskInfo = new OricDiskInfo(fileInfo.FullName);

            switch(diskInfo.DOSFormat)
            {
                case OricDisk.DOSFormats.TDOS:
                    nodeImageIndex = 4;
                    groupTreeNode = ftDosGroupNode;
                    break;

                case OricDisk.DOSFormats.OricDOS:
                    nodeImageIndex = 5;
                    groupTreeNode = oricDosGroupNode;
                    break;

                case OricDisk.DOSFormats.SedOric:
                    nodeImageIndex = 6;
                    groupTreeNode = sedOricGroupNode;
                    break;

                case OricDisk.DOSFormats.StratSed:
                    nodeImageIndex = 6;
                    groupTreeNode = stratSedGroupNode;
                    break;

                case OricDisk.DOSFormats.XLDos:
                    nodeImageIndex = 6;
                    groupTreeNode = xlDosGroupNode;
                    break;

                default:
                    nodeImageIndex = 17;
                    groupTreeNode = unknownGroupNode;
                    break;
            }

            if (groupTreeNode != null)
            {
                newDiskTreeNode = AddNodeToTree(fileInfo.Name, groupTreeNode, nodeImageIndex, "");

                if (newDiskTreeNode != null)
                {
                    newDiskTreeNode.Tag = diskInfo;

                    if (diskInfo.DOSFormat == OricDisk.DOSFormats.Unknown)
                    {
                        // Add rightclick context menu to disk
                        newDiskTreeNode.ContextMenuStrip = contextMenuStripUnknownDisk;
                    }
                    else
                    {
                        // Add rightclick context menu to disk
                        newDiskTreeNode.ContextMenuStrip = diskContextMenuStrip;

                        // Add files to disk branch
                        OricFileInfo[] fileList = diskInfo.GetFiles();

                        if (fileList.Length > 0)
                        {
                            AddDirectoryToDiskBranch(newDiskTreeNode, fileList);
                        }

                        // Build the Tooltip string
                        StringBuilder stbToolTip = new StringBuilder();

                        stbToolTip.AppendFormat("Filename\t: {0}\n", Path.GetFileName(fileInfo.FullName));
                        stbToolTip.AppendFormat("Folder\t\t: {0}\n\n", Path.GetDirectoryName(fileInfo.FullName));

                        stbToolTip.AppendFormat("Disk name\t: {0}\n", diskInfo.DiskName);
                        stbToolTip.AppendFormat("Disk type\t: {0}\n", diskInfo.DiskType.ToString());
                        stbToolTip.AppendFormat("DOS Format\t: {0}\n", diskInfo.DOSFormat.ToString());
                        stbToolTip.AppendFormat("DOS Version\t: {0}\n\n", diskInfo.DosVersion());

                        if (diskInfo.Sides == 1)
                        {
                            stbToolTip.Append("Structure\t: Single sided, ");
                        }
                        else
                        {
                            stbToolTip.Append("Structure\t: Double sided, ");
                        }

                        stbToolTip.AppendFormat("{0} tracks per side, {1} sectors per track\n", diskInfo.TracksPerSide, diskInfo.SectorsPerTrack);
                        stbToolTip.Append("Usage\t\t: ");

                        if (fileList.Length > 0)
                        {
                            stbToolTip.AppendFormat("{0} files, ", fileList.Length);
                        }

                        stbToolTip.AppendFormat("{0:N0} sectors used, {1:N0} free, out of {2:N0}\n",
                                                diskInfo.SectorsUsed, diskInfo.SectorsFree, diskInfo.Sectors);

                        if (diskInfo.Sectors > 0)
                        {
                            float flPercentageFree = diskInfo.SectorsFree;
                            flPercentageFree = (float)(flPercentageFree / diskInfo.Sectors);
                            flPercentageFree = flPercentageFree * 100;

                            stbToolTip.AppendFormat("Percent Free\t: {0:N0}%\n", flPercentageFree);
                        }

                        stbToolTip.AppendFormat("\nCreated\t\t: {0}, {1}\n", fileInfo.CreationTime.ToLongDateString(), fileInfo.CreationTime.ToLongTimeString());
                        stbToolTip.AppendFormat("Modified\t: {0}, {1}", fileInfo.LastWriteTime.ToLongDateString(), fileInfo.LastWriteTime.ToLongTimeString());

                        newDiskTreeNode.ToolTipText = stbToolTip.ToString();
                    }
                }
            }

            return newDiskTreeNode;
        }

        private void AddDirectoryToDiskBranch(TreeNode diskNode, OricFileInfo[] Directory)
        {
            foreach (OricFileInfo FileInfo in Directory)
            {
                int imageIndex = 0;

                switch (FileInfo.Format)
                {
                    case OricProgram.ProgramFormat.BasicProgram: imageIndex = 13; break;
                    case OricProgram.ProgramFormat.CodeFile: imageIndex = 11; break;
                    case OricProgram.ProgramFormat.CharacterSet: imageIndex = 10; break;
                    case OricProgram.ProgramFormat.DirectAccessFile: imageIndex = 16; break;
                    case OricProgram.ProgramFormat.HiresScreen: imageIndex = 14; break;
                    case OricProgram.ProgramFormat.SequentialFile: imageIndex = 8; break;
                    case OricProgram.ProgramFormat.TextScreen: imageIndex = 12; break;
                    case OricProgram.ProgramFormat.WindowFile: imageIndex = 12; break;
                    case OricProgram.ProgramFormat.HelpFile: imageIndex = 9; break;
                    default: imageIndex = 15; break;
                }

                TreeNode ProgramNode;
                ProgramNode = AddNodeToTree(FileInfo.ProgramName, diskNode, imageIndex, "");

                ProgramNode.Tag = FileInfo;
                ProgramNode.ImageIndex = imageIndex;
                ProgramNode.SelectedImageIndex = imageIndex;
                ProgramNode.ContextMenuStrip = progContextMenuStrip;

                StringBuilder stbToolTip = new StringBuilder();
                stbToolTip.Length = 0;

                stbToolTip.AppendFormat("Name\t: {0}\n", FileInfo.ProgramName);
                stbToolTip.AppendFormat("Format\t: {0}\n", FileInfo.FormatToString());

                if (FileInfo.Format == OricProgram.ProgramFormat.DirectAccessFile)
                {
                    stbToolTip.AppendFormat("Records\t: {0:N0}\n", FileInfo.m_ui16NoOfRecords);
                    stbToolTip.AppendFormat("Length\t: {0:N0}\n", FileInfo.m_ui16RecordLength);
                }
                else
                {
                    stbToolTip.AppendFormat("Address\t: ${0:X4} - ${1:X4}\n", FileInfo.StartAddress, FileInfo.EndAddress);

                    if (FileInfo.StartAddress > FileInfo.EndAddress)
                    {
                        // Problem with address values
                        stbToolTip.Append("Length\t: Address Error\n");
                    }
                    else
                    {
                        if (FileInfo.LengthBytes >= 1024)
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes ({1:N1} KB)\n", FileInfo.LengthBytes, (float)FileInfo.LengthBytes / 1024);
                        }
                        else
                        {
                            stbToolTip.AppendFormat("Length\t: {0:N0} bytes\n", FileInfo.LengthBytes);
                        }
                    }

                    stbToolTip.AppendFormat("Size\t: {0} sectors\n", FileInfo.LengthSectors);
                }

                stbToolTip.AppendFormat("Status\t: {0}", FileInfo.Protection.ToString());

                if (FileInfo.Format == OricProgram.ProgramFormat.BasicProgram ||
                    FileInfo.Format == OricProgram.ProgramFormat.CodeFile)
                {
                    stbToolTip.AppendFormat("\nAuto\t: {0}", FileInfo.AutoRun.ToString());
                }

                ProgramNode.ToolTipText = stbToolTip.ToString();
            }
        }

        public TreeNode AddTapeToTree(FileInfo fiFileInfo)
        {
            TreeNode tapeNode = null;

            OricTape oricTape = new OricTape();
            OricFileInfo[] tapeCatalog = oricTape.Catalog(fiFileInfo);

            if (tapeCatalog.Length > 0)
            {
                TreeNode[] tmpNode;
                System.Char firstCharacter = Convert.ToChar(fiFileInfo.Name.Substring(0, 1));

                if (System.Char.IsLetter(firstCharacter))
                {
                    tmpNode = tapeTreeNode.Nodes.Find(fiFileInfo.Name.Substring(0, 1), false);
                }
                else if (System.Char.IsDigit(firstCharacter))
                {
                    tmpNode = tapeTreeNode.Nodes.Find("0-9", false);
                }
                else
                {
                    tmpNode = tapeTreeNode.Nodes.Find("Other", false);
                }

                if (tmpNode.Length > 0)
                {
                    tapeNode = AddNodeToTree(fiFileInfo.Name, tmpNode[0], 2, "");
                    tmpNode[0].ToolTipText = String.Format("Contains {0} tapes.", tmpNode[0].Nodes.Count);
                }

                if (tapeNode != null)
                {
                    tapeNode.ContextMenuStrip = tapeContextMenuStrip;

                    StringBuilder tapeToolTipText = new StringBuilder();
                    tapeToolTipText.AppendFormat("Name\t\t: {0}\n", fiFileInfo.Name);
                    tapeToolTipText.AppendFormat("Folder\t\t: {0}\n\n", fiFileInfo.DirectoryName);
                    tapeToolTipText.AppendFormat("No. of files\t: {0}\n", tapeCatalog.Length);

                    if (fiFileInfo.Length >= 1024)
                    {
                        tapeToolTipText.AppendFormat("Length\t\t: {0:N0} bytes ({1:N1} KB)\n", fiFileInfo.Length, (float)fiFileInfo.Length / 1024);
                    }
                    else
                    {
                        tapeToolTipText.AppendFormat("Length\t\t: {0:N0} bytes\n", fiFileInfo.Length);
                    }

                    tapeToolTipText.AppendFormat("\nLast modified\t: {0}, {1}",
                                                 fiFileInfo.LastWriteTime.ToLongDateString(),
                                                 fiFileInfo.LastWriteTime.ToLongTimeString());

                    tapeNode.ToolTipText = tapeToolTipText.ToString();

                    TapeInfo tapeInfo = new TapeInfo();
                    tapeInfo.Folder = fiFileInfo.DirectoryName;
                    tapeInfo.Name = fiFileInfo.Name;
                    tapeInfo.FileCount = (ushort)tapeCatalog.Length;
                    tapeInfo.Length = (ushort)fiFileInfo.Length;

                    // Get file timestamps
                    tapeInfo.CreationTime = fiFileInfo.CreationTime;
                    tapeInfo.AccessedTime = fiFileInfo.LastAccessTime;
                    tapeInfo.WrittenTime = fiFileInfo.LastWriteTime;

                    tapeNode.Tag = tapeInfo;

                    foreach (OricFileInfo programInfo in tapeCatalog)
                    {
                        int imageIndex = 0;

                        switch (programInfo.Format)
                        {
                            case OricProgram.ProgramFormat.BasicProgram: imageIndex = 13; break;
                            case OricProgram.ProgramFormat.CodeFile: imageIndex = 11; break;
                            case OricProgram.ProgramFormat.CharacterSet: imageIndex = 10; break;
                            case OricProgram.ProgramFormat.DirectAccessFile: imageIndex = 16; break;
                            case OricProgram.ProgramFormat.HiresScreen: imageIndex = 14; break;
                            case OricProgram.ProgramFormat.SequentialFile: imageIndex = 8; break;
                            case OricProgram.ProgramFormat.TextScreen: imageIndex = 12; break;
                            case OricProgram.ProgramFormat.WindowFile: imageIndex = 12; break;
                            case OricProgram.ProgramFormat.HelpFile: imageIndex = 9; break;
                            default: imageIndex = 15; break;
                        }

                        TreeNode progNode;
                        progNode = AddNodeToTree(programInfo.ProgramName, tapeNode, imageIndex, "");

                        progNode.Tag = programInfo;
                        progNode.ImageIndex = imageIndex;
                        progNode.SelectedImageIndex = imageIndex;
                        progNode.ContextMenuStrip = progContextMenuStrip;

                        tapeToolTipText.Length = 0;

                        tapeToolTipText.AppendFormat("Name\t: {0}\n", programInfo.ProgramName);
                        tapeToolTipText.AppendFormat("Format\t: {0}\n", programInfo.FormatToString());
                        tapeToolTipText.AppendFormat("Address\t: ${0:X4} - ${1:X4}\n", programInfo.StartAddress, programInfo.EndAddress);

                        if (programInfo.LengthBytes >= 1024)
                        {
                            tapeToolTipText.AppendFormat("Length\t: {0:N0} bytes ({1:N1} KB)\n", programInfo.LengthBytes, (float)programInfo.LengthBytes / 1024);
                        }
                        else
                        {
                            tapeToolTipText.AppendFormat("Length\t: {0:N0} bytes\n", programInfo.LengthBytes, programInfo.LengthBytes / 1024);
                        }

                        tapeToolTipText.AppendFormat("Status\t: Auto Run is {0}", programInfo.AutoRun.ToString());

                        progNode.ToolTipText = tapeToolTipText.ToString();
                    }
                }
            }

            return tapeNode;
        }

        public TreeNode AddROMToTree(FileInfo fiFileInfo)
        {
            TreeNode romNode = AddNodeToTree(fiFileInfo.Name, romTreeNode, 3, "");

            if (romNode != null)
            {
                romNode.ContextMenuStrip = tapeContextMenuStrip;

                StringBuilder romToolTipText = new StringBuilder();
                romToolTipText.AppendFormat("Name\t\t: {0}\n", fiFileInfo.Name);
                romToolTipText.AppendFormat("Folder\t\t: {0}\n\n", fiFileInfo.DirectoryName);

                if (fiFileInfo.Length >= 1024)
                {
                    romToolTipText.AppendFormat("Length\t\t: {0:N0} bytes ({1:N1} KB)\n", fiFileInfo.Length, (float)fiFileInfo.Length / 1024);
                }
                else
                {
                    romToolTipText.AppendFormat("Length\t\t: {0:N0} bytes\n", fiFileInfo.Length);
                }

                romToolTipText.AppendFormat("\nLast modified\t: {0}, {1}",
                                                fiFileInfo.LastWriteTime.ToLongDateString(),
                                                fiFileInfo.LastWriteTime.ToLongTimeString());

                romNode.ToolTipText = romToolTipText.ToString();

                //TapeInfo tapeInfo = new TapeInfo();
                //tapeInfo.Folder = fiFileInfo.DirectoryName;
                //tapeInfo.Name = fiFileInfo.Name;
                //tapeInfo.FileCount = (ushort)tapeCatalog.Length;
                //tapeInfo.Length = (ushort)fiFileInfo.Length;

                // Get file timestamps
                //tapeInfo.CreationTime = fiFileInfo.CreationTime;
                //tapeInfo.AccessedTime = fiFileInfo.LastAccessTime;
                //tapeInfo.WrittenTime = fiFileInfo.LastWriteTime;

                //tapeNode.Tag = tapeInfo;

                romNode.Tag = fiFileInfo.FullName;
            }

            return romNode;
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

            String nodeTag = selectedNode.Tag.GetType().ToString();

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
        private void CopyTapeFilesToTape(TreeNode SourceNode, TreeNode DestNode)
        {
            // Retrieve details of the destination Tape
            /*TapeInfo DestTapeInfo = (TapeInfo)DestNode.Tag;

            OricTape DestTape = new OricTape();
            DestTape.TapeName = tapeFolder + "\\" + DestTapeInfo.Name;

            // Copy a file from a Tape
            if(SourceNode.Tag.GetType().ToString().Equals("OricExplorer.Catalog"))
            {
                // Retrieve program information from the source node
                OricFileInfo ProgramInfo = (OricFileInfo)SourceNode.Tag;

                // Load the program contents from the source tape
                OricProgram Program = new OricProgram();
                Program = oricTape.Load(tapeFolder + "\\" + ProgramInfo.ParentName,
                                        ProgramInfo.ProgramName, ProgramInfo.ProgramIndex);

                // Copy file to the end of the destination tape
                DestTape.SaveFile(Program);
            }

            // Copy a whole Tape
            if(SourceNode.Tag.GetType().ToString().Equals("OricExplorer.TapeInfo"))
            {
                // Retrieve information about the source Tape
                TapeInfo SourceTapeInfo = (TapeInfo)SourceNode.Tag;

                OricTape SourceTape = new OricTape();
                SourceTape.TapeName = tapeFolder + "\\" + SourceTapeInfo.Name;

                FileInfo fiTapeFile = new FileInfo(SourceTape.TapeName);

                // Retrieve a catalog of all the programs on the source Tape
                OricFileInfo[] TapeCatalog = SourceTape.Catalog(fiTapeFile);

                foreach (OricFileInfo ProgramInfo in TapeCatalog)
                {
                    // Load the program contents from the source tape
                    OricProgram Program = new OricProgram();
                    Program = SourceTape.Load(tapeFolder + "\\" + ProgramInfo.ParentName,
                                              ProgramInfo.ProgramName, ProgramInfo.ProgramIndex);

                    // Copy file to the end of the destination tape
                    DestTape.SaveFile(Program);
                }
            }

            // Get full pathname of the updated destination Tape
            FileInfo fiTape = new FileInfo(tapeFolder + "\\" + DestNode.Text);

            // Remove destination Tape from Tree list
            DestNode.Remove();

            // Add the updated Tape to the Tree list and display the files in the Tape
            TreeNode NewNode = AddTapeToTree(fiTape);
            NewNode.Expand();*/
        }

        private void DirectoryOfTapes()
        {
            // Scan through Tapes
            foreach(TreeNode tapeDetails in tapeTreeNode.Nodes)
            {
                OutputTapeDirectory(tapeDetails);
                dirListing.WriteLine();
            }
        }

        private void OutputTapeDirectory(TreeNode tapeNode)
        {
            // Get DiskInfo
            TapeInfo tapeInfo = (TapeInfo)tapeNode.Tag;

            dirListing.WriteLine("Directory of {0}", tapeInfo.Name);
            dirListing.WriteLine();

            int totalBytes = 0;

            foreach(TreeNode fileNode in tapeNode.Nodes)
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

        private Boolean FindRecursive(TreeNode treeNode, String strSearchString)
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
        #endregion

        #region Print Functions
        private void printImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        #endregion

        #region Emulator Functions
        private void oric1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            loadTapeInEmulator(Machine.Oric_1);
        }

        private void oricAtmosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTapeInEmulator(Machine.Oric_Atmos);
        }

        private void loadTapeInEmulator(Machine machineType)
        {
            // Get emulator executable from configuration settings
            Configuration configuration = new Configuration();

            TapeInfo tapeInfo = (TapeInfo)fileListForm.treeFileList.SelectedNode.Tag;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = configuration.EmulatorExecutable;
            startInfo.WorkingDirectory = Path.GetDirectoryName(configuration.EmulatorExecutable);

            String machineName = "";

            if (machineType == Machine.Oric_1)
            {
                machineName = "oric1";
            }
            else if (machineType == Machine.Oric_Atmos)
            {
                machineName = "atmos";
            }

            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = String.Format("--machine {0} --tape \"{1}\"", machineName, Path.Combine(tapeInfo.Folder, tapeInfo.Name));

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                String message = ex.Message;

                String errorMessage = "Failed to start the Emulator\n\nPlease check the Emulator location in Options.";
                MessageBox.Show(errorMessage, "Run in Emulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dockPanel1.ActiveDocument.DockHandler.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int index = dockPanel1.Contents.Count - 1; index >= 0; index--)
            {
                if (dockPanel1.Contents[index] is IDockContent)
                {
                    IDockContent content = (IDockContent)dockPanel1.Contents[index];

                    if (content.GetType().Name.Equals("MainView"))
                    {
                        content.DockHandler.Close();
                    }
                }
            }
        }

        private void closeAllButThisOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                if (document.GetType().Name.Equals("MainView"))
                {
                    if (!document.DockHandler.IsActivated)
                    {
                        document.DockHandler.Close();
                    }
                }
            }
        }

        private void editTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TapeInfo tapeInfo = (TapeInfo)fileListForm.treeFileList.SelectedNode.Tag;

            using (EditTapeForm editTapeForm = new EditTapeForm())
            {
                // Setup parameters
                editTapeForm.tapeName = tapeInfo.Name;
                editTapeForm.tapeFolder = tapeInfo.Folder;

                FileInfo tapeFileInfo = new FileInfo(Path.Combine(tapeInfo.Folder, tapeInfo.Name));

                OricTape oricTape = new OricTape();
                OricFileInfo[] tapeCatalog = oricTape.Catalog(tapeFileInfo);

                editTapeForm.tapeCatalog = tapeCatalog;

                // Show edit form
                DialogResult dialogResult = editTapeForm.ShowDialog();

                // Remove tape from tree

                // Create new tape

                // Add tape to tree
            }
        }

        #region Enable/Disable Context Menu Options
        private void diskContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;
        }

        private void tapeContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            TreeNode selectedNode = fileListForm.treeFileList.SelectedNode;

            if (selectedNode.IsExpanded)
            {
                tapeContextMenuStrip.Items[0].Text = "Collapse";
                tapeContextMenuStrip.Items[0].Image = Properties.Resources.Collapse_small;
                tapeContextMenuStrip.Items[0].ImageTransparentColor = Color.Magenta;
            }
            else
            {
                tapeContextMenuStrip.Items[0].Text = "Expand";
                tapeContextMenuStrip.Items[0].Image = Properties.Resources.Expand_small;
                tapeContextMenuStrip.Items[0].ImageTransparentColor = Color.Magenta;
            }
        }

        private void progContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Check we have a valid node
            if(fileListForm.treeFileList.SelectedNode.Tag == null)
                return;

            // Retrieve program information for the selected node
            OricFileInfo ProgramInfo = (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag;

            if (ProgramInfo.MediaType == OricExplorer.MediaType.TapeFile)
            {
                TapeInfo TapeDetails = (TapeInfo)fileListForm.treeFileList.SelectedNode.Parent.Tag;

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
        #endregion

        #region Disk Context Menu Options
        private void createNewDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void convertToTapeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void slideshowViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ScreenViewerForm slideshowViewerForm = new ScreenViewerForm())
            {
                OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Tag;
                slideshowViewerForm.diskInfo = diskInfo;

                slideshowViewerForm.ShowDialog();
            }
        }

        private void diskInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Tag;
            DisplayDiskInformation(diskInfo);
        }

        private void loadIntoEmulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblStatusMain.Text = "Starting emulator...";
            Application.DoEvents();

            // Get emulator executable from configuration settings
            Configuration configuration = new Configuration();

            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Tag;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = configuration.EmulatorExecutable;
            startInfo.WorkingDirectory = Path.GetDirectoryName(configuration.EmulatorExecutable);

            String machineName = "atmos";

            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = String.Format("--machine {0} --disk \"{1}\"", machineName, diskInfo.FullName);

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                String message = ex.Message;

                String errorMessage = "Failed to start the Emulator\n\nPlease check the Emulator location in Options.";
                MessageBox.Show(errorMessage, "Run in Emulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblStatusMain.Text = "Ready.";
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
#endregion

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListForm.treeFileList.TreeViewNodeSorter = new NodeSortedByName();
            fileListForm.treeFileList.Sort();
        }

        private void byTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileListForm.treeFileList.TreeViewNodeSorter = new NodeSortedByType();
            fileListForm.treeFileList.Sort();
        }

        private void convertTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImportTextFileForm importTextFileForm = new ImportTextFileForm())
            {
                DialogResult dialogResult = importTextFileForm.ShowDialog();
            }
        }

        private void displaySectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Tag;
            OricDisk oricDisk = new OricDisk();

            if (oricDisk.LoadDisk(diskInfo.FullName))
            {
                oricDisk.OutputDiskSectors(diskInfo.FullName);
            }

            MessageBox.Show("Sector List", "Sector completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            int documentCount = dockPanel1.DocumentsCount;

            if (documentCount > 0)
            {
                if (dockPanel1.ActiveDocument != null)
                {
                    if (dockPanel1.ActiveDocument.GetType().ToString().Equals("OricExplorer.User_Controls.MainView"))
                    {
                        MainView document = (MainView)dockPanel1.ActiveDocument;

                        if (document != null && document.programInfo != null)
                        {
                            programInfoForm.DisplayProgramInformation(document.programInfo);
                        }
                    }
                    else if (dockPanel1.ActiveDocument.GetType().ToString().Equals("OricExplorer.User_Controls.MainView"))
                    {
                        DiskInfoViewerControl document = (DiskInfoViewerControl)dockPanel1.ActiveDocument;

                        if (document != null)
                        {
                            //programInfoForm.DisplayProgramInformation(document.programInfo);
                        }
                    }
                }
            }
            else
            {
                programInfoForm.ClearInfo();
            }
        }

        private void openEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine what type of file has been selected and open the required Editor
            OricFileInfo fileInfo = (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag;
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Parent.Tag;

            switch (fileInfo.Format)
            {
                case OricProgram.ProgramFormat.BasicProgram:
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    break;

                case OricProgram.ProgramFormat.CodeFile:
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
                    using (TextScreenEditorForm textEditor = new TextScreenEditorForm())
                    {
                        textEditor.fileInfo = fileInfo;
                        textEditor.diskInfo = diskInfo;
                        textEditor.mediaType = OricExplorer.MediaType.DiskFile;

                        DialogResult dialogResult = textEditor.ShowDialog();
                    }
                    break;

                case OricProgram.ProgramFormat.UnknownFile:
                    break;

                default:
                    break;
            }
        }

        private void openDataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OricFileInfo fileInfo = (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag;

            OricProgram loadedProgram = new OricProgram();
            loadedProgram.New();

            switch (fileInfo.MediaType)
            {
                case OricExplorer.MediaType.TapeFile:
                    // Load the selected program from Tape
                    OricTape oricTape = new OricTape();
                    loadedProgram = oricTape.Load(Path.Combine(fileInfo.Folder, fileInfo.ParentName),
                                                  fileInfo.ProgramName, fileInfo.ProgramIndex);
                    break;

                case OricExplorer.MediaType.DiskFile:
                    loadedProgram = fileInfo.LoadFile();
                    break;

                default:
                    break;
            }

            DataViewerForm dataViewerForm = new DataViewerForm(fileInfo, loadedProgram);
            dataViewerForm.ShowDialog();
        }

        private void rawDataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OricDiskInfo diskInfo = (OricDiskInfo)fileListForm.treeFileList.SelectedNode.Tag;
            DisplayUnknownDisk(diskInfo);
        }

        #region Initial version check
        private Boolean getVersionFromWebsite()
        {
            Version newVersion = null;

            try
            {
                // Provide the XmlTextReader with the URL of our xml document
                String xmlURL = "http://oric.mrandmrsdavies.com/app_version.xml";

                XmlTextReader reader = new XmlTextReader(xmlURL);

                // Simply (and easily) skip the junk at the beginning
                reader.MoveToContent();

                // internal - as the XmlTextReader moves only forward, we save current xml element name
                // in elementName variable. When we parse a text node, we refer to elementName to check
                // what was the node name
                string elementName = "";

                // We check if the xml starts with a proper "ourfancyapp" element node
                if ((reader.NodeType == XmlNodeType.Element)) // && (reader.Name == "oricexplorer"))
                {
                    while (reader.Read())
                    {
                        // When we find an element node, we remember its name
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                // We check what the name of the node was
                                switch (elementName)
                                {
                                    case "version":
                                        // Thats why we keep the version info in xxx.xxx.xxx.xxx format
                                        // the Version class does the parsing for us
                                        newVersion = new Version(reader.Value);
                                        break;
                                }
                            }
                        }
                    }
                }

                reader.Close();

                compareVersions(newVersion);
            }
            catch (FileNotFoundException ex)
            {
                String message = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private Boolean compareVersions(Version newVersion)
        {
            Boolean newVersionAvailable = false;

            // Example : 2.1.3.4567
            // Major.Minor.Build.Revision

            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            int result = curVersion.CompareTo(newVersion);

            if (curVersion.CompareTo(newVersion) < 0)
            {
                newVersionAvailable = true;
            }
            else
            {
                newVersionAvailable = false;
            }

            return newVersionAvailable;
        }
        #endregion

        private void syntaxHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SyntaxHighlightingForm syntaxHighlightingForm = new SyntaxHighlightingForm())
            {
                syntaxHighlightingForm.ShowDialog();
            }
        }

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

        private void tapeFiletapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Tape, (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag);
        }

        private void textFiletxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Text, (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag);
        }

        private void rawFilenoHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFile(ExportTo.Raw, (OricFileInfo)fileListForm.treeFileList.SelectedNode.Tag);
        }

        private void exportFile(ExportTo exportTo, OricFileInfo fileInfo)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export file to";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(fileInfo.ProgramName);

            switch(exportTo)
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

            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                // Load into memory
                OricProgram program = new OricProgram();
                program = fileInfo.LoadFile();

                switch (exportTo)
                {
                    case ExportTo.Tape:
                        {
                            // Setup name of the Tape
                            if (fileInfo.Name.Length == 0)
                            {
                                program.ProgramName = "NONAME";
                            }
                            else
                            {
                                program.ProgramName = String.Format("{0}.{1}", fileInfo.Name, fileInfo.Extension);
                            }

                            // Create a new tape file
                            OricTape tape = new OricTape();
                            tape.TapeName = saveFileDialog.FileName;
                            tape.SaveFile(program);
                        }
                        break;

                    case ExportTo.Text:
                        using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                        {
                            if (program.Format == OricProgram.ProgramFormat.BasicProgram)
                            {
                                sw.Write(program.ListAsText());
                            }
                            else
                            {
                                sw.Write(program.Hexdump());
                            }
                        }
                        break;

                    case ExportTo.Raw:
                        Encoding utf8 = Encoding.UTF8;

                        // Create a new binary file
                        using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create), utf8))
                        {
                            bw.Write(program.m_programData);
                        }
                        break;

                    default:
                        break;
                }

                MessageBox.Show("Exported successfully", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
