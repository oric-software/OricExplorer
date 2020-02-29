namespace OricExplorer
{
    using System;

    public class TapeInfo
    {
        public DateTime CreationTime { get; set; }

        public DateTime AccessedTime { get; set; }

        public DateTime WrittenTime { get; set; }

        public ushort FileCount { get; set; } = 0;

        public ushort Length { get; set; } = 0;

        public string Folder { get; set; } = "";

        public string Name { get; set; } = "";
    }
}
