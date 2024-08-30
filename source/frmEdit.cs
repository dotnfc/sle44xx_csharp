using SLE44xxTool.MemoryCard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SLE44xxTool
{
    public partial class frmEdit : Form
    {
        public byte[] mData;
        private string mStrInput;

        public frmEdit()
        {
            InitializeComponent();

            mData = new byte[16];
            for (int i = 0; i < 16; i ++)
            {
                mData[i] = (byte)i;
            }

            updateShow();
        }

        public void updateShow ()
        {
            string hexString = BitConverter.ToString(mData, 0, 16);
            txtDataHex.Text = hexString.Replace("-", " ");
            mStrInput = txtDataHex.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strData;
            if (fmtAscii.Checked)
            {
                // convert ascii to hex
                string strMsg = txtDataHex.Text;
                strMsg = strMsg.PadRight(16, ' ').Substring(0, 16);
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strMsg);

                string hexString = BitConverter.ToString(bytes, 0, 16);
                strData = hexString.Replace("-", "");
            }
            else
            {
                strData = txtDataHex.Text.Replace(" ", "");
            }

            // Hex only
            string pattern = @"^[0-9A-Fa-f]+$";
            if(! Regex.IsMatch(strData, pattern) )
            {
                MessageBox.Show("Invalid input, retry.");
                this.DialogResult = DialogResult.None;
                return;
            }

            byte[] byData = Utils.HexStringToByteArray(strData);

            Array.Clear(mData, 0, 16);
            Array.Copy(byData, 0, mData, 0, byData.Length);

            this.DialogResult = DialogResult.OK;
        }

        private static string ConvertHexToPrintableString(string hexString)
        {
            StringBuilder printableString = new StringBuilder();

            hexString = hexString.Replace(" ", "");

            // 确保字符串长度是偶数
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string length must be even.");
            }

            for (int i = 0; i < hexString.Length; i += 2)
            {
                // 从字符串中提取两个字符作为一个字节的十六进制数
                string hexByte = hexString.Substring(i, 2);

                // 将十六进制字符串转换为字节
                byte b = Convert.ToByte(hexByte, 16);

                // 检查是否是可打印的ASCII字符
                if (b >= 32 && b <= 126)
                {
                    printableString.Append((char)b);
                }
                else
                {
                    printableString.Append('?');
                }
            }

            return printableString.ToString();
        }

        private void fmtAscii_CheckedChanged(object sender, EventArgs e)
        {
            if (fmtAscii.Checked)
            {
                mStrInput = txtDataHex.Text.Replace(" ", "");

                if (mStrInput.Length % 2 != 0)
                {
                    MessageBox.Show("Invalid input, retry.");
                    return;
                }

                txtDataHex.Text = ConvertHexToPrintableString(mStrInput);
            }
        }

        private void fmtHex_CheckedChanged(object sender, EventArgs e)
        {
            if (fmtHex.Checked)
            {
                lblLength.Text = " ";

                string strMsg = txtDataHex.Text;
                strMsg = strMsg.PadRight(16, ' ').Substring(0, 16);
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(strMsg);

                string hexString = BitConverter.ToString(bytes, 0, 16);
                txtDataHex.Text = hexString.Replace("-", " ");
            }
        }

        private void btnEditReload_Click(object sender, EventArgs e)
        {
            fmtAscii.Checked = false;
            fmtHex.Checked = true;
            updateShow();
        }

        private void txtDataHex_TextChanged(object sender, EventArgs e)
        {
            if (fmtAscii.Checked)
            {
                int textLength = txtDataHex.Text.Length;
                lblLength.Text = " " + textLength.ToString();

                if (textLength > 16)
                {
                    txtDataHex.Text = txtDataHex.Text.Substring(0, 16);
                    txtDataHex.SelectionStart = txtDataHex.Text.Length;
                }
            }
        }
    }
}
