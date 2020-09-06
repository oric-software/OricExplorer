namespace OricExplorer.User_Controls
{
    partial class ctlDataFileViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwRecords = new System.Windows.Forms.ListView();
            this.colRecord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDataFile = new System.Windows.Forms.TabControl();
            this.tabpListView = new System.Windows.Forms.TabPage();
            this.tabpCardView = new System.Windows.Forms.TabPage();
            this.panCardView = new System.Windows.Forms.Panel();
            this.txtFieldData0 = new System.Windows.Forms.TextBox();
            this.lblFieldID0 = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.tabDataFile.SuspendLayout();
            this.tabpListView.SuspendLayout();
            this.tabpCardView.SuspendLayout();
            this.panCardView.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwRecords
            // 
            this.lvwRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRecord});
            this.lvwRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRecords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwRecords.FullRowSelect = true;
            this.lvwRecords.GridLines = true;
            this.lvwRecords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwRecords.HideSelection = false;
            this.lvwRecords.Location = new System.Drawing.Point(3, 3);
            this.lvwRecords.MultiSelect = false;
            this.lvwRecords.Name = "lvwRecords";
            this.lvwRecords.Size = new System.Drawing.Size(552, 275);
            this.lvwRecords.TabIndex = 1;
            this.lvwRecords.UseCompatibleStateImageBehavior = false;
            this.lvwRecords.View = System.Windows.Forms.View.Details;
            this.lvwRecords.DoubleClick += new System.EventHandler(this.lvwRecords_DoubleClick);
            // 
            // colRecord
            // 
            this.colRecord.Text = "Record";
            this.colRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabDataFile
            // 
            this.tabDataFile.Controls.Add(this.tabpListView);
            this.tabDataFile.Controls.Add(this.tabpCardView);
            this.tabDataFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataFile.Location = new System.Drawing.Point(0, 0);
            this.tabDataFile.Name = "tabDataFile";
            this.tabDataFile.SelectedIndex = 0;
            this.tabDataFile.Size = new System.Drawing.Size(566, 307);
            this.tabDataFile.TabIndex = 0;
            // 
            // tabpListView
            // 
            this.tabpListView.Controls.Add(this.lvwRecords);
            this.tabpListView.Location = new System.Drawing.Point(4, 22);
            this.tabpListView.Name = "tabpListView";
            this.tabpListView.Padding = new System.Windows.Forms.Padding(3);
            this.tabpListView.Size = new System.Drawing.Size(558, 281);
            this.tabpListView.TabIndex = 0;
            this.tabpListView.Text = "List View";
            this.tabpListView.UseVisualStyleBackColor = true;
            // 
            // tabpCardView
            // 
            this.tabpCardView.Controls.Add(this.panCardView);
            this.tabpCardView.Controls.Add(this.btnLast);
            this.tabpCardView.Controls.Add(this.btnNext);
            this.tabpCardView.Controls.Add(this.btnPrev);
            this.tabpCardView.Controls.Add(this.btnFirst);
            this.tabpCardView.Location = new System.Drawing.Point(4, 22);
            this.tabpCardView.Name = "tabpCardView";
            this.tabpCardView.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCardView.Size = new System.Drawing.Size(558, 281);
            this.tabpCardView.TabIndex = 1;
            this.tabpCardView.Text = "Card View";
            this.tabpCardView.UseVisualStyleBackColor = true;
            // 
            // panCardView
            // 
            this.panCardView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCardView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panCardView.Controls.Add(this.txtFieldData0);
            this.panCardView.Controls.Add(this.lblFieldID0);
            this.panCardView.Location = new System.Drawing.Point(6, 37);
            this.panCardView.Name = "panCardView";
            this.panCardView.Size = new System.Drawing.Size(546, 238);
            this.panCardView.TabIndex = 4;
            // 
            // txtFieldData0
            // 
            this.txtFieldData0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFieldData0.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFieldData0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldData0.Location = new System.Drawing.Point(79, 11);
            this.txtFieldData0.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txtFieldData0.Name = "txtFieldData0";
            this.txtFieldData0.ReadOnly = true;
            this.txtFieldData0.Size = new System.Drawing.Size(454, 20);
            this.txtFieldData0.TabIndex = 1;
            // 
            // lblFieldID0
            // 
            this.lblFieldID0.AutoSize = true;
            this.lblFieldID0.BackColor = System.Drawing.Color.Transparent;
            this.lblFieldID0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldID0.ForeColor = System.Drawing.Color.Black;
            this.lblFieldID0.Location = new System.Drawing.Point(12, 14);
            this.lblFieldID0.Name = "lblFieldID0";
            this.lblFieldID0.Size = new System.Drawing.Size(61, 13);
            this.lblFieldID0.TabIndex = 0;
            this.lblFieldID0.Text = "Field 1 :";
            // 
            // btnLast
            // 
            this.btnLast.ForeColor = System.Drawing.Color.Black;
            this.btnLast.Image = global::OricExplorer.Properties.Resources.control_end_blue;
            this.btnLast.Location = new System.Drawing.Point(96, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 24);
            this.btnLast.TabIndex = 3;
            this.btnLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Image = global::OricExplorer.Properties.Resources.control_fastforward_blue;
            this.btnNext.Location = new System.Drawing.Point(66, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.ForeColor = System.Drawing.Color.Black;
            this.btnPrev.Image = global::OricExplorer.Properties.Resources.control_fastrewind_blue;
            this.btnPrev.Location = new System.Drawing.Point(36, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(24, 24);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ForeColor = System.Drawing.Color.Black;
            this.btnFirst.Image = global::OricExplorer.Properties.Resources.control_start_blue;
            this.btnFirst.Location = new System.Drawing.Point(6, 6);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 24);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // ctlDataFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDataFile);
            this.Name = "ctlDataFileViewer";
            this.Size = new System.Drawing.Size(566, 307);
            this.tabDataFile.ResumeLayout(false);
            this.tabpListView.ResumeLayout(false);
            this.tabpCardView.ResumeLayout(false);
            this.panCardView.ResumeLayout(false);
            this.panCardView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwRecords;
        private System.Windows.Forms.ColumnHeader colRecord;
        private System.Windows.Forms.TabControl tabDataFile;
        private System.Windows.Forms.TabPage tabpListView;
        private System.Windows.Forms.TabPage tabpCardView;
        private System.Windows.Forms.TextBox txtFieldData0;
        private System.Windows.Forms.Label lblFieldID0;
        private System.Windows.Forms.Panel panCardView;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
    }
}
