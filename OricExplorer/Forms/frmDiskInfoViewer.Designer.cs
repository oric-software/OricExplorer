using System.Drawing;

namespace OricExplorer.User_Controls    
{
    partial class frmDiskInfoViewer
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("BASIC Programs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Code/Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("TEXT Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("HIRES Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Character Sets", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Text Windows", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Sequential Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Direct Access Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("HELP Screens", System.Windows.Forms.HorizontalAlignment.Left);
            this.grpDiskView = new GroupFrame.GroupFrame();
            this.tabDiskView = new System.Windows.Forms.TabControl();
            this.tabpSectorData = new System.Windows.Forms.TabPage();
            this.grpSector = new GroupFrame.GroupFrame();
            this.btnResetSector = new System.Windows.Forms.Button();
            this.tkbSectors = new System.Windows.Forms.TrackBar();
            this.grpSectorInfo = new GroupFrame.GroupFrame();
            this.lblSectorDescription = new System.Windows.Forms.Label();
            this.ibxNextTrack = new InfoBox.InfoBox();
            this.ibxNextSector = new InfoBox.InfoBox();
            this.ibxNextSide = new InfoBox.InfoBox();
            this.hdvNextSector = new HorizontalDivider.HorizontalDivider();
            this.btnJumpToSector = new System.Windows.Forms.Button();
            this.ibxSelectedTrack = new InfoBox.InfoBox();
            this.ibxSelectedSector = new InfoBox.InfoBox();
            this.lblSelectedSide = new System.Windows.Forms.Label();
            this.lblSelectedTrack = new System.Windows.Forms.Label();
            this.lblSelectedSector = new System.Windows.Forms.Label();
            this.ibxSelectedSide = new InfoBox.InfoBox();
            this.ibxSectorDescription = new InfoBox.InfoBox();
            this.grpTrack = new GroupFrame.GroupFrame();
            this.tkbTracks = new System.Windows.Forms.TrackBar();
            this.btnResetTrack = new System.Windows.Forms.Button();
            this.hxbSectorData = new Be.Windows.Forms.HexBox();
            this.tabpDiskDirectory = new System.Windows.Forms.TabPage();
            this.btnPrintSetup = new System.Windows.Forms.Button();
            this.lvwDirectory = new System.Windows.Forms.ListView();
            this.colFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSectors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAutoRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProtection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.chkViewGroups = new System.Windows.Forms.CheckBox();
            this.btnPrintDirectory = new System.Windows.Forms.Button();
            this.grpSectorMap = new GroupFrame.GroupFrame();
            this.panSectorMap = new System.Windows.Forms.Panel();
            this.lblSectorMapTrack = new System.Windows.Forms.Label();
            this.lblSectorMapSector = new System.Windows.Forms.Label();
            this.ibxSectorMapInfo = new InfoBox.InfoBox();
            this.lblSectorMapInfo = new System.Windows.Forms.Label();
            this.ibxSectorMapSector = new InfoBox.InfoBox();
            this.ibxSectorMapTrack = new InfoBox.InfoBox();
            this.tabSides = new System.Windows.Forms.TabControl();
            this.tabpSide0 = new System.Windows.Forms.TabPage();
            this.picSectorMapSide0 = new System.Windows.Forms.PictureBox();
            this.tabpSide1 = new System.Windows.Forms.TabPage();
            this.picSectorMapSide1 = new System.Windows.Forms.PictureBox();
            this.grpUsage = new GroupFrame.GroupFrame();
            this.pbUsage = new PercentageBar.PercentageBar();
            this.ibxUsage = new InfoBox.InfoBox();
            this.grpStructure = new GroupFrame.GroupFrame();
            this.ibxStructure = new InfoBox.InfoBox();
            this.grpNameAndFormat = new GroupFrame.GroupFrame();
            this.ibxDiskName = new InfoBox.InfoBox();
            this.ibxDiskType = new InfoBox.InfoBox();
            this.ibxDOS = new InfoBox.InfoBox();
            this.grpDiskView.SuspendLayout();
            this.tabDiskView.SuspendLayout();
            this.tabpSectorData.SuspendLayout();
            this.grpSector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSectors)).BeginInit();
            this.grpSectorInfo.SuspendLayout();
            this.grpTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTracks)).BeginInit();
            this.tabpDiskDirectory.SuspendLayout();
            this.grpSectorMap.SuspendLayout();
            this.panSectorMap.SuspendLayout();
            this.tabSides.SuspendLayout();
            this.tabpSide0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSectorMapSide0)).BeginInit();
            this.tabpSide1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSectorMapSide1)).BeginInit();
            this.grpUsage.SuspendLayout();
            this.grpStructure.SuspendLayout();
            this.grpNameAndFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDiskView
            // 
            this.grpDiskView.Controls.Add(this.tabDiskView);
            this.grpDiskView.Location = new System.Drawing.Point(12, 305);
            this.grpDiskView.Name = "grpDiskView";
            this.grpDiskView.Size = new System.Drawing.Size(919, 288);
            this.grpDiskView.TabIndex = 4;
            this.grpDiskView.TabStop = false;
            // 
            // tabDiskView
            // 
            this.tabDiskView.Controls.Add(this.tabpSectorData);
            this.tabDiskView.Controls.Add(this.tabpDiskDirectory);
            this.tabDiskView.Location = new System.Drawing.Point(7, 12);
            this.tabDiskView.Name = "tabDiskView";
            this.tabDiskView.SelectedIndex = 0;
            this.tabDiskView.Size = new System.Drawing.Size(898, 268);
            this.tabDiskView.TabIndex = 0;
            // 
            // tabpSectorData
            // 
            this.tabpSectorData.BackColor = System.Drawing.SystemColors.Control;
            this.tabpSectorData.Controls.Add(this.grpSector);
            this.tabpSectorData.Controls.Add(this.grpSectorInfo);
            this.tabpSectorData.Controls.Add(this.grpTrack);
            this.tabpSectorData.Controls.Add(this.hxbSectorData);
            this.tabpSectorData.Location = new System.Drawing.Point(4, 22);
            this.tabpSectorData.Name = "tabpSectorData";
            this.tabpSectorData.Padding = new System.Windows.Forms.Padding(3);
            this.tabpSectorData.Size = new System.Drawing.Size(890, 242);
            this.tabpSectorData.TabIndex = 0;
            this.tabpSectorData.Text = "Sector Data";
            // 
            // grpSector
            // 
            this.grpSector.Controls.Add(this.btnResetSector);
            this.grpSector.Controls.Add(this.tkbSectors);
            this.grpSector.Location = new System.Drawing.Point(809, 6);
            this.grpSector.Name = "grpSector";
            this.grpSector.Size = new System.Drawing.Size(70, 227);
            this.grpSector.TabIndex = 3;
            this.grpSector.TabStop = false;
            this.grpSector.Text = "Sector";
            this.grpSector.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnResetSector
            // 
            this.btnResetSector.Location = new System.Drawing.Point(7, 196);
            this.btnResetSector.Name = "btnResetSector";
            this.btnResetSector.Size = new System.Drawing.Size(57, 24);
            this.btnResetSector.TabIndex = 1;
            this.btnResetSector.Text = "Reset";
            this.btnResetSector.UseVisualStyleBackColor = true;
            this.btnResetSector.Click += new System.EventHandler(this.btnResetSector_Click);
            // 
            // tkbSectors
            // 
            this.tkbSectors.Location = new System.Drawing.Point(13, 17);
            this.tkbSectors.Name = "tkbSectors";
            this.tkbSectors.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbSectors.Size = new System.Drawing.Size(45, 174);
            this.tkbSectors.TabIndex = 0;
            this.tkbSectors.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tkbSectors.ValueChanged += new System.EventHandler(this.tkbSectors_ValueChanged);
            // 
            // grpSectorInfo
            // 
            this.grpSectorInfo.Controls.Add(this.lblSectorDescription);
            this.grpSectorInfo.Controls.Add(this.ibxNextTrack);
            this.grpSectorInfo.Controls.Add(this.ibxNextSector);
            this.grpSectorInfo.Controls.Add(this.ibxNextSide);
            this.grpSectorInfo.Controls.Add(this.hdvNextSector);
            this.grpSectorInfo.Controls.Add(this.btnJumpToSector);
            this.grpSectorInfo.Controls.Add(this.ibxSelectedTrack);
            this.grpSectorInfo.Controls.Add(this.ibxSelectedSector);
            this.grpSectorInfo.Controls.Add(this.lblSelectedSide);
            this.grpSectorInfo.Controls.Add(this.lblSelectedTrack);
            this.grpSectorInfo.Controls.Add(this.lblSelectedSector);
            this.grpSectorInfo.Controls.Add(this.ibxSelectedSide);
            this.grpSectorInfo.Controls.Add(this.ibxSectorDescription);
            this.grpSectorInfo.Location = new System.Drawing.Point(529, 6);
            this.grpSectorInfo.Name = "grpSectorInfo";
            this.grpSectorInfo.Size = new System.Drawing.Size(184, 227);
            this.grpSectorInfo.TabIndex = 1;
            this.grpSectorInfo.TabStop = false;
            this.grpSectorInfo.Text = "Sector Info";
            this.grpSectorInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblSectorDescription
            // 
            this.lblSectorDescription.AutoSize = true;
            this.lblSectorDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblSectorDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSectorDescription.Location = new System.Drawing.Point(56, 89);
            this.lblSectorDescription.Name = "lblSectorDescription";
            this.lblSectorDescription.Size = new System.Drawing.Size(73, 13);
            this.lblSectorDescription.TabIndex = 6;
            this.lblSectorDescription.Text = "Sector Details";
            this.lblSectorDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibxNextTrack
            // 
            this.ibxNextTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxNextTrack.ForeColor = System.Drawing.Color.Blue;
            this.ibxNextTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextTrack.Location = new System.Drawing.Point(72, 165);
            this.ibxNextTrack.Margin = new System.Windows.Forms.Padding(4);
            this.ibxNextTrack.Name = "ibxNextTrack";
            this.ibxNextTrack.Size = new System.Drawing.Size(40, 20);
            this.ibxNextTrack.TabIndex = 10;
            // 
            // ibxNextSector
            // 
            this.ibxNextSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxNextSector.ForeColor = System.Drawing.Color.Blue;
            this.ibxNextSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextSector.Location = new System.Drawing.Point(120, 165);
            this.ibxNextSector.Margin = new System.Windows.Forms.Padding(4);
            this.ibxNextSector.Name = "ibxNextSector";
            this.ibxNextSector.Size = new System.Drawing.Size(40, 20);
            this.ibxNextSector.TabIndex = 11;
            // 
            // ibxNextSide
            // 
            this.ibxNextSide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxNextSide.ForeColor = System.Drawing.Color.Blue;
            this.ibxNextSide.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextSide.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxNextSide.Location = new System.Drawing.Point(24, 166);
            this.ibxNextSide.Margin = new System.Windows.Forms.Padding(4);
            this.ibxNextSide.Name = "ibxNextSide";
            this.ibxNextSide.Size = new System.Drawing.Size(40, 19);
            this.ibxNextSide.TabIndex = 9;
            // 
            // hdvNextSector
            // 
            this.hdvNextSector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hdvNextSector.Location = new System.Drawing.Point(0, 144);
            this.hdvNextSector.Name = "hdvNextSector";
            this.hdvNextSector.Size = new System.Drawing.Size(200, 15);
            this.hdvNextSector.TabIndex = 8;
            this.hdvNextSector.Text = "Next Sector";
            // 
            // btnJumpToSector
            // 
            this.btnJumpToSector.Location = new System.Drawing.Point(24, 196);
            this.btnJumpToSector.Name = "btnJumpToSector";
            this.btnJumpToSector.Size = new System.Drawing.Size(136, 24);
            this.btnJumpToSector.TabIndex = 12;
            this.btnJumpToSector.Text = "Jump to next linked Sector";
            this.btnJumpToSector.UseVisualStyleBackColor = true;
            this.btnJumpToSector.Click += new System.EventHandler(this.btnJumpToSector_Click);
            // 
            // ibxSelectedTrack
            // 
            this.ibxSelectedTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSelectedTrack.ForeColor = System.Drawing.Color.Black;
            this.ibxSelectedTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedTrack.Location = new System.Drawing.Point(75, 39);
            this.ibxSelectedTrack.Margin = new System.Windows.Forms.Padding(4);
            this.ibxSelectedTrack.Name = "ibxSelectedTrack";
            this.ibxSelectedTrack.Size = new System.Drawing.Size(100, 20);
            this.ibxSelectedTrack.TabIndex = 3;
            // 
            // ibxSelectedSector
            // 
            this.ibxSelectedSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSelectedSector.ForeColor = System.Drawing.Color.Black;
            this.ibxSelectedSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedSector.Location = new System.Drawing.Point(75, 63);
            this.ibxSelectedSector.Margin = new System.Windows.Forms.Padding(4);
            this.ibxSelectedSector.Name = "ibxSelectedSector";
            this.ibxSelectedSector.Size = new System.Drawing.Size(100, 20);
            this.ibxSelectedSector.TabIndex = 5;
            // 
            // lblSelectedSide
            // 
            this.lblSelectedSide.AutoSize = true;
            this.lblSelectedSide.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedSide.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSelectedSide.Location = new System.Drawing.Point(36, 19);
            this.lblSelectedSide.Name = "lblSelectedSide";
            this.lblSelectedSide.Size = new System.Drawing.Size(28, 13);
            this.lblSelectedSide.TabIndex = 0;
            this.lblSelectedSide.Text = "Side";
            this.lblSelectedSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedTrack
            // 
            this.lblSelectedTrack.AutoSize = true;
            this.lblSelectedTrack.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedTrack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSelectedTrack.Location = new System.Drawing.Point(29, 43);
            this.lblSelectedTrack.Name = "lblSelectedTrack";
            this.lblSelectedTrack.Size = new System.Drawing.Size(35, 13);
            this.lblSelectedTrack.TabIndex = 2;
            this.lblSelectedTrack.Text = "Track";
            this.lblSelectedTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedSector
            // 
            this.lblSelectedSector.AutoSize = true;
            this.lblSelectedSector.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedSector.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSelectedSector.Location = new System.Drawing.Point(26, 67);
            this.lblSelectedSector.Name = "lblSelectedSector";
            this.lblSelectedSector.Size = new System.Drawing.Size(38, 13);
            this.lblSelectedSector.TabIndex = 4;
            this.lblSelectedSector.Text = "Sector";
            this.lblSelectedSector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibxSelectedSide
            // 
            this.ibxSelectedSide.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSelectedSide.ForeColor = System.Drawing.Color.Black;
            this.ibxSelectedSide.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedSide.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSelectedSide.Location = new System.Drawing.Point(75, 16);
            this.ibxSelectedSide.Margin = new System.Windows.Forms.Padding(4);
            this.ibxSelectedSide.Name = "ibxSelectedSide";
            this.ibxSelectedSide.Size = new System.Drawing.Size(40, 19);
            this.ibxSelectedSide.TabIndex = 1;
            // 
            // ibxSectorDescription
            // 
            this.ibxSectorDescription.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSectorDescription.ForeColor = System.Drawing.Color.Black;
            this.ibxSectorDescription.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorDescription.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorDescription.Location = new System.Drawing.Point(7, 106);
            this.ibxSectorDescription.Margin = new System.Windows.Forms.Padding(4);
            this.ibxSectorDescription.Name = "ibxSectorDescription";
            this.ibxSectorDescription.Size = new System.Drawing.Size(168, 31);
            this.ibxSectorDescription.TabIndex = 7;
            // 
            // grpTrack
            // 
            this.grpTrack.Controls.Add(this.tkbTracks);
            this.grpTrack.Controls.Add(this.btnResetTrack);
            this.grpTrack.Location = new System.Drawing.Point(733, 6);
            this.grpTrack.Name = "grpTrack";
            this.grpTrack.Size = new System.Drawing.Size(70, 227);
            this.grpTrack.TabIndex = 2;
            this.grpTrack.TabStop = false;
            this.grpTrack.Text = "Track";
            this.grpTrack.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tkbTracks
            // 
            this.tkbTracks.Location = new System.Drawing.Point(13, 17);
            this.tkbTracks.Name = "tkbTracks";
            this.tkbTracks.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbTracks.Size = new System.Drawing.Size(45, 174);
            this.tkbTracks.TabIndex = 0;
            this.tkbTracks.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tkbTracks.ValueChanged += new System.EventHandler(this.tkbTracks_ValueChanged);
            // 
            // btnResetTrack
            // 
            this.btnResetTrack.Location = new System.Drawing.Point(7, 196);
            this.btnResetTrack.Name = "btnResetTrack";
            this.btnResetTrack.Size = new System.Drawing.Size(57, 24);
            this.btnResetTrack.TabIndex = 1;
            this.btnResetTrack.Text = "Reset";
            this.btnResetTrack.UseVisualStyleBackColor = true;
            this.btnResetTrack.Click += new System.EventHandler(this.btnResetTrack_Click);
            // 
            // hxbSectorData
            // 
            this.hxbSectorData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hxbSectorData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hxbSectorData.ColumnInfoVisible = true;
            this.hxbSectorData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hxbSectorData.ForeColor = System.Drawing.Color.White;
            this.hxbSectorData.InfoForeColor = System.Drawing.Color.Teal;
            this.hxbSectorData.LineInfoPrefix = "$";
            this.hxbSectorData.LineInfoVisible = true;
            this.hxbSectorData.LineInfoWidth = 2;
            this.hxbSectorData.Location = new System.Drawing.Point(6, 6);
            this.hxbSectorData.Name = "hxbSectorData";
            this.hxbSectorData.ReadOnly = true;
            this.hxbSectorData.SelectionBackColor = System.Drawing.Color.Red;
            this.hxbSectorData.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hxbSectorData.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxbSectorData.Size = new System.Drawing.Size(514, 227);
            this.hxbSectorData.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hxbSectorData.StringViewVisible = true;
            this.hxbSectorData.TabIndex = 0;
            this.hxbSectorData.UseFixedBytesPerLine = true;
            // 
            // tabpDiskDirectory
            // 
            this.tabpDiskDirectory.Controls.Add(this.btnPrintSetup);
            this.tabpDiskDirectory.Controls.Add(this.lvwDirectory);
            this.tabpDiskDirectory.Controls.Add(this.btnPrintPreview);
            this.tabpDiskDirectory.Controls.Add(this.chkViewGroups);
            this.tabpDiskDirectory.Controls.Add(this.btnPrintDirectory);
            this.tabpDiskDirectory.Location = new System.Drawing.Point(4, 22);
            this.tabpDiskDirectory.Name = "tabpDiskDirectory";
            this.tabpDiskDirectory.Padding = new System.Windows.Forms.Padding(3);
            this.tabpDiskDirectory.Size = new System.Drawing.Size(890, 242);
            this.tabpDiskDirectory.TabIndex = 1;
            this.tabpDiskDirectory.Text = "Disk Directory";
            this.tabpDiskDirectory.UseVisualStyleBackColor = true;
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.Image = global::OricExplorer.Properties.Resources.PrintSetupHS;
            this.btnPrintSetup.Location = new System.Drawing.Point(782, 7);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(100, 24);
            this.btnPrintSetup.TabIndex = 3;
            this.btnPrintSetup.Text = "Print Setup";
            this.btnPrintSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintSetup.UseVisualStyleBackColor = true;
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // lvwDirectory
            // 
            this.lvwDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDirectory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFilename,
            this.colFormat,
            this.colSectors,
            this.colSize,
            this.colStart,
            this.colEnd,
            this.colExe,
            this.colAutoRun,
            this.colProtection});
            this.lvwDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvwDirectory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDirectory.FullRowSelect = true;
            this.lvwDirectory.GridLines = true;
            listViewGroup1.Header = "BASIC Programs";
            listViewGroup1.Name = "listViewGroupBasic";
            listViewGroup2.Header = "Code/Data Files";
            listViewGroup2.Name = "listViewGroupCode";
            listViewGroup3.Header = "TEXT Screens";
            listViewGroup3.Name = "listViewGroupText";
            listViewGroup4.Header = "HIRES Screens";
            listViewGroup4.Name = "listViewGroupHires";
            listViewGroup5.Header = "Character Sets";
            listViewGroup5.Name = "listViewGroupCharSets";
            listViewGroup6.Header = "Text Windows";
            listViewGroup6.Name = "listViewGroupWindows";
            listViewGroup7.Header = "Sequential Data Files";
            listViewGroup7.Name = "listViewGroupSequential";
            listViewGroup8.Header = "Direct Access Files";
            listViewGroup8.Name = "listViewGroupDirectAccess";
            listViewGroup9.Header = "Other";
            listViewGroup9.Name = "listViewGroupOther";
            listViewGroup10.Header = "HELP Screens";
            listViewGroup10.Name = "listViewGroupHelpScreens";
            this.lvwDirectory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            this.lvwDirectory.HideSelection = false;
            this.lvwDirectory.Location = new System.Drawing.Point(8, 36);
            this.lvwDirectory.MultiSelect = false;
            this.lvwDirectory.Name = "lvwDirectory";
            this.lvwDirectory.ShowItemToolTips = true;
            this.lvwDirectory.Size = new System.Drawing.Size(874, 199);
            this.lvwDirectory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwDirectory.TabIndex = 4;
            this.lvwDirectory.UseCompatibleStateImageBehavior = false;
            this.lvwDirectory.View = System.Windows.Forms.View.Details;
            this.lvwDirectory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwDirectory_ColumnClick);
            this.lvwDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwDirectory_MouseClick);
            // 
            // colFilename
            // 
            this.colFilename.Text = "Filename";
            this.colFilename.Width = 136;
            // 
            // colFormat
            // 
            this.colFormat.Text = "Format";
            // 
            // colSectors
            // 
            this.colSectors.Text = "Sectors";
            this.colSectors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSectors.Width = 66;
            // 
            // colSize
            // 
            this.colSize.Text = "Bytes";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 97;
            // 
            // colStart
            // 
            this.colStart.Text = "Start";
            this.colStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colStart.Width = 73;
            // 
            // colEnd
            // 
            this.colEnd.Text = "End";
            this.colEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colEnd.Width = 71;
            // 
            // colExe
            // 
            this.colExe.Text = "Exe";
            this.colExe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colExe.Width = 68;
            // 
            // colAutoRun
            // 
            this.colAutoRun.Text = "Auto Run";
            this.colAutoRun.Width = 77;
            // 
            // colProtection
            // 
            this.colProtection.Text = "Status";
            this.colProtection.Width = 80;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::OricExplorer.Properties.Resources.PrintPreviewHS;
            this.btnPrintPreview.Location = new System.Drawing.Point(676, 7);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(100, 24);
            this.btnPrintPreview.TabIndex = 2;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // chkViewGroups
            // 
            this.chkViewGroups.AutoSize = true;
            this.chkViewGroups.Location = new System.Drawing.Point(13, 12);
            this.chkViewGroups.Name = "chkViewGroups";
            this.chkViewGroups.Size = new System.Drawing.Size(86, 17);
            this.chkViewGroups.TabIndex = 0;
            this.chkViewGroups.Text = "View Groups";
            this.chkViewGroups.UseVisualStyleBackColor = true;
            this.chkViewGroups.CheckedChanged += new System.EventHandler(this.chkViewGroups_CheckedChanged);
            // 
            // btnPrintDirectory
            // 
            this.btnPrintDirectory.Image = global::OricExplorer.Properties.Resources.PrintHS;
            this.btnPrintDirectory.Location = new System.Drawing.Point(570, 7);
            this.btnPrintDirectory.Name = "btnPrintDirectory";
            this.btnPrintDirectory.Size = new System.Drawing.Size(100, 24);
            this.btnPrintDirectory.TabIndex = 1;
            this.btnPrintDirectory.Text = "Print Directory";
            this.btnPrintDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintDirectory.UseVisualStyleBackColor = true;
            this.btnPrintDirectory.Click += new System.EventHandler(this.btnPrintDirectory_Click);
            // 
            // grpSectorMap
            // 
            this.grpSectorMap.Controls.Add(this.panSectorMap);
            this.grpSectorMap.Controls.Add(this.tabSides);
            this.grpSectorMap.Location = new System.Drawing.Point(227, 9);
            this.grpSectorMap.Name = "grpSectorMap";
            this.grpSectorMap.Size = new System.Drawing.Size(704, 290);
            this.grpSectorMap.TabIndex = 3;
            this.grpSectorMap.TabStop = false;
            this.grpSectorMap.Text = "Sector Map";
            // 
            // panSectorMap
            // 
            this.panSectorMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSectorMap.Controls.Add(this.lblSectorMapTrack);
            this.panSectorMap.Controls.Add(this.lblSectorMapSector);
            this.panSectorMap.Controls.Add(this.ibxSectorMapInfo);
            this.panSectorMap.Controls.Add(this.lblSectorMapInfo);
            this.panSectorMap.Controls.Add(this.ibxSectorMapSector);
            this.panSectorMap.Controls.Add(this.ibxSectorMapTrack);
            this.panSectorMap.Location = new System.Drawing.Point(12, 238);
            this.panSectorMap.Name = "panSectorMap";
            this.panSectorMap.Size = new System.Drawing.Size(680, 36);
            this.panSectorMap.TabIndex = 1;
            // 
            // lblSectorMapTrack
            // 
            this.lblSectorMapTrack.AutoSize = true;
            this.lblSectorMapTrack.BackColor = System.Drawing.Color.Transparent;
            this.lblSectorMapTrack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSectorMapTrack.Location = new System.Drawing.Point(4, 11);
            this.lblSectorMapTrack.Name = "lblSectorMapTrack";
            this.lblSectorMapTrack.Size = new System.Drawing.Size(35, 13);
            this.lblSectorMapTrack.TabIndex = 0;
            this.lblSectorMapTrack.Text = "Track";
            this.lblSectorMapTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSectorMapSector
            // 
            this.lblSectorMapSector.AutoSize = true;
            this.lblSectorMapSector.BackColor = System.Drawing.Color.Transparent;
            this.lblSectorMapSector.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSectorMapSector.Location = new System.Drawing.Point(125, 11);
            this.lblSectorMapSector.Name = "lblSectorMapSector";
            this.lblSectorMapSector.Size = new System.Drawing.Size(38, 13);
            this.lblSectorMapSector.TabIndex = 2;
            this.lblSectorMapSector.Text = "Sector";
            this.lblSectorMapSector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibxSectorMapInfo
            // 
            this.ibxSectorMapInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSectorMapInfo.ForeColor = System.Drawing.Color.Black;
            this.ibxSectorMapInfo.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapInfo.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapInfo.Location = new System.Drawing.Point(332, 7);
            this.ibxSectorMapInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxSectorMapInfo.Name = "ibxSectorMapInfo";
            this.ibxSectorMapInfo.Size = new System.Drawing.Size(342, 20);
            this.ibxSectorMapInfo.TabIndex = 5;
            // 
            // lblSectorMapInfo
            // 
            this.lblSectorMapInfo.AutoSize = true;
            this.lblSectorMapInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSectorMapInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSectorMapInfo.Location = new System.Drawing.Point(255, 11);
            this.lblSectorMapInfo.Name = "lblSectorMapInfo";
            this.lblSectorMapInfo.Size = new System.Drawing.Size(73, 13);
            this.lblSectorMapInfo.TabIndex = 4;
            this.lblSectorMapInfo.Text = "Sector Details";
            this.lblSectorMapInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ibxSectorMapSector
            // 
            this.ibxSectorMapSector.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSectorMapSector.ForeColor = System.Drawing.Color.Black;
            this.ibxSectorMapSector.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapSector.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapSector.Location = new System.Drawing.Point(167, 7);
            this.ibxSectorMapSector.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxSectorMapSector.Name = "ibxSectorMapSector";
            this.ibxSectorMapSector.Size = new System.Drawing.Size(70, 20);
            this.ibxSectorMapSector.TabIndex = 3;
            // 
            // ibxSectorMapTrack
            // 
            this.ibxSectorMapTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSectorMapTrack.ForeColor = System.Drawing.Color.Black;
            this.ibxSectorMapTrack.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapTrack.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSectorMapTrack.Location = new System.Drawing.Point(43, 7);
            this.ibxSectorMapTrack.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxSectorMapTrack.Name = "ibxSectorMapTrack";
            this.ibxSectorMapTrack.Size = new System.Drawing.Size(70, 20);
            this.ibxSectorMapTrack.TabIndex = 1;
            // 
            // tabSides
            // 
            this.tabSides.Controls.Add(this.tabpSide0);
            this.tabSides.Controls.Add(this.tabpSide1);
            this.tabSides.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSides.Location = new System.Drawing.Point(8, 19);
            this.tabSides.Name = "tabSides";
            this.tabSides.SelectedIndex = 0;
            this.tabSides.Size = new System.Drawing.Size(688, 208);
            this.tabSides.TabIndex = 0;
            // 
            // tabpSide0
            // 
            this.tabpSide0.Controls.Add(this.picSectorMapSide0);
            this.tabpSide0.Location = new System.Drawing.Point(4, 22);
            this.tabpSide0.Name = "tabpSide0";
            this.tabpSide0.Padding = new System.Windows.Forms.Padding(3);
            this.tabpSide0.Size = new System.Drawing.Size(680, 182);
            this.tabpSide0.TabIndex = 0;
            this.tabpSide0.Text = "Side 0";
            this.tabpSide0.UseVisualStyleBackColor = true;
            // 
            // picSectorMapSide0
            // 
            this.picSectorMapSide0.BackColor = System.Drawing.Color.White;
            this.picSectorMapSide0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSectorMapSide0.Location = new System.Drawing.Point(5, 6);
            this.picSectorMapSide0.Name = "picSectorMapSide0";
            this.picSectorMapSide0.Size = new System.Drawing.Size(670, 170);
            this.picSectorMapSide0.TabIndex = 0;
            this.picSectorMapSide0.TabStop = false;
            this.picSectorMapSide0.MouseLeave += new System.EventHandler(this.picSectorMap_MouseLeave);
            this.picSectorMapSide0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSectorMap_MouseMove);
            this.picSectorMapSide0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSectorMap_MouseUp);
            // 
            // tabpSide1
            // 
            this.tabpSide1.Controls.Add(this.picSectorMapSide1);
            this.tabpSide1.Location = new System.Drawing.Point(4, 22);
            this.tabpSide1.Name = "tabpSide1";
            this.tabpSide1.Padding = new System.Windows.Forms.Padding(3);
            this.tabpSide1.Size = new System.Drawing.Size(680, 182);
            this.tabpSide1.TabIndex = 1;
            this.tabpSide1.Text = "Side 1";
            this.tabpSide1.UseVisualStyleBackColor = true;
            // 
            // picSectorMapSide1
            // 
            this.picSectorMapSide1.BackColor = System.Drawing.Color.White;
            this.picSectorMapSide1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSectorMapSide1.Location = new System.Drawing.Point(5, 6);
            this.picSectorMapSide1.Name = "picSectorMapSide1";
            this.picSectorMapSide1.Size = new System.Drawing.Size(670, 170);
            this.picSectorMapSide1.TabIndex = 1;
            this.picSectorMapSide1.TabStop = false;
            this.picSectorMapSide1.MouseLeave += new System.EventHandler(this.picSectorMap_MouseLeave);
            this.picSectorMapSide1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSectorMap_MouseMove);
            this.picSectorMapSide1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSectorMap_MouseUp);
            // 
            // grpUsage
            // 
            this.grpUsage.Controls.Add(this.pbUsage);
            this.grpUsage.Controls.Add(this.ibxUsage);
            this.grpUsage.Location = new System.Drawing.Point(12, 176);
            this.grpUsage.Name = "grpUsage";
            this.grpUsage.Size = new System.Drawing.Size(209, 123);
            this.grpUsage.TabIndex = 2;
            this.grpUsage.TabStop = false;
            this.grpUsage.Text = "Usage";
            this.grpUsage.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pbUsage
            // 
            this.pbUsage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.pbUsage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbUsage.Location = new System.Drawing.Point(9, 96);
            this.pbUsage.Name = "pbUsage";
            this.pbUsage.PercentageBarColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pbUsage.Size = new System.Drawing.Size(190, 19);
            this.pbUsage.TabIndex = 1;
            // 
            // ibxUsage
            // 
            this.ibxUsage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxUsage.ForeColor = System.Drawing.Color.Black;
            this.ibxUsage.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxUsage.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxUsage.Location = new System.Drawing.Point(9, 19);
            this.ibxUsage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxUsage.Name = "ibxUsage";
            this.ibxUsage.Size = new System.Drawing.Size(190, 73);
            this.ibxUsage.TabIndex = 0;
            // 
            // grpStructure
            // 
            this.grpStructure.Controls.Add(this.ibxStructure);
            this.grpStructure.Location = new System.Drawing.Point(10, 93);
            this.grpStructure.Name = "grpStructure";
            this.grpStructure.Size = new System.Drawing.Size(209, 77);
            this.grpStructure.TabIndex = 1;
            this.grpStructure.TabStop = false;
            this.grpStructure.Text = "Structure";
            this.grpStructure.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ibxStructure
            // 
            this.ibxStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxStructure.ForeColor = System.Drawing.Color.Black;
            this.ibxStructure.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStructure.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStructure.Location = new System.Drawing.Point(9, 19);
            this.ibxStructure.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxStructure.Name = "ibxStructure";
            this.ibxStructure.Size = new System.Drawing.Size(190, 50);
            this.ibxStructure.TabIndex = 0;
            // 
            // grpNameAndFormat
            // 
            this.grpNameAndFormat.Controls.Add(this.ibxDiskName);
            this.grpNameAndFormat.Controls.Add(this.ibxDiskType);
            this.grpNameAndFormat.Controls.Add(this.ibxDOS);
            this.grpNameAndFormat.Location = new System.Drawing.Point(10, 9);
            this.grpNameAndFormat.Name = "grpNameAndFormat";
            this.grpNameAndFormat.Size = new System.Drawing.Size(209, 78);
            this.grpNameAndFormat.TabIndex = 0;
            this.grpNameAndFormat.TabStop = false;
            this.grpNameAndFormat.Text = "Name & Format";
            this.grpNameAndFormat.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ibxDiskName
            // 
            this.ibxDiskName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDiskName.ForeColor = System.Drawing.Color.Maroon;
            this.ibxDiskName.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDiskName.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDiskName.Location = new System.Drawing.Point(9, 19);
            this.ibxDiskName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxDiskName.Name = "ibxDiskName";
            this.ibxDiskName.Size = new System.Drawing.Size(190, 19);
            this.ibxDiskName.TabIndex = 0;
            // 
            // ibxDiskType
            // 
            this.ibxDiskType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDiskType.ForeColor = System.Drawing.Color.Black;
            this.ibxDiskType.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDiskType.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDiskType.Location = new System.Drawing.Point(9, 41);
            this.ibxDiskType.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxDiskType.Name = "ibxDiskType";
            this.ibxDiskType.Size = new System.Drawing.Size(93, 30);
            this.ibxDiskType.TabIndex = 1;
            // 
            // ibxDOS
            // 
            this.ibxDOS.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDOS.ForeColor = System.Drawing.Color.Black;
            this.ibxDOS.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDOS.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDOS.Location = new System.Drawing.Point(106, 41);
            this.ibxDOS.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ibxDOS.Name = "ibxDOS";
            this.ibxDOS.Size = new System.Drawing.Size(93, 30);
            this.ibxDOS.TabIndex = 2;
            // 
            // frmDiskInfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(939, 602);
            this.Controls.Add(this.grpDiskView);
            this.Controls.Add(this.grpSectorMap);
            this.Controls.Add(this.grpUsage);
            this.Controls.Add(this.grpStructure);
            this.Controls.Add(this.grpNameAndFormat);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(707, 39);
            this.Name = "frmDiskInfoViewer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disk Information";
            this.Load += new System.EventHandler(this.frmDiskInfoViewer_Load);
            this.grpDiskView.ResumeLayout(false);
            this.tabDiskView.ResumeLayout(false);
            this.tabpSectorData.ResumeLayout(false);
            this.grpSector.ResumeLayout(false);
            this.grpSector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSectors)).EndInit();
            this.grpSectorInfo.ResumeLayout(false);
            this.grpSectorInfo.PerformLayout();
            this.grpTrack.ResumeLayout(false);
            this.grpTrack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTracks)).EndInit();
            this.tabpDiskDirectory.ResumeLayout(false);
            this.tabpDiskDirectory.PerformLayout();
            this.grpSectorMap.ResumeLayout(false);
            this.panSectorMap.ResumeLayout(false);
            this.panSectorMap.PerformLayout();
            this.tabSides.ResumeLayout(false);
            this.tabpSide0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSectorMapSide0)).EndInit();
            this.tabpSide1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSectorMapSide1)).EndInit();
            this.grpUsage.ResumeLayout(false);
            this.grpStructure.ResumeLayout(false);
            this.grpNameAndFormat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvwDirectory;
        private System.Windows.Forms.ColumnHeader colFilename;
        private System.Windows.Forms.ColumnHeader colFormat;
        private System.Windows.Forms.ColumnHeader colSectors;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.ColumnHeader colExe;
        private System.Windows.Forms.ColumnHeader colAutoRun;
        private System.Windows.Forms.ColumnHeader colProtection;
        private System.Windows.Forms.TabControl tabDiskView;
        private System.Windows.Forms.TabPage tabpSectorData;
        private System.Windows.Forms.TabControl tabSides;
        private System.Windows.Forms.TabPage tabpSide0;
        private System.Windows.Forms.PictureBox picSectorMapSide0;
        private System.Windows.Forms.TabPage tabpSide1;
        private System.Windows.Forms.PictureBox picSectorMapSide1;
        private System.Windows.Forms.Button btnPrintSetup;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnPrintDirectory;
        private System.Windows.Forms.CheckBox chkViewGroups;
        private System.Windows.Forms.TabPage tabpDiskDirectory;
        private InfoBox.InfoBox ibxSectorDescription;
        private InfoBox.InfoBox ibxSelectedSide;
        private System.Windows.Forms.Label lblSectorMapInfo;
        private InfoBox.InfoBox ibxSectorMapSector;
        private InfoBox.InfoBox ibxSectorMapTrack;
        private InfoBox.InfoBox ibxSectorMapInfo;
        private InfoBox.InfoBox ibxUsage;
        private InfoBox.InfoBox ibxStructure;
        private InfoBox.InfoBox ibxDOS;
        private InfoBox.InfoBox ibxDiskType;
        private InfoBox.InfoBox ibxDiskName;
        private Be.Windows.Forms.HexBox hxbSectorData;
        private PercentageBar.PercentageBar pbUsage;
        private GroupFrame.GroupFrame grpNameAndFormat;
        private GroupFrame.GroupFrame grpStructure;
        private GroupFrame.GroupFrame grpUsage;
        private GroupFrame.GroupFrame grpSectorMap;
        private GroupFrame.GroupFrame grpDiskView;
        private System.Windows.Forms.Panel panSectorMap;
        private GroupFrame.GroupFrame grpSectorInfo;
        private InfoBox.InfoBox ibxSelectedSector;
        private System.Windows.Forms.Label lblSelectedSide;
        private System.Windows.Forms.Label lblSelectedSector;
        private System.Windows.Forms.Label lblSectorMapTrack;
        private System.Windows.Forms.Label lblSectorMapSector;
        private System.Windows.Forms.Button btnResetSector;
        private System.Windows.Forms.Button btnResetTrack;
        private GroupFrame.GroupFrame grpSector;
        private System.Windows.Forms.TrackBar tkbSectors;
        private GroupFrame.GroupFrame grpTrack;
        private System.Windows.Forms.TrackBar tkbTracks;
        private System.Windows.Forms.Button btnJumpToSector;
        private System.Windows.Forms.Label lblSectorDescription;
        private InfoBox.InfoBox ibxNextTrack;
        private InfoBox.InfoBox ibxNextSector;
        private InfoBox.InfoBox ibxNextSide;
        private HorizontalDivider.HorizontalDivider hdvNextSector;
        private InfoBox.InfoBox ibxSelectedTrack;
        private System.Windows.Forms.Label lblSelectedTrack;
    }
}