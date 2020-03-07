namespace OricExplorer.Forms
{
    partial class ImportTextFileForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFileToImport = new System.Windows.Forms.TextBox();
            this.buttonBrowseForTextFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonExistingDisk = new System.Windows.Forms.RadioButton();
            this.radioButtonNewDisk = new System.Windows.Forms.RadioButton();
            this.radioButtonExistingTape = new System.Windows.Forms.RadioButton();
            this.radioButtonNewTape = new System.Windows.Forms.RadioButton();
            this.textBoxProgramName = new System.Windows.Forms.TextBox();
            this.textBoxStartAddress = new System.Windows.Forms.TextBox();
            this.checkBoxAutoRun = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBrowseForDestinationFile = new System.Windows.Forms.Button();
            this.textBoxDestinationFile = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEndAddress = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select text file to import :";
            // 
            // textBoxFileToImport
            // 
            this.textBoxFileToImport.Location = new System.Drawing.Point(9, 41);
            this.textBoxFileToImport.Name = "textBoxFileToImport";
            this.textBoxFileToImport.Size = new System.Drawing.Size(367, 20);
            this.textBoxFileToImport.TabIndex = 1;
            // 
            // buttonBrowseForTextFile
            // 
            this.buttonBrowseForTextFile.Location = new System.Drawing.Point(382, 40);
            this.buttonBrowseForTextFile.Name = "buttonBrowseForTextFile";
            this.buttonBrowseForTextFile.Size = new System.Drawing.Size(75, 22);
            this.buttonBrowseForTextFile.TabIndex = 2;
            this.buttonBrowseForTextFile.Text = "Browse...";
            this.buttonBrowseForTextFile.UseVisualStyleBackColor = true;
            this.buttonBrowseForTextFile.Click += new System.EventHandler(this.buttonBrowseForTextFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonBrowseForTextFile);
            this.groupBox1.Controls.Add(this.textBoxFileToImport);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonExistingDisk);
            this.groupBox2.Controls.Add(this.radioButtonNewDisk);
            this.groupBox2.Controls.Add(this.radioButtonExistingTape);
            this.groupBox2.Controls.Add(this.radioButtonNewTape);
            this.groupBox2.Location = new System.Drawing.Point(6, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 179);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add To";
            // 
            // radioButtonExistingDisk
            // 
            this.radioButtonExistingDisk.AutoSize = true;
            this.radioButtonExistingDisk.Location = new System.Drawing.Point(9, 101);
            this.radioButtonExistingDisk.Name = "radioButtonExistingDisk";
            this.radioButtonExistingDisk.Size = new System.Drawing.Size(85, 17);
            this.radioButtonExistingDisk.TabIndex = 3;
            this.radioButtonExistingDisk.TabStop = true;
            this.radioButtonExistingDisk.Text = "Existing Disk";
            this.radioButtonExistingDisk.UseVisualStyleBackColor = true;
            this.radioButtonExistingDisk.CheckedChanged += new System.EventHandler(this.radioButtonExistingDisk_CheckedChanged);
            // 
            // radioButtonNewDisk
            // 
            this.radioButtonNewDisk.AutoSize = true;
            this.radioButtonNewDisk.Location = new System.Drawing.Point(9, 78);
            this.radioButtonNewDisk.Name = "radioButtonNewDisk";
            this.radioButtonNewDisk.Size = new System.Drawing.Size(71, 17);
            this.radioButtonNewDisk.TabIndex = 2;
            this.radioButtonNewDisk.TabStop = true;
            this.radioButtonNewDisk.Text = "New Disk";
            this.radioButtonNewDisk.UseVisualStyleBackColor = true;
            this.radioButtonNewDisk.CheckedChanged += new System.EventHandler(this.radioButtonNewDisk_CheckedChanged);
            // 
            // radioButtonExistingTape
            // 
            this.radioButtonExistingTape.AutoSize = true;
            this.radioButtonExistingTape.Location = new System.Drawing.Point(9, 45);
            this.radioButtonExistingTape.Name = "radioButtonExistingTape";
            this.radioButtonExistingTape.Size = new System.Drawing.Size(89, 17);
            this.radioButtonExistingTape.TabIndex = 1;
            this.radioButtonExistingTape.TabStop = true;
            this.radioButtonExistingTape.Text = "Existing Tape";
            this.radioButtonExistingTape.UseVisualStyleBackColor = true;
            this.radioButtonExistingTape.CheckedChanged += new System.EventHandler(this.radioButtonExistingTape_CheckedChanged);
            // 
            // radioButtonNewTape
            // 
            this.radioButtonNewTape.AutoSize = true;
            this.radioButtonNewTape.Location = new System.Drawing.Point(9, 22);
            this.radioButtonNewTape.Name = "radioButtonNewTape";
            this.radioButtonNewTape.Size = new System.Drawing.Size(75, 17);
            this.radioButtonNewTape.TabIndex = 0;
            this.radioButtonNewTape.TabStop = true;
            this.radioButtonNewTape.Text = "New Tape";
            this.radioButtonNewTape.UseVisualStyleBackColor = true;
            this.radioButtonNewTape.CheckedChanged += new System.EventHandler(this.radioButtonNewTape_CheckedChanged);
            // 
            // textBoxProgramName
            // 
            this.textBoxProgramName.Location = new System.Drawing.Point(98, 22);
            this.textBoxProgramName.Name = "textBoxProgramName";
            this.textBoxProgramName.Size = new System.Drawing.Size(170, 20);
            this.textBoxProgramName.TabIndex = 4;
            // 
            // textBoxStartAddress
            // 
            this.textBoxStartAddress.Location = new System.Drawing.Point(98, 48);
            this.textBoxStartAddress.Name = "textBoxStartAddress";
            this.textBoxStartAddress.Size = new System.Drawing.Size(45, 20);
            this.textBoxStartAddress.TabIndex = 5;
            this.textBoxStartAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxAutoRun
            // 
            this.checkBoxAutoRun.AutoSize = true;
            this.checkBoxAutoRun.Location = new System.Drawing.Point(98, 74);
            this.checkBoxAutoRun.Name = "checkBoxAutoRun";
            this.checkBoxAutoRun.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutoRun.TabIndex = 7;
            this.checkBoxAutoRun.Text = "Auto Run?";
            this.checkBoxAutoRun.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Program Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Select destination file :";
            // 
            // buttonBrowseForDestinationFile
            // 
            this.buttonBrowseForDestinationFile.Location = new System.Drawing.Point(274, 40);
            this.buttonBrowseForDestinationFile.Name = "buttonBrowseForDestinationFile";
            this.buttonBrowseForDestinationFile.Size = new System.Drawing.Size(75, 22);
            this.buttonBrowseForDestinationFile.TabIndex = 5;
            this.buttonBrowseForDestinationFile.Text = "Browse...";
            this.buttonBrowseForDestinationFile.UseVisualStyleBackColor = true;
            this.buttonBrowseForDestinationFile.Click += new System.EventHandler(this.buttonBrowseForDestinationFile_Click);
            // 
            // textBoxDestinationFile
            // 
            this.textBoxDestinationFile.Location = new System.Drawing.Point(9, 41);
            this.textBoxDestinationFile.Name = "textBoxDestinationFile";
            this.textBoxDestinationFile.Size = new System.Drawing.Size(259, 20);
            this.textBoxDestinationFile.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonReset);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxEndAddress);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxProgramName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxStartAddress);
            this.groupBox3.Controls.Add(this.checkBoxAutoRun);
            this.groupBox3.Location = new System.Drawing.Point(114, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Program Settings";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(274, 21);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 22);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "End :";
            // 
            // textBoxEndAddress
            // 
            this.textBoxEndAddress.Location = new System.Drawing.Point(223, 48);
            this.textBoxEndAddress.Name = "textBoxEndAddress";
            this.textBoxEndAddress.ReadOnly = true;
            this.textBoxEndAddress.Size = new System.Drawing.Size(45, 20);
            this.textBoxEndAddress.TabIndex = 10;
            this.textBoxEndAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxDestinationFile);
            this.groupBox4.Controls.Add(this.buttonBrowseForDestinationFile);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(114, 85);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(357, 73);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destination";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(315, 270);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 7;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(396, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ImportTextFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 300);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportTextFileForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Text File";
            this.Shown += new System.EventHandler(this.ImportTextFileForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileToImport;
        private System.Windows.Forms.Button buttonBrowseForTextFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonExistingDisk;
        private System.Windows.Forms.RadioButton radioButtonNewDisk;
        private System.Windows.Forms.RadioButton radioButtonExistingTape;
        private System.Windows.Forms.RadioButton radioButtonNewTape;
        private System.Windows.Forms.TextBox textBoxProgramName;
        private System.Windows.Forms.TextBox textBoxStartAddress;
        private System.Windows.Forms.CheckBox checkBoxAutoRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBrowseForDestinationFile;
        private System.Windows.Forms.TextBox textBoxDestinationFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEndAddress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReset;
    }
}