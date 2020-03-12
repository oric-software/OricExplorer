namespace OricExplorer
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;

    class FTDos : OricDisk
    {
        //byte directoryTrack = 0x00;
        //byte directorySector = 0x00;

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

            stm.Seek(0xF8, SeekOrigin.Begin);

            byte[] bByteArray = rdr.ReadBytes(8);

            diskName = enc.GetString(bByteArray);
            diskName.Trim();

            sectorData = base.ReadSector(0, 1);

            MemoryStream stm2 = new MemoryStream(sectorData, 0, sectorData.Length);
            BinaryReader rdr2 = new BinaryReader(stm2);

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

            sectors = (ushort)((tracksPerSide * sectorsPerTrack) * sides);

            OricFileInfo[] programList = ReadDirectory(diskPathname);

            foreach (OricFileInfo programInfo in programList)
            {
                ushort sectorsUsedByProgram = programInfo.LengthSectors;
                sectorsUsed += sectorsUsedByProgram;
            }

            if(diskType == DiskTypes.Master)
            {
                sectorsUsed += 62;
            }

            sectorsFree = (ushort)(sectors - sectorsUsed);

            noOfFiles = (ushort)programList.Count();
        }

        public override OricFileInfo[] ReadDirectory(string diskPathname)
        {
            base.LoadDisk(diskPathname);
            OricFileInfo[] files = ReadFTDosDirectory();
            return files;
        }

        private OricFileInfo[] ReadFTDosDirectory()
        {
            OricFileInfo[] diskDirectory = null;

            int iDirFileCount;

            ushort i16DirectoryIndex = 1;
            ushort i16EntryIndex = 1;

            System.Text.Encoding enc = System.Text.Encoding.ASCII;

            ArrayList diskCatalog = new ArrayList();

            byte bNextTrack = 20;
            byte bNextSector = 2;
            
            byte bCurrTrack = bNextTrack;
            byte bCurrSector = bNextSector;
            
            bool bMoreDirectories = true;

            while (bMoreDirectories)
            {
                iDirFileCount = 0;

                byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
                BinaryReader rdr = new BinaryReader(stm);

                byte[] bByteArray = new byte[32];
                bByteArray = rdr.ReadBytes(2);

                bNextTrack = rdr.ReadByte();
                bNextSector = rdr.ReadByte();

                for (int iLoop = 0; iLoop < 14; iLoop++)
                {
                    OricFileInfo diskFile = new OricFileInfo();
                    diskFile.MediaType = ConstantsAndEnums.MediaType.DiskFile;

                    diskFile.FirstTrack = rdr.ReadByte();
                    diskFile.FirstSector = rdr.ReadByte();

                    diskFile.Folder = base.diskFolder;
                    diskFile.ParentName = base.diskPathname;

                    byte bProtection = rdr.ReadByte();

                    if (bProtection == 'U')
                        diskFile.Protection = OricProgram.ProtectionStatus.Unlocked;
                    else if (bProtection == 'L')
                        diskFile.Protection = OricProgram.ProtectionStatus.Locked;
                    else
                        diskFile.Protection = OricProgram.ProtectionStatus.Unlocked;

                    bByteArray = rdr.ReadBytes(8);

                    if ((bByteArray[0] != 0xFF && bByteArray[0] != 0x00 && bByteArray[0] != 0x6C) && diskFile.FirstTrack != 0xFF)
                    {
                        string strFilename = enc.GetString(bByteArray).Trim();

                        if (strFilename.Length > 0)
                        {
                            // Read decimal point between filename and extension
                            bByteArray = rdr.ReadBytes(1);

                            // Read the Extension
                            bByteArray = rdr.ReadBytes(3);
                            string strExtension = enc.GetString(bByteArray).Trim();

                            diskFile.Name = strFilename;
                            diskFile.Extension = strExtension;

                            if (strExtension.Length > 0)
                            {
                                diskFile.ProgramName = string.Format("{0}.{1}", diskFile.Name, diskFile.Extension);
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
                                diskFile.Format = OricProgram.ProgramFormat.AtmosBasicProgram;
                            }
                            else if (strExtension.Equals("CMD") || strExtension.Equals("BIN") || strExtension.Equals("SYS"))
                            {
                                diskFile.Format = OricProgram.ProgramFormat.BinaryFile;
                            }
                            else
                            {
                                diskFile.Format = OricProgram.ProgramFormat.UnknownFile;
                            }

                            diskFile.LengthSectors = rdr.ReadByte();

                            bByteArray = rdr.ReadBytes(1);

                            byte[] fileDesc = base.ReadSector(diskFile.FirstTrack, diskFile.FirstSector);

                            MemoryStream stm2 = new MemoryStream(fileDesc, 0, sectorData.Length);
                            BinaryReader rdr2 = new BinaryReader(stm2);

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

            byte dataTrack = 0;
            byte dataSector = 0;
            byte nextDescTrack = 0;
            byte nextDescSector = 1;

            OricProgram loadedProgram = new OricProgram();
            loadedProgram.New();

            string diskPathname = Path.Combine(oricFileInfo.Folder, oricFileInfo.ParentName);

            if (base.LoadDisk(diskPathname))
            {
                byte[] fileDescriptor = base.ReadSector(oricFileInfo.FirstTrack, oricFileInfo.FirstSector);

                loadedProgram.Format = OricProgram.ProgramFormat.AtmosBasicProgram; // GetFileFormat(fileDescriptor);
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

                //byte formatFlag = fileDescriptor[0x03];

                /*if ((formatFlag & 0x01) == 0x01)
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Enabled;
                }
                else
                {
                    loadedProgram.AutoRun = OricProgram.AutoRunFlag.Disabled;
                }*/

                //ushort sectorsToLoad = (ushort)(fileDescriptor[0x0A] + (fileDescriptor[0x0B] * 256));
                ushort sectorsToLoad = oricFileInfo.LengthSectors;

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

                        loadedProgram.StartAddress = (ushort)(fileDescriptor[0x02] + (fileDescriptor[0x03] * 256));
                        loadedProgram.EndAddress = (ushort)(loadedProgram.StartAddress + ((ushort)(fileDescriptor[0x04] + (fileDescriptor[0x05] * 256))));
                        break;
                }

                do
                {
                    MemoryStream stm = new MemoryStream(fileDescriptor, 0, fileDescriptor.Length);
                    BinaryReader rdr = new BinaryReader(stm);

                    byte[] byteArray = new byte[32];

                    nextDescTrack = rdr.ReadByte();
                    nextDescSector = rdr.ReadByte();

                    byteArray = rdr.ReadBytes(4);

                    // byte firstDescriptorFlag = rdr.ReadByte();

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

                    loadedProgram.m_programData = new byte[programLength];

                    while (dataSector != 0xFF && descriptorIndex < totalDescriptors)
                    {
                        byte[] programData = base.ReadSector(dataTrack, dataSector);

                        MemoryStream stm2 = new MemoryStream(programData, 0, programData.Length);
                        BinaryReader rdr2 = new BinaryReader(stm2);

                        byte tmpByte = 0;

                        int loopStart = 0;

                        if (loadedProgram.Format == OricProgram.ProgramFormat.AtmosBasicProgram)
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

        private static OricProgram.ProgramFormat GetFileFormat(byte[] FileDescriptor)
        {
            OricProgram.ProgramFormat programFormat = OricProgram.ProgramFormat.UnknownFile;

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
                programFormat = OricProgram.ProgramFormat.AtmosBasicProgram;
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
            byte dirSector = 2;

            byte nextDirTrack = dirTrack;
            byte nextDirSector = dirSector;

            /*while ((nextDirTrack != 0 && nextDirSector != 0) && fileMatchFound == false)
            {
                // Read current Directory Sector
                byte[] directory = base.ReadSector(dirTrack, dirSector);

                // Scan thru each file in the current directory
                MemoryStream memStream = new MemoryStream(directory, 0, directory.Length);
                BinaryReader binaryReader = new BinaryReader(memStream);

                byte[] bByteArray = new byte[32];
                bByteArray = binaryReader.ReadBytes(2);

                nextDirTrack = directory[0x00];
                nextDirSector = directory[0x01];

                index = 0;

                // Move to first entry
                memStream.Seek(0x04, SeekOrigin.Begin);

                while (!fileMatchFound && index < 15)
                {
                    byte firstTrack = binaryReader.ReadByte();
                    byte firstSector = binaryReader.ReadByte();

                    byte bProtection = binaryReader.ReadByte();

                    if (binaryReader.PeekChar() != 0x00)
                    {
                        byte[] fileName = binaryReader.ReadBytes(8);

                        // Read decimal point between filename and extension
                        bByteArray = binaryReader.ReadBytes(1);

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
            }*/

            return fileMatchFound;
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

            // Mark the disk bitmap
            UpdateSectorMap(sectorMap, 20, 1, 0x0200);

            if (diskType == DiskTypes.Master)
            {
                SetDOSSectors(sectorMap, 0, 1, 62);
            }

            byte directoryTrack = 0x14;
            byte directorySector = 0x02;

            // Mark Directories
            UpdateSectorMap(sectorMap, directoryTrack, directorySector, 0x0400);

            byte nextDirectoryTrack = directoryTrack;
            byte nextDirectorySector = directorySector;

            while ((directoryTrack != 0xFF) && (directoryTrack != 0x6C && directorySector != 0x6C) && (directoryTrack != 0x00 && directorySector != 0x00))
            {
                byte[] directory = this.ReadSector(directoryTrack, directorySector);

                MemoryStream memoryStream = new MemoryStream(directory, 0, directory.Length);
                BinaryReader binReader = new BinaryReader(memoryStream);

                binReader.ReadBytes(2);

                nextDirectoryTrack = binReader.ReadByte();
                nextDirectorySector = binReader.ReadByte();

                //byte nextFreeEntry = binReader.ReadByte();

                byte noOfFiles = 0;

                /*if (nextFreeEntry == 0x00)
                {
                    noOfFiles = 15;
                }
                else
                {
                }*/

                if (directoryTrack != 0x6C && directorySector != 0x6C)
                {
                    UpdateSectorMap(sectorMap, directoryTrack, directorySector, (ushort)(0x0400 + noOfFiles));
                }

                directoryTrack = nextDirectoryTrack;
                directorySector = nextDirectorySector;
            }

            BuildTDosSectorMap2(sectorMap, diskPathname);

            return sectorMap;
        }

        private void BuildTDosSectorMap2(ushort[] sectorMap, string diskPathname)
        {
            int iFileNum = 1;

            ushort bNextTrack = 0;
            ushort bNextSector = 0;
            ushort bNextDescTrack;
            ushort bNextDescSector;

            byte[] bByteArray = new byte[10];

            string strSectorKey = "";

            OricFileInfo[] programList = ReadDirectory(diskPathname);

            foreach (OricFileInfo programInfo in programList)
            {
                if (programInfo.Format != OricProgram.ProgramFormat.UnknownFile)
                {
                    ushort bTrack;
                    ushort bSector;

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
                            byte[] bitmapSector = base.ReadSector(bTrack, bSector, ref bNextTrack, ref bNextSector);

                            // Add file descriptor to the sector map
                            UpdateSectorMap(sectorMap, bTrack, bSector, (ushort)(0x1100 + Convert.ToByte(iFileNum)));

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
                            byte[] sectorData = base.ReadSector(bNextTrack, bNextSector);

                            MemoryStream stm = new MemoryStream(sectorData, 0, sectorData.Length);
                            BinaryReader rdr = new BinaryReader(stm);

                            bNextTrack = rdr.ReadByte();
                            bNextSector = rdr.ReadByte();

                            bNextDescTrack = bNextTrack;
                            bNextDescSector = bNextSector;

                            rdr.ReadBytes(4);

                            //byte bFirstDesc = rdr.ReadByte();

                            int iDescIndex = 0;
                            int iTotalDescriptors = 125;

                            byte bDataTrack;
                            byte bDataSector;

                            bDataTrack = rdr.ReadByte();
                            bDataSector = rdr.ReadByte();

                            if (bDataTrack != 0xFF && bDataSector != 0xFF)
                            {
                                UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (ushort)(0x1000 + Convert.ToByte(iFileNum)));
                            }

                            while (bDataSector != 0xFF && iDescIndex < iTotalDescriptors)
                            {
                                if (bDataSector != 0xFF)
                                {
                                    bDataTrack = rdr.ReadByte();
                                    bDataSector = rdr.ReadByte();

                                    if (bDataSector != 0xFF)
                                    {
                                        UpdateSectorMap(sectorMap, bDataTrack, bDataSector, (ushort)(0x1000 + Convert.ToByte(iFileNum)));
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
            catch (Exception ex)
            {
                string oMessage = ex.Message;
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
    }
}
