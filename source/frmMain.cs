// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SLE44xxTool.ExtControl;
using SLE44xxTool.MemoryCard;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static SLE44xxTool.MemoryCard.Sle44xx;

namespace SLE44xxTool
{
    public partial class frmMain : FormEx
    {
        private WinscardReader mReader;
        private ICardReaderApi mCardApi;
        private CardType mCardType;

        public frmMain()
        {
            InitializeComponent();

            mReader = new WinscardReader(LogMessage);

            Load += frmMain_Load;
        }

        void ReaderList()
        {
            String oldItemName = "";

            oldItemName = cbxReaderList.Text;

            cbxReaderList.Items.Clear();

            foreach (var reader in mReader.ListReaders())
            {
                cbxReaderList.Items.Add(reader);
            }

            if (cbxReaderList.Items.Count > 0)
            {
                if (oldItemName != "")
                {
                    cbxReaderList.SelectedItem = oldItemName;
                }
                else
                {
                    cbxReaderList.SelectedIndex = 0;
                }
            }
        }

        private void cbxReaderList_DropDown(object sender, EventArgs e)
        {
            ReaderList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReaderList();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReaderList();

            byteDataView.OnCellClick += OnCellClick;
            byteDataView.OnRWEClick += OnRWEClick;
            byteDataView.verticalScrollBar.Scroll += dataView_Scroll;
            byteDataView.OnCellDblClick += OnCellDblClick;

            byteAttrView.OnCellClick += OnCellClick;
            byteAttrView.OnRWEClick += OnRWEClick;
            byteAttrView.verticalScrollBar.Scroll += attrView_Scroll;

            this.WindowState = FormWindowState.Maximized;
        }

        private void btnRdrConnect_Click(object sender, EventArgs e)
        {
            if (mReader.IsConnected)
            {
                mReader.Disconnect();
            }

            String readerName = cbxReaderList.Text;

            try
            {
                string atr = "";
                mReader.Connect(readerName, ref atr);
                // bool result = mReader.Reset(SyncCardReader.ResetType.ColdReset, ref atr);
                if (mReader.IsConnected)
                {
                    statusLabel.Text = "Connected to " + readerName;
                    statusLabel.ForeColor = Color.Green;

                    LogMessage("Connected to " + readerName);
                    LogMessage("ATR: " + atr);

                    mCardApi = CardReaderFactory.CreateCardReader(readerName, mReader);
                    DetectCard();
                    return;
                }
            }
            catch (Exception ex)
            {
            }

            statusLabel.Text = "Failed to connect " + readerName;
            statusLabel.ForeColor = Color.Red;
            LogMessage("Failed to connect '" + readerName + "'\r\n " + mReader.getErrorMessage());
        }

        private void btnReadByteData_Click(object sender, EventArgs e)
        {
            if (!checkConnection())
                return;

            if (mCardApi.LoadAll())
            {
                byteDataView.Data = mCardApi.ByteData;
                byteDataView.ProtectedData = mCardApi.AttrData;
                byteDataView.DisplayMode = ByteViewerControl.ShowMode.DATA;
                byteDataView.updateView();

                byteAttrView.Data = mCardApi.ByteData;
                byteAttrView.ProtectedData = mCardApi.AttrData;
                byteAttrView.DisplayMode = ByteViewerControl.ShowMode.ATTR;
                byteAttrView.updateView();
            }
        }

        private void tabCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCardType.SelectedIndex == 0)
            {
                mCardType = CardType.SLE4428;
                // mCardApi.SetCardType(CardType.SLE4428);
            }
            else if (tabCardType.SelectedIndex == 1)
            {
                mCardType = CardType.SLE4442;
                // mCardApi.SetCardType(CardType.SLE4442);
            }
        }

        private void LogMessage(string message)
        {
            if (message.Length > 128)
            {
                message = message.Substring(0, 128) + $"..({message.Length})";
            }
            txtLog.AppendText(message + Environment.NewLine);
            txtLog.SelectionStart = txtLog.TextLength; // 将光标移动到文本末尾
            txtLog.SelectionLength = 0; // 清除选择
            txtLog.ScrollToCaret(); // 滚动到光标位置
        }

        private void btnAuthPSC_Click(object sender, EventArgs e)
        {
            if (!checkConnection())
                return;

            if (mCardApi.AuthPSC(txtPSC.Text))
            {
                LogMessage("sle4428 PCS verfied.");
                statusLabel.Text = "sle4428 PCS verfied.";
                statusLabel.ForeColor = Color.Green;

                boldAuthButton(Color.Green);
            }
            else
            {
                LogMessage("sle4428 PCS verfy failed.");
                statusLabel.Text = "sle4428 PCS verfy failed.";
                statusLabel.ForeColor = Color.Red;

                boldAuthButton(Color.Red);
            }            
        }

        private void boldAuthButton(Color foreColor)
        {
            if (!btnAuthPSC.Font.Bold)
            {
                btnAuthPSC.Font = new Font(btnAuthPSC.Font.FontFamily,
                                        btnAuthPSC.Font.Size, btnAuthPSC.Font.Style | FontStyle.Bold);
            }

            btnAuthPSC.ForeColor = foreColor;
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            byteDataView.updateView();
            byteAttrView.updateView();

            Debug.Print("Client " + ClientSize.Height + " " + ClientSize.Width);
        }

        private void dataView_Scroll(object sender, ScrollEventArgs e)
        {
            byteAttrView.verticalScrollBar.Value = byteDataView.verticalScrollBar.Value;
            byteAttrView.Refresh();
        }

        private void attrView_Scroll(object sender, ScrollEventArgs e)
        {
            byteDataView.verticalScrollBar.Value = byteAttrView.verticalScrollBar.Value;
            byteDataView.Refresh();
        }

        private void DetectCard ()
        {
            if (!checkConnection())
                return;

            byte[] rapdu = null;
            if (mCardApi.ReadData(0x0000, ref rapdu, 0x1b))
            {
                CARD_TYPE cardType = CARD_TYPE.SLE_4428;
                bool result = Sle44xx.showSLE44xxCardInfo(rapdu, ref cardType, LogMessage);
                if (result)
                {
                    if (cardType == CARD_TYPE.SLE_4428)
                    {
                        mCardApi.SetCardType(CardType.SLE4428);
                    }
                    else if (cardType == CARD_TYPE.SLE_4442)
                    {
                        mCardApi.SetCardType(CardType.SLE4442);
                    }
                }
            }
        }

        private void btnDetectCard_Click(object sender, EventArgs e)
        {
            DetectCard();
        }

        private void btnChangePSC_Click(object sender, EventArgs e)
        {

        }

        private void OnRWEClick(object ctrl, RWEOperation operation, int row)
        {
            ushort addr = (ushort)(row * 16);
            byte[] data = null;

            if (ctrl == byteDataView)
            {
                if (operation == RWEOperation.READ)
                {
                    if (mCardApi.LoadDataFromIcc(addr, 16))
                    {
                        byteDataView.Refresh();
                    }
                }
                else if (operation == RWEOperation.WRITE)
                {
                    if (mCardApi.SaveDataToIcc(addr, 16))
                    {
                        byteDataView.Refresh();
                    }
                }
                else if (operation == RWEOperation.EDIT)
                {
                    OnEditData(row);
                }
            }
            else if (ctrl == byteAttrView)
            {
                if (operation == RWEOperation.READ)
                {
                    if (mCardApi.LoadAttrFromIcc(addr, 16))
                    {
                        byteDataView.Refresh();
                        byteAttrView.Refresh();
                    }
                }
                else if (operation == RWEOperation.WRITE)
                {
                    if (mCardApi.SaveAttrToIcc(addr, 16))
                    {
                        byteDataView.Refresh();
                        byteAttrView.Refresh();
                    }
                }
            }
            Debug.Print($"object {ctrl} clicked on row {row} with {operation}");
        }

        private void OnCellClick(object ctrl, int row, int col)
        {
            if (ctrl == byteDataView)
            {
                //Debug.Print($"Cell clicked data, row {row}, column {col}");
            }
            else if (ctrl == byteAttrView)
            {
                //Debug.Print($"Cell clicked attr, row {row}, column {col}");
                if (mCardApi.ToggleProtectBit(row, col))
                {
                    byteDataView.Refresh();
                    byteAttrView.Refresh();
                }
            }
        }

        private void OnEditData(int row)
        {
            ushort addr = (ushort)(row * 16);

            using (frmEdit editUI = new frmEdit())
            {
                editUI.StartPosition = FormStartPosition.CenterParent;
                Buffer.BlockCopy(byteDataView.Data, addr, editUI.mData, 0, 16);
                editUI.updateShow();

                DialogResult result = editUI.ShowDialog(this);

                if (result == DialogResult.OK)
                {// take new data from dialog
                    Buffer.BlockCopy(editUI.mData, 0, byteDataView.Data, addr, 16);
                    byteDataView.Refresh();
                }
            }
        }

        private void OnCellDblClick(object ctrl, int row, int col)
        {
            if (ctrl == byteDataView)
            {
                OnEditData(row);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            byteDataView.updateView();
            byteAttrView.updateView();
        }

        private bool checkConnection()
        {
            if (!mReader.IsConnected)
            {
                LogMessage("reader is not connect.");
                return false;
            }
            if (mCardApi == null)
            {
                LogMessage("please connect sle44xx card first.");
                return false;
            }

            return true;
        }


    }
}
