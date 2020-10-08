using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace ns.Network
{
    public class IpConfig
    {
        public static IPAddress[] ListIpAddresses()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return null;

            var host = Dns.GetHostEntry(Dns.GetHostName());

            var addresses = host.AddressList;

            return addresses;
        }

        public static IPAddress[] ListIpV4Addresses()
        {
            var addresses = ListIpAddresses();
            if (addresses is null) return null;


            return addresses.Where(x => !x.IsIPv6LinkLocal && !x.IsIPv6Multicast && !x.IsIPv6SiteLocal && !x.IsIPv6Teredo).ToArray();

        }

        public static IPAddress[] IpRangeForIpAddress(IPAddress ip)
        {
            var ipBytes = ip.GetAddressBytes();
            byte[] startIp = (byte[]) ipBytes.Clone();
            byte[] lastIp = (byte[]) ipBytes.Clone();


            startIp[3] = 1;
            lastIp[3] = 254;


            IPAddress[] result = new IPAddress[2];
            result[0] = new IPAddress(startIp);
            result[1] = new IPAddress(lastIp);

            return result;
        }
    }
}
