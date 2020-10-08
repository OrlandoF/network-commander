using ns.Network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace ns.test.Network
{
    public class IpConfigTest
    {
        //Only pass on network connected device
        [Fact]
        public void HasIps()
        {          
            var addresses = IpConfig.ListIpAddresses();

            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);

        }

        [Fact]
        public void HasOnlyIPv4()
        {
            var addresses = IpConfig.ListIpV4Addresses();

            Assert.NotNull(addresses);
            Assert.NotEmpty(addresses);
            
        }

        [Fact]
        public void CheckIpRange()
        {
            IPAddress ip, expectedStartIp,expecttedEndIp;

            ip = IPAddress.Parse("192.168.1.127");
            expectedStartIp = IPAddress.Parse("192.168.1.1");
            expecttedEndIp = IPAddress.Parse("192.168.1.254");

            var result = IpConfig.IpRangeForIpAddress(ip);

            Assert.NotNull(result);
            Assert.Equal(2, result.Length);

            Assert.Equal(expectedStartIp, result[0]);
            Assert.Equal(expecttedEndIp, result[1]);
        }
    }
}
