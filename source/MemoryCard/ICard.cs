using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLE44xxTool.MemoryCard
{
    public interface ICard
    {
        ushort MemSize {  get; }
        byte[] ByteData { get; }
        bool[] AttrData { get; }
    }
}
