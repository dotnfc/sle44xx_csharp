// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace SLE44xxTool.MemoryCard
{
    public class WinscardReader
    {
        private int mLastResult;

        public enum ResetType
        {
            ColdReset, // 冷复位
            WarmReset  // 热复位
        }

        #region Constants for SCardConnect

        private uint SCARD_S_SUCCESS = 0;

        // This application is willing to share this card with other applications.
        private const int SCARD_SHARE_SHARED = 1;

        // This application is not willing to share this card with other applications.
        private const int SCARD_SHARE_EXCLUSIVE = 2;

        // This application demands direct control of the reader, so it is not available to other applications.
        private const int SCARD_SHARE_DIRECT = 3;

        private const int SCARD_PROTOCOL_T0 = 0x01;
        private const int SCARD_PROTOCOL_T1 = 0x02;

        // The context is a user context, and any database operations are performed within the domain of the user.
        private const int SCARD_SCOPE_USER = 0;

        // The context is that of the current terminal, and any database operations are performed
        // within the domain of that terminal.  (The calling application must have appropriate
        // access permissions for any database actions.)
        private const int SCARD_SCOPE_TERMINAL = 1;

        // The context is the system context, and any database operations are performed within the
        // domain of the system.  (The calling application must have appropriate access
        // permissions for any database actions.)
        private const int SCARD_SCOPE_SYSTEM = 2;

        private const int SCARD_LEAVE_CARD = 0; // Don't do anything special on close
        private const int SCARD_RESET_CARD = 1; // Reset the card on close
        private const int SCARD_UNPOWER_CARD = 2; // Power down the card on close
        private const int SCARD_EJECT_CARD = 3; // Eject the card on close
        #endregion // Constants for SCardConnect


        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardEstablishContext(int dwScope, IntPtr pvReserved1, IntPtr pvReserved2, out IntPtr phContext);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardReleaseContext(IntPtr hContext);

        [DllImport("winscard.dll", EntryPoint = "SCardListReadersA", CharSet = CharSet.Auto)]
        private static extern int SCardListReaders(IntPtr hContext, byte[] Groups, byte[] Readers, ref int pcchReaders);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardConnect(IntPtr hContext, string szReader, uint dwShareMode, uint dwPreferredProtocols, out IntPtr phCard, out uint pdwActiveProtocol);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardDisconnect(IntPtr hCard, uint dwDisposition);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardReconnect(IntPtr hCard, uint dwShareMode, uint dwPreferredProtocols, uint dwInitialization, out uint pdwActiveProtocol);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardStatus(IntPtr hCard, StringBuilder szReaderName, ref int pcchReaderName, ref uint pdwState, ref uint pdwProtocol, byte[] pbAtr, ref int pcbAtr);

        [DllImport("winscard.dll", CharSet = CharSet.Auto)]
        private static extern int SCardTransmit(IntPtr hCard, [In] ref SCARD_IO_REQUEST pioSendPci, byte[] pbSendBuffer, uint cbSendLength, ref SCARD_IO_REQUEST pioRecvPci, byte[] pbRecvBuffer, ref uint pcbRecvLength);

        [StructLayout(LayoutKind.Sequential)]
        public struct SCARD_IO_REQUEST
        {
            public uint dwProtocol;
            public uint cbPciLength;
        }

        private IntPtr hCard = IntPtr.Zero;
        private IntPtr hContext = IntPtr.Zero;
        private string readerName = null;
        private uint activeProtocol = SCARD_PROTOCOL_T0;
        private bool bIsConnected = false;

        private ushort sw;
        private byte[] response;
        private Log _logger;

        public WinscardReader(Log logger)
        {
            _logger = logger;
            sw = 0x6f00;
            response = new byte[256 + 2];

            mLastResult = SCardEstablishContext(SCARD_SCOPE_SYSTEM, IntPtr.Zero, IntPtr.Zero, out hContext);
            if (mLastResult != SCARD_S_SUCCESS)
            {
                mLastResult = SCardEstablishContext(SCARD_SCOPE_USER, IntPtr.Zero, IntPtr.Zero, out hContext);
                if (mLastResult != SCARD_S_SUCCESS)
                {
                    throw new Exception("Failed to establish context.");
                }
            }
        }

        ~WinscardReader()
        {
            if (hContext != IntPtr.Zero)
            {
                SCardReleaseContext(hContext);
            }
        }

        public List<string> ListReaders()
        {
            int pcchReaders = 0;

            // First call to determine the size of the buffer needed
            mLastResult = SCardListReaders(hContext, null, null, ref pcchReaders);
            if (mLastResult != SCARD_S_SUCCESS)
            {
                throw new InvalidOperationException("Failed to get reader list buffer size.");
            }

            // Allocate buffer and get the list of readers
            byte[]readerNameArray = new byte[pcchReaders];
            mLastResult = SCardListReaders(hContext, null, readerNameArray, ref pcchReaders);
            if (mLastResult != SCARD_S_SUCCESS)
            {
                throw new InvalidOperationException("Failed to get reader list.");
            }

            // Parse the list of readers
            string readerString = System.Text.ASCIIEncoding.ASCII.GetString(readerNameArray).Trim('\0');
            string[] readerList = new string[0];
            readerList = readerString.Split('\0');

            return readerList.ToList();
        }

        static List<string> ConvertCharArrayToStringArray(char[] charArray)
        {
            var strings = new System.Collections.Generic.List<string>();

            string temp = string.Empty;

            foreach (char ch in charArray)
            {
                if (ch == '\0')
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        strings.Add(temp);
                        temp = string.Empty;
                    }
                }
                else
                {
                    temp += ch;
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                strings.Add(temp);
            }

            return strings;
        }

        public bool Connect(string readerName)
        {
            string atr = "";
            return Connect(readerName, ref atr);
        }

        public bool Connect(string readerName, ref string strAtr)
        {
            strAtr = "3B 00";
            activeProtocol = SCARD_PROTOCOL_T0;

            mLastResult = SCardConnect(hContext,
                readerName,
                SCARD_SHARE_SHARED,
                SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1,
                out hCard,
                out activeProtocol);
            if (mLastResult == SCARD_S_SUCCESS)
            {
                StringBuilder readerNameBuf = new StringBuilder(256);
                uint state = 0;
                uint protocolUsed = activeProtocol;
                byte[] atrBuf = new byte[36];
                int atrLength = atrBuf.Length;

                mLastResult = SCardStatus(hCard, readerNameBuf, ref atrLength, ref state, ref protocolUsed, atrBuf, ref atrLength);
                if (mLastResult == SCARD_S_SUCCESS)
                {
                    strAtr = BitConverter.ToString(atrBuf, 0, atrLength).Replace("-", "");
                }

                this.readerName = readerName;
                bIsConnected = true;
                return true;
            }

            bIsConnected = false;
            return false;
        }

        public bool Disconnect()
        {
            bIsConnected = false;

            if (hCard != IntPtr.Zero)
            {
                mLastResult = SCardDisconnect(hCard, SCARD_UNPOWER_CARD);
                hCard = IntPtr.Zero;
                if (mLastResult == SCARD_S_SUCCESS)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Transmit(string capdu, ref byte[] rapdu)
        {
            capdu = capdu.Replace(" ", "");
            byte[] arrApdu = Utils.HexStringToByteArray(capdu);

            return Transmit(arrApdu, ref rapdu);
        }

        public bool Transmit(byte[] capdu, ref byte[] rapdu)
        {
            //byte[] responseBuffer = new byte[258]; // APDU response maximum length
            uint responseLength = (uint)response.Length;
            SCARD_IO_REQUEST ioRequest = new SCARD_IO_REQUEST
            {
                dwProtocol = activeProtocol,
                cbPciLength = (uint)Marshal.SizeOf(typeof(SCARD_IO_REQUEST))
            };

            _logger("--> " + Utils.ByteArrayToHexString(capdu, capdu.Length));

            mLastResult = SCardTransmit(hCard, ref ioRequest, capdu, (uint)capdu.Length, ref ioRequest, response, ref responseLength);
            if (mLastResult == SCARD_S_SUCCESS)
            {
                // make sure responseLength >= 2
                if (responseLength >=2)
                {
                    rapdu = new byte[responseLength - 2];
                    Array.Copy(response, rapdu, (int)responseLength - 2);

                    sw = (ushort)((response[responseLength - 2] << 8) + response[responseLength - 1]);

                    _logger("<-- " + Utils.ByteArrayToHexString(rapdu, rapdu.Length) + " (" + sw.ToString("X4") + ")");

                    return true;
                }
            }

            sw = 0x6f00;
            return false;
        }

        public string getErrorMessage()
        {
            string message = new Win32Exception(mLastResult).Message;

            return message;
        }

        public bool Reset(ResetType resetType, ref string strATR)
        {
            bIsConnected = false;

            uint dwInitialization = SCARD_UNPOWER_CARD;      // cold reset

            if (resetType == ResetType.ColdReset)
                dwInitialization = SCARD_UNPOWER_CARD;      // cold reset
            else
                dwInitialization = SCARD_RESET_CARD;		// warm reset

            int result = SCardReconnect(hCard,
                SCARD_SHARE_SHARED,
                SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1,
                dwInitialization,
                out activeProtocol);
            if (result == SCARD_S_SUCCESS)
            {
                StringBuilder readerNameBuf = new StringBuilder(256);
                uint state = 0;
                uint protocolUsed = 0;
                byte[] atrBuf = new byte[36];
                int atrLength = atrBuf.Length;

                result = SCardStatus(hCard, readerNameBuf, ref atrLength, ref state, ref protocolUsed, atrBuf, ref atrLength);
                if (result == SCARD_S_SUCCESS)
                {
                    bIsConnected = true;
                    strATR = BitConverter.ToString(atrBuf, 0, atrLength).Replace("-", "");
                    return true;
                }
            }
            return false;
        }

        private static byte[] ConvertHexStringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid hex string length.");
            }

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public bool IsConnected { get { return bIsConnected; } }
        public ushort SW {  get { return sw; } }
        public byte SW1 { get { return (byte)((sw >> 8) & 0xff); } }
        public byte SW2 { get { return (byte)(sw & 0xff); } }

    } // class SyncCardReader
} // namespace HidSle44xx.MemoryCard
