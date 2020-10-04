using ns.Network;
using System;
using Terminal.Gui;

namespace ns
{
    class Program
    {
        public static Action running = MainApp;
        static void Main(string[] args)
        {
            while (running != null)
            {
                running.Invoke();
            }
            Application.Shutdown();

        }

        static void MainApp()
        {
            Application.Init();

            var top = Application.Top;
            var mainWindow = new App();

            var statusBar = new StatusBar(new StatusItem[] {
            new StatusItem(Key.F5, "F5 Scan", () => {StartSearch(mainWindow); }),
            new StatusItem(Key.ControlQ, "~^Q~ Quit", () => { if (Quit ()) { running = null; top.Running = false; } })
            });

            
            top.Add(mainWindow, statusBar);
            Application.Run(top);
        }

        static void StartSearch(App app)
        {
            var result = IpScan.ListAll();
            app.RefreshDeviceList(result);
        }

        static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Network Commander", "Are you sure you want to quit?", "Yes", "No");
            return n == 0;
        }

    }
}
