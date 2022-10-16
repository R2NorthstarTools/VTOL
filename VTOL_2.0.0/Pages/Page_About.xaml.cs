using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using MdXaml;
using MdXaml.Plugins;
namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_About.xaml
    /// </summary>
    public partial class Page_About : Page
    {

        public MainWindow Main = GetMainWindow();

        private static String updaterModulePath;
        bool is_portable_= true;
        Wpf.Ui.Controls.Snackbar SnackBar;

        async Task Set_About()
        {
          




        }
        public static MainWindow GetMainWindow()
        {
            MainWindow mainWindow = null;

            foreach (Window window in Application.Current.Windows)
            {
                Type type = typeof(MainWindow);
                if (window != null && window.DependencyObjectType.Name == type.Name)
                {
                    mainWindow = (MainWindow)window;
                    if (mainWindow != null)
                    {
                        break;
                    }
                }
            }


            return mainWindow;

        }

        public Page_About()
        {
            InitializeComponent();
            string Header = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../"));
            string markdownTxt = System.IO.File.ReadAllText(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).FullName + "/README.md");

            MarkDown_Display.Markdown = markdownTxt;

            updaterModulePath = Path.Combine(Header, "VTOL_Updater.exe");
            if (!File.Exists(updaterModulePath))
            {
                Cofigure.IsEnabled = false;
                is_portable_ = true;
            }
            else
            {
                Cofigure.IsEnabled = true;
                is_portable_ = false;


            }
            Set_About();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(updaterModulePath))
            {
                try
                {


                    Process[] processes = Process.GetProcessesByName(updaterModulePath);
                    if (processes.Length > 0)
                        processes[0].CloseMainWindow();
                }
                catch (Exception ex)
                {
                     Main.logger2.Open();
                     Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

                }
                Process process = Process.Start(updaterModulePath, "/configure");
                process.Close();

            }
            else
            {
                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_UPDATER_NOT_FOUND"));

            }
        }
        void Check_For_New_Update()
        {
            try
            {
             
                var thisApp = Assembly.GetExecutingAssembly();
                AssemblyName name = new AssemblyName(thisApp.FullName);
                Updater Update = new Updater("BigSpice", "VTOL");
                

                if (Update.CheckForUpdate())
                {

                    SnackBar.Message = "Update Available!, Please Check and Download The latest portable release.";
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();



                }
                else
                {


                    SnackBar.Message = "No Update Found";
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                }




            }
            catch (Exception ex)
            {
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }



        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {

            if (is_portable_==false)
            {
                if (File.Exists(updaterModulePath))
                {
                    //   StartSilent();
                    Process process = Process.Start(updaterModulePath, "/checknow ");
                    // process.Close();
                }
               
            }
            else
            {



                Check_For_New_Update();
                

            }

        }
    }
}
