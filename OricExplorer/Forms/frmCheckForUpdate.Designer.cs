namespace OricExplorer.Forms
{
    partial class frmCheckForUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckForUpdate));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ibxDetails = new InfoBox.InfoBox();
            this.ibxCurrentVersion = new InfoBox.InfoBox();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblAvailableVersion = new System.Windows.Forms.Label();
            this.ibxAvailableVersion = new InfoBox.InfoBox();
            this.grpVersions = new GroupFrame.GroupFrame();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpVersions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(181, 216);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(272, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(10, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(140, 72);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 11;
            this.picLogo.TabStop = false;
            // 
            // ibxDetails
            // 
            this.ibxDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxDetails.GradientEndColour = System.Drawing.Color.Transparent;
            this.ibxDetails.GradientStartColour = System.Drawing.Color.Transparent;
            this.ibxDetails.Location = new System.Drawing.Point(12, 93);
            this.ibxDetails.Name = "ibxDetails";
            this.ibxDetails.Size = new System.Drawing.Size(345, 116);
            this.ibxDetails.TabIndex = 3;
            this.ibxDetails.Text = "Checking for updates.\r\n\r\nPlease wait...";
            this.ibxDetails.TextHorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.ibxDetails.TextVerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ibxCurrentVersion
            // 
            this.ibxCurrentVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxCurrentVersion.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCurrentVersion.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCurrentVersion.Location = new System.Drawing.Point(107, 16);
            this.ibxCurrentVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ibxCurrentVersion.Name = "ibxCurrentVersion";
            this.ibxCurrentVersion.Size = new System.Drawing.Size(82, 20);
            this.ibxCurrentVersion.TabIndex = 1;
            // 
            // lblCurrentVersion
            // 
            this.lblCurrentVersion.AutoSize = true;
            this.lblCurrentVersion.Location = new System.Drawing.Point(17, 20);
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            this.lblCurrentVersion.Size = new System.Drawing.Size(85, 13);
            this.lblCurrentVersion.TabIndex = 0;
            this.lblCurrentVersion.Text = "Current Version :";
            // 
            // lblAvailableVersion
            // 
            this.lblAvailableVersion.AutoSize = true;
            this.lblAvailableVersion.Location = new System.Drawing.Point(8, 50);
            this.lblAvailableVersion.Name = "lblAvailableVersion";
            this.lblAvailableVersion.Size = new System.Drawing.Size(94, 13);
            this.lblAvailableVersion.TabIndex = 2;
            this.lblAvailableVersion.Text = "Available Version :";
            // 
            // ibxAvailableVersion
            // 
            this.ibxAvailableVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxAvailableVersion.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAvailableVersion.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAvailableVersion.Location = new System.Drawing.Point(107, 46);
            this.ibxAvailableVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ibxAvailableVersion.Name = "ibxAvailableVersion";
            this.ibxAvailableVersion.Size = new System.Drawing.Size(82, 20);
            this.ibxAvailableVersion.TabIndex = 3;
            // 
            // grpVersions
            // 
            this.grpVersions.Controls.Add(this.lblCurrentVersion);
            this.grpVersions.Controls.Add(this.ibxAvailableVersion);
            this.grpVersions.Controls.Add(this.ibxCurrentVersion);
            this.grpVersions.Controls.Add(this.lblAvailableVersion);
            this.grpVersions.Location = new System.Drawing.Point(156, 10);
            this.grpVersions.Name = "grpVersions";
            this.grpVersions.Size = new System.Drawing.Size(201, 77);
            this.grpVersions.TabIndex = 2;
            this.grpVersions.TabStop = false;
            // 
            // frmCheckForUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(367, 246);
            this.Controls.Add(this.grpVersions);
            this.Controls.Add(this.ibxDetails);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckForUpdate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Notification";
            this.Shown += new System.EventHandler(this.frmCheckForUpdate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpVersions.ResumeLayout(false);
            this.grpVersions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox picLogo;
        private InfoBox.InfoBox ibxDetails;
        private InfoBox.InfoBox ibxCurrentVersion;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label lblAvailableVersion;
        private InfoBox.InfoBox ibxAvailableVersion;
        private GroupFrame.GroupFrame grpVersions;
    }
}