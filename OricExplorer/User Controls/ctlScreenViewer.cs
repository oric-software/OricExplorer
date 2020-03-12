namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Windows.Forms;

    public partial class ctlScreenViewerControl : UserControl
    {
        public Label FileHeadings;
        public Label FileInformation;

        public byte[] tmpScreenData;
        public OricProgram ProgramData;
        public OricFileInfo ProgramInfo;
        public bool bScrnUpdated;
        public ConstantsAndEnums.MediaType mediaType;

        ScreenImage.ScreenImageSize screenImageSize;
        ScreenImage.ScreenImageFormat screenImageFormat;

        private ScreenImage oricScreenImage;
        private System.Windows.Forms.Timer FlashTimer;

        private int _ZoomFactor;

        public ctlScreenViewerControl()
        {
            InitializeComponent();

            _ZoomFactor = 2;

            oricScreenImage = new ScreenImage();

            screenImageSize = ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED;
            screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_UNKNOWN;

            FileInformation = new Label();
            FileHeadings = new Label();

            ProgramInfo = new OricFileInfo();
            ProgramData = new OricProgram();

            chkAttributePaper.Checked = true;
            chkAttributeInk.Checked = true;
            chkAttributeOther.Checked = true;

            this.picScreenImage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBoxScreenImage_MouseWheel);
        }

        ~ctlScreenViewerControl()
        {
            FlashTimer.Stop();
            FlashTimer = null;
        }

        public void InitialiseView()
        {
            oricScreenImage.m_ui16StartAddress = ProgramData.StartAddress;
            oricScreenImage.m_ui16DataLength = ProgramData.ProgramLength;
            oricScreenImage.bScrnData = ProgramData.m_programData;

            if (ProgramData.Format == OricProgram.ProgramFormat.HiresScreen)
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES;
                chkAttributeIndicator.Enabled = false;
                chkAttributeIndicator.Checked = false;
            }
            else
            {
                screenImageFormat = ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT;
            }

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;

            // Make a copy of the screen data
            tmpScreenData = new byte[ProgramData.ProgramLength];

            for (int index = 0; index < ProgramData.ProgramLength; index++)
            {
                tmpScreenData[index] = ProgramData.m_programData[index];
            }

            if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT)
            {
                if (FlashTimer == null)
                {
                    FlashTimer = new System.Windows.Forms.Timer();
                    FlashTimer.Interval = 700;
                    FlashTimer.Start();
                    FlashTimer.Tick += new EventHandler(Timer_Tick);
                }
            }
        }

        private void DisplayInfoText(int screenXPos, int screenYPos)
        {
            ushort memoryAddress = 0;
            memoryAddress = CalculateMemoryAddress(screenYPos, screenXPos);

            ibxScreenPosition.Text = "--";
            ibxScreenByte.Text = "--";

            ushort bufferIndex = (ushort)(memoryAddress - ProgramInfo.StartAddress);

            if (bufferIndex < tmpScreenData.Length)
            {
                byte screenByte = tmpScreenData[bufferIndex];

                if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT)
                {
                    if (screenYPos == 0)
                    {
                        ibxScreenPosition.Text = string.Format("{0:D2},SL", screenXPos);
                    }
                    else
                    {
                        ibxScreenPosition.Text = string.Format("{0:D2},{1:D2}", screenXPos, screenYPos - 1);
                    }
                }
                else if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES)
                {
                    ibxScreenPosition.Text = string.Format("{0:D3},{1:D3}", screenXPos, screenYPos);
                    ibxScreenByte.Text = string.Format("byte {0}", (screenXPos / 6));
                }

                ibxAddressDec.Text = string.Format("{0}", memoryAddress);
                ibxAddressHex.Text = string.Format("${0:X4}", memoryAddress);

                ibxAsciiDec.Text = string.Format("{0}", screenByte);
                ibxAsciiHex.Text = string.Format("#{0:X2}", screenByte);

                StringBuilder formatText = new StringBuilder();

                if ((screenByte >= 0 && screenByte <= 7) || (screenByte >= 16 && screenByte <= 23))
                {
                    ibxCellFormat.Text = "Colour Attribute";

                    int colourValue;

                    if (screenByte >= 16)
                    {
                        colourValue = (int)screenByte - 16;
                    }
                    else
                    {
                        colourValue = (int)screenByte;
                    }

                    switch (colourValue)
                    {
                        case 0:
                            ibxCellDetails.Text = "Black";
                            break;

                        case 1:
                            ibxCellDetails.Text = "Red";
                            break;

                        case 2:
                            ibxCellDetails.Text = "Green";
                            break;

                        case 3:
                            ibxCellDetails.Text = "Yellow"; 
                            break;

                        case 4:
                            ibxCellDetails.Text = "Blue";
                            break;

                        case 5:
                            ibxCellDetails.Text = "Magenta";
                            break;

                        case 6:
                            ibxCellDetails.Text = "Cyan";
                            break;

                        case 7:
                            ibxCellDetails.Text = "White";
                            break;
                    }

                    if (screenByte >= 16)
                    {
                        ibxCellDetails.Text += " Background";
                    }
                    else
                    {
                        ibxCellDetails.Text += " Foreground";
                    }
                }
                else if (screenByte >= 32 && screenByte <= 127)
                {
                    if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT)
                    {
                        ibxCellFormat.Text = "ASCII Character";

                        if (screenByte == 32)
                        {
                            ibxCellDetails.Text = "Space";
                        }
                        else
                        {
                            ibxCellDetails.Text = string.Format("{0}", Convert.ToChar(screenByte));
                        }
                    }
                    else
                    {
                        // Calculate whether Pixel is set or not
                        int value = screenXPos % 6;
                        int result = 32 >> value;

                        if ((byte)(screenByte & result) == result)
                        {
                            ibxCellFormat.Text = "Pixel is SET";
                            ibxCellDetails.Text = string.Format("Bit settings {0}", DectoBin(screenByte));
                        }
                        else if ((byte)(screenByte & result) == 0)
                        {
                            ibxCellFormat.Text = "Pixel is NOT set";
                            ibxCellDetails.Text = string.Format("Bit settings {0}", DectoBin(screenByte));
                        }
                        else
                        {
                            ibxCellFormat.Text = "---";
                            ibxCellDetails.Text = "---";
                        }
                    }
                }
                else
                {
                    ibxCellFormat.Text = "Character Attribute";

                    switch (screenByte)
                    {
                        case 0x08:
                        case 0x09:
                            ibxCellDetails.Text = "Single Height, Steady";
                            break;

                        case 0x0A:
                        case 0x0B:
                            ibxCellDetails.Text = "Double Height, Steady";
                            break;

                        case 0x0C:
                        case 0x0D:
                            ibxCellDetails.Text = "Single Height, Flashing";
                            break;

                        case 0x0E:
                        case 0x0F:
                            ibxCellDetails.Text = "Double Height, Flashing";
                            break;

                        default:
                            ibxCellDetails.Text = "----";
                            break;
                    }
                }
            }
        }

        private void picScreenImage_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseXPos = e.X;
            int mouseYPos = e.Y;

            Rectangle rectScreenLimits = new Rectangle(0, 0, picScreenImage.Width, picScreenImage.Height);

            if(rectScreenLimits.Contains(mouseXPos, mouseYPos))
            {
                int rowHeight = 0;
                int columnWidth = 0;
                int screenStartAddress = 0;

                if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT)
                {
                    screenStartAddress = 0xBB80;

                    if (screenImageSize == ScreenImage.ScreenImageSize.IMAGE_SIZE_NORMAL)
                    {
                        rowHeight = 8;
                        columnWidth = 6;
                    }
                    else
                    {
                        rowHeight = 16;
                        columnWidth = 12;
                    }
                }
                else if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES)
                {
                    screenStartAddress = 0xA000;

                    if (screenImageSize == ScreenImage.ScreenImageSize.IMAGE_SIZE_NORMAL)
                    {
                        rowHeight = 1;
                        columnWidth = 1; //6;
                    }
                    else
                    {
                        rowHeight = 2;
                        columnWidth = 2; //12;
                    }
                }
                else
                {
                    screenStartAddress = 0xBBA8;

                    if (screenImageSize == ScreenImage.ScreenImageSize.IMAGE_SIZE_NORMAL)
                    {
                        rowHeight = 8;
                        columnWidth = 6;
                    }
                    else
                    {
                        rowHeight = 16;
                        columnWidth = 12;
                    }
                }

                // Calculate the screen position in relation to the mouse pointer
                int screenXPos = mouseXPos / columnWidth;
                int screenYPos = mouseYPos / rowHeight;

                int firstRow = (ProgramInfo.StartAddress - screenStartAddress) / 40;
                int lastRow = (ProgramInfo.EndAddress - screenStartAddress) / 40;

                if (screenYPos >= firstRow && screenYPos <= lastRow)
                {
                    DisplayInfoText(screenXPos, screenYPos);
                }

                oricScreenImage.cursXPos = screenXPos;
                oricScreenImage.cursYPos = screenYPos;

                oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
                picScreenImage.Image = oricScreenImage.screenImageData;
            }

            UpdateZoomedImage(e.X, e.Y);
        }

        private void picScreenImage_MouseLeave(object sender, EventArgs e)
        {
            ibxScreenPosition.Text = "--,--";
            ibxScreenByte.Text = "--";
            ibxAddressDec.Text = "--";
            ibxAddressHex.Text = "--";
            ibxAsciiDec.Text = "--";
            ibxAsciiHex.Text = "--";
            ibxCellFormat.Text = "--";
        }

        private void pictureBoxScreenImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if(_ZoomFactor > 1)
                {
                    _ZoomFactor--;
                }
            }
            else
            {
                if (_ZoomFactor < 10)
                {
                    _ZoomFactor++;
                }
            }

            grpZoomedImage.Text = string.Format("Zoomed Image (x{0})", _ZoomFactor);
        }

        private void checkBoxGrid_CheckedChanged(object sender, EventArgs e)
        {
            /*if(checkBoxGrid.Checked)
            {
                checkBoxGrid.Text = "Hide Grid";
                bShowGrid = true;
            }
            else
            {
                checkBoxGrid.Text = "Show Grid";
                bShowGrid = false;
            }

            oricScreenImage.ShowGrid = bShowGrid;
            oricScreenImage.DrawScreenImage(screenImageSize, screenImageFormat);
            pictureBoxScreenImage.Image = oricScreenImage.screenImageData;*/
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            oricScreenImage.m_bFlash = !oricScreenImage.m_bFlash;

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;

            try
            {
                Point cursPos = Cursor.Position;
                Point newCusrPos = picScreenImage.PointToClient(cursPos);

                UpdateZoomedImage(newCusrPos.X, newCusrPos.Y);
            }
            catch (ObjectDisposedException)
            {
                FlashTimer.Stop();
                FlashTimer = null;
            }
        }

        private ushort CalculateMemoryAddress(int screenRow, int screenColumn)
        {
            int screenAddress = 0;

            if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES)
            {
                screenAddress = (0xA000 + (screenRow * 40));
            }
            else if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT)
            {
                screenAddress = (0xBB80 + (screenRow * 40));
            }
            else
            {
                screenAddress = (ProgramInfo.StartAddress + (screenRow * 40));
            }

            if (screenImageFormat == ScreenImage.ScreenImageFormat.IMAGE_FORMAT_HIRES)
            {
                byte byteAddress = (byte)(screenColumn / 6);
                screenAddress = screenAddress + byteAddress;
            }
            else
            {
                screenAddress = screenAddress + screenColumn;
            }

            return (ushort)(screenAddress);
        }

        private string DectoBin(ushort decVal)
        {
            StringBuilder sBinary = new StringBuilder();

            ushort siDivisor = 0x80;

            for (int iLoop = 0; iLoop < 8; iLoop++)
            {
                if ((decVal & siDivisor) == siDivisor)
                {
                    sBinary.Append("1");
                }
                else
                {
                    sBinary.Append("0");
                }

                siDivisor /= 2;
            }

            string Binary;
            Binary = sBinary.ToString();

            return Binary;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            prtDocument.OriginAtMargins = true;
            prtDocument.DocumentName = ProgramInfo.ProgramName;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = prtDocument;

            if(printDialog.ShowDialog() == DialogResult.OK)
            {
                prtDocument.Print();
            }
        }

        private void prtDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int xPos = (e.MarginBounds.Width - picScreenImage.Width) / 2;
            int yPos = (e.MarginBounds.Height - picScreenImage.Height) / 2;

            e.Graphics.DrawImage(picScreenImage.Image, xPos, yPos);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oricScreenImage.SaveScreen();
        }

        private void chkAttributePaper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributePaper.Checked)
            {
                // Switch PAPER on
                oricScreenImage.m_bDisablePaper = false;
            }
            else
            {
                // Switch PAPER off
                oricScreenImage.m_bDisablePaper = true;
            }

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;
        }

        private void chkAttributeInk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAttributeInk.Checked)
            {
                // Switch INK on
                oricScreenImage.m_bDisableInk = false;
            }
            else
            {
                // Switch INK off
                oricScreenImage.m_bDisableInk = true;
            }

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;
        }

        private void UpdateZoomedImage(int xPos, int yPos)
        {
            // Calculate the width and height of the portion of the image we want
            // to show in the picZoom picturebox. This value changes when the zoom
            // factor is changed.
            int zoomWidth = picZoomedImage.Width / _ZoomFactor;
            int zoomHeight = picZoomedImage.Height / _ZoomFactor;

            // Calculate the horizontal and vertical midpoints for the crosshair
            // cursor and correct centering of the new image
            int halfWidth = zoomWidth / 2;
            int halfHeight = zoomHeight / 2;

            // Create a new temporary bitmap to fit inside the picZoom picturebox
            Bitmap tempBitmap = new Bitmap(zoomWidth, zoomHeight, PixelFormat.Format24bppRgb);

            // Create a temporary Graphics object to work on the bitmap
            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            // Clear the bitmap with the selected backcolor
            bmGraphics.Clear(Color.Black);

            bmGraphics.SmoothingMode = SmoothingMode.None;
            bmGraphics.PixelOffsetMode = PixelOffsetMode.None;

            // Set the interpolation mode
            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the portion of the main image onto the bitmap
            // The target rectangle is already known now.
            // Here the mouse position of the cursor on the main image is used to
            // cut out a portion of the main image.
            bmGraphics.DrawImage(picScreenImage.Image,
                                 new Rectangle(0, 0, zoomWidth, zoomHeight),
                                 new Rectangle(xPos - halfWidth, yPos - halfHeight, zoomWidth, zoomHeight),
                                 GraphicsUnit.Pixel);

            // Draw a crosshair on the bitmap to simulate the cursor position
            bmGraphics.DrawLine(Pens.Gray, halfWidth, 0, halfWidth, zoomHeight);
            bmGraphics.DrawLine(Pens.Gray, 0, halfHeight, zoomWidth, halfHeight);

            // Draw the bitmap on the picZoom picturebox
            picZoomedImage.Image = tempBitmap;

            // Dispose of the Graphics object
            bmGraphics.Dispose();

            // Refresh the picZoom picturebox to reflect the changes
            picZoomedImage.Refresh();
        }

        private void chkAttributeOther_CheckedChanged(object sender, EventArgs e)
        {
            oricScreenImage.m_bDisableAttributes = !chkAttributeOther.Checked;

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;
        }

        private void chkAttributeIndicator_CheckedChanged(object sender, EventArgs e)
        {
            oricScreenImage.bShowAttrIndicator = chkAttributeIndicator.Checked;

            oricScreenImage.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_ENLARGED, screenImageFormat);
            picScreenImage.Image = oricScreenImage.screenImageData;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (_ZoomFactor < 10)
            {
                _ZoomFactor++;
            }

            grpZoomedImage.Text = string.Format("Zoomed Image (x{0})", _ZoomFactor);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (_ZoomFactor > 1)
            {
                _ZoomFactor--;
            }

            grpZoomedImage.Text = string.Format("Zoomed Image (x{0})", _ZoomFactor);
        }

        private void btnZoomReset_Click(object sender, EventArgs e)
        {
            _ZoomFactor = 2;

            grpZoomedImage.Text = string.Format("Zoomed Image (x{0})", _ZoomFactor);
        }
    }
}