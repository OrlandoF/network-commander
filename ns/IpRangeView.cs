using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace ns
{
    class IpRangeView:View
    {
        public IpRangeView()
        {

            Width = Dim.Fill();
            Height = Dim.Fill();

            var firstIpLabel = new Label("First Ip ");
            var firstIpText = new TextField("") { X = Pos.Right(firstIpLabel), Width = 15};
            var lastIpLabel = new Label(" Last ") { X=Pos.Right (firstIpText) };
            var lastIpText = new TextField("") { X = Pos.Right(lastIpLabel), Width = 15 };
            var scanButton = new Button("Scan");
            scanButton.X = Pos.AnchorEnd() - (Pos.Right(scanButton) - Pos.Left(scanButton));

            Add(firstIpLabel,lastIpLabel, firstIpText, lastIpText, scanButton);
        }

    }
}
