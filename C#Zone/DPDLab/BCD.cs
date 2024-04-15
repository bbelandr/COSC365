class BCD : BCDDecoderBase {
    private uint _raw;  // Holds the bits to be converted
    // public override int CompareTo(object? objectIn) {   // The question mark means that the object can be null
    //     // TODO: Compare objects
    //     return -1;
    // }
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
            return ComputeBCD(_raw);
        }
    }
}