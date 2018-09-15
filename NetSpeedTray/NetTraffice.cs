using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetTraffice
    {
        private const int BYTES_DIVIDER = 1024;

        private static StringBuilder _bytesUnit;   // bytsunit used by BytesFormat method

        private long _lngBytesSend = 0;              // bytes sent storage
        private long _lngBytesReceived = 0;          // bytes received storage

        public string BytesSentText { get; private set; }
        public string BytesReceivedText { get; private set; }

        public long SpeedUp { get; private set; }
        public long SpeedDown { get; private set; }

        public string SpeedUpText { get; private set; }
        public string SpeedDownText { get; private set; }

        public string UnicastPacketsSent { get { return interfaceStatistic?.UnicastPacketsSent.ToString() ?? "0"; } }
        public string UnicastPacketsReceived { get { return interfaceStatistic?.UnicastPacketsReceived.ToString() ?? "0"; } }
 
        NetworkInterface oInterface;

        IPv4InterfaceStatistics interfaceStatistic;

        public NetTraffice()
        {
            _lngBytesSend = 0;
            _lngBytesReceived = 0;
            SpeedUp = 0;
            SpeedDown = 0;
        }

        public NetTraffice(NetworkInterface _oInterface) : this()
        {
            SetInterface(_oInterface);
        }

        public void SetInterface(NetworkInterface _oInterface)
        {
            oInterface = _oInterface;
        }

        public void Update()
        {
            interfaceStatistic = oInterface?.GetIPv4Statistics();

            if(interfaceStatistic != null)
            {
                BytesSentText = BytesFormat(interfaceStatistic.BytesSent, "B", 1024);
                BytesReceivedText = BytesFormat(interfaceStatistic.BytesReceived, "B", 1024);

                SpeedUp = (interfaceStatistic.BytesSent - _lngBytesSend);
                SpeedDown = (interfaceStatistic.BytesReceived - _lngBytesReceived);

                SpeedUpText = BytesFormat(SpeedUp, "B/s", 1024);
                SpeedDownText = BytesFormat(SpeedDown, "B/s", 1024);

                _lngBytesSend = interfaceStatistic?.BytesSent ?? 0;
                _lngBytesReceived = interfaceStatistic?.BytesReceived ?? 0;
            }
        }

        /// <summary>
        /// Format Bytes to string
        /// </summary>
        /// <param name="iValue">bytes value</param>
        /// <param name="sFormat"></param>
        /// <param name="iDivider">1000 or 1024</param>
        /// <returns></returns>
        public static string BytesFormat(double iValue, string sFormat, int iDivider)
        {
            if (iValue == 0)
                return "0";

            _bytesUnit = new StringBuilder(sFormat, 5);

            if (iValue > 1073741824) // 1gb
            {
                iValue = iValue / iDivider / iDivider / iDivider;
                _bytesUnit.Insert(0, "G");
            }
            else if (iValue > 1048576) // 1mb
            {
                iValue = iValue / iDivider / iDivider;
                _bytesUnit.Insert(0, "M");
            }
            else if (iValue > 1024) // 1kb
            {
                iValue = iValue / iDivider;
                _bytesUnit.Insert(0, "K");
            }

            _bytesUnit.Insert(0, " ");

            return iValue.ToString("#.##") + _bytesUnit.ToString();
        }
    }
}
