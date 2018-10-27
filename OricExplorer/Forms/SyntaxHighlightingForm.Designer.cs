namespace OricExplorer.Forms
{
    partial class SyntaxHighlightingForm
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
            this.components = new System.ComponentModel.Container();
            this.radioButtonBasicListing = new System.Windows.Forms.RadioButton();
            this.radioButtonAssemblerListing = new System.Windows.Forms.RadioButton();
            this.fastColoredTextBoxSample = new FastColoredTextBoxNS.FastColoredTextBox();
            this.labelForegroundColour = new System.Windows.Forms.Label();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.checkBoxItalic = new System.Windows.Forms.CheckBox();
            this.checkBoxUnderline = new System.Windows.Forms.CheckBox();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPageBackgroundColour = new System.Windows.Forms.Label();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.groupFrame1 = new GroupFrame.GroupFrame();
            this.radioButtonHexDump = new System.Windows.Forms.RadioButton();
            this.groupFrame2 = new GroupFrame.GroupFrame();
            this.label1 = new System.Windows.Forms.Label();
            this.groupFrame3 = new GroupFrame.GroupFrame();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFrame4 = new GroupFrame.GroupFrame();
            this.groupFrame5 = new GroupFrame.GroupFrame();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSample)).BeginInit();
            this.groupFrame1.SuspendLayout();
            this.groupFrame2.SuspendLayout();
            this.groupFrame3.SuspendLayout();
            this.groupFrame4.SuspendLayout();
            this.groupFrame5.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonBasicListing
            // 
            this.radioButtonBasicListing.AutoSize = true;
            this.radioButtonBasicListing.Location = new System.Drawing.Point(149, 21);
            this.radioButtonBasicListing.Name = "radioButtonBasicListing";
            this.radioButtonBasicListing.Size = new System.Drawing.Size(89, 17);
            this.radioButtonBasicListing.TabIndex = 0;
            this.radioButtonBasicListing.TabStop = true;
            this.radioButtonBasicListing.Text = "BASIC Listing";
            this.radioButtonBasicListing.UseVisualStyleBackColor = true;
            this.radioButtonBasicListing.CheckedChanged += new System.EventHandler(this.radioButtonBasicListing_CheckedChanged);
            // 
            // radioButtonAssemblerListing
            // 
            this.radioButtonAssemblerListing.AutoSize = true;
            this.radioButtonAssemblerListing.Location = new System.Drawing.Point(285, 21);
            this.radioButtonAssemblerListing.Name = "radioButtonAssemblerListing";
            this.radioButtonAssemblerListing.Size = new System.Drawing.Size(106, 17);
            this.radioButtonAssemblerListing.TabIndex = 1;
            this.radioButtonAssemblerListing.TabStop = true;
            this.radioButtonAssemblerListing.Text = "Assembler Listing";
            this.radioButtonAssemblerListing.UseVisualStyleBackColor = true;
            this.radioButtonAssemblerListing.CheckedChanged += new System.EventHandler(this.radioButtonAssemblerListing_CheckedChanged);
            // 
            // fastColoredTextBoxSample
            // 
            this.fastColoredTextBoxSample.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBoxSample.AutoScrollMinSize = new System.Drawing.Size(2, 15);
            this.fastColoredTextBoxSample.BackBrush = null;
            this.fastColoredTextBoxSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fastColoredTextBoxSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fastColoredTextBoxSample.CharHeight = 15;
            this.fastColoredTextBoxSample.CharWidth = 7;
            this.fastColoredTextBoxSample.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBoxSample.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBoxSample.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fastColoredTextBoxSample.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBoxSample.IsReplaceMode = false;
            this.fastColoredTextBoxSample.Location = new System.Drawing.Point(6, 17);
            this.fastColoredTextBoxSample.Name = "fastColoredTextBoxSample";
            this.fastColoredTextBoxSample.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBoxSample.ReadOnly = true;
            this.fastColoredTextBoxSample.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBoxSample.ShowLineNumbers = false;
            this.fastColoredTextBoxSample.Size = new System.Drawing.Size(402, 239);
            this.fastColoredTextBoxSample.TabIndex = 2;
            this.fastColoredTextBoxSample.Zoom = 100;
            this.fastColoredTextBoxSample.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBoxSample_TextChanged);
            // 
            // labelForegroundColour
            // 
            this.labelForegroundColour.BackColor = System.Drawing.Color.White;
            this.labelForegroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelForegroundColour.Location = new System.Drawing.Point(9, 33);
            this.labelForegroundColour.Name = "labelForegroundColour";
            this.labelForegroundColour.Size = new System.Drawing.Size(182, 29);
            this.labelForegroundColour.TabIndex = 6;
            this.labelForegroundColour.Click += new System.EventHandler(this.labelForegroundColour_Click);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(9, 83);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(47, 17);
            this.checkBoxBold.TabIndex = 7;
            this.checkBoxBold.Text = "Bold";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
            // 
            // checkBoxItalic
            // 
            this.checkBoxItalic.AutoSize = true;
            this.checkBoxItalic.Location = new System.Drawing.Point(64, 83);
            this.checkBoxItalic.Name = "checkBoxItalic";
            this.checkBoxItalic.Size = new System.Drawing.Size(48, 17);
            this.checkBoxItalic.TabIndex = 8;
            this.checkBoxItalic.Text = "Italic";
            this.checkBoxItalic.UseVisualStyleBackColor = true;
            this.checkBoxItalic.CheckedChanged += new System.EventHandler(this.checkBoxItalic_CheckedChanged);
            // 
            // checkBoxUnderline
            // 
            this.checkBoxUnderline.AutoSize = true;
            this.checkBoxUnderline.Location = new System.Drawing.Point(120, 83);
            this.checkBoxUnderline.Name = "checkBoxUnderline";
            this.checkBoxUnderline.Size = new System.Drawing.Size(71, 17);
            this.checkBoxUnderline.TabIndex = 9;
            this.checkBoxUnderline.Text = "Underline";
            this.checkBoxUnderline.UseVisualStyleBackColor = true;
            this.checkBoxUnderline.CheckedChanged += new System.EventHandler(this.checkBoxUnderline_CheckedChanged);
            // 
            // listViewItems
            // 
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewItems.FullRowSelect = true;
            this.listViewItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(6, 21);
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(194, 177);
            this.listViewItems.TabIndex = 15;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            this.listViewItems.SelectedIndexChanged += new System.EventHandler(this.listViewItems_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 185;
            // 
            // buttonOkay
            // 
            this.buttonOkay.Location = new System.Drawing.Point(175, 542);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(75, 23);
            this.buttonOkay.TabIndex = 13;
            this.buttonOkay.Text = "Save";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(338, 542);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPageBackgroundColour
            // 
            this.labelPageBackgroundColour.BackColor = System.Drawing.Color.Black;
            this.labelPageBackgroundColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPageBackgroundColour.Location = new System.Drawing.Point(9, 19);
            this.labelPageBackgroundColour.Name = "labelPageBackgroundColour";
            this.labelPageBackgroundColour.Size = new System.Drawing.Size(182, 29);
            this.labelPageBackgroundColour.TabIndex = 19;
            this.labelPageBackgroundColour.Click += new System.EventHandler(this.labelPageBackgroundColor_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(12, 542);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 20;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // groupFrame1
            // 
            this.groupFrame1.Controls.Add(this.radioButtonHexDump);
            this.groupFrame1.Controls.Add(this.radioButtonAssemblerListing);
            this.groupFrame1.Controls.Add(this.radioButtonBasicListing);
            this.groupFrame1.ForeColor = System.Drawing.Color.Black;
            this.groupFrame1.Location = new System.Drawing.Point(6, 6);
            this.groupFrame1.Name = "groupFrame1";
            this.groupFrame1.Size = new System.Drawing.Size(414, 52);
            this.groupFrame1.TabIndex = 21;
            this.groupFrame1.TabStop = false;
            this.groupFrame1.Text = "Show Settings For";
            // 
            // radioButtonHexDump
            // 
            this.radioButtonHexDump.AutoSize = true;
            this.radioButtonHexDump.Enabled = false;
            this.radioButtonHexDump.Location = new System.Drawing.Point(24, 21);
            this.radioButtonHexDump.Name = "radioButtonHexDump";
            this.radioButtonHexDump.Size = new System.Drawing.Size(78, 17);
            this.radioButtonHexDump.TabIndex = 2;
            this.radioButtonHexDump.TabStop = true;
            this.radioButtonHexDump.Text = "HEX Dump";
            this.radioButtonHexDump.UseVisualStyleBackColor = true;
            // 
            // groupFrame2
            // 
            this.groupFrame2.Controls.Add(this.groupFrame5);
            this.groupFrame2.Controls.Add(this.listViewItems);
            this.groupFrame2.Controls.Add(this.groupFrame4);
            this.groupFrame2.Location = new System.Drawing.Point(6, 64);
            this.groupFrame2.Name = "groupFrame2";
            this.groupFrame2.Size = new System.Drawing.Size(414, 204);
            this.groupFrame2.TabIndex = 22;
            this.groupFrame2.TabStop = false;
            this.groupFrame2.Text = "Display Items";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Foreground Colour:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupFrame3
            // 
            this.groupFrame3.Controls.Add(this.fastColoredTextBoxSample);
            this.groupFrame3.Location = new System.Drawing.Point(6, 274);
            this.groupFrame3.Name = "groupFrame3";
            this.groupFrame3.Size = new System.Drawing.Size(414, 262);
            this.groupFrame3.TabIndex = 23;
            this.groupFrame3.TabStop = false;
            this.groupFrame3.Text = "Sample Output";
            this.groupFrame3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Style:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupFrame4
            // 
            this.groupFrame4.Controls.Add(this.labelPageBackgroundColour);
            this.groupFrame4.Location = new System.Drawing.Point(208, 139);
            this.groupFrame4.Name = "groupFrame4";
            this.groupFrame4.Size = new System.Drawing.Size(200, 59);
            this.groupFrame4.TabIndex = 24;
            this.groupFrame4.TabStop = false;
            this.groupFrame4.Text = "Page Background Colour";
            this.groupFrame4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame5
            // 
            this.groupFrame5.Controls.Add(this.checkBoxUnderline);
            this.groupFrame5.Controls.Add(this.label1);
            this.groupFrame5.Controls.Add(this.checkBoxItalic);
            this.groupFrame5.Controls.Add(this.label2);
            this.groupFrame5.Controls.Add(this.checkBoxBold);
            this.groupFrame5.Controls.Add(this.labelForegroundColour);
            this.groupFrame5.Location = new System.Drawing.Point(208, 21);
            this.groupFrame5.Name = "groupFrame5";
            this.groupFrame5.Size = new System.Drawing.Size(200, 112);
            this.groupFrame5.TabIndex = 25;
            this.groupFrame5.TabStop = false;
            this.groupFrame5.Text = "Item Colour/Style";
            this.groupFrame5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // SyntaxHighlightingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 572);
            this.Controls.Add(this.groupFrame3);
            this.Controls.Add(this.groupFrame2);
            this.Controls.Add(this.groupFrame1);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyntaxHighlightingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Syntax Highlighting";
            this.Load += new System.EventHandler(this.SyntaxHighlightingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSample)).EndInit();
            this.groupFrame1.ResumeLayout(false);
            this.groupFrame1.PerformLayout();
            this.groupFrame2.ResumeLayout(false);
            this.groupFrame3.ResumeLayout(false);
            this.groupFrame4.ResumeLayout(false);
            this.groupFrame5.ResumeLayout(false);
            this.groupFrame5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonBasicListing;
        private System.Windows.Forms.RadioButton radioButtonAssemblerListing;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxSample;
        private System.Windows.Forms.Label labelForegroundColour;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.CheckBox checkBoxItalic;
        private System.Windows.Forms.CheckBox checkBoxUnderline;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label labelPageBackgroundColour;
        private System.Windows.Forms.Button buttonDefault;
        private GroupFrame.GroupFrame groupFrame1;
        private GroupFrame.GroupFrame groupFrame2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonHexDump;
        private System.Windows.Forms.Label label2;
        private GroupFrame.GroupFrame groupFrame3;
        private GroupFrame.GroupFrame groupFrame4;
        private GroupFrame.GroupFrame groupFrame5;
    }
}