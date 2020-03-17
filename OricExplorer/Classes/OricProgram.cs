namespace OricExplorer
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class OricProgram
    {
        public enum ProgramFormat { BasicProgram, HyperbasicProgram, TeleassSource, BinaryFile, OrixProgram, HiresScreen, TextScreen, CharacterSet, DirectAccessFile, SequentialFile, WindowFile, HelpFile, UnknownFile };
        public enum ProtectionStatus { Unprotected, Protected, Invisible, Unlocked, Locked };
        public enum AutoRunFlag { Disabled, Enabled };
        public enum SpecialMode { None, Telestrat, Orix };

        // byte array containing the actual program data
        public byte[] ProgramData { get; set; }

        private BasicTokens basicTokens;
        private HyperbasicTokens hyperbasicTokens;
        private TeleassTokens teleassTokens;
        private OpCodes opCodes;

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
            if (ProgramData != null)
            {
                ProgramData.Initialize();
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

                byte bByte = ProgramData[ui16Loop];

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
                highByte = ProgramData[ui16Index];
                lowByte = ProgramData[ui16Index + 1];

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
                    highByte = ProgramData[ui16Index];
                    lowByte = ProgramData[ui16Index + 1];

                    ushort uiLineNo = Convert.ToUInt16(highByte + (lowByte * 256));

                    stbBasic.Append("\\cf1 ");
                    stbBasic.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    do
                    {
                        byte bByte = ProgramData[ui16Index];

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
                    } while (ProgramData[ui16Index] != 0);

                    stbListing.Append(stbBasic.ToString());
                    stbListing.Append("\\i0\\par\n");

                    ui16Index++;
                }
            }

            stbListing.Append("}");

            return stbListing.ToString().Replace('`', '©');
        }

        public string ListBasicSourceAsText()
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
                highByte = ProgramData[ui16Index];
                lowByte = ProgramData[ui16Index + 1];

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
                    highByte = ProgramData[ui16Index];
                    lowByte = ProgramData[ui16Index + 1];

                    ushort uiLineNo = Convert.ToUInt16(highByte + (lowByte * 256));
                    stbLine.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    if (ui16Index >= ProgramData.Length)
                    {
                        bEndOfProg = true;
                    }
                    else
                    {
                        do
                        {
                            byte bByte = ProgramData[ui16Index];

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

                            if (ui16Index >= ProgramData.Length)
                            {
                                bEndOfProg = true;
                            }
                        } while (!bEndOfProg && ProgramData[ui16Index] != 0 && ui16Index < ProgramData.Length);
                    }

                    stbListing.Append(stbLine.ToString());
                    stbListing.Append("\n");

                    ui16Index++;
                }
            }

            return stbListing.ToString().Replace('`', '©');
        }

        public string ListHyperbasicSourceAsText()
        {
            Dictionary<ushort, string> dicVariables = new Dictionary<ushort, string>();
            StringBuilder stbListing = new StringBuilder();
            StringBuilder stbDebug = new StringBuilder();
            ushort ushActualLineStartIndex = 16;
            bool boolEndOfProg = false;

            hyperbasicTokens = new HyperbasicTokens();

            // determine the address of variable block
            byte bytHigh = ProgramData[13];
            byte bytLow = ProgramData[14];
            ushort ushVariableIndex = (ushort)(bytHigh + (bytLow * 256));

    // display debug
    ushort ushIndex = 0;
    while ((ushVariableIndex + ushIndex - 0x7f0) < ProgramData.Length)
    {
        stbDebug.Append($"{(ushIndex % 16 == 0 ? $"\r\n{ushVariableIndex + ushIndex:X4} " : " ")}{ProgramData[ushVariableIndex + ushIndex++ - 0x7f0]:X2}");
    }
    stbDebug.Append($"\r\n\r\nDébut des variables : {ushVariableIndex:X4}\r\n\r\n");

            
            // build the dictionary of variables
            ushVariableIndex -= 0x7f0;
            bytHigh = ProgramData[ushVariableIndex++];
            bytLow = ProgramData[ushVariableIndex++];
            ushort ushNextVariableStartIndex = (ushort)(bytHigh + (bytLow * 256));
            byte b;
Console.WriteLine($"{ushNextVariableStartIndex:X4}");

            while (ushNextVariableStartIndex > 0)
            {
                ushNextVariableStartIndex -= 0x7f0;

                bytHigh = ProgramData[ushVariableIndex++];
                bytLow = ProgramData[ushVariableIndex++];
                ushort ushVariableType = (ushort)((bytHigh * 256) + bytLow);
Console.WriteLine($"{ushVariableType:X4}");

                if (ushVariableType > 0)
                {
                    bytHigh = ProgramData[ushVariableIndex++];
                    bytLow = ProgramData[ushVariableIndex++];
                    ushort ushVariableId = (ushort)((bytHigh * 256) + bytLow);
Console.WriteLine($"{ushVariableId:X4}");
                    
                    string strPs = (ushVariableType == 0x1000 ? "\"" : "");

                    StringBuilder stbVariable = new StringBuilder();
                    byte bytVariableLength = (byte)(ProgramData[ushVariableIndex++] - 7);
                    for (b = 0; b < bytVariableLength; b++)
                    {
                        stbVariable.Append((char)ProgramData[ushVariableIndex++]);
                    }

                    dicVariables.Add(ushVariableId, $"{strPs}{stbVariable.ToString()}{strPs}");

                    ushVariableIndex = ushNextVariableStartIndex;
                    bytHigh = ProgramData[ushVariableIndex++];
                    bytLow = ProgramData[ushVariableIndex++];
                    ushNextVariableStartIndex = (ushort)(bytHigh + (bytLow * 256));
Console.WriteLine($"{ushNextVariableStartIndex:X4}");
                }
                else
                {
                    ushNextVariableStartIndex = 0;
                }
            }

            ushort ushIndentation = 2;
            ushort ushAdjust = 0;
            // treat the code
            while (!boolEndOfProg)
            {
                //try
                {
                    byte bytLineLength = ProgramData[ushActualLineStartIndex];
                    ushort ushNextLineStartIndex = (ushort)(ushActualLineStartIndex + bytLineLength);

//ushIndex = ushActualLineStartIndex;
//while (ushIndex < ushNextLineStartIndex)
//{
//    stbListing.Append($"{m_programData[ushIndex++]:X2} ");
//}
//stbListing.Append("\r\n");

                    bytHigh = ProgramData[ushActualLineStartIndex + 1];
                    bytLow = ProgramData[ushActualLineStartIndex + 2];
                    ushort ushLineNumber = (ushort)(bytHigh + (bytLow * 256));
                    stbListing.Append($"{ushLineNumber, 6} ");

                    ushIndex = (ushort)(ushActualLineStartIndex + 4);

                    bool boolFirst = true;
                    while (ushIndex < ushNextLineStartIndex)
                    {
                        string strKeyword = string.Empty;
                        ushort token = 0;
                        byte bytToken = ProgramData[ushIndex];

                        if (bytToken < 0xD0)
                        {
                            ushIndex++;

                            byte bytParam = (bytToken == 0xC0 ? ProgramData[ushIndex++] : (byte)0);
                            token = (bytParam == 0 && bytToken != 0xC0 ? bytToken : (ushort)((bytToken * 256) + bytParam));
                            Console.WriteLine($"{token:X4}");

                            strKeyword = hyperbasicTokens.GetKeyword(token);
                        }

                        if (boolFirst)
                        {
                            switch (strKeyword.Trim())
                            {
                                case "]":
                                case "RETURN":
                                case "END":
                                case "'":
                                    ushIndentation = 0;
                                    ushAdjust = 2;
                                    break;

                                case "FOR":
                                case "REPEAT":
                                case "COUNT":
                                case "WHILE":
                                    ushAdjust = (ushort)(ushIndentation + 1);
                                    break;

                                case "NEXT":
                                case "UNTIL":
                                case "UNCOUNT":
                                case "WEND":
                                    ushIndentation -= 1;
                                    ushAdjust = 0;
                                    break;
                            }

                            stbListing.Append(new String(' ', ushIndentation));

                            if (ushAdjust > 0)
                            {
                                ushIndentation = ushAdjust;
                                ushAdjust = 0;
                            }
                        }

                        stbListing.Append(strKeyword);

                        if (token == 0x20)
                        {
                        }
                        else if (ProgramData[ushIndex] >= 0xD0 && ushIndex < ushNextLineStartIndex)
                        {
                            bytHigh = ProgramData[ushIndex++];
                            bytLow = ProgramData[ushIndex++];
                            ushort ushVariableId = (ushort)((bytHigh * 256) + bytLow);

                            stbListing.Append(dicVariables[ushVariableId]);
                        }
                        
                        boolFirst = false;
                    }

                    stbListing.Append("\n");

                    boolEndOfProg = (ProgramData[ushNextLineStartIndex] == 0);
                    ushActualLineStartIndex = ushNextLineStartIndex;
                }
                //catch (Exception)
                //{
                //    MessageBox.Show("Error displaying file: file seems to be corrupted or truncated.", "Display file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    boolEndOfProg = true;
                //}
            }

            //return stbDebug.ToString() + stbListing.ToString();
            return stbListing.ToString();
        }

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
                    byte _ = ProgramData[intIndex++];

                    byte bytHigh = ProgramData[intIndex++];
                    byte bytLow = ProgramData[intIndex++];

                    int intLineNumber = bytHigh + (bytLow * 256);
                    stbListing.Append($"{intLineNumber,6} ");

                    StringBuilder stbLabel = new StringBuilder();
                    byte bytByte;
                    while ((bytByte = ProgramData[intIndex]) > 0 && bytByte < 0x80)
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

                    while ((bytByte = ProgramData[intIndex]) > 0)
                    {
                        stbListing.Append((char)bytByte);
                        intIndex++;
                    }

                    stbListing.Append("\n");

                    intIndex++;
                    boolEndOfProg = (ProgramData[intIndex] == 0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error displaying file: file seems to be corrupted or truncated.", "Display file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolEndOfProg = true;
                }
            }

            return stbListing.ToString().Replace('`', '©');
        }

        public string ListAssembler(SpecialMode specialMode = SpecialMode.None)
        {
            opCodes = new OpCodes();

            ushort ui16Loop = (ushort)(Format == ProgramFormat.OrixProgram ? OtherFileInfo.ORIX_HEADER_LENGTH : 0);
            ushort ui16Address;
            ushort ui16BranchAddr;

            string strAscii;

            StringBuilder stbDissassembly = new StringBuilder();
            stbDissassembly.EnsureCapacity(65000);

            if (ProgramName == null)
            {
                ProgramName = "";
            }

            ui16Address = (ushort)(StartAddress + (Format == ProgramFormat.OrixProgram ? OtherFileInfo.ORIX_HEADER_LENGTH : 0));

            byte bByte;

            while (ui16Loop < ProgramLength)
            {
                bByte = ProgramData[ui16Loop];

                OpCodes.sOpCode sTmpStructOpCodes = opCodes.FindOpInfo(bByte);

                // if the byte is 00 (BRK instruction) and it is a Telestrat (Stratsed) floppy disk,
                // this mnemonic is accompanied by an argument so we adjust the default properties
                if (bByte == 0 && specialMode == SpecialMode.Telestrat)
                {
                    sTmpStructOpCodes.bOpBytes = 2;//instead of 1
                    sTmpStructOpCodes.bOpMode = 4;//instead of 1
                }

                strAscii = "";

                string strOpParams = "";

                // Current address
                stbDissassembly.AppendFormat("${0:X4}  ", ui16Address);

                if (ui16Loop + sTmpStructOpCodes.bOpBytes > ProgramLength)
                {
                    byte bCurrByte = Convert.ToByte(ProgramData[ui16Loop]);

                    stbDissassembly.AppendFormat("{0:X2} ", bCurrByte);

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
                        byte bCurrByte = Convert.ToByte(ProgramData[ui16Loop + siIndex]);

                        stbDissassembly.AppendFormat("{0:X2} ", bCurrByte);

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
                    stbDissassembly.Append("   ");
                }

                if (sTmpStructOpCodes.bOpBytes < 3)
                {
                    stbDissassembly.Append("   ");
                }

                byte bByte1 = 0;
                byte bByte2 = 0;

                if (sTmpStructOpCodes.bOpBytes > 1)
                {
                    bByte1 = Convert.ToByte(ProgramData[ui16Loop + 1]);
                }

                if (sTmpStructOpCodes.bOpBytes > 2)
                {
                    bByte2 = Convert.ToByte(ProgramData[ui16Loop + 2]);
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

                stbDissassembly.AppendFormat("   {0,-3:G} {1,-8:G}   {2,-3}\n",
                                             sTmpStructOpCodes.strOpMne, strOpParams, strAscii);

                ui16Address += sTmpStructOpCodes.bOpBytes;
                ui16Loop += sTmpStructOpCodes.bOpBytes;
            }

            return stbDissassembly.ToString().Replace('`', '©');
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
