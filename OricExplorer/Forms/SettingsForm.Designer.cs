namespace OricExplorer
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonRemoveFolder = new System.Windows.Forms.Button();
            this.buttonUpdateFolder = new System.Windows.Forms.Button();
            this.checkBoxScanSubfolders = new System.Windows.Forms.CheckBox();
            this.radioButtonTapes = new System.Windows.Forms.RadioButton();
            this.radioButtonDisks = new System.Windows.Forms.RadioButton();
            this.listViewFolderList = new System.Windows.Forms.ListView();
            this.columnHeaderFolderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEmulatorExecutable = new System.Windows.Forms.Button();
            this.textBoxEmulatorExecutable = new System.Windows.Forms.TextBox();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonDirListingsFolder = new System.Windows.Forms.Button();
            this.textBoxDirListingFolder = new System.Windows.Forms.TextBox();
            this.groupFrame1 = new GroupFrame.GroupFrame();
            this.groupFrame4 = new GroupFrame.GroupFrame();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonROMs = new System.Windows.Forms.RadioButton();
            this.buttonBrowseForFolder = new System.Windows.Forms.Button();
            this.textBoxSelectedFolder = new System.Windows.Forms.TextBox();
            this.groupFrame2 = new GroupFrame.GroupFrame();
            this.label1 = new System.Windows.Forms.Label();
            this.groupFrame3 = new GroupFrame.GroupFrame();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTapeAndDiskFolders = new System.Windows.Forms.TabPage();
            this.tabPageEmulator = new System.Windows.Forms.TabPage();
            this.tabPageDirListings = new System.Windows.Forms.TabPage();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.groupFrame5 = new GroupFrame.GroupFrame();
            this.checkBoxCheckForUpdatesOnStartup = new System.Windows.Forms.CheckBox();
            this.listViewFieldsAvailable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFieldsSelected = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddField = new System.Windows.Forms.Button();
            this.buttonRemoveField = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.textBoxSample = new System.Windows.Forms.TextBox();
            this.groupFrame1.SuspendLayout();
            this.groupFrame4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupFrame2.SuspendLayout();
            this.groupFrame3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTapeAndDiskFolders.SuspendLayout();
            this.tabPageEmulator.SuspendLayout();
            this.tabPageDirListings.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.groupFrame5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(8, 17);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 13;
            this.buttonAddFolder.Text = "Add...";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // buttonRemoveFolder
            // 
            this.buttonRemoveFolder.Location = new System.Drawing.Point(8, 73);
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.buttonRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveFolder.TabIndex = 12;
            this.buttonRemoveFolder.Text = "Remove";
            this.buttonRemoveFolder.UseVisualStyleBackColor = true;
            this.buttonRemoveFolder.Click += new System.EventHandler(this.buttonRemoveFolder_Click);
            // 
            // buttonUpdateFolder
            // 
            this.buttonUpdateFolder.Location = new System.Drawing.Point(8, 45);
            this.buttonUpdateFolder.Name = "buttonUpdateFolder";
            this.buttonUpdateFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateFolder.TabIndex = 15;
            this.buttonUpdateFolder.Text = "Update";
            this.buttonUpdateFolder.UseVisualStyleBackColor = true;
            this.buttonUpdateFolder.Click += new System.EventHandler(this.buttonUpdateFolder_Click);
            // 
            // checkBoxScanSubfolders
            // 
            this.checkBoxScanSubfolders.AutoSize = true;
            this.checkBoxScanSubfolders.Checked = true;
            this.checkBoxScanSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxScanSubfolders.ForeColor = System.Drawing.Color.Black;
            this.checkBoxScanSubfolders.Location = new System.Drawing.Point(414, 19);
            this.checkBoxScanSubfolders.Name = "checkBoxScanSubfolders";
            this.checkBoxScanSubfolders.Size = new System.Drawing.Size(108, 17);
            this.checkBoxScanSubfolders.TabIndex = 3;
            this.checkBoxScanSubfolders.Text = "Scan subfolders?";
            this.checkBoxScanSubfolders.UseVisualStyleBackColor = true;
            // 
            // radioButtonTapes
            // 
            this.radioButtonTapes.AutoSize = true;
            this.radioButtonTapes.ForeColor = System.Drawing.Color.Black;
            this.radioButtonTapes.Location = new System.Drawing.Point(9, 19);
            this.radioButtonTapes.Name = "radioButtonTapes";
            this.radioButtonTapes.Size = new System.Drawing.Size(98, 17);
            this.radioButtonTapes.TabIndex = 1;
            this.radioButtonTapes.TabStop = true;
            this.radioButtonTapes.Text = "Tape files (.tap)";
            this.radioButtonTapes.UseVisualStyleBackColor = true;
            // 
            // radioButtonDisks
            // 
            this.radioButtonDisks.AutoSize = true;
            this.radioButtonDisks.ForeColor = System.Drawing.Color.Black;
            this.radioButtonDisks.Location = new System.Drawing.Point(113, 19);
            this.radioButtonDisks.Name = "radioButtonDisks";
            this.radioButtonDisks.Size = new System.Drawing.Size(96, 17);
            this.radioButtonDisks.TabIndex = 2;
            this.radioButtonDisks.TabStop = true;
            this.radioButtonDisks.Text = "Disk files (.dsk)";
            this.radioButtonDisks.UseVisualStyleBackColor = true;
            // 
            // listViewFolderList
            // 
            this.listViewFolderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFolderType,
            this.columnHeaderFolderName});
            this.listViewFolderList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFolderList.FullRowSelect = true;
            this.listViewFolderList.GridLines = true;
            this.listViewFolderList.Location = new System.Drawing.Point(8, 135);
            this.listViewFolderList.Name = "listViewFolderList";
            this.listViewFolderList.Size = new System.Drawing.Size(629, 160);
            this.listViewFolderList.TabIndex = 0;
            this.listViewFolderList.UseCompatibleStateImageBehavior = false;
            this.listViewFolderList.View = System.Windows.Forms.View.Details;
            this.listViewFolderList.Click += new System.EventHandler(this.listViewFolderList_Click);
            this.listViewFolderList.DoubleClick += new System.EventHandler(this.listViewFolderList_DoubleClick);
            // 
            // columnHeaderFolderType
            // 
            this.columnHeaderFolderType.Text = "Media Type";
            this.columnHeaderFolderType.Width = 82;
            // 
            // columnHeaderFolderName
            // 
            this.columnHeaderFolderName.Text = "Folder";
            this.columnHeaderFolderName.Width = 450;
            // 
            // buttonEmulatorExecutable
            // 
            this.buttonEmulatorExecutable.ForeColor = System.Drawing.Color.Black;
            this.buttonEmulatorExecutable.Location = new System.Drawing.Point(553, 48);
            this.buttonEmulatorExecutable.Name = "buttonEmulatorExecutable";
            this.buttonEmulatorExecutable.Size = new System.Drawing.Size(77, 22);
            this.buttonEmulatorExecutable.TabIndex = 2;
            this.buttonEmulatorExecutable.Text = "Browse...";
            this.buttonEmulatorExecutable.UseVisualStyleBackColor = true;
            this.buttonEmulatorExecutable.Click += new System.EventHandler(this.buttonEmulatorExecutable_Click);
            // 
            // textBoxEmulatorExecutable
            // 
            this.textBoxEmulatorExecutable.ForeColor = System.Drawing.Color.Black;
            this.textBoxEmulatorExecutable.Location = new System.Drawing.Point(9, 48);
            this.textBoxEmulatorExecutable.Name = "textBoxEmulatorExecutable";
            this.textBoxEmulatorExecutable.Size = new System.Drawing.Size(538, 20);
            this.textBoxEmulatorExecutable.TabIndex = 1;
            // 
            // buttonOkay
            // 
            this.buttonOkay.Location = new System.Drawing.Point(421, 378);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(77, 22);
            this.buttonOkay.TabIndex = 2;
            this.buttonOkay.Text = "OK";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(587, 378);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 22);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(504, 378);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(77, 22);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonDirListingsFolder
            // 
            this.buttonDirListingsFolder.ForeColor = System.Drawing.Color.Black;
            this.buttonDirListingsFolder.Location = new System.Drawing.Point(553, 48);
            this.buttonDirListingsFolder.Name = "buttonDirListingsFolder";
            this.buttonDirListingsFolder.Size = new System.Drawing.Size(77, 22);
            this.buttonDirListingsFolder.TabIndex = 2;
            this.buttonDirListingsFolder.Text = "Browse...";
            this.buttonDirListingsFolder.UseVisualStyleBackColor = true;
            this.buttonDirListingsFolder.Click += new System.EventHandler(this.buttonDirListingsFolder_Click);
            // 
            // textBoxDirListingFolder
            // 
            this.textBoxDirListingFolder.ForeColor = System.Drawing.Color.Black;
            this.textBoxDirListingFolder.Location = new System.Drawing.Point(9, 48);
            this.textBoxDirListingFolder.Name = "textBoxDirListingFolder";
            this.textBoxDirListingFolder.Size = new System.Drawing.Size(538, 20);
            this.textBoxDirListingFolder.TabIndex = 1;
            // 
            // groupFrame1
            // 
            this.groupFrame1.Controls.Add(this.groupFrame4);
            this.groupFrame1.Controls.Add(this.groupBox2);
            this.groupFrame1.Controls.Add(this.listViewFolderList);
            this.groupFrame1.ForeColor = System.Drawing.Color.Black;
            this.groupFrame1.Location = new System.Drawing.Point(7, 6);
            this.groupFrame1.Name = "groupFrame1";
            this.groupFrame1.Size = new System.Drawing.Size(647, 301);
            this.groupFrame1.TabIndex = 18;
            this.groupFrame1.TabStop = false;
            this.groupFrame1.Text = "Disk and Tape Folders";
            this.groupFrame1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupFrame4
            // 
            this.groupFrame4.Controls.Add(this.buttonAddFolder);
            this.groupFrame4.Controls.Add(this.buttonUpdateFolder);
            this.groupFrame4.Controls.Add(this.buttonRemoveFolder);
            this.groupFrame4.Location = new System.Drawing.Point(547, 19);
            this.groupFrame4.Name = "groupFrame4";
            this.groupFrame4.Size = new System.Drawing.Size(90, 110);
            this.groupFrame4.TabIndex = 21;
            this.groupFrame4.TabStop = false;
            this.groupFrame4.Text = "Options";
            this.groupFrame4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonROMs);
            this.groupBox2.Controls.Add(this.buttonBrowseForFolder);
            this.groupBox2.Controls.Add(this.textBoxSelectedFolder);
            this.groupBox2.Controls.Add(this.radioButtonTapes);
            this.groupBox2.Controls.Add(this.checkBoxScanSubfolders);
            this.groupBox2.Controls.Add(this.radioButtonDisks);
            this.groupBox2.Location = new System.Drawing.Point(8, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 110);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folder Details";
            // 
            // radioButtonROMs
            // 
            this.radioButtonROMs.AutoSize = true;
            this.radioButtonROMs.ForeColor = System.Drawing.Color.Black;
            this.radioButtonROMs.Location = new System.Drawing.Point(215, 19);
            this.radioButtonROMs.Name = "radioButtonROMs";
            this.radioButtonROMs.Size = new System.Drawing.Size(100, 17);
            this.radioButtonROMs.TabIndex = 24;
            this.radioButtonROMs.TabStop = true;
            this.radioButtonROMs.Text = "ROM files (.rom)";
            this.radioButtonROMs.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseForFolder
            // 
            this.buttonBrowseForFolder.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseForFolder.Location = new System.Drawing.Point(445, 75);
            this.buttonBrowseForFolder.Name = "buttonBrowseForFolder";
            this.buttonBrowseForFolder.Size = new System.Drawing.Size(77, 22);
            this.buttonBrowseForFolder.TabIndex = 23;
            this.buttonBrowseForFolder.Text = "Browse...";
            this.buttonBrowseForFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseForFolder.Click += new System.EventHandler(this.buttonBrowseForFolder_Click);
            // 
            // textBoxSelectedFolder
            // 
            this.textBoxSelectedFolder.ForeColor = System.Drawing.Color.Black;
            this.textBoxSelectedFolder.Location = new System.Drawing.Point(9, 47);
            this.textBoxSelectedFolder.Name = "textBoxSelectedFolder";
            this.textBoxSelectedFolder.Size = new System.Drawing.Size(513, 20);
            this.textBoxSelectedFolder.TabIndex = 22;
            this.textBoxSelectedFolder.TextChanged += new System.EventHandler(this.textBoxSelectedFolder_TextChanged);
            // 
            // groupFrame2
            // 
            this.groupFrame2.Controls.Add(this.label1);
            this.groupFrame2.Controls.Add(this.textBoxEmulatorExecutable);
            this.groupFrame2.Controls.Add(this.buttonEmulatorExecutable);
            this.groupFrame2.ForeColor = System.Drawing.Color.Black;
            this.groupFrame2.Location = new System.Drawing.Point(7, 6);
            this.groupFrame2.Name = "groupFrame2";
            this.groupFrame2.Size = new System.Drawing.Size(647, 76);
            this.groupFrame2.TabIndex = 19;
            this.groupFrame2.TabStop = false;
            this.groupFrame2.Text = "Emulator";
            this.groupFrame2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Please specify the folder and name of the Emulator executable file eg. C:\\Program" +
    " Files\\Oricutron\\Oricutron.exe\r\n";
            // 
            // groupFrame3
            // 
            this.groupFrame3.Controls.Add(this.label2);
            this.groupFrame3.Controls.Add(this.textBoxDirListingFolder);
            this.groupFrame3.Controls.Add(this.buttonDirListingsFolder);
            this.groupFrame3.ForeColor = System.Drawing.Color.Black;
            this.groupFrame3.Location = new System.Drawing.Point(7, 3);
            this.groupFrame3.Name = "groupFrame3";
            this.groupFrame3.Size = new System.Drawing.Size(647, 76);
            this.groupFrame3.TabIndex = 20;
            this.groupFrame3.TabStop = false;
            this.groupFrame3.Text = "Directory Listings";
            this.groupFrame3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Please specify the folder where Disk and Tape directory listings will be output t" +
    "o\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTapeAndDiskFolders);
            this.tabControl1.Controls.Add(this.tabPageEmulator);
            this.tabControl1.Controls.Add(this.tabPageDirListings);
            this.tabControl1.Controls.Add(this.tabPageOther);
            this.tabControl1.Location = new System.Drawing.Point(5, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 366);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPageTapeAndDiskFolders
            // 
            this.tabPageTapeAndDiskFolders.Controls.Add(this.groupFrame1);
            this.tabPageTapeAndDiskFolders.Location = new System.Drawing.Point(4, 22);
            this.tabPageTapeAndDiskFolders.Name = "tabPageTapeAndDiskFolders";
            this.tabPageTapeAndDiskFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTapeAndDiskFolders.Size = new System.Drawing.Size(661, 340);
            this.tabPageTapeAndDiskFolders.TabIndex = 0;
            this.tabPageTapeAndDiskFolders.Text = "Tape and Disk Folders";
            this.tabPageTapeAndDiskFolders.UseVisualStyleBackColor = true;
            // 
            // tabPageEmulator
            // 
            this.tabPageEmulator.Controls.Add(this.groupFrame2);
            this.tabPageEmulator.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmulator.Name = "tabPageEmulator";
            this.tabPageEmulator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmulator.Size = new System.Drawing.Size(661, 340);
            this.tabPageEmulator.TabIndex = 1;
            this.tabPageEmulator.Text = "Emulator";
            this.tabPageEmulator.UseVisualStyleBackColor = true;
            // 
            // tabPageDirListings
            // 
            this.tabPageDirListings.Controls.Add(this.textBoxSample);
            this.tabPageDirListings.Controls.Add(this.buttonMoveDown);
            this.tabPageDirListings.Controls.Add(this.buttonMoveUp);
            this.tabPageDirListings.Controls.Add(this.buttonRemoveField);
            this.tabPageDirListings.Controls.Add(this.buttonAddField);
            this.tabPageDirListings.Controls.Add(this.listViewFieldsSelected);
            this.tabPageDirListings.Controls.Add(this.listViewFieldsAvailable);
            this.tabPageDirListings.Controls.Add(this.groupFrame3);
            this.tabPageDirListings.Location = new System.Drawing.Point(4, 22);
            this.tabPageDirListings.Name = "tabPageDirListings";
            this.tabPageDirListings.Size = new System.Drawing.Size(661, 340);
            this.tabPageDirListings.TabIndex = 2;
            this.tabPageDirListings.Text = "Directory Listings";
            this.tabPageDirListings.UseVisualStyleBackColor = true;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Controls.Add(this.groupFrame5);
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Size = new System.Drawing.Size(661, 340);
            this.tabPageOther.TabIndex = 3;
            this.tabPageOther.Text = "Other Settings";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // groupFrame5
            // 
            this.groupFrame5.Controls.Add(this.checkBoxCheckForUpdatesOnStartup);
            this.groupFrame5.Location = new System.Drawing.Point(6, 6);
            this.groupFrame5.Name = "groupFrame5";
            this.groupFrame5.Size = new System.Drawing.Size(200, 47);
            this.groupFrame5.TabIndex = 1;
            this.groupFrame5.TabStop = false;
            this.groupFrame5.Text = "Check for Updates";
            this.groupFrame5.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // checkBoxCheckForUpdatesOnStartup
            // 
            this.checkBoxCheckForUpdatesOnStartup.AutoSize = true;
            this.checkBoxCheckForUpdatesOnStartup.Location = new System.Drawing.Point(16, 19);
            this.checkBoxCheckForUpdatesOnStartup.Name = "checkBoxCheckForUpdatesOnStartup";
            this.checkBoxCheckForUpdatesOnStartup.Size = new System.Drawing.Size(169, 17);
            this.checkBoxCheckForUpdatesOnStartup.TabIndex = 0;
            this.checkBoxCheckForUpdatesOnStartup.Text = "Check for updates on startup?";
            this.checkBoxCheckForUpdatesOnStartup.UseVisualStyleBackColor = true;
            // 
            // listViewFieldsAvailable
            // 
            this.listViewFieldsAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewFieldsAvailable.FullRowSelect = true;
            this.listViewFieldsAvailable.GridLines = true;
            this.listViewFieldsAvailable.Location = new System.Drawing.Point(7, 85);
            this.listViewFieldsAvailable.Name = "listViewFieldsAvailable";
            this.listViewFieldsAvailable.Size = new System.Drawing.Size(280, 157);
            this.listViewFieldsAvailable.TabIndex = 21;
            this.listViewFieldsAvailable.UseCompatibleStateImageBehavior = false;
            this.listViewFieldsAvailable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field Name";
            this.columnHeader1.Width = 257;
            // 
            // listViewFieldsSelected
            // 
            this.listViewFieldsSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewFieldsSelected.FullRowSelect = true;
            this.listViewFieldsSelected.GridLines = true;
            this.listViewFieldsSelected.Location = new System.Drawing.Point(374, 85);
            this.listViewFieldsSelected.Name = "listViewFieldsSelected";
            this.listViewFieldsSelected.Size = new System.Drawing.Size(280, 157);
            this.listViewFieldsSelected.TabIndex = 22;
            this.listViewFieldsSelected.UseCompatibleStateImageBehavior = false;
            this.listViewFieldsSelected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Field Name";
            this.columnHeader2.Width = 258;
            // 
            // buttonAddField
            // 
            this.buttonAddField.Location = new System.Drawing.Point(293, 109);
            this.buttonAddField.Name = "buttonAddField";
            this.buttonAddField.Size = new System.Drawing.Size(75, 23);
            this.buttonAddField.TabIndex = 23;
            this.buttonAddField.Text = "Add >>";
            this.buttonAddField.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveField
            // 
            this.buttonRemoveField.Location = new System.Drawing.Point(293, 138);
            this.buttonRemoveField.Name = "buttonRemoveField";
            this.buttonRemoveField.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveField.TabIndex = 24;
            this.buttonRemoveField.Text = "<< Remove";
            this.buttonRemoveField.UseVisualStyleBackColor = true;
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Location = new System.Drawing.Point(293, 167);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 25;
            this.buttonMoveUp.Text = "Move Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Location = new System.Drawing.Point(293, 196);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 26;
            this.buttonMoveDown.Text = "Move Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            // 
            // textBoxSample
            // 
            this.textBoxSample.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSample.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSample.Location = new System.Drawing.Point(7, 248);
            this.textBoxSample.Multiline = true;
            this.textBoxSample.Name = "textBoxSample";
            this.textBoxSample.Size = new System.Drawing.Size(647, 89);
            this.textBoxSample.TabIndex = 27;
            this.textBoxSample.Text = "Filename                   Size                 Date....\r\nABC.dtd                " +
    " 12,3434             01/01/1970 12:20";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 408);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oric Explorer Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.groupFrame1.ResumeLayout(false);
            this.groupFrame4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupFrame2.ResumeLayout(false);
            this.groupFrame2.PerformLayout();
            this.groupFrame3.ResumeLayout(false);
            this.groupFrame3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTapeAndDiskFolders.ResumeLayout(false);
            this.tabPageEmulator.ResumeLayout(false);
            this.tabPageDirListings.ResumeLayout(false);
            this.tabPageDirListings.PerformLayout();
            this.tabPageOther.ResumeLayout(false);
            this.groupFrame5.ResumeLayout(false);
            this.groupFrame5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEmulatorExecutable;
        private System.Windows.Forms.TextBox textBoxEmulatorExecutable;
        private System.Windows.Forms.RadioButton radioButtonDisks;
        private System.Windows.Forms.RadioButton radioButtonTapes;
        private System.Windows.Forms.ListView listViewFolderList;
        private System.Windows.Forms.ColumnHeader columnHeaderFolderType;
        private System.Windows.Forms.ColumnHeader columnHeaderFolderName;
        private System.Windows.Forms.Button buttonRemoveFolder;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonUpdateFolder;
        private System.Windows.Forms.CheckBox checkBoxScanSubfolders;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonDirListingsFolder;
        private System.Windows.Forms.TextBox textBoxDirListingFolder;
        private GroupFrame.GroupFrame groupFrame1;
        private GroupFrame.GroupFrame groupFrame4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBrowseForFolder;
        private System.Windows.Forms.TextBox textBoxSelectedFolder;
        private GroupFrame.GroupFrame groupFrame2;
        private System.Windows.Forms.Label label1;
        private GroupFrame.GroupFrame groupFrame3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTapeAndDiskFolders;
        private System.Windows.Forms.TabPage tabPageEmulator;
        private System.Windows.Forms.TabPage tabPageDirListings;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.CheckBox checkBoxCheckForUpdatesOnStartup;
        private GroupFrame.GroupFrame groupFrame5;
        private System.Windows.Forms.RadioButton radioButtonROMs;
        private System.Windows.Forms.TextBox textBoxSample;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonRemoveField;
        private System.Windows.Forms.Button buttonAddField;
        private System.Windows.Forms.ListView listViewFieldsSelected;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewFieldsAvailable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}