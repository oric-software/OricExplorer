namespace OricExplorer.Forms
{
    partial class ScreenViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenViewerForm));
            this.pictureBoxScreenImage = new System.Windows.Forms.PictureBox();
            this.infoBoxImageFormat = new InfoBox.InfoBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoBoxSlideshowStatus = new InfoBox.InfoBox();
            this.labelIntervalSecs = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonFirstImage = new System.Windows.Forms.Button();
            this.buttonPrevImage = new System.Windows.Forms.Button();
            this.buttonNextImage = new System.Windows.Forms.Button();
            this.buttonLastImage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.infoBoxDimensions = new InfoBox.InfoBox();
            this.label5 = new System.Windows.Forms.Label();
            this.infoBoxLength = new InfoBox.InfoBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infoBoxEndAddress = new InfoBox.InfoBox();
            this.label3 = new System.Windows.Forms.Label();
            this.infoBoxStartAddress = new InfoBox.InfoBox();
            this.label2 = new System.Windows.Forms.Label();
            this.infoBoxFormat = new InfoBox.InfoBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoBoxFilename = new InfoBox.InfoBox();
            this.buttonPrintScreen = new System.Windows.Forms.Button();
            this.buttonSaveScreen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioButtonShowHiresOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonShowTextOnly = new System.Windows.Forms.RadioButton();
            this.radioButtonShowBoth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.infoBoxImageCount = new InfoBox.InfoBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.infoBoxImageCounter = new InfoBox.InfoBox();
            this.flowLayoutPanelThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageViewControls = new System.Windows.Forms.TabPage();
            this.tabPageSlideshowcontrols = new System.Windows.Forms.TabPage();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageViewControls.SuspendLayout();
            this.tabPageSlideshowcontrols.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxScreenImage
            // 
            this.pictureBoxScreenImage.BackColor = System.Drawing.Color.Black;
            this.pictureBoxScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScreenImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxScreenImage.Location = new System.Drawing.Point(7, 6);
            this.pictureBoxScreenImage.Name = "pictureBoxScreenImage";
            this.pictureBoxScreenImage.Size = new System.Drawing.Size(480, 448);
            this.pictureBoxScreenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxScreenImage.TabIndex = 54;
            this.pictureBoxScreenImage.TabStop = false;
            // 
            // infoBoxImageFormat
            // 
            this.infoBoxImageFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxImageFormat.ForeColor = System.Drawing.Color.Green;
            this.infoBoxImageFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageFormat.Location = new System.Drawing.Point(89, 19);
            this.infoBoxImageFormat.Name = "infoBoxImageFormat";
            this.infoBoxImageFormat.Size = new System.Drawing.Size(136, 19);
            this.infoBoxImageFormat.TabIndex = 63;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 2;
            this.trackBarSpeed.Location = new System.Drawing.Point(89, 76);
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(134, 45);
            this.trackBarSpeed.TabIndex = 58;
            this.trackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.trackBarSpeed, "Adjust interval between images");
            this.trackBarSpeed.Value = 1;
            this.trackBarSpeed.ValueChanged += new System.EventHandler(this.trackBarSpeed_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoBoxSlideshowStatus);
            this.groupBox1.Controls.Add(this.labelIntervalSecs);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.trackBarSpeed);
            this.groupBox1.Controls.Add(this.checkBoxLoop);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonPause);
            this.groupBox1.Controls.Add(this.buttonPlay);
            this.groupBox1.Location = new System.Drawing.Point(8, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 123);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // infoBoxSlideshowStatus
            // 
            this.infoBoxSlideshowStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSlideshowStatus.ForeColor = System.Drawing.Color.Blue;
            this.infoBoxSlideshowStatus.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSlideshowStatus.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxSlideshowStatus.Location = new System.Drawing.Point(89, 22);
            this.infoBoxSlideshowStatus.Name = "infoBoxSlideshowStatus";
            this.infoBoxSlideshowStatus.Size = new System.Drawing.Size(136, 19);
            this.infoBoxSlideshowStatus.TabIndex = 79;
            // 
            // labelIntervalSecs
            // 
            this.labelIntervalSecs.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelIntervalSecs.Location = new System.Drawing.Point(4, 76);
            this.labelIntervalSecs.Name = "labelIntervalSecs";
            this.labelIntervalSecs.Size = new System.Drawing.Size(79, 45);
            this.labelIntervalSecs.TabIndex = 66;
            this.labelIntervalSecs.Text = "Interval\r\n( 2 secs)";
            this.labelIntervalSecs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(40, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Status :";
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLoop.Image = global::OricExplorer.Properties.Resources.control_repeat_blue;
            this.checkBoxLoop.Location = new System.Drawing.Point(200, 47);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(23, 23);
            this.checkBoxLoop.TabIndex = 63;
            this.toolTip1.SetToolTip(this.checkBoxLoop, "Enable/Disable looping");
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            this.checkBoxLoop.CheckedChanged += new System.EventHandler(this.checkBoxLoop_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Image = global::OricExplorer.Properties.Resources.control_stop_blue;
            this.buttonStop.Location = new System.Drawing.Point(163, 47);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(23, 23);
            this.buttonStop.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonStop, "Stop slideshow");
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Image = global::OricExplorer.Properties.Resources.control_pause_blue;
            this.buttonPause.Location = new System.Drawing.Point(126, 47);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(23, 23);
            this.buttonPause.TabIndex = 5;
            this.toolTip1.SetToolTip(this.buttonPause, "Pause slideshow");
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Image = global::OricExplorer.Properties.Resources.control_play_blue;
            this.buttonPlay.Location = new System.Drawing.Point(89, 47);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(23, 23);
            this.buttonPlay.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonPlay, "Start slideshow");
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonFirstImage
            // 
            this.buttonFirstImage.Image = global::OricExplorer.Properties.Resources.control_start_blue;
            this.buttonFirstImage.Location = new System.Drawing.Point(89, 69);
            this.buttonFirstImage.Name = "buttonFirstImage";
            this.buttonFirstImage.Size = new System.Drawing.Size(23, 23);
            this.buttonFirstImage.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonFirstImage, "Show first image");
            this.buttonFirstImage.UseVisualStyleBackColor = true;
            this.buttonFirstImage.Click += new System.EventHandler(this.buttonFirstImage_Click);
            // 
            // buttonPrevImage
            // 
            this.buttonPrevImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrevImage.Image")));
            this.buttonPrevImage.Location = new System.Drawing.Point(126, 69);
            this.buttonPrevImage.Name = "buttonPrevImage";
            this.buttonPrevImage.Size = new System.Drawing.Size(23, 23);
            this.buttonPrevImage.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonPrevImage, "Show previous image");
            this.buttonPrevImage.UseVisualStyleBackColor = true;
            this.buttonPrevImage.Click += new System.EventHandler(this.buttonPrevImage_Click);
            // 
            // buttonNextImage
            // 
            this.buttonNextImage.Image = ((System.Drawing.Image)(resources.GetObject("buttonNextImage.Image")));
            this.buttonNextImage.Location = new System.Drawing.Point(163, 69);
            this.buttonNextImage.Name = "buttonNextImage";
            this.buttonNextImage.Size = new System.Drawing.Size(23, 23);
            this.buttonNextImage.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonNextImage, "Show next image");
            this.buttonNextImage.UseVisualStyleBackColor = true;
            this.buttonNextImage.Click += new System.EventHandler(this.buttonNextImage_Click);
            // 
            // buttonLastImage
            // 
            this.buttonLastImage.Image = global::OricExplorer.Properties.Resources.control_end_blue;
            this.buttonLastImage.Location = new System.Drawing.Point(200, 69);
            this.buttonLastImage.Name = "buttonLastImage";
            this.buttonLastImage.Size = new System.Drawing.Size(23, 23);
            this.buttonLastImage.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonLastImage, "Show last image");
            this.buttonLastImage.UseVisualStyleBackColor = true;
            this.buttonLastImage.Click += new System.EventHandler(this.buttonLastImage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.infoBoxDimensions);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.infoBoxLength);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.infoBoxEndAddress);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.infoBoxStartAddress);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.infoBoxFormat);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.infoBoxFilename);
            this.groupBox5.Location = new System.Drawing.Point(519, 94);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(253, 170);
            this.groupBox5.TabIndex = 62;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Screen Information";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(17, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 65;
            this.label11.Text = "Dimensions :";
            // 
            // infoBoxDimensions
            // 
            this.infoBoxDimensions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDimensions.ForeColor = System.Drawing.Color.Black;
            this.infoBoxDimensions.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDimensions.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxDimensions.Location = new System.Drawing.Point(89, 141);
            this.infoBoxDimensions.Name = "infoBoxDimensions";
            this.infoBoxDimensions.Size = new System.Drawing.Size(148, 19);
            this.infoBoxDimensions.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(37, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Length :";
            // 
            // infoBoxLength
            // 
            this.infoBoxLength.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxLength.ForeColor = System.Drawing.Color.Black;
            this.infoBoxLength.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxLength.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxLength.Location = new System.Drawing.Point(89, 117);
            this.infoBoxLength.Name = "infoBoxLength";
            this.infoBoxLength.Size = new System.Drawing.Size(148, 19);
            this.infoBoxLength.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Address :";
            // 
            // infoBoxEndAddress
            // 
            this.infoBoxEndAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxEndAddress.ForeColor = System.Drawing.Color.Black;
            this.infoBoxEndAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxEndAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxEndAddress.Location = new System.Drawing.Point(89, 93);
            this.infoBoxEndAddress.Name = "infoBoxEndAddress";
            this.infoBoxEndAddress.Size = new System.Drawing.Size(148, 19);
            this.infoBoxEndAddress.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Address :";
            // 
            // infoBoxStartAddress
            // 
            this.infoBoxStartAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxStartAddress.ForeColor = System.Drawing.Color.Black;
            this.infoBoxStartAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStartAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxStartAddress.Location = new System.Drawing.Point(89, 69);
            this.infoBoxStartAddress.Name = "infoBoxStartAddress";
            this.infoBoxStartAddress.Size = new System.Drawing.Size(148, 19);
            this.infoBoxStartAddress.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(28, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filename :";
            // 
            // infoBoxFormat
            // 
            this.infoBoxFormat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxFormat.ForeColor = System.Drawing.Color.Black;
            this.infoBoxFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxFormat.Location = new System.Drawing.Point(89, 45);
            this.infoBoxFormat.Name = "infoBoxFormat";
            this.infoBoxFormat.Size = new System.Drawing.Size(148, 19);
            this.infoBoxFormat.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(38, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format :";
            // 
            // infoBoxFilename
            // 
            this.infoBoxFilename.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxFilename.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxFilename.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxFilename.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxFilename.Location = new System.Drawing.Point(89, 21);
            this.infoBoxFilename.Name = "infoBoxFilename";
            this.infoBoxFilename.Size = new System.Drawing.Size(148, 19);
            this.infoBoxFilename.TabIndex = 66;
            // 
            // buttonPrintScreen
            // 
            this.buttonPrintScreen.Location = new System.Drawing.Point(158, 12);
            this.buttonPrintScreen.Name = "buttonPrintScreen";
            this.buttonPrintScreen.Size = new System.Drawing.Size(80, 25);
            this.buttonPrintScreen.TabIndex = 77;
            this.buttonPrintScreen.Text = "Print Screen";
            this.buttonPrintScreen.UseVisualStyleBackColor = true;
            this.buttonPrintScreen.Click += new System.EventHandler(this.buttonPrintScreen_Click);
            // 
            // buttonSaveScreen
            // 
            this.buttonSaveScreen.Location = new System.Drawing.Point(14, 12);
            this.buttonSaveScreen.Name = "buttonSaveScreen";
            this.buttonSaveScreen.Size = new System.Drawing.Size(80, 25);
            this.buttonSaveScreen.TabIndex = 76;
            this.buttonSaveScreen.Text = "Save Screen";
            this.buttonSaveScreen.UseVisualStyleBackColor = true;
            this.buttonSaveScreen.Click += new System.EventHandler(this.buttonSaveScreen_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(38, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Format :";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // radioButtonShowHiresOnly
            // 
            this.radioButtonShowHiresOnly.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonShowHiresOnly.Location = new System.Drawing.Point(91, 44);
            this.radioButtonShowHiresOnly.Name = "radioButtonShowHiresOnly";
            this.radioButtonShowHiresOnly.Size = new System.Drawing.Size(70, 22);
            this.radioButtonShowHiresOnly.TabIndex = 68;
            this.radioButtonShowHiresOnly.Text = "HIRES";
            this.radioButtonShowHiresOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonShowHiresOnly.UseVisualStyleBackColor = true;
            this.radioButtonShowHiresOnly.CheckedChanged += new System.EventHandler(this.radioButtonShowHiresOnly_CheckedChanged);
            // 
            // radioButtonShowTextOnly
            // 
            this.radioButtonShowTextOnly.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonShowTextOnly.Location = new System.Drawing.Point(176, 44);
            this.radioButtonShowTextOnly.Name = "radioButtonShowTextOnly";
            this.radioButtonShowTextOnly.Size = new System.Drawing.Size(70, 22);
            this.radioButtonShowTextOnly.TabIndex = 69;
            this.radioButtonShowTextOnly.Text = "TEXT";
            this.radioButtonShowTextOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonShowTextOnly.UseVisualStyleBackColor = true;
            this.radioButtonShowTextOnly.CheckedChanged += new System.EventHandler(this.radioButtonShowTextOnly_CheckedChanged);
            // 
            // radioButtonShowBoth
            // 
            this.radioButtonShowBoth.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonShowBoth.Checked = true;
            this.radioButtonShowBoth.Location = new System.Drawing.Point(6, 44);
            this.radioButtonShowBoth.Name = "radioButtonShowBoth";
            this.radioButtonShowBoth.Size = new System.Drawing.Size(70, 22);
            this.radioButtonShowBoth.TabIndex = 70;
            this.radioButtonShowBoth.TabStop = true;
            this.radioButtonShowBoth.Text = "All";
            this.radioButtonShowBoth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonShowBoth.UseVisualStyleBackColor = true;
            this.radioButtonShowBoth.CheckedChanged += new System.EventHandler(this.radioButtonShowBoth_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.infoBoxImageCount);
            this.groupBox2.Controls.Add(this.radioButtonShowBoth);
            this.groupBox2.Controls.Add(this.radioButtonShowTextOnly);
            this.groupBox2.Controls.Add(this.radioButtonShowHiresOnly);
            this.groupBox2.Location = new System.Drawing.Point(518, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 76);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Format Filter";
            // 
            // infoBoxImageCount
            // 
            this.infoBoxImageCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxImageCount.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxImageCount.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageCount.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageCount.Location = new System.Drawing.Point(6, 18);
            this.infoBoxImageCount.Name = "infoBoxImageCount";
            this.infoBoxImageCount.Size = new System.Drawing.Size(239, 20);
            this.infoBoxImageCount.TabIndex = 79;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxScreenImage);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 463);
            this.panel1.TabIndex = 72;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.infoBoxImageCounter);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.infoBoxImageFormat);
            this.groupBox3.Controls.Add(this.buttonFirstImage);
            this.groupBox3.Controls.Add(this.buttonPrevImage);
            this.groupBox3.Controls.Add(this.buttonLastImage);
            this.groupBox3.Controls.Add(this.buttonNextImage);
            this.groupBox3.Location = new System.Drawing.Point(8, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 100);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(2, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 65;
            this.label8.Text = "Image Counter :";
            // 
            // infoBoxImageCounter
            // 
            this.infoBoxImageCounter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxImageCounter.ForeColor = System.Drawing.Color.Green;
            this.infoBoxImageCounter.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageCounter.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxImageCounter.Location = new System.Drawing.Point(89, 42);
            this.infoBoxImageCounter.Name = "infoBoxImageCounter";
            this.infoBoxImageCounter.Size = new System.Drawing.Size(136, 19);
            this.infoBoxImageCounter.TabIndex = 64;
            // 
            // flowLayoutPanelThumbnails
            // 
            this.flowLayoutPanelThumbnails.AutoScroll = true;
            this.flowLayoutPanelThumbnails.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelThumbnails.Location = new System.Drawing.Point(12, 481);
            this.flowLayoutPanelThumbnails.Name = "flowLayoutPanelThumbnails";
            this.flowLayoutPanelThumbnails.Size = new System.Drawing.Size(760, 201);
            this.flowLayoutPanelThumbnails.TabIndex = 74;
            this.flowLayoutPanelThumbnails.WrapContents = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageViewControls);
            this.tabControl1.Controls.Add(this.tabPageSlideshowcontrols);
            this.tabControl1.Location = new System.Drawing.Point(518, 320);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(257, 155);
            this.tabControl1.TabIndex = 75;
            // 
            // tabPageViewControls
            // 
            this.tabPageViewControls.Controls.Add(this.groupBox3);
            this.tabPageViewControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewControls.Name = "tabPageViewControls";
            this.tabPageViewControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewControls.Size = new System.Drawing.Size(249, 129);
            this.tabPageViewControls.TabIndex = 0;
            this.tabPageViewControls.Text = "Viewer Controls";
            this.tabPageViewControls.UseVisualStyleBackColor = true;
            // 
            // tabPageSlideshowcontrols
            // 
            this.tabPageSlideshowcontrols.Controls.Add(this.groupBox1);
            this.tabPageSlideshowcontrols.Location = new System.Drawing.Point(4, 22);
            this.tabPageSlideshowcontrols.Name = "tabPageSlideshowcontrols";
            this.tabPageSlideshowcontrols.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSlideshowcontrols.Size = new System.Drawing.Size(249, 129);
            this.tabPageSlideshowcontrols.TabIndex = 1;
            this.tabPageSlideshowcontrols.Text = "Slideshow Controls";
            this.tabPageSlideshowcontrols.UseVisualStyleBackColor = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSaveScreen);
            this.groupBox4.Controls.Add(this.buttonPrintScreen);
            this.groupBox4.Location = new System.Drawing.Point(518, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 44);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            // 
            // ScreenViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 693);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanelThumbnails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(761, 521);
            this.Name = "ScreenViewerForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screen Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlideshowViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.SlideshowViewerForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenViewerForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageViewControls.ResumeLayout(false);
            this.tabPageSlideshowcontrols.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPrevImage;
        private System.Windows.Forms.Button buttonFirstImage;
        private System.Windows.Forms.PictureBox pictureBoxScreenImage;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button buttonNextImage;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonLastImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelIntervalSecs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private InfoBox.InfoBox infoBoxImageFormat;
        private System.Windows.Forms.RadioButton radioButtonShowHiresOnly;
        private System.Windows.Forms.RadioButton radioButtonShowTextOnly;
        private System.Windows.Forms.RadioButton radioButtonShowBoth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private InfoBox.InfoBox infoBoxImageCounter;
        private InfoBox.InfoBox infoBoxSlideshowStatus;
        private InfoBox.InfoBox infoBoxDimensions;
        private InfoBox.InfoBox infoBoxLength;
        private InfoBox.InfoBox infoBoxEndAddress;
        private InfoBox.InfoBox infoBoxStartAddress;
        private InfoBox.InfoBox infoBoxFormat;
        private InfoBox.InfoBox infoBoxFilename;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelThumbnails;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageViewControls;
        private System.Windows.Forms.TabPage tabPageSlideshowcontrols;
        private System.Windows.Forms.Button buttonSaveScreen;
        private System.Windows.Forms.Button buttonPrintScreen;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private InfoBox.InfoBox infoBoxImageCount;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}