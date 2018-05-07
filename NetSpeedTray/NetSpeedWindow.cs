using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public partial class NetSpeedWindow : Form
    {

        #region PROPERTIES

        //NetworkInterface oInterface;        // selected interface object


        NetInterfaceManager interfaceManager;

        NetInterface currentInterface;

        NetTraffice currentTraffice;

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Initialize and Retrieve interfaces info
        /// </summary>
        public NetSpeedWindow()
        {
            InitializeComponent();

            if(null == oTimer)
            {
                throw new Exception("Timer Initialization Error");
            }
            
            oTimer.Stop();

            interfaceManager = new NetInterfaceManager();

            UpdateInterfaces();

        }
        #endregion

        #region new Interface list update

        protected void UpdateInterfaces()
        {
            menuInterfaces.DropDownItems.Clear();
            
            interfaceManager.Update();

            foreach(NetInterface anInterface in interfaceManager.InterfaceList)
            {
                ToolStripMenuItem oItem = new ToolStripMenuItem(anInterface.Name)
                {
                    ForeColor = anInterface.State.ForeColor,
                    Tag = anInterface.Id,
                    Image = anInterface.State.Png
                };

                oItem.Click += new System.EventHandler(this.SelectInterface);

                menuInterfaces.DropDownItems.Add(oItem);
            }

            menuInterfaces.Text = interfaceManager.ToString();

            SelectInterface(interfaceManager.FirstUpInterfaceId);
        }

        #endregion

        #region INTERFACE SELECTION

        /// <summary>
        /// Select current interface stored in oInterface and check its connexion status
        /// </summary>
        private void SelectInterface()
        {
            this.Text = currentInterface.Name;
            this.Icon = currentInterface.State.Ico;

            lblName.Text = currentInterface.Text;
            lblName.ForeColor = currentInterface.State.ForeColor;

            oNotify.BalloonTipTitle = currentInterface.Name;

            cbNotify.Enabled = currentInterface.State.Up;

            if (currentInterface.State.Up)
            {
                oTimer.Start();
                this.ClientSize = new System.Drawing.Size(212, 152);
            }
            else
            {
                cbNotify.Checked = false;
                oTimer.Stop();
                this.ClientSize = new System.Drawing.Size(212, 80);
            }
        }

        /// <summary>
        /// Select an interface by its ID
        /// </summary>
        /// <param name="iId">Interface ID (array key in GetAllNetworkInterfaces()</param>
        private void SelectInterface(int iId)
        {
            currentInterface = interfaceManager.GetInterface(iId);
            currentTraffice = currentInterface.Traffice;
            //oInterface = currentInterface.OInterface;
            SelectInterface();
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


        #region TIMER
        /// <summary>
        /// Event oTimer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            currentTraffice.Update();

            lblSrUp.Text = currentTraffice.UnicastPacketsSent;
            lblSrDown.Text = currentTraffice.UnicastPacketsReceived;
            lblBytesUp.Text = currentTraffice.BytesSentText;
            lblBytesDown.Text = currentTraffice.BytesReceivedText;
            lblUl.Text = currentTraffice.BytesSentSpeedText;
            lblDl.Text = currentTraffice.BytesReceivedSpeedText;

            if (
                (cbNotify.Checked) &&
                ((currentTraffice.BytesReceivedSpeed >= 1) || (currentTraffice.BytesSentSpeed >= 1))
              )
            {
                oNotify.Text = "Up: " + lblUl.Text + "\nDown: " + lblDl.Text;
                oNotify.BalloonTipText = oNotify.Text;
                oNotify.ShowBalloonTip(2500);
            }
        }

        #endregion

        #region EVENTS

        private void ReloadApp(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ReloadNetwork(object sender, EventArgs e)
        {

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
                "(" + Properties.Settings.Default.PublishDate + ")\r" +
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
            cbNotify.Checked = (this.Visible == true) ? cbNotify.Checked : false; 
            this.Visible = !this.Visible;
         }

        #endregion

    }
}
