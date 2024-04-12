class BCD : ICompValue {
    private uint _raw;
    int IComparable.CompareTo(object? objectIn) {   // The question mark means that the object can be null
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
            uint decodedNum = 0;
            for (int i = 0; i < 8; i++) {
                char currentNum = (char)((_raw >> (i * 4)) & 0b_1111);
                decodedNum += currentNum * (uint)Math.Pow(10, i);
            }

            return decodedNum;
        }
    }
}