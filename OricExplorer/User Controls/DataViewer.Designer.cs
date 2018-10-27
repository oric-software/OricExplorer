namespace OricExplorer
{
    partial class DataViewerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewerControl));
            this.radioButtonHires = new System.Windows.Forms.RadioButton();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.radioButtonCharSet = new System.Windows.Forms.RadioButton();
            this.buttonResetZoom = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonResetOffset = new System.Windows.Forms.Button();
            this.buttonIncOffset = new System.Windows.Forms.Button();
            this.buttonDecOffset = new System.Windows.Forms.Button();
            this.buttonResetWidth = new System.Windows.Forms.Button();
            this.buttonDecWidth = new System.Windows.Forms.Button();
            this.buttonIncWidth = new System.Windows.Forms.Button();
            this.checkBoxForeground = new System.Windows.Forms.CheckBox();
            this.checkBoxBackground = new System.Windows.Forms.CheckBox();
            this.checkBoxOthers = new System.Windows.Forms.CheckBox();
            this.infoBoxWidth = new InfoBox.InfoBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.infoBoxOffset = new InfoBox.InfoBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.groupFrame1 = new GroupFrame.GroupFrame();
            this.groupFrame2 = new GroupFrame.GroupFrame();
            this.infoBoxZoom = new InfoBox.InfoBox();
            this.groupFrame3 = new GroupFrame.GroupFrame();
            this.groupFrame4 = new GroupFrame.GroupFrame();
            this.groupFrame5 = new GroupFrame.GroupFrame();
            this.groupFrame6 = new GroupFrame.GroupFrame();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.groupFrame1.SuspendLayout();
            this.groupFrame2.SuspendLayout();
            this.groupFrame3.SuspendLayout();
            this.groupFrame4.SuspendLayout();
            this.groupFrame5.SuspendLayout();
            this.groupFrame6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonHires
            // 
            this.radioButtonHires.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonHires.Location = new System.Drawing.Point(6, 19);
            this.radioButtonHires.Name = "radioButtonHires";
            this.radioButtonHires.Size = new System.Drawing.Size(58, 23);
            this.radioButtonHires.TabIndex = 0;
            this.radioButtonHires.TabStop = true;
            this.radioButtonHires.Text = "HIRES";
            this.radioButtonHires.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonHires.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButtonHires.UseVisualStyleBackColor = true;
            this.radioButtonHires.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // radioButtonText
            // 
            this.radioButtonText.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonText.Location = new System.Drawing.Point(71, 19);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(58, 23);
            this.radioButtonText.TabIndex = 1;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "TEXT";
            this.radioButtonText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // radioButtonCharSet
            // 
            this.radioButtonCharSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonCharSet.Location = new System.Drawing.Point(136, 19);
            this.radioButtonCharSet.Name = "radioButtonCharSet";
            this.radioButtonCharSet.Size = new System.Drawing.Size(58, 23);
            this.radioButtonCharSet.TabIndex = 2;
            this.radioButtonCharSet.TabStop = true;
            this.radioButtonCharSet.Text = "CHAR";
            this.radioButtonCharSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonCharSet.UseVisualStyleBackColor = true;
            this.radioButtonCharSet.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // buttonResetZoom
            // 
            this.buttonResetZoom.ForeColor = System.Drawing.Color.Black;
            this.buttonResetZoom.Image = ((System.Drawing.Image)(resources.GetObject("buttonResetZoom.Image")));
            this.buttonResetZoom.Location = new System.Drawing.Point(112, 47);
            this.buttonResetZoom.Name = "buttonResetZoom";
            this.buttonResetZoom.Size = new System.Drawing.Size(82, 25);
            this.buttonResetZoom.TabIndex = 36;
            this.buttonResetZoom.Text = "Reset";
            this.buttonResetZoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonResetZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonResetZoom.UseVisualStyleBackColor = true;
            this.buttonResetZoom.Click += new System.EventHandler(this.buttonResetZoom_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("buttonZoomIn.Image")));
            this.buttonZoomIn.Location = new System.Drawing.Point(6, 47);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(25, 25);
            this.buttonZoomIn.TabIndex = 20;
            this.buttonZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("buttonZoomOut.Image")));
            this.buttonZoomOut.Location = new System.Drawing.Point(36, 47);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(25, 25);
            this.buttonZoomOut.TabIndex = 21;
            this.buttonZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonResetOffset
            // 
            this.buttonResetOffset.ForeColor = System.Drawing.Color.Black;
            this.buttonResetOffset.Image = ((System.Drawing.Image)(resources.GetObject("buttonResetOffset.Image")));
            this.buttonResetOffset.Location = new System.Drawing.Point(112, 47);
            this.buttonResetOffset.Name = "buttonResetOffset";
            this.buttonResetOffset.Size = new System.Drawing.Size(82, 25);
            this.buttonResetOffset.TabIndex = 34;
            this.buttonResetOffset.Text = "Reset";
            this.buttonResetOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonResetOffset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonResetOffset.UseVisualStyleBackColor = true;
            this.buttonResetOffset.Click += new System.EventHandler(this.buttonResetOffset_Click);
            // 
            // buttonIncOffset
            // 
            this.buttonIncOffset.ForeColor = System.Drawing.Color.Black;
            this.buttonIncOffset.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncOffset.Image")));
            this.buttonIncOffset.Location = new System.Drawing.Point(37, 47);
            this.buttonIncOffset.Name = "buttonIncOffset";
            this.buttonIncOffset.Size = new System.Drawing.Size(25, 25);
            this.buttonIncOffset.TabIndex = 27;
            this.buttonIncOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonIncOffset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonIncOffset.UseVisualStyleBackColor = true;
            this.buttonIncOffset.Click += new System.EventHandler(this.buttonIncOffset_Click);
            // 
            // buttonDecOffset
            // 
            this.buttonDecOffset.ForeColor = System.Drawing.Color.Black;
            this.buttonDecOffset.Image = ((System.Drawing.Image)(resources.GetObject("buttonDecOffset.Image")));
            this.buttonDecOffset.Location = new System.Drawing.Point(6, 47);
            this.buttonDecOffset.Name = "buttonDecOffset";
            this.buttonDecOffset.Size = new System.Drawing.Size(25, 25);
            this.buttonDecOffset.TabIndex = 26;
            this.buttonDecOffset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDecOffset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDecOffset.UseVisualStyleBackColor = true;
            this.buttonDecOffset.Click += new System.EventHandler(this.buttonDecOffset_Click);
            // 
            // buttonResetWidth
            // 
            this.buttonResetWidth.ForeColor = System.Drawing.Color.Black;
            this.buttonResetWidth.Image = ((System.Drawing.Image)(resources.GetObject("buttonResetWidth.Image")));
            this.buttonResetWidth.Location = new System.Drawing.Point(112, 47);
            this.buttonResetWidth.Name = "buttonResetWidth";
            this.buttonResetWidth.Size = new System.Drawing.Size(82, 25);
            this.buttonResetWidth.TabIndex = 35;
            this.buttonResetWidth.Text = "Reset";
            this.buttonResetWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonResetWidth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonResetWidth.UseVisualStyleBackColor = true;
            this.buttonResetWidth.Click += new System.EventHandler(this.buttonResetWidth_Click);
            // 
            // buttonDecWidth
            // 
            this.buttonDecWidth.ForeColor = System.Drawing.Color.Black;
            this.buttonDecWidth.Image = ((System.Drawing.Image)(resources.GetObject("buttonDecWidth.Image")));
            this.buttonDecWidth.Location = new System.Drawing.Point(7, 47);
            this.buttonDecWidth.Name = "buttonDecWidth";
            this.buttonDecWidth.Size = new System.Drawing.Size(25, 25);
            this.buttonDecWidth.TabIndex = 33;
            this.buttonDecWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDecWidth.UseVisualStyleBackColor = true;
            this.buttonDecWidth.Click += new System.EventHandler(this.buttonDecWidth_Click);
            // 
            // buttonIncWidth
            // 
            this.buttonIncWidth.ForeColor = System.Drawing.Color.Black;
            this.buttonIncWidth.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncWidth.Image")));
            this.buttonIncWidth.Location = new System.Drawing.Point(38, 47);
            this.buttonIncWidth.Name = "buttonIncWidth";
            this.buttonIncWidth.Size = new System.Drawing.Size(25, 25);
            this.buttonIncWidth.TabIndex = 34;
            this.buttonIncWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonIncWidth.UseVisualStyleBackColor = true;
            this.buttonIncWidth.Click += new System.EventHandler(this.buttonIncWidth_Click);
            // 
            // checkBoxForeground
            // 
            this.checkBoxForeground.AutoSize = true;
            this.checkBoxForeground.Location = new System.Drawing.Point(11, 40);
            this.checkBoxForeground.Name = "checkBoxForeground";
            this.checkBoxForeground.Size = new System.Drawing.Size(41, 17);
            this.checkBoxForeground.TabIndex = 1;
            this.checkBoxForeground.Text = "Ink";
            this.checkBoxForeground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxForeground.UseVisualStyleBackColor = true;
            this.checkBoxForeground.CheckedChanged += new System.EventHandler(this.checkBoxForeground_CheckedChanged);
            // 
            // checkBoxBackground
            // 
            this.checkBoxBackground.AutoSize = true;
            this.checkBoxBackground.Location = new System.Drawing.Point(11, 19);
            this.checkBoxBackground.Name = "checkBoxBackground";
            this.checkBoxBackground.Size = new System.Drawing.Size(54, 17);
            this.checkBoxBackground.TabIndex = 0;
            this.checkBoxBackground.Text = "Paper";
            this.checkBoxBackground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBackground.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBoxBackground.UseVisualStyleBackColor = true;
            this.checkBoxBackground.CheckedChanged += new System.EventHandler(this.checkBoxBackground_CheckedChanged);
            // 
            // checkBoxOthers
            // 
            this.checkBoxOthers.AutoSize = true;
            this.checkBoxOthers.Location = new System.Drawing.Point(11, 61);
            this.checkBoxOthers.Name = "checkBoxOthers";
            this.checkBoxOthers.Size = new System.Drawing.Size(144, 30);
            this.checkBoxOthers.TabIndex = 2;
            this.checkBoxOthers.Text = "Others\r\n(Double Height/Flashing)";
            this.checkBoxOthers.UseVisualStyleBackColor = true;
            this.checkBoxOthers.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // infoBoxWidth
            // 
            this.infoBoxWidth.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxWidth.ForeColor = System.Drawing.Color.Black;
            this.infoBoxWidth.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxWidth.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxWidth.Location = new System.Drawing.Point(6, 19);
            this.infoBoxWidth.Name = "infoBoxWidth";
            this.infoBoxWidth.Size = new System.Drawing.Size(188, 22);
            this.infoBoxWidth.TabIndex = 40;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(103, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save Image";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = global::OricExplorer.Properties.Resources.PrintHS;
            this.btnPrint.Location = new System.Drawing.Point(6, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 25);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print Image";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // infoBoxOffset
            // 
            this.infoBoxOffset.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxOffset.ForeColor = System.Drawing.Color.Black;
            this.infoBoxOffset.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxOffset.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxOffset.Location = new System.Drawing.Point(6, 19);
            this.infoBoxOffset.Name = "infoBoxOffset";
            this.infoBoxOffset.Size = new System.Drawing.Size(188, 22);
            this.infoBoxOffset.TabIndex = 39;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxImage);
            this.panel1.Location = new System.Drawing.Point(17, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 448);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.PicBox_MouseEnter);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxImage.Location = new System.Drawing.Point(-2, -2);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(480, 448);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pictureBoxImage.MouseEnter += new System.EventHandler(this.PicBox_MouseEnter);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseMove);
            // 
            // groupFrame1
            // 
            this.groupFrame1.Controls.Add(this.radioButtonHires);
            this.groupFrame1.Controls.Add(this.radioButtonText);
            this.groupFrame1.Controls.Add(this.radioButtonCharSet);
            this.groupFrame1.Location = new System.Drawing.Point(6, 6);
            this.groupFrame1.Name = "groupFrame1";
            this.groupFrame1.Size = new System.Drawing.Size(200, 52);
            this.groupFrame1.TabIndex = 37;
            this.groupFrame1.TabStop = false;
            this.groupFrame1.Text = "Display Format";
            this.groupFrame1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame2
            // 
            this.groupFrame2.Controls.Add(this.infoBoxZoom);
            this.groupFrame2.Controls.Add(this.buttonResetZoom);
            this.groupFrame2.Controls.Add(this.buttonZoomIn);
            this.groupFrame2.Controls.Add(this.buttonZoomOut);
            this.groupFrame2.Location = new System.Drawing.Point(6, 64);
            this.groupFrame2.Name = "groupFrame2";
            this.groupFrame2.Size = new System.Drawing.Size(200, 82);
            this.groupFrame2.TabIndex = 38;
            this.groupFrame2.TabStop = false;
            this.groupFrame2.Text = "Zoom Options";
            this.groupFrame2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // infoBoxZoom
            // 
            this.infoBoxZoom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxZoom.ForeColor = System.Drawing.Color.Black;
            this.infoBoxZoom.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxZoom.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxZoom.Location = new System.Drawing.Point(6, 19);
            this.infoBoxZoom.Name = "infoBoxZoom";
            this.infoBoxZoom.Size = new System.Drawing.Size(188, 22);
            this.infoBoxZoom.TabIndex = 48;
            // 
            // groupFrame3
            // 
            this.groupFrame3.Controls.Add(this.infoBoxOffset);
            this.groupFrame3.Controls.Add(this.buttonDecOffset);
            this.groupFrame3.Controls.Add(this.buttonIncOffset);
            this.groupFrame3.Controls.Add(this.buttonResetOffset);
            this.groupFrame3.Location = new System.Drawing.Point(6, 152);
            this.groupFrame3.Name = "groupFrame3";
            this.groupFrame3.Size = new System.Drawing.Size(200, 82);
            this.groupFrame3.TabIndex = 39;
            this.groupFrame3.TabStop = false;
            this.groupFrame3.Text = "Offset Options";
            this.groupFrame3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame4
            // 
            this.groupFrame4.Controls.Add(this.infoBoxWidth);
            this.groupFrame4.Controls.Add(this.buttonResetWidth);
            this.groupFrame4.Controls.Add(this.buttonIncWidth);
            this.groupFrame4.Controls.Add(this.buttonDecWidth);
            this.groupFrame4.Location = new System.Drawing.Point(6, 240);
            this.groupFrame4.Name = "groupFrame4";
            this.groupFrame4.Size = new System.Drawing.Size(200, 82);
            this.groupFrame4.TabIndex = 40;
            this.groupFrame4.TabStop = false;
            this.groupFrame4.Text = "Display Width";
            this.groupFrame4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame5
            // 
            this.groupFrame5.Controls.Add(this.checkBoxBackground);
            this.groupFrame5.Controls.Add(this.checkBoxForeground);
            this.groupFrame5.Controls.Add(this.checkBoxOthers);
            this.groupFrame5.Location = new System.Drawing.Point(6, 328);
            this.groupFrame5.Name = "groupFrame5";
            this.groupFrame5.Size = new System.Drawing.Size(200, 100);
            this.groupFrame5.TabIndex = 41;
            this.groupFrame5.TabStop = false;
            this.groupFrame5.Text = "Show/Hide Attributes";
            this.groupFrame5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame6
            // 
            this.groupFrame6.Controls.Add(this.btnPrint);
            this.groupFrame6.Controls.Add(this.btnSave);
            this.groupFrame6.Location = new System.Drawing.Point(6, 434);
            this.groupFrame6.Name = "groupFrame6";
            this.groupFrame6.Size = new System.Drawing.Size(200, 52);
            this.groupFrame6.TabIndex = 42;
            this.groupFrame6.TabStop = false;
            this.groupFrame6.Text = "Output Options";
            this.groupFrame6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(212, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 480);
            this.panel2.TabIndex = 43;
            // 
            // DataViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupFrame6);
            this.Controls.Add(this.groupFrame5);
            this.Controls.Add(this.groupFrame4);
            this.Controls.Add(this.groupFrame3);
            this.Controls.Add(this.groupFrame2);
            this.Controls.Add(this.groupFrame1);
            this.MinimumSize = new System.Drawing.Size(554, 354);
            this.Name = "DataViewerControl";
            this.Size = new System.Drawing.Size(758, 493);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.groupFrame1.ResumeLayout(false);
            this.groupFrame2.ResumeLayout(false);
            this.groupFrame3.ResumeLayout(false);
            this.groupFrame4.ResumeLayout(false);
            this.groupFrame5.ResumeLayout(false);
            this.groupFrame5.PerformLayout();
            this.groupFrame6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.RadioButton radioButtonCharSet;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.RadioButton radioButtonHires;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonIncOffset;
        private System.Windows.Forms.Button buttonDecOffset;
        private System.Windows.Forms.Button buttonIncWidth;
        private System.Windows.Forms.Button buttonDecWidth;
        private System.Windows.Forms.Button buttonResetOffset;
        private System.Windows.Forms.Button buttonResetWidth;
        private System.Windows.Forms.Button buttonResetZoom;
        private System.Windows.Forms.CheckBox checkBoxForeground;
        private System.Windows.Forms.CheckBox checkBoxBackground;
        private System.Windows.Forms.CheckBox checkBoxOthers;
        private InfoBox.InfoBox infoBoxOffset;
        private InfoBox.InfoBox infoBoxWidth;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private GroupFrame.GroupFrame groupFrame1;
        private GroupFrame.GroupFrame groupFrame2;
        private InfoBox.InfoBox infoBoxZoom;
        private GroupFrame.GroupFrame groupFrame3;
        private GroupFrame.GroupFrame groupFrame4;
        private GroupFrame.GroupFrame groupFrame5;
        private GroupFrame.GroupFrame groupFrame6;
        private System.Windows.Forms.Panel panel2;
    }
}