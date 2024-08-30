namespace SLE44xxTool
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDetectCard = new System.Windows.Forms.Button();
            this.tabPageSLE4442 = new System.Windows.Forms.TabPage();
            this.btnChangePSC = new System.Windows.Forms.Button();
            this.btnAuthPSC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPSC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnReadByteData = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.byteDataView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.byteAttrView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.tabPageSLE4428 = new System.Windows.Forms.TabPage();
            this.tabCardType = new System.Windows.Forms.TabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnRdrConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxReaderList = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblPanel.SuspendLayout();
            this.tabPageSLE4428.SuspendLayout();
            this.tabCardType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDetectCard
            // 
            this.btnDetectCard.Location = new System.Drawing.Point(902, 9);
            this.btnDetectCard.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDetectCard.Name = "btnDetectCard";
            this.btnDetectCard.Size = new System.Drawing.Size(148, 32);
            this.btnDetectCard.TabIndex = 19;
            this.btnDetectCard.Text = "Detect Card";
            this.btnDetectCard.UseVisualStyleBackColor = true;
            this.btnDetectCard.Click += new System.EventHandler(this.btnDetectCard_Click);
            // 
            // tabPageSLE4442
            // 
            this.tabPageSLE4442.Location = new System.Drawing.Point(4, 25);
            this.tabPageSLE4442.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE4442.Name = "tabPageSLE4442";
            this.tabPageSLE4442.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE4442.Size = new System.Drawing.Size(1344, 465);
            this.tabPageSLE4442.TabIndex = 1;
            this.tabPageSLE4442.Text = "SLE4442";
            this.tabPageSLE4442.UseVisualStyleBackColor = true;
            // 
            // btnChangePSC
            // 
            this.btnChangePSC.Location = new System.Drawing.Point(315, 24);
            this.btnChangePSC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnChangePSC.Name = "btnChangePSC";
            this.btnChangePSC.Size = new System.Drawing.Size(94, 32);
            this.btnChangePSC.TabIndex = 3;
            this.btnChangePSC.Text = "Change";
            this.btnChangePSC.UseVisualStyleBackColor = true;
            this.btnChangePSC.Click += new System.EventHandler(this.btnChangePSC_Click);
            // 
            // btnAuthPSC
            // 
            this.btnAuthPSC.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuthPSC.Location = new System.Drawing.Point(199, 24);
            this.btnAuthPSC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAuthPSC.Name = "btnAuthPSC";
            this.btnAuthPSC.Size = new System.Drawing.Size(94, 32);
            this.btnAuthPSC.TabIndex = 2;
            this.btnAuthPSC.Text = "Auth";
            this.btnAuthPSC.UseVisualStyleBackColor = true;
            this.btnAuthPSC.Click += new System.EventHandler(this.btnAuthPSC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = " PSC:";
            // 
            // txtPSC
            // 
            this.txtPSC.Location = new System.Drawing.Point(91, 27);
            this.txtPSC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPSC.Name = "txtPSC";
            this.txtPSC.Size = new System.Drawing.Size(82, 27);
            this.txtPSC.TabIndex = 0;
            this.txtPSC.Text = "FF FF";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePSC);
            this.groupBox1.Controls.Add(this.btnAuthPSC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPSC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(1338, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " PSC Security ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 13, 0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Show in ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(306, 13);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "ASCII";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(389, 13);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 24);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "HEX";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnReadByteData
            // 
            this.btnReadByteData.Location = new System.Drawing.Point(3, 7);
            this.btnReadByteData.Margin = new System.Windows.Forms.Padding(3, 7, 3, 5);
            this.btnReadByteData.Name = "btnReadByteData";
            this.btnReadByteData.Size = new System.Drawing.Size(215, 32);
            this.btnReadByteData.TabIndex = 0;
            this.btnReadByteData.Text = "Read Data Bytes";
            this.btnReadByteData.UseVisualStyleBackColor = true;
            this.btnReadByteData.Click += new System.EventHandler(this.btnReadByteData_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnReadByteData);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(574, 38);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tblPanel
            // 
            this.tblPanel.AutoSize = true;
            this.tblPanel.ColumnCount = 2;
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanel.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tblPanel.Controls.Add(this.byteDataView, 0, 1);
            this.tblPanel.Controls.Add(this.byteAttrView, 1, 1);
            this.tblPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanel.Location = new System.Drawing.Point(3, 77);
            this.tblPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tblPanel.Name = "tblPanel";
            this.tblPanel.RowCount = 2;
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanel.Size = new System.Drawing.Size(1338, 383);
            this.tblPanel.TabIndex = 1;
            this.tblPanel.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            // 
            // byteDataView
            // 
            this.byteDataView.BackColor = System.Drawing.SystemColors.Window;
            this.byteDataView.BytesPerRow = 16;
            this.byteDataView.Caption = "Byte Data Viewer";
            this.byteDataView.CardDataLength = 0;
            this.byteDataView.Data = null;
            this.byteDataView.DisplayMode = SLE44xxTool.ExtControl.ByteViewerControl.ShowMode.DATA;
            this.byteDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteDataView.Location = new System.Drawing.Point(3, 52);
            this.byteDataView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byteDataView.Name = "byteDataView";
            this.byteDataView.ProtectedData = null;
            this.byteDataView.Size = new System.Drawing.Size(663, 327);
            this.byteDataView.TabIndex = 5;
            // 
            // byteAttrView
            // 
            this.byteAttrView.BackColor = System.Drawing.SystemColors.Window;
            this.byteAttrView.BytesPerRow = 16;
            this.byteAttrView.Caption = "Byte Attr Viewer";
            this.byteAttrView.CardDataLength = 0;
            this.byteAttrView.Data = null;
            this.byteAttrView.DisplayMode = SLE44xxTool.ExtControl.ByteViewerControl.ShowMode.ATTR;
            this.byteAttrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteAttrView.Location = new System.Drawing.Point(672, 52);
            this.byteAttrView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byteAttrView.Name = "byteAttrView";
            this.byteAttrView.ProtectedData = null;
            this.byteAttrView.Size = new System.Drawing.Size(663, 327);
            this.byteAttrView.TabIndex = 6;
            // 
            // tabPageSLE4428
            // 
            this.tabPageSLE4428.Controls.Add(this.tblPanel);
            this.tabPageSLE4428.Controls.Add(this.groupBox1);
            this.tabPageSLE4428.Location = new System.Drawing.Point(4, 25);
            this.tabPageSLE4428.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE4428.Name = "tabPageSLE4428";
            this.tabPageSLE4428.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE4428.Size = new System.Drawing.Size(1344, 465);
            this.tabPageSLE4428.TabIndex = 0;
            this.tabPageSLE4428.Text = "SLE4428";
            this.tabPageSLE4428.UseVisualStyleBackColor = true;
            // 
            // tabCardType
            // 
            this.tabCardType.Controls.Add(this.tabPageSLE4428);
            this.tabCardType.Controls.Add(this.tabPageSLE4442);
            this.tabCardType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCardType.ItemSize = new System.Drawing.Size(96, 21);
            this.tabCardType.Location = new System.Drawing.Point(0, 0);
            this.tabCardType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabCardType.Name = "tabCardType";
            this.tabCardType.SelectedIndex = 0;
            this.tabCardType.Size = new System.Drawing.Size(1352, 494);
            this.tabCardType.TabIndex = 1;
            this.tabCardType.SelectedIndexChanged += new System.EventHandler(this.tabCardType_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabCardType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(1352, 625);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 18;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1352, 124);
            this.txtLog.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(59, 20);
            this.statusLabel.Text = "Ready!";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 677);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1352, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnRdrConnect
            // 
            this.btnRdrConnect.Location = new System.Drawing.Point(722, 9);
            this.btnRdrConnect.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRdrConnect.Name = "btnRdrConnect";
            this.btnRdrConnect.Size = new System.Drawing.Size(148, 32);
            this.btnRdrConnect.TabIndex = 16;
            this.btnRdrConnect.Text = "Connect Card";
            this.btnRdrConnect.UseVisualStyleBackColor = true;
            this.btnRdrConnect.Click += new System.EventHandler(this.btnRdrConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(540, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 32);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "List Reader";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxReaderList
            // 
            this.cbxReaderList.FormattingEnabled = true;
            this.cbxReaderList.Location = new System.Drawing.Point(22, 11);
            this.cbxReaderList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbxReaderList.MaxDropDownItems = 16;
            this.cbxReaderList.Name = "cbxReaderList";
            this.cbxReaderList.Size = new System.Drawing.Size(497, 28);
            this.cbxReaderList.TabIndex = 14;
            this.cbxReaderList.DropDown += new System.EventHandler(this.cbxReaderList_DropDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(8);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1352, 52);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 703);
            this.Controls.Add(this.btnDetectCard);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRdrConnect);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbxReaderList);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "SLE44xxTool - 1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tblPanel.ResumeLayout(false);
            this.tabPageSLE4428.ResumeLayout(false);
            this.tabPageSLE4428.PerformLayout();
            this.tabCardType.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetectCard;
        private System.Windows.Forms.TabPage tabPageSLE4442;
        private System.Windows.Forms.Button btnChangePSC;
        private System.Windows.Forms.Button btnAuthPSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPSC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnReadByteData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblPanel;
        private System.Windows.Forms.TabPage tabPageSLE4428;
        private System.Windows.Forms.TabControl tabCardType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnRdrConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbxReaderList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ExtControl.ByteViewerControl byteDataView;
        private ExtControl.ByteViewerControl byteAttrView;
    }
}

