// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;
using System.Collections;
using static SLE44xxTool.MemoryCard.Sle44xx;

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

        public bool SetCardType(CardType cardType)
        {
            _cardType = cardType;
            if (cardType == CardType.SLE4428)
            {
                _card = _4428;
            }
            else if(cardType == CardType.SLE4442)
            {
                _card = _4442;
            }
            return true;
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

        public bool ReadSecureMemory(ref byte[] data)
        {
            bool ret;

            byte[] rapdu = null;

            // --> FF70 076B 07  A6 05 A0 03   31 00 00 08
            // <-- BD06A0 04 07000000 9000
            string apdu = "FF70 076B 07  A6 05 A0 03   31 00 00 08 ";
            ret = _reader.Transmit(apdu, ref rapdu);
            if (ret && _reader.SW == 0x9000)
            {
                data = new byte[4];
                Array.Copy(rapdu, 4, data, 0, 4);

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

            int length = _card.AttrData.Length;
            byte blkLen = (byte)((_cardType == CardType.SLE4428) ? 128 : 32);

            while (addr < length)
            {
                ret = ReadProtectBits(addr, ref rapdu, blkLen);

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

                    addr += blkLen;
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
            int i;

            if (length % 8 != 0)
                return false;

            if ((addr + length) > _card.AttrData.Length)
                return false; // invalid range

            byte[] rdata = null;
            bool ret = ReadProtectBits(addr, ref rdata, length);
            if (ret && _reader.SW == 0x9000)
            {
                for (i = 0; i < rdata.Length; i++)
                {
                    // hid api: 
                    // 0x00 - protection bit is not set
                    // 0x01 - protection bit is set

                    // here we invert it, for acs first
                    _card.AttrData[addr + i] = (rdata[i] == 0);
                }

                return true;
            }

            return false;
        }

        public bool LoadDataFromIcc(ushort addr, byte length)
        {
            if ((addr + length) > _card.ByteData.Length)
                return false; // invalid range

            byte[] rdata = null;
            bool ret = ReadData(addr, ref rdata, length);
            if (ret && _reader.SW == 0x9000)
            {
                Array.Copy(rdata, 0, _card.ByteData, addr, length);
                return true;
            }

            return false;
        }

        public bool SaveAttrToIcc(ushort addr, byte length)
        {
            throw new NotImplementedException();
        }

        public bool SaveDataToIcc(ushort addr, byte length)
        {
            if ((addr + length) > _card.ByteData.Length)
                return false; // invalid range

            bool ret = WriteData(addr, _card.ByteData, addr, length);
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }

            return false;
        }

        public bool ToggleProtectBit(int row, int col)
        {
            int addr = row * 16 + col;
            if (addr > _card.ByteData.Length)
            {
                return false;
            }

            _card.AttrData[addr] = !_card.AttrData[addr];
            return true;
        }

        public bool AuthPSC(string strPsc)
        {
            bool ret;
            byte[] rapdu = null;
            string capdu = "";
            //const int SLE5528_ERROR_COUNT = 8;
            //const int SLE5542_ERROR_COUNT = 3;
            //const int SLE5542_MAX_ERROR_COUNTER = 7;

            strPsc = strPsc.Replace(" ", "");
            byte[] pscs = Utils.HexStringToByteArray(strPsc);

            if (_cardType == CardType.SLE4428)
            {
                if (pscs.Length != 2)
                {
                    return false;
                }
                capdu = "FF20 0000 02" + pscs[0].ToString("X2") + pscs[1].ToString("X2");
            }
            else if (_cardType == CardType.SLE4442)
            {
                if (pscs.Length != 3)
                {
                    return false;
                }
                capdu = "FF20 0000 03" + pscs[0].ToString("X2") + pscs[1].ToString("X2")  + pscs[2].ToString("X2");
            }

            ret = _reader.Transmit(capdu, ref rapdu);
            if (ret)
            {
                if (_reader.SW == 0x9000)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ChangePSC(string strOldPsc, string strNewPsc)
        {
            bool ret;
            byte[] rapdu = null;
            string capdu = "";

            strOldPsc = strOldPsc.Replace(" ", "");
            byte[] oldPsc = Utils.HexStringToByteArray(strOldPsc);

            strNewPsc = strNewPsc.Replace(" ", "");
            byte[] newPsc = Utils.HexStringToByteArray(strNewPsc);

            int lc = oldPsc.Length + newPsc.Length;

            capdu = "FF21 0000 " + lc.ToString("X2") + strOldPsc + strNewPsc;

            ret = _reader.Transmit(capdu, ref rapdu);
            if (ret && (_reader.SW1 == 0x90))
            {
                if (_reader.SW2 == 0xFF)
                    return true;
            }

            return false;
        }

        public int ReadErrorCounter()
        {
            int count = 0;
            byte[] rapdu = null;

            if (_cardType == CardType.SLE4428)
            {
                if( ReadData(0x3FD, ref rapdu, 1) )
                {
                    count = Utils.CountBits(rapdu[0]);                    
                }
            }
            else if (_cardType == CardType.SLE4442)
            {
                if (ReadSecureMemory(ref rapdu))
                {
                    count = Utils.CountBits(rapdu[0]);
                }
            }
            else
            {
                throw new Exception("Invalid card type");
            }

            return count;
        }

        public bool WriteProtectBits(ushort address, byte[] protectBits, int offset, byte length)
        {
            throw new NotImplementedException();
        }
    }
}
