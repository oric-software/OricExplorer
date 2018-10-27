namespace OricExplorer.Forms
{
    partial class DiskDataForm
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
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoBoxSectorsPerTrack = new InfoBox.InfoBox();
            this.infoBoxNoOfTracks = new InfoBox.InfoBox();
            this.infoBoxNoOfSides = new InfoBox.InfoBox();
            this.infoBoxSignature = new InfoBox.InfoBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hexBoxDiskData = new Be.Windows.Forms.HexBox();
            this.hexBoxSectorView = new Be.Windows.Forms.HexBox();
            this.trackBarTracks = new System.Windows.Forms.TrackBar();
            this.trackBarSectors = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.infoBoxInfo = new InfoBox.InfoBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(34, 65);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 14);
            this.label16.TabIndex = 53;
            this.label16.Text = "No. of Sides";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(40, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 43;
            this.label6.Text = "Signature";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(27, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 14);
            this.label14.TabIndex = 51;
            this.label14.Text = "Tracks per Side";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoBoxSectorsPerTrack);
            this.groupBox1.Controls.Add(this.infoBoxNoOfTracks);
            this.groupBox1.Controls.Add(this.infoBoxNoOfSides);
            this.groupBox1.Controls.Add(this.infoBoxSignature);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(608, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 285);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disk Info";
            // 
            // infoBoxSectorsPerTrack
            // 
            this.infoBoxSectorsPerTrack.BackColor = System.Drawing.Color.Black;
            this.infoBoxSectorsPerTrack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSectorsPerTrack.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSectorsPerTrack.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxSectorsPerTrack.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxSectorsPerTrack.Location = new System.Drawing.Point(9, 178);
            this.infoBoxSectorsPerTrack.Name = "infoBoxSectorsPerTrack";
            this.infoBoxSectorsPerTrack.Size = new System.Drawing.Size(117, 22);
            this.infoBoxSectorsPerTrack.TabIndex = 91;
            // 
            // infoBoxNoOfTracks
            // 
            this.infoBoxNoOfTracks.BackColor = System.Drawing.Color.Black;
            this.infoBoxNoOfTracks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxNoOfTracks.ForeColor = System.Drawing.Color.Black;
            this.infoBoxNoOfTracks.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxNoOfTracks.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxNoOfTracks.Location = new System.Drawing.Point(9, 130);
            this.infoBoxNoOfTracks.Name = "infoBoxNoOfTracks";
            this.infoBoxNoOfTracks.Size = new System.Drawing.Size(117, 22);
            this.infoBoxNoOfTracks.TabIndex = 90;
            // 
            // infoBoxNoOfSides
            // 
            this.infoBoxNoOfSides.BackColor = System.Drawing.Color.Black;
            this.infoBoxNoOfSides.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxNoOfSides.ForeColor = System.Drawing.Color.Black;
            this.infoBoxNoOfSides.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxNoOfSides.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxNoOfSides.Location = new System.Drawing.Point(9, 82);
            this.infoBoxNoOfSides.Name = "infoBoxNoOfSides";
            this.infoBoxNoOfSides.Size = new System.Drawing.Size(117, 22);
            this.infoBoxNoOfSides.TabIndex = 89;
            // 
            // infoBoxSignature
            // 
            this.infoBoxSignature.BackColor = System.Drawing.Color.Black;
            this.infoBoxSignature.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxSignature.ForeColor = System.Drawing.Color.Black;
            this.infoBoxSignature.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxSignature.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxSignature.Location = new System.Drawing.Point(9, 36);
            this.infoBoxSignature.Name = "infoBoxSignature";
            this.infoBoxSignature.Size = new System.Drawing.Size(117, 22);
            this.infoBoxSignature.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(22, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 14);
            this.label2.TabIndex = 55;
            this.label2.Text = "Sectors per Track";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hexBoxDiskData
            // 
            this.hexBoxDiskData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hexBoxDiskData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hexBoxDiskData.ColumnInfoVisible = true;
            this.hexBoxDiskData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBoxDiskData.ForeColor = System.Drawing.Color.White;
            this.hexBoxDiskData.InfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(174)))), ((int)(((byte)(13)))));
            this.hexBoxDiskData.LineInfoPrefix = "$";
            this.hexBoxDiskData.LineInfoVisible = true;
            this.hexBoxDiskData.Location = new System.Drawing.Point(8, 19);
            this.hexBoxDiskData.Name = "hexBoxDiskData";
            this.hexBoxDiskData.ReadOnly = true;
            this.hexBoxDiskData.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hexBoxDiskData.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxDiskData.ShadowSelectionVisible = false;
            this.hexBoxDiskData.Size = new System.Drawing.Size(581, 260);
            this.hexBoxDiskData.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hexBoxDiskData.StringViewVisible = true;
            this.hexBoxDiskData.TabIndex = 76;
            this.hexBoxDiskData.UseFixedBytesPerLine = true;
            this.hexBoxDiskData.VScrollBarVisible = true;
            // 
            // hexBoxSectorView
            // 
            this.hexBoxSectorView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hexBoxSectorView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hexBoxSectorView.ColumnInfoVisible = true;
            this.hexBoxSectorView.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBoxSectorView.ForeColor = System.Drawing.Color.White;
            this.hexBoxSectorView.InfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(174)))), ((int)(((byte)(13)))));
            this.hexBoxSectorView.LineInfoPrefix = "$";
            this.hexBoxSectorView.LineInfoVisible = true;
            this.hexBoxSectorView.Location = new System.Drawing.Point(8, 47);
            this.hexBoxSectorView.Name = "hexBoxSectorView";
            this.hexBoxSectorView.ReadOnly = true;
            this.hexBoxSectorView.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hexBoxSectorView.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxSectorView.ShadowSelectionVisible = false;
            this.hexBoxSectorView.Size = new System.Drawing.Size(581, 260);
            this.hexBoxSectorView.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hexBoxSectorView.StringViewVisible = true;
            this.hexBoxSectorView.TabIndex = 78;
            this.hexBoxSectorView.UseFixedBytesPerLine = true;
            // 
            // trackBarTracks
            // 
            this.trackBarTracks.Location = new System.Drawing.Point(9, 19);
            this.trackBarTracks.Name = "trackBarTracks";
            this.trackBarTracks.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTracks.Size = new System.Drawing.Size(45, 242);
            this.trackBarTracks.TabIndex = 79;
            this.trackBarTracks.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarTracks.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarSectors
            // 
            this.trackBarSectors.LargeChange = 1;
            this.trackBarSectors.Location = new System.Drawing.Point(9, 19);
            this.trackBarSectors.Name = "trackBarSectors";
            this.trackBarSectors.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarSectors.Size = new System.Drawing.Size(45, 242);
            this.trackBarSectors.TabIndex = 80;
            this.trackBarSectors.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSectors.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hexBoxDiskData);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 285);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Raw Data View";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.infoBoxInfo);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.hexBoxSectorView);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(6, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 316);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sector View";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(673, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 87;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Side 1";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(604, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 86;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Side 0";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // infoBoxInfo
            // 
            this.infoBoxInfo.BackColor = System.Drawing.Color.Black;
            this.infoBoxInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxInfo.ForeColor = System.Drawing.Color.Black;
            this.infoBoxInfo.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxInfo.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.infoBoxInfo.Location = new System.Drawing.Point(8, 19);
            this.infoBoxInfo.Name = "infoBoxInfo";
            this.infoBoxInfo.Size = new System.Drawing.Size(581, 22);
            this.infoBoxInfo.TabIndex = 85;
            this.infoBoxInfo.Text = "Sector Info";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.trackBarSectors);
            this.groupBox5.Location = new System.Drawing.Point(665, 47);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(63, 262);
            this.groupBox5.TabIndex = 84;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sector";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBarTracks);
            this.groupBox4.Location = new System.Drawing.Point(596, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(63, 262);
            this.groupBox4.TabIndex = 83;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Track";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(667, 626);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 83;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DiskDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 656);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiskDataForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disk Data";
            this.Load += new System.EventHandler(this.DiskDataForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        public Be.Windows.Forms.HexBox hexBoxDiskData;
        public Be.Windows.Forms.HexBox hexBoxSectorView;
        private System.Windows.Forms.TrackBar trackBarTracks;
        private System.Windows.Forms.TrackBar trackBarSectors;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private InfoBox.InfoBox infoBoxInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private InfoBox.InfoBox infoBoxSectorsPerTrack;
        private InfoBox.InfoBox infoBoxNoOfTracks;
        private InfoBox.InfoBox infoBoxNoOfSides;
        private InfoBox.InfoBox infoBoxSignature;
    }
}