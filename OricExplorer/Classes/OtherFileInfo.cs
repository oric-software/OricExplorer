namespace OricExplorer
{
    using System;
    using System.IO;
    using System.Linq;

    public class OtherFileInfo
    {
        private readonly byte[] ORIX_SIGNATURE = new byte[] { 0x01, 0x00, 0x6f, 0x72, 0x69 };
        public const byte ORIX_HEADER_LENGTH = 20;
        private const byte ORIX_START_ADDRESS_HIGHT = 15;
        private const byte ORIX_START_ADDRESS_LOW = 14;

        public OtherFileInfo(string fullName)
        {
            this.FullName = fullName;
            
            FileInfo fileInfo = new FileInfo(fullName);
            this.Length = (ushort)fileInfo.Length;

            if (fileInfo.Length > ORIX_HEADER_LENGTH)
            {
                byte[] data = File.ReadAllBytes(fullName);
                
                // oric header?
                if (Enumerable.Range(0, 5).All(w => data[w] == ORIX_SIGNATURE[w]))
                { 
                    this.StartAddress = (ushort)((data[ORIX_START_ADDRESS_LOW] + (data[ORIX_START_ADDRESS_HIGHT] * 256)) - ORIX_HEADER_LENGTH);
                    this.Length -= ORIX_HEADER_LENGTH;
                    this.Format = OricProgram.ProgramFormat.OrixProgram;
                }

                data = null;
            }

            // Get file timestamps
            this.CreationTime = fileInfo.CreationTime;
            this.AccessedTime = fileInfo.LastAccessTime;
            this.WrittenTime = fileInfo.LastWriteTime;
        }

        public string FullName { get; set; } = "";

        public OricProgram.ProgramFormat Format { get; set; } = OricProgram.ProgramFormat.BinaryFile;

        public ushort StartAddress { get; set; } = 0;

        public ushort Length { get; set; } = 0;

        public DateTime CreationTime { get; set; }

        public DateTime AccessedTime { get; set; }

        public DateTime WrittenTime { get; set; }
    }
}
