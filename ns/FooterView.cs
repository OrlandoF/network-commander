using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace ns
{
    class FooterView:View
    {
        public FooterView()
        {
            Width = Dim.Fill();

            var shortcutLabel = new Label("[ESC] Quit");
            shortcutLabel.ColorScheme = Colors.Menu;
            Add(shortcutLabel);

        }
    }
}
