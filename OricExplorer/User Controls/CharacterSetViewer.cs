using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OricExplorer
{
    // TODO:
    // 1. Print options
    // 2. Create actual data statements (Single characters or entire set)

    public partial class CharacterSetViewerControl : UserControl
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

        public CharacterSetViewerControl()
        {
            InitializeComponent();

            FileInformation = new Label();

            charSetImageData = new Bitmap(pictureBoxCharSet.Width, pictureBoxCharSet.Height);
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
            UInt16 ui16BufferOffset = (UInt16)(iCharacter * 8);

            Byte[] charData = new Byte[8];

            infoBoxCharIndex.Text = String.Format("{0} of {1}", iCharacter+1, ProgramInfo.LengthBytes / 8);
            infoBoxCharAddress.Text = String.Format("${0:X4}", ProgramInfo.StartAddress + ui16BufferOffset);

            for (int iIndex = 0; iIndex < 8; iIndex++)
            {
                charData[iIndex] = (Byte)ProgramData.m_programData[ui16BufferOffset + iIndex];

                String labelToFind = String.Format("labelAddr{0}", iIndex + 1);
                Control[] labelControl = groupBox2.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = String.Format("${0:X4}", (ProgramInfo.StartAddress + ui16BufferOffset) + iIndex);
                }

                labelToFind = String.Format("labelHex{0}", iIndex+1);
                labelControl = groupBox2.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = String.Format("{0:X2}", charData[iIndex]);
                }

                labelToFind = String.Format("labelDec{0}", iIndex + 1);
                labelControl = groupBox2.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    labelControl[0].Text = String.Format("{0}", charData[iIndex]);
                }

                labelToFind = String.Format("labelBin{0}", iIndex + 1);
                labelControl = groupBox2.Controls.Find(labelToFind, true);

                if (labelControl.Length > 0)
                {
                    String BinaryString = Convert.ToString(charData[iIndex], 2);
                    labelControl[0].Text = String.Format("{0,8}", BinaryString.PadLeft(8, '0'));
                }
            }

            DrawCharacterGrid(charData);
        }

        private void DrawCharacterGrid(Byte[] characterData)
        {
            Image tempImage = Properties.Resources.CharacterSetViewer;

            Graphics newGraphics = Graphics.FromImage(tempImage);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            int gridRow = 0;

            Font textFont = new Font("Consolas", 9, FontStyle.Regular);

            // Fill each row with the character data
            foreach (Byte characterByte in characterData)
            {
                gridRow++;

                for (int index = 2; index < 8; index++)
                {
                    Byte cBit = (Byte)(characterByte << (index));
                    Byte cResult = Convert.ToByte(0x80 & cBit);

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

                //String BinaryString = Convert.ToString(characterByte, 2);
                //String numericValues = String.Format("#{0:X2}      {1:d2}    {2,6}",
                //                                     characterByte, characterByte, BinaryString.PadLeft(6, '0'));

                //newGraphics.DrawString(numericValues, numericFont, textBrush, textXPos, textYPos);
                //numericFont.Dispose();
            }

            // Dispose of graphics object.
            newGraphics.Dispose();

            pictureBoxCharacterView.Image = tempImage;
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

        private void DrawCharacterSet(Int16 currentCharacter)
        {
            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(charSetImageData);
            newGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            DrawCharacterSetGrid(newGraphics);

            Byte cByte;
            Byte cResult;

            short siXPos = 2;
            short siYPos = 4;

            UInt16 ui16ByteCount = 0;
            UInt16 ui16Loop = 0;
            UInt16 ui16CharacterCount = 0;

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
                    if ((ui16Loop + siLoop2) < ProgramData.m_programData.Length)
                    {
                        cByte = ProgramData.m_programData[ui16Loop + siLoop2];
                    }
                    else
                    {
                        cByte = 0x00;
                    }

                    short siPattern = cByte;

                    for (short siLoop3 = 2; siLoop3 < 8; siLoop3++)
                    {
                        Byte cBit = (Byte)(siPattern << (siLoop3));
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

            pictureBoxCharSet.Image = charSetImageData;
        }

        private void pictureBoxCharSet_MouseMove(object sender, MouseEventArgs e)
        {
            int CharacterTotal = ProgramInfo.LengthBytes / 8;
            int CellAcross = (e.X - 3) / 16;
            int CellDown = (e.Y - 2) / 20;
            int CharacterIndex = (CellDown * 18) + CellAcross;

            if (e.X >= 3 && CellAcross < 18 && CharacterIndex < CharacterTotal)
            {
                DrawCharacterSet((Int16)CharacterIndex);
                DisplaySelectedCharacter(CharacterIndex);
            }
            else
            {
                DrawCharacterSet(-1);
                ClearDetails();
            }
        }

        private void pictureBoxCharSet_MouseLeave(object sender, EventArgs e)
        {
            ClearDetails();
        }

        private void ClearDetails()
        {
            Byte[] charData = new Byte[8];

            for (int iIndex = 0; iIndex < 8; iIndex++)
            {
                charData[iIndex] = 0;
            }

            DrawCharacterGrid(charData);

            labelAddr1.Text = "";
            labelAddr2.Text = "";
            labelAddr3.Text = "";
            labelAddr4.Text = "";
            labelAddr5.Text = "";
            labelAddr6.Text = "";
            labelAddr7.Text = "";
            labelAddr8.Text = "";

            labelDec1.Text = "";
            labelDec2.Text = "";
            labelDec3.Text = "";
            labelDec4.Text = "";
            labelDec5.Text = "";
            labelDec6.Text = "";
            labelDec7.Text = "";
            labelDec8.Text = "";

            labelHex1.Text = "";
            labelHex2.Text = "";
            labelHex3.Text = "";
            labelHex4.Text = "";
            labelHex5.Text = "";
            labelHex6.Text = "";
            labelHex7.Text = "";
            labelHex8.Text = "";

            labelBin1.Text = "";
            labelBin2.Text = "";
            labelBin3.Text = "";
            labelBin4.Text = "";
            labelBin5.Text = "";
            labelBin6.Text = "";
            labelBin7.Text = "";
            labelBin8.Text = "";

            infoBoxCharIndex.Text = "--";
            infoBoxCharAddress.Text = "--";
        }
    }
}