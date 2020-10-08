using ns.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace ns.test.Network
{
    public class IpScanTest
    {
        [Fact]
        public void ScanIps()
        {
            var scanner = new IpScan();
            var parameters = new ScanParameters();

            parameters.StartIp = IPAddress.Parse("192.168.0.1");
            parameters.LastIp = IPAddress.Parse("192.168.0.5");

            var devices = scanner.ScanIpRange(parameters);

            Assert.NotEmpty(devices);

        }
    }
}
