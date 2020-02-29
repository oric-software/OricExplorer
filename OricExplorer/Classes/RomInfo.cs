namespace OricExplorer
{
    using System;

    public class RomInfo
    {
        public DateTime CreationTime { get; set; }

        public DateTime AccessedTime { get; set; }

        public DateTime WrittenTime { get; set; }

        public ushort Length { get; set; } = 0;

        public string Folder { get; set; } = "";

        public string Name { get; set; } = "";
    }
}
