using System.Windows.Forms;
namespace OricExplorer
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewCloseAllButThisOne = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsImportAtmosBasicFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsSyntaxHighlighting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsslStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDisplayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOverallTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmnuProgram = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuProgramViewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramOpenDataViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramOpenEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuProgramCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuProgramAutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramAutoRunEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramAutorunDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuProgramExtractTo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramExtractToTapeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramExtractToTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuProgramExtractToRawFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ttpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.prtDocument = new System.Drawing.Printing.PrintDocument();
            this.prtPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.prtDialog = new System.Windows.Forms.PrintDialog();
            this.prtPageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.cmnuTape = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuTapeViewFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuTapeOutputDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuTapeLoadIntoEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeLoadIntoEmulatorPravetz = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeLoadIntoEmulatorOric1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeLoadIntoEmulatorAtmos = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuTapeCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuTapeEditTape = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeAddToDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeConvertToDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuTapeSep5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuTapeRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dkpPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.cmnuDisk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuDiskRawDataViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskDiskInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskScreenViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDiskOutputDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskOutputDirectoryToPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskOutputDirectoryToTextFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskOutputDirectoryToPrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDiskLoadIntoEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDiskCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDiskCreateNewDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskFormatDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskConvertToTape = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSortDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSortDirectoryByName = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSortDirectoryByType = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDiskSep5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuDiskRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUnknownDisk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuUnknownDiskRawDataViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuUnknownDiskLoadIntoEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUnknownDiskLoadIntoEmulatorOric1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuRomViewRom = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRomSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuRomCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRomDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRomRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRomSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuRomRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrAfterLabelEdit = new System.Windows.Forms.Timer(this.components);
            this.cmnuOtherFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOtherFilesViewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.ssStatusBar.SuspendLayout();
            this.cmnuProgram.SuspendLayout();
            this.cmnuTape.SuspendLayout();
            this.cmnuDisk.SuspendLayout();
            this.cmnuUnknownDisk.SuspendLayout();
            this.cmnuRom.SuspendLayout();
            this.cmnuOtherFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuEdit,
            this.mnuTools,
            this.mnuHelp});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(839, 24);
            this.mnu.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFileExit.Size = new System.Drawing.Size(180, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Enabled = false;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Visible = false;
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewClose,
            this.mnuViewCloseAll,
            this.mnuViewCloseAllButThisOne,
            this.mnuViewSep1,
            this.mnuViewRefresh});
            this.mnuView.Name = "mnuView";
            this.mnuView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            this.mnuView.DropDownOpening += new System.EventHandler(this.mnuView_DropDownOpening);
            // 
            // mnuViewClose
            // 
            this.mnuViewClose.Name = "mnuViewClose";
            this.mnuViewClose.Size = new System.Drawing.Size(180, 22);
            this.mnuViewClose.Text = "Close";
            this.mnuViewClose.Click += new System.EventHandler(this.mnuViewClose_Click);
            // 
            // mnuViewCloseAll
            // 
            this.mnuViewCloseAll.Name = "mnuViewCloseAll";
            this.mnuViewCloseAll.Size = new System.Drawing.Size(180, 22);
            this.mnuViewCloseAll.Text = "Close All";
            this.mnuViewCloseAll.Click += new System.EventHandler(this.mnuViewCloseAll_Click);
            // 
            // mnuViewCloseAllButThisOne
            // 
            this.mnuViewCloseAllButThisOne.Name = "mnuViewCloseAllButThisOne";
            this.mnuViewCloseAllButThisOne.Size = new System.Drawing.Size(180, 22);
            this.mnuViewCloseAllButThisOne.Text = "Close All But This";
            this.mnuViewCloseAllButThisOne.Click += new System.EventHandler(this.mnuViewCloseAllButThisOne_Click);
            // 
            // mnuViewSep1
            // 
            this.mnuViewSep1.Name = "mnuViewSep1";
            this.mnuViewSep1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuViewRefresh
            // 
            this.mnuViewRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewRefresh.Image")));
            this.mnuViewRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuViewRefresh.Name = "mnuViewRefresh";
            this.mnuViewRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuViewRefresh.Size = new System.Drawing.Size(180, 22);
            this.mnuViewRefresh.Text = "Refresh";
            this.mnuViewRefresh.Click += new System.EventHandler(this.mnuViewRefresh_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsImportAtmosBasicFile,
            this.mnuToolsSep1,
            this.mnuToolsSyntaxHighlighting,
            this.mnuToolsSep2,
            this.mnuToolsSettings});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsImportAtmosBasicFile
            // 
            this.mnuToolsImportAtmosBasicFile.Name = "mnuToolsImportAtmosBasicFile";
            this.mnuToolsImportAtmosBasicFile.Size = new System.Drawing.Size(251, 22);
            this.mnuToolsImportAtmosBasicFile.Text = "Import Oric-1/Atmos BASIC File...";
            this.mnuToolsImportAtmosBasicFile.Click += new System.EventHandler(this.mnuToolsImportAtmosBasicFile_Click);
            // 
            // mnuToolsSep1
            // 
            this.mnuToolsSep1.Name = "mnuToolsSep1";
            this.mnuToolsSep1.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuToolsSyntaxHighlighting
            // 
            this.mnuToolsSyntaxHighlighting.Name = "mnuToolsSyntaxHighlighting";
            this.mnuToolsSyntaxHighlighting.Size = new System.Drawing.Size(251, 22);
            this.mnuToolsSyntaxHighlighting.Text = "Syntax Highlighting...";
            this.mnuToolsSyntaxHighlighting.Click += new System.EventHandler(this.mnuToolsSyntaxHighlighting_Click);
            // 
            // mnuToolsSep2
            // 
            this.mnuToolsSep2.Name = "mnuToolsSep2";
            this.mnuToolsSep2.Size = new System.Drawing.Size(248, 6);
            // 
            // mnuToolsSettings
            // 
            this.mnuToolsSettings.Image = ((System.Drawing.Image)(resources.GetObject("mnuToolsSettings.Image")));
            this.mnuToolsSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuToolsSettings.Name = "mnuToolsSettings";
            this.mnuToolsSettings.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.mnuToolsSettings.Size = new System.Drawing.Size(251, 22);
            this.mnuToolsSettings.Text = "Settings...";
            this.mnuToolsSettings.Click += new System.EventHandler(this.mnuToolsSettings_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpCheckForUpdates,
            this.mnuHelpSep1,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpCheckForUpdates
            // 
            this.mnuHelpCheckForUpdates.Name = "mnuHelpCheckForUpdates";
            this.mnuHelpCheckForUpdates.Size = new System.Drawing.Size(197, 22);
            this.mnuHelpCheckForUpdates.Text = "Check for updates...";
            this.mnuHelpCheckForUpdates.Click += new System.EventHandler(this.mnuHelpCheckForUpdates_Click);
            // 
            // mnuHelpSep1
            // 
            this.mnuHelpSep1.Name = "mnuHelpSep1";
            this.mnuHelpSep1.Size = new System.Drawing.Size(194, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Image = ((System.Drawing.Image)(resources.GetObject("mnuHelpAbout.Image")));
            this.mnuHelpAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelpAbout.Size = new System.Drawing.Size(197, 22);
            this.mnuHelpAbout.Text = "About Oric Explorer";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatusMain,
            this.tsslLoadTime,
            this.tsslDisplayTime,
            this.tsslOverallTime});
            this.ssStatusBar.Location = new System.Drawing.Point(0, 454);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.Size = new System.Drawing.Size(839, 24);
            this.ssStatusBar.TabIndex = 2;
            // 
            // tsslStatusMain
            // 
            this.tsslStatusMain.ForeColor = System.Drawing.Color.Black;
            this.tsslStatusMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslStatusMain.Name = "tsslStatusMain";
            this.tsslStatusMain.Size = new System.Drawing.Size(674, 19);
            this.tsslStatusMain.Spring = true;
            this.tsslStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslLoadTime
            // 
            this.tsslLoadTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslLoadTime.ForeColor = System.Drawing.Color.Blue;
            this.tsslLoadTime.Name = "tsslLoadTime";
            this.tsslLoadTime.Size = new System.Drawing.Size(50, 19);
            this.tsslLoadTime.Text = "000.000";
            // 
            // tsslDisplayTime
            // 
            this.tsslDisplayTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslDisplayTime.ForeColor = System.Drawing.Color.Blue;
            this.tsslDisplayTime.Name = "tsslDisplayTime";
            this.tsslDisplayTime.Size = new System.Drawing.Size(50, 19);
            this.tsslDisplayTime.Text = "000.000";
            // 
            // tsslOverallTime
            // 
            this.tsslOverallTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslOverallTime.ForeColor = System.Drawing.Color.Blue;
            this.tsslOverallTime.Name = "tsslOverallTime";
            this.tsslOverallTime.Size = new System.Drawing.Size(50, 19);
            this.tsslOverallTime.Text = "000.000";
            // 
            // cmnuProgram
            // 
            this.cmnuProgram.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuProgramViewFile,
            this.cmnuProgramOpenDataViewer,
            this.cmnuProgramOpenEditor,
            this.cmnuProgramSep1,
            this.cmnuProgramCopy,
            this.cmnuProgramDelete,
            this.cmnuProgramRename,
            this.cmnuProgramSep2,
            this.cmnuProgramAutoRun,
            this.cmnuProgramSep3,
            this.cmnuProgramExtractTo});
            this.cmnuProgram.Name = "contextMenuStrip2";
            this.cmnuProgram.Size = new System.Drawing.Size(178, 198);
            this.cmnuProgram.Text = "Program Menu";
            this.cmnuProgram.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuProgram_Opening);
            // 
            // cmnuProgramViewFile
            // 
            this.cmnuProgramViewFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuProgramViewFile.Image = global::OricExplorer.Properties.Resources.view;
            this.cmnuProgramViewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuProgramViewFile.Name = "cmnuProgramViewFile";
            this.cmnuProgramViewFile.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramViewFile.Text = "View file";
            this.cmnuProgramViewFile.Click += new System.EventHandler(this.cmnuProgramViewFile_Click);
            // 
            // cmnuProgramOpenDataViewer
            // 
            this.cmnuProgramOpenDataViewer.Name = "cmnuProgramOpenDataViewer";
            this.cmnuProgramOpenDataViewer.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramOpenDataViewer.Text = "Open Data Viewer...";
            this.cmnuProgramOpenDataViewer.Click += new System.EventHandler(this.cmnuProgramOpenDataViewer_Click);
            // 
            // cmnuProgramOpenEditor
            // 
            this.cmnuProgramOpenEditor.Name = "cmnuProgramOpenEditor";
            this.cmnuProgramOpenEditor.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramOpenEditor.Text = "Open Editor...";
            this.cmnuProgramOpenEditor.Visible = false;
            this.cmnuProgramOpenEditor.Click += new System.EventHandler(this.cmnuProgramOpenEditor_Click);
            // 
            // cmnuProgramSep1
            // 
            this.cmnuProgramSep1.Name = "cmnuProgramSep1";
            this.cmnuProgramSep1.Size = new System.Drawing.Size(174, 6);
            // 
            // cmnuProgramCopy
            // 
            this.cmnuProgramCopy.Enabled = false;
            this.cmnuProgramCopy.Image = ((System.Drawing.Image)(resources.GetObject("cmnuProgramCopy.Image")));
            this.cmnuProgramCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuProgramCopy.Name = "cmnuProgramCopy";
            this.cmnuProgramCopy.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramCopy.Text = "Copy";
            this.cmnuProgramCopy.Visible = false;
            // 
            // cmnuProgramDelete
            // 
            this.cmnuProgramDelete.Enabled = false;
            this.cmnuProgramDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmnuProgramDelete.Image")));
            this.cmnuProgramDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuProgramDelete.Name = "cmnuProgramDelete";
            this.cmnuProgramDelete.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramDelete.Text = "Delete";
            this.cmnuProgramDelete.Visible = false;
            this.cmnuProgramDelete.Click += new System.EventHandler(this.cmnuProgramDelete_Click);
            // 
            // cmnuProgramRename
            // 
            this.cmnuProgramRename.Enabled = false;
            this.cmnuProgramRename.Image = ((System.Drawing.Image)(resources.GetObject("cmnuProgramRename.Image")));
            this.cmnuProgramRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuProgramRename.Name = "cmnuProgramRename";
            this.cmnuProgramRename.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramRename.Text = "Rename";
            this.cmnuProgramRename.Visible = false;
            // 
            // cmnuProgramSep2
            // 
            this.cmnuProgramSep2.Name = "cmnuProgramSep2";
            this.cmnuProgramSep2.Size = new System.Drawing.Size(174, 6);
            this.cmnuProgramSep2.Visible = false;
            // 
            // cmnuProgramAutoRun
            // 
            this.cmnuProgramAutoRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuProgramAutoRunEnabled,
            this.cmnuProgramAutorunDisabled});
            this.cmnuProgramAutoRun.Enabled = false;
            this.cmnuProgramAutoRun.Name = "cmnuProgramAutoRun";
            this.cmnuProgramAutoRun.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramAutoRun.Text = "Set Auto Run State";
            this.cmnuProgramAutoRun.Visible = false;
            // 
            // cmnuProgramAutoRunEnabled
            // 
            this.cmnuProgramAutoRunEnabled.Name = "cmnuProgramAutoRunEnabled";
            this.cmnuProgramAutoRunEnabled.Size = new System.Drawing.Size(119, 22);
            this.cmnuProgramAutoRunEnabled.Text = "Enabled";
            // 
            // cmnuProgramAutorunDisabled
            // 
            this.cmnuProgramAutorunDisabled.Name = "cmnuProgramAutorunDisabled";
            this.cmnuProgramAutorunDisabled.Size = new System.Drawing.Size(119, 22);
            this.cmnuProgramAutorunDisabled.Text = "Disabled";
            // 
            // cmnuProgramSep3
            // 
            this.cmnuProgramSep3.Name = "cmnuProgramSep3";
            this.cmnuProgramSep3.Size = new System.Drawing.Size(174, 6);
            this.cmnuProgramSep3.Visible = false;
            // 
            // cmnuProgramExtractTo
            // 
            this.cmnuProgramExtractTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuProgramExtractToTapeFile,
            this.cmnuProgramExtractToTextFile,
            this.cmnuProgramExtractToRawFile});
            this.cmnuProgramExtractTo.Name = "cmnuProgramExtractTo";
            this.cmnuProgramExtractTo.Size = new System.Drawing.Size(177, 22);
            this.cmnuProgramExtractTo.Text = "Extract To...";
            // 
            // cmnuProgramExtractToTapeFile
            // 
            this.cmnuProgramExtractToTapeFile.Name = "cmnuProgramExtractToTapeFile";
            this.cmnuProgramExtractToTapeFile.Size = new System.Drawing.Size(179, 22);
            this.cmnuProgramExtractToTapeFile.Text = "Tape file (tap)";
            this.cmnuProgramExtractToTapeFile.Click += new System.EventHandler(this.cmnuProgramExtractToTapeFile_Click);
            // 
            // cmnuProgramExtractToTextFile
            // 
            this.cmnuProgramExtractToTextFile.Name = "cmnuProgramExtractToTextFile";
            this.cmnuProgramExtractToTextFile.Size = new System.Drawing.Size(179, 22);
            this.cmnuProgramExtractToTextFile.Text = "Text file (txt)";
            this.cmnuProgramExtractToTextFile.Click += new System.EventHandler(this.cmnuProgramExtractToTextFile_Click);
            // 
            // cmnuProgramExtractToRawFile
            // 
            this.cmnuProgramExtractToRawFile.Name = "cmnuProgramExtractToRawFile";
            this.cmnuProgramExtractToRawFile.Size = new System.Drawing.Size(179, 22);
            this.cmnuProgramExtractToRawFile.Text = "Raw file (no header)";
            this.cmnuProgramExtractToRawFile.Click += new System.EventHandler(this.cmnuProgramExtractToRawFile_Click);
            // 
            // prtPreviewDialog
            // 
            this.prtPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prtPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prtPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.prtPreviewDialog.Document = this.prtDocument;
            this.prtPreviewDialog.Enabled = true;
            this.prtPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("prtPreviewDialog.Icon")));
            this.prtPreviewDialog.Name = "printPreviewDialog1";
            this.prtPreviewDialog.UseAntiAlias = true;
            this.prtPreviewDialog.Visible = false;
            // 
            // prtDialog
            // 
            this.prtDialog.Document = this.prtDocument;
            this.prtDialog.UseEXDialog = true;
            // 
            // prtPageSetupDialog
            // 
            this.prtPageSetupDialog.Document = this.prtDocument;
            // 
            // cmnuTape
            // 
            this.cmnuTape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuTapeViewFiles,
            this.cmnuTapeSep1,
            this.cmnuTapeOutputDirectory,
            this.cmnuTapeSep2,
            this.cmnuTapeLoadIntoEmulator,
            this.cmnuTapeSep3,
            this.cmnuTapeCopy,
            this.cmnuTapeDelete,
            this.cmnuTapeRename,
            this.cmnuTapeSep4,
            this.cmnuTapeEditTape,
            this.cmnuTapeAddToDisk,
            this.cmnuTapeConvertToDisk,
            this.cmnuTapeSep5,
            this.cmnuTapeRefresh});
            this.cmnuTape.Name = "tapeContextMenuStrip";
            this.cmnuTape.Size = new System.Drawing.Size(179, 254);
            // 
            // cmnuTapeViewFiles
            // 
            this.cmnuTapeViewFiles.Image = global::OricExplorer.Properties.Resources.view;
            this.cmnuTapeViewFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuTapeViewFiles.Name = "cmnuTapeViewFiles";
            this.cmnuTapeViewFiles.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeViewFiles.Text = "View files";
            this.cmnuTapeViewFiles.Click += new System.EventHandler(this.cmnuTapeViewFiles_Click);
            // 
            // cmnuTapeSep1
            // 
            this.cmnuTapeSep1.Name = "cmnuTapeSep1";
            this.cmnuTapeSep1.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuTapeOutputDirectory
            // 
            this.cmnuTapeOutputDirectory.Name = "cmnuTapeOutputDirectory";
            this.cmnuTapeOutputDirectory.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeOutputDirectory.Text = "Output Directory";
            this.cmnuTapeOutputDirectory.Click += new System.EventHandler(this.cmnuTapeOutputDirectory_Click);
            // 
            // cmnuTapeSep2
            // 
            this.cmnuTapeSep2.Name = "cmnuTapeSep2";
            this.cmnuTapeSep2.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuTapeLoadIntoEmulator
            // 
            this.cmnuTapeLoadIntoEmulator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuTapeLoadIntoEmulatorPravetz,
            this.cmnuTapeLoadIntoEmulatorOric1,
            this.cmnuTapeLoadIntoEmulatorAtmos});
            this.cmnuTapeLoadIntoEmulator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuTapeLoadIntoEmulator.Image = global::OricExplorer.Properties.Resources.emulator;
            this.cmnuTapeLoadIntoEmulator.Name = "cmnuTapeLoadIntoEmulator";
            this.cmnuTapeLoadIntoEmulator.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeLoadIntoEmulator.Text = "Load into Emulator";
            this.cmnuTapeLoadIntoEmulator.DropDownOpening += new System.EventHandler(this.cmnuTapeLoadIntoEmulator_DropDownOpening);
            // 
            // cmnuTapeLoadIntoEmulatorPravetz
            // 
            this.cmnuTapeLoadIntoEmulatorPravetz.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuTapeLoadIntoEmulatorPravetz.Image = ((System.Drawing.Image)(resources.GetObject("cmnuTapeLoadIntoEmulatorPravetz.Image")));
            this.cmnuTapeLoadIntoEmulatorPravetz.Name = "cmnuTapeLoadIntoEmulatorPravetz";
            this.cmnuTapeLoadIntoEmulatorPravetz.Size = new System.Drawing.Size(112, 22);
            this.cmnuTapeLoadIntoEmulatorPravetz.Text = "Pravetz";
            this.cmnuTapeLoadIntoEmulatorPravetz.Click += new System.EventHandler(this.cmnuTapeLoadIntoEmulatorPravetz_Click);
            // 
            // cmnuTapeLoadIntoEmulatorOric1
            // 
            this.cmnuTapeLoadIntoEmulatorOric1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuTapeLoadIntoEmulatorOric1.Image = ((System.Drawing.Image)(resources.GetObject("cmnuTapeLoadIntoEmulatorOric1.Image")));
            this.cmnuTapeLoadIntoEmulatorOric1.Name = "cmnuTapeLoadIntoEmulatorOric1";
            this.cmnuTapeLoadIntoEmulatorOric1.Size = new System.Drawing.Size(112, 22);
            this.cmnuTapeLoadIntoEmulatorOric1.Text = "Oric-1";
            this.cmnuTapeLoadIntoEmulatorOric1.Click += new System.EventHandler(this.cmnuTapeLoadIntoEmulatorOric1_Click);
            // 
            // cmnuTapeLoadIntoEmulatorAtmos
            // 
            this.cmnuTapeLoadIntoEmulatorAtmos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuTapeLoadIntoEmulatorAtmos.Image = ((System.Drawing.Image)(resources.GetObject("cmnuTapeLoadIntoEmulatorAtmos.Image")));
            this.cmnuTapeLoadIntoEmulatorAtmos.Name = "cmnuTapeLoadIntoEmulatorAtmos";
            this.cmnuTapeLoadIntoEmulatorAtmos.Size = new System.Drawing.Size(112, 22);
            this.cmnuTapeLoadIntoEmulatorAtmos.Text = "Atmos";
            this.cmnuTapeLoadIntoEmulatorAtmos.Click += new System.EventHandler(this.cmnuTapeLoadIntoEmulatorAtmos_Click);
            // 
            // cmnuTapeSep3
            // 
            this.cmnuTapeSep3.Name = "cmnuTapeSep3";
            this.cmnuTapeSep3.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuTapeCopy
            // 
            this.cmnuTapeCopy.Image = global::OricExplorer.Properties.Resources.copy;
            this.cmnuTapeCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuTapeCopy.Name = "cmnuTapeCopy";
            this.cmnuTapeCopy.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeCopy.Text = "Copy";
            this.cmnuTapeCopy.Click += new System.EventHandler(this.cmnuTapeCopy_Click);
            // 
            // cmnuTapeDelete
            // 
            this.cmnuTapeDelete.Image = global::OricExplorer.Properties.Resources.delete;
            this.cmnuTapeDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuTapeDelete.Name = "cmnuTapeDelete";
            this.cmnuTapeDelete.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeDelete.Text = "Delete";
            this.cmnuTapeDelete.Click += new System.EventHandler(this.cmnuTapeDelete_Click);
            // 
            // cmnuTapeRename
            // 
            this.cmnuTapeRename.Image = global::OricExplorer.Properties.Resources.rename;
            this.cmnuTapeRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuTapeRename.Name = "cmnuTapeRename";
            this.cmnuTapeRename.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeRename.Text = "Rename";
            this.cmnuTapeRename.Click += new System.EventHandler(this.cmnuDiskRename_Click);
            // 
            // cmnuTapeSep4
            // 
            this.cmnuTapeSep4.Name = "cmnuTapeSep4";
            this.cmnuTapeSep4.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuTapeEditTape
            // 
            this.cmnuTapeEditTape.Image = global::OricExplorer.Properties.Resources.tape;
            this.cmnuTapeEditTape.Name = "cmnuTapeEditTape";
            this.cmnuTapeEditTape.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeEditTape.Text = "Edit Tape";
            this.cmnuTapeEditTape.Click += new System.EventHandler(this.cmnuTapeEditTape_Click);
            // 
            // cmnuTapeAddToDisk
            // 
            this.cmnuTapeAddToDisk.Enabled = false;
            this.cmnuTapeAddToDisk.Name = "cmnuTapeAddToDisk";
            this.cmnuTapeAddToDisk.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeAddToDisk.Text = "Add to Disk...";
            this.cmnuTapeAddToDisk.Visible = false;
            // 
            // cmnuTapeConvertToDisk
            // 
            this.cmnuTapeConvertToDisk.Enabled = false;
            this.cmnuTapeConvertToDisk.Name = "cmnuTapeConvertToDisk";
            this.cmnuTapeConvertToDisk.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeConvertToDisk.Text = "Convert to Disk...";
            this.cmnuTapeConvertToDisk.Visible = false;
            // 
            // cmnuTapeSep5
            // 
            this.cmnuTapeSep5.Name = "cmnuTapeSep5";
            this.cmnuTapeSep5.Size = new System.Drawing.Size(175, 6);
            this.cmnuTapeSep5.Visible = false;
            // 
            // cmnuTapeRefresh
            // 
            this.cmnuTapeRefresh.Enabled = false;
            this.cmnuTapeRefresh.Image = global::OricExplorer.Properties.Resources.refresh;
            this.cmnuTapeRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuTapeRefresh.Name = "cmnuTapeRefresh";
            this.cmnuTapeRefresh.Size = new System.Drawing.Size(178, 22);
            this.cmnuTapeRefresh.Text = "Refresh";
            this.cmnuTapeRefresh.Visible = false;
            // 
            // dkpPanel
            // 
            this.dkpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dkpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dkpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dkpPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dkpPanel.DockRightPortion = 300D;
            this.dkpPanel.ForeColor = System.Drawing.Color.Black;
            this.dkpPanel.Location = new System.Drawing.Point(0, 25);
            this.dkpPanel.Name = "dkpPanel";
            this.dkpPanel.ShowAutoHideContentOnHover = false;
            this.dkpPanel.ShowDocumentIcon = true;
            this.dkpPanel.Size = new System.Drawing.Size(838, 430);
            this.dkpPanel.TabIndex = 4;
            this.dkpPanel.ActiveDocumentChanged += new System.EventHandler(this.dkpPanel_ActiveDocumentChanged);
            // 
            // cmnuDisk
            // 
            this.cmnuDisk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDiskRawDataViewer,
            this.cmnuDiskDiskInformation,
            this.cmnuDiskScreenViewer,
            this.cmnuDiskSep1,
            this.cmnuDiskOutputDirectory,
            this.cmnuDiskSep2,
            this.cmnuDiskLoadIntoEmulator,
            this.cmnuDiskSep3,
            this.cmnuDiskCopy,
            this.cmnuDiskDelete,
            this.cmnuDiskRename,
            this.cmnuDiskSep4,
            this.cmnuDiskCreateNewDisk,
            this.cmnuDiskFormatDisk,
            this.cmnuDiskConvertToTape,
            this.cmnuDiskSortDirectory,
            this.cmnuDiskSep5,
            this.cmnuDiskRefresh});
            this.cmnuDisk.Name = "diskContextMenuStrip";
            this.cmnuDisk.Size = new System.Drawing.Size(179, 320);
            this.cmnuDisk.Text = "Disk Options";
            this.cmnuDisk.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuDisk_Opening);
            // 
            // cmnuDiskRawDataViewer
            // 
            this.cmnuDiskRawDataViewer.Name = "cmnuDiskRawDataViewer";
            this.cmnuDiskRawDataViewer.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskRawDataViewer.Text = "Raw Data Viewer";
            this.cmnuDiskRawDataViewer.Click += new System.EventHandler(this.cmnuDiskRawDataViewer_Click);
            // 
            // cmnuDiskDiskInformation
            // 
            this.cmnuDiskDiskInformation.Image = global::OricExplorer.Properties.Resources.information;
            this.cmnuDiskDiskInformation.Name = "cmnuDiskDiskInformation";
            this.cmnuDiskDiskInformation.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskDiskInformation.Text = "Disk Information...";
            this.cmnuDiskDiskInformation.Click += new System.EventHandler(this.cmnuDiskDiskInformation_Click);
            // 
            // cmnuDiskScreenViewer
            // 
            this.cmnuDiskScreenViewer.Image = global::OricExplorer.Properties.Resources.images;
            this.cmnuDiskScreenViewer.Name = "cmnuDiskScreenViewer";
            this.cmnuDiskScreenViewer.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskScreenViewer.Text = "Screen Viewer...";
            this.cmnuDiskScreenViewer.Click += new System.EventHandler(this.cmnuDiskScreenViewer_Click);
            // 
            // cmnuDiskSep1
            // 
            this.cmnuDiskSep1.Name = "cmnuDiskSep1";
            this.cmnuDiskSep1.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuDiskOutputDirectory
            // 
            this.cmnuDiskOutputDirectory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDiskOutputDirectoryToPDF,
            this.cmnuDiskOutputDirectoryToTextFile,
            this.cmnuDiskOutputDirectoryToPrinter});
            this.cmnuDiskOutputDirectory.Name = "cmnuDiskOutputDirectory";
            this.cmnuDiskOutputDirectory.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskOutputDirectory.Text = "Output directory";
            this.cmnuDiskOutputDirectory.Click += new System.EventHandler(this.cmnuDiskOutputDirectory_Click);
            // 
            // cmnuDiskOutputDirectoryToPDF
            // 
            this.cmnuDiskOutputDirectoryToPDF.Name = "cmnuDiskOutputDirectoryToPDF";
            this.cmnuDiskOutputDirectoryToPDF.Size = new System.Drawing.Size(128, 22);
            this.cmnuDiskOutputDirectoryToPDF.Text = "to PDF";
            this.cmnuDiskOutputDirectoryToPDF.Visible = false;
            this.cmnuDiskOutputDirectoryToPDF.Click += new System.EventHandler(this.cmnuDiskOutputDirectoryToPDF_Click);
            // 
            // cmnuDiskOutputDirectoryToTextFile
            // 
            this.cmnuDiskOutputDirectoryToTextFile.Name = "cmnuDiskOutputDirectoryToTextFile";
            this.cmnuDiskOutputDirectoryToTextFile.Size = new System.Drawing.Size(128, 22);
            this.cmnuDiskOutputDirectoryToTextFile.Text = "to Text file";
            this.cmnuDiskOutputDirectoryToTextFile.Visible = false;
            this.cmnuDiskOutputDirectoryToTextFile.Click += new System.EventHandler(this.cmnuDiskOutputDirectoryToTextFile_Click);
            // 
            // cmnuDiskOutputDirectoryToPrinter
            // 
            this.cmnuDiskOutputDirectoryToPrinter.Name = "cmnuDiskOutputDirectoryToPrinter";
            this.cmnuDiskOutputDirectoryToPrinter.Size = new System.Drawing.Size(128, 22);
            this.cmnuDiskOutputDirectoryToPrinter.Text = "to Printer";
            this.cmnuDiskOutputDirectoryToPrinter.Visible = false;
            this.cmnuDiskOutputDirectoryToPrinter.Click += new System.EventHandler(this.cmnuDiskOutputDirectoryToPrinter_Click);
            // 
            // cmnuDiskSep2
            // 
            this.cmnuDiskSep2.Name = "cmnuDiskSep2";
            this.cmnuDiskSep2.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuDiskLoadIntoEmulator
            // 
            this.cmnuDiskLoadIntoEmulator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuDiskLoadIntoEmulator.Image = global::OricExplorer.Properties.Resources.emulator;
            this.cmnuDiskLoadIntoEmulator.Name = "cmnuDiskLoadIntoEmulator";
            this.cmnuDiskLoadIntoEmulator.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskLoadIntoEmulator.Text = "Load into Emulator";
            this.cmnuDiskLoadIntoEmulator.Click += new System.EventHandler(this.cmnuDiskLoadIntoEmulator_Click);
            // 
            // cmnuDiskSep3
            // 
            this.cmnuDiskSep3.Name = "cmnuDiskSep3";
            this.cmnuDiskSep3.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuDiskCopy
            // 
            this.cmnuDiskCopy.Image = global::OricExplorer.Properties.Resources.copy;
            this.cmnuDiskCopy.Name = "cmnuDiskCopy";
            this.cmnuDiskCopy.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskCopy.Text = "Copy";
            this.cmnuDiskCopy.Click += new System.EventHandler(this.cmnuDiskCopy_Click);
            // 
            // cmnuDiskDelete
            // 
            this.cmnuDiskDelete.Image = global::OricExplorer.Properties.Resources.delete;
            this.cmnuDiskDelete.Name = "cmnuDiskDelete";
            this.cmnuDiskDelete.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskDelete.Text = "Delete";
            this.cmnuDiskDelete.Click += new System.EventHandler(this.cmnuDiskDelete_Click);
            // 
            // cmnuDiskRename
            // 
            this.cmnuDiskRename.Image = global::OricExplorer.Properties.Resources.rename;
            this.cmnuDiskRename.Name = "cmnuDiskRename";
            this.cmnuDiskRename.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskRename.Text = "Rename";
            this.cmnuDiskRename.Click += new System.EventHandler(this.cmnuDiskRename_Click);
            // 
            // cmnuDiskSep4
            // 
            this.cmnuDiskSep4.Name = "cmnuDiskSep4";
            this.cmnuDiskSep4.Size = new System.Drawing.Size(175, 6);
            // 
            // cmnuDiskCreateNewDisk
            // 
            this.cmnuDiskCreateNewDisk.Enabled = false;
            this.cmnuDiskCreateNewDisk.Name = "cmnuDiskCreateNewDisk";
            this.cmnuDiskCreateNewDisk.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskCreateNewDisk.Text = "Create new disk...";
            this.cmnuDiskCreateNewDisk.Visible = false;
            this.cmnuDiskCreateNewDisk.Click += new System.EventHandler(this.cmnuDiskCreateNewDisk_Click);
            // 
            // cmnuDiskFormatDisk
            // 
            this.cmnuDiskFormatDisk.Enabled = false;
            this.cmnuDiskFormatDisk.Name = "cmnuDiskFormatDisk";
            this.cmnuDiskFormatDisk.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskFormatDisk.Text = "Format disk...";
            this.cmnuDiskFormatDisk.Visible = false;
            this.cmnuDiskFormatDisk.Click += new System.EventHandler(this.cmnuDiskFormatDisk_Click);
            // 
            // cmnuDiskConvertToTape
            // 
            this.cmnuDiskConvertToTape.Enabled = false;
            this.cmnuDiskConvertToTape.Name = "cmnuDiskConvertToTape";
            this.cmnuDiskConvertToTape.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskConvertToTape.Text = "Convert to tape...";
            this.cmnuDiskConvertToTape.Visible = false;
            this.cmnuDiskConvertToTape.Click += new System.EventHandler(this.cmnuDiskConvertToTape_Click);
            // 
            // cmnuDiskSortDirectory
            // 
            this.cmnuDiskSortDirectory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDiskSortDirectoryByName,
            this.cmnuDiskSortDirectoryByType});
            this.cmnuDiskSortDirectory.Name = "cmnuDiskSortDirectory";
            this.cmnuDiskSortDirectory.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskSortDirectory.Text = "Sort Directory";
            // 
            // cmnuDiskSortDirectoryByName
            // 
            this.cmnuDiskSortDirectoryByName.Name = "cmnuDiskSortDirectoryByName";
            this.cmnuDiskSortDirectoryByName.Size = new System.Drawing.Size(122, 22);
            this.cmnuDiskSortDirectoryByName.Text = "by Name";
            this.cmnuDiskSortDirectoryByName.Click += new System.EventHandler(this.cmnuDiskSortDirectoryByName_Click);
            // 
            // cmnuDiskSortDirectoryByType
            // 
            this.cmnuDiskSortDirectoryByType.Name = "cmnuDiskSortDirectoryByType";
            this.cmnuDiskSortDirectoryByType.Size = new System.Drawing.Size(122, 22);
            this.cmnuDiskSortDirectoryByType.Text = "by Type";
            this.cmnuDiskSortDirectoryByType.Click += new System.EventHandler(this.cmnuDiskSortDirectoryByType_Click);
            // 
            // cmnuDiskSep5
            // 
            this.cmnuDiskSep5.Name = "cmnuDiskSep5";
            this.cmnuDiskSep5.Size = new System.Drawing.Size(175, 6);
            this.cmnuDiskSep5.Visible = false;
            // 
            // cmnuDiskRefresh
            // 
            this.cmnuDiskRefresh.Enabled = false;
            this.cmnuDiskRefresh.Image = global::OricExplorer.Properties.Resources.refresh;
            this.cmnuDiskRefresh.Name = "cmnuDiskRefresh";
            this.cmnuDiskRefresh.Size = new System.Drawing.Size(178, 22);
            this.cmnuDiskRefresh.Text = "Refresh";
            this.cmnuDiskRefresh.Visible = false;
            this.cmnuDiskRefresh.Click += new System.EventHandler(this.cmnuDiskRefresh_Click);
            // 
            // cmnuUnknownDisk
            // 
            this.cmnuUnknownDisk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuUnknownDiskRawDataViewer,
            this.toolStripMenuItem5,
            this.cmnuUnknownDiskLoadIntoEmulator});
            this.cmnuUnknownDisk.Name = "contextMenuStripUnknownDisk";
            this.cmnuUnknownDisk.Size = new System.Drawing.Size(176, 54);
            // 
            // cmnuUnknownDiskRawDataViewer
            // 
            this.cmnuUnknownDiskRawDataViewer.Name = "cmnuUnknownDiskRawDataViewer";
            this.cmnuUnknownDiskRawDataViewer.Size = new System.Drawing.Size(175, 22);
            this.cmnuUnknownDiskRawDataViewer.Text = "Raw Data Viewer";
            this.cmnuUnknownDiskRawDataViewer.Click += new System.EventHandler(this.cmnuUnknownDiskRawDataViewer_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(172, 6);
            // 
            // cmnuUnknownDiskLoadIntoEmulator
            // 
            this.cmnuUnknownDiskLoadIntoEmulator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz,
            this.cmnuUnknownDiskLoadIntoEmulatorOric1,
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos,
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat});
            this.cmnuUnknownDiskLoadIntoEmulator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuUnknownDiskLoadIntoEmulator.Image = global::OricExplorer.Properties.Resources.emulator;
            this.cmnuUnknownDiskLoadIntoEmulator.Name = "cmnuUnknownDiskLoadIntoEmulator";
            this.cmnuUnknownDiskLoadIntoEmulator.Size = new System.Drawing.Size(175, 22);
            this.cmnuUnknownDiskLoadIntoEmulator.Text = "Load into Emulator";
            // 
            // cmnuUnknownDiskLoadIntoEmulatorPravetz
            // 
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Image = ((System.Drawing.Image)(resources.GetObject("cmnuUnknownDiskLoadIntoEmulatorPravetz.Image")));
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Name = "cmnuUnknownDiskLoadIntoEmulatorPravetz";
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Size = new System.Drawing.Size(117, 22);
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Text = "Pravetz";
            this.cmnuUnknownDiskLoadIntoEmulatorPravetz.Click += new System.EventHandler(this.cmnuUnknownDiskLoadIntoEmulatorPravetz_Click);
            // 
            // cmnuUnknownDiskLoadIntoEmulatorOric1
            // 
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Image = ((System.Drawing.Image)(resources.GetObject("cmnuUnknownDiskLoadIntoEmulatorOric1.Image")));
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Name = "cmnuUnknownDiskLoadIntoEmulatorOric1";
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Size = new System.Drawing.Size(117, 22);
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Text = "Oric-1";
            this.cmnuUnknownDiskLoadIntoEmulatorOric1.Click += new System.EventHandler(this.cmnuUnknownDiskLoadIntoEmulatorOric1_Click);
            // 
            // cmnuUnknownDiskLoadIntoEmulatorAtmos
            // 
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Image = ((System.Drawing.Image)(resources.GetObject("cmnuUnknownDiskLoadIntoEmulatorAtmos.Image")));
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Name = "cmnuUnknownDiskLoadIntoEmulatorAtmos";
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Size = new System.Drawing.Size(117, 22);
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Text = "Atmos";
            this.cmnuUnknownDiskLoadIntoEmulatorAtmos.Click += new System.EventHandler(this.cmnuUnknownDiskLoadIntoEmulatorAtmos_Click);
            // 
            // cmnuUnknownDiskLoadIntoEmulatorTelestrat
            // 
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Image = ((System.Drawing.Image)(resources.GetObject("cmnuUnknownDiskLoadIntoEmulatorTelestrat.Image")));
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Name = "cmnuUnknownDiskLoadIntoEmulatorTelestrat";
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Size = new System.Drawing.Size(117, 22);
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Text = "Telestrat";
            this.cmnuUnknownDiskLoadIntoEmulatorTelestrat.Click += new System.EventHandler(this.cmnuUnknownDiskLoadIntoEmulatorTelestrat_Click);
            // 
            // cmnuRom
            // 
            this.cmnuRom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuRomViewRom,
            this.cmnuRomSep1,
            this.cmnuRomCopy,
            this.cmnuRomDelete,
            this.cmnuRomRename,
            this.cmnuRomSep2,
            this.cmnuRomRefresh});
            this.cmnuRom.Name = "tapeContextMenuStrip";
            this.cmnuRom.Size = new System.Drawing.Size(125, 126);
            // 
            // cmnuRomViewRom
            // 
            this.cmnuRomViewRom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuRomViewRom.Image = global::OricExplorer.Properties.Resources.view;
            this.cmnuRomViewRom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuRomViewRom.Name = "cmnuRomViewRom";
            this.cmnuRomViewRom.Size = new System.Drawing.Size(124, 22);
            this.cmnuRomViewRom.Text = "View rom";
            this.cmnuRomViewRom.Click += new System.EventHandler(this.cmnuRomViewRom_Click);
            // 
            // cmnuRomSep1
            // 
            this.cmnuRomSep1.Name = "cmnuRomSep1";
            this.cmnuRomSep1.Size = new System.Drawing.Size(121, 6);
            this.cmnuRomSep1.Visible = false;
            // 
            // cmnuRomCopy
            // 
            this.cmnuRomCopy.Enabled = false;
            this.cmnuRomCopy.Image = global::OricExplorer.Properties.Resources.copy;
            this.cmnuRomCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuRomCopy.Name = "cmnuRomCopy";
            this.cmnuRomCopy.Size = new System.Drawing.Size(124, 22);
            this.cmnuRomCopy.Text = "Copy";
            this.cmnuRomCopy.Visible = false;
            // 
            // cmnuRomDelete
            // 
            this.cmnuRomDelete.Enabled = false;
            this.cmnuRomDelete.Image = global::OricExplorer.Properties.Resources.delete;
            this.cmnuRomDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuRomDelete.Name = "cmnuRomDelete";
            this.cmnuRomDelete.Size = new System.Drawing.Size(124, 22);
            this.cmnuRomDelete.Text = "Delete";
            this.cmnuRomDelete.Visible = false;
            // 
            // cmnuRomRename
            // 
            this.cmnuRomRename.Enabled = false;
            this.cmnuRomRename.Image = global::OricExplorer.Properties.Resources.rename;
            this.cmnuRomRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuRomRename.Name = "cmnuRomRename";
            this.cmnuRomRename.Size = new System.Drawing.Size(124, 22);
            this.cmnuRomRename.Text = "Rename";
            this.cmnuRomRename.Visible = false;
            // 
            // cmnuRomSep2
            // 
            this.cmnuRomSep2.Name = "cmnuRomSep2";
            this.cmnuRomSep2.Size = new System.Drawing.Size(121, 6);
            this.cmnuRomSep2.Visible = false;
            // 
            // cmnuRomRefresh
            // 
            this.cmnuRomRefresh.Enabled = false;
            this.cmnuRomRefresh.Image = global::OricExplorer.Properties.Resources.refresh;
            this.cmnuRomRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuRomRefresh.Name = "cmnuRomRefresh";
            this.cmnuRomRefresh.Size = new System.Drawing.Size(124, 22);
            this.cmnuRomRefresh.Text = "Refresh";
            this.cmnuRomRefresh.Visible = false;
            // 
            // tmrAfterLabelEdit
            // 
            this.tmrAfterLabelEdit.Tick += new System.EventHandler(this.tmrAfterLabelEdit_Tick);
            // 
            // cmnuOtherFiles
            // 
            this.cmnuOtherFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOtherFilesViewFile,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator2,
            this.toolStripMenuItem6});
            this.cmnuOtherFiles.Name = "tapeContextMenuStrip";
            this.cmnuOtherFiles.Size = new System.Drawing.Size(119, 126);
            // 
            // cmnuOtherFilesViewFile
            // 
            this.cmnuOtherFilesViewFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmnuOtherFilesViewFile.Image = global::OricExplorer.Properties.Resources.view;
            this.cmnuOtherFilesViewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmnuOtherFilesViewFile.Name = "cmnuOtherFilesViewFile";
            this.cmnuOtherFilesViewFile.Size = new System.Drawing.Size(118, 22);
            this.cmnuOtherFilesViewFile.Text = "View file";
            this.cmnuOtherFilesViewFile.Click += new System.EventHandler(this.cmnuOtherFilesViewFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Image = global::OricExplorer.Properties.Resources.copy;
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem2.Text = "Copy";
            this.toolStripMenuItem2.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Image = global::OricExplorer.Properties.Resources.delete;
            this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem3.Text = "Delete";
            this.toolStripMenuItem3.Visible = false;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Image = global::OricExplorer.Properties.Resources.rename;
            this.toolStripMenuItem4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem4.Text = "Rename";
            this.toolStripMenuItem4.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Image = global::OricExplorer.Properties.Resources.refresh;
            this.toolStripMenuItem6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem6.Text = "Refresh";
            this.toolStripMenuItem6.Visible = false;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 478);
            this.Controls.Add(this.dkpPanel);
            this.Controls.Add(this.ssStatusBar);
            this.Controls.Add(this.mnu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnu;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Oric Explorer v{0} © {1} by Scott Davies";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMainForm_Closing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.Shown += new System.EventHandler(this.frmMainForm_Shown);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            this.cmnuProgram.ResumeLayout(false);
            this.cmnuTape.ResumeLayout(false);
            this.cmnuDisk.ResumeLayout(false);
            this.cmnuUnknownDisk.ResumeLayout(false);
            this.cmnuRom.ResumeLayout(false);
            this.cmnuOtherFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.StatusStrip ssStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatusMain;
        private System.Windows.Forms.ToolTip ttpToolTip;
        private System.Drawing.Printing.PrintDocument prtDocument;
        private System.Windows.Forms.PrintPreviewDialog prtPreviewDialog;
        private System.Windows.Forms.PrintDialog prtDialog;
        private System.Windows.Forms.PageSetupDialog prtPageSetupDialog;
        private ContextMenuStrip cmnuProgram;
        private ToolStripMenuItem mnuHelpAbout;
        private ToolStripMenuItem cmnuProgramViewFile;
        private ToolStripMenuItem cmnuProgramCopy;
        private ToolStripSeparator cmnuProgramSep1;
        private ToolStripMenuItem cmnuProgramDelete;
        private ToolStripMenuItem cmnuProgramRename;
        private ToolStripSeparator cmnuProgramSep3;
        private ContextMenuStrip cmnuTape;
        private ToolStripMenuItem cmnuTapeCopy;
        private ToolStripMenuItem cmnuTapeConvertToDisk;
        private ToolStripMenuItem cmnuTapeAddToDisk;
        private ToolStripSeparator cmnuTapeSep1;
        private ToolStripMenuItem cmnuTapeDelete;
        private ToolStripMenuItem cmnuTapeRename;
        private ToolStripSeparator cmnuTapeSep3;
        private ToolStripMenuItem cmnuTapeOutputDirectory;
        private ToolStripSeparator cmnuTapeSep5;
        private ToolStripMenuItem cmnuTapeRefresh;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripSeparator mnuViewSep1;
        private ToolStripMenuItem mnuToolsSettings;
        private ToolStripMenuItem mnuViewRefresh;
        private ToolStripMenuItem mnuHelpCheckForUpdates;
        private ToolStripSeparator mnuHelpSep1;
        private ToolStripMenuItem cmnuProgramAutoRun;
        private ToolStripMenuItem cmnuProgramAutoRunEnabled;
        private ToolStripMenuItem cmnuProgramAutorunDisabled;
        private ToolStripMenuItem cmnuTapeLoadIntoEmulator;
        private ToolStripSeparator cmnuTapeSep4;
        private ToolStripStatusLabel tsslLoadTime;
        private ToolStripStatusLabel tsslDisplayTime;
        private ToolStripStatusLabel tsslOverallTime;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dkpPanel;
        private ToolStripMenuItem mnuViewClose;
        private ToolStripMenuItem mnuViewCloseAll;
        private ToolStripMenuItem cmnuTapeEditTape;
        private ToolStripSeparator cmnuTapeSep2;
        private ToolStripMenuItem cmnuTapeLoadIntoEmulatorOric1;
        private ToolStripMenuItem cmnuTapeLoadIntoEmulatorAtmos;
        private ContextMenuStrip cmnuDisk;
        private ToolStripMenuItem cmnuDiskScreenViewer;
        private ToolStripMenuItem cmnuDiskDiskInformation;
        private ToolStripSeparator cmnuDiskSep5;
        private ToolStripMenuItem cmnuDiskCreateNewDisk;
        private ToolStripSeparator cmnuDiskSep1;
        private ToolStripMenuItem cmnuDiskFormatDisk;
        private ToolStripMenuItem cmnuDiskConvertToTape;
        private ToolStripSeparator cmnuDiskSep2;
        private ToolStripMenuItem cmnuDiskCopy;
        private ToolStripMenuItem cmnuDiskDelete;
        private ToolStripMenuItem cmnuDiskRename;
        private ToolStripSeparator cmnuDiskSep3;
        private ToolStripMenuItem cmnuDiskOutputDirectory;
        private ToolStripMenuItem cmnuDiskOutputDirectoryToPDF;
        private ToolStripMenuItem cmnuDiskOutputDirectoryToTextFile;
        private ToolStripMenuItem cmnuDiskOutputDirectoryToPrinter;
        private ToolStripSeparator cmnuDiskSep4;
        private ToolStripMenuItem cmnuDiskLoadIntoEmulator;
        private ToolStripMenuItem cmnuDiskRefresh;
        private ToolStripMenuItem cmnuProgramOpenDataViewer;
        private ToolStripMenuItem cmnuDiskSortDirectory;
        private ToolStripMenuItem cmnuDiskSortDirectoryByName;
        private ToolStripMenuItem cmnuDiskSortDirectoryByType;
        private ToolStripMenuItem mnuToolsImportAtmosBasicFile;
        private ToolStripSeparator mnuToolsSep1;
        private ContextMenuStrip cmnuUnknownDisk;
        private ToolStripMenuItem cmnuProgramOpenEditor;
        private ToolStripSeparator cmnuProgramSep2;
        private ToolStripMenuItem cmnuDiskRawDataViewer;
        private ToolStripMenuItem mnuViewCloseAllButThisOne;
        private ToolStripMenuItem mnuToolsSyntaxHighlighting;
        private ToolStripSeparator mnuToolsSep2;
        private ToolStripMenuItem cmnuProgramExtractTo;
        private ToolStripMenuItem cmnuProgramExtractToTapeFile;
        private ToolStripMenuItem cmnuProgramExtractToTextFile;
        private ToolStripMenuItem cmnuProgramExtractToRawFile;
        private ContextMenuStrip cmnuRom;
        private ToolStripMenuItem cmnuRomCopy;
        private ToolStripMenuItem cmnuRomDelete;
        private ToolStripMenuItem cmnuRomRename;
        private ToolStripSeparator cmnuRomSep1;
        private ToolStripSeparator cmnuRomSep2;
        private ToolStripMenuItem cmnuRomRefresh;
        private ToolStripMenuItem cmnuTapeViewFiles;
        private ToolStripMenuItem cmnuRomViewRom;
        private ToolStripMenuItem cmnuUnknownDiskRawDataViewer;
        private Timer tmrAfterLabelEdit;
        private ToolStripMenuItem cmnuTapeLoadIntoEmulatorPravetz;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem cmnuUnknownDiskLoadIntoEmulator;
        private ToolStripMenuItem cmnuUnknownDiskLoadIntoEmulatorPravetz;
        private ToolStripMenuItem cmnuUnknownDiskLoadIntoEmulatorOric1;
        private ToolStripMenuItem cmnuUnknownDiskLoadIntoEmulatorAtmos;
        private ToolStripMenuItem cmnuUnknownDiskLoadIntoEmulatorTelestrat;
        private ContextMenuStrip cmnuOtherFiles;
        private ToolStripMenuItem cmnuOtherFilesViewFile;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItem6;
    }
}

