// MIT License
// 
// Copyright (c) 2024 dotnfc
// 

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SLE44xxTool.ExtControl
{
    public enum RWEOperation
    {
        READ, WRITE, EDIT
    }

    public partial class ByteViewerControl : UserControl
    {
        public int cardDataLength = 0;
        private byte[] data;
        private bool[] protectedData;
        private int bytesPerRow = 16; // 每行显示16个字节
        private int cellWidth;
        private int addressWidth;
        private int rowHeight;
        private ShowMode showMode = ShowMode.DATA;
        private int selectedRow = -1; // 记录选中的行，默认没有选中行

        public VScrollBar verticalScrollBar;
        private HScrollBar horizontalScrollBar;

        private string _text = "Byte Viewer";

        private string mIconRead = "\uE11C";
        private string mIconWrite = "\uE118";
        private string mIconEdit = "\uF742";
        private string mIconLocked = "\uE1F6";
        private string mIconUnLocked = "";

        // 公共 Text 属性
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Sets the text displayed in the control.")]
        public string Caption
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate(); // 触发重绘
            }
        }

        public enum ShowMode
        {
            DATA,
            ATTR
        }

        // 回调事件
        public event Action<object, RWEOperation, int> OnRWEClick;
        public event Action<object, int, int> OnCellClick;
        public event Action<object, int, int> OnCellDblClick;

        public ByteViewerControl()
        {
            InitializeComponent();
            
            this.Size = new Size(100, 100); // 设定控件的默认大小

            this.DoubleBuffered = true;
            this.MouseDoubleClick += ByteViewerControl_MouseDoubleClick;
            this.MouseDown += ByteViewerControl_MouseDown;
            this.MouseWheel += ByteViewerControl_MouseWheel;

            // 初始化滚动条
            verticalScrollBar = new VScrollBar
            {
                Dock = DockStyle.Right,
                Minimum = 0,
                LargeChange = 1,
                SmallChange = 1,
                Maximum = 100,
                Visible = false
            };
            verticalScrollBar.Scroll += VerticalScrollBar_Scroll;
            this.Controls.Add(verticalScrollBar);

            horizontalScrollBar = new HScrollBar
            {
                Dock = DockStyle.Bottom,
                Minimum = 0,
                LargeChange = 1,
                SmallChange = 1,
                Maximum = 100,
                Visible = false
            };
            horizontalScrollBar.Scroll += HorizontalScrollBar_Scroll;
            this.Controls.Add(horizontalScrollBar);
        }

        public byte[] Data
        {
            get => data;
            set
            {
                data = value;
                Invalidate(); // 数据改变时重新绘制
            }
        }

        public bool[] ProtectedData
        {
            get => protectedData;
            set
            {
                protectedData = value;
                Invalidate(); // 保护数据改变时重新绘制
            }
        }

        public int CardDataLength 
        { 
            get => cardDataLength; 
            set => cardDataLength = value;
        }

        public void updateView()
        {
            if (showMode == ShowMode.DATA)
            {
                cardDataLength = (data != null) ? data.Length : 0;
            }
            if (showMode == ShowMode.ATTR)
            {
                cardDataLength = (protectedData != null) ? protectedData.Length : 0;
            }

            AdjustScrollBars();
            Refresh();
        }

        public int BytesPerRow
        {
            get => bytesPerRow;
            set
            {
                bytesPerRow = value;
                AdjustScrollBars();
                Invalidate(); // 每行字节数改变时重新绘制
            }
        }

        public ShowMode DisplayMode
        {
            get => showMode;
            set
            {
                showMode = value;
                Invalidate(); // 显示模式改变时重新绘制
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (showMode == ShowMode.DATA)
            {
                if (data == null) return;
            }
            if (showMode == ShowMode.ATTR)
            {
                if (protectedData == null) return;
            }

            // bool isDesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            if (this.DesignMode)
            {
                // 设计时渲染
                e.Graphics.DrawRectangle(Pens.Gray, this.ClientRectangle);
                TextRenderer.DrawText(e.Graphics, "Design Time", this.Font, this.ClientRectangle, Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                return;
            }

            Graphics g = e.Graphics;
            Font font = new Font("Consolas", 10);
            Font attrFont = new Font("Segoe MDL2 Assets", 10); //  
            //Font attrFont = new Font("Wingdings", 10); // •
            Brush textBrush = Brushes.Black;
            Brush headerBrush = new SolidBrush(Color.FromArgb(232, 232, 232));
            Brush addressBrush = new SolidBrush(Color.FromArgb(232, 232, 232)); // 灰色背景
            Brush selectedRowBrush = new SolidBrush(Color.FromArgb(220, 220, 220)); // 浅灰色背景
            Pen linePen = Pens.Gray;
            Brush protectedBrush = Brushes.Red;
            Brush attrBrush = Brushes.Black;

            int rowCount = (cardDataLength + bytesPerRow - 1) / bytesPerRow;
            
            cellWidth = GetCellWidth();
            addressWidth = GetAddressWidth();
            rowHeight = GetRowHeight();
            int fullRowHeigth = (rowHeight + 1) * rowCount;

            // 绘制表头
            using (Font boldFont = new Font(font, FontStyle.Bold))
            {
                g.FillRectangle(headerBrush, 0, 0, Width, rowHeight);
                g.DrawString("Addr", boldFont, textBrush, 0, 4);
                for (int i = 0; i < bytesPerRow; i++)
                {
                    string colHeaderText = i.ToString("D");
                    SizeF colHeaderSize = g.MeasureString(colHeaderText, boldFont);
                    float x = addressWidth + i * cellWidth + (cellWidth - colHeaderSize.Width) / 2;
                    float y = (rowHeight - colHeaderSize.Height) / 2;
                    g.DrawString(colHeaderText, boldFont, textBrush, x, y + 2);
                }
                if (showMode == ShowMode.DATA)
                    g.DrawLine(linePen, 0, rowHeight, addressWidth + bytesPerRow * cellWidth + 3 * cellWidth, rowHeight);
                else
                    g.DrawLine(linePen, 0, rowHeight, addressWidth + bytesPerRow * cellWidth + 2 * cellWidth, rowHeight);

                int rColX = addressWidth + bytesPerRow * cellWidth;
                int wColX = rColX + cellWidth;
                int eColX = wColX + cellWidth;
                
                g.DrawString("R", boldFont, Brushes.Black, rColX + (cellWidth - g.MeasureString("R", boldFont).Width) / 2, 2);
                g.DrawString("W", boldFont, Brushes.Black, wColX + (cellWidth - g.MeasureString("W", boldFont).Width) / 2, 2);

                if (showMode == ShowMode.DATA)
                    g.DrawString("E", boldFont, Brushes.Black, eColX + (cellWidth - g.MeasureString("E", boldFont).Width) / 2, 2);
                
            }

            // 绘制数据行
            int visibleStartRow = verticalScrollBar.Value / rowHeight;
            int visibleEndRow = Math.Min(rowCount - 1, (verticalScrollBar.Value + ClientSize.Height - rowHeight) / rowHeight);

            for (int row = visibleStartRow; row <= visibleEndRow; row++)
            {
                int offset = row * bytesPerRow;
                int y = (row - visibleStartRow) * rowHeight + rowHeight;

                // first row, address
                g.FillRectangle(addressBrush, 0, y + 1, addressWidth, rowHeight - 2); // 地址列背景色
                g.DrawString(offset.ToString("X4"), font, Brushes.Black, 0, y + 4);

                // select row
                if(row == selectedRow)
                {
                    g.FillRectangle(selectedRowBrush, addressWidth, y + 1, addressWidth + (bytesPerRow + 2) * cellWidth, rowHeight - 1);
                }

                for (int col = 0; col < bytesPerRow; col++)
                {
                    int index = offset + col;
                    
                    Rectangle cellRect = new Rectangle(addressWidth + col * cellWidth, y, cellWidth, rowHeight);

                    if (showMode == ShowMode.DATA)
                    {
                        if (index < cardDataLength)
                        {
                            string cellText = index < cardDataLength ? data[index].ToString("X2") : "  ";

                            if ((protectedData != null) && (index < cardDataLength) && (!protectedData[index]))
                            {
                                g.FillRectangle(protectedBrush, cellRect); // 保护单元格背景色
                            }
                            g.DrawString(cellText, font, textBrush, addressWidth + col * cellWidth + 2, y + 4);
                        }
                    }
                    else if (showMode == ShowMode.ATTR)
                    {
                        string attrText = index < cardDataLength && protectedData[index] ? mIconUnLocked : mIconLocked;
                        TextRenderer.DrawText(g, attrText, attrFont, cellRect, Color.Red, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }

                // 绘制 R W E
                {
                    Point ptRead = new Point(addressWidth + bytesPerRow * cellWidth + 4, y + 4);
                    Point ptWrite = new Point(addressWidth + bytesPerRow * cellWidth + cellWidth + 4, y + 4);
                    Point ptEdit = new Point(addressWidth + bytesPerRow * cellWidth + cellWidth + cellWidth + 4, y + 4);

                    TextRenderer.DrawText(g, mIconRead, attrFont, ptRead, Color.Blue, 0);
                    TextRenderer.DrawText(g, mIconWrite, attrFont, ptWrite, Color.Blue, 0);
                    if (showMode == ShowMode.DATA)
                        TextRenderer.DrawText(g, mIconEdit, attrFont, ptEdit, Color.Blue, 0);
                }

                // 绘制行分隔线（仅限有效数据区域）
                if (showMode == ShowMode.DATA)
                    g.DrawLine(linePen, 0, y + rowHeight, addressWidth + bytesPerRow * cellWidth + 3 * cellWidth, y + rowHeight);
                else
                    g.DrawLine(linePen, 0, y + rowHeight, addressWidth + bytesPerRow * cellWidth + 2 * cellWidth, y + rowHeight);
            }

            fullRowHeigth = (visibleEndRow - visibleStartRow + 1) * rowHeight + rowHeight;

            // 绘制列分隔线（仅限有效数据区域）
            int ext = (showMode == ShowMode.DATA) ? 3 : 2;
            for (int i = 0; i <= bytesPerRow + ext; i++)
            {
                g.DrawLine(linePen, addressWidth + i * cellWidth, 0, addressWidth + i * cellWidth, fullRowHeigth);
            }
        }

        private void AdjustScrollBars()
        {
            if ((data == null) && protectedData == null) return;

            rowHeight = GetRowHeight();
            int rowCount = cardDataLength / bytesPerRow + 3;
            int totalHeight = rowCount * rowHeight;

            // Adjust vertical scrollbar
            if (totalHeight > ClientSize.Height)
            {
                verticalScrollBar.Maximum = totalHeight;
                verticalScrollBar.LargeChange = ClientSize.Height;
                verticalScrollBar.SmallChange = rowHeight;
                verticalScrollBar.Visible = true;
            }
            else
            {
                verticalScrollBar.Visible = false;
            }

            // Adjust horizontal scrollbar
            int totalWidth = addressWidth + bytesPerRow * cellWidth + 2 * cellWidth;
            if (totalWidth > ClientSize.Width)
            {
                horizontalScrollBar.Maximum = totalWidth - ClientSize.Width;
                horizontalScrollBar.LargeChange = ClientSize.Width;
                horizontalScrollBar.SmallChange = cellWidth;
                horizontalScrollBar.Visible = true;
            }
            else
            {
                horizontalScrollBar.Visible = false;
            }

            // Update the control layout to ensure proper scrollbars positioning
            this.Invalidate();
        }

        private void VerticalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate(); // 滚动时重新绘制
        }

        private void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate(); // 滚动时重新绘制
        }

        private void ByteViewerControl_MouseWheel(object sender, MouseEventArgs e)
        {
            int vscrollValue = verticalScrollBar.Value;
            if (e.Delta > 0)
            {
                if (vscrollValue > verticalScrollBar.Minimum)
                    vscrollValue -= verticalScrollBar.SmallChange;
            }
            else
            {
                if (vscrollValue < verticalScrollBar.Maximum - verticalScrollBar.LargeChange + 1)
                    vscrollValue += verticalScrollBar.SmallChange;
            }

            if (vscrollValue < 0)
            {
                vscrollValue = 0;
            }
            verticalScrollBar.Value = vscrollValue;

            this.Invalidate(true);
        }

        private void ByteViewerControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (data == null) return;

            this.Focus();

            int row = (verticalScrollBar.Value + e.Y - rowHeight) / rowHeight;
            int col = (e.X - addressWidth) / cellWidth;

            if (e.X < addressWidth)
            {
                selectedRow = row;
                Invalidate();
            }
            if (row < 0 || col < 0 || row >= (cardDataLength + bytesPerRow + 3 - 1) / (bytesPerRow + 3)) return;

            if (e.X >= addressWidth && e.X < addressWidth + bytesPerRow * cellWidth)
            {
                int rowCount = (cardDataLength + bytesPerRow - 1) / bytesPerRow;
                rowHeight = GetRowHeight();
                int fullRowHeigth = (rowHeight + 1) * rowCount;

                if (e.Y >= rowHeight && e.Y < fullRowHeigth)
                {
                    // Double Clicked on a cell
                    OnCellDblClick?.Invoke(this, row, col);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (IsMouseInSpecialArea(e.Location))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsMouseInSpecialArea(Point pt)
        {
            if (data == null) return false;

            this.Focus();

            int row = (verticalScrollBar.Value + pt.Y - rowHeight) / rowHeight;
            int col = (pt.X - addressWidth) / cellWidth;

            if (row < 0 || col < 0 || row >= (cardDataLength + bytesPerRow + 3 - 1) / (bytesPerRow + 3)) 
                return false;

            if ((pt.Y >= rowHeight) && (pt.X >= addressWidth + bytesPerRow * cellWidth))
            {
                // Clicked on R W E columns
                if (pt.X >= addressWidth + bytesPerRow * cellWidth && pt.X < addressWidth + bytesPerRow * cellWidth + cellWidth)
                {
                    return true;
                }
                else if ((pt.X >= addressWidth + bytesPerRow * cellWidth + cellWidth) && (pt.X < addressWidth + bytesPerRow * cellWidth + 2 * cellWidth))
                {
                    return true;
                }
                else if (pt.X >= addressWidth + bytesPerRow * cellWidth + 2 * cellWidth)
                {
                    if ( pt.X < addressWidth + bytesPerRow * cellWidth + 3 * cellWidth )
                        if (showMode == ShowMode.DATA)
                            return true;
                }
            }

            return false;
        }

        private void ByteViewerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (data == null) return;

            this.Focus();

            int row = (verticalScrollBar.Value + e.Y - rowHeight) / rowHeight;
            int col = (e.X - addressWidth) / cellWidth;

            if (e.X < addressWidth)
            {
                selectedRow = row;
                Invalidate();
            }
            if (row < 0 || col < 0 || row >= (cardDataLength + bytesPerRow + 3 - 1) / (bytesPerRow + 3)) return;

            if (e.X >= addressWidth && e.X < addressWidth + bytesPerRow * cellWidth)
            {
                int rowCount = (cardDataLength + bytesPerRow - 1) / bytesPerRow;
                rowHeight = GetRowHeight();
                int fullRowHeigth = (rowHeight + 1) * rowCount;

                if (e.Y >= rowHeight && e.Y < fullRowHeigth)
                {
                    // Clicked on a cell
                    OnCellClick?.Invoke(this, row, col);
                }
            }
            else if ( (e.Y >= rowHeight) && (e.X >= addressWidth + bytesPerRow * cellWidth) )
            {
                // Clicked on R W E columns
                if (e.X >= addressWidth + bytesPerRow * cellWidth && e.X < addressWidth + bytesPerRow * cellWidth + cellWidth)
                {
                    OnRWEClick?.Invoke(this, RWEOperation.READ, row);
                }
                else if ((e.X >= addressWidth + bytesPerRow * cellWidth + cellWidth) && (e.X < addressWidth + bytesPerRow * cellWidth + 2 * cellWidth))
                {
                    OnRWEClick?.Invoke(this, RWEOperation.WRITE, row);
                }
                else if (e.X >= addressWidth + bytesPerRow * cellWidth + 2 * cellWidth)
                {
                    if (e.X < addressWidth + bytesPerRow * cellWidth + 3 * cellWidth)
                        if (showMode == ShowMode.DATA)
                            OnRWEClick?.Invoke(this, RWEOperation.EDIT, row);
                }
            }
        }

        private int GetCellWidth()
        {
            using (Graphics g = CreateGraphics())
            {
                return g.MeasureString("FF", Font).ToSize().Width + 10; // Include padding
                // return (int)g.MeasureString(sampleText, new Font("Consolas", 10)).Width;
            }
        }

        private int GetAddressWidth()
        {
            using (Graphics g = CreateGraphics())
            {
                return g.MeasureString("FFFF", Font).ToSize().Width + 10; // Include padding
                // return (int)g.MeasureString(sampleText, new Font("Consolas", 10)).Width;
            }
        }

        private int GetRowHeight()
        {
            return Font.Height + 4;
        }

        private void DrawCenteredText(Graphics g, string text, Font font, Brush brush, int x, int y)
        {
            SizeF textSize = g.MeasureString(text, font);
            g.DrawString(text, font, brush, x + (cellWidth - textSize.Width) / 2, y + (rowHeight - textSize.Height) / 2);
        }
    }
}
