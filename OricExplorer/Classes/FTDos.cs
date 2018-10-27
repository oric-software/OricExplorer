using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OricExplorer
{
    class FTDos : OricDisk
    {
        Byte directoryTrack = 0x00;
        Byte directorySector = 0x00;

        public UInt16 sectors = 0;
        public UInt16 sectorsUsed = 0;
        public UInt16 sectorsFree = 0;

        public UInt16 sides = 0;
        public UInt16 tracksPerSide = 0;
        public UInt16 sectorsPerTrack = 0;

        public UInt16 noOfFiles = 0;
        public UInt16 noOfDirectories = 0;

        public String diskName = "";

        public DiskTypes diskType = DiskTypes.Unknown;

        public void GetDiskInfo(String diskPathname)
        {
            base.LoadDisk(diskPathname);

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            // Read the System Sector
            Byte[] sectorData = base.ReadSector(20, 1);

            System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

            stm.Seek(0xF8, SeekOrigin.Begin);

            Byte[] bByteArray = rdr.ReadBytes(8);

            diskName = enc.GetString(bByteArray);
            diskName.Trim();

            sectorData = base.ReadSector(0, 1);

            System.IO.MemoryStream stm2 = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

            bByteArray = rdr2.ReadBytes(4);

            if (bByteArray[0] == 0x78 && bByteArray[1] == 0xA9 && bByteArray[2] == 0x7F && bByteArray[3] == 0x8D)
            {
                diskType = DiskTypes.Master;
            }
            else
            {
                diskType = DiskTypes.Slave;
            }

            sides = 2;
            tracksPerSide = 41;
            sectorsPerTrack = 17;

            sectors = (UInt16)((tracksPerSide * sectorsPerTrack) * sides);

            OricFileInfo[] programList = ReadDirectory(diskPathname);

            foreach (OricFileInfo programInfo in programList)
            {
                UInt16 sectorsUsedByProgram = programInfo.LengthSectors;
                sectorsUsed += sectorsUsedByProgram;
            }

            if(diskType == DiskTypes.Master)
            {
                sectorsUsed += 62;
            }

            sectorsFree = (UInt16)(sectors - sectorsUsed);

            noOfFiles = (UInt16)programList.Count();
        }

        public override OricFileInfo[] ReadDirectory(String diskPathname)
        {
            base.LoadDisk(diskPathname);
            OricFileInfo[] files = ReadFTDosDirectory();
            return files;
        }

        private OricFileInfo[] ReadFTDosDirectory()
        {
            OricFileInfo[] diskDirectory = null;

            int iDirFileCount = 0;

            UInt16 i16DirectoryIndex = 1;
            UInt16 i16EntryIndex = 1;

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            ArrayList diskCatalog = new ArrayList();

            Byte bNextTrack = 20;
            Byte bNextSector = 2;

            Byte bCurrTrack = bNextTrack;
            Byte bCurrSector = bNextSector;

            Boolean bMoreDirectories = true;

            while (bMoreDirectories)
            {
                iDirFileCount = 0;

                Byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
                System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                Byte[] bByteArray = new Byte[32];
                bByteArray = rdr.ReadBytes(2);

                bNextTrack = rdr.ReadByte();
                bNextSector = rdr.ReadByte();

                for (int iLoop = 0; iLoop < 14; iLoop++)
                {
                    OricFileInfo diskFile = new OricFileInfo();
                    diskFile.MediaType = OricExplorer.MediaType.DiskFile;

                    diskFile.FirstTrack = rdr.ReadByte();
                    diskFile.FirstSector = rdr.ReadByte();

                    diskFile.Folder = base.diskFolder;
                    diskFile.ParentName = base.diskPathname;

                    Byte bProtection = rdr.ReadByte();

                    if (bProtection == 'U')
                        diskFile.Protection = OricProgram.ProtectionStatus.Unlocked;
                    else if (bProtection == 'L')
                        diskFile.Protection = OricProgram.ProtectionStatus.Locked;
                    else
                        diskFile.Protection = OricProgram.ProtectionStatus.Unlocked;

                    bByteArray = rdr.ReadBytes(8);

                    if ((bByteArray[0] != 0xFF && bByteArray[0] != 0x00 && bByteArray[0] != 0x6C) && diskFile.FirstTrack != 0xFF)
                    {
                        String strFilename = enc.GetString(bByteArray).Trim();

                        if (strFilename.Length > 0)
                        {
                            // Read decimal point between filename and extension
                            bByteArray = rdr.ReadBytes(1);

                            // Read the Extension
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

                            bByteArray = rdr.ReadBytes(1);

                            if (strExtension.Equals("SCR"))
                            {
                                diskFile.Format = OricProgram.ProgramFormat.TextScreen;
                            }
                            else if (strExtension.Equals("BAS"))
                            {
                                diskFile.Format = OricProgram.ProgramFormat.BasicProgram;
                            }
                            else if (strExtension.Equals("CMD") || strExtension.Equals("BIN") || strExtension.Equals("SYS"))
                            {
                                diskFile.Format = OricProgram.ProgramFormat.CodeFile;
                            }
                            else
                            {
                                diskFile.Format = OricProgram.ProgramFormat.UnknownFile;
                            }

                            diskFile.LengthSectors = rdr.ReadByte();

                            bByteArray = rdr.ReadBytes(1);

                            Byte[] fileDesc = base.ReadSector(diskFile.FirstTrack, diskFile.FirstSector);

                            System.IO.MemoryStream stm2 = new System.IO.MemoryStream(fileDesc, 0, sectorData.Length);
                            System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

                            bByteArray = rdr2.ReadBytes(2);

                            diskFile.StartAddress = rdr2.ReadUInt16();
                            diskFile.EndAddress = (ushort)(diskFile.StartAddress + rdr2.ReadUInt16());
                            diskFile.ExeAddress = 0;
                            diskFile.AutoRun = OricProgram.AutoRunFlag.Disabled;

                            if ((diskFile.StartAddress == 0x0000 && diskFile.EndAddress == 0x0000) && strExtension != "SYS")
                            {
                                diskFile.Format = OricProgram.ProgramFormat.UnknownFile;
                            }

                            //diskFile.FirstTrack = 

                            diskFile.DirectoryIndex = i16DirectoryIndex;
                            diskFile.EntryIndex = i16EntryIndex;

                            diskCatalog.Add(diskFile);

                            iDirFileCount++;
                        }

                        i16EntryIndex++;
                    }
                    else
                    {
                        bByteArray = rdr.ReadBytes(7);
                        //swOutfile.WriteLine();
                    }
                }

                iDirFileCount = 0;

                if ((bNextTrack == 0xFF && bNextSector == 0) || (bNextTrack == 0x6C && bNextSector == 0x6C) || (bNextTrack == 0x00 && bNextSector == 0x00))
                    bMoreDirectories = false;
                else
                {
                    bCurrTrack = bNextTrack;
                    bCurrSector = bNextSector;

                    i16EntryIndex = 1;
                    i16DirectoryIndex++;
                }
            }

            diskDirectory = new OricFileInfo[diskCatalog.Count];
            diskCatalog.CopyTo(diskDirectory);

            return diskDirectory;
        }

        public override OricProgram LoadFile(string diskName, OricFileInfo oricFileInfo)
        {
            int index = 0;
            int totalDescriptors = 0;

            Byte dataTrack = 0;
            Byte dataSector = 0;
            Byte nextDescTrack = 0;
            Byte nextDescSector = 1;

            OricProgram loadedProgram = new OricProgram();
            loadedProgram.New();

            String diskPathname = Path.Combine(oricFileInfo.Folder, oricFileInfo.ParentName);

            if (base.LoadDisk(diskPathname))
            {
                Byte[] fileDescriptor = base.ReadSector(oricFileInfo.FirstTrack, oricFileInfo.FirstSector);

                loadedProgram.Format = OricProgram.ProgramFormat.BasicProgram; // GetFileFormat(fileDescriptor);
                loadedProgram.ProgramName = oricFileInfo.ProgramName;

                if (loadedProgram.ProgramName.ToUpper().EndsWith(".CHS"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.CharacterSet;
                }
                else if (loadedProgram.ProgramName.ToUpper().EndsWith(".HRS"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.HiresScreen;
                }
                else if(loadedProgram.ProgramName.ToUpper().EndsWith(".SCR"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.TextScreen;
                }

                //Byte formatFlag = fileDescriptor[0x03];

                /*if ((formatFlag & 0x01) == 0x01)
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Enabled;
                }
                else
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Disabled;
                }*/

                //UInt16 sectorsToLoad = (UInt16)(fileDescriptor[0x0A] + (fileDescriptor[0x0B] * 256));
                UInt16 sectorsToLoad = oricFileInfo.LengthSectors;

                // Get program header info
                switch (loadedProgram.Format)
                {
                    case OricProgram.ProgramFormat.DirectAccessFile:
                        loadedProgram.RecordCount = (UInt16)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256));
                        loadedProgram.RecordLength = (UInt16)(fileDescriptor[0x06] + (fileDescriptor[0x07] * 256));

                        loadedProgram.StartAddress = 0x0000;
                        loadedProgram.EndAddress = (UInt16)(loadedProgram.RecordCount * loadedProgram.RecordLength);
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        loadedProgram.RecordCount = 0;
                        loadedProgram.RecordLength = 0;

                        loadedProgram.StartAddress = 0x0000;
                        loadedProgram.EndAddress = (UInt16)(sectorsToLoad * fileDescriptor.Length);
                        break;

                    default:
                        loadedProgram.RecordCount = 0;
                        loadedProgram.RecordLength = 0;

                        loadedProgram.StartAddress = (UInt16)(fileDescriptor[0x02] + (fileDescriptor[0x03] * 256));
                        loadedProgram.EndAddress = (UInt16)(loadedProgram.StartAddress + ((UInt16)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256))));
                        break;
                }

                do
                {
                    System.IO.MemoryStream stm = new System.IO.MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                    System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                    Byte[] byteArray = new Byte[32];

                    nextDescTrack = rdr.ReadByte();
                    nextDescSector = rdr.ReadByte();

                    byteArray = rdr.ReadBytes(4);

                    // Byte firstDescriptorFlag = rdr.ReadByte();

                    int descriptorIndex = 0;
                    totalDescriptors = 125;

                    dataTrack = rdr.ReadByte();
                    dataSector = rdr.ReadByte();

                    /*if (firstDescriptorFlag == 0xFF)
                    {
                        byteArray = rdr.ReadBytes(9);

                        dataTrack = rdr.ReadByte();
                        dataSector = rdr.ReadByte();

                        totalDescriptors = 121;
                    }
                    else
                    {
                        dataTrack = firstDescriptorFlag;
                        dataSector = rdr.ReadByte();

                        totalDescriptors = 126;
                    }*/

                    int programLength = (loadedProgram.EndAddress - loadedProgram.StartAddress) + 1;

                    loadedProgram.m_programData = new Byte[programLength];

                    while (dataSector != 0xFF && descriptorIndex < totalDescriptors)
                    {
                        Byte[] programData = base.ReadSector(dataTrack, dataSector);

                        System.IO.MemoryStream stm2 = new System.IO.MemoryStream(programData, 0, programData.Length);
                        System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

                        Byte tmpByte = 0;

                        int loopStart = 0;

                        if (loadedProgram.Format == OricProgram.ProgramFormat.BasicProgram)
                        {
                            if (descriptorIndex == 0)
                            {
                                // Skip first byte
                                tmpByte = rdr2.ReadByte();
                                loopStart = 1;
                            }
                        }

                        for (int loop = loopStart; loop < programData.Length; loop++)
                        {
                            tmpByte = rdr2.ReadByte();

                            if (index < programLength)
                            {
                                loadedProgram.m_programData[index] = tmpByte;
                            }

                            index++;
                        }

                        if (dataSector != 0)
                        {
                            dataTrack = rdr.ReadByte();
                            dataSector = rdr.ReadByte();

                            descriptorIndex++;
                        }
                    }

                    if (nextDescSector != 0)
                    {
                        fileDescriptor.Initialize();
                        fileDescriptor = base.ReadSector(nextDescTrack, nextDescSector);
                    }
                } while (nextDescSector != 0);
            }

            return loadedProgram;
        }

        private Byte[] GetFileDescriptor(String fileName)
        {
            Byte dirTrack = 0;
            Byte dirSector = 0;
            Byte dirIndex = 0;

            Byte[] fileDescriptor = new Byte[256];
            fileDescriptor.Initialize();

            // Search directory for matching file
            if (FindFile(fileName, ref dirTrack, ref dirSector, ref dirIndex))
            {
                // Get directory entry
                Byte[] directory = base.ReadSector(dirTrack, dirSector);

                // Calculate start position of directory entry
                int bufferIndex = 0x10 * dirIndex;

                // Get Track & Sector of the File descriptor
                Byte descTrack = directory[bufferIndex + 0x0C];
                Byte descSector = directory[bufferIndex + 0x0D];

                // Get the file descriptor
                fileDescriptor = base.ReadSector(descTrack, descSector);
            }

            return fileDescriptor;
        }

        private static OricProgram.ProgramFormat GetFileFormat(Byte[] FileDescriptor)
        {
            OricProgram.ProgramFormat programFormat = OricProgram.ProgramFormat.UnknownFile;

            UInt16 tmpStartAddr = (UInt16)(FileDescriptor[0x04] + (FileDescriptor[0x05] * 256));

            Byte formatFlag = FileDescriptor[0x03];

            if ((formatFlag & 0x08) == 0x08)
                programFormat = OricProgram.ProgramFormat.DirectAccessFile;
            else if ((formatFlag & 0x10) == 0x10)
                programFormat = OricProgram.ProgramFormat.SequentialFile;
            else if ((formatFlag & 0x20) == 0x20)
                programFormat = OricProgram.ProgramFormat.WindowFile;
            else if ((formatFlag & 0x40) == 0x40)
                programFormat = OricProgram.ProgramFormat.CodeFile;
            else if ((formatFlag & 0x80) == 0x80)
                programFormat = OricProgram.ProgramFormat.BasicProgram;
            else
                programFormat = OricProgram.ProgramFormat.UnknownFile;

            if (programFormat == OricProgram.ProgramFormat.CodeFile)
            {
                switch (tmpStartAddr)
                {
                    case 0xBB80: programFormat = OricProgram.ProgramFormat.TextScreen; break;
                    case 0xBBA8: programFormat = OricProgram.ProgramFormat.TextScreen; break;
                    case 0xA000: programFormat = OricProgram.ProgramFormat.HiresScreen; break;
                    case 0xB400: programFormat = OricProgram.ProgramFormat.CharacterSet; break;
                    case 0xB500: programFormat = OricProgram.ProgramFormat.CharacterSet; break;
                    default: programFormat = OricProgram.ProgramFormat.CodeFile; break;
                }
            }

            return programFormat;
        }

        private Boolean FindFile(String filename, ref Byte track, ref Byte sector, ref Byte index)
        {
            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            Boolean fileMatchFound = false;

            Byte dirTrack = 20;
            Byte dirSector = 2;

            Byte nextDirTrack = dirTrack;
            Byte nextDirSector = dirSector;

            /*while ((nextDirTrack != 0 && nextDirSector != 0) && fileMatchFound == false)
            {
                // Read current Directory Sector
                Byte[] directory = base.ReadSector(dirTrack, dirSector);

                // Scan thru each file in the current directory
                System.IO.MemoryStream memStream = new System.IO.MemoryStream(directory, 0, directory.Length);
                System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(memStream);

                Byte[] bByteArray = new Byte[32];
                bByteArray = binaryReader.ReadBytes(2);

                nextDirTrack = directory[0x00];
                nextDirSector = directory[0x01];

                index = 0;

                // Move to first entry
                memStream.Seek(0x04, SeekOrigin.Begin);

                while (!fileMatchFound && index < 15)
                {
                    Byte firstTrack = binaryReader.ReadByte();
                    Byte firstSector = binaryReader.ReadByte();

                    Byte bProtection = binaryReader.ReadByte();

                    if (binaryReader.PeekChar() != 0x00)
                    {
                        Byte[] fileName = binaryReader.ReadBytes(8);

                        // Read decimal point between filename and extension
                        bByteArray = binaryReader.ReadBytes(1);

                        Byte[] extension = binaryReader.ReadBytes(3);

                        String dirFilename = enc.GetString(fileName).Trim();
                        String dirExtension = enc.GetString(extension).Trim();

                        String pathname = String.Format("{0}.{1}", dirFilename, dirExtension);

                        if (pathname == filename)
                        {
                            fileMatchFound = true;
                        }
                        else
                        {
                            index++;
                        }
                    }

                    binaryReader.ReadBytes(4);
                }

                if (!fileMatchFound)
                {
                    dirTrack = nextDirTrack;
                    dirSector = nextDirSector;
                }
                else
                {
                    track = dirTrack;
                    sector = dirSector;

                    index++;
                }
            }*/

            return fileMatchFound;
        }

        internal UInt16[] BuildSectorMap(String diskPathname)
        {
            base.LoadDisk(diskPathname);

            UInt16 noOfSectors = (UInt16)((tracksPerSide * sectorsPerTrack) * sides);

            UInt16[] sectorMap = new UInt16[noOfSectors];

            for (int index = 0; index < noOfSectors; index++)
            {
                sectorMap[index] = 0xFFFF;
            }

            // Mark the disk bitmap
            UpdateSectorMap(sectorMap, 20, 1, 0x0200);

            if (diskType == DiskTypes.Master)
            {
                SetDOSSectors(sectorMap, 0, 1, 62);
            }

            Byte directoryTrack = 0x14;
            Byte directorySector = 0x02;

            // Mark Directories
            UpdateSectorMap(sectorMap, directoryTrack, directorySector, 0x0400);

            Byte nextDirectoryTrack = directoryTrack;
            Byte nextDirectorySector = directorySector;

            while ((directoryTrack != 0xFF) && (directoryTrack != 0x6C && directorySector != 0x6C) && (directoryTrack != 0x00 && directorySector != 0x00))
            {
                Byte[] directory = this.ReadSector(directoryTrack, directorySector);

                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(directory, 0, directory.Length);
                System.IO.BinaryReader binReader = new System.IO.BinaryReader(memoryStream);

                binReader.ReadBytes(2);

                nextDirectoryTrack = binReader.ReadByte();
                nextDirectorySector = binReader.ReadByte();

                //Byte nextFreeEntry = binReader.ReadByte();

                Byte noOfFiles = 0;

                /*if (nextFreeEntry == 0x00)
                {
                    noOfFiles = 15;
                }
                else
                {
                }*/

                if (directoryTrack != 0x6C && directorySector != 0x6C)
                {
                    UpdateSectorMap(sectorMap, directoryTrack, directorySector, (UInt16)(0x0400 + noOfFiles));
                }

                directoryTrack = nextDirectoryTrack;
                directorySector = nextDirectorySector;
            }

            BuildTDosSectorMap2(sectorMap, diskPathname);

            return sectorMap;
        }

        private void BuildTDosSectorMap2(UInt16[] sectorMap, String diskPathname)
        {
            int iFileNum = 1;

            UInt16 bNextTrack = 0;
            UInt16 bNextSector = 0;
            UInt16 bNextDescTrack;
            UInt16 bNextDescSector;

            Byte[] bByteArray = new Byte[10];

            String strSectorKey = "";

            OricFileInfo[] programList = ReadDirectory(diskPathname);

            foreach (OricFileInfo programInfo in programList)
            {
                if (programInfo.Format != OricProgram.ProgramFormat.UnknownFile)
                {
                    UInt16 bTrack;
                    UInt16 bSector;

                    bTrack = programInfo.FirstTrack;
                    bSector = programInfo.FirstSector;

                    if (bTrack == 0x00 && bSector == 0x00)
                    {
                        // This is the DOS file (FTDOS3-2.sys) so don't process it
                    }
                    else
                    {
                        do
                        {
                            Byte[] bitmapSector = base.ReadSector(bTrack, bSector, ref bNextTrack, ref bNextSector);

                            // Add file descriptor to the sector map
                            UpdateSectorMap(sectorMap, bTrack, bSector, (UInt16)(0x1100 + Convert.ToByte(iFileNum)));

                            bTrack = bNextTrack;
                            bSector = bNextSector;

                            // Safety net
                            /*if (bTrack > tracksPerSide || bNextSector > sectorsPerTrack)
                            {
                                // Might have a problem
                                bSector = 0;
                            }*/
                        } while (bSector != 0);

                        strSectorKey = CreateKey(programInfo.FirstTrack, programInfo.FirstSector);

                        bNextTrack = programInfo.FirstTrack;
                        bNextSector = programInfo.FirstSector;

                        do
                        {
                            // Read the file descriptor
                            Byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                            System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
                            System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                            bNextTrack = rdr.ReadByte();
                            bNextSector = rdr.ReadByte();

                            bNextDescTrack = bNextTrack;
                            bNextDescSector = bNextSector;

                            rdr.ReadBytes(4);

                            //Byte bFirstDesc = rdr.ReadByte();

                            int iDescIndex = 0;
                            int iTotalDescriptors = 125;

                            Byte bDataTrack;
                            Byte bDataSector;

                            bDataTrack = rdr.ReadByte();
                            bDataSector = rdr.ReadByte();

                            if (bDataTrack != 0xFF && bDataSector != 0xFF)
                            {
                                UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)));
                            }

                            while (bDataSector != 0xFF && iDescIndex < iTotalDescriptors)
                            {
                                if (bDataSector != 0xFF)
                                {
                                    bDataTrack = rdr.ReadByte();
                                    bDataSector = rdr.ReadByte();

                                    if (bDataSector != 0xFF)
                                    {
                                        UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)));
                                    }

                                    iDescIndex++;
                                }
                            }

                            strSectorKey = CreateKey(bNextDescTrack, bNextDescSector);

                        } while (bNextDescTrack != 0xFF && bNextDescSector != 0x00);
                    }
                }

                iFileNum++;
            }
        }

        private void UpdateSectorMap(UInt16[] sectorMap, int iTrack, int iSector, UInt16 ui16Marker)
        {
            if ((iTrack & 0x80) == 0x80)
            {
                iTrack = (short)(iTrack & 0x7F);
                iTrack += tracksPerSide;
            }

            int iIndex = (iTrack * sectorsPerTrack) + (iSector - 1);

            try
            {
                sectorMap[iIndex] = ui16Marker;
            }
            catch (Exception ex)
            {
                String oMessage = ex.Message;
            }
        }

        private void SetDOSSectors(UInt16[] sectorMap, int iTrack, int iSector, int iNoOfSectors)
        {
            while (iNoOfSectors > 0)
            {
                UpdateSectorMap(sectorMap, iTrack, iSector, 0x0800);

                iSector++;

                if (iSector > sectorsPerTrack)
                {
                    iTrack++;
                    iSector = 1;
                }

                iNoOfSectors--;
            }
        }
    }
}
