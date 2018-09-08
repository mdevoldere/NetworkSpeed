using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCNetInterfaceList : UserControl
    {
        BindingSource data;

        public UCNetInterfaceList()
        {
            InitializeComponent();

            data = new BindingSource();
            data.DataSource = NetInterfaceManager.InterfaceList;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.DataSource = data;
            dataGrid.Refresh();
            NetInterfaceManager.TimerApp.Tick += timer_Tick;
        }

        #region TIMER
        /// <summary>
        /// Event oTimer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            data.DataSource = null;
            data.DataSource = NetInterfaceManager.InterfaceList;
            dataGrid.Update();
        }

        #endregion
    }
}
