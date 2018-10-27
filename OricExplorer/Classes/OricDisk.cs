using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace OricExplorer
{
    public class OricDisk
    {
        private static System.Text.Encoding AsciiEncoder = System.Text.Encoding.ASCII;

        public enum DiskTypes { Unknown, Master, Slave, Game };
        public enum DOSFormats { Unknown, OricDOS, SedOric, TDOS, StratSed, XLDos };
        public enum DOSVersions { Unknown, OricDOS_V1_1, OricDOS_V1_13, SedOric_V1_004, SedOric_V1_005, SedOric_V1_006, SedOric_V1_007, SedOric_V2_1, SedOric_V3_006, TDOS_V3_2, Stratsed_V2_0_c, XLDos_V0_6 };

        public enum SectorState { FREE, USED };

        protected DOSFormats dosFormat;
        protected DOSVersions dosVersion;

        private DiskTypes diskType;

        public Boolean diskLoaded = false;
        private Boolean diskModified = false;

        private UInt16 noOfSides = 0;
        private UInt16 tracksPerSide = 0;
        private UInt16 sectorsPerTrack = 0;
        private UInt16 noOfFiles = 0;
        private UInt16 noOfDirectories = 0;

        protected String diskPathname = "";
        protected String diskFilename = "";
        protected String diskFolder = "";

        private Hashtable sectorPointers;     // List of pointers to each sector in the diskBuffer
        public Byte[] diskBuffer;            // Buffer used to store the entire disk

        public OricDisk()
        {
            // Initialise settings
            diskLoaded = false;
            diskModified = false;

            noOfSides = 0;
            tracksPerSide = 0;
            sectorsPerTrack = 0;
            noOfFiles = 0;

            dosFormat = DOSFormats.Unknown;
            dosVersion = DOSVersions.Unknown;
            diskType = DiskTypes.Unknown;
        }

        public OricDisk(String diskPathname)
        {
            // Initialise settings
            diskLoaded = false;
            diskModified = false;

            noOfSides = 0;
            tracksPerSide = 0;
            sectorsPerTrack = 0;
            noOfFiles = 0;

            dosFormat = DOSFormats.Unknown;
            dosVersion = DOSVersions.Unknown;
            diskType = DiskTypes.Unknown;

            if (!LoadDisk(diskPathname))
            {
                diskLoaded = false;
            }
            else
            {
                diskLoaded = true;
            }
        }

        public virtual Boolean DeleteFile(String diskName, String filename)
        {
            return true;
        }

        public Boolean SaveFile(String diskName, String fileName, OricProgram program)
        {
            Boolean fileSaved = false;

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

        public virtual OricProgram LoadFile(String diskName, OricFileInfo oricFileInfo)
        {
            OricProgram oricProgram = new OricProgram();
            oricProgram.New();

            return oricProgram;
        }

        public virtual OricFileInfo[] ReadDirectory(String diskPathname)
        {
            OricFileInfo[] files = new OricFileInfo[0];
            return files;
        }

        #region Disk functions
        private DOSFormats GetDOSFormat(Byte track, Byte sector, ref DOSVersions version, Byte offset)
        {
            DOSFormats format = DOSFormats.Unknown;

            Byte[] sectorData = ReadSector(track, sector);

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

            Byte[] dosFormat = new Byte[8];
            dosFormat = binaryReader.ReadBytes(8);

            String dosFormatString = AsciiEncoder.GetString(dosFormat).Trim();

            if (dosFormatString.Equals("SEDORIC"))
            {
                format = DOSFormats.SedOric;

                // Now get the version string
                dosFormat = binaryReader.ReadBytes(6);

                char[] delimiters = new char[3];
                delimiters[0] = '\r';
                delimiters[1] = '\n';
                delimiters[2] = ' ';

                String dosVersionString = AsciiEncoder.GetString(dosFormat).Trim(delimiters);

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
            format = DOSFormats.Unknown;
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
                                Byte[] DosID = ReadSector(20, 1);

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
        
        private Boolean ValidateDisk()
        {
            FileStream diskFile = new FileStream(diskPathname, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader binaryReader = new BinaryReader(diskFile);

            // Read the disk identifier (first 9 bytes)
            Byte[] diskID = new Byte[8];
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

            noOfSides = 0;
            tracksPerSide = 0;
            sectorsPerTrack = 0;
            noOfFiles = 0;
        }

        private Boolean LoadDiskIntoMemory()
        {
            try
            {
                diskBuffer = File.ReadAllBytes(diskPathname);
            }
            catch (FileNotFoundException ex)
            {
                String strMessage = ex.Message;
                return false;
            }
            catch (IOException ex)
            {
                String strMessage = ex.Message;
                return false;
            }

            return true;
        }

        public Boolean LoadDisk(String diskPathname)
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
                noOfFiles = 10;
            }

            return true;
        }

        public Boolean WriteDisk()
        {
            try
            {
                File.WriteAllBytes(diskPathname, diskBuffer);

                // Reset the modified flag
                diskModified = false;
            }
            catch (FileNotFoundException ex)
            {
                String message = ex.Message;
                return false;
            }

            return true;
        }
        #endregion

        #region Disk Sector functions
        public int CalculateNoOfSectors()
        {
            int noOfSectors = 0;

            Byte currTrack = 0;
            Byte currSide = 0;
            Byte currSector = 0;
            Byte sectorSize = 0;

            Boolean markerFound = false;
            Boolean endOfDisk = false;

            sectorPointers = new Hashtable();

            // Set buffer index to start of first track
            UInt32 bufferIndex = 0x0100;

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
                    catch (IndexOutOfRangeException ex)
                    {
                        String messageText = ex.Message;

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
                    String sectorKey = String.Format("{0:D2}{1:D2}{2:D2}", currSide, currTrack, currSector);

                    // Put sector data into the hashtable
                    if (!sectorPointers.ContainsKey(sectorKey))
                    {
                        String sectoryInfo = String.Format("{0},{1}", sectorSize, bufferIndex);
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
                    catch (IndexOutOfRangeException ex)
                    {
                        String messageText = ex.Message;

                        Console.WriteLine("> Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return 0;
                    }
                }
            }

            return noOfSectors;
        }

        private Boolean GenerateSectorIndexes()
        {
            Byte currTrack = 0;
            Byte currSide = 0;
            Byte currSector = 0;
            Byte sectorSize = 0;

            Boolean markerFound = false;
            Boolean endOfDisk = false;

            sectorPointers = new Hashtable();

            // Set buffer index to start of first track
            UInt32 bufferIndex = 0x0100;

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
                    catch (IndexOutOfRangeException ex)
                    {
                        String messageText = ex.Message;

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
                    String sectorKey = String.Format("{0:D2}{1:D2}{2:D2}", currSide, currTrack, currSector);

                    // Put sector data into the hashtable
                    if (!sectorPointers.ContainsKey(sectorKey))
                    {
                        //swLogfile.WriteLine("Creating sector key : {0}, Index {1}", sectorKey, bufferIndex);

                        String sectoryInfo = String.Format("{0},{1}", sectorSize, bufferIndex);
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
                    catch (IndexOutOfRangeException ex)
                    {
                        String messageText = ex.Message;

                        Console.WriteLine("> Index out of range error (Disk : {0}, Index: {1})", diskFilename, bufferIndex);
                        return false;
                    }
                }
            }

            return true;
        }

        public String CreateKey(UInt16 track, UInt16 sector)
        {
            // Set the default side
            UInt16 side = 0;

            if ((track & 0x80) == 0x80)
            {
                track = (UInt16)(track & 0x7F);
                side = 1;
            }

            return String.Format("{0:D2}{1:D2}{2:D2}", side, track, sector);
        }
        
        public Byte[] ReadSector(UInt16 track, UInt16 sector, ref UInt16 nextTrack, ref UInt16 nextSector)
        {
            // Create key
            String sectorKey = CreateKey(track, sector);

            Byte[] sectorData;

            if (sectorPointers.ContainsKey(sectorKey))
            {
                String[] sectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                UInt16 bufferSize = Convert.ToUInt16(sectorInfo[0]);
                UInt32 bufferIndex = Convert.ToUInt32(sectorInfo[1]);

                sectorData = new Byte[bufferSize * 256];

                // Get first two bytes which point to next sector
                nextTrack = Convert.ToUInt16(diskBuffer[bufferIndex]);
                nextSector = Convert.ToUInt16(diskBuffer[bufferIndex + 1]);

                // Copy the sector data
                for (UInt16 loop = 0; loop < bufferSize * 256; loop++)
                {
                    sectorData[loop] = diskBuffer[bufferIndex + loop];
                }
            }
            else
            {
                sectorData = new Byte[256];
                sectorData.Initialize();
            }

            return sectorData;
        }

        public Byte[] ReadSector(UInt16 track, UInt16 sector)
        {
            // Create key
            String sectorKey = CreateKey(track, sector);

            Byte[] sectorData;

            if (sectorPointers.ContainsKey(sectorKey))
            {
                String[] sectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                UInt16 bufferSize = Convert.ToUInt16(sectorInfo[0]);
                UInt32 bufferIndex = Convert.ToUInt32(sectorInfo[1]);

                sectorData = new Byte[bufferSize * 256];

                // Copy the sector data
                for (UInt16 loop = 0; loop < bufferSize * 256; loop++)
                {
                    sectorData[loop] = diskBuffer[bufferIndex + loop];
                }
            }
            else
            {
                sectorData = new Byte[256];
                sectorData.Initialize();
            }

            return sectorData;
        }

        public void WriteSector(UInt16 track, UInt16 sector, Byte[] sectorData)
        {
            String sectorKey = CreateKey(track, sector);

            if (sectorPointers.ContainsKey(sectorKey))
            {
                String[] strSectorInfo = sectorPointers[sectorKey].ToString().Split(',');

                UInt16 bufferSize = Convert.ToUInt16(strSectorInfo[0]);
                UInt32 bufferIndex = Convert.ToUInt32(strSectorInfo[1]);

                for (UInt16 loop = 0; loop < sectorData.Length; loop++)
                {
                    diskBuffer[bufferIndex + loop] = sectorData[loop];
                }
            }
        }

        public void InitialiseSector(UInt16 track, UInt16 sector)
        {
            Byte[] sectorData = ReadSector(track, sector);

            for (UInt16 loop = 0; loop < sectorData.Length; loop++)
            {
                sectorData[loop] = 0x00;
            }

            WriteSector(track, sector, sectorData);
        }
        #endregion

        #region Getters and Setters
        public Boolean DiskLoaded()
        {
            return diskLoaded;
        }

        public Boolean DiskModified()
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

        public UInt16 FileCount()
        {
            return noOfFiles;
        }
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

        public OricFileInfo[] GetDirectory(String filter)
        {
            OricFileInfo fileInfo = new OricFileInfo();
            fileInfo.Name = "DISKNAME";

            OricFileInfo[] fileList = new OricFileInfo[10];

            return fileList;
        }

        public StringBuilder OutputDiskSectors(String diskPathname)
        {
            StringBuilder sectorList = new StringBuilder();

            foreach (DictionaryEntry entry in sectorPointers)
            {
                UInt16 side = Convert.ToUInt16(entry.Key.ToString().Substring(0, 2));
                UInt16 track = Convert.ToUInt16(entry.Key.ToString().Substring(2, 2));
                UInt16 sector = Convert.ToUInt16(entry.Key.ToString().Substring(4, 2));

                Byte[] sectorData = ReadSector(track, sector);

                sectorList.AppendFormat("      Side : {0}, Track : {1}, Sector : {2}", side, track, sector);
                sectorList.AppendLine();

                int count = 0;
                String ascii = "";

                for (int index = 0; index < sectorData.Length; index++)
                {
                    if (count == 0)
                    {
                        ascii = "";
                        sectorList.AppendFormat("${0:X4}|", index);
                    }

                    sectorList.AppendFormat("{0:X2} ", sectorData[index]);

                    if (sectorData[index] >= 32 && sectorData[index] <= 127)
                    {
                        ascii += Convert.ToChar(sectorData[index]);
                    }
                    else
                    {
                        ascii += ".";
                    }

                    count++;

                    if (count == 16)
                    {
                        sectorList.Append(ascii);
                        sectorList.AppendLine();
                        count = 0;
                    }
                }

                sectorList.AppendLine();
            }

            return sectorList;
        }
        #endregion
    }
}
