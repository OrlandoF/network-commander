using ns.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace ns
{
    public class App:Window
    {
        ListView resultView = new ListView();
        public App():base()
        {
            X = 0;
            Y = 0;
            Width = Dim.Fill();
            Height = Dim.Fill() - 1;


            var ipRangeView = new IpRangeView();
            Add(ipRangeView);

            resultView.Y = Pos.Bottom(ipRangeView);
            resultView.Width = Dim.Fill();
            resultView.Height = Dim.Fill();
            Add(resultView);
        }

        public void RefreshDeviceList(string[] devices)
        {
            resultView.SetSource(devices);
        }

    }
}
