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
        public NetworkInterface NetIF;

        /// <summary>
        /// 设置IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="getway"></param>
        /// <param name="dns"></param>
        public bool SetIPAddress(string[] ip, string[] submask, string[] getway, string[] dns, ref string err)
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
                    if (ErrInfoMap.ContainsKey(str))
                    {
                        err = ErrInfoMap[str];
                    }
                    else
                    {
                        err = str;
                    }
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
                    if (ErrInfoMap.ContainsKey(str))
                    {
                        err = ErrInfoMap[str];
                    }
                    else
                    {
                        err = str;
                    }
                    return (str == "0" || str == "1") ? true : false;
                }
                if (dns != null)
                {
                    inPar = MO.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = MO.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                    str = outPar["returnvalue"].ToString();
                    if (ErrInfoMap.ContainsKey(str))
                    {
                        err = ErrInfoMap[str];
                    }
                    else
                    {
                        err = str;
                    }
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
        /// 刷新
        /// </summary>
        public void Update(NetworkInterface adapter)
        {
            this.NetIF = adapter;

            IPInterfaceProperties ips = NetIF.GetIPProperties();
            this.Name = NetIF.Name;
            this.NetworkInterfaceType = NetIF.NetworkInterfaceType.ToString();
            this.Speed = NetIF.Speed / 1000 / 1000 + "MB"; //速度
            this.MacAddress = NetIF.GetPhysicalAddress(); //物理地址集合
            this.NetworkInterfaceID = NetIF.Id;//网络适配器标识符

            this.Gateways = ips.GatewayAddresses; //网关地址集合
            this.IPAddrs = ips.UnicastAddresses; //IP地址集合
            this.DhcpServerAddrs = ips.DhcpServerAddresses;//DHCP地址集合
            this.IsDhcpEnabled = ips.GetIPv4Properties() == null ? false : ips.GetIPv4Properties().IsDhcpEnabled; //是否启用DHCP服务
            this.DnsAddrs = ips.DnsAddresses; //获取并显示DNS服务器IP地址信息 集合

            this.MO = NetworkAdapterUtil.GetManageObj(NetIF.Id);
            if (this.MO != null)
            {
                this.Desc = this.MO["Description"].ToString();
            }
        }

        /// <summary>
        /// 重新加载数据
        /// </summary>
        public void ReloadData()
        {
            IEnumerable<NetworkInterface> adapters = NetworkInterface.GetAllNetworkInterfaces(); //得到所有适配器
            foreach (var x in adapters)
            {
                if (x.Id == this.NetworkInterfaceID )
                {
                    this.Update(x);
                    break;
                }
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

        #region 错误代码信息表
        /// <summary>
        /// 错误代码信息表
        /// </summary>
        private Dictionary<string, string> ErrInfoMap = new Dictionary<string, string>()
        {
            {"0", "Successful completion, no reboot required"},
            {"1", "Successful completion, reboot required"},
            {"64", "Method not supported on this platform"},
            {"65", "Method not supported when the NIC is in DHCP mode."},
            {"66", "Invalid subnet mask"},
            {"67", "An error occurred while processing an Instance that was returned"},
            {"68", "Invalid input parameter"},
            {"69", "More than 5 gateways specified"},
            {"70", "Invalid IP address"},
            {"71", "Invalid gateway IP address"},
            {"72", "An error occurred while accessing the Registry for the requested information"},
            {"73", "Invalid domain name"},
            {"74", "Invalid host name"},
            {"75", "No primary/secondary WINS server defined"},
            {"76", "Invalid file"},
            {"77", "Invalid system path"},
            {"78", "File copy failed"},
            {"79", "Invalid security parameter"},
            {"80", "Unable to configure TCP/IP service"},
            {"81", "Unable to configure DHCP service"},
            {"82", "Unable to renew DHCP lease"},
            {"83", "Unable to release DHCP lease"},
            {"84", "IP not enabled on adapter"},
            {"85", "IPX not enabled on adapter"},
            {"86", "Frame/network number bounds error"},
            {"87", "Invalid frame type"},
            {"88", "Invalid network number"},
            {"89", "Duplicate network number"},
            {"90", "Parameter out of bounds"},
            {"91", "Access denied"},
            {"92", "Out of memory"},
            {"93", "Already exists"},
            {"94", "Path, file or object not found"},
            {"95", "Unable to notify service"},
            {"96", "Unable to notify DNS service"},
            {"97", "Interface not configurable"},
            {"98", "Not all DHCP leases could be released/renewed"},
            {"99", "Successful"},
            {"100", "DHCP not enabled on adapter"},
            {"101", "Other"},
        };
        #endregion
    }
}
