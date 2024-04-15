abstract class BCDDecoderBase : ICompValue {
    public abstract uint Raw { get; set; }
    public abstract uint Val { get; }

    public uint ComputeBCD(uint bitsIn) {
        uint decodedNum = 0;
        for (int i = 0; i < sizeof(uint) * 2; i++) {
            char currentNum = (char)((bitsIn >> (i * 4)) & 0b_1111);
            decodedNum += currentNum * (uint)Math.Pow(10, i);
        }
        return decodedNum;
    }
    

    public bool IsBitSet(uint bits, int index) {
        return ((bits >> index) & 1) == 1;
    }
    public void SetBit(ref uint bits, int index) {
        bits = bits | (uint)(1 << index);
    }
    public void CopyBit(uint sourceBits, int sourceIndex, ref uint destBits, int destIndex) {
        if (IsBitSet(sourceBits, sourceIndex)) {
            SetBit(ref destBits, destIndex);
        }
    }
    public int CompareTo(object? obj) {
        // TODO: Compare objects
        ICompValue? incomingObj = obj as ICompValue;
        if (incomingObj is not null) {
            if (Val < incomingObj.Val) {
                return -1;
            }
            else if (Val == incomingObj.Val) {
                return 0;
            }
            else {
                return 1;
            }
        }
        return -1;
    }
    // public abstract int CompareTo(object? obj);
}
