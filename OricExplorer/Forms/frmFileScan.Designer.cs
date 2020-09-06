
namespace OricExplorer.Forms
{
    partial class frmFileScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileScan));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pbProgress = new PercentageBar.PercentageBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.panHeader = new System.Windows.Forms.Panel();
            this.hdv1 = new HorizontalDivider.HorizontalDivider();
            this.hdv2 = new HorizontalDivider.HorizontalDivider();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(123, 68);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 33;
            this.picLogo.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(10, 86);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.PercentageBarColour = System.Drawing.Color.Lime;
            this.pbProgress.Size = new System.Drawing.Size(485, 28);
            this.pbProgress.TabIndex = 36;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(137, 46);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(162, 20);
            this.lblInfo.TabIndex = 33;
            this.lblInfo.Text = "Scanning tape folders...";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.BackColor = System.Drawing.Color.Transparent;
            this.lblPleaseWait.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.White;
            this.lblPleaseWait.Location = new System.Drawing.Point(135, 8);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(163, 32);
            this.lblPleaseWait.TabIndex = 0;
            this.lblPleaseWait.Text = "Please wait...";
            this.lblPleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFile
            // 
            this.lblFile.AutoEllipsis = true;
            this.lblFile.BackColor = System.Drawing.Color.Transparent;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.ForeColor = System.Drawing.Color.Black;
            this.lblFile.Location = new System.Drawing.Point(6, 128);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(493, 20);
            this.lblFile.TabIndex = 37;
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panHeader
            // 
            this.panHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panHeader.Controls.Add(this.picLogo);
            this.panHeader.Controls.Add(this.lblPleaseWait);
            this.panHeader.Controls.Add(this.lblInfo);
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(506, 75);
            this.panHeader.TabIndex = 38;
            // 
            // hdv1
            // 
            this.hdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hdv1.Location = new System.Drawing.Point(0, 75);
            this.hdv1.Name = "hdv1";
            this.hdv1.Size = new System.Drawing.Size(505, 2);
            this.hdv1.TabIndex = 39;
            // 
            // hdv2
            // 
            this.hdv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hdv2.Location = new System.Drawing.Point(0, 124);
            this.hdv2.Name = "hdv2";
            this.hdv2.Size = new System.Drawing.Size(505, 2);
            this.hdv2.TabIndex = 40;
            // 
            // frmFileScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(505, 151);
            this.Controls.Add(this.hdv2);
            this.Controls.Add(this.hdv1);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileScan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.frmFileScan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblInfo;
        private PercentageBar.PercentageBar pbProgress;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Panel panHeader;
        private HorizontalDivider.HorizontalDivider hdv1;
        private HorizontalDivider.HorizontalDivider hdv2;
    }
}