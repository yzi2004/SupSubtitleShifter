using System.Text;

namespace SupReSyncTool
{
    internal class ParseUseBinaryWriter : BinaryWriter
    {
        public ParseUseBinaryWriter(Stream stream) : base(stream) { }

        public ParseUseBinaryWriter(string fileName) : base(new FileStream(fileName, FileMode.OpenOrCreate))
        {

        }

        public void write(byte data)
        {
            BaseStream.WriteByte(data);
        }

        public void write(string data)
        {
            var bytData = Encoding.ASCII.GetBytes(data);
            BaseStream.Write(bytData);
        }

        public void write(byte[] data)
        {
            BaseStream.Write(data, 0, data.Length);
        }

        public void write(ushort data)
        {
            var byt = (byte)((data & 0xFF00) >> 8);
            BaseStream.WriteByte(byt);
            byt = (byte)(data & 0xFF);
            BaseStream.WriteByte(byt);
        }
        public void writeThreeByte(uint data)
        {
            var byt = (byte)((data & 0xFF0000) >> 16);
            BaseStream.WriteByte(byt);
            byt = (byte)((data & 0xFF00) >> 8);
            BaseStream.WriteByte(byt);
            byt = (byte)(data & 0xFF);
            BaseStream.WriteByte(byt);
        }
        public void write(uint data)
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
