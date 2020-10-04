using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ns.Network
{
    public static class IpScan
    {
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
    }
}
