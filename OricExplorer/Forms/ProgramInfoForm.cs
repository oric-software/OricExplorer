using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace OricExplorer.Forms
{
    public partial class ProgramInfoForm : DockContent
    {
        public ProgramInfoForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void AddDetails(String header, String detail)
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
            flowLayoutPanelInfo.Controls.Add(infoPanel);
        }

        public void DisplayProgramInformation(OricFileInfo fileInformation)
        {
            flowLayoutPanelInfo.Controls.Clear();

            if (fileInformation.MediaType == OricExplorer.MediaType.DiskFile || fileInformation.MediaType == OricExplorer.MediaType.TapeFile)
            {
                AddDetails("Program Name", fileInformation.ProgramName);
                AddDetails("Program Format", String.Format("{0}", fileInformation.FormatToString()));
                AddDetails("Memory Location", String.Format("${0:X4} to ${1:X4}\n({2} to {3})",
                           fileInformation.StartAddress, fileInformation.EndAddress, fileInformation.StartAddress, fileInformation.EndAddress));

                if (fileInformation.LengthBytes >= 1024)
                {
                    AddDetails("Program Size", String.Format("{0:N0} bytes\n({1:N1} KB)",
                               fileInformation.LengthBytes, (float)fileInformation.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("Program Size", String.Format("{0:N0} bytes", fileInformation.LengthBytes));
                }

                if (fileInformation.Format == OricProgram.ProgramFormat.BasicProgram || fileInformation.Format == OricProgram.ProgramFormat.CodeFile)
                {
                    AddDetails("Auto Run", fileInformation.AutoRun.ToString());
                }


                if (fileInformation.Format == OricProgram.ProgramFormat.CodeFile && fileInformation.ExeAddress != 0)
                {
                    AddDetails("Executable Address", String.Format("${0:X4}\n({1})", fileInformation.ExeAddress, fileInformation.ExeAddress));
                }

                switch (fileInformation.Format)
                {
                    case OricProgram.ProgramFormat.CharacterSet:
                        AddDetails("No. of Characters", (fileInformation.LengthBytes / 8).ToString());
                        break;

                    case OricProgram.ProgramFormat.DirectAccessFile:
                        AddDetails("No. of Records", fileInformation.m_ui16NoOfRecords.ToString());
                        AddDetails("Record Length", fileInformation.m_ui16RecordLength.ToString());
                        break;

                    case OricProgram.ProgramFormat.HelpFile:
                        AddDetails("Dimensions", String.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.HiresScreen:
                        AddDetails("Dimensions", String.Format("240 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.TextScreen:
                        AddDetails("Dimensions", String.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    case OricProgram.ProgramFormat.CodeFile:
                        break;

                    case OricProgram.ProgramFormat.BasicProgram:
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        // FileInformation.Text = String.Format("{0} Records", listViewRecords.Items.Count);
                        break;

                    case OricProgram.ProgramFormat.WindowFile:
                        AddDetails("Dimensions", String.Format("40 x {0}", fileInformation.LengthBytes / 40));
                        break;

                    default:
                        break;
                }

                if (fileInformation.MediaType == OricExplorer.MediaType.DiskFile)
                {
                    AddDetails("Disk Usage", String.Format("{0:N0} sectors", fileInformation.LengthSectors));

                    AddDetails("Security Status", fileInformation.Protection.ToString());
                }
            }
            else if(fileInformation.MediaType == OricExplorer.MediaType.ROMFile)
            {
                AddDetails("Name", Path.GetFileName(fileInformation.Name));
                AddDetails("Format", "Oric ROM File");

                AddDetails("Memory Location", String.Format("${0:X4} to ${1:X4}\n({2} to {3})",
                           fileInformation.StartAddress, fileInformation.EndAddress, fileInformation.StartAddress, fileInformation.EndAddress));

                if (fileInformation.LengthBytes >= 1024)
                {
                    AddDetails("ROM Size", String.Format("{0:N0} bytes\n({1:N1} KB)",
                               fileInformation.LengthBytes, (float)fileInformation.LengthBytes / 1024));
                }
                else
                {
                    AddDetails("ROM Size", String.Format("{0:N0} bytes", fileInformation.LengthBytes));
                }
            }
        }

        public void ClearInfo()
        {
            flowLayoutPanelInfo.Controls.Clear();
        }
    }
}
