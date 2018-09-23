using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCViewMini : UserControl, INetObserver
    {
        NetAdapter CurrentInterface;

        StringBuilder sb = new StringBuilder();

        public UCViewMini()
        {
            InitializeComponent();

            NetListener.NetRegister(this);
        }

        public void NetUpdate()
        {
            CurrentInterface = NetListener.AdapterList.SelectedItem;

            lblName.Text = CurrentInterface.Name;
            lblTrafficeUp.Text = "U: " + CurrentInterface.SpeedUpText;
            lblTrafficeDown.Text = "D: " + CurrentInterface.SpeedDownText;
        }
    }
}
