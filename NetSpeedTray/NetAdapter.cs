using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Devoldere.NetSpeedTray
{
    public class NetAdapter
    {
        static StringBuilder sb = new StringBuilder();

        public int Id { get; private set; }

        public NetState State { get; protected set; }

        public string StateText { get { return State?.Text ?? "Down"; } }


        public NetworkInterface NetInterface { get; protected set; }

        public string Name { get { return NetInterface.Name ?? "Network"; } }
        
        public string Mac { get { return NetInterface.GetPhysicalAddress().HumanReadable() ?? "00:00:00:00:00:00"; } }

        public string Speed { get { return ((NetInterface.Speed / 1000000).ToString() + " Mbps"); } }


        public IPInterfaceProperties IpProperties { get; protected set; }

        public UnicastIPAddressInformation Ipv4Address { get; protected set; }

        public UnicastIPAddressInformation Ipv6Addess { get; protected set; }

        public string Ipv4 { get { return Ipv4Address?.Address.ToString() ?? "0.0.0.0"; } }

        public string Ipv4Mask { get { return Ipv4Address?.IPv4Mask.ToString() ?? "255.255.255.255"; } }

        public string Ipv4Prefix { get { return Ipv4Address?.PrefixLength.ToString() ?? "32"; } }

        public string Ipv6 { get { return Ipv6Addess?.Address.ToString() ?? "fe80::"; } }

        public string Ipv6Prefix { get { return Ipv6Addess?.PrefixLength.ToString() ?? "64"; } }


        public IPv4InterfaceStatistics IpStatistic { get; protected set; }

        private long _lngBytesSend = 0;              // bytes sent storage
        private long _lngBytesReceived = 0;          // bytes received storage

        public long BytesSent { get { return IpStatistic?.BytesSent ?? 0; } }
        public long BytesReceived { get { return IpStatistic?.BytesReceived ?? 0; } }

        public string BytesSentText { get { return BytesSent.BytesFormat("B"); } }
        public string BytesReceivedText { get { return BytesReceived.BytesFormat("B"); } }

        public long SpeedUp { get; private set; } = 0;
        public long SpeedDown { get; private set; } = 0;

        public string SpeedUpText { get { return SpeedUp.BytesFormat("B/s"); } }
        public string SpeedDownText { get { return SpeedDown.BytesFormat("B/s"); } }
        
        public string TrafficeText { get { return ("Up: " + SpeedUpText + " / Down: " + SpeedDown.BytesFormat("B/s")); } }

        public string UnicastPacketsSent { get { return IpStatistic?.UnicastPacketsSent.ToString() ?? "0"; } }
        public string UnicastPacketsReceived { get { return IpStatistic?.UnicastPacketsReceived.ToString() ?? "0"; } }




        public NetAdapter(NetworkInterface _interface) : this(_interface, 0)
        {
        }

        public NetAdapter(NetworkInterface _interface, int _key)
        {
            Id = _key;
            NetInterface = _interface;
            State = new NetState();
            Update();
        }

        public void Update()
        {
            State.SetState(NetInterface.OperationalStatus);
            
            IpProperties = NetInterface.GetIPProperties();

            if(IpProperties == null)
            {
                return;
            }

            foreach(UnicastIPAddressInformation ip in IpProperties.UnicastAddresses)
            {
                if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6 && Ipv6Addess == null)
                {
                    Ipv6Addess = ip;

                }
                else if (ip.Address.AddressFamily == AddressFamily.InterNetwork && Ipv4Address == null)
                {
                    Ipv4Address = ip;
                }
            }

            return;
        }

        public void UpdateTraffice()
        {
            if (State.Up)
            {
                IpStatistic = NetInterface?.GetIPv4Statistics();

                if (IpStatistic != null)
                {
                    SpeedUp = (IpStatistic.BytesSent - _lngBytesSend);
                    SpeedDown = (IpStatistic.BytesReceived - _lngBytesReceived);

                    _lngBytesSend = IpStatistic.BytesSent;
                    _lngBytesReceived = IpStatistic.BytesReceived;
                }
            }
        }


        public override string ToString()
        {
            sb.Clear();

            sb.Append(NetInterface.Name).Append(" - ").AppendLine(Speed);
            sb.AppendLine(Mac).Append(Ipv4).Append("/").AppendLine(Ipv4Prefix);
            sb.AppendLine(Ipv4Mask);

            return sb.ToString();
        }

    }
}
