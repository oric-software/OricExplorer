namespace OricExplorer
{
    partial class ctlDataViewerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDataViewerControl));
            this.optDisplayHires = new System.Windows.Forms.RadioButton();
            this.optDisplayText = new System.Windows.Forms.RadioButton();
            this.optDisplayCharSet = new System.Windows.Forms.RadioButton();
            this.btnZoomReset = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnOffsetReset = new System.Windows.Forms.Button();
            this.btnOffsetInc = new System.Windows.Forms.Button();
            this.btnOffsetDec = new System.Windows.Forms.Button();
            this.btnWidthReset = new System.Windows.Forms.Button();
            this.btnWidthDec = new System.Windows.Forms.Button();
            this.btnWidthInc = new System.Windows.Forms.Button();
            this.chkAttributesForeground = new System.Windows.Forms.CheckBox();
            this.chkAttributesBackground = new System.Windows.Forms.CheckBox();
            this.chkAttributesOthers = new System.Windows.Forms.CheckBox();
            this.ibxWidth = new InfoBox.InfoBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ibxOffset = new InfoBox.InfoBox();
            this.prtDocument = new System.Drawing.Printing.PrintDocument();
            this.panImageInner = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.grpDisplayFormat = new GroupFrame.GroupFrame();
            this.grpZoomOptions = new GroupFrame.GroupFrame();
            this.ibxZoom = new InfoBox.InfoBox();
            this.grpOffsetOptions = new GroupFrame.GroupFrame();
            this.grpDisplayWidth = new GroupFrame.GroupFrame();
            this.grpAttributes = new GroupFrame.GroupFrame();
            this.grpOutputOptions = new GroupFrame.GroupFrame();
            this.panImageOuter = new System.Windows.Forms.Panel();
            this.panImageInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.grpDisplayFormat.SuspendLayout();
            this.grpZoomOptions.SuspendLayout();
            this.grpOffsetOptions.SuspendLayout();
            this.grpDisplayWidth.SuspendLayout();
            this.grpAttributes.SuspendLayout();
            this.grpOutputOptions.SuspendLayout();
            this.panImageOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // optDisplayHires
            // 
            this.optDisplayHires.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDisplayHires.Location = new System.Drawing.Point(6, 19);
            this.optDisplayHires.Name = "optDisplayHires";
            this.optDisplayHires.Size = new System.Drawing.Size(58, 23);
            this.optDisplayHires.TabIndex = 0;
            this.optDisplayHires.TabStop = true;
            this.optDisplayHires.Text = "HIRES";
            this.optDisplayHires.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optDisplayHires.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optDisplayHires.UseVisualStyleBackColor = true;
            this.optDisplayHires.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // optDisplayText
            // 
            this.optDisplayText.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDisplayText.Location = new System.Drawing.Point(71, 19);
            this.optDisplayText.Name = "optDisplayText";
            this.optDisplayText.Size = new System.Drawing.Size(58, 23);
            this.optDisplayText.TabIndex = 1;
            this.optDisplayText.TabStop = true;
            this.optDisplayText.Text = "TEXT";
            this.optDisplayText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optDisplayText.UseVisualStyleBackColor = true;
            this.optDisplayText.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // optDisplayCharSet
            // 
            this.optDisplayCharSet.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDisplayCharSet.Location = new System.Drawing.Point(136, 19);
            this.optDisplayCharSet.Name = "optDisplayCharSet";
            this.optDisplayCharSet.Size = new System.Drawing.Size(58, 23);
            this.optDisplayCharSet.TabIndex = 2;
            this.optDisplayCharSet.TabStop = true;
            this.optDisplayCharSet.Text = "CHAR";
            this.optDisplayCharSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optDisplayCharSet.UseVisualStyleBackColor = true;
            this.optDisplayCharSet.CheckedChanged += new System.EventHandler(this.ChangePreviewFormat);
            // 
            // btnZoomReset
            // 
            this.btnZoomReset.ForeColor = System.Drawing.Color.Black;
            this.btnZoomReset.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomReset.Image")));
            this.btnZoomReset.Location = new System.Drawing.Point(112, 47);
            this.btnZoomReset.Name = "btnZoomReset";
            this.btnZoomReset.Size = new System.Drawing.Size(82, 25);
            this.btnZoomReset.TabIndex = 3;
            this.btnZoomReset.Text = "Reset";
            this.btnZoomReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZoomReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZoomReset.UseVisualStyleBackColor = true;
            this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(37, 47);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(25, 25);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(6, 47);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(25, 25);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnOffsetReset
            // 
            this.btnOffsetReset.ForeColor = System.Drawing.Color.Black;
            this.btnOffsetReset.Image = ((System.Drawing.Image)(resources.GetObject("btnOffsetReset.Image")));
            this.btnOffsetReset.Location = new System.Drawing.Point(112, 47);
            this.btnOffsetReset.Name = "btnOffsetReset";
            this.btnOffsetReset.Size = new System.Drawing.Size(82, 25);
            this.btnOffsetReset.TabIndex = 3;
            this.btnOffsetReset.Text = "Reset";
            this.btnOffsetReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOffsetReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOffsetReset.UseVisualStyleBackColor = true;
            this.btnOffsetReset.Click += new System.EventHandler(this.btnOffsetReset_Click);
            // 
            // btnOffsetInc
            // 
            this.btnOffsetInc.ForeColor = System.Drawing.Color.Black;
            this.btnOffsetInc.Image = ((System.Drawing.Image)(resources.GetObject("btnOffsetInc.Image")));
            this.btnOffsetInc.Location = new System.Drawing.Point(37, 47);
            this.btnOffsetInc.Name = "btnOffsetInc";
            this.btnOffsetInc.Size = new System.Drawing.Size(25, 25);
            this.btnOffsetInc.TabIndex = 2;
            this.btnOffsetInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOffsetInc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOffsetInc.UseVisualStyleBackColor = true;
            this.btnOffsetInc.Click += new System.EventHandler(this.btnOffsetInc_Click);
            // 
            // btnOffsetDec
            // 
            this.btnOffsetDec.ForeColor = System.Drawing.Color.Black;
            this.btnOffsetDec.Image = ((System.Drawing.Image)(resources.GetObject("btnOffsetDec.Image")));
            this.btnOffsetDec.Location = new System.Drawing.Point(6, 47);
            this.btnOffsetDec.Name = "btnOffsetDec";
            this.btnOffsetDec.Size = new System.Drawing.Size(25, 25);
            this.btnOffsetDec.TabIndex = 1;
            this.btnOffsetDec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOffsetDec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOffsetDec.UseVisualStyleBackColor = true;
            this.btnOffsetDec.Click += new System.EventHandler(this.btnOffsetDec_Click);
            // 
            // btnWidthReset
            // 
            this.btnWidthReset.ForeColor = System.Drawing.Color.Black;
            this.btnWidthReset.Image = ((System.Drawing.Image)(resources.GetObject("btnWidthReset.Image")));
            this.btnWidthReset.Location = new System.Drawing.Point(112, 47);
            this.btnWidthReset.Name = "btnWidthReset";
            this.btnWidthReset.Size = new System.Drawing.Size(82, 25);
            this.btnWidthReset.TabIndex = 3;
            this.btnWidthReset.Text = "Reset";
            this.btnWidthReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWidthReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWidthReset.UseVisualStyleBackColor = true;
            this.btnWidthReset.Click += new System.EventHandler(this.btnWidthReset_Click);
            // 
            // btnWidthDec
            // 
            this.btnWidthDec.ForeColor = System.Drawing.Color.Black;
            this.btnWidthDec.Image = ((System.Drawing.Image)(resources.GetObject("btnWidthDec.Image")));
            this.btnWidthDec.Location = new System.Drawing.Point(7, 47);
            this.btnWidthDec.Name = "btnWidthDec";
            this.btnWidthDec.Size = new System.Drawing.Size(25, 25);
            this.btnWidthDec.TabIndex = 1;
            this.btnWidthDec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWidthDec.UseVisualStyleBackColor = true;
            this.btnWidthDec.Click += new System.EventHandler(this.btnWidthDec_Click);
            // 
            // btnWidthInc
            // 
            this.btnWidthInc.ForeColor = System.Drawing.Color.Black;
            this.btnWidthInc.Image = ((System.Drawing.Image)(resources.GetObject("btnWidthInc.Image")));
            this.btnWidthInc.Location = new System.Drawing.Point(38, 47);
            this.btnWidthInc.Name = "btnWidthInc";
            this.btnWidthInc.Size = new System.Drawing.Size(25, 25);
            this.btnWidthInc.TabIndex = 2;
            this.btnWidthInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWidthInc.UseVisualStyleBackColor = true;
            this.btnWidthInc.Click += new System.EventHandler(this.btnWidthInc_Click);
            // 
            // chkAttributesForeground
            // 
            this.chkAttributesForeground.AutoSize = true;
            this.chkAttributesForeground.Location = new System.Drawing.Point(11, 40);
            this.chkAttributesForeground.Name = "chkAttributesForeground";
            this.chkAttributesForeground.Size = new System.Drawing.Size(41, 17);
            this.chkAttributesForeground.TabIndex = 1;
            this.chkAttributesForeground.Text = "Ink";
            this.chkAttributesForeground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAttributesForeground.UseVisualStyleBackColor = true;
            this.chkAttributesForeground.CheckedChanged += new System.EventHandler(this.chkAttributesForeground_CheckedChanged);
            // 
            // chkAttributesBackground
            // 
            this.chkAttributesBackground.AutoSize = true;
            this.chkAttributesBackground.Location = new System.Drawing.Point(11, 19);
            this.chkAttributesBackground.Name = "chkAttributesBackground";
            this.chkAttributesBackground.Size = new System.Drawing.Size(54, 17);
            this.chkAttributesBackground.TabIndex = 0;
            this.chkAttributesBackground.Text = "Paper";
            this.chkAttributesBackground.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAttributesBackground.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkAttributesBackground.UseVisualStyleBackColor = true;
            this.chkAttributesBackground.CheckedChanged += new System.EventHandler(this.chkAttributesBackground_CheckedChanged);
            // 
            // chkAttributesOthers
            // 
            this.chkAttributesOthers.AutoSize = true;
            this.chkAttributesOthers.Location = new System.Drawing.Point(11, 61);
            this.chkAttributesOthers.Name = "chkAttributesOthers";
            this.chkAttributesOthers.Size = new System.Drawing.Size(144, 30);
            this.chkAttributesOthers.TabIndex = 2;
            this.chkAttributesOthers.Text = "Others\r\n(Double Height/Flashing)";
            this.chkAttributesOthers.UseVisualStyleBackColor = true;
            this.chkAttributesOthers.CheckedChanged += new System.EventHandler(this.chkAttributesOthers_CheckedChanged);
            // 
            // ibxWidth
            // 
            this.ibxWidth.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxWidth.ForeColor = System.Drawing.Color.Black;
            this.ibxWidth.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxWidth.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxWidth.Location = new System.Drawing.Point(6, 19);
            this.ibxWidth.Name = "ibxWidth";
            this.ibxWidth.Size = new System.Drawing.Size(188, 22);
            this.ibxWidth.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(103, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Image";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Image = global::OricExplorer.Properties.Resources.PrintHS;
            this.btnPrint.Location = new System.Drawing.Point(6, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 25);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Image";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ibxOffset
            // 
            this.ibxOffset.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxOffset.ForeColor = System.Drawing.Color.Black;
            this.ibxOffset.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxOffset.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxOffset.Location = new System.Drawing.Point(6, 19);
            this.ibxOffset.Name = "ibxOffset";
            this.ibxOffset.Size = new System.Drawing.Size(188, 22);
            this.ibxOffset.TabIndex = 0;
            // 
            // prtDocument
            // 
            this.prtDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocument_PrintPage);
            // 
            // panImageInner
            // 
            this.panImageInner.AutoScroll = true;
            this.panImageInner.BackColor = System.Drawing.Color.Black;
            this.panImageInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImageInner.Controls.Add(this.picImage);
            this.panImageInner.Location = new System.Drawing.Point(17, 16);
            this.panImageInner.Name = "panImageInner";
            this.panImageInner.Size = new System.Drawing.Size(504, 448);
            this.panImageInner.TabIndex = 0;
            this.panImageInner.MouseEnter += new System.EventHandler(this.panImageInner_MouseEnter);
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picImage.Location = new System.Drawing.Point(-2, -2);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(480, 448);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseEnter += new System.EventHandler(this.panImageInner_MouseEnter);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            // 
            // grpDisplayFormat
            // 
            this.grpDisplayFormat.Controls.Add(this.optDisplayHires);
            this.grpDisplayFormat.Controls.Add(this.optDisplayText);
            this.grpDisplayFormat.Controls.Add(this.optDisplayCharSet);
            this.grpDisplayFormat.Location = new System.Drawing.Point(6, 6);
            this.grpDisplayFormat.Name = "grpDisplayFormat";
            this.grpDisplayFormat.Size = new System.Drawing.Size(200, 52);
            this.grpDisplayFormat.TabIndex = 0;
            this.grpDisplayFormat.TabStop = false;
            this.grpDisplayFormat.Text = "Display Format";
            this.grpDisplayFormat.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpZoomOptions
            // 
            this.grpZoomOptions.Controls.Add(this.ibxZoom);
            this.grpZoomOptions.Controls.Add(this.btnZoomReset);
            this.grpZoomOptions.Controls.Add(this.btnZoomIn);
            this.grpZoomOptions.Controls.Add(this.btnZoomOut);
            this.grpZoomOptions.Location = new System.Drawing.Point(6, 64);
            this.grpZoomOptions.Name = "grpZoomOptions";
            this.grpZoomOptions.Size = new System.Drawing.Size(200, 82);
            this.grpZoomOptions.TabIndex = 1;
            this.grpZoomOptions.TabStop = false;
            this.grpZoomOptions.Text = "Zoom Options";
            this.grpZoomOptions.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // ibxZoom
            // 
            this.ibxZoom.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxZoom.ForeColor = System.Drawing.Color.Black;
            this.ibxZoom.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxZoom.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxZoom.Location = new System.Drawing.Point(6, 19);
            this.ibxZoom.Name = "ibxZoom";
            this.ibxZoom.Size = new System.Drawing.Size(188, 22);
            this.ibxZoom.TabIndex = 0;
            // 
            // grpOffsetOptions
            // 
            this.grpOffsetOptions.Controls.Add(this.ibxOffset);
            this.grpOffsetOptions.Controls.Add(this.btnOffsetDec);
            this.grpOffsetOptions.Controls.Add(this.btnOffsetInc);
            this.grpOffsetOptions.Controls.Add(this.btnOffsetReset);
            this.grpOffsetOptions.Location = new System.Drawing.Point(6, 152);
            this.grpOffsetOptions.Name = "grpOffsetOptions";
            this.grpOffsetOptions.Size = new System.Drawing.Size(200, 82);
            this.grpOffsetOptions.TabIndex = 2;
            this.grpOffsetOptions.TabStop = false;
            this.grpOffsetOptions.Text = "Offset Options";
            this.grpOffsetOptions.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpDisplayWidth
            // 
            this.grpDisplayWidth.Controls.Add(this.ibxWidth);
            this.grpDisplayWidth.Controls.Add(this.btnWidthReset);
            this.grpDisplayWidth.Controls.Add(this.btnWidthInc);
            this.grpDisplayWidth.Controls.Add(this.btnWidthDec);
            this.grpDisplayWidth.Location = new System.Drawing.Point(6, 240);
            this.grpDisplayWidth.Name = "grpDisplayWidth";
            this.grpDisplayWidth.Size = new System.Drawing.Size(200, 82);
            this.grpDisplayWidth.TabIndex = 3;
            this.grpDisplayWidth.TabStop = false;
            this.grpDisplayWidth.Text = "Display Width";
            this.grpDisplayWidth.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.chkAttributesBackground);
            this.grpAttributes.Controls.Add(this.chkAttributesForeground);
            this.grpAttributes.Controls.Add(this.chkAttributesOthers);
            this.grpAttributes.Location = new System.Drawing.Point(6, 328);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(200, 100);
            this.grpAttributes.TabIndex = 4;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Show/Hide Attributes";
            this.grpAttributes.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpOutputOptions
            // 
            this.grpOutputOptions.Controls.Add(this.btnPrint);
            this.grpOutputOptions.Controls.Add(this.btnSave);
            this.grpOutputOptions.Location = new System.Drawing.Point(6, 434);
            this.grpOutputOptions.Name = "grpOutputOptions";
            this.grpOutputOptions.Size = new System.Drawing.Size(200, 52);
            this.grpOutputOptions.TabIndex = 5;
            this.grpOutputOptions.TabStop = false;
            this.grpOutputOptions.Text = "Output Options";
            this.grpOutputOptions.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panImageOuter
            // 
            this.panImageOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImageOuter.Controls.Add(this.panImageInner);
            this.panImageOuter.Location = new System.Drawing.Point(212, 6);
            this.panImageOuter.Name = "panImageOuter";
            this.panImageOuter.Size = new System.Drawing.Size(538, 480);
            this.panImageOuter.TabIndex = 6;
            // 
            // ctlDataViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panImageOuter);
            this.Controls.Add(this.grpOutputOptions);
            this.Controls.Add(this.grpAttributes);
            this.Controls.Add(this.grpDisplayWidth);
            this.Controls.Add(this.grpOffsetOptions);
            this.Controls.Add(this.grpZoomOptions);
            this.Controls.Add(this.grpDisplayFormat);
            this.MinimumSize = new System.Drawing.Size(554, 354);
            this.Name = "ctlDataViewerControl";
            this.Size = new System.Drawing.Size(758, 493);
            this.panImageInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.grpDisplayFormat.ResumeLayout(false);
            this.grpZoomOptions.ResumeLayout(false);
            this.grpOffsetOptions.ResumeLayout(false);
            this.grpDisplayWidth.ResumeLayout(false);
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            this.grpOutputOptions.ResumeLayout(false);
            this.panImageOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panImageInner;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.RadioButton optDisplayCharSet;
        private System.Windows.Forms.RadioButton optDisplayText;
        private System.Windows.Forms.RadioButton optDisplayHires;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnOffsetInc;
        private System.Windows.Forms.Button btnOffsetDec;
        private System.Windows.Forms.Button btnWidthInc;
        private System.Windows.Forms.Button btnWidthDec;
        private System.Windows.Forms.Button btnOffsetReset;
        private System.Windows.Forms.Button btnWidthReset;
        private System.Windows.Forms.Button btnZoomReset;
        private System.Windows.Forms.CheckBox chkAttributesForeground;
        private System.Windows.Forms.CheckBox chkAttributesBackground;
        private System.Windows.Forms.CheckBox chkAttributesOthers;
        private InfoBox.InfoBox ibxOffset;
        private InfoBox.InfoBox ibxWidth;
        private System.Drawing.Printing.PrintDocument prtDocument;
        private GroupFrame.GroupFrame grpDisplayFormat;
        private GroupFrame.GroupFrame grpZoomOptions;
        private InfoBox.InfoBox ibxZoom;
        private GroupFrame.GroupFrame grpOffsetOptions;
        private GroupFrame.GroupFrame grpDisplayWidth;
        private GroupFrame.GroupFrame grpAttributes;
        private GroupFrame.GroupFrame grpOutputOptions;
        private System.Windows.Forms.Panel panImageOuter;
    }
}