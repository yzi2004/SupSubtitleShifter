using SupReSyncTool;

if (args.Length < 2)
{
    Console.WriteLine("Usage: SupReSyncTool input_file delaytime");
    Console.WriteLine("  delaytime: delay time in second with three decimal number under point.");
    Console.WriteLine("             minus value for display early. ");
    Console.WriteLine();
    return;
}

string supFile = args[0];
if (!float.TryParse(args[1], out var delay))
{
    Console.WriteLine("delay time can't be known. it must be like 9.999 or -9.999.");
    return;
}


SupParser supParser = new SupParser();

supParser.SyncTimeLine(supFile, (int)(delay * 1000));
