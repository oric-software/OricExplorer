namespace OricExplorer
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class OricProgram
    {
        public enum ProgramFormat { AtmosBasicProgram, HyperbasicSource, TeleassSource, BinaryFile, HiresScreen, TextScreen, CharacterSet, DirectAccessFile, SequentialFile, WindowFile, HelpFile, UnknownFile };
        public enum ProtectionStatus { Unprotected, Protected, Invisible, Unlocked, Locked };
        public enum AutoRunFlag { Disabled, Enabled };

        // byte array containing the actual program data
        public byte[] m_programData;

        public BasicTokens basicTokens;
        public TeleassTokens teleassTokens;
        public OpCodes opCodes;

        /// <summary>
        /// Constructor builds the Basic token list and calls the New() function to reset the values
        /// </summary>
        public OricProgram()
        {
            // Initialise the program data buffer
            //m_programData = new byte[0xFFFF];

            // Call New to reset values
            New();
        }

        /// <summary>
        /// Renumbers a Basic program
        /// </summary>
        /// <returns></returns>
        //private bool Renumber(ushort ui16Start)
        //{
        //    return true;
        //}

        /// <summary>
        /// New - Resets the program settings and clears out the program data
        /// </summary>
        /// <returns></returns>
        public void New()
        {
            // Reset the address values
            StartAddress = 0;
            EndAddress = 0;
            ExeAddress = 0;

            // Reset the program format
            Format = 0;

            // Reset the program status flag
            Protection = ProtectionStatus.Unprotected;

            Format = ProgramFormat.UnknownFile;

            // Reset the AutoRun flag
            AutoRun = AutoRunFlag.Disabled;

            // Reset the program name
            ProgramName = "";

            // Reset the program data
            if (m_programData != null)
            {
                m_programData.Initialize();
            }
        }

        public string HexDump()
        {
            ushort ui16Index = 0;
            ushort ui16Loop;
            ushort ui16Address;

            StringBuilder stbHexLine = new StringBuilder();
            StringBuilder stbAscii = new StringBuilder();
            StringBuilder stbHexDump = new StringBuilder();

            ui16Address = StartAddress;

            for (ui16Loop = 0; ui16Loop < ProgramLength; ui16Loop++)
            {
                if (ui16Index == 0)
                {
                    stbHexLine.AppendFormat("${0:X4}  ", ui16Address);
                    ui16Address += 16;
                    stbAscii.Length = 0;
                }

                byte bByte = m_programData[ui16Loop];

                if (bByte < 32 || bByte > 126)
                {
                    stbAscii.Append(".");
                }
                else
                {
                    /*if (bByte == 0x60)
                        strAscii.Append("\\'a9");
                    else if(Convert.ToChar(bByte) == '\\')
                        strAscii.Append("\\\\");
                    else if(Convert.ToChar(bByte) == '{')
                        strAscii.Append("\\{");
                    else if(Convert.ToChar(bByte) == '}')
                        strAscii.Append("\\}");
                    else*/
                    stbAscii.Append(Convert.ToChar(bByte));
                }

                stbHexLine.AppendFormat("{0:X2} ", bByte);

                ui16Index++;

                if (ui16Index == 16 || ui16Loop == ProgramLength)
                {
                    stbHexDump.AppendFormat("{0,-56:G} {1}\n", stbHexLine.ToString(), stbAscii.ToString());

                    ui16Index = 0;
                    stbHexLine.Length = 0;
                }
            }

            if (stbHexLine.Length > 0)
            {
                stbHexDump.AppendFormat("{0,-56:G} {1}\n", stbHexLine.ToString(), stbAscii.ToString());
            }

            return stbHexDump.ToString().Replace('`', '©');
        }

        public string List()
        {
            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);

            byte highByte;
            byte lowByte;

            bool bREMFlag;
            bool bDATAFlag;
            bool bStringFlag;
            bool bKeyword;
            bool bMCFlag;

            ushort ui16Index = 0;

            StringBuilder stbListing = new StringBuilder();
            StringBuilder stbBasic = new StringBuilder();

            stbBasic.EnsureCapacity(255);

            bool bEndOfProg = false;

            stbListing.Append("{\\rtf\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Consolas;}}");
            stbListing.Append(BuildColourTable());
            stbListing.Append("{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\lang2057\\f0\\fs18 ");

            if (ProgramName == null)
                ProgramName = "";

            while (!bEndOfProg)
            {
                stbBasic.Length = 0;

                // Get the address of the next line
                highByte = m_programData[ui16Index];
                lowByte = m_programData[ui16Index + 1];

                ushort ui16NextAddress = Convert.ToUInt16(highByte + (lowByte * 256));

                if (ui16NextAddress == 0)
                {
                    bEndOfProg = true;
                }
                else
                {
                    bREMFlag = false;
                    bDATAFlag = false;
                    bStringFlag = false;
                    bMCFlag = false;
                    bKeyword = false;

                    ui16Index += 2;

                    // Get the current line number
                    highByte = m_programData[ui16Index];
                    lowByte = m_programData[ui16Index + 1];

                    ushort uiLineNo = Convert.ToUInt16(highByte + (lowByte * 256));

                    stbBasic.Append("\\cf1 ");
                    stbBasic.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    do
                    {
                        byte bByte = m_programData[ui16Index];

                        if (bByte >= 0x80 && bByte <= 0xF6)
                        {
                            if (bByte == 0x9D || bByte == '\'')
                            {
                                if (!bREMFlag)
                                {
                                    bREMFlag = true;
                                    stbBasic.Append("\\cf2 ");
                                }
                            }
                            else if (bByte == 0x91)
                            {
                                if (!bDATAFlag)
                                {
                                    bDATAFlag = true;
                                    stbBasic.Append("\\cf2 ");
                                }
                            }
                            else if (bByte == 0xC0)
                            {
                                if (!bMCFlag)
                                {
                                    bMCFlag = true;
                                    stbBasic.Append("\\cf0 ");
                                }
                            }
                            else
                            {
                                if (!bREMFlag && !bDATAFlag && !bMCFlag)
                                    stbBasic.Append("\\cf2 ");
                            }

                            if (!bKeyword)
                                bKeyword = true;

                            // We have a BASIC token
                            stbBasic.Append(basicTokens.GetBasicToken(Convert.ToByte(bByte - 0x80)));

                            if (bREMFlag)
                            {
                                stbBasic.Append("\\cf5 ");
                            }

                            if (bDATAFlag)
                            {
                                stbBasic.Append("\\cf4 ");
                            }
                        }
                        else
                        {
                            if (bKeyword)
                            {
                                if (!bREMFlag && !bDATAFlag && !bMCFlag)
                                    stbBasic.Append("\\cf0 ");

                                bKeyword = false;
                            }

                            if (bByte >= 0x20)
                            {
                                if (bMCFlag)
                                {
                                    if (!Char.IsLetter((Char)bByte))
                                    {
                                        bMCFlag = false;
                                        stbBasic.Append("\\cf0 ");
                                    }
                                }

                                if (bByte == '\'')
                                {
                                    if (!bREMFlag && !bStringFlag && !bDATAFlag && !bMCFlag)
                                    {
                                        bREMFlag = true;
                                        stbBasic.Append("\'\\cf5 ");
                                    }
                                    else
                                    {
                                        stbBasic.Append("\'");
                                    }
                                }
                                else if (bByte == '\"')
                                {
                                    if (!bREMFlag && !bDATAFlag && !bMCFlag)
                                    {
                                        if (!bStringFlag)
                                        {
                                            bStringFlag = true;
                                            stbBasic.Append("\"\\cf3 ");
                                        }
                                        else
                                        {
                                            bStringFlag = false;
                                            stbBasic.Append("\\cf0 \"");
                                        }
                                    }
                                    else
                                    {
                                        stbBasic.Append("\"");
                                    }
                                }
                                else if (bByte == ':')
                                {
                                    if (!bREMFlag && !bStringFlag)
                                    {
                                        if (bMCFlag)
                                        {
                                            bMCFlag = false;
                                            stbBasic.Append("\\cf0 :");
                                        }
                                        else
                                        {
                                            stbBasic.Append(":");
                                        }
                                    }
                                    else
                                    {
                                        stbBasic.Append(":");
                                    }
                                }
                                else if (bByte == 0x60)
                                    stbBasic.Append("\\'a9");
                                else if (Convert.ToChar(bByte) == '\\')
                                    stbBasic.Append("\\\\");
                                else if (Convert.ToChar(bByte) == '{')
                                    stbBasic.Append("\\{");
                                else if (Convert.ToChar(bByte) == '}')
                                    stbBasic.Append("\\}");
                                else
                                    stbBasic.Append(Convert.ToChar(bByte));
                            }
                        }

                        ui16Index++;
                    } while (m_programData[ui16Index] != 0);

                    stbListing.Append(stbBasic.ToString());
                    stbListing.Append("\\i0\\par\n");

                    ui16Index++;
                }
            }

            stbListing.Append("}");

            return stbListing.ToString().Replace('`', '©');
        }

        public string ListAtmosBasicSourceAsText()
        {
            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);

            byte highByte;
            byte lowByte;

            bool bREMFlag;
            bool bDATAFlag;
            bool bStringFlag;
            bool bKeyword;

            ushort ui16Index = 0;

            StringBuilder stbListing = new StringBuilder();
            StringBuilder stbLine = new StringBuilder();

            stbLine.EnsureCapacity(255);

            bool bEndOfProg = false;

            if (ProgramName == null)
            {
                ProgramName = "";
            }

            while (!bEndOfProg)
            {
                stbLine.Length = 0;

                // Get the address of the next line
                highByte = m_programData[ui16Index];
                lowByte = m_programData[ui16Index + 1];

                ushort ui16NextAddress = Convert.ToUInt16(highByte + (lowByte * 256));

                if (ui16NextAddress == 0)
                {
                    bEndOfProg = true;
                }
                else
                {
                    bREMFlag = false;
                    bDATAFlag = false;
                    bStringFlag = false;
                    bKeyword = false;

                    ui16Index += 2;

                    // Get the current line number
                    highByte = m_programData[ui16Index];
                    lowByte = m_programData[ui16Index + 1];

                    ushort uiLineNo = Convert.ToUInt16(highByte + (lowByte * 256));
                    stbLine.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    if (ui16Index >= m_programData.Length)
                    {
                        bEndOfProg = true;
                    }
                    else
                    {
                        do
                        {
                            byte bByte = m_programData[ui16Index];

                            if (bByte >= 0x80 && bByte <= 0xF6)
                            {
                                if (bByte == 0x9D || bByte == '\'')
                                {
                                    if (!bREMFlag)
                                    {
                                        bREMFlag = true;
                                    }
                                }
                                else if (bByte == 0x91)
                                {
                                    if (!bDATAFlag)
                                    {
                                        bDATAFlag = true;
                                    }
                                }

                                if (!bKeyword)
                                    bKeyword = true;

                                // We have a BASIC token
                                stbLine.Append(basicTokens.GetBasicToken(Convert.ToByte(bByte - 0x80)));
                            }
                            else
                            {
                                if (bKeyword)
                                {
                                    bKeyword = false;
                                }

                                if (bByte >= 0x20)
                                {
                                    if (bByte == '\'')
                                    {
                                        if (!bREMFlag && !bStringFlag && !bDATAFlag)
                                        {
                                            bREMFlag = true;
                                            stbLine.Append("\'");
                                        }
                                        else
                                        {
                                            stbLine.Append("\'");
                                        }
                                    }
                                    else if (bByte == '\"')
                                    {
                                        if (!bREMFlag && !bDATAFlag)
                                        {
                                            if (!bStringFlag)
                                            {
                                                bStringFlag = true;
                                                stbLine.Append("\"");
                                            }
                                            else
                                            {
                                                bStringFlag = false;
                                                stbLine.Append("\"");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        stbLine.Append(Convert.ToChar(bByte));
                                    }
                                }
                            }

                            ui16Index++;

                            if (ui16Index >= m_programData.Length)
                            {
                                bEndOfProg = true;
                            }
                        } while (!bEndOfProg && m_programData[ui16Index] != 0 && ui16Index < m_programData.Length);
                    }

                    stbListing.Append(stbLine.ToString());
                    stbListing.Append("\n");

                    ui16Index++;
                }
            }

            return stbListing.ToString().Replace('`', '©');
        }

        //public string ListHyperbasicSourceAsText()
        //{
        //    StringBuilder stbListing = new StringBuilder();

        //    int intIndex = 16;
        //    bool boolEndOfProg = false;

        //    while (!boolEndOfProg)
        //    {
        //        try
        //        {
        //            byte bytLineLength = m_programData[intIndex++];

        //            byte bytHigh = m_programData[intIndex++];
        //            byte bytLow = m_programData[intIndex++];

        //            int intLineNumber = bytHigh + (bytLow * 256);
        //            stbListing.Append($"{intLineNumber,6} ");

        //            for (byte b = 2; b < bytLineLength - 1; b++)
        //            {
        //                stbListing.Append($"{m_programData[intIndex++]:X2} ");
        //            }

        //            stbListing.Append("\n");

        //            boolEndOfProg = (m_programData[intIndex] == 0);
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error displaying file: file seems to be corrupted or truncated.", "Display file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            boolEndOfProg = true;
        //        }
        //    }

        //    return stbListing.ToString();
        //}

        public string ListTeleassSourceAsText()
        {
            teleassTokens = new TeleassTokens();

            StringBuilder stbListing = new StringBuilder();
            
            int intIndex = 0;
            bool boolEndOfProg = false;

            while (!boolEndOfProg)
            {
                try
                {
                    byte _ = m_programData[intIndex++];

                    byte bytHigh = m_programData[intIndex++];
                    byte bytLow = m_programData[intIndex++];

                    int intLineNumber = bytHigh + (bytLow * 256);
                    stbListing.Append($"{intLineNumber,6} ");

                    StringBuilder stbLabel = new StringBuilder();
                    byte bytByte;
                    while ((bytByte = m_programData[intIndex]) > 0 && bytByte < 0x80)
                    {
                        stbLabel.Append((char)bytByte);
                        intIndex++;
                    }
                    stbListing.Append($"{stbLabel,-6}");

                    if (bytByte > 0)
                    {
                        stbListing.Append($" {teleassTokens.GetTeleassToken((byte)(bytByte - 0x80))} ");
                        intIndex++;
                    }

                    while ((bytByte = m_programData[intIndex]) > 0)
                    {
                        stbListing.Append((char)bytByte);
                        intIndex++;
                    }

                    stbListing.Append("\n");

                    intIndex++;
                    boolEndOfProg = (m_programData[intIndex] == 0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error displaying file: file seems to be corrupted or truncated.", "Display file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolEndOfProg = true;
                }
            }

            return stbListing.ToString().Replace('`', '©');
        }

        public string ListAssembler()
        {
            opCodes = new OpCodes();

            ushort ui16Loop = 0;
            ushort ui16Address;
            ushort ui16BranchAddr;

            string strAscii;

            StringBuilder strDissassembly = new StringBuilder();
            strDissassembly.EnsureCapacity(65000);

            if (ProgramName == null)
            {
                ProgramName = "";
            }

            ui16Address = StartAddress;

            byte bByte;

            while (ui16Loop < ProgramLength)
            {
                bByte = m_programData[ui16Loop];

                OpCodes.sOpCode sTmpStructOpCodes = opCodes.FindOpInfo(bByte);

                strAscii = "";

                string strOpParams = "";

                // Current address
                strDissassembly.AppendFormat("${0:X4}  ", ui16Address);

                if (ui16Loop + sTmpStructOpCodes.bOpBytes > ProgramLength)
                {
                    byte bCurrByte = Convert.ToByte(m_programData[ui16Loop]);

                    strDissassembly.AppendFormat("{0:X2} ", bCurrByte);

                    sTmpStructOpCodes.bOpBytes = 1;
                    sTmpStructOpCodes.bOpMode = 0;

                    if (bCurrByte < 32 || bCurrByte > 126)
                    {
                        strAscii += ".";
                    }
                    else
                    {
                        strAscii += Convert.ToChar(bCurrByte);
                    }
                }
                else
                {
                    for (ushort siIndex = 0; siIndex < sTmpStructOpCodes.bOpBytes; siIndex++)
                    {
                        byte bCurrByte = Convert.ToByte(m_programData[ui16Loop + siIndex]);

                        strDissassembly.AppendFormat("{0:X2} ", bCurrByte);

                        if (bCurrByte < 32 || bCurrByte > 126)
                        {
                            strAscii += ".";
                        }
                        else
                        {
                            strAscii += Convert.ToChar(bCurrByte);
                        }
                    }
                }

                if (sTmpStructOpCodes.bOpBytes < 2)
                {
                    strDissassembly.Append("   ");
                }

                if (sTmpStructOpCodes.bOpBytes < 3)
                {
                    strDissassembly.Append("   ");
                }

                byte bByte1 = 0;
                byte bByte2 = 0;

                if (sTmpStructOpCodes.bOpBytes > 1)
                {
                    bByte1 = Convert.ToByte(m_programData[ui16Loop + 1]);
                }

                if (sTmpStructOpCodes.bOpBytes > 2)
                {
                    bByte2 = Convert.ToByte(m_programData[ui16Loop + 2]);
                }

                switch (sTmpStructOpCodes.bOpMode)
                {
                    case 0:
                    case 1: 
                        strOpParams = "";
                        break;

                    case 2: 
                        strOpParams = string.Format("#${0:X2}", bByte1);
                        break;

                    case 3: 
                        strOpParams = string.Format("${0:X2}{1:X2}", bByte2, bByte1);
                        break;

                    case 4: 
                        strOpParams = string.Format("${0:X2}", bByte1);
                        break;

                    case 5: // Calculate jump address
                        if (bByte1 > 127)
                        {
                            ui16BranchAddr = (ushort)(ui16Address - (255 - bByte1));
                            ui16BranchAddr++;
                        }
                        else
                        {
                            ui16BranchAddr = (ushort)((ui16Address + 2) + bByte1);
                        }

                        strOpParams = string.Format("${0:X4}", ui16BranchAddr);
                        break;

                    case 6: 
                        strOpParams = string.Format("${0:X2}{1:X2},X", bByte2, bByte1);
                        break;

                    case 7:
                        strOpParams = string.Format("${0:X2}{1:X2},Y", bByte2, bByte1);
                        break;

                    case 8:
                        strOpParams = string.Format("${0:X2},X", bByte1);
                        break;

                    case 9: 
                        strOpParams = string.Format("${0:X2},Y", bByte1);
                        break;

                    case 10:
                        strOpParams = string.Format("(${0:X2},X)", bByte1);
                        break;

                    case 11: 
                        strOpParams = string.Format("(${0:X2}),Y", bByte1);
                        break;

                    case 12:
                        strOpParams = "A";
                        break;

                    case 13:
                        strOpParams = string.Format("${0:X2}{1:X2}", bByte2, bByte1);
                        break;
                }

                strDissassembly.AppendFormat("   {0,-3:G} {1,-8:G}   {2,-3}\n",
                                             sTmpStructOpCodes.strOpMne, strOpParams, strAscii);

                ui16Address += sTmpStructOpCodes.bOpBytes;
                ui16Loop += sTmpStructOpCodes.bOpBytes;
            }

            return strDissassembly.ToString().Replace('`', '©');
        }

        private string BuildColourTable()
        {
            // Colour table for BASIC listing
            //Color oDefault = Color.Black; // cf0
            Color oLineNo = Color.Black; // cf1
            Color oKeyword = Color.FromArgb(0, 0, 200); // cf2
            Color oString = Color.FromArgb(200, 0, 0); // cf3
            Color oData = Color.Maroon; // cf4
            Color oComment = Color.DarkGreen; // cf5

            StringBuilder oColorTbl = new StringBuilder();
            oColorTbl.Append("{\\colortbl ;");

            oColorTbl.AppendFormat("\\red{0}\\green{1}\\blue{2};", oLineNo.R, oLineNo.G, oLineNo.B);
            oColorTbl.AppendFormat("\\red{0}\\green{1}\\blue{2};", oKeyword.R, oKeyword.G, oKeyword.B);
            oColorTbl.AppendFormat("\\red{0}\\green{1}\\blue{2};", oString.R, oString.G, oString.B);
            oColorTbl.AppendFormat("\\red{0}\\green{1}\\blue{2};", oData.R, oData.G, oData.B);
            oColorTbl.AppendFormat("\\red{0}\\green{1}\\blue{2};", oComment.R, oComment.G, oComment.B);
            oColorTbl.Append("}");

            return oColorTbl.ToString();
        }

        public ushort StartAddress { get; set; } = 0;

        public ushort EndAddress { get; set; } = 0;

        public ushort ExeAddress { get; set; } = 0;

        public ushort RecordCount { get; set; } = 0;

        public ushort RecordLength { get; set; } = 0;

        public ushort ProgramLength
        {
            get {return Convert.ToUInt16((EndAddress - StartAddress) + 1);}
        }

        public OricProgram.AutoRunFlag AutoRun { get; set; }

        public OricProgram.ProgramFormat Format { get; set; }

        public string ProgramName { get; set; }

        public string ParentName { get; set; }

        public ProtectionStatus Protection { get; set; } = ProtectionStatus.Unprotected;

        //public string DectoBin(ushort decVal)
        //{
        //    StringBuilder sBinary = new StringBuilder();

        //    ushort siDivisor = 0x80;

        //    for (int iLoop = 0; iLoop < 8; iLoop++)
        //    {
        //        if ((decVal & siDivisor) == siDivisor)
        //        {
        //            sBinary.Append("1");
        //        }
        //        else
        //        {
        //            sBinary.Append("0");
        //        }

        //        siDivisor /= 2;
        //    }

        //    string Binary;
        //    Binary = sBinary.ToString();

        //    return Binary;
        //}
    }
}
