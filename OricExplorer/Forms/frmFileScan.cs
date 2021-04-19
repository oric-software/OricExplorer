namespace OricExplorer.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmFileScan : Form
    {
        enum ScanType { Tape, Disk, ROM, Other };

        readonly frmMainForm parent;

        Boolean cancelScan = false;

        public frmFileScan(frmMainForm mainForm)
        {
            InitializeComponent();

            // Link back to the parent form
            parent = mainForm;
        }

        private void frmFileScan_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            lblVersion.Text = "V" + version.ToString();
            
            // Display Wait cursor in case it takes a while
            Cursor.Current = Cursors.WaitCursor;

            // Scan folders for each file type
            GetListOfFiles(ScanType.Disk);

            if(!cancelScan)
                GetListOfFiles(ScanType.Tape);

            if(!cancelScan)
                GetListOfFiles(ScanType.ROM);

            if(!cancelScan)
                GetListOfFiles(ScanType.Other);

            // Switch back to default cursor
            Cursor.Current = Cursors.Default;

            lblInfo.Text = (cancelScan) ? "Scan cancelled by user" : "Scan completed";
            lblFile.Text = "";
            lblProgress.Text = "";

            Application.DoEvents();

            // Add a pause before closing the form
            System.Threading.Thread.Sleep(1500);
            Close();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel the file scan?", "Cancel Scan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cancelScan = true;
                Close();
            }
        }

        private void GetListOfFiles(ScanType scanType)
        {
            String searchPattern = "";
            int filesScanned = 0;

            List<String> folderList = null;

            switch(scanType)
            {
                case ScanType.Tape:
                    folderList = Configuration.Persistent.TapeFolders;
                    searchPattern = "*.ta?";
                    break;

                case ScanType.Disk:
                    folderList = Configuration.Persistent.DiskFolders;
                    searchPattern = "*.dsk";
                    break;

                case ScanType.ROM:
                    folderList = Configuration.Persistent.RomFolders;
                    searchPattern = "*.rom";
                    break;

                case ScanType.Other:
                    folderList = Configuration.Persistent.OtherFilesFolders;
                    searchPattern = "*.*";
                    break;
            }

            lblInfo.Text = String.Format("Searching folders for {0} files...", scanType.ToString());
            lblFile.Text = "";
            lblProgress.Text = "";

            ctlProgressBar.PercentageValue = 0;

            Application.DoEvents();

            foreach (string directory in folderList)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                if (directoryInfo.Exists)
                {
                    FileInfo[] fileInfoList = directoryInfo.GetFiles(searchPattern, SearchOption.AllDirectories);

                    if (fileInfoList != null)
                    {
                        lblInfo.Text = String.Format("Loading {0} files...", scanType.ToString());
                        Application.DoEvents();

                        foreach (FileInfo fileInfo in fileInfoList)
                        {
                            lblFile.Text = Path.GetFileNameWithoutExtension(fileInfo.FullName);

                            AddFileToTree(scanType, fileInfo, directoryInfo.FullName);

                            filesScanned++;

                            float percentage = (100 / (float)fileInfoList.Length) * filesScanned;
                            ctlProgressBar.PercentageValue = (int)percentage;

                            lblProgress.Text = String.Format("{0:N0} of {1:N0} ({2:N1}%)", filesScanned, fileInfoList.Length, percentage);

                            Application.DoEvents();

                            if (cancelScan)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private TreeNode AddFileToTree(ScanType scanType, FileInfo fileInfo, string fullname)
        {
            TreeNode newNode;

            switch (scanType)
            {
                case ScanType.Disk:
                    newNode = parent.AddDiskToTree(fileInfo, fullname);
                    break;

                case ScanType.Tape:
                    newNode = parent.AddTapeToTree(fileInfo, fullname);
                    break;

                case ScanType.ROM:
                    newNode = parent.AddRomToTree(fileInfo, fullname);
                    break;

                default:
                    newNode = parent.AddOtherFileToTree(fileInfo, fullname);
                    break;
            }

            return newNode;
        }
    }
}