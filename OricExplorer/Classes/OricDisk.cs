namespace OricExplorer
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    public class OricDisk
    {
        private static Encoding AsciiEncoder = Encoding.ASCII;

        public enum DiskTypes { Unknown, Master, Slave, Game };
        public enum DOSFormats { Unknown, OricDOS, SedOric, TDOS, StratSed, XLDos };
        public enum DOSVersions { Unknown, OricDOS_V1_1, OricDOS_V1_13, SedOric_V1_004, SedOric_V1_005, SedOric_V1_006, SedOric_V1_007, SedOric_V2_1, SedOric_V3_006, TDOS_V3_2, Stratsed_V2_0_c, XLDos_V0_6 };

        public enum SectorState { FREE, USED };

        protected DOSFormats dosFormat;
        protected DOSVersions dosVersion;

        //private DiskTypes diskType;

        public bool diskLoaded = false;
        private bool diskModified = false;

        //private ushort noOfSides = 0;
        //private ushort tracksPerSide = 0;
        //private ushort sectorsPerTrack = 0;
        //private ushort noOfFiles = 0;
        //private ushort noOfDirectories = 0;

        protected string diskPathname = "";
        protected string diskFilename = "";
        protected string diskFolder = "";

        private Hashtable sectorPointers;     // List of pointers to each sector in the diskBuffer
        public byte[] diskBuffer;            // Buffer used to store the entire disk

        public OricDisk()
        {
            // Initialise settings
            diskLoaded = false;
            diskModified = false;

            //noOfSides = 0;
            //tracksPerSide = 0;
            //sectorsPerTrack = 0;
            //noOfFiles = 0;

            dosFormat = DOSFormats.Unknown;
            dosVersion = DOSVersions.Unknown;
            //diskType = DiskTypes.Unknown;
        }

        public OricDisk(string diskPathname)
        {
            // Initialise settings
            diskLoaded = false;
            diskModified = false;

            //noOfSides = 0;
            //tracksPerSide = 0;
            //sectorsPerTrack = 0;
            //noOfFiles = 0;

            dosFormat = DOSFormats.Unknown;
            dosVersion = DOSVersions.Unknown;
            //diskType = DiskTypes.Unknown;

            if (!LoadDisk(diskPathname))
            {
                diskLoaded = false;
            }
            else
            {
                diskLoaded = true;
            }
        }

        public virtual bool DeleteFile(string diskName, string filename)
        {
            return true;
        }

        public bool SaveFile(string diskName, string fileName, OricProgram program)
        {
            bool fileSaved = false;

            // Disk should be loaded
            if (diskLoaded)
            {
                if (dosFormat == DOSFormats.OricDOS)
                {
                    OricDos oricdos = new OricDos();
                    oricdos.SaveFile(diskName, fileName, program, this);
                }
            }

            return fileSaved;
        }

        public virtual OricProgram LoadFile(string diskName, OricFileInfo oricFileInfo)
        {
            OricProgram oricProgram = new OricProgram();
            oricProgram.New();

            return oricProgram;
        }

        public virtual OricFileInfo[] ReadDirectory(string diskPathname)
        {
            OricFileInfo[] files = new OricFileInfo[0];
            return files;
        }

        #region Disk functions
        private DOSFormats GetDOSFormat(byte track, byte sector, ref DOSVersions version, byte offset)
        {
            DOSFormats format = DOSFormats.Unknown;

            byte[] sectorData = ReadSector(track, sector);

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(sectorData, 0, sectorData.Length);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(memoryStream);

            // Move to where the version string starts
            if (offset == 0x00)
            {
                memoryStream.Seek(0x40, SeekOrigin.Begin);
            }
            else
            {
                memoryStream.Seek(offset, SeekOrigin.Begin);
            }

            byte[] dosFormat;
            dosFormat = binaryReader.ReadBytes(8);

            string dosFormatString = AsciiEncoder.GetString(dosFormat).Trim();

            if (dosFormatString.Equals("SEDORIC"))
            {
                format = DOSFormats.SedOric;

                // Now get the version string
                dosFormat = binaryReader.ReadBytes(6);

                char[] delimiters = new char[3];
                delimiters[0] = '\r';
                delimiters[1] = '\n';
                delimiters[2] = ' ';

                string dosVersionString = AsciiEncoder.GetString(dosFormat).Trim(delimiters);

                switch(dosVersionString)
                {
                    case "V1.004":
                        version = DOSVersions.SedOric_V1_004;
                        break;

                    case "V1.005":
                        version = DOSVersions.SedOric_V1_005;
                        break;

                    case "V1.006":
                        version = DOSVersions.SedOric_V1_006;
                        break;

                    case "V1.007":
                        version = DOSVersions.SedOric_V1_007;
                        break;

                    case "V2.1":
                        version = DOSVersions.SedOric_V2_1;
                        break;

                    case "V3.0":
                        version = DOSVersions.SedOric_V3_006;
                        break;

                    case "V3.006":
                        version = DOSVersions.SedOric_V3_006;
                        break;

                    default:
                        version = DOSVersions.Unknown;
                        break;

                }
            }
            else if (dosFormatString.Equals("Oric DOS"))
            {
                format = DOSFormats.OricDOS;
                version = DOSVersions.OricDOS_V1_13;
            }
            else if (dosFormatString.Equals("STRATSED"))
            {
                format = DOSFormats.StratSed;
                version = DOSVersions.Stratsed_V2_0_c;
            }
            else if (dosFormatString.StartsWith("XL DOS"))
            {
                format = DOSFormats.XLDos;
                version = DOSVersions.XLDos_V0_6;
            }

            return format;
        }

        private void IdentifyDosFormat(ref DOSFormats format, ref DOSVersions version)
        {
            // Identify the DOS format and version of the currently loaded disk
            //format = DOSFormats.Unknown;
            version = DOSVersions.Unknown;

            // Firstly lets see if it's a SedOric disk
            format = GetDOSFormat(0, 1, ref version, 0x00);

            if (format == DOSFormats.Unknown)
            {
                format = GetDOSFormat(0, 2, ref version, 0xD1);

                if (format == DOSFormats.Unknown)
                {
                    format = GetDOSFormat(4, 17, ref version, 0x00);

                    if (format == DOSFormats.Unknown)
                    {
                        format = GetDOSFormat(2, 11, ref version, 0xC8);

                        if (format == DOSFormats.Unknown)
                        {
                            format = GetDOSFormat(0, 1, ref version, 0x22);

                            if (format == DOSFormats.Unknown)
                            {
                                // Check if it is a TDOS disk
                                byte[] DosID = ReadSector(20, 1);

                                if (DosID[0xF6] == 0x80 && DosID[0xF7] == 0x80)
                                {
                                    format = DOSFormats.TDOS;
                                    version = DOSVersions.TDOS_V3_2;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private bool ValidateDisk()
        {
            FileStream diskFile = new FileStream(diskPathname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader binaryReader = new BinaryReader(diskFile);

            // Read the disk identifier (first 9 bytes)
            byte[] diskID;
            diskID = binaryReader.ReadBytes(8);

            // Close the disk file
            diskFile.Close();

            // Check if identifier is valid or not
            if (diskID.Equals("MFM_DISK"))
            {
                return false;
            }

            return true;
        }

        public void Initialise()
        {
            // Reset/Initialise disk values and settings
            diskLoaded = false;
            diskModified = false;

            //noOfSides = 0;
            //tracksPerSide = 0;
            //sectorsPerTrack = 0;
            //noOfFiles = 0;
        }

        private bool LoadDiskIntoMemory()
        {
            try
            {
                diskBuffer = File.ReadAllBytes(diskPathname);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        public bool LoadDisk(string diskPathname)
        {
            this.diskPathname = diskPathname;

            diskFolder = Path.GetDirectoryName(diskPathname);
            diskFilename = Path.GetFileName(diskPathname);

            // Initialise disk settings to remove currently loaded values
            Initialise();

            // Validate the disk file
            if (ValidateDisk())
            {
                // Disk is a valid Oric disk, load entire disk into memory
                if (LoadDiskIntoMemory())
                {
                    // Build table of pointers to each sector in the disk buffer
                    if (GenerateSectorIndexes())
                    {
                        diskLoaded = true;

                        // Now we need to ascertain what DOS format the disk is
                        IdentifyDosFormat(ref dosFormat, ref dosVersion);

                        if (dosFormat != DOSFormats.Unknown)
                        {
                            //GetDiskInformation();
                            diskLoaded = true;
                        }
                    }
                }
            }

            if (diskLoaded)
            {
                // Get information about the disk

                //TODO: Remove
                //noOfFiles = 10;
            }

            return true;
        }

        public bool WriteDisk()
        {
            try
            {
                File.WriteAllBytes(diskPathname, diskBuffer);

                // Reset the modified flag
                diskModified = false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Disk Sector functions
        public int CalculateNoOfSectors()
        {
            int noOfSectors = 0;

            byte currTrack;
            byte currSide;
            byte currSector;
            byte sectorSize;

            bool markerFound;
            bool endOfDisk = false;

            sectorPointers = new Hashtable();

            // Set buffer index to start of first track
            uint bufferIndex = 0x0100;

            while (!endOfDisk)
            {
                markerFound = false;

                // Locate the sector marker
                while (markerFound == false && endOfDisk == false)
                {
                    try
                    {
                        if (diskBuffer[bufferIndex] == 0xFE)
                        {
                            markerFound = true;
                        }
                        else
                        {
                            bufferIndex++;

                            if (bufferIndex == diskBuffer.Length)
                            {
                                endOfDisk = true;
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return 0;
                    }
                }

                if (!endOfDisk)
                {
                    // Get details from the sector header
                    bufferIndex++;

                    currTrack = diskBuffer[bufferIndex];
                    bufferIndex++;

                    currSide = diskBuffer[bufferIndex];
                    bufferIndex++;

                    currSector = diskBuffer[bufferIndex];

                    if(currSector > noOfSectors)
                    {
                        noOfSectors = currSector;
                    }

                    bufferIndex++;

                    sectorSize = diskBuffer[bufferIndex];
                    bufferIndex += 3;

                    while (diskBuffer[bufferIndex] != 0xFB && diskBuffer[bufferIndex] != 0xF8)
                    {
                        bufferIndex++;
                    }

                    // Skip past the data flag
                    bufferIndex++;

                    // Create the sector key
                    string sectorKey = string.Format("{0:D2}{1:D2}{2:D2}", currSide, currTrack, currSector);

                    // Put sector data into the hashtable
                    if (!sectorPointers.ContainsKey(sectorKey))
                    {
                        string sectoryInfo = string.Format("{0},{1}", sectorSize, bufferIndex);
                        sectorPointers.Add(sectorKey, sectoryInfo);
                    }

                    if (sectorSize == 1)
                    {
                        bufferIndex += 258;
                    }
                    else
                    {
                        bufferIndex += 514;
                    }

                    // Current byte should be 0x4E
                    try
                    {
                        if (diskBuffer[bufferIndex] != 0x4E)
                        {
                            return 0;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("> Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return 0;
                    }
                }
            }

            return noOfSectors;
        }

        private bool GenerateSectorIndexes()
        {
            byte currTrack;
            byte currSide;
            byte currSector;
            byte sectorSize;

            bool markerFound;
            bool endOfDisk = false;

            sectorPointers = new Hashtable();

            // Set buffer index to start of first track
            uint bufferIndex = 0x0100;

            while (!endOfDisk)
            {
                markerFound = false;

                // Locate the sector marker
                while (markerFound == false && endOfDisk == false)
                {
                    try
                    {
                        if (diskBuffer[bufferIndex] == 0xFE)
                        {
                            markerFound = true;
                            //swLogfile.WriteLine("Marker 0xFE found at {0}", bufferIndex);
                        }
                        else
                        {
                            bufferIndex++;

                            if (bufferIndex == diskBuffer.Length)
                            {
                                endOfDisk = true;
                                //swLogfile.WriteLine("Reached end of disk (Index : {0})", bufferIndex);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return false;
                    }
                }

                if (!endOfDisk)
                {
                    // Get details from the sector header
                    bufferIndex++;

                    currTrack = diskBuffer[bufferIndex];
                    bufferIndex++;

                    currSide = diskBuffer[bufferIndex];
                    bufferIndex++;

                    currSector = diskBuffer[bufferIndex];
                    bufferIndex++;

                    sectorSize = diskBuffer[bufferIndex];
                    bufferIndex += 3;

                    //swLogfile.WriteLine("Disk Info found : Side {0}, Track {1}, Sector {2} (Sector size {3})",
                    //                    currSide, currTrack, currSector, sectorSize);

                    while (diskBuffer[bufferIndex] != 0xFB && diskBuffer[bufferIndex] != 0xF8)
                    {
                        bufferIndex++;
                    }

                    // Skip past the data flag
                    bufferIndex++;

                    // Create the sector key
                    string sectorKey = string.Format("{0:D2}{1:D2}{2:D2}", currSide, currTrack, currSector);

                    // Put sector data into the hashtable
                    if (!sectorPointers.ContainsKey(sectorKey))
                    {
                        //swLogfile.WriteLine("Creating sector key : {0}, Index {1}", sectorKey, bufferIndex);

                        string sectoryInfo = string.Format("{0},{1}", sectorSize, bufferIndex);
                        sectorPointers.Add(sectorKey, sectoryInfo);
                    }

                    if (sectorSize == 1)
                    {
                        bufferIndex += 258;
                    }
                    else
                    {
                        bufferIndex += 514;
                    }

                    // Current byte should be 0x4E
                    try
                    {
                        if (diskBuffer[bufferIndex] != 0x4E)
                        {
                            //swLogfile.WriteLine("Found end marker 0x4E at index {0}", bufferIndex);
                            return false;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("> Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return false;
                    }
                }
            }

            return true;
        }

        public string CreateKey(ushort track, ushort sector)
        {
            // Set the default side
            ushort side = 0;

            if ((track & 0x80) == 0x80)
            {
                track = (ushort)(track & 0x7F);
                side = 1;
            }

            return string.Format("{0:D2}{1:D2}{2:D2}", side, track, sector);
        }
        
        public byte[] ReadSector(ushort track, ushort sector, ref ushort nextTrack, ref ushort nextSector)
        {
            // Create key
            string sectorKey = CreateKey(track, sector);

            byte[] sectorData;

            if (sectorPointers.ContainsKey(sectorKey))
            {
                string[] sectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                ushort bufferSize = Convert.ToUInt16(sectorInfo[0]);
                uint bufferIndex = Convert.ToUInt32(sectorInfo[1]);

                sectorData = new byte[bufferSize * 256];

                // Get first two bytes which point to next sector
                nextTrack = Convert.ToUInt16(diskBuffer[bufferIndex]);
                nextSector = Convert.ToUInt16(diskBuffer[bufferIndex + 1]);

                // Copy the sector data
                for (ushort loop = 0; loop < bufferSize * 256; loop++)
                {
                    sectorData[loop] = diskBuffer[bufferIndex + loop];
                }
            }
            else
            {
                sectorData = new byte[256];
                sectorData.Initialize();
            }

            return sectorData;
        }

        public byte[] ReadSector(ushort track, ushort sector)
        {
            // Create key
            string sectorKey = CreateKey(track, sector);

            byte[] sectorData;

            if (sectorPointers.ContainsKey(sectorKey))
            {
                string[] sectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                ushort bufferSize = Convert.ToUInt16(sectorInfo[0]);
                uint bufferIndex = Convert.ToUInt32(sectorInfo[1]);

                sectorData = new byte[bufferSize * 256];

                // Copy the sector data
                for (ushort loop = 0; loop < bufferSize * 256; loop++)
                {
                    sectorData[loop] = diskBuffer[bufferIndex + loop];
                }
            }
            else
            {
                sectorData = new byte[256];
                sectorData.Initialize();
            }

            return sectorData;
        }

        public void WriteSector(ushort track, ushort sector, byte[] sectorData)
        {
            string sectorKey = CreateKey(track, sector);

            if (sectorPointers.ContainsKey(sectorKey))
            {
                string[] strSectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                //ushort bufferSize = Convert.ToUInt16(strSectorInfo[0]);
                uint bufferIndex = Convert.ToUInt32(strSectorInfo[1]);

                for (ushort loop = 0; loop < sectorData.Length; loop++)
                {
                    diskBuffer[bufferIndex + loop] = sectorData[loop];
                }
            }
        }

        public void InitialiseSector(ushort track, ushort sector)
        {
            byte[] sectorData = ReadSector(track, sector);

            for (ushort loop = 0; loop < sectorData.Length; loop++)
            {
                sectorData[loop] = 0x00;
            }

            WriteSector(track, sector, sectorData);
        }
        #endregion

        #region Getters and Setters
        public bool DiskLoaded()
        {
            return diskLoaded;
        }

        public bool DiskModified()
        {
            return diskModified;
        }

        public DOSFormats DOSFormat()
        {
            return dosFormat;
        }

        public DOSVersions DOSVersion()
        {
            return dosVersion;
        }

        //public ushort FileCount()
        //{
        //    return noOfFiles;
        //}
        #endregion

        #region Misc Functions
        /*public OricFileInfo[] GetDirectory()
        {
            OricFileInfo[] files = null;

            switch (dosFormat)
            {
                case DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        files = oricDisc.ReadDirectory(diskPathname);
                    }
                    break;

                case DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        files = oricDisc.ReadDirectory(diskPathname);
                    }
                    break;

                default:
                    files = new OricFileInfo[0];
                    break;
            }

            return files;
        }*/

        //public OricFileInfo[] GetDirectory(string filter)
        //{
        //    OricFileInfo fileInfo = new OricFileInfo();
        //    fileInfo.Name = "DISKNAME";

        //    OricFileInfo[] fileList = new OricFileInfo[10];

        //    return fileList;
        //}

        //public StringBuilder OutputDiskSectors(string diskPathname)
        //{
        //    StringBuilder sectorList = new StringBuilder();

        //    foreach (DictionaryEntry entry in sectorPointers)
        //    {
        //        ushort side = Convert.ToUInt16(entry.Key.ToString().Substring(0, 2));
        //        ushort track = Convert.ToUInt16(entry.Key.ToString().Substring(2, 2));
        //        ushort sector = Convert.ToUInt16(entry.Key.ToString().Substring(4, 2));

        //        byte[] sectorData = ReadSector(track, sector);

        //        sectorList.AppendFormat("      Side : {0}, Track : {1}, Sector : {2}", side, track, sector);
        //        sectorList.AppendLine();

        //        int count = 0;
        //        string ascii = "";

        //        for (int index = 0; index < sectorData.Length; index++)
        //        {
        //            if (count == 0)
        //            {
        //                ascii = "";
        //                sectorList.AppendFormat("${0:X4}|", index);
        //            }

        //            sectorList.AppendFormat("{0:X2} ", sectorData[index]);

        //            if (sectorData[index] >= 32 && sectorData[index] <= 127)
        //            {
        //                ascii += Convert.ToChar(sectorData[index]);
        //            }
        //            else
        //            {
        //                ascii += ".";
        //            }

        //            count++;

        //            if (count == 16)
        //            {
        //                sectorList.Append(ascii);
        //                sectorList.AppendLine();
        //                count = 0;
        //            }
        //        }

        //        sectorList.AppendLine();
        //    }

        //    return sectorList;
        //}
        #endregion
    }
}
