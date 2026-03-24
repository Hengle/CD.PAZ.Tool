using System;

namespace CD.Unpacker
{
    class MetaFolder
    {
        public UInt32 dwChecksum { get; set; }
        public Int32 dwFolderNameOffset { get; set; }
        public Int32 dwUnknown1 { get; set; } // files in the previous root directory?
        public Int32 dwTotalFiles { get; set; } // files in the current root directory?
    }
}
