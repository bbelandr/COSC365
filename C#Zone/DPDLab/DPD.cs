using System.Text.RegularExpressions;

class DPD : ICompValue {
    private uint _raw;
    int IComparable.CompareTo(object? obj) {
        // TODO: Compare objects
        return -1;
    }

    public uint Raw {
        get {
            return _raw;
        }
        set {
            _raw = value;
        }
    }

    public uint Val {
        get {
            // Decode here

            // Separate into groups
            ushort[] bitGroups = new ushort[3];    // What stores the 3 groupings of numbers
            for (int i = 0; i < 3; i++) {
                bitGroups[i] = (ushort)((_raw >> (i * 10)) & 0b_0011_1111_1111);
            }

            // Find which row of the table corresponds with the current value
            int[] rows = new int[3];
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
                    default:
                        Console.WriteLine(Convert.ToString(bitGroups[i], 2) + " not recognized as DPD format");
                        break;
                }
                
            }
            
            return bitGroups[2];
        }
    }
}