using System.Windows.Forms;
namespace OricExplorer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.syntaxHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutOricExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDisplayTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOverallTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openDataViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAutoRun = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.switchViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tapeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.editTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oric1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oricAtmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.diskContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createNewDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.formatDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToTapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.outputDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.loadIntoEmulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.screenViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawDataViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sortDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripUnknownDisk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displaySectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.extractToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFiletxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawFilenoHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tapeFiletapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.progContextMenuStrip.SuspendLayout();
            this.tapeContextMenuStrip.SuspendLayout();
            this.diskContextMenuStrip.SuspendLayout();
            this.contextMenuStripUnknownDisk.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.closeAllButThisOneToolStripMenuItem,
            this.toolStripSeparator16,
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // closeAllButThisOneToolStripMenuItem
            // 
            this.closeAllButThisOneToolStripMenuItem.Name = "closeAllButThisOneToolStripMenuItem";
            this.closeAllButThisOneToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeAllButThisOneToolStripMenuItem.Text = "Close All But This";
            this.closeAllButThisOneToolStripMenuItem.Click += new System.EventHandler(this.closeAllButThisOneToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(163, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertTextFileToolStripMenuItem,
            this.toolStripSeparator18,
            this.syntaxHighlightingToolStripMenuItem,
            this.toolStripSeparator11,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // convertTextFileToolStripMenuItem
            // 
            this.convertTextFileToolStripMenuItem.Name = "convertTextFileToolStripMenuItem";
            this.convertTextFileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.convertTextFileToolStripMenuItem.Text = "Convert Text File...";
            this.convertTextFileToolStripMenuItem.Click += new System.EventHandler(this.convertTextFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(184, 6);
            // 
            // syntaxHighlightingToolStripMenuItem
            // 
            this.syntaxHighlightingToolStripMenuItem.Name = "syntaxHighlightingToolStripMenuItem";
            this.syntaxHighlightingToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.syntaxHighlightingToolStripMenuItem.Text = "Syntax Highlighting...";
            this.syntaxHighlightingToolStripMenuItem.Click += new System.EventHandler(this.syntaxHighlightingToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(184, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
            this.optionsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.optionsToolStripMenuItem.Text = "Settings...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator25,
            this.aboutOricExplorerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates...";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(176, 6);
            // 
            // aboutOricExplorerToolStripMenuItem
            // 
            this.aboutOricExplorerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutOricExplorerToolStripMenuItem.Image")));
            this.aboutOricExplorerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutOricExplorerToolStripMenuItem.Name = "aboutOricExplorerToolStripMenuItem";
            this.aboutOricExplorerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutOricExplorerToolStripMenuItem.Text = "About Oric Explorer";
            this.aboutOricExplorerToolStripMenuItem.Click += new System.EventHandler(this.aboutOricExplorerToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMain,
            this.toolStripStatusLabelLoadTime,
            this.toolStripStatusLabelDisplayTime,
            this.toolStripStatusLabelOverallTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(839, 24);
            this.statusStrip1.TabIndex = 2;
            // 
            // lblStatusMain
            // 
            this.lblStatusMain.ForeColor = System.Drawing.Color.Black;
            this.lblStatusMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusMain.Name = "lblStatusMain";
            this.lblStatusMain.Size = new System.Drawing.Size(674, 19);
            this.lblStatusMain.Spring = true;
            this.lblStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelLoadTime
            // 
            this.toolStripStatusLabelLoadTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelLoadTime.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelLoadTime.Name = "toolStripStatusLabelLoadTime";
            this.toolStripStatusLabelLoadTime.Size = new System.Drawing.Size(50, 19);
            this.toolStripStatusLabelLoadTime.Text = "000.000";
            // 
            // toolStripStatusLabelDisplayTime
            // 
            this.toolStripStatusLabelDisplayTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelDisplayTime.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelDisplayTime.Name = "toolStripStatusLabelDisplayTime";
            this.toolStripStatusLabelDisplayTime.Size = new System.Drawing.Size(50, 19);
            this.toolStripStatusLabelDisplayTime.Text = "000.000";
            // 
            // toolStripStatusLabelOverallTime
            // 
            this.toolStripStatusLabelOverallTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelOverallTime.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabelOverallTime.Name = "toolStripStatusLabelOverallTime";
            this.toolStripStatusLabelOverallTime.Size = new System.Drawing.Size(50, 19);
            this.toolStripStatusLabelOverallTime.Text = "000.000";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "microdisc.ico");
            this.imageList1.Images.SetKeyName(1, "folderopen.ico");
            this.imageList1.Images.SetKeyName(2, "tree_image_tape.png");
            this.imageList1.Images.SetKeyName(3, "OricROM.ico");
            this.imageList1.Images.SetKeyName(4, "tree_image_disk.png");
            this.imageList1.Images.SetKeyName(5, "tree_image_disk_oricdos.PNG");
            this.imageList1.Images.SetKeyName(6, "tree_image_disk_sedoric.PNG");
            this.imageList1.Images.SetKeyName(7, "delete_16x.ico");
            this.imageList1.Images.SetKeyName(8, "db.ico");
            this.imageList1.Images.SetKeyName(9, "helpdoc.ico");
            this.imageList1.Images.SetKeyName(10, "fonfile.ico");
            this.imageList1.Images.SetKeyName(11, "VSObject_Type.bmp");
            this.imageList1.Images.SetKeyName(12, "tree_image_text.png");
            this.imageList1.Images.SetKeyName(13, "UtilityText.ico");
            this.imageList1.Images.SetKeyName(14, "tree_image_hires.png");
            this.imageList1.Images.SetKeyName(15, "tree_image_unknown.png");
            this.imageList1.Images.SetKeyName(16, "dbs.ico");
            this.imageList1.Images.SetKeyName(17, "unknown_disk.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.printSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 98);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveImageToolStripMenuItem.Image")));
            this.saveImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printSetupToolStripMenuItem.Image")));
            this.printSetupToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printSetupToolStripMenuItem.Text = "Page Setup";
            this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.printSetupToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // printImageToolStripMenuItem
            // 
            this.printImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printImageToolStripMenuItem.Image")));
            this.printImageToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printImageToolStripMenuItem.Name = "printImageToolStripMenuItem";
            this.printImageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printImageToolStripMenuItem.Text = "Print";
            this.printImageToolStripMenuItem.Click += new System.EventHandler(this.printImageToolStripMenuItem_Click);
            // 
            // progContextMenuStrip
            // 
            this.progContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripSeparator8,
            this.openDataViewerToolStripMenuItem,
            this.openEditorToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem14,
            this.deleteFileToolStripMenuItem,
            this.toolStripMenuItem16,
            this.toolStripSeparator10,
            this.toolStripMenuItemAutoRun,
            this.toolStripSeparator21,
            this.extractToToolStripMenuItem});
            this.progContextMenuStrip.Name = "contextMenuStrip2";
            this.progContextMenuStrip.Size = new System.Drawing.Size(178, 226);
            this.progContextMenuStrip.Text = "Program Menu";
            this.progContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.progContextMenuStrip_Opening);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Enabled = false;
            this.toolStripMenuItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem12.Image")));
            this.toolStripMenuItem12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem12.Text = "View file";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(174, 6);
            // 
            // openDataViewerToolStripMenuItem
            // 
            this.openDataViewerToolStripMenuItem.Name = "openDataViewerToolStripMenuItem";
            this.openDataViewerToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openDataViewerToolStripMenuItem.Text = "Open Data Viewer...";
            this.openDataViewerToolStripMenuItem.Click += new System.EventHandler(this.openDataViewerToolStripMenuItem_Click);
            // 
            // openEditorToolStripMenuItem
            // 
            this.openEditorToolStripMenuItem.Enabled = false;
            this.openEditorToolStripMenuItem.Name = "openEditorToolStripMenuItem";
            this.openEditorToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openEditorToolStripMenuItem.Text = "Open Editor...";
            this.openEditorToolStripMenuItem.Click += new System.EventHandler(this.openEditorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Enabled = false;
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem14.Text = "Copy";
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Enabled = false;
            this.deleteFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFileToolStripMenuItem.Image")));
            this.deleteFileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deleteFileToolStripMenuItem.Text = "Delete";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Enabled = false;
            this.toolStripMenuItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem16.Image")));
            this.toolStripMenuItem16.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem16.Text = "Rename";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem22_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(174, 6);
            // 
            // toolStripMenuItemAutoRun
            // 
            this.toolStripMenuItemAutoRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.toolStripMenuItemAutoRun.Enabled = false;
            this.toolStripMenuItemAutoRun.Name = "toolStripMenuItemAutoRun";
            this.toolStripMenuItemAutoRun.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItemAutoRun.Text = "Set Auto Run State";
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.enableToolStripMenuItem.Text = "Enabled";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.disableToolStripMenuItem.Text = "Disabled";
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(174, 6);
            // 
            // switchViewToolStripMenuItem
            // 
            this.switchViewToolStripMenuItem.Name = "switchViewToolStripMenuItem";
            this.switchViewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.UseAntiAlias = true;
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // tapeContextMenuStrip
            // 
            this.tapeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem25,
            this.toolStripMenuItem20,
            this.toolStripSeparator12,
            this.editTapeToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem19,
            this.toolStripMenuItem21,
            this.toolStripMenuItem22,
            this.toolStripSeparator14,
            this.startToolStripMenuItem,
            this.toolStripSeparator27,
            this.toolStripMenuItem26,
            this.toolStripSeparator15,
            this.toolStripMenuItem24});
            this.tapeContextMenuStrip.Name = "tapeContextMenuStrip";
            this.tapeContextMenuStrip.Size = new System.Drawing.Size(176, 232);
            this.tapeContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.tapeContextMenuStrip_Opening);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Enabled = false;
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem25.Text = "Add to Disk...";
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Enabled = false;
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem20.Text = "Convert to Disk...";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(172, 6);
            // 
            // editTapeToolStripMenuItem
            // 
            this.editTapeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editTapeToolStripMenuItem.Image")));
            this.editTapeToolStripMenuItem.Name = "editTapeToolStripMenuItem";
            this.editTapeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.editTapeToolStripMenuItem.Text = "Edit Tape";
            this.editTapeToolStripMenuItem.Click += new System.EventHandler(this.editTapeToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem19.Image")));
            this.toolStripMenuItem19.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem19.Text = "Copy";
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem21.Image")));
            this.toolStripMenuItem21.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem21.Text = "Delete";
            this.toolStripMenuItem21.Click += new System.EventHandler(this.toolStripMenuItem21_Click);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem22.Image")));
            this.toolStripMenuItem22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem22.Text = "Rename";
            this.toolStripMenuItem22.Click += new System.EventHandler(this.toolStripMenuItem22_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(172, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oric1ToolStripMenuItem,
            this.oricAtmosToolStripMenuItem});
            this.startToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startToolStripMenuItem.Image")));
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.startToolStripMenuItem.Text = "Load into Emulator";
            // 
            // oric1ToolStripMenuItem
            // 
            this.oric1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oric1ToolStripMenuItem.Image")));
            this.oric1ToolStripMenuItem.Name = "oric1ToolStripMenuItem";
            this.oric1ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.oric1ToolStripMenuItem.Text = "Oric-1";
            this.oric1ToolStripMenuItem.Click += new System.EventHandler(this.oric1ToolStripMenuItem_Click_1);
            // 
            // oricAtmosToolStripMenuItem
            // 
            this.oricAtmosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oricAtmosToolStripMenuItem.Image")));
            this.oricAtmosToolStripMenuItem.Name = "oricAtmosToolStripMenuItem";
            this.oricAtmosToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.oricAtmosToolStripMenuItem.Text = "Oric Atmos";
            this.oricAtmosToolStripMenuItem.Click += new System.EventHandler(this.oricAtmosToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(172, 6);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem26.Text = "Output Directory";
            this.toolStripMenuItem26.Click += new System.EventHandler(this.toolStripMenuItem26_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(172, 6);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Enabled = false;
            this.toolStripMenuItem24.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem24.Image")));
            this.toolStripMenuItem24.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem24.Text = "Refresh";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dockPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockPanel1.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dockPanel1.DockRightPortion = 300D;
            this.dockPanel1.ForeColor = System.Drawing.Color.Black;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowAutoHideContentOnHover = false;
            this.dockPanel1.ShowDocumentIcon = true;
            this.dockPanel1.Size = new System.Drawing.Size(838, 430);
            this.dockPanel1.TabIndex = 4;
            this.dockPanel1.ActiveDocumentChanged += new System.EventHandler(this.dockPanel1_ActiveDocumentChanged);
            // 
            // diskContextMenuStrip
            // 
            this.diskContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewDiskToolStripMenuItem,
            this.toolStripSeparator6,
            this.formatDiskToolStripMenuItem,
            this.convertToTapeToolStripMenuItem,
            this.toolStripSeparator7,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripSeparator9,
            this.outputDirectoryToolStripMenuItem,
            this.toolStripSeparator19,
            this.loadIntoEmulatorToolStripMenuItem,
            this.toolStripSeparator5,
            this.screenViewerToolStripMenuItem,
            this.diskInformationToolStripMenuItem,
            this.rawDataViewerToolStripMenuItem,
            this.toolStripSeparator13,
            this.refreshToolStripMenuItem1,
            this.sortDirectoryToolStripMenuItem});
            this.diskContextMenuStrip.Name = "diskContextMenuStrip";
            this.diskContextMenuStrip.Size = new System.Drawing.Size(176, 326);
            this.diskContextMenuStrip.Text = "Disk Options";
            this.diskContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.diskContextMenuStrip_Opening);
            // 
            // createNewDiskToolStripMenuItem
            // 
            this.createNewDiskToolStripMenuItem.Enabled = false;
            this.createNewDiskToolStripMenuItem.Name = "createNewDiskToolStripMenuItem";
            this.createNewDiskToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.createNewDiskToolStripMenuItem.Text = "Create new disk...";
            this.createNewDiskToolStripMenuItem.Click += new System.EventHandler(this.createNewDiskToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(172, 6);
            // 
            // formatDiskToolStripMenuItem
            // 
            this.formatDiskToolStripMenuItem.Enabled = false;
            this.formatDiskToolStripMenuItem.Name = "formatDiskToolStripMenuItem";
            this.formatDiskToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.formatDiskToolStripMenuItem.Text = "Format disk...";
            this.formatDiskToolStripMenuItem.Click += new System.EventHandler(this.formatDiskToolStripMenuItem_Click);
            // 
            // convertToTapeToolStripMenuItem
            // 
            this.convertToTapeToolStripMenuItem.Enabled = false;
            this.convertToTapeToolStripMenuItem.Name = "convertToTapeToolStripMenuItem";
            this.convertToTapeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.convertToTapeToolStripMenuItem.Text = "Convert to tape...";
            this.convertToTapeToolStripMenuItem.Click += new System.EventHandler(this.convertToTapeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(172, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(172, 6);
            // 
            // outputDirectoryToolStripMenuItem
            // 
            this.outputDirectoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toPDFToolStripMenuItem,
            this.toTextFileToolStripMenuItem,
            this.toPrinterToolStripMenuItem});
            this.outputDirectoryToolStripMenuItem.Name = "outputDirectoryToolStripMenuItem";
            this.outputDirectoryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.outputDirectoryToolStripMenuItem.Text = "Output directory";
            // 
            // toPDFToolStripMenuItem
            // 
            this.toPDFToolStripMenuItem.Name = "toPDFToolStripMenuItem";
            this.toPDFToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.toPDFToolStripMenuItem.Text = "to PDF";
            this.toPDFToolStripMenuItem.Click += new System.EventHandler(this.toPDFToolStripMenuItem_Click);
            // 
            // toTextFileToolStripMenuItem
            // 
            this.toTextFileToolStripMenuItem.Name = "toTextFileToolStripMenuItem";
            this.toTextFileToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.toTextFileToolStripMenuItem.Text = "to Text file";
            this.toTextFileToolStripMenuItem.Click += new System.EventHandler(this.toTextFileToolStripMenuItem_Click);
            // 
            // toPrinterToolStripMenuItem
            // 
            this.toPrinterToolStripMenuItem.Name = "toPrinterToolStripMenuItem";
            this.toPrinterToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.toPrinterToolStripMenuItem.Text = "to Printer";
            this.toPrinterToolStripMenuItem.Click += new System.EventHandler(this.toPrinterToolStripMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(172, 6);
            // 
            // loadIntoEmulatorToolStripMenuItem
            // 
            this.loadIntoEmulatorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadIntoEmulatorToolStripMenuItem.Image")));
            this.loadIntoEmulatorToolStripMenuItem.Name = "loadIntoEmulatorToolStripMenuItem";
            this.loadIntoEmulatorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.loadIntoEmulatorToolStripMenuItem.Text = "Load into Emulator";
            this.loadIntoEmulatorToolStripMenuItem.Click += new System.EventHandler(this.loadIntoEmulatorToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(172, 6);
            // 
            // screenViewerToolStripMenuItem
            // 
            this.screenViewerToolStripMenuItem.Image = global::OricExplorer.Properties.Resources.images;
            this.screenViewerToolStripMenuItem.Name = "screenViewerToolStripMenuItem";
            this.screenViewerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.screenViewerToolStripMenuItem.Text = "Screen Viewer...";
            this.screenViewerToolStripMenuItem.Click += new System.EventHandler(this.slideshowViewerToolStripMenuItem_Click);
            // 
            // diskInformationToolStripMenuItem
            // 
            this.diskInformationToolStripMenuItem.Image = global::OricExplorer.Properties.Resources.information;
            this.diskInformationToolStripMenuItem.Name = "diskInformationToolStripMenuItem";
            this.diskInformationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.diskInformationToolStripMenuItem.Text = "Disk Information...";
            this.diskInformationToolStripMenuItem.Click += new System.EventHandler(this.diskInformationToolStripMenuItem_Click);
            // 
            // rawDataViewerToolStripMenuItem
            // 
            this.rawDataViewerToolStripMenuItem.Name = "rawDataViewerToolStripMenuItem";
            this.rawDataViewerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.rawDataViewerToolStripMenuItem.Text = "Raw Data Viewer";
            this.rawDataViewerToolStripMenuItem.Click += new System.EventHandler(this.rawDataViewerToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(172, 6);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Enabled = false;
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // sortDirectoryToolStripMenuItem
            // 
            this.sortDirectoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNameToolStripMenuItem,
            this.byTypeToolStripMenuItem});
            this.sortDirectoryToolStripMenuItem.Name = "sortDirectoryToolStripMenuItem";
            this.sortDirectoryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.sortDirectoryToolStripMenuItem.Text = "Sort Directory";
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.byNameToolStripMenuItem.Text = "by Name";
            this.byNameToolStripMenuItem.Click += new System.EventHandler(this.byNameToolStripMenuItem_Click);
            // 
            // byTypeToolStripMenuItem
            // 
            this.byTypeToolStripMenuItem.Name = "byTypeToolStripMenuItem";
            this.byTypeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.byTypeToolStripMenuItem.Text = "by Type";
            this.byTypeToolStripMenuItem.Click += new System.EventHandler(this.byTypeToolStripMenuItem_Click);
            // 
            // contextMenuStripUnknownDisk
            // 
            this.contextMenuStripUnknownDisk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displaySectorsToolStripMenuItem});
            this.contextMenuStripUnknownDisk.Name = "contextMenuStripUnknownDisk";
            this.contextMenuStripUnknownDisk.Size = new System.Drawing.Size(154, 26);
            // 
            // displaySectorsToolStripMenuItem
            // 
            this.displaySectorsToolStripMenuItem.Name = "displaySectorsToolStripMenuItem";
            this.displaySectorsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.displaySectorsToolStripMenuItem.Text = "Display Sectors";
            this.displaySectorsToolStripMenuItem.Click += new System.EventHandler(this.displaySectorsToolStripMenuItem_Click);
            // 
            // extractToToolStripMenuItem
            // 
            this.extractToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tapeFiletapToolStripMenuItem,
            this.textFiletxtToolStripMenuItem,
            this.rawFilenoHeaderToolStripMenuItem});
            this.extractToToolStripMenuItem.Name = "extractToToolStripMenuItem";
            this.extractToToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.extractToToolStripMenuItem.Text = "Extract To...";
            // 
            // textFiletxtToolStripMenuItem
            // 
            this.textFiletxtToolStripMenuItem.Name = "textFiletxtToolStripMenuItem";
            this.textFiletxtToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.textFiletxtToolStripMenuItem.Text = "Text file (txt)";
            this.textFiletxtToolStripMenuItem.Click += new System.EventHandler(this.textFiletxtToolStripMenuItem_Click);
            // 
            // rawFilenoHeaderToolStripMenuItem
            // 
            this.rawFilenoHeaderToolStripMenuItem.Name = "rawFilenoHeaderToolStripMenuItem";
            this.rawFilenoHeaderToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.rawFilenoHeaderToolStripMenuItem.Text = "Raw file (no header)";
            this.rawFilenoHeaderToolStripMenuItem.Click += new System.EventHandler(this.rawFilenoHeaderToolStripMenuItem_Click);
            // 
            // tapeFiletapToolStripMenuItem
            // 
            this.tapeFiletapToolStripMenuItem.Name = "tapeFiletapToolStripMenuItem";
            this.tapeFiletapToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tapeFiletapToolStripMenuItem.Text = "Tape file (tap)";
            this.tapeFiletapToolStripMenuItem.Click += new System.EventHandler(this.tapeFiletapToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 478);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Oric Explorer V2.0 © 2017 by Scott Davies";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.progContextMenuStrip.ResumeLayout(false);
            this.tapeContextMenuStrip.ResumeLayout(false);
            this.diskContextMenuStrip.ResumeLayout(false);
            this.contextMenuStripUnknownDisk.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem switchViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ContextMenuStrip progContextMenuStrip;
        private ToolStripMenuItem aboutOricExplorerToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem deleteFileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripSeparator toolStripSeparator10;
        private ContextMenuStrip tapeContextMenuStrip;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem toolStripMenuItem25;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem toolStripMenuItem21;
        private ToolStripMenuItem toolStripMenuItem22;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem toolStripMenuItem26;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem toolStripMenuItem24;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripMenuItem toolStripMenuItemAutoRun;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripStatusLabel toolStripStatusLabelLoadTime;
        private ToolStripStatusLabel toolStripStatusLabelDisplayTime;
        private ToolStripStatusLabel toolStripStatusLabelOverallTime;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem closeAllToolStripMenuItem;
        private ToolStripMenuItem editTapeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem oric1ToolStripMenuItem;
        private ToolStripMenuItem oricAtmosToolStripMenuItem;
        private ContextMenuStrip diskContextMenuStrip;
        private ToolStripMenuItem screenViewerToolStripMenuItem;
        private ToolStripMenuItem diskInformationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem createNewDiskToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem formatDiskToolStripMenuItem;
        private ToolStripMenuItem convertToTapeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem outputDirectoryToolStripMenuItem;
        private ToolStripMenuItem toPDFToolStripMenuItem;
        private ToolStripMenuItem toTextFileToolStripMenuItem;
        private ToolStripMenuItem toPrinterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem loadIntoEmulatorToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem1;
        private ToolStripMenuItem openDataViewerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem sortDirectoryToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byTypeToolStripMenuItem;
        private ToolStripMenuItem convertTextFileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator18;
        private ContextMenuStrip contextMenuStripUnknownDisk;
        private ToolStripMenuItem displaySectorsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem openEditorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem rawDataViewerToolStripMenuItem;
        private ToolStripMenuItem closeAllButThisOneToolStripMenuItem;
        private ToolStripMenuItem syntaxHighlightingToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem extractToToolStripMenuItem;
        private ToolStripMenuItem tapeFiletapToolStripMenuItem;
        private ToolStripMenuItem textFiletxtToolStripMenuItem;
        private ToolStripMenuItem rawFilenoHeaderToolStripMenuItem;
    }
}

