using System;
using System.Collections.Generic;
using System.Text;

namespace OricExplorer
{
    public class TapeInfo
    {
        private DateTime dtCreationTime;
        private DateTime dtAccessedTime;
        private DateTime dtWrittenTime;

        private UInt16 m_ui16FileCount = 0;
        private UInt16 m_ui16Length = 0;

        private String m_strFolder = "";
        private String m_strName = "";

        public DateTime CreationTime
        {
            get { return dtCreationTime; }
            set { dtCreationTime = value; }
        }

        public DateTime AccessedTime
        {
            get { return dtAccessedTime; }
            set { dtAccessedTime = value; }
        }

        public DateTime WrittenTime
        {
            get { return dtWrittenTime; }
            set { dtWrittenTime = value; }
        }

        public UInt16 FileCount
        {
            get { return m_ui16FileCount; }
            set { m_ui16FileCount = value; }
        }

        public UInt16 Length
        {
            get { return m_ui16Length; }
            set { m_ui16Length = value; }
        }

        public String Folder
        {
            get { return m_strFolder; }
            set { m_strFolder = value; }
        }

        public String Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }
    }
}
