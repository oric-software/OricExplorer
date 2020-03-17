namespace OricExplorer.Forms
{
    partial class frmDiskData
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
            this.lblNoOfSides = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblNoOfTracks = new System.Windows.Forms.Label();
            this.grpDiskInfo = new System.Windows.Forms.GroupBox();
            this.ibxSectorsPerTrack = new InfoBox.InfoBox();
            this.ibxNoOfTracks = new InfoBox.InfoBox();
            this.ibxNoOfSides = new InfoBox.InfoBox();
            this.ibxSignature = new InfoBox.InfoBox();
            this.lblSectorsPerTrack = new System.Windows.Forms.Label();
            this.hxbDiskData = new Be.Windows.Forms.HexBox();
            this.hxbSectorView = new Be.Windows.Forms.HexBox();
            this.tkbTracks = new System.Windows.Forms.TrackBar();
            this.tkbSectors = new System.Windows.Forms.TrackBar();
            this.grpRawDataViewer = new System.Windows.Forms.GroupBox();
            this.grpSectorView = new System.Windows.Forms.GroupBox();
            this.optSide1 = new System.Windows.Forms.RadioButton();
            this.optSide0 = new System.Windows.Forms.RadioButton();
            this.ibxInfo = new InfoBox.InfoBox();
            this.grpSector = new System.Windows.Forms.GroupBox();
            this.grpTrack = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpDiskInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSectors)).BeginInit();
            this.grpRawDataViewer.SuspendLayout();
            this.grpSectorView.SuspendLayout();
            this.grpSector.SuspendLayout();
            this.grpTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoOfSides
            // 
            this.lblNoOfSides.AutoSize = true;
            this.lblNoOfSides.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfSides.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNoOfSides.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoOfSides.Location = new System.Drawing.Point(34, 65);
            this.lblNoOfSides.Name = "lblNoOfSides";
            this.lblNoOfSides.Size = new System.Drawing.Size(72, 14);
            this.lblNoOfSides.TabIndex = 2;
            this.lblNoOfSides.Text = "No. of Sides";
            this.lblNoOfSides.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignature.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSignature.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSignature.Location = new System.Drawing.Point(40, 19);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(59, 14);
            this.lblSignature.TabIndex = 0;
            this.lblSignature.Text = "Signature";
            this.lblSignature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNoOfTracks
            // 
            this.lblNoOfTracks.AutoSize = true;
            this.lblNoOfTracks.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfTracks.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNoOfTracks.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNoOfTracks.Location = new System.Drawing.Point(27, 113);
            this.lblNoOfTracks.Name = "lblNoOfTracks";
            this.lblNoOfTracks.Size = new System.Drawing.Size(88, 14);
            this.lblNoOfTracks.TabIndex = 4;
            this.lblNoOfTracks.Text = "Tracks per Side";
            this.lblNoOfTracks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpDiskInfo
            // 
            this.grpDiskInfo.Controls.Add(this.ibxSectorsPerTrack);
            this.grpDiskInfo.Controls.Add(this.ibxNoOfTracks);
            this.grpDiskInfo.Controls.Add(this.ibxNoOfSides);
            this.grpDiskInfo.Controls.Add(this.ibxSignature);
            this.grpDiskInfo.Controls.Add(this.lblSectorsPerTrack);
            this.grpDiskInfo.Controls.Add(this.lblSignature);
            this.grpDiskInfo.Controls.Add(this.lblNoOfTracks);
            this.grpDiskInfo.Controls.Add(this.lblNoOfSides);
            this.grpDiskInfo.Location = new System.Drawing.Point(608, 12);
            this.grpDiskInfo.Name = "grpDiskInfo";
            this.grpDiskInfo.Size = new System.Drawing.Size(134, 285);
            this.grpDiskInfo.TabIndex = 1;
            this.grpDiskInfo.TabStop = false;
            this.grpDiskInfo.Text = "Disk Info";
            // 
            // ibxSectorsPerTrack
            // 
            this.ibxSectorsPerTrack.BackColor = System.Drawing.Color.Black;
            this.ibxSectorsPerTrack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSectorsPerTrack.ForeColor = System.Drawing.Color.Black;
            this.ibxSectorsPerTrack.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.ibxSectorsPerTrack.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.ibxSectorsPerTrack.Location = new System.Drawing.Point(9, 178);
            this.ibxSectorsPerTrack.Name = "ibxSectorsPerTrack";
            this.ibxSectorsPerTrack.Size = new System.Drawing.Size(117, 22);
            this.ibxSectorsPerTrack.TabIndex = 7;
            // 
            // ibxNoOfTracks
            // 
            this.ibxNoOfTracks.BackColor = System.Drawing.Color.Black;
            this.ibxNoOfTracks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxNoOfTracks.ForeColor = System.Drawing.Color.Black;
            this.ibxNoOfTracks.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.ibxNoOfTracks.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.ibxNoOfTracks.Location = new System.Drawing.Point(9, 130);
            this.ibxNoOfTracks.Name = "ibxNoOfTracks";
            this.ibxNoOfTracks.Size = new System.Drawing.Size(117, 22);
            this.ibxNoOfTracks.TabIndex = 5;
            // 
            // ibxNoOfSides
            // 
            this.ibxNoOfSides.BackColor = System.Drawing.Color.Black;
            this.ibxNoOfSides.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxNoOfSides.ForeColor = System.Drawing.Color.Black;
            this.ibxNoOfSides.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.ibxNoOfSides.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.ibxNoOfSides.Location = new System.Drawing.Point(9, 82);
            this.ibxNoOfSides.Name = "ibxNoOfSides";
            this.ibxNoOfSides.Size = new System.Drawing.Size(117, 22);
            this.ibxNoOfSides.TabIndex = 3;
            // 
            // ibxSignature
            // 
            this.ibxSignature.BackColor = System.Drawing.Color.Black;
            this.ibxSignature.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxSignature.ForeColor = System.Drawing.Color.Black;
            this.ibxSignature.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.ibxSignature.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.ibxSignature.Location = new System.Drawing.Point(9, 36);
            this.ibxSignature.Name = "ibxSignature";
            this.ibxSignature.Size = new System.Drawing.Size(117, 22);
            this.ibxSignature.TabIndex = 1;
            // 
            // lblSectorsPerTrack
            // 
            this.lblSectorsPerTrack.AutoSize = true;
            this.lblSectorsPerTrack.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectorsPerTrack.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSectorsPerTrack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSectorsPerTrack.Location = new System.Drawing.Point(22, 161);
            this.lblSectorsPerTrack.Name = "lblSectorsPerTrack";
            this.lblSectorsPerTrack.Size = new System.Drawing.Size(97, 14);
            this.lblSectorsPerTrack.TabIndex = 6;
            this.lblSectorsPerTrack.Text = "Sectors per Track";
            this.lblSectorsPerTrack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hxbDiskData
            // 
            this.hxbDiskData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hxbDiskData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hxbDiskData.ColumnInfoVisible = true;
            this.hxbDiskData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hxbDiskData.ForeColor = System.Drawing.Color.White;
            this.hxbDiskData.InfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(174)))), ((int)(((byte)(13)))));
            this.hxbDiskData.LineInfoPrefix = "$";
            this.hxbDiskData.LineInfoVisible = true;
            this.hxbDiskData.Location = new System.Drawing.Point(8, 19);
            this.hxbDiskData.Name = "hxbDiskData";
            this.hxbDiskData.ReadOnly = true;
            this.hxbDiskData.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hxbDiskData.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxbDiskData.Size = new System.Drawing.Size(581, 260);
            this.hxbDiskData.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hxbDiskData.StringViewVisible = true;
            this.hxbDiskData.TabIndex = 0;
            this.hxbDiskData.UseFixedBytesPerLine = true;
            this.hxbDiskData.VScrollBarVisible = true;
            // 
            // hxbSectorView
            // 
            this.hxbSectorView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hxbSectorView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hxbSectorView.ColumnInfoVisible = true;
            this.hxbSectorView.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hxbSectorView.ForeColor = System.Drawing.Color.White;
            this.hxbSectorView.InfoForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(174)))), ((int)(((byte)(13)))));
            this.hxbSectorView.LineInfoPrefix = "$";
            this.hxbSectorView.LineInfoVisible = true;
            this.hxbSectorView.Location = new System.Drawing.Point(8, 47);
            this.hxbSectorView.Name = "hxbSectorView";
            this.hxbSectorView.ReadOnly = true;
            this.hxbSectorView.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hxbSectorView.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hxbSectorView.Size = new System.Drawing.Size(581, 260);
            this.hxbSectorView.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hxbSectorView.StringViewVisible = true;
            this.hxbSectorView.TabIndex = 1;
            this.hxbSectorView.UseFixedBytesPerLine = true;
            // 
            // tkbTracks
            // 
            this.tkbTracks.Location = new System.Drawing.Point(9, 19);
            this.tkbTracks.Name = "tkbTracks";
            this.tkbTracks.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbTracks.Size = new System.Drawing.Size(45, 237);
            this.tkbTracks.TabIndex = 0;
            this.tkbTracks.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tkbTracks.Scroll += new System.EventHandler(this.tkbTracks_Scroll);
            // 
            // tkbSectors
            // 
            this.tkbSectors.LargeChange = 1;
            this.tkbSectors.Location = new System.Drawing.Point(9, 19);
            this.tkbSectors.Name = "tkbSectors";
            this.tkbSectors.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbSectors.Size = new System.Drawing.Size(45, 237);
            this.tkbSectors.TabIndex = 0;
            this.tkbSectors.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tkbSectors.Scroll += new System.EventHandler(this.tkbSectors_Scroll);
            // 
            // grpRawDataViewer
            // 
            this.grpRawDataViewer.Controls.Add(this.hxbDiskData);
            this.grpRawDataViewer.Location = new System.Drawing.Point(6, 12);
            this.grpRawDataViewer.Name = "grpRawDataViewer";
            this.grpRawDataViewer.Size = new System.Drawing.Size(596, 285);
            this.grpRawDataViewer.TabIndex = 0;
            this.grpRawDataViewer.TabStop = false;
            this.grpRawDataViewer.Text = "Raw Data View";
            // 
            // grpSectorView
            // 
            this.grpSectorView.Controls.Add(this.optSide1);
            this.grpSectorView.Controls.Add(this.optSide0);
            this.grpSectorView.Controls.Add(this.ibxInfo);
            this.grpSectorView.Controls.Add(this.grpSector);
            this.grpSectorView.Controls.Add(this.hxbSectorView);
            this.grpSectorView.Controls.Add(this.grpTrack);
            this.grpSectorView.Location = new System.Drawing.Point(6, 303);
            this.grpSectorView.Name = "grpSectorView";
            this.grpSectorView.Size = new System.Drawing.Size(736, 316);
            this.grpSectorView.TabIndex = 2;
            this.grpSectorView.TabStop = false;
            this.grpSectorView.Text = "Sector View";
            // 
            // optSide1
            // 
            this.optSide1.AutoSize = true;
            this.optSide1.Location = new System.Drawing.Point(673, 24);
            this.optSide1.Name = "optSide1";
            this.optSide1.Size = new System.Drawing.Size(55, 17);
            this.optSide1.TabIndex = 4;
            this.optSide1.TabStop = true;
            this.optSide1.Text = "Side 1";
            this.optSide1.UseVisualStyleBackColor = true;
            this.optSide1.CheckedChanged += new System.EventHandler(this.optSide1_CheckedChanged);
            // 
            // optSide0
            // 
            this.optSide0.AutoSize = true;
            this.optSide0.Location = new System.Drawing.Point(604, 24);
            this.optSide0.Name = "optSide0";
            this.optSide0.Size = new System.Drawing.Size(55, 17);
            this.optSide0.TabIndex = 2;
            this.optSide0.TabStop = true;
            this.optSide0.Text = "Side 0";
            this.optSide0.UseVisualStyleBackColor = true;
            this.optSide0.CheckedChanged += new System.EventHandler(this.optSide0_CheckedChanged);
            // 
            // ibxInfo
            // 
            this.ibxInfo.BackColor = System.Drawing.Color.Black;
            this.ibxInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxInfo.ForeColor = System.Drawing.Color.Black;
            this.ibxInfo.GradientEndColour = System.Drawing.SystemColors.ControlLight;
            this.ibxInfo.GradientStartColour = System.Drawing.SystemColors.ControlLight;
            this.ibxInfo.Location = new System.Drawing.Point(8, 19);
            this.ibxInfo.Name = "ibxInfo";
            this.ibxInfo.Size = new System.Drawing.Size(581, 22);
            this.ibxInfo.TabIndex = 0;
            this.ibxInfo.Text = "Sector Info";
            // 
            // grpSector
            // 
            this.grpSector.Controls.Add(this.tkbSectors);
            this.grpSector.Location = new System.Drawing.Point(665, 47);
            this.grpSector.Name = "grpSector";
            this.grpSector.Size = new System.Drawing.Size(63, 262);
            this.grpSector.TabIndex = 5;
            this.grpSector.TabStop = false;
            this.grpSector.Text = "Sector";
            // 
            // grpTrack
            // 
            this.grpTrack.Controls.Add(this.tkbTracks);
            this.grpTrack.Location = new System.Drawing.Point(596, 47);
            this.grpTrack.Name = "grpTrack";
            this.grpTrack.Size = new System.Drawing.Size(63, 262);
            this.grpTrack.TabIndex = 3;
            this.grpTrack.TabStop = false;
            this.grpTrack.Text = "Track";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(667, 626);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDiskData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(750, 656);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpSectorView);
            this.Controls.Add(this.grpRawDataViewer);
            this.Controls.Add(this.grpDiskInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiskData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disk Data";
            this.Load += new System.EventHandler(this.frmDiskData_Load);
            this.grpDiskInfo.ResumeLayout(false);
            this.grpDiskInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbSectors)).EndInit();
            this.grpRawDataViewer.ResumeLayout(false);
            this.grpSectorView.ResumeLayout(false);
            this.grpSectorView.PerformLayout();
            this.grpSector.ResumeLayout(false);
            this.grpSector.PerformLayout();
            this.grpTrack.ResumeLayout(false);
            this.grpTrack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNoOfSides;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblNoOfTracks;
        private System.Windows.Forms.GroupBox grpDiskInfo;
        public Be.Windows.Forms.HexBox hxbDiskData;
        public Be.Windows.Forms.HexBox hxbSectorView;
        private System.Windows.Forms.TrackBar tkbTracks;
        private System.Windows.Forms.TrackBar tkbSectors;
        private System.Windows.Forms.GroupBox grpRawDataViewer;
        private System.Windows.Forms.GroupBox grpSectorView;
        private System.Windows.Forms.GroupBox grpSector;
        private System.Windows.Forms.GroupBox grpTrack;
        private InfoBox.InfoBox ibxInfo;
        private System.Windows.Forms.Label lblSectorsPerTrack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton optSide1;
        private System.Windows.Forms.RadioButton optSide0;
        private InfoBox.InfoBox ibxSectorsPerTrack;
        private InfoBox.InfoBox ibxNoOfTracks;
        private InfoBox.InfoBox ibxNoOfSides;
        private InfoBox.InfoBox ibxSignature;
    }
}