// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

namespace SLE44xxTool.MemoryCard
{    
    public class Sle4428 : ICard
    {
        public static ushort MEM_SIZE = 1024;

        private byte[] _data;
        private bool[] _protectedBits;

        public ushort MemSize { get => MEM_SIZE; }

        public byte[] ByteData { get => _data; }
        public bool[] AttrData { get => _protectedBits; }

        public Sle4428()
        {
            _data = new byte[MEM_SIZE];
            _protectedBits = new bool[MEM_SIZE];
        }
    } //public class Sle4428
}
