using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCViewSingle : UserControl, INetObserver
    {
        #region PROPERTIES
        
        public bool Notify { get; set; }

        public NetAdapter CurrentInterface { get; private set; }

        #endregion

        public UCViewSingle()
        {
            InitializeComponent();

            NetListener.NetRegister(this);
        }

        public void NetUpdate()
        {
            CurrentInterface = NetListener.AdapterList.SelectedItem;

            lblName.Text = NetListener.AdapterList.SelectedItem.ToString();
            lblName.ForeColor = NetListener.AdapterList.SelectedItem.State.ForeColor;

            lblSrUp.Text = CurrentInterface.UnicastPacketsSent;
            lblSrDown.Text = CurrentInterface.UnicastPacketsReceived;
            lblBytesUp.Text = CurrentInterface.BytesSentText;
            lblBytesDown.Text = CurrentInterface.BytesReceivedText;
            lblUl.Text = CurrentInterface.SpeedUpText;
            lblDl.Text = CurrentInterface.SpeedDownText;
        }

        #region TIMER
        /// <summary>
        /// Event oTimer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    if(NetInterfaceManager.InterfaceList.SelectedInterface.State.Up)
        //    {
        //        lblSrUp.Text = CurrentTraffice.UnicastPacketsSent;
        //        lblSrDown.Text = CurrentTraffice.UnicastPacketsReceived;
        //        lblBytesUp.Text = CurrentTraffice.BytesSentText;
        //        lblBytesDown.Text = CurrentTraffice.BytesReceivedText;
        //        lblUl.Text = CurrentTraffice.BytesSentSpeedText;
        //        lblDl.Text = CurrentTraffice.BytesReceivedSpeedText;
        //    }
            

        //    if (
        //        (Notify) &&
        //        ((CurrentTraffice.BytesReceivedSpeed >= 1) || (CurrentTraffice.BytesSentSpeed >= 1))
        //      )
        //    {
        //        oNotify.Text = "Up: " + lblUl.Text + "\nDown: " + lblDl.Text;
        //        oNotify.BalloonTipText = oNotify.Text;
        //        oNotify.ShowBalloonTip(2500);
        //    }
        //}

        #endregion

    }
}
