namespace OricExplorer.Forms
{
    partial class frmSyntaxHighlighting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyntaxHighlighting));
            this.optBasicListing = new System.Windows.Forms.RadioButton();
            this.optAssemblerListing = new System.Windows.Forms.RadioButton();
            this.fcSample = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lblForegroundColor = new System.Windows.Forms.Label();
            this.chkStyleBold = new System.Windows.Forms.CheckBox();
            this.chkStyleItalic = new System.Windows.Forms.CheckBox();
            this.chkStyleUnderline = new System.Windows.Forms.CheckBox();
            this.lvwDisplayItems = new System.Windows.Forms.ListView();
            this.colItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPageBackgroundColor = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.grpShowSettingsFor = new GroupFrame.GroupFrame();
            this.optHyperbasicListing = new System.Windows.Forms.RadioButton();
            this.optTeleassListing = new System.Windows.Forms.RadioButton();
            this.optHexDumpListing = new System.Windows.Forms.RadioButton();
            this.grpDisplayItems = new GroupFrame.GroupFrame();
            this.grpItemColorAndStyle = new GroupFrame.GroupFrame();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.grpPageBackgroundColor = new GroupFrame.GroupFrame();
            this.grpSampleOuput = new GroupFrame.GroupFrame();
            ((System.ComponentModel.ISupportInitialize)(this.fcSample)).BeginInit();
            this.grpShowSettingsFor.SuspendLayout();
            this.grpDisplayItems.SuspendLayout();
            this.grpItemColorAndStyle.SuspendLayout();
            this.grpPageBackgroundColor.SuspendLayout();
            this.grpSampleOuput.SuspendLayout();
            this.SuspendLayout();
            // 
            // optBasicListing
            // 
            this.optBasicListing.AutoSize = true;
            this.optBasicListing.Location = new System.Drawing.Point(92, 22);
            this.optBasicListing.Name = "optBasicListing";
            this.optBasicListing.Size = new System.Drawing.Size(89, 17);
            this.optBasicListing.TabIndex = 1;
            this.optBasicListing.TabStop = true;
            this.optBasicListing.Text = "BASIC Listing";
            this.optBasicListing.UseVisualStyleBackColor = true;
            this.optBasicListing.CheckedChanged += new System.EventHandler(this.optBasicListing_CheckedChanged);
            // 
            // optAssemblerListing
            // 
            this.optAssemblerListing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optAssemblerListing.AutoSize = true;
            this.optAssemblerListing.Location = new System.Drawing.Point(437, 22);
            this.optAssemblerListing.Name = "optAssemblerListing";
            this.optAssemblerListing.Size = new System.Drawing.Size(106, 17);
            this.optAssemblerListing.TabIndex = 4;
            this.optAssemblerListing.TabStop = true;
            this.optAssemblerListing.Text = "Assembler Listing";
            this.optAssemblerListing.UseVisualStyleBackColor = true;
            this.optAssemblerListing.CheckedChanged += new System.EventHandler(this.optAssemblerListing_CheckedChanged);
            // 
            // fcSample
            // 
            this.fcSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fcSample.AutoCompleteBracketsList = new char[] {
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
            this.fcSample.AutoScrollMinSize = new System.Drawing.Size(2, 15);
            this.fcSample.BackBrush = null;
            this.fcSample.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fcSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fcSample.CharHeight = 15;
            this.fcSample.CharWidth = 7;
            this.fcSample.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fcSample.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fcSample.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fcSample.ForeColor = System.Drawing.Color.White;
            this.fcSample.IsReplaceMode = false;
            this.fcSample.Location = new System.Drawing.Point(6, 17);
            this.fcSample.Name = "fcSample";
            this.fcSample.Paddings = new System.Windows.Forms.Padding(0);
            this.fcSample.ReadOnly = true;
            this.fcSample.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fcSample.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fcSample.ServiceColors")));
            this.fcSample.ShowLineNumbers = false;
            this.fcSample.Size = new System.Drawing.Size(538, 246);
            this.fcSample.TabIndex = 0;
            this.fcSample.Zoom = 100;
            this.fcSample.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fcSample_TextChanged);
            // 
            // lblForegroundColor
            // 
            this.lblForegroundColor.BackColor = System.Drawing.Color.White;
            this.lblForegroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForegroundColor.Location = new System.Drawing.Point(9, 33);
            this.lblForegroundColor.Name = "lblForegroundColor";
            this.lblForegroundColor.Size = new System.Drawing.Size(182, 29);
            this.lblForegroundColor.TabIndex = 1;
            this.lblForegroundColor.Click += new System.EventHandler(this.lblForegroundColor_Click);
            // 
            // chkStyleBold
            // 
            this.chkStyleBold.AutoSize = true;
            this.chkStyleBold.Location = new System.Drawing.Point(9, 87);
            this.chkStyleBold.Name = "chkStyleBold";
            this.chkStyleBold.Size = new System.Drawing.Size(47, 17);
            this.chkStyleBold.TabIndex = 3;
            this.chkStyleBold.Text = "Bold";
            this.chkStyleBold.UseVisualStyleBackColor = true;
            this.chkStyleBold.Click += new System.EventHandler(this.chkStyleBold_Click);
            // 
            // chkStyleItalic
            // 
            this.chkStyleItalic.AutoSize = true;
            this.chkStyleItalic.Location = new System.Drawing.Point(64, 87);
            this.chkStyleItalic.Name = "chkStyleItalic";
            this.chkStyleItalic.Size = new System.Drawing.Size(48, 17);
            this.chkStyleItalic.TabIndex = 4;
            this.chkStyleItalic.Text = "Italic";
            this.chkStyleItalic.UseVisualStyleBackColor = true;
            this.chkStyleItalic.Click += new System.EventHandler(this.chkStyleItalic_Click);
            // 
            // chkStyleUnderline
            // 
            this.chkStyleUnderline.AutoSize = true;
            this.chkStyleUnderline.Location = new System.Drawing.Point(120, 87);
            this.chkStyleUnderline.Name = "chkStyleUnderline";
            this.chkStyleUnderline.Size = new System.Drawing.Size(71, 17);
            this.chkStyleUnderline.TabIndex = 5;
            this.chkStyleUnderline.Text = "Underline";
            this.chkStyleUnderline.UseVisualStyleBackColor = true;
            this.chkStyleUnderline.Click += new System.EventHandler(this.chkStyleUnderline_Click);
            // 
            // lvwDisplayItems
            // 
            this.lvwDisplayItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDisplayItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItems});
            this.lvwDisplayItems.FullRowSelect = true;
            this.lvwDisplayItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwDisplayItems.HideSelection = false;
            this.lvwDisplayItems.Location = new System.Drawing.Point(6, 20);
            this.lvwDisplayItems.MultiSelect = false;
            this.lvwDisplayItems.Name = "lvwDisplayItems";
            this.lvwDisplayItems.Size = new System.Drawing.Size(330, 177);
            this.lvwDisplayItems.TabIndex = 0;
            this.lvwDisplayItems.UseCompatibleStateImageBehavior = false;
            this.lvwDisplayItems.View = System.Windows.Forms.View.Details;
            this.lvwDisplayItems.SelectedIndexChanged += new System.EventHandler(this.lvwDisplayItems_SelectedIndexChanged);
            // 
            // colItems
            // 
            this.colItems.Text = "Item";
            this.colItems.Width = 290;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(393, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(474, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPageBackgroundColor
            // 
            this.lblPageBackgroundColor.BackColor = System.Drawing.Color.Black;
            this.lblPageBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPageBackgroundColor.Location = new System.Drawing.Point(9, 19);
            this.lblPageBackgroundColor.Name = "lblPageBackgroundColor";
            this.lblPageBackgroundColor.Size = new System.Drawing.Size(182, 29);
            this.lblPageBackgroundColor.TabIndex = 0;
            this.lblPageBackgroundColor.Click += new System.EventHandler(this.lblPageBackgroundColor_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefault.Location = new System.Drawing.Point(12, 550);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // grpShowSettingsFor
            // 
            this.grpShowSettingsFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpShowSettingsFor.Controls.Add(this.optHyperbasicListing);
            this.grpShowSettingsFor.Controls.Add(this.optTeleassListing);
            this.grpShowSettingsFor.Controls.Add(this.optHexDumpListing);
            this.grpShowSettingsFor.Controls.Add(this.optAssemblerListing);
            this.grpShowSettingsFor.Controls.Add(this.optBasicListing);
            this.grpShowSettingsFor.ForeColor = System.Drawing.Color.Black;
            this.grpShowSettingsFor.Location = new System.Drawing.Point(6, 6);
            this.grpShowSettingsFor.Name = "grpShowSettingsFor";
            this.grpShowSettingsFor.Size = new System.Drawing.Size(550, 52);
            this.grpShowSettingsFor.TabIndex = 0;
            this.grpShowSettingsFor.TabStop = false;
            this.grpShowSettingsFor.Text = "Show Settings For";
            // 
            // optHyperbasicListing
            // 
            this.optHyperbasicListing.AutoSize = true;
            this.optHyperbasicListing.Location = new System.Drawing.Point(189, 22);
            this.optHyperbasicListing.Name = "optHyperbasicListing";
            this.optHyperbasicListing.Size = new System.Drawing.Size(126, 17);
            this.optHyperbasicListing.TabIndex = 2;
            this.optHyperbasicListing.TabStop = true;
            this.optHyperbasicListing.Text = "HYPERBASIC Listing";
            this.optHyperbasicListing.UseVisualStyleBackColor = true;
            this.optHyperbasicListing.CheckedChanged += new System.EventHandler(this.optHyperbasicListing_CheckedChanged);
            // 
            // optTeleassListing
            // 
            this.optTeleassListing.AutoSize = true;
            this.optTeleassListing.Location = new System.Drawing.Point(323, 22);
            this.optTeleassListing.Name = "optTeleassListing";
            this.optTeleassListing.Size = new System.Drawing.Size(106, 17);
            this.optTeleassListing.TabIndex = 3;
            this.optTeleassListing.TabStop = true;
            this.optTeleassListing.Text = "TELEASS Listing";
            this.optTeleassListing.UseVisualStyleBackColor = true;
            this.optTeleassListing.CheckedChanged += new System.EventHandler(this.optTeleassListing_CheckedChanged);
            // 
            // optHexDumpListing
            // 
            this.optHexDumpListing.AutoSize = true;
            this.optHexDumpListing.Location = new System.Drawing.Point(6, 22);
            this.optHexDumpListing.Name = "optHexDumpListing";
            this.optHexDumpListing.Size = new System.Drawing.Size(78, 17);
            this.optHexDumpListing.TabIndex = 0;
            this.optHexDumpListing.TabStop = true;
            this.optHexDumpListing.Text = "HEX Dump";
            this.optHexDumpListing.UseVisualStyleBackColor = true;
            this.optHexDumpListing.CheckedChanged += new System.EventHandler(this.optHexDumpListing_CheckedChanged);
            // 
            // grpDisplayItems
            // 
            this.grpDisplayItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDisplayItems.Controls.Add(this.grpItemColorAndStyle);
            this.grpDisplayItems.Controls.Add(this.lvwDisplayItems);
            this.grpDisplayItems.Controls.Add(this.grpPageBackgroundColor);
            this.grpDisplayItems.Location = new System.Drawing.Point(6, 64);
            this.grpDisplayItems.Name = "grpDisplayItems";
            this.grpDisplayItems.Size = new System.Drawing.Size(550, 204);
            this.grpDisplayItems.TabIndex = 1;
            this.grpDisplayItems.TabStop = false;
            this.grpDisplayItems.Text = "Display Items";
            // 
            // grpItemColorAndStyle
            // 
            this.grpItemColorAndStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItemColorAndStyle.Controls.Add(this.chkStyleUnderline);
            this.grpItemColorAndStyle.Controls.Add(this.lblColor);
            this.grpItemColorAndStyle.Controls.Add(this.chkStyleItalic);
            this.grpItemColorAndStyle.Controls.Add(this.lblStyle);
            this.grpItemColorAndStyle.Controls.Add(this.chkStyleBold);
            this.grpItemColorAndStyle.Controls.Add(this.lblForegroundColor);
            this.grpItemColorAndStyle.Location = new System.Drawing.Point(344, 15);
            this.grpItemColorAndStyle.Name = "grpItemColorAndStyle";
            this.grpItemColorAndStyle.Size = new System.Drawing.Size(200, 117);
            this.grpItemColorAndStyle.TabIndex = 1;
            this.grpItemColorAndStyle.TabStop = false;
            this.grpItemColorAndStyle.Text = "Item Color/Style";
            this.grpItemColorAndStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(6, 16);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 0;
            this.lblColor.Text = "Color:";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(6, 71);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(33, 13);
            this.lblStyle.TabIndex = 2;
            this.lblStyle.Text = "Style:";
            this.lblStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpPageBackgroundColor
            // 
            this.grpPageBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPageBackgroundColor.Controls.Add(this.lblPageBackgroundColor);
            this.grpPageBackgroundColor.Location = new System.Drawing.Point(344, 138);
            this.grpPageBackgroundColor.Name = "grpPageBackgroundColor";
            this.grpPageBackgroundColor.Size = new System.Drawing.Size(200, 59);
            this.grpPageBackgroundColor.TabIndex = 2;
            this.grpPageBackgroundColor.TabStop = false;
            this.grpPageBackgroundColor.Text = "Page Background Color";
            this.grpPageBackgroundColor.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpSampleOuput
            // 
            this.grpSampleOuput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSampleOuput.Controls.Add(this.fcSample);
            this.grpSampleOuput.Location = new System.Drawing.Point(6, 274);
            this.grpSampleOuput.Name = "grpSampleOuput";
            this.grpSampleOuput.Size = new System.Drawing.Size(550, 270);
            this.grpSampleOuput.TabIndex = 2;
            this.grpSampleOuput.TabStop = false;
            this.grpSampleOuput.Text = "Sample Output";
            this.grpSampleOuput.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmSyntaxHighlighting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(561, 580);
            this.Controls.Add(this.grpSampleOuput);
            this.Controls.Add(this.grpDisplayItems);
            this.Controls.Add(this.grpShowSettingsFor);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSyntaxHighlighting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Syntax Highlighting";
            this.Load += new System.EventHandler(this.frmSyntaxHighlighting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fcSample)).EndInit();
            this.grpShowSettingsFor.ResumeLayout(false);
            this.grpShowSettingsFor.PerformLayout();
            this.grpDisplayItems.ResumeLayout(false);
            this.grpItemColorAndStyle.ResumeLayout(false);
            this.grpItemColorAndStyle.PerformLayout();
            this.grpPageBackgroundColor.ResumeLayout(false);
            this.grpSampleOuput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton optBasicListing;
        private System.Windows.Forms.RadioButton optAssemblerListing;
        private FastColoredTextBoxNS.FastColoredTextBox fcSample;
        private System.Windows.Forms.Label lblForegroundColor;
        private System.Windows.Forms.CheckBox chkStyleBold;
        private System.Windows.Forms.CheckBox chkStyleItalic;
        private System.Windows.Forms.CheckBox chkStyleUnderline;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwDisplayItems;
        private System.Windows.Forms.ColumnHeader colItems;
        private System.Windows.Forms.Label lblPageBackgroundColor;
        private System.Windows.Forms.Button btnDefault;
        private GroupFrame.GroupFrame grpShowSettingsFor;
        private GroupFrame.GroupFrame grpDisplayItems;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.RadioButton optHexDumpListing;
        private System.Windows.Forms.Label lblStyle;
        private GroupFrame.GroupFrame grpSampleOuput;
        private GroupFrame.GroupFrame grpPageBackgroundColor;
        private GroupFrame.GroupFrame grpItemColorAndStyle;
        private System.Windows.Forms.RadioButton optTeleassListing;
        private System.Windows.Forms.RadioButton optHyperbasicListing;
    }
}