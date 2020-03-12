namespace OricExplorer
{
    partial class frmTextScreenEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextScreenEditor));
            this.picEditor = new System.Windows.Forms.PictureBox();
            this.lblSelectedPaperColour = new System.Windows.Forms.Label();
            this.lblWhite = new System.Windows.Forms.Label();
            this.lblYellow = new System.Windows.Forms.Label();
            this.lblMagenta = new System.Windows.Forms.Label();
            this.lblCyan = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.optAttributesSteady = new System.Windows.Forms.RadioButton();
            this.optAttributesFlashing = new System.Windows.Forms.RadioButton();
            this.optAttributesDouble = new System.Windows.Forms.RadioButton();
            this.optAttributesSingle = new System.Windows.Forms.RadioButton();
            this.btnInk = new System.Windows.Forms.Button();
            this.btnPaper = new System.Windows.Forms.Button();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAscii = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsToolsBar = new System.Windows.Forms.ToolStrip();
            this.tsbClearScreen = new System.Windows.Forms.ToolStripButton();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.tssSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tssSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tssSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowHideGrid = new System.Windows.Forms.ToolStripButton();
            this.panTools = new System.Windows.Forms.Panel();
            this.lblSelectedInkColour = new System.Windows.Forms.Label();
            this.optToolsEraseMode = new System.Windows.Forms.RadioButton();
            this.panAttributesSteadyFlash = new System.Windows.Forms.Panel();
            this.optToolsTextMode = new System.Windows.Forms.RadioButton();
            this.panAttributesSingleDouble = new System.Windows.Forms.Panel();
            this.optToolsAttributeMode = new System.Windows.Forms.RadioButton();
            this.hdiv1 = new HorizontalDivider.HorizontalDivider();
            this.optToolsColourMode = new System.Windows.Forms.RadioButton();
            this.hdiv2 = new HorizontalDivider.HorizontalDivider();
            this.panEditor = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.lblEndAddress = new System.Windows.Forms.Label();
            this.ibxDimensions = new InfoBox.InfoBox();
            this.ibxLength = new InfoBox.InfoBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.ibxEndAddress = new InfoBox.InfoBox();
            this.ibxStartAddress = new InfoBox.InfoBox();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.pan = new System.Windows.Forms.Panel();
            this.ttpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).BeginInit();
            this.ssStatusBar.SuspendLayout();
            this.mnu.SuspendLayout();
            this.tsToolsBar.SuspendLayout();
            this.panTools.SuspendLayout();
            this.panAttributesSteadyFlash.SuspendLayout();
            this.panAttributesSingleDouble.SuspendLayout();
            this.panEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.grpInformation.SuspendLayout();
            this.pan.SuspendLayout();
            this.SuspendLayout();
            // 
            // picEditor
            // 
            this.picEditor.BackColor = System.Drawing.Color.Beige;
            this.picEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditor.Location = new System.Drawing.Point(6, 4);
            this.picEditor.Name = "picEditor";
            this.picEditor.Size = new System.Drawing.Size(503, 466);
            this.picEditor.TabIndex = 0;
            this.picEditor.TabStop = false;
            this.picEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseDown);
            this.picEditor.MouseLeave += new System.EventHandler(this.picEditor_MouseLeave);
            this.picEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picEditor_MouseMove);
            // 
            // lblSelectedPaperColour
            // 
            this.lblSelectedPaperColour.BackColor = System.Drawing.Color.Black;
            this.lblSelectedPaperColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedPaperColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectedPaperColour.Location = new System.Drawing.Point(20, 416);
            this.lblSelectedPaperColour.Name = "lblSelectedPaperColour";
            this.lblSelectedPaperColour.Size = new System.Drawing.Size(31, 31);
            this.lblSelectedPaperColour.TabIndex = 1;
            this.lblSelectedPaperColour.Tag = "0";
            this.ttpToolTip.SetToolTip(this.lblSelectedPaperColour, "Current Paper colour");
            // 
            // lblWhite
            // 
            this.lblWhite.BackColor = System.Drawing.Color.White;
            this.lblWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblWhite.Location = new System.Drawing.Point(42, 355);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(31, 31);
            this.lblWhite.TabIndex = 8;
            this.lblWhite.Tag = "7";
            this.ttpToolTip.SetToolTip(this.lblWhite, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblWhite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblYellow
            // 
            this.lblYellow.BackColor = System.Drawing.Color.Yellow;
            this.lblYellow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblYellow.Location = new System.Drawing.Point(42, 291);
            this.lblYellow.Name = "lblYellow";
            this.lblYellow.Size = new System.Drawing.Size(31, 31);
            this.lblYellow.TabIndex = 7;
            this.lblYellow.Tag = "3";
            this.ttpToolTip.SetToolTip(this.lblYellow, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblYellow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblMagenta
            // 
            this.lblMagenta.BackColor = System.Drawing.Color.Magenta;
            this.lblMagenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMagenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMagenta.Location = new System.Drawing.Point(42, 323);
            this.lblMagenta.Name = "lblMagenta";
            this.lblMagenta.Size = new System.Drawing.Size(31, 31);
            this.lblMagenta.TabIndex = 6;
            this.lblMagenta.Tag = "5";
            this.ttpToolTip.SetToolTip(this.lblMagenta, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblMagenta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblCyan
            // 
            this.lblCyan.BackColor = System.Drawing.Color.Cyan;
            this.lblCyan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCyan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCyan.Location = new System.Drawing.Point(8, 355);
            this.lblCyan.Name = "lblCyan";
            this.lblCyan.Size = new System.Drawing.Size(31, 31);
            this.lblCyan.TabIndex = 5;
            this.lblCyan.Tag = "6";
            this.ttpToolTip.SetToolTip(this.lblCyan, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblCyan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblBlue
            // 
            this.lblBlue.BackColor = System.Drawing.Color.Blue;
            this.lblBlue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBlue.Location = new System.Drawing.Point(8, 323);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(31, 31);
            this.lblBlue.TabIndex = 4;
            this.lblBlue.Tag = "4";
            this.ttpToolTip.SetToolTip(this.lblBlue, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblBlue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblGreen
            // 
            this.lblGreen.BackColor = System.Drawing.Color.Lime;
            this.lblGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGreen.Location = new System.Drawing.Point(8, 291);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(31, 31);
            this.lblGreen.TabIndex = 3;
            this.lblGreen.Tag = "2";
            this.ttpToolTip.SetToolTip(this.lblGreen, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblGreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblRed
            // 
            this.lblRed.BackColor = System.Drawing.Color.Red;
            this.lblRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRed.Location = new System.Drawing.Point(42, 259);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(31, 31);
            this.lblRed.TabIndex = 2;
            this.lblRed.Tag = "1";
            this.ttpToolTip.SetToolTip(this.lblRed, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblRed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // lblBlack
            // 
            this.lblBlack.BackColor = System.Drawing.Color.Black;
            this.lblBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBlack.Location = new System.Drawing.Point(8, 259);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(31, 31);
            this.lblBlack.TabIndex = 1;
            this.lblBlack.Tag = "0";
            this.ttpToolTip.SetToolTip(this.lblBlack, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.lblBlack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblColors_MouseClick);
            // 
            // optAttributesSteady
            // 
            this.optAttributesSteady.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAttributesSteady.Location = new System.Drawing.Point(8, 2);
            this.optAttributesSteady.Name = "optAttributesSteady";
            this.optAttributesSteady.Size = new System.Drawing.Size(31, 31);
            this.optAttributesSteady.TabIndex = 13;
            this.optAttributesSteady.TabStop = true;
            this.optAttributesSteady.Text = "SD";
            this.optAttributesSteady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optAttributesSteady.UseVisualStyleBackColor = true;
            this.optAttributesSteady.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optAttributes_MouseClick);
            // 
            // optAttributesFlashing
            // 
            this.optAttributesFlashing.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAttributesFlashing.Location = new System.Drawing.Point(42, 2);
            this.optAttributesFlashing.Name = "optAttributesFlashing";
            this.optAttributesFlashing.Size = new System.Drawing.Size(31, 31);
            this.optAttributesFlashing.TabIndex = 11;
            this.optAttributesFlashing.TabStop = true;
            this.optAttributesFlashing.Text = "FL";
            this.optAttributesFlashing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optAttributesFlashing.UseVisualStyleBackColor = true;
            this.optAttributesFlashing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optAttributes_MouseClick);
            // 
            // optAttributesDouble
            // 
            this.optAttributesDouble.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAttributesDouble.Location = new System.Drawing.Point(42, 3);
            this.optAttributesDouble.Name = "optAttributesDouble";
            this.optAttributesDouble.Size = new System.Drawing.Size(31, 31);
            this.optAttributesDouble.TabIndex = 13;
            this.optAttributesDouble.TabStop = true;
            this.optAttributesDouble.Text = "DH";
            this.optAttributesDouble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optAttributesDouble.UseVisualStyleBackColor = true;
            this.optAttributesDouble.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optAttributes_MouseClick);
            // 
            // optAttributesSingle
            // 
            this.optAttributesSingle.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAttributesSingle.Location = new System.Drawing.Point(8, 3);
            this.optAttributesSingle.Name = "optAttributesSingle";
            this.optAttributesSingle.Size = new System.Drawing.Size(31, 31);
            this.optAttributesSingle.TabIndex = 11;
            this.optAttributesSingle.TabStop = true;
            this.optAttributesSingle.Text = "SH";
            this.optAttributesSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optAttributesSingle.UseVisualStyleBackColor = true;
            this.optAttributesSingle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optAttributes_MouseClick);
            // 
            // btnInk
            // 
            this.btnInk.Location = new System.Drawing.Point(57, 404);
            this.btnInk.Name = "btnInk";
            this.btnInk.Size = new System.Drawing.Size(20, 20);
            this.btnInk.TabIndex = 18;
            this.btnInk.Text = "I";
            this.ttpToolTip.SetToolTip(this.btnInk, "Set the screens foreground colour");
            this.btnInk.UseVisualStyleBackColor = true;
            this.btnInk.Click += new System.EventHandler(this.btnInk_Click);
            // 
            // btnPaper
            // 
            this.btnPaper.Location = new System.Drawing.Point(57, 430);
            this.btnPaper.Name = "btnPaper";
            this.btnPaper.Size = new System.Drawing.Size(20, 20);
            this.btnPaper.TabIndex = 15;
            this.btnPaper.Text = "P";
            this.ttpToolTip.SetToolTip(this.btnPaper, "Set the screens background colour");
            this.btnPaper.UseVisualStyleBackColor = true;
            this.btnPaper.Click += new System.EventHandler(this.btnPaper_Click);
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslInfo,
            this.tsslPosition,
            this.tsslAddress,
            this.tsslAscii});
            this.ssStatusBar.Location = new System.Drawing.Point(0, 535);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.Size = new System.Drawing.Size(891, 23);
            this.ssStatusBar.TabIndex = 28;
            // 
            // tsslStatus
            // 
            this.tsslStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(594, 18);
            this.tsslStatus.Spring = true;
            this.tsslStatus.Text = "Ready.";
            this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslInfo
            // 
            this.tsslInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(116, 18);
            this.tsslInfo.Text = "Blue Foreground";
            // 
            // tsslPosition
            // 
            this.tsslPosition.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslPosition.Name = "tsslPosition";
            this.tsslPosition.Size = new System.Drawing.Size(46, 18);
            this.tsslPosition.Text = "00,01";
            // 
            // tsslAddress
            // 
            this.tsslAddress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslAddress.Name = "tsslAddress";
            this.tsslAddress.Size = new System.Drawing.Size(46, 18);
            this.tsslAddress.Text = "$BB80";
            // 
            // tsslAscii
            // 
            this.tsslAscii.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslAscii.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslAscii.Name = "tsslAscii";
            this.tsslAscii.Size = new System.Drawing.Size(74, 18);
            this.tsslAscii.Text = "#FF (255)";
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(891, 24);
            this.mnu.TabIndex = 30;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(180, 22);
            this.mnuFileExit.Text = "Close";
            // 
            // tsToolsBar
            // 
            this.tsToolsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClearScreen,
            this.tsbReload,
            this.tssSep1,
            this.tsbSave,
            this.tssSep2,
            this.tsbPrint,
            this.tssSep3,
            this.tsbShowHideGrid});
            this.tsToolsBar.Location = new System.Drawing.Point(0, 24);
            this.tsToolsBar.Name = "tsToolsBar";
            this.tsToolsBar.Size = new System.Drawing.Size(891, 25);
            this.tsToolsBar.TabIndex = 31;
            this.tsToolsBar.Text = "toolStrip1";
            // 
            // tsbClearScreen
            // 
            this.tsbClearScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearScreen.Image")));
            this.tsbClearScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearScreen.Name = "tsbClearScreen";
            this.tsbClearScreen.Size = new System.Drawing.Size(23, 22);
            this.tsbClearScreen.Text = "Clear Screen";
            // 
            // tsbReload
            // 
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = ((System.Drawing.Image)(resources.GetObject("tsbReload.Image")));
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(23, 22);
            this.tsbReload.Text = "Reload";
            // 
            // tssSep1
            // 
            this.tssSep1.Name = "tssSep1";
            this.tssSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            // 
            // tssSep2
            // 
            this.tssSep2.Name = "tssSep2";
            this.tssSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Print Screen Image";
            // 
            // tssSep3
            // 
            this.tssSep3.Name = "tssSep3";
            this.tssSep3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbShowHideGrid
            // 
            this.tsbShowHideGrid.Checked = true;
            this.tsbShowHideGrid.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.tsbShowHideGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowHideGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowHideGrid.Image")));
            this.tsbShowHideGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowHideGrid.Name = "tsbShowHideGrid";
            this.tsbShowHideGrid.Size = new System.Drawing.Size(23, 22);
            this.tsbShowHideGrid.Text = "Grid";
            this.tsbShowHideGrid.Click += new System.EventHandler(this.tsbShowHideGrid_Click);
            // 
            // panTools
            // 
            this.panTools.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTools.Controls.Add(this.lblSelectedInkColour);
            this.panTools.Controls.Add(this.optToolsEraseMode);
            this.panTools.Controls.Add(this.panAttributesSteadyFlash);
            this.panTools.Controls.Add(this.optToolsTextMode);
            this.panTools.Controls.Add(this.panAttributesSingleDouble);
            this.panTools.Controls.Add(this.optToolsAttributeMode);
            this.panTools.Controls.Add(this.hdiv1);
            this.panTools.Controls.Add(this.optToolsColourMode);
            this.panTools.Controls.Add(this.btnInk);
            this.panTools.Controls.Add(this.hdiv2);
            this.panTools.Controls.Add(this.btnPaper);
            this.panTools.Controls.Add(this.lblBlack);
            this.panTools.Controls.Add(this.lblSelectedPaperColour);
            this.panTools.Controls.Add(this.lblBlue);
            this.panTools.Controls.Add(this.lblYellow);
            this.panTools.Controls.Add(this.lblWhite);
            this.panTools.Controls.Add(this.lblMagenta);
            this.panTools.Controls.Add(this.lblRed);
            this.panTools.Controls.Add(this.lblCyan);
            this.panTools.Controls.Add(this.lblGreen);
            this.panTools.Location = new System.Drawing.Point(7, 52);
            this.panTools.Name = "panTools";
            this.panTools.Size = new System.Drawing.Size(82, 461);
            this.panTools.TabIndex = 32;
            // 
            // lblSelectedInkColour
            // 
            this.lblSelectedInkColour.BackColor = System.Drawing.Color.White;
            this.lblSelectedInkColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedInkColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectedInkColour.Location = new System.Drawing.Point(6, 404);
            this.lblSelectedInkColour.Name = "lblSelectedInkColour";
            this.lblSelectedInkColour.Size = new System.Drawing.Size(31, 31);
            this.lblSelectedInkColour.TabIndex = 2;
            this.lblSelectedInkColour.Tag = "0";
            this.ttpToolTip.SetToolTip(this.lblSelectedInkColour, "Current Ink colour");
            // 
            // optToolsEraseMode
            // 
            this.optToolsEraseMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.optToolsEraseMode.Image = ((System.Drawing.Image)(resources.GetObject("optToolsEraseMode.Image")));
            this.optToolsEraseMode.Location = new System.Drawing.Point(43, 43);
            this.optToolsEraseMode.Name = "optToolsEraseMode";
            this.optToolsEraseMode.Size = new System.Drawing.Size(31, 31);
            this.optToolsEraseMode.TabIndex = 81;
            this.optToolsEraseMode.TabStop = true;
            this.optToolsEraseMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optToolsEraseMode.UseVisualStyleBackColor = true;
            this.optToolsEraseMode.CheckedChanged += new System.EventHandler(this.optToolsEraseMode_CheckedChanged);
            // 
            // panAttributesSteadyFlash
            // 
            this.panAttributesSteadyFlash.Controls.Add(this.optAttributesSteady);
            this.panAttributesSteadyFlash.Controls.Add(this.optAttributesFlashing);
            this.panAttributesSteadyFlash.Location = new System.Drawing.Point(0, 193);
            this.panAttributesSteadyFlash.Name = "panAttributesSteadyFlash";
            this.panAttributesSteadyFlash.Size = new System.Drawing.Size(80, 36);
            this.panAttributesSteadyFlash.TabIndex = 26;
            // 
            // optToolsTextMode
            // 
            this.optToolsTextMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.optToolsTextMode.Image = ((System.Drawing.Image)(resources.GetObject("optToolsTextMode.Image")));
            this.optToolsTextMode.Location = new System.Drawing.Point(6, 43);
            this.optToolsTextMode.Name = "optToolsTextMode";
            this.optToolsTextMode.Size = new System.Drawing.Size(31, 31);
            this.optToolsTextMode.TabIndex = 80;
            this.optToolsTextMode.TabStop = true;
            this.optToolsTextMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optToolsTextMode.UseVisualStyleBackColor = true;
            this.optToolsTextMode.CheckedChanged += new System.EventHandler(this.optToolsTextMode_CheckedChanged);
            // 
            // panAttributesSingleDouble
            // 
            this.panAttributesSingleDouble.Controls.Add(this.optAttributesSingle);
            this.panAttributesSingleDouble.Controls.Add(this.optAttributesDouble);
            this.panAttributesSingleDouble.Location = new System.Drawing.Point(0, 150);
            this.panAttributesSingleDouble.Name = "panAttributesSingleDouble";
            this.panAttributesSingleDouble.Size = new System.Drawing.Size(80, 36);
            this.panAttributesSingleDouble.TabIndex = 25;
            // 
            // optToolsAttributeMode
            // 
            this.optToolsAttributeMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.optToolsAttributeMode.Image = ((System.Drawing.Image)(resources.GetObject("optToolsAttributeMode.Image")));
            this.optToolsAttributeMode.Location = new System.Drawing.Point(43, 6);
            this.optToolsAttributeMode.Name = "optToolsAttributeMode";
            this.optToolsAttributeMode.Size = new System.Drawing.Size(31, 31);
            this.optToolsAttributeMode.TabIndex = 79;
            this.optToolsAttributeMode.TabStop = true;
            this.optToolsAttributeMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optToolsAttributeMode.UseVisualStyleBackColor = true;
            this.optToolsAttributeMode.CheckedChanged += new System.EventHandler(this.optToolsAttributeMode_CheckedChanged);
            // 
            // hdiv1
            // 
            this.hdiv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hdiv1.ForeColor = System.Drawing.Color.Navy;
            this.hdiv1.Location = new System.Drawing.Point(0, 134);
            this.hdiv1.Name = "hdiv1";
            this.hdiv1.Size = new System.Drawing.Size(80, 15);
            this.hdiv1.TabIndex = 23;
            this.hdiv1.Text = "Attributes";
            this.hdiv1.TextShadow = true;
            // 
            // optToolsColourMode
            // 
            this.optToolsColourMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.optToolsColourMode.Image = ((System.Drawing.Image)(resources.GetObject("optToolsColourMode.Image")));
            this.optToolsColourMode.Location = new System.Drawing.Point(6, 6);
            this.optToolsColourMode.Name = "optToolsColourMode";
            this.optToolsColourMode.Size = new System.Drawing.Size(31, 31);
            this.optToolsColourMode.TabIndex = 78;
            this.optToolsColourMode.TabStop = true;
            this.optToolsColourMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optToolsColourMode.UseVisualStyleBackColor = true;
            this.optToolsColourMode.CheckedChanged += new System.EventHandler(this.optToolsColourMode_CheckedChanged);
            // 
            // hdiv2
            // 
            this.hdiv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hdiv2.ForeColor = System.Drawing.Color.Navy;
            this.hdiv2.Location = new System.Drawing.Point(0, 241);
            this.hdiv2.Name = "hdiv2";
            this.hdiv2.Size = new System.Drawing.Size(80, 15);
            this.hdiv2.TabIndex = 9;
            this.hdiv2.Text = "Colours";
            this.hdiv2.TextShadow = true;
            // 
            // panEditor
            // 
            this.panEditor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEditor.Controls.Add(this.picEditor);
            this.panEditor.Location = new System.Drawing.Point(95, 52);
            this.panEditor.Name = "panEditor";
            this.panEditor.Size = new System.Drawing.Size(517, 477);
            this.panEditor.TabIndex = 33;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.Black;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Location = new System.Drawing.Point(6, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(241, 225);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic.TabIndex = 35;
            this.pic.TabStop = false;
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.lblEndAddress);
            this.grpInformation.Controls.Add(this.ibxDimensions);
            this.grpInformation.Controls.Add(this.ibxLength);
            this.grpInformation.Controls.Add(this.lblDimensions);
            this.grpInformation.Controls.Add(this.ibxEndAddress);
            this.grpInformation.Controls.Add(this.ibxStartAddress);
            this.grpInformation.Controls.Add(this.lblStartAddress);
            this.grpInformation.Controls.Add(this.lblLength);
            this.grpInformation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInformation.Location = new System.Drawing.Point(623, 296);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(259, 110);
            this.grpInformation.TabIndex = 73;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "Information";
            // 
            // lblEndAddress
            // 
            this.lblEndAddress.AutoSize = true;
            this.lblEndAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEndAddress.Location = new System.Drawing.Point(160, 25);
            this.lblEndAddress.Name = "lblEndAddress";
            this.lblEndAddress.Size = new System.Drawing.Size(18, 13);
            this.lblEndAddress.TabIndex = 76;
            this.lblEndAddress.Text = "to";
            // 
            // ibxDimensions
            // 
            this.ibxDimensions.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDimensions.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDimensions.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDimensions.Location = new System.Drawing.Point(85, 76);
            this.ibxDimensions.Name = "ibxDimensions";
            this.ibxDimensions.Size = new System.Drawing.Size(168, 20);
            this.ibxDimensions.TabIndex = 69;
            // 
            // ibxLength
            // 
            this.ibxLength.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxLength.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxLength.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxLength.Location = new System.Drawing.Point(85, 48);
            this.ibxLength.Name = "ibxLength";
            this.ibxLength.Size = new System.Drawing.Size(168, 22);
            this.ibxLength.TabIndex = 68;
            // 
            // lblDimensions
            // 
            this.lblDimensions.BackColor = System.Drawing.Color.Transparent;
            this.lblDimensions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDimensions.Location = new System.Drawing.Point(4, 80);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(75, 13);
            this.lblDimensions.TabIndex = 70;
            this.lblDimensions.Text = "Dimensions :";
            this.lblDimensions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibxEndAddress
            // 
            this.ibxEndAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxEndAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxEndAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxEndAddress.Location = new System.Drawing.Point(182, 20);
            this.ibxEndAddress.Name = "ibxEndAddress";
            this.ibxEndAddress.Size = new System.Drawing.Size(71, 22);
            this.ibxEndAddress.TabIndex = 66;
            // 
            // ibxStartAddress
            // 
            this.ibxStartAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxStartAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStartAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStartAddress.Location = new System.Drawing.Point(85, 20);
            this.ibxStartAddress.Name = "ibxStartAddress";
            this.ibxStartAddress.Size = new System.Drawing.Size(71, 22);
            this.ibxStartAddress.TabIndex = 64;
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblStartAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStartAddress.Location = new System.Drawing.Point(4, 25);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(75, 13);
            this.lblStartAddress.TabIndex = 43;
            this.lblStartAddress.Text = "Address :";
            this.lblStartAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLength
            // 
            this.lblLength.BackColor = System.Drawing.Color.Transparent;
            this.lblLength.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLength.Location = new System.Drawing.Point(4, 53);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(75, 13);
            this.lblLength.TabIndex = 45;
            this.lblLength.Text = "Length :";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pan
            // 
            this.pan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan.Controls.Add(this.pic);
            this.pan.Location = new System.Drawing.Point(623, 52);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(255, 235);
            this.pan.TabIndex = 75;
            // 
            // ttpToolTip
            // 
            this.ttpToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ttpToolTip_Popup);
            // 
            // frmTextScreenEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 558);
            this.Controls.Add(this.panTools);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.grpInformation);
            this.Controls.Add(this.panEditor);
            this.Controls.Add(this.tsToolsBar);
            this.Controls.Add(this.ssStatusBar);
            this.Controls.Add(this.mnu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextScreenEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Screen Editor";
            this.Load += new System.EventHandler(this.frmTextScreenEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picEditor)).EndInit();
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.tsToolsBar.ResumeLayout(false);
            this.tsToolsBar.PerformLayout();
            this.panTools.ResumeLayout(false);
            this.panAttributesSteadyFlash.ResumeLayout(false);
            this.panAttributesSingleDouble.ResumeLayout(false);
            this.panEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.pan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picEditor;
        private System.Windows.Forms.Label lblSelectedPaperColour;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.Label lblYellow;
        private System.Windows.Forms.Label lblMagenta;
        private System.Windows.Forms.Label lblCyan;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.RadioButton optAttributesDouble;
        private System.Windows.Forms.RadioButton optAttributesSingle;
        private System.Windows.Forms.Button btnPaper;
        private System.Windows.Forms.Button btnInk;
        private System.Windows.Forms.RadioButton optAttributesSteady;
        private System.Windows.Forms.RadioButton optAttributesFlashing;
        private System.Windows.Forms.StatusStrip ssStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStrip tsToolsBar;
        private System.Windows.Forms.Panel panTools;
        private System.Windows.Forms.Panel panEditor;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripButton tsbClearScreen;
        private System.Windows.Forms.ToolStripButton tsbReload;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbShowHideGrid;
        private HorizontalDivider.HorizontalDivider hdiv1;
        private HorizontalDivider.HorizontalDivider hdiv2;
        private System.Windows.Forms.Label lblSelectedInkColour;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.GroupBox grpInformation;
        private InfoBox.InfoBox ibxDimensions;
        private InfoBox.InfoBox ibxLength;
        private InfoBox.InfoBox ibxEndAddress;
        private InfoBox.InfoBox ibxStartAddress;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Panel pan;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator tssSep1;
        private System.Windows.Forms.ToolStripSeparator tssSep2;
        private System.Windows.Forms.ToolStripSeparator tssSep3;
        private System.Windows.Forms.ToolTip ttpToolTip;
        private System.Windows.Forms.Panel panAttributesSteadyFlash;
        private System.Windows.Forms.Panel panAttributesSingleDouble;
        private System.Windows.Forms.RadioButton optToolsEraseMode;
        private System.Windows.Forms.RadioButton optToolsTextMode;
        private System.Windows.Forms.RadioButton optToolsAttributeMode;
        private System.Windows.Forms.RadioButton optToolsColourMode;
        private System.Windows.Forms.ToolStripStatusLabel tsslPosition;
        private System.Windows.Forms.ToolStripStatusLabel tsslAddress;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslAscii;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblEndAddress;
    }
}