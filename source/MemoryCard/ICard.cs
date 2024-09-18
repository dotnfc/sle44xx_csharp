// MIT License
// 
// Copyright (c) 2024 dotnfc
//

namespace SLE44xxTool.MemoryCard
{
    public interface ICard
    {
        ushort MemSize {  get; }
        byte[] ByteData { get; }
        bool[] AttrData { get; }
    }
}
