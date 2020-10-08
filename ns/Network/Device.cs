using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Terminal.Gui;

namespace ns.Network
{
    public class Device
    {
        public IPAddress Ip { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Ip.ToString() + "  " + Name;
        }
    }
}
