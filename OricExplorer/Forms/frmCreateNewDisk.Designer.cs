namespace OricExplorer.Forms
{
    partial class frmCreateNewDisk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNewDisk));
            this.lblOricDiskCreator = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.picDisk = new System.Windows.Forms.PictureBox();
            this.lblDiskName = new System.Windows.Forms.Label();
            this.txtDiskName = new System.Windows.Forms.TextBox();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkDoubleSided = new System.Windows.Forms.CheckBox();
            this.grpNewDiskFormat = new System.Windows.Forms.GroupBox();
            this.optSedoric = new System.Windows.Forms.RadioButton();
            this.opt80Tracks = new System.Windows.Forms.RadioButton();
            this.optOricDos = new System.Windows.Forms.RadioButton();
            this.opt40Tracks = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picDisk)).BeginInit();
            this.grpNewDiskFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOricDiskCreator
            // 
            this.lblOricDiskCreator.AutoSize = true;
            this.lblOricDiskCreator.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOricDiskCreator.Location = new System.Drawing.Point(79, 35);
            this.lblOricDiskCreator.Name = "lblOricDiskCreator";
            this.lblOricDiskCreator.Size = new System.Drawing.Size(127, 20);
            this.lblOricDiskCreator.TabIndex = 0;
            this.lblOricDiskCreator.Text = "Oric Disk Creator";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(80, 57);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(209, 17);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Create a blank formatted Oric disk";
            // 
            // picDisk
            // 
            this.picDisk.Image = global::OricExplorer.Properties.Resources.disk;
            this.picDisk.Location = new System.Drawing.Point(25, 32);
            this.picDisk.Name = "picDisk";
            this.picDisk.Size = new System.Drawing.Size(48, 45);
            this.picDisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDisk.TabIndex = 2;
            this.picDisk.TabStop = false;
            // 
            // lblDiskName
            // 
            this.lblDiskName.AutoSize = true;
            this.lblDiskName.Location = new System.Drawing.Point(6, 123);
            this.lblDiskName.Name = "lblDiskName";
            this.lblDiskName.Size = new System.Drawing.Size(62, 13);
            this.lblDiskName.TabIndex = 5;
            this.lblDiskName.Text = "Disk Name:";
            // 
            // txtDiskName
            // 
            this.txtDiskName.Location = new System.Drawing.Point(74, 120);
            this.txtDiskName.Name = "txtDiskName";
            this.txtDiskName.Size = new System.Drawing.Size(106, 20);
            this.txtDiskName.TabIndex = 6;
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(3, 177);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(93, 13);
            this.lblDirectory.TabIndex = 7;
            this.lblDirectory.Text = "Save to directory :";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(102, 170);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(520, 20);
            this.txtDirectory.TabIndex = 8;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(547, 196);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(491, 336);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(572, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // chkDoubleSided
            // 
            this.chkDoubleSided.AutoSize = true;
            this.chkDoubleSided.Location = new System.Drawing.Point(181, 43);
            this.chkDoubleSided.Name = "chkDoubleSided";
            this.chkDoubleSided.Size = new System.Drawing.Size(90, 17);
            this.chkDoubleSided.TabIndex = 3;
            this.chkDoubleSided.Text = "Double Sided";
            this.chkDoubleSided.UseVisualStyleBackColor = true;
            // 
            // grpNewDiskFormat
            // 
            this.grpNewDiskFormat.Controls.Add(this.btnBrowse);
            this.grpNewDiskFormat.Controls.Add(this.txtDirectory);
            this.grpNewDiskFormat.Controls.Add(this.lblDirectory);
            this.grpNewDiskFormat.Controls.Add(this.txtDiskName);
            this.grpNewDiskFormat.Controls.Add(this.optSedoric);
            this.grpNewDiskFormat.Controls.Add(this.lblDiskName);
            this.grpNewDiskFormat.Controls.Add(this.opt80Tracks);
            this.grpNewDiskFormat.Controls.Add(this.optOricDos);
            this.grpNewDiskFormat.Controls.Add(this.opt40Tracks);
            this.grpNewDiskFormat.Controls.Add(this.chkDoubleSided);
            this.grpNewDiskFormat.Location = new System.Drawing.Point(25, 88);
            this.grpNewDiskFormat.Name = "grpNewDiskFormat";
            this.grpNewDiskFormat.Size = new System.Drawing.Size(641, 242);
            this.grpNewDiskFormat.TabIndex = 2;
            this.grpNewDiskFormat.TabStop = false;
            this.grpNewDiskFormat.Text = "New Disk Format";
            // 
            // optSedoric
            // 
            this.optSedoric.AutoSize = true;
            this.optSedoric.Location = new System.Drawing.Point(6, 78);
            this.optSedoric.Name = "optSedoric";
            this.optSedoric.Size = new System.Drawing.Size(106, 17);
            this.optSedoric.TabIndex = 4;
            this.optSedoric.TabStop = true;
            this.optSedoric.Text = "SedOric (V1.006)";
            this.optSedoric.UseVisualStyleBackColor = true;
            // 
            // opt80Tracks
            // 
            this.opt80Tracks.AutoSize = true;
            this.opt80Tracks.Location = new System.Drawing.Point(102, 42);
            this.opt80Tracks.Name = "opt80Tracks";
            this.opt80Tracks.Size = new System.Drawing.Size(73, 17);
            this.opt80Tracks.TabIndex = 2;
            this.opt80Tracks.TabStop = true;
            this.opt80Tracks.Text = "80 Tracks";
            this.opt80Tracks.UseVisualStyleBackColor = true;
            // 
            // optOricDos
            // 
            this.optOricDos.AutoSize = true;
            this.optOricDos.Location = new System.Drawing.Point(6, 19);
            this.optOricDos.Name = "optOricDos";
            this.optOricDos.Size = new System.Drawing.Size(106, 17);
            this.optOricDos.TabIndex = 0;
            this.optOricDos.TabStop = true;
            this.optOricDos.Text = "OricDos (V1.003)";
            this.optOricDos.UseVisualStyleBackColor = true;
            // 
            // opt40Tracks
            // 
            this.opt40Tracks.AutoSize = true;
            this.opt40Tracks.Location = new System.Drawing.Point(23, 42);
            this.opt40Tracks.Name = "opt40Tracks";
            this.opt40Tracks.Size = new System.Drawing.Size(73, 17);
            this.opt40Tracks.TabIndex = 1;
            this.opt40Tracks.TabStop = true;
            this.opt40Tracks.Text = "40 Tracks";
            this.opt40Tracks.UseVisualStyleBackColor = true;
            // 
            // frmCreateNewDisk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 368);
            this.Controls.Add(this.grpNewDiskFormat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.picDisk);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblOricDiskCreator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateNewDisk";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oric Disk Creator";
            ((System.ComponentModel.ISupportInitialize)(this.picDisk)).EndInit();
            this.grpNewDiskFormat.ResumeLayout(false);
            this.grpNewDiskFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOricDiskCreator;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picDisk;
        private System.Windows.Forms.Label lblDiskName;
        private System.Windows.Forms.TextBox txtDiskName;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkDoubleSided;
        private System.Windows.Forms.GroupBox grpNewDiskFormat;
        private System.Windows.Forms.RadioButton optSedoric;
        private System.Windows.Forms.RadioButton opt80Tracks;
        private System.Windows.Forms.RadioButton optOricDos;
        private System.Windows.Forms.RadioButton opt40Tracks;
    }
}