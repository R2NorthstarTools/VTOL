
using Json.Net;
using Serilog;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Wpf.Ui.Common;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_Settings.xaml
    /// </summary>
    public partial class Page_Settings : Page
    {
        PropertyGridDemoModel Settings_;
        public MainWindow Main = GetMainWindow();
        User_Settings User_Settings_Vars = null;
        string DocumentsFolder = null;
        Language curr_lang;
        Wpf.Ui.Controls.Snackbar SnackBar;
        string OLD_MSG;
        string OLD_TITLE;
        DispatcherTimer timer = new DispatcherTimer();

        public enum Language
        {
            English,
            French,
            Chinese,
            Italian,
            Korean,
            German,
            Russian
        }
        public class PropertyGridDemoModel
        {
            [Category("General")]
            public Language Language { get; set; }
            [Category("General")]
            public bool Do_Not_Overwrite_Config_Files { get; set; }
            [Category("General")]

            public bool Hide_Console_Window { get; set; }
            [Category("General")]

            public bool Restart_As_Admin { get; set; }
            [Category("General")]

            public bool Enable_EA_APP_Usage { get; set; }
            [Category("General")]

            public bool Minimize_On_Launch { get; set; }
            [Category("General")]
            public bool Minimize_To_Tray { get; set; }
            [Category("General")]
            public bool Auto_Update_Northstar { get; set; }

            [Category("Github")]
            public string Repo_Url { get; set; }
            [Category("Github")]

            public string Repo { get; set; }
            [Category("Github")]

            public string Author { get; set; }
            [Category("Github")]

            public string Master_Server_Url { get; set; }

            [Category("Themes")]

            public Theme Theme { get; set; }

        }
        public enum Theme
        {
            Home_Green,
            Final_Grey,
            Redstone_Red
        }
        public Page_Settings()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.2);
            timer.Tick += timer_Tick;

            User_Settings_Vars = Main.User_Settings_Vars;
            DocumentsFolder = Main.AppDataFolder;
            Language Lang = Language.English;
            SnackBar = Main.Snackbar;
            if (User_Settings_Vars.Language != null)
            {
                switch (User_Settings_Vars.Language)
                {
                    case "en":
                        Lang = Language.English;

                        break;
                    case "fr":
                        Lang = Language.French;

                        break;
                    case "zh":
                        Lang = Language.Chinese;

                        break;
                    case "it":
                        Lang = Language.Italian;

                        break;
                    case "ko":
                        Lang = Language.Korean;

                        break;
                    case "de":
                        Lang = Language.German;

                        break;
                    case "ru":
                        Lang = Language.Russian;
                        break;
                    default:
                        Lang = Language.English;

                        break;


                }
            }
            curr_lang = Lang;

            Settings_ = new PropertyGridDemoModel
            {
                Language = Lang,
                Master_Server_Url = User_Settings_Vars.MasterServerUrl,
                Do_Not_Overwrite_Config_Files = Properties.Settings.Default.Backup_arg_Files,
                Minimize_On_Launch = Properties.Settings.Default.Auto_Close_VTOL_on_Launch,
                Hide_Console_Window = Properties.Settings.Default.Hide_Console_Window,
                Repo_Url = User_Settings_Vars.RepoUrl,
                Repo = User_Settings_Vars.Repo,
                Enable_EA_APP_Usage = Properties.Settings.Default.EA_APP_SUPPORT,
                Author = User_Settings_Vars.Author,
                Auto_Update_Northstar = User_Settings_Vars.Auto_Update_Northstar,
                Minimize_To_Tray = Properties.Settings.Default.Minimize_to_Tray,
                
            };
            Settings.SelectedObject = Settings_;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Settings_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void Settings_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                User_Settings_Vars.MasterServerUrl = Settings_.Master_Server_Url;
                Properties.Settings.Default.Auto_Close_VTOL_on_Launch = Settings_.Minimize_On_Launch;
                Properties.Settings.Default.Save();
                DispatchIfNecessary(async () =>
                {
                    OLD_MSG = (VTOL.Resources.Languages.Language.Page_Settings_Settings_LostFocus_AChangeInLanguageWasDetectedNVTOLRequiresARestartToDisplayTheseChangesNWouldYouLikeToRestartNow).Replace("@", System.Environment.NewLine);
                    OLD_TITLE = VTOL.Resources.Languages.Language.Page_Settings_Settings_LostFocus_LanguageChangeDetected;
                });
                switch (Settings_.Language.ToString())
                {
                    case "English":
                        User_Settings_Vars.Language = "en";

                        break;
                    case "French":
                        User_Settings_Vars.Language = "fr";

                        break;
                    case "Chinese":
                        User_Settings_Vars.Language = "zh";

                        break;
                    case "Italian":
                        User_Settings_Vars.Language = "it";

                        break;
                    case "Korean":
                        User_Settings_Vars.Language = "ko";

                        break;
                    case "German":
                        User_Settings_Vars.Language = "de";

                        break;
                    case "Russian":
                        User_Settings_Vars.Language = "ru";

                        break;
                    default:
                        User_Settings_Vars.Language = "en";

                        break;


                }




                User_Settings_Vars.Auto_Close_VTOL = Settings_.Minimize_On_Launch;
                User_Settings_Vars.Author = Settings_.Author;
                User_Settings_Vars.Repo = Settings_.Repo;
                User_Settings_Vars.RepoUrl = Settings_.Repo_Url;
                User_Settings_Vars.Auto_Update_Northstar = Settings_.Auto_Update_Northstar;

                Properties.Settings.Default.Hide_Console_Window = Settings_.Hide_Console_Window;
                Properties.Settings.Default.EA_APP_SUPPORT = Settings_.Enable_EA_APP_Usage;
                Properties.Settings.Default.Backup_arg_Files = Settings_.Do_Not_Overwrite_Config_Files;
                Properties.Settings.Default.Minimize_to_Tray = Settings_.Minimize_To_Tray;
                Properties.Settings.Default.Save();
                Main.minimize_to_tray = Settings_.Minimize_To_Tray;

                string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                using (var StreamWriter = new StreamWriter(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                {
                    StreamWriter.WriteLine(User_Settings_Json_Strings);
                    StreamWriter.Close();
                }
                DispatchIfNecessary(async () =>
                {

                    if (curr_lang.ToString() != Settings_.Language.ToString())
                    {
                        Dialog_.ButtonLeftName = VTOL.Resources.Languages.Language.Page_Settings_Settings_LostFocus_Restart;
                        Dialog_.ButtonRightName = "No";
                        Dialog_.ButtonRightAppearance = ControlAppearance.Secondary;
                        Dialog_.ButtonLeftAppearance = ControlAppearance.Success;
                        Dialog_.Title = OLD_TITLE;

                        Dialog_.Content = OLD_MSG;
                        Dialog_.Show();

                    }
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }


        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Dialog__ButtonLeftClick(object sender, RoutedEventArgs e)
        {
            Restart();
        }
        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        async void Restart()
        {
            DispatchIfNecessary(async () =>
            {


                SnackBar.Appearance = ControlAppearance.Info;
                SnackBar.Title = "INFO";
                SnackBar.Message = VTOL.Resources.Languages.Language.PleaseWaitAsVTOLRestarts;
                SnackBar.Show();
            });

            await Task.Delay(2000);
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }

        async void Restart_As_admin()
        {

            DispatchIfNecessary(async () =>
            {


                SnackBar.Appearance = ControlAppearance.Info;
                SnackBar.Title = "INFO";
                SnackBar.Message = "VTOL RESTARTING IN ADMIN MODE";
                SnackBar.Show();
            });

            await Task.Delay(1500);
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;

            //Process.Start(currentExecutablePath);




            //Public domain; no attribution required.
            const int ERROR_CANCELLED = 1223; //The operation was canceled by the user.

            ProcessStartInfo info = new ProcessStartInfo(currentExecutablePath);
            info.UseShellExecute = true;
            info.Verb = "runas";
            try
            {
                Process.Start(info);
                Application.Current.Shutdown();

            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_CANCELLED)
                {
                    DispatchIfNecessary(async () =>
                    {


                        SnackBar.Appearance = ControlAppearance.Info;
                        SnackBar.Title = "INFO";
                        SnackBar.Message = "CANCELLED PERMISSIONS";
                        SnackBar.Show();
                        Settings_.Restart_As_Admin = false;
                    });
                    return;
                }

                else
                {
                    Settings_.Restart_As_Admin = false;

                    throw;
                }
            }



        }

        void timer_Tick(object sender, EventArgs e)
        {

            try
            {
                if (Settings_.Restart_As_Admin == true)
                {
                    timer.Stop();

                    Restart_As_admin();
                }

            }
            catch (Exception ex)
            {

                //i dont need to log this
            }
        }

        private void Dialog_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {
                curr_lang = Settings_.Language;
                Dialog_.Hide();
            });
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Settings_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

        }

        private void Settings_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Settings_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Settings_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            timer.Start();

        }
    }
}
