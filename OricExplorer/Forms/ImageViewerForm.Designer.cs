namespace OricExplorer.Forms
{
    partial class ImageViewerForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxScreenImage = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelTextCount = new System.Windows.Forms.Label();
            this.labelHiresCount = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelSlideshowStatus = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonFirstImage = new System.Windows.Forms.Button();
            this.buttonPrevImage = new System.Windows.Forms.Button();
            this.buttonNextImage = new System.Windows.Forms.Button();
            this.buttonLastImage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEndAddressHex = new System.Windows.Forms.Label();
            this.labelImageCount = new System.Windows.Forms.Label();
            this.labelStartAddressHex = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.labelEndAddress = new System.Windows.Forms.Label();
            this.labelStartAddress = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.labelFilename = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRowCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBoxScreenImage);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 471);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            // 
            // pictureBoxScreenImage
            // 
            this.pictureBoxScreenImage.BackColor = System.Drawing.Color.Black;
            this.pictureBoxScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScreenImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxScreenImage.Location = new System.Drawing.Point(7, 15);
            this.pictureBoxScreenImage.Name = "pictureBoxScreenImage";
            this.pictureBoxScreenImage.Size = new System.Drawing.Size(480, 448);
            this.pictureBoxScreenImage.TabIndex = 54;
            this.pictureBoxScreenImage.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelTextCount);
            this.groupBox4.Controls.Add(this.labelHiresCount);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(505, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 58);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Images Found";
            // 
            // labelTextCount
            // 
            this.labelTextCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelTextCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTextCount.Location = new System.Drawing.Point(122, 23);
            this.labelTextCount.Name = "labelTextCount";
            this.labelTextCount.Size = new System.Drawing.Size(105, 21);
            this.labelTextCount.TabIndex = 2;
            this.labelTextCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHiresCount
            // 
            this.labelHiresCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHiresCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHiresCount.Location = new System.Drawing.Point(7, 23);
            this.labelHiresCount.Name = "labelHiresCount";
            this.labelHiresCount.Size = new System.Drawing.Size(105, 21);
            this.labelHiresCount.TabIndex = 1;
            this.labelHiresCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSpeed
            // 
            this.labelSpeed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSpeed.Location = new System.Drawing.Point(89, 85);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(134, 21);
            this.labelSpeed.TabIndex = 63;
            this.labelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSlideshowStatus
            // 
            this.labelSlideshowStatus.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSlideshowStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSlideshowStatus.Location = new System.Drawing.Point(89, 21);
            this.labelSlideshowStatus.Name = "labelSlideshowStatus";
            this.labelSlideshowStatus.Size = new System.Drawing.Size(136, 21);
            this.labelSlideshowStatus.TabIndex = 62;
            this.labelSlideshowStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 2;
            this.trackBarSpeed.Location = new System.Drawing.Point(89, 109);
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
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.trackBarSpeed);
            this.groupBox1.Controls.Add(this.labelSpeed);
            this.groupBox1.Controls.Add(this.checkBoxLoop);
            this.groupBox1.Controls.Add(this.labelSlideshowStatus);
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonPause);
            this.groupBox1.Controls.Add(this.buttonPlay);
            this.groupBox1.Location = new System.Drawing.Point(505, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 164);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slideshow Controls";
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
            this.buttonFirstImage.Location = new System.Drawing.Point(89, 41);
            this.buttonFirstImage.Name = "buttonFirstImage";
            this.buttonFirstImage.Size = new System.Drawing.Size(23, 23);
            this.buttonFirstImage.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonFirstImage, "Show first image");
            this.buttonFirstImage.UseVisualStyleBackColor = true;
            this.buttonFirstImage.Click += new System.EventHandler(this.buttonFirstImage_Click);
            // 
            // buttonPrevImage
            // 
            this.buttonPrevImage.Image = global::OricExplorer.Properties.Resources.control_rewind_blue;
            this.buttonPrevImage.Location = new System.Drawing.Point(126, 41);
            this.buttonPrevImage.Name = "buttonPrevImage";
            this.buttonPrevImage.Size = new System.Drawing.Size(23, 23);
            this.buttonPrevImage.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonPrevImage, "Show previous image");
            this.buttonPrevImage.UseVisualStyleBackColor = true;
            this.buttonPrevImage.Click += new System.EventHandler(this.buttonPrevImage_Click);
            // 
            // buttonNextImage
            // 
            this.buttonNextImage.Image = global::OricExplorer.Properties.Resources.control_fastforward_blue;
            this.buttonNextImage.Location = new System.Drawing.Point(163, 41);
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
            this.buttonLastImage.Location = new System.Drawing.Point(200, 41);
            this.buttonLastImage.Name = "buttonLastImage";
            this.buttonLastImage.Size = new System.Drawing.Size(23, 23);
            this.buttonLastImage.TabIndex = 3;
            this.toolTip1.SetToolTip(this.buttonLastImage, "Show last image");
            this.buttonLastImage.UseVisualStyleBackColor = true;
            this.buttonLastImage.Click += new System.EventHandler(this.buttonLastImage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelRowCount);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.labelEndAddressHex);
            this.groupBox5.Controls.Add(this.labelImageCount);
            this.groupBox5.Controls.Add(this.buttonFirstImage);
            this.groupBox5.Controls.Add(this.labelStartAddressHex);
            this.groupBox5.Controls.Add(this.buttonPrevImage);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.buttonNextImage);
            this.groupBox5.Controls.Add(this.labelLength);
            this.groupBox5.Controls.Add(this.buttonLastImage);
            this.groupBox5.Controls.Add(this.labelEndAddress);
            this.groupBox5.Controls.Add(this.labelStartAddress);
            this.groupBox5.Controls.Add(this.labelFormat);
            this.groupBox5.Controls.Add(this.labelFilename);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(505, 69);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 234);
            this.groupBox5.TabIndex = 62;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Image Information";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(7, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 2);
            this.label6.TabIndex = 64;
            // 
            // labelEndAddressHex
            // 
            this.labelEndAddressHex.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelEndAddressHex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEndAddressHex.Location = new System.Drawing.Point(161, 157);
            this.labelEndAddressHex.Name = "labelEndAddressHex";
            this.labelEndAddressHex.Size = new System.Drawing.Size(65, 19);
            this.labelEndAddressHex.TabIndex = 13;
            this.labelEndAddressHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelImageCount
            // 
            this.labelImageCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelImageCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelImageCount.Location = new System.Drawing.Point(89, 19);
            this.labelImageCount.Name = "labelImageCount";
            this.labelImageCount.Size = new System.Drawing.Size(137, 19);
            this.labelImageCount.TabIndex = 12;
            this.labelImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartAddressHex
            // 
            this.labelStartAddressHex.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelStartAddressHex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStartAddressHex.Location = new System.Drawing.Point(161, 133);
            this.labelStartAddressHex.Name = "labelStartAddressHex";
            this.labelStartAddressHex.Size = new System.Drawing.Size(65, 19);
            this.labelStartAddressHex.TabIndex = 13;
            this.labelStartAddressHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(29, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Showing :";
            // 
            // labelLength
            // 
            this.labelLength.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLength.Location = new System.Drawing.Point(89, 181);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(137, 19);
            this.labelLength.TabIndex = 9;
            this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEndAddress
            // 
            this.labelEndAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelEndAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelEndAddress.Location = new System.Drawing.Point(89, 157);
            this.labelEndAddress.Name = "labelEndAddress";
            this.labelEndAddress.Size = new System.Drawing.Size(65, 19);
            this.labelEndAddress.TabIndex = 8;
            this.labelEndAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStartAddress
            // 
            this.labelStartAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelStartAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStartAddress.Location = new System.Drawing.Point(89, 133);
            this.labelStartAddress.Name = "labelStartAddress";
            this.labelStartAddress.Size = new System.Drawing.Size(65, 19);
            this.labelStartAddress.TabIndex = 7;
            this.labelStartAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFormat
            // 
            this.labelFormat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFormat.Location = new System.Drawing.Point(89, 109);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(137, 19);
            this.labelFormat.TabIndex = 6;
            this.labelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFilename
            // 
            this.labelFilename.BackColor = System.Drawing.SystemColors.Info;
            this.labelFilename.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFilename.Location = new System.Drawing.Point(89, 85);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(137, 19);
            this.labelFilename.TabIndex = 5;
            this.labelFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(37, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Length :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(10, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(7, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(28, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filename :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(38, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format :";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(4, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Interval (secs) :";
            // 
            // labelRowCount
            // 
            this.labelRowCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelRowCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRowCount.Location = new System.Drawing.Point(89, 205);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(137, 19);
            this.labelRowCount.TabIndex = 66;
            this.labelRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(17, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 65;
            this.label11.Text = "Row Count :";
            // 
            // ImageViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 482);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageViewerForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SlideshowViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.SlideshowViewerForm_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPrevImage;
        private System.Windows.Forms.Button buttonFirstImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBoxScreenImage;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button buttonNextImage;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonLastImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelSlideshowStatus;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelTextCount;
        private System.Windows.Forms.Label labelHiresCount;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label labelEndAddress;
        private System.Windows.Forms.Label labelStartAddress;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label labelImageCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEndAddressHex;
        private System.Windows.Forms.Label labelStartAddressHex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelRowCount;
        private System.Windows.Forms.Label label11;
    }
}