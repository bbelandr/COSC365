interface ICompValue : System.IComparable {
    // CompareTo(object);
    // Needs to:
    // return -1 if this.Val < object.Val (object typecasted into ICompValue)
    // return 0 if this.Val == object.Val (object typecasted into ICompValue)
    // return 1 if this.Val > object.Val

    // Raw property (gets/sets the RAW DPD or BCD)
    public uint Raw { get; set; }
    // Decoded property (gets the actual number)
    public uint Val { get; }
    // uint ComputeBCD(uint bitsIn) {
    //     uint decodedNum = 0;
    //     for (int i = 0; i < sizeof(uint) * 2; i++) {
    //         char currentNum = (char)((bitsIn >> (i * 4)) & 0b_1111);
    //         decodedNum += currentNum * (uint)Math.Pow(10, i);
    //     }
    //     return decodedNum;
    // }
}