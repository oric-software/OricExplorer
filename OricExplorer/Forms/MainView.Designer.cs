namespace OricExplorer.User_Controls
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.fastColoredTextBoxSourceCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControlMainView = new FarsiLibrary.Win.FATabStrip();
            this.faTabStripItemHexDump = new FarsiLibrary.Win.FATabStripItem();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.tabPageSourceCodeView = new FarsiLibrary.Win.FATabStripItem();
            this.tabPageDataView = new FarsiLibrary.Win.FATabStripItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSourceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMainView)).BeginInit();
            this.tabControlMainView.SuspendLayout();
            this.faTabStripItemHexDump.SuspendLayout();
            this.tabPageSourceCodeView.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastColoredTextBoxSourceCode
            // 
            this.fastColoredTextBoxSourceCode.AutoCompleteBracketsList = new char[] {
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
            this.fastColoredTextBoxSourceCode.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fastColoredTextBoxSourceCode.BackBrush = null;
            this.fastColoredTextBoxSourceCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fastColoredTextBoxSourceCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fastColoredTextBoxSourceCode.CharHeight = 14;
            this.fastColoredTextBoxSourceCode.CharWidth = 7;
            this.fastColoredTextBoxSourceCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBoxSourceCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBoxSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBoxSourceCode.Font = new System.Drawing.Font("Consolas", 9F);
            this.fastColoredTextBoxSourceCode.ForeColor = System.Drawing.Color.Gainsboro;
            this.fastColoredTextBoxSourceCode.IsReplaceMode = false;
            this.fastColoredTextBoxSourceCode.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBoxSourceCode.Name = "fastColoredTextBoxSourceCode";
            this.fastColoredTextBoxSourceCode.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBoxSourceCode.ReadOnly = true;
            this.fastColoredTextBoxSourceCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBoxSourceCode.ShowLineNumbers = false;
            this.fastColoredTextBoxSourceCode.Size = new System.Drawing.Size(835, 504);
            this.fastColoredTextBoxSourceCode.TabIndex = 2;
            this.fastColoredTextBoxSourceCode.Zoom = 100;
            this.fastColoredTextBoxSourceCode.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fastColoredTextBoxSourceCode_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "microdisc.ico");
            this.imageList1.Images.SetKeyName(1, "folderopen.ico");
            this.imageList1.Images.SetKeyName(2, "tree_image_tape.png");
            this.imageList1.Images.SetKeyName(3, "OricROM.ico");
            this.imageList1.Images.SetKeyName(4, "tree_image_disk.png");
            this.imageList1.Images.SetKeyName(5, "tree_image_disk_oricdos.PNG");
            this.imageList1.Images.SetKeyName(6, "tree_image_disk_sedoric.PNG");
            this.imageList1.Images.SetKeyName(7, "delete_16x.ico");
            this.imageList1.Images.SetKeyName(8, "db.ico");
            this.imageList1.Images.SetKeyName(9, "helpdoc.ico");
            this.imageList1.Images.SetKeyName(10, "fonfile.ico");
            this.imageList1.Images.SetKeyName(11, "VSObject_Type.bmp");
            this.imageList1.Images.SetKeyName(12, "tree_image_text.png");
            this.imageList1.Images.SetKeyName(13, "UtilityText.ico");
            this.imageList1.Images.SetKeyName(14, "tree_image_hires.png");
            this.imageList1.Images.SetKeyName(15, "tree_image_unknown.png");
            this.imageList1.Images.SetKeyName(16, "dbs.ico");
            this.imageList1.Images.SetKeyName(17, "unknown_disk.png");
            // 
            // tabControlMainView
            // 
            this.tabControlMainView.AlwaysShowClose = false;
            this.tabControlMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMainView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMainView.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.faTabStripItemHexDump,
            this.tabPageSourceCodeView,
            this.tabPageDataView});
            this.tabControlMainView.Location = new System.Drawing.Point(0, 0);
            this.tabControlMainView.Name = "tabControlMainView";
            this.tabControlMainView.SelectedItem = this.faTabStripItemHexDump;
            this.tabControlMainView.Size = new System.Drawing.Size(837, 525);
            this.tabControlMainView.TabIndex = 4;
            // 
            // faTabStripItemHexDump
            // 
            this.faTabStripItemHexDump.CanClose = false;
            this.faTabStripItemHexDump.Controls.Add(this.hexBox1);
            this.faTabStripItemHexDump.Image = ((System.Drawing.Image)(resources.GetObject("faTabStripItemHexDump.Image")));
            this.faTabStripItemHexDump.IsDrawn = true;
            this.faTabStripItemHexDump.Name = "faTabStripItemHexDump";
            this.faTabStripItemHexDump.Selected = true;
            this.faTabStripItemHexDump.Size = new System.Drawing.Size(835, 504);
            this.faTabStripItemHexDump.TabIndex = 0;
            this.faTabStripItemHexDump.Title = "Hex Dump";
            // 
            // hexBox1
            // 
            this.hexBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hexBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox1.ForeColor = System.Drawing.Color.White;
            this.hexBox1.GroupSize = 2;
            this.hexBox1.InfoForeColor = System.Drawing.Color.Teal;
            this.hexBox1.LineInfoPrefix = "$";
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.LineInfoWidth = 4;
            this.hexBox1.Location = new System.Drawing.Point(0, 0);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.SelectionBackColor = System.Drawing.Color.Red;
            this.hexBox1.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(835, 504);
            this.hexBox1.StringViewColour = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 4;
            this.hexBox1.UseFixedBytesPerLine = true;
            this.hexBox1.VScrollBarVisible = true;
            // 
            // tabPageSourceCodeView
            // 
            this.tabPageSourceCodeView.CanClose = false;
            this.tabPageSourceCodeView.Controls.Add(this.fastColoredTextBoxSourceCode);
            this.tabPageSourceCodeView.Image = ((System.Drawing.Image)(resources.GetObject("tabPageSourceCodeView.Image")));
            this.tabPageSourceCodeView.IsDrawn = true;
            this.tabPageSourceCodeView.Name = "tabPageSourceCodeView";
            this.tabPageSourceCodeView.Size = new System.Drawing.Size(835, 504);
            this.tabPageSourceCodeView.TabIndex = 1;
            this.tabPageSourceCodeView.Title = "Source Code";
            // 
            // tabPageDataView
            // 
            this.tabPageDataView.CanClose = false;
            this.tabPageDataView.Image = ((System.Drawing.Image)(resources.GetObject("tabPageDataView.Image")));
            this.tabPageDataView.IsDrawn = true;
            this.tabPageDataView.Name = "tabPageDataView";
            this.tabPageDataView.Size = new System.Drawing.Size(835, 504);
            this.tabPageDataView.TabIndex = 2;
            this.tabPageDataView.Title = "Data Viewer";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.closeAllButThisToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 70);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            // 
            // closeAllButThisToolStripMenuItem
            // 
            this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.closeAllButThisToolStripMenuItem.Text = "Close All But This";
            // 
            // MainView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(837, 525);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tabControlMainView);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBoxSourceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMainView)).EndInit();
            this.tabControlMainView.ResumeLayout(false);
            this.faTabStripItemHexDump.ResumeLayout(false);
            this.tabPageSourceCodeView.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBoxSourceCode;
        private System.Windows.Forms.ImageList imageList1;
        private FarsiLibrary.Win.FATabStrip tabControlMainView;
        private FarsiLibrary.Win.FATabStripItem faTabStripItemHexDump;
        private FarsiLibrary.Win.FATabStripItem tabPageSourceCodeView;
        private FarsiLibrary.Win.FATabStripItem tabPageDataView;
        //private System.Windows.Forms.Label label6;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
    }
}
