namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ctlDataViewerControl : UserControl
    {
        public Label FileInformation;
        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        private Preview dataPreview;
        private Point panStartingPoint;
        private double ZOOMFACTOR = 2;

        private byte AddressOffset = 0;
        private byte ScreenWidth = 40;

        public ctlDataViewerControl()
        {
            InitializeComponent();

            FileInformation = new Label();

            // Set some defaults for the dataviewer
            dataPreview = new Preview(false);
            dataPreview.m_scrnFormat = OricProgram.ProgramFormat.UnknownFile;
            dataPreview.DataLength = 0;

            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
        }

        public void InitialiseView()
        {
            AddressOffset = 0;
            ScreenWidth = 40;

            DisplayZoomLevel();

            dataPreview.StartAddress = ProgramData.StartAddress;
            dataPreview.DataLength = ProgramData.ProgramLength;
            dataPreview.bScrnData = ProgramData.m_programData;

            dataPreview.DisablePaper = false;
            dataPreview.DisableInk = false;

            chkAttributesBackground.Checked = true;
            chkAttributesForeground.Checked = true;
            chkAttributesOthers.Checked = true;

            switch (ProgramData.Format)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    optDisplayHires.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                    optDisplayText.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.TextScreen;
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    optDisplayCharSet.Checked = true;
                    dataPreview.m_scrnFormat = OricProgram.ProgramFormat.CharacterSet;
                    break;

                default:
                    optDisplayHires.Checked = true;
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
                    btnWidthDec.Enabled = false;
                    btnWidthInc.Enabled = true;
                    btnWidthReset.Enabled = true;

                    ibxWidth.Text = "1 Byte";
                    break;

                default:
                    btnWidthDec.Enabled = true;

                    if (ScreenWidth == 40)
                    {
                        btnWidthInc.Enabled = false;
                        btnWidthReset.Enabled = false;
                    }
                    else
                    {
                        btnWidthInc.Enabled = true;
                        btnWidthReset.Enabled = true;
                    }

                    ibxWidth.Text = string.Format("{0} Bytes", ScreenWidth);
                    break;
            }

            switch (AddressOffset)
            {
                case 0:
                    btnOffsetDec.Enabled = false;
                    btnOffsetInc.Enabled = true;
                    btnOffsetReset.Enabled = false;

                    ibxOffset.Text = string.Format("0 Bytes (${0:X4})", ProgramInfo.StartAddress);
                    break;

                case 1:
                    btnOffsetDec.Enabled = true;
                    btnOffsetInc.Enabled = true;
                    btnOffsetReset.Enabled = true;

                    ibxOffset.Text = string.Format("1 byte (${0:X4})", ProgramInfo.StartAddress + 1);
                    break;

                default:
                    btnOffsetDec.Enabled = true;

                    if (AddressOffset == 40)
                    {
                        btnOffsetInc.Enabled = false;
                        btnOffsetReset.Enabled = true;
                    }
                    else
                    {
                        btnOffsetInc.Enabled = true;
                        btnOffsetReset.Enabled = true;
                    }

                    ibxOffset.Text = string.Format("{0} Bytes (${1:X4})", AddressOffset, ProgramInfo.StartAddress + AddressOffset);
                    break;
            }

            // If CharacterSet view then disable the Width controls
            if (ProgramData.Format == OricProgram.ProgramFormat.CharacterSet)
            {
                btnWidthDec.Enabled = false;
                btnWidthInc.Enabled = false;
                btnWidthReset.Enabled = false;

                ibxWidth.Text = "----";
            }

            redrawPreview();
        }

        private void redrawPreview()
        {
            // Set cursor to the wait cursor
            Cursor.Current = Cursors.WaitCursor;

            dataPreview.Offset = AddressOffset;
            dataPreview.WidthBytes = ScreenWidth;

            Application.DoEvents();
            dataPreview.DrawDataView();

            picImage.Image = dataPreview.screenImage;
            picImage.SizeMode = PictureBoxSizeMode.Normal;
            picImage.Size = picImage.Image.Size;

            // Set the cursor back to the default cursor
            Cursor.Current = Cursors.Default;
        }

        private void ChangePreviewFormat(object sender, EventArgs e)
        {
            btnWidthDec.Enabled = true;
            btnWidthInc.Enabled = true;
            btnWidthReset.Enabled = true;

            if (optDisplayText.Checked)
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.TextScreen;
            }
            else if (optDisplayHires.Checked)
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
            }
            else
            {
                dataPreview.m_scrnFormat = OricProgram.ProgramFormat.CharacterSet;

                btnWidthDec.Enabled = false;
                btnWidthInc.Enabled = false;
                btnWidthReset.Enabled = false;
            }

            AddressOffset = 0;
            ScreenWidth = 40;
            redrawPreview();

            DisplayZoomLevel();

            ibxWidth.Text = string.Format("{0} Bytes", ScreenWidth);
            ibxOffset.Text = string.Format("0 Bytes (${0:X4})", ProgramInfo.StartAddress);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataPreview.SaveScreen();
        }

        private void panImageInner_MouseEnter(object sender, EventArgs e)
        {
            if (picImage.Focused == false)
            {
                //pictureBoxImage.Focus ();
            }
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int DeltaX = panStartingPoint.X - e.X;
                int DeltaY = panStartingPoint.Y - e.Y; 

                panImageInner.AutoScrollPosition = new Point(DeltaX - panImageInner.AutoScrollPosition.X, DeltaY - panImageInner.AutoScrollPosition.Y);
            }
        }

        private void picImage_MouseDown(object sender, MouseEventArgs e)
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
            if ((picImage.Width / ZOOMFACTOR) <= 2400)
            {
                picImage.Width = Convert.ToInt32(picImage.Width * ZOOMFACTOR);
                picImage.Height = Convert.ToInt32(picImage.Height * ZOOMFACTOR);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;

                DisplayZoomLevel();
            }
        }

        private void ZoomOut()
        {
            if((picImage.Width / ZOOMFACTOR) >= 480)
            {
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                picImage.Width = Convert.ToInt32(picImage.Width / ZOOMFACTOR);
                picImage.Height = Convert.ToInt32(picImage.Height / ZOOMFACTOR);

                DisplayZoomLevel();
            }
        }

        private void DisplayZoomLevel()
        {
            float zoomLevel = (float)picImage.Width / 240;
            ibxZoom.Text = string.Format("Zoom Level x{0:N0}", zoomLevel);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void btnOffsetDec_Click(object sender, EventArgs e)
        {
            if (AddressOffset > 0)
            {
                AddressOffset--;
                UpdateScreen();

                dataPreview.Offset = AddressOffset;
                redrawPreview();
            }
        }

        private void btnOffsetInc_Click(object sender, EventArgs e)
        {
            if (AddressOffset < 39)
            {
                AddressOffset++;
                UpdateScreen();

                dataPreview.Offset = AddressOffset;
                redrawPreview();
            }
        }

        private void btnWidthDec_Click(object sender, EventArgs e)
        {
            if (ScreenWidth > 1)
            {
                ScreenWidth--;
                UpdateScreen();

                dataPreview.WidthBytes = (byte)ScreenWidth;
                redrawPreview();
            }
        }

        private void btnWidthInc_Click(object sender, EventArgs e)
        {
            if (ScreenWidth < 40)
            {
                ScreenWidth++;
                UpdateScreen();

                dataPreview.WidthBytes = (byte)ScreenWidth;
                redrawPreview();
            }
        }

        private void btnOffsetReset_Click(object sender, EventArgs e)
        {
            AddressOffset = 0;
            UpdateScreen();
        }

        private void btnWidthReset_Click(object sender, EventArgs e)
        {
            ScreenWidth = 40;
            UpdateScreen();
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            ZOOMFACTOR = 2;
            redrawPreview();

            DisplayZoomLevel();
        }

        private void chkAttributesBackground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributesBackground.Checked)
            {
                dataPreview.DisablePaper = false;
            }
            else
            {
                dataPreview.DisablePaper = true;
            }

            UpdateScreen();
        }

        private void chkAttributesForeground_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributesForeground.Checked)
            {
                dataPreview.DisableInk = false;
            }
            else
            {
                dataPreview.DisableInk = true;
            }

            UpdateScreen();
        }

        private void chkAttributesOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributesOthers.Checked)
            {
                dataPreview.DisableAttributes = false;
            }
            else
            {
                dataPreview.DisableAttributes = true;
            }

            UpdateScreen();
        }

        private void prtDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int xPos = (e.MarginBounds.Width - picImage.Width) / 2;
            int yPos = (e.MarginBounds.Height - picImage.Height) / 2;

            e.Graphics.DrawImage(picImage.Image, xPos, yPos);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            prtDocument.OriginAtMargins = true;
            prtDocument.DocumentName = ProgramInfo.ProgramName;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = prtDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                prtDocument.Print();
            }
        }
    }
}