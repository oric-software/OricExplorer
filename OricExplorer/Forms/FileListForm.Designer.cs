namespace OricExplorer
{
    partial class FileListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListForm));
            this.treeFileList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeFileList
            // 
            this.treeFileList.AllowDrop = true;
            this.treeFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.treeFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFileList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeFileList.ForeColor = System.Drawing.Color.White;
            this.treeFileList.FullRowSelect = true;
            this.treeFileList.ImageIndex = 0;
            this.treeFileList.ImageList = this.imageList1;
            this.treeFileList.LineColor = System.Drawing.Color.DimGray;
            this.treeFileList.Location = new System.Drawing.Point(0, 0);
            this.treeFileList.Name = "treeFileList";
            this.treeFileList.SelectedImageIndex = 0;
            this.treeFileList.ShowNodeToolTips = true;
            this.treeFileList.Size = new System.Drawing.Size(284, 261);
            this.treeFileList.TabIndex = 0;
            this.treeFileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeFileList_ItemDrag);
            this.treeFileList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFileList_NodeMouseClick);
            this.treeFileList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFileList_NodeMouseDoubleClick);
            this.treeFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeFileList_DragDrop);
            this.treeFileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeFileList_DragEnter);
            this.treeFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.treeFileList_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "OricExplorer.ico");
            this.imageList1.Images.SetKeyName(1, "Folder-icon.png");
            this.imageList1.Images.SetKeyName(2, "image_tape.png");
            this.imageList1.Images.SetKeyName(3, "OricROM.ico");
            this.imageList1.Images.SetKeyName(4, "tree_image_disk.png");
            this.imageList1.Images.SetKeyName(5, "tree_image_disk_oricdos.PNG");
            this.imageList1.Images.SetKeyName(6, "tree_image_disk_sedoric.PNG");
            this.imageList1.Images.SetKeyName(7, "delete_16x.ico");
            this.imageList1.Images.SetKeyName(8, "db.ico");
            this.imageList1.Images.SetKeyName(9, "helpdoc.ico");
            this.imageList1.Images.SetKeyName(10, "fonfile.ico");
            this.imageList1.Images.SetKeyName(11, "document-binary-icon.png");
            this.imageList1.Images.SetKeyName(12, "tree_image_text.png");
            this.imageList1.Images.SetKeyName(13, "source-code-icon.png");
            this.imageList1.Images.SetKeyName(14, "kig_doc.png");
            this.imageList1.Images.SetKeyName(15, "tree_image_unknown.png");
            this.imageList1.Images.SetKeyName(16, "dbs.ico");
            this.imageList1.Images.SetKeyName(17, "unknown_disk.png");
            // 
            // FileListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.treeFileList);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FileListForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "File List";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeFileList;
        private System.Windows.Forms.ImageList imageList1;

    }
}