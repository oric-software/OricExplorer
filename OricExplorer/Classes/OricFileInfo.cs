namespace OricExplorer
{
    using System;
    using System.Collections;
    using System.IO;

    public class OricFileInfo
    {
        public OricProgram LoadFile()
        {
            OricProgram oricProgram = new OricProgram();
            oricProgram.New();

            if (MediaType == ConstantsAndEnums.MediaType.TapeFile)
            {
                OricTape oricTape = new OricTape();
                oricProgram = oricTape.Load(Path.Combine(Folder, ParentName), ProgramName, ProgramIndex);
            }
            else
            {
                OricDisk oricDisk = new OricDisk();
                oricDisk.LoadDisk(ParentName);

                switch (oricDisk.DOSFormat())
                {
                    case OricDisk.DOSFormats.OricDOS:
                        {
                            OricDos oricDisc = new OricDos();
                            oricProgram = oricDisc.LoadFile(ParentName, this);
                        }
                        break;

                    case OricDisk.DOSFormats.SedOric:
                        {
                            SedOric oricDisc = new SedOric();
                            oricProgram = oricDisc.LoadFile(ParentName, this);
                        }
                        break;

                    case OricDisk.DOSFormats.StratSed:
                        {
                            StratSed oricDisc = new StratSed();
                            oricProgram = oricDisc.LoadFile(ParentName, this);
                        }
                        break;

                    case OricDisk.DOSFormats.TDOS:
                        {
                            FTDos oricDisc = new FTDos();
                            oricProgram = oricDisc.LoadFile(ParentName, this);
                        }
                        break;

                    default:
                        break;
                }
            }

            return oricProgram;
        }

        //public ArrayList GetSectorList()
        //{
        //    ArrayList sectorList = new ArrayList();

        //    return sectorList;
        //}

        #region Getters and Setters 
        public ConstantsAndEnums.MediaType MediaType { get; set; }

        public ushort DirectoryIndex { get; set; }

        public ushort EntryIndex { get; set; }

        public ushort StartAddress { get; set; }

        public ushort EndAddress { get; set; }

        public ushort ExeAddress { get; set; }

        public ushort LengthBytes
        {
            get {return Convert.ToUInt16((EndAddress - StartAddress) + 1);}
        }

        public ushort LengthSectors { get; set; }

        public OricProgram.AutoRunFlag AutoRun { get; set; }

        public OricProgram.ProgramFormat Format { get; set; }

        public byte DirTrack { get; set; }
        public byte DirSector { get; set; }
        public byte DirIndex { get; set; }

        // For SEDORIC Direct Access files (Filetype = 8)
        public ushort NoOfRecords { get; set; }
        public ushort RecordLength { get; set; }

        public string FormatToString()
        {
            string strFormat;

            switch(Format)
            {
                case OricProgram.ProgramFormat.AtmosBasicProgram:
                    strFormat = "BASIC program";
                    break;

                case OricProgram.ProgramFormat.HyperbasicSource:
                    strFormat = "HYPERBASIC source";
                    break;

                case OricProgram.ProgramFormat.TeleassSource:
                    strFormat = "TELEASS source";
                    break;
                
                case OricProgram.ProgramFormat.CharacterSet:
                    strFormat = "Character set";
                    break;

                case OricProgram.ProgramFormat.BinaryFile:
                    strFormat = "Code/Data file";
                    break;

                case OricProgram.ProgramFormat.DirectAccessFile:
                    strFormat = "Direct Access file";
                    break;

                case OricProgram.ProgramFormat.SequentialFile:
                    strFormat = "Sequential file";
                    break;

                case OricProgram.ProgramFormat.HiresScreen:
                    strFormat = "HIRES screen";
                    break;

                case OricProgram.ProgramFormat.TextScreen:
                    strFormat = "TEXT screen";
                    break;

                case OricProgram.ProgramFormat.WindowFile:
                    strFormat = "Text window";
                    break;

                case OricProgram.ProgramFormat.HelpFile:
                    strFormat = "Help file";
                    break;

                default:
                    strFormat = "Unknown format";
                    break;
            }

            return strFormat;
        }

        public string ProgramName { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Folder { get; set; }

        public string ParentName { get; set; }

        public OricProgram.ProtectionStatus Protection { get; set; }

        public ushort ProgramIndex { get; set; }

        public byte FirstSector { get; set; }

        public byte FirstTrack { get; set; }

        public byte LastSector { get; set; }

        public byte LastTrack { get; set; }
        #endregion
    }
}
