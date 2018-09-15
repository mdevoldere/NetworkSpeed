using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

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


        public string StateText { get { return State.Text; } }

        public string TrafficeDown { get { return Traffice.SpeedDownText; } }
        
        public string TrafficeUp { get { return Traffice.SpeedUpText; } }


        IPInterfaceProperties ipProperties;

        int adressId;

        public NetInterface(NetworkInterface _interface)
        {
            Id = 0;
            SetInterface(_interface);
        }

        public NetInterface(NetworkInterface _interface, int _key)
        {
            Id = _key;
            SetInterface(_interface);
        }

        public NetInterface(int _key)
        {
            Id = _key;

            if (Id >= 0 && Id < NetworkInterface.GetAllNetworkInterfaces().Length)
            {
                SetInterface(NetworkInterface.GetAllNetworkInterfaces()[Id]);
            }
            else
            {
                throw new Exception("No interface at postion " + Id.ToString());
            }            
        }

        protected void SetInterface(NetworkInterface _interface)
        {
            OInterface = _interface;
            State = new NetState(OInterface.OperationalStatus);
            Traffice = new NetTraffice(OInterface);
            Update();
        }

        public NetState Update()
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
                //return State;
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

            var macRegex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
            var macReplace = "$1:$2:$3:$4:$5:$6";
            var macFormat = Regex.Replace(OInterface.GetPhysicalAddress().ToString(), macRegex, macReplace);

            Text +=  " - " + Mbps.ToString() + " Mbps\r" + macFormat + "\r" + Ip + "\r" + NetMask;

            return State;
        }

        public void UpdateTraffice()
        {
            if(State.Up)
                Traffice.Update();
        }
    }
}
