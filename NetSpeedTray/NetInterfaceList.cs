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

        protected NetworkInterface nic;

        protected StringBuilder sb;

        /*public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/


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
            sb.Append("Networks (").Append(CountUp.ToString()).Append("/").Append(Count.ToString()).Append(")");
            return sb.ToString();
        }

        public void UpdateList()
        {
            nic = null;
            CountUp = 0;
            FirstUp = -1;
            Clear();

            if (NetworkInterface.GetAllNetworkInterfaces().Length == 0)
            {
                return;
            }

            for(int i = 0; i < NetworkInterface.GetAllNetworkInterfaces().Length; i++)
            {
                nic = NetworkInterface.GetAllNetworkInterfaces()[i];

                if (nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    NetInterface ni = new NetInterface(nic, i);

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
