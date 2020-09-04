using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;

namespace IPConfiger
{
    /// <summary>
    /// 网络适配器类
    /// </summary>
    public class NetworkAdapter
    {
        /// <summary>
        /// 适配器ID
        /// </summary>
        public string ID
        {
            get
            {
                return NetIF.Id;
            }
        }

        /// <summary>
        /// 适配器类型
        /// </summary>
        public string Type
        {
            get
            {
                return NetIF.NetworkInterfaceType.ToString();
            }
        }

        /// <summary>
        /// 适配器名称
        /// </summary>
        public string Name
        {
            get
            {
                return NetIF.Name;
            }
        }

        /// <summary>
        /// 适配器描述
        /// </summary>
        public string Desc
        {
            get
            {
                return NetIF.Description;
            }
        }

        /// <summary>
        /// MAC地址
        /// </summary>
        public PhysicalAddress MacAddress
        {
            get
            {
                return NetIF.GetPhysicalAddress();
            }
        }

        /// <summary>
        /// 网关列表
        /// </summary>
        public GatewayIPAddressInformationCollection Gateways
        {
            get 
            {
                return NetIF.GetIPProperties().GatewayAddresses;
            }
        }

        /// <summary>
        /// IP地址列表
        /// </summary>
        public UnicastIPAddressInformationCollection IPAddrs
        {
            get
            {
                return NetIF.GetIPProperties().UnicastAddresses;
            }
        }

        /// <summary>
        /// DHCP列表
        /// </summary>
        public IPAddressCollection DhcpServerAddrs
        {
            get
            {
                return NetIF.GetIPProperties().DhcpServerAddresses;
            }
        }

        /// <summary>
        /// DNS列表
        /// </summary>
        public IPAddressCollection DnsAddrs
        {
            get
            {
                return NetIF.GetIPProperties().DnsAddresses;
            }
        }

        /// <summary>
        /// 是否启用DHCP
        /// </summary>
        public bool DhcpEnabled
        {
            get
            {
                var ips = NetIF.GetIPProperties().GetIPv4Properties();
                if (ips != null)
                {
                    return ips.IsDhcpEnabled;
                }
                return false;
            }
        }

        /// <summary>
        /// 是否为环回网卡
        /// </summary>
        public bool IsLoopback
        {
            get
            {
                var x = this.MO["ServiceName"];
                if (x != null)
                {
                    return x.ToString().Contains("loop");
                }
                return false;
            }
        }


        public ManagementObject MO; /* 网络管理对象 */
        public NetworkInterface NetIF; /* 网络接口 */


        /// <summary>
        /// 构造函数
        /// </summary>
        public NetworkAdapter(NetworkInterface ni)
        {
            this.Update(ni);
        }

        /// <summary>
        /// 获取所有网络适配器接口
        /// </summary>
        /// <returns></returns>
        public static List<NetworkAdapter> GetAllNetworkAdapters()
        {
            IEnumerable<NetworkInterface> nics = NetworkInterface.GetAllNetworkInterfaces(); //得到所有适配器
            var result = new List<NetworkAdapter>();

            // 遍历网络接口
            foreach (NetworkInterface ni in nics)
            {
                // Only display informatin for interfaces that support IPv4.
                if (ni.Supports(NetworkInterfaceComponent.IPv4) == false)
                {
                    continue;
                }

                // 创建适配器对象
                var adapter = new NetworkAdapter(ni);
                if (adapter.Type == "Ethernet")
                {
                    result.Add(adapter);       
                }
            }
            return result;
        }

        /// <summary>
        /// 获取网络适配器管理对象
        /// </summary>
        /// <param name="interfaceID">接口ID</param>
        /// <returns></returns>
        public static ManagementObject GetNetManageObj(string interfaceID)
        {
            var moc = new ManagementObjectSearcher("select * FROM Win32_NetworkAdapterConfiguration");
            foreach (ManagementObject mo in moc.Get())
            {
                if (mo["SettingID"].ToString() == interfaceID) //网卡接口标识是否相等, 相当只设置指定适配器IP地址
                {
                    return mo;
                }
            }
            return null;
        }

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
                if (ip != null && submask != null && ip.Length > 0)
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
        /// 刷新
        /// </summary>
        public void Update(NetworkInterface ni)
        {
            this.NetIF = ni;
            this.MO = NetworkAdapter.GetNetManageObj(this.ID);
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        public void Reload()
        {
            IEnumerable<NetworkInterface> adapters = NetworkInterface.GetAllNetworkInterfaces(); //得到所有适配器
            foreach (var x in adapters)
            {
                if (x.Id == this.ID)
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
        //    return string.Format("[{4}] {0}(IPEnable={1}, DHCPEnabled={2}, NetEnabled={3})", this.Name, this.IPEnabled, this.DhcpEnabled, this.NetEnabled,
        //        this.NetEnabled ? "已启用" : "已禁用");

            var s = this.Name;
            if (this.DhcpEnabled)
            {
                s += "(DHCP)";
            }
            return s;
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
