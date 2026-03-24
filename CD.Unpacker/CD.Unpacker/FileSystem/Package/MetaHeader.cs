using System;

namespace CD.Unpacker
{
    class MetaHeader
    {
        public UInt32 dwChecksum { get; set; }
        public Int32 dwTotalArchives { get; set; }
        public UInt32 dwMagic { get; set; } // Always (32 02 0E 61)
        public Int32 dwUnknown2 { get; set; } // 0
        public UInt32 dwUnknown3 { get; set; }
        public Int32 dwArchiveSize { get; set; } // Size of PAZ file's
        public Int32 dwFoldersTableSize { get; set; }
        public Int32 dwNamesTableSize { get; set; }
        public Int32 dwTotalFolders { get; set; }
        public Int32 dwTotalFiles { get; set; }
    }
}
