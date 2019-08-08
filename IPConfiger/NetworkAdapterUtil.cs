using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Management;

namespace IPConfiger
{
    public class NetworkAdapterUtil
    {
        /// <summary>
        /// 获取所有适配器类型，适配器被禁用则不能获取到
        /// </summary>
        /// <returns></returns>
        public static List<NetworkAdapter> GetAllNetworkAdapters() //如果适配器被禁用则不能获取到
        {
            IEnumerable<NetworkInterface> adapters = NetworkInterface.GetAllNetworkInterfaces(); //得到所有适配器
            return GetNetworkAdapters(adapters);
        }

        /// <summary>
        /// 根据条件获取IP地址集合，
        /// </summary>
        /// <param name="adapters">网络接口地址集合</param>
        /// <param name="adapterTypes">网络连接状态，如,UP,DOWN等</param>
        /// <returns></returns>
        private static List<NetworkAdapter> GetNetworkAdapters(IEnumerable<NetworkInterface> adapters, params NetworkInterfaceType[] networkInterfaceTypes)
        {
            var adapterList = new List<NetworkAdapter>();

            foreach (NetworkInterface adapter in adapters)
            {
                if (networkInterfaceTypes.Length <= 0) //如果没传可选参数，就查询所有
                {
                    if (adapter != null)
                    {
                        NetworkAdapter adp = SetNetworkAdapterValue(adapter);
                        if (adp.NetworkInterfaceType == "Ethernet")
                        {
                            adapterList.Add(adp);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else //过滤查询数据
                {
                    foreach (NetworkInterfaceType networkInterfaceType in networkInterfaceTypes)
                    {
                        if (adapter.NetworkInterfaceType.ToString().Equals(networkInterfaceType.ToString()))
                        {
                            NetworkAdapter adp = SetNetworkAdapterValue(adapter);
                            if (adp.NetworkInterfaceType == "Ethernet")
                            {
                                adapterList.Add(adp);
                            }
                            break; //退出当前循环
                        }
                    }
                }
            }
            return adapterList;
        }

        /// <summary>
        /// 设置网络适配器信息
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        private static NetworkAdapter SetNetworkAdapterValue(NetworkInterface adapter)
        {
            NetworkAdapter adp = new NetworkAdapter();
            adp.Update(adapter);
            return adp;
        }

        /// <summary>
        /// 获取网张适配器管理对象
        /// </summary>
        /// <param name="interfaceID">接口ID</param>
        /// <returns></returns>
        public static ManagementObject GetManageObj(string interfaceID)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                if (mo["SettingID"].ToString() == interfaceID) //网卡接口标识是否相等, 相当只设置指定适配器IP地址
                {
                    return mo;
                }
            }
            return null;
        }
    }
}
