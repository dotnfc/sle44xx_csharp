// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;

namespace SLE44xxTool.MemoryCard
{
    public delegate void Log(string message);

    public class Sle44xx
    {
        public enum CARD_TYPE
        {
            SLE_4428 = 0x05,
            SLE_4442 = 0x06,
            UNKNOWN
        }

        public enum IC_TYPE
        {
            SLE_4428 = 0x13,
            SLE_4442 = 0x15
        }

        public enum PROTOCOL_TYPE
        {
            RESERVED_MIN = 0x00,
            RESERVED_MAX = 0x70,
            NOT_DEFINED_MIN = 0xB0,
            NOT_DEFINED_MAX = 0xE0,
            SERIAL_DATA = 0x80,
            THREE_WIRE = 0x90,
            TWO_WIRE = 0xA0,
            RFU = 0xF0,
            UNKNOWN
        }

        public enum DATA_UNITS
        {
            NO_INDICATION = 0x00,
            BYTES_128 = 0x10,
            BYTES_256 = 0x20,
            BYTES_512 = 0x30,
            BYTES_1024 = 0x40,
            BYTES_2048 = 0x50,
            BYTES_4096 = 0x60,
            UNKNOWN
        }

        private const int MANUFACTURER_DATA_LENGTH = 2;
        private const int APPLICATION_ID_LENGTH = 6;
        private const int DATA_UNIT_AND_PROTOCOL_LENGTH = 4;

        public Sle44xx()
        {

        }

        public static PROTOCOL_TYPE getProtocolType(byte cardInformation)
        {
            byte protocolType = (byte)(cardInformation & 0xF0);

            if (protocolType == (byte)PROTOCOL_TYPE.SERIAL_DATA)
            {
                return PROTOCOL_TYPE.SERIAL_DATA;
            }
            else if (protocolType == (byte)PROTOCOL_TYPE.THREE_WIRE)
            {
                return PROTOCOL_TYPE.THREE_WIRE;
            }
            else if (protocolType == (byte)PROTOCOL_TYPE.TWO_WIRE)
            {
                return PROTOCOL_TYPE.TWO_WIRE;
            }
            else if (protocolType == (byte)PROTOCOL_TYPE.RFU)
            {
                return PROTOCOL_TYPE.RFU;
            }
            else if (protocolType == (byte)PROTOCOL_TYPE.RESERVED_MIN ||
                     protocolType == (byte)PROTOCOL_TYPE.RESERVED_MAX ||
                    (protocolType > (byte)PROTOCOL_TYPE.RESERVED_MIN &&
                     protocolType < (byte)PROTOCOL_TYPE.RESERVED_MAX))
            {
                return PROTOCOL_TYPE.RESERVED_MAX;
            }
            else if (protocolType == (byte)PROTOCOL_TYPE.NOT_DEFINED_MIN ||
                     protocolType == (byte)PROTOCOL_TYPE.NOT_DEFINED_MAX ||
                    (protocolType > (byte)PROTOCOL_TYPE.NOT_DEFINED_MIN &&
                     protocolType < (byte)PROTOCOL_TYPE.NOT_DEFINED_MAX))
            {
                return PROTOCOL_TYPE.NOT_DEFINED_MAX;
            }
            else
            {
                return PROTOCOL_TYPE.UNKNOWN;
            }
        }

        public static DATA_UNITS getDataUnits(byte cardInformation)
        {
            byte dataUnits = (byte)(cardInformation << 1);

            dataUnits = (byte)(dataUnits & 0xF0);

            if (dataUnits == (byte)DATA_UNITS.BYTES_128)
            {
                return DATA_UNITS.BYTES_128;
            }
            else if (dataUnits == (byte)DATA_UNITS.BYTES_256)
            {
                return DATA_UNITS.BYTES_256;
            }
            else if (dataUnits == (byte)DATA_UNITS.BYTES_512)
            {
                return DATA_UNITS.BYTES_512;
            }
            else if (dataUnits == (byte)DATA_UNITS.BYTES_1024)
            {
                return DATA_UNITS.BYTES_1024;
            }
            else if (dataUnits == (byte)DATA_UNITS.BYTES_2048)
            {
                return DATA_UNITS.BYTES_2048;
            }
            else if (dataUnits == (byte)DATA_UNITS.BYTES_4096)
            {
                return DATA_UNITS.BYTES_4096;
            }
            else if (dataUnits == (byte)DATA_UNITS.NO_INDICATION)
            {
                return DATA_UNITS.NO_INDICATION;
            }
            else
            {
                return DATA_UNITS.UNKNOWN;
            }
        }

        public static bool showSLE44xxCardInfo(byte[] cardInfoData, ref CARD_TYPE cardType, Log addMessageToLog)
        {
            byte[] cardInformation = new byte[12];
            Array.Copy(cardInfoData, 0, cardInformation, 0, DATA_UNIT_AND_PROTOCOL_LENGTH);
            Array.Copy(cardInfoData, 6, cardInformation, 4, MANUFACTURER_DATA_LENGTH);
            Array.Copy(cardInfoData, 21, cardInformation, 6, APPLICATION_ID_LENGTH);

            addMessageToLog("\nIC Manufacturer ID: " + string.Format("{0:X2}", cardInformation[4]));

            if (cardInformation[5] == (byte)IC_TYPE.SLE_4428)
            {
                cardType = CARD_TYPE.SLE_4428;
                addMessageToLog("IC Type: SLE4418 / SLE4428 / SLE5528");
            }
            else if (cardInformation[5] == (byte)IC_TYPE.SLE_4442)
            {
                cardType = CARD_TYPE.SLE_4442;
                addMessageToLog("IC Type: SLE4432 / SLE4442 / SLE5542");
            }
            else
            {
                addMessageToLog("IC Type: Unknown");
                return false;
            }

            addMessageToLog("Application ID: " + Utils.byteAsString(cardInformation, 6, 6, true));

            PROTOCOL_TYPE protocolType = getProtocolType(cardInformation[0]);
            if (protocolType == PROTOCOL_TYPE.SERIAL_DATA)
            {
                addMessageToLog("Protocol Type: Serial Data Access");
            }
            else if (protocolType == PROTOCOL_TYPE.THREE_WIRE)
            {
                addMessageToLog("Protocol Type: 3-Wire Bus");
            }
            else if (protocolType == PROTOCOL_TYPE.TWO_WIRE)
            {
                addMessageToLog("Protocol Type: 2-Wire Bus");
            }
            else if (protocolType == PROTOCOL_TYPE.RFU)
            {
                addMessageToLog("Protocol Type: RFU");
            }
            else if (protocolType == PROTOCOL_TYPE.RESERVED_MAX)
            {
                addMessageToLog("Protocol Type: Reserved for ISO");
            }
            else if (protocolType == PROTOCOL_TYPE.NOT_DEFINED_MAX)
            {
                addMessageToLog("Protocol Type: Not defined by ISO");
            }
            else
            {
                addMessageToLog("Protocol Type: Unknown");
            }

            DATA_UNITS dataUnits = getDataUnits(cardInformation[1]);

            if (dataUnits == DATA_UNITS.BYTES_128)
            {
                addMessageToLog("Data Units: 128 Bytes");
            }
            else if (dataUnits == DATA_UNITS.BYTES_256)
            {
                addMessageToLog("Data Units: 256 Bytes");
            }
            else if (dataUnits == DATA_UNITS.BYTES_512)
            {
                addMessageToLog("Data Units: 512 Bytes");
            }
            else if (dataUnits == DATA_UNITS.BYTES_1024)
            {
                addMessageToLog("Data Units: 1024 Bytes");
            }
            else if (dataUnits == DATA_UNITS.BYTES_2048)
            {
                addMessageToLog("Data Units: 2048 Bytes");
            }
            else if (dataUnits == DATA_UNITS.BYTES_4096)
            {
                addMessageToLog("Data Units: 4096 Bytes");
            }
            else if (dataUnits == DATA_UNITS.NO_INDICATION)
            {
                addMessageToLog("Data Units: Not Indicated");
            }
            else
            {
                addMessageToLog("Data Units: Unknown");
            }
            return true;
        }
    } // public class Sle44xx

} // namespace SLE44xxTool.MemoryCard
