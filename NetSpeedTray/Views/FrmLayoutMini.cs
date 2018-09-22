using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class FrmLayoutMini : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        public static Point P = new Point(5, 2);

        FrmLayout layout;

        public FrmLayoutMini()
        {
            InitializeComponent();
        }

        public FrmLayoutMini(FrmLayout _parent) : this()
        {
            layout = _parent;
        }

        private void FrmLayoutMini_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public void Display()
        {
            if (layout != null)
            {
                layout.Hide();
                this.Controls.Add(FrmLayout.ViewNetInterfaceMini);
                FrmLayout.ViewNetInterfaceMini.Location = P;
                FrmLayout.ViewNetInterfaceMini.MouseDoubleClick += FrmLayoutMini_MouseDoubleClick;
                this.Show();
                Height = FrmLayout.ViewNetInterfaceMini.Height + 4;
                Width = FrmLayout.ViewNetInterfaceMini.Width + 10;
                FrmLayout.ViewNetInterfaceMini.Show();
            }
        }

        public void GoToLayout()
        {
            if (layout != null)
            {
                this.Hide();
                layout.Controls.Add(FrmLayout.ViewNetInterfaceMini);
                FrmLayout.ViewNetInterfaceMini.Location = FrmLayout.P;
                FrmLayout.ViewNetInterfaceMini.MouseDoubleClick -= FrmLayoutMini_MouseDoubleClick;
                layout.Show();
            }
        }

        private void FrmLayoutMini_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GoToLayout();
        }
    }
}
