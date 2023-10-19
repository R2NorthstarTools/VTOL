using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Path = System.IO.Path;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_About.xaml
    /// </summary>
    public partial class Page_About : Page
    {

        public MainWindow Main = GetMainWindow();

        private static String updaterModulePath;
        bool is_portable_ = true;
        Wpf.Ui.Controls.Snackbar SnackBar;

        async Task Set_About()
        {

            About_BOX.IsReadOnly = true;
            Paragraph paragraph = new Paragraph();
            SnackBar = Main.Snackbar;


            string Text = @"-This Application Installs The Northstar Launcher Created by BobTheBob and can install the countless Mods Authored by the many Titanfall2 Modders.
Current Features:
Easily install, update and launch Northstar
Manage installed Northstar mods
Downloading and installing Northstar mods from a GitHub/GitLab repository
Installing downloaded Northstar mods (.zip files)
Easily install custom Weapon/Pilot Skins
Easily start a Northstar Dedicated Server
Thunderstore Mod Browser
Create custom servers using this application to fine tune setups.
Manage dedicated Northstar servers.
Use the Tools To pack Thunderstore Compatible Mod Packages
Install Skins From the Thunderstore Mod Browser
-Please do suggest any new features and/or improvements through the Git issue tracker, or by sending me a personal message.
Thank you again to all you Pilots, Hope we wreak havoc on the Frontier for years to come.
More Instructions at this link: https://github.com/BigSpice/VTOL/blob/master/README.md
Gif image used in Northstar is by @Smurfson.
Big Thanks to - 
@Ralley111
@MysteriousRSA
@emma-miler
@wolf109909
@laundmo
@SamLam140330
@ConnorDoesDev
@ScureX
@rrrfffrrr
@themoonisacheese
@xamionex
Every cent counts towards feeding my baby Ticks - https://www.buymeacoffee.com/Ju1cy ";

            About_BOX.Document.Blocks.Clear();
            Run run = new Run(Text);
            paragraph.Inlines.Add(run);
            About_BOX.Document.Blocks.Add(paragraph);




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
                    Main.VTOL_UPDATE_BADGE.Visibility = Visibility.Hidden;

                    Process[] processes = Process.GetProcessesByName(updaterModulePath);
                    if (processes.Length > 0)
                        processes[0].CloseMainWindow();
                }
                catch (Exception ex)
                {

                }
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
                    Main.VTOL_UPDATE_BADGE.Visibility = Visibility.Hidden;


                    SnackBar.Message = "No Update Found";
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                }




            }
            catch (Exception ex)
            {


            }



        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {

            if (is_portable_ == false)
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
