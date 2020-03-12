namespace OricExplorer.Forms
{
    using Be.Windows.Forms;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class frmDiskData : DockContent
    {
        private byte currentSide = 0;
        private byte currentTrack = 0;
        private byte currentSector = 1;

        public OricDiskInfo DiskInfo { get; set; }

        public frmDiskData()
        {
            InitializeComponent();
        }

        public void InitialDisplay()
        {
            hxbSectorView.BackColor = hxbDiskData.BackColor = Configuration.Persistent.PageBackground;
            hxbSectorView.InfoForeColor = hxbDiskData.InfoForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHeadersStyle].ForeBrush).Color;
            hxbSectorView.ForeColor = hxbDiskData.ForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpHexStyle].ForeBrush).Color;
            hxbSectorView.StringViewColour = hxbDiskData.StringViewColour = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpAsciiStyle].ForeBrush).Color;
            hxbSectorView.SelectionBackColor = hxbDiskData.SelectionBackColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionBackStyle].ForeBrush).Color;
            hxbSectorView.SelectionForeColor = hxbDiskData.SelectionForeColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpMainSelectionFrontStyle].ForeBrush).Color;
            hxbDiskData.ShadowSelectionColor = ((SolidBrush)Configuration.Persistent.SyntaxHighlightingStyles[ConstantsAndEnums.SyntaxHighlightingItems.DumpSecondarySelectionBackStyle].ForeBrush).Color;
            hxbSectorView.ShadowSelectionColor = hxbDiskData.ShadowSelectionColor = Color.FromArgb(100, hxbDiskData.ShadowSelectionColor.R, hxbDiskData.ShadowSelectionColor.G, hxbDiskData.ShadowSelectionColor.B);

            FileStream fs = new FileStream(DiskInfo.FullName, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            long numBytes = new FileInfo(DiskInfo.FullName).Length;
            byte[] diskData = br.ReadBytes((int)numBytes);

            byte[] signature = new byte[8];
            Array.Copy(diskData, 0, signature, 0, 8);
            ibxSignature.Text = Encoding.UTF8.GetString(signature);

            byte[] diskFormat = new byte[4];
            Array.Copy(diskData, 8, diskFormat, 0, 4);
            uint noOfSides = BitConverter.ToUInt32(diskFormat, 0);

            uint noOfTracks = 0;
            uint noOfSectors = 0;

            if (noOfSides > 0 && noOfSides < 3)
            {
                Array.Copy(diskData, 12, diskFormat, 0, 4);
                noOfTracks = BitConverter.ToUInt32(diskFormat, 0);

                Array.Copy(diskData, 16, diskFormat, 0, 4);
                uint geometryType = BitConverter.ToUInt32(diskFormat, 0);

                OricDisk oricDisk = new OricDisk();
                oricDisk.LoadDisk(DiskInfo.FullName);
                noOfSectors = (uint)oricDisk.CalculateNoOfSectors();
            }
            else
            {
                noOfSides = 0;
            }

            ibxNoOfSides.Text = string.Format("{0}", noOfSides);
            ibxNoOfTracks.Text = string.Format("{0}", noOfTracks);
            ibxSectorsPerTrack.Text = noOfSectors.ToString();

            tkbTracks.Minimum = 0;
            tkbTracks.Maximum = (noOfTracks == 0 ? 1 : (int)noOfTracks - 1);
            tkbTracks.Value = 0;

            tkbSectors.Minimum = (noOfSectors == 0 ? 0 : 1);
            tkbSectors.Maximum = Math.Max(1, (int)noOfSectors);
            tkbSectors.Value = (noOfSectors == 0 ? 0 : 1);

            optSide0.Enabled = optSide1.Enabled = tkbTracks.Enabled = tkbSectors.Enabled = (noOfTracks > 0 && noOfSectors > 0);

            optSide0.Checked = true;
            if (noOfSides == 1)
            {
                optSide0.Enabled = false;
                optSide1.Enabled = false;
            }

            byte[] binaryData = File.ReadAllBytes(DiskInfo.FullName);
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(binaryData);

            hxbDiskData.ByteProvider = dynamicByteProvider;
            hxbDiskData.LineInfoOffset = 0x0000;
            hxbDiskData.ReadOnly = true;

            UpdateDisplay();
        }

        private void frmDiskData_Load(object sender, EventArgs e)
        {
            InitialDisplay();

            Text = string.Format("Disk Data Viewer - {0}", Path.GetFileName(DiskInfo.FullName));
        }

        private void UpdateDisplay()
        {
            if (!tkbSectors.Enabled) return;

            ibxInfo.Text = string.Format("Track - {1:X2}, Sector - {2:X2}", currentSide, currentTrack, currentSector);

            // Read current sector
            if (currentSide == 1)
            {
                currentTrack += 0x80;
            }

            byte[] byteArray = DiskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(byteArray);

            hxbSectorView.ByteProvider = dynamicByteProvider;

            tkbTracks.Value = currentTrack & 0x7F;
            tkbSectors.Value = currentSector;

            currentTrack = (byte)tkbTracks.Value;
        }

        private void tkbTracks_Scroll(object sender, EventArgs e)
        {
            currentTrack = Convert.ToByte(tkbTracks.Value);
            UpdateDisplay();
        }

        private void tkbSectors_Scroll(object sender, EventArgs e)
        {
            currentSector = Convert.ToByte(tkbSectors.Value);
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void optSide0_CheckedChanged(object sender, EventArgs e)
        {
            currentSide = 0;
            UpdateDisplay();
        }

        private void optSide1_CheckedChanged(object sender, EventArgs e)
        {
            currentSide = 1;
            UpdateDisplay();
        }
    }
}
