using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetInterfaceManager
    {
        static protected readonly Timer TimerMain = new Timer { Interval = 10000 };

        static protected readonly Timer TimerTraffice = new Timer { Interval = 1000 };

        static public readonly Timer TimerApp = new Timer { Interval = 1200 };

        static public NetInterfaceList InterfaceList { get; private set; }

        static public NetInterfaceList Init()
        {
            if(InterfaceList == null)
            {
                InterfaceList = new NetInterfaceList();
                TimerMain.Tick += Timer_Tick;
                TimerTraffice.Tick += TimerTraffice_Tick;
            }

            return InterfaceList;
        }

        static public void Start()
        {
            TimerMain.Start();
            TimerTraffice.Start();
            TimerApp.Start();
        }

        static public void Stop()
        {
            TimerMain.Stop();
            TimerTraffice.Stop();
            TimerApp.Stop();
        }

        /// <summary>
        /// Event timer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void Timer_Tick(object sender, EventArgs e)
        {
            foreach (NetInterface ni in InterfaceList)
            {
                ni.Update();
            }
        }

        /// <summary>
        /// Event timerTraffice Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void TimerTraffice_Tick(object sender, EventArgs e)
        {
            foreach (NetInterface ni in InterfaceList)
            {
                ni.UpdateTraffice();
            }
        }

    }
}
