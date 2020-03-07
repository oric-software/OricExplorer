namespace OricExplorer.User_Controls
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class SequentialFileViewer : UserControl
    {
        public Label FileInformation;
        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        public SequentialFileViewer()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            FileInformation = new Label();
            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
        }

        public void InitialiseView()
        {
            ushort ui16RecordCount = 0;
            ushort ui16Index = 0;

            ushort ui16DataLength = 0;
            ListViewItem lvItem;
            StringBuilder oData;
            byte bByte = 0;

            listViewRecords.Items.Clear();

            while (bByte != 0xFF)
            {
                ui16RecordCount++;

                //if (ProgramInfo.MediaType == OricExplorer.MediaType. OricDisk.DOSFormat.SedOric)
                //{
                    bByte = ProgramData.m_programData[ui16Index];
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
                        ui16DataLength = ProgramData.m_programData[ui16Index];

                        lvItem = new ListViewItem();
                        lvItem.Text = string.Format("{0}", ui16RecordCount);
                        lvItem.SubItems.Add("Numeric");

                        oData = new StringBuilder();
                        ui16Index++;

                        byte Exponent = ProgramData.m_programData[ui16Index];
                        ui16Index++;

                        StringBuilder Mantissa = new StringBuilder();
                        Mantissa.Length = 0;

                        for (int iIndex = 1; iIndex < ui16DataLength; iIndex++)
                        {
                            Mantissa.AppendFormat("{0:X2}", ProgramData.m_programData[ui16Index]);
                            ui16Index++;
                        }

                        Int32 NumericValue = ConvertNumber(Exponent, Convert.ToUInt32(Mantissa.ToString(), 16));

                        lvItem.SubItems.Add(string.Format("{0}", NumericValue));
                        lvItem.ForeColor = Color.DarkGreen;
                        listViewRecords.Items.Add(lvItem);
                        break;

                    case 0x80:
                        ui16DataLength = ProgramData.m_programData[ui16Index];

                        lvItem = new ListViewItem();
                        lvItem.Text = string.Format("{0}", ui16RecordCount);
                        lvItem.SubItems.Add("String");

                        oData = new StringBuilder();
                        ui16Index++;

                        if (ui16DataLength > 0)
                        {
                            for (int iIndex = 0; iIndex < ui16DataLength; iIndex++)
                            {
                                oData.Append(Convert.ToChar(ProgramData.m_programData[ui16Index]));
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
                        listViewRecords.Items.Add(lvItem);
                        break;

                    case 0xFF:
                        break;

                    default:
                        ui16DataLength = ProgramData.m_programData[ui16Index];

                        lvItem = new ListViewItem();
                        lvItem.Text = string.Format("{0}", ui16RecordCount);
                        lvItem.SubItems.Add(string.Format("Unknown ({0:x2})", bByte));

                        oData = new StringBuilder();
                        ui16Index++;

                        for (int iIndex = 0; iIndex < ui16DataLength; iIndex++)
                        {
                            oData.AppendFormat("{0:X2} ", ProgramData.m_programData[ui16Index]);
                            ui16Index++;
                        }

                        lvItem.SubItems.Add(oData.ToString());
                        lvItem.ForeColor = Color.DarkRed;
                        listViewRecords.Items.Add(lvItem);
                        break;
                }
            }

            AdjustColumnHeaderWidths();
            listViewRecords.Items[0].Selected = true;

            FileInformation.Text = string.Format("{0} Records\n{1:N0} Bytes\nFile is {2}",
                                                 listViewRecords.Items.Count, ProgramInfo.LengthBytes,
                                                 ProgramInfo.Protection.ToString());
        }

        private void AdjustColumnHeaderWidths()
        {
            for (int iIndex = 0; iIndex < listViewRecords.Columns.Count; iIndex++)
            {
                listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int iColSizeContent = listViewRecords.Columns[iIndex].Width;

                listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int iColSizeHeader = listViewRecords.Columns[iIndex].Width;

                if (iColSizeContent > iColSizeHeader)
                {
                    listViewRecords.Columns[iIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
        }

        private Int32 ConvertNumber(byte Exponent, uint Mantissa)
        {
            Int32 Result = 0;
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
                Result = Result - (2 * Result);
            }
            
            return Result;
        }
    }
}
