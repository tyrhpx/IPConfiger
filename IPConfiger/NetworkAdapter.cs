using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;

namespace IPConfiger
{
    /// <summary>
    /// 网络适配器类
    /// </summary>
    public class NetworkAdapter
    {
        public string NetworkInterfaceID = "";
        public string Name;
        public string Desc;
        public string Speed;
        public PhysicalAddress MacAddress;
        public GatewayIPAddressInformationCollection Gateways;
        public UnicastIPAddressInformationCollection IPAddrs;
        public IPAddressCollection DhcpServerAddrs;
        public bool IsDhcpEnabled;
        public IPAddressCollection DnsAddrs;
        public string NetworkInterfaceType;
        public ManagementObject MO; /* 管理对象 */

        /// <summary>
        /// 设置IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="getway"></param>
        /// <param name="dns"></param>
        public bool SetIPAddress(string[] ip, string[] submask, string[] getway, string[] dns)
        {
            if (this.MO != null)
            {
                ManagementBaseObject inPar, outPar;
                string str;
                if (ip != null && submask != null)
                {
                    inPar = MO.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = MO.InvokeMethod("EnableStatic", inPar, null);
                    str = outPar["returnvalue"].ToString();
                    return (str == "0" || str == "1") ? true : false;
                    //获取操作设置IP的返回值， 可根据返回值去确认IP是否设置成功。 0或1表示成功 
                    // 返回值说明网址： https://msdn.microsoft.com/en-us/library/aa393301(v=vs.85).aspx
                }
                if (getway != null)
                {
                    inPar = MO.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = getway;
                    outPar = MO.InvokeMethod("SetGateways", inPar, null);
                    str = outPar["returnvalue"].ToString();
                    return (str == "0" || str == "1") ? true : false;
                }
                if (dns != null)
                {
                    inPar = MO.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = MO.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                    str = outPar["returnvalue"].ToString();
                    return (str == "0" || str == "1") ? true : false;
                }
            }
            return false;
        }

        /// <summary>
        /// 启用DHCP服务
        /// </summary>
        public void EnableDHCP()
        {
            if (this.MO != null)
            {
                MO.InvokeMethod("SetDNSServerSearchOrder", null);
                MO.InvokeMethod("EnableDHCP", null);
            }
        }

        /// <summary>
        /// 重载ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
