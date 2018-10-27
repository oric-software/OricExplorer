using System.Drawing;
namespace OricExplorer.User_Controls    
{
    partial class SectorViewerControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 75D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("BASIC Programs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Code/Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("TEXT Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("HIRES Screens", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Character Sets", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Text Windows", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Sequential Data Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Direct Access Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Other", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("HELP Screens", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUsage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelSectorSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDiskFolder = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDosVersion = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelSectorsFree = new System.Windows.Forms.Label();
            this.labelSectorsUsed = new System.Windows.Forms.Label();
            this.labelSectorsPerTrack = new System.Windows.Forms.Label();
            this.labelDOSFormat = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelFileCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDiskName = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.labelSides = new System.Windows.Forms.Label();
            this.labelTracksPerSide = new System.Windows.Forms.Label();
            this.labelDiskType = new System.Windows.Forms.Label();
            this.labelSectorTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageDirectory = new System.Windows.Forms.TabPage();
            this.buttonPrintSetup = new System.Windows.Forms.Button();
            this.buttonPrintPreview = new System.Windows.Forms.Button();
            this.buttonPrintDirectory = new System.Windows.Forms.Button();
            this.checkBoxViewGroups = new System.Windows.Forms.CheckBox();
            this.lvDirectory = new System.Windows.Forms.ListView();
            this.columnFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSectors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAutoRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProtection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewSectorList = new System.Windows.Forms.ListView();
            this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSide = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTrack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSector = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxDisplayAsHex = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBarSectors = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBarTracks = new System.Windows.Forms.TrackBar();
            this.hexBoxSectorView = new Be.Windows.Forms.HexBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabSides = new System.Windows.Forms.TabControl();
            this.tabPageSide0 = new System.Windows.Forms.TabPage();
            this.pbSectorMapSide0 = new System.Windows.Forms.PictureBox();
            this.tabPageSide1 = new System.Windows.Forms.TabPage();
            this.pbSectorMapSide1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSectorMapSectorHex = new System.Windows.Forms.Label();
            this.labelSectorMapTrackHex = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelSectorMapInfo = new System.Windows.Forms.Label();
            this.labelSectorMapSector = new System.Windows.Forms.Label();
            this.labelSectorMapTrack = new System.Windows.Forms.Label();
            this.labelSectorMapSide = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageUsage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPageDirectory.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).BeginInit();
            this.tabSides.SuspendLayout();
            this.tabPageSide0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide0)).BeginInit();
            this.tabPageSide1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUsage);
            this.tabControl1.Controls.Add(this.tabPageDirectory);
            this.tabControl1.Location = new System.Drawing.Point(155, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 282);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPageUsage
            // 
            this.tabPageUsage.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageUsage.Controls.Add(this.panel1);
            this.tabPageUsage.Controls.Add(this.chart1);
            this.tabPageUsage.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsage.Name = "tabPageUsage";
            this.tabPageUsage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsage.Size = new System.Drawing.Size(702, 256);
            this.tabPageUsage.TabIndex = 1;
            this.tabPageUsage.Text = "Disk Information";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.labelSectorSize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelDiskFolder);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelDosVersion);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labelSectorsFree);
            this.panel1.Controls.Add(this.labelSectorsUsed);
            this.panel1.Controls.Add(this.labelSectorsPerTrack);
            this.panel1.Controls.Add(this.labelDOSFormat);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.labelFileCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelDiskName);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.labelSides);
            this.panel1.Controls.Add(this.labelTracksPerSide);
            this.panel1.Controls.Add(this.labelDiskType);
            this.panel1.Controls.Add(this.labelSectorTotal);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 248);
            this.panel1.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(252, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 69;
            this.label1.Text = "Info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(81, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 2);
            this.label2.TabIndex = 70;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label25.Location = new System.Drawing.Point(233, 176);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 16);
            this.label25.TabIndex = 67;
            this.label25.Text = "Disk Usage";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(81, 184);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(370, 2);
            this.label26.TabIndex = 68;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Location = new System.Drawing.Point(233, 101);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 16);
            this.label20.TabIndex = 30;
            this.label20.Text = "Structure";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(81, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(370, 2);
            this.label18.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(3, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 65;
            this.label17.Text = "Sector Size";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSectorSize
            // 
            this.labelSectorSize.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorSize.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectorSize.ForeColor = System.Drawing.Color.Black;
            this.labelSectorSize.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelSectorSize.Location = new System.Drawing.Point(81, 146);
            this.labelSectorSize.Name = "labelSectorSize";
            this.labelSectorSize.Size = new System.Drawing.Size(140, 18);
            this.labelSectorSize.TabIndex = 64;
            this.labelSectorSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(233, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "Version";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDiskFolder
            // 
            this.labelDiskFolder.AutoEllipsis = true;
            this.labelDiskFolder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDiskFolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDiskFolder.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskFolder.ForeColor = System.Drawing.Color.Black;
            this.labelDiskFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDiskFolder.Location = new System.Drawing.Point(81, 72);
            this.labelDiskFolder.Name = "labelDiskFolder";
            this.labelDiskFolder.Size = new System.Drawing.Size(370, 18);
            this.labelDiskFolder.TabIndex = 62;
            this.labelDiskFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Folder";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDosVersion
            // 
            this.labelDosVersion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDosVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDosVersion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDosVersion.ForeColor = System.Drawing.Color.Black;
            this.labelDosVersion.Location = new System.Drawing.Point(311, 48);
            this.labelDosVersion.Name = "labelDosVersion";
            this.labelDosVersion.Size = new System.Drawing.Size(140, 18);
            this.labelDosVersion.TabIndex = 60;
            this.labelDosVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(233, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 16);
            this.label15.TabIndex = 59;
            this.label15.Text = "Total";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(3, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 58;
            this.label12.Text = "Free";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(3, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 57;
            this.label11.Text = "Used";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(233, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 56;
            this.label9.Text = "Sectors";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(233, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 55;
            this.label8.Text = "Tracks";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSectorsFree
            // 
            this.labelSectorsFree.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorsFree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorsFree.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectorsFree.ForeColor = System.Drawing.Color.Black;
            this.labelSectorsFree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSectorsFree.Location = new System.Drawing.Point(81, 218);
            this.labelSectorsFree.Name = "labelSectorsFree";
            this.labelSectorsFree.Size = new System.Drawing.Size(140, 18);
            this.labelSectorsFree.TabIndex = 50;
            this.labelSectorsFree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorsUsed
            // 
            this.labelSectorsUsed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorsUsed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorsUsed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectorsUsed.ForeColor = System.Drawing.Color.Black;
            this.labelSectorsUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSectorsUsed.Location = new System.Drawing.Point(81, 197);
            this.labelSectorsUsed.Name = "labelSectorsUsed";
            this.labelSectorsUsed.Size = new System.Drawing.Size(140, 18);
            this.labelSectorsUsed.TabIndex = 49;
            this.labelSectorsUsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorsPerTrack
            // 
            this.labelSectorsPerTrack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorsPerTrack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorsPerTrack.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectorsPerTrack.ForeColor = System.Drawing.Color.Black;
            this.labelSectorsPerTrack.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelSectorsPerTrack.Location = new System.Drawing.Point(311, 144);
            this.labelSectorsPerTrack.Name = "labelSectorsPerTrack";
            this.labelSectorsPerTrack.Size = new System.Drawing.Size(140, 18);
            this.labelSectorsPerTrack.TabIndex = 48;
            this.labelSectorsPerTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDOSFormat
            // 
            this.labelDOSFormat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDOSFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDOSFormat.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDOSFormat.ForeColor = System.Drawing.Color.Black;
            this.labelDOSFormat.Location = new System.Drawing.Point(81, 48);
            this.labelDOSFormat.Name = "labelDOSFormat";
            this.labelDOSFormat.Size = new System.Drawing.Size(140, 18);
            this.labelDOSFormat.TabIndex = 14;
            this.labelDOSFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(3, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 16);
            this.label21.TabIndex = 31;
            this.label21.Text = "Sides";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFileCount
            // 
            this.labelFileCount.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelFileCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFileCount.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileCount.ForeColor = System.Drawing.Color.Black;
            this.labelFileCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFileCount.Location = new System.Drawing.Point(311, 218);
            this.labelFileCount.Name = "labelFileCount";
            this.labelFileCount.Size = new System.Drawing.Size(140, 18);
            this.labelFileCount.TabIndex = 35;
            this.labelFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(3, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Disk Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDiskName
            // 
            this.labelDiskName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDiskName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDiskName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskName.ForeColor = System.Drawing.Color.Black;
            this.labelDiskName.Location = new System.Drawing.Point(81, 24);
            this.labelDiskName.Name = "labelDiskName";
            this.labelDiskName.Size = new System.Drawing.Size(140, 18);
            this.labelDiskName.TabIndex = 13;
            this.labelDiskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label23.Location = new System.Drawing.Point(233, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 33;
            this.label23.Text = "Disk Type";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSides
            // 
            this.labelSides.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSides.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSides.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSides.ForeColor = System.Drawing.Color.Black;
            this.labelSides.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSides.Location = new System.Drawing.Point(81, 123);
            this.labelSides.Name = "labelSides";
            this.labelSides.Size = new System.Drawing.Size(140, 18);
            this.labelSides.TabIndex = 39;
            this.labelSides.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTracksPerSide
            // 
            this.labelTracksPerSide.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelTracksPerSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTracksPerSide.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTracksPerSide.ForeColor = System.Drawing.Color.Black;
            this.labelTracksPerSide.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelTracksPerSide.Location = new System.Drawing.Point(311, 122);
            this.labelTracksPerSide.Name = "labelTracksPerSide";
            this.labelTracksPerSide.Size = new System.Drawing.Size(140, 18);
            this.labelTracksPerSide.TabIndex = 40;
            this.labelTracksPerSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDiskType
            // 
            this.labelDiskType.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelDiskType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDiskType.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiskType.ForeColor = System.Drawing.Color.Black;
            this.labelDiskType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDiskType.Location = new System.Drawing.Point(311, 24);
            this.labelDiskType.Name = "labelDiskType";
            this.labelDiskType.Size = new System.Drawing.Size(140, 18);
            this.labelDiskType.TabIndex = 34;
            this.labelDiskType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorTotal
            // 
            this.labelSectorTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorTotal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSectorTotal.ForeColor = System.Drawing.Color.Black;
            this.labelSectorTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSectorTotal.Location = new System.Drawing.Point(311, 197);
            this.labelSectorTotal.Name = "labelSectorTotal";
            this.labelSectorTotal.Size = new System.Drawing.Size(140, 18);
            this.labelSectorTotal.TabIndex = 36;
            this.labelSectorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(3, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "DOS Format";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(233, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "File Count";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BackSecondaryColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 40;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.TitleAlignment = System.Drawing.StringAlignment.Far;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(477, 4);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            dataPoint1.CustomProperties = "Exploded=True";
            dataPoint1.IsVisibleInLegend = true;
            dataPoint2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataPoint2.IsVisibleInLegend = true;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(215, 248);
            this.chart1.TabIndex = 46;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Disk Usage";
            this.chart1.Titles.Add(title1);
            // 
            // tabPageDirectory
            // 
            this.tabPageDirectory.Controls.Add(this.buttonPrintSetup);
            this.tabPageDirectory.Controls.Add(this.buttonPrintPreview);
            this.tabPageDirectory.Controls.Add(this.buttonPrintDirectory);
            this.tabPageDirectory.Controls.Add(this.checkBoxViewGroups);
            this.tabPageDirectory.Controls.Add(this.lvDirectory);
            this.tabPageDirectory.Location = new System.Drawing.Point(4, 22);
            this.tabPageDirectory.Name = "tabPageDirectory";
            this.tabPageDirectory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDirectory.Size = new System.Drawing.Size(702, 256);
            this.tabPageDirectory.TabIndex = 0;
            this.tabPageDirectory.Text = "Directory Listing";
            this.tabPageDirectory.UseVisualStyleBackColor = true;
            // 
            // buttonPrintSetup
            // 
            this.buttonPrintSetup.Image = global::OricExplorer.Properties.Resources.PrintSetupHS;
            this.buttonPrintSetup.Location = new System.Drawing.Point(583, 4);
            this.buttonPrintSetup.Name = "buttonPrintSetup";
            this.buttonPrintSetup.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintSetup.TabIndex = 5;
            this.buttonPrintSetup.Text = "Print Setup";
            this.buttonPrintSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintSetup.UseVisualStyleBackColor = true;
            this.buttonPrintSetup.Click += new System.EventHandler(this.buttonPrintSetup_Click);
            // 
            // buttonPrintPreview
            // 
            this.buttonPrintPreview.Image = global::OricExplorer.Properties.Resources.PrintPreviewHS;
            this.buttonPrintPreview.Location = new System.Drawing.Point(476, 4);
            this.buttonPrintPreview.Name = "buttonPrintPreview";
            this.buttonPrintPreview.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintPreview.TabIndex = 4;
            this.buttonPrintPreview.Text = "Print Preview";
            this.buttonPrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintPreview.UseVisualStyleBackColor = true;
            this.buttonPrintPreview.Click += new System.EventHandler(this.buttonPrintPreview_Click);
            // 
            // buttonPrintDirectory
            // 
            this.buttonPrintDirectory.Image = global::OricExplorer.Properties.Resources.PrintHS;
            this.buttonPrintDirectory.Location = new System.Drawing.Point(370, 4);
            this.buttonPrintDirectory.Name = "buttonPrintDirectory";
            this.buttonPrintDirectory.Size = new System.Drawing.Size(100, 24);
            this.buttonPrintDirectory.TabIndex = 3;
            this.buttonPrintDirectory.Text = "Print Directory";
            this.buttonPrintDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintDirectory.UseVisualStyleBackColor = true;
            this.buttonPrintDirectory.Click += new System.EventHandler(this.buttonPrintDirectory_Click);
            // 
            // checkBoxViewGroups
            // 
            this.checkBoxViewGroups.AutoSize = true;
            this.checkBoxViewGroups.Location = new System.Drawing.Point(8, 9);
            this.checkBoxViewGroups.Name = "checkBoxViewGroups";
            this.checkBoxViewGroups.Size = new System.Drawing.Size(86, 17);
            this.checkBoxViewGroups.TabIndex = 2;
            this.checkBoxViewGroups.Text = "View Groups";
            this.checkBoxViewGroups.UseVisualStyleBackColor = true;
            this.checkBoxViewGroups.CheckedChanged += new System.EventHandler(this.checkBoxViewGroups_CheckedChanged);
            // 
            // lvDirectory
            // 
            this.lvDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDirectory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnFormat,
            this.columnSectors,
            this.columnSize,
            this.columnStart,
            this.columnEnd,
            this.columnExe,
            this.columnAutoRun,
            this.columnProtection});
            this.lvDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvDirectory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDirectory.FullRowSelect = true;
            listViewGroup1.Header = "BASIC Programs";
            listViewGroup1.Name = "listViewGroupBasic";
            listViewGroup2.Header = "Code/Data Files";
            listViewGroup2.Name = "listViewGroupCode";
            listViewGroup3.Header = "TEXT Screens";
            listViewGroup3.Name = "listViewGroupText";
            listViewGroup4.Header = "HIRES Screens";
            listViewGroup4.Name = "listViewGroupHires";
            listViewGroup5.Header = "Character Sets";
            listViewGroup5.Name = "listViewGroupCharSets";
            listViewGroup6.Header = "Text Windows";
            listViewGroup6.Name = "listViewGroupWindows";
            listViewGroup7.Header = "Sequential Data Files";
            listViewGroup7.Name = "listViewGroupSequential";
            listViewGroup8.Header = "Direct Access Files";
            listViewGroup8.Name = "listViewGroupDirectAccess";
            listViewGroup9.Header = "Other";
            listViewGroup9.Name = "listViewGroupOther";
            listViewGroup10.Header = "HELP Screens";
            listViewGroup10.Name = "listViewGroupHelpScreens";
            this.lvDirectory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            this.lvDirectory.HideSelection = false;
            this.lvDirectory.Location = new System.Drawing.Point(1, 33);
            this.lvDirectory.MultiSelect = false;
            this.lvDirectory.Name = "lvDirectory";
            this.lvDirectory.ShowItemToolTips = true;
            this.lvDirectory.Size = new System.Drawing.Size(687, 223);
            this.lvDirectory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDirectory.TabIndex = 1;
            this.lvDirectory.UseCompatibleStateImageBehavior = false;
            this.lvDirectory.View = System.Windows.Forms.View.Details;
            this.lvDirectory.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvDirectory_ColumnClick);
            this.lvDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvDirectory_MouseClick);
            // 
            // columnFilename
            // 
            this.columnFilename.Text = "Filename";
            this.columnFilename.Width = 136;
            // 
            // columnFormat
            // 
            this.columnFormat.Text = "Format";
            // 
            // columnSectors
            // 
            this.columnSectors.Text = "Sectors";
            this.columnSectors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnSectors.Width = 66;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Bytes";
            this.columnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnSize.Width = 97;
            // 
            // columnStart
            // 
            this.columnStart.Text = "Start";
            this.columnStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnEnd
            // 
            this.columnEnd.Text = "End";
            this.columnEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnExe
            // 
            this.columnExe.Text = "Exe";
            this.columnExe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnAutoRun
            // 
            this.columnAutoRun.Text = "Auto Run";
            // 
            // columnProtection
            // 
            this.columnProtection.Text = "Status";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(155, 290);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(710, 345);
            this.tabControl2.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.hexBoxSectorView);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(702, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sector Data";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.listViewSectorList);
            this.panel3.Controls.Add(this.checkBoxDisplayAsHex);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(528, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 306);
            this.panel3.TabIndex = 66;
            // 
            // listViewSectorList
            // 
            this.listViewSectorList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCount,
            this.columnHeaderSide,
            this.columnHeaderTrack,
            this.columnHeaderSector});
            this.listViewSectorList.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSectorList.FullRowSelect = true;
            this.listViewSectorList.GridLines = true;
            this.listViewSectorList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSectorList.HideSelection = false;
            this.listViewSectorList.Location = new System.Drawing.Point(5, 22);
            this.listViewSectorList.MultiSelect = false;
            this.listViewSectorList.Name = "listViewSectorList";
            this.listViewSectorList.ShowGroups = false;
            this.listViewSectorList.Size = new System.Drawing.Size(158, 212);
            this.listViewSectorList.TabIndex = 62;
            this.listViewSectorList.UseCompatibleStateImageBehavior = false;
            this.listViewSectorList.View = System.Windows.Forms.View.Details;
            this.listViewSectorList.SelectedIndexChanged += new System.EventHandler(this.listViewSectorList_SelectedIndexChanged);
            // 
            // columnHeaderCount
            // 
            this.columnHeaderCount.Text = "";
            this.columnHeaderCount.Width = 5;
            // 
            // columnHeaderSide
            // 
            this.columnHeaderSide.Text = "Side";
            this.columnHeaderSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderSide.Width = 44;
            // 
            // columnHeaderTrack
            // 
            this.columnHeaderTrack.Text = "Trk";
            this.columnHeaderTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderTrack.Width = 44;
            // 
            // columnHeaderSector
            // 
            this.columnHeaderSector.Text = "Sect";
            this.columnHeaderSector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderSector.Width = 48;
            // 
            // checkBoxDisplayAsHex
            // 
            this.checkBoxDisplayAsHex.AutoSize = true;
            this.checkBoxDisplayAsHex.Location = new System.Drawing.Point(11, 248);
            this.checkBoxDisplayAsHex.Name = "checkBoxDisplayAsHex";
            this.checkBoxDisplayAsHex.Size = new System.Drawing.Size(146, 17);
            this.checkBoxDisplayAsHex.TabIndex = 65;
            this.checkBoxDisplayAsHex.Text = "Display Sector List in Hex";
            this.checkBoxDisplayAsHex.UseVisualStyleBackColor = true;
            this.checkBoxDisplayAsHex.CheckedChanged += new System.EventHandler(this.checkBoxDisplayAsHex_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(56, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "Sector List";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trackBarSectors);
            this.groupBox2.Location = new System.Drawing.Point(273, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 65);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sector";
            // 
            // trackBarSectors
            // 
            this.trackBarSectors.Location = new System.Drawing.Point(7, 15);
            this.trackBarSectors.Name = "trackBarSectors";
            this.trackBarSectors.Size = new System.Drawing.Size(237, 45);
            this.trackBarSectors.TabIndex = 47;
            this.trackBarSectors.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSectors.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBarTracks);
            this.groupBox1.Location = new System.Drawing.Point(8, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 65);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track";
            // 
            // trackBarTracks
            // 
            this.trackBarTracks.Location = new System.Drawing.Point(7, 15);
            this.trackBarTracks.Name = "trackBarTracks";
            this.trackBarTracks.Size = new System.Drawing.Size(237, 45);
            this.trackBarTracks.TabIndex = 46;
            this.trackBarTracks.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarTracks.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // hexBoxSectorView
            // 
            this.hexBoxSectorView.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBoxSectorView.LineInfoForeColor = System.Drawing.Color.Teal;
            this.hexBoxSectorView.LineInfoOffset = ((long)(0));
            this.hexBoxSectorView.LineInfoVisible = true;
            this.hexBoxSectorView.Location = new System.Drawing.Point(8, 29);
            this.hexBoxSectorView.Name = "hexBoxSectorView";
            this.hexBoxSectorView.ReadOnly = true;
            this.hexBoxSectorView.SelectionForeColor = System.Drawing.Color.Yellow;
            this.hexBoxSectorView.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBoxSectorView.Size = new System.Drawing.Size(515, 212);
            this.hexBoxSectorView.StringViewVisible = true;
            this.hexBoxSectorView.TabIndex = 47;
            this.hexBoxSectorView.UseFixedBytesPerLine = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(267, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 18);
            this.label7.TabIndex = 30;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 18);
            this.label6.TabIndex = 29;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSides
            // 
            this.tabSides.Controls.Add(this.tabPageSide0);
            this.tabSides.Controls.Add(this.tabPageSide1);
            this.tabSides.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSides.Location = new System.Drawing.Point(1, 2);
            this.tabSides.Name = "tabSides";
            this.tabSides.SelectedIndex = 0;
            this.tabSides.Size = new System.Drawing.Size(152, 524);
            this.tabSides.TabIndex = 25;
            // 
            // tabPageSide0
            // 
            this.tabPageSide0.Controls.Add(this.pbSectorMapSide0);
            this.tabPageSide0.Location = new System.Drawing.Point(4, 22);
            this.tabPageSide0.Name = "tabPageSide0";
            this.tabPageSide0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSide0.Size = new System.Drawing.Size(144, 498);
            this.tabPageSide0.TabIndex = 0;
            this.tabPageSide0.Text = "Side 0";
            this.tabPageSide0.UseVisualStyleBackColor = true;
            // 
            // pbSectorMapSide0
            // 
            this.pbSectorMapSide0.BackColor = System.Drawing.SystemColors.Control;
            this.pbSectorMapSide0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSectorMapSide0.Location = new System.Drawing.Point(0, 0);
            this.pbSectorMapSide0.Name = "pbSectorMapSide0";
            this.pbSectorMapSide0.Size = new System.Drawing.Size(141, 495);
            this.pbSectorMapSide0.TabIndex = 0;
            this.pbSectorMapSide0.TabStop = false;
            this.pbSectorMapSide0.MouseLeave += new System.EventHandler(this.pbSectorMap_MouseLeave);
            this.pbSectorMapSide0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseMove);
            this.pbSectorMapSide0.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseUp);
            // 
            // tabPageSide1
            // 
            this.tabPageSide1.Controls.Add(this.pbSectorMapSide1);
            this.tabPageSide1.Location = new System.Drawing.Point(4, 22);
            this.tabPageSide1.Name = "tabPageSide1";
            this.tabPageSide1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSide1.Size = new System.Drawing.Size(144, 498);
            this.tabPageSide1.TabIndex = 1;
            this.tabPageSide1.Text = "Side 1";
            this.tabPageSide1.UseVisualStyleBackColor = true;
            // 
            // pbSectorMapSide1
            // 
            this.pbSectorMapSide1.BackColor = System.Drawing.SystemColors.Control;
            this.pbSectorMapSide1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSectorMapSide1.Location = new System.Drawing.Point(0, 0);
            this.pbSectorMapSide1.Name = "pbSectorMapSide1";
            this.pbSectorMapSide1.Size = new System.Drawing.Size(141, 495);
            this.pbSectorMapSide1.TabIndex = 1;
            this.pbSectorMapSide1.TabStop = false;
            this.pbSectorMapSide1.MouseLeave += new System.EventHandler(this.pbSectorMap_MouseLeave);
            this.pbSectorMapSide1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseMove);
            this.pbSectorMapSide1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSectorMap_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelSectorMapSectorHex);
            this.panel2.Controls.Add(this.labelSectorMapTrackHex);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.labelSectorMapInfo);
            this.panel2.Controls.Add(this.labelSectorMapSector);
            this.panel2.Controls.Add(this.labelSectorMapTrack);
            this.panel2.Controls.Add(this.labelSectorMapSide);
            this.panel2.Location = new System.Drawing.Point(1, 528);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 106);
            this.panel2.TabIndex = 28;
            // 
            // labelSectorMapSectorHex
            // 
            this.labelSectorMapSectorHex.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorMapSectorHex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapSectorHex.ForeColor = System.Drawing.Color.DimGray;
            this.labelSectorMapSectorHex.Location = new System.Drawing.Point(102, 50);
            this.labelSectorMapSectorHex.Name = "labelSectorMapSectorHex";
            this.labelSectorMapSectorHex.Size = new System.Drawing.Size(45, 18);
            this.labelSectorMapSectorHex.TabIndex = 9;
            this.labelSectorMapSectorHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorMapTrackHex
            // 
            this.labelSectorMapTrackHex.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorMapTrackHex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapTrackHex.ForeColor = System.Drawing.Color.DimGray;
            this.labelSectorMapTrackHex.Location = new System.Drawing.Point(102, 27);
            this.labelSectorMapTrackHex.Name = "labelSectorMapTrackHex";
            this.labelSectorMapTrackHex.Size = new System.Drawing.Size(45, 18);
            this.labelSectorMapTrackHex.TabIndex = 8;
            this.labelSectorMapTrackHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Sector :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "Track :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Side :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSectorMapInfo
            // 
            this.labelSectorMapInfo.BackColor = System.Drawing.SystemColors.Info;
            this.labelSectorMapInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapInfo.Location = new System.Drawing.Point(3, 72);
            this.labelSectorMapInfo.Name = "labelSectorMapInfo";
            this.labelSectorMapInfo.Size = new System.Drawing.Size(144, 30);
            this.labelSectorMapInfo.TabIndex = 3;
            this.labelSectorMapInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorMapSector
            // 
            this.labelSectorMapSector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorMapSector.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapSector.Location = new System.Drawing.Point(53, 50);
            this.labelSectorMapSector.Name = "labelSectorMapSector";
            this.labelSectorMapSector.Size = new System.Drawing.Size(45, 18);
            this.labelSectorMapSector.TabIndex = 2;
            this.labelSectorMapSector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorMapTrack
            // 
            this.labelSectorMapTrack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorMapTrack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapTrack.Location = new System.Drawing.Point(53, 27);
            this.labelSectorMapTrack.Name = "labelSectorMapTrack";
            this.labelSectorMapTrack.Size = new System.Drawing.Size(45, 18);
            this.labelSectorMapTrack.TabIndex = 1;
            this.labelSectorMapTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSectorMapSide
            // 
            this.labelSectorMapSide.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelSectorMapSide.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSectorMapSide.Location = new System.Drawing.Point(53, 4);
            this.labelSectorMapSide.Name = "labelSectorMapSide";
            this.labelSectorMapSide.Size = new System.Drawing.Size(45, 18);
            this.labelSectorMapSide.TabIndex = 0;
            this.labelSectorMapSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SectorViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(867, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabSides);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(707, 39);
            this.Name = "SectorViewerControl";
            this.Text = "Disk Information";
            this.Load += new System.EventHandler(this.SectorViewerControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPageDirectory.ResumeLayout(false);
            this.tabPageDirectory.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSectors)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTracks)).EndInit();
            this.tabSides.ResumeLayout(false);
            this.tabPageSide0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide0)).EndInit();
            this.tabPageSide1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSectorMapSide1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDirectory;
        private System.Windows.Forms.ListView lvDirectory;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnFormat;
        private System.Windows.Forms.ColumnHeader columnSectors;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnStart;
        private System.Windows.Forms.ColumnHeader columnEnd;
        private System.Windows.Forms.ColumnHeader columnExe;
        private System.Windows.Forms.ColumnHeader columnAutoRun;
        private System.Windows.Forms.ColumnHeader columnProtection;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabSides;
        private System.Windows.Forms.TabPage tabPageSide0;
        private System.Windows.Forms.PictureBox pbSectorMapSide0;
        private System.Windows.Forms.TabPage tabPageSide1;
        private System.Windows.Forms.PictureBox pbSectorMapSide1;
        private System.Windows.Forms.TabPage tabPageUsage;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label labelDiskType;
        private System.Windows.Forms.Label labelFileCount;
        private System.Windows.Forms.Label labelSectorTotal;
        private System.Windows.Forms.Label labelDiskName;
        private System.Windows.Forms.Label labelDOSFormat;
        private System.Windows.Forms.Label labelSides;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelTracksPerSide;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        private Be.Windows.Forms.HexBox hexBoxSectorView;
        private System.Windows.Forms.Label labelSectorsFree;
        private System.Windows.Forms.Label labelSectorsUsed;
        private System.Windows.Forms.Label labelSectorsPerTrack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBarSectors;
        private System.Windows.Forms.TrackBar trackBarTracks;
        private System.Windows.Forms.Button buttonPrintSetup;
        private System.Windows.Forms.Button buttonPrintPreview;
        private System.Windows.Forms.Button buttonPrintDirectory;
        private System.Windows.Forms.CheckBox checkBoxViewGroups;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewSectorList;
        private System.Windows.Forms.ColumnHeader columnHeaderSide;
        private System.Windows.Forms.ColumnHeader columnHeaderTrack;
        private System.Windows.Forms.ColumnHeader columnHeaderSector;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelDosVersion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelSectorMapInfo;
        private System.Windows.Forms.Label labelSectorMapSector;
        private System.Windows.Forms.Label labelSectorMapTrack;
        private System.Windows.Forms.Label labelSectorMapSide;
        private System.Windows.Forms.Label labelSectorMapSectorHex;
        private System.Windows.Forms.Label labelSectorMapTrackHex;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelSectorSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDiskFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxDisplayAsHex;
        private System.Windows.Forms.ColumnHeader columnHeaderCount;
    }
}