namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ctlDataViewerControl : UserControl
    {
        public OricFileInfo ProgramInfo { get; set; }
        public OricProgram ProgramData { get; set; }

        private Preview dataPreview;
        private Point ptStartingPoint;
        
        private byte bytZoomFactor = 1;
        private byte bytAddressOffset = 0;
        private byte bytScreenWidth = 40;

        public ctlDataViewerControl()
        {
            InitializeComponent();

            // Set some defaults for the dataviewer
            dataPreview = new Preview(false);
            dataPreview.ScreenFormat = OricProgram.ProgramFormat.UnknownFile;
            dataPreview.DataLength = 0;

            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();
        }

        private void ChangePreviewFormat(object sender, EventArgs e)
        {
            btnWidthDec.Enabled = true;
            btnWidthInc.Enabled = true;
            btnWidthReset.Enabled = true;

            if (optDisplayText.Checked)
            {
                dataPreview.ScreenFormat = OricProgram.ProgramFormat.TextScreen;
            }
            else if (optDisplayHires.Checked)
            {
                dataPreview.ScreenFormat = OricProgram.ProgramFormat.HiresScreen;
            }
            else
            {
                dataPreview.ScreenFormat = OricProgram.ProgramFormat.CharacterSet;

                btnWidthDec.Enabled = false;
                btnWidthInc.Enabled = false;
                btnWidthReset.Enabled = false;
            }

            bytAddressOffset = 0;
            bytScreenWidth = 40;
            
            RedrawPreview();

            DisplayZoomLevel();

            ibxWidth.Text = string.Format("{0} Bytes", bytScreenWidth);
            ibxOffset.Text = string.Format("0 Bytes (${0:X4})", dataPreview.StartAddress);
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
            if (e.Button == MouseButtons.Left)
            {
                int DeltaX = ptStartingPoint.X - e.X;
                int DeltaY = ptStartingPoint.Y - e.Y; 

                panImageInner.AutoScrollPosition = new Point(DeltaX - panImageInner.AutoScrollPosition.X, DeltaY - panImageInner.AutoScrollPosition.Y);
            }
        }

        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            ptStartingPoint = new Point(e.X, e.Y);
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

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (bytZoomFactor < 32)
            {
                bytZoomFactor++;
                picImage.Width = Convert.ToInt32(picImage.Image.Width * bytZoomFactor);
                picImage.Height = Convert.ToInt32(picImage.Image.Height * bytZoomFactor);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;

                DisplayZoomLevel();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (bytZoomFactor > 1)
            {
                bytZoomFactor--;
                picImage.Width = Convert.ToInt32(picImage.Image.Width * bytZoomFactor);
                picImage.Height = Convert.ToInt32(picImage.Image.Height * bytZoomFactor);
                picImage.SizeMode = PictureBoxSizeMode.StretchImage;

                DisplayZoomLevel();
            }
        }

        private void btnOffsetDec_Click(object sender, EventArgs e)
        {
            if (bytAddressOffset > 0)
            {
                bytAddressOffset--;
                UpdateScreen();

                dataPreview.Offset = bytAddressOffset;
                RedrawPreview();
            }
        }

        private void btnOffsetInc_Click(object sender, EventArgs e)
        {
            if (bytAddressOffset < 39)
            {
                bytAddressOffset++;
                UpdateScreen();

                dataPreview.Offset = bytAddressOffset;
                RedrawPreview();
            }
        }

        private void btnWidthDec_Click(object sender, EventArgs e)
        {
            if (bytScreenWidth > 1)
            {
                bytScreenWidth--;
                UpdateScreen();

                dataPreview.WidthBytes = (byte)bytScreenWidth;
                RedrawPreview();
            }
        }

        private void btnWidthInc_Click(object sender, EventArgs e)
        {
            if (bytScreenWidth < 40)
            {
                bytScreenWidth++;
                UpdateScreen();

                dataPreview.WidthBytes = (byte)bytScreenWidth;
                RedrawPreview();
            }
        }

        private void btnOffsetReset_Click(object sender, EventArgs e)
        {
            bytAddressOffset = 0;
            UpdateScreen();
        }

        private void btnWidthReset_Click(object sender, EventArgs e)
        {
            bytScreenWidth = 40;
            UpdateScreen();
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            bytZoomFactor = 1;
            RedrawPreview();

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


        public void InitialiseView()
        {
            bytAddressOffset = 0;
            bytScreenWidth = 40;

            DisplayZoomLevel();

            if (ProgramData.Format == OricProgram.ProgramFormat.OrixProgram)
            {
                dataPreview.StartAddress = (ushort)(ProgramData.StartAddress + OtherFileInfo.ORIX_HEADER_LENGTH);
                dataPreview.ScreenData = ProgramData.ProgramData.Skip(OtherFileInfo.ORIX_HEADER_LENGTH).ToArray();
            }
            else
            {
                dataPreview.StartAddress = ProgramData.StartAddress;
                dataPreview.ScreenData = ProgramData.ProgramData;
            }

            dataPreview.DataLength = ProgramData.ProgramLength;
            dataPreview.DisablePaper = false;
            dataPreview.DisableInk = false;

            chkAttributesBackground.Checked = true;
            chkAttributesForeground.Checked = true;
            chkAttributesOthers.Checked = true;

            switch (ProgramData.Format)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    optDisplayHires.Checked = true;
                    dataPreview.ScreenFormat = OricProgram.ProgramFormat.HiresScreen;
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                    optDisplayText.Checked = true;
                    dataPreview.ScreenFormat = OricProgram.ProgramFormat.TextScreen;
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    optDisplayCharSet.Checked = true;
                    dataPreview.ScreenFormat = OricProgram.ProgramFormat.CharacterSet;
                    break;

                default:
                    optDisplayHires.Checked = true;
                    dataPreview.ScreenFormat = OricProgram.ProgramFormat.HiresScreen;
                    break;
            }

            UpdateScreen();
            Application.DoEvents();
        }

        private void DisplayZoomLevel()
        {
            btnZoomOut.Enabled = (bytZoomFactor > 1);
            btnZoomIn.Enabled = (bytZoomFactor < 32);
            btnZoomReset.Enabled = (bytZoomFactor > 1);
            ibxZoom.Text = string.Format("Zoom Level x{0:N0}", bytZoomFactor);
        }

        private void UpdateScreen()
        {
            btnWidthDec.Enabled = (bytScreenWidth > 0);
            btnWidthInc.Enabled = (bytScreenWidth < 40);
            btnWidthReset.Enabled = (bytScreenWidth < 40);
            ibxWidth.Text = string.Format("{0} Byte(s)", bytScreenWidth);

            btnOffsetDec.Enabled = (bytAddressOffset > 0);
            btnOffsetInc.Enabled = (bytAddressOffset < 40);
            btnOffsetReset.Enabled = (bytAddressOffset > 0);
            ibxOffset.Text = string.Format("{0} Byte(s) (${1:X4})", bytAddressOffset, dataPreview.StartAddress + bytAddressOffset);

            // If CharacterSet view then disable the Width controls
            if (ProgramData.Format == OricProgram.ProgramFormat.CharacterSet)
            {
                btnWidthDec.Enabled = false;
                btnWidthInc.Enabled = false;
                btnWidthReset.Enabled = false;

                ibxWidth.Text = "----";
            }

            RedrawPreview();
        }

        private void RedrawPreview()
        {
            // Set cursor to the wait cursor
            Cursor.Current = Cursors.WaitCursor;

            dataPreview.Offset = bytAddressOffset;
            dataPreview.WidthBytes = bytScreenWidth;

            Application.DoEvents();
            dataPreview.DrawDataView();

            picImage.Image = dataPreview.ScreenImage;
            picImage.SizeMode = PictureBoxSizeMode.Normal;
            picImage.Size = picImage.Image.Size;

            // Set the cursor back to the default cursor
            Cursor.Current = Cursors.Default;
        }
    }
}