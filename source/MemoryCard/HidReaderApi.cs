using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLE44xxTool.MemoryCard
{
    public class HidReaderApi : ICardReaderApi
    {
        private readonly WinscardReader _device; // 假设有一个HidDevice类用于操作HID设备

        public HidReaderApi(WinscardReader device)
        {
            _device = device;
        }

        CardType ICardReaderApi.Type => throw new NotImplementedException();

        byte[] ICardReaderApi.ByteData => throw new NotImplementedException();

        bool[] ICardReaderApi.AttrData => throw new NotImplementedException();

        public bool LoadAll()
        {
            throw new NotImplementedException();
        }

        public bool LoadAttrFromIcc(ushort addr, byte length)
        {
            throw new NotImplementedException();
        }

        public bool LoadDataFromIcc(ushort addr, byte length)
        {
            throw new NotImplementedException();
        }

        public bool SaveAttrToIcc(ushort addr, byte length)
        {
            throw new NotImplementedException();
        }

        public bool SaveDataToIcc(ushort addr, byte length)
        {
            throw new NotImplementedException();
        }

        public bool ToggleProtectBit(int row, int col)
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.AuthPSC(string strPsc)
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.ChangePSC(string strNewPsc)
        {
            throw new NotImplementedException();
        }


        bool ICardReaderApi.ReadData(ushort address, ref byte[] data, byte length)
        {
            throw new NotImplementedException();
        }

        int ICardReaderApi.ReadErrorCounter()
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.ReadProtectBits(ushort address, ref byte[] protectBits, byte length)
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.SetCardType(CardType cardType)
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.WriteData(ushort address, byte[] data, int offset, byte length)
        {
            throw new NotImplementedException();
        }

        bool ICardReaderApi.WriteProtectBits(ushort address, byte[] protectBits, int offset, byte length)
        {
            throw new NotImplementedException();
        }
    }
}
