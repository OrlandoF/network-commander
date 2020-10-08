using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace ns.Network.Scanners
{
    public class PingScanner
    {
        public bool CheckIp(IPAddress ip)
        {
            var ping = new Ping();

            var pong = ping.Send(ip);

            return pong.Status == IPStatus.Success;

        }
    }
}
