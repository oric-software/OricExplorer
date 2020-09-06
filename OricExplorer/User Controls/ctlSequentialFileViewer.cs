namespace OricExplorer.User_Controls
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class ctlSequentialFileViewer : UserControl
    {
        public Label FileInformation;
        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        public ctlSequentialFileViewer()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            FileInformation = new Label();
            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
        }

        public void InitialiseView()
        {
            try
            {
                ushort ui16RecordCount = 0;
                ushort ui16Index = 0;

                ushort ui16DataLength = 0;
                ListViewItem lvItem;
                StringBuilder oData;
                byte bByte = 0;

                lvwRecords.Items.Clear();

                while (bByte != 0xFF)
                {
                    ui16RecordCount++;

                    //if (ProgramInfo.MediaType == OricExplorer.MediaType. OricDisk.DOSFormat.SedOric)
                    //{
                    bByte = ProgramData.ProgramData[ui16Index];
                    ui16Index++;
                    //}
                    //else
                    //{
                    //    bByte = 0x80;

                    //    if (ui16Index >= ProgramInfo.LengthBytes)
                    //    {
                    //        bByte = 0xFF;
                    //    }
                    //}

                    switch (bByte)
                    {
                        case 0x00:
                            ui16DataLength = ProgramData.ProgramData[ui16Index];

                            lvItem = new ListViewItem();
                            lvItem.Text = string.Format("{0}", ui16RecordCount);
                            lvItem.SubItems.Add("Numeric");

                            oData = new StringBuilder();
                            ui16Index++;

                            byte Exponent = ProgramData.ProgramData[ui16Index];
                            ui16Index++;

                            StringBuilder Mantissa = new StringBuilder();
                            Mantissa.Length = 0;

                            for (int iIndex = 1; iIndex < ui16DataLength; iIndex++)
                            {
                                Mantissa.AppendFormat("{0:X2}", ProgramData.ProgramData[ui16Index]);
                                ui16Index++;
                            }

                            Int32 NumericValue = ConvertNumber(Exponent, Convert.ToUInt32(Mantissa.ToString(), 16));

                            lvItem.SubItems.Add(string.Format("{0}", NumericValue));
                            lvItem.ForeColor = Color.DarkGreen;
                            lvwRecords.Items.Add(lvItem);
                            break;

                        case 0x80:
                            ui16DataLength = ProgramData.ProgramData[ui16Index];

                            lvItem = new ListViewItem();
                            lvItem.Text = string.Format("{0}", ui16RecordCount);
                            lvItem.SubItems.Add("String");

                            oData = new StringBuilder();
                            ui16Index++;

                            if (ui16DataLength > 0)
                            {
                                for (int iIndex = 0; iIndex < ui16DataLength; iIndex++)
                                {
                                    oData.Append(Convert.ToChar(ProgramData.ProgramData[ui16Index]));
                                    ui16Index++;
                                }

                                lvItem.ForeColor = Color.DarkBlue;
                            }
                            else
                            {
                                oData.Append("<Empty>");
                                lvItem.ForeColor = Color.Gray;
                            }

                            lvItem.SubItems.Add(oData.ToString());
                            lvwRecords.Items.Add(lvItem);
                            break;

                        case 0xFF:
                            break;

                        default:
                            ui16DataLength = ProgramData.ProgramData[ui16Index];

                            lvItem = new ListViewItem();
                            lvItem.Text = string.Format("{0}", ui16RecordCount);
                            lvItem.SubItems.Add(string.Format("Unknown ({0:x2})", bByte));

                            oData = new StringBuilder();
                            ui16Index++;

                            for (int iIndex = 0; iIndex < ui16DataLength; iIndex++)
                            {
                                oData.AppendFormat("{0:X2} ", ProgramData.ProgramData[ui16Index]);
                                ui16Index++;
                            }

                            lvItem.SubItems.Add(oData.ToString());
                            lvItem.ForeColor = Color.DarkRed;
                            lvwRecords.Items.Add(lvItem);
                            break;
                    }
                }

                AdjustColumnHeaderWidths();
                lvwRecords.Items[0].Selected = true;

                FileInformation.Text = string.Format("{0} Records\n{1:N0} Bytes\nFile is {2}",
                                                     lvwRecords.Items.Count, ProgramInfo.LengthBytes,
                                                     ProgramInfo.Protection.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying file\r\n\r\n{ex.Message}", "Displaying File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustColumnHeaderWidths()
        {
            for (int iIndex = 0; iIndex < lvwRecords.Columns.Count; iIndex++)
            {
                lvwRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int iColSizeContent = lvwRecords.Columns[iIndex].Width;

                lvwRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int iColSizeHeader = lvwRecords.Columns[iIndex].Width;

                if (iColSizeContent > iColSizeHeader)
                {
                    lvwRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private Int32 ConvertNumber(byte Exponent, uint Mantissa)
        {
            Int32 Result;
            bool NegativeNumber = false;

            if (Exponent == 0 & Mantissa == 0)
            {
                return 0;
            }

            byte BitsToShift = (byte)(Exponent - 128);

            if ((Mantissa & 0x80000000) != 0x80000000)
            {
                Mantissa = (uint)(Mantissa + 0x80000000);
            }
            else
            {
                NegativeNumber = true;
            }

            Result = (Int32)(((Mantissa) << (BitsToShift)) | ((Mantissa) >> (32 - (BitsToShift))));

            if (NegativeNumber)
            {
                Result -= (2 * Result);
            }
            
            return Result;
        }
    }
}
