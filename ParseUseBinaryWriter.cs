using System.Text;

namespace SupReSyncTool
{
    internal class ParseUseBinaryWriter : BinaryWriter
    {
        public ParseUseBinaryWriter(Stream stream) : base(stream) { }

        public ParseUseBinaryWriter(string fileName) : base(new FileStream(fileName, FileMode.OpenOrCreate))
        {

        }

        public void WriteByte(byte data)
        {
            BaseStream.WriteByte(data);
        }

        public void WriteBytes(byte[] data)
        {
            BaseStream.Write(data, 0, data.Length);
        }

        public void WriteTwoByte(ushort data)
        {
            var byt = (byte)((data & 0xFF00) >> 8);
            BaseStream.WriteByte(byt);
            byt = (byte)(data & 0xFF);
            BaseStream.WriteByte(byt);
        }
        public void WriteThreeByte(uint data)
        {
            var byt = (byte)((data & 0xFF0000) >> 16);
            BaseStream.WriteByte(byt);
            byt = (byte)((data & 0xFF00) >> 8);
            BaseStream.WriteByte(byt);
            byt = (byte)(data & 0xFF);
            BaseStream.WriteByte(byt);
        }
        public void WriteFourByte(uint data)
        {
            var byt = (byte)((data & 0xFF000000) >> 24);
            BaseStream.WriteByte(byt);
            byt = (byte)((data & 0xFF0000) >> 16);
            BaseStream.WriteByte(byt);
            byt = (byte)((data & 0xFF00) >> 8);
            BaseStream.WriteByte(byt);
            byt = (byte)(data & 0xFF);
            BaseStream.WriteByte(byt);
        }
    }
}
