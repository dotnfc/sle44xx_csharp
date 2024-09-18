// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;
using System.Collections;

namespace SLE44xxTool.MemoryCard
{
    public class HidReaderApi : ICardReaderApi
    {
        private readonly WinscardReader _reader;
        private CardType _cardType;
        private Sle4428 _4428;
        private Sle4442 _4442;
        private ICard _card;

        byte[] ICardReaderApi.ByteData
        {
            get => _card.ByteData;
        }

        bool[] ICardReaderApi.AttrData
        {
            get => _card.AttrData;
        }

        CardType ICardReaderApi.Type
        {
            get => _cardType;
        }

        public HidReaderApi(WinscardReader device)
        {
            _reader = device;
            _4428 = new Sle4428();
            _4442 = new Sle4442();
            _card = _4428;
        }

        public bool ReadData(ushort address, ref byte[] data, byte length)
        {
            bool ret;
            string apdu = "FFB0 " + address.ToString("X4") + length.ToString("X2");
            ret = _reader.Transmit(apdu, ref data);
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }
            return false;
        }

        public bool WriteData(ushort address, byte[] data, int offset, byte length)
        {
            bool ret;
            byte[] rapdu = null;

            string sdata = Utils.ByteArrayToHexString(data, offset, length);
            string apdu = "FFD6 " + address.ToString("X4") + length.ToString("X2") + " " + sdata;
            ret = _reader.Transmit(apdu, ref rapdu);
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }

            return false;
        }

        public bool LoadAllData()
        {
            bool ret;
            ushort addr = 0;
            byte[] rapdu = null;

            Array.Clear(_card.ByteData, 0, _card.ByteData.Length);

            while (addr < _card.MemSize)
            {
                ret = ReadData(addr, ref rapdu, 128);
                if (ret && _reader.SW == 0x9000)
                {
                    Array.Copy(rapdu, 0, _card.ByteData, addr, 128);
                    addr += 128;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool LoadAllAttr()
        {
            bool ret;
            ushort addr = 0;
            byte[] rapdu = null;

            Array.Clear(_card.AttrData, 0, _card.AttrData.Length);

            int length = _card.MemSize;

            while (addr < length)
            {
                ret = ReadProtectBits(addr, ref rapdu, 128);

                if (ret && _reader.SW == 0x9000)
                {
                    for (int i = 0; i < rapdu.Length; i++)
                    {
                        // hid api: 
                        // 0x00 - protection bit is not set
                        // 0x01 - protection bit is set

                        // here we invert it, for acs first
                        _card.AttrData[addr + i] = (rapdu[i] == 0);
                    }            

                    addr += 128;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool ReadProtectBits(ushort address, ref byte[] protectBits, byte length)
        {
            bool ret;

            string apdu = "FF3A " + address.ToString("X4") + length.ToString("X2");
            ret = _reader.Transmit(apdu, ref protectBits);
            if (ret && _reader.SW == 0x9000)
            {
                // byte array to bits-byte array

                return true;
            }

            return false;
        }

        public bool LoadAll()
        {
            if (LoadAllData())
            {
                return LoadAllAttr();
            }

            return false;
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

        public bool AuthPSC(string strPsc)
        {
            throw new NotImplementedException();
        }

        public bool ChangePSC(string strNewPsc)
        {
            throw new NotImplementedException();
        }

        public int ReadErrorCounter()
        {
            throw new NotImplementedException();
        }

        public bool SetCardType(CardType cardType)
        {
            return true;
        }

        public bool WriteProtectBits(ushort address, byte[] protectBits, int offset, byte length)
        {
            throw new NotImplementedException();
        }
    }
}
