namespace OricExplorer.Forms
{
    partial class CheckForUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForUpdateForm));
            this.buttonWebsite = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.infoBoxDetails = new InfoBox.InfoBox();
            this.infoBoxCurrentVersion = new InfoBox.InfoBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infoBoxAvailableVersion = new InfoBox.InfoBox();
            this.groupFrame1 = new GroupFrame.GroupFrame();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWebsite
            // 
            this.buttonWebsite.Location = new System.Drawing.Point(181, 216);
            this.buttonWebsite.Name = "buttonWebsite";
            this.buttonWebsite.Size = new System.Drawing.Size(85, 23);
            this.buttonWebsite.TabIndex = 8;
            this.buttonWebsite.Text = "Yes";
            this.buttonWebsite.UseVisualStyleBackColor = true;
            this.buttonWebsite.Click += new System.EventHandler(this.buttonWebsite_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(272, 216);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "No";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // infoBoxDetails
            // 
            this.infoBoxDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxDetails.GradientEndColour = System.Drawing.Color.Transparent;
            this.infoBoxDetails.GradientStartColour = System.Drawing.Color.Transparent;
            this.infoBoxDetails.Location = new System.Drawing.Point(12, 93);
            this.infoBoxDetails.Name = "infoBoxDetails";
            this.infoBoxDetails.Size = new System.Drawing.Size(345, 116);
            this.infoBoxDetails.TabIndex = 12;
            this.infoBoxDetails.Text = "Checking for updates.\r\n\r\nPlease wait...";
            this.infoBoxDetails.TextHorizontalAlignment = System.Drawing.StringAlignment.Near;
            this.infoBoxDetails.TextVerticalAlignment = System.Drawing.StringAlignment.Near;
            // 
            // infoBoxCurrentVersion
            // 
            this.infoBoxCurrentVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxCurrentVersion.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCurrentVersion.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCurrentVersion.Location = new System.Drawing.Point(107, 16);
            this.infoBoxCurrentVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoBoxCurrentVersion.Name = "infoBoxCurrentVersion";
            this.infoBoxCurrentVersion.Size = new System.Drawing.Size(82, 20);
            this.infoBoxCurrentVersion.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current Version :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Available Version :";
            // 
            // infoBoxAvailableVersion
            // 
            this.infoBoxAvailableVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxAvailableVersion.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAvailableVersion.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAvailableVersion.Location = new System.Drawing.Point(107, 46);
            this.infoBoxAvailableVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoBoxAvailableVersion.Name = "infoBoxAvailableVersion";
            this.infoBoxAvailableVersion.Size = new System.Drawing.Size(82, 20);
            this.infoBoxAvailableVersion.TabIndex = 17;
            // 
            // groupFrame1
            // 
            this.groupFrame1.Controls.Add(this.label1);
            this.groupFrame1.Controls.Add(this.infoBoxAvailableVersion);
            this.groupFrame1.Controls.Add(this.infoBoxCurrentVersion);
            this.groupFrame1.Controls.Add(this.label2);
            this.groupFrame1.Location = new System.Drawing.Point(156, 10);
            this.groupFrame1.Name = "groupFrame1";
            this.groupFrame1.Size = new System.Drawing.Size(201, 77);
            this.groupFrame1.TabIndex = 18;
            this.groupFrame1.TabStop = false;
            // 
            // CheckForUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 246);
            this.Controls.Add(this.groupFrame1);
            this.Controls.Add(this.infoBoxDetails);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonWebsite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckForUpdateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Notification";
            this.Shown += new System.EventHandler(this.CheckForUpdateForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupFrame1.ResumeLayout(false);
            this.groupFrame1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonWebsite;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private InfoBox.InfoBox infoBoxDetails;
        private InfoBox.InfoBox infoBoxCurrentVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private InfoBox.InfoBox infoBoxAvailableVersion;
        private GroupFrame.GroupFrame groupFrame1;
    }
}