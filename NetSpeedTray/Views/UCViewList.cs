using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCViewList : UserControl, INetObserver
    {
        BindingSource data;

        public UCViewList()
        {
            InitializeComponent();

            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.ForeColor;
            dataGrid.DefaultCellStyle.SelectionBackColor = dataGrid.DefaultCellStyle.BackColor;

            data = new BindingSource();
            data.DataSource = NetListener.AdapterList;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.DataSource = data;
            dataGrid.Refresh();
            NetListener.NetRegister(this);
        }

        #region TIMER
        /// <summary>
        /// Event NetListener.*Timer Tick
        /// </summary>
        public void NetUpdate()
        {
            Point p = dataGrid.CurrentCellAddress;
            data.CurrentItemChanged += ItemUpdated;
            data.DataSource = null;
            data.DataSource = NetListener.AdapterList;
            dataGrid.Update();
        }

        protected void ItemUpdated(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
