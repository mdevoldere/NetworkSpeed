using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public interface INetObserver
    {
        void NetUpdate();
    }

    public class NetListener
    {
        static protected readonly Timer AppTimer = new Timer { Interval = 10000, Enabled = false };

        static protected readonly Timer NetTimer = new Timer { Interval = 1000, Enabled = false };

        //static public NetInterfaceList InterfaceList { get; private set; } = new NetInterfaceList();

        static public NetAdapterList AdapterList { get; private set; } = new NetAdapterList();

        static protected List<INetObserver> appObs = new List<INetObserver>();

        static protected List<INetObserver> netObs = new List<INetObserver>();

        #region Timers

        static public void Start()
        {
            //NetTimer_Tick(new object(), new EventArgs());
            AppTimer.Tick += AppTimer_Tick;
            NetTimer.Tick += NetTimer_Tick;
            AppTimer.Start();
            NetTimer.Start();
        }

        static public void Stop()
        {
            AppTimer.Tick -= AppTimer_Tick;
            NetTimer.Tick -= NetTimer_Tick;
            AppTimer.Stop();
            NetTimer.Stop();
        }

        /// <summary>
        /// Event timer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void AppTimer_Tick(object sender, EventArgs e)
        {
            foreach (NetAdapter ni in AdapterList)
            {
                if(ni != null)
                    ni.Update();
            }

            Notify(appObs);
        }

        /// <summary>
        /// Event timerTraffice Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static public void NetTimer_Tick(object sender, EventArgs e)
        {
            foreach (NetAdapter ni in AdapterList)
            {
                if (ni != null)
                    ni.UpdateTraffice();
            }
            
            Notify(netObs);
        }

        #endregion

        #region Observers

        static public void AppRegister(INetObserver obs)
        {
            if (!appObs.Contains(obs))
            {
                appObs.Add(obs);
            }
        }

        static public void NetRegister(INetObserver obs)
        {
            if (!netObs.Contains(obs))
            {
                netObs.Add(obs);
            }
        }

        static public void Notify(List<INetObserver> observers)
        {
            foreach (INetObserver obs in observers)
            {
                if (obs != null)
                {
                    obs.NetUpdate();
                }
            }
        }

        static public void Release(INetObserver obs)
        {
            if (netObs.Contains(obs))
            {
                netObs.Remove(obs);
            }

            if (appObs.Contains(obs))
            {
                appObs.Remove(obs);
            }
        }
        
        #endregion

    }
}
