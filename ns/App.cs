using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace ns
{
    public class App:Window
    {
        public App():base()
        {

            var ipRangeView = new IpRangeView();
            Add(ipRangeView);
        }

    }
}
