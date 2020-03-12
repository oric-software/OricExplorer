namespace OricExplorer
{
    using System;
    using System.IO;

    public class RomInfo
    {
        public RomInfo(string fullName)
        {
            this.FullName = fullName;
            
            FileInfo fileInfo = new FileInfo(fullName);
            this.Length = (ushort)fileInfo.Length;

            // Get file timestamps
            this.CreationTime = fileInfo.CreationTime;
            this.AccessedTime = fileInfo.LastAccessTime;
            this.WrittenTime = fileInfo.LastWriteTime;
        }

        public string FullName { get; set; } = "";

        public ushort Length { get; set; } = 0;

        public DateTime CreationTime { get; set; }

        public DateTime AccessedTime { get; set; }

        public DateTime WrittenTime { get; set; }
    }
}
