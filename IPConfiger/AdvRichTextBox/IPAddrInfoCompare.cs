using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace IPConfiger
{
    /// <summary>
    /// IP地址比较器
    /// </summary>
    public class IPAddrInfoCompare : IComparer<UnicastIPAddressInformation>
    {
        public int Compare(UnicastIPAddressInformation x, UnicastIPAddressInformation y)
        {
            var ipX = x.Address.GetAddressBytes();
            var ipY = y.Address.GetAddressBytes();
            int ret = 0;

            if (ipX.Length == ipY.Length)
            {
                for (int i = 0; i < ipX.Length; i++)
                {
                    if (ipX[i] != ipY[i])
                    {
                        ret = ipX[i] - ipY[i];
                        break;
                    }
                }
            }
            else
            {
                ret = ipX.Length - ipY.Length;
            }
            return ret;
        }
    }
}
