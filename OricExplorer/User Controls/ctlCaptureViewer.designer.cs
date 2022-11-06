namespace OricExplorer.User_Controls
{
    partial class ctlCaptureViewer
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.chkSélection = new System.Windows.Forms.CheckBox();
            this.tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.AutoSize = true;
            this.tlp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp.ColumnCount = 1;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Controls.Add(this.picImage, 0, 0);
            this.tlp.Controls.Add(this.chkSélection, 0, 1);
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Margin = new System.Windows.Forms.Padding(0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 2;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp.Size = new System.Drawing.Size(243, 248);
            this.tlp.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picImage.Location = new System.Drawing.Point(1, 1);
            this.picImage.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(240, 224);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // chkSélection
            // 
            this.chkSélection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSélection.AutoSize = true;
            this.chkSélection.Location = new System.Drawing.Point(114, 230);
            this.chkSélection.Name = "chkSélection";
            this.chkSélection.Size = new System.Drawing.Size(15, 14);
            this.chkSélection.TabIndex = 1;
            this.chkSélection.UseVisualStyleBackColor = true;
            this.chkSélection.Click += new System.EventHandler(this.chkSélection_Click);
            // 
            // ctlCaptureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlp);
            this.Name = "ctlCaptureViewer";
            this.Size = new System.Drawing.Size(243, 248);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.CheckBox chkSélection;
    }
}
