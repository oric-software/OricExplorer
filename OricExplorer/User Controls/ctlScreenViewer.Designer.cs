namespace OricExplorer
{
    partial class ctlScreenViewerControl
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
            if(disposing && (components != null))
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
            this.prtDocument = new System.Drawing.Printing.PrintDocument();
            this.lblScreenPosition = new System.Windows.Forms.Label();
            this.lblScreenAddress = new System.Windows.Forms.Label();
            this.lblAsciiCode = new System.Windows.Forms.Label();
            this.grpScreenImage = new System.Windows.Forms.GroupBox();
            this.grpScreenAttributes = new System.Windows.Forms.GroupBox();
            this.chkAttributeIndicator = new System.Windows.Forms.CheckBox();
            this.chkAttributeOther = new System.Windows.Forms.CheckBox();
            this.chkAttributePaper = new System.Windows.Forms.CheckBox();
            this.chkAttributeInk = new System.Windows.Forms.CheckBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picScreenImage = new System.Windows.Forms.PictureBox();
            this.grpZoomedImage = new System.Windows.Forms.GroupBox();
            this.btnZoomReset = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.picZoomedImage = new System.Windows.Forms.PictureBox();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.ibxAsciiHex = new InfoBox.InfoBox();
            this.ibxAsciiDec = new InfoBox.InfoBox();
            this.ibxAddressHex = new InfoBox.InfoBox();
            this.ibxAddressDec = new InfoBox.InfoBox();
            this.ibxScreenByte = new InfoBox.InfoBox();
            this.ibxScreenPosition = new InfoBox.InfoBox();
            this.ibxCellFormat = new InfoBox.InfoBox();
            this.tlpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpCharacterAndAttributeInformation = new System.Windows.Forms.GroupBox();
            this.ibxCellDetails = new InfoBox.InfoBox();
            this.grpScreenImage.SuspendLayout();
            this.grpScreenAttributes.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreenImage)).BeginInit();
            this.grpZoomedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomedImage)).BeginInit();
            this.grpInformation.SuspendLayout();
            this.grpCharacterAndAttributeInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // prtDocument
            // 
            this.prtDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocument_PrintPage);
            // 
            // lblScreenPosition
            // 
            this.lblScreenPosition.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenPosition.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScreenPosition.Location = new System.Drawing.Point(5, 22);
            this.lblScreenPosition.Name = "lblScreenPosition";
            this.lblScreenPosition.Size = new System.Drawing.Size(93, 13);
            this.lblScreenPosition.TabIndex = 0;
            this.lblScreenPosition.Text = "Screen Position :";
            this.lblScreenPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScreenAddress
            // 
            this.lblScreenAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblScreenAddress.Location = new System.Drawing.Point(5, 54);
            this.lblScreenAddress.Name = "lblScreenAddress";
            this.lblScreenAddress.Size = new System.Drawing.Size(93, 13);
            this.lblScreenAddress.TabIndex = 3;
            this.lblScreenAddress.Text = "Screen Address :";
            this.lblScreenAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAsciiCode
            // 
            this.lblAsciiCode.BackColor = System.Drawing.Color.Transparent;
            this.lblAsciiCode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAsciiCode.Location = new System.Drawing.Point(5, 86);
            this.lblAsciiCode.Name = "lblAsciiCode";
            this.lblAsciiCode.Size = new System.Drawing.Size(93, 13);
            this.lblAsciiCode.TabIndex = 6;
            this.lblAsciiCode.Text = "ASCII Code :";
            this.lblAsciiCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpScreenImage
            // 
            this.grpScreenImage.Controls.Add(this.grpScreenAttributes);
            this.grpScreenImage.Controls.Add(this.grpOptions);
            this.grpScreenImage.Controls.Add(this.picScreenImage);
            this.grpScreenImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScreenImage.Location = new System.Drawing.Point(13, 8);
            this.grpScreenImage.Name = "grpScreenImage";
            this.grpScreenImage.Size = new System.Drawing.Size(494, 523);
            this.grpScreenImage.TabIndex = 0;
            this.grpScreenImage.TabStop = false;
            this.grpScreenImage.Text = "Screen Image";
            // 
            // grpScreenAttributes
            // 
            this.grpScreenAttributes.Controls.Add(this.chkAttributeIndicator);
            this.grpScreenAttributes.Controls.Add(this.chkAttributeOther);
            this.grpScreenAttributes.Controls.Add(this.chkAttributePaper);
            this.grpScreenAttributes.Controls.Add(this.chkAttributeInk);
            this.grpScreenAttributes.Location = new System.Drawing.Point(7, 472);
            this.grpScreenAttributes.Name = "grpScreenAttributes";
            this.grpScreenAttributes.Size = new System.Drawing.Size(308, 44);
            this.grpScreenAttributes.TabIndex = 0;
            this.grpScreenAttributes.TabStop = false;
            this.grpScreenAttributes.Text = "Show/Hide Screen Attributes";
            // 
            // chkAttributeIndicator
            // 
            this.chkAttributeIndicator.ForeColor = System.Drawing.Color.Black;
            this.chkAttributeIndicator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAttributeIndicator.Location = new System.Drawing.Point(9, 19);
            this.chkAttributeIndicator.Name = "chkAttributeIndicator";
            this.chkAttributeIndicator.Size = new System.Drawing.Size(126, 20);
            this.chkAttributeIndicator.TabIndex = 0;
            this.chkAttributeIndicator.Text = "Attribute Indicator";
            this.tlpToolTip.SetToolTip(this.chkAttributeIndicator, "Show/Hide Grid");
            this.chkAttributeIndicator.UseVisualStyleBackColor = true;
            this.chkAttributeIndicator.CheckedChanged += new System.EventHandler(this.chkAttributeIndicator_CheckedChanged);
            // 
            // chkAttributeOther
            // 
            this.chkAttributeOther.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAttributeOther.Location = new System.Drawing.Point(250, 19);
            this.chkAttributeOther.Name = "chkAttributeOther";
            this.chkAttributeOther.Size = new System.Drawing.Size(57, 20);
            this.chkAttributeOther.TabIndex = 3;
            this.chkAttributeOther.Text = "Other";
            this.tlpToolTip.SetToolTip(this.chkAttributeOther, "Show/Hide Ink Attributes");
            this.chkAttributeOther.UseVisualStyleBackColor = true;
            this.chkAttributeOther.CheckedChanged += new System.EventHandler(this.chkAttributeOther_CheckedChanged);
            // 
            // chkAttributePaper
            // 
            this.chkAttributePaper.Location = new System.Drawing.Point(140, 19);
            this.chkAttributePaper.Name = "chkAttributePaper";
            this.chkAttributePaper.Size = new System.Drawing.Size(56, 20);
            this.chkAttributePaper.TabIndex = 1;
            this.chkAttributePaper.Text = "Paper";
            this.tlpToolTip.SetToolTip(this.chkAttributePaper, "Show/Hide Paper Attributes");
            this.chkAttributePaper.UseVisualStyleBackColor = true;
            this.chkAttributePaper.CheckedChanged += new System.EventHandler(this.chkAttributePaper_CheckedChanged);
            // 
            // chkAttributeInk
            // 
            this.chkAttributeInk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAttributeInk.Location = new System.Drawing.Point(201, 19);
            this.chkAttributeInk.Name = "chkAttributeInk";
            this.chkAttributeInk.Size = new System.Drawing.Size(44, 20);
            this.chkAttributeInk.TabIndex = 2;
            this.chkAttributeInk.Text = "Ink";
            this.tlpToolTip.SetToolTip(this.chkAttributeInk, "Show/Hide Ink Attributes");
            this.chkAttributeInk.UseVisualStyleBackColor = true;
            this.chkAttributeInk.CheckedChanged += new System.EventHandler(this.chkAttributeInk_CheckedChanged);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.btnPrint);
            this.grpOptions.Controls.Add(this.btnSave);
            this.grpOptions.Location = new System.Drawing.Point(321, 472);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(166, 45);
            this.grpOptions.TabIndex = 1;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(5, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Image";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picScreenImage
            // 
            this.picScreenImage.BackColor = System.Drawing.Color.Black;
            this.picScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreenImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picScreenImage.Location = new System.Drawing.Point(7, 18);
            this.picScreenImage.Name = "picScreenImage";
            this.picScreenImage.Size = new System.Drawing.Size(480, 448);
            this.picScreenImage.TabIndex = 0;
            this.picScreenImage.TabStop = false;
            this.picScreenImage.MouseLeave += new System.EventHandler(this.picScreenImage_MouseLeave);
            this.picScreenImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScreenImage_MouseMove);
            // 
            // grpZoomedImage
            // 
            this.grpZoomedImage.Controls.Add(this.btnZoomReset);
            this.grpZoomedImage.Controls.Add(this.btnZoomOut);
            this.grpZoomedImage.Controls.Add(this.btnZoomIn);
            this.grpZoomedImage.Controls.Add(this.picZoomedImage);
            this.grpZoomedImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpZoomedImage.Location = new System.Drawing.Point(516, 8);
            this.grpZoomedImage.Name = "grpZoomedImage";
            this.grpZoomedImage.Size = new System.Drawing.Size(259, 281);
            this.grpZoomedImage.TabIndex = 1;
            this.grpZoomedImage.TabStop = false;
            this.grpZoomedImage.Text = "Zoomed View (x2)";
            // 
            // btnZoomReset
            // 
            this.btnZoomReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomReset.Location = new System.Drawing.Point(175, 249);
            this.btnZoomReset.Name = "btnZoomReset";
            this.btnZoomReset.Size = new System.Drawing.Size(75, 23);
            this.btnZoomReset.TabIndex = 2;
            this.btnZoomReset.Text = "Reset";
            this.btnZoomReset.UseVisualStyleBackColor = true;
            this.btnZoomReset.Click += new System.EventHandler(this.btnZoomReset_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(92, 249);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(75, 23);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(9, 249);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 23);
            this.btnZoomIn.TabIndex = 0;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // picZoomedImage
            // 
            this.picZoomedImage.BackColor = System.Drawing.Color.Black;
            this.picZoomedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picZoomedImage.Location = new System.Drawing.Point(9, 18);
            this.picZoomedImage.Name = "picZoomedImage";
            this.picZoomedImage.Size = new System.Drawing.Size(241, 225);
            this.picZoomedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picZoomedImage.TabIndex = 35;
            this.picZoomedImage.TabStop = false;
            // 
            // grpInformation
            // 
            this.grpInformation.Controls.Add(this.ibxAsciiHex);
            this.grpInformation.Controls.Add(this.ibxAsciiDec);
            this.grpInformation.Controls.Add(this.ibxAddressHex);
            this.grpInformation.Controls.Add(this.ibxAddressDec);
            this.grpInformation.Controls.Add(this.ibxScreenByte);
            this.grpInformation.Controls.Add(this.ibxScreenPosition);
            this.grpInformation.Controls.Add(this.lblScreenPosition);
            this.grpInformation.Controls.Add(this.lblScreenAddress);
            this.grpInformation.Controls.Add(this.lblAsciiCode);
            this.grpInformation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInformation.Location = new System.Drawing.Point(516, 295);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(259, 115);
            this.grpInformation.TabIndex = 2;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "Information";
            // 
            // ibxAsciiHex
            // 
            this.ibxAsciiHex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxAsciiHex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAsciiHex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAsciiHex.Location = new System.Drawing.Point(179, 81);
            this.ibxAsciiHex.Name = "ibxAsciiHex";
            this.ibxAsciiHex.Size = new System.Drawing.Size(71, 22);
            this.ibxAsciiHex.TabIndex = 8;
            // 
            // ibxAsciiDec
            // 
            this.ibxAsciiDec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxAsciiDec.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAsciiDec.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAsciiDec.Location = new System.Drawing.Point(102, 81);
            this.ibxAsciiDec.Name = "ibxAsciiDec";
            this.ibxAsciiDec.Size = new System.Drawing.Size(71, 22);
            this.ibxAsciiDec.TabIndex = 7;
            // 
            // ibxAddressHex
            // 
            this.ibxAddressHex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxAddressHex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAddressHex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAddressHex.Location = new System.Drawing.Point(179, 49);
            this.ibxAddressHex.Name = "ibxAddressHex";
            this.ibxAddressHex.Size = new System.Drawing.Size(71, 22);
            this.ibxAddressHex.TabIndex = 5;
            // 
            // ibxAddressDec
            // 
            this.ibxAddressDec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxAddressDec.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAddressDec.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxAddressDec.Location = new System.Drawing.Point(102, 49);
            this.ibxAddressDec.Name = "ibxAddressDec";
            this.ibxAddressDec.Size = new System.Drawing.Size(71, 22);
            this.ibxAddressDec.TabIndex = 4;
            // 
            // ibxScreenByte
            // 
            this.ibxScreenByte.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxScreenByte.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxScreenByte.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxScreenByte.Location = new System.Drawing.Point(179, 17);
            this.ibxScreenByte.Name = "ibxScreenByte";
            this.ibxScreenByte.Size = new System.Drawing.Size(71, 22);
            this.ibxScreenByte.TabIndex = 2;
            // 
            // ibxScreenPosition
            // 
            this.ibxScreenPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxScreenPosition.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxScreenPosition.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxScreenPosition.Location = new System.Drawing.Point(102, 17);
            this.ibxScreenPosition.Name = "ibxScreenPosition";
            this.ibxScreenPosition.Size = new System.Drawing.Size(71, 22);
            this.ibxScreenPosition.TabIndex = 1;
            // 
            // ibxCellFormat
            // 
            this.ibxCellFormat.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxCellFormat.ForeColor = System.Drawing.Color.Maroon;
            this.ibxCellFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCellFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCellFormat.Location = new System.Drawing.Point(9, 22);
            this.ibxCellFormat.Name = "ibxCellFormat";
            this.ibxCellFormat.Size = new System.Drawing.Size(241, 22);
            this.ibxCellFormat.TabIndex = 0;
            // 
            // grpCharacterAndAttributeInformation
            // 
            this.grpCharacterAndAttributeInformation.Controls.Add(this.ibxCellDetails);
            this.grpCharacterAndAttributeInformation.Controls.Add(this.ibxCellFormat);
            this.grpCharacterAndAttributeInformation.Location = new System.Drawing.Point(516, 416);
            this.grpCharacterAndAttributeInformation.Name = "grpCharacterAndAttributeInformation";
            this.grpCharacterAndAttributeInformation.Size = new System.Drawing.Size(259, 85);
            this.grpCharacterAndAttributeInformation.TabIndex = 3;
            this.grpCharacterAndAttributeInformation.TabStop = false;
            this.grpCharacterAndAttributeInformation.Text = "Character / Attribute Information";
            // 
            // ibxCellDetails
            // 
            this.ibxCellDetails.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxCellDetails.ForeColor = System.Drawing.Color.Maroon;
            this.ibxCellDetails.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCellDetails.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCellDetails.Location = new System.Drawing.Point(9, 49);
            this.ibxCellDetails.Name = "ibxCellDetails";
            this.ibxCellDetails.Size = new System.Drawing.Size(241, 22);
            this.ibxCellDetails.TabIndex = 1;
            // 
            // ctlScreenViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCharacterAndAttributeInformation);
            this.Controls.Add(this.grpZoomedImage);
            this.Controls.Add(this.grpScreenImage);
            this.Controls.Add(this.grpInformation);
            this.Name = "ctlScreenViewerControl";
            this.Size = new System.Drawing.Size(788, 541);
            this.grpScreenImage.ResumeLayout(false);
            this.grpScreenAttributes.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScreenImage)).EndInit();
            this.grpZoomedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picZoomedImage)).EndInit();
            this.grpInformation.ResumeLayout(false);
            this.grpCharacterAndAttributeInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picScreenImage;
        private System.Drawing.Printing.PrintDocument prtDocument;
        private System.Windows.Forms.PictureBox picZoomedImage;
        private System.Windows.Forms.Label lblScreenPosition;
        private System.Windows.Forms.Label lblScreenAddress;
        private System.Windows.Forms.Label lblAsciiCode;
        private System.Windows.Forms.GroupBox grpScreenImage;
        private System.Windows.Forms.GroupBox grpZoomedImage;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.CheckBox chkAttributeInk;
        private System.Windows.Forms.CheckBox chkAttributePaper;
        private System.Windows.Forms.ToolTip tlpToolTip;
        private System.Windows.Forms.GroupBox grpScreenAttributes;
        private InfoBox.InfoBox ibxCellFormat;
        private InfoBox.InfoBox ibxAsciiHex;
        private InfoBox.InfoBox ibxAsciiDec;
        private InfoBox.InfoBox ibxAddressHex;
        private InfoBox.InfoBox ibxAddressDec;
        private InfoBox.InfoBox ibxScreenByte;
        private InfoBox.InfoBox ibxScreenPosition;
        private System.Windows.Forms.CheckBox chkAttributeIndicator;
        private System.Windows.Forms.CheckBox chkAttributeOther;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.GroupBox grpCharacterAndAttributeInformation;
        private InfoBox.InfoBox ibxCellDetails;
        private System.Windows.Forms.Button btnZoomReset;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
    }
}