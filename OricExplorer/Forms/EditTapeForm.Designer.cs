namespace OricExplorer.Forms
{
    partial class EditTapeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTapeForm));
            this.listViewPrograms = new System.Windows.Forms.ListView();
            this.columnHeaderProgramName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelProgramLength = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxAutoRun = new System.Windows.Forms.CheckBox();
            this.radioButtonCodeData = new System.Windows.Forms.RadioButton();
            this.radioButtonBasic = new System.Windows.Forms.RadioButton();
            this.numericUpDownEndAddress = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartAddress = new System.Windows.Forms.NumericUpDown();
            this.textBoxProgramName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxTapeFolder = new System.Windows.Forms.TextBox();
            this.textBoxTapeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartAddress)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewPrograms
            // 
            this.listViewPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProgramName});
            this.listViewPrograms.FullRowSelect = true;
            this.listViewPrograms.GridLines = true;
            this.listViewPrograms.HideSelection = false;
            this.listViewPrograms.Location = new System.Drawing.Point(10, 19);
            this.listViewPrograms.MultiSelect = false;
            this.listViewPrograms.Name = "listViewPrograms";
            this.listViewPrograms.Size = new System.Drawing.Size(184, 125);
            this.listViewPrograms.TabIndex = 0;
            this.listViewPrograms.UseCompatibleStateImageBehavior = false;
            this.listViewPrograms.View = System.Windows.Forms.View.Details;
            this.listViewPrograms.SelectedIndexChanged += new System.EventHandler(this.listViewPrograms_SelectedIndexChanged);
            this.listViewPrograms.Click += new System.EventHandler(this.listViewPrograms_Click);
            this.listViewPrograms.DoubleClick += new System.EventHandler(this.listViewPrograms_DoubleClick);
            // 
            // columnHeaderProgramName
            // 
            this.columnHeaderProgramName.Text = "Program Name";
            this.columnHeaderProgramName.Width = 162;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewPrograms);
            this.groupBox2.Controls.Add(this.buttonMoveUp);
            this.groupBox2.Controls.Add(this.buttonUpdate);
            this.groupBox2.Controls.Add(this.buttonMoveDown);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Location = new System.Drawing.Point(9, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tape Catalog";
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Image = global::OricExplorer.Properties.Resources._1uparrow1;
            this.buttonMoveUp.Location = new System.Drawing.Point(11, 150);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(28, 28);
            this.buttonMoveUp.TabIndex = 4;
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Image = global::OricExplorer.Properties.Resources.apply;
            this.buttonUpdate.Location = new System.Drawing.Point(113, 150);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(28, 28);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Image = global::OricExplorer.Properties.Resources._1downarrow1;
            this.buttonMoveDown.Location = new System.Drawing.Point(62, 150);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(28, 28);
            this.buttonMoveDown.TabIndex = 5;
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::OricExplorer.Properties.Resources.button_cancel1;
            this.buttonDelete.Location = new System.Drawing.Point(164, 150);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(28, 28);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelProgramLength);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.checkBoxAutoRun);
            this.groupBox3.Controls.Add(this.radioButtonCodeData);
            this.groupBox3.Controls.Add(this.radioButtonBasic);
            this.groupBox3.Controls.Add(this.numericUpDownEndAddress);
            this.groupBox3.Controls.Add(this.numericUpDownStartAddress);
            this.groupBox3.Controls.Add(this.textBoxProgramName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(219, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 186);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Program Details";
            // 
            // labelProgramLength
            // 
            this.labelProgramLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProgramLength.Location = new System.Drawing.Point(106, 151);
            this.labelProgramLength.Name = "labelProgramLength";
            this.labelProgramLength.Size = new System.Drawing.Size(155, 20);
            this.labelProgramLength.TabIndex = 12;
            this.labelProgramLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Program Length :";
            // 
            // checkBoxAutoRun
            // 
            this.checkBoxAutoRun.AutoSize = true;
            this.checkBoxAutoRun.Location = new System.Drawing.Point(106, 90);
            this.checkBoxAutoRun.Name = "checkBoxAutoRun";
            this.checkBoxAutoRun.Size = new System.Drawing.Size(65, 17);
            this.checkBoxAutoRun.TabIndex = 10;
            this.checkBoxAutoRun.Text = "Enabled";
            this.checkBoxAutoRun.UseVisualStyleBackColor = true;
            this.checkBoxAutoRun.CheckedChanged += new System.EventHandler(this.checkBoxAutoRun_CheckedChanged);
            // 
            // radioButtonCodeData
            // 
            this.radioButtonCodeData.AutoSize = true;
            this.radioButtonCodeData.Location = new System.Drawing.Point(183, 57);
            this.radioButtonCodeData.Name = "radioButtonCodeData";
            this.radioButtonCodeData.Size = new System.Drawing.Size(78, 17);
            this.radioButtonCodeData.TabIndex = 9;
            this.radioButtonCodeData.TabStop = true;
            this.radioButtonCodeData.Text = "Code/Data";
            this.radioButtonCodeData.UseVisualStyleBackColor = true;
            this.radioButtonCodeData.CheckedChanged += new System.EventHandler(this.radioButtonCodeData_CheckedChanged);
            // 
            // radioButtonBasic
            // 
            this.radioButtonBasic.AutoSize = true;
            this.radioButtonBasic.Location = new System.Drawing.Point(106, 57);
            this.radioButtonBasic.Name = "radioButtonBasic";
            this.radioButtonBasic.Size = new System.Drawing.Size(56, 17);
            this.radioButtonBasic.TabIndex = 8;
            this.radioButtonBasic.TabStop = true;
            this.radioButtonBasic.Text = "BASIC";
            this.radioButtonBasic.UseVisualStyleBackColor = true;
            this.radioButtonBasic.CheckedChanged += new System.EventHandler(this.radioButtonBasic_CheckedChanged);
            // 
            // numericUpDownEndAddress
            // 
            this.numericUpDownEndAddress.Hexadecimal = true;
            this.numericUpDownEndAddress.Location = new System.Drawing.Point(203, 121);
            this.numericUpDownEndAddress.Name = "numericUpDownEndAddress";
            this.numericUpDownEndAddress.ReadOnly = true;
            this.numericUpDownEndAddress.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownEndAddress.TabIndex = 7;
            // 
            // numericUpDownStartAddress
            // 
            this.numericUpDownStartAddress.Hexadecimal = true;
            this.numericUpDownStartAddress.Location = new System.Drawing.Point(106, 121);
            this.numericUpDownStartAddress.Name = "numericUpDownStartAddress";
            this.numericUpDownStartAddress.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownStartAddress.TabIndex = 6;
            this.numericUpDownStartAddress.ValueChanged += new System.EventHandler(this.numericUpDownStartAddress_ValueChanged);
            // 
            // textBoxProgramName
            // 
            this.textBoxProgramName.Location = new System.Drawing.Point(106, 24);
            this.textBoxProgramName.Name = "textBoxProgramName";
            this.textBoxProgramName.Size = new System.Drawing.Size(155, 20);
            this.textBoxProgramName.TabIndex = 5;
            this.textBoxProgramName.TextChanged += new System.EventHandler(this.textBoxProgramName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Auto Run :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Program Format :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Memory Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Program Name :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxTapeFolder);
            this.groupBox4.Controls.Add(this.textBoxTapeName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(9, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(483, 76);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tape Details";
            // 
            // textBoxTapeFolder
            // 
            this.textBoxTapeFolder.Location = new System.Drawing.Point(57, 45);
            this.textBoxTapeFolder.Name = "textBoxTapeFolder";
            this.textBoxTapeFolder.ReadOnly = true;
            this.textBoxTapeFolder.Size = new System.Drawing.Size(415, 20);
            this.textBoxTapeFolder.TabIndex = 5;
            // 
            // textBoxTapeName
            // 
            this.textBoxTapeName.Location = new System.Drawing.Point(57, 19);
            this.textBoxTapeName.Name = "textBoxTapeName";
            this.textBoxTapeName.ReadOnly = true;
            this.textBoxTapeName.Size = new System.Drawing.Size(415, 20);
            this.textBoxTapeName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(406, 286);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(325, 286);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // EditTapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 316);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTapeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Tape";
            this.Load += new System.EventHandler(this.EditTapeForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEndAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartAddress)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPrograms;
        private System.Windows.Forms.ColumnHeader columnHeaderProgramName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxTapeFolder;
        private System.Windows.Forms.TextBox textBoxTapeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxAutoRun;
        private System.Windows.Forms.RadioButton radioButtonCodeData;
        private System.Windows.Forms.RadioButton radioButtonBasic;
        private System.Windows.Forms.NumericUpDown numericUpDownEndAddress;
        private System.Windows.Forms.NumericUpDown numericUpDownStartAddress;
        private System.Windows.Forms.TextBox textBoxProgramName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelProgramLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSave;
    }
}