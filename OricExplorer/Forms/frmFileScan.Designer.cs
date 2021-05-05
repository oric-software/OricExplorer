
using OricExplorer.User_Controls;

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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.ctlProgressBar = new OricExplorer.User_Controls.ctlProgressBar();
            this.pnlBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoEllipsis = true;
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(7, 51);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(55, 13);
            this.lblInfo.TabIndex = 33;
            this.lblInfo.Text = "Scanning";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFile
            // 
            this.lblFile.AutoEllipsis = true;
            this.lblFile.BackColor = System.Drawing.Color.Transparent;
            this.lblFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblFile.Location = new System.Drawing.Point(7, 89);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(412, 13);
            this.lblFile.TabIndex = 37;
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoEllipsis = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.White;
            this.lblProgress.Location = new System.Drawing.Point(261, 51);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(158, 13);
            this.lblProgress.TabIndex = 39;
            this.lblProgress.Text = "0 of 0 (0.0%)";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.pnlBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackground.Controls.Add(this.lblCancel);
            this.pnlBackground.Controls.Add(this.lblProgramName);
            this.pnlBackground.Controls.Add(this.lblInfo);
            this.pnlBackground.Controls.Add(this.lblProgress);
            this.pnlBackground.Controls.Add(this.lblFile);
            this.pnlBackground.Controls.Add(this.ctlProgressBar);
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "panel1";
            this.pnlBackground.Size = new System.Drawing.Size(429, 110);
            this.pnlBackground.TabIndex = 40;
            // 
            // lblCancel
            // 
            this.lblCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCancel.Image = ((System.Drawing.Image)(resources.GetObject("lblCancel.Image")));
            this.lblCancel.Location = new System.Drawing.Point(408, 74);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(11, 11);
            this.lblCancel.TabIndex = 41;
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // darkLabel1
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramName.ForeColor = System.Drawing.Color.White;
            this.lblProgramName.Location = new System.Drawing.Point(4, 4);
            this.lblProgramName.Name = "darkLabel1";
            this.lblProgramName.Size = new System.Drawing.Size(95, 20);
            this.lblProgramName.TabIndex = 41;
            this.lblProgramName.Text = "Oric Explorer";
            // 
            // ctlProgressBar
            // 
            this.ctlProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ctlProgressBar.Location = new System.Drawing.Point(9, 77);
            this.ctlProgressBar.Name = "ctlProgressBar";
            this.ctlProgressBar.PercentageBarColour = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.ctlProgressBar.Size = new System.Drawing.Size(391, 4);
            this.ctlProgressBar.TabIndex = 36;
            // 
            // frmFileScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(429, 110);
            this.Controls.Add(this.pnlBackground);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileScan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.frmFileScan_Shown);
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblInfo;
        private ctlProgressBar ctlProgressBar;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblProgramName;
    }
}