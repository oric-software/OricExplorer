namespace OricExplorer.Forms
{
    partial class frmScreenViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenViewer));
            this.picScreenImage = new System.Windows.Forms.PictureBox();
            this.ibxImageFormat = new InfoBox.InfoBox();
            this.tkbSpeed = new System.Windows.Forms.TrackBar();
            this.grpSlideshowControls = new System.Windows.Forms.GroupBox();
            this.ibxSlideshowStatus = new InfoBox.InfoBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblSlideshowStatus = new System.Windows.Forms.Label();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnFirstImage = new System.Windows.Forms.Button();
            this.btnPrevImage = new System.Windows.Forms.Button();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnLastImage = new System.Windows.Forms.Button();
            this.grpScreenInformation = new System.Windows.Forms.GroupBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.ibxDimensions = new InfoBox.InfoBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.ibxLength = new InfoBox.InfoBox();
            this.lblEndAddress = new System.Windows.Forms.Label();
            this.ibxEndAddress = new InfoBox.InfoBox();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.ibxStartAddress = new InfoBox.InfoBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.ibxFormat = new InfoBox.InfoBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.ibxFilename = new InfoBox.InfoBox();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.btnSaveScreen = new System.Windows.Forms.Button();
            this.lblImageFormat = new System.Windows.Forms.Label();
            this.tlpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.optShowHiresOnly = new System.Windows.Forms.RadioButton();
            this.optShowTextOnly = new System.Windows.Forms.RadioButton();
            this.optShowBoth = new System.Windows.Forms.RadioButton();
            this.grpFormatFilter = new System.Windows.Forms.GroupBox();
            this.ibxImageCount = new InfoBox.InfoBox();
            this.panScreenImage = new System.Windows.Forms.Panel();
            this.grpViewerControls = new System.Windows.Forms.GroupBox();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.ibxImageCounter = new InfoBox.InfoBox();
            this.flpThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabpViewerControls = new System.Windows.Forms.TabPage();
            this.tabpSlideshowControls = new System.Windows.Forms.TabPage();
            this.prtDocument = new System.Drawing.Printing.PrintDocument();
            this.grpActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSpeed)).BeginInit();
            this.grpSlideshowControls.SuspendLayout();
            this.grpScreenInformation.SuspendLayout();
            this.grpFormatFilter.SuspendLayout();
            this.panScreenImage.SuspendLayout();
            this.grpViewerControls.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.tabpViewerControls.SuspendLayout();
            this.tabpSlideshowControls.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // picScreenImage
            // 
            this.picScreenImage.BackColor = System.Drawing.Color.Black;
            this.picScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScreenImage.Location = new System.Drawing.Point(7, 6);
            this.picScreenImage.Name = "picScreenImage";
            this.picScreenImage.Size = new System.Drawing.Size(480, 448);
            this.picScreenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picScreenImage.TabIndex = 54;
            this.picScreenImage.TabStop = false;
            // 
            // ibxImageFormat
            // 
            this.ibxImageFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxImageFormat.ForeColor = System.Drawing.Color.Green;
            this.ibxImageFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageFormat.Location = new System.Drawing.Point(89, 19);
            this.ibxImageFormat.Name = "ibxImageFormat";
            this.ibxImageFormat.Size = new System.Drawing.Size(136, 19);
            this.ibxImageFormat.TabIndex = 1;
            // 
            // tkbSpeed
            // 
            this.tkbSpeed.LargeChange = 2;
            this.tkbSpeed.Location = new System.Drawing.Point(89, 76);
            this.tkbSpeed.Minimum = 1;
            this.tkbSpeed.Name = "tkbSpeed";
            this.tkbSpeed.Size = new System.Drawing.Size(134, 45);
            this.tkbSpeed.TabIndex = 8;
            this.tkbSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tlpToolTip.SetToolTip(this.tkbSpeed, "Adjust interval between images");
            this.tkbSpeed.Value = 1;
            this.tkbSpeed.ValueChanged += new System.EventHandler(this.tkbSpeed_ValueChanged);
            // 
            // grpSlideshowControls
            // 
            this.grpSlideshowControls.Controls.Add(this.ibxSlideshowStatus);
            this.grpSlideshowControls.Controls.Add(this.lblSpeed);
            this.grpSlideshowControls.Controls.Add(this.lblSlideshowStatus);
            this.grpSlideshowControls.Controls.Add(this.tkbSpeed);
            this.grpSlideshowControls.Controls.Add(this.chkLoop);
            this.grpSlideshowControls.Controls.Add(this.btnStop);
            this.grpSlideshowControls.Controls.Add(this.btnPause);
            this.grpSlideshowControls.Controls.Add(this.btnPlay);
            this.grpSlideshowControls.Location = new System.Drawing.Point(8, 1);
            this.grpSlideshowControls.Name = "grpSlideshowControls";
            this.grpSlideshowControls.Size = new System.Drawing.Size(233, 123);
            this.grpSlideshowControls.TabIndex = 0;
            this.grpSlideshowControls.TabStop = false;
            // 
            // ibxSlideshowStatus
            // 
            this.ibxSlideshowStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSlideshowStatus.ForeColor = System.Drawing.Color.Blue;
            this.ibxSlideshowStatus.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSlideshowStatus.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxSlideshowStatus.Location = new System.Drawing.Point(89, 22);
            this.ibxSlideshowStatus.Name = "ibxSlideshowStatus";
            this.ibxSlideshowStatus.Size = new System.Drawing.Size(136, 19);
            this.ibxSlideshowStatus.TabIndex = 2;
            // 
            // lblSpeed
            // 
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSpeed.Location = new System.Drawing.Point(4, 76);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(79, 45);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "Interval\r\n( 2 secs)";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlideshowStatus
            // 
            this.lblSlideshowStatus.AutoSize = true;
            this.lblSlideshowStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSlideshowStatus.Location = new System.Drawing.Point(40, 25);
            this.lblSlideshowStatus.Name = "lblSlideshowStatus";
            this.lblSlideshowStatus.Size = new System.Drawing.Size(43, 13);
            this.lblSlideshowStatus.TabIndex = 1;
            this.lblSlideshowStatus.Text = "Status :";
            // 
            // chkLoop
            // 
            this.chkLoop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLoop.Image = global::OricExplorer.Properties.Resources.control_repeat_blue;
            this.chkLoop.Location = new System.Drawing.Point(200, 47);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(23, 23);
            this.chkLoop.TabIndex = 6;
            this.tlpToolTip.SetToolTip(this.chkLoop, "Enable/Disable looping");
            this.chkLoop.UseVisualStyleBackColor = true;
            this.chkLoop.CheckedChanged += new System.EventHandler(this.chkLoop_CheckedChanged);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::OricExplorer.Properties.Resources.control_stop_blue;
            this.btnStop.Location = new System.Drawing.Point(163, 47);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 23);
            this.btnStop.TabIndex = 5;
            this.tlpToolTip.SetToolTip(this.btnStop, "Stop slideshow");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::OricExplorer.Properties.Resources.control_pause_blue;
            this.btnPause.Location = new System.Drawing.Point(126, 47);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(23, 23);
            this.btnPause.TabIndex = 4;
            this.tlpToolTip.SetToolTip(this.btnPause, "Pause slideshow");
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::OricExplorer.Properties.Resources.control_play_blue;
            this.btnPlay.Location = new System.Drawing.Point(89, 47);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 23);
            this.btnPlay.TabIndex = 3;
            this.tlpToolTip.SetToolTip(this.btnPlay, "Start slideshow");
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnFirstImage
            // 
            this.btnFirstImage.Image = global::OricExplorer.Properties.Resources.control_start_blue;
            this.btnFirstImage.Location = new System.Drawing.Point(89, 69);
            this.btnFirstImage.Name = "btnFirstImage";
            this.btnFirstImage.Size = new System.Drawing.Size(23, 23);
            this.btnFirstImage.TabIndex = 4;
            this.tlpToolTip.SetToolTip(this.btnFirstImage, "Show first image");
            this.btnFirstImage.UseVisualStyleBackColor = true;
            this.btnFirstImage.Click += new System.EventHandler(this.btnFirstImage_Click);
            // 
            // btnPrevImage
            // 
            this.btnPrevImage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevImage.Image")));
            this.btnPrevImage.Location = new System.Drawing.Point(126, 69);
            this.btnPrevImage.Name = "btnPrevImage";
            this.btnPrevImage.Size = new System.Drawing.Size(23, 23);
            this.btnPrevImage.TabIndex = 5;
            this.tlpToolTip.SetToolTip(this.btnPrevImage, "Show previous image");
            this.btnPrevImage.UseVisualStyleBackColor = true;
            this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
            // 
            // btnNextImage
            // 
            this.btnNextImage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextImage.Image")));
            this.btnNextImage.Location = new System.Drawing.Point(163, 69);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(23, 23);
            this.btnNextImage.TabIndex = 6;
            this.tlpToolTip.SetToolTip(this.btnNextImage, "Show next image");
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // btnLastImage
            // 
            this.btnLastImage.Image = global::OricExplorer.Properties.Resources.control_end_blue;
            this.btnLastImage.Location = new System.Drawing.Point(200, 69);
            this.btnLastImage.Name = "btnLastImage";
            this.btnLastImage.Size = new System.Drawing.Size(23, 23);
            this.btnLastImage.TabIndex = 7;
            this.tlpToolTip.SetToolTip(this.btnLastImage, "Show last image");
            this.btnLastImage.UseVisualStyleBackColor = true;
            this.btnLastImage.Click += new System.EventHandler(this.btnLastImage_Click);
            // 
            // grpScreenInformation
            // 
            this.grpScreenInformation.Controls.Add(this.lblDimensions);
            this.grpScreenInformation.Controls.Add(this.ibxDimensions);
            this.grpScreenInformation.Controls.Add(this.lblLength);
            this.grpScreenInformation.Controls.Add(this.ibxLength);
            this.grpScreenInformation.Controls.Add(this.lblEndAddress);
            this.grpScreenInformation.Controls.Add(this.ibxEndAddress);
            this.grpScreenInformation.Controls.Add(this.lblStartAddress);
            this.grpScreenInformation.Controls.Add(this.ibxStartAddress);
            this.grpScreenInformation.Controls.Add(this.lblFilename);
            this.grpScreenInformation.Controls.Add(this.ibxFormat);
            this.grpScreenInformation.Controls.Add(this.lblFormat);
            this.grpScreenInformation.Controls.Add(this.ibxFilename);
            this.grpScreenInformation.Location = new System.Drawing.Point(519, 94);
            this.grpScreenInformation.Name = "grpScreenInformation";
            this.grpScreenInformation.Size = new System.Drawing.Size(253, 170);
            this.grpScreenInformation.TabIndex = 3;
            this.grpScreenInformation.TabStop = false;
            this.grpScreenInformation.Text = "Screen Information";
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDimensions.Location = new System.Drawing.Point(17, 144);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(67, 13);
            this.lblDimensions.TabIndex = 10;
            this.lblDimensions.Text = "Dimensions :";
            // 
            // ibxDimensions
            // 
            this.ibxDimensions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDimensions.ForeColor = System.Drawing.Color.Black;
            this.ibxDimensions.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDimensions.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxDimensions.Location = new System.Drawing.Point(89, 141);
            this.ibxDimensions.Name = "ibxDimensions";
            this.ibxDimensions.Size = new System.Drawing.Size(148, 19);
            this.ibxDimensions.TabIndex = 11;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLength.Location = new System.Drawing.Point(37, 120);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(46, 13);
            this.lblLength.TabIndex = 8;
            this.lblLength.Text = "Length :";
            // 
            // ibxLength
            // 
            this.ibxLength.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxLength.ForeColor = System.Drawing.Color.Black;
            this.ibxLength.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxLength.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxLength.Location = new System.Drawing.Point(89, 117);
            this.ibxLength.Name = "ibxLength";
            this.ibxLength.Size = new System.Drawing.Size(148, 19);
            this.ibxLength.TabIndex = 9;
            // 
            // lblEndAddress
            // 
            this.lblEndAddress.AutoSize = true;
            this.lblEndAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEndAddress.Location = new System.Drawing.Point(10, 96);
            this.lblEndAddress.Name = "lblEndAddress";
            this.lblEndAddress.Size = new System.Drawing.Size(73, 13);
            this.lblEndAddress.TabIndex = 6;
            this.lblEndAddress.Text = "End Address :";
            // 
            // ibxEndAddress
            // 
            this.ibxEndAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxEndAddress.ForeColor = System.Drawing.Color.Black;
            this.ibxEndAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxEndAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxEndAddress.Location = new System.Drawing.Point(89, 93);
            this.ibxEndAddress.Name = "ibxEndAddress";
            this.ibxEndAddress.Size = new System.Drawing.Size(148, 19);
            this.ibxEndAddress.TabIndex = 7;
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStartAddress.Location = new System.Drawing.Point(7, 72);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(76, 13);
            this.lblStartAddress.TabIndex = 4;
            this.lblStartAddress.Text = "Start Address :";
            // 
            // ibxStartAddress
            // 
            this.ibxStartAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxStartAddress.ForeColor = System.Drawing.Color.Black;
            this.ibxStartAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStartAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxStartAddress.Location = new System.Drawing.Point(89, 69);
            this.ibxStartAddress.Name = "ibxStartAddress";
            this.ibxStartAddress.Size = new System.Drawing.Size(148, 19);
            this.ibxStartAddress.TabIndex = 5;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFilename.Location = new System.Drawing.Point(28, 24);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(55, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "Filename :";
            // 
            // ibxFormat
            // 
            this.ibxFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxFormat.ForeColor = System.Drawing.Color.Black;
            this.ibxFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxFormat.Location = new System.Drawing.Point(89, 45);
            this.ibxFormat.Name = "ibxFormat";
            this.ibxFormat.Size = new System.Drawing.Size(148, 19);
            this.ibxFormat.TabIndex = 3;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFormat.Location = new System.Drawing.Point(38, 48);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(45, 13);
            this.lblFormat.TabIndex = 2;
            this.lblFormat.Text = "Format :";
            // 
            // ibxFilename
            // 
            this.ibxFilename.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxFilename.ForeColor = System.Drawing.Color.Maroon;
            this.ibxFilename.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxFilename.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxFilename.Location = new System.Drawing.Point(89, 21);
            this.ibxFilename.Name = "ibxFilename";
            this.ibxFilename.Size = new System.Drawing.Size(148, 19);
            this.ibxFilename.TabIndex = 1;
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Location = new System.Drawing.Point(158, 12);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(80, 25);
            this.btnPrintScreen.TabIndex = 1;
            this.btnPrintScreen.Text = "Print Screen";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrintScreen_Click);
            // 
            // btnSaveScreen
            // 
            this.btnSaveScreen.Location = new System.Drawing.Point(14, 12);
            this.btnSaveScreen.Name = "btnSaveScreen";
            this.btnSaveScreen.Size = new System.Drawing.Size(80, 25);
            this.btnSaveScreen.TabIndex = 0;
            this.btnSaveScreen.Text = "Save Screen";
            this.btnSaveScreen.UseVisualStyleBackColor = true;
            this.btnSaveScreen.Click += new System.EventHandler(this.btnSaveScreen_Click);
            // 
            // lblImageFormat
            // 
            this.lblImageFormat.AutoSize = true;
            this.lblImageFormat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblImageFormat.Location = new System.Drawing.Point(38, 22);
            this.lblImageFormat.Name = "lblImageFormat";
            this.lblImageFormat.Size = new System.Drawing.Size(45, 13);
            this.lblImageFormat.TabIndex = 0;
            this.lblImageFormat.Text = "Format :";
            // 
            // tlpToolTip
            // 
            this.tlpToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.tlpToolTip_Popup);
            // 
            // optShowHiresOnly
            // 
            this.optShowHiresOnly.Appearance = System.Windows.Forms.Appearance.Button;
            this.optShowHiresOnly.Location = new System.Drawing.Point(91, 44);
            this.optShowHiresOnly.Name = "optShowHiresOnly";
            this.optShowHiresOnly.Size = new System.Drawing.Size(70, 22);
            this.optShowHiresOnly.TabIndex = 3;
            this.optShowHiresOnly.Text = "HIRES";
            this.optShowHiresOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optShowHiresOnly.UseVisualStyleBackColor = true;
            this.optShowHiresOnly.CheckedChanged += new System.EventHandler(this.optShowHiresOnly_CheckedChanged);
            // 
            // optShowTextOnly
            // 
            this.optShowTextOnly.Appearance = System.Windows.Forms.Appearance.Button;
            this.optShowTextOnly.Location = new System.Drawing.Point(176, 44);
            this.optShowTextOnly.Name = "optShowTextOnly";
            this.optShowTextOnly.Size = new System.Drawing.Size(70, 22);
            this.optShowTextOnly.TabIndex = 0;
            this.optShowTextOnly.Text = "TEXT";
            this.optShowTextOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optShowTextOnly.UseVisualStyleBackColor = true;
            this.optShowTextOnly.CheckedChanged += new System.EventHandler(this.optShowTextOnly_CheckedChanged);
            // 
            // optShowBoth
            // 
            this.optShowBoth.Appearance = System.Windows.Forms.Appearance.Button;
            this.optShowBoth.Checked = true;
            this.optShowBoth.Location = new System.Drawing.Point(6, 44);
            this.optShowBoth.Name = "optShowBoth";
            this.optShowBoth.Size = new System.Drawing.Size(70, 22);
            this.optShowBoth.TabIndex = 2;
            this.optShowBoth.TabStop = true;
            this.optShowBoth.Text = "All";
            this.optShowBoth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optShowBoth.UseVisualStyleBackColor = true;
            this.optShowBoth.CheckedChanged += new System.EventHandler(this.optShowBoth_CheckedChanged);
            // 
            // grpFormatFilter
            // 
            this.grpFormatFilter.Controls.Add(this.ibxImageCount);
            this.grpFormatFilter.Controls.Add(this.optShowBoth);
            this.grpFormatFilter.Controls.Add(this.optShowTextOnly);
            this.grpFormatFilter.Controls.Add(this.optShowHiresOnly);
            this.grpFormatFilter.Location = new System.Drawing.Point(518, 12);
            this.grpFormatFilter.Name = "grpFormatFilter";
            this.grpFormatFilter.Size = new System.Drawing.Size(253, 76);
            this.grpFormatFilter.TabIndex = 2;
            this.grpFormatFilter.TabStop = false;
            this.grpFormatFilter.Text = "Format Filter";
            // 
            // ibxImageCount
            // 
            this.ibxImageCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxImageCount.ForeColor = System.Drawing.Color.Maroon;
            this.ibxImageCount.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageCount.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageCount.Location = new System.Drawing.Point(6, 18);
            this.ibxImageCount.Name = "ibxImageCount";
            this.ibxImageCount.Size = new System.Drawing.Size(239, 20);
            this.ibxImageCount.TabIndex = 1;
            // 
            // panScreenImage
            // 
            this.panScreenImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panScreenImage.Controls.Add(this.picScreenImage);
            this.panScreenImage.Location = new System.Drawing.Point(12, 12);
            this.panScreenImage.Name = "panScreenImage";
            this.panScreenImage.Size = new System.Drawing.Size(497, 463);
            this.panScreenImage.TabIndex = 1;
            // 
            // grpViewerControls
            // 
            this.grpViewerControls.Controls.Add(this.lblImageCounter);
            this.grpViewerControls.Controls.Add(this.ibxImageCounter);
            this.grpViewerControls.Controls.Add(this.lblImageFormat);
            this.grpViewerControls.Controls.Add(this.ibxImageFormat);
            this.grpViewerControls.Controls.Add(this.btnFirstImage);
            this.grpViewerControls.Controls.Add(this.btnPrevImage);
            this.grpViewerControls.Controls.Add(this.btnLastImage);
            this.grpViewerControls.Controls.Add(this.btnNextImage);
            this.grpViewerControls.Location = new System.Drawing.Point(8, 1);
            this.grpViewerControls.Name = "grpViewerControls";
            this.grpViewerControls.Size = new System.Drawing.Size(233, 100);
            this.grpViewerControls.TabIndex = 0;
            this.grpViewerControls.TabStop = false;
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblImageCounter.Location = new System.Drawing.Point(2, 45);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(82, 13);
            this.lblImageCounter.TabIndex = 2;
            this.lblImageCounter.Text = "Image Counter :";
            // 
            // ibxImageCounter
            // 
            this.ibxImageCounter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxImageCounter.ForeColor = System.Drawing.Color.Green;
            this.ibxImageCounter.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageCounter.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxImageCounter.Location = new System.Drawing.Point(89, 42);
            this.ibxImageCounter.Name = "ibxImageCounter";
            this.ibxImageCounter.Size = new System.Drawing.Size(136, 19);
            this.ibxImageCounter.TabIndex = 3;
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.AutoScroll = true;
            this.flpThumbnails.BackColor = System.Drawing.Color.White;
            this.flpThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpThumbnails.Location = new System.Drawing.Point(12, 481);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(760, 201);
            this.flpThumbnails.TabIndex = 6;
            this.flpThumbnails.WrapContents = false;
            // 
            // tabControls
            // 
            this.tabControls.Controls.Add(this.tabpViewerControls);
            this.tabControls.Controls.Add(this.tabpSlideshowControls);
            this.tabControls.Location = new System.Drawing.Point(518, 320);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(257, 155);
            this.tabControls.TabIndex = 5;
            // 
            // tabpViewerControls
            // 
            this.tabpViewerControls.Controls.Add(this.grpViewerControls);
            this.tabpViewerControls.Location = new System.Drawing.Point(4, 22);
            this.tabpViewerControls.Name = "tabpViewerControls";
            this.tabpViewerControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabpViewerControls.Size = new System.Drawing.Size(249, 129);
            this.tabpViewerControls.TabIndex = 0;
            this.tabpViewerControls.Text = "Viewer Controls";
            this.tabpViewerControls.UseVisualStyleBackColor = true;
            // 
            // tabpSlideshowControls
            // 
            this.tabpSlideshowControls.Controls.Add(this.grpSlideshowControls);
            this.tabpSlideshowControls.Location = new System.Drawing.Point(4, 22);
            this.tabpSlideshowControls.Name = "tabpSlideshowControls";
            this.tabpSlideshowControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabpSlideshowControls.Size = new System.Drawing.Size(249, 129);
            this.tabpSlideshowControls.TabIndex = 1;
            this.tabpSlideshowControls.Text = "Slideshow Controls";
            this.tabpSlideshowControls.UseVisualStyleBackColor = true;
            // 
            // prtDocument
            // 
            this.prtDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocument_PrintPage);
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnSaveScreen);
            this.grpActions.Controls.Add(this.btnPrintScreen);
            this.grpActions.Location = new System.Drawing.Point(518, 270);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(253, 44);
            this.grpActions.TabIndex = 4;
            this.grpActions.TabStop = false;
            // 
            // frmScreenViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 693);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.tabControls);
            this.Controls.Add(this.flpThumbnails);
            this.Controls.Add(this.panScreenImage);
            this.Controls.Add(this.grpFormatFilter);
            this.Controls.Add(this.grpScreenInformation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(761, 521);
            this.Name = "frmScreenViewer";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screen Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenViewer_FormClosing);
            this.Load += new System.EventHandler(this.frmScreenViewer_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmScreenViewer_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSpeed)).EndInit();
            this.grpSlideshowControls.ResumeLayout(false);
            this.grpSlideshowControls.PerformLayout();
            this.grpScreenInformation.ResumeLayout(false);
            this.grpScreenInformation.PerformLayout();
            this.grpFormatFilter.ResumeLayout(false);
            this.panScreenImage.ResumeLayout(false);
            this.grpViewerControls.ResumeLayout(false);
            this.grpViewerControls.PerformLayout();
            this.tabControls.ResumeLayout(false);
            this.tabpViewerControls.ResumeLayout(false);
            this.tabpSlideshowControls.ResumeLayout(false);
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrevImage;
        private System.Windows.Forms.Button btnFirstImage;
        private System.Windows.Forms.PictureBox picScreenImage;
        private System.Windows.Forms.TrackBar tkbSpeed;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLastImage;
        private System.Windows.Forms.GroupBox grpSlideshowControls;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.GroupBox grpScreenInformation;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblEndAddress;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblImageFormat;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.ToolTip tlpToolTip;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblSlideshowStatus;
        private System.Windows.Forms.Label lblDimensions;
        private InfoBox.InfoBox ibxImageFormat;
        private System.Windows.Forms.RadioButton optShowHiresOnly;
        private System.Windows.Forms.RadioButton optShowTextOnly;
        private System.Windows.Forms.RadioButton optShowBoth;
        private System.Windows.Forms.GroupBox grpFormatFilter;
        private System.Windows.Forms.Panel panScreenImage;
        private System.Windows.Forms.GroupBox grpViewerControls;
        private System.Windows.Forms.Label lblImageCounter;
        private InfoBox.InfoBox ibxImageCounter;
        private InfoBox.InfoBox ibxSlideshowStatus;
        private InfoBox.InfoBox ibxDimensions;
        private InfoBox.InfoBox ibxLength;
        private InfoBox.InfoBox ibxEndAddress;
        private InfoBox.InfoBox ibxStartAddress;
        private InfoBox.InfoBox ibxFormat;
        private InfoBox.InfoBox ibxFilename;
        private System.Windows.Forms.FlowLayoutPanel flpThumbnails;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.TabPage tabpViewerControls;
        private System.Windows.Forms.TabPage tabpSlideshowControls;
        private System.Windows.Forms.Button btnSaveScreen;
        private System.Windows.Forms.Button btnPrintScreen;
        private System.Drawing.Printing.PrintDocument prtDocument;
        private InfoBox.InfoBox ibxImageCount;
        private System.Windows.Forms.GroupBox grpActions;
    }
}