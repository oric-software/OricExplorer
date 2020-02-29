namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    class ScreenImage
    {
        public enum ScreenImageSize { IMAGE_SIZE_NORMAL, IMAGE_SIZE_ENLARGED };
        public enum ScreenImageFormat { IMAGE_FORMAT_TEXT, IMAGE_FORMAT_HIRES, IMAGE_FORMAT_UNKNOWN };

        public byte[] bScrnData;

        public OricProgram.ProgramFormat m_scrnFormat;

        private ScreenImageSize screenImageSize = ScreenImageSize.IMAGE_SIZE_ENLARGED;
        private ScreenImageFormat screenImageFormat = ScreenImageFormat.IMAGE_FORMAT_TEXT;

        public ushort m_ui16DataLength;
        private ushort m_ui16DisplayBytes;
        public ushort m_ui16StartAddress;

        public byte cScrnPaper;
        public byte cScrnInk;
        public byte cResult;

        public byte m_bWidthBytes;

        public bool m_bDisablePaper;
        public bool m_bDisableInk;
        public bool m_bFlash;
        public bool m_bDisableAttributes;
        public bool bShowAttrIndicator;
        public bool imageSizeNormal;

        public byte[] standardCharacterSet;

        private bool showGrid = false;
        
        // Contains the image data
        public Image screenImageData;

        // Image dimension defaults
        ushort imageWidth = 240;
        ushort imageHeight = 224;

        int pixelWidth = 1;
        int pixelHeight = 1;

        // Used by the Screen viewer
        public int cursXPos;
        public int cursYPos;

        public ScreenImage()
        {
            // Set initial value for showGrid
            showGrid = false;

            m_ui16DataLength = 0;
            m_ui16StartAddress = 0;

            // Initialise the screen buffer
            bScrnData = new byte[8000];

            // Generate the Standard Character Set
            GenerateStandardCharacterSet();

            cScrnPaper = 0;
            cScrnInk = 7;

            m_bDisablePaper = false;
            m_bDisableInk = false;

            m_bFlash = true;

            bShowAttrIndicator = false;
            m_bDisableAttributes = false;

            m_bWidthBytes = 40;
            imageSizeNormal = true;

            cursXPos = -1;
            cursYPos = -1;
        }

        #region Screen Image Drawing Functions
        public void DrawScreenImage()
        {
            DrawScreenImage(screenImageSize, screenImageFormat);
        }

        public void DrawScreenImage(ScreenImageSize imageSize, ScreenImageFormat imageFormat)
        {
            screenImageSize = imageSize;
            screenImageFormat = imageFormat;

            // Set the image and pixel dimensions
            if (screenImageSize == ScreenImageSize.IMAGE_SIZE_NORMAL)
            {
                imageWidth = 240;
                imageHeight = 224;
                pixelWidth = 1;
                pixelHeight = 1;
            }
            else if (screenImageSize == ScreenImageSize.IMAGE_SIZE_ENLARGED)
            {
                imageWidth = 480;
                imageHeight = 448;
                pixelWidth = 2;
                pixelHeight = 2;
            }

            if (screenImageFormat == ScreenImageFormat.IMAGE_FORMAT_TEXT)
            {
                m_scrnFormat = OricProgram.ProgramFormat.TextScreen;
            }
            else if (screenImageFormat == ScreenImageFormat.IMAGE_FORMAT_HIRES)
            {
                m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;
            }
            else
            {
                m_scrnFormat = OricProgram.ProgramFormat.UnknownFile;
            }

            screenImageData = new Bitmap(imageWidth, imageHeight);

            switch(m_scrnFormat)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    if(m_ui16DataLength > 8000)
                        m_ui16DisplayBytes = 8000;
                    else
                        m_ui16DisplayBytes = m_ui16DataLength;

                    DrawHiresScreen();
                    break;

                case OricProgram.ProgramFormat.WindowFile:
                case OricProgram.ProgramFormat.TextScreen:
                    if(m_ui16DataLength > 1120)
                        m_ui16DisplayBytes = 1120;
                    else
                        m_ui16DisplayBytes = m_ui16DataLength;

                    DrawTextScreen();
                    break;
 
                default:
                    DrawNoImageMessage();
                    break;
            }
        }

        private void DrawNoImageMessage()
        {
            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImageData);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 224);
            newGraphics.DrawRectangle(new Pen(Color.Yellow), 0, 0, 239, 223);

            string strMessage = "No Image Available";

            // Create font and brush.
            Font drawFont = new Font("Arial", 14);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

            SizeF stringSize = newGraphics.MeasureString(strMessage, drawFont);

            // Calc position of text so that it is centred
            float x = (screenImageData.Width / 2) - (stringSize.Width / 2);
            float y = (screenImageData.Height / 2) - (stringSize.Height / 2);

            // Draw string to screen.
            newGraphics.DrawString(strMessage, drawFont, drawBrush, x, y);

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawHiresScreen()
        {
            byte cByte;

            short siXPos = 0;
            short siYPos = 0;

            ushort ui16Loop;
            ushort ui16ByteCount = 0;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImageData);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, imageWidth, imageHeight);

            ui16Loop = 0;

            while(ui16Loop < m_ui16DisplayBytes)
            {
                cByte = bScrnData[ui16Loop];

                cResult = Convert.ToByte(0x40 & cByte);

                if(cResult != 0x40)
                {
                    // Convert attribute to a Paper or Ink value
                    if(cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else if(cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        short siWidth = (short)(((imageWidth / 6) - ui16ByteCount) * (pixelWidth * 6));

                        if (!m_bDisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, pixelHeight);
                        }
                    }

                    siXPos += (short)(pixelWidth * 6);
                }
                else
                {
                    // Graphics
                    for(short siLoop2 = 2; siLoop2 < 8; siLoop2++)
                    {
                        byte cBit = (byte)(cByte << (siLoop2));

                        cResult = Convert.ToByte(0x80 & cBit);

                        if(cResult == 0x80)
                        {
                            if (!m_bDisableInk)
                            {
                                newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, pixelWidth, pixelHeight);
                            }
                            else
                            {
                                newGraphics.FillRectangle(new SolidBrush(Colour(7)), siXPos, siYPos, pixelWidth, pixelHeight);
                            }
                        }

                        siXPos += (short)pixelWidth;
                    }
                }

                ui16ByteCount++;

                if(ui16ByteCount == m_bWidthBytes)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += (short)pixelHeight;

                    // Reset counter
                    ui16ByteCount = 0;

                    cScrnPaper = 0;
                    cScrnInk = 7;
                }

                ui16Loop++;
            }

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawTextScreen()
        {
            byte cByte;

            short siXPos = 0;
            short siYPos;

            short siStart;
            short siLimit;
            short siLine;

            ushort ui16Loop;
            ushort ui16ByteCount = 0;

            bool bDoubleHeight = false;
            bool bBlink = false;

            int cursorAddress = -1;

            if (cursXPos != -1 && cursYPos != -1)
            {
                cursorAddress = 0xBB80 + ((cursYPos * 40) + cursXPos);
            }

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImageData);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            cScrnPaper = 0;
            cScrnInk = 7;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, imageWidth, imageHeight);

            if(m_ui16StartAddress == 0xBB80)
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

            while(ui16Loop < m_ui16DisplayBytes)
            {
                cByte = bScrnData[ui16Loop];

                if(ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                {
                    cScrnPaper = 0;

                    if (!m_bDisablePaper)
                    {
                        newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, imageWidth, pixelHeight * 8);
                    }

                    if(cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                }

                cResult = Convert.ToByte(0x40 & cByte);

                if(cByte < 32)
                {
                    if(cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        short siWidth = (short)(((imageWidth / 6) - ui16ByteCount) * (pixelWidth * 6));

                        if (!m_bDisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, pixelHeight * 8);
                        }
                    }
                    else if(cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else
                    {
                        if (!m_bDisableAttributes)
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
                        else
                        {
                            bDoubleHeight = false;
                            bBlink = false;
                        }
                    }

                    if (bShowAttrIndicator)
                    {
                        if ((cByte >= 8 && cByte <= 15) || (cByte >= 0 && cByte <= 7) || (cByte >= 16 && cByte <= 23))
                        {
                            // Draw indicator to show cell is an attribute
                            if (!m_bDisablePaper)
                            {
                                newGraphics.DrawString("A", new Font("Arial", 6), new SolidBrush(Color.Black), siXPos + 1, siYPos + 1);
                                newGraphics.DrawString("A", new Font("Arial", 6), new SolidBrush(Color.White), siXPos, siYPos);
                            }
                            else
                            {
                                newGraphics.DrawString("A", new Font("Arial", 6), new SolidBrush(Color.Yellow), siXPos, siYPos);
                            }
                        }
                    }
                }
                else
                {
                    siStart = 0;
                    siLimit = 8;

                    short siRemainder;

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
                        if(cByte > 0x7F)
                        {
                            cByte = 32;
                        }

                        int iIndex = (cByte - 32) * 8;
                        short siPattern = standardCharacterSet[iIndex + siLoop2];

                        for(short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            byte cBit = (byte)(siPattern << (siLoop3));

                            cResult = Convert.ToByte(0x80 & cBit);

                            if(cResult == 0x80)
                            {
                                short siPixelHeight = (short)(pixelHeight * 1);

                                if (bDoubleHeight)
                                    siPixelHeight = (short)(pixelHeight * 2);

                                if (!m_bDisableInk)
                                {
                                    if (bBlink)
                                    {
                                        if (m_bFlash)
                                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, pixelWidth, siPixelHeight);
                                    }
                                    else
                                    {
                                        newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, pixelWidth, siPixelHeight);
                                    }
                                }
                                else
                                {
                                    newGraphics.FillRectangle(new SolidBrush(Colour(7)), siXPos, siYPos, pixelWidth, siPixelHeight);
                                }
                            }

                            siXPos += (short)(pixelWidth);
                        }

                        siXPos -= (short)(pixelWidth * 6);
                        siYPos += (short)(pixelHeight);

                        if (bDoubleHeight)
                            siYPos += (short)pixelHeight;
                    }

                    siYPos -= (short)(pixelHeight * 8);
                }

                if (cursorAddress != -1)
                {
                    if ((ui16Loop + m_ui16StartAddress) == cursorAddress)
                    {
                        newGraphics.DrawRectangle(new Pen(Color.Orange), siXPos, siYPos, 11, 15);
                    }
                }

                siXPos += (short)(pixelWidth * 6);

                ui16ByteCount++;

                // Have we drawn one whole TEXT line?
                if(ui16ByteCount == m_bWidthBytes)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += (short)(pixelHeight * 8);

                    // Reset back to single height characters
                    bDoubleHeight = false;

                    // Reset to no blink
                    bBlink = false;

                    // Reset counter
                    ui16ByteCount = 0;
                    //siColumn = 0;

                    // Increment the line counter
                    siLine++;

                    // Reset the Paper and Ink values
                    cScrnInk = 7;
                    cScrnPaper = 0;
                }

                ui16Loop++;
            }

            /*if (showGrid && screenImageSize != ScreenImageSize.IMAGE_SIZE_NORMAL)
            {
                //Pen gridPen = new Pen(Color.FromArgb(175, 175, 175));
                //Pen gridPen = new Pen(Color.FromArgb(237, 236, 239));
                Pen gridPen = new Pen(Color.FromArgb(242, 242, 242));

                for (int columnIndex = 1; columnIndex < 40; columnIndex++)
                {
                    newGraphics.DrawLine(gridPen, (columnIndex * 12) - 1, 0, (columnIndex * 12) - 1, 448);
                }

                for (int rowIndex = 1; rowIndex < 28; rowIndex++)
                {
                    newGraphics.DrawLine(gridPen, 0, (rowIndex * 16) - 1, 480, (rowIndex * 16) - 1);
                }

                gridPen.Dispose();
            }*/

            // Dispose of graphics object.
            newGraphics.Dispose();
        }
        #endregion

        #region Print Screen Image Functions
        /*public void PrintScreen(ref PrintPageEventArgs e)
        {
            printEventArgs = e;

            if (m_scrnFormat == OricProgram.ProgramFormat.HiresScreen)
            {
                PrintHiresScreen();
            }
            else if (m_scrnFormat == OricProgram.ProgramFormat.TextScreen)
            {
                PrintTextScreen();
            }

            e.HasMorePages = false;
        }*/

        /*public void PrintTextScreen()
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            short siStart = 0;
            short siLimit = 0;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;
            ushort ui16DataLength = 0;

            //bool bDoubleHeight = false;
            //bool bBlink = false;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 240, 200);

            if (m_ui16DataLength > 1000)
                ui16DataLength = 1000;
            else
                ui16DataLength = m_ui16DataLength;

            while (ui16Loop < ui16DataLength)
            {
                cByte = bScrnData[ui16Loop];

                if (ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                {
                    cScrnPaper = 0;
                    newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, 240, 8);
                }

                if (ui16ByteCount == 1 && cByte > 7)
                {
                    cScrnInk = 7;
                }

                cResult = Convert.ToByte(0x40 & cByte);

                if (cByte < 32)
                {
                    if (cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        short siWidth = (byte)((40 - ui16ByteCount) * 6);

                        newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, 8);
                    }
                    else if (cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else
                    {
                        //if(cByte == 0x08 || cByte == 0x09 || cByte == 0x0C || cByte == 0x0D)
                        //{
                        //    bDoubleHeight = false;
                        //}

                        //if(cByte == 0x0A || cByte == 0x0B || cByte == 0x0E || cByte == 0x0F)
                        //{
                        //    bDoubleHeight = true;
                        //}

                        //if(cByte == 0x08 || cByte == 0x09 || cByte == 0x0A || cByte == 0x0B)
                        //{
                        //    bBlink = false;
                        //}

                        //if(cByte == 0x0C || cByte == 0x0D || cByte == 0x0E || cByte == 0x0F)
                        //{
                        //    bBlink = true;
                        //}
                    }
                }
                else
                {
                    siStart = 0;
                    siLimit = 8;

                    for (short siLoop2 = siStart; siLoop2 < siLimit; siLoop2++)
                    {
                        if (cByte > 0x7F)
                        {
                            cByte = 32;
                        }

                        int iIndex = (cByte - 32) * 8;
                        short siPattern = standardCharacterSet[iIndex + siLoop2];

                        for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            byte cBit = (byte)(siPattern << (siLoop3));

                            cResult = Convert.ToByte(0x80 & cBit);

                            if (cResult == 0x80)
                            {
                                newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, 1, 1);
                            }

                            siXPos++;
                        }

                        siXPos -= 6;
                        siYPos += 1;
                    }

                    siYPos -= 8;
                }

                siXPos += 6;

                ui16ByteCount++;

                // Have we drawn one whole TEXT line?
                if (ui16ByteCount == 40)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += 8;

                    // Reset back to single height characters
                    //bDoubleHeight = false;

                    // Reset to no blink
                    //bBlink = false;

                    // Reset counter
                    ui16ByteCount = 0;
                    //siColumn = 0;

                    // Increment the line counter
                    //siLine++;
                }

                ui16Loop++;
            }

            // Turn off any antialiasing
            printEventArgs.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            Rectangle rectMargins = printEventArgs.MarginBounds;

            int intNewWidth = rectMargins.Width;
            int intNewHeight = rectMargins.Height;

            float flWidth2Height = 240.0F / 200.0F;
            float flNewWidth2Height = (float)rectMargins.Width / (float)rectMargins.Height;

            if (flWidth2Height > flNewWidth2Height)
            {
                // Horizontal, make height smaller then in spec. Use width to calc the scale
                float flScale = (float)rectMargins.Width / 240.0F;
                intNewHeight = System.Convert.ToInt32(flScale * 200);
            }
            else
            {
                // Vertical, make width smaller then in spec. Use height to calc the scale
                float flScale = (float)rectMargins.Height / 200.0F;
                intNewWidth = System.Convert.ToInt32(flScale * 240);
            }

            // Draw image to fill page
            int iXTemp = (rectMargins.Width * (int)newGraphics.DpiX) / 100;
            int iYTemp = (rectMargins.Height * (int)newGraphics.DpiY) / 100;

            int iCentreXPos = (iXTemp / 2) - (intNewWidth / 2);
            int iCentreYPos = (iYTemp / 2) - (intNewHeight / 2);

            printEventArgs.Graphics.DrawImage(imageFile, iCentreXPos + rectMargins.Left, iCentreYPos + rectMargins.Top, intNewWidth, intNewHeight);

            // Dispose of graphics object.
            newGraphics.Dispose();
        }*/

        /*public void PrintHiresScreen()
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;
            ushort ui16DataLength = 0;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 200);

            if (m_ui16DataLength > 8000)
                ui16DataLength = 8000;
            else
                ui16DataLength = m_ui16DataLength;

            while (ui16Loop < ui16DataLength)
            {
                cByte = bScrnData[ui16Loop];

                if (ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                {
                    cScrnPaper = 0;
                    newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, 240, 1);
                }

                if (ui16ByteCount == 1 && cByte > 7)
                {
                    cScrnInk = 7;
                }

                cResult = Convert.ToByte(0x40 & cByte);

                if (cResult != 0x40)
                {
                    // Convert attribute to a Paper or Ink value
                    if (cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else if (cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        short siWidth = (byte)((40 - ui16ByteCount) * 6);

                        newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, 1);
                    }

                    cByte = 0;

                    siXPos += 6;
                }
                else
                {
                    // Graphics
                    for (short siLoop2 = 2; siLoop2 < 8; siLoop2++)
                    {
                        byte cBit = (byte)(cByte << (siLoop2));

                        cResult = Convert.ToByte(0x80 & cBit);

                        if (cResult == 0x80)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, 1, 1);
                        }

                        siXPos += 1;
                    }
                }

                ui16ByteCount++;

                if (ui16ByteCount == 40)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += 1;

                    // Reset counter
                    ui16ByteCount = 0;

                    cScrnPaper = 0;
                    cScrnInk = 7;
                }

                ui16Loop++;
            }

            // Turn off any antialiasing
            printEventArgs.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            Rectangle rectMargins = printEventArgs.MarginBounds;

            int intNewWidth = rectMargins.Width;
            int intNewHeight = rectMargins.Height;

            float flWidth2Height = 240.0F / 200.0F;
            float flNewWidth2Height = (float)rectMargins.Width / (float)rectMargins.Height;

            if (flWidth2Height > flNewWidth2Height)
            {
                // Horizontal, make height smaller then in spec. Use width to calc the scale
                float flScale = (float)rectMargins.Width / 240.0F;
                intNewHeight = System.Convert.ToInt32(flScale * 200);
            }
            else
            {
                // Vertical, make width smaller then in spec. Use height to calc the scale
                float flScale = (float)rectMargins.Height / 200.0F;
                intNewWidth = System.Convert.ToInt32(flScale * 240);
            }

            // Draw image to fill page
            int iXTemp = (rectMargins.Width * (int)newGraphics.DpiX) / 100;
            int iYTemp = (rectMargins.Height * (int)newGraphics.DpiY) / 100;

            int iCentreXPos = (iXTemp / 2) - (intNewWidth / 2);
            int iCentreYPos = (iYTemp / 2) - (intNewHeight / 2);

            printEventArgs.Graphics.DrawImage(imageFile, iCentreXPos + rectMargins.Left, iCentreYPos + rectMargins.Top, intNewWidth, intNewHeight);

            // Dispose of graphics object.
            newGraphics.Dispose();
        }*/
        #endregion

        private Color Colour(byte cIndex)
        {
            Color crColour;

            switch(cIndex)
            {
                case 0: crColour = Color.Black; break;
                case 1: crColour = Color.FromArgb(255, 0, 0); break;
                case 2: crColour = Color.FromArgb(0, 255, 0); break;
                case 3: crColour = Color.Yellow; break;
                case 4: crColour = Color.FromArgb(0, 0, 255); break;
                case 5: crColour = Color.Magenta; break;
                case 6: crColour = Color.Cyan; break;
                case 7: crColour = Color.White; break;
                default: crColour = Color.Black; break;
            }

            return crColour;
        }

        public void GenerateStandardCharacterSet()
        {
            standardCharacterSet = new byte[Properties.Resources.StdCharSet.Length];
            Properties.Resources.StdCharSet.CopyTo(standardCharacterSet, 0);
        }

        public void SaveScreen()
        {
            try
            {
                SaveFileDialog dlgSave = new SaveFileDialog();

                StringBuilder strFilter = new StringBuilder();
                strFilter.Append("Bitmaps (*.bmp)|*.bmp|");
                strFilter.Append("GIF Images (*.gif)|*.gif|");
                strFilter.Append("JPEG Images (*.jpg,*.jpeg)|*.jpg;*.jpeg|");
                strFilter.Append("PNG Images (*.png)|*.png|");
                strFilter.Append("TIFF Images (*.tif,*.tiff)|*.tif;*.tiff|");

                dlgSave.Filter = strFilter.ToString();

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    string imageFileName = dlgSave.FileName;
                    string imageFileNameExtension = Path.GetExtension(imageFileName);
                    ImageFormat imageFormat = ImageFormat.Png;

                    switch(imageFileNameExtension)
                    {
                        case "bmp":
                            imageFormat = ImageFormat.Bmp;
                            break;

                        case "gif":
                            imageFormat = ImageFormat.Gif;
                            break;

                        case "jpg":
                        case "jpeg":
                            imageFormat = ImageFormat.Jpeg;
                            break;

                        case "png":
                            imageFormat = ImageFormat.Png;
                            break;

                        case "tif":
                        case "tiff":
                            imageFormat = ImageFormat.Tiff;
                            break;
                    }

                    screenImageData.Save(imageFileName, imageFormat);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public bool ShowGrid
        {
            set { showGrid = value; }
            get { return showGrid; }
        }
    }
}
