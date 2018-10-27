namespace OricExplorer.User_Controls
{
    partial class SequentialFileViewer
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
            this.columnHeaderCount = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFormat = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderData = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listViewRecords
            // 
            this.listViewRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCount,
            this.columnHeaderFormat,
            this.columnHeaderData});
            this.listViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRecords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRecords.FullRowSelect = true;
            this.listViewRecords.GridLines = true;
            this.listViewRecords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRecords.Location = new System.Drawing.Point(0, 0);
            this.listViewRecords.MultiSelect = false;
            this.listViewRecords.Name = "listViewRecords";
            this.listViewRecords.Size = new System.Drawing.Size(614, 452);
            this.listViewRecords.TabIndex = 0;
            this.listViewRecords.UseCompatibleStateImageBehavior = false;
            this.listViewRecords.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "Record";
            this.columnHeaderCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeaderCount.Width = 93;
            // 
            // columnHeaderFormat
            // 
            this.columnHeaderFormat.Text = "Format";
            this.columnHeaderFormat.Width = 97;
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Data";
            this.columnHeaderData.Width = 336;
            // 
            // SequentialFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewRecords);
            this.Name = "SequentialFileViewer";
            this.Size = new System.Drawing.Size(614, 452);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRecords;
        private System.Windows.Forms.ColumnHeader columnHeaderFormat;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
    }
}
