using System;

namespace CD.Unpacker
{
    [Flags]
    public enum Compression : Int16
    {
        NONE = 0,
        PARTIAL = 1,
        LZ4 = 2,
        ZLIB = 3,
        QUICKLZ = 4,
    }

    public enum Encryption : Int16
    {
        NONE = 0,
        ICE = 0x1,
        AES = 0x2,
        CHACHA20 = 0x3,
    }
}
