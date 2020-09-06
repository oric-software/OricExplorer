namespace OricExplorer
{
    partial class ctlCharacterSetViewerControl
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
            this.grpCharacterSet = new System.Windows.Forms.GroupBox();
            this.picCharSet = new System.Windows.Forms.PictureBox();
            this.lblHex = new System.Windows.Forms.Label();
            this.lblDec = new System.Windows.Forms.Label();
            this.lblBin = new System.Windows.Forms.Label();
            this.picCharacterView = new System.Windows.Forms.PictureBox();
            this.grpCharacterDetails = new System.Windows.Forms.GroupBox();
            this.ibxCharAddress = new InfoBox.InfoBox();
            this.ibxCharIndex = new InfoBox.InfoBox();
            this.lblCharAddress = new System.Windows.Forms.Label();
            this.lblCharIndex = new System.Windows.Forms.Label();
            this.hdiv1 = new HorizontalDivider.HorizontalDivider();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddr8 = new System.Windows.Forms.Label();
            this.lblAddr7 = new System.Windows.Forms.Label();
            this.lblAddr6 = new System.Windows.Forms.Label();
            this.lblAddr5 = new System.Windows.Forms.Label();
            this.lblAddr4 = new System.Windows.Forms.Label();
            this.lblAddr3 = new System.Windows.Forms.Label();
            this.lblAddr2 = new System.Windows.Forms.Label();
            this.lblAddr1 = new System.Windows.Forms.Label();
            this.lblBin8 = new System.Windows.Forms.Label();
            this.lblDec8 = new System.Windows.Forms.Label();
            this.lblHex8 = new System.Windows.Forms.Label();
            this.lblBin7 = new System.Windows.Forms.Label();
            this.lblDec7 = new System.Windows.Forms.Label();
            this.lblHex7 = new System.Windows.Forms.Label();
            this.lblBin6 = new System.Windows.Forms.Label();
            this.lblDec6 = new System.Windows.Forms.Label();
            this.lblHex6 = new System.Windows.Forms.Label();
            this.lblBin5 = new System.Windows.Forms.Label();
            this.lblDec5 = new System.Windows.Forms.Label();
            this.lblHex5 = new System.Windows.Forms.Label();
            this.lblBin4 = new System.Windows.Forms.Label();
            this.lblDec4 = new System.Windows.Forms.Label();
            this.lblHex4 = new System.Windows.Forms.Label();
            this.lblBin3 = new System.Windows.Forms.Label();
            this.lblDec3 = new System.Windows.Forms.Label();
            this.lblHex3 = new System.Windows.Forms.Label();
            this.lblBin2 = new System.Windows.Forms.Label();
            this.lblDec2 = new System.Windows.Forms.Label();
            this.lblHex2 = new System.Windows.Forms.Label();
            this.lblBin1 = new System.Windows.Forms.Label();
            this.lblDec1 = new System.Windows.Forms.Label();
            this.lblHex1 = new System.Windows.Forms.Label();
            this.grpCharacterSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCharSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacterView)).BeginInit();
            this.grpCharacterDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCharacterSet
            // 
            this.grpCharacterSet.Controls.Add(this.picCharSet);
            this.grpCharacterSet.Location = new System.Drawing.Point(7, 6);
            this.grpCharacterSet.Name = "grpCharacterSet";
            this.grpCharacterSet.Size = new System.Drawing.Size(307, 269);
            this.grpCharacterSet.TabIndex = 0;
            this.grpCharacterSet.TabStop = false;
            this.grpCharacterSet.Text = "Character Set";
            // 
            // picCharSet
            // 
            this.picCharSet.BackColor = System.Drawing.Color.White;
            this.picCharSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCharSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCharSet.Location = new System.Drawing.Point(6, 16);
            this.picCharSet.Name = "picCharSet";
            this.picCharSet.Size = new System.Drawing.Size(294, 246);
            this.picCharSet.TabIndex = 0;
            this.picCharSet.TabStop = false;
            this.picCharSet.MouseLeave += new System.EventHandler(this.picCharSet_MouseLeave);
            this.picCharSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCharSet_MouseMove);
            // 
            // lblHex
            // 
            this.lblHex.AutoSize = true;
            this.lblHex.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHex.Location = new System.Drawing.Point(224, 83);
            this.lblHex.Name = "lblHex";
            this.lblHex.Size = new System.Drawing.Size(26, 13);
            this.lblHex.TabIndex = 6;
            this.lblHex.Text = "Hex";
            // 
            // lblDec
            // 
            this.lblDec.AutoSize = true;
            this.lblDec.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDec.Location = new System.Drawing.Point(258, 83);
            this.lblDec.Name = "lblDec";
            this.lblDec.Size = new System.Drawing.Size(27, 13);
            this.lblDec.TabIndex = 7;
            this.lblDec.Text = "Dec";
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBin.Location = new System.Drawing.Point(307, 83);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(22, 13);
            this.lblBin.TabIndex = 8;
            this.lblBin.Text = "Bin";
            // 
            // picCharacterView
            // 
            this.picCharacterView.Image = global::OricExplorer.Properties.Resources.UpdatedCharacterSetViewer;
            this.picCharacterView.Location = new System.Drawing.Point(7, 79);
            this.picCharacterView.Name = "picCharacterView";
            this.picCharacterView.Size = new System.Drawing.Size(143, 183);
            this.picCharacterView.TabIndex = 24;
            this.picCharacterView.TabStop = false;
            // 
            // grpCharacterDetails
            // 
            this.grpCharacterDetails.Controls.Add(this.ibxCharAddress);
            this.grpCharacterDetails.Controls.Add(this.ibxCharIndex);
            this.grpCharacterDetails.Controls.Add(this.lblCharAddress);
            this.grpCharacterDetails.Controls.Add(this.lblCharIndex);
            this.grpCharacterDetails.Controls.Add(this.hdiv1);
            this.grpCharacterDetails.Controls.Add(this.lblAddress);
            this.grpCharacterDetails.Controls.Add(this.lblAddr8);
            this.grpCharacterDetails.Controls.Add(this.lblAddr7);
            this.grpCharacterDetails.Controls.Add(this.lblAddr6);
            this.grpCharacterDetails.Controls.Add(this.lblAddr5);
            this.grpCharacterDetails.Controls.Add(this.lblAddr4);
            this.grpCharacterDetails.Controls.Add(this.lblAddr3);
            this.grpCharacterDetails.Controls.Add(this.lblAddr2);
            this.grpCharacterDetails.Controls.Add(this.lblAddr1);
            this.grpCharacterDetails.Controls.Add(this.lblBin8);
            this.grpCharacterDetails.Controls.Add(this.lblDec8);
            this.grpCharacterDetails.Controls.Add(this.lblHex8);
            this.grpCharacterDetails.Controls.Add(this.lblBin7);
            this.grpCharacterDetails.Controls.Add(this.lblDec7);
            this.grpCharacterDetails.Controls.Add(this.lblHex7);
            this.grpCharacterDetails.Controls.Add(this.lblBin6);
            this.grpCharacterDetails.Controls.Add(this.lblDec6);
            this.grpCharacterDetails.Controls.Add(this.lblHex6);
            this.grpCharacterDetails.Controls.Add(this.lblBin5);
            this.grpCharacterDetails.Controls.Add(this.lblDec5);
            this.grpCharacterDetails.Controls.Add(this.lblHex5);
            this.grpCharacterDetails.Controls.Add(this.lblBin4);
            this.grpCharacterDetails.Controls.Add(this.lblDec4);
            this.grpCharacterDetails.Controls.Add(this.lblHex4);
            this.grpCharacterDetails.Controls.Add(this.lblBin3);
            this.grpCharacterDetails.Controls.Add(this.lblDec3);
            this.grpCharacterDetails.Controls.Add(this.lblHex3);
            this.grpCharacterDetails.Controls.Add(this.lblBin2);
            this.grpCharacterDetails.Controls.Add(this.lblDec2);
            this.grpCharacterDetails.Controls.Add(this.lblHex2);
            this.grpCharacterDetails.Controls.Add(this.lblBin1);
            this.grpCharacterDetails.Controls.Add(this.lblDec1);
            this.grpCharacterDetails.Controls.Add(this.lblHex1);
            this.grpCharacterDetails.Controls.Add(this.picCharacterView);
            this.grpCharacterDetails.Controls.Add(this.lblBin);
            this.grpCharacterDetails.Controls.Add(this.lblDec);
            this.grpCharacterDetails.Controls.Add(this.lblHex);
            this.grpCharacterDetails.Location = new System.Drawing.Point(320, 6);
            this.grpCharacterDetails.Name = "grpCharacterDetails";
            this.grpCharacterDetails.Size = new System.Drawing.Size(366, 269);
            this.grpCharacterDetails.TabIndex = 1;
            this.grpCharacterDetails.TabStop = false;
            this.grpCharacterDetails.Text = "Character Details";
            // 
            // ibxCharAddress
            // 
            this.ibxCharAddress.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxCharAddress.ForeColor = System.Drawing.Color.Maroon;
            this.ibxCharAddress.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCharAddress.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCharAddress.Location = new System.Drawing.Point(309, 22);
            this.ibxCharAddress.Name = "ibxCharAddress";
            this.ibxCharAddress.Size = new System.Drawing.Size(50, 22);
            this.ibxCharAddress.TabIndex = 3;
            // 
            // ibxCharIndex
            // 
            this.ibxCharIndex.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibxCharIndex.ForeColor = System.Drawing.Color.Maroon;
            this.ibxCharIndex.GradientEndColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCharIndex.GradientStartColour = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ibxCharIndex.Location = new System.Drawing.Point(100, 22);
            this.ibxCharIndex.Name = "ibxCharIndex";
            this.ibxCharIndex.Size = new System.Drawing.Size(95, 22);
            this.ibxCharIndex.TabIndex = 1;
            // 
            // lblCharAddress
            // 
            this.lblCharAddress.AutoSize = true;
            this.lblCharAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCharAddress.Location = new System.Drawing.Point(252, 27);
            this.lblCharAddress.Name = "lblCharAddress";
            this.lblCharAddress.Size = new System.Drawing.Size(51, 13);
            this.lblCharAddress.TabIndex = 2;
            this.lblCharAddress.Text = "Address :";
            // 
            // lblCharIndex
            // 
            this.lblCharIndex.AutoSize = true;
            this.lblCharIndex.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCharIndex.Location = new System.Drawing.Point(6, 27);
            this.lblCharIndex.Name = "lblCharIndex";
            this.lblCharIndex.Size = new System.Drawing.Size(88, 13);
            this.lblCharIndex.TabIndex = 0;
            this.lblCharIndex.Text = "Character Index :";
            // 
            // hdiv1
            // 
            this.hdiv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hdiv1.Location = new System.Drawing.Point(0, 60);
            this.hdiv1.Name = "hdiv1";
            this.hdiv1.Size = new System.Drawing.Size(200, 2);
            this.hdiv1.TabIndex = 4;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAddress.Location = new System.Drawing.Point(167, 83);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr8
            // 
            this.lblAddr8.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr8.Location = new System.Drawing.Point(162, 242);
            this.lblAddr8.Name = "lblAddr8";
            this.lblAddr8.Size = new System.Drawing.Size(55, 19);
            this.lblAddr8.TabIndex = 37;
            this.lblAddr8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr7
            // 
            this.lblAddr7.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr7.Location = new System.Drawing.Point(162, 222);
            this.lblAddr7.Name = "lblAddr7";
            this.lblAddr7.Size = new System.Drawing.Size(55, 19);
            this.lblAddr7.TabIndex = 33;
            this.lblAddr7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr6
            // 
            this.lblAddr6.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr6.Location = new System.Drawing.Point(162, 202);
            this.lblAddr6.Name = "lblAddr6";
            this.lblAddr6.Size = new System.Drawing.Size(55, 19);
            this.lblAddr6.TabIndex = 29;
            this.lblAddr6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr5
            // 
            this.lblAddr5.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr5.Location = new System.Drawing.Point(162, 182);
            this.lblAddr5.Name = "lblAddr5";
            this.lblAddr5.Size = new System.Drawing.Size(55, 19);
            this.lblAddr5.TabIndex = 25;
            this.lblAddr5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr4
            // 
            this.lblAddr4.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr4.Location = new System.Drawing.Point(162, 162);
            this.lblAddr4.Name = "lblAddr4";
            this.lblAddr4.Size = new System.Drawing.Size(55, 19);
            this.lblAddr4.TabIndex = 21;
            this.lblAddr4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr3
            // 
            this.lblAddr3.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr3.Location = new System.Drawing.Point(162, 142);
            this.lblAddr3.Name = "lblAddr3";
            this.lblAddr3.Size = new System.Drawing.Size(55, 19);
            this.lblAddr3.TabIndex = 17;
            this.lblAddr3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr2
            // 
            this.lblAddr2.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr2.Location = new System.Drawing.Point(162, 122);
            this.lblAddr2.Name = "lblAddr2";
            this.lblAddr2.Size = new System.Drawing.Size(55, 19);
            this.lblAddr2.TabIndex = 13;
            this.lblAddr2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr1
            // 
            this.lblAddr1.BackColor = System.Drawing.SystemColors.Info;
            this.lblAddr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAddr1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddr1.Location = new System.Drawing.Point(162, 102);
            this.lblAddr1.Name = "lblAddr1";
            this.lblAddr1.Size = new System.Drawing.Size(55, 19);
            this.lblAddr1.TabIndex = 9;
            this.lblAddr1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin8
            // 
            this.lblBin8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin8.Location = new System.Drawing.Point(291, 242);
            this.lblBin8.Name = "lblBin8";
            this.lblBin8.Size = new System.Drawing.Size(68, 19);
            this.lblBin8.TabIndex = 40;
            this.lblBin8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec8
            // 
            this.lblDec8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec8.Location = new System.Drawing.Point(257, 242);
            this.lblDec8.Name = "lblDec8";
            this.lblDec8.Size = new System.Drawing.Size(28, 19);
            this.lblDec8.TabIndex = 39;
            this.lblDec8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex8
            // 
            this.lblHex8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex8.Location = new System.Drawing.Point(223, 242);
            this.lblHex8.Name = "lblHex8";
            this.lblHex8.Size = new System.Drawing.Size(28, 19);
            this.lblHex8.TabIndex = 38;
            this.lblHex8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin7
            // 
            this.lblBin7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin7.Location = new System.Drawing.Point(291, 222);
            this.lblBin7.Name = "lblBin7";
            this.lblBin7.Size = new System.Drawing.Size(68, 19);
            this.lblBin7.TabIndex = 36;
            this.lblBin7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec7
            // 
            this.lblDec7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec7.Location = new System.Drawing.Point(257, 222);
            this.lblDec7.Name = "lblDec7";
            this.lblDec7.Size = new System.Drawing.Size(28, 19);
            this.lblDec7.TabIndex = 35;
            this.lblDec7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex7
            // 
            this.lblHex7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex7.Location = new System.Drawing.Point(223, 222);
            this.lblHex7.Name = "lblHex7";
            this.lblHex7.Size = new System.Drawing.Size(28, 19);
            this.lblHex7.TabIndex = 34;
            this.lblHex7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin6
            // 
            this.lblBin6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin6.Location = new System.Drawing.Point(291, 202);
            this.lblBin6.Name = "lblBin6";
            this.lblBin6.Size = new System.Drawing.Size(68, 19);
            this.lblBin6.TabIndex = 32;
            this.lblBin6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec6
            // 
            this.lblDec6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec6.Location = new System.Drawing.Point(257, 202);
            this.lblDec6.Name = "lblDec6";
            this.lblDec6.Size = new System.Drawing.Size(28, 19);
            this.lblDec6.TabIndex = 31;
            this.lblDec6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex6
            // 
            this.lblHex6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex6.Location = new System.Drawing.Point(223, 202);
            this.lblHex6.Name = "lblHex6";
            this.lblHex6.Size = new System.Drawing.Size(28, 19);
            this.lblHex6.TabIndex = 30;
            this.lblHex6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin5
            // 
            this.lblBin5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin5.Location = new System.Drawing.Point(291, 182);
            this.lblBin5.Name = "lblBin5";
            this.lblBin5.Size = new System.Drawing.Size(68, 19);
            this.lblBin5.TabIndex = 28;
            this.lblBin5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec5
            // 
            this.lblDec5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec5.Location = new System.Drawing.Point(257, 182);
            this.lblDec5.Name = "lblDec5";
            this.lblDec5.Size = new System.Drawing.Size(28, 19);
            this.lblDec5.TabIndex = 27;
            this.lblDec5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex5
            // 
            this.lblHex5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex5.Location = new System.Drawing.Point(223, 182);
            this.lblHex5.Name = "lblHex5";
            this.lblHex5.Size = new System.Drawing.Size(28, 19);
            this.lblHex5.TabIndex = 26;
            this.lblHex5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin4
            // 
            this.lblBin4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin4.Location = new System.Drawing.Point(291, 162);
            this.lblBin4.Name = "lblBin4";
            this.lblBin4.Size = new System.Drawing.Size(68, 19);
            this.lblBin4.TabIndex = 24;
            this.lblBin4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec4
            // 
            this.lblDec4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec4.Location = new System.Drawing.Point(257, 162);
            this.lblDec4.Name = "lblDec4";
            this.lblDec4.Size = new System.Drawing.Size(28, 19);
            this.lblDec4.TabIndex = 23;
            this.lblDec4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex4
            // 
            this.lblHex4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex4.Location = new System.Drawing.Point(223, 162);
            this.lblHex4.Name = "lblHex4";
            this.lblHex4.Size = new System.Drawing.Size(28, 19);
            this.lblHex4.TabIndex = 22;
            this.lblHex4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin3
            // 
            this.lblBin3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin3.Location = new System.Drawing.Point(291, 142);
            this.lblBin3.Name = "lblBin3";
            this.lblBin3.Size = new System.Drawing.Size(68, 19);
            this.lblBin3.TabIndex = 20;
            this.lblBin3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec3
            // 
            this.lblDec3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec3.Location = new System.Drawing.Point(257, 142);
            this.lblDec3.Name = "lblDec3";
            this.lblDec3.Size = new System.Drawing.Size(28, 19);
            this.lblDec3.TabIndex = 19;
            this.lblDec3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex3
            // 
            this.lblHex3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex3.Location = new System.Drawing.Point(223, 142);
            this.lblHex3.Name = "lblHex3";
            this.lblHex3.Size = new System.Drawing.Size(28, 19);
            this.lblHex3.TabIndex = 18;
            this.lblHex3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin2
            // 
            this.lblBin2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin2.Location = new System.Drawing.Point(291, 122);
            this.lblBin2.Name = "lblBin2";
            this.lblBin2.Size = new System.Drawing.Size(68, 19);
            this.lblBin2.TabIndex = 16;
            this.lblBin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec2
            // 
            this.lblDec2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec2.Location = new System.Drawing.Point(257, 122);
            this.lblDec2.Name = "lblDec2";
            this.lblDec2.Size = new System.Drawing.Size(28, 19);
            this.lblDec2.TabIndex = 15;
            this.lblDec2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex2
            // 
            this.lblHex2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex2.Location = new System.Drawing.Point(223, 122);
            this.lblHex2.Name = "lblHex2";
            this.lblHex2.Size = new System.Drawing.Size(28, 19);
            this.lblHex2.TabIndex = 14;
            this.lblHex2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBin1
            // 
            this.lblBin1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblBin1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBin1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBin1.Location = new System.Drawing.Point(291, 102);
            this.lblBin1.Name = "lblBin1";
            this.lblBin1.Size = new System.Drawing.Size(68, 19);
            this.lblBin1.TabIndex = 12;
            this.lblBin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDec1
            // 
            this.lblDec1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDec1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDec1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDec1.Location = new System.Drawing.Point(257, 102);
            this.lblDec1.Name = "lblDec1";
            this.lblDec1.Size = new System.Drawing.Size(28, 19);
            this.lblDec1.TabIndex = 11;
            this.lblDec1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHex1
            // 
            this.lblHex1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHex1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHex1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHex1.Location = new System.Drawing.Point(223, 102);
            this.lblHex1.Name = "lblHex1";
            this.lblHex1.Size = new System.Drawing.Size(28, 19);
            this.lblHex1.TabIndex = 10;
            this.lblHex1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctlCharacterSetViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCharacterDetails);
            this.Controls.Add(this.grpCharacterSet);
            this.Name = "ctlCharacterSetViewerControl";
            this.Size = new System.Drawing.Size(698, 282);
            this.grpCharacterSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCharSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCharacterView)).EndInit();
            this.grpCharacterDetails.ResumeLayout(false);
            this.grpCharacterDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCharacterSet;
        private System.Windows.Forms.PictureBox picCharSet;
        private System.Windows.Forms.Label lblHex;
        private System.Windows.Forms.Label lblDec;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.PictureBox picCharacterView;
        private System.Windows.Forms.GroupBox grpCharacterDetails;
        private System.Windows.Forms.Label lblBin8;
        private System.Windows.Forms.Label lblDec8;
        private System.Windows.Forms.Label lblHex8;
        private System.Windows.Forms.Label lblBin7;
        private System.Windows.Forms.Label lblDec7;
        private System.Windows.Forms.Label lblHex7;
        private System.Windows.Forms.Label lblBin6;
        private System.Windows.Forms.Label lblDec6;
        private System.Windows.Forms.Label lblHex6;
        private System.Windows.Forms.Label lblBin5;
        private System.Windows.Forms.Label lblDec5;
        private System.Windows.Forms.Label lblHex5;
        private System.Windows.Forms.Label lblBin4;
        private System.Windows.Forms.Label lblDec4;
        private System.Windows.Forms.Label lblHex4;
        private System.Windows.Forms.Label lblBin3;
        private System.Windows.Forms.Label lblDec3;
        private System.Windows.Forms.Label lblHex3;
        private System.Windows.Forms.Label lblBin2;
        private System.Windows.Forms.Label lblDec2;
        private System.Windows.Forms.Label lblHex2;
        private System.Windows.Forms.Label lblBin1;
        private System.Windows.Forms.Label lblDec1;
        private System.Windows.Forms.Label lblHex1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddr8;
        private System.Windows.Forms.Label lblAddr7;
        private System.Windows.Forms.Label lblAddr6;
        private System.Windows.Forms.Label lblAddr5;
        private System.Windows.Forms.Label lblAddr4;
        private System.Windows.Forms.Label lblAddr3;
        private System.Windows.Forms.Label lblAddr2;
        private System.Windows.Forms.Label lblAddr1;
        private InfoBox.InfoBox ibxCharAddress;
        private InfoBox.InfoBox ibxCharIndex;
        private System.Windows.Forms.Label lblCharAddress;
        private System.Windows.Forms.Label lblCharIndex;
        private HorizontalDivider.HorizontalDivider hdiv1;
    }
}