namespace OricExplorer
{
    partial class frmFileList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileList));
            this.tvwFileList = new System.Windows.Forms.TreeView();
            this.imlIcons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvwFileList
            // 
            this.tvwFileList.AllowDrop = true;
            this.tvwFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tvwFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFileList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwFileList.ForeColor = System.Drawing.Color.White;
            this.tvwFileList.FullRowSelect = true;
            this.tvwFileList.ImageIndex = 0;
            this.tvwFileList.ImageList = this.imlIcons;
            this.tvwFileList.LineColor = System.Drawing.Color.DimGray;
            this.tvwFileList.Location = new System.Drawing.Point(0, 0);
            this.tvwFileList.Name = "tvwFileList";
            this.tvwFileList.SelectedImageIndex = 0;
            this.tvwFileList.ShowNodeToolTips = true;
            this.tvwFileList.Size = new System.Drawing.Size(284, 261);
            this.tvwFileList.TabIndex = 0;
            this.tvwFileList.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwFileList_AfterLabelEdit);
            this.tvwFileList.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFileList_BeforeCollapse);
            this.tvwFileList.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFileList_BeforeExpand);
            this.tvwFileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwFileList_ItemDrag);
            this.tvwFileList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwFileList_NodeMouseClick);
            this.tvwFileList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwFileList_NodeMouseDoubleClick);
            this.tvwFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwFileList_DragDrop);
            this.tvwFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwFileList_DragOver);
            this.tvwFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwFileList_MouseDown);
            // 
            // imlIcons
            // 
            this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
            this.imlIcons.TransparentColor = System.Drawing.Color.White;
            this.imlIcons.Images.SetKeyName(0, "root");
            this.imlIcons.Images.SetKeyName(1, "folder");
            this.imlIcons.Images.SetKeyName(2, "tape");
            this.imlIcons.Images.SetKeyName(3, "rom");
            this.imlIcons.Images.SetKeyName(4, "disk");
            this.imlIcons.Images.SetKeyName(5, "disk_master");
            this.imlIcons.Images.SetKeyName(6, "disk_slave");
            this.imlIcons.Images.SetKeyName(7, "disk_game");
            this.imlIcons.Images.SetKeyName(8, "disk_unknown");
            this.imlIcons.Images.SetKeyName(9, "disk_hs");
            this.imlIcons.Images.SetKeyName(10, "binary");
            this.imlIcons.Images.SetKeyName(11, "text");
            this.imlIcons.Images.SetKeyName(12, "image_text");
            this.imlIcons.Images.SetKeyName(13, "image_hires");
            this.imlIcons.Images.SetKeyName(14, "image_unknown");
            this.imlIcons.Images.SetKeyName(15, "sequential");
            this.imlIcons.Images.SetKeyName(16, "direct");
            this.imlIcons.Images.SetKeyName(17, "font");
            this.imlIcons.Images.SetKeyName(18, "helpdoc");
            // 
            // frmFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tvwFileList);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmFileList";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "File List";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView tvwFileList;
        private System.Windows.Forms.ImageList imlIcons;
    }
}