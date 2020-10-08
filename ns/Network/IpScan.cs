using ns.Network.Scanners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ns.Network
{
    public class IpScan
    {
        public List<Device> ScanIpRange(ScanParameters parameters)
        {
            var devices = new List<Device>();

            var pingScan = new PingScanner();

            var ips = EnumerateIps(parameters.StartIp, parameters.LastIp);

            Parallel.ForEach(ips, (currentIp) =>
            {
                if (pingScan.CheckIp(currentIp)) devices.Add(new Device { Ip = currentIp });
            });

            return devices;
        }
        public static string[] ListAll()
        {
            var devices = new string[]
            {
                new Device{ Ip= IPAddress.Parse( "192.168.0.1"), Name =DateTime.Now.ToString()}.ToString(),
                new Device{ Ip= IPAddress.Parse( "192.168.0.2"), Name ="unkwown"}.ToString(),
                new Device{ Ip=IPAddress.Parse( "192.168.0.3"), Name ="unkwown"}.ToString()
            };

            return devices;
        }

        private List<IPAddress> EnumerateIps(IPAddress start, IPAddress end)
        {
            const int maxLimit= 10000;
            int count = 0;
            var ips = new List<IPAddress>();
            var currentIp = start;

            ips.Add(currentIp);
            while (!currentIp.Equals(end) && count<maxLimit)
            {
                count++;
                currentIp = IPAddress.Parse(GetNextIpAddress(currentIp.ToString(), 1));
                ips.Add(currentIp);
            }



            return ips;
        }
        private static string GetNextIpAddress(string ipAddress, uint increment)
        {
            byte[] addressBytes = IPAddress.Parse(ipAddress).GetAddressBytes().Reverse().ToArray();
            uint ipAsUint = BitConverter.ToUInt32(addressBytes, 0);
            var nextAddress = BitConverter.GetBytes(ipAsUint + increment);
            return String.Join(".", nextAddress.Reverse());
        }
    }
}
