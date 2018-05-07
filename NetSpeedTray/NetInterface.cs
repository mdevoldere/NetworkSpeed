using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetInterface
    {

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Ip { get; private set; }

        public string NetMask { get; private set; }

        public string Text { get; private set; }
        
        public long Mbps { get; private set; }

        public NetworkInterface OInterface { get; private set; }

        public NetState State { get; private set; }

        public NetTraffice Traffice { get; private set; }


        IPInterfaceProperties ipProperties;

        int adressId;

        public NetInterface(int _key)
        {
            Id = _key;

            State = new NetState();

            Traffice = new NetTraffice();
        }

        public NetState Update()
        {
            if (Id < NetworkInterface.GetAllNetworkInterfaces().Length)
            {
                OInterface = NetworkInterface.GetAllNetworkInterfaces()[Id];
                Traffice.SetInterface(OInterface);
            }
            else
            {
                throw new Exception("No interface at postion " + Id.ToString());
            }

            UpdateInfo();

            return State;
        }

        protected void UpdateInfo()
        {
            State.SetState(OInterface.OperationalStatus);
            Name = OInterface.Name + " (" + State.Text + ")";
            NetMask = "";
            Text = OInterface.Name;

            if(!State.Up)
            {
                Ip = "0.0.0.0";
                Mbps = 0;
                Text += "\rDown";
                return;
            }

            
            Mbps = (OInterface.Speed / 1000000);

            ipProperties = OInterface.GetIPProperties();

            adressId = -1;

            if(ipProperties.UnicastAddresses.Count < 1)
            {
                Ip = "0.0.0.0";
            }
            else if ((ipProperties.UnicastAddresses.Count > 1) && (null != ipProperties.UnicastAddresses[1].Address))
            {
                adressId = 1;
            }
            else
            {
                adressId = 0;
            }

            if(adressId > -1)
            {
                Ip = ipProperties.UnicastAddresses[adressId].Address.ToString();
                if (null != (ipProperties.UnicastAddresses[adressId].IPv4Mask))
                    NetMask = ipProperties.UnicastAddresses[adressId].IPv4Mask.ToString();
            }

            Text += "\r" + Ip + "\r" + NetMask + "\r" + Mbps.ToString() + " Mbps";

        }

        public void UpdateTraffice()
        {
            Traffice.Update();
        }
    }
}
