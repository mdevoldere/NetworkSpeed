using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray
{
    public static class NetExtensions
    {
        static string _macRegex = "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})";
        static string _macReplace = "$1:$2:$3:$4:$5:$6";

        static double _kbytesDivider = 1024;
        static double _mbytesDivider = Math.Pow(_kbytesDivider, 2);
        static double _gbytesDivider = Math.Pow(_kbytesDivider, 3);
        static double _tbytesDivider = Math.Pow(_kbytesDivider, 4);

        static StringBuilder _bytesUnit;

        /// <summary>
        /// Format Physical Address to human readable string
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        public static string HumanReadable(this PhysicalAddress _input)
        {
            return Regex.Replace(_input.ToString(), _macRegex, _macReplace);
        }

        /// <summary>
        /// Add the multiplier according to iValue for sFormat
        /// </summary>
        /// <param name="iValue">Base value</param>
        /// <param name="sFormat">Measure unit</param>
        /// <returns></returns>
        public static string BytesFormat(this double iValue, string sFormat = "B")
        {
            _bytesUnit = new StringBuilder(sFormat, 5);

            if (iValue < 1)
                return 0.ToString();


            if (iValue >= _tbytesDivider) // 1tb
            {
                iValue = iValue / _tbytesDivider;
                _bytesUnit.Insert(0, "T");
            }
            if (iValue >= _gbytesDivider) // 1gb
            {
                iValue = iValue / _gbytesDivider;
                _bytesUnit.Insert(0, "G");
            }
            else if (iValue >= _mbytesDivider) // 1mb
            {
                iValue = iValue / _mbytesDivider;
                _bytesUnit.Insert(0, "M");
            }
            else if (iValue >= _kbytesDivider) // 1kb
            {
                iValue = iValue / _kbytesDivider;
                _bytesUnit.Insert(0, "K");
            }

            _bytesUnit.Insert(0, " ");

            return iValue.ToString("#.##") + _bytesUnit.ToString();
        }

        public static string BytesFormat(this long iValue, string sFormat = "B")
        {
            return Convert.ToDouble(iValue).BytesFormat(sFormat);
        }

        /// <summary>
        /// int example = 152;
        /// Console.WriteLine(example.Round(100)); // round to the nearest 100
        /// Console.WriteLine(example.Round(10)); // round to the nearest 10
        /// </summary>
        /// <param name="i"></param>
        /// <param name="nearest"></param>
        /// <returns></returns>
        public static int Round(this int i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }

        public static long Round(this long i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }
    }
}
