namespace OricExplorer
{
    partial class CharacterSetViewerControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxCharSet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxCharacterView = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.infoBoxCharAddress = new InfoBox.InfoBox();
            this.infoBoxCharIndex = new InfoBox.InfoBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.horizontalDivider1 = new HorizontalDivider.HorizontalDivider();
            this.label14 = new System.Windows.Forms.Label();
            this.labelAddr8 = new System.Windows.Forms.Label();
            this.labelAddr7 = new System.Windows.Forms.Label();
            this.labelAddr6 = new System.Windows.Forms.Label();
            this.labelAddr5 = new System.Windows.Forms.Label();
            this.labelAddr4 = new System.Windows.Forms.Label();
            this.labelAddr3 = new System.Windows.Forms.Label();
            this.labelAddr2 = new System.Windows.Forms.Label();
            this.labelAddr1 = new System.Windows.Forms.Label();
            this.labelBin8 = new System.Windows.Forms.Label();
            this.labelDec8 = new System.Windows.Forms.Label();
            this.labelHex8 = new System.Windows.Forms.Label();
            this.labelBin7 = new System.Windows.Forms.Label();
            this.labelDec7 = new System.Windows.Forms.Label();
            this.labelHex7 = new System.Windows.Forms.Label();
            this.labelBin6 = new System.Windows.Forms.Label();
            this.labelDec6 = new System.Windows.Forms.Label();
            this.labelHex6 = new System.Windows.Forms.Label();
            this.labelBin5 = new System.Windows.Forms.Label();
            this.labelDec5 = new System.Windows.Forms.Label();
            this.labelHex5 = new System.Windows.Forms.Label();
            this.labelBin4 = new System.Windows.Forms.Label();
            this.labelDec4 = new System.Windows.Forms.Label();
            this.labelHex4 = new System.Windows.Forms.Label();
            this.labelBin3 = new System.Windows.Forms.Label();
            this.labelDec3 = new System.Windows.Forms.Label();
            this.labelHex3 = new System.Windows.Forms.Label();
            this.labelBin2 = new System.Windows.Forms.Label();
            this.labelDec2 = new System.Windows.Forms.Label();
            this.labelHex2 = new System.Windows.Forms.Label();
            this.labelBin1 = new System.Windows.Forms.Label();
            this.labelDec1 = new System.Windows.Forms.Label();
            this.labelHex1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacterView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxCharSet);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 269);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Character Set";
            // 
            // pictureBoxCharSet
            // 
            this.pictureBoxCharSet.BackColor = System.Drawing.Color.White;
            this.pictureBoxCharSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCharSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCharSet.Location = new System.Drawing.Point(6, 16);
            this.pictureBoxCharSet.Name = "pictureBoxCharSet";
            this.pictureBoxCharSet.Size = new System.Drawing.Size(294, 246);
            this.pictureBoxCharSet.TabIndex = 0;
            this.pictureBoxCharSet.TabStop = false;
            this.pictureBoxCharSet.MouseLeave += new System.EventHandler(this.pictureBoxCharSet_MouseLeave);
            this.pictureBoxCharSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCharSet_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(224, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Hex";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(258, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Dec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(307, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bin";
            // 
            // pictureBoxCharacterView
            // 
            this.pictureBoxCharacterView.Image = global::OricExplorer.Properties.Resources.UpdatedCharacterSetViewer;
            this.pictureBoxCharacterView.Location = new System.Drawing.Point(7, 79);
            this.pictureBoxCharacterView.Name = "pictureBoxCharacterView";
            this.pictureBoxCharacterView.Size = new System.Drawing.Size(143, 183);
            this.pictureBoxCharacterView.TabIndex = 24;
            this.pictureBoxCharacterView.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.infoBoxCharAddress);
            this.groupBox2.Controls.Add(this.infoBoxCharIndex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.horizontalDivider1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.labelAddr8);
            this.groupBox2.Controls.Add(this.labelAddr7);
            this.groupBox2.Controls.Add(this.labelAddr6);
            this.groupBox2.Controls.Add(this.labelAddr5);
            this.groupBox2.Controls.Add(this.labelAddr4);
            this.groupBox2.Controls.Add(this.labelAddr3);
            this.groupBox2.Controls.Add(this.labelAddr2);
            this.groupBox2.Controls.Add(this.labelAddr1);
            this.groupBox2.Controls.Add(this.labelBin8);
            this.groupBox2.Controls.Add(this.labelDec8);
            this.groupBox2.Controls.Add(this.labelHex8);
            this.groupBox2.Controls.Add(this.labelBin7);
            this.groupBox2.Controls.Add(this.labelDec7);
            this.groupBox2.Controls.Add(this.labelHex7);
            this.groupBox2.Controls.Add(this.labelBin6);
            this.groupBox2.Controls.Add(this.labelDec6);
            this.groupBox2.Controls.Add(this.labelHex6);
            this.groupBox2.Controls.Add(this.labelBin5);
            this.groupBox2.Controls.Add(this.labelDec5);
            this.groupBox2.Controls.Add(this.labelHex5);
            this.groupBox2.Controls.Add(this.labelBin4);
            this.groupBox2.Controls.Add(this.labelDec4);
            this.groupBox2.Controls.Add(this.labelHex4);
            this.groupBox2.Controls.Add(this.labelBin3);
            this.groupBox2.Controls.Add(this.labelDec3);
            this.groupBox2.Controls.Add(this.labelHex3);
            this.groupBox2.Controls.Add(this.labelBin2);
            this.groupBox2.Controls.Add(this.labelDec2);
            this.groupBox2.Controls.Add(this.labelHex2);
            this.groupBox2.Controls.Add(this.labelBin1);
            this.groupBox2.Controls.Add(this.labelDec1);
            this.groupBox2.Controls.Add(this.labelHex1);
            this.groupBox2.Controls.Add(this.pictureBoxCharacterView);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(320, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 269);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Character Details";
            // 
            // infoBoxCharAddress
            // 
            this.infoBoxCharAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxCharAddress.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxCharAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCharAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCharAddress.Location = new System.Drawing.Point(309, 22);
            this.infoBoxCharAddress.Name = "infoBoxCharAddress";
            this.infoBoxCharAddress.Size = new System.Drawing.Size(50, 22);
            this.infoBoxCharAddress.TabIndex = 63;
            // 
            // infoBoxCharIndex
            // 
            this.infoBoxCharIndex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBoxCharIndex.ForeColor = System.Drawing.Color.Maroon;
            this.infoBoxCharIndex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCharIndex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.infoBoxCharIndex.Location = new System.Drawing.Point(100, 22);
            this.infoBoxCharIndex.Name = "infoBoxCharIndex";
            this.infoBoxCharIndex.Size = new System.Drawing.Size(95, 22);
            this.infoBoxCharIndex.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(252, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Address :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Character Index :";
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider1.Location = new System.Drawing.Point(0, 60);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(366, 2);
            this.horizontalDivider1.TabIndex = 59;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(167, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Address";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr8
            // 
            this.labelAddr8.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr8.Location = new System.Drawing.Point(162, 242);
            this.labelAddr8.Name = "labelAddr8";
            this.labelAddr8.Size = new System.Drawing.Size(55, 19);
            this.labelAddr8.TabIndex = 57;
            this.labelAddr8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr7
            // 
            this.labelAddr7.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr7.Location = new System.Drawing.Point(162, 222);
            this.labelAddr7.Name = "labelAddr7";
            this.labelAddr7.Size = new System.Drawing.Size(55, 19);
            this.labelAddr7.TabIndex = 56;
            this.labelAddr7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr6
            // 
            this.labelAddr6.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr6.Location = new System.Drawing.Point(162, 202);
            this.labelAddr6.Name = "labelAddr6";
            this.labelAddr6.Size = new System.Drawing.Size(55, 19);
            this.labelAddr6.TabIndex = 55;
            this.labelAddr6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr5
            // 
            this.labelAddr5.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr5.Location = new System.Drawing.Point(162, 182);
            this.labelAddr5.Name = "labelAddr5";
            this.labelAddr5.Size = new System.Drawing.Size(55, 19);
            this.labelAddr5.TabIndex = 54;
            this.labelAddr5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr4
            // 
            this.labelAddr4.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr4.Location = new System.Drawing.Point(162, 162);
            this.labelAddr4.Name = "labelAddr4";
            this.labelAddr4.Size = new System.Drawing.Size(55, 19);
            this.labelAddr4.TabIndex = 53;
            this.labelAddr4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr3
            // 
            this.labelAddr3.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr3.Location = new System.Drawing.Point(162, 142);
            this.labelAddr3.Name = "labelAddr3";
            this.labelAddr3.Size = new System.Drawing.Size(55, 19);
            this.labelAddr3.TabIndex = 52;
            this.labelAddr3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr2
            // 
            this.labelAddr2.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr2.Location = new System.Drawing.Point(162, 122);
            this.labelAddr2.Name = "labelAddr2";
            this.labelAddr2.Size = new System.Drawing.Size(55, 19);
            this.labelAddr2.TabIndex = 51;
            this.labelAddr2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAddr1
            // 
            this.labelAddr1.BackColor = System.Drawing.SystemColors.Info;
            this.labelAddr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddr1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddr1.Location = new System.Drawing.Point(162, 102);
            this.labelAddr1.Name = "labelAddr1";
            this.labelAddr1.Size = new System.Drawing.Size(55, 19);
            this.labelAddr1.TabIndex = 50;
            this.labelAddr1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin8
            // 
            this.labelBin8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin8.Location = new System.Drawing.Point(291, 242);
            this.labelBin8.Name = "labelBin8";
            this.labelBin8.Size = new System.Drawing.Size(68, 19);
            this.labelBin8.TabIndex = 49;
            this.labelBin8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec8
            // 
            this.labelDec8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec8.Location = new System.Drawing.Point(257, 242);
            this.labelDec8.Name = "labelDec8";
            this.labelDec8.Size = new System.Drawing.Size(28, 19);
            this.labelDec8.TabIndex = 48;
            this.labelDec8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex8
            // 
            this.labelHex8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex8.Location = new System.Drawing.Point(223, 242);
            this.labelHex8.Name = "labelHex8";
            this.labelHex8.Size = new System.Drawing.Size(28, 19);
            this.labelHex8.TabIndex = 47;
            this.labelHex8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin7
            // 
            this.labelBin7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin7.Location = new System.Drawing.Point(291, 222);
            this.labelBin7.Name = "labelBin7";
            this.labelBin7.Size = new System.Drawing.Size(68, 19);
            this.labelBin7.TabIndex = 46;
            this.labelBin7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec7
            // 
            this.labelDec7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec7.Location = new System.Drawing.Point(257, 222);
            this.labelDec7.Name = "labelDec7";
            this.labelDec7.Size = new System.Drawing.Size(28, 19);
            this.labelDec7.TabIndex = 45;
            this.labelDec7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex7
            // 
            this.labelHex7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex7.Location = new System.Drawing.Point(223, 222);
            this.labelHex7.Name = "labelHex7";
            this.labelHex7.Size = new System.Drawing.Size(28, 19);
            this.labelHex7.TabIndex = 44;
            this.labelHex7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin6
            // 
            this.labelBin6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin6.Location = new System.Drawing.Point(291, 202);
            this.labelBin6.Name = "labelBin6";
            this.labelBin6.Size = new System.Drawing.Size(68, 19);
            this.labelBin6.TabIndex = 43;
            this.labelBin6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec6
            // 
            this.labelDec6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec6.Location = new System.Drawing.Point(257, 202);
            this.labelDec6.Name = "labelDec6";
            this.labelDec6.Size = new System.Drawing.Size(28, 19);
            this.labelDec6.TabIndex = 42;
            this.labelDec6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex6
            // 
            this.labelHex6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex6.Location = new System.Drawing.Point(223, 202);
            this.labelHex6.Name = "labelHex6";
            this.labelHex6.Size = new System.Drawing.Size(28, 19);
            this.labelHex6.TabIndex = 41;
            this.labelHex6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin5
            // 
            this.labelBin5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin5.Location = new System.Drawing.Point(291, 182);
            this.labelBin5.Name = "labelBin5";
            this.labelBin5.Size = new System.Drawing.Size(68, 19);
            this.labelBin5.TabIndex = 40;
            this.labelBin5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec5
            // 
            this.labelDec5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec5.Location = new System.Drawing.Point(257, 182);
            this.labelDec5.Name = "labelDec5";
            this.labelDec5.Size = new System.Drawing.Size(28, 19);
            this.labelDec5.TabIndex = 39;
            this.labelDec5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex5
            // 
            this.labelHex5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex5.Location = new System.Drawing.Point(223, 182);
            this.labelHex5.Name = "labelHex5";
            this.labelHex5.Size = new System.Drawing.Size(28, 19);
            this.labelHex5.TabIndex = 38;
            this.labelHex5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin4
            // 
            this.labelBin4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin4.Location = new System.Drawing.Point(291, 162);
            this.labelBin4.Name = "labelBin4";
            this.labelBin4.Size = new System.Drawing.Size(68, 19);
            this.labelBin4.TabIndex = 37;
            this.labelBin4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec4
            // 
            this.labelDec4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec4.Location = new System.Drawing.Point(257, 162);
            this.labelDec4.Name = "labelDec4";
            this.labelDec4.Size = new System.Drawing.Size(28, 19);
            this.labelDec4.TabIndex = 36;
            this.labelDec4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex4
            // 
            this.labelHex4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex4.Location = new System.Drawing.Point(223, 162);
            this.labelHex4.Name = "labelHex4";
            this.labelHex4.Size = new System.Drawing.Size(28, 19);
            this.labelHex4.TabIndex = 35;
            this.labelHex4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin3
            // 
            this.labelBin3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin3.Location = new System.Drawing.Point(291, 142);
            this.labelBin3.Name = "labelBin3";
            this.labelBin3.Size = new System.Drawing.Size(68, 19);
            this.labelBin3.TabIndex = 34;
            this.labelBin3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec3
            // 
            this.labelDec3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec3.Location = new System.Drawing.Point(257, 142);
            this.labelDec3.Name = "labelDec3";
            this.labelDec3.Size = new System.Drawing.Size(28, 19);
            this.labelDec3.TabIndex = 33;
            this.labelDec3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex3
            // 
            this.labelHex3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex3.Location = new System.Drawing.Point(223, 142);
            this.labelHex3.Name = "labelHex3";
            this.labelHex3.Size = new System.Drawing.Size(28, 19);
            this.labelHex3.TabIndex = 32;
            this.labelHex3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin2
            // 
            this.labelBin2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin2.Location = new System.Drawing.Point(291, 122);
            this.labelBin2.Name = "labelBin2";
            this.labelBin2.Size = new System.Drawing.Size(68, 19);
            this.labelBin2.TabIndex = 31;
            this.labelBin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec2
            // 
            this.labelDec2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec2.Location = new System.Drawing.Point(257, 122);
            this.labelDec2.Name = "labelDec2";
            this.labelDec2.Size = new System.Drawing.Size(28, 19);
            this.labelDec2.TabIndex = 30;
            this.labelDec2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex2
            // 
            this.labelHex2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex2.Location = new System.Drawing.Point(223, 122);
            this.labelHex2.Name = "labelHex2";
            this.labelHex2.Size = new System.Drawing.Size(28, 19);
            this.labelHex2.TabIndex = 29;
            this.labelHex2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBin1
            // 
            this.labelBin1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelBin1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBin1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBin1.Location = new System.Drawing.Point(291, 102);
            this.labelBin1.Name = "labelBin1";
            this.labelBin1.Size = new System.Drawing.Size(68, 19);
            this.labelBin1.TabIndex = 28;
            this.labelBin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDec1
            // 
            this.labelDec1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDec1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDec1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDec1.Location = new System.Drawing.Point(257, 102);
            this.labelDec1.Name = "labelDec1";
            this.labelDec1.Size = new System.Drawing.Size(28, 19);
            this.labelDec1.TabIndex = 27;
            this.labelDec1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHex1
            // 
            this.labelHex1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelHex1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHex1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHex1.Location = new System.Drawing.Point(223, 102);
            this.labelHex1.Name = "labelHex1";
            this.labelHex1.Size = new System.Drawing.Size(28, 19);
            this.labelHex1.TabIndex = 26;
            this.labelHex1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharacterSetViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CharacterSetViewerControl";
            this.Size = new System.Drawing.Size(698, 282);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCharacterView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxCharSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCharacterView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelBin8;
        private System.Windows.Forms.Label labelDec8;
        private System.Windows.Forms.Label labelHex8;
        private System.Windows.Forms.Label labelBin7;
        private System.Windows.Forms.Label labelDec7;
        private System.Windows.Forms.Label labelHex7;
        private System.Windows.Forms.Label labelBin6;
        private System.Windows.Forms.Label labelDec6;
        private System.Windows.Forms.Label labelHex6;
        private System.Windows.Forms.Label labelBin5;
        private System.Windows.Forms.Label labelDec5;
        private System.Windows.Forms.Label labelHex5;
        private System.Windows.Forms.Label labelBin4;
        private System.Windows.Forms.Label labelDec4;
        private System.Windows.Forms.Label labelHex4;
        private System.Windows.Forms.Label labelBin3;
        private System.Windows.Forms.Label labelDec3;
        private System.Windows.Forms.Label labelHex3;
        private System.Windows.Forms.Label labelBin2;
        private System.Windows.Forms.Label labelDec2;
        private System.Windows.Forms.Label labelHex2;
        private System.Windows.Forms.Label labelBin1;
        private System.Windows.Forms.Label labelDec1;
        private System.Windows.Forms.Label labelHex1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelAddr8;
        private System.Windows.Forms.Label labelAddr7;
        private System.Windows.Forms.Label labelAddr6;
        private System.Windows.Forms.Label labelAddr5;
        private System.Windows.Forms.Label labelAddr4;
        private System.Windows.Forms.Label labelAddr3;
        private System.Windows.Forms.Label labelAddr2;
        private System.Windows.Forms.Label labelAddr1;
        private InfoBox.InfoBox infoBoxCharAddress;
        private InfoBox.InfoBox infoBoxCharIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private HorizontalDivider.HorizontalDivider horizontalDivider1;
    }
}