namespace OricExplorer.Forms
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class FileScanForm : Form
    {
        private MainForm parent;

        private ushort filesScanned;
        private ushort filesSkipped;

        private ushort tapesFound;
        private ushort tapesSkipped;

        private ushort disksFound;
        private ushort disksSkipped;

        private ushort romsFound;
        private ushort romsSkipped;

        //private Configuration configuration;

        public FileScanForm(MainForm mainForm)
        {
            InitializeComponent();

            this.Text = mainForm.Text;

            // Link back to the parent form
            parent = mainForm;
        }

        private void FileScanForm_Shown(object sender, EventArgs e)
        {
            // Display Wait cursor in case it takes a while
            Cursor.Current = Cursors.WaitCursor;

            // Initialise the counters
            filesScanned = 0;
            filesSkipped = 0;

            tapesFound = 0;
            tapesSkipped = 0;

            disksFound = 0;
            disksSkipped = 0;

            romsFound = 0;
            romsSkipped = 0;

            GetListOfTapes();
            GetListOfDisks();
            GetListOfROMs();

            // Switch back to default cursor
            Cursor.Current = Cursors.Default;

            percentageBarProgress.Text = "Finished";
            labelMain.Text = "Scan Completed";
            labelStatus.Text = "";
            labelFile.Text = "";

            Application.DoEvents();

            // Add a pause before closing the form
            System.Threading.Thread.Sleep(1500);
            Close();
        }

        public void GetListOfTapes()
        {
            filesScanned = 0;

            foreach (string directory in Configuration.Persistent.TapeFolders)
            {
                DirectoryInfo tapeDirectoryInfo = new DirectoryInfo(directory);

                // Get list of Tape files
                if (tapeDirectoryInfo.Exists)
                {
                    FileInfo[] tapeFileInfo = tapeDirectoryInfo.GetFiles("*.ta*", SearchOption.AllDirectories);

                    if (tapeFileInfo != null)
                    {
                        foreach (FileInfo fileInfo in tapeFileInfo)
                        {
                            labelStatus.Text = "Scanning folders for Tape files...";
                            labelFile.Text = fileInfo.FullName;

                            // Add the tape to the tree
                            if (parent.AddTapeToTree(fileInfo) != null)
                            {
                                tapesFound++;
                            }
                            else
                            {
                                filesSkipped++;
                                tapesSkipped++;
                            }

                            filesScanned++;

                            float percentage = (100 / (float)tapeFileInfo.Length) * filesScanned;
                            percentageBarProgress.PercentageValue = (int)percentage;
                            percentageBarProgress.Text = string.Format("Processing {0:N0} of {1:N0}", filesScanned, tapeFileInfo.Length);

                            Application.DoEvents();
                        }
                    }
                }
            }
        }

        public void GetListOfDisks()
        {
            filesScanned = 0;

            foreach (string directory in Configuration.Persistent.DiskFolders)
            {
                DirectoryInfo diskDirectoryInfo = new DirectoryInfo(directory);

                // Get list of Disk files
                if (diskDirectoryInfo.Exists)
                {
                    FileInfo[] diskFileInfo = diskDirectoryInfo.GetFiles("*.dsk", SearchOption.AllDirectories);

                    if (diskFileInfo != null)
                    {
                        foreach (FileInfo fileInfo in diskFileInfo)
                        {
                            labelStatus.Text = "Scanning folders for Disk files...";
                            labelFile.Text = fileInfo.FullName;

                            // Add the disk to the tree
                            if (parent.AddDiskToTree(fileInfo) != null)
                            {
                                disksFound++;
                            }
                            else
                            {
                                filesSkipped++;
                                disksSkipped++;
                            }

                            filesScanned++;

                            float percentage = (100 / (float)diskFileInfo.Length) * filesScanned;
                            percentageBarProgress.PercentageValue = (int)percentage;
                            percentageBarProgress.Text = string.Format("Processing {0:N0} of {1:N0}", filesScanned, diskFileInfo.Length);

                            Application.DoEvents();
                        }
                    }
                }
            }
        }

        public void GetListOfROMs()
        {
            filesScanned = 0;

            foreach (string directory in Configuration.Persistent.RomFolders)
            {
                DirectoryInfo romDirectoryInfo = new DirectoryInfo(directory);

                // Get list of Disk files
                if (romDirectoryInfo.Exists)
                {
                    FileInfo[] romFileInfo = romDirectoryInfo.GetFiles("*.rom", SearchOption.AllDirectories);

                    if (romFileInfo != null)
                    {
                        foreach (FileInfo fileInfo in romFileInfo)
                        {
                            labelStatus.Text = "Scanning folders for ROM files...";
                            labelFile.Text = fileInfo.FullName;

                            // Add the disk to the tree
                            if (parent.AddROMToTree(fileInfo) != null)
                            {
                                romsFound++;
                            }
                            else
                            {
                                filesSkipped++;
                                romsSkipped++;
                            }

                            filesScanned++;

                            float percentage = (100 / (float)romFileInfo.Length) * filesScanned;
                            percentageBarProgress.PercentageValue = (int)percentage;
                            percentageBarProgress.Text = string.Format("Processing {0:N0} of {1:N0}", filesScanned, romFileInfo.Length);

                            Application.DoEvents();
                        }
                    }
                }
            }
        }
    }
}