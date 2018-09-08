using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class FrmLayout : Form
    {
        protected static NetInterface currentInterface;
        
        protected static UCNetInterfaceList listView;

        private static Size netViewSize;

        private static Size listViewSize;

        #region CONSTRUCTOR
        /// <summary>
        /// Initialize
        /// </summary>
        public FrmLayout()
        {
            InitializeComponent();
            NetInterfaceManager.Init();
            netViewSize = new Size(netView.Width + 30, netView.Height + 75);
            UpdateInterfaces();
        }
        #endregion

        #region Interface list update

        /// <summary>
        /// Update Network Interfaces & bound menuInterfaces Items
        /// </summary>
        protected void UpdateInterfaces()
        {
            NetInterfaceManager.Stop();

            NetInterfaceManager.InterfaceList.UpdateList();

            menuInterfaces.DropDownItems.Clear();
            foreach (NetInterface ni in NetInterfaceManager.InterfaceList)
            {
                ToolStripMenuItem oItem = new ToolStripMenuItem(ni.Name)
                {
                    ForeColor = ni.State.ForeColor,
                    Tag = ni.Id,
                    Image = ni.State.Png
                };

                oItem.Click += SelectInterface;

                menuInterfaces.DropDownItems.Add(oItem);
            }

            menuInterfaces.Text = NetInterfaceManager.InterfaceList.ToString();

            NetInterfaceManager.Start();

            SelectInterface(NetInterfaceManager.InterfaceList.FirstUp);

            
        }

        #endregion

        #region INTERFACE SELECTION

        /// <summary>
        /// Select an interface by its ID in NetInterfaceManager.InterfaceList
        /// </summary>
        /// <param name="iId">Interface ID (array key in GetAllNetworkInterfaces()</param>
        private void SelectInterface(int iId)
        {
            netView.SetInterface(iId);

            this.Text = netView.CurrentInterface.Name;
            this.Icon = netView.CurrentInterface.State.Ico;

            oNotify.BalloonTipTitle = netView.CurrentInterface.Name;
        }

        /// <summary>
        /// MenuClick : Select an interface
        /// </summary>
        /// <param name="sender">a ToolStripMenuItem</param>
        /// <param name="e">EventArgs</param>
        private void SelectInterface(object sender, EventArgs e)
        {
            ToolStripMenuItem oItem = sender as ToolStripMenuItem;
            SelectInterface((int)oItem.Tag);
        }

        #endregion

        #region EVENTS

        private void ReloadApp(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ReloadNetwork(object sender, EventArgs e)
        {
            UpdateInterfaces();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AboutApp(object sender, EventArgs e)
        {
            DialogResult mResult = MessageBox.Show
            (
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +
                " " +
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version +
                " (" + Properties.Settings.Default.PublishDate + ")\r" +
                Properties.Settings.Default.Author + "\r" +
                Properties.Settings.Default.Url + "\r\r" +
                "Do you wish to visit "+ Properties.Settings.Default.UrlLabel + "  ?",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None
             );

            if(mResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.Url);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        { 
            this.Visible = !this.Visible;
         }

        #endregion

        private void menuViewInterface_Click(object sender, EventArgs e)
        {
            if(listView != null)
            {
                listView.Hide();
            }
            
            menuInterfaces.Visible = true;
            this.Size = netViewSize;
            netView.Show(); 
        }

        private void menuViewList_Click(object sender, EventArgs e)
        {
            if (listView == null)
            {
                listView = new Views.UCNetInterfaceList();
                listView.Location = netView.Location;
                listViewSize = new Size(listView.Width + 30, listView.Height + 50);
                this.Controls.Add(listView);
            }

            netView.Hide();
            menuInterfaces.Visible = false;
            this.Size = listViewSize;
            listView.Show();
        }

        private void FrmLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            oNotify.Visible = false;
        }
    }
}
