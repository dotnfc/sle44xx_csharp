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
            this.btnChangePSC = new System.Windows.Forms.Button();
            this.btnAuthPSC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPSC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetErrCounter = new System.Windows.Forms.Button();
            this.btnReadByteData = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.byteDataView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.byteAttrView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.tabPageSLE44xx = new System.Windows.Forms.TabPage();
            this.tabCardType = new System.Windows.Forms.TabControl();
            this.tabPageI2C = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.byteViewerControl1 = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.byteViewerControl2 = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnRdrConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxReaderList = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblPanel.SuspendLayout();
            this.tabPageSLE44xx.SuspendLayout();
            this.tabCardType.SuspendLayout();
            this.tabPageI2C.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.btnGetErrCounter);
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
            // btnGetErrCounter
            // 
            this.btnGetErrCounter.Location = new System.Drawing.Point(431, 24);
            this.btnGetErrCounter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGetErrCounter.Name = "btnGetErrCounter";
            this.btnGetErrCounter.Size = new System.Drawing.Size(134, 32);
            this.btnGetErrCounter.TabIndex = 4;
            this.btnGetErrCounter.Text = "GetErrCounter";
            this.btnGetErrCounter.UseVisualStyleBackColor = true;
            this.btnGetErrCounter.Click += new System.EventHandler(this.btnGetErrCounter_Click);
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
            this.tblPanel.Size = new System.Drawing.Size(1338, 372);
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
            this.byteDataView.Size = new System.Drawing.Size(663, 316);
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
            this.byteAttrView.Size = new System.Drawing.Size(663, 316);
            this.byteAttrView.TabIndex = 6;
            // 
            // tabPageSLE44xx
            // 
            this.tabPageSLE44xx.Controls.Add(this.tblPanel);
            this.tabPageSLE44xx.Controls.Add(this.groupBox1);
            this.tabPageSLE44xx.Location = new System.Drawing.Point(4, 36);
            this.tabPageSLE44xx.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE44xx.Name = "tabPageSLE44xx";
            this.tabPageSLE44xx.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageSLE44xx.Size = new System.Drawing.Size(1344, 454);
            this.tabPageSLE44xx.TabIndex = 0;
            this.tabPageSLE44xx.Text = "SLE4428";
            this.tabPageSLE44xx.UseVisualStyleBackColor = true;
            // 
            // tabCardType
            // 
            this.tabCardType.Controls.Add(this.tabPageSLE44xx);
            this.tabCardType.Controls.Add(this.tabPageI2C);
            this.tabCardType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCardType.ItemSize = new System.Drawing.Size(96, 32);
            this.tabCardType.Location = new System.Drawing.Point(0, 0);
            this.tabCardType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabCardType.Name = "tabCardType";
            this.tabCardType.SelectedIndex = 0;
            this.tabCardType.Size = new System.Drawing.Size(1352, 494);
            this.tabCardType.TabIndex = 1;
            this.tabCardType.SelectedIndexChanged += new System.EventHandler(this.tabCardType_SelectedIndexChanged);
            // 
            // tabPageI2C
            // 
            this.tabPageI2C.Controls.Add(this.tableLayoutPanel1);
            this.tabPageI2C.Location = new System.Drawing.Point(4, 36);
            this.tabPageI2C.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageI2C.Name = "tabPageI2C";
            this.tabPageI2C.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabPageI2C.Size = new System.Drawing.Size(1344, 454);
            this.tabPageI2C.TabIndex = 1;
            this.tabPageI2C.Text = "Atmel-I2C";
            this.tabPageI2C.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.byteViewerControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.byteViewerControl2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1338, 444);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 5);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(574, 38);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 7);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 32);
            this.button4.TabIndex = 0;
            this.button4.Text = "Read Data Bytes";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // byteViewerControl1
            // 
            this.byteViewerControl1.BackColor = System.Drawing.SystemColors.Window;
            this.byteViewerControl1.BytesPerRow = 16;
            this.byteViewerControl1.Caption = "Byte Data Viewer";
            this.byteViewerControl1.CardDataLength = 0;
            this.byteViewerControl1.Data = null;
            this.byteViewerControl1.DisplayMode = SLE44xxTool.ExtControl.ByteViewerControl.ShowMode.DATA;
            this.byteViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteViewerControl1.Location = new System.Drawing.Point(3, 52);
            this.byteViewerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byteViewerControl1.Name = "byteViewerControl1";
            this.byteViewerControl1.ProtectedData = null;
            this.byteViewerControl1.Size = new System.Drawing.Size(663, 388);
            this.byteViewerControl1.TabIndex = 5;
            // 
            // byteViewerControl2
            // 
            this.byteViewerControl2.BackColor = System.Drawing.SystemColors.Window;
            this.byteViewerControl2.BytesPerRow = 16;
            this.byteViewerControl2.Caption = "Byte Attr Viewer";
            this.byteViewerControl2.CardDataLength = 0;
            this.byteViewerControl2.Data = null;
            this.byteViewerControl2.DisplayMode = SLE44xxTool.ExtControl.ByteViewerControl.ShowMode.ATTR;
            this.byteViewerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.byteViewerControl2.Location = new System.Drawing.Point(672, 52);
            this.byteViewerControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byteViewerControl2.Name = "byteViewerControl2";
            this.byteViewerControl2.ProtectedData = null;
            this.byteViewerControl2.Size = new System.Drawing.Size(663, 388);
            this.byteViewerControl2.TabIndex = 6;
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
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblVersion.Location = new System.Drawing.Point(1184, 15);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(156, 20);
            this.lblVersion.TabIndex = 20;
            this.lblVersion.Text = "Buildon: 2024/09/22";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 703);
            this.Controls.Add(this.lblVersion);
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
            this.Text = "SLE44xxTool-V1.1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tblPanel.ResumeLayout(false);
            this.tabPageSLE44xx.ResumeLayout(false);
            this.tabPageSLE44xx.PerformLayout();
            this.tabCardType.ResumeLayout(false);
            this.tabPageI2C.ResumeLayout(false);
            this.tabPageI2C.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnChangePSC;
        private System.Windows.Forms.Button btnAuthPSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPSC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReadByteData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblPanel;
        private System.Windows.Forms.TabPage tabPageSLE44xx;
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
        private System.Windows.Forms.Button btnGetErrCounter;
        private System.Windows.Forms.TabPage tabPageI2C;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button4;
        private ExtControl.ByteViewerControl byteViewerControl1;
        private ExtControl.ByteViewerControl byteViewerControl2;
        private System.Windows.Forms.Label lblVersion;
    }
}

