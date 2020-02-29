using System.Drawing;

namespace OricExplorer.User_Controls    
{
    partial class DiskInfoViewerControl
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
            if (disposing && (components != null))
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
            System.Windows.Forms.ListViewGroup listViewGroup41 = new System.Windows.Forms.ListViewGroup("BASIC Programs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup42 = new System.Windows.Forms.ListViewGroup("Code/Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup43 = new System.Windows.Forms.ListViewGroup("TEXT Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup44 = new System.Windows.Forms.ListViewGroup("HIRES Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup45 = new System.Windows.Forms.ListViewGroup("Character Sets", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup46 = new System.Windows.Forms.ListViewGroup("Text Windows", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup47 = new System.Windows.Forms.ListViewGroup("Sequential Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup48 = new System.Windows.Forms.ListViewGroup("Direct Access Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup49 = new System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup50 = new System.Windows.Forms.ListViewGroup("HELP Screens", System.Windows.Forms.HorizontalAlignment.Left);
            this.groupFrame5 = new GroupFrame.GroupFrame();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupFrame9 = new GroupFrame.GroupFrame();
            this.buttonResetSector = new System.Windows.Forms.Button();
            this.trackBarSectors = new System.Windows.Forms.TrackBar();
            this.groupFrame6 = new GroupFrame.GroupFrame();
            this.label4 = new System.Windows.Forms.Label();
            this.infoBoxNextTrack = new InfoBox.InfoBox();
            this.infoBoxNextSector = new InfoBox.InfoBox();
            this.infoBoxNextSide = new InfoBox.InfoBox();
            this.horizontalDivider1 = new HorizontalDivider.HorizontalDivider();
            this.buttonJumpToSector = new System.Windows.Forms.Button();
            this.infoBoxSelectedTrack = new InfoBox.InfoBox();
            this.infoBoxSelectedSector = new InfoBox.InfoBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.infoBoxSelectedSide = new InfoBox.InfoBox();
            this.infoBoxSectorDescription = new InfoBox.InfoBox();
            this.groupFrame8 = new GroupFrame.GroupFrame();
            this.trackBarTracks = new System.Windows.Forms.TrackBar();
            this.buttonResetTrack = new System.Windows.Forms.Button();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.tabPageDiskDirectory = new System.Windows.Forms.TabPage();
            this.buttonPrintSetup = new System.Windows.Forms.Button();
            this.lvDirectory = new System.Windows.Forms.ListView();
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSectors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAutoRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProtection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonPrintPreview = new System.Windows.Forms.Button();
            this.checkBoxViewGroups = new System.Windows.Forms.CheckBox();
            this.buttonPrintDirectory = new System.Windows.Forms.Button();
            this.groupFrame4 = new GroupFrame.GroupFrame();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.infoBoxSectorMapInfo = new InfoBox.InfoBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoBoxSectorMapSector = new InfoBox.InfoBox();
            this.infoBoxSectorMapTrack = new InfoBox.InfoBox();
            this.tabSides = new System.Windows.Forms.TabControl();
            this.tabPageSide0 = new System.Windows.Forms.TabPage();
            this.pbSectorMapSide0 = new System.Windows.Forms.PictureBox();
            this.tabPageSide1 = new System.Windows.Forms.TabPage();
            this.pbSectorMapSide1 = new System.Windows.Forms.PictureBox();
            this.groupFrame3 = new GroupFrame.GroupFrame();
            this.percentageBar1 = new PercentageBar.PercentageBar();
            this.infoBoxUsage = new InfoBox.InfoBox();
            this.groupFrame2 = new GroupFrame.GroupFrame();
            this.infoBoxStructure = new InfoBox.InfoBox();
            this.groupFrame1 = new GroupFrame.GroupFrame();
            this.infoBoxDiskName = new InfoBox.InfoBox();
            this.infoBoxDiskType = new InfoBox.InfoBox();
            this.infoBoxDOS = new InfoBox.InfoBox();
            this.groupFrame5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupFrame9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).BeginInit();
            this.groupFrame6.SuspendLayout();
            this.groupFrame8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).BeginInit();
            this.tabPageDiskDirectory.SuspendLayout();
            this.groupFrame4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSides.SuspendLayout();
            this.tabPageSide0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide0)).BeginInit();
            this.tabPageSide1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide1)).BeginInit();
            this.groupFrame3.SuspendLayout();
            this.groupFrame2.SuspendLayout();
            this.groupFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFrame5
            // 
            this.groupFrame5.Controls.Add(this.tabControl2);
            this.groupFrame5.Location = new System.Drawing.Point(12, 305);
            this.groupFrame5.Name = "groupFrame5";
            this.groupFrame5.Size = new System.Drawing.Size(919, 288);
            this.groupFrame5.TabIndex = 57;
            this.groupFrame5.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPageDiskDirectory);
            this.tabControl2.Location = new System.Drawing.Point(7, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(898, 268);
            this.tabControl2.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupFrame9);
            this.tabPage1.Controls.Add(this.groupFrame6);
            this.tabPage1.Controls.Add(this.groupFrame8);
            this.tabPage1.Controls.Add(this.hexBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sector Data";
            // 
            // groupFrame9
            // 
            this.groupFrame9.Controls.Add(this.buttonResetSector);
            this.groupFrame9.Controls.Add(this.trackBarSectors);
            this.groupFrame9.Location = new System.Drawing.Point(809, 6);
            this.groupFrame9.Name = "groupFrame9";
            this.groupFrame9.Size = new System.Drawing.Size(70, 227);
            this.groupFrame9.TabIndex = 59;
            this.groupFrame9.TabStop = false;
            this.groupFrame9.Text = "Sector";
            this.groupFrame9.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonResetSector
            // 
            this.buttonResetSector.Location = new System.Drawing.Point(7, 196);
            this.buttonResetSector.Name = "buttonResetSector";
            this.buttonResetSector.Size = new System.Drawing.Size(57, 24);
            this.buttonResetSector.TabIndex = 8;
            this.buttonResetSector.Text = "Reset";
            this.buttonResetSector.UseVisualStyleBackColor = true;
            this.buttonResetSector.Click += new System.EventHandler(this.buttonResetSector_Click);
            // 
            // trackBarSectors
            // 
            this.trackBarSectors.Location = new System.Drawing.Point(13, 17);
            this.trackBarSectors.Name = "trackBarSectors";
            this.trackBarSectors.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSectors.Size = new System.Drawing.Size(45, 174);
            this.trackBarSectors.TabIndex = 0;
            this.trackBarSectors.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSectors.ValueChanged += new System.EventHandler(this.trackBarSectors_ValueChanged);
            // 
            // groupFrame6
            // 
            this.groupFrame6.Controls.Add(this.label4);
            this.groupFrame6.Controls.Add(this.infoBoxNextTrack);
            this.groupFrame6.Controls.Add(this.infoBoxNextSector);
            this.groupFrame6.Controls.Add(this.infoBoxNextSide);
            this.groupFrame6.Controls.Add(this.horizontalDivider1);
            this.groupFrame6.Controls.Add(this.buttonJumpToSector);
            this.groupFrame6.Controls.Add(this.infoBoxSelectedTrack);
            this.groupFrame6.Controls.Add(this.infoBoxSelectedSector);
            this.groupFrame6.Controls.Add(this.label7);
            this.groupFrame6.Controls.Add(this.label5);
            this.groupFrame6.Controls.Add(this.label6);
            this.groupFrame6.Controls.Add(this.infoBoxSelectedSide);
            this.groupFrame6.Controls.Add(this.infoBoxSectorDescription);
            this.groupFrame6.Location = new System.Drawing.Point(529, 6);
            this.groupFrame6.Name = "groupFrame6";
            this.groupFrame6.Size = new System.Drawing.Size(184, 227);
            this.groupFrame6.TabIndex = 66;
            this.groupFrame6.TabStop = false;
            this.groupFrame6.Text = "Sector Info";
            this.groupFrame6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(56, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Sector Details";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoBoxNextTrack
            // 
            this.infoBoxNextTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxNextTrack.ForeColor = System.Drawing.Color.Blue;
            this.infoBoxNextTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextTrack.Location = new System.Drawing.Point(72, 165);
            this.infoBoxNextTrack.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxNextTrack.Name = "infoBoxNextTrack";
            this.infoBoxNextTrack.Size = new System.Drawing.Size(40, 20);
            this.infoBoxNextTrack.TabIndex = 45;
            // 
            // infoBoxNextSector
            // 
            this.infoBoxNextSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxNextSector.ForeColor = System.Drawing.Color.Blue;
            this.infoBoxNextSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextSector.Location = new System.Drawing.Point(120, 165);
            this.infoBoxNextSector.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxNextSector.Name = "infoBoxNextSector";
            this.infoBoxNextSector.Size = new System.Drawing.Size(40, 20);
            this.infoBoxNextSector.TabIndex = 44;
            // 
            // infoBoxNextSide
            // 
            this.infoBoxNextSide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxNextSide.ForeColor = System.Drawing.Color.Blue;
            this.infoBoxNextSide.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextSide.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxNextSide.Location = new System.Drawing.Point(24, 166);
            this.infoBoxNextSide.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxNextSide.Name = "infoBoxNextSide";
            this.infoBoxNextSide.Size = new System.Drawing.Size(40, 19);
            this.infoBoxNextSide.TabIndex = 43;
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider1.Location = new System.Drawing.Point(0, 144);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(200, 15);
            this.horizontalDivider1.TabIndex = 42;
            this.horizontalDivider1.Text = "Next Sector";
            // 
            // buttonJumpToSector
            // 
            this.buttonJumpToSector.Location = new System.Drawing.Point(24, 196);
            this.buttonJumpToSector.Name = "buttonJumpToSector";
            this.buttonJumpToSector.Size = new System.Drawing.Size(136, 24);
            this.buttonJumpToSector.TabIndex = 41;
            this.buttonJumpToSector.Text = "Jump to next linked Sector";
            this.buttonJumpToSector.UseVisualStyleBackColor = true;
            this.buttonJumpToSector.Click += new System.EventHandler(this.buttonJumpToSector_Click);
            // 
            // infoBoxSelectedTrack
            // 
            this.infoBoxSelectedTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSelectedTrack.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSelectedTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedTrack.Location = new System.Drawing.Point(75, 39);
            this.infoBoxSelectedTrack.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxSelectedTrack.Name = "infoBoxSelectedTrack";
            this.infoBoxSelectedTrack.Size = new System.Drawing.Size(100, 20);
            this.infoBoxSelectedTrack.TabIndex = 40;
            // 
            // infoBoxSelectedSector
            // 
            this.infoBoxSelectedSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSelectedSector.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSelectedSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedSector.Location = new System.Drawing.Point(75, 63);
            this.infoBoxSelectedSector.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxSelectedSector.Name = "infoBoxSelectedSector";
            this.infoBoxSelectedSector.Size = new System.Drawing.Size(100, 20);
            this.infoBoxSelectedSector.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(36, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Side";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(29, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Track";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(26, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Sector";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoBoxSelectedSide
            // 
            this.infoBoxSelectedSide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSelectedSide.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSelectedSide.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedSide.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSelectedSide.Location = new System.Drawing.Point(75, 16);
            this.infoBoxSelectedSide.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxSelectedSide.Name = "infoBoxSelectedSide";
            this.infoBoxSelectedSide.Size = new System.Drawing.Size(40, 19);
            this.infoBoxSelectedSide.TabIndex = 35;
            // 
            // infoBoxSectorDescription
            // 
            this.infoBoxSectorDescription.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSectorDescription.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSectorDescription.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorDescription.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorDescription.Location = new System.Drawing.Point(7, 106);
            this.infoBoxSectorDescription.Margin = new System.Windows.Forms.Padding(4);
            this.infoBoxSectorDescription.Name = "infoBoxSectorDescription";
            this.infoBoxSectorDescription.Size = new System.Drawing.Size(168, 31);
            this.infoBoxSectorDescription.TabIndex = 36;
            // 
            // groupFrame8
            // 
            this.groupFrame8.Controls.Add(this.trackBarTracks);
            this.groupFrame8.Controls.Add(this.buttonResetTrack);
            this.groupFrame8.Location = new System.Drawing.Point(733, 6);
            this.groupFrame8.Name = "groupFrame8";
            this.groupFrame8.Size = new System.Drawing.Size(70, 227);
            this.groupFrame8.TabIndex = 58;
            this.groupFrame8.TabStop = false;
            this.groupFrame8.Text = "Track";
            this.groupFrame8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // trackBarTracks
            // 
            this.trackBarTracks.Location = new System.Drawing.Point(13, 17);
            this.trackBarTracks.Name = "trackBarTracks";
            this.trackBarTracks.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTracks.Size = new System.Drawing.Size(45, 174);
            this.trackBarTracks.TabIndex = 0;
            this.trackBarTracks.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarTracks.ValueChanged += new System.EventHandler(this.trackBarTracks_ValueChanged);
            // 
            // buttonResetTrack
            // 
            this.buttonResetTrack.Location = new System.Drawing.Point(7, 196);
            this.buttonResetTrack.Name = "buttonResetTrack";
            this.buttonResetTrack.Size = new System.Drawing.Size(57, 24);
            this.buttonResetTrack.TabIndex = 7;
            this.buttonResetTrack.Text = "Reset";
            this.buttonResetTrack.UseVisualStyleBackColor = true;
            this.buttonResetTrack.Click += new System.EventHandler(this.buttonResetTrack_Click);
            // 
            // hexBox1
            // 
            this.hexBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hexBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.ForeColor = System.Drawing.Color.White;
            this.hexBox1.InfoForeColor = System.Drawing.Color.Teal;
            this.hexBox1.LineInfoPrefix = "$";
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.LineInfoWidth = 2;
            this.hexBox1.Location = new System.Drawing.Point(6, 6);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.SelectionBackColor = System.Drawing.Color.Red;
            this.hexBox1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(514, 227);
            this.hexBox1.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 65;
            this.hexBox1.UseFixedBytesPerLine = true;
            // 
            // tabPageDiskDirectory
            // 
            this.tabPageDiskDirectory.Controls.Add(this.buttonPrintSetup);
            this.tabPageDiskDirectory.Controls.Add(this.lvDirectory);
            this.tabPageDiskDirectory.Controls.Add(this.buttonPrintPreview);
            this.tabPageDiskDirectory.Controls.Add(this.checkBoxViewGroups);
            this.tabPageDiskDirectory.Controls.Add(this.buttonPrintDirectory);
            this.tabPageDiskDirectory.Location = new System.Drawing.Point(4, 22);
            this.tabPageDiskDirectory.Name = "tabPageDiskDirectory";
            this.tabPageDiskDirectory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiskDirectory.Size = new System.Drawing.Size(890, 242);
            this.tabPageDiskDirectory.TabIndex = 1;
            this.tabPageDiskDirectory.Text = "Disk Directory";
            this.tabPageDiskDirectory.UseVisualStyleBackColor = true;
            // 
            // buttonPrintSetup
            // 
            this.buttonPrintSetup.Image = global::OricExplorer.Properties.Resources.PrintSetupHS;
            this.buttonPrintSetup.Location = new System.Drawing.Point(782, 7);
            this.buttonPrintSetup.Name = "buttonPrintSetup";
            this.buttonPrintSetup.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintSetup.TabIndex = 5;
            this.buttonPrintSetup.Text = "Print Setup";
            this.buttonPrintSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintSetup.UseVisualStyleBackColor = true;
            this.buttonPrintSetup.Click += new System.EventHandler(this.buttonPrintSetup_Click);
            // 
            // lvDirectory
            // 
            this.lvDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDirectory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnFormat,
            this.columnSectors,
            this.columnSize,
            this.columnStart,
            this.columnEnd,
            this.columnExe,
            this.columnAutoRun,
            this.columnProtection});
            this.lvDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvDirectory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDirectory.FullRowSelect = true;
            this.lvDirectory.GridLines = true;
            listViewGroup41.Header = "BASIC Programs";
            listViewGroup41.Name = "listViewGroupBasic";
            listViewGroup42.Header = "Code/Data Files";
            listViewGroup42.Name = "listViewGroupCode";
            listViewGroup43.Header = "TEXT Screens";
            listViewGroup43.Name = "listViewGroupText";
            listViewGroup44.Header = "HIRES Screens";
            listViewGroup44.Name = "listViewGroupHires";
            listViewGroup45.Header = "Character Sets";
            listViewGroup45.Name = "listViewGroupCharSets";
            listViewGroup46.Header = "Text Windows";
            listViewGroup46.Name = "listViewGroupWindows";
            listViewGroup47.Header = "Sequential Data Files";
            listViewGroup47.Name = "listViewGroupSequential";
            listViewGroup48.Header = "Direct Access Files";
            listViewGroup48.Name = "listViewGroupDirectAccess";
            listViewGroup49.Header = "Other";
            listViewGroup49.Name = "listViewGroupOther";
            listViewGroup50.Header = "HELP Screens";
            listViewGroup50.Name = "listViewGroupHelpScreens";
            this.lvDirectory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup41,
            listViewGroup42,
            listViewGroup43,
            listViewGroup44,
            listViewGroup45,
            listViewGroup46,
            listViewGroup47,
            listViewGroup48,
            listViewGroup49,
            listViewGroup50});
            this.lvDirectory.HideSelection = false;
            this.lvDirectory.Location = new System.Drawing.Point(8, 36);
            this.lvDirectory.MultiSelect = false;
            this.lvDirectory.Name = "lvDirectory";
            this.lvDirectory.ShowItemToolTips = true;
            this.lvDirectory.Size = new System.Drawing.Size(874, 199);
            this.lvDirectory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDirectory.TabIndex = 1;
            this.lvDirectory.UseCompatibleStateImageBehavior = false;
            this.lvDirectory.View = System.Windows.Forms.View.Details;
            this.lvDirectory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDirectory_ColumnClick);
            this.lvDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDirectory_MouseClick);
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "Filename";
            this.columnFilename.Width = 136;
            // 
            // columnFormat
            // 
            this.columnFormat.Text = "Format";
            // 
            // columnSectors
            // 
            this.columnSectors.Text = "Sectors";
            this.columnSectors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnSectors.Width = 66;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Bytes";
            this.columnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnSize.Width = 97;
            // 
            // columnStart
            // 
            this.columnStart.Text = "Start";
            this.columnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnStart.Width = 73;
            // 
            // columnEnd
            // 
            this.columnEnd.Text = "End";
            this.columnEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnEnd.Width = 71;
            // 
            // columnExe
            // 
            this.columnExe.Text = "Exe";
            this.columnExe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnExe.Width = 68;
            // 
            // columnAutoRun
            // 
            this.columnAutoRun.Text = "Auto Run";
            this.columnAutoRun.Width = 77;
            // 
            // columnProtection
            // 
            this.columnProtection.Text = "Status";
            this.columnProtection.Width = 80;
            // 
            // buttonPrintPreview
            // 
            this.buttonPrintPreview.Image = global::OricExplorer.Properties.Resources.PrintPreviewHS;
            this.buttonPrintPreview.Location = new System.Drawing.Point(676, 7);
            this.buttonPrintPreview.Name = "buttonPrintPreview";
            this.buttonPrintPreview.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintPreview.TabIndex = 4;
            this.buttonPrintPreview.Text = "Print Preview";
            this.buttonPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintPreview.UseVisualStyleBackColor = true;
            this.buttonPrintPreview.Click += new System.EventHandler(this.buttonPrintPreview_Click);
            // 
            // checkBoxViewGroups
            // 
            this.checkBoxViewGroups.AutoSize = true;
            this.checkBoxViewGroups.Location = new System.Drawing.Point(13, 12);
            this.checkBoxViewGroups.Name = "checkBoxViewGroups";
            this.checkBoxViewGroups.Size = new System.Drawing.Size(86, 17);
            this.checkBoxViewGroups.TabIndex = 2;
            this.checkBoxViewGroups.Text = "View Groups";
            this.checkBoxViewGroups.UseVisualStyleBackColor = true;
            this.checkBoxViewGroups.CheckedChanged += new System.EventHandler(this.checkBoxViewGroups_CheckedChanged);
            // 
            // buttonPrintDirectory
            // 
            this.buttonPrintDirectory.Image = global::OricExplorer.Properties.Resources.PrintHS;
            this.buttonPrintDirectory.Location = new System.Drawing.Point(570, 7);
            this.buttonPrintDirectory.Name = "buttonPrintDirectory";
            this.buttonPrintDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintDirectory.TabIndex = 3;
            this.buttonPrintDirectory.Text = "Print Directory";
            this.buttonPrintDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintDirectory.UseVisualStyleBackColor = true;
            this.buttonPrintDirectory.Click += new System.EventHandler(this.buttonPrintDirectory_Click);
            // 
            // groupFrame4
            // 
            this.groupFrame4.Controls.Add(this.panel1);
            this.groupFrame4.Controls.Add(this.tabSides);
            this.groupFrame4.Location = new System.Drawing.Point(227, 9);
            this.groupFrame4.Name = "groupFrame4";
            this.groupFrame4.Size = new System.Drawing.Size(704, 290);
            this.groupFrame4.TabIndex = 56;
            this.groupFrame4.TabStop = false;
            this.groupFrame4.Text = "Sector Map";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.infoBoxSectorMapInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.infoBoxSectorMapSector);
            this.panel1.Controls.Add(this.infoBoxSectorMapTrack);
            this.panel1.Location = new System.Drawing.Point(12, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 36);
            this.panel1.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Track";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(125, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sector";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoBoxSectorMapInfo
            // 
            this.infoBoxSectorMapInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSectorMapInfo.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSectorMapInfo.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapInfo.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapInfo.Location = new System.Drawing.Point(332, 7);
            this.infoBoxSectorMapInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxSectorMapInfo.Name = "infoBoxSectorMapInfo";
            this.infoBoxSectorMapInfo.Size = new System.Drawing.Size(342, 20);
            this.infoBoxSectorMapInfo.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(255, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Sector Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // infoBoxSectorMapSector
            // 
            this.infoBoxSectorMapSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSectorMapSector.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSectorMapSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapSector.Location = new System.Drawing.Point(167, 7);
            this.infoBoxSectorMapSector.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxSectorMapSector.Name = "infoBoxSectorMapSector";
            this.infoBoxSectorMapSector.Size = new System.Drawing.Size(70, 20);
            this.infoBoxSectorMapSector.TabIndex = 31;
            // 
            // infoBoxSectorMapTrack
            // 
            this.infoBoxSectorMapTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSectorMapTrack.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSectorMapTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSectorMapTrack.Location = new System.Drawing.Point(43, 7);
            this.infoBoxSectorMapTrack.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxSectorMapTrack.Name = "infoBoxSectorMapTrack";
            this.infoBoxSectorMapTrack.Size = new System.Drawing.Size(70, 20);
            this.infoBoxSectorMapTrack.TabIndex = 30;
            // 
            // tabSides
            // 
            this.tabSides.Controls.Add(this.tabPageSide0);
            this.tabSides.Controls.Add(this.tabPageSide1);
            this.tabSides.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSides.Location = new System.Drawing.Point(8, 19);
            this.tabSides.Name = "tabSides";
            this.tabSides.SelectedIndex = 0;
            this.tabSides.Size = new System.Drawing.Size(688, 208);
            this.tabSides.TabIndex = 25;
            // 
            // tabPageSide0
            // 
            this.tabPageSide0.Controls.Add(this.pbSectorMapSide0);
            this.tabPageSide0.Location = new System.Drawing.Point(4, 22);
            this.tabPageSide0.Name = "tabPageSide0";
            this.tabPageSide0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSide0.Size = new System.Drawing.Size(680, 182);
            this.tabPageSide0.TabIndex = 0;
            this.tabPageSide0.Text = "Side 0";
            this.tabPageSide0.UseVisualStyleBackColor = true;
            // 
            // pbSectorMapSide0
            // 
            this.pbSectorMapSide0.BackColor = System.Drawing.Color.White;
            this.pbSectorMapSide0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSectorMapSide0.Location = new System.Drawing.Point(5, 6);
            this.pbSectorMapSide0.Name = "pbSectorMapSide0";
            this.pbSectorMapSide0.Size = new System.Drawing.Size(670, 170);
            this.pbSectorMapSide0.TabIndex = 0;
            this.pbSectorMapSide0.TabStop = false;
            this.pbSectorMapSide0.MouseLeave += new System.EventHandler(this.pbSectorMap_MouseLeave);
            this.pbSectorMapSide0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseMove);
            this.pbSectorMapSide0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseUp);
            // 
            // tabPageSide1
            // 
            this.tabPageSide1.Controls.Add(this.pbSectorMapSide1);
            this.tabPageSide1.Location = new System.Drawing.Point(4, 22);
            this.tabPageSide1.Name = "tabPageSide1";
            this.tabPageSide1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSide1.Size = new System.Drawing.Size(680, 182);
            this.tabPageSide1.TabIndex = 1;
            this.tabPageSide1.Text = "Side 1";
            this.tabPageSide1.UseVisualStyleBackColor = true;
            // 
            // pbSectorMapSide1
            // 
            this.pbSectorMapSide1.BackColor = System.Drawing.Color.White;
            this.pbSectorMapSide1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSectorMapSide1.Location = new System.Drawing.Point(5, 6);
            this.pbSectorMapSide1.Name = "pbSectorMapSide1";
            this.pbSectorMapSide1.Size = new System.Drawing.Size(670, 170);
            this.pbSectorMapSide1.TabIndex = 1;
            this.pbSectorMapSide1.TabStop = false;
            this.pbSectorMapSide1.MouseLeave += new System.EventHandler(this.pbSectorMap_MouseLeave);
            this.pbSectorMapSide1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseMove);
            this.pbSectorMapSide1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseUp);
            // 
            // groupFrame3
            // 
            this.groupFrame3.Controls.Add(this.percentageBar1);
            this.groupFrame3.Controls.Add(this.infoBoxUsage);
            this.groupFrame3.Location = new System.Drawing.Point(12, 176);
            this.groupFrame3.Name = "groupFrame3";
            this.groupFrame3.Size = new System.Drawing.Size(209, 123);
            this.groupFrame3.TabIndex = 55;
            this.groupFrame3.TabStop = false;
            this.groupFrame3.Text = "Usage";
            this.groupFrame3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // percentageBar1
            // 
            this.percentageBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.percentageBar1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentageBar1.Location = new System.Drawing.Point(9, 96);
            this.percentageBar1.Name = "percentageBar1";
            this.percentageBar1.PercentageBarColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.percentageBar1.Size = new System.Drawing.Size(190, 19);
            this.percentageBar1.TabIndex = 78;
            // 
            // infoBoxUsage
            // 
            this.infoBoxUsage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxUsage.ForeColor = System.Drawing.Color.Black;
            this.infoBoxUsage.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxUsage.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxUsage.Location = new System.Drawing.Point(9, 19);
            this.infoBoxUsage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxUsage.Name = "infoBoxUsage";
            this.infoBoxUsage.Size = new System.Drawing.Size(190, 73);
            this.infoBoxUsage.TabIndex = 60;
            // 
            // groupFrame2
            // 
            this.groupFrame2.Controls.Add(this.infoBoxStructure);
            this.groupFrame2.Location = new System.Drawing.Point(10, 93);
            this.groupFrame2.Name = "groupFrame2";
            this.groupFrame2.Size = new System.Drawing.Size(209, 77);
            this.groupFrame2.TabIndex = 54;
            this.groupFrame2.TabStop = false;
            this.groupFrame2.Text = "Structure";
            this.groupFrame2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // infoBoxStructure
            // 
            this.infoBoxStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxStructure.ForeColor = System.Drawing.Color.Black;
            this.infoBoxStructure.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStructure.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStructure.Location = new System.Drawing.Point(9, 19);
            this.infoBoxStructure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxStructure.Name = "infoBoxStructure";
            this.infoBoxStructure.Size = new System.Drawing.Size(190, 50);
            this.infoBoxStructure.TabIndex = 57;
            // 
            // groupFrame1
            // 
            this.groupFrame1.Controls.Add(this.infoBoxDiskName);
            this.groupFrame1.Controls.Add(this.infoBoxDiskType);
            this.groupFrame1.Controls.Add(this.infoBoxDOS);
            this.groupFrame1.Location = new System.Drawing.Point(10, 9);
            this.groupFrame1.Name = "groupFrame1";
            this.groupFrame1.Size = new System.Drawing.Size(209, 78);
            this.groupFrame1.TabIndex = 53;
            this.groupFrame1.TabStop = false;
            this.groupFrame1.Text = "Name & Format";
            this.groupFrame1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // infoBoxDiskName
            // 
            this.infoBoxDiskName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDiskName.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxDiskName.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDiskName.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDiskName.Location = new System.Drawing.Point(9, 19);
            this.infoBoxDiskName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxDiskName.Name = "infoBoxDiskName";
            this.infoBoxDiskName.Size = new System.Drawing.Size(190, 19);
            this.infoBoxDiskName.TabIndex = 53;
            // 
            // infoBoxDiskType
            // 
            this.infoBoxDiskType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDiskType.ForeColor = System.Drawing.Color.Black;
            this.infoBoxDiskType.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDiskType.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDiskType.Location = new System.Drawing.Point(9, 41);
            this.infoBoxDiskType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxDiskType.Name = "infoBoxDiskType";
            this.infoBoxDiskType.Size = new System.Drawing.Size(93, 30);
            this.infoBoxDiskType.TabIndex = 54;
            // 
            // infoBoxDOS
            // 
            this.infoBoxDOS.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDOS.ForeColor = System.Drawing.Color.Black;
            this.infoBoxDOS.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDOS.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDOS.Location = new System.Drawing.Point(106, 41);
            this.infoBoxDOS.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.infoBoxDOS.Name = "infoBoxDOS";
            this.infoBoxDOS.Size = new System.Drawing.Size(93, 30);
            this.infoBoxDOS.TabIndex = 55;
            // 
            // DiskInfoViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(939, 602);
            this.Controls.Add(this.groupFrame5);
            this.Controls.Add(this.groupFrame4);
            this.Controls.Add(this.groupFrame3);
            this.Controls.Add(this.groupFrame2);
            this.Controls.Add(this.groupFrame1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(707, 39);
            this.Name = "DiskInfoViewerControl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disk Information";
            this.Load += new System.EventHandler(this.SectorViewerControl_Load);
            this.groupFrame5.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupFrame9.ResumeLayout(false);
            this.groupFrame9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).EndInit();
            this.groupFrame6.ResumeLayout(false);
            this.groupFrame6.PerformLayout();
            this.groupFrame8.ResumeLayout(false);
            this.groupFrame8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).EndInit();
            this.tabPageDiskDirectory.ResumeLayout(false);
            this.tabPageDiskDirectory.PerformLayout();
            this.groupFrame4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabSides.ResumeLayout(false);
            this.tabPageSide0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide0)).EndInit();
            this.tabPageSide1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide1)).EndInit();
            this.groupFrame3.ResumeLayout(false);
            this.groupFrame2.ResumeLayout(false);
            this.groupFrame1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvDirectory;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnFormat;
        private System.Windows.Forms.ColumnHeader columnSectors;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnStart;
        private System.Windows.Forms.ColumnHeader columnEnd;
        private System.Windows.Forms.ColumnHeader columnExe;
        private System.Windows.Forms.ColumnHeader columnAutoRun;
        private System.Windows.Forms.ColumnHeader columnProtection;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabSides;
        private System.Windows.Forms.TabPage tabPageSide0;
        private System.Windows.Forms.PictureBox pbSectorMapSide0;
        private System.Windows.Forms.TabPage tabPageSide1;
        private System.Windows.Forms.PictureBox pbSectorMapSide1;
        private System.Windows.Forms.Button buttonPrintSetup;
        private System.Windows.Forms.Button buttonPrintPreview;
        private System.Windows.Forms.Button buttonPrintDirectory;
        private System.Windows.Forms.CheckBox checkBoxViewGroups;
        private System.Windows.Forms.TabPage tabPageDiskDirectory;
        private InfoBox.InfoBox infoBoxSectorDescription;
        private InfoBox.InfoBox infoBoxSelectedSide;
        private System.Windows.Forms.Label label1;
        private InfoBox.InfoBox infoBoxSectorMapSector;
        private InfoBox.InfoBox infoBoxSectorMapTrack;
        private InfoBox.InfoBox infoBoxSectorMapInfo;
        private InfoBox.InfoBox infoBoxUsage;
        private InfoBox.InfoBox infoBoxStructure;
        private InfoBox.InfoBox infoBoxDOS;
        private InfoBox.InfoBox infoBoxDiskType;
        private InfoBox.InfoBox infoBoxDiskName;
        private Be.Windows.Forms.HexBox hexBox1;
        private PercentageBar.PercentageBar percentageBar1;
        private GroupFrame.GroupFrame groupFrame1;
        private GroupFrame.GroupFrame groupFrame2;
        private GroupFrame.GroupFrame groupFrame3;
        private GroupFrame.GroupFrame groupFrame4;
        private GroupFrame.GroupFrame groupFrame5;
        private System.Windows.Forms.Panel panel1;
        private GroupFrame.GroupFrame groupFrame6;
        private InfoBox.InfoBox infoBoxSelectedSector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonResetSector;
        private System.Windows.Forms.Button buttonResetTrack;
        private GroupFrame.GroupFrame groupFrame9;
        private System.Windows.Forms.TrackBar trackBarSectors;
        private GroupFrame.GroupFrame groupFrame8;
        private System.Windows.Forms.TrackBar trackBarTracks;
        private System.Windows.Forms.Button buttonJumpToSector;
        private System.Windows.Forms.Label label4;
        private InfoBox.InfoBox infoBoxNextTrack;
        private InfoBox.InfoBox infoBoxNextSector;
        private InfoBox.InfoBox infoBoxNextSide;
        private HorizontalDivider.HorizontalDivider horizontalDivider1;
        private InfoBox.InfoBox infoBoxSelectedTrack;
        private System.Windows.Forms.Label label5;
    }
}