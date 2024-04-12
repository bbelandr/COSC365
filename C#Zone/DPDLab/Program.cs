using System.Buffers.Binary;
interface ICompValue : System.IComparable {
    //  CompareTo(object)
    // Needs to:
    // return -1 if this.Val < object.Val (object typecasted into ICompValue)
    // return 0 if this.Val == object.Val (object typecasted into ICompValue)
    // return 1 if this.Val > object.Val

    // Raw property (gets/sets the RAW DPD or BCD)
    uint Raw { get; set; }
    // Decoded property (gets the actual number)
    uint Val { get; }
}


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
        BCD myBCD = new BCD();


        if (br.ReadBoolean() == true) {
            // Handle DPD
        }
        else {
            // Handle BCD
            myBCD.Raw = BinaryPrimitives.ReverseEndianness(br.ReadUInt32());

            // Console.WriteLine(Convert.ToString(myBCD.Val, 2));
            Console.WriteLine(myBCD.Val);
        }

    }
}