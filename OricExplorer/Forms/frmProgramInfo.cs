namespace OricExplorer.Forms
{
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;
    using static OricExplorer.ConstantsAndEnums;

    public partial class frmProgramInfo : DockContent
    {
        public frmProgramInfo()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void AddDetails(string header, string detail)
        {
            // Create a new Panel
            Panel infoPanel = new Panel();
            infoPanel.AutoSize = true;
            infoPanel.BackColor = Color.Transparent;

            //infoPanel.BackColor = Color.FromArgb(38, 38, 38);
            //infoPanel.BorderStyle = BorderStyle.FixedSingle;

            // Create info header
            Label infoHeaderLabel = new Label();
            infoHeaderLabel.AutoSize = true;
            infoHeaderLabel.Font = new Font("Segoe UI", 9);
            infoHeaderLabel.ForeColor = Color.Orange;
            infoHeaderLabel.TextAlign = ContentAlignment.MiddleLeft;
            infoHeaderLabel.Text = header;
            infoHeaderLabel.Left = 5;
            infoHeaderLabel.Top = 5;

            // Create info detail
            Label infoDetailLabel = new Label();
            infoDetailLabel.AutoSize = true;
            infoDetailLabel.Font = new Font("Consolas", 9);
            infoDetailLabel.ForeColor = Color.White;
            infoDetailLabel.TextAlign = ContentAlignment.MiddleLeft;
            infoDetailLabel.Text = detail;
            infoDetailLabel.Left = 5;
            infoDetailLabel.Top = 25;

            // Add header and info to Panel
            infoPanel.Controls.Add(infoHeaderLabel);
            infoPanel.Controls.Add(infoDetailLabel);

            // Add Panel to FlowControlLayout
            flpInfo.Controls.Add(infoPanel);
        }

        public void DisplayProgramInformation(OricFileInfo oricFileInfo)
        {
            flpInfo.Controls.Clear();

            if (oricFileInfo.MediaType.In(MediaType.DiskFile, MediaType.TapeFile))
            {
                AddDetails("Program Name", oricFileInfo.ProgramName);
                AddDetails("Program Format", string.Format("{0}", oricFileInfo.FormatToString()));
                AddDetails("Memory Location", string.Format("${0:X4} to ${1:X4}\n({0} to {1})", oricFileInfo.StartAddress, oricFileInfo.EndAddress));

                if (oricFileInfo.LengthBytes >= 1024)
                {
                    AddDetails("Program Size", string.Format("{0:N0} bytes\n({1:N1} KB)", oricFileInfo.LengthBytes, (float)oricFileInfo.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("Program Size", string.Format("{0:N0} bytes", oricFileInfo.LengthBytes));
                }

                if (oricFileInfo.Format.In(OricProgram.ProgramFormat.BasicProgram, OricProgram.ProgramFormat.BinaryFile))
                {
                    AddDetails("Auto Run", oricFileInfo.AutoRun.ToString());
                }


                if (oricFileInfo.Format == OricProgram.ProgramFormat.BinaryFile && oricFileInfo.ExeAddress != 0)
                {
                    AddDetails("Executable Address", string.Format("${0:X4}\n({0})", oricFileInfo.ExeAddress));
                }

                switch (oricFileInfo.Format)
                {
                    case OricProgram.ProgramFormat.CharacterSet:
                        AddDetails("No. of Characters", (oricFileInfo.LengthBytes / 8).ToString());
                        break;

                    case OricProgram.ProgramFormat.DirectAccessFile:
                        AddDetails("No. of Records", oricFileInfo.NoOfRecords.ToString());
                        AddDetails("Record Length", oricFileInfo.RecordLength.ToString());
                        break;

                    case OricProgram.ProgramFormat.HelpFile:
                        AddDetails("Dimensions", string.Format("40 x {0}", oricFileInfo.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.HiresScreen:
                        AddDetails("Dimensions", string.Format("240 x {0}", oricFileInfo.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.TextScreen:
                        AddDetails("Dimensions", string.Format("40 x {0}", oricFileInfo.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.BinaryFile:
                        break;

                    case OricProgram.ProgramFormat.BasicProgram:
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        // FileInformation.Text = string.Format("{0} Records", listViewRecords.Items.Count);
                        break;

                    case OricProgram.ProgramFormat.WindowFile:
                        AddDetails("Dimensions", string.Format("40 x {0}", oricFileInfo.LengthBytes / 40));
                        break;

                    default:
                        break;
                }

                if (oricFileInfo.MediaType == MediaType.DiskFile)
                {
                    AddDetails("Disk Usage", string.Format("{0:N0} sectors", oricFileInfo.LengthSectors));

                    AddDetails("Security Status", oricFileInfo.Protection.ToString());
                }
            }
            else if(oricFileInfo.MediaType == MediaType.ROMFile)
            {
                AddDetails("Name", Path.GetFileName(oricFileInfo.Name));
                AddDetails("Format", "Oric ROM File");

                AddDetails("Memory Location", string.Format("${0:X4} to ${1:X4}\n({0} to {1})", oricFileInfo.StartAddress, oricFileInfo.EndAddress));

                if (oricFileInfo.LengthBytes >= 1024)
                {
                    AddDetails("ROM Size", string.Format("{0:N0} bytes\n({1:N1} KB)",
                               oricFileInfo.LengthBytes, (float)oricFileInfo.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("ROM Size", string.Format("{0:N0} bytes", oricFileInfo.LengthBytes));
                }
            }
            else if (oricFileInfo.MediaType == MediaType.UnknownMedia)
            {
                AddDetails("Name", Path.GetFileName(oricFileInfo.Name));
                AddDetails("Format", oricFileInfo.Format.ToString());

                ushort ushStartAddress = oricFileInfo.StartAddress;
                ushort ushLength = oricFileInfo.LengthBytes;

                if (oricFileInfo.Format == OricProgram.ProgramFormat.OrixProgram)
                {
                    ushStartAddress += OtherFileInfo.ORIX_HEADER_LENGTH;
                    AddDetails($"Memory Location", string.Format("${0:X4} to ${1:X4}\n({0} to {1})", ushStartAddress, ushStartAddress + ushLength - 1));
                }

                if (oricFileInfo.LengthBytes >= 1024)
                {
                    AddDetails($"Length", $"{ushLength:N0}\n({(float)ushLength / 1024:N1} KB)");
                }
                else
                {
                    AddDetails($"Length", $"{ushLength:N0} bytes");
                }
            }
        }

        public void ClearInfo()
        {
            flpInfo.Controls.Clear();
        }
    }
}
