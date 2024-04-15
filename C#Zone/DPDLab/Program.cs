using System.Buffers.Binary;


class Program {
    public static void Main(string[] args) {
        // Check the commandline arguments
        if (args.Length != 1) {
            Console.WriteLine("Incorrect amount of command line args");
            return;
        }
        
        // Opening the file
        // byte[] myBytes = File.ReadAllBytes("bcd.2000"); // Maybe want a try catch statement here
        BinaryReader br;

        try {
            br = new BinaryReader(new FileStream(args[0], FileMode.Open));
        }
        catch (IOException e) {
            Console.WriteLine(e.Message + "\n Can't open the file");
            return;
        } 
        List<BCDDecoderBase> FileVals = new List<BCDDecoderBase>(); // Holds all the BCD and DPD information

        while (br.BaseStream.Position != br.BaseStream.Length) {
            if (br.ReadBoolean() == true) {
                // Handle DPD
                DPD myDPD = new DPD();
                myDPD.Raw = BinaryPrimitives.ReverseEndianness(br.ReadUInt32());

                // Console.WriteLine(Convert.ToString(myDPD.Val, 2));
                // Console.WriteLine(myDPD.Val);
                FileVals.Add(myDPD);
            }
            else {
                // Handle BCD
                BCD myBCD = new BCD();
                myBCD.Raw = BinaryPrimitives.ReverseEndianness(br.ReadUInt32());

                // Console.WriteLine(Convert.ToString(myBCD.Val, 2));
                // Console.WriteLine(myBCD.Val);
                FileVals.Add(myBCD);
            }
        
        }
        FileVals.Sort();
        // Console.WriteLine(val.Val);
        string fileName = args[0] + ".txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (BCDDecoderBase val in FileVals)
            {
                writer.WriteLine(val.Val);
            }
        }
        Console.WriteLine("Values written to " + fileName);

    }
}