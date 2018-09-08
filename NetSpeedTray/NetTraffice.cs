using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public class NetTraffice
    {


        long lngBytesSend = 0;              // bytes sent storage
        long lngBytesReceived = 0;          // bytes received storage

        private StringBuilder _bytesUnit;   // bytsunit used by BytesFormat method

        public long BytesSentSpeed { get; private set; }
        public long BytesReceivedSpeed { get; private set; }

        public string UnicastPacketsSent { get { return interfaceStatistic?.UnicastPacketsSent.ToString() ?? "0"; } }

        public string UnicastPacketsReceived { get { return interfaceStatistic?.UnicastPacketsReceived.ToString() ?? "0"; } }

        public string BytesSentText { get; private set; }

        public string BytesReceivedText { get; private set; }

        public string BytesSentSpeedText { get; private set; }

        public string BytesReceivedSpeedText { get; private set; }

        NetworkInterface oInterface;

        IPv4InterfaceStatistics interfaceStatistic;

        public NetTraffice()
        {
            BytesSentSpeed = 0;
            BytesReceivedSpeed = 0;
        }

        public NetTraffice(NetworkInterface _oInterface)
        {
            SetInterface(_oInterface);
        }

        public void SetInterface(NetworkInterface _oInterface)
        {
            BytesSentSpeed = 0;
            BytesReceivedSpeed = 0;
            lngBytesSend = 0;
            lngBytesReceived = 0;
            oInterface = _oInterface;
        }

        public void Update()
        {
            interfaceStatistic = oInterface.GetIPv4Statistics();

            BytesSentSpeed = (interfaceStatistic.BytesSent - lngBytesSend);
            BytesReceivedSpeed = (interfaceStatistic.BytesReceived - lngBytesReceived);
            
            BytesSentText = BytesFormat(interfaceStatistic.BytesSent, "B", 1024);
            BytesReceivedText = BytesFormat(interfaceStatistic.BytesReceived, "B", 1024);
            
            BytesSentSpeedText = BytesFormat(BytesSentSpeed, "B/s", 1024);
            BytesReceivedSpeedText = BytesFormat(BytesReceivedSpeed, "B/s", 1024);
            
            lngBytesSend = interfaceStatistic.BytesSent;
            lngBytesReceived = interfaceStatistic.BytesReceived;
        }

        /// <summary>
        /// Format Bytes to string
        /// </summary>
        /// <param name="iValue">bytes value</param>
        /// <param name="sFormat"></param>
        /// <param name="iDivider">1000 or 1024</param>
        /// <returns></returns>
        public string BytesFormat(double iValue, string sFormat, int iDivider)
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
