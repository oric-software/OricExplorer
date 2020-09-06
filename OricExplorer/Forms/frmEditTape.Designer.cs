namespace OricExplorer.Forms
{
    partial class frmEditTape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTape));
            this.lvwPrograms = new System.Windows.Forms.ListView();
            this.colProgramName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpTapeCatalog = new System.Windows.Forms.GroupBox();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpProgramDetails = new System.Windows.Forms.GroupBox();
            this.lblProgramLength = new System.Windows.Forms.Label();
            this.lblProgramLengthLabel = new System.Windows.Forms.Label();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.optCodeData = new System.Windows.Forms.RadioButton();
            this.optBasic = new System.Windows.Forms.RadioButton();
            this.nudEndAddress = new System.Windows.Forms.NumericUpDown();
            this.nudStartAddress = new System.Windows.Forms.NumericUpDown();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.lblAutoRun = new System.Windows.Forms.Label();
            this.lblProgramFormat = new System.Windows.Forms.Label();
            this.lblRightArrow = new System.Windows.Forms.Label();
            this.lblMemoryAddress = new System.Windows.Forms.Label();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.grpTapeDetails = new System.Windows.Forms.GroupBox();
            this.txtTapeFolder = new System.Windows.Forms.TextBox();
            this.txtTapeName = new System.Windows.Forms.TextBox();
            this.lblTapeFolder = new System.Windows.Forms.Label();
            this.lblTapeName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpTapeCatalog.SuspendLayout();
            this.grpProgramDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAddress)).BeginInit();
            this.grpTapeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPrograms
            // 
            this.lvwPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProgramName});
            this.lvwPrograms.FullRowSelect = true;
            this.lvwPrograms.GridLines = true;
            this.lvwPrograms.HideSelection = false;
            this.lvwPrograms.Location = new System.Drawing.Point(10, 19);
            this.lvwPrograms.MultiSelect = false;
            this.lvwPrograms.Name = "lvwPrograms";
            this.lvwPrograms.Size = new System.Drawing.Size(154, 159);
            this.lvwPrograms.TabIndex = 0;
            this.lvwPrograms.UseCompatibleStateImageBehavior = false;
            this.lvwPrograms.View = System.Windows.Forms.View.Details;
            this.lvwPrograms.SelectedIndexChanged += new System.EventHandler(this.lvwPrograms_SelectedIndexChanged);
            // 
            // colProgramName
            // 
            this.colProgramName.Text = "Program Name";
            this.colProgramName.Width = 130;
            // 
            // grpTapeCatalog
            // 
            this.grpTapeCatalog.Controls.Add(this.lvwPrograms);
            this.grpTapeCatalog.Controls.Add(this.btnMoveUp);
            this.grpTapeCatalog.Controls.Add(this.btnMoveDown);
            this.grpTapeCatalog.Controls.Add(this.btnDelete);
            this.grpTapeCatalog.Location = new System.Drawing.Point(9, 94);
            this.grpTapeCatalog.Name = "grpTapeCatalog";
            this.grpTapeCatalog.Size = new System.Drawing.Size(204, 186);
            this.grpTapeCatalog.TabIndex = 2;
            this.grpTapeCatalog.TabStop = false;
            this.grpTapeCatalog.Text = "Tape Catalog";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::OricExplorer.Properties.Resources.up_arrow;
            this.btnMoveUp.Location = new System.Drawing.Point(170, 19);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(28, 28);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::OricExplorer.Properties.Resources.down_arrow;
            this.btnMoveDown.Location = new System.Drawing.Point(170, 149);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(28, 28);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::OricExplorer.Properties.Resources.button_cancel;
            this.btnDelete.Location = new System.Drawing.Point(170, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(28, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::OricExplorer.Properties.Resources.apply;
            this.btnUpdate.Location = new System.Drawing.Point(233, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(28, 28);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grpProgramDetails
            // 
            this.grpProgramDetails.Controls.Add(this.lblProgramLength);
            this.grpProgramDetails.Controls.Add(this.lblProgramLengthLabel);
            this.grpProgramDetails.Controls.Add(this.btnUpdate);
            this.grpProgramDetails.Controls.Add(this.chkAutoRun);
            this.grpProgramDetails.Controls.Add(this.optCodeData);
            this.grpProgramDetails.Controls.Add(this.optBasic);
            this.grpProgramDetails.Controls.Add(this.nudEndAddress);
            this.grpProgramDetails.Controls.Add(this.nudStartAddress);
            this.grpProgramDetails.Controls.Add(this.txtProgramName);
            this.grpProgramDetails.Controls.Add(this.lblAutoRun);
            this.grpProgramDetails.Controls.Add(this.lblProgramFormat);
            this.grpProgramDetails.Controls.Add(this.lblRightArrow);
            this.grpProgramDetails.Controls.Add(this.lblMemoryAddress);
            this.grpProgramDetails.Controls.Add(this.lblProgramName);
            this.grpProgramDetails.Location = new System.Drawing.Point(219, 94);
            this.grpProgramDetails.Name = "grpProgramDetails";
            this.grpProgramDetails.Size = new System.Drawing.Size(273, 186);
            this.grpProgramDetails.TabIndex = 3;
            this.grpProgramDetails.TabStop = false;
            this.grpProgramDetails.Text = "Program Details";
            // 
            // lblProgramLength
            // 
            this.lblProgramLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProgramLength.Location = new System.Drawing.Point(106, 151);
            this.lblProgramLength.Name = "lblProgramLength";
            this.lblProgramLength.Size = new System.Drawing.Size(85, 20);
            this.lblProgramLength.TabIndex = 12;
            this.lblProgramLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgramLengthLabel
            // 
            this.lblProgramLengthLabel.AutoSize = true;
            this.lblProgramLengthLabel.Location = new System.Drawing.Point(12, 155);
            this.lblProgramLengthLabel.Name = "lblProgramLengthLabel";
            this.lblProgramLengthLabel.Size = new System.Drawing.Size(88, 13);
            this.lblProgramLengthLabel.TabIndex = 11;
            this.lblProgramLengthLabel.Text = "Program Length :";
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(106, 90);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(65, 17);
            this.chkAutoRun.TabIndex = 6;
            this.chkAutoRun.Text = "Enabled";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.chkAutoRun_CheckedChanged);
            // 
            // optCodeData
            // 
            this.optCodeData.AutoSize = true;
            this.optCodeData.Enabled = false;
            this.optCodeData.Location = new System.Drawing.Point(183, 57);
            this.optCodeData.Name = "optCodeData";
            this.optCodeData.Size = new System.Drawing.Size(78, 17);
            this.optCodeData.TabIndex = 4;
            this.optCodeData.TabStop = true;
            this.optCodeData.Text = "Code/Data";
            this.optCodeData.UseVisualStyleBackColor = true;
            // 
            // optBasic
            // 
            this.optBasic.AutoSize = true;
            this.optBasic.Enabled = false;
            this.optBasic.Location = new System.Drawing.Point(106, 57);
            this.optBasic.Name = "optBasic";
            this.optBasic.Size = new System.Drawing.Size(56, 17);
            this.optBasic.TabIndex = 3;
            this.optBasic.TabStop = true;
            this.optBasic.Text = "BASIC";
            this.optBasic.UseVisualStyleBackColor = true;
            // 
            // nudEndAddress
            // 
            this.nudEndAddress.Hexadecimal = true;
            this.nudEndAddress.Location = new System.Drawing.Point(202, 121);
            this.nudEndAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudEndAddress.Name = "nudEndAddress";
            this.nudEndAddress.ReadOnly = true;
            this.nudEndAddress.Size = new System.Drawing.Size(58, 20);
            this.nudEndAddress.TabIndex = 10;
            this.nudEndAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudStartAddress
            // 
            this.nudStartAddress.Hexadecimal = true;
            this.nudStartAddress.Location = new System.Drawing.Point(106, 121);
            this.nudStartAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudStartAddress.Name = "nudStartAddress";
            this.nudStartAddress.Size = new System.Drawing.Size(58, 20);
            this.nudStartAddress.TabIndex = 8;
            this.nudStartAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStartAddress.ValueChanged += new System.EventHandler(this.nudStartAddress_ValueChanged);
            // 
            // txtProgramName
            // 
            this.txtProgramName.Location = new System.Drawing.Point(106, 24);
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(155, 20);
            this.txtProgramName.TabIndex = 1;
            this.txtProgramName.TextChanged += new System.EventHandler(this.txtProgramName_TextChanged);
            // 
            // lblAutoRun
            // 
            this.lblAutoRun.AutoSize = true;
            this.lblAutoRun.Location = new System.Drawing.Point(42, 91);
            this.lblAutoRun.Name = "lblAutoRun";
            this.lblAutoRun.Size = new System.Drawing.Size(58, 13);
            this.lblAutoRun.TabIndex = 5;
            this.lblAutoRun.Text = "Auto Run :";
            // 
            // lblProgramFormat
            // 
            this.lblProgramFormat.AutoSize = true;
            this.lblProgramFormat.Location = new System.Drawing.Point(13, 59);
            this.lblProgramFormat.Name = "lblProgramFormat";
            this.lblProgramFormat.Size = new System.Drawing.Size(87, 13);
            this.lblProgramFormat.TabIndex = 2;
            this.lblProgramFormat.Text = "Program Format :";
            // 
            // lblRightArrow
            // 
            this.lblRightArrow.AutoSize = true;
            this.lblRightArrow.Location = new System.Drawing.Point(175, 125);
            this.lblRightArrow.Name = "lblRightArrow";
            this.lblRightArrow.Size = new System.Drawing.Size(16, 13);
            this.lblRightArrow.TabIndex = 9;
            this.lblRightArrow.Text = "->";
            // 
            // lblMemoryAddress
            // 
            this.lblMemoryAddress.AutoSize = true;
            this.lblMemoryAddress.Location = new System.Drawing.Point(9, 123);
            this.lblMemoryAddress.Name = "lblMemoryAddress";
            this.lblMemoryAddress.Size = new System.Drawing.Size(91, 13);
            this.lblMemoryAddress.TabIndex = 7;
            this.lblMemoryAddress.Text = "Memory Address :";
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Location = new System.Drawing.Point(17, 27);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(83, 13);
            this.lblProgramName.TabIndex = 0;
            this.lblProgramName.Text = "Program Name :";
            // 
            // grpTapeDetails
            // 
            this.grpTapeDetails.Controls.Add(this.txtTapeFolder);
            this.grpTapeDetails.Controls.Add(this.txtTapeName);
            this.grpTapeDetails.Controls.Add(this.lblTapeFolder);
            this.grpTapeDetails.Controls.Add(this.lblTapeName);
            this.grpTapeDetails.Location = new System.Drawing.Point(9, 12);
            this.grpTapeDetails.Name = "grpTapeDetails";
            this.grpTapeDetails.Size = new System.Drawing.Size(483, 76);
            this.grpTapeDetails.TabIndex = 1;
            this.grpTapeDetails.TabStop = false;
            this.grpTapeDetails.Text = "Tape Details";
            // 
            // txtTapeFolder
            // 
            this.txtTapeFolder.Location = new System.Drawing.Point(57, 45);
            this.txtTapeFolder.Name = "txtTapeFolder";
            this.txtTapeFolder.ReadOnly = true;
            this.txtTapeFolder.Size = new System.Drawing.Size(415, 20);
            this.txtTapeFolder.TabIndex = 3;
            // 
            // txtTapeName
            // 
            this.txtTapeName.Location = new System.Drawing.Point(57, 19);
            this.txtTapeName.Name = "txtTapeName";
            this.txtTapeName.ReadOnly = true;
            this.txtTapeName.Size = new System.Drawing.Size(415, 20);
            this.txtTapeName.TabIndex = 1;
            // 
            // lblTapeFolder
            // 
            this.lblTapeFolder.AutoSize = true;
            this.lblTapeFolder.Location = new System.Drawing.Point(8, 49);
            this.lblTapeFolder.Name = "lblTapeFolder";
            this.lblTapeFolder.Size = new System.Drawing.Size(42, 13);
            this.lblTapeFolder.TabIndex = 2;
            this.lblTapeFolder.Text = "Folder :";
            // 
            // lblTapeName
            // 
            this.lblTapeName.AutoSize = true;
            this.lblTapeName.Location = new System.Drawing.Point(9, 23);
            this.lblTapeName.Name = "lblTapeName";
            this.lblTapeName.Size = new System.Drawing.Size(41, 13);
            this.lblTapeName.TabIndex = 0;
            this.lblTapeName.Text = "Name :";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(414, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditTape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(501, 316);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpTapeDetails);
            this.Controls.Add(this.grpProgramDetails);
            this.Controls.Add(this.grpTapeCatalog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditTape";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Tape";
            this.Load += new System.EventHandler(this.frmEditTape_Load);
            this.grpTapeCatalog.ResumeLayout(false);
            this.grpProgramDetails.ResumeLayout(false);
            this.grpProgramDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartAddress)).EndInit();
            this.grpTapeDetails.ResumeLayout(false);
            this.grpTapeDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPrograms;
        private System.Windows.Forms.ColumnHeader colProgramName;
        private System.Windows.Forms.GroupBox grpTapeCatalog;
        private System.Windows.Forms.GroupBox grpProgramDetails;
        private System.Windows.Forms.GroupBox grpTapeDetails;
        private System.Windows.Forms.TextBox txtTapeFolder;
        private System.Windows.Forms.TextBox txtTapeName;
        private System.Windows.Forms.Label lblTapeFolder;
        private System.Windows.Forms.Label lblTapeName;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.RadioButton optCodeData;
        private System.Windows.Forms.RadioButton optBasic;
        private System.Windows.Forms.NumericUpDown nudEndAddress;
        private System.Windows.Forms.NumericUpDown nudStartAddress;
        private System.Windows.Forms.TextBox txtProgramName;
        private System.Windows.Forms.Label lblAutoRun;
        private System.Windows.Forms.Label lblProgramFormat;
        private System.Windows.Forms.Label lblRightArrow;
        private System.Windows.Forms.Label lblMemoryAddress;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblProgramLength;
        private System.Windows.Forms.Label lblProgramLengthLabel;
        private System.Windows.Forms.Button btnSave;
    }
}