using System;
using System.Collections;
using System.IO;

namespace OricExplorer
{
    class StratSed : OricDisk
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

            stm.Seek(0x09, SeekOrigin.Begin);

            Byte[] bByteArray = rdr.ReadBytes(21);

            diskName = enc.GetString(bByteArray);
            diskName.Trim();

            ReadBitmap1();
            ReadBitmap2();
        }

        private void ReadBitmap1()
        {
            // Read the System sector
            Byte[] sectorData = base.ReadSector(20, 2);

            System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

            Byte[] bByteArray = rdr.ReadBytes(2);

            sectorsFree = rdr.ReadUInt16();
            noOfFiles = rdr.ReadUInt16();
            tracksPerSide = rdr.ReadByte();
            sectorsPerTrack = rdr.ReadByte();
            noOfDirectories = rdr.ReadByte();

            bByteArray = rdr.ReadBytes(1);

            if ((bByteArray[0] & 0x80) == 0x80)
            {
                sides = 2;
            }
            else
            {
                sides = 1;
            }

            bByteArray = rdr.ReadBytes(1);

            if (bByteArray[0] == 0)
            {
                diskType = DiskTypes.Master;
            }
            else if (bByteArray[0] == 0x01)
            {
                diskType = DiskTypes.Slave;
            }
            else if (bByteArray[0] == 0x47)
            {
                diskType = DiskTypes.Game;
            }
            else
            {
                diskType = DiskTypes.Unknown;
            }

            sectors = (ushort)((sectorsPerTrack * tracksPerSide) * sides);
            sectorsUsed = (ushort)(sectors - sectorsFree);
        }

        private void ReadBitmap2()
        {
            // Read the System sector
            Byte[] sectorData = base.ReadSector(20, 3);

            System.IO.MemoryStream stm = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

            Byte[] bByteArray = rdr.ReadBytes(2);

            sectors = rdr.ReadUInt16();
            sectorsUsed = (ushort)(sectors - sectorsFree);
        }

        public override OricFileInfo[] ReadDirectory(String diskPathname)
        {
            base.LoadDisk(diskPathname);
            OricFileInfo[] files = ReadSedOricDirectory();
            return files;
        }

        private OricFileInfo[] ReadSedOricDirectory()
        {
            OricFileInfo[] diskDirectory = null;

            //int noOfFiles = 0;

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            ArrayList diskCatalog = new ArrayList();

            Byte bNextTrack = Convert.ToByte(20);
            Byte bNextSector = Convert.ToByte(4);

            Byte bCurrTrack = bNextTrack;
            Byte bCurrSector = bNextSector;

            Boolean MoreDirectories = true;

            while (MoreDirectories)
            {
                // Read the first directory sector
                Byte[] directory = base.ReadSector(bCurrTrack, bCurrSector);

                if (directory[0] == 0x00 && directory[1] == 0x00)
                {
                    MoreDirectories = false;
                }
                else
                {
                    bCurrTrack = directory[0];
                    bCurrSector = directory[1];
                }

                // Scan thru all 15 entries to build the directory
                UInt16 DirectoryIndex = 0;

                System.IO.MemoryStream stm = new System.IO.MemoryStream(directory, 0, 256);
                System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);
                stm.Seek(0x10, SeekOrigin.Begin);

                do
                {
                    if (rdr.PeekChar() != 0x00)
                    {
                        // Read the filename
                        String Filename = enc.GetString(rdr.ReadBytes(9)).Trim();

                        // Read the file extension
                        String FileExtension = enc.GetString(rdr.ReadBytes(3)).Trim();

                        // Read the file descriptor track
                        Byte FileDescTrack = rdr.ReadByte();

                        // Read the file descriptor sector
                        Byte FileDescSector = rdr.ReadByte();

                        // Read the no. of sectors used by file (includes file descriptor)
                        Byte SectorsUsed = rdr.ReadByte();

                        // Read the files protection status
                        Byte ProtectionStatus = rdr.ReadByte();

                        OricFileInfo diskFileInfo = new OricFileInfo();
                        diskFileInfo.MediaType = OricExplorer.MediaType.DiskFile;

                        //diskFileInfo.m_bDosFormat = OricDisk.DOSFormat.SedOric;

                        diskFileInfo.Folder = base.diskFolder;
                        diskFileInfo.ParentName = base.diskPathname;

                        diskFileInfo.ProgramName = Filename;
                        diskFileInfo.Extension = FileExtension;

                        if (FileExtension.Length > 0)
                        {
                            diskFileInfo.ProgramName = String.Format("{0}.{1}", Filename, FileExtension);
                        }
                        else
                        {
                            diskFileInfo.ProgramName = Filename;
                        }

                        diskFileInfo.FirstTrack = FileDescTrack;
                        diskFileInfo.FirstSector = FileDescSector;
                        diskFileInfo.LengthSectors = SectorsUsed;

                        if (ProtectionStatus == 0xC0)
                        {
                            diskFileInfo.Protection = OricProgram.ProtectionStatus.Protected;
                        }
                        else if (ProtectionStatus == 0x40)
                        {
                            diskFileInfo.Protection = OricProgram.ProtectionStatus.Unprotected;
                        }
                        else
                        {
                            diskFileInfo.Protection = OricProgram.ProtectionStatus.Unprotected;
                        }

                        Byte[] FileDescriptor = base.ReadSector(FileDescTrack, FileDescSector);

                        System.IO.MemoryStream stmFileDescriptor = new System.IO.MemoryStream(FileDescriptor, 0, FileDescriptor.Length);
                        System.IO.BinaryReader rdrFileDescriptor = new System.IO.BinaryReader(stmFileDescriptor);

                        stmFileDescriptor.Seek(0x03, SeekOrigin.Begin);

                        Byte FileType = rdrFileDescriptor.ReadByte();

                        if ((FileType & 0x08) == 0x08)
                        {
                            // We have a direct access file
                            diskFileInfo.m_ui16NoOfRecords = rdrFileDescriptor.ReadUInt16();
                            diskFileInfo.m_ui16RecordLength = rdrFileDescriptor.ReadUInt16();

                            diskFileInfo.StartAddress = 0x0000;
                            diskFileInfo.EndAddress = (ushort)(diskFileInfo.m_ui16NoOfRecords * diskFileInfo.m_ui16RecordLength);
                        }
                        else if ((FileType & 0x10) == 0x10)
                        {
                            // We have a sequential file
                            diskFileInfo.StartAddress = 0x0000;
                            diskFileInfo.EndAddress = (ushort)((diskFileInfo.LengthSectors - 1) * 256);
                        }
                        else
                        {
                            diskFileInfo.StartAddress = rdrFileDescriptor.ReadUInt16();
                            diskFileInfo.EndAddress = rdrFileDescriptor.ReadUInt16();
                        }

                        diskFileInfo.ExeAddress = rdrFileDescriptor.ReadUInt16();

                        if ((FileType & 0x08) == 0x08)
                            diskFileInfo.Format = OricProgram.ProgramFormat.DirectAccessFile;
                        else if ((FileType & 0x10) == 0x10)
                            diskFileInfo.Format = OricProgram.ProgramFormat.SequentialFile;
                        else if ((FileType & 0x20) == 0x20)
                            diskFileInfo.Format = OricProgram.ProgramFormat.WindowFile;
                        else if ((FileType & 0x40) == 0x40)
                            diskFileInfo.Format = OricProgram.ProgramFormat.CodeFile;
                        else if ((FileType & 0x80) == 0x80)
                            diskFileInfo.Format = OricProgram.ProgramFormat.BasicProgram;
                        else
                            diskFileInfo.Format = OricProgram.ProgramFormat.UnknownFile;

                        if (diskFileInfo.Format == OricProgram.ProgramFormat.CodeFile)
                        {
                            switch (diskFileInfo.StartAddress)
                            {
                                case 0xBB80:
                                    if (diskFileInfo.ProgramName.ToUpper().EndsWith(".HLP"))
                                        diskFileInfo.Format = OricProgram.ProgramFormat.HelpFile;
                                    else
                                        diskFileInfo.Format = OricProgram.ProgramFormat.TextScreen;
                                    break;

                                case 0xBBA8:
                                    if (diskFileInfo.ProgramName.ToUpper().EndsWith(".HLP"))
                                        diskFileInfo.Format = OricProgram.ProgramFormat.HelpFile;
                                    else
                                        diskFileInfo.Format = OricProgram.ProgramFormat.TextScreen;
                                    break;

                                case 0xA000: diskFileInfo.Format = OricProgram.ProgramFormat.HiresScreen; break;
                                case 0xB500: diskFileInfo.Format = OricProgram.ProgramFormat.CharacterSet; break;
                                default: diskFileInfo.Format = OricProgram.ProgramFormat.CodeFile; break;
                            }

                            if (diskFileInfo.StartAddress >= 0xA000 && diskFileInfo.StartAddress <= 0xBF3F)
                            {
                                // Possibly a HIRES screen
                                if (diskFileInfo.ProgramName.ToUpper().EndsWith(".HRS"))
                                    diskFileInfo.Format = OricProgram.ProgramFormat.HiresScreen;
                            }

                            if (diskFileInfo.ProgramName.ToUpper().EndsWith(".CHS") || diskFileInfo.ProgramName.ToUpper().EndsWith(".CHR"))
                            {
                                diskFileInfo.Format = OricProgram.ProgramFormat.CharacterSet;
                            }
                        }

                        if ((FileType & 0x01) == 0x01)
                        {
                            diskFileInfo.AutoRun = OricProgram.AutoRunFlag.Enabled;
                        }
                        else
                        {
                            diskFileInfo.AutoRun = OricProgram.AutoRunFlag.Disabled;
                        }

                        diskCatalog.Add(diskFileInfo);
                    }

                    DirectoryIndex++;
                } while (DirectoryIndex < 15);
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
                Byte[] fileDescriptor = GetFileDescriptor(oricFileInfo.ProgramName);

                loadedProgram.Format = GetFileFormat(fileDescriptor);
                loadedProgram.ProgramName = oricFileInfo.ProgramName;

                if (loadedProgram.ProgramName.ToUpper().EndsWith(".CHS") || loadedProgram.ProgramName.ToUpper().EndsWith(".CHR"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.CharacterSet;
                }

                if (loadedProgram.ProgramName.ToUpper().EndsWith(".HRS"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.HiresScreen;
                }

                Byte formatFlag = fileDescriptor[0x03];

                if ((formatFlag & 0x01) == 0x01)
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Enabled;
                }
                else
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Disabled;
                }

                UInt16 sectorsToLoad = (UInt16)(fileDescriptor[0x0A] + (fileDescriptor[0x0B] * 256));

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

                        loadedProgram.StartAddress = (UInt16)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256));
                        loadedProgram.EndAddress = (UInt16)(fileDescriptor[0x06] + (fileDescriptor[0x07] * 256));
                        break;
                }

                do
                {
                    System.IO.MemoryStream stm = new System.IO.MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                    System.IO.BinaryReader rdr = new System.IO.BinaryReader(stm);

                    Byte[] byteArray = new Byte[32];

                    nextDescTrack = rdr.ReadByte();
                    nextDescSector = rdr.ReadByte();

                    Byte firstDescriptorFlag = rdr.ReadByte();

                    int descriptorIndex = 0;

                    if (firstDescriptorFlag == 0xFF)
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
                    }

                    int programLength = (loadedProgram.EndAddress - loadedProgram.StartAddress) + 1;

                    loadedProgram.m_programData = new Byte[programLength];

                    while (dataSector != 0 && descriptorIndex < totalDescriptors)
                    {
                        Byte[] programData = base.ReadSector(dataTrack, dataSector);

                        System.IO.MemoryStream stm2 = new System.IO.MemoryStream(programData, 0, programData.Length);
                        System.IO.BinaryReader rdr2 = new System.IO.BinaryReader(stm2);

                        /*if(descriptorIndex == 0)
                        {
                            stm2.Seek(5, SeekOrigin.Begin);
                        }*/

                        Byte tmpByte = 0;

                        for (int loop = 0; loop < programData.Length; loop++)
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
            Byte dirSector = 4;

            Byte nextDirTrack = 20;
            Byte nextDirSector = 4;

            while ((nextDirTrack != 0 && nextDirSector != 0) && fileMatchFound == false)
            {
                // Read current Directory Sector
                Byte[] directory = base.ReadSector(dirTrack, dirSector);

                nextDirTrack = directory[0x00];
                nextDirSector = directory[0x01];

                index = 0;

                // Scan thru each file in the current directory
                System.IO.MemoryStream memStream = new System.IO.MemoryStream(directory, 0, directory.Length);
                System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(memStream);

                // Move to first entry
                memStream.Seek(0x10, SeekOrigin.Begin);

                while (!fileMatchFound && index < 15)
                {
                    if (binaryReader.PeekChar() != 0x00)
                    {
                        Byte[] fileName = binaryReader.ReadBytes(9);
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
            }

            return fileMatchFound;
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

        internal UInt16[] BuildSectorMap(String diskPathname)
        {
            base.LoadDisk(diskPathname);

            UInt16 noOfSectors = (UInt16)((tracksPerSide * sectorsPerTrack) * sides);

            UInt16[] sectorMap = new UInt16[noOfSectors];

            for (int index = 0; index < noOfSectors; index++)
            {
                sectorMap[index] = 0xFFFF;
            }

            // Mark the System sector
            UpdateSectorMap(sectorMap, 0, 1, 0x0101);

            UpdateSectorMap(sectorMap, 0, 2, 0x0102);
            UpdateSectorMap(sectorMap, 0, 3, 0x0103);

            UpdateSectorMap(sectorMap, 20, 1, 0x0100);
            UpdateSectorMap(sectorMap, 20, 2, 0x0201);
            UpdateSectorMap(sectorMap, 20, 3, 0x0202);

            if (diskType == DiskTypes.Master)
            {
                if (dosVersion == DOSVersions.SedOric_V3_006)
                {
                    SetDOSSectors(sectorMap, 0, 4, 96);
                }
                else
                {
                    SetDOSSectors(sectorMap, 0, 4, 91);
                }
            }
            else if (diskType == DiskTypes.Slave)
            {
                SetDOSSectors(sectorMap, 0, 4, 5);
            }
            else
            {
                SetDOSSectors(sectorMap, 0, 4, 14);
            }

            // Directories
            UpdateSectorMap(sectorMap, 20, 4, 0x0400);
            UpdateSectorMap(sectorMap, 20, 7, 0x0400);
            UpdateSectorMap(sectorMap, 20, 10, 0x0400);
            UpdateSectorMap(sectorMap, 20, 13, 0x0400);
            UpdateSectorMap(sectorMap, 20, 16, 0x0400);

            Byte directoryTrack = 0x14;
            Byte directorySector = 0x04;
            Byte nextDirectoryTrack = 0x14;
            Byte nextDirectorySector = 0x04;

            while (directorySector != 0x00)
            {
                Byte[] directory = this.ReadSector(directoryTrack, directorySector);

                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(directory, 0, directory.Length);
                System.IO.BinaryReader binReader = new System.IO.BinaryReader(memoryStream);

                nextDirectoryTrack = binReader.ReadByte();
                nextDirectorySector = binReader.ReadByte();

                Byte nextFreeEntry = binReader.ReadByte();

                Byte noOfFiles = 0;

                if (nextFreeEntry == 0x00)
                {
                    noOfFiles = 15;
                }
                else
                {
                }

                UpdateSectorMap(sectorMap, directoryTrack, directorySector, (UInt16)(0x0400 + noOfFiles));

                directoryTrack = nextDirectoryTrack;
                directorySector = nextDirectorySector;
            }

            BuildSedOricSectorMap2(sectorMap, diskPathname);

            return sectorMap;
        }

        private void BuildSedOricSectorMap2(UInt16[] sectorMap, String diskPathname)
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
                UInt16 bTrack;
                UInt16 bSector;

                bTrack = programInfo.FirstTrack;
                bSector = programInfo.FirstSector;

                do
                {
                    Byte[] bitmapSector = base.ReadSector(bTrack, bSector, ref bNextTrack, ref bNextSector);

                    // Add file descriptor to the sector map
                    UpdateSectorMap(sectorMap, bTrack, bSector, (UInt16)(0x1100 + Convert.ToByte(iFileNum)));

                    bTrack = bNextTrack;
                    bSector = bNextSector;

                    // Safety net
                    if(bTrack > tracksPerSide || bNextSector > sectorsPerTrack)
                    {
                        // Might have a problem
                        bSector = 0;
                    }
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

                    Byte bFirstDesc = rdr.ReadByte();

                    int iDescIndex = 0;

                    Byte bDataTrack;
                    Byte bDataSector;

                    int iTotalDescriptors;

                    if (bFirstDesc == 0xFF)
                    {
                        bByteArray = rdr.ReadBytes(9);

                        bDataTrack = rdr.ReadByte();
                        bDataSector = rdr.ReadByte();

                        iTotalDescriptors = 121;
                    }
                    else
                    {
                        bDataTrack = bFirstDesc;
                        bDataSector = rdr.ReadByte();

                        iTotalDescriptors = 126;
                    }

                    if (bDataSector != 0)
                    {
                        UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)));
                    }

                    while (bDataSector != 0 && iDescIndex < iTotalDescriptors)
                    {
                        if (bDataSector != 0)
                        {
                            bDataTrack = rdr.ReadByte();
                            bDataSector = rdr.ReadByte();

                            if (bDataSector != 0)
                            {
                                UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (UInt16)(0x1000 + Convert.ToByte(iFileNum)));
                            }

                            iDescIndex++;
                        }
                    }

                    strSectorKey = CreateKey(bNextDescTrack, bNextDescSector);

                } while (bNextDescSector != 0);

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

        public override Boolean DeleteFile(String diskName, String filename)
        {
            Boolean fileDeleted = false;

            // Find matching entry in the directory
            Byte track = 0x00;
            Byte sector = 0x00;
            Byte index = 0x00;

            base.LoadDisk(diskName);
            ReadBitmap1();

            // Locate file in directory and return directory reference
            Boolean fileFound = FindFile(filename, ref track, ref sector, ref index);

            if (fileFound)
            {
                // Get the file descriptor
                Byte[] fileDescriptor = GetFileDescriptor(filename);

                // Scan thought the descriptor for each sector to delete
                MemoryStream memoryStream = new System.IO.MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                BinaryReader binReader = new System.IO.BinaryReader(memoryStream);

                // Move to the required offset
                memoryStream.Seek(0x0A, SeekOrigin.Begin);

                // Get number of sectors
                UInt16 noOfSectors = binReader.ReadUInt16();

                UInt16 sectorIndex = 0;

                while (sectorIndex < noOfSectors)
                {
                    Byte fileDataTrack = binReader.ReadByte();
                    Byte fileDataSector = binReader.ReadByte();

                    if (fileDataSector != 0x00)
                    {
                        // Clear data in the sector
                        Byte[] sectorData = base.ReadSector(fileDataTrack, fileDataSector);

                        for (int dataIndex = 0; dataIndex < sectorData.Length; dataIndex++)
                        {
                            sectorData[dataIndex] = 0x00;
                        }

                        base.WriteSector(fileDataTrack, fileDataSector, sectorData);

                        sectorsFree++;

                        // Update the Bitmap to indicate sector is now free
                        UpdateBitmap(fileDataTrack, fileDataSector, SectorState.FREE);
                    }

                    sectorIndex++;
                }

                // Initialise the Program descriptor

                // Get directory entry
                Byte[] directory = base.ReadSector(track, sector);

                // Calculate start position of directory entry
                int bufferIndex = 0x10 * index;

                // Get Track & Sector of the File descriptor
                Byte descTrack = directory[bufferIndex + 0x0C];
                Byte descSector = directory[bufferIndex + 0x0D];

                // Clear data in the sector
                Byte[] descSectorData = base.ReadSector(descTrack, descSector);

                for (int dataIndex = 0; dataIndex < descSectorData.Length; dataIndex++)
                {
                    descSectorData[dataIndex] = 0x00;
                }

                base.WriteSector(descTrack, descSector, descSectorData);

                sectorsFree++;

                // Update the Bitmap to indicate sector is now free
                UpdateBitmap(descTrack, descSector, SectorState.FREE);

                // Update Directory to remove the entry
                //RemoveDirectoryEntry(filename);

                noOfFiles--;

                // Update Bitmap 1 (No. of Sectors free and No. of files in Bitmap 1 and 2)
                Byte[] Bitmap1 = base.ReadSector(20, 2);

                MemoryStream memStream = new System.IO.MemoryStream(Bitmap1, 0, Bitmap1.Length);
                BinaryWriter bw = new System.IO.BinaryWriter(memStream);

                memStream.Seek(0x02, SeekOrigin.Begin);

                bw.Write(sectorsFree);
                bw.Write(noOfFiles);

                base.WriteSector(20, 2, Bitmap1);

                // Update Bitmap 1 (No. of Sectors free and No. of files in Bitmap 1 and 2)
                Byte[] Bitmap2 = base.ReadSector(20, 3);

                MemoryStream memStream2 = new System.IO.MemoryStream(Bitmap2, 0, Bitmap2.Length);
                BinaryWriter bw2 = new System.IO.BinaryWriter(memStream2);

                memStream2.Seek(0x04, SeekOrigin.Begin);
                bw2.Write(noOfFiles);

                base.WriteSector(20, 3, Bitmap2);

                base.WriteDisk();

                fileDeleted = true;

                // No reorganise the directory to remove any empty entries
                ReorganiseDirectory(diskName, filename);
            }
            else
            {
                fileDeleted = false;
            }

            return fileDeleted;
        }

        private void UpdateBitmap(Byte track, Byte sector, SectorState sectorState)
        {
            // Read bitmap
            Byte[] bitmap = base.ReadSector(20, 2);

            int index = (track * sectorsPerTrack) + sector;
            int byteIndex = (index - 1) / 8;
            int bitIndex = (index - 1) % 8;

            Byte data = bitmap[0x10 + byteIndex];

            if (GetBit(data, bitIndex))
            {
                //System.Console.WriteLine("Track : {0}, Sector : {1} - FREE", track, sector);
            }
            else
            {
                //System.Console.WriteLine("Track : {0}, Sector : {1} - USED", track, sector);
            }

            Byte updatedData = 0x00;

            if (sectorState == SectorState.FREE)
            {
                updatedData = SetBit(data, bitIndex, true);
            }
            else
            {
                updatedData = SetBit(data, bitIndex, false);
            }

            bitmap[0x10 + byteIndex] = updatedData;

            //base.WriteSector(track, sector, bitmap);
        }

        private bool GetBit(byte b, int bitNumber)
        {
            System.Collections.BitArray ba = new BitArray(new byte[] { b });
            return ba.Get(bitNumber);
        }

        private Byte SetBit(byte b, int bitNumber, bool value)
        {
            System.Collections.BitArray ba = new BitArray(new byte[] { b });
            ba.Set(bitNumber, value);

            String binary = ConvertBitArray(ba);

            Byte number = Convert.ToByte(binary, 2);

            return number;
        }

        private String ConvertBitArray(BitArray bits)
        {
            String binary = "";

            for(int index = 7; index >= 0; index--)
            {
                bool bit = bits.Get(index);

                if (bit)
                {
                    binary += "1";
                }
                else
                {
                    binary += "0";
                }
            }

            return binary;
        }

        private void RemoveDirectoryEntry(String filename)
        {
            Byte dirTrack = 0x00;
            Byte dirSector = 0x00;
            Byte dirIndex = 0x00;

            // Locate file in directory and return directory reference
            Boolean fileFound = FindFile(filename, ref dirTrack, ref dirSector, ref dirIndex);

            if (fileFound)
            {
                Byte[] directory = base.ReadSector(dirTrack, dirSector);

                // Calculate start position of directory entry
                int bufferIndex = 0x10 * dirIndex;

                for (int index = 0; index < 16; index++)
                {
                    directory[bufferIndex + index] = 0x00;
                }

                base.WriteSector(dirTrack, dirSector, directory);
            }
        }

        private void ReorganiseDirectory(String diskName, String filenameToDelete)
        {
            Byte directoryTrack = 20;
            Byte directorySector = 4;
            Byte directoryIndex = 0;

            Byte prevDirTrack = directoryTrack;
            Byte prevDirSector = directorySector;

            int directoryCount = 0;

            Byte[] directory = new Byte[256];

            for (int index = 0; index < directory.Length; index++)
            {
                directory[index] = 0x00;
            }

            MemoryStream memStream = new System.IO.MemoryStream(directory, 0, directory.Length);
            BinaryWriter bw = new System.IO.BinaryWriter(memStream);
            memStream.Seek(0x10, SeekOrigin.Begin);

            // Read entire directory
            OricFileInfo[] diskDirectory = ReadDirectory(diskName);

            foreach (OricFileInfo fileInfo in diskDirectory)
            {
                if (!fileInfo.ProgramName.Equals(filenameToDelete))
                {
                    String filename = fileInfo.ProgramName;
                    filename = Path.GetFileNameWithoutExtension(filename);
                    filename = filename.PadRight(9, ' ');

                    bw.Write(filename.ToCharArray());

                    String extension = fileInfo.Extension.PadRight(3, ' ');
                    bw.Write(extension.ToCharArray());

                    bw.Write(fileInfo.FirstTrack);
                    bw.Write(fileInfo.FirstSector);
                    bw.Write((Byte)fileInfo.LengthSectors);

                    if (fileInfo.Protection == OricProgram.ProtectionStatus.Protected)
                    {
                        bw.Write((Byte)0xC0);
                    }
                    else if (fileInfo.Protection == OricProgram.ProtectionStatus.Unprotected)
                    {
                        bw.Write((Byte)0x40);
                    }
                    else
                    {
                        bw.Write((Byte)0x00);
                    }

                    directoryIndex++;

                    if (directoryIndex == 15)
                    {
                        prevDirTrack = directoryTrack;
                        prevDirSector = directorySector;

                        directoryCount++;

                        // Directory is full, setup details of next directory
                        switch (directoryCount)
                        {
                            case 1: directorySector = 7; break;
                            case 2: directorySector = 10; break;
                            case 3: directorySector = 13; break;
                            case 4: directorySector = 16; break;
                            default:
                                // Find next free sector and use that
                                break;
                        }

                        bw.Seek(0x00, SeekOrigin.Begin);
                        bw.Write(directoryTrack);
                        bw.Write(directorySector);

                        // Write value to indicate directory is full
                        bw.Write((Byte)0x00);

                        base.WriteSector(prevDirTrack, prevDirSector, directory);

                        for (int index = 0; index < directory.Length; index++)
                        {
                            directory[index] = 0x00;
                        }

                        directoryIndex = 0;

                        memStream.Seek(0x10, SeekOrigin.Begin);
                    }
                }
            }

            if (directoryIndex > 0)
            {
                bw.Seek(0x02, SeekOrigin.Begin);

                Byte nextFreeSlot = (Byte)((directoryIndex + 1) * 16);
                bw.Write((Byte)nextFreeSlot);

                base.WriteSector(directoryTrack, directorySector, directory);
            }

            base.WriteDisk();
        }
    }
}
