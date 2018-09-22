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
    /// <summary>
    /// Old Standalone Form (working, disabled in current version)
    /// </summary>
    public partial class FrmLegacy : Form
    {

        #region PROPERTIES

        int iInterface = 0;                 // found interfaces
        int iInterfaceUp = 0;               // interfaces up
        int iFirstUp = -1;                  // First interface ID
        long lngBytesSend = 0;              // bytes sent storage
        long lngBytesReceived = 0;          // bytes received storage
        private StringBuilder _bytesUnit;   // bytsunit used by BytesFormat method
        NetworkInterface oInterface;        // selected interface object

        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Initialize and Retrieve interfaces info
        /// </summary>
        public FrmLegacy()
        {
            InitializeComponent();

            if(null == oTimer)
            {
                throw new Exception("Timer Initialization Error");
            }
            
            oTimer.Stop();

            if (NetworkInterface.GetAllNetworkInterfaces().Length == 0)
            {
                throw new Exception("No interface found");
            }

            foreach (NetworkInterface anInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(anInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && anInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    MenuInterfacesAdd(anInterface);
            }

            if (0 < iInterface)
            {
                menuInterfaces.Text += " (" + iInterfaceUp.ToString();
                menuInterfaces.Text += "/" + (iInterface - iInterfaceUp).ToString() + ")";
                if (-1 == iFirstUp)
                {
                    iFirstUp = 0;
                }
                SelectInterface(iFirstUp);
            }
            else
            {
                IsDown();
            }
        }
        #endregion

        #region INTERFACE SELECTION
        /// <summary>
        /// Add interface info to the top menu
        /// </summary>
        /// <param name="anInterface">NetworkInterface object</param>
        private void MenuInterfacesAdd(NetworkInterface anInterface)
        {
            if(anInterface.NetworkInterfaceType.ToString() != "Tunnel")
            {
                ToolStripMenuItem oItem = new ToolStripMenuItem(anInterface.OperationalStatus.ToString() + ": " + anInterface.Name);
                oItem.ForeColor = Color.DarkGray;
                oItem.Tag       = iInterface;
                oItem.Click     += new System.EventHandler(this.SelectInterface);
                oItem.Image = Devoldere.NetSpeedTray.Properties.Resources.scroll_down_png;
                if (anInterface.OperationalStatus == OperationalStatus.Up)
                {
                    oItem.ForeColor = Color.Black;
                    oItem.Image = Devoldere.NetSpeedTray.Properties.Resources.scroll_up_png;
                    iInterfaceUp++;
                    if (-1 == iFirstUp)
                    {
                        iFirstUp = iInterface;
                    }
                }
                menuInterfaces.DropDownItems.Add(oItem);
                iInterface++;
            }
        }

        /// <summary>
        /// Select current interface stored in oInterface and check its connexion status
        /// </summary>
        private void SelectInterface()
        {
            lblName.Text = oInterface.Name;
            this.Text = oInterface.Name + " " + oInterface.OperationalStatus.ToString();

            if (oInterface.OperationalStatus == OperationalStatus.Up)
            {
                IsUp();
            }
            else
            {
                IsDown();
            }
        }

        /// <summary>
        /// Select an interface by its ID
        /// </summary>
        /// <param name="iId">Interface ID (array key in GetAllNetworkInterfaces()</param>
        private void SelectInterface(int iId)
        {
            if (iId < NetworkInterface.GetAllNetworkInterfaces().Length)
            {
                oInterface = NetworkInterface.GetAllNetworkInterfaces()[iId];
                SelectInterface();
            }
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

        #region INTERFACE_UPDATE

        /// <summary>
        /// Retrieve interface connexion info
        /// </summary>
        private void IsUp()
        {
            if (
                1 < oInterface.GetIPProperties().UnicastAddresses.Count 
                && 
                null != (oInterface.GetIPProperties().UnicastAddresses[1].Address)
               )
            {
                lblName.Text += "\r" + (oInterface.GetIPProperties().UnicastAddresses[1].Address).ToString();
                if (null != (oInterface.GetIPProperties().UnicastAddresses[1].IPv4Mask))
                    lblName.Text += "\r" + (oInterface.GetIPProperties().UnicastAddresses[1].IPv4Mask).ToString();
            }
            else
            {
                lblName.Text += "\r" + (oInterface.GetIPProperties().UnicastAddresses[0].Address).ToString();
                this.Icon = Devoldere.NetSpeedTray.Properties.Resources.scroll;
            }
            lblName.Text += "\r" + (oInterface.Speed / 1000000).ToString() + " Mbps"; ;
            
            oTimer.Start();
            oNotify.BalloonTipTitle = this.Text;
            lblName.ForeColor = Color.Black;
            cbNotify.Enabled = true;
            this.ClientSize = new System.Drawing.Size(212, 152);
            this.Icon = Devoldere.NetSpeedTray.Properties.Resources.scroll_up;
        }

        /// <summary>
        /// Display an offline interface info
        /// </summary>
        private void IsDown()
        {
            oTimer.Stop();
            lblName.ForeColor = Color.Gray;
            lblName.Text += "\rDown";
            cbNotify.Checked = false;
            cbNotify.Enabled = false;
            this.ClientSize = new System.Drawing.Size(212, 80);
            this.Icon = Devoldere.NetSpeedTray.Properties.Resources.scroll_down;
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
            IPv4InterfaceStatistics interfaceStatistic = oInterface.GetIPv4Statistics();

            int bytesSentSpeed = (int)(interfaceStatistic.BytesSent - lngBytesSend);
            int bytesReceivedSpeed = (int)(interfaceStatistic.BytesReceived - lngBytesReceived);

            //lblSpeed.Text = (oInterface.Speed / 1000000).ToString() + " Mbps";
            lblSrUp.Text = interfaceStatistic.UnicastPacketsSent.ToString();
            lblSrDown.Text = interfaceStatistic.UnicastPacketsReceived.ToString();
            lblBytesUp.Text = BytesFormat(interfaceStatistic.BytesSent, "B", 1024);
            lblBytesDown.Text = BytesFormat(interfaceStatistic.BytesReceived, "B", 1024);
            lblUl.Text = BytesFormat(bytesSentSpeed, "B/s", 1024);
            lblDl.Text = BytesFormat(bytesReceivedSpeed, "B/s", 1024);
            lngBytesSend = interfaceStatistic.BytesSent;
            lngBytesReceived = interfaceStatistic.BytesReceived;

            if (
                (cbNotify.Checked == true) &&
                ((bytesReceivedSpeed >= 1) || (bytesSentSpeed >= 1))
              )
            {
                oNotify.Text = "UL: " + lblUl.Text + "\nDL: " + lblDl.Text;
                oNotify.BalloonTipText = oNotify.Text;
                oNotify.ShowBalloonTip(2500);
            }
        }

        #endregion

        #region BYTES_FORMAT
        /// <summary>
        /// Format Bytes to string
        /// </summary>
        /// <param name="iValue">bytes value</param>
        /// <param name="sFormat"></param>
        /// <param name="iDivider">1000 or 1024</param>
        /// <returns></returns>
        private string BytesFormat(double iValue, string sFormat, int iDivider)
        {
            if (iValue == 0)
                return "0";

            _bytesUnit = new StringBuilder(sFormat, 5);

            if (iValue > 1073741824) // 1gb
            {
                iValue = iValue / iDivider / iDivider / iDivider;
                _bytesUnit.Insert(0, "G");
            }
            else if (iValue > 1048576) // 1mb
            {
                iValue = iValue / iDivider / iDivider;
                _bytesUnit.Insert(0, "M");
            }
            else if (iValue > 1024) // 1kb
            {
                iValue = iValue / iDivider;
                _bytesUnit.Insert(0, "K");
            }

            _bytesUnit.Insert(0, " ");

            return iValue.ToString("#.##") + _bytesUnit.ToString();
        }

        #endregion

        #region EVENTS

        private void ReloadApp(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AboutApp(object sender, EventArgs e)
        {
            DialogResult mResult =  MessageBox.Show
            (
                "NetSpeedTray 1.1.0.3 (Legacy)\rMickaël  Devoldère\rhttps://devoldere.net\r\rDo you wish to visit devoldere.net ?",
                "DEVOLDERE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None
             );

            if(mResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://devoldere.net");
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //cbNotify.Checked = (this.Visible == true) ? cbNotify.Checked : false; 
            this.Visible = (this.Visible == true) ? false : true;
        }

        #endregion



    }
}
