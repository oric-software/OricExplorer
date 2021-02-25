namespace OricExplorer
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnUpdateFolder = new System.Windows.Forms.Button();
            this.chkScanSubfolders = new System.Windows.Forms.CheckBox();
            this.optTape = new System.Windows.Forms.RadioButton();
            this.optDisk = new System.Windows.Forms.RadioButton();
            this.lvwFolderList = new System.Windows.Forms.ListView();
            this.colFolderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBrowseForEmulatorExecutable = new System.Windows.Forms.Button();
            this.txtEmulatorExecutable = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowserForDirListingsFolder = new System.Windows.Forms.Button();
            this.txtDirListingFolder = new System.Windows.Forms.TextBox();
            this.grpTapeAndDiskFolders = new GroupFrame.GroupFrame();
            this.grpOptions = new GroupFrame.GroupFrame();
            this.grpFolderDetails = new System.Windows.Forms.GroupBox();
            this.optOtherFiles = new System.Windows.Forms.RadioButton();
            this.optRom = new System.Windows.Forms.RadioButton();
            this.btnBrowseForFolder = new System.Windows.Forms.Button();
            this.txtSelectedFolder = new System.Windows.Forms.TextBox();
            this.grpEmulator = new GroupFrame.GroupFrame();
            this.optDefaultMachinePravetz = new System.Windows.Forms.RadioButton();
            this.optDefaultMachineAtmos = new System.Windows.Forms.RadioButton();
            this.optDefaultMachineOric1 = new System.Windows.Forms.RadioButton();
            this.lblDefaultMachine = new System.Windows.Forms.Label();
            this.lblEmulatorExecutable = new System.Windows.Forms.Label();
            this.grpDirListings = new GroupFrame.GroupFrame();
            this.lblDirListingFolder = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabpTapeAndDiskFolders = new System.Windows.Forms.TabPage();
            this.tabpEmulator = new System.Windows.Forms.TabPage();
            this.tabpDirListings = new System.Windows.Forms.TabPage();
            this.txtSample = new System.Windows.Forms.TextBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.lvwFieldsSelected = new System.Windows.Forms.ListView();
            this.colFieldNameSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwFieldsAvailable = new System.Windows.Forms.ListView();
            this.colFieldNameAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabpOther = new System.Windows.Forms.TabPage();
            this.grpTapeRepresentation = new GroupFrame.GroupFrame();
            this.chkOtherFilesTree = new System.Windows.Forms.CheckBox();
            this.chkROMsTree = new System.Windows.Forms.CheckBox();
            this.chkTapesTree = new System.Windows.Forms.CheckBox();
            this.chkDisksTree = new System.Windows.Forms.CheckBox();
            this.chkTapesIndex = new System.Windows.Forms.CheckBox();
            this.grpUpdates = new GroupFrame.GroupFrame();
            this.chkCheckForUpdatesOnStartup = new System.Windows.Forms.CheckBox();
            this.grpTapeAndDiskFolders.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.grpFolderDetails.SuspendLayout();
            this.grpEmulator.SuspendLayout();
            this.grpDirListings.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabpTapeAndDiskFolders.SuspendLayout();
            this.tabpEmulator.SuspendLayout();
            this.tabpDirListings.SuspendLayout();
            this.tabpOther.SuspendLayout();
            this.grpTapeRepresentation.SuspendLayout();
            this.grpUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(8, 17);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "Add";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(8, 73);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFolder.TabIndex = 2;
            this.btnRemoveFolder.Text = "Remove";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // btnUpdateFolder
            // 
            this.btnUpdateFolder.Location = new System.Drawing.Point(8, 45);
            this.btnUpdateFolder.Name = "btnUpdateFolder";
            this.btnUpdateFolder.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateFolder.TabIndex = 1;
            this.btnUpdateFolder.Text = "Update";
            this.btnUpdateFolder.UseVisualStyleBackColor = true;
            this.btnUpdateFolder.Click += new System.EventHandler(this.btnUpdateFolder_Click);
            // 
            // chkScanSubfolders
            // 
            this.chkScanSubfolders.AutoSize = true;
            this.chkScanSubfolders.Checked = true;
            this.chkScanSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScanSubfolders.ForeColor = System.Drawing.Color.Black;
            this.chkScanSubfolders.Location = new System.Drawing.Point(9, 77);
            this.chkScanSubfolders.Name = "chkScanSubfolders";
            this.chkScanSubfolders.Size = new System.Drawing.Size(108, 17);
            this.chkScanSubfolders.TabIndex = 6;
            this.chkScanSubfolders.Text = "Scan subfolders?";
            this.chkScanSubfolders.UseVisualStyleBackColor = true;
            this.chkScanSubfolders.Visible = false;
            // 
            // optTape
            // 
            this.optTape.AutoSize = true;
            this.optTape.ForeColor = System.Drawing.Color.Black;
            this.optTape.Location = new System.Drawing.Point(119, 19);
            this.optTape.Name = "optTape";
            this.optTape.Size = new System.Drawing.Size(98, 17);
            this.optTape.TabIndex = 1;
            this.optTape.TabStop = true;
            this.optTape.Text = "Tape files (.tap)";
            this.optTape.UseVisualStyleBackColor = true;
            // 
            // optDisk
            // 
            this.optDisk.AutoSize = true;
            this.optDisk.ForeColor = System.Drawing.Color.Black;
            this.optDisk.Location = new System.Drawing.Point(9, 20);
            this.optDisk.Name = "optDisk";
            this.optDisk.Size = new System.Drawing.Size(96, 17);
            this.optDisk.TabIndex = 0;
            this.optDisk.TabStop = true;
            this.optDisk.Text = "Disk files (.dsk)";
            this.optDisk.UseVisualStyleBackColor = true;
            // 
            // lvwFolderList
            // 
            this.lvwFolderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFolderType,
            this.colFolderName});
            this.lvwFolderList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwFolderList.FullRowSelect = true;
            this.lvwFolderList.GridLines = true;
            this.lvwFolderList.HideSelection = false;
            this.lvwFolderList.Location = new System.Drawing.Point(8, 135);
            this.lvwFolderList.Name = "lvwFolderList";
            this.lvwFolderList.Size = new System.Drawing.Size(629, 184);
            this.lvwFolderList.TabIndex = 2;
            this.lvwFolderList.UseCompatibleStateImageBehavior = false;
            this.lvwFolderList.View = System.Windows.Forms.View.Details;
            this.lvwFolderList.SelectedIndexChanged += new System.EventHandler(this.lvwFolderList_SelectedIndexChanged);
            this.lvwFolderList.DoubleClick += new System.EventHandler(this.lvwFolderList_DoubleClick);
            // 
            // colFolderType
            // 
            this.colFolderType.Text = "Media Type";
            this.colFolderType.Width = 82;
            // 
            // colFolderName
            // 
            this.colFolderName.Text = "Folder";
            this.colFolderName.Width = 524;
            // 
            // btnBrowseForEmulatorExecutable
            // 
            this.btnBrowseForEmulatorExecutable.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseForEmulatorExecutable.Location = new System.Drawing.Point(553, 44);
            this.btnBrowseForEmulatorExecutable.Name = "btnBrowseForEmulatorExecutable";
            this.btnBrowseForEmulatorExecutable.Size = new System.Drawing.Size(77, 22);
            this.btnBrowseForEmulatorExecutable.TabIndex = 3;
            this.btnBrowseForEmulatorExecutable.Text = "Browse...";
            this.btnBrowseForEmulatorExecutable.UseVisualStyleBackColor = true;
            this.btnBrowseForEmulatorExecutable.Click += new System.EventHandler(this.btnBrowseForEmulatorExecutable_Click);
            // 
            // txtEmulatorExecutable
            // 
            this.txtEmulatorExecutable.ForeColor = System.Drawing.Color.Black;
            this.txtEmulatorExecutable.Location = new System.Drawing.Point(9, 45);
            this.txtEmulatorExecutable.Name = "txtEmulatorExecutable";
            this.txtEmulatorExecutable.Size = new System.Drawing.Size(538, 20);
            this.txtEmulatorExecutable.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(504, 378);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(587, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowserForDirListingsFolder
            // 
            this.btnBrowserForDirListingsFolder.ForeColor = System.Drawing.Color.Black;
            this.btnBrowserForDirListingsFolder.Location = new System.Drawing.Point(553, 44);
            this.btnBrowserForDirListingsFolder.Name = "btnBrowserForDirListingsFolder";
            this.btnBrowserForDirListingsFolder.Size = new System.Drawing.Size(77, 22);
            this.btnBrowserForDirListingsFolder.TabIndex = 3;
            this.btnBrowserForDirListingsFolder.Text = "Browse...";
            this.btnBrowserForDirListingsFolder.UseVisualStyleBackColor = true;
            this.btnBrowserForDirListingsFolder.Click += new System.EventHandler(this.btnBrowserForDirListingsFolder_Click);
            // 
            // txtDirListingFolder
            // 
            this.txtDirListingFolder.ForeColor = System.Drawing.Color.Black;
            this.txtDirListingFolder.Location = new System.Drawing.Point(9, 45);
            this.txtDirListingFolder.Name = "txtDirListingFolder";
            this.txtDirListingFolder.Size = new System.Drawing.Size(538, 20);
            this.txtDirListingFolder.TabIndex = 2;
            // 
            // grpTapeAndDiskFolders
            // 
            this.grpTapeAndDiskFolders.Controls.Add(this.grpOptions);
            this.grpTapeAndDiskFolders.Controls.Add(this.grpFolderDetails);
            this.grpTapeAndDiskFolders.Controls.Add(this.lvwFolderList);
            this.grpTapeAndDiskFolders.ForeColor = System.Drawing.Color.Black;
            this.grpTapeAndDiskFolders.Location = new System.Drawing.Point(7, 6);
            this.grpTapeAndDiskFolders.Name = "grpTapeAndDiskFolders";
            this.grpTapeAndDiskFolders.Size = new System.Drawing.Size(647, 328);
            this.grpTapeAndDiskFolders.TabIndex = 0;
            this.grpTapeAndDiskFolders.TabStop = false;
            this.grpTapeAndDiskFolders.Text = "Disk and Tape Folders";
            this.grpTapeAndDiskFolders.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.btnAddFolder);
            this.grpOptions.Controls.Add(this.btnUpdateFolder);
            this.grpOptions.Controls.Add(this.btnRemoveFolder);
            this.grpOptions.Location = new System.Drawing.Point(547, 19);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(90, 110);
            this.grpOptions.TabIndex = 1;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            this.grpOptions.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // grpFolderDetails
            // 
            this.grpFolderDetails.Controls.Add(this.optOtherFiles);
            this.grpFolderDetails.Controls.Add(this.optRom);
            this.grpFolderDetails.Controls.Add(this.btnBrowseForFolder);
            this.grpFolderDetails.Controls.Add(this.txtSelectedFolder);
            this.grpFolderDetails.Controls.Add(this.optTape);
            this.grpFolderDetails.Controls.Add(this.chkScanSubfolders);
            this.grpFolderDetails.Controls.Add(this.optDisk);
            this.grpFolderDetails.Location = new System.Drawing.Point(8, 19);
            this.grpFolderDetails.Name = "grpFolderDetails";
            this.grpFolderDetails.Size = new System.Drawing.Size(533, 110);
            this.grpFolderDetails.TabIndex = 0;
            this.grpFolderDetails.TabStop = false;
            this.grpFolderDetails.Text = "Folder Details";
            // 
            // optOtherFiles
            // 
            this.optOtherFiles.AutoSize = true;
            this.optOtherFiles.ForeColor = System.Drawing.Color.Black;
            this.optOtherFiles.Location = new System.Drawing.Point(345, 19);
            this.optOtherFiles.Name = "optOtherFiles";
            this.optOtherFiles.Size = new System.Drawing.Size(72, 17);
            this.optOtherFiles.TabIndex = 3;
            this.optOtherFiles.TabStop = true;
            this.optOtherFiles.Text = "Other files";
            this.optOtherFiles.UseVisualStyleBackColor = true;
            // 
            // optRom
            // 
            this.optRom.AutoSize = true;
            this.optRom.ForeColor = System.Drawing.Color.Black;
            this.optRom.Location = new System.Drawing.Point(231, 19);
            this.optRom.Name = "optRom";
            this.optRom.Size = new System.Drawing.Size(100, 17);
            this.optRom.TabIndex = 2;
            this.optRom.TabStop = true;
            this.optRom.Text = "ROM files (.rom)";
            this.optRom.UseVisualStyleBackColor = true;
            // 
            // btnBrowseForFolder
            // 
            this.btnBrowseForFolder.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseForFolder.Location = new System.Drawing.Point(445, 75);
            this.btnBrowseForFolder.Name = "btnBrowseForFolder";
            this.btnBrowseForFolder.Size = new System.Drawing.Size(77, 22);
            this.btnBrowseForFolder.TabIndex = 5;
            this.btnBrowseForFolder.Text = "Browse...";
            this.btnBrowseForFolder.UseVisualStyleBackColor = true;
            this.btnBrowseForFolder.Click += new System.EventHandler(this.btnBrowseForFolder_Click);
            // 
            // txtSelectedFolder
            // 
            this.txtSelectedFolder.ForeColor = System.Drawing.Color.Black;
            this.txtSelectedFolder.Location = new System.Drawing.Point(9, 47);
            this.txtSelectedFolder.Name = "txtSelectedFolder";
            this.txtSelectedFolder.Size = new System.Drawing.Size(513, 20);
            this.txtSelectedFolder.TabIndex = 4;
            this.txtSelectedFolder.TextChanged += new System.EventHandler(this.txtSelectedFolder_TextChanged);
            // 
            // grpEmulator
            // 
            this.grpEmulator.Controls.Add(this.optDefaultMachinePravetz);
            this.grpEmulator.Controls.Add(this.optDefaultMachineAtmos);
            this.grpEmulator.Controls.Add(this.optDefaultMachineOric1);
            this.grpEmulator.Controls.Add(this.lblDefaultMachine);
            this.grpEmulator.Controls.Add(this.lblEmulatorExecutable);
            this.grpEmulator.Controls.Add(this.txtEmulatorExecutable);
            this.grpEmulator.Controls.Add(this.btnBrowseForEmulatorExecutable);
            this.grpEmulator.ForeColor = System.Drawing.Color.Black;
            this.grpEmulator.Location = new System.Drawing.Point(7, 6);
            this.grpEmulator.Name = "grpEmulator";
            this.grpEmulator.Size = new System.Drawing.Size(647, 136);
            this.grpEmulator.TabIndex = 0;
            this.grpEmulator.TabStop = false;
            this.grpEmulator.Text = "Emulator";
            this.grpEmulator.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // optDefaultMachinePravetz
            // 
            this.optDefaultMachinePravetz.AutoSize = true;
            this.optDefaultMachinePravetz.Location = new System.Drawing.Point(9, 105);
            this.optDefaultMachinePravetz.Name = "optDefaultMachinePravetz";
            this.optDefaultMachinePravetz.Size = new System.Drawing.Size(61, 17);
            this.optDefaultMachinePravetz.TabIndex = 5;
            this.optDefaultMachinePravetz.Text = "Pravetz";
            this.optDefaultMachinePravetz.UseVisualStyleBackColor = true;
            // 
            // optDefaultMachineAtmos
            // 
            this.optDefaultMachineAtmos.AutoSize = true;
            this.optDefaultMachineAtmos.Checked = true;
            this.optDefaultMachineAtmos.Location = new System.Drawing.Point(167, 105);
            this.optDefaultMachineAtmos.Name = "optDefaultMachineAtmos";
            this.optDefaultMachineAtmos.Size = new System.Drawing.Size(76, 17);
            this.optDefaultMachineAtmos.TabIndex = 7;
            this.optDefaultMachineAtmos.TabStop = true;
            this.optDefaultMachineAtmos.Text = "Oric Atmos";
            this.optDefaultMachineAtmos.UseVisualStyleBackColor = true;
            // 
            // optDefaultMachineOric1
            // 
            this.optDefaultMachineOric1.AutoSize = true;
            this.optDefaultMachineOric1.Location = new System.Drawing.Point(92, 105);
            this.optDefaultMachineOric1.Name = "optDefaultMachineOric1";
            this.optDefaultMachineOric1.Size = new System.Drawing.Size(53, 17);
            this.optDefaultMachineOric1.TabIndex = 6;
            this.optDefaultMachineOric1.Text = "Oric-1";
            this.optDefaultMachineOric1.UseVisualStyleBackColor = true;
            // 
            // lblDefaultMachine
            // 
            this.lblDefaultMachine.AutoSize = true;
            this.lblDefaultMachine.ForeColor = System.Drawing.Color.Black;
            this.lblDefaultMachine.Location = new System.Drawing.Point(6, 89);
            this.lblDefaultMachine.Name = "lblDefaultMachine";
            this.lblDefaultMachine.Size = new System.Drawing.Size(335, 13);
            this.lblDefaultMachine.TabIndex = 4;
            this.lblDefaultMachine.Text = "Default machine emulator for tapes (when launched with double-click)";
            // 
            // lblEmulatorExecutable
            // 
            this.lblEmulatorExecutable.AutoSize = true;
            this.lblEmulatorExecutable.ForeColor = System.Drawing.Color.Black;
            this.lblEmulatorExecutable.Location = new System.Drawing.Point(6, 28);
            this.lblEmulatorExecutable.Name = "lblEmulatorExecutable";
            this.lblEmulatorExecutable.Size = new System.Drawing.Size(532, 13);
            this.lblEmulatorExecutable.TabIndex = 1;
            this.lblEmulatorExecutable.Text = "Please specify the folder and name of the Emulator executable file eg. C:\\Program" +
    " Files\\Oricutron\\Oricutron.exe\r\n";
            // 
            // grpDirListings
            // 
            this.grpDirListings.Controls.Add(this.lblDirListingFolder);
            this.grpDirListings.Controls.Add(this.txtDirListingFolder);
            this.grpDirListings.Controls.Add(this.btnBrowserForDirListingsFolder);
            this.grpDirListings.ForeColor = System.Drawing.Color.Black;
            this.grpDirListings.Location = new System.Drawing.Point(7, 6);
            this.grpDirListings.Name = "grpDirListings";
            this.grpDirListings.Size = new System.Drawing.Size(647, 76);
            this.grpDirListings.TabIndex = 0;
            this.grpDirListings.TabStop = false;
            this.grpDirListings.Text = "Directory Listings";
            this.grpDirListings.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblDirListingFolder
            // 
            this.lblDirListingFolder.AutoSize = true;
            this.lblDirListingFolder.ForeColor = System.Drawing.Color.Black;
            this.lblDirListingFolder.Location = new System.Drawing.Point(6, 28);
            this.lblDirListingFolder.Name = "lblDirListingFolder";
            this.lblDirListingFolder.Size = new System.Drawing.Size(627, 13);
            this.lblDirListingFolder.TabIndex = 1;
            this.lblDirListingFolder.Text = "Please specify the folder where Disk and Tape directory listings will be output t" +
    "o. If not specified, the OricExplorer folder will be used.";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabpTapeAndDiskFolders);
            this.tabSettings.Controls.Add(this.tabpEmulator);
            this.tabSettings.Controls.Add(this.tabpDirListings);
            this.tabSettings.Controls.Add(this.tabpOther);
            this.tabSettings.Location = new System.Drawing.Point(5, 6);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(669, 366);
            this.tabSettings.TabIndex = 0;
            // 
            // tabpTapeAndDiskFolders
            // 
            this.tabpTapeAndDiskFolders.Controls.Add(this.grpTapeAndDiskFolders);
            this.tabpTapeAndDiskFolders.Location = new System.Drawing.Point(4, 22);
            this.tabpTapeAndDiskFolders.Name = "tabpTapeAndDiskFolders";
            this.tabpTapeAndDiskFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tabpTapeAndDiskFolders.Size = new System.Drawing.Size(661, 340);
            this.tabpTapeAndDiskFolders.TabIndex = 0;
            this.tabpTapeAndDiskFolders.Text = "Tape and Disk Folders";
            this.tabpTapeAndDiskFolders.UseVisualStyleBackColor = true;
            // 
            // tabpEmulator
            // 
            this.tabpEmulator.Controls.Add(this.grpEmulator);
            this.tabpEmulator.Location = new System.Drawing.Point(4, 22);
            this.tabpEmulator.Name = "tabpEmulator";
            this.tabpEmulator.Padding = new System.Windows.Forms.Padding(3);
            this.tabpEmulator.Size = new System.Drawing.Size(661, 340);
            this.tabpEmulator.TabIndex = 1;
            this.tabpEmulator.Text = "Emulator";
            this.tabpEmulator.UseVisualStyleBackColor = true;
            // 
            // tabpDirListings
            // 
            this.tabpDirListings.Controls.Add(this.txtSample);
            this.tabpDirListings.Controls.Add(this.btnMoveDown);
            this.tabpDirListings.Controls.Add(this.btnMoveUp);
            this.tabpDirListings.Controls.Add(this.btnRemoveField);
            this.tabpDirListings.Controls.Add(this.btnAddField);
            this.tabpDirListings.Controls.Add(this.lvwFieldsSelected);
            this.tabpDirListings.Controls.Add(this.lvwFieldsAvailable);
            this.tabpDirListings.Controls.Add(this.grpDirListings);
            this.tabpDirListings.Location = new System.Drawing.Point(4, 22);
            this.tabpDirListings.Name = "tabpDirListings";
            this.tabpDirListings.Size = new System.Drawing.Size(661, 340);
            this.tabpDirListings.TabIndex = 2;
            this.tabpDirListings.Text = "Directory Listings";
            this.tabpDirListings.UseVisualStyleBackColor = true;
            // 
            // txtSample
            // 
            this.txtSample.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSample.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSample.Location = new System.Drawing.Point(7, 248);
            this.txtSample.Multiline = true;
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(647, 89);
            this.txtSample.TabIndex = 7;
            this.txtSample.Text = "Filename                   Size                 Date....\r\nABC.dtd                " +
    " 12,3434             01/01/1970 12:20";
            this.txtSample.Visible = false;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(293, 196);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Visible = false;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(293, 167);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Visible = false;
            // 
            // btnRemoveField
            // 
            this.btnRemoveField.Location = new System.Drawing.Point(293, 138);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveField.TabIndex = 3;
            this.btnRemoveField.Text = "<< Remove";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            this.btnRemoveField.Visible = false;
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(293, 109);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(75, 23);
            this.btnAddField.TabIndex = 2;
            this.btnAddField.Text = "Add >>";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Visible = false;
            // 
            // lvwFieldsSelected
            // 
            this.lvwFieldsSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFieldNameSelected});
            this.lvwFieldsSelected.FullRowSelect = true;
            this.lvwFieldsSelected.GridLines = true;
            this.lvwFieldsSelected.HideSelection = false;
            this.lvwFieldsSelected.Location = new System.Drawing.Point(374, 88);
            this.lvwFieldsSelected.Name = "lvwFieldsSelected";
            this.lvwFieldsSelected.Size = new System.Drawing.Size(280, 154);
            this.lvwFieldsSelected.TabIndex = 6;
            this.lvwFieldsSelected.UseCompatibleStateImageBehavior = false;
            this.lvwFieldsSelected.View = System.Windows.Forms.View.Details;
            this.lvwFieldsSelected.Visible = false;
            // 
            // colFieldNameSelected
            // 
            this.colFieldNameSelected.Text = "Field Name";
            this.colFieldNameSelected.Width = 258;
            // 
            // lvwFieldsAvailable
            // 
            this.lvwFieldsAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFieldNameAvailable});
            this.lvwFieldsAvailable.FullRowSelect = true;
            this.lvwFieldsAvailable.GridLines = true;
            this.lvwFieldsAvailable.HideSelection = false;
            this.lvwFieldsAvailable.Location = new System.Drawing.Point(7, 88);
            this.lvwFieldsAvailable.Name = "lvwFieldsAvailable";
            this.lvwFieldsAvailable.Size = new System.Drawing.Size(280, 154);
            this.lvwFieldsAvailable.TabIndex = 1;
            this.lvwFieldsAvailable.UseCompatibleStateImageBehavior = false;
            this.lvwFieldsAvailable.View = System.Windows.Forms.View.Details;
            this.lvwFieldsAvailable.Visible = false;
            // 
            // colFieldNameAvailable
            // 
            this.colFieldNameAvailable.Text = "Field Name";
            this.colFieldNameAvailable.Width = 257;
            // 
            // tabpOther
            // 
            this.tabpOther.Controls.Add(this.grpTapeRepresentation);
            this.tabpOther.Controls.Add(this.grpUpdates);
            this.tabpOther.Location = new System.Drawing.Point(4, 22);
            this.tabpOther.Name = "tabpOther";
            this.tabpOther.Size = new System.Drawing.Size(661, 340);
            this.tabpOther.TabIndex = 3;
            this.tabpOther.Text = "Other Settings";
            this.tabpOther.UseVisualStyleBackColor = true;
            // 
            // grpTapeRepresentation
            // 
            this.grpTapeRepresentation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTapeRepresentation.Controls.Add(this.chkOtherFilesTree);
            this.grpTapeRepresentation.Controls.Add(this.chkROMsTree);
            this.grpTapeRepresentation.Controls.Add(this.chkTapesTree);
            this.grpTapeRepresentation.Controls.Add(this.chkDisksTree);
            this.grpTapeRepresentation.Controls.Add(this.chkTapesIndex);
            this.grpTapeRepresentation.Location = new System.Drawing.Point(7, 59);
            this.grpTapeRepresentation.Name = "grpTapeRepresentation";
            this.grpTapeRepresentation.Size = new System.Drawing.Size(648, 168);
            this.grpTapeRepresentation.TabIndex = 1;
            this.grpTapeRepresentation.TabStop = false;
            this.grpTapeRepresentation.Text = "Files list representation (changes require rescan to take effect)";
            this.grpTapeRepresentation.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // chkOtherFilesTree
            // 
            this.chkOtherFilesTree.AutoSize = true;
            this.chkOtherFilesTree.Location = new System.Drawing.Point(16, 141);
            this.chkOtherFilesTree.Name = "chkOtherFilesTree";
            this.chkOtherFilesTree.Size = new System.Drawing.Size(340, 17);
            this.chkOtherFilesTree.TabIndex = 4;
            this.chkOtherFilesTree.Text = "View other files as in the initial tree structure instead of the flat view";
            this.chkOtherFilesTree.UseVisualStyleBackColor = true;
            // 
            // chkROMsTree
            // 
            this.chkROMsTree.AutoSize = true;
            this.chkROMsTree.Location = new System.Drawing.Point(16, 110);
            this.chkROMsTree.Name = "chkROMsTree";
            this.chkROMsTree.Size = new System.Drawing.Size(325, 17);
            this.chkROMsTree.TabIndex = 3;
            this.chkROMsTree.Text = "View ROMs as in the initial tree structure instead of the flat view";
            this.chkROMsTree.UseVisualStyleBackColor = true;
            // 
            // chkTapesTree
            // 
            this.chkTapesTree.AutoSize = true;
            this.chkTapesTree.Location = new System.Drawing.Point(16, 77);
            this.chkTapesTree.Name = "chkTapesTree";
            this.chkTapesTree.Size = new System.Drawing.Size(321, 17);
            this.chkTapesTree.TabIndex = 2;
            this.chkTapesTree.Text = "View tapes as in the initial tree structure instead of the flat view";
            this.chkTapesTree.UseVisualStyleBackColor = true;
            this.chkTapesTree.CheckedChanged += new System.EventHandler(this.chkTapesTree_CheckedChanged);
            // 
            // chkDisksTree
            // 
            this.chkDisksTree.AutoSize = true;
            this.chkDisksTree.Location = new System.Drawing.Point(16, 25);
            this.chkDisksTree.Name = "chkDisksTree";
            this.chkDisksTree.Size = new System.Drawing.Size(405, 17);
            this.chkDisksTree.TabIndex = 0;
            this.chkDisksTree.Text = "View disks as in the initial tree structure instead of the organization by disk f" +
    "ormat";
            this.chkDisksTree.UseVisualStyleBackColor = true;
            // 
            // chkTapesIndex
            // 
            this.chkTapesIndex.AutoSize = true;
            this.chkTapesIndex.Location = new System.Drawing.Point(16, 54);
            this.chkTapesIndex.Name = "chkTapesIndex";
            this.chkTapesIndex.Size = new System.Drawing.Size(132, 17);
            this.chkTapesIndex.TabIndex = 1;
            this.chkTapesIndex.Text = "View tapes in an index";
            this.chkTapesIndex.UseVisualStyleBackColor = true;
            this.chkTapesIndex.CheckedChanged += new System.EventHandler(this.chkTapesIndex_CheckedChanged);
            // 
            // grpUpdates
            // 
            this.grpUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUpdates.Controls.Add(this.chkCheckForUpdatesOnStartup);
            this.grpUpdates.Location = new System.Drawing.Point(7, 6);
            this.grpUpdates.Name = "grpUpdates";
            this.grpUpdates.Size = new System.Drawing.Size(648, 47);
            this.grpUpdates.TabIndex = 0;
            this.grpUpdates.TabStop = false;
            this.grpUpdates.Text = "Updates";
            this.grpUpdates.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // chkCheckForUpdatesOnStartup
            // 
            this.chkCheckForUpdatesOnStartup.AutoSize = true;
            this.chkCheckForUpdatesOnStartup.Location = new System.Drawing.Point(16, 19);
            this.chkCheckForUpdatesOnStartup.Name = "chkCheckForUpdatesOnStartup";
            this.chkCheckForUpdatesOnStartup.Size = new System.Drawing.Size(163, 17);
            this.chkCheckForUpdatesOnStartup.TabIndex = 0;
            this.chkCheckForUpdatesOnStartup.Text = "Check for updates on startup";
            this.chkCheckForUpdatesOnStartup.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(679, 408);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oric Explorer Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpTapeAndDiskFolders.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpFolderDetails.ResumeLayout(false);
            this.grpFolderDetails.PerformLayout();
            this.grpEmulator.ResumeLayout(false);
            this.grpEmulator.PerformLayout();
            this.grpDirListings.ResumeLayout(false);
            this.grpDirListings.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabpTapeAndDiskFolders.ResumeLayout(false);
            this.tabpEmulator.ResumeLayout(false);
            this.tabpDirListings.ResumeLayout(false);
            this.tabpDirListings.PerformLayout();
            this.tabpOther.ResumeLayout(false);
            this.grpTapeRepresentation.ResumeLayout(false);
            this.grpTapeRepresentation.PerformLayout();
            this.grpUpdates.ResumeLayout(false);
            this.grpUpdates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowseForEmulatorExecutable;
        private System.Windows.Forms.TextBox txtEmulatorExecutable;
        private System.Windows.Forms.RadioButton optDisk;
        private System.Windows.Forms.RadioButton optTape;
        private System.Windows.Forms.ListView lvwFolderList;
        private System.Windows.Forms.ColumnHeader colFolderType;
        private System.Windows.Forms.ColumnHeader colFolderName;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnUpdateFolder;
        private System.Windows.Forms.CheckBox chkScanSubfolders;
        private System.Windows.Forms.Button btnBrowserForDirListingsFolder;
        private System.Windows.Forms.TextBox txtDirListingFolder;
        private GroupFrame.GroupFrame grpTapeAndDiskFolders;
        private GroupFrame.GroupFrame grpOptions;
        private System.Windows.Forms.GroupBox grpFolderDetails;
        private System.Windows.Forms.Button btnBrowseForFolder;
        private System.Windows.Forms.TextBox txtSelectedFolder;
        private GroupFrame.GroupFrame grpEmulator;
        private System.Windows.Forms.Label lblEmulatorExecutable;
        private GroupFrame.GroupFrame grpDirListings;
        private System.Windows.Forms.Label lblDirListingFolder;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabpTapeAndDiskFolders;
        private System.Windows.Forms.TabPage tabpEmulator;
        private System.Windows.Forms.TabPage tabpDirListings;
        private System.Windows.Forms.TabPage tabpOther;
        private System.Windows.Forms.CheckBox chkCheckForUpdatesOnStartup;
        private GroupFrame.GroupFrame grpUpdates;
        private System.Windows.Forms.RadioButton optRom;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnRemoveField;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.ListView lvwFieldsSelected;
        private System.Windows.Forms.ColumnHeader colFieldNameSelected;
        private System.Windows.Forms.ListView lvwFieldsAvailable;
        private System.Windows.Forms.ColumnHeader colFieldNameAvailable;
        private System.Windows.Forms.RadioButton optDefaultMachineAtmos;
        private System.Windows.Forms.RadioButton optDefaultMachineOric1;
        private System.Windows.Forms.Label lblDefaultMachine;
        private GroupFrame.GroupFrame grpTapeRepresentation;
        private System.Windows.Forms.CheckBox chkTapesIndex;
        private System.Windows.Forms.RadioButton optDefaultMachinePravetz;
        private System.Windows.Forms.RadioButton optOtherFiles;
        private System.Windows.Forms.CheckBox chkDisksTree;
        private System.Windows.Forms.CheckBox chkOtherFilesTree;
        private System.Windows.Forms.CheckBox chkROMsTree;
        private System.Windows.Forms.CheckBox chkTapesTree;
    }
}