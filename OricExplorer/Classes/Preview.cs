namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.Text;
    using System.Windows.Forms;

    class Preview
    {
        public byte[] ScreenData { get; set; }

        public OricProgram.ProgramFormat ScreenFormat { get; set; }

        private ushort m_ui16DisplayBytes;
        private ushort m_ui16ScreenHeight;

        private byte cScrnPaper;
        private byte cScrnInk;
        private byte cResult;

        private byte[] stdCharSet;

        private PrintPageEventArgs printEventArgs;

        private Image imageFile;
        
        public ushort DataLength { get; set; }
        public ushort Offset { get; set; }
        public ushort StartAddress { get; set; }

        public byte WidthBytes { get; set; }

        public bool DisablePaper { get; set; }
        public bool DisableInk { get; set; }
        public bool DisableAttributes { get; set; }
        public bool Flash { get; set; }

        // Contains the image data
        public Image ScreenImage { get; set; }

        public Preview(bool bPreview)
        {
            DataLength = 0;
            StartAddress = 0;

            // Set initial format to HIRES
            ScreenFormat = OricProgram.ProgramFormat.HiresScreen;

            // Initialise the screen buffer
            ScreenData = new byte[8000];

            // Load the standard character set
            BuildCharSet();

            cScrnPaper = 0;
            cScrnInk = 7;

            DisablePaper = false;
            DisableInk = false;
            DisableAttributes = false;

            Flash = true;

            WidthBytes = 40;

            if(bPreview)
            {
                ScreenImage = new Bitmap(480, 448);
            }
        }

        public void PrintScreen(ref PrintPageEventArgs e)
        {
            printEventArgs = e;

            if (ScreenFormat == OricProgram.ProgramFormat.HiresScreen)
            {
                PrintHiresScreen();
            }
            else if (ScreenFormat == OricProgram.ProgramFormat.TextScreen)
            {
                PrintTextScreen();
            }
            else if (ScreenFormat == OricProgram.ProgramFormat.CharacterSet)
            {
                PrintCharSet();
            }

            e.HasMorePages = false;
        }

        public void PrintTextScreen()
        {
            byte cByte;

            short siXPos = 0;
            short siYPos = 0;

            short siStart;
            short siLimit;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;
            ushort ui16DataLength;

            //bool bDoubleHeight = false;
            //bool bBlink = false;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 240, 200);

            if (DataLength > 1000)
                ui16DataLength = 1000;
            else
                ui16DataLength = DataLength;

            while (ui16Loop < ui16DataLength)
            {
                cByte = ScreenData[ui16Loop];

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
                        short siPattern = stdCharSet[iIndex + siLoop2];

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
        }

        public void PrintHiresScreen()
        {
            byte cByte;

            short siXPos = 0;
            short siYPos = 0;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;
            ushort ui16DataLength;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 200);

            if (DataLength > 8000)
                ui16DataLength = 8000;
            else
                ui16DataLength = DataLength;

            while (ui16Loop < ui16DataLength)
            {
                cByte = ScreenData[ui16Loop];

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
        }

        public void PrintCharSet()
        {
            byte cByte;

            short siXPos = 5;
            short siYPos = 5;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;
            ushort ui16DataLength;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 240, 200);

            if (DataLength > 800)
                ui16DataLength = 800;
            else
                ui16DataLength = DataLength;

            while (ui16Loop < ui16DataLength)
            {
                for (short siLoop2 = 0; siLoop2 < 8; siLoop2++)
                {
                    cByte = ScreenData[ui16Loop + siLoop2];
                    short siPattern = cByte;

                    for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                    {
                        byte cBit = (byte)(siPattern << (siLoop3));
                        cResult = Convert.ToByte(0x80 & cBit);

                        if (cResult == 0x80)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos + (siLoop3 - 2), siYPos + siLoop2, 1, 1);
                        }
                    }
                }

                siXPos += 8;

                ui16ByteCount++;

                // Have we drawn 40 characters?
                if (ui16ByteCount == 29)
                {
                    // Reset X position back to start of line
                    siXPos = 5;

                    // Increment Y position to next line down
                    siYPos += 10;

                    // Reset counter
                    ui16ByteCount = 0;
                }

                ui16Loop += 8;
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
        }

        public void DrawDataView()
        {
            m_ui16DisplayBytes = (ushort)(DataLength - Offset);

            // Calculate height of Bitmap
            ushort ui16Rows = (ushort)(m_ui16DisplayBytes / WidthBytes);

            if (ui16Rows < 1)
            {
                ui16Rows = 1;
            }

            m_ui16ScreenHeight = (ushort)(ui16Rows * 2);

            if(ScreenFormat != OricProgram.ProgramFormat.HiresScreen)
            {
                m_ui16ScreenHeight = (ushort)(m_ui16ScreenHeight * 16);
            }

            //if(m_ui16ScreenHeight < 448)
            //{
            //    m_ui16ScreenHeight = 448;
            //}

            ScreenImage = new Bitmap(WidthBytes * 12, m_ui16ScreenHeight);

            switch(ScreenFormat)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    DrawHiresPreview();
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                    DrawTextPreview();
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    DrawCharSetPreview();
                    break;

                default:
                    NoPreview();
                    break;
            }
        }

        public void DrawPreview()
        {
            DisablePaper = false;
            DisableInk = false;
            DisableAttributes = false;

            WidthBytes = 40;
            m_ui16ScreenHeight = 224;
            Offset = 0;

            switch(ScreenFormat)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    if(DataLength > 8000)
                        m_ui16DisplayBytes = 8000;
                    else
                        m_ui16DisplayBytes = DataLength;

                    DrawHiresPreview();
                    break;

                case OricProgram.ProgramFormat.WindowFile:
                case OricProgram.ProgramFormat.TextScreen:
                    if(DataLength > 1120)
                        m_ui16DisplayBytes = 1120;
                    else
                        m_ui16DisplayBytes = DataLength;

                    DrawTextPreview();
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    if(DataLength > 800)
                        m_ui16DisplayBytes = 800;
                    else
                        m_ui16DisplayBytes = DataLength;

                    DrawCharSetPreview();
                    break;

                default:
                    NoPreview();
                    break;
            }
        }

        private void NoPreview()
        {
            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(ScreenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 224);
            newGraphics.DrawRectangle(new Pen(Color.Yellow), 0, 0, 239, 223);

            string strMessage = "No Preview Available";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 255, 0));

            SizeF stringSize = new SizeF();
            stringSize = newGraphics.MeasureString(strMessage, drawFont);

            // Calc position of text so that it is centred
            float x = (ScreenImage.Width / 2) - (stringSize.Width / 2);
            float y = (ScreenImage.Height / 2) - (stringSize.Height / 2);

            // Draw string to screen.
            newGraphics.DrawString(strMessage, drawFont, drawBrush, x, y);

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawHiresPreview()
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 2;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(ScreenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, WidthBytes * 12, m_ui16ScreenHeight);

            ui16Loop = Offset;

            while(ui16Loop < m_ui16DisplayBytes)
            {
                cByte = ScreenData[ui16Loop];

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

                        short siWidth = (short)((80 - ui16ByteCount) * 12);

                        if(!DisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, 2);
                        }
                    }

                    cByte = 0;

                    siXPos += 12;
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
                            if(!DisableInk)
                            {
                                newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, 2, 2);
                            }
                            else
                            {
                                newGraphics.FillRectangle(new SolidBrush(Colour(7)), siXPos, siYPos, 2, 2);
                            }
                        }

                        siXPos += 2;
                    }
                }

                ui16ByteCount++;

                if(ui16ByteCount == WidthBytes)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += 2;

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

        private void DrawTextPreview()
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            short siStart = 0;
            short siLimit = 0;
            short siLine = 0;

            ushort ui16Loop;
            ushort ui16ByteCount = 0;

            bool bDoubleHeight = false;
            bool bBlink = false;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(ScreenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            cScrnPaper = 0;
            cScrnInk = 7;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, WidthBytes * 12, m_ui16ScreenHeight);

            if(StartAddress == 0xBB80)
            {
                siLine = -1;
            }
            else
            {
                siLine = (short)((StartAddress - 0xBBA8) / 40);
            }

            ui16Loop = Offset;

            while(ui16Loop < m_ui16DisplayBytes)
            {
                cByte = ScreenData[ui16Loop];

                if(WidthBytes == 40)
                {
                    if(ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                    {
                        cScrnPaper = 0;

                        if(!DisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, WidthBytes * 12, 16);
                        }

                        if (cByte >= 0 && cByte <= 7)
                        {
                            cScrnInk = cByte;
                        }
                    }
                }

                if(ui16ByteCount == 1 && cByte > 7)
                {
                    cScrnInk = 7;
                }

                cResult = Convert.ToByte(0x40 & cByte);

                if(cByte < 32)
                {
                    if(cByte >= 16 && cByte <= 23)
                    {
                        cScrnPaper = (byte)(cByte - 16);

                        short siWidth = (short)((40 - ui16ByteCount) * 12);

                        if(!DisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnPaper)), siXPos, siYPos, siWidth, 16);
                        }
                    }
                    else if(cByte >= 0 && cByte <= 7)
                    {
                        cScrnInk = cByte;
                    }
                    else
                    {
                        if (!DisableAttributes)
                        {
                            if (cByte.In((byte)0x08, (byte)0x09, (byte)0x0C, (byte)0x0D))
                                bDoubleHeight = false;

                            if (cByte.In((byte)0x0A, (byte)0x0B, (byte)0x0E, (byte)0x0F))
                                bDoubleHeight = true;

                            if (cByte.In((byte)0x08, (byte)0x09, (byte)0x0A, (byte)0x0B))
                                bBlink = false;

                            if (cByte.In((byte)0x0C, (byte)0x0D, (byte)0x0E, (byte)0x0F))
                                bBlink = true;
                        }
                        else
                        {
                            bDoubleHeight = false;
                            bBlink = false;
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
                        if(cByte > 0x7F)
                        {
                            cByte = 32;
                        }

                        int iIndex = (cByte - 32) * 8;
                        short siPattern = stdCharSet[iIndex + siLoop2];

                        for(short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            byte cBit = (byte)(siPattern << (siLoop3));

                            cResult = Convert.ToByte(0x80 & cBit);

                            if(cResult == 0x80)
                            {
                                short siPixelHeight = 2;

                                if (bDoubleHeight)
                                    siPixelHeight = 4;

                                if(!DisableInk)
                                {
                                    if (bBlink)
                                    {
                                        if (Flash)
                                            newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, 2, siPixelHeight);
                                    }
                                    else
                                    {
                                        newGraphics.FillRectangle(new SolidBrush(Colour(cScrnInk)), siXPos, siYPos, 2, siPixelHeight);
                                    }
                                }
                                else
                                {
                                    newGraphics.FillRectangle(new SolidBrush(Colour(7)), siXPos, siYPos, 2, siPixelHeight);
                                }
                            }

                            siXPos += 2;
                        }

                        siXPos -= 12;
                        siYPos += 2;

                        if (bDoubleHeight)
                            siYPos += 2;
                    }

                    siYPos -= 16;
                }

                siXPos += 12;

                ui16ByteCount++;

                // Have we drawn one whole TEXT line?
                if(ui16ByteCount == WidthBytes)
                {
                    // Reset X position back to start of line
                    siXPos = 0;

                    // Increment Y position to next line down
                    siYPos += 16;

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

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawCharSetPreview()
        {
            byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            ushort ui16Loop = 0;
            ushort ui16ByteCount = 0;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(ScreenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 480, m_ui16ScreenHeight);

            siYPos = 0;

            // Draw background for each character
            for (int OuterLoop = 0; OuterLoop < (m_ui16ScreenHeight / 18); OuterLoop++)
            {
                siXPos = 0;

                for (int InnerLoop = 0; InnerLoop < (480 / 14); InnerLoop++)
                {
                    newGraphics.FillRectangle(new SolidBrush(Color.FromArgb(227,227,227)), siXPos, siYPos, 12, 16);
                    siXPos += 14;
                }

                siYPos += 18;
            }

            // Reset X and Y variables
            siXPos = 0;
            siYPos = 0;

            ui16Loop = Offset;

            // Draw each character in grid layout
            while(ui16Loop < m_ui16DisplayBytes)
            {
                if (ui16Loop + 8 < ScreenData.Length)
                {
                    for (short siLoop2 = 0; siLoop2 < 8; siLoop2++)
                    {
                        cByte = ScreenData[ui16Loop + siLoop2];
                        short siPattern = cByte;

                        for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            byte cBit = (byte)(siPattern << (siLoop3));
                            cResult = Convert.ToByte(0x80 & cBit);

                            if (cResult == 0x80)
                            {
                                newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, 2, 2);
                            }

                            siXPos += 2;
                        }

                        siXPos -= 12;
                        siYPos += 2;
                    }

                    siYPos -= 16;
                    siXPos += 14;

                    ui16ByteCount++;

                    // Have we drawn 40 characters?
                    if (ui16ByteCount == (480 / 14))
                    {
                        // Reset X position back to start of line
                        siXPos = 0;

                        // Increment Y position to next line down
                        siYPos += 18;

                        // Reset counter
                        ui16ByteCount = 0;
                    }
                }

                ui16Loop += 8;
            }

            // Dispose of graphics object.
            newGraphics.Dispose();
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

        public void BuildCharSet()
        {
            int iBufferLen = Properties.Resources.StdCharSet.Length;

            stdCharSet = new byte[iBufferLen];

            Properties.Resources.StdCharSet.CopyTo(stdCharSet, 0);
        }

        public void SaveScreen()
        {
            try
            {
                SaveFileDialog dlgSave = new SaveFileDialog();

                StringBuilder strFilter = new StringBuilder();
                strFilter.Append("JPEG Images (*.jpg,*.jpeg)|*.jpg;*.jpeg|");
                strFilter.Append("GIF Images (*.gif)|*.gif|");
                strFilter.Append("Bitmaps (*.bmp)|*.bmp|");
                strFilter.Append("PNG Images (*.png)|*.png|");
                strFilter.Append("TIFF Images (*.tif,*.tiff)|*.tif;*.tiff");

                dlgSave.Filter = strFilter.ToString();

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    string strImgName = dlgSave.FileName;

                    if (strImgName.EndsWith("jpg") || strImgName.EndsWith("jpeg"))
                        ScreenImage.Save(strImgName, ImageFormat.Jpeg);

                    if (strImgName.EndsWith("gif"))
                        ScreenImage.Save(strImgName, ImageFormat.Gif);

                    if (strImgName.EndsWith("bmp"))
                        ScreenImage.Save(strImgName, ImageFormat.Bmp);

                    if (strImgName.EndsWith("png"))
                        ScreenImage.Save(strImgName, ImageFormat.Png);

                    if (strImgName.EndsWith("tif") || strImgName.EndsWith("tiff"))
                        ScreenImage.Save(strImgName, ImageFormat.Tiff);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
