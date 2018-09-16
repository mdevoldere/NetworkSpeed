using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetAdapterList : List<NetAdapter>
    {
        public int CountUp { get; private set; }

        public int FirstUp { get; private set; }

        public NetAdapter SelectedItem { get; private set; }

        protected static StringBuilder sb = new StringBuilder();


        public NetAdapterList() : base()
        {
            UpdateList();
        }

        public NetAdapter GetInterface(int _id)
        {
            SelectedItem = Find(x => (x.Id == _id));

            if (null != SelectedItem)
                SelectedItem.Update();

            return SelectedItem;
        }

        public NetAdapter GetFirstUpInterface()
        {
            return GetInterface(FirstUp);
        }

        public override string ToString()
        {
            sb.Clear();
            sb.Append("Networks (").Append(CountUp.ToString()).Append("/").Append(Count.ToString()).Append(")");
            return sb.ToString();
        }

        public void UpdateList()
        {
            CountUp = 0;
            FirstUp = -1;
            Clear();

            if (NetworkInterface.GetAllNetworkInterfaces().Length == 0)
            {
                return;
            }

            for(int i = 0; i < NetworkInterface.GetAllNetworkInterfaces().Length; i++)
            {
                NetworkInterface nic = NetworkInterface.GetAllNetworkInterfaces()[i];

                if (nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    NetAdapter ni = new NetAdapter(nic, i);

                    if (ni.State.Up)
                    {
                        CountUp++;

                        if (FirstUp == -1)
                        {
                            FirstUp = ni.Id;
                        }
                    }

                    ni.Update();
                    Add(ni);
                }

            }

            if (FirstUp == -1)
            {
                FirstUp = (Count - 1);
            }
        }
    }
}
