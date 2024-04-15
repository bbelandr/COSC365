using System.Text.RegularExpressions;

class DPD : BCDDecoderBase {
    private uint _raw;  // Holds the raw bits to be converted

    private static char[][] DPDBits = {    // The 10 bit sequence from each row of the DPD column
        new char[] {'a', 'b', 'c', 'd', 'e', 'f', '0', 'g', 'h', 'i'},
        new char[] {'a', 'b', 'c', 'd', 'e', 'f', '1', '0', '0', 'i'},
        new char[] {'a', 'b', 'c', 'g', 'h', 'f', '1', '0', '1', 'i'},
        new char[] {'g', 'h', 'c', 'd', 'e', 'f', '1', '1', '0', 'i'},
        new char[] {'g', 'h', 'c', '0', '0', 'f', '1', '1', '1', 'i'},
        new char[] {'d', 'e', 'c', '0', '1', 'f', '1', '1', '1', 'i'},
        new char[] {'a', 'b', 'c', '1', '0', 'f', '1', '1', '1', 'i'},
        new char[] {'0', '0', 'c', '1', '1', 'f', '1', '1', '1', 'i'}
    };
    private static char[][] BCDBits = {    // The 12 bit sequence from each row of the BCD column
        new char[] {'0', 'a', 'b', 'c', '0', 'd', 'e', 'f', '0', 'g', 'h', 'i'},
        new char[] {'0', 'a', 'b', 'c', '0', 'd', 'e', 'f', '1', '0', '0', 'i'},
        new char[] {'0', 'a', 'b', 'c', '1', '0', '0', 'f', '0', 'g', 'h', 'i'},
        new char[] {'1', '0', '0', 'c', '0', 'd', 'e', 'f', '0', 'g', 'h', 'i'},
        new char[] {'1', '0', '0', 'c', '1', '0', '0', 'f', '0', 'g', 'h', 'i'},
        new char[] {'1', '0', '0', 'c', '0', 'd', 'e', 'f', '1', '0', '0', 'i'},
        new char[] {'0', 'a', 'b', 'c', '1', '0', '0', 'f', '1', '0', '0', 'i'}, 	
        new char[] {'1', '0', '0', 'c', '1', '0', '0', 'f', '1', '0', '0', 'i'}

    };
    

    public override uint Raw {
        get {
            return _raw;
        }
        set {
            _raw = value;
        }
    }

    public override uint Val {
        get {

            // Separate into groups
            ushort[] bitGroups = new ushort[3];    // What stores the 3 groupings of numbers
            for (int i = 0; i < 3; i++) {
                bitGroups[i] = (ushort)((_raw >> (i * 10)) & 0b_0011_1111_1111);
            }

            // Find which row of the table corresponds with the current value
            int[] rows = new int[3];    // Which row this group of bits belongs to
            for (int i = 0; i < bitGroups.Length; i++) {
                if ((bitGroups[i] & 0b_000_000_1_000) == 0) {
                    rows[i] = 1;
                    continue;
                }
                switch (bitGroups[i] & 0b_000_000_111_0) {
                    case 0b_000_000_100_0:      // Row 2
                        rows[i] = 2;
                        continue;
                    case 0b_000_000_101_0:      // Row 3
                        rows[i] = 3;
                        continue;
                    case 0b_000_000_110_0:      // Row 4
                        // Console.WriteLine("4");
                        rows[i] = 4;
                        continue;
                }
                switch (bitGroups[i] & 0b_000_11_0_111_0) {
                    case 0b_000_00_0_111_0:     // Row 5
                        rows[i] = 5;
                        continue;
                    case 0b_000_01_0_111_0:     // Row 6
                        rows[i] = 6;
                        continue;
                    case 0b_000_10_0_111_0:     // Row 7
                        rows[i] = 7;
                        continue;
                    case 0b_000_11_0_111_0:     // Row 8
                        rows[i] = 8;
                        continue;
                    default:                    // This should never happen
                        Console.WriteLine(Convert.ToString(bitGroups[i], 2) + " not recognized as DPD format");
                        rows[i] = -1;
                        break;
                }
                
            }

            // Do the conversions to BCD
            uint ConvertedBits = 0;
            int BitsIndex;
            for (int i = 0; i < bitGroups.Length; i++) {    // Iterate through the bitGroups
                char currentChar;
                for (int j = 0; j < BCDBits[i].Length; j++) {   // Iterate through the individual bits
                    currentChar = BCDBits[rows[i] - 1][BCDBits[i].Length - 1 - j];  // Written to go through backwards to easier set the BCD bits
                    if (currentChar == '0') {
                        continue;
                    }
                    if (currentChar == '1') {
                        SetBit(ref ConvertedBits, i * 12 + j);
                    }

                    // Console.Write(currentChar);
                    
                    BitsIndex = DPDBits[i].Length - 1 - Array.IndexOf(DPDBits[rows[i] - 1], currentChar); 
                    // Console.Write(BitsIndex + " ");

                    CopyBit(bitGroups[i], BitsIndex, ref ConvertedBits, i * 12 + j);
                }
                // Console.WriteLine("   For row " + rows[i]);
            }
            
            return ComputeBCD(ConvertedBits);
        }
    }
}