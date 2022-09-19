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
      
    }
}
