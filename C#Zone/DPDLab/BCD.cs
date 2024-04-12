class BCD : ICompValue {
    private uint _raw;
    int IComparable.CompareTo(object? objectIn) {   // The question mark means that the object can be null
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
            // Decode BCD
            // int decodedNum = 0;
            // int currentPlace = 0;
            // int individualNum;
            // for (int i = 0; i < RawBytes.Length; i++) {
            //     // Get the right bits
            //     individualNum = RawBytes[RawBytes.Length - 1 - i] & 0b_0000_1111;
            //     decodedNum += individualNum * (int)Math.Pow(10, currentPlace++);
                
            //     // Get the left bits
            //     individualNum = RawBytes[RawBytes.Length - 1 - i] >> 4;
            //     decodedNum += individualNum * (int)Math.Pow(10, currentPlace++);
                
            // }
            
            // return decodedNum;
            uint decodedNum = 0;
            for (int i = 0; i < 8; i++) {
                // int currentMask = 0b_1111 << (i * 4);
                char currentNum = (char)((_raw >> (i * 4)) & 0b_1111);
                decodedNum += currentNum * (uint)Math.Pow(10, i);
            }

            
            return decodedNum;
        }
    }
}