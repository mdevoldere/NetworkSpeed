using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetInterfaceList : List<NetInterface>
    {
        public int CountUp { get; private set; }

        public int FirstUp { get; private set; }

        public NetInterface SelectedInterface { get; private set; }

        protected StringBuilder sb;


        public NetInterfaceList() : base()
        {
            UpdateList();
        }

        public NetInterface GetInterface(int _id)
        {
            SelectedInterface = Find(x => (x.Id == _id));

            if (null != SelectedInterface)
                SelectedInterface.Update();

            return SelectedInterface;
        }

        public NetInterface GetFirstUpInterface()
        {
            return GetInterface(FirstUp);
        }

        public override string ToString()
        {
            sb = new StringBuilder();
            sb.Append("Interfaces (").Append(CountUp.ToString()).Append("/").Append(Count.ToString()).Append(")");
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

            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    NetInterface ni = new NetInterface(nic, Count);

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
