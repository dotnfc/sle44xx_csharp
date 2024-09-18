namespace SLE44xxTool.ExtControl
{
    partial class Sle44xxPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChangePSC = new System.Windows.Forms.Button();
            this.btnAuthPSC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPSC = new System.Windows.Forms.TextBox();
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReadByteData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.byteDataView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.byteAttrView = new SLE44xxTool.ExtControl.ByteViewerControl();
            this.groupBox1.SuspendLayout();
            this.tblPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangePSC);
            this.groupBox1.Controls.Add(this.btnAuthPSC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPSC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(901, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " PSC Security ";
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = " PSC:";
            // 
            // txtPSC
            // 
            this.txtPSC.Location = new System.Drawing.Point(91, 27);
            this.txtPSC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPSC.Name = "txtPSC";
            this.txtPSC.Size = new System.Drawing.Size(82, 25);
            this.txtPSC.TabIndex = 0;
            this.txtPSC.Text = "FF FF";
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
            this.tblPanel.Location = new System.Drawing.Point(0, 72);
            this.tblPanel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tblPanel.Name = "tblPanel";
            this.tblPanel.RowCount = 2;
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanel.Size = new System.Drawing.Size(901, 550);
            this.tblPanel.TabIndex = 2;
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(444, 38);
            this.flowLayoutPanel1.TabIndex = 1;
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 13, 0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Show in ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(307, 13);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 19);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "ASCII";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 62);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 19);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "HEX";
            this.radioButton2.UseVisualStyleBackColor = true;
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
            this.byteDataView.Size = new System.Drawing.Size(444, 494);
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
            this.byteAttrView.Location = new System.Drawing.Point(453, 52);
            this.byteAttrView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.byteAttrView.Name = "byteAttrView";
            this.byteAttrView.ProtectedData = null;
            this.byteAttrView.Size = new System.Drawing.Size(445, 494);
            this.byteAttrView.TabIndex = 6;
            // 
            // Sle44xxPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sle44xxPanel";
            this.Size = new System.Drawing.Size(901, 622);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tblPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChangePSC;
        private System.Windows.Forms.Button btnAuthPSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPSC;
        private System.Windows.Forms.TableLayoutPanel tblPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnReadByteData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private ByteViewerControl byteDataView;
        private ByteViewerControl byteAttrView;
    }
}
