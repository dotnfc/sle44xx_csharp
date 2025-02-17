﻿// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;

namespace SLE44xxTool.MemoryCard
{
    public enum CardType
    {
        SLE4428, SLE4442, ATI2C
    }

    public interface ICardReaderApi
    {
        CardType Type { get; }
        byte[] ByteData { get; }
        bool[] AttrData { get; }

        bool SetCardType(CardType cardType);

        bool LoadAll();

        bool AuthPSC(string strPsc);
        
        bool ChangePSC(string strOldPsc, string strNewPsc);

        int ReadErrorCounter();

        // memory data attr-bits R/W
        bool ReadProtectBits(ushort address, ref byte[] protectBits, byte length);
        bool WriteProtectBits(ushort address, byte[] protectBits, int offset, byte length);

        // memory data R/W
        bool ReadData(ushort address, ref byte[] data, byte length);
        bool WriteData(ushort address, byte[] data, int offset, byte length);

        //// utils for UI, by specify address and length(16 bytes)
        bool LoadDataFromIcc(ushort addr, byte length);
        bool SaveDataToIcc(ushort addr, byte length);
        bool ToggleProtectBit(int row, int col);
        bool LoadAttrFromIcc(ushort addr, byte length);
        bool SaveAttrToIcc(ushort addr, byte length);
    }
    
    public class CardReaderFactory
    {
        public static ICardReaderApi CreateCardReader(string readerName, object device)
        {
            if (readerName.StartsWith("Aero") || readerName.StartsWith("HID") || readerName.StartsWith("Feitian") )
            {
                return new HidReaderApi((WinscardReader)device);
            }
            else if (readerName.StartsWith("ACS"))
            {
                return new AcsReaderApi((WinscardReader)device);
            }
            else
            {
                throw new ArgumentException("Unsupported Reader");
            }
        }
    }
}
