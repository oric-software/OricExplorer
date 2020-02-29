namespace OricExplorer.Forms
{
    using Be.Windows.Forms;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class DiskDataForm : DockContent
    {
        private byte currentSide = 0;
        private byte currentTrack = 0;
        private byte currentSector = 1;

        private int noOfSectors = 0;

        public OricDiskInfo diskInfo;

        public DiskDataForm()
        {
            InitializeComponent();
        }

        public void InitialDisplay()
        {
            hexBoxSectorView.BackColor = hexBoxDiskData.BackColor = Configuration.Persistent.PageBackground;
            hexBoxSectorView.InfoForeColor = hexBoxDiskData.InfoForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush).Color;
            hexBoxSectorView.ForeColor = hexBoxDiskData.ForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush).Color;
            hexBoxSectorView.StringViewColour = hexBoxDiskData.StringViewColour = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush).Color;
            hexBoxSectorView.SelectionBackColor = hexBoxDiskData.SelectionBackColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush).Color;
            hexBoxSectorView.SelectionForeColor = hexBoxDiskData.SelectionForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush).Color;
            hexBoxDiskData.ShadowSelectionColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush).Color;
            hexBoxSectorView.ShadowSelectionColor = hexBoxDiskData.ShadowSelectionColor = Color.FromArgb(100, hexBoxDiskData.ShadowSelectionColor.R, hexBoxDiskData.ShadowSelectionColor.G, hexBoxDiskData.ShadowSelectionColor.B);

            FileStream fs = new FileStream(diskInfo.FullName, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            long numBytes = new FileInfo(diskInfo.FullName).Length;
            byte[] diskData = br.ReadBytes((int)numBytes);

            byte[] signature = new byte[8];
            Array.Copy(diskData, 0, signature, 0, 8);
            infoBoxSignature.Text = Encoding.UTF8.GetString(signature);

            byte[] diskFormat = new byte[4];
            Array.Copy(diskData, 8, diskFormat, 0, 4);
            uint noOfSides = BitConverter.ToUInt32(diskFormat, 0);

            Array.Copy(diskData, 12, diskFormat, 0, 4);
            uint noOfTracks = BitConverter.ToUInt32(diskFormat, 0);

            Array.Copy(diskData, 16, diskFormat, 0, 4);
            uint geometryType = BitConverter.ToUInt32(diskFormat, 0);

            infoBoxNoOfSides.Text = string.Format("{0}", noOfSides);
            infoBoxNoOfTracks.Text = string.Format("{0}", noOfTracks);

            byte[] binaryData = File.ReadAllBytes(diskInfo.FullName);
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(binaryData);

            hexBoxDiskData.ByteProvider = dynamicByteProvider;
            hexBoxDiskData.LineInfoOffset = 0x0000;
            hexBoxDiskData.ReadOnly = true;

            OricDisk oricDisk = new OricDisk();
            oricDisk.LoadDisk(diskInfo.FullName);
            noOfSectors = oricDisk.CalculateNoOfSectors();

            infoBoxSectorsPerTrack.Text = noOfSectors.ToString();

            trackBarTracks.Minimum = 0;
            trackBarTracks.Maximum = (int)(noOfTracks - 1);
            trackBarTracks.Value = 0;

            trackBarSectors.Minimum = 1;
            trackBarSectors.Maximum = noOfSectors;
            trackBarSectors.Value = 1;

            radioButton1.Checked = true;

            if (noOfSides == 1)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }

            UpdateDisplay();
        }

        private void DiskDataForm_Load(object sender, EventArgs e)
        {
            InitialDisplay();

            Text = string.Format("Disk Data Viewer - {0}", Path.GetFileName(diskInfo.FullName));
        }

        private void UpdateDisplay()
        {
            infoBoxInfo.Text = string.Format("Track - {1:X2}, Sector - {2:X2}", currentSide, currentTrack, currentSector);

            // Read current sector
            if (currentSide == 1)
            {
                currentTrack += 0x80;
            }

            byte[] byteArray = diskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(byteArray);

            hexBoxSectorView.ByteProvider = dynamicByteProvider;

            trackBarTracks.Value = currentTrack & 0x7F;
            trackBarSectors.Value = currentSector;

            currentTrack = (byte)trackBarTracks.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentTrack = Convert.ToByte(trackBarTracks.Value);
            UpdateDisplay();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            currentSector = Convert.ToByte(trackBarSectors.Value);
            UpdateDisplay();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            currentSide = 0;
            UpdateDisplay();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            currentSide = 1;
            UpdateDisplay();
        }
    }
}
