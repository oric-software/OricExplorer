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
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new OricExplorer.TextBoxPlus();
            this.btnGo = new System.Windows.Forms.Button();
            this.tlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwFileList
            // 
            this.tvwFileList.AllowDrop = true;
            this.tvwFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tlp.SetColumnSpan(this.tvwFileList, 3);
            this.tvwFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFileList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwFileList.ForeColor = System.Drawing.Color.White;
            this.tvwFileList.FullRowSelect = true;
            this.tvwFileList.HideSelection = false;
            this.tvwFileList.ImageIndex = 0;
            this.tvwFileList.ImageList = this.imlIcons;
            this.tvwFileList.LineColor = System.Drawing.Color.DimGray;
            this.tvwFileList.Location = new System.Drawing.Point(3, 3);
            this.tvwFileList.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tvwFileList.Name = "tvwFileList";
            this.tvwFileList.SelectedImageIndex = 0;
            this.tvwFileList.ShowNodeToolTips = true;
            this.tvwFileList.Size = new System.Drawing.Size(278, 229);
            this.tvwFileList.TabIndex = 0;
            this.tvwFileList.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwFileList_AfterLabelEdit);
            this.tvwFileList.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFileList_BeforeCollapse);
            this.tvwFileList.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFileList_BeforeExpand);
            this.tvwFileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvwFileList_ItemDrag);
            this.tvwFileList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwFileList_NodeMouseClick);
            this.tvwFileList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwFileList_NodeMouseDoubleClick);
            this.tvwFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwFileList_DragDrop);
            this.tvwFileList.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwFileList_DragOver);
            this.tvwFileList.Leave += new System.EventHandler(this.tvwFileList_Leave);
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
            this.imlIcons.Images.SetKeyName(10, "other_file");
            this.imlIcons.Images.SetKeyName(11, "binary");
            this.imlIcons.Images.SetKeyName(12, "text");
            this.imlIcons.Images.SetKeyName(13, "image_text");
            this.imlIcons.Images.SetKeyName(14, "image_hires");
            this.imlIcons.Images.SetKeyName(15, "image_unknown");
            this.imlIcons.Images.SetKeyName(16, "sequential");
            this.imlIcons.Images.SetKeyName(17, "direct");
            this.imlIcons.Images.SetKeyName(18, "font");
            this.imlIcons.Images.SetKeyName(19, "helpdoc");
            // 
            // tlp
            // 
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Controls.Add(this.tvwFileList, 0, 0);
            this.tlp.Controls.Add(this.lblFilter, 0, 1);
            this.tlp.Controls.Add(this.txtFilter, 1, 1);
            this.tlp.Controls.Add(this.btnGo, 2, 1);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 2;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp.Size = new System.Drawing.Size(284, 261);
            this.tlp.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 240);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(29, 13);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.ClearButton = true;
            this.txtFilter.Location = new System.Drawing.Point(38, 236);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(203, 20);
            this.txtFilter.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGo.AutoSize = true;
            this.btnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGo.Location = new System.Drawing.Point(247, 235);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(34, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmFileList
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tlp);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmFileList";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "File List";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFileList_KeyDown);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView tvwFileList;
        private System.Windows.Forms.ImageList imlIcons;
        private System.Windows.Forms.TableLayoutPanel tlp;
        public OricExplorer.TextBoxPlus txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnGo;
    }
}