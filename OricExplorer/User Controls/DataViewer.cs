using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OricExplorer
{
    public partial class DataViewerControl : UserControl
    {
        public Label FileInformation;
        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        private Preview dataPreview;
        private Point panStartingPoint;
        private double ZOOMFACTOR = 2;

        private Byte AddressOffset = 0;
        private Byte ScreenWidth = 40;

        public DataViewerControl()
        {
            InitializeComponent();

            FileInformation = new Label();

            // Set some defaults for the dataviewer
            dataPreview = new Preview(false);
            dataPreview.m_scrnFormat = OricProgram.ProgramFormat.UnknownFile;
            dataPreview.m_ui16DataLength = 0;

            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
        }

        public void InitialiseView()
        {
            AddressOffset = 0;
            ScreenWidth = 40;

            DisplayZoomLevel();

            dataPreview.m_ui16StartAddress = ProgramData.StartAddress;
            dataPreview.m_ui16DataLength = ProgramData.ProgramLength;
            dataPreview.bScrnData = ProgramData.m_programData;

            dataPreview.m_bDisablePaper = false;
            dataPreview.m_bDisableInk = false;

            checkBoxBackground.Checked = true;
            checkBoxForeground.Checked = true;
            checkBoxOthers.Checked = true;

            switch (ProgramData.Format)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    radioButtonHires.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                    radioButtonText.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.TextScreen;
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    radioButtonCharSet.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.CharacterSet;
                    break;

                default:
                    radioButtonHires.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
                    break;
            }

            UpdateScreen();
            Application.DoEvents();

        }
        
        private void UpdateScreen()
        {
            switch (ScreenWidth)
            {
                case 1:
                    buttonDecWidth.Enabled = false;
                    buttonIncWidth.Enabled = true;
                    buttonResetWidth.Enabled = true;

                    infoBoxWidth.Text = "1 Byte";
                    break;

                default:
                    buttonDecWidth.Enabled = true;

                    if (ScreenWidth == 40)
                    {
                        buttonIncWidth.Enabled = false;
                        buttonResetWidth.Enabled = false;
                    }
                    else
                    {
                        buttonIncWidth.Enabled = true;
                        buttonResetWidth.Enabled = true;
                    }

                    infoBoxWidth.Text = String.Format("{0} Bytes", ScreenWidth);
                    break;
            }

            switch (AddressOffset)
            {
                case 0:
                    buttonDecOffset.Enabled = false;
                    buttonIncOffset.Enabled = true;
                    buttonResetOffset.Enabled = false;

                    infoBoxOffset.Text = String.Format("0 Bytes (${0:X4})", ProgramInfo.StartAddress);
                    break;

                case 1:
                    buttonDecOffset.Enabled = true;
                    buttonIncOffset.Enabled = true;
                    buttonResetOffset.Enabled = true;

                    infoBoxOffset.Text = String.Format("1 Byte (${0:X4})", ProgramInfo.StartAddress + 1);
                    break;

                default:
                    buttonDecOffset.Enabled = true;

                    if (AddressOffset == 40)
                    {
                        buttonIncOffset.Enabled = false;
                        buttonResetOffset.Enabled = true;
                    }
                    else
                    {
                        buttonIncOffset.Enabled = true;
                        buttonResetOffset.Enabled = true;
                    }

                    infoBoxOffset.Text = String.Format("{0} Bytes (${1:X4})", AddressOffset, ProgramInfo.StartAddress + AddressOffset);
                    break;
            }

            // If CharacterSet view then disable the Width controls
            if (ProgramData.Format == OricProgram.ProgramFormat.CharacterSet)
            {
                buttonDecWidth.Enabled = false;
                buttonIncWidth.Enabled = false;
                buttonResetWidth.Enabled = false;

                infoBoxWidth.Text = "----";
            }

            redrawPreview();
        }

        private void redrawPreview()
        {
            // Set cursor to the wait cursor
            Cursor.Current = Cursors.WaitCursor;

            dataPreview.m_ui16Offset = AddressOffset;
            dataPreview.m_bWidthBytes = ScreenWidth;

            Application.DoEvents();
            dataPreview.DrawDataView();

            pictureBoxImage.Image = dataPreview.screenImage;
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Normal;
            pictureBoxImage.Size = pictureBoxImage.Image.Size;

            // Set the cursor back to the default cursor
            Cursor.Current = Cursors.Default;
        }

        private void ChangePreviewFormat(object sender, EventArgs e)
        {
            buttonDecWidth.Enabled = true;
            buttonIncWidth.Enabled = true;
            buttonResetWidth.Enabled = true;

            if (radioButtonText.Checked)
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.TextScreen;
            }
            else if (radioButtonHires.Checked)
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
            }
            else
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.CharacterSet;

                buttonDecWidth.Enabled = false;
                buttonIncWidth.Enabled = false;
                buttonResetWidth.Enabled = false;
            }

            AddressOffset = 0;
            ScreenWidth = 40;
            redrawPreview();

            DisplayZoomLevel();

            infoBoxWidth.Text = String.Format("{0} Bytes", ScreenWidth);
            infoBoxOffset.Text = String.Format("0 Bytes (${0:X4})", ProgramInfo.StartAddress);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataPreview.SaveScreen();
        }

        private void PicBox_MouseEnter(object sender, EventArgs e)
        {
            if (pictureBoxImage.Focused == false)
            {
                //pictureBoxImage.Focus ();
            }
        }

        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int DeltaX = panStartingPoint.X - e.X;
                int DeltaY = panStartingPoint.Y - e.Y; 

                panel1.AutoScrollPosition = new Point(DeltaX - panel1.AutoScrollPosition.X, DeltaY - panel1.AutoScrollPosition.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panStartingPoint = new Point(e.X, e.Y);
        }

        /*private void pictureBoxImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
        }*/

        private void ZoomIn()
        {
            if ((pictureBoxImage.Width / ZOOMFACTOR) <= 2400)
            {
                pictureBoxImage.Width = Convert.ToInt32(pictureBoxImage.Width * ZOOMFACTOR);
                pictureBoxImage.Height = Convert.ToInt32(pictureBoxImage.Height * ZOOMFACTOR);
                pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;

                DisplayZoomLevel();
            }
        }

        private void ZoomOut()
        {
            if((pictureBoxImage.Width / ZOOMFACTOR) >= 480)
            {
                pictureBoxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxImage.Width = Convert.ToInt32(pictureBoxImage.Width / ZOOMFACTOR);
                pictureBoxImage.Height = Convert.ToInt32(pictureBoxImage.Height / ZOOMFACTOR);

                DisplayZoomLevel();
            }
        }

        private void DisplayZoomLevel()
        {
            float zoomLevel = (float)pictureBoxImage.Width / 240;
            infoBoxZoom.Text = String.Format("Zoom Level x{0:N0}", zoomLevel);
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void buttonDecOffset_Click(object sender, EventArgs e)
        {
            if (AddressOffset > 0)
            {
                AddressOffset--;
                UpdateScreen();

                dataPreview.m_ui16Offset = AddressOffset;
                redrawPreview();
            }
        }

        private void buttonIncOffset_Click(object sender, EventArgs e)
        {
            if (AddressOffset < 39)
            {
                AddressOffset++;
                UpdateScreen();

                dataPreview.m_ui16Offset = AddressOffset;
                redrawPreview();
            }
        }

        private void buttonDecWidth_Click(object sender, EventArgs e)
        {
            if (ScreenWidth > 1)
            {
                ScreenWidth--;
                UpdateScreen();

                dataPreview.m_bWidthBytes = (Byte)ScreenWidth;
                redrawPreview();
            }
        }

        private void buttonIncWidth_Click(object sender, EventArgs e)
        {
            if (ScreenWidth < 40)
            {
                ScreenWidth++;
                UpdateScreen();

                dataPreview.m_bWidthBytes = (Byte)ScreenWidth;
                redrawPreview();
            }
        }

        private void buttonResetOffset_Click(object sender, EventArgs e)
        {
            AddressOffset = 0;
            UpdateScreen();
        }

        private void buttonResetWidth_Click(object sender, EventArgs e)
        {
            ScreenWidth = 40;
            UpdateScreen();
        }

        private void buttonResetZoom_Click(object sender, EventArgs e)
        {
            ZOOMFACTOR = 2;
            redrawPreview();

            DisplayZoomLevel();
        }

        private void checkBoxBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBackground.Checked)
            {
                dataPreview.m_bDisablePaper = false;
            }
            else
            {
                dataPreview.m_bDisablePaper = true;
            }

            UpdateScreen();
        }

        private void checkBoxForeground_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForeground.Checked)
            {
                dataPreview.m_bDisableInk = false;
            }
            else
            {
                dataPreview.m_bDisableInk = true;
            }

            UpdateScreen();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOthers.Checked)
            {
                dataPreview.m_bDisableAttributes = false;
            }
            else
            {
                dataPreview.m_bDisableAttributes = true;
            }

            UpdateScreen();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int xPos = (e.MarginBounds.Width - pictureBoxImage.Width) / 2;
            int yPos = (e.MarginBounds.Height - pictureBoxImage.Height) / 2;

            e.Graphics.DrawImage(pictureBoxImage.Image, xPos, yPos);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.OriginAtMargins = true;
            printDocument1.DocumentName = ProgramInfo.ProgramName;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}