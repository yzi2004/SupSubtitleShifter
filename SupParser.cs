namespace SupReSyncTool
{
    internal class SupParser
    {

        public SupParser()
        {
        }

        public void SyncTimeLine(string fileName, int delay)
        {
            try
            {
                var delayTicks = delay * 90F;

                string newFileName = fileName.Replace(".sup", "_resync.sup", StringComparison.OrdinalIgnoreCase);
                using (ParseUseBinaryWriter pbw = new ParseUseBinaryWriter(newFileName))
                {
                    using (ParseUseBinaryReader pbr = new ParseUseBinaryReader(new FileStream(fileName, FileMode.Open)))
                    {
                        while (!pbr.EOF)
                        {
                            var pg = pbr.ReadBytes(2);
                            if (pg.Length < 2)
                            {
                                pbw.write(pg);
                                continue;
                            }
                            if (pg[0] != 0x50 || pg[1] != 0x47)
                            {
                                pbr.Back();
                                pbw.write(pg[0]);
                                continue;
                            }

                            pbw.Write(pg);

                            var segment = Read(pbr);

                            if (segment != null)
                            {
                                if (delayTicks > 0)
                                {
                                    segment.PTS += (uint)delayTicks;
                                }
                                else if (delayTicks < 0)
                                {
                                    segment.PTS -= (uint)(delayTicks * -1);
                                }
                                Write(pbw, segment);
                            }
                        }
                        pbr.Close();
                        pbw.Close();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("oh,nooop.....");

            }
        }

        private Segment Read(ParseUseBinaryReader reader)
        {
            Segment seg = new Segment();
            seg.PTS = reader.ReadFourBytes();
            seg.DTS = reader.ReadFourBytes();
            seg.segType = reader.ReadByte();
            seg.DataSize = reader.ReadTwoBytes();
            seg.Data = reader.ReadBytes(seg.DataSize);
            return seg;
        }

        private void Write(ParseUseBinaryWriter writer, Segment seg)
        {
            writer.Write(seg.PTS);
            writer.Write(seg.DTS);
            writer.Write(seg.segType);
            writer.Write(seg.DataSize);
            writer.Write(seg.Data);
        }
    }
}
