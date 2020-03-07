
namespace OricExplorer.Forms
{
    partial class FileScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileScanForm));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.percentageBarProgress = new PercentageBar.PercentageBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelMain = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.horizontalDivider1 = new HorizontalDivider.HorizontalDivider();
            this.horizontalDivider2 = new HorizontalDivider.HorizontalDivider();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(123, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // percentageBarProgress
            // 
            this.percentageBarProgress.Location = new System.Drawing.Point(10, 86);
            this.percentageBarProgress.Name = "percentageBarProgress";
            this.percentageBarProgress.PercentageBarColour = System.Drawing.Color.Lime;
            this.percentageBarProgress.Size = new System.Drawing.Size(485, 28);
            this.percentageBarProgress.TabIndex = 36;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoEllipsis = true;
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(137, 46);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(162, 20);
            this.labelStatus.TabIndex = 33;
            this.labelStatus.Text = "Scanning tape folders...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.BackColor = System.Drawing.Color.Transparent;
            this.labelMain.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.ForeColor = System.Drawing.Color.White;
            this.labelMain.Location = new System.Drawing.Point(135, 8);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(163, 32);
            this.labelMain.TabIndex = 0;
            this.labelMain.Text = "Please wait...";
            this.labelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFile
            // 
            this.labelFile.AutoEllipsis = true;
            this.labelFile.BackColor = System.Drawing.Color.Transparent;
            this.labelFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFile.ForeColor = System.Drawing.Color.Black;
            this.labelFile.Location = new System.Drawing.Point(6, 128);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(493, 20);
            this.labelFile.TabIndex = 37;
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.labelMain);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 75);
            this.panel1.TabIndex = 38;
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider1.Location = new System.Drawing.Point(0, 75);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(505, 2);
            this.horizontalDivider1.TabIndex = 39;
            // 
            // horizontalDivider2
            // 
            this.horizontalDivider2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider2.Location = new System.Drawing.Point(0, 124);
            this.horizontalDivider2.Name = "horizontalDivider2";
            this.horizontalDivider2.Size = new System.Drawing.Size(505, 2);
            this.horizontalDivider2.TabIndex = 40;
            // 
            // FileScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(505, 151);
            this.Controls.Add(this.horizontalDivider2);
            this.Controls.Add(this.horizontalDivider1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.percentageBarProgress);
            this.Controls.Add(this.labelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileScanForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.FileScanForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelStatus;
        private PercentageBar.PercentageBar percentageBarProgress;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Panel panel1;
        private HorizontalDivider.HorizontalDivider horizontalDivider1;
        private HorizontalDivider.HorizontalDivider horizontalDivider2;
    }
}