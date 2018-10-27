namespace OricExplorer.Forms
{
    partial class ProgramInfoForm
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
            this.flowLayoutPanelInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelInfo
            // 
            this.flowLayoutPanelInfo.AutoScroll = true;
            this.flowLayoutPanelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.flowLayoutPanelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelInfo.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelInfo.Name = "flowLayoutPanelInfo";
            this.flowLayoutPanelInfo.Size = new System.Drawing.Size(184, 551);
            this.flowLayoutPanelInfo.TabIndex = 0;
            this.flowLayoutPanelInfo.WrapContents = false;
            // 
            // ProgramInfoForm
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(184, 551);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.flowLayoutPanelInfo);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(200, 39);
            this.Name = "ProgramInfoForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.Text = "Program Information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfo;
    }
}