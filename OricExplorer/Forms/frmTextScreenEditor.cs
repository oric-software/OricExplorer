namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmTextScreenEditor : Form
    {
        private enum ScreenRegion { HORIZONTAL_RULER, VERTICAL_RULER, SCREEN_DISPLAY, OUTSIDE_REGION };
        private enum EditingMode { COLOUR_MODE, ATTRIBUTE_MODE, TEXT_MODE, ERASE_MODE };

        public byte[] stdCharSet;
        public byte[] bScrnData;

        public Image screenImage;

        public ushort m_ui16DataLength;

        private ushort m_ui16DisplayBytes;

        public ushort m_ui16Offset;
        public ushort m_ui16StartAddress;

        public byte cScrnPaper;
        public byte cScrnInk;
        public byte cResult;

        public OricFileInfo fileInfo;
        public OricDiskInfo diskInfo;

        public TapeInfo tapeInfo;

        private OricDisk oricDisk;
        private OricTape oricTape;
        private OricProgram loadedProgram;

        private int scrnCol;
        private int scrnRow;

        private int firstRow;
        private int lastRow;

        short screenOffsetX = 21;
        short screenOffsetY = 17;

        public bool m_bFlash;

        private bool bShowGrid;
        private bool bShowAttrIndicator;

        public bool bScrnUpdated;

        //private int _ZoomFactor;

        public ConstantsAndEnums.MediaType mediaType;

        private EditingMode editMode = EditingMode.COLOUR_MODE;
        private System.Windows.Forms.Timer FlashTimer;

        //protected override bool IsInputKey(Keys keyData)
        //{
        //    // Make sure we get arrow keys
        //    switch(keyData)
        //    {
        //        case Keys.Up:
        //        case Keys.Left:
        //        case Keys.Down:
        //        case Keys.Right:
        //            return true;
        //    }

        //    // The rest can be determined by the base class
        //    return base.IsInputKey(keyData);
        //}

        //protected override void OnKeyUp(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);

        //    //MessageBox.Show("raw key:" + e.KeyCode.ToString(), "debug");
        //    //MessageBox.Show("Keys.KeyCode:" + Keys.KeyCode.ToString(), "debug");
        //    //MessageBox.Show("e.KeyCode:" + e.KeyCode.ToString(), "debug");

        //    switch(Keys.KeyCode & e.KeyCode)
        //    {
        //        case Keys.Up:
        //            if(iScrnRow > 0)
        //                iScrnRow--;
        //            break;

        //        case Keys.Down:
        //            if(iScrnRow < 28)
        //                iScrnRow++;
        //            break;

        //        case Keys.Left:
        //            if(iScrnCol > 0)
        //                iScrnCol--;
        //            break;

        //        case Keys.Right:
        //            if(iScrnCol < 39)
        //                iScrnCol++;
        //            break;
        //    }

        //    NewDrawTextPreview();
        //    pictureBox1.Image = screenImage;
        //}

        public frmTextScreenEditor()
        {
            InitializeComponent();

            m_ui16DataLength = 0;
            m_ui16StartAddress = 0;

            scrnCol = 0;
            scrnRow = 0;

            cScrnPaper = 0;
            cScrnInk = 7;

            bScrnUpdated = false;

            // Load the standard character set
            BuildCharSet();

            lblSelectedPaperColour.BackColor = Color.Black;
            lblSelectedPaperColour.Tag = 0;

            lblSelectedInkColour.BackColor = Color.White;
            lblSelectedInkColour.Tag = 7;

            optAttributesSingle.Checked = true;
            optAttributesSteady.Checked = true;

            screenImage = new Bitmap(picEditor.Width , picEditor.Height);

            fileInfo = new OricFileInfo();
            oricDisk = new OricDisk();
            oricTape = new OricTape();

            loadedProgram = new OricProgram();

            bShowGrid = true;
            bShowAttrIndicator = true;

            m_bFlash = true;

            //_ZoomFactor = 2;

            optToolsColourMode.Checked = true;
            editMode = EditingMode.COLOUR_MODE;
        }

        private void frmTextScreenEditor_Load(object sender, EventArgs e)
        {
            string strTitleText = Text;
            Text = string.Format("Text Screen Editor - {0}", fileInfo.ProgramName);

            // Initialise program settings
            loadedProgram.New();

            if (mediaType == ConstantsAndEnums.MediaType.DiskFile)
            {
                loadedProgram = fileInfo.LoadFile();
            }
            else if (mediaType == ConstantsAndEnums.MediaType.TapeFile)
            {
                //loadedProgram = oricTape.Load(Path.Combine(tapeInfo.Folder, tapeInfo.Name), fileInfo.ProgramName, fileInfo.ProgramIndex);
                loadedProgram = oricTape.Load(tapeInfo.FullName, fileInfo.ProgramName, fileInfo.ProgramIndex);
            }

            bScrnData = new byte[loadedProgram.ProgramLength];

            for(int iIndex = 0; iIndex < loadedProgram.ProgramLength; iIndex++)
            {
                bScrnData[iIndex] = loadedProgram.m_programData[iIndex];
            }

            m_ui16StartAddress = loadedProgram.StartAddress;
            m_ui16DisplayBytes = loadedProgram.ProgramLength;

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;

            firstRow = (fileInfo.StartAddress - 0xBBA8) / 40;
            lastRow = (fileInfo.EndAddress - 0xBBA8) / 40;

            if (FlashTimer == null)
            {
                FlashTimer = new System.Windows.Forms.Timer();
                FlashTimer.Interval = 700;
                FlashTimer.Start();
                FlashTimer.Tick += new EventHandler(Timer_Tick);
            }

            UpdateStandardImage();

            ibxStartAddress.Text = string.Format("${0:X4}", loadedProgram.StartAddress);
            ibxEndAddress.Text = string.Format("${0:X4}", loadedProgram.EndAddress);
            ibxLength.Text = string.Format("{0:N0} bytes ({1:N1} KB)", loadedProgram.ProgramLength, loadedProgram.ProgramLength/1024);
            ibxDimensions.Text = string.Format("40 columns by {0} rows", lastRow - firstRow);
        }

        private void picEditor_MouseMove(object sender, MouseEventArgs e)
        {
            int screenX = 0;
            int screenY = 0;
            int memoryIndex = 0;

            ScreenRegion region = CalculateScreenPosition(e.X, e.Y, ref screenX, ref screenY);

            switch(region)
            {
                case ScreenRegion.HORIZONTAL_RULER:
                    tsslStatus.Text = string.Format("Mouse over horizontal ruler - X:{0:D2},Y{1:D2}", screenX, screenY);
                    break;

                case ScreenRegion.VERTICAL_RULER:
                    tsslStatus.Text = string.Format("Mouse over vertical ruler - X:{0:D2},Y{1:D2}", screenX, screenY);
                    break;

                case ScreenRegion.SCREEN_DISPLAY:
                    if (screenY >= firstRow && screenY <= lastRow)
                    {
                        if (screenY == -1)
                        {
                            memoryIndex = ((screenY + 1) * 40) + screenX;
                        }
                        else
                        {
                            memoryIndex = (screenY * 40) + screenX;
                        }

                        DisplayInfoText(screenX, screenY, bScrnData[memoryIndex]);
                    }
                    break;

                default:
                    // Mouse is outside our defined areas
                    tsslStatus.Text = "Ready.";
                    break;
            }
        }

        private void picEditor_MouseLeave(object sender, EventArgs e)
        {
            tsslAddress.Text = "-----";
            tsslAscii.Text = "--- ---";
            tsslPosition.Text = "--,--";
            tsslInfo.Text = "N/A";

            tsslStatus.Text = "Ready.";
        }

        private void picEditor_MouseDown(object sender, MouseEventArgs e)
        {
            int screenX = 0;
            int screenY = 0;
            int screenAddress = 0;
            int memoryIndex = 0;

            ScreenRegion region = CalculateScreenPosition(e.X, e.Y, ref screenX, ref screenY);

            switch (region)
            {
                case ScreenRegion.HORIZONTAL_RULER:
                    tsslStatus.Text = string.Format("Mouse over horizontal ruler - X:{0:D2},Y{1:D2}", screenX, screenY);
                    break;

                case ScreenRegion.VERTICAL_RULER:
                    tsslStatus.Text = string.Format("Mouse over vertical ruler - X:{0:D2},Y{1:D2}", screenX, screenY);
                    break;

                case ScreenRegion.SCREEN_DISPLAY:
                    if (screenY >= firstRow && screenY <= lastRow)
                    {
                        memoryIndex = (screenY * 40) + screenX;

                        screenAddress = fileInfo.StartAddress + memoryIndex;

                        if (memoryIndex < bScrnData.Length)
                        {
                            switch (editMode)
                            {
                                case EditingMode.COLOUR_MODE:
                                    byte colourIndex = 0;

                                    if (e.Button == MouseButtons.Left)
                                    {
                                        // Set the foreground colour
                                        colourIndex = Convert.ToByte(lblSelectedInkColour.Tag);
                                        UpdateScreenMemory(screenAddress, colourIndex);
                                    }
                                    else if (e.Button == MouseButtons.Right)
                                    {
                                        // Set the background colour
                                        colourIndex = Convert.ToByte(lblSelectedPaperColour.Tag);
                                        colourIndex += 16;

                                        UpdateScreenMemory(screenAddress, colourIndex);
                                    }
                                    break;

                                case EditingMode.ATTRIBUTE_MODE:
                                    if (e.Button == MouseButtons.Left)
                                    {
                                        if (optAttributesSingle.Checked == true)
                                        {
                                            if (optAttributesSteady.Checked == true)
                                            {
                                                UpdateScreenMemory(screenAddress, 0x08);
                                            }
                                            else
                                            {
                                                UpdateScreenMemory(screenAddress, 0x0C);
                                            }
                                        }
                                        else
                                        {
                                            if (optAttributesSteady.Checked == true)
                                            {
                                                UpdateScreenMemory(screenAddress, 0x0A);
                                            }
                                            else
                                            {
                                                UpdateScreenMemory(screenAddress, 0x0E);
                                            }
                                        }
                                    }
                                    break;

                                case EditingMode.TEXT_MODE:
                                    break;

                                case EditingMode.ERASE_MODE:
                                    if (e.Button == MouseButtons.Left)
                                    {
                                        UpdateScreenMemory(screenAddress, 0x20);
                                    }
                                    break;
                            }

                            DrawTextPreview(screenImage);
                            picEditor.Image = screenImage;

                            UpdateStandardImage();
                        }
                    }
                    break;

                default:
                    // Mouse is outside our defined areas
                    tsslStatus.Text = "Ready.";
                    break;
            }
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            bScrnUpdated = true;

            // Set the screens PAPER attribute (Column 0)
            for (int iIndex = 0; iIndex < fileInfo.LengthBytes; iIndex += 40)
            {
                byte colourIndex = Convert.ToByte(lblSelectedPaperColour.Tag);
                colourIndex += 16;

                bScrnData[iIndex] = colourIndex;
            }

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;
        }

        private void btnInk_Click(object sender, EventArgs e)
        {
            bScrnUpdated = true;

            // Set the screens INK attribute (Column 1)
            for (int iIndex = 0; iIndex < fileInfo.LengthBytes; iIndex += 40)
            {
                bScrnData[iIndex+1] = Convert.ToByte(lblSelectedInkColour.Tag);
            }

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;
        }

        private void lblColors_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Label colourLabel;
            colourLabel = new Label();

            colourLabel = (Label)sender;
            byte bColour = Convert.ToByte(colourLabel.Tag);

            if (e.Button == MouseButtons.Left)
            {
                lblSelectedInkColour.Tag = bColour;
                lblSelectedInkColour.BackColor = Colour(bColour);
            }
            else if (e.Button == MouseButtons.Right)
            {
                lblSelectedPaperColour.Tag = bColour;
                lblSelectedPaperColour.BackColor = Colour(bColour);
            }

            optToolsColourMode.Checked = true;
        }

        private void ttpToolTip_Popup(object sender, PopupEventArgs e)
        {
            Control selectedControl = e.AssociatedControl;

            ttpToolTip.ToolTipTitle = "Editor Info";
            tsslStatus.Text = ttpToolTip.GetToolTip(selectedControl);
        }

        private void tsbShowHideGrid_Click(object sender, EventArgs e)
        {
            if (tsbShowHideGrid.Checked)
            {
                tsbShowHideGrid.Checked = false;
                bShowGrid = false;
            }
            else
            {
                tsbShowHideGrid.Checked = true;
                bShowGrid = true;
            }

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;
        }

        private void optAttributes_MouseClick(object sender, MouseEventArgs e)
        {
            optToolsAttributeMode.Checked = true;
        }

        private void optToolsColourMode_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditingMode.COLOUR_MODE;
        }

        private void optToolsAttributeMode_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditingMode.ATTRIBUTE_MODE;
        }

        private void optToolsTextMode_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditingMode.TEXT_MODE;
        }

        private void optToolsEraseMode_CheckedChanged(object sender, EventArgs e)
        {
            editMode = EditingMode.ERASE_MODE;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            m_bFlash = !m_bFlash;

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;

            UpdateStandardImage();
        }

        private void DisplayInfoText(int screenXPos, int screenYPos, byte screenByte)
        {
            int memoryOffset = (screenYPos * 40) + screenXPos;
            int screenAddress = fileInfo.StartAddress + memoryOffset;

            if (screenYPos == 0)
            {
                tsslPosition.Text = string.Format("{0:D2},SL", screenXPos);
            }
            else
            {
                tsslPosition.Text = string.Format("{0:D2},{1:D2}", screenXPos, screenYPos - 1);
            }

            tsslAddress.Text = string.Format("${0:X4}", screenAddress);
            tsslAscii.Text = string.Format("#{0:X2} ({1:D3})", screenByte, screenByte);

            if ((screenByte >= 0 && screenByte <= 7) || (screenByte >= 16 && screenByte <= 23))
            {
                int colourValue = 0;
                string colourDescription = "";

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
                        colourDescription = "Black";
                        break;

                    case 1:
                        colourDescription = "Red";
                        break;

                    case 2:
                        colourDescription = "Green";
                        break;

                    case 3:
                        colourDescription = "Yellow";
                        break;

                    case 4:
                        colourDescription = "Blue";
                        break;

                    case 5:
                        colourDescription = "Magenta";
                        break;

                    case 6:
                        colourDescription = "Cyan";
                        break;

                    case 7:
                        colourDescription = "White";
                        break;
                }

                if (screenByte >= 16)
                {
                    colourDescription += " Background";
                }
                else
                {
                    colourDescription += " Foreground";
                }

                tsslInfo.Text = "Colour Attribute : " + colourDescription;
            }
            else if (screenByte >= 32 && screenByte <= 127)
            {
                if (screenByte == 32)
                {
                    tsslInfo.Text = "ASCII Character : Space";
                }
                else
                {
                    tsslInfo.Text = string.Format("ASCII Character : {0}", Convert.ToChar(screenByte));
                }

            }
            else
            {
                string attributeDescription = "";

                switch (screenByte)
                {
                    case 0x08:
                    case 0x09:
                        attributeDescription = "Single Height, Steady";
                        break;

                    case 0x0A:
                    case 0x0B:
                        attributeDescription = "Double Height, Steady";
                        break;

                    case 0x0C:
                    case 0x0D:
                        attributeDescription = "Single Height, Flashing";
                        break;

                    case 0x0E:
                    case 0x0F:
                        attributeDescription = "Double Height, Flashing";
                        break;

                    default:
                        attributeDescription = "???";
                        break;
                }

                tsslInfo.Text = "Character Attribute : " + attributeDescription;
            }
        }

        private void DrawTextPreview(Image textImage)
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            short siStart = 0;
            short siLimit = 0;
            short siLine = 0;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;

            bool bDoubleHeight = false;
            bool bBlink = false;

            int imageWidth = 480 + screenOffsetX;
            int imageHeight = 448 + screenOffsetY;
            int pixelWidth = 12;
            int pixelHeight = 16;

            int screenX = 0;
            int screenY = 0;

            try
            {
                Point cursorPosition = Cursor.Position;
                Point currentCursorPositon = picEditor.PointToClient(cursorPosition);
                ScreenRegion region = CalculateScreenPosition(currentCursorPositon.X, currentCursorPositon.Y, ref screenX, ref screenY);
            }
            catch(ObjectDisposedException ex)
            {
                string message = ex.Message;
            }

            // Create graphics object for alteration.
            Graphics g = Graphics.FromImage(textImage);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            cScrnPaper = 0;
            cScrnInk = 7;

            // Fill entire image with black background.
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, imageWidth, imageHeight);

            DrawHorizontalRuler(g, screenX);
            DrawVerticalRuler(g, screenY);

            if (m_ui16StartAddress == 0xBB80)
            {
                siLine = -1;
            }
            else
            {
                siLine = (short)((m_ui16StartAddress - 0xBBA8) / 40);
            }

            // Calculate starting Y position
            siYPos = (short)((siLine + 1) * (pixelHeight * 8));

            ui16Loop = 0;

            while (ui16Loop < m_ui16DisplayBytes)
            {
                cByte = bScrnData[ui16Loop];

                if (ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                {
                    cScrnPaper = 0;
                    g.FillRectangle(new SolidBrush(Color.Black), siXPos+screenOffsetX, siYPos+screenOffsetY, imageWidth, pixelHeight);
                }

                if (cByte >= 0 && cByte <= 7)
                {
                    cScrnInk = cByte;
                }

                cResult = Convert.ToByte(0x40 & cByte);

                if (cByte < 32)
                {
                    if (cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        int iWidth = (40 - ui16ByteCount) * pixelWidth;

                        g.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos + screenOffsetX, siYPos + screenOffsetY, iWidth, pixelHeight);
                    }
                    else if (cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else
                    {
                        if (cByte == 0x08 || cByte == 0x09 || cByte == 0x0C || cByte == 0x0D)
                            bDoubleHeight = false;

                        if (cByte == 0x0A || cByte == 0x0B || cByte == 0x0E || cByte == 0x0F)
                            bDoubleHeight = true;

                        if (cByte == 0x08 || cByte == 0x09 || cByte == 0x0A || cByte == 0x0B)
                            bBlink = false;

                        if (cByte == 0x0C || cByte == 0x0D || cByte == 0x0E || cByte == 0x0F)
                            bBlink = true;
                    }

                    if (bShowAttrIndicator)
                    {
                        if ((cByte >= 8 && cByte <= 15) || (cByte >= 0 && cByte <= 7) || (cByte >= 16 && cByte <= 23))
                        {
                            // Draw indicator to show cell is an attribute
                            g.FillRectangle(new SolidBrush(Color.Orange), siXPos + screenOffsetX, siYPos + screenOffsetY, pixelWidth / 4, pixelHeight / 4);
                        }
                    }
                }
                else
                {
                    siStart = 0;
                    siLimit = 8;

                    short siRemainder = 0;

                    if (bDoubleHeight)
                    {
                        // Check if current line is odd or even
                        siRemainder = (short)(siLine % 2);

                        if (siRemainder == 0)
                        {
                            siStart = 4;
                            siLimit = 8;
                        }
                        else
                        {
                            siStart = 0;
                            siLimit = 4;
                        }
                    }

                    for (short siLoop2 = siStart; siLoop2 < siLimit; siLoop2++)
                    {
                        if (cByte > 0x7F)
                        {
                            cByte = 32;
                        }

                        int iIndex = (cByte - 32) * 8;
                        short siPattern = stdCharSet[iIndex + siLoop2];

                        short siPixelHeight = 2;
                        short siPixelWidth = 2;

                        if (bDoubleHeight)
                            siPixelHeight = (short)(siPixelHeight * 2);

                        for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            byte cBit = (byte)(siPattern << (siLoop3));

                            cResult = Convert.ToByte(0x80 & cBit);

                            if (cResult == 0x80)
                            {
                                if (bBlink)
                                {
                                    if (m_bFlash)
                                    {
                                        g.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos + screenOffsetX, siYPos + screenOffsetY, siPixelWidth, siPixelHeight);
                                    }
                                }
                                else
                                {
                                    g.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos + screenOffsetX, siYPos + screenOffsetY, siPixelWidth, siPixelHeight);
                                }
                            }

                            siXPos += siPixelWidth;
                        }

                        siXPos -= (short)pixelWidth;

                        siYPos += 2;

                        if (bDoubleHeight)
                            siYPos += 2;
                    }

                    siYPos -= (short)pixelHeight;
                }

                siXPos += (short)pixelWidth;

                ui16ByteCount++;

                // Have we drawn one whole TEXT line?
                if (ui16ByteCount == 40)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += (short)pixelHeight;

                    // Reset back to single height characters
                    bDoubleHeight = false;

                    // Reset to no blink
                    bBlink = false;

                    // Reset counter
                    ui16ByteCount = 0;
                    //siColumn = 0;

                    // Increment the line counter
                    siLine++;
                }

                ui16Loop++;
            }

            // Draw grid
            if (bShowGrid)
            {
                DrawGrid(g, screenOffsetX, screenOffsetY);
            }

            // Dispose of graphics object.
            g.Dispose();
        }

        private void DrawHorizontalRuler(Graphics g, int screenX)
        {
            // Draw horizontal ruler (0 to 39)
            int rulerOffset = 20;

            int rulerX = 6 + rulerOffset;
            int rulerY = 5;

            g.FillRectangle(new SolidBrush(Color.White), rulerOffset, 0, 482, 16);
            g.DrawRectangle(new Pen(Color.Black), rulerOffset, 0, 482, 16);

            Font objFont;
            objFont = new System.Drawing.Font("Consolas", 7);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            for (int column = 0; column < 40; column++)
            {
                string number = string.Format("{0:D2}", column);

                if (screenX == column)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), rulerX-6, 1, 12, rulerY + 10);
                    g.DrawString(number, objFont, new SolidBrush(Color.Yellow), rulerX + 1, rulerY, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX, rulerY + 5, rulerX, rulerY + 10);
                }
                else
                {
                    g.DrawString(number, objFont, new SolidBrush(Color.Black), rulerX + 1, rulerY, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX, rulerY + 5, rulerX, rulerY + 10);
                }

                rulerX += 12;
            }
        }

        private void DrawVerticalRuler(Graphics g, int screenY)
        {
            // Draw vertical ruler (0 to 26)
            int rulerOffset = 17;

            int rulerX = 6;
            int rulerY = 8 + rulerOffset;

            g.FillRectangle(new SolidBrush(Color.White), 0, rulerOffset, 20, 448);
            g.DrawRectangle(new Pen(Color.Black), 0, rulerOffset, 20, 448);

            Font objFont;
            objFont = new System.Drawing.Font("Consolas", 7);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            int startRow = -1;

            for (int row = startRow; row < 27; row++)
            {
                string number = "";

                if (row == -1)
                {
                    number = "SL";
                }
                else
                {
                    number = string.Format("{0:D2}", row);
                }

                if (screenY == row)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), 1, rulerY - 8, rulerX+13, 16);
                    g.DrawString(number, objFont, new SolidBrush(Color.Yellow), rulerX + 1, rulerY + 1, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX + 8, rulerY, rulerX + 13, rulerY);
                }
                else
                {
                    g.DrawString(number, objFont, new SolidBrush(Color.Black), rulerX + 1, rulerY + 1, drawFormat);
                    g.DrawLine(new Pen(Color.Black), rulerX + 8, rulerY, rulerX + 13, rulerY);
                }

                rulerY += 16;
            }
        }

        private void DrawGrid(Graphics g, int screenOffsetX, int screenOffsetY)
        {
            int xPos = 0;
            int yPos = 0;

            Pen gridPen = new Pen(Color.FromArgb(100, 100, 100));

            for (int iCol = 1; iCol < 40; iCol++)
            {
                xPos = (iCol * 12) - 1;
                xPos += screenOffsetX;

                g.DrawLine(gridPen, xPos, 0+screenOffsetY, xPos, 448 + screenOffsetY);
            }

            for (int iRow = 1; iRow < 28; iRow++)
            {
                yPos = (iRow * 16) - 1;
                yPos += screenOffsetY;

                g.DrawLine(gridPen, 0+screenOffsetX, yPos, 480+screenOffsetX, yPos);
            }

            g.DrawRectangle(gridPen, screenOffsetX, screenOffsetY, 480, 448);
        }

        private void UpdateStandardImage()
        {
            ScreenImage dataPreview = new ScreenImage();

            dataPreview.m_ui16StartAddress = loadedProgram.StartAddress;
            dataPreview.m_ui16DataLength = loadedProgram.ProgramLength;
            dataPreview.bScrnData = bScrnData;
            dataPreview.m_bFlash = m_bFlash;

            dataPreview.DrawScreenImage(ScreenImage.ScreenImageSize.IMAGE_SIZE_NORMAL, ScreenImage.ScreenImageFormat.IMAGE_FORMAT_TEXT);
            pic.Image = dataPreview.screenImageData;
        }

        private Color Colour(byte cIndex)
        {
            Color crColour;

            switch(cIndex)
            {
                case 0: 
                    crColour = Color.Black;
                    break;

                case 1: 
                    crColour = Color.FromArgb(255, 0, 0);
                    break;

                case 2: 
                    crColour = Color.FromArgb(0, 255, 0);
                    break;

                case 3: 
                    crColour = Color.Yellow;
                    break;

                case 4: 
                    crColour = Color.FromArgb(0, 0, 255);
                    break;

                case 5: 
                    crColour = Color.Magenta;
                    break;

                case 6: 
                    crColour = Color.Cyan; 
                    break;

                case 7: 
                    crColour = Color.White; 
                    break;

                default:
                    crColour = Color.Black; 
                    break;
            }

            return crColour;
        }

        private ScreenRegion CheckMouseRegion(int mouseX, int mouseY)
        {
            // Set to default region
            ScreenRegion region = ScreenRegion.OUTSIDE_REGION;

            // Define screen regions to check
            Rectangle rectHorizontalRulerLimits = new Rectangle(20, 0, 482, 16);
            Rectangle rectVerticalRulerLimits = new Rectangle(0, 17, 20, 448);
            Rectangle rectScreenLimits = new Rectangle(screenOffsetX, screenOffsetY, 480 + screenOffsetX, 448 + screenOffsetY);

            if (rectHorizontalRulerLimits.Contains(mouseX, mouseY))
            {
                // Mouse is over the horizontal ruler
                region = ScreenRegion.HORIZONTAL_RULER;
            }
            else if (rectVerticalRulerLimits.Contains(mouseX, mouseY))
            {
                // Mouse is over the vertical ruler
                region = ScreenRegion.VERTICAL_RULER;
            }
            else if (rectScreenLimits.Contains(mouseX, mouseY))
            {
                // Mouse is over main screen image
                region = ScreenRegion.SCREEN_DISPLAY;
            }

            return region;
        }

        private ScreenRegion CalculateScreenPosition(int mouseX, int mouseY, ref int screenX, ref int screenY)
        {
            ScreenRegion region = ScreenRegion.OUTSIDE_REGION;

            switch (CheckMouseRegion(mouseX, mouseY))
            {
                case ScreenRegion.HORIZONTAL_RULER:
                    region = ScreenRegion.HORIZONTAL_RULER;

                    // Calculate the screen position in relation to the mouse pointer
                    screenX = (mouseX - screenOffsetX) / 12;
                    screenY = mouseY / 16;
                    break;

                case ScreenRegion.VERTICAL_RULER:
                    region = ScreenRegion.VERTICAL_RULER;

                    // Calculate the screen position in relation to the mouse pointer
                    screenX = mouseX / 12;
                    screenY = (mouseY - screenOffsetY) / 16;
                    break;

                case ScreenRegion.SCREEN_DISPLAY:
                    region = ScreenRegion.SCREEN_DISPLAY;

                    // Calculate the screen position in relation to the mouse pointer
                    screenX = (mouseX - screenOffsetX) / 12;
                    screenY = (mouseY - screenOffsetY) / 16;

                    if(loadedProgram.StartAddress == 0xBB80)
                    {
                        screenY--;
                    }
                    break;

                default:
                    // Mouse is outside our defined areas
                    region = ScreenRegion.OUTSIDE_REGION;

                    screenX = -1;
                    screenY = -1;
                    break;
            }

            return region;
        }

        public void BuildCharSet()
        {
            int iBufferLen = Properties.Resources.StdCharSet.Length;

            stdCharSet = new byte[iBufferLen];

            Properties.Resources.StdCharSet.CopyTo(stdCharSet, 0);
        }

        private int CalcMemoryAddress()
        {
            int iAddress = 0;
            iAddress = 0xBBA8 + ((scrnRow * 40) + scrnCol);

            return iAddress;
        }

        private void UpdateScreenMemory(int iAddress, byte bNewValue)
        {
            // Update form title to indicate amendments have been made
            bScrnUpdated = true;
            Text = string.Format("Text Screen Editor - [{0}]*", fileInfo.ProgramName);

            int iIndex = iAddress - fileInfo.StartAddress;

            bScrnData[iIndex] = bNewValue;

            DrawTextPreview(screenImage);
            picEditor.Image = screenImage;

            UpdateStandardImage();
        }
    }
}