using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using Be.Windows.Forms;

namespace OricExplorer.Forms
{
    public partial class DiskDataForm : DockContent
    {
        private Byte currentSide = 0;
        private Byte currentTrack = 0;
        private Byte currentSector = 1;

        private int noOfSectors = 0;

        public OricDiskInfo diskInfo;

        public DiskDataForm()
        {
            InitializeComponent();
        }

        public void InitialDisplay()
        {
            FileStream fs = new FileStream(diskInfo.FullName, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            long numBytes = new FileInfo(diskInfo.FullName).Length;
            Byte[] diskData = br.ReadBytes((int)numBytes);

            Byte[] signature = new Byte[8];
            Array.Copy(diskData, 0, signature, 0, 8);
            infoBoxSignature.Text = Encoding.UTF8.GetString(signature);

            Byte[] diskFormat = new Byte[4];
            Array.Copy(diskData, 8, diskFormat, 0, 4);
            UInt32 noOfSides = BitConverter.ToUInt32(diskFormat, 0);

            Array.Copy(diskData, 12, diskFormat, 0, 4);
            UInt32 noOfTracks = BitConverter.ToUInt32(diskFormat, 0);

            Array.Copy(diskData, 16, diskFormat, 0, 4);
            UInt32 geometryType = BitConverter.ToUInt32(diskFormat, 0);

            infoBoxNoOfSides.Text = String.Format("{0}", noOfSides);
            infoBoxNoOfTracks.Text = String.Format("{0}", noOfTracks);

            Byte[] binaryData = File.ReadAllBytes(diskInfo.FullName);
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

            Text = String.Format("Disk Data Viewer - {0}", Path.GetFileName(diskInfo.FullName));
        }

        private void UpdateDisplay()
        {
            infoBoxInfo.Text = String.Format("Track - {1:X2}, Sector - {2:X2}", currentSide, currentTrack, currentSector);

            // Read current sector
            if (currentSide == 1)
            {
                currentTrack += 0x80;
            }

            Byte[] byteArray = diskInfo.ReadSector(currentTrack, currentSector);

            // Display current sector
            DynamicByteProvider dynamicByteProvider;
            dynamicByteProvider = new DynamicByteProvider(byteArray);

            hexBoxSectorView.ByteProvider = dynamicByteProvider;

            trackBarTracks.Value = currentTrack & 0x7F;
            trackBarSectors.Value = currentSector;

            currentTrack = (Byte)trackBarTracks.Value;
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
