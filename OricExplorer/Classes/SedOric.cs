namespace OricExplorer
{
    using System;
    using System.Collections;
    using System.IO;

    class SedOric : OricDisk
    {
        public ushort sectors = 0;
        public ushort sectorsUsed = 0;
        public ushort sectorsFree = 0;

        public ushort sides = 0;
        public ushort tracksPerSide = 0;
        public ushort sectorsPerTrack = 0;

        public ushort noOfFiles = 0;
        public ushort noOfDirectories = 0;

        public string diskName = "";

        public DiskTypes diskType = DiskTypes.Unknown;

        public void GetDiskInfo(string diskPathname)
        {
            base.LoadDisk(diskPathname);

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            // Read the System Sector
            byte[] sectorData = base.ReadSector(20, 1);

            MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
            BinaryReader rdr = new BinaryReader(stm);

            stm.Seek(0x09, SeekOrigin.Begin);

            byte[] bByteArray = rdr.ReadBytes(21);

            diskName = enc.GetString(bByteArray).Trim().Trim(new char[] { '\0' });

            ReadBitmap1();
            ReadBitmap2();
        }

        private void ReadBitmap1()
        {
            // Read the System sector
            byte[] sectorData = base.ReadSector(20, 2);

            MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
            BinaryReader rdr = new BinaryReader(stm);

            _ = rdr.ReadBytes(2);

            sectorsFree = rdr.ReadUInt16();
            noOfFiles = rdr.ReadUInt16();
            tracksPerSide = rdr.ReadByte();
            sectorsPerTrack = rdr.ReadByte();
            noOfDirectories = rdr.ReadByte();

            byte[] bByteArray = rdr.ReadBytes(1);

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
            byte[] sectorData = base.ReadSector(20, 3);

            MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
            BinaryReader rdr = new BinaryReader(stm);

            _ = rdr.ReadBytes(2);

            sectors = rdr.ReadUInt16();
            sectorsUsed = (ushort)(sectors - sectorsFree);
        }

        public override OricFileInfo[] ReadDirectory(string diskPathname)
        {
            base.LoadDisk(diskPathname);
            OricFileInfo[] files = ReadSedOricDirectory();
            return files;
        }

        private OricFileInfo[] ReadSedOricDirectory()
        {
            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            ArrayList diskCatalog = new ArrayList();

            byte bNextTrack = Convert.ToByte(20);
            byte bNextSector = Convert.ToByte(4);

            byte bCurrTrack = bNextTrack;
            byte bCurrSector = bNextSector;

            bool MoreDirectories = true;

            while (MoreDirectories)
            {
                // Read the first directory sector
                byte[] directory = base.ReadSector(bCurrTrack, bCurrSector);

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
                ushort DirectoryIndex = 0;

                MemoryStream stm = new MemoryStream(directory, 0, 256);
                BinaryReader rdr = new BinaryReader(stm);
                stm.Seek(0x10, SeekOrigin.Begin);

                do
                {
                    if (rdr.PeekChar() != 0x00)
                    {
                        // Read the filename
                        string Filename = enc.GetString(rdr.ReadBytes(9)).Trim();

                        // Read the file extension
                        string FileExtension = enc.GetString(rdr.ReadBytes(3)).Trim();

                        // Read the file descriptor track
                        byte FileDescTrack = rdr.ReadByte();

                        // Read the file descriptor sector
                        byte FileDescSector = rdr.ReadByte();

                        // Read the no. of sectors used by file (includes file descriptor)
                        byte SectorsUsed = rdr.ReadByte();

                        // Read the files protection status
                        byte ProtectionStatus = rdr.ReadByte();

                        OricFileInfo diskFileInfo = new OricFileInfo
                        {
                            MediaType = ConstantsAndEnums.MediaType.DiskFile,

                            //diskFileInfo.m_bDosFormat = OricDisk.DOSFormat.SedOric;

                            Folder = base.diskFolder,
                            ParentName = base.diskPathname,

                            ProgramName = Filename,
                            Extension = FileExtension
                        };

                        if (FileExtension.Length > 0)
                        {
                            diskFileInfo.ProgramName = string.Format("{0}.{1}", Filename, FileExtension);
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

                        byte[] FileDescriptor = base.ReadSector(FileDescTrack, FileDescSector);

                        MemoryStream stmFileDescriptor = new MemoryStream(FileDescriptor, 0, FileDescriptor.Length);
                        BinaryReader rdrFileDescriptor = new BinaryReader(stmFileDescriptor);

                        stmFileDescriptor.Seek(0x03, SeekOrigin.Begin);

                        byte FileType = rdrFileDescriptor.ReadByte();

                        if ((FileType & 0x08) == 0x08)
                        {
                            // We have a direct access file
                            diskFileInfo.NoOfRecords = rdrFileDescriptor.ReadUInt16();
                            diskFileInfo.RecordLength = rdrFileDescriptor.ReadUInt16();

                            diskFileInfo.StartAddress = 0x0000;
                            diskFileInfo.EndAddress = (ushort)(diskFileInfo.NoOfRecords * diskFileInfo.RecordLength);
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
                            diskFileInfo.Format = OricProgram.ProgramFormat.BinaryFile;
                        else if ((FileType & 0x80) == 0x80)
                            if (diskFileInfo.StartAddress == 0x501)
                                diskFileInfo.Format = OricProgram.ProgramFormat.BasicProgram;
                            else
                                diskFileInfo.Format = OricProgram.ProgramFormat.BinaryFile;
                        else
                            diskFileInfo.Format = OricProgram.ProgramFormat.UnknownFile;

                        if (diskFileInfo.Format == OricProgram.ProgramFormat.BinaryFile)
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

                                case 0xA000: 
                                    diskFileInfo.Format = OricProgram.ProgramFormat.HiresScreen;
                                    break;

                                case 0xB500:
                                    diskFileInfo.Format = OricProgram.ProgramFormat.CharacterSet;
                                    break;

                                default: 
                                    diskFileInfo.Format = OricProgram.ProgramFormat.BinaryFile;
                                    break;
                            }

                            if (diskFileInfo.StartAddress >= 0xA000 && diskFileInfo.StartAddress <= 0xBF3F)
                            {
                                // Possibly a HIRES screen
                                if (diskFileInfo.ProgramName.ToUpper().EndsWith(".HRS"))
                                    diskFileInfo.Format = OricProgram.ProgramFormat.HiresScreen;
                            }

                            if (diskFileInfo.ProgramName.ToUpper().EndsWith(".CHS"))
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

            OricFileInfo[] diskDirectory = new OricFileInfo[diskCatalog.Count];
            diskCatalog.CopyTo(diskDirectory);

            return diskDirectory;
        }

        public override OricProgram LoadFile(string diskName, OricFileInfo oricFileInfo)
        {
            int index = 0;
            int totalDescriptors;

            byte dataTrack;
            byte dataSector;
            byte nextDescTrack;
            byte nextDescSector;

            OricProgram loadedProgram = new OricProgram();
            loadedProgram.New();

            string diskPathname = Path.Combine(oricFileInfo.Folder, oricFileInfo.ParentName);

            if (base.LoadDisk(diskPathname))
            {
                byte[] fileDescriptor = GetFileDescriptor(oricFileInfo.ProgramName);

                loadedProgram.Format = GetFileFormat(fileDescriptor);
                loadedProgram.ProgramName = oricFileInfo.ProgramName;

                if (loadedProgram.ProgramName.ToUpper().EndsWith(".CHS"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.CharacterSet;
                }

                if (loadedProgram.ProgramName.ToUpper().EndsWith(".HRS"))
                {
                    loadedProgram.Format = OricProgram.ProgramFormat.HiresScreen;
                }

                byte formatFlag = fileDescriptor[0x03];

                if ((formatFlag & 0x01) == 0x01)
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Enabled;
                }
                else
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Disabled;
                }

                ushort sectorsToLoad = (ushort)(fileDescriptor[0x0A] + (fileDescriptor[0x0B] * 256));

                // Get program header info
                switch (loadedProgram.Format)
                {
                    case OricProgram.ProgramFormat.DirectAccessFile:
                        loadedProgram.RecordCount = (ushort)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256));
                        loadedProgram.RecordLength = (ushort)(fileDescriptor[0x06] + (fileDescriptor[0x07] * 256));

                        loadedProgram.StartAddress = 0x0000;
                        loadedProgram.EndAddress = (ushort)(loadedProgram.RecordCount * loadedProgram.RecordLength);
                        break;

                    case OricProgram.ProgramFormat.SequentialFile:
                        loadedProgram.RecordCount = 0;
                        loadedProgram.RecordLength = 0;

                        loadedProgram.StartAddress = 0x0000;
                        loadedProgram.EndAddress = (ushort)(sectorsToLoad * fileDescriptor.Length);
                        break;

                    default:
                        loadedProgram.RecordCount = 0;
                        loadedProgram.RecordLength = 0;

                        loadedProgram.StartAddress = (ushort)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256));
                        loadedProgram.EndAddress = (ushort)(fileDescriptor[0x06] + (fileDescriptor[0x07] * 256));
                        break;
                }

                do
                {
                    MemoryStream stm = new MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                    BinaryReader rdr = new BinaryReader(stm);

                    _ = new byte[32];

                    nextDescTrack = rdr.ReadByte();
                    nextDescSector = rdr.ReadByte();

                    byte firstDescriptorFlag = rdr.ReadByte();

                    int descriptorIndex = 0;

                    if (firstDescriptorFlag == 0xFF)
                    {
                        _ = rdr.ReadBytes(9);

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

                    //loadedProgram.m_programData = new byte[0xFFFF];
                    loadedProgram.ProgramData = new byte[programLength];

                    while (dataSector != 0 && descriptorIndex < totalDescriptors)
                    {
                        byte[] programData = base.ReadSector(dataTrack, dataSector);

                        MemoryStream stm2 = new MemoryStream(programData, 0, programData.Length);
                        BinaryReader rdr2 = new BinaryReader(stm2);

                        byte tmpByte;

                        for (int loop = 0; loop < programData.Length; loop++)
                        {
                            tmpByte = rdr2.ReadByte();

                            if (index < programLength)
                            {
                                loadedProgram.ProgramData[index] = tmpByte;
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

        private static OricProgram.ProgramFormat GetFileFormat(byte[] FileDescriptor)
        {
            OricProgram.ProgramFormat programFormat;

            ushort tmpStartAddr = (ushort)(FileDescriptor[0x04] + (FileDescriptor[0x05] * 256));

            byte formatFlag = FileDescriptor[0x03];

            if ((formatFlag & 0x08) == 0x08)
                programFormat = OricProgram.ProgramFormat.DirectAccessFile;
            else if ((formatFlag & 0x10) == 0x10)
                programFormat = OricProgram.ProgramFormat.SequentialFile;
            else if ((formatFlag & 0x20) == 0x20)
                programFormat = OricProgram.ProgramFormat.WindowFile;
            else if ((formatFlag & 0x40) == 0x40)
                programFormat = OricProgram.ProgramFormat.BinaryFile;
            else if ((formatFlag & 0x80) == 0x80)
                if (tmpStartAddr == 0x501)
                    programFormat = OricProgram.ProgramFormat.BasicProgram;
                else
                    programFormat = OricProgram.ProgramFormat.BinaryFile;
            else
                programFormat = OricProgram.ProgramFormat.UnknownFile;

            if (programFormat == OricProgram.ProgramFormat.BinaryFile)
            {
                switch (tmpStartAddr)
                {
                    case 0xBB80: 
                        programFormat = OricProgram.ProgramFormat.TextScreen;
                        break;
                    case 0xBBA8: 
                        programFormat = OricProgram.ProgramFormat.TextScreen; 
                        break;
                    case 0xA000:
                        programFormat = OricProgram.ProgramFormat.HiresScreen;
                        break;
                    case 0xB400: 
                        programFormat = OricProgram.ProgramFormat.CharacterSet;
                        break;
                    case 0xB500: 
                        programFormat = OricProgram.ProgramFormat.CharacterSet;
                        break;
                    default: 
                        programFormat = OricProgram.ProgramFormat.BinaryFile;
                        break;
                }
            }

            return programFormat;
        }

        private bool FindFile(string filename, ref byte track, ref byte sector, ref byte index)
        {
            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            bool fileMatchFound = false;

            byte dirTrack = 20;
            byte dirSector = 4;

            byte nextDirTrack = 20;
            byte nextDirSector = 4;

            while ((nextDirTrack != 0 && nextDirSector != 0) && fileMatchFound == false)
            {
                // Read current Directory Sector
                byte[] directory = base.ReadSector(dirTrack, dirSector);

                nextDirTrack = directory[0x00];
                nextDirSector = directory[0x01];

                index = 0;

                // Scan thru each file in the current directory
                MemoryStream memStream = new MemoryStream(directory, 0, directory.Length);
                BinaryReader binaryReader = new BinaryReader(memStream);

                // Move to first entry
                memStream.Seek(0x10, SeekOrigin.Begin);

                while (!fileMatchFound && index < 15)
                {
                    if (binaryReader.PeekChar() != 0x00)
                    {
                        byte[] fileName = binaryReader.ReadBytes(9);
                        byte[] extension = binaryReader.ReadBytes(3);

                        string dirFilename = enc.GetString(fileName).Trim();
                        string dirExtension = enc.GetString(extension).Trim();

                        string pathname = string.Format("{0}.{1}", dirFilename, dirExtension);

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
        
        private byte[] GetFileDescriptor(string fileName)
        {
            byte dirTrack = 0;
            byte dirSector = 0;
            byte dirIndex = 0;

            byte[] fileDescriptor = new byte[256];
            fileDescriptor.Initialize();

            // Search directory for matching file
            if (FindFile(fileName, ref dirTrack, ref dirSector, ref dirIndex))
            {
                // Get directory entry
                byte[] directory = base.ReadSector(dirTrack, dirSector);

                // Calculate start position of directory entry
                int bufferIndex = 0x10 * dirIndex;

                // Get Track & Sector of the File descriptor
                byte descTrack = directory[bufferIndex + 0x0C];
                byte descSector = directory[bufferIndex + 0x0D];

                // Get the file descriptor
                fileDescriptor = base.ReadSector(descTrack, descSector);
            }

            return fileDescriptor;
        }

        internal ushort[] BuildSectorMap(string diskPathname)
        {
            base.LoadDisk(diskPathname);

            ushort noOfSectors = (ushort)((tracksPerSide * sectorsPerTrack) * sides);

            ushort[] sectorMap = new ushort[noOfSectors];

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

            byte directoryTrack = 0x14;
            byte directorySector = 0x04;
            byte nextDirectoryTrack;
            byte nextDirectorySector;

            while (directorySector != 0x00)
            {
                byte[] directory = this.ReadSector(directoryTrack, directorySector);

                MemoryStream memoryStream = new MemoryStream(directory, 0, directory.Length);
                BinaryReader binReader = new BinaryReader(memoryStream);

                nextDirectoryTrack = binReader.ReadByte();
                nextDirectorySector = binReader.ReadByte();

                byte nextFreeEntry = binReader.ReadByte();

                byte noOfFiles = 0;

                if (nextFreeEntry == 0x00)
                {
                    noOfFiles = 15;
                }
                else
                {
                }

                UpdateSectorMap(sectorMap, directoryTrack, directorySector, (ushort)(0x0400 + noOfFiles));

                directoryTrack = nextDirectoryTrack;
                directorySector = nextDirectorySector;
            }

            BuildSedOricSectorMap2(sectorMap, diskPathname);

            return sectorMap;
        }

        private void BuildSedOricSectorMap2(ushort[] sectorMap, string diskPathname)
        {
            int iFileNum = 1;

            ushort bNextTrack = 0;
            ushort bNextSector = 0;
            ushort bNextDescTrack;
            ushort bNextDescSector;

            _ = new byte[10];

            string strSectorKey;

            OricFileInfo[] programList = ReadDirectory(diskPathname);

            foreach (OricFileInfo programInfo in programList)
            {
                ushort bTrack;
                ushort bSector;

                bTrack = programInfo.FirstTrack;
                bSector = programInfo.FirstSector;

                do
                {
                    byte[] bitmapSector = base.ReadSector(bTrack, bSector, ref bNextTrack, ref bNextSector);

                    // Add file descriptor to the sector map
                    UpdateSectorMap(sectorMap, bTrack, bSector, (ushort)(0x1100 + Convert.ToByte(iFileNum)));

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
                    byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                    MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
                    BinaryReader rdr = new BinaryReader(stm);

                    bNextTrack = rdr.ReadByte();
                    bNextSector = rdr.ReadByte();

                    bNextDescTrack = bNextTrack;
                    bNextDescSector = bNextSector;

                    byte bFirstDesc = rdr.ReadByte();

                    int iDescIndex = 0;

                    byte bDataTrack;
                    byte bDataSector;

                    int iTotalDescriptors;

                    if (bFirstDesc == 0xFF)
                    {
                        _ = rdr.ReadBytes(9);

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
                        UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (ushort)(0x1000 + Convert.ToByte(iFileNum)));
                    }

                    while (bDataSector != 0 && iDescIndex < iTotalDescriptors)
                    {
                        if (bDataSector != 0)
                        {
                            bDataTrack = rdr.ReadByte();
                            bDataSector = rdr.ReadByte();

                            if (bDataSector != 0)
                            {
                                UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (ushort)(0x1000 + Convert.ToByte(iFileNum)));
                            }

                            iDescIndex++;
                        }
                    }

                    strSectorKey = CreateKey(bNextDescTrack, bNextDescSector);

                } while (bNextDescSector != 0);

                iFileNum++;
            }
        }

        private void UpdateSectorMap(ushort[] sectorMap, int iTrack, int iSector, ushort ui16Marker)
        {
            if ((iTrack & 0x80) == 0x80)
            {
                iTrack = (ushort)(iTrack & 0x7F);
                iTrack += tracksPerSide;
            }

            int iIndex = (iTrack * sectorsPerTrack) + (iSector - 1);

            try
            {
                sectorMap[iIndex] = ui16Marker;
            }
            catch (Exception)
            {
            }
        }

        private void SetDOSSectors(ushort[] sectorMap, int iTrack, int iSector, int iNoOfSectors)
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

        public override bool DeleteFile(string diskName, string filename)
        {
            bool fileDeleted;

            // Find matching entry in the directory
            byte track = 0x00;
            byte sector = 0x00;
            byte index = 0x00;

            base.LoadDisk(diskName);
            ReadBitmap1();

            // Locate file in directory and return directory reference
            bool fileFound = FindFile(filename, ref track, ref sector, ref index);

            if (fileFound)
            {
                // Get the file descriptor
                byte[] fileDescriptor = GetFileDescriptor(filename);

                // Scan thought the descriptor for each sector to delete
                MemoryStream memoryStream = new MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                BinaryReader binReader = new BinaryReader(memoryStream);

                // Move to the required offset
                memoryStream.Seek(0x0A, SeekOrigin.Begin);

                // Get number of sectors
                ushort noOfSectors = binReader.ReadUInt16();

                ushort sectorIndex = 0;

                while (sectorIndex < noOfSectors)
                {
                    byte fileDataTrack = binReader.ReadByte();
                    byte fileDataSector = binReader.ReadByte();

                    if (fileDataSector != 0x00)
                    {
                        // Clear data in the sector
                        byte[] sectorData = base.ReadSector(fileDataTrack, fileDataSector);

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
                byte[] directory = base.ReadSector(track, sector);

                // Calculate start position of directory entry
                int bufferIndex = 0x10 * index;

                // Get Track & Sector of the File descriptor
                byte descTrack = directory[bufferIndex + 0x0C];
                byte descSector = directory[bufferIndex + 0x0D];

                // Clear data in the sector
                byte[] descSectorData = base.ReadSector(descTrack, descSector);

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
                byte[] Bitmap1 = base.ReadSector(20, 2);

                MemoryStream memStream = new MemoryStream(Bitmap1, 0, Bitmap1.Length);
                BinaryWriter bw = new BinaryWriter(memStream);

                memStream.Seek(0x02, SeekOrigin.Begin);

                bw.Write(sectorsFree);
                bw.Write(noOfFiles);

                base.WriteSector(20, 2, Bitmap1);

                // Update Bitmap 1 (No. of Sectors free and No. of files in Bitmap 1 and 2)
                byte[] Bitmap2 = base.ReadSector(20, 3);

                MemoryStream memStream2 = new MemoryStream(Bitmap2, 0, Bitmap2.Length);
                BinaryWriter bw2 = new BinaryWriter(memStream2);

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

        private void UpdateBitmap(byte track, byte sector, SectorState sectorState)
        {
            // Read bitmap
            byte[] bitmap = base.ReadSector(20, 2);

            int index = (track * sectorsPerTrack) + sector;
            int byteIndex = (index - 1) / 8;
            int bitIndex = (index - 1) % 8;

            byte data = bitmap[0x10 + byteIndex];

            if (GetBit(data, bitIndex))
            {
                //System.Console.WriteLine("Track : {0}, Sector : {1} - FREE", track, sector);
            }
            else
            {
                //System.Console.WriteLine("Track : {0}, Sector : {1} - USED", track, sector);
            }

            byte updatedData;

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
            BitArray ba = new BitArray(new byte[] { b });
            return ba.Get(bitNumber);
        }

        private byte SetBit(byte b, int bitNumber, bool value)
        {
            BitArray ba = new BitArray(new byte[] { b });
            ba.Set(bitNumber, value);

            string binary = ConvertBitArray(ba);

            byte number = Convert.ToByte(binary, 2);

            return number;
        }

        private string ConvertBitArray(BitArray bits)
        {
            string binary = "";

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

        //private void RemoveDirectoryEntry(string filename)
        //{
        //    byte dirTrack = 0x00;
        //    byte dirSector = 0x00;
        //    byte dirIndex = 0x00;

        //    // Locate file in directory and return directory reference
        //    bool fileFound = FindFile(filename, ref dirTrack, ref dirSector, ref dirIndex);

        //    if (fileFound)
        //    {
        //        byte[] directory = base.ReadSector(dirTrack, dirSector);

        //        // Calculate start position of directory entry
        //        int bufferIndex = 0x10 * dirIndex;

        //        for (int index = 0; index < 16; index++)
        //        {
        //            directory[bufferIndex + index] = 0x00;
        //        }

        //        base.WriteSector(dirTrack, dirSector, directory);
        //    }
        //}

        private void ReorganiseDirectory(string diskName, string filenameToDelete)
        {
            byte directoryTrack = 20;
            byte directorySector = 4;
            byte directoryIndex = 0;

            byte prevDirTrack;
            byte prevDirSector;

            int directoryCount = 0;

            byte[] directory = new byte[256];

            for (int index = 0; index < directory.Length; index++)
            {
                directory[index] = 0x00;
            }

            MemoryStream memStream = new MemoryStream(directory, 0, directory.Length);
            BinaryWriter bw = new BinaryWriter(memStream);
            memStream.Seek(0x10, SeekOrigin.Begin);

            // Read entire directory
            OricFileInfo[] diskDirectory = ReadDirectory(diskName);

            foreach (OricFileInfo fileInfo in diskDirectory)
            {
                if (!fileInfo.ProgramName.Equals(filenameToDelete))
                {
                    string filename = fileInfo.ProgramName;
                    filename = Path.GetFileNameWithoutExtension(filename);
                    filename = filename.PadRight(9, ' ');

                    bw.Write(filename.ToCharArray());

                    string extension = fileInfo.Extension.PadRight(3, ' ');
                    bw.Write(extension.ToCharArray());

                    bw.Write(fileInfo.FirstTrack);
                    bw.Write(fileInfo.FirstSector);
                    bw.Write((byte)fileInfo.LengthSectors);

                    if (fileInfo.Protection == OricProgram.ProtectionStatus.Protected)
                    {
                        bw.Write((byte)0xC0);
                    }
                    else if (fileInfo.Protection == OricProgram.ProtectionStatus.Unprotected)
                    {
                        bw.Write((byte)0x40);
                    }
                    else
                    {
                        bw.Write((byte)0x00);
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
                            case 1:
                                directorySector = 7; 
                                break;

                            case 2:
                                directorySector = 10; 
                                break;

                            case 3:
                                directorySector = 13;
                                break;

                            case 4:
                                directorySector = 16;
                                break;

                            default:
                                // Find next free sector and use that
                                break;
                        }

                        bw.Seek(0x00, SeekOrigin.Begin);
                        bw.Write(directoryTrack);
                        bw.Write(directorySector);

                        // Write value to indicate directory is full
                        bw.Write((byte)0x00);

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

                byte nextFreeSlot = (byte)((directoryIndex + 1) * 16);
                bw.Write((byte)nextFreeSlot);

                base.WriteSector(directoryTrack, directorySector, directory);
            }

            base.WriteDisk();
        }
    }
}
