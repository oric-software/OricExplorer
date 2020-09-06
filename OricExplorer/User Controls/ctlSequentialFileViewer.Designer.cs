namespace OricExplorer.User_Controls
{
    partial class ctlSequentialFileViewer
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
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwRecords
            // 
            this.lvwRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCount,
            this.colFormat,
            this.colData});
            this.lvwRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwRecords.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwRecords.FullRowSelect = true;
            this.lvwRecords.GridLines = true;
            this.lvwRecords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwRecords.HideSelection = false;
            this.lvwRecords.Location = new System.Drawing.Point(0, 0);
            this.lvwRecords.MultiSelect = false;
            this.lvwRecords.Name = "lvwRecords";
            this.lvwRecords.Size = new System.Drawing.Size(614, 452);
            this.lvwRecords.TabIndex = 0;
            this.lvwRecords.UseCompatibleStateImageBehavior = false;
            this.lvwRecords.View = System.Windows.Forms.View.Details;
            // 
            // colCount
            // 
            this.colCount.Text = "Record";
            this.colCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCount.Width = 93;
            // 
            // colFormat
            // 
            this.colFormat.Text = "Format";
            this.colFormat.Width = 97;
            // 
            // colData
            // 
            this.colData.Text = "Data";
            this.colData.Width = 336;
            // 
            // ctlSequentialFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwRecords);
            this.Name = "ctlSequentialFileViewer";
            this.Size = new System.Drawing.Size(614, 452);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwRecords;
        private System.Windows.Forms.ColumnHeader colFormat;
        private System.Windows.Forms.ColumnHeader colData;
        private System.Windows.Forms.ColumnHeader colCount;
    }
}
