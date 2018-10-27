using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace OricExplorer
{
    internal class OricTape
    {
        Boolean m_bWriteToLogfile = false;
        StreamWriter swLogfile;

        Byte m_bProgramCount = 0;

        String m_strTapeName = "";

        Byte[] m_bTapeBuffer;
        UInt32 m_ui32BufferIdx = 0;

        private struct ProgramHeader
        {
            public UInt16 ui16StartAddress;
            public UInt16 ui16EndAddress;
            public Byte bProgramFormat;
            public OricProgram.AutoRunFlag bAutoRun;
            public String strProgramName;
        };

        public OricFileInfo[] Catalog(FileInfo fiFileInfo)
        {
            Int16 i16ProgramCount = 0;
            Int16 i16NoNameCount = 1;

            Boolean bReadError = false;

            // Store the tape name
            TapeName = fiFileInfo.FullName;

            if(fiFileInfo.Name == "NewTape.tap")
            {
                i16NoNameCount = 1;
                i16ProgramCount = 0;
            }

            // Read the entire tape into a buffer
            ReadTapeIntoBuffer();

            // Create an array to store program information
            ArrayList tapeCatalog = new ArrayList();

            // Initialise the buffer position
            m_ui32BufferIdx = 0;

            // Syncronise with the tape header
            while(SyncTape() && !bReadError)
            {
                // Store the program header
                ProgramHeader programHeader = ReadProgramHeader();

                // Check details in Program header are valid
                if (programHeader.ui16StartAddress >= programHeader.ui16EndAddress)
                {
                    if (m_bWriteToLogfile)
                    {
                        swLogfile.WriteLine("> *** Invalid Start/End address found in header. ***");
                        swLogfile.WriteLine("> *** Start : ${0:X4}, End : ${1:X4} ***",
                                            programHeader.ui16StartAddress, programHeader.ui16EndAddress);

                        bReadError = true;

                        m_ui32BufferIdx = (UInt32)(m_bTapeBuffer.Length + 1);
                    }
                }
                else
                {
                    // Create a Catalog object to store tape information
                    OricFileInfo tapeProgram = new OricFileInfo();

                    tapeProgram.Folder = fiFileInfo.DirectoryName;

                    // Set the parent name
                    tapeProgram.ParentName = fiFileInfo.Name;

                    // Store program information
                    tapeProgram.StartAddress = programHeader.ui16StartAddress;
                    tapeProgram.EndAddress = programHeader.ui16EndAddress;
                    tapeProgram.AutoRun = programHeader.bAutoRun;

                    if (programHeader.bProgramFormat == 0x00)
                        tapeProgram.Format = OricProgram.ProgramFormat.BasicProgram;
                    else
                    {
                        if (programHeader.ui16StartAddress == 0xA000)
                            tapeProgram.Format = OricProgram.ProgramFormat.HiresScreen;
                        else if (programHeader.ui16StartAddress == 0xB500)
                            tapeProgram.Format = OricProgram.ProgramFormat.CharacterSet;
                        else if (programHeader.ui16StartAddress == 0xBB80 || programHeader.ui16StartAddress == 0xBBA8)
                            tapeProgram.Format = OricProgram.ProgramFormat.TextScreen;
                        else
                            tapeProgram.Format = OricProgram.ProgramFormat.CodeFile;
                    }

                    if (programHeader.strProgramName == null)
                    {
                        tapeProgram.ProgramName = String.Format("NONAME{0:G3}", i16NoNameCount);
                        i16NoNameCount++;
                    }
                    else
                    {
                        tapeProgram.ProgramName = programHeader.strProgramName;
                    }

                    tapeProgram.MediaType = OricExplorer.MediaType.TapeFile;

                    tapeProgram.ProgramIndex = i16ProgramCount;
                    i16ProgramCount++;

                    // Add information to the catalog
                    tapeCatalog.Add(tapeProgram);

                    // Move buffer pointer beyond program data
                    m_ui32BufferIdx += tapeProgram.LengthBytes;

                    // Skip passed the null terminator
                    m_ui32BufferIdx++;
                }
            }

            OricFileInfo[] programList = new OricFileInfo[tapeCatalog.Count];
            tapeCatalog.CopyTo(programList);

            return programList;
        }

        public Boolean CheckTapeLeader()
        {
            m_bWriteToLogfile = false;

            // Read the entire tape into a buffer
            ReadTapeIntoBuffer();

            // Reset the index value
            m_ui32BufferIdx = 0;

            // Check for a valid tape leader (i.e. 0x16, 0x16, 0x16, 0x24)
            Boolean validTape = SyncTape();

            return validTape;
        }

        private Boolean SyncTape()
        {
            UInt32 ui32Offset = 0;
            Byte bByte = 0;

            if (m_ui32BufferIdx >= (m_bTapeBuffer.Length - 1))
            {
                return false;
            }

            if (m_bWriteToLogfile)
            {
                swLogfile.WriteLine("> Searching for tape leader. (Offset 0x{0:X4})", m_ui32BufferIdx);
            }

            do
            {
                bByte = m_bTapeBuffer[m_ui32BufferIdx];

                m_ui32BufferIdx++;
            } while(bByte != 0x16 && m_ui32BufferIdx < (m_bTapeBuffer.Length - 1));

            if(m_ui32BufferIdx == (m_bTapeBuffer.Length - 1))
            {
                return false;
            }

            ui32Offset = m_ui32BufferIdx;

            do
            {
                bByte = m_bTapeBuffer[m_ui32BufferIdx];

                m_ui32BufferIdx++;
            } while(bByte == 0x16 && m_ui32BufferIdx < (m_bTapeBuffer.Length - 1));

            if(m_ui32BufferIdx == (m_bTapeBuffer.Length - 1))
            {
                return false;
            }

            if(bByte != 0x24)
            {
                if (m_bWriteToLogfile)
                {
                    ui32Offset--;
                    swLogfile.WriteLine("> *** Tape leader not found, invalid tape file. (Offset 0x{0:X4}) ***", ui32Offset);
                }

                return false;
            }

            m_ui32BufferIdx++;

            if (m_bWriteToLogfile)
            {
                ui32Offset--;
                swLogfile.WriteLine("> Tape leader found. (Offset 0x{0:X4})", ui32Offset);
            }

            return true;
        }

        private ProgramHeader ReadProgramHeader()
        {
            Byte HighByte = 0;
            Byte LowByte = 0;

            ProgramHeader programHeader = new ProgramHeader();

            // Skip passed the unused bytes
            m_ui32BufferIdx += 1;

            if (m_bWriteToLogfile)
            {
                swLogfile.WriteLine("> Reading program header. (Offset 0x{0:X4})", m_ui32BufferIdx);
            }

            // Get the program type
            Byte bProgramFormat = m_bTapeBuffer[m_ui32BufferIdx];

            programHeader.bProgramFormat = m_bTapeBuffer[m_ui32BufferIdx];

            m_ui32BufferIdx++;

            // Get the AutoRun flag
            if(m_bTapeBuffer[m_ui32BufferIdx] == 0x00)
                programHeader.bAutoRun = OricProgram.AutoRunFlag.Disabled;
            else
                programHeader.bAutoRun = OricProgram.AutoRunFlag.Enabled;

            m_ui32BufferIdx++;

            // Get the programs end address
            HighByte = m_bTapeBuffer[m_ui32BufferIdx];
            LowByte = m_bTapeBuffer[m_ui32BufferIdx + 1];

            programHeader.ui16EndAddress = Convert.ToUInt16(LowByte + (HighByte * 256));

            m_ui32BufferIdx += 2;

            // Get the programs start address
            HighByte = m_bTapeBuffer[m_ui32BufferIdx];
            LowByte = m_bTapeBuffer[m_ui32BufferIdx + 1];

            programHeader.ui16StartAddress = Convert.ToUInt16(LowByte + (HighByte * 256));

            if(bProgramFormat == 0x00)
                programHeader.bProgramFormat = (Byte)OricProgram.ProgramFormat.BasicProgram;
            else
            {
                if(programHeader.ui16StartAddress == 0xA000)
                    programHeader.bProgramFormat = (Byte)OricProgram.ProgramFormat.HiresScreen;
                else if(programHeader.ui16StartAddress == 0xB500)
                    programHeader.bProgramFormat = (Byte)OricProgram.ProgramFormat.CharacterSet;
                else if(programHeader.ui16StartAddress == 0xBB80 || programHeader.ui16StartAddress == 0xBBA8)
                    programHeader.bProgramFormat = (Byte)OricProgram.ProgramFormat.TextScreen;
                else
                    programHeader.bProgramFormat = (Byte)OricProgram.ProgramFormat.CodeFile;
            }

            m_ui32BufferIdx += 3;

            while(m_bTapeBuffer[m_ui32BufferIdx] != 0)
            {
                programHeader.strProgramName += Convert.ToChar(m_bTapeBuffer[m_ui32BufferIdx]);
                m_ui32BufferIdx++;
            }

            // Skip passed the null terminator
            m_ui32BufferIdx++;

            return programHeader;
        }

        private void ReadTapeIntoBuffer()
        {
            m_bTapeBuffer = File.ReadAllBytes(TapeName);
        }

        public OricProgram Load(String strTapeName, String strProgName, short siProgIndex)
        {
            Int16 i16ProgramCount = 0;
            Int16 i16NoNameCount = 0;

            OricProgram loadProgram = new OricProgram();

            TapeName = strTapeName;

            ReadTapeIntoBuffer();

            m_ui32BufferIdx = 0;

            while(SyncTape() && siProgIndex >= i16ProgramCount)
            {
                // Store the program header
                ProgramHeader programHeader = ReadProgramHeader();

                // Set the parent name
                loadProgram.ParentName = strTapeName;

                // Store program information
                loadProgram.StartAddress = programHeader.ui16StartAddress;
                loadProgram.EndAddress = programHeader.ui16EndAddress;
                loadProgram.AutoRun = programHeader.bAutoRun;

                if(programHeader.bProgramFormat == 0x00)
                    loadProgram.Format = OricProgram.ProgramFormat.BasicProgram;
                else
                {
                    if(programHeader.ui16StartAddress == 0xA000)
                        loadProgram.Format = OricProgram.ProgramFormat.HiresScreen;
                    else if(programHeader.ui16StartAddress == 0xB500)
                        loadProgram.Format = OricProgram.ProgramFormat.CharacterSet;
                    else if(programHeader.ui16StartAddress == 0xBB80 || programHeader.ui16StartAddress == 0xBBA8)
                        loadProgram.Format = OricProgram.ProgramFormat.TextScreen;
                    else
                        loadProgram.Format = OricProgram.ProgramFormat.CodeFile;
                }

                if(programHeader.strProgramName == null)
                {
                    loadProgram.ProgramName = String.Format("NONAME{0:G3}", i16NoNameCount);
                    i16NoNameCount++;
                }
                else
                {
                    loadProgram.ProgramName = programHeader.strProgramName;
                }

                if(i16ProgramCount == siProgIndex)
                {
                    UInt16 ui16Count = 0;
                    UInt16 ui16ProgLength = loadProgram.ProgramLength;

                    loadProgram.m_programData = new Byte[ui16ProgLength];

                    do
                    {
                        loadProgram.m_programData[ui16Count] = m_bTapeBuffer[m_ui32BufferIdx];

                        ui16Count++;
                        m_ui32BufferIdx++;
                    } while((ui16Count < ui16ProgLength) && (m_ui32BufferIdx < m_bTapeBuffer.Length));
                }
                else
                {
                    // Move buffer pointer beyond program data
                    m_ui32BufferIdx += loadProgram.ProgramLength;

                    // Skip passed the null terminator
                    m_ui32BufferIdx++;
                }

                i16ProgramCount++;
            }

            return loadProgram;
        }

        public void WriteFiles(ArrayList ProgramList, FileMode WriteFileMode)
        {
            FileStream tapeFile = new FileStream(m_strTapeName, WriteFileMode);
            
            using(BinaryWriter binWriter = new BinaryWriter(tapeFile))
            {
                foreach(OricProgram program in ProgramList)
                {
                    binWriter.Write((Byte)0x16);
                    binWriter.Write((Byte)0x16);
                    binWriter.Write((Byte)0x16);
                    binWriter.Write((Byte)0x24);
                    binWriter.Write((Byte)0x00);
                    binWriter.Write((Byte)0x00);

                    if(program.Format == OricProgram.ProgramFormat.BasicProgram)
                        binWriter.Write((Byte)0x00);
                    else
                        binWriter.Write((Byte)0x01);

                    if(program.AutoRun == OricProgram.AutoRunFlag.Enabled)
                        binWriter.Write((Byte)0x01);
                    else
                        binWriter.Write((Byte)0x00);

                    //binWriter.Write((Byte)0x00);

                    Byte hi = Convert.ToByte((program.EndAddress >> 8) & 0xFF);
                    Byte lo = Convert.ToByte(program.EndAddress & 0xFF);

                    binWriter.Write((Byte)hi);
                    binWriter.Write((Byte)lo);

                    hi = Convert.ToByte((program.StartAddress >> 8) & 0xFF);
                    lo = Convert.ToByte(program.StartAddress & 0xFF);

                    binWriter.Write((Byte)hi);
                    binWriter.Write((Byte)lo);

                    binWriter.Write((Byte)0x00);

                    int iIndex = 0;

                    for(iIndex = 0; iIndex < program.ProgramName.Length; iIndex++)
                    {
                        binWriter.Write(Convert.ToByte(program.ProgramName[iIndex]));
                    }

                    binWriter.Write((Byte)0x00);

                    // Write file data
                    for(iIndex = 0; iIndex < program.ProgramLength; iIndex++)
                    {
                        binWriter.Write((Byte)program.m_programData[iIndex]);
                    }
                }
            }

            tapeFile.Close();
        }

        public Boolean SaveFile(OricProgram oricFile)
        {
            // Open the Tape and set pointer to the end of file
            FileStream tapeFile = new FileStream(m_strTapeName, FileMode.Append);
            
            using(BinaryWriter binWriter = new BinaryWriter(tapeFile))
            {
                // Write the Tape leader
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x16);
                binWriter.Write((Byte)0x24);
                binWriter.Write((Byte)0x00);
                binWriter.Write((Byte)0x00);

                // Write the Program format
                if (oricFile.Format == OricProgram.ProgramFormat.BasicProgram)
                    binWriter.Write((Byte)0x00);
                else
                    binWriter.Write((Byte)0x01);

                // Write the Auto run flag
                if (oricFile.AutoRun == OricProgram.AutoRunFlag.Enabled)
                    binWriter.Write((Byte)0x01);
                else
                    binWriter.Write((Byte)0x00);

                // Get the High and Low bytes of the End address and write to file
                Byte hi = Convert.ToByte((oricFile.EndAddress >> 8) & 0xFF);
                Byte lo = Convert.ToByte(oricFile.EndAddress & 0xFF);

                binWriter.Write((Byte)hi);
                binWriter.Write((Byte)lo);

                // Get the High and Low bytes of the Start address and write to file
                hi = Convert.ToByte((oricFile.StartAddress >> 8) & 0xFF);
                lo = Convert.ToByte(oricFile.StartAddress & 0xFF);

                binWriter.Write((Byte)hi);
                binWriter.Write((Byte)lo);

                // Write unused byte
                binWriter.Write((Byte)0x00);

                int iIndex = 0;

                // Write the Program name
                for (iIndex = 0; iIndex < oricFile.ProgramName.Length; iIndex++)
                {
                    binWriter.Write(Convert.ToByte(oricFile.ProgramName[iIndex]));
                }

                // NULL terminate the Program name
                binWriter.Write((Byte)0x00);

                // Write file data
                for (iIndex = 0; iIndex < oricFile.ProgramLength; iIndex++)
                {
                    binWriter.Write((Byte)oricFile.m_programData[iIndex]);
                }
            }

            // Close the Tape file
            tapeFile.Close();

            return true;
        }

        public String TapeName
        {
            get { return m_strTapeName; }
            set { m_strTapeName = value; }
        }

        public Byte ProgramCount
        {
            get { return m_bProgramCount; }
        }

        public Boolean WriteToLogFile
        {
            get { return m_bWriteToLogfile; }
            set { m_bWriteToLogfile = value; }
        }

        public StreamWriter SetLogfile
        {
            set { swLogfile = value; }
        }
    }

    // Sample Code from BASIC editor to update a Tape program
    //TapeInfo tapeInfo = (TapeInfo)treeNodeSelected.Parent.Tag;

    //OricTape oricTape = new OricTape();
    //oricTape.TapeName = Path.Combine(tapeInfo.Folder, tapeInfo.Name);

    //FileInfo fiFileInfo = new FileInfo(Path.Combine(tapeInfo.Folder, tapeInfo.Name));
    //Catalog[] tapeCatalog = oricTape.Catalog(fiFileInfo);

    //ArrayList programList = new ArrayList();

    // loop thru progs loading each one and adding it to an array of OricProgram
    // call WriteFiles using the array to update the Tape.
    //for (int iIndex = 0; iIndex < tapeCatalog.Length; iIndex++)
    //{
    //    OricProgram tapeProgram = new OricProgram();
    //    tapeProgram = oricTape.Load(oricTape.TapeName, "", (short)iIndex);

    //    if (iIndex == iTapeProgramIndex)
    //    {
    //        programList.Add((OricProgram)oricProgram);
    //    }
    //    else
    //    {
    //        programList.Add((OricProgram)tapeProgram);
    //    }
    //}

    //oricTape.WriteFiles(programList, FileMode.Create);

    // Tape Operations
    // ===============
    // 1. Rename Program
    // 2. Insert Program
    // 3. Delete Program
    // 4. Replace Program
    // 5. Add Program (end of tape)
}
