namespace OricExplorer
{
    partial class TextScreenEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextScreenEditorForm));
            this.pictureBoxEditor = new System.Windows.Forms.PictureBox();
            this.labelSelectedPaperColour = new System.Windows.Forms.Label();
            this.labelWhite = new System.Windows.Forms.Label();
            this.labelYellow = new System.Windows.Forms.Label();
            this.labelMagenta = new System.Windows.Forms.Label();
            this.labelCyan = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelBlack = new System.Windows.Forms.Label();
            this.radioButtonSteady = new System.Windows.Forms.RadioButton();
            this.radioButtonFlashing = new System.Windows.Forms.RadioButton();
            this.radioButtonDouble = new System.Windows.Forms.RadioButton();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.buttonInk = new System.Windows.Forms.Button();
            this.buttonPaper = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClearScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowHideGrid = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelSelectedInkColour = new System.Windows.Forms.Label();
            this.radioButtonEraseMode = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButtonTextMode = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonAttributeMode = new System.Windows.Forms.RadioButton();
            this.horizontalDivider2 = new HorizontalDivider.HorizontalDivider();
            this.radioButtonColourMode = new System.Windows.Forms.RadioButton();
            this.horizontalDivider1 = new HorizontalDivider.HorizontalDivider();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.infoBoxDimensions = new InfoBox.InfoBox();
            this.infoBoxLength = new InfoBox.InfoBox();
            this.infoBoxEndAddress = new InfoBox.InfoBox();
            this.infoBoxStartAddress = new InfoBox.InfoBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripStatusLabelAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAscii = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditor)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxEditor
            // 
            this.pictureBoxEditor.BackColor = System.Drawing.Color.Beige;
            this.pictureBoxEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEditor.Location = new System.Drawing.Point(6, 4);
            this.pictureBoxEditor.Name = "pictureBoxEditor";
            this.pictureBoxEditor.Size = new System.Drawing.Size(503, 466);
            this.pictureBoxEditor.TabIndex = 0;
            this.pictureBoxEditor.TabStop = false;
            this.pictureBoxEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEditor_MouseDown);
            this.pictureBoxEditor.MouseLeave += new System.EventHandler(this.pictureBoxEditor_MouseLeave);
            this.pictureBoxEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEditor_MouseMove);
            // 
            // labelSelectedPaperColour
            // 
            this.labelSelectedPaperColour.BackColor = System.Drawing.Color.Black;
            this.labelSelectedPaperColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedPaperColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSelectedPaperColour.Location = new System.Drawing.Point(20, 416);
            this.labelSelectedPaperColour.Name = "labelSelectedPaperColour";
            this.labelSelectedPaperColour.Size = new System.Drawing.Size(31, 31);
            this.labelSelectedPaperColour.TabIndex = 1;
            this.labelSelectedPaperColour.Tag = "0";
            this.toolTip1.SetToolTip(this.labelSelectedPaperColour, "Current Paper colour");
            // 
            // labelWhite
            // 
            this.labelWhite.BackColor = System.Drawing.Color.White;
            this.labelWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelWhite.Location = new System.Drawing.Point(42, 355);
            this.labelWhite.Name = "labelWhite";
            this.labelWhite.Size = new System.Drawing.Size(31, 31);
            this.labelWhite.TabIndex = 8;
            this.labelWhite.Tag = "7";
            this.toolTip1.SetToolTip(this.labelWhite, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelWhite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelYellow
            // 
            this.labelYellow.BackColor = System.Drawing.Color.Yellow;
            this.labelYellow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelYellow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelYellow.Location = new System.Drawing.Point(42, 291);
            this.labelYellow.Name = "labelYellow";
            this.labelYellow.Size = new System.Drawing.Size(31, 31);
            this.labelYellow.TabIndex = 7;
            this.labelYellow.Tag = "3";
            this.toolTip1.SetToolTip(this.labelYellow, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelYellow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelMagenta
            // 
            this.labelMagenta.BackColor = System.Drawing.Color.Magenta;
            this.labelMagenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMagenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMagenta.Location = new System.Drawing.Point(42, 323);
            this.labelMagenta.Name = "labelMagenta";
            this.labelMagenta.Size = new System.Drawing.Size(31, 31);
            this.labelMagenta.TabIndex = 6;
            this.labelMagenta.Tag = "5";
            this.toolTip1.SetToolTip(this.labelMagenta, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelMagenta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelCyan
            // 
            this.labelCyan.BackColor = System.Drawing.Color.Cyan;
            this.labelCyan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCyan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCyan.Location = new System.Drawing.Point(8, 355);
            this.labelCyan.Name = "labelCyan";
            this.labelCyan.Size = new System.Drawing.Size(31, 31);
            this.labelCyan.TabIndex = 5;
            this.labelCyan.Tag = "6";
            this.toolTip1.SetToolTip(this.labelCyan, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelCyan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelBlue
            // 
            this.labelBlue.BackColor = System.Drawing.Color.Blue;
            this.labelBlue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBlue.Location = new System.Drawing.Point(8, 323);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(31, 31);
            this.labelBlue.TabIndex = 4;
            this.labelBlue.Tag = "4";
            this.toolTip1.SetToolTip(this.labelBlue, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelBlue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelGreen
            // 
            this.labelGreen.BackColor = System.Drawing.Color.Lime;
            this.labelGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGreen.Location = new System.Drawing.Point(8, 291);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(31, 31);
            this.labelGreen.TabIndex = 3;
            this.labelGreen.Tag = "2";
            this.toolTip1.SetToolTip(this.labelGreen, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelGreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelRed
            // 
            this.labelRed.BackColor = System.Drawing.Color.Red;
            this.labelRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelRed.Location = new System.Drawing.Point(42, 259);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(31, 31);
            this.labelRed.TabIndex = 2;
            this.labelRed.Tag = "1";
            this.toolTip1.SetToolTip(this.labelRed, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelRed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // labelBlack
            // 
            this.labelBlack.BackColor = System.Drawing.Color.Black;
            this.labelBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelBlack.Location = new System.Drawing.Point(8, 259);
            this.labelBlack.Name = "labelBlack";
            this.labelBlack.Size = new System.Drawing.Size(31, 31);
            this.labelBlack.TabIndex = 1;
            this.labelBlack.Tag = "0";
            this.toolTip1.SetToolTip(this.labelBlack, "Click left mouse button to select this as the INK colour or Right button to selec" +
        "t it as the PAPER colour.");
            this.labelBlack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_MouseClick);
            // 
            // radioButtonSteady
            // 
            this.radioButtonSteady.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonSteady.Location = new System.Drawing.Point(8, 2);
            this.radioButtonSteady.Name = "radioButtonSteady";
            this.radioButtonSteady.Size = new System.Drawing.Size(31, 31);
            this.radioButtonSteady.TabIndex = 13;
            this.radioButtonSteady.TabStop = true;
            this.radioButtonSteady.Text = "SD";
            this.radioButtonSteady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonSteady.UseVisualStyleBackColor = true;
            this.radioButtonSteady.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseClick);
            // 
            // radioButtonFlashing
            // 
            this.radioButtonFlashing.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonFlashing.Location = new System.Drawing.Point(42, 2);
            this.radioButtonFlashing.Name = "radioButtonFlashing";
            this.radioButtonFlashing.Size = new System.Drawing.Size(31, 31);
            this.radioButtonFlashing.TabIndex = 11;
            this.radioButtonFlashing.TabStop = true;
            this.radioButtonFlashing.Text = "FL";
            this.radioButtonFlashing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonFlashing.UseVisualStyleBackColor = true;
            this.radioButtonFlashing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseClick);
            // 
            // radioButtonDouble
            // 
            this.radioButtonDouble.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonDouble.Location = new System.Drawing.Point(42, 3);
            this.radioButtonDouble.Name = "radioButtonDouble";
            this.radioButtonDouble.Size = new System.Drawing.Size(31, 31);
            this.radioButtonDouble.TabIndex = 13;
            this.radioButtonDouble.TabStop = true;
            this.radioButtonDouble.Text = "DH";
            this.radioButtonDouble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonDouble.UseVisualStyleBackColor = true;
            this.radioButtonDouble.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseClick);
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonSingle.Location = new System.Drawing.Point(8, 3);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(31, 31);
            this.radioButtonSingle.TabIndex = 11;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "SH";
            this.radioButtonSingle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            this.radioButtonSingle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseClick);
            // 
            // buttonInk
            // 
            this.buttonInk.Location = new System.Drawing.Point(57, 404);
            this.buttonInk.Name = "buttonInk";
            this.buttonInk.Size = new System.Drawing.Size(20, 20);
            this.buttonInk.TabIndex = 18;
            this.buttonInk.Text = "I";
            this.toolTip1.SetToolTip(this.buttonInk, "Set the screens foreground colour");
            this.buttonInk.UseVisualStyleBackColor = true;
            this.buttonInk.Click += new System.EventHandler(this.buttonInk_Click);
            // 
            // buttonPaper
            // 
            this.buttonPaper.Location = new System.Drawing.Point(57, 430);
            this.buttonPaper.Name = "buttonPaper";
            this.buttonPaper.Size = new System.Drawing.Size(20, 20);
            this.buttonPaper.TabIndex = 15;
            this.buttonPaper.Text = "P";
            this.toolTip1.SetToolTip(this.buttonPaper, "Set the screens background colour");
            this.buttonPaper.UseVisualStyleBackColor = true;
            this.buttonPaper.Click += new System.EventHandler(this.buttonPaper_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelInfo,
            this.toolStripStatusLabelPosition,
            this.toolStripStatusLabelAddress,
            this.toolStripStatusLabelAscii});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(891, 23);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(594, 18);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Ready.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClearScreen,
            this.toolStripButtonReload,
            this.toolStripSeparator2,
            this.toolStripButtonSave,
            this.toolStripSeparator3,
            this.toolStripButtonPrint,
            this.toolStripSeparator1,
            this.toolStripButtonShowHideGrid});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(891, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonClearScreen
            // 
            this.toolStripButtonClearScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClearScreen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearScreen.Image")));
            this.toolStripButtonClearScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearScreen.Name = "toolStripButtonClearScreen";
            this.toolStripButtonClearScreen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClearScreen.Text = "Clear Screen";
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReload.Image")));
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReload.Text = "Reload";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrint.Image")));
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrint.Text = "Print Screen Image";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowHideGrid
            // 
            this.toolStripButtonShowHideGrid.Checked = true;
            this.toolStripButtonShowHideGrid.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.toolStripButtonShowHideGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowHideGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowHideGrid.Image")));
            this.toolStripButtonShowHideGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowHideGrid.Name = "toolStripButtonShowHideGrid";
            this.toolStripButtonShowHideGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowHideGrid.Text = "Grid";
            this.toolStripButtonShowHideGrid.Click += new System.EventHandler(this.toolStripButtonShowHideGrid_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelSelectedInkColour);
            this.panel3.Controls.Add(this.radioButtonEraseMode);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.radioButtonTextMode);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.radioButtonAttributeMode);
            this.panel3.Controls.Add(this.horizontalDivider2);
            this.panel3.Controls.Add(this.radioButtonColourMode);
            this.panel3.Controls.Add(this.buttonInk);
            this.panel3.Controls.Add(this.horizontalDivider1);
            this.panel3.Controls.Add(this.buttonPaper);
            this.panel3.Controls.Add(this.labelBlack);
            this.panel3.Controls.Add(this.labelSelectedPaperColour);
            this.panel3.Controls.Add(this.labelBlue);
            this.panel3.Controls.Add(this.labelYellow);
            this.panel3.Controls.Add(this.labelWhite);
            this.panel3.Controls.Add(this.labelMagenta);
            this.panel3.Controls.Add(this.labelRed);
            this.panel3.Controls.Add(this.labelCyan);
            this.panel3.Controls.Add(this.labelGreen);
            this.panel3.Location = new System.Drawing.Point(7, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(82, 461);
            this.panel3.TabIndex = 32;
            // 
            // labelSelectedInkColour
            // 
            this.labelSelectedInkColour.BackColor = System.Drawing.Color.White;
            this.labelSelectedInkColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectedInkColour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSelectedInkColour.Location = new System.Drawing.Point(6, 404);
            this.labelSelectedInkColour.Name = "labelSelectedInkColour";
            this.labelSelectedInkColour.Size = new System.Drawing.Size(31, 31);
            this.labelSelectedInkColour.TabIndex = 2;
            this.labelSelectedInkColour.Tag = "0";
            this.toolTip1.SetToolTip(this.labelSelectedInkColour, "Current Ink colour");
            // 
            // radioButtonEraseMode
            // 
            this.radioButtonEraseMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonEraseMode.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonEraseMode.Image")));
            this.radioButtonEraseMode.Location = new System.Drawing.Point(43, 43);
            this.radioButtonEraseMode.Name = "radioButtonEraseMode";
            this.radioButtonEraseMode.Size = new System.Drawing.Size(31, 31);
            this.radioButtonEraseMode.TabIndex = 81;
            this.radioButtonEraseMode.TabStop = true;
            this.radioButtonEraseMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonEraseMode.UseVisualStyleBackColor = true;
            this.radioButtonEraseMode.CheckedChanged += new System.EventHandler(this.radioButtonEraseMode_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioButtonSteady);
            this.panel5.Controls.Add(this.radioButtonFlashing);
            this.panel5.Location = new System.Drawing.Point(0, 193);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(80, 36);
            this.panel5.TabIndex = 26;
            // 
            // radioButtonTextMode
            // 
            this.radioButtonTextMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonTextMode.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonTextMode.Image")));
            this.radioButtonTextMode.Location = new System.Drawing.Point(6, 43);
            this.radioButtonTextMode.Name = "radioButtonTextMode";
            this.radioButtonTextMode.Size = new System.Drawing.Size(31, 31);
            this.radioButtonTextMode.TabIndex = 80;
            this.radioButtonTextMode.TabStop = true;
            this.radioButtonTextMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonTextMode.UseVisualStyleBackColor = true;
            this.radioButtonTextMode.CheckedChanged += new System.EventHandler(this.radioButtonTextMode_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonSingle);
            this.panel2.Controls.Add(this.radioButtonDouble);
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 36);
            this.panel2.TabIndex = 25;
            // 
            // radioButtonAttributeMode
            // 
            this.radioButtonAttributeMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAttributeMode.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonAttributeMode.Image")));
            this.radioButtonAttributeMode.Location = new System.Drawing.Point(43, 6);
            this.radioButtonAttributeMode.Name = "radioButtonAttributeMode";
            this.radioButtonAttributeMode.Size = new System.Drawing.Size(31, 31);
            this.radioButtonAttributeMode.TabIndex = 79;
            this.radioButtonAttributeMode.TabStop = true;
            this.radioButtonAttributeMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonAttributeMode.UseVisualStyleBackColor = true;
            this.radioButtonAttributeMode.CheckedChanged += new System.EventHandler(this.radioButtonAttributeMode_CheckedChanged);
            // 
            // horizontalDivider2
            // 
            this.horizontalDivider2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider2.ForeColor = System.Drawing.Color.Navy;
            this.horizontalDivider2.Location = new System.Drawing.Point(0, 134);
            this.horizontalDivider2.Name = "horizontalDivider2";
            this.horizontalDivider2.Size = new System.Drawing.Size(200, 15);
            this.horizontalDivider2.TabIndex = 23;
            this.horizontalDivider2.Text = "Attributes";
            this.horizontalDivider2.TextShadow = true;
            // 
            // radioButtonColourMode
            // 
            this.radioButtonColourMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonColourMode.Image = ((System.Drawing.Image)(resources.GetObject("radioButtonColourMode.Image")));
            this.radioButtonColourMode.Location = new System.Drawing.Point(6, 6);
            this.radioButtonColourMode.Name = "radioButtonColourMode";
            this.radioButtonColourMode.Size = new System.Drawing.Size(31, 31);
            this.radioButtonColourMode.TabIndex = 78;
            this.radioButtonColourMode.TabStop = true;
            this.radioButtonColourMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonColourMode.UseVisualStyleBackColor = true;
            this.radioButtonColourMode.CheckedChanged += new System.EventHandler(this.radioButtonColourMode_CheckedChanged);
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider1.ForeColor = System.Drawing.Color.Navy;
            this.horizontalDivider1.Location = new System.Drawing.Point(0, 241);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(200, 15);
            this.horizontalDivider1.TabIndex = 9;
            this.horizontalDivider1.Text = "Colours";
            this.horizontalDivider1.TextShadow = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBoxEditor);
            this.panel4.Location = new System.Drawing.Point(95, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(517, 477);
            this.panel4.TabIndex = 33;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.infoBoxDimensions);
            this.groupBox5.Controls.Add(this.infoBoxLength);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.infoBoxEndAddress);
            this.groupBox5.Controls.Add(this.infoBoxStartAddress);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(623, 296);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 110);
            this.groupBox5.TabIndex = 73;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Information";
            // 
            // infoBoxDimensions
            // 
            this.infoBoxDimensions.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDimensions.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDimensions.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDimensions.Location = new System.Drawing.Point(85, 76);
            this.infoBoxDimensions.Name = "infoBoxDimensions";
            this.infoBoxDimensions.Size = new System.Drawing.Size(168, 20);
            this.infoBoxDimensions.TabIndex = 69;
            // 
            // infoBoxLength
            // 
            this.infoBoxLength.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxLength.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxLength.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxLength.Location = new System.Drawing.Point(85, 48);
            this.infoBoxLength.Name = "infoBoxLength";
            this.infoBoxLength.Size = new System.Drawing.Size(168, 22);
            this.infoBoxLength.TabIndex = 68;
            // 
            // infoBoxEndAddress
            // 
            this.infoBoxEndAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxEndAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxEndAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxEndAddress.Location = new System.Drawing.Point(182, 20);
            this.infoBoxEndAddress.Name = "infoBoxEndAddress";
            this.infoBoxEndAddress.Size = new System.Drawing.Size(71, 22);
            this.infoBoxEndAddress.TabIndex = 66;
            // 
            // infoBoxStartAddress
            // 
            this.infoBoxStartAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxStartAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStartAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStartAddress.Location = new System.Drawing.Point(85, 20);
            this.infoBoxStartAddress.Name = "infoBoxStartAddress";
            this.infoBoxStartAddress.Size = new System.Drawing.Size(71, 22);
            this.infoBoxStartAddress.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Address :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(4, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Length :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(623, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 235);
            this.panel1.TabIndex = 75;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // toolStripStatusLabelAddress
            // 
            this.toolStripStatusLabelAddress.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelAddress.Name = "toolStripStatusLabelAddress";
            this.toolStripStatusLabelAddress.Size = new System.Drawing.Size(46, 18);
            this.toolStripStatusLabelAddress.Text = "$BB80";
            // 
            // toolStripStatusLabelPosition
            // 
            this.toolStripStatusLabelPosition.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelPosition.Name = "toolStripStatusLabelPosition";
            this.toolStripStatusLabelPosition.Size = new System.Drawing.Size(46, 18);
            this.toolStripStatusLabelPosition.Text = "00,01";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(116, 18);
            this.toolStripStatusLabelInfo.Text = "Blue Foreground";
            // 
            // toolStripStatusLabelAscii
            // 
            this.toolStripStatusLabelAscii.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabelAscii.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelAscii.Name = "toolStripStatusLabelAscii";
            this.toolStripStatusLabelAscii.Size = new System.Drawing.Size(74, 18);
            this.toolStripStatusLabelAscii.Text = "#FF (255)";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Dimensions :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(160, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "to";
            // 
            // TextScreenEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 558);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextScreenEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Screen Editor";
            this.Load += new System.EventHandler(this.TextEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditor)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxEditor;
        private System.Windows.Forms.Label labelSelectedPaperColour;
        private System.Windows.Forms.Label labelWhite;
        private System.Windows.Forms.Label labelYellow;
        private System.Windows.Forms.Label labelMagenta;
        private System.Windows.Forms.Label labelCyan;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelBlack;
        private System.Windows.Forms.RadioButton radioButtonDouble;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.Button buttonPaper;
        private System.Windows.Forms.Button buttonInk;
        private System.Windows.Forms.RadioButton radioButtonSteady;
        private System.Windows.Forms.RadioButton radioButtonFlashing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearScreen;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowHideGrid;
        private HorizontalDivider.HorizontalDivider horizontalDivider2;
        private HorizontalDivider.HorizontalDivider horizontalDivider1;
        private System.Windows.Forms.Label labelSelectedInkColour;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private InfoBox.InfoBox infoBoxDimensions;
        private InfoBox.InfoBox infoBoxLength;
        private InfoBox.InfoBox infoBoxEndAddress;
        private InfoBox.InfoBox infoBoxStartAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonEraseMode;
        private System.Windows.Forms.RadioButton radioButtonTextMode;
        private System.Windows.Forms.RadioButton radioButtonAttributeMode;
        private System.Windows.Forms.RadioButton radioButtonColourMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPosition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAddress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAscii;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}