namespace SupReSyncTool
{
    public class ParseUseBinaryReader : BinaryReader
    {
        public ParseUseBinaryReader(Stream stream) : base(stream)
        {
        }

        public ParseUseBinaryReader(byte[] data) : base(new MemoryStream(data))
        {
        }

        public ushort ReadTwoBytes()
        {
            byte[] buffer = base.ReadBytes(2);

            if (buffer.Length < 2)
            {
                return 0;
            }

            return (ushort)((buffer[0] << 8) + buffer[1]);
        }

        public uint ReadThreeBytes()
        {
            byte[] buffer = base.ReadBytes(3);

            if (buffer.Length < 3)
            {
                return 0;
            }

            return (uint)((buffer[0] << 16) + (buffer[1] << 8) + buffer[2]);
        }

        public uint ReadFourBytes()
        {
            byte[] buffer = base.ReadBytes(4);

            if (buffer.Length < 4)
            {
                return 0;
            }

            return (uint)((buffer[0] << 24) + (buffer[1] << 16) + (buffer[2] << 8) + (buffer[3]));
        }

        public bool Back(int Count = 1)
        {
            if (!BaseStream.CanSeek)
            {
                return false;
            }

            if (BaseStream.Position <= Count)
            {
                BaseStream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                BaseStream.Seek(Count * -1, SeekOrigin.Current);
            }

            return true;
        }

        public byte[] ReadBytes(ushort count)
        {
            var buf = new byte[count];
            BaseStream.Read(buf, 0, count);
            return buf;
        }

        public bool Forward(int Count = 1)
        {
            if (!BaseStream.CanSeek)
            {
                return false;
            }

            if (BaseStream.Position + Count >= BaseStream.Length)
            {
                BaseStream.Seek(0, SeekOrigin.End);
            }
            else
            {
                BaseStream.Seek(Count, SeekOrigin.Current);
            }
            return true;
        }

        public bool Goto(long pos)
        {
            if (!BaseStream.CanSeek)
            {
                return false;
            }
            if (pos > BaseStream.Length)
            {
                pos = BaseStream.Length;
            }
            else if (pos < 0)
            {
                pos = 0;
            }

            BaseStream.Seek(pos, SeekOrigin.Begin);
            return true;
        }

        public long GetPos()
        {
            if (!BaseStream.CanSeek)
            {
                throw new NotSupportedException("the stream is not support seek");
            }

            return BaseStream.Position;
        }

        public bool EOF => BaseStream.Position == BaseStream.Length;
    }
}
