using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace OricExplorer
{
    class OricDos : OricDisk
    {
        Byte directoryTrack = 0x00;
        Byte directorySector = 0x04;

        public UInt16 sectors = 0;
        public UInt16 sectorsUsed = 0;
        public UInt16 sectorsFree = 0;

        public Byte sides = 0;
        public Byte tracksPerSide = 0;
        public Byte sectorsPerTrack = 0;

        public String diskName = "";
        public String diskPathName = "";

        public UInt16 fileCount = 0;

        public int nextAvailableTrack;
        public int nextAvailableSector;

        public OricDisk.DiskTypes diskType = DiskTypes.Unknown;
        public OricDiskInfo diskInfo;

        public void GetDiskInfo(String diskPathname)
        {
            base.LoadDisk(diskPathname);

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            // Read the System Sector
            Byte[] sectorData = base.ReadSector(0, 1);

            System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

            stm.Seek(0x10, SeekOrigin.Begin);

            nextAvailableSector = rdr.ReadByte();
            nextAvailableTrack = rdr.ReadByte();

            directorySector = rdr.ReadByte();
            directoryTrack = rdr.ReadByte();

            sectorsFree = rdr.ReadUInt16();
            sectorsUsed = rdr.ReadUInt16();
            sectors = (UInt16)(sectorsUsed + sectorsFree);

            Byte[] bByteArray = rdr.ReadBytes(21);

            diskName = enc.GetString(bByteArray);
            diskName.Trim();

            diskType = OricDisk.DiskTypes.Master;

            sides = 2;
            tracksPerSide = 40;
            sectorsPerTrack = 16;
        }

        public Boolean SaveFile(string diskName, string fileName, OricProgram program, OricDisk disk)
        {
            Boolean fileSaved = false;

            LoadDisk(diskName);

            // Check if disk has been loaded
            if (DiskLoaded())
            {
                diskInfo = new OricDiskInfo(diskName);

                //ArrayList dir<String, OricFileInfo>
                // Check if file already exists
                OricFileInfo[] diskDirectory = ReadOricDosDirectory();

                int dirIndex = 0;
                Boolean fileMatched = false;

                while(dirIndex < diskDirectory.Length && !fileMatched)
                {
                    if(diskDirectory[dirIndex].ProgramName.Equals(fileName))
                    {
                        fileMatched = true;
                    }

                    dirIndex++;
                }

                if(!fileMatched)
                {
                    nextAvailableTrack = diskInfo.nextAvailableTrack;
                    nextAvailableSector = diskInfo.nextAvailableSector;

                    int noOfSectors = 0;

                    if (program.ProgramLength < 245)
                    {
                        noOfSectors = 1;
                    }
                    else
                    {
                        int remaining = program.ProgramLength - 245;
                        noOfSectors = remaining / 253;
                    }

                    sectorsFree = (ushort)(diskInfo.SectorsFree - noOfSectors);
                    sectorsUsed = (ushort)(diskInfo.SectorsUsed + noOfSectors);

                    // Write program data
                    WriteProgramData(program);

                    // Update disk directory
                    AddDirectoryEntry(fileName, (ushort)noOfSectors, (Byte)nextAvailableTrack, (Byte)nextAvailableSector, program.Protection);

                    // Update System sector (free sectors etc)
                    UpdateSystemSector();

                    if (WriteDisk())
                    {
                        MessageBox.Show("Program saved.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to save program");
                    }

                }
            }

            return fileSaved;
        }

        private void UpdateSystemSector()
        {
            Byte[] sectorData = ReadSector(0, 1);

            // Next free Track/Sector
            sectorData[0x0A] = Convert.ToByte(nextAvailableSector);
            sectorData[0x0B] = Convert.ToByte(nextAvailableTrack);

            sectorData[0x14] = Convert.ToByte((sectorsFree >> 8) & 0xFF);
            sectorData[0x15] = Convert.ToByte(sectorsFree & 0xFF);

            sectorData[0x16] = Convert.ToByte((sectorsUsed >> 8) & 0xFF);
            sectorData[0x17] = Convert.ToByte(sectorsUsed & 0xFF);

            WriteSector(0, 1, sectorData);
        }

        private void WriteProgramData(OricProgram program)
        {
            // How many sectors are needed
            int programLength = program.m_programData.Length;
            int noOfSectors = 0;

            if(programLength < 245)
            {
                noOfSectors = 1;
            }
            else
            {
                int remaining = programLength - 245;
                noOfSectors = remaining / 253;
            }

            // Update first sector
            Byte[] sectorData = new Byte[256];

            // Initialise the sector
            for(int index = 0; index < sectorData.Length; index++)
            {
                sectorData[index] = 0x40;
            }

            sectorData[0x00] = 0x00; // Track pointer to next block
            sectorData[0x01] = 0x00; // Sector pointer to next block

            sectorData[0x02] = 0xFF; // 0xFF - Suitable for !LOAD
            sectorData[0x03] = 0x00;

            // Setup Start address
            sectorData[0x04] = Convert.ToByte((program.StartAddress >> 8) & 0xFF);
            sectorData[0x05] = Convert.ToByte(program.StartAddress & 0xFF);

            // Setup End Address
            sectorData[0x06] = Convert.ToByte((program.EndAddress >> 8) & 0xFF);
            sectorData[0x07] = Convert.ToByte(program.EndAddress & 0xFF);

            if(program.Format == OricProgram.ProgramFormat.BasicProgram)
            {
                if(program.AutoRun == OricProgram.AutoRunFlag.Enabled)
                {
                    sectorData[0x08] = 0x02; // T address or Program type
                    sectorData[0x09] = 0x00; // T address or Program type
                }
                else
                {
                    sectorData[0x08] = 0x01; // T address or Program type
                    sectorData[0x09] = 0x00; // T address or Program type
                }
            }
            else
            {
                if(program.ExeAddress > 0x0000)
                {
                    sectorData[0x08] = Convert.ToByte(program.ExeAddress & 0xFF);
                    sectorData[0x09] = Convert.ToByte((program.ExeAddress >> 8) & 0xFF);
                }
                else
                {
                    sectorData[0x08] = 0x00; // T address or Program type
                    sectorData[0x09] = 0x00; // T address or Program type
                }
            }

            if (noOfSectors > 1)
            {
                sectorData[0x0A] = 0xF5; // 0xF5 = Full otherwise no. of bytes in this block
            }
            else
            {
                sectorData[0x0A] = Convert.ToByte(programLength);
            }

            int sectorPos = 0x0B;
            int dataPos = 0x00;

            int iFirstTrack = nextAvailableTrack;
            int iFirstSector = nextAvailableSector;

            // Write program data to first program sector
            while (dataPos < programLength && sectorPos < 0xFF)
            {
                sectorData[sectorPos] = program.m_programData[dataPos];

                sectorPos++;
                dataPos++;
            }

            // Write program sector to disk
            WriteSector((UInt16)iFirstTrack, (UInt16)iFirstSector, sectorData);

            // Adjust count of no. of Sectors left to write
            noOfSectors--;

            while(noOfSectors > 0)
            {
                // Find next available Sector
                FindNextAvailableSector(iFirstTrack, iFirstSector, ref nextAvailableTrack, ref nextAvailableSector);

                // Initialise the sector
                for (int index = 0; index < sectorData.Length; index++)
                {
                    sectorData[index] = 0x40;
                }

                sectorData[0x00] = (Byte)nextAvailableTrack;
                sectorData[0x01] = (Byte)nextAvailableSector;

                if (programLength - dataPos > 0xFD)
                {
                    sectorData[0x02] = 0xFD; // 0xFD = Full otherwise no. of bytes in this block
                }
                else
                {
                    sectorData[0x02] = (Byte)(programLength - dataPos);
                }

                sectorPos = 0x03;

                // Write program data to the next program sector
                while (dataPos < programLength && sectorPos < 0xFF)
                {
                    sectorData[sectorPos] = program.m_programData[dataPos];

                    sectorPos++;
                    dataPos++;
                }

                // Write program sector to disk
                WriteSector((UInt16)nextAvailableTrack, (UInt16)nextAvailableSector, sectorData);
            }
        }

        private Boolean FindNextAvailableSector(int iFirstTrack, int iFirstSector, ref int iFreeTrack, ref int iFreeSector)
        {
            int iTrack = iFirstTrack;
            int iSector = iFirstSector;

            iSector++;

            Boolean bFreeSector = false;

            while (iTrack < diskInfo.TracksPerSide && !bFreeSector)
            {
                while (iSector <= diskInfo.SectorsPerTrack && !bFreeSector)
                {
                    Byte[] sectorData = ReadSector((ushort)iTrack, (ushort)iSector);

                    if (sectorData[0x00] == 0xFF && sectorData[0x01] == 0xFF)
                    {
                        bFreeSector = true;
                        iFreeSector = (Byte)iSector;
                        iFreeTrack = (Byte)iTrack;
                    }
                    else
                    {
                        iSector++;
                    }
                }

                if (!bFreeSector)
                {
                    iSector = 1;
                    iTrack++;
                }
            }

            return bFreeSector;
        }

        public override OricFileInfo[] ReadDirectory(String diskPathname)
        {
            base.LoadDisk(diskPathname);
            OricFileInfo[] files = ReadOricDosDirectory();
            return files;
        }

        private OricFileInfo[] ReadOricDosDirectory()
        {
            OricFileInfo[] diskDirectory = null;

            int noOfFiles = 0;

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            ArrayList diskCatalog = new ArrayList();

            Byte bNextTrack = Convert.ToByte(0);
            Byte bNextSector = Convert.ToByte(4);

            Byte bCurrTrack = bNextTrack;
            Byte bCurrSector = bNextSector;

            Boolean bMoreDirectories = true;

            while (bMoreDirectories)
            {
                Byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
                System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                Byte[] bByteArray = new Byte[32];

                bNextTrack = rdr.ReadByte();
                bNextSector = rdr.ReadByte();

                int iFilesInDir = Convert.ToInt16(rdr.ReadByte());

                noOfFiles += iFilesInDir;

                for (int iLoop = 0; iLoop < 15; iLoop++)
                {
                    OricFileInfo diskFile = new OricFileInfo();
                    diskFile.MediaType = OricExplorer.MediaType.DiskFile;

                    bByteArray = rdr.ReadBytes(6);

                    if (bByteArray[0] != '\0')
                    {
                        String strFilename = enc.GetString(bByteArray).Trim();

                        if (strFilename.Length > 0)
                        {
                            bByteArray = rdr.ReadBytes(3);
                            String strExtension = enc.GetString(bByteArray).Trim();

                            diskFile.Name = strFilename;
                            diskFile.Extension = strExtension;

                            if (strExtension.Length > 0)
                            {
                                diskFile.ProgramName = String.Format("{0}.{1}", diskFile.Name, diskFile.Extension);
                            }
                            else
                            {
                                diskFile.ProgramName = diskFile.Name;
                            }

                            diskFile.LengthSectors = rdr.ReadUInt16();

                            diskFile.FirstSector = rdr.ReadByte();
                            diskFile.FirstTrack = rdr.ReadByte();

                            diskFile.LastSector = rdr.ReadByte();
                            diskFile.LastTrack = rdr.ReadByte();

                            Byte bProtection = rdr.ReadByte();

                            if (bProtection == 0x80)
                                diskFile.Protection = OricProgram.ProtectionStatus.Protected;
                            else if (bProtection == 0xC0)
                                diskFile.Protection = OricProgram.ProtectionStatus.Invisible;
                            else
                                diskFile.Protection = OricProgram.ProtectionStatus.Unprotected;

                            Byte[] programData = base.ReadSector(diskFile.FirstTrack, diskFile.FirstSector);

                            System.IO.MemoryStream stm2 = new System.IO.MemoryStream(programData, 0, programData.Length);
                            System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

                            bByteArray = rdr2.ReadBytes(2);

                            Byte bLoadable = rdr2.ReadByte();

                            bByteArray = rdr2.ReadBytes(1);

                            if (bLoadable == 0xFF)
                            {
                                diskFile.StartAddress = rdr2.ReadUInt16();
                                diskFile.EndAddress = rdr2.ReadUInt16();

                                // 0000 = code no T, 0001 = basic, 0002 = basic AUTO, ABCD = code T address
                                UInt16 ui16ExeAddress = rdr2.ReadUInt16();

                                if (ui16ExeAddress == 0x0000)
                                {
                                    diskFile.ExeAddress = diskFile.StartAddress;
                                    diskFile.Format = OricProgram.ProgramFormat.CodeFile;
                                    diskFile.AutoRun = OricProgram.AutoRunFlag.Disabled;
                                }
                                else if (ui16ExeAddress == 0x0001)
                                {
                                    diskFile.ExeAddress = diskFile.StartAddress;
                                    diskFile.Format = OricProgram.ProgramFormat.BasicProgram;
                                    diskFile.AutoRun = OricProgram.AutoRunFlag.Disabled;
                                }
                                else if (ui16ExeAddress == 0x0002)
                                {
                                    diskFile.ExeAddress = diskFile.StartAddress;
                                    diskFile.Format = OricProgram.ProgramFormat.BasicProgram;
                                    diskFile.AutoRun = OricProgram.AutoRunFlag.Disabled;
                                }
                                else
                                {
                                    diskFile.ExeAddress = ui16ExeAddress;
                                    diskFile.Format = OricProgram.ProgramFormat.CodeFile;
                                    diskFile.AutoRun = OricProgram.AutoRunFlag.Enabled;
                                }

                                if (diskFile.Format == OricProgram.ProgramFormat.CodeFile)
                                {
                                    switch (diskFile.StartAddress)
                                    {
                                        case 0xBB80: diskFile.Format = OricProgram.ProgramFormat.TextScreen; break;
                                        case 0xBBA8: diskFile.Format = OricProgram.ProgramFormat.TextScreen; break;
                                        case 0xA000: diskFile.Format = OricProgram.ProgramFormat.HiresScreen; break;
                                        case 0xB500: diskFile.Format = OricProgram.ProgramFormat.CharacterSet; break;
                                        default: diskFile.Format = OricProgram.ProgramFormat.CodeFile; break;
                                    }

                                    if (diskFile.StartAddress >= 0xBB80 && diskFile.StartAddress <= 0xBFB8)
                                        diskFile.Format = OricProgram.ProgramFormat.TextScreen;
                                }
                            }
                            else
                            {
                                // Possibly a datafile? (!OPEN/!PUT)
                                diskFile.StartAddress = 0x0000;
                                diskFile.EndAddress = Convert.ToUInt16(253 * diskFile.LengthSectors);
                                diskFile.ExeAddress = 0x0000;
                                diskFile.Format = OricProgram.ProgramFormat.UnknownFile;
                                diskFile.AutoRun = OricProgram.AutoRunFlag.Disabled;
                            }

                            diskFile.Folder = base.diskFolder;
                            diskFile.ParentName = base.diskPathname;

                            diskCatalog.Add(diskFile);
                        }
                    }
                    else
                    {
                        bByteArray = rdr.ReadBytes(10);
                    }
                }

                if (bNextTrack == 0 && bNextSector == 0)
                    bMoreDirectories = false;
                else
                {
                    bCurrTrack = bNextTrack;
                    bCurrSector = bNextSector;
                }
            }

            diskDirectory = new OricFileInfo[diskCatalog.Count];
            diskCatalog.CopyTo(diskDirectory);

            return diskDirectory;
        }

        public override OricProgram LoadFile(String diskName, OricFileInfo programInfo)
        {
            OricProgram loadProgram = new OricProgram();
            loadProgram.New();

            String diskPathname = Path.Combine(programInfo.Folder, programInfo.ParentName);

            if (base.LoadDisk(diskPathname))
            {
                loadProgram.Format = programInfo.Format;
                loadProgram.StartAddress = programInfo.StartAddress;
                loadProgram.EndAddress = programInfo.EndAddress;

                Byte bFirstTrack = programInfo.FirstTrack;
                Byte bFirstSector = programInfo.FirstSector;

                String strSectorKey = base.CreateKey(bFirstTrack, bFirstSector);

                // Get sector data
                //Byte[] sectorData = new Byte[512];
                Byte[] sectorData = base.ReadSector(bFirstTrack, bFirstSector);

                System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
                System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                Byte[] bByteArray = new Byte[32];
                Byte bNoOfBytes = 0;

                Byte bNextTrack = rdr.ReadByte();
                Byte bNextSector = rdr.ReadByte();

                if (programInfo.Format == OricProgram.ProgramFormat.UnknownFile)
                {
                    bByteArray = rdr.ReadBytes(1);
                    bNoOfBytes = 0xFD;  // 253 bytes
                }
                else
                {
                    bByteArray = rdr.ReadBytes(8);
                    bNoOfBytes = rdr.ReadByte();
                }

                loadProgram.m_programData = new Byte[programInfo.LengthBytes];

                Byte bByte = 0;
                int iIndex = 0;

                for (int iLoop = 0; iLoop < bNoOfBytes; iLoop++)
                {
                    bByte = rdr.ReadByte();
                    loadProgram.m_programData[iIndex] = bByte;
                    iIndex++;
                }

                while (bNextSector != 0)
                {
                    strSectorKey = CreateKey(bNextTrack, bNextSector);

                    //Byte[] programData = new Byte[512];
                    Byte[] programData = base.ReadSector(bNextTrack, bNextSector);

                    System.IO.MemoryStream stm2 = new System.IO.MemoryStream(programData, 0, programData.Length);
                    System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

                    bNextTrack = rdr2.ReadByte();
                    bNextSector = rdr2.ReadByte();
                    bNoOfBytes = rdr2.ReadByte();

                    for (int iLoop = 0; iLoop < (bNoOfBytes); iLoop++)
                    {
                        try
                        {
                            bByte = rdr2.ReadByte();
                            loadProgram.m_programData[iIndex] = bByte;
                            iIndex++;
                        }
                        catch(IndexOutOfRangeException ex)
                        {
                            String strMessage = ex.Message;
                        }
                        catch (EndOfStreamException ex)
                        {
                            String strMessage = ex.Message;
                        }
                    }
                }
            }

            return loadProgram;
        }

        internal UInt16[] BuildSectorMap(String diskPathname)
        {
            base.LoadDisk(diskPathname);

            fileCount = 0;

            UInt16 noOfSectors = (UInt16)((tracksPerSide * sectorsPerTrack) * sides);

            UInt16[] sectorMap = new UInt16[noOfSectors];

            for (int index = 0; index < noOfSectors; index++)
            {
                sectorMap[index] = 0xFFFF;
            }

            SectorMapUpdate(0, 1, 0x0101, ref sectorMap);

            int iFileNum = 1;

            Byte bNextTrack;
            Byte bNextSector;

            String strSectorKey = "";

            Byte directoryTrack = 0x00;
            Byte directorySector = 0x04;
            Byte nextDirectoryTrack = 0x00;
            Byte nextDirectorySector = 0x04;

            while (directorySector != 0x00)
            {
                Byte[] directory = this.ReadSector(directoryTrack, directorySector);

                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(directory, 0, directory.Length);
                System.IO.BinaryReader binReader = new System.IO.BinaryReader(memoryStream);

                nextDirectoryTrack = binReader.ReadByte();
                nextDirectorySector = binReader.ReadByte();

                Byte noOfFiles = binReader.ReadByte();
                fileCount += noOfFiles;

                SectorMapUpdate(directoryTrack, directorySector, (UInt16)(0x0400 + noOfFiles), ref sectorMap);

                directoryTrack = nextDirectoryTrack;
                directorySector = nextDirectorySector;
            }

            // Mark sectors used by each file in the directory
            foreach (OricFileInfo fileInfo in ReadOricDosDirectory())
            {
                SectorMapUpdate(fileInfo.FirstTrack, fileInfo.FirstSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)), ref sectorMap);

                strSectorKey = CreateKey(fileInfo.FirstTrack, fileInfo.FirstSector);

                bNextTrack = fileInfo.FirstTrack;
                bNextSector = fileInfo.FirstSector;

                do
                {
                    // Get sector data
                    //Byte[] sectorData = new Byte[512];
                    Byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                    System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
                    System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                    bNextTrack = rdr.ReadByte();
                    bNextSector = rdr.ReadByte();

                    if (bNextSector != 0)
                    {
                        SectorMapUpdate(bNextTrack, bNextSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)), ref sectorMap);
                        strSectorKey = CreateKey(bNextTrack, bNextSector);
                    }
                } while (bNextSector != 0);

                iFileNum++;
            }
            
            return sectorMap;
        }

        private void SectorMapMarkDOSSectors(Byte track, Byte sector, int sectorCount, ref UInt16[] diskSectorMap)
        {
            while (sectorCount > 0)
            {
                // Mark sector as DOS sector
                SectorMapUpdate(track, sector, 0x0800, ref diskSectorMap);

                sector++;

                if (sector > sectorsPerTrack)
                {
                    track++;
                    sector = 1;
                }

                sectorCount--;
            }
        }

        private void SectorMapMarkDOSSectors(Byte currTrack, Byte currSector, Byte lastTrack, Byte lastSector, Byte marker, ref UInt16[] diskSectorMap)
        {
            // Firstly, make descriptor
            SectorMapUpdate(currTrack, currSector, (ushort)(0x0880 + marker), ref diskSectorMap);

            // Now mark sectors used by the Bank
            Boolean bCompleted = false;

            while (!bCompleted)
            {
                currSector++;

                if (currSector > sectorsPerTrack)
                {
                    currTrack++;
                    currSector = 1;
                }

                SectorMapUpdate(currTrack, currSector, (ushort)(0x0800 + marker), ref diskSectorMap);

                if (currSector == lastSector && currTrack == lastTrack)
                    bCompleted = true;
            }
        }

        private void SectorMapUpdate(Byte track, Byte sector, UInt16 marker, ref UInt16[] diskSectorMap)
        {
            if ((track & 0x80) == 0x80)
            {
                track = (Byte)(track & 0x7F);
                track += tracksPerSide;
            }

            int index = (track * sectorsPerTrack) + (sector - 1);

            try
            {
                diskSectorMap[index] = marker;
            }
            catch (Exception e)
            {
                String oMessage = e.Message;
            }
        }

        /* Oric DOS Directory Sector Structure
         * $00 - Track (pointer to next directory, 0 if no more)
         * $01 - Sector (pointer to next directory, 0 if no more)
         * $02 - Number of files in directory (max 15)

         * $03,$08 - Filename (null if no file in slot)
         * $09,$0B - Filename extension
         * $0C,$0D - Number of sectors taken by file (2 bytes)

         * $0E     - Sector of first block of program
         * $0F     - Track of first block of program
         * $10     - Sector of last block of program
         * $11     - Track of last block of program
         * $12     - Status (P, N or I)

         * $13,$22 - Repeat sequence in 16 byte blocks
         */

        #region Disk Functions
        #endregion

        #region Directory Functions
        public void AddDirectoryEntry(String programName, UInt16 noOfSectors, Byte firstTrack, Byte firstSector, OricProgram.ProtectionStatus status)
        {
            // Find first free slot then add entry
            int track = 0;
            int sector = 0;
            int entry = 0;

            if (findFreeDirectorySlot(ref track, ref sector, ref entry))
            {
                // Slot found, need to put new entry in the free slot
                Byte[] sectorData = ReadSector((ushort)track, (ushort)sector);

                int entryIndex = (entry * 16) + 3;

                int noOfEntriesInDir = sectorData[0x02];

                String name = Path.GetFileNameWithoutExtension(programName);
                String ext = Path.GetExtension(programName);

                name = name.PadRight(6, ' ');
                ext = ext.PadRight(3, ' ');
                ext = ext.Substring(1);

                // File name
                for(int index = 0; index < 6; index++)
                {
                    sectorData[entryIndex] = Convert.ToByte(name[index]);
                    entryIndex++;
                }

                // Extension
                for (int index = 0; index < 3; index++)
                {
                    sectorData[entryIndex] = Convert.ToByte(ext[index]);
                    entryIndex++;
                }

                // No. of Sectors used (2 bytes)
                sectorData[entryIndex] = Convert.ToByte((noOfSectors >> 8) & 0xFF);
                sectorData[entryIndex + 1] = Convert.ToByte(noOfSectors & 0xFF);

                entryIndex += 2;

                // Track/Sector of first block
                sectorData[entryIndex] = firstSector;
                sectorData[entryIndex + 1] = firstTrack;

                entryIndex += 2;

                // Track/Sector of last block
                sectorData[entryIndex] = firstSector;
                sectorData[entryIndex + 1] = firstTrack;

                entryIndex += 2;

                // Status (P,N)
                sectorData[entryIndex] = (Byte)status;

                noOfEntriesInDir++;
                sectorData[0x02] = Convert.ToByte(noOfEntriesInDir);

                WriteSector((ushort)track, (ushort)sector, sectorData);
            }
            else
            {
                // No free space
            }
        }

        public void DeleteDirectoryEntry()
        {
        }

        public void RenameDirectoryEntry(String oldName, String newName)
        {
        }

        public void UpdateDirectoryEntry()
        {
        }
        #endregion

        #region File Functions
        #endregion

        #region Other Functions
        void readSector(Byte track, Byte sector, ref MemoryStream memStream, ref BinaryReader reader)
        {
            // Read the System Sector
            Byte[] sectorData = base.ReadSector(track, sector);

            memStream = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            reader = new System.IO.BinaryReader(memStream);
        }

        Boolean findFreeDirectorySlot(ref int track, ref int sector, ref int entry)
        {
            Boolean slotFound = false;

            Boolean moreDirectories = true;

            Byte dirTrack = directoryTrack;
            Byte dirSector = directorySector;

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            while (moreDirectories && !slotFound)
            {
                MemoryStream memStream = new MemoryStream();
                BinaryReader reader = new BinaryReader(memStream);

                readSector(dirTrack, dirSector, ref memStream, ref reader);

                Byte nextDirTrack = reader.ReadByte();
                Byte nextDirSector = reader.ReadByte();

                Byte noOfFiles = reader.ReadByte();

                if (noOfFiles != 15)
                {
                    // Should be a free slot here somewhere
                    entry = 0;

                    while (!slotFound || entry > 15)
                    {
                        Byte[] filename = reader.ReadBytes(6);

                        if (filename[0] == 0x00)
                        {
                            slotFound = true;
                            track = dirTrack;
                            sector = dirSector;
                        }
                        else
                        {
                            // Current slot not empty
                            entry++;

                            // Skip to next entry
                            memStream.Seek(10, SeekOrigin.Current);
                        }
                    }
                }
                else
                {
                    // Directory is full
                    dirTrack = nextDirTrack;
                    dirSector = nextDirSector;
                }

                if (nextDirTrack == 0x00 && nextDirTrack == 0x00)
                {
                    moreDirectories = false;
                }
            }

            return slotFound;
        }
        #endregion

    }
}
