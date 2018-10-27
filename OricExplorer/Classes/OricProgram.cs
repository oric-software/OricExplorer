using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

namespace OricExplorer
{
    public class OricProgram
    {
        public enum ProgramFormat { BasicProgram, CodeFile, HiresScreen, TextScreen, CharacterSet, DirectAccessFile, SequentialFile, WindowFile, HelpFile, UnknownFile };
        public enum ProtectionStatus { Unprotected, Protected, Invisible, Unlocked, Locked };
        public enum AutoRunFlag { Disabled, Enabled };

        // Used by both Tape and Disk programs
        private String m_programName;
        private String m_parentName;

        private UInt16 m_startAddress = 0;
        private UInt16 m_endAddress = 0;

        // Used by SedOric Direct Access Files
        private UInt16 m_recordCount = 0;
        private UInt16 m_recordLength = 0;

        // Basic, Code, HIRES, TEXT, Char Set, Data etc.
        private OricProgram.ProgramFormat m_programFormat;

        private OricProgram.AutoRunFlag m_autoRun;

        // For tape programs this is the same as the start address
        private UInt16 m_exeAddress = 0;

        // Only used by Disk programs
        private ProtectionStatus m_protectionStatus = ProtectionStatus.Unprotected;

        // Byte array containing the actual program data
        public Byte[] m_programData;

        public BasicTokens basicTokens;
        public OpCodes opCodes;

        /// <summary>
        /// Constructor builds the Basic token list and calls the New() function to reset the values
        /// </summary>
        public OricProgram()
        {
            // Initialise the program data buffer
            //m_programData = new Byte[0xFFFF];

            // Call New to reset values
            New();
        }

        /// <summary>
        /// Renumbers a Basic program
        /// </summary>
        /// <returns></returns>
        private Boolean Renumber(UInt16 ui16Start)
        {
            return true;
        }

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
            m_protectionStatus = ProtectionStatus.Unprotected;

            m_programFormat = ProgramFormat.UnknownFile;

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

        public String Hexdump()
        {
            UInt16 ui16Index = 0;
            UInt16 ui16Loop = 0;
            UInt16 ui16Address = 0;

            StringBuilder strHexLine = new StringBuilder();
            StringBuilder strAscii = new StringBuilder();
            StringBuilder strHexDump = new StringBuilder();

            ui16Address = StartAddress;

            for(ui16Loop = 0; ui16Loop < ProgramLength; ui16Loop++)
            {
                if (ui16Index == 0)
                {
                    strHexLine.AppendFormat("${0:X4}  ", ui16Address);
                    ui16Address += 16;
                    strAscii.Length = 0;
                }

                Byte bByte = m_programData[ui16Loop];

                if(bByte < 32 || bByte > 126)
                {
                    strAscii.Append(".");
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
                        strAscii.Append(Convert.ToChar(bByte));
                }

                strHexLine.AppendFormat("{0:X2} ", bByte);

                ui16Index++;

                if (ui16Index == 16 || ui16Loop == ProgramLength)
                {
                    strHexDump.AppendFormat("{0,-56:G} {1}\n", strHexLine.ToString(), strAscii.ToString());

                    ui16Index = 0;
                    strHexLine.Length = 0;
                }
            }

            if (strHexLine.Length > 0)
            {
                strHexDump.AppendFormat("{0,-56:G} {1}\n", strHexLine.ToString(), strAscii.ToString());
            }

            return strHexDump.ToString();
        }

        public String List()
        {
            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);

            Byte HighByte = 0;
            Byte LowByte = 0;

            Boolean bREMFlag = false;
            Boolean bDATAFlag = false;
            Boolean bStringFlag = false;
            Boolean bKeyword = false;
            Boolean bMCFlag = false;

            UInt16 ui16Index = 0;

            StringBuilder strListing = new StringBuilder();
            StringBuilder strBasic = new StringBuilder();

            strBasic.EnsureCapacity(255);

            Boolean bEndOfProg = false;

            strListing.Append("{\\rtf\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Consolas;}}");
            strListing.Append(BuildColourTable());
            strListing.Append("{\\*\\generator Msftedit 5.41.15.1507;}\\viewkind4\\uc1\\pard\\lang2057\\f0\\fs18 ");

            if(ProgramName == null)
                ProgramName = "";

            while(!bEndOfProg)
            {
                strBasic.Length = 0;

                // Get the address of the next line
                HighByte = m_programData[ui16Index];
                LowByte = m_programData[ui16Index + 1];

                UInt16 ui16NextAddress = Convert.ToUInt16(HighByte + (LowByte * 256));

                if(ui16NextAddress == 0)
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
                    HighByte = m_programData[ui16Index];
                    LowByte = m_programData[ui16Index + 1];

                    UInt16 uiLineNo = Convert.ToUInt16(HighByte + (LowByte * 256));

                    strBasic.Append("\\cf1 ");
                    strBasic.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    do
                    {
                        Byte bByte = m_programData[ui16Index];

                        if(bByte >= 0x80 && bByte <= 0xF6)
                        {
                            if(bByte == 0x9D || bByte == '\'')
                            {
                                if(!bREMFlag)
                                {
                                    bREMFlag = true;
                                    strBasic.Append("\\cf2 ");
                                }
                            }
                            else if(bByte == 0x91)
                            {
                                if(!bDATAFlag)
                                {
                                    bDATAFlag = true;
                                    strBasic.Append("\\cf2 ");
                                }
                            }
                            else if(bByte == 0xC0)
                            {
                                if(!bMCFlag)
                                {
                                    bMCFlag = true;
                                    strBasic.Append("\\cf0 ");
                                }
                            }
                            else
                            {
                                if(!bREMFlag && !bDATAFlag && !bMCFlag)
                                    strBasic.Append("\\cf2 ");
                            }

                            if(!bKeyword)
                                bKeyword = true;

                            // We have a BASIC token
                            strBasic.Append(basicTokens.GetBasicToken(Convert.ToByte(bByte - 0x80)));

                            if(bREMFlag)
                            {
                                strBasic.Append("\\cf5 ");
                            }

                            if(bDATAFlag)
                            {
                                strBasic.Append("\\cf4 ");
                            }
                        }
                        else
                        {
                            if(bKeyword)
                            {
                                if(!bREMFlag && !bDATAFlag && !bMCFlag)
                                    strBasic.Append("\\cf0 ");

                                bKeyword = false;
                            }

                            if(bByte >= 0x20)
                            {
                                if(bMCFlag)
                                {
                                    if(!Char.IsLetter((Char)bByte))
                                    {
                                        bMCFlag = false;
                                        strBasic.Append("\\cf0 ");
                                    }
                                }

                                if (bByte == '\'')
                                {
                                    if (!bREMFlag && !bStringFlag && !bDATAFlag && !bMCFlag)
                                    {
                                        bREMFlag = true;
                                        strBasic.Append("\'\\cf5 ");
                                    }
                                    else
                                    {
                                        strBasic.Append("\'");
                                    }
                                }
                                else if (bByte == '\"')
                                {
                                    if (!bREMFlag && !bDATAFlag && !bMCFlag)
                                    {
                                        if (!bStringFlag)
                                        {
                                            bStringFlag = true;
                                            strBasic.Append("\"\\cf3 ");
                                        }
                                        else
                                        {
                                            bStringFlag = false;
                                            strBasic.Append("\\cf0 \"");
                                        }
                                    }
                                    else
                                    {
                                        strBasic.Append("\"");
                                    }
                                }
                                else if (bByte == ':')
                                {
                                    if (!bREMFlag && !bStringFlag)
                                    {
                                        if (bMCFlag)
                                        {
                                            bMCFlag = false;
                                            strBasic.Append("\\cf0 :");
                                        }
                                        else
                                        {
                                            strBasic.Append(":");
                                        }
                                    }
                                    else
                                    {
                                        strBasic.Append(":");
                                    }
                                }
                                else if (bByte == 0x60)
                                    strBasic.Append("\\'a9");
                                else if (Convert.ToChar(bByte) == '\\')
                                    strBasic.Append("\\\\");
                                else if (Convert.ToChar(bByte) == '{')
                                    strBasic.Append("\\{");
                                else if (Convert.ToChar(bByte) == '}')
                                    strBasic.Append("\\}");
                                else
                                    strBasic.Append(Convert.ToChar(bByte));
                            }
                        }

                        ui16Index++;
                    } while(m_programData[ui16Index] != 0);

                    strListing.Append(strBasic.ToString());
                    strListing.Append("\\i0\\par\n");

                    ui16Index++;
                }
            }

            strListing.Append("}");

            return strListing.ToString();
        }

        public String ListAsText()
        {
            basicTokens = new BasicTokens(BasicTokens.ROMVersion.V1_1);

            Byte HighByte = 0;
            Byte LowByte = 0;

            Boolean bREMFlag = false;
            Boolean bDATAFlag = false;
            Boolean bStringFlag = false;
            Boolean bKeyword = false;

            UInt16 ui16Index = 0;

            StringBuilder strListing = new StringBuilder();
            StringBuilder strBasic = new StringBuilder();

            strBasic.EnsureCapacity(255);

            Boolean bEndOfProg = false;

            if (ProgramName == null)
            {
                ProgramName = "";
            }

            while(!bEndOfProg)
            {
                strBasic.Length = 0;

                // Get the address of the next line
                HighByte = m_programData[ui16Index];
                LowByte = m_programData[ui16Index + 1];

                UInt16 ui16NextAddress = Convert.ToUInt16(HighByte + (LowByte * 256));

                if(ui16NextAddress == 0)
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
                    HighByte = m_programData[ui16Index];
                    LowByte = m_programData[ui16Index + 1];

                    UInt16 uiLineNo = Convert.ToUInt16(HighByte + (LowByte * 256));
                    strBasic.AppendFormat("{0} ", uiLineNo);

                    ui16Index += 2;

                    if (ui16Index >= m_programData.Length)
                    {
                        bEndOfProg = true;
                    }
                    else
                    {
                        do
                        {
                            Byte bByte = m_programData[ui16Index];

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
                                strBasic.Append(basicTokens.GetBasicToken(Convert.ToByte(bByte - 0x80)));
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
                                            strBasic.Append("\'");
                                        }
                                        else
                                        {
                                            strBasic.Append("\'");
                                        }
                                    }
                                    else if (bByte == '\"')
                                    {
                                        if (!bREMFlag && !bDATAFlag)
                                        {
                                            if (!bStringFlag)
                                            {
                                                bStringFlag = true;
                                                strBasic.Append("\"");
                                            }
                                            else
                                            {
                                                bStringFlag = false;
                                                strBasic.Append("\"");
                                            }
                                        }
                                    }
                                    else if (bByte == 0x60)
                                        strBasic.Append("©");
                                    else
                                        strBasic.Append(Convert.ToChar(bByte));
                                }
                            }

                            ui16Index++;

                            if (ui16Index >= m_programData.Length)
                            {
                                bEndOfProg = true;
                            }
                        } while (!bEndOfProg && m_programData[ui16Index] != 0 && ui16Index < m_programData.Length);
                    }

                    strListing.Append(strBasic.ToString());
                    strListing.Append("\n");

                    ui16Index++;
                }
            }

            return strListing.ToString();
        }

        public String Assembly()
        {
            opCodes = new OpCodes();

            UInt16 ui16Loop = 0;
            UInt16 ui16Address = 0;
            UInt16 ui16BranchAddr = 0;

            String strAscii = "";

            StringBuilder strDissassembly = new StringBuilder();
            strDissassembly.EnsureCapacity(65000);

            if (ProgramName == null)
            {
                ProgramName = "";
            }

            ui16Address = StartAddress;

            Byte bByte = 0x00;

            while(ui16Loop < ProgramLength)
            {
                bByte = m_programData[ui16Loop];

                OpCodes.sOpCode sTmpStructOpCodes = new OpCodes.sOpCode();
                sTmpStructOpCodes = opCodes.FindOpInfo(bByte);

                strAscii = "";

                String strOpParams = "";

                // Current address
                strDissassembly.AppendFormat("${0:X4}  ", ui16Address);

                if (ui16Loop + sTmpStructOpCodes.bOpBytes > ProgramLength)
                {
                    Byte bCurrByte = Convert.ToByte(m_programData[ui16Loop]);

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
                    for (short siIndex = 0; siIndex < sTmpStructOpCodes.bOpBytes; siIndex++)
                    {
                        Byte bCurrByte = Convert.ToByte(m_programData[ui16Loop + siIndex]);

                        strDissassembly.AppendFormat("{0:X2} ", bCurrByte);

                        if (bCurrByte < 32 || bCurrByte > 126)
                        {
                            strAscii += ".";
                        }
                        else
                        {
                            if (bCurrByte == 0x60)
                            {
                                strAscii += "©";
                            }
                            else
                            {
                                strAscii += Convert.ToChar(bCurrByte);
                            }
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

                Byte bByte1 = 0;
                Byte bByte2 = 0;

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
                    case 1: strOpParams = "";
                        break;

                    case 2: strOpParams = String.Format("#${0:X2}", bByte1);
                        break;

                    case 3: strOpParams = String.Format("${0:X2}{1:X2}", bByte2, bByte1);
                        break;

                    case 4: strOpParams = String.Format("${0:X2}", bByte1);
                        break;

                    case 5: // Calculate jump address
                        if (bByte1 > 127)
                        {
                            ui16BranchAddr = (UInt16)(ui16Address - (255 - bByte1));
                            ui16BranchAddr++;
                        }
                        else
                        {
                            ui16BranchAddr = (UInt16)((ui16Address + 2) + bByte1);
                        }

                        strOpParams = String.Format("${0:X4}", ui16BranchAddr);
                        break;

                    case 6: strOpParams = String.Format("${0:X2}{1:X2},X", bByte2, bByte1);
                        break;

                    case 7: strOpParams = String.Format("${0:X2}{1:X2},Y", bByte2, bByte1);
                        break;

                    case 8: strOpParams = String.Format("${0:X2},X", bByte1);
                        break;

                    case 9: strOpParams = String.Format("${0:X2},Y", bByte1);
                        break;

                    case 10: strOpParams = String.Format("(${0:X2},X)", bByte1);
                        break;

                    case 11: strOpParams = String.Format("(${0:X2}),Y", bByte1);
                        break;

                    case 12: strOpParams = "A";
                        break;

                    case 13: strOpParams = String.Format("${0:X2}{1:X2}", bByte2, bByte1);
                        break;
                }

                strDissassembly.AppendFormat("   {0,-3:G} {1,-8:G}   {2,-3}\n",
                                             sTmpStructOpCodes.strOpMne, strOpParams, strAscii);

                ui16Address += sTmpStructOpCodes.bOpBytes;
                ui16Loop += sTmpStructOpCodes.bOpBytes;
            }

            return strDissassembly.ToString();
        }

        private String BuildColourTable()
        {
            // Colour table for BASIC listing
            Color oDefault = Color.Black; // cf0
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

        public UInt16 StartAddress
        {
            get {return m_startAddress;}
            set {m_startAddress = value;}
        }

        public UInt16 EndAddress
        {
            get {return m_endAddress;}
            set {m_endAddress = value;}
        }

        public UInt16 ExeAddress
        {
            get {return m_exeAddress;}
            set {m_exeAddress = value;}
        }

        public UInt16 RecordCount
        {
            get { return m_recordCount; }
            set { m_recordCount = value; }
        }

        public UInt16 RecordLength
        {
            get { return m_recordLength; }
            set { m_recordLength = value; }
        }

        public UInt16 ProgramLength
        {
            get {return Convert.ToUInt16((m_endAddress - m_startAddress) + 1);}
        }

        public OricProgram.AutoRunFlag AutoRun
        {
            get { return m_autoRun; }
            set { m_autoRun = value; }
        }

        public OricProgram.ProgramFormat Format
        {
            get { return m_programFormat; }
            set { m_programFormat = value; }
        }

        public String ProgramName
        {
            get { return m_programName; }
            set { m_programName = value; }
        }

        public String ParentName
        {
            get { return m_parentName; }
            set { m_parentName = value; }
        }

        public ProtectionStatus Protection
        {
            get { return m_protectionStatus; }
            set { m_protectionStatus = value; }
        }

        public string DectoBin(short decVal)
        {
            StringBuilder sBinary = new StringBuilder();

            short siDivisor = 0x80;

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

            String Binary;
            Binary = sBinary.ToString();

            return Binary;
        }
    }
}
