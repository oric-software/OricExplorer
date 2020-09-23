namespace OricExplorer.Forms
{
    partial class frmImportAtmosBasicFile
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
            this.lblFileToImport = new System.Windows.Forms.Label();
            this.txtFileToImport = new System.Windows.Forms.TextBox();
            this.btnBrowseForTextFile = new System.Windows.Forms.Button();
            this.grpTextFile = new System.Windows.Forms.GroupBox();
            this.grpAddTo = new System.Windows.Forms.GroupBox();
            this.optExistingDisk = new System.Windows.Forms.RadioButton();
            this.optNewDisk = new System.Windows.Forms.RadioButton();
            this.optExistingTape = new System.Windows.Forms.RadioButton();
            this.optNewTape = new System.Windows.Forms.RadioButton();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.txtStartAddress = new System.Windows.Forms.TextBox();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblStartAddress = new System.Windows.Forms.Label();
            this.lblDestinationFile = new System.Windows.Forms.Label();
            this.btnBrowseForDestinationFile = new System.Windows.Forms.Button();
            this.txtDestinationFile = new System.Windows.Forms.TextBox();
            this.grpProgramSettings = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblEndAddress = new System.Windows.Forms.Label();
            this.txtEndAddress = new System.Windows.Forms.TextBox();
            this.grpDestination = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpTextFile.SuspendLayout();
            this.grpAddTo.SuspendLayout();
            this.grpProgramSettings.SuspendLayout();
            this.grpDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileToImport
            // 
            this.lblFileToImport.AutoSize = true;
            this.lblFileToImport.Location = new System.Drawing.Point(8, 22);
            this.lblFileToImport.Name = "lblFileToImport";
            this.lblFileToImport.Size = new System.Drawing.Size(122, 13);
            this.lblFileToImport.TabIndex = 0;
            this.lblFileToImport.Text = "Select text file to import :";
            // 
            // txtFileToImport
            // 
            this.txtFileToImport.Location = new System.Drawing.Point(9, 41);
            this.txtFileToImport.Name = "txtFileToImport";
            this.txtFileToImport.Size = new System.Drawing.Size(367, 20);
            this.txtFileToImport.TabIndex = 1;
            this.txtFileToImport.TextChanged += new System.EventHandler(this.txtFileToImport_TextChanged);
            // 
            // btnBrowseForTextFile
            // 
            this.btnBrowseForTextFile.Location = new System.Drawing.Point(382, 40);
            this.btnBrowseForTextFile.Name = "btnBrowseForTextFile";
            this.btnBrowseForTextFile.Size = new System.Drawing.Size(75, 22);
            this.btnBrowseForTextFile.TabIndex = 2;
            this.btnBrowseForTextFile.Text = "Browse...";
            this.btnBrowseForTextFile.UseVisualStyleBackColor = true;
            this.btnBrowseForTextFile.Click += new System.EventHandler(this.btnBrowseForTextFile_Click);
            // 
            // grpTextFile
            // 
            this.grpTextFile.Controls.Add(this.lblFileToImport);
            this.grpTextFile.Controls.Add(this.btnBrowseForTextFile);
            this.grpTextFile.Controls.Add(this.txtFileToImport);
            this.grpTextFile.Location = new System.Drawing.Point(6, 6);
            this.grpTextFile.Name = "grpTextFile";
            this.grpTextFile.Size = new System.Drawing.Size(465, 73);
            this.grpTextFile.TabIndex = 0;
            this.grpTextFile.TabStop = false;
            this.grpTextFile.Text = "Text File";
            // 
            // grpAddTo
            // 
            this.grpAddTo.Controls.Add(this.optExistingDisk);
            this.grpAddTo.Controls.Add(this.optNewDisk);
            this.grpAddTo.Controls.Add(this.optExistingTape);
            this.grpAddTo.Controls.Add(this.optNewTape);
            this.grpAddTo.Location = new System.Drawing.Point(6, 85);
            this.grpAddTo.Name = "grpAddTo";
            this.grpAddTo.Size = new System.Drawing.Size(102, 179);
            this.grpAddTo.TabIndex = 1;
            this.grpAddTo.TabStop = false;
            this.grpAddTo.Text = "Add To";
            // 
            // optExistingDisk
            // 
            this.optExistingDisk.AutoSize = true;
            this.optExistingDisk.Enabled = false;
            this.optExistingDisk.Location = new System.Drawing.Point(9, 101);
            this.optExistingDisk.Name = "optExistingDisk";
            this.optExistingDisk.Size = new System.Drawing.Size(85, 17);
            this.optExistingDisk.TabIndex = 3;
            this.optExistingDisk.TabStop = true;
            this.optExistingDisk.Text = "Existing Disk";
            this.optExistingDisk.UseVisualStyleBackColor = true;
            this.optExistingDisk.Visible = false;
            this.optExistingDisk.CheckedChanged += new System.EventHandler(this.optExistingDisk_CheckedChanged);
            // 
            // optNewDisk
            // 
            this.optNewDisk.AutoSize = true;
            this.optNewDisk.Enabled = false;
            this.optNewDisk.Location = new System.Drawing.Point(9, 78);
            this.optNewDisk.Name = "optNewDisk";
            this.optNewDisk.Size = new System.Drawing.Size(71, 17);
            this.optNewDisk.TabIndex = 2;
            this.optNewDisk.TabStop = true;
            this.optNewDisk.Text = "New Disk";
            this.optNewDisk.UseVisualStyleBackColor = true;
            this.optNewDisk.Visible = false;
            this.optNewDisk.CheckedChanged += new System.EventHandler(this.optNewDisk_CheckedChanged);
            // 
            // optExistingTape
            // 
            this.optExistingTape.AutoSize = true;
            this.optExistingTape.Location = new System.Drawing.Point(9, 45);
            this.optExistingTape.Name = "optExistingTape";
            this.optExistingTape.Size = new System.Drawing.Size(89, 17);
            this.optExistingTape.TabIndex = 1;
            this.optExistingTape.TabStop = true;
            this.optExistingTape.Text = "Existing Tape";
            this.optExistingTape.UseVisualStyleBackColor = true;
            this.optExistingTape.CheckedChanged += new System.EventHandler(this.optExistingTape_CheckedChanged);
            // 
            // optNewTape
            // 
            this.optNewTape.AutoSize = true;
            this.optNewTape.Location = new System.Drawing.Point(9, 22);
            this.optNewTape.Name = "optNewTape";
            this.optNewTape.Size = new System.Drawing.Size(75, 17);
            this.optNewTape.TabIndex = 0;
            this.optNewTape.TabStop = true;
            this.optNewTape.Text = "New Tape";
            this.optNewTape.UseVisualStyleBackColor = true;
            this.optNewTape.CheckedChanged += new System.EventHandler(this.optNewTape_CheckedChanged);
            // 
            // txtProgramName
            // 
            this.txtProgramName.Location = new System.Drawing.Point(98, 22);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(170, 20);
            this.txtProgramName.TabIndex = 1;
            // 
            // txtStartAddress
            // 
            this.txtStartAddress.Location = new System.Drawing.Point(98, 48);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.Size = new System.Drawing.Size(45, 20);
            this.txtStartAddress.TabIndex = 4;
            this.txtStartAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(98, 74);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(77, 17);
            this.chkAutoRun.TabIndex = 7;
            this.chkAutoRun.Text = "Auto Run?";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Location = new System.Drawing.Point(9, 23);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(83, 13);
            this.lblProgramName.TabIndex = 0;
            this.lblProgramName.Text = "Program Name :";
            // 
            // lblStartAddress
            // 
            this.lblStartAddress.AutoSize = true;
            this.lblStartAddress.Location = new System.Drawing.Point(16, 51);
            this.lblStartAddress.Name = "lblStartAddress";
            this.lblStartAddress.Size = new System.Drawing.Size(76, 13);
            this.lblStartAddress.TabIndex = 3;
            this.lblStartAddress.Text = "Start Address :";
            // 
            // lblDestinationFile
            // 
            this.lblDestinationFile.AutoSize = true;
            this.lblDestinationFile.Location = new System.Drawing.Point(8, 22);
            this.lblDestinationFile.Name = "lblDestinationFile";
            this.lblDestinationFile.Size = new System.Drawing.Size(113, 13);
            this.lblDestinationFile.TabIndex = 0;
            this.lblDestinationFile.Text = "Select destination file :";
            // 
            // btnBrowseForDestinationFile
            // 
            this.btnBrowseForDestinationFile.Location = new System.Drawing.Point(274, 40);
            this.btnBrowseForDestinationFile.Name = "btnBrowseForDestinationFile";
            this.btnBrowseForDestinationFile.Size = new System.Drawing.Size(75, 22);
            this.btnBrowseForDestinationFile.TabIndex = 2;
            this.btnBrowseForDestinationFile.Text = "Browse...";
            this.btnBrowseForDestinationFile.UseVisualStyleBackColor = true;
            this.btnBrowseForDestinationFile.Click += new System.EventHandler(this.btnBrowseForDestinationFile_Click);
            // 
            // txtDestinationFile
            // 
            this.txtDestinationFile.Location = new System.Drawing.Point(9, 41);
            this.txtDestinationFile.Name = "txtDestinationFile";
            this.txtDestinationFile.Size = new System.Drawing.Size(259, 20);
            this.txtDestinationFile.TabIndex = 1;
            this.txtDestinationFile.TextChanged += new System.EventHandler(this.txtDestinationFile_TextChanged);
            // 
            // grpProgramSettings
            // 
            this.grpProgramSettings.Controls.Add(this.btnReset);
            this.grpProgramSettings.Controls.Add(this.lblEndAddress);
            this.grpProgramSettings.Controls.Add(this.txtEndAddress);
            this.grpProgramSettings.Controls.Add(this.lblProgramName);
            this.grpProgramSettings.Controls.Add(this.txtProgramName);
            this.grpProgramSettings.Controls.Add(this.lblStartAddress);
            this.grpProgramSettings.Controls.Add(this.txtStartAddress);
            this.grpProgramSettings.Controls.Add(this.chkAutoRun);
            this.grpProgramSettings.Location = new System.Drawing.Point(114, 164);
            this.grpProgramSettings.Name = "grpProgramSettings";
            this.grpProgramSettings.Size = new System.Drawing.Size(357, 100);
            this.grpProgramSettings.TabIndex = 3;
            this.grpProgramSettings.TabStop = false;
            this.grpProgramSettings.Text = "Program Settings";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(274, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 22);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblEndAddress
            // 
            this.lblEndAddress.AutoSize = true;
            this.lblEndAddress.Location = new System.Drawing.Point(185, 51);
            this.lblEndAddress.Name = "lblEndAddress";
            this.lblEndAddress.Size = new System.Drawing.Size(32, 13);
            this.lblEndAddress.TabIndex = 5;
            this.lblEndAddress.Text = "End :";
            // 
            // txtEndAddress
            // 
            this.txtEndAddress.Location = new System.Drawing.Point(223, 48);
            this.txtEndAddress.Name = "txtEndAddress";
            this.txtEndAddress.ReadOnly = true;
            this.txtEndAddress.Size = new System.Drawing.Size(45, 20);
            this.txtEndAddress.TabIndex = 6;
            this.txtEndAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpDestination
            // 
            this.grpDestination.Controls.Add(this.txtDestinationFile);
            this.grpDestination.Controls.Add(this.btnBrowseForDestinationFile);
            this.grpDestination.Controls.Add(this.lblDestinationFile);
            this.grpDestination.Location = new System.Drawing.Point(114, 85);
            this.grpDestination.Name = "grpDestination";
            this.grpDestination.Size = new System.Drawing.Size(357, 73);
            this.grpDestination.TabIndex = 2;
            this.grpDestination.TabStop = false;
            this.grpDestination.Text = "Destination";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(315, 270);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(396, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmImportAtmosBasicFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(479, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grpDestination);
            this.Controls.Add(this.grpProgramSettings);
            this.Controls.Add(this.grpAddTo);
            this.Controls.Add(this.grpTextFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportAtmosBasicFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Oric-1/Atmos BASIC File";
            this.Shown += new System.EventHandler(this.frmImportTextFile_Shown);
            this.grpTextFile.ResumeLayout(false);
            this.grpTextFile.PerformLayout();
            this.grpAddTo.ResumeLayout(false);
            this.grpAddTo.PerformLayout();
            this.grpProgramSettings.ResumeLayout(false);
            this.grpProgramSettings.PerformLayout();
            this.grpDestination.ResumeLayout(false);
            this.grpDestination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFileToImport;
        private System.Windows.Forms.TextBox txtFileToImport;
        private System.Windows.Forms.Button btnBrowseForTextFile;
        private System.Windows.Forms.GroupBox grpTextFile;
        private System.Windows.Forms.GroupBox grpAddTo;
        private System.Windows.Forms.RadioButton optExistingDisk;
        private System.Windows.Forms.RadioButton optNewDisk;
        private System.Windows.Forms.RadioButton optExistingTape;
        private System.Windows.Forms.RadioButton optNewTape;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblStartAddress;
        private System.Windows.Forms.Label lblDestinationFile;
        private System.Windows.Forms.Button btnBrowseForDestinationFile;
        private System.Windows.Forms.TextBox txtDestinationFile;
        private System.Windows.Forms.GroupBox grpProgramSettings;
        private System.Windows.Forms.Label lblEndAddress;
        private System.Windows.Forms.TextBox txtEndAddress;
        private System.Windows.Forms.GroupBox grpDestination;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
    }
}