namespace OricExplorer.Forms
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using WeifenLuo.WinFormsUI.Docking;

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

        public void DisplayProgramInformation(OricFileInfo fileInformation)
        {
            flpInfo.Controls.Clear();

            if (fileInformation.MediaType == ConstantsAndEnums.MediaType.DiskFile || fileInformation.MediaType == ConstantsAndEnums.MediaType.TapeFile)
            {
                AddDetails("Program Name", fileInformation.ProgramName);
                AddDetails("Program Format", string.Format("{0}", fileInformation.FormatToString()));
                AddDetails("Memory Location", string.Format("${0:X4} to ${1:X4}\n({2} to {3})",
                           fileInformation.StartAddress, fileInformation.EndAddress, fileInformation.StartAddress, fileInformation.EndAddress));

                if (fileInformation.LengthBytes >= 1024)
                {
                    AddDetails("Program Size", string.Format("{0:N0} bytes\n({1:N1} KB)",
                               fileInformation.LengthBytes, (float)fileInformation.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("Program Size", string.Format("{0:N0} bytes", fileInformation.LengthBytes));
                }

                if (fileInformation.Format == OricProgram.ProgramFormat.AtmosBasicProgram || fileInformation.Format == OricProgram.ProgramFormat.BinaryFile)
                {
                    AddDetails("Auto Run", fileInformation.AutoRun.ToString());
                }


                if (fileInformation.Format == OricProgram.ProgramFormat.BinaryFile && fileInformation.ExeAddress != 0)
                {
                    AddDetails("Executable Address", string.Format("${0:X4}\n({1})", fileInformation.ExeAddress, fileInformation.ExeAddress));
                }

                switch (fileInformation.Format)
                {
                    case OricProgram.ProgramFormat.CharacterSet:
                        AddDetails("No. of Characters", (fileInformation.LengthBytes / 8).ToString());
                        break;

                    case OricProgram.ProgramFormat.DirectAccessFile:
                        AddDetails("No. of Records", fileInformation.NoOfRecords.ToString());
                        AddDetails("Record Length", fileInformation.RecordLength.ToString());
                        break;

                    case OricProgram.ProgramFormat.HelpFile:
                        AddDetails("Dimensions", string.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.HiresScreen:
                        AddDetails("Dimensions", string.Format("240 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.TextScreen:
                        AddDetails("Dimensions", string.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.BinaryFile:
                        break;

                    case OricProgram.ProgramFormat.AtmosBasicProgram:
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        // FileInformation.Text = string.Format("{0} Records", listViewRecords.Items.Count);
                        break;

                    case OricProgram.ProgramFormat.WindowFile:
                        AddDetails("Dimensions", string.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    default:
                        break;
                }

                if (fileInformation.MediaType == ConstantsAndEnums.MediaType.DiskFile)
                {
                    AddDetails("Disk Usage", string.Format("{0:N0} sectors", fileInformation.LengthSectors));

                    AddDetails("Security Status", fileInformation.Protection.ToString());
                }
            }
            else if(fileInformation.MediaType == ConstantsAndEnums.MediaType.ROMFile)
            {
                AddDetails("Name", Path.GetFileName(fileInformation.Name));
                AddDetails("Format", "Oric ROM File");

                AddDetails("Memory Location", string.Format("${0:X4} to ${1:X4}\n({2} to {3})",
                           fileInformation.StartAddress, fileInformation.EndAddress, fileInformation.StartAddress, fileInformation.EndAddress));

                if (fileInformation.LengthBytes >= 1024)
                {
                    AddDetails("ROM Size", string.Format("{0:N0} bytes\n({1:N1} KB)",
                               fileInformation.LengthBytes, (float)fileInformation.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("ROM Size", string.Format("{0:N0} bytes", fileInformation.LengthBytes));
                }
            }
        }

        public void ClearInfo()
        {
            flpInfo.Controls.Clear();
        }
    }
}
