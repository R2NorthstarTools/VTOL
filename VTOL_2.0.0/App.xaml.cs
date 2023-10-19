using Microsoft.Win32;
using System.Windows;
namespace VTOL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string UriScheme = "ror2mm";
        const string FriendlyName = "  Thunderstore Mod Manager Protocol";
        public static void RegisterUriScheme()
        {


            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + UriScheme))
            {
                // Replace typeof(App) by the class that contains the Main method or any class located in the project that produces the exe.
                // or replace typeof(App).Assembly.Location by anything that gives the full path to the exe
                string applicationLocation = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                key.SetValue("", "URL:" + FriendlyName);
                key.SetValue("URL Protocol", "");

                using (var defaultIcon = key.CreateSubKey(@"DefaultIcon\"))
                {
                    defaultIcon.SetValue("", applicationLocation + @"\Resources\Icons\Main_UI\Northstar-512.ico" + ",1");
                }
                using (var Fire = key.CreateSubKey(@"shell\open"))
                {
                    Fire.SetValue("FriendlyAppName", "VTOL");

                }
                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
                }
            }
        }
        private async void Application_Startup(object sender, StartupEventArgs e)
        {




            //SplashScreen splashScreen = new SplashScreen(@"\Pages\Splash.jpg");

            //splashScreen.Show(true, true); 

            // Auto-close: NO, On top: YES
            //    var splashScreen = new Splash_();
            //    splashScreen.Show();

            //    // Async load the main window
            //   // var mainWindow = new MainWindow();
            //    await Task.Delay(3000); // Simulate loading time
            // //   mainWindow.Show();

            //    // Fade out the splash screen
            //  //  var animation = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(1)));
            //  //  splashScreen.BeginAnimation(OpacityProperty, animation);
            //  //  animation.Completed += (s, a) => splashScreen.Close();
            //    //RegisterUriScheme();
            //    splashScreen.Close();
            //if (args.Length > 0)
            //{
            //    if (Uri.TryCreate(args[0], UriKind.Absolute, out var uri) &&
            //        string.Equals(uri.Scheme, UriScheme, StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine(args.ToString());
            //    }
            //}
            //for (int i = 0; i != e.Args.Length; ++i)
            //{

            //        Console.WriteLine("Ahh i cant see the args " + e.Args);

            //}

        }
    }
}
