using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VTOL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1000; // Miliseconds  
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        private int counter = 60;
        Startup splash;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            splash = new Startup();

            splash.Show();
            // Step 2 - Start a stop watch  
            Task.Factory.StartNew(() =>
            {
                // Step 3 - Load your windows but don't show it yet  
              
                this.Dispatcher.Invoke(() =>
                {
                    MainWindow main = new MainWindow();
                   // this.MainWindow = main;

                    main.ShowActivated = false;
                    splash.Close();

                });
            });

        }

      
    }
}
