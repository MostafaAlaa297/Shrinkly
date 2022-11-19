using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{
    public partial class HomePage : Form
    {
        private int flag = 0;
        Register? reg;
        Teast? search;
        public HomePage( int aflag)
        {
            flag = aflag;
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            flag = 0;
            search = new Teast(1);
            search.Show(this);
            Hide();
        }

        private void add_Click(object sender, EventArgs e)
        {
          flag = 0;
          reg = new Register(1);
          reg.Show(this);
          Hide();
        }

        
        private void HomePage_FormClosing(object sender ,FormClosingEventArgs e)
        {
            if (flag == 1)
            {
                if (MessageBox.Show("هل انت متأكد بأند تريد الخروج من البرنامج ؟", "تأكيد خروج", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    flag = 0;
                    Application.Exit();
                }
            }
        }


        private void HomePage_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();

        }

        private void HomePage_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
            && (((int)m.WParam & 0xFFFF) == 5))
            {
                // Change SB_THUMBTRACK to SB_THUMBPOSITION
                m.WParam = (IntPtr)(((int)m.WParam & ~0xFFFF) | 4);
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
/*base.OnFormClosing(e);

if (e.CloseReason == CloseReason.WindowsShutDown) return;

// Confirm user wants to close
switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
{
    case DialogResult.No:
        e.Cancel = true;
        break;
    default:
        break;
}*/