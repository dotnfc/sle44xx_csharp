using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms.VisualStyles;
using static SLE44xxTool.MemoryCard.Sle44xx;

namespace SLE44xxTool.MemoryCard
{
    public class AcsReaderApi : ICardReaderApi
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

        public AcsReaderApi(WinscardReader device)
        {
            _reader = device;
            _4428 = new Sle4428();
            _4442 = new Sle4442();
            _card = _4428;
        }

        public bool SetCardType(CardType cardType)
        {
            string capdu = "";
            _cardType = cardType;
            if (cardType == CardType.SLE4428)
            {
                _card = _4428;
                capdu = "ffa4 0000 01 05";
            }
            else if (cardType == CardType.SLE4442)
            {
                _card = _4442;
                capdu = "ffa4 0000 01 06";
            }

            byte[] rapdu = null;
            bool ret = _reader.Transmit(capdu, ref rapdu);
            if (ret && (_reader.SW == 0x9000))
            {
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
            if (ret && (_reader.SW1 == 0x90))
            {
                if (_reader.SW2 == 0xFF)
                    return true;
            }

            return false;
        }

        public bool ChangePSC(string strNewPsc)
        {
            bool ret;
            byte[] rapdu = null;
            string capdu = "";
            strNewPsc = strNewPsc.Replace(" ", "");
            byte[] pscs = Utils.HexStringToByteArray(strNewPsc);

            if (_cardType == CardType.SLE4428)
            {
                capdu = "FFD0 03FD 03 FF " + pscs[0].ToString("X2") + pscs[1].ToString("X2");
            }
            else
            {
                capdu = "FFD2 0001 03" + pscs[0].ToString("X2") + pscs[1].ToString("X2");
            }

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
            bool ret;
            string apdu;

            if (_cardType == CardType.SLE4428)
            {
                apdu = "FFB1 0000 03";
            }
            else if (_cardType == CardType.SLE4442)
            {
                apdu = "FFB1 0000 04";
            }
            else
            {
                throw new Exception("Invalid card type");
            }

            byte[] rapdu = null;
            ret = _reader.Transmit(apdu, ref rapdu);
            if (ret && _reader.SW == 0x9000)
            {
                int count = 0;
                BitArray bitErrorCounter = new BitArray(rapdu[0]);

                if (_cardType == CardType.SLE4428)
                {
                    for (int i = 0; i < bitErrorCounter.Length; i++)
                    {
                        if (bitErrorCounter[i].ToString() == "True")
                            count++;
                    }
                }
                else if (_cardType == CardType.SLE4442)
                {
                    for (int i = 0; i < rapdu[0]; i++)
                    {
                        if (bitErrorCounter[i].ToString() == "True")
                            count++;
                    }
                }
                else
                {
                    count = 0;
                }
                return count;
            }

            return -1;
        }

        public bool ReadProtectBits(ushort address, ref byte[] protectBits, byte length)
        {
            bool ret;

            string apdu = "FFB2 " + address.ToString("X4") + length.ToString("X2");
            ret = _reader.Transmit(apdu, ref protectBits);
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }

            return false;
        }

        public bool WriteProtectBits(ushort address, byte[] protectBits, int offset, byte length)
        {
            bool ret;
            byte[] rapdu = null;

            string sdata = Utils.ByteArrayToHexString(protectBits, offset, length);
            string apdu = "FFD1 " + address.ToString("X4") + length.ToString("X2") + " " + sdata;
            ret = _reader.Transmit(apdu, ref rapdu);
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }

            return false;
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
            string apdu = "FFD0 " + address.ToString("X4") + length.ToString("X2") + " " + sdata;
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
            bool[] result;
            int i = 0;

            while (addr < length)
            {
                ret = ReadProtectBits(addr, ref rapdu, 16);

                if (ret && _reader.SW == 0x9000)
                {
                    for (i = 0; i < 16; i++)
                    {
                        result = Utils.ExpandByteToEightBools(rapdu[i]);
                        Array.Copy(result, 0, _card.AttrData, addr + i * 8, 8);
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

        // protectedBits are 8 bits(aka ONE byte) for 8 bytes data!!!
        // so here the 'length' is bits counter
        public bool LoadAttrFromIcc(ushort addr, byte length)
        {
            int i;
            bool[] result;

            if (length % 8 != 0)
                return false;

            if ((addr + length) > _card.AttrData.Length)
                return false; // invalid range

            byte[] rdata = null;
            bool ret = ReadProtectBits(addr, ref rdata, (byte)(length / 8));
            if (ret && _reader.SW == 0x9000)
            {
                for (i = 0; i < (length / 8); i++)
                {
                    result = Utils.ExpandByteToEightBools(rdata[i]);
                    Array.Copy(result, 0, _card.AttrData, addr + i * 8, 8);
                }

                return true;
            }

            return false;
        }

        // protectedBits are 8 bits(aka ONE byte) for 8 bytes data!!!
        // so here the 'length' is bits counter
        //
        // Note: The protect bit is only written if the old and the new data are identical.
        public bool SaveAttrToIcc(ushort addr, byte length)
        {
            if (length % 8 != 0)
                return false;

            if ((addr + length) > _card.AttrData.Length)
                return false; // invalid range

            byte[] bitsByte = new byte[length / 8];
            for(int i = 0; i < (length /8); i ++)
            {
                bitsByte[i] = Utils.CompressEightBoolsToByte(_card.AttrData, addr + 8 * i);
            }
            bool ret = WriteProtectBits(addr, bitsByte, 0, (byte)(length / 8));
            if (ret && _reader.SW == 0x9000)
            {
                return true;
            }

            return false;
        }
    }
}
