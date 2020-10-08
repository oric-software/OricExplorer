namespace OricExplorer
{
    using System;
    using System.IO;

    public class OricDiskInfo
    {
        readonly OricDisk oricDisk;

        public ushort nextAvailableTrack = 0;
        public ushort nextAvailableSector = 0;

        ushort[] diskSectorMap = null;

        public OricDiskInfo(string diskPathName)
        {
            FullName = diskPathName;

            oricDisk = new OricDisk();
            oricDisk.LoadDisk(FullName);

            DOSFormat = oricDisk.DOSFormat();
            DOSVersion = oricDisk.DOSVersion();

            switch (DOSFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        oricDisc.GetDiskInfo(FullName);

                        nextAvailableSector = (ushort)oricDisc.nextAvailableSector;
                        nextAvailableTrack = (ushort)oricDisc.nextAvailableTrack;

                        DiskName = oricDisc.diskName;
                        DiskType = oricDisc.diskType;

                        Sectors = oricDisc.sectors;
                        SectorsFree = oricDisc.sectorsFree;
                        SectorsUsed = oricDisc.sectorsUsed;

                        Sides = oricDisc.sides;
                        TracksPerSide = oricDisc.tracksPerSide;
                        SectorsPerTrack = oricDisc.sectorsPerTrack;

                        FileCount = oricDisc.fileCount;
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(FullName);

                        DiskName = oricDisc.diskName;
                        DiskType = oricDisc.diskType;

                        Sectors = oricDisc.sectors;
                        SectorsFree = oricDisc.sectorsFree;
                        SectorsUsed = oricDisc.sectorsUsed;

                        Sides = oricDisc.sides;
                        TracksPerSide = oricDisc.tracksPerSide;
                        SectorsPerTrack = oricDisc.sectorsPerTrack;

                        FileCount = oricDisc.noOfFiles;
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(FullName);

                        DiskName = oricDisc.diskName;
                        DiskType = oricDisc.diskType;

                        Sectors = oricDisc.sectors;
                        SectorsFree = oricDisc.sectorsFree;
                        SectorsUsed = oricDisc.sectorsUsed;

                        Sides = oricDisc.sides;
                        TracksPerSide = oricDisc.tracksPerSide;
                        SectorsPerTrack = oricDisc.sectorsPerTrack;

                        FileCount = oricDisc.noOfFiles;
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        oricDisc.GetDiskInfo(FullName);

                        DiskName = oricDisc.diskName;
                        DiskType = oricDisc.diskType;

                        Sectors = oricDisc.sectors;
                        SectorsFree = oricDisc.sectorsFree;
                        SectorsUsed = oricDisc.sectorsUsed;

                        Sides = oricDisc.sides;
                        TracksPerSide = oricDisc.tracksPerSide;
                        SectorsPerTrack = oricDisc.sectorsPerTrack;

                        FileCount = oricDisc.noOfFiles;
                    }
                    break;

                default:
                    break;
            }

            if (this.GetFiles() == null)
            {
                DOSFormat = OricDisk.DOSFormats.Unknown;
            }

            CreationTime = File.GetCreationTime(diskPathName);
            LastAccessTime = File.GetLastAccessTime(diskPathName);
            LastWriteTime = File.GetLastWriteTime(diskPathName);
        }

        #region Methods
        public byte[] ReadSector(byte track, byte sector)
        {
            // Load the disk into memory
            OricDisk oricDisk = new OricDisk();
            oricDisk.LoadDisk(FullName);

            // Read the requested sector
            byte[] sectorData = oricDisk.ReadSector(track, sector);

            // Return the sector data
            return sectorData;
        }

        public bool DeleteFile(string diskName, string filename)
        {
            bool fileDeleted = false;

            switch (DOSFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        //files = oricDisc.ReadDirectory(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        fileDeleted = oricDisc.DeleteFile(diskName, filename);
                    }
                    break;

                default:
                    break;
            }

            return fileDeleted;
        }

        public OricFileInfo[] GetFiles()
        {
            OricFileInfo[] files;

            switch (DOSFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        files = oricDisc.ReadDirectory(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        files = oricDisc.ReadDirectory(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        StratSed oricDisc = new StratSed();
                        files = oricDisc.ReadDirectory(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        files = oricDisc.ReadDirectory(FullName);
                    }
                    break;

                default:
                    files = new OricFileInfo[0];
                    break;
            }

            return files;
        }

        public void UpdateFullName(string fullName)
        {
            this.FullName = fullName;
        }
        #endregion

        public ushort GetSectorInfo(byte track, byte sector)
        {
            ushort sectorInfo = 0xFFFF;

            if (diskSectorMap != null)
            {
                ushort index = GetSectorIndex(track, sector);
                sectorInfo = diskSectorMap[index];
            }

            return sectorInfo;
        }

        public ushort GetSectorInfo(ushort index)
        {
            ushort sectorInfo = 0xFFFF;

            if (diskSectorMap != null)
            {
                sectorInfo = diskSectorMap[index];
            }

            return sectorInfo;
        }

        private ushort GetSectorIndex(byte track, byte sector)
        {
            ushort index;

            if ((track & 0x80) == 0x80)
            {
                track = (byte)(track & 0x7F);
                track += (byte)TracksPerSide;
            }

            index = (ushort)((track * SectorsPerTrack) + (sector - 1));

            return index;
        }

        public void BuildSectorMap()
        {
            switch (DOSFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        oricDisc.GetDiskInfo(FullName);

                        diskSectorMap = oricDisc.BuildSectorMap(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(FullName);

                        diskSectorMap = oricDisc.BuildSectorMap(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        StratSed oricDisc = new StratSed();
                        oricDisc.GetDiskInfo(FullName);

                        diskSectorMap = oricDisc.BuildSectorMap(FullName);
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        oricDisc.GetDiskInfo(FullName);

                        diskSectorMap = oricDisc.BuildSectorMap(FullName);
                    }
                    break;

                default:
                    break;
            }
        }

        #region Properties
        public string DosVersion()
        {
            string versionString;

            if (DOSVersion != OricDisk.DOSVersions.Unknown)
            {
                int versPosition = DOSVersion.ToString().IndexOf('V');
                versionString = DOSVersion.ToString().Substring(versPosition).Replace('_', '.');
            }
            else
            {
                versionString = OricDisk.DOSVersions.Unknown.ToString();
            }

            return versionString;
        }

        public string FullName { get; private set; } = "";

        public OricDisk.DOSFormats DOSFormat { get; private set; } = OricDisk.DOSFormats.Unknown;

        public OricDisk.DOSVersions DOSVersion { get; private set; } = OricDisk.DOSVersions.Unknown;

        public OricDisk.DiskTypes DiskType { get; private set; } = OricDisk.DiskTypes.Unknown;

        public string DiskName { get; private set; } = "";

        public bool Exists { get; private set; } = false;

        public ushort FileCount { get; private set; } = 0;

        public ushort Sides { get; private set; } = 0;

        public ushort Tracks { get; private set; } = 0;

        public ushort Sectors { get; private set; } = 0;

        public ushort TracksPerSide { get; private set; } = 0;

        public ushort SectorsPerTrack { get; private set; } = 0;

        public ushort SectorsFree { get; private set; } = 0;

        public ushort SectorsUsed { get; private set; } = 0;

        public DateTime CreationTime { get; private set; } = DateTime.Now;

        public DateTime LastAccessTime { get; private set; } = DateTime.Now;

        public DateTime LastWriteTime { get; private set; } = DateTime.Now;

        #endregion
    }
}
