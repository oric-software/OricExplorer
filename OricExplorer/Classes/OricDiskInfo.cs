using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OricExplorer
{
    public class OricDiskInfo
    {
        /**
         * A Class to return information about an Oric Disk (.dsk) such as disk name,
         * DOS Format, No of Sides etc.
         **/

        OricDisk.DOSFormats dosFormat = OricDisk.DOSFormats.Unknown;
        OricDisk.DOSVersions dosVersion = OricDisk.DOSVersions.Unknown;

        OricDisk.DiskTypes diskType = OricDisk.DiskTypes.Unknown;

        DateTime creationTime = DateTime.Now;
        DateTime lastAccessTime = DateTime.Now;
        DateTime lastWriteTime = DateTime.Now;

        Boolean exists = false;

        String fullName = "";
        String diskName = "";

        UInt16 noOfSides = 0;
        UInt16 tracksPerSide = 0;
        UInt16 sectorsPerTrack = 0;
        UInt16 tracks = 0;
        UInt16 sectors = 0;
        UInt16 freeSectors = 0;
        UInt16 usedSectors = 0;
        UInt16 fileCount = 0;

        public UInt16 nextAvailableTrack = 0;
        public UInt16 nextAvailableSector = 0;

        UInt16[] diskSectorMap = null;

        OricDisk oricDisk;

        public OricDiskInfo(String diskPathName)
        {
            fullName = diskPathName;

            oricDisk = new OricDisk();
            oricDisk.LoadDisk(fullName);

            dosFormat = oricDisk.DOSFormat();
            dosVersion = oricDisk.DOSVersion();

            switch (dosFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        oricDisc.GetDiskInfo(fullName);

                        nextAvailableSector = (ushort)oricDisc.nextAvailableSector;
                        nextAvailableTrack = (ushort)oricDisc.nextAvailableTrack;

                        diskName = oricDisc.diskName;
                        diskType = oricDisc.diskType;

                        sectors = oricDisc.sectors;
                        freeSectors = oricDisc.sectorsFree;
                        usedSectors = oricDisc.sectorsUsed;

                        noOfSides = oricDisc.sides;
                        tracksPerSide = oricDisc.tracksPerSide;
                        sectorsPerTrack = oricDisc.sectorsPerTrack;

                        fileCount = oricDisc.fileCount;
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(fullName);

                        diskName = oricDisc.diskName;
                        diskType = oricDisc.diskType;

                        sectors = oricDisc.sectors;
                        freeSectors = oricDisc.sectorsFree;
                        usedSectors = oricDisc.sectorsUsed;

                        noOfSides = oricDisc.sides;
                        tracksPerSide = oricDisc.tracksPerSide;
                        sectorsPerTrack = oricDisc.sectorsPerTrack;

                        fileCount = oricDisc.noOfFiles;
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(fullName);

                        diskName = oricDisc.diskName;
                        diskType = oricDisc.diskType;

                        sectors = oricDisc.sectors;
                        freeSectors = oricDisc.sectorsFree;
                        usedSectors = oricDisc.sectorsUsed;

                        noOfSides = oricDisc.sides;
                        tracksPerSide = oricDisc.tracksPerSide;
                        sectorsPerTrack = oricDisc.sectorsPerTrack;

                        fileCount = oricDisc.noOfFiles;
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        oricDisc.GetDiskInfo(fullName);

                        diskName = oricDisc.diskName;
                        diskType = oricDisc.diskType;

                        sectors = oricDisc.sectors;
                        freeSectors = oricDisc.sectorsFree;
                        usedSectors = oricDisc.sectorsUsed;

                        noOfSides = oricDisc.sides;
                        tracksPerSide = oricDisc.tracksPerSide;
                        sectorsPerTrack = oricDisc.sectorsPerTrack;

                        fileCount = oricDisc.noOfFiles;
                    }
                    break;

                default:
                    break;
            }

            creationTime = File.GetCreationTime(diskPathName);
            lastAccessTime = File.GetLastAccessTime(diskPathName);
            lastWriteTime = File.GetLastWriteTime(diskPathName);
        }

        #region Methods
        public Byte[] ReadSector(Byte track, Byte sector)
        {
            // Load the disk into memory
            OricDisk oricDisk = new OricDisk();
            oricDisk.LoadDisk(fullName);

            // Read the requested sector
            Byte[] sectorData = oricDisk.ReadSector(track, sector);

            // Return the sector data
            return sectorData;
        }

        public Boolean DeleteFile(String diskName, String filename)
        {
            Boolean fileDeleted = false;

            switch (dosFormat)
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
            OricFileInfo[] files = null;

            switch (dosFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        files = oricDisc.ReadDirectory(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        files = oricDisc.ReadDirectory(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        StratSed oricDisc = new StratSed();
                        files = oricDisc.ReadDirectory(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        files = oricDisc.ReadDirectory(fullName);
                    }
                    break;

                default:
                    files = new OricFileInfo[0];
                    break;
            }

            return files;
        }
        #endregion

        public UInt16 GetSectorInfo(Byte track, Byte sector)
        {
            UInt16 sectorInfo = 0xFFFF;

            if (diskSectorMap != null)
            {
                UInt16 index = getSectorIndex(track, sector);
                sectorInfo = diskSectorMap[index];
            }

            return sectorInfo;
        }

        public UInt16 GetSectorInfo(UInt16 index)
        {
            UInt16 sectorInfo = 0xFFFF;

            if (diskSectorMap != null)
            {
                sectorInfo = diskSectorMap[index];
            }

            return sectorInfo;
        }

        private UInt16 getSectorIndex(Byte track, Byte sector)
        {
            UInt16 index = 0;

            if ((track & 0x80) == 0x80)
            {
                track = (Byte)(track & 0x7F);
                track += (Byte)tracksPerSide;
            }

            index = (UInt16)((track * sectorsPerTrack) + (sector - 1));

            return index;
        }

        public void BuildSectorMap()
        {
            switch (dosFormat)
            {
                case OricDisk.DOSFormats.OricDOS:
                    {
                        OricDos oricDisc = new OricDos();
                        oricDisc.GetDiskInfo(fullName);

                        diskSectorMap = oricDisc.BuildSectorMap(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.SedOric:
                    {
                        SedOric oricDisc = new SedOric();
                        oricDisc.GetDiskInfo(fullName);

                        diskSectorMap = oricDisc.BuildSectorMap(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.StratSed:
                    {
                        StratSed oricDisc = new StratSed();
                        oricDisc.GetDiskInfo(fullName);

                        diskSectorMap = oricDisc.BuildSectorMap(fullName);
                    }
                    break;

                case OricDisk.DOSFormats.TDOS:
                    {
                        FTDos oricDisc = new FTDos();
                        oricDisc.GetDiskInfo(fullName);

                        diskSectorMap = oricDisc.BuildSectorMap(fullName);
                    }
                    break;

                default:
                    break;
            }
        }

        #region Properties
        public String DosVersion()
        {
            String versionString = "";

            if (dosVersion != OricDisk.DOSVersions.Unknown)
            {
                int versPosition = dosVersion.ToString().IndexOf('V');
                versionString = dosVersion.ToString().Substring(versPosition).Replace('_', '.');
            }
            else
            {
                versionString = OricDisk.DOSVersions.Unknown.ToString();
            }

            return versionString;
        }

        public OricDisk.DOSFormats DOSFormat
        {
            get { return dosFormat; }
        }

        public OricDisk.DOSVersions DOSVersion
        {
            get { return dosVersion; }
        }

        public OricDisk.DiskTypes DiskType
        {
            get { return diskType; }
        }

        public DateTime CreationTime
        {
            get { return creationTime; }
        }

        public DateTime LastAccessTime
        {
            get { return lastAccessTime; }
        }

        public DateTime LastWriteTime
        {
            get { return lastWriteTime; }
        }

        public String FullName
        {
            get { return fullName; }
        }

        public String DiskName
        {
            get { return diskName; }
        }

        public Boolean Exists
        {
            get { return exists; }
        }

        public UInt16 FileCount
        {
            get { return fileCount; }
        }

        public UInt16 Sides
        {
            get { return noOfSides; }
        }

        public UInt16 Tracks
        {
            get { return tracks; }
        }

        public UInt16 Sectors
        {
            get { return sectors; }
        }

        public UInt16 TracksPerSide
        {
            get { return tracksPerSide; }
        }

        public UInt16 SectorsPerTrack
        {
            get { return sectorsPerTrack; }
        }

        public UInt16 SectorsFree
        {
            get { return freeSectors; }
        }

        public UInt16 SectorsUsed
        {
            get { return usedSectors; }
        }

        #endregion
    }
}
