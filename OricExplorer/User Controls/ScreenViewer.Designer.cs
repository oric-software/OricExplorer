namespace OricExplorer
{
    partial class ScreenViewerControl
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
            this.printDocumentScreenViewer = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAttributeIndicator = new System.Windows.Forms.CheckBox();
            this.checkBoxOtherAttributes = new System.Windows.Forms.CheckBox();
            this.checkBoxPaperAttribute = new System.Windows.Forms.CheckBox();
            this.checkBoxInkAttribute = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureBoxScreenImage = new System.Windows.Forms.PictureBox();
            this.groupBoxZoomedImage = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.infoBoxAsciiHex = new InfoBox.InfoBox();
            this.infoBoxAsciiDec = new InfoBox.InfoBox();
            this.infoBoxAddressHex = new InfoBox.InfoBox();
            this.infoBoxAddressDec = new InfoBox.InfoBox();
            this.infoBoxScreenByte = new InfoBox.InfoBox();
            this.infoBoxScreenPosition = new InfoBox.InfoBox();
            this.infoBoxCellFormat = new InfoBox.InfoBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.infoBoxCellDetails = new InfoBox.InfoBox();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomReset = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).BeginInit();
            this.groupBoxZoomedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocumentScreenViewer
            // 
            this.printDocumentScreenViewer.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentScreenViewer_PrintPage);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Screen Position :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Screen Address :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(5, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "ASCII Code :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.pictureBoxScreenImage);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 523);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Screen Image";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAttributeIndicator);
            this.groupBox1.Controls.Add(this.checkBoxOtherAttributes);
            this.groupBox1.Controls.Add(this.checkBoxPaperAttribute);
            this.groupBox1.Controls.Add(this.checkBoxInkAttribute);
            this.groupBox1.Location = new System.Drawing.Point(7, 472);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 44);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show/Hide Screen Attributes";
            // 
            // checkBoxAttributeIndicator
            // 
            this.checkBoxAttributeIndicator.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAttributeIndicator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxAttributeIndicator.Location = new System.Drawing.Point(9, 19);
            this.checkBoxAttributeIndicator.Name = "checkBoxAttributeIndicator";
            this.checkBoxAttributeIndicator.Size = new System.Drawing.Size(126, 20);
            this.checkBoxAttributeIndicator.TabIndex = 60;
            this.checkBoxAttributeIndicator.Text = "Attribute Indicator";
            this.toolTip1.SetToolTip(this.checkBoxAttributeIndicator, "Show/Hide Grid");
            this.checkBoxAttributeIndicator.UseVisualStyleBackColor = true;
            this.checkBoxAttributeIndicator.CheckedChanged += new System.EventHandler(this.checkBoxAttributeIndicator_CheckedChanged);
            // 
            // checkBoxOtherAttributes
            // 
            this.checkBoxOtherAttributes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxOtherAttributes.Location = new System.Drawing.Point(250, 19);
            this.checkBoxOtherAttributes.Name = "checkBoxOtherAttributes";
            this.checkBoxOtherAttributes.Size = new System.Drawing.Size(57, 20);
            this.checkBoxOtherAttributes.TabIndex = 59;
            this.checkBoxOtherAttributes.Text = "Other";
            this.toolTip1.SetToolTip(this.checkBoxOtherAttributes, "Show/Hide Ink Attributes");
            this.checkBoxOtherAttributes.UseVisualStyleBackColor = true;
            this.checkBoxOtherAttributes.CheckedChanged += new System.EventHandler(this.checkBoxOtherAttributes_CheckedChanged);
            // 
            // checkBoxPaperAttribute
            // 
            this.checkBoxPaperAttribute.Location = new System.Drawing.Point(140, 19);
            this.checkBoxPaperAttribute.Name = "checkBoxPaperAttribute";
            this.checkBoxPaperAttribute.Size = new System.Drawing.Size(56, 20);
            this.checkBoxPaperAttribute.TabIndex = 57;
            this.checkBoxPaperAttribute.Text = "Paper";
            this.toolTip1.SetToolTip(this.checkBoxPaperAttribute, "Show/Hide Paper Attributes");
            this.checkBoxPaperAttribute.UseVisualStyleBackColor = true;
            this.checkBoxPaperAttribute.CheckedChanged += new System.EventHandler(this.radioButtonPaper_CheckedChanged);
            // 
            // checkBoxInkAttribute
            // 
            this.checkBoxInkAttribute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxInkAttribute.Location = new System.Drawing.Point(201, 19);
            this.checkBoxInkAttribute.Name = "checkBoxInkAttribute";
            this.checkBoxInkAttribute.Size = new System.Drawing.Size(44, 20);
            this.checkBoxInkAttribute.TabIndex = 58;
            this.checkBoxInkAttribute.Text = "Ink";
            this.toolTip1.SetToolTip(this.checkBoxInkAttribute, "Show/Hide Ink Attributes");
            this.checkBoxInkAttribute.UseVisualStyleBackColor = true;
            this.checkBoxInkAttribute.CheckedChanged += new System.EventHandler(this.radioButtonInk_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonPrint);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Location = new System.Drawing.Point(321, 472);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 45);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(5, 17);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 56;
            this.buttonPrint.Text = "Print Image";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(86, 17);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 57;
            this.buttonSave.Text = "Save Image";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBoxScreenImage
            // 
            this.pictureBoxScreenImage.BackColor = System.Drawing.Color.Black;
            this.pictureBoxScreenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScreenImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxScreenImage.Location = new System.Drawing.Point(7, 18);
            this.pictureBoxScreenImage.Name = "pictureBoxScreenImage";
            this.pictureBoxScreenImage.Size = new System.Drawing.Size(480, 448);
            this.pictureBoxScreenImage.TabIndex = 0;
            this.pictureBoxScreenImage.TabStop = false;
            this.pictureBoxScreenImage.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBoxScreenImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // groupBoxZoomedImage
            // 
            this.groupBoxZoomedImage.Controls.Add(this.buttonZoomReset);
            this.groupBoxZoomedImage.Controls.Add(this.buttonZoomOut);
            this.groupBoxZoomedImage.Controls.Add(this.buttonZoomIn);
            this.groupBoxZoomedImage.Controls.Add(this.pictureBox1);
            this.groupBoxZoomedImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxZoomedImage.Location = new System.Drawing.Point(516, 8);
            this.groupBoxZoomedImage.Name = "groupBoxZoomedImage";
            this.groupBoxZoomedImage.Size = new System.Drawing.Size(259, 281);
            this.groupBoxZoomedImage.TabIndex = 54;
            this.groupBoxZoomedImage.TabStop = false;
            this.groupBoxZoomedImage.Text = "Zoomed View (x2)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(9, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.infoBoxAsciiHex);
            this.groupBox5.Controls.Add(this.infoBoxAsciiDec);
            this.groupBox5.Controls.Add(this.infoBoxAddressHex);
            this.groupBox5.Controls.Add(this.infoBoxAddressDec);
            this.groupBox5.Controls.Add(this.infoBoxScreenByte);
            this.groupBox5.Controls.Add(this.infoBoxScreenPosition);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(516, 295);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 115);
            this.groupBox5.TabIndex = 55;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Information";
            // 
            // infoBoxAsciiHex
            // 
            this.infoBoxAsciiHex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxAsciiHex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAsciiHex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAsciiHex.Location = new System.Drawing.Point(179, 81);
            this.infoBoxAsciiHex.Name = "infoBoxAsciiHex";
            this.infoBoxAsciiHex.Size = new System.Drawing.Size(71, 22);
            this.infoBoxAsciiHex.TabIndex = 69;
            // 
            // infoBoxAsciiDec
            // 
            this.infoBoxAsciiDec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxAsciiDec.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAsciiDec.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAsciiDec.Location = new System.Drawing.Point(102, 81);
            this.infoBoxAsciiDec.Name = "infoBoxAsciiDec";
            this.infoBoxAsciiDec.Size = new System.Drawing.Size(71, 22);
            this.infoBoxAsciiDec.TabIndex = 68;
            // 
            // infoBoxAddressHex
            // 
            this.infoBoxAddressHex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxAddressHex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAddressHex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAddressHex.Location = new System.Drawing.Point(179, 49);
            this.infoBoxAddressHex.Name = "infoBoxAddressHex";
            this.infoBoxAddressHex.Size = new System.Drawing.Size(71, 22);
            this.infoBoxAddressHex.TabIndex = 67;
            // 
            // infoBoxAddressDec
            // 
            this.infoBoxAddressDec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxAddressDec.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAddressDec.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxAddressDec.Location = new System.Drawing.Point(102, 49);
            this.infoBoxAddressDec.Name = "infoBoxAddressDec";
            this.infoBoxAddressDec.Size = new System.Drawing.Size(71, 22);
            this.infoBoxAddressDec.TabIndex = 66;
            // 
            // infoBoxScreenByte
            // 
            this.infoBoxScreenByte.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxScreenByte.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxScreenByte.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxScreenByte.Location = new System.Drawing.Point(179, 17);
            this.infoBoxScreenByte.Name = "infoBoxScreenByte";
            this.infoBoxScreenByte.Size = new System.Drawing.Size(71, 22);
            this.infoBoxScreenByte.TabIndex = 65;
            // 
            // infoBoxScreenPosition
            // 
            this.infoBoxScreenPosition.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxScreenPosition.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxScreenPosition.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxScreenPosition.Location = new System.Drawing.Point(102, 17);
            this.infoBoxScreenPosition.Name = "infoBoxScreenPosition";
            this.infoBoxScreenPosition.Size = new System.Drawing.Size(71, 22);
            this.infoBoxScreenPosition.TabIndex = 64;
            // 
            // infoBoxCellFormat
            // 
            this.infoBoxCellFormat.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxCellFormat.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxCellFormat.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCellFormat.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCellFormat.Location = new System.Drawing.Point(9, 22);
            this.infoBoxCellFormat.Name = "infoBoxCellFormat";
            this.infoBoxCellFormat.Size = new System.Drawing.Size(241, 22);
            this.infoBoxCellFormat.TabIndex = 70;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.infoBoxCellDetails);
            this.groupBox4.Controls.Add(this.infoBoxCellFormat);
            this.groupBox4.Location = new System.Drawing.Point(516, 416);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 85);
            this.groupBox4.TabIndex = 71;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Character / Attribute Information";
            // 
            // infoBoxCellDetails
            // 
            this.infoBoxCellDetails.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxCellDetails.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxCellDetails.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCellDetails.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCellDetails.Location = new System.Drawing.Point(9, 49);
            this.infoBoxCellDetails.Name = "infoBoxCellDetails";
            this.infoBoxCellDetails.Size = new System.Drawing.Size(241, 22);
            this.infoBoxCellDetails.TabIndex = 71;
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(9, 249);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(75, 23);
            this.buttonZoomIn.TabIndex = 36;
            this.buttonZoomIn.Text = "Zoom In";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(92, 249);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(75, 23);
            this.buttonZoomOut.TabIndex = 37;
            this.buttonZoomOut.Text = "Zoom Out";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonZoomReset
            // 
            this.buttonZoomReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonZoomReset.Location = new System.Drawing.Point(175, 249);
            this.buttonZoomReset.Name = "buttonZoomReset";
            this.buttonZoomReset.Size = new System.Drawing.Size(75, 23);
            this.buttonZoomReset.TabIndex = 38;
            this.buttonZoomReset.Text = "Reset";
            this.buttonZoomReset.UseVisualStyleBackColor = true;
            this.buttonZoomReset.Click += new System.EventHandler(this.buttonZoomReset_Click);
            // 
            // ScreenViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBoxZoomedImage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Name = "ScreenViewerControl";
            this.Size = new System.Drawing.Size(788, 541);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenImage)).EndInit();
            this.groupBoxZoomedImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxScreenImage;
        private System.Drawing.Printing.PrintDocument printDocumentScreenViewer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBoxZoomedImage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBoxInkAttribute;
        private System.Windows.Forms.CheckBox checkBoxPaperAttribute;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private InfoBox.InfoBox infoBoxCellFormat;
        private InfoBox.InfoBox infoBoxAsciiHex;
        private InfoBox.InfoBox infoBoxAsciiDec;
        private InfoBox.InfoBox infoBoxAddressHex;
        private InfoBox.InfoBox infoBoxAddressDec;
        private InfoBox.InfoBox infoBoxScreenByte;
        private InfoBox.InfoBox infoBoxScreenPosition;
        private System.Windows.Forms.CheckBox checkBoxAttributeIndicator;
        private System.Windows.Forms.CheckBox checkBoxOtherAttributes;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private InfoBox.InfoBox infoBoxCellDetails;
        private System.Windows.Forms.Button buttonZoomReset;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
    }
}