namespace OricExplorer
{
    partial class frmAboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAboutBox));
            this.btnOK = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lklWebsite = new System.Windows.Forms.LinkLabel();
            this.lklContact = new System.Windows.Forms.LinkLabel();
            this.grpContributors = new GroupFrame.GroupFrame();
            this.lblContributors = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.grpContributors.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(160, 418);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 21);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(69, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(257, 138);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 30;
            this.picLogo.TabStop = false;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(93, 154);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(209, 34);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "Oric Disk and Tape Management\r\n© 2020 by Scott Davies";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lklWebsite
            // 
            this.lklWebsite.AutoSize = true;
            this.lklWebsite.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklWebsite.Location = new System.Drawing.Point(130, 204);
            this.lklWebsite.Name = "lklWebsite";
            this.lklWebsite.Size = new System.Drawing.Size(135, 17);
            this.lklWebsite.TabIndex = 1;
            this.lklWebsite.TabStop = true;
            this.lklWebsite.Text = "Oric Explorer Website";
            this.lklWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lklWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklWebsiteAndContact_LinkClicked);
            // 
            // lklContact
            // 
            this.lklContact.AutoSize = true;
            this.lklContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklContact.Location = new System.Drawing.Point(113, 225);
            this.lklContact.Name = "lklContact";
            this.lklContact.Size = new System.Drawing.Size(168, 17);
            this.lklContact.TabIndex = 2;
            this.lklContact.TabStop = true;
            this.lklContact.Text = "Oric Explorer Email Contact";
            this.lklContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklWebsiteAndContact_LinkClicked);
            // 
            // grpContributors
            // 
            this.grpContributors.Controls.Add(this.lblContributors);
            this.grpContributors.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpContributors.Location = new System.Drawing.Point(7, 260);
            this.grpContributors.Name = "grpContributors";
            this.grpContributors.Size = new System.Drawing.Size(381, 151);
            this.grpContributors.TabIndex = 3;
            this.grpContributors.TabStop = false;
            this.grpContributors.Text = "Contributors";
            this.grpContributors.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblContributors
            // 
            this.lblContributors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContributors.Location = new System.Drawing.Point(6, 25);
            this.lblContributors.Name = "lblContributors";
            this.lblContributors.Size = new System.Drawing.Size(368, 119);
            this.lblContributors.TabIndex = 0;
            this.lblContributors.Text = "Damien \"dipi\" PONNELLE (https://www.dipisoft.com/)\r\n\r\n< add your name here >";
            // 
            // frmAboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(395, 445);
            this.Controls.Add(this.grpContributors);
            this.Controls.Add(this.lklContact);
            this.Controls.Add(this.lklWebsite);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Oric Explorer";
            this.Load += new System.EventHandler(this.frmAboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.grpContributors.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.LinkLabel lklWebsite;
        private System.Windows.Forms.LinkLabel lklContact;
        private GroupFrame.GroupFrame grpContributors;
        private System.Windows.Forms.Label lblContributors;
    }
}
