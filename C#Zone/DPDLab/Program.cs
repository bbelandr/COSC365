// Benjamin Belandres
// Read in a file, decode the binary information from BCD/DPD and sort it into a text file called <openedFileName>.out

// See https://aka.ms/new-console-template for more information

using System;
using System.Dynamic;
using System.Net.Http.Headers;
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

public struct ByteArray {
    private List<byte> bytes;
    public ByteArray(byte[] inBytes) {
        bytes = new List<byte>();
        foreach (byte b in inBytes) {
            bytes.Add(b);
            // bytes.Add(BinaryPrimitives.ReverseEndianness(b));
        }
    }
    public int at(int index) {
        int byteIndex = index / 8;
        int bitIndex = index % 8;
        if (byteIndex >= bytes.Count) {
            Console.WriteLine("Index out of scope");
            return -1;
        }

        // if (((1 << bitIndex) & bytes[byteIndex]) == 1) {
        //     return 1;
        // }
        // else {
        //     return 0;
        // }
        // int retval;

        // vals.Add((b & ()1 << i)) == 0 ? '0' : '1');
        int retVal = (bytes[byteIndex] & (1 << bitIndex)) == 0 ? 0 : 1;

        return retVal;
    }

    public void dumpBits() {
        foreach (byte b in bytes) {
            for (int i = 0; i < 8; i++) {
                // Console.Write()
            }
        }
    }

}


class BCDReader {
    // This starts from the rightmost bits and then moves onwards
    public int DecodeBytes(byte[] RawBytes) {  // Takes in a set of bytes to decode
        int decodedNum = 0;
        int currentPlace = 0;
        int individualNum;
        for (int i = 0; i < RawBytes.Length; i++) {
            // Get the right bits
            individualNum = RawBytes[RawBytes.Length - 1 - i] & 0b_0000_1111;
            decodedNum += individualNum * (int)Math.Pow(10, currentPlace++);
            
            // Get the left bits
            individualNum = RawBytes[RawBytes.Length - 1 - i] >> 4;
            decodedNum += individualNum * (int)Math.Pow(10, currentPlace++);
            
        }
        
        return decodedNum;
    }
}

class DPDReader {
    
    // Helper function for returning bits
    bool GetBit(byte[] bytes, int index) {
        int currentByte = index / 8;
        Console.WriteLine(currentByte);
        return false;
    }

    public int DecodeBytes(byte[] RawBytes) {
        ByteArray bytes = new ByteArray(RawBytes);
        
        for (int i = 0; i < 32; i++) {
            Console.Write(bytes.at(i) + " ");

        }
        return 5;
    }
}

class Program {
    public static void Main(string[] args) {
        // byte[] myBytes = File.ReadAllBytes("bcd.2000"); // Maybe want a try catch statement here
        BinaryReader br;

        try {
            br = new BinaryReader(new FileStream("bcd.2000", FileMode.Open));
        }
        catch (IOException e) {
            Console.WriteLine(e.Message + "\n Can't open the file");
            return;
        }
        
        BCDReader bcd = new BCDReader();
        DPDReader dpd = new DPDReader();
        bool DPDFlag;
        byte[] EncodedNum = new byte[4];
        
        DPDFlag = br.ReadBoolean();
        EncodedNum = br.ReadBytes(4);
        if (DPDFlag) {
            // Do DPD
            Console.WriteLine("I am doing DPD rn");
        }
        else {
            // Do BCD
            // Console.WriteLine(dpd.DecodeBytes(EncodedNum));
            
            Console.WriteLine(bcd.DecodeBytes(EncodedNum));
        }




    }
}