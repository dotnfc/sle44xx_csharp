using System;
using System.Drawing;
using System.Windows.Forms;

namespace SLE44xxTool.ExtControl
{
    public class FormEx : Form
    {

        public FormEx()
        {
            Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            Font messageBoxFont = SystemFonts.MessageBoxFont;

            SetControlFont(this, messageBoxFont);
        }

        protected void SetControlFont(Control parent, Font font)
        {
            parent.Font = font;

            foreach (Control control in parent.Controls)
            {
                SetControlFont(control, font);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormEx
            // 
            this.ClientSize = new System.Drawing.Size(693, 469);
            this.Name = "FormEx";
            this.ResumeLayout(false);

        }
    }
}
