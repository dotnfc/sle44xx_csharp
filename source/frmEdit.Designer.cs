namespace SLE44xxTool
{
    partial class frmEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDataHex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fmtAscii = new System.Windows.Forms.RadioButton();
            this.fmtHex = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEditReload = new System.Windows.Forms.Button();
            this.lblLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDataHex
            // 
            this.txtDataHex.Location = new System.Drawing.Point(73, 36);
            this.txtDataHex.Name = "txtDataHex";
            this.txtDataHex.Size = new System.Drawing.Size(409, 25);
            this.txtDataHex.TabIndex = 0;
            this.txtDataHex.TextChanged += new System.EventHandler(this.txtDataHex_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 13, 0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Format:";
            // 
            // fmtAscii
            // 
            this.fmtAscii.AutoSize = true;
            this.fmtAscii.Location = new System.Drawing.Point(72, 77);
            this.fmtAscii.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.fmtAscii.Name = "fmtAscii";
            this.fmtAscii.Size = new System.Drawing.Size(68, 19);
            this.fmtAscii.TabIndex = 4;
            this.fmtAscii.Text = "ASCII";
            this.fmtAscii.UseVisualStyleBackColor = true;
            this.fmtAscii.CheckedChanged += new System.EventHandler(this.fmtAscii_CheckedChanged);
            // 
            // fmtHex
            // 
            this.fmtHex.AutoSize = true;
            this.fmtHex.Checked = true;
            this.fmtHex.Location = new System.Drawing.Point(155, 77);
            this.fmtHex.Margin = new System.Windows.Forms.Padding(3, 13, 12, 17);
            this.fmtHex.Name = "fmtHex";
            this.fmtHex.Size = new System.Drawing.Size(52, 19);
            this.fmtHex.TabIndex = 6;
            this.fmtHex.TabStop = true;
            this.fmtHex.Text = "HEX";
            this.fmtHex.UseVisualStyleBackColor = true;
            this.fmtHex.CheckedChanged += new System.EventHandler(this.fmtHex_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(266, 112);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(385, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEditReload
            // 
            this.btnEditReload.Location = new System.Drawing.Point(144, 112);
            this.btnEditReload.Name = "btnEditReload";
            this.btnEditReload.Size = new System.Drawing.Size(97, 32);
            this.btnEditReload.TabIndex = 9;
            this.btnEditReload.Text = "Reset";
            this.btnEditReload.UseVisualStyleBackColor = true;
            this.btnEditReload.Click += new System.EventHandler(this.btnEditReload_Click);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(488, 39);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(0, 15);
            this.lblLength.TabIndex = 10;
            // 
            // frmEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(551, 165);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.btnEditReload);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fmtAscii);
            this.Controls.Add(this.fmtHex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDataHex);
            this.Name = "frmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataHex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton fmtAscii;
        private System.Windows.Forms.RadioButton fmtHex;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEditReload;
        private System.Windows.Forms.Label lblLength;
    }
}