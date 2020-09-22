namespace OricExplorer
{
    partial class TextBoxPlus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextBoxPlus));
            this.picClear = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).BeginInit();
            this.SuspendLayout();
            // 
            // picRAZ
            // 
            this.picClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.picClear.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picRAZ.ErrorImage")));
            this.picClear.Image = ((System.Drawing.Image)(resources.GetObject("picRAZ.Image")));
            this.picClear.InitialImage = ((System.Drawing.Image)(resources.GetObject("picRAZ.InitialImage")));
            this.picClear.Location = new System.Drawing.Point(80, 2);
            this.picClear.Name = "picRAZ";
            this.picClear.Size = new System.Drawing.Size(13, 13);
            this.picClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClear.TabIndex = 5;
            this.picClear.TabStop = false;
            this.picClear.Click += new System.EventHandler(this.picClear_Click);
            this.picClear.MouseEnter += new System.EventHandler(this.picClear_MouseEnter);
            this.picClear.MouseLeave += new System.EventHandler(this.picClear_MouseLeave);
            // 
            // DipiTextBox
            // 
            this.Controls.Add(this.picClear);
            ((System.ComponentModel.ISupportInitialize)(this.picClear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picClear;
    }
}
