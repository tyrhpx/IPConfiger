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
        public static void ListNetworkAdapters()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");

            using (var searcher = new ManagementObjectSearcher(query))
            {
                var queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    Console.WriteLine("\n--------------------------------------------");
                    PrintProperty(m, "AdapterType");
                    PrintProperty(m, "AdapterTypeID");
                    PrintProperty(m, "AutoSense");
                    PrintProperty(m, "Availability");
                    PrintProperty(m, "Caption");
                    PrintProperty(m, "ConfigManagerErrorCode");
                    PrintProperty(m, "ConfigManagerUserConfig");
                    PrintProperty(m, "CreationClassName");
                    PrintProperty(m, "Description");
                    PrintProperty(m, "DeviceID");
                    PrintProperty(m, "ErrorCleared");
                    PrintProperty(m, "ErrorDescription");
                    PrintProperty(m, "GUID");
                    PrintProperty(m, "Index");
                    PrintProperty(m, "InstallDate");
                    PrintProperty(m, "Installed");
                    PrintProperty(m, "InterfaceIndex");
                    PrintProperty(m, "LastErrorCode");
                    PrintProperty(m, "MACAddress");
                    PrintProperty(m, "Manufacturer");
                    PrintProperty(m, "MaxNumberControlled");
                    PrintProperty(m, "MaxSpeed");
                    PrintProperty(m, "Name");
                    PrintProperty(m, "NetConnectionID");
                    PrintProperty(m, "NetConnectionStatus");
                    PrintProperty(m, "NetEnabled");
                    PrintProperty(m, "NetworkAddresses");
                    PrintProperty(m, "PermanentAddress");
                    PrintProperty(m, "PhysicalAdapter");
                    PrintProperty(m, "PNPDeviceID");
                    PrintProperty(m, "PowerManagementCapabilities");
                    PrintProperty(m, "PowerManagementSupported");
                    PrintProperty(m, "ProductName");
                    PrintProperty(m, "ServiceName");
                    PrintProperty(m, "Speed");
                    PrintProperty(m, "Status");
                    PrintProperty(m, "StatusInfo");
                    PrintProperty(m, "SystemCreationClassName");
                    PrintProperty(m, "SystemName");
                    PrintProperty(m, "TimeOfLastReset");
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
            /* https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-networkadapter*/
        }

        public static void ListNetworkAdapters2()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration");

            using (var searcher = new ManagementObjectSearcher(query))
            {
                var queryCollection = searcher.Get();

                foreach (ManagementObject m in queryCollection)
                {
                    Console.WriteLine("\n--------------------------------------------");
                    PrintProperty(m, "Caption");
                    PrintProperty(m, "Description");
                    PrintProperty(m, "SettingID");
                    PrintProperty(m, "ArpAlwaysSourceRoute");
                    PrintProperty(m, "ArpUseEtherSNAP");
                    PrintProperty(m, "DatabasePath");
                    PrintProperty(m, "DeadGWDetectEnabled");
                    PrintProperty(m, "DefaultIPGateway");
                    PrintProperty(m, "DefaultTOS");
                    PrintProperty(m, "DefaultTTL");
                    PrintProperty(m, "DHCPEnabled");
                    PrintProperty(m, "DHCPLeaseExpires");
                    PrintProperty(m, "DHCPLeaseObtained");
                    PrintProperty(m, "DHCPServer");
                    PrintProperty(m, "DNSDomain");
                    PrintProperty(m, "DNSDomainSuffixSearchOrder");
                    PrintProperty(m, "DNSEnabledForWINSResolution");
                    PrintProperty(m, "DNSHostName");
                    PrintProperty(m, "DNSServerSearchOrder");
                    PrintProperty(m, "DomainDNSRegistrationEnabled");
                    PrintProperty(m, "ForwardBufferMemory");
                    PrintProperty(m, "FullDNSRegistrationEnabled");
                    PrintProperty(m, "GatewayCostMetric");
                    PrintProperty(m, "IGMPLevel");
                    PrintProperty(m, "Index");
                    PrintProperty(m, "InterfaceIndex");
                    PrintProperty(m, "IPAddress");
                    PrintProperty(m, "IPConnectionMetric");
                    PrintProperty(m, "IPEnabled");
                    PrintProperty(m, "IPFilterSecurityEnabled");
                    PrintProperty(m, "IPPortSecurityEnabled");
                    PrintProperty(m, "IPSecPermitIPProtocols");
                    PrintProperty(m, "IPSecPermitTCPPorts");
                    PrintProperty(m, "IPSecPermitUDPPorts");
                    PrintProperty(m, "IPSubnet");
                    PrintProperty(m, "IPUseZeroBroadcast");
                    PrintProperty(m, "IPXAddress");
                    PrintProperty(m, "IPXEnabled");
                    PrintProperty(m, "IPXFrameType");
                    PrintProperty(m, "IPXMediaType");
                    PrintProperty(m, "IPXNetworkNumber");
                    PrintProperty(m, "IPXVirtualNetNumber");
                    PrintProperty(m, "KeepAliveInterval");
                    PrintProperty(m, "KeepAliveTime");
                    PrintProperty(m, "MACAddress");
                    PrintProperty(m, "MTU");
                    PrintProperty(m, "NumForwardPackets");
                    PrintProperty(m, "PMTUBHDetectEnabled");
                    PrintProperty(m, "PMTUDiscoveryEnabled");
                    PrintProperty(m, "ServiceName");
                    PrintProperty(m, "TcpipNetbiosOptions");
                    PrintProperty(m, "TcpMaxConnectRetransmissions");
                    PrintProperty(m, "TcpMaxDataRetransmissions");
                    PrintProperty(m, "TcpNumConnections");
                    PrintProperty(m, "TcpUseRFC1122UrgentPointer");
                    PrintProperty(m, "TcpWindowSize");
                    PrintProperty(m, "WINSEnableLMHostsLookup");
                    PrintProperty(m, "WINSHostLookupFile");
                    PrintProperty(m, "WINSPrimaryServer");
                    PrintProperty(m, "WINSScopeID");
                    PrintProperty(m, "WINSSecondaryServer");
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
            /* https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-networkadapterconfiguration */
        }

        private static void PrintProperty(ManagementObject m, string pp)
        {
            Console.WriteLine("{0} = {1} -- {2}", pp, m[pp], m[pp]!=null ? m[pp].GetType() : null);
        }
    }
}
