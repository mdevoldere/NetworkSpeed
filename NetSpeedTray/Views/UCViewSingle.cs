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

        public NetInterface CurrentInterface { get; private set; }

        public NetTraffice CurrentTraffice { get; private set; }

        #endregion

        public UCViewSingle()
        {
            InitializeComponent();

            NetListener.NetRegister(this);
        }

        public void NetUpdate()
        {
            if(CurrentTraffice != null)
            {
                lblSrUp.Text = CurrentTraffice.UnicastPacketsSent;
                lblSrDown.Text = CurrentTraffice.UnicastPacketsReceived;
                lblBytesUp.Text = CurrentTraffice.BytesSentText;
                lblBytesDown.Text = CurrentTraffice.BytesReceivedText;
                lblUl.Text = CurrentTraffice.SpeedUpText;
                lblDl.Text = CurrentTraffice.SpeedDownText;
            }
        }

        public void SetInterface(int _id)
        {
            CurrentInterface = NetListener.InterfaceList.GetInterface(_id);

            CurrentTraffice = NetListener.InterfaceList.SelectedInterface.Traffice;

            lblName.Text = NetListener.InterfaceList.SelectedInterface.Text;
            lblName.ForeColor = NetListener.InterfaceList.SelectedInterface.State.ForeColor;
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
