using System;

namespace CD.Unpacker
{
    class MetaEntry
    {
        public Int32 dwFileNameOffset { get; set; }
        public UInt32 dwOffset { get; set; }
        public Int32 dwCompressedSize { get; set; }
        public Int32 dwDecompressedSize { get; set; }
        public Int16 wArchiveId { get; set; }
        public Int16 wFlags { get; set; }
        public Encryption wEncryption { get; set; }
        public Compression wCompression { get; set; }
    }
}
