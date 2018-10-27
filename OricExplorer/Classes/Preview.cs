using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace OricExplorer
{
    class Preview
    {
        public Byte[] bScrnData;

        public OricProgram.ProgramFormat m_scrnFormat;

        private UInt16 m_ui16DisplayBytes;
        private UInt16 m_ui16ScreenHeight;

        public UInt16 m_ui16DataLength;
        public UInt16 m_ui16Offset;
        public UInt16 m_ui16StartAddress;

        public Byte cScrnPaper;
        public Byte cScrnInk;
        public Byte cResult;

        public Byte m_bWidthBytes;

        public Boolean m_bDisablePaper;
        public Boolean m_bDisableInk;
        public Boolean m_bDisableAttributes;
        public Boolean m_bFlash;

        public Byte[] stdCharSet;

        PrintPageEventArgs printEventArgs;

        Image imageFile;
        
        // Contains the image data
        public Image screenImage;

        public Preview(Boolean bPreview)
        {
            m_ui16DataLength = 0;
            m_ui16StartAddress = 0;

            // Set initial format to HIRES
            m_scrnFormat = OricProgram.ProgramFormat.HiresScreen;

            // Initialise the screen buffer
            bScrnData = new Byte[8000];

            // Load the standard character set
            BuildCharSet();

            cScrnPaper = 0;
            cScrnInk = 7;

            m_bDisablePaper = false;
            m_bDisableInk = false;
            m_bDisableAttributes = false;

            m_bFlash = true;

            m_bWidthBytes = 40;

            if(bPreview)
            {
                screenImage = new Bitmap(480, 448);
            }
        }

        public void PrintScreen(ref PrintPageEventArgs e)
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
            else if (m_scrnFormat == OricProgram.ProgramFormat.CharacterSet)
            {
                PrintCharSet();
            }

            e.HasMorePages = false;
        }

        public void PrintTextScreen()
        {
            Byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            short siStart = 0;
            short siLimit = 0;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;
            UInt16 ui16DataLength = 0;

            //Boolean bDoubleHeight = false;
            //Boolean bBlink = false;

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
                        cScrnPaper = (Byte)(cByte - 16);

                        short siWidth = (Byte)((40 - ui16ByteCount) * 6);

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
                            Byte cBit = (Byte)(siPattern << (siLoop3));

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
            Byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;
            UInt16 ui16DataLength = 0;

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
                        cScrnPaper = (Byte)(cByte - 16);

                        short siWidth = (Byte)((40 - ui16ByteCount) * 6);

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
                        Byte cBit = (Byte)(cByte << (siLoop2));

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
            Byte cByte = 0;

            short siXPos = 5;
            short siYPos = 5;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;
            UInt16 ui16DataLength = 0;

            // Create image.
            imageFile = new Bitmap(240, 200);

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 240, 200);

            if (m_ui16DataLength > 800)
                ui16DataLength = 800;
            else
                ui16DataLength = m_ui16DataLength;

            while (ui16Loop < ui16DataLength)
            {
                for (short siLoop2 = 0; siLoop2 < 8; siLoop2++)
                {
                    cByte = bScrnData[ui16Loop + siLoop2];
                    short siPattern = cByte;

                    for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                    {
                        Byte cBit = (Byte)(siPattern << (siLoop3));
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
            m_ui16DisplayBytes = (UInt16)(m_ui16DataLength - m_ui16Offset);

            // Calculate height of Bitmap
            UInt16 ui16Rows = (UInt16)(m_ui16DisplayBytes / m_bWidthBytes);

            if (ui16Rows < 1)
            {
                ui16Rows = 1;
            }

            m_ui16ScreenHeight = (UInt16)(ui16Rows * 2);

            if(m_scrnFormat != OricProgram.ProgramFormat.HiresScreen)
            {
                m_ui16ScreenHeight = (UInt16)(m_ui16ScreenHeight * 16);
            }

            //if(m_ui16ScreenHeight < 448)
            //{
            //    m_ui16ScreenHeight = 448;
            //}

            screenImage = new Bitmap(m_bWidthBytes * 12, m_ui16ScreenHeight);

            switch(m_scrnFormat)
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
            m_bDisablePaper = false;
            m_bDisableInk = false;
            m_bDisableAttributes = false;

            m_bWidthBytes = 40;
            m_ui16ScreenHeight = 224;
            m_ui16Offset = 0;

            switch(m_scrnFormat)
            {
                case OricProgram.ProgramFormat.HiresScreen:
                    if(m_ui16DataLength > 8000)
                        m_ui16DisplayBytes = 8000;
                    else
                        m_ui16DisplayBytes = m_ui16DataLength;

                    DrawHiresPreview();
                    break;

                case OricProgram.ProgramFormat.WindowFile:
                case OricProgram.ProgramFormat.TextScreen:
                    if(m_ui16DataLength > 1120)
                        m_ui16DisplayBytes = 1120;
                    else
                        m_ui16DisplayBytes = m_ui16DataLength;

                    DrawTextPreview();
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    if(m_ui16DataLength > 800)
                        m_ui16DisplayBytes = 800;
                    else
                        m_ui16DisplayBytes = m_ui16DataLength;

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
            Graphics newGraphics = Graphics.FromImage(screenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 240, 224);
            newGraphics.DrawRectangle(new Pen(Color.Yellow), 0, 0, 239, 223);

            String strMessage = "No Preview Available";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(0, 255, 0));

            SizeF stringSize = new SizeF();
            stringSize = newGraphics.MeasureString(strMessage, drawFont);

            // Calc position of text so that it is centred
            float x = (screenImage.Width / 2) - (stringSize.Width / 2);
            float y = (screenImage.Height / 2) - (stringSize.Height / 2);

            // Draw string to screen.
            newGraphics.DrawString(strMessage, drawFont, drawBrush, x, y);

            // Dispose of graphics object.
            newGraphics.Dispose();
        }

        private void DrawHiresPreview()
        {
            Byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // Fill entire image with black background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, m_bWidthBytes * 12, m_ui16ScreenHeight);

            ui16Loop = m_ui16Offset;

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
                        cScrnPaper = (Byte)(cByte - 16);

                        short siWidth = (short)((80 - ui16ByteCount) * 12);

                        if(!m_bDisablePaper)
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
                        Byte cBit = (Byte)(cByte << (siLoop2));

                        cResult = Convert.ToByte(0x80 & cBit);

                        if(cResult == 0x80)
                        {
                            if(!m_bDisableInk)
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

                if(ui16ByteCount == m_bWidthBytes)
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
            Byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            short siStart = 0;
            short siLimit = 0;
            short siLine = 0;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;

            Boolean bDoubleHeight = false;
            Boolean bBlink = false;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            cScrnPaper = 0;
            cScrnInk = 7;

            // Fill entire image with white background.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, m_bWidthBytes * 12, m_ui16ScreenHeight);

            if(m_ui16StartAddress == 0xBB80)
            {
                siLine = -1;
            }
            else
            {
                siLine = (short)((m_ui16StartAddress - 0xBBA8) / 40);
            }

            ui16Loop = m_ui16Offset;

            while(ui16Loop < m_ui16DisplayBytes)
            {
                cByte = bScrnData[ui16Loop];

                if(m_bWidthBytes == 40)
                {
                    if(ui16ByteCount == 0 && (cByte < 16 || cByte > 23))
                    {
                        cScrnPaper = 0;

                        if(!m_bDisablePaper)
                        {
                            newGraphics.FillRectangle(new SolidBrush(Color.Black), siXPos, siYPos, m_bWidthBytes * 12, 16);
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
                        cScrnPaper = (Byte)(cByte - 16);

                        short siWidth = (short)((40 - ui16ByteCount) * 12);

                        if(!m_bDisablePaper)
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
                            Byte cBit = (Byte)(siPattern << (siLoop3));

                            cResult = Convert.ToByte(0x80 & cBit);

                            if(cResult == 0x80)
                            {
                                short siPixelHeight = 2;

                                if (bDoubleHeight)
                                    siPixelHeight = 4;

                                if(!m_bDisableInk)
                                {
                                    if (bBlink)
                                    {
                                        if (m_bFlash)
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
                if(ui16ByteCount == m_bWidthBytes)
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
            Byte cByte = 0;

            short siXPos = 0;
            short siYPos = 0;

            UInt16 ui16Loop = 0;
            UInt16 ui16ByteCount = 0;

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(screenImage);
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

            ui16Loop = m_ui16Offset;

            // Draw each character in grid layout
            while(ui16Loop < m_ui16DisplayBytes)
            {
                if (ui16Loop + 8 < bScrnData.Length)
                {
                    for (short siLoop2 = 0; siLoop2 < 8; siLoop2++)
                    {
                        cByte = bScrnData[ui16Loop + siLoop2];
                        short siPattern = cByte;

                        for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                        {
                            Byte cBit = (Byte)(siPattern << (siLoop3));
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

        private Color Colour(Byte cIndex)
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

        public void BuildCharSet()
        {
            int iBufferLen = Properties.Resources.StdCharSet.Length;

            stdCharSet = new Byte[iBufferLen];

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
                    String strImgName = dlgSave.FileName;

                    if (strImgName.EndsWith("jpg") || strImgName.EndsWith("jpeg"))
                        screenImage.Save(strImgName, ImageFormat.Jpeg);

                    if (strImgName.EndsWith("gif"))
                        screenImage.Save(strImgName, ImageFormat.Gif);

                    if (strImgName.EndsWith("bmp"))
                        screenImage.Save(strImgName, ImageFormat.Bmp);

                    if (strImgName.EndsWith("png"))
                        screenImage.Save(strImgName, ImageFormat.Png);

                    if (strImgName.EndsWith("tif") || strImgName.EndsWith("tiff"))
                        screenImage.Save(strImgName, ImageFormat.Tiff);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
