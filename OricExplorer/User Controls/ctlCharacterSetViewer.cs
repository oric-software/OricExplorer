namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    // TODO:
    // 1. Print options
    // 2. Create actual data statements (Single characters or entire set)

    public partial class ctlCharacterSetViewerControl : UserControl
    {
        public Label FileInformation;

        // Contains the image data
        private Image charSetImageData;

        private int gridColWidth = 20;
        private int gridRowHeight = 20;

        private int gridXOffset = 21;
        private int gridYOffset = 21;

        public OricFileInfo ProgramInfo;
        public OricProgram ProgramData;

        private Image tmpCharacterGrid;

        public ctlCharacterSetViewerControl()
        {
            InitializeComponent();

            FileInformation = new Label();

            charSetImageData = new Bitmap(picCharSet.Width, picCharSet.Height);
            tmpCharacterGrid = Properties.Resources.CharacterSetViewer;
        }

        public void InitialiseView()
        {
            // Setup the Information panel
            /*StringBuilder Information = new StringBuilder();
            Information.AppendFormat("${0:X4} - ${1:X4}\n", ProgramInfo.StartAddress, ProgramInfo.EndAddress);
            Information.AppendFormat("{0:N0} Characters\n", ProgramInfo.LengthBytes / 8);
            Information.AppendFormat("{0:N0} Bytes\n", ProgramInfo.LengthBytes);
            Information.AppendFormat("File is {0}", ProgramInfo.Protection.ToString());

            FileInformation.Text = Information.ToString();*/

            // Draw the entire character set
            DrawCharacterSet(-1);
        }

        private void DisplaySelectedCharacter(int iCharacter)
        {
            ushort ui16BufferOffset = (ushort)(iCharacter * 8);

            byte[] charData = new byte[8];

            ibxCharIndex.Text = string.Format("{0} of {1}", iCharacter+1, ProgramInfo.LengthBytes / 8);
            ibxCharAddress.Text = string.Format("${0:X4}", ProgramInfo.StartAddress + ui16BufferOffset);

            for (int iIndex = 0; iIndex < 8; iIndex++)
            {
                charData[iIndex] = (byte)ProgramData.ProgramData[ui16BufferOffset + iIndex];

                string labelToFind = string.Format("lblAddr{0}", iIndex + 1);
                Control[] labelControl = grpCharacterDetails.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = string.Format("${0:X4}", (ProgramInfo.StartAddress + ui16BufferOffset) + iIndex);
                }

                labelToFind = string.Format("lblHex{0}", iIndex+1);
                labelControl = grpCharacterDetails.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = string.Format("{0:X2}", charData[iIndex]);
                }

                labelToFind = string.Format("lblDec{0}", iIndex + 1);
                labelControl = grpCharacterDetails.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = string.Format("{0}", charData[iIndex]);
                }

                labelToFind = string.Format("lblBin{0}", iIndex + 1);
                labelControl = grpCharacterDetails.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    string BinaryString = Convert.ToString(charData[iIndex], 2);
                    labelControl[0].Text = string.Format("{0,8}", BinaryString.PadLeft(8, '0'));
                }
            }

            DrawCharacterGrid(charData);
        }

        private void DrawCharacterGrid(byte[] characterData)
        {
            Image tempImage = Properties.Resources.CharacterSetViewer;

            Graphics newGraphics = Graphics.FromImage(tempImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            int gridRow = 0;

            Font textFont = new Font("Consolas", 9, FontStyle.Regular);

            // Fill each row with the character data
            foreach (byte characterByte in characterData)
            {
                gridRow++;

                for (int index = 2; index < 8; index++)
                {
                    byte cBit = (byte)(characterByte << (index));
                    byte cResult = Convert.ToByte(0x80 & cBit);

                    if (cResult == 0x80)
                    {
                        FillGridCell(newGraphics, index - 1, gridRow);
                    }
                }

                //int textXPos = (gridColWidth * 6) + (gridXOffset + 8) + 8;
                //int textYPos = ((gridRow - 1) * gridRowHeight) + (gridYOffset + 4);

                // Select a brush for the row/column text

                //SolidBrush textBrush = new SolidBrush(Color.Blue);
                //Font numericFont = new Font("Consolas", 11, FontStyle.Regular);

                //string BinaryString = Convert.ToString(characterByte, 2);
                //string numericValues = string.Format("#{0:X2}      {1:d2}    {2,6}",
                //                                     characterByte, characterByte, BinaryString.PadLeft(6, '0'));

                //newGraphics.DrawString(numericValues, numericFont, textBrush, textXPos, textYPos);
                //numericFont.Dispose();
            }

            // Dispose of graphics object.
            newGraphics.Dispose();

            picCharacterView.Image = tempImage;
        }

        private void FillGridCell(Graphics g, int gridXPos, int gridYPos)
        {
            gridXPos -= 1;
            gridYPos -= 1;

            int cellXPos = (gridXOffset + 1) + (gridXPos * gridColWidth);
            int cellYPos = (gridYOffset + 1) + (gridYPos * gridRowHeight);

            int cellWidth = gridColWidth - 1;
            int cellHeight = gridRowHeight - 1;

            g.FillRectangle(new SolidBrush(Color.Navy), cellXPos, cellYPos, cellWidth, cellHeight);

            Point cellTopLeft = new Point(cellXPos, cellYPos);
            Point cellTopRight = new Point((cellXPos + cellWidth) - 1, cellYPos);
            Point cellBottomLeft = new Point(cellXPos, (cellYPos + cellHeight) - 1);
            Point cellBottomRight = new Point((cellXPos + cellWidth) - 1, (cellYPos + cellHeight) - 1);
            
            //g.DrawLine(new Pen(Color.White), cellTopLeft, cellTopRight);
            //g.DrawLine(new Pen(Color.White), cellTopLeft, cellBottomLeft);

            //g.DrawLine(new Pen(Color.Black), cellTopRight, cellBottomRight);
            //g.DrawLine(new Pen(Color.Black), cellBottomLeft, cellBottomRight);
        }

        private void DrawCharacterSetGrid(Graphics g)
        {
            short gridXPos = 3;
            short gridYPos = 3;

            for (int rowCount = 0; rowCount < 12; rowCount++)
            {
                for (int columnCount = 0; columnCount < 18; columnCount++)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(227,227,227)), gridXPos, gridYPos, 14, 18);

                    gridXPos += 16;
                }

                gridXPos = 3;
                gridYPos += 20;
            }
        }

        private void DrawCharacterSet(short currentCharacter)
        {
            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(charSetImageData);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            DrawCharacterSetGrid(newGraphics);

            byte cByte;
            byte cResult;

            short siXPos = 2;
            short siYPos = 4;

            ushort ui16ByteCount = 0;
            ushort ui16Loop = 0;
            ushort ui16CharacterCount = 0;

            SolidBrush brush = new SolidBrush(Color.Black);

            while (ui16Loop < ProgramInfo.LengthBytes)
            {
                ui16CharacterCount++;

                if (ui16CharacterCount == (currentCharacter + 1))
                {
                    // Draw a square around the current character
                    newGraphics.FillRectangle(new SolidBrush(Color.Blue), siXPos + 1, siYPos - 1, 14, 18);
                    brush.Color = Color.Yellow;
                }
                else
                {
                    brush.Color = Color.Black;
                }

                for (short siLoop2 = 0; siLoop2 < 8; siLoop2++)
                {
                    if ((ui16Loop + siLoop2) < ProgramData.ProgramData.Length)
                    {
                        cByte = ProgramData.ProgramData[ui16Loop + siLoop2];
                    }
                    else
                    {
                        cByte = 0x00;
                    }

                    short siPattern = cByte;

                    for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                    {
                        byte cBit = (byte)(siPattern << (siLoop3));
                        cResult = Convert.ToByte(0x80 & cBit);

                        if (cResult == 0x80)
                        {
                            newGraphics.FillRectangle(brush, siXPos + ((siLoop3 * 2) - 2), siYPos + (siLoop2 * 2), 2, 2);
                        }
                    }
                }
                
                siXPos += 16;

                ui16ByteCount++;

                // Have we drawn 40 characters?
                if (ui16ByteCount == 18)
                {
                    // Reset X position back to start of line
                    siXPos = 2;

                    // Increment Y position to next line down
                    siYPos += 20;

                    // Reset counter
                    ui16ByteCount = 0;
                }

                ui16Loop += 8;
            }

            // Dispose of graphics object.
            newGraphics.Dispose();

            picCharSet.Image = charSetImageData;
        }

        private void picCharSet_MouseMove(object sender, MouseEventArgs e)
        {
            int CharacterTotal = ProgramInfo.LengthBytes / 8;
            int CellAcross = (e.X - 3) / 16;
            int CellDown = (e.Y - 2) / 20;
            int CharacterIndex = (CellDown * 18) + CellAcross;

            if (e.X >= 3 && CellAcross < 18 && CharacterIndex < CharacterTotal)
            {
                DrawCharacterSet((short)CharacterIndex);
                DisplaySelectedCharacter(CharacterIndex);
            }
            else
            {
                DrawCharacterSet(-1);
                ClearDetails();
            }
        }

        private void picCharSet_MouseLeave(object sender, EventArgs e)
        {
            ClearDetails();
        }

        private void ClearDetails()
        {
            byte[] charData = new byte[8];

            for (int iIndex = 0; iIndex < 8; iIndex++)
            {
                charData[iIndex] = 0;
            }

            DrawCharacterGrid(charData);

            lblAddr1.Text = "";
            lblAddr2.Text = "";
            lblAddr3.Text = "";
            lblAddr4.Text = "";
            lblAddr5.Text = "";
            lblAddr6.Text = "";
            lblAddr7.Text = "";
            lblAddr8.Text = "";

            lblDec1.Text = "";
            lblDec2.Text = "";
            lblDec3.Text = "";
            lblDec4.Text = "";
            lblDec5.Text = "";
            lblDec6.Text = "";
            lblDec7.Text = "";
            lblDec8.Text = "";

            lblHex1.Text = "";
            lblHex2.Text = "";
            lblHex3.Text = "";
            lblHex4.Text = "";
            lblHex5.Text = "";
            lblHex6.Text = "";
            lblHex7.Text = "";
            lblHex8.Text = "";

            lblBin1.Text = "";
            lblBin2.Text = "";
            lblBin3.Text = "";
            lblBin4.Text = "";
            lblBin5.Text = "";
            lblBin6.Text = "";
            lblBin7.Text = "";
            lblBin8.Text = "";

            ibxCharIndex.Text = "--";
            ibxCharAddress.Text = "--";
        }
    }
}