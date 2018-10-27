namespace OricExplorer.User_Controls
{
    partial class DataFileViewer
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
            this.listViewRecords = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlDataFile = new System.Windows.Forms.TabControl();
            this.tabPageListView = new System.Windows.Forms.TabPage();
            this.tabPageCardView = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxFieldData0 = new System.Windows.Forms.TextBox();
            this.labelFieldID0 = new System.Windows.Forms.Label();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonFirst = new System.Windows.Forms.Button();
            this.tabControlDataFile.SuspendLayout();
            this.tabPageListView.SuspendLayout();
            this.tabPageCardView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewRecords
            // 
            this.listViewRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRecords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRecords.FullRowSelect = true;
            this.listViewRecords.GridLines = true;
            this.listViewRecords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRecords.Location = new System.Drawing.Point(3, 3);
            this.listViewRecords.MultiSelect = false;
            this.listViewRecords.Name = "listViewRecords";
            this.listViewRecords.Size = new System.Drawing.Size(552, 275);
            this.listViewRecords.TabIndex = 0;
            this.listViewRecords.UseCompatibleStateImageBehavior = false;
            this.listViewRecords.View = System.Windows.Forms.View.Details;
            this.listViewRecords.DoubleClick += new System.EventHandler(this.listViewRecords_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Record";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControlDataFile
            // 
            this.tabControlDataFile.Controls.Add(this.tabPageListView);
            this.tabControlDataFile.Controls.Add(this.tabPageCardView);
            this.tabControlDataFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDataFile.Location = new System.Drawing.Point(0, 0);
            this.tabControlDataFile.Name = "tabControlDataFile";
            this.tabControlDataFile.SelectedIndex = 0;
            this.tabControlDataFile.Size = new System.Drawing.Size(566, 307);
            this.tabControlDataFile.TabIndex = 1;
            // 
            // tabPageListView
            // 
            this.tabPageListView.Controls.Add(this.listViewRecords);
            this.tabPageListView.Location = new System.Drawing.Point(4, 22);
            this.tabPageListView.Name = "tabPageListView";
            this.tabPageListView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListView.Size = new System.Drawing.Size(558, 281);
            this.tabPageListView.TabIndex = 0;
            this.tabPageListView.Text = "List View";
            this.tabPageListView.UseVisualStyleBackColor = true;
            // 
            // tabPageCardView
            // 
            this.tabPageCardView.Controls.Add(this.panel1);
            this.tabPageCardView.Controls.Add(this.buttonLast);
            this.tabPageCardView.Controls.Add(this.buttonNext);
            this.tabPageCardView.Controls.Add(this.buttonPrev);
            this.tabPageCardView.Controls.Add(this.buttonFirst);
            this.tabPageCardView.Location = new System.Drawing.Point(4, 22);
            this.tabPageCardView.Name = "tabPageCardView";
            this.tabPageCardView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCardView.Size = new System.Drawing.Size(558, 281);
            this.tabPageCardView.TabIndex = 1;
            this.tabPageCardView.Text = "Card View";
            this.tabPageCardView.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.textBoxFieldData0);
            this.panel1.Controls.Add(this.labelFieldID0);
            this.panel1.Location = new System.Drawing.Point(6, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 238);
            this.panel1.TabIndex = 7;
            // 
            // textBoxFieldData0
            // 
            this.textBoxFieldData0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFieldData0.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxFieldData0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFieldData0.Location = new System.Drawing.Point(79, 11);
            this.textBoxFieldData0.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.textBoxFieldData0.Name = "textBoxFieldData0";
            this.textBoxFieldData0.ReadOnly = true;
            this.textBoxFieldData0.Size = new System.Drawing.Size(454, 20);
            this.textBoxFieldData0.TabIndex = 2;
            // 
            // labelFieldID0
            // 
            this.labelFieldID0.AutoSize = true;
            this.labelFieldID0.BackColor = System.Drawing.Color.Transparent;
            this.labelFieldID0.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFieldID0.ForeColor = System.Drawing.Color.Black;
            this.labelFieldID0.Location = new System.Drawing.Point(12, 14);
            this.labelFieldID0.Name = "labelFieldID0";
            this.labelFieldID0.Size = new System.Drawing.Size(61, 13);
            this.labelFieldID0.TabIndex = 1;
            this.labelFieldID0.Text = "Field 1 :";
            // 
            // buttonLast
            // 
            this.buttonLast.ForeColor = System.Drawing.Color.Black;
            this.buttonLast.Image = global::OricExplorer.Properties.Resources.control_end_blue;
            this.buttonLast.Location = new System.Drawing.Point(96, 7);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(24, 24);
            this.buttonLast.TabIndex = 6;
            this.buttonLast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.ForeColor = System.Drawing.Color.Black;
            this.buttonNext.Image = global::OricExplorer.Properties.Resources.control_fastforward_blue;
            this.buttonNext.Location = new System.Drawing.Point(66, 7);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(24, 24);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.ForeColor = System.Drawing.Color.Black;
            this.buttonPrev.Image = global::OricExplorer.Properties.Resources.control_rewind_blue;
            this.buttonPrev.Location = new System.Drawing.Point(36, 6);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(24, 24);
            this.buttonPrev.TabIndex = 4;
            this.buttonPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonFirst
            // 
            this.buttonFirst.ForeColor = System.Drawing.Color.Black;
            this.buttonFirst.Image = global::OricExplorer.Properties.Resources.control_start_blue1;
            this.buttonFirst.Location = new System.Drawing.Point(6, 6);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(24, 24);
            this.buttonFirst.TabIndex = 3;
            this.buttonFirst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // DataFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDataFile);
            this.Name = "DataFileViewer";
            this.Size = new System.Drawing.Size(566, 307);
            this.tabControlDataFile.ResumeLayout(false);
            this.tabPageListView.ResumeLayout(false);
            this.tabPageCardView.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRecords;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabControl tabControlDataFile;
        private System.Windows.Forms.TabPage tabPageListView;
        private System.Windows.Forms.TabPage tabPageCardView;
        private System.Windows.Forms.TextBox textBoxFieldData0;
        private System.Windows.Forms.Label labelFieldID0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonFirst;
    }
}
