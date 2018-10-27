using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace OricExplorer
{
    public class Catalog
    {
        OricExplorer.MediaType m_bMediaType;

        OricProgram.ProtectionStatus m_bProtection;
        OricProgram.ProgramFormat m_bProgramFormat;
        OricProgram.AutoRunFlag m_bAutoRun;

        private Byte m_bFirstTrack;
        private Byte m_bFirstSector;
        private Byte m_bLastTrack;
        private Byte m_bLastSector;

        public Byte m_bDirTrack;
        public Byte m_bDirSector;
        public Byte m_bDirIndex;

        private String m_strFolder;
        private String m_strParentName;
        private String m_strProgramName;
        private String m_strName;
        private String m_strExtension;

        private Int16 m_i16ProgramIndex;

        private UInt16 m_ui16DirectoryIndex;
        private UInt16 m_ui16EntryIndex;

        private UInt16 m_ui16StartAddress;
        private UInt16 m_ui16EndAddress;
        private UInt16 m_ui16ExeAddress;
        private UInt16 m_ui16LengthSectors;

        // For SEDORIC Direct Access files (Filetype = 8)
        public UInt16 m_ui16NoOfRecords;
        public UInt16 m_ui16RecordLength;

        public OricExplorer.MediaType MediaType
        {
            get { return m_bMediaType; }
            set { m_bMediaType = value; }
        }

        public UInt16 DirectoryIndex
        {
            get { return m_ui16DirectoryIndex; }
            set { m_ui16DirectoryIndex = value; }
        }

        public UInt16 EntryIndex
        {
            get { return m_ui16EntryIndex; }
            set { m_ui16EntryIndex = value; }
        }

        public UInt16 StartAddress
        {
            get {return m_ui16StartAddress;}
            set {m_ui16StartAddress = value;}
        }

        public UInt16 EndAddress
        {
            get {return m_ui16EndAddress;}
            set {m_ui16EndAddress = value;}
        }

        public UInt16 ExeAddress
        {
            get {return m_ui16ExeAddress;}
            set {m_ui16ExeAddress = value;}
        }

        public UInt16 LengthBytes
        {
            get {return Convert.ToUInt16((m_ui16EndAddress - m_ui16StartAddress) + 1);}
        }

        public UInt16 LengthSectors
        {
            get { return m_ui16LengthSectors; }
            set { m_ui16LengthSectors = value; }
        }

        public OricProgram.AutoRunFlag AutoRun
        {
            get { return m_bAutoRun; }
            set { m_bAutoRun = value; }
        }

        public OricProgram.ProgramFormat Format
        {
            get { return m_bProgramFormat; }
            set { m_bProgramFormat = value; }
        }

        public String FormatToString()
        {
            String strFormat;

            switch(m_bProgramFormat)
            {
                case OricProgram.ProgramFormat.BasicProgram:
                    strFormat = "BASIC program";
                    break;

                case OricProgram.ProgramFormat.CharacterSet:
                    strFormat = "Character set";
                    break;

                case OricProgram.ProgramFormat.CodeFile:
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

        public String ProgramName
        {
            get { return m_strProgramName; }
            set { m_strProgramName = value; }
        }

        public String Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        public String Extension
        {
            get { return m_strExtension; }
            set { m_strExtension = value; }
        }

        public String Folder
        {
            get { return m_strFolder; }
            set { m_strFolder = value; }
        }

        public String ParentName
        {
            get { return m_strParentName; }
            set { m_strParentName = value; }
        }

        public OricProgram.ProtectionStatus Protection
        {
            get { return m_bProtection; }
            set { m_bProtection = value; }
        }

        public Int16 ProgramIndex
        {
            get { return m_i16ProgramIndex; }
            set { m_i16ProgramIndex = value; }
        }

        public Byte FirstSector
        {
            get { return m_bFirstSector; }
            set { m_bFirstSector = value; }
        }

        public Byte FirstTrack
        {
            get { return m_bFirstTrack; }
            set { m_bFirstTrack = value; }
        }

        public Byte LastSector
        {
            get { return m_bLastSector; }
            set { m_bLastSector = value; }
        }

        public Byte LastTrack
        {
            get { return m_bLastTrack; }
            set { m_bLastTrack = value; }
        }
    }
}
