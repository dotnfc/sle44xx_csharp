using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLE44xxTool.MemoryCard
{
    public class Sle4442 : ICard
    {
        public static ushort MEM_SIZE = 256;

        private byte[] _data;
        private bool[] _protectedBits;

        public ushort MemSize { get => MEM_SIZE; }

        public byte[] ByteData { get => _data; }
        public bool[] AttrData { get => _protectedBits; }

        public Sle4442()
        {
            _data = new byte[MEM_SIZE];
            _protectedBits = new bool[MEM_SIZE];
        }
    } //public class Sle4442
}
