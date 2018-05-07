using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetInterfaceManager
    {
        public List<NetInterface> InterfaceList { get; protected set; }

        public int numInterfaceUp;

        public int FirstUpInterfaceId;

        protected StringBuilder sb;

        public NetInterfaceManager()
        {
            InterfaceList = new List<NetInterface>();
            sb = new StringBuilder();
        }

        public void Update()
        {
            if (NetworkInterface.GetAllNetworkInterfaces().Length == 0)
            {
                throw new Exception("No network interface");
            }

            numInterfaceUp = 0;
            FirstUpInterfaceId = -1;
            InterfaceList.Clear();

            for (int i = 0; i < NetworkInterface.GetAllNetworkInterfaces().Length; i++)
            {
                if (NetworkInterface.GetAllNetworkInterfaces()[i].NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    NetInterface oInterface = new NetInterface(i);

                    if (oInterface.State.Up)
                    {
                        numInterfaceUp++;

                        if(FirstUpInterfaceId == -1)
                        {
                            FirstUpInterfaceId = i;
                        }
                    }

                    oInterface.Update();
                    InterfaceList.Add(oInterface);
                }
            }

            if (InterfaceList.Count < 1)
            {
                throw new NullReferenceException("No valid network interface");
            }

            if(FirstUpInterfaceId == -1)
            {
                FirstUpInterfaceId = 0;
            }
        }

        public NetInterface GetInterface(int _id)
        {
            NetInterface o = InterfaceList.Find(x => (x.Id == _id));

            if (null != o)
                o.Update();

            return o;
        }

        public NetInterface GetFirstUpInterface(int _id)
        {
            return GetInterface(FirstUpInterfaceId);
        }

        public override string ToString()
        {
            StringBuilder sb =  new StringBuilder("Interfaces ");
            sb.Append("(").Append(numInterfaceUp.ToString()).Append("/").Append(InterfaceList.Count.ToString()).Append(")");
            return sb.ToString();
        }
    }
}
