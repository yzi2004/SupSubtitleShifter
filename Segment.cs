namespace SupReSyncTool
{
    internal class Segment
    {
        /// <summary>
        /// Presentation Timestamp
        /// </summary>
        public uint PTS { get; set; }

        /// <summary>
        /// Decoding Timestamp
        /// </summary>
        public uint DTS { get; set; }

        public byte segType { get; set; }

        /// <summary>
        /// Size of the segment
        /// </summary>
        public ushort DataSize { get; set; }

        public byte[] Data { get; set; }
        
    }
}
