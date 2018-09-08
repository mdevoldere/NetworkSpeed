using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCNetInterface : UserControl
    {
        #region PROPERTIES
        
        public bool Notify { get; set; }

        public NetInterfaceList InterfaceList { get; private set; }

        public NetInterface CurrentInterface { get; private set; }

        public NetTraffice CurrentTraffice { get; private set; }

        #endregion

        public UCNetInterface()
        {
            InitializeComponent();

            InterfaceList = NetInterfaceManager.Init();
            
        }

        public void SetInterface(int _id)
        {
            NetInterfaceManager.TimerApp.Tick -= timer_Tick;

            CurrentInterface = NetInterfaceManager.InterfaceList.GetInterface(_id);

            CurrentTraffice = NetInterfaceManager.InterfaceList.SelectedInterface.Traffice;

            lblName.Text = NetInterfaceManager.InterfaceList.SelectedInterface.Text;
            lblName.ForeColor = NetInterfaceManager.InterfaceList.SelectedInterface.State.ForeColor;

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
           // if(NetInterfaceManager.InterfaceList.SelectedInterface.State.Up)
            //{
                lblSrUp.Text = CurrentTraffice.UnicastPacketsSent;
                lblSrDown.Text = CurrentTraffice.UnicastPacketsReceived;
                lblBytesUp.Text = CurrentTraffice.BytesSentText;
                lblBytesDown.Text = CurrentTraffice.BytesReceivedText;
                lblUl.Text = CurrentTraffice.BytesSentSpeedText;
                lblDl.Text = CurrentTraffice.BytesReceivedSpeedText;
           // }
            

            /*if (
                (Notify) &&
                ((CurrentTraffice.BytesReceivedSpeed >= 1) || (CurrentTraffice.BytesSentSpeed >= 1))
              )
            {
                oNotify.Text = "Up: " + lblUl.Text + "\nDown: " + lblDl.Text;
                oNotify.BalloonTipText = oNotify.Text;
                oNotify.ShowBalloonTip(2500);
            }*/
        }

        #endregion

    }
}
