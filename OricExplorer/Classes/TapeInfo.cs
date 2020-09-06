namespace OricExplorer
{
    using System;
    using System.IO;

    public class TapeInfo
    {
        public TapeInfo (string fullName)
        {
            this.FullName = fullName;

            FileInfo fileInfo = new FileInfo(fullName);
            this.Length = (ushort)fileInfo.Length;

            // Get file timestamps
            this.CreationTime = fileInfo.CreationTime;
            this.AccessedTime = fileInfo.LastAccessTime;
            this.WrittenTime = fileInfo.LastWriteTime;
        }

        public void UpdateFullName(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName { get; private set; } = "";

        public ushort FileCount { get; set; } = 0;

        public ushort Length { get; private set; } = 0;

        public DateTime CreationTime { get; private set; }

        public DateTime AccessedTime { get; private set; }

        public DateTime WrittenTime { get; private set; }
    }
}
