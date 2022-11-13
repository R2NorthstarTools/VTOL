using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Parallax;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using VTOL.Scripts;
using System.Globalization;
using Serilog;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace VTOL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Merge Complete
        private Wpf.Ui.Appearance.ThemeType ThemeType = Wpf.Ui.Appearance.ThemeType.Dark;
        bool Profile_card = false;
        public User_Settings User_Settings_Vars = new User_Settings();
        public string DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        const string UriScheme = "ror2mm://";
        const string FriendlyName = "Sample Protocol";
        public TlsPaperTrailLogger logger2 = new TlsPaperTrailLogger("logs5.papertrailapp.com", 38137);
        static void Main(string[] args)
        {
           

            if (args.Length > 0)
            {
                if (Uri.TryCreate(args[0], UriKind.Absolute, out var uri) &&
                    string.Equals(uri.Scheme, UriScheme, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(args.ToString());
                }
            }
        }
        public MainWindow()
        {
            try
            {

                InitializeComponent();



                //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");


                if (Directory.Exists(DocumentsFolder))
                {

                    if (!File.Exists(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json"))
                    {
                       TryCreateDirectory(DocumentsFolder + @"\VTOL_DATA\Settings");
                        dynamic User_Settings_Json = new JObject();
                        User_Settings_Json.Current_Version = "NODATA";
                        User_Settings_Json.Theme = "NODATA";
                        User_Settings_Json.Master_Server_Url = "Northstar.tf";
                        User_Settings_Json.Profile_Path = "R2Northstar";
                        User_Settings_Json.Repo = "Northstar";
                        User_Settings_Json.Language = "NODATA";
                        User_Settings_Json.Repo_Url = "https://api.github.com/repos/R2Northstar/Northstar/releases/latest";
                        User_Settings_Json.Northstar_Install_Location = "NODATA";
                        User_Settings_Json.MasterServer_URL_CN = "nscn.wolf109909.top";
                        User_Settings_Json.Current_REPO_URL_CN = "https://nscn.wolf109909.top/version/query";
                        User_Settings_Json.Author = "R2Northstar";
                        User_Settings_Vars.Auto_Update_Northstar = true;
                        User_Settings_Vars.Auto_Close_VTOL = true;
                        var User_Settings_Json_String = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Json);

                        using (var StreamWriter = new StreamWriter(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json", true))
                        {
                            StreamWriter.WriteLine(User_Settings_Json_String.ToString());
                            StreamWriter.Close();
                        }
                        User_Settings_Vars = User_Settings.FromJson(User_Settings_Json_String);
                    }
                    else
                    {
                        string User_Settings_String = File.ReadAllText(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json");

                        User_Settings_Vars = User_Settings.FromJson(User_Settings_String);



                    }

                }
                else
                {
                    MessageBox.Show("VTOL SYSTEMS FAILED TO FIND YOUR DOCUMENTS FOLDER");
                    Application.Current.Shutdown();

                }
                if (User_Settings_Vars != null)
                {

                    // ProfileManager Profile_ = new ProfileManager();
                    //  Profile_.InitializeProfiles(null);
                    string language = "en-EN";
                    switch (User_Settings_Vars.Language)
                    {
                        case "fr":
                            language = "fr-FR";
                            break;
                        case "it":
                            language = "it-IT";
                            break;
                        case "de":
                            language = "de-DE";
                            break;
                        case "zh":
                            language = "zh-CHT";
                            break;
                        case "ko":
                            language = "ko-KR";
                            break;
                        case "en":
                            language = "en-EN";
                            break;
                        case "ru":
                            language = "ru-RU";
                            break;
                        default:
                            language = "en-EN";
                            break;

                    }

                    CultureInfo ui_culture = new CultureInfo(language);
                    CultureInfo culture = new CultureInfo(language);

                    Thread.CurrentThread.CurrentUICulture = ui_culture;
                    Thread.CurrentThread.CurrentCulture = culture;
                }
                else
                {

                    Send_Danger_Notif("Could Not Read User Settings, Please Run as Admin or Repair/Clean your Installation", 10000);

                }
                Wpf.Ui.Appearance.Theme.Apply(
            Wpf.Ui.Appearance.ThemeType.Unknown,
  // Theme type
  Wpf.Ui.Appearance.BackgroundType.None, // Background type
  true                                  // Whether to change accents automatically
);






            }


            catch (Exception ex)
            {
                MessageBox.Show("Exception Encountered! - " + ex.Message);
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                logger2.Open();
                logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
                logger2.Close();
            }





        }
        public bool TryDeleteDirectory(
   string directoryPath, bool overwrite = true,
   int maxRetries = 10,
   int millisecondsDelay = 300)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(directoryPath);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {
                    if (Directory.Exists(directoryPath))
                    {
                        Directory.Delete(directoryPath, overwrite);
                    }

                    return true;
                }
                catch (IOException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (UnauthorizedAccessException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
            }

            return false;
        }
        public bool TryCreateDirectory(
   string directoryPath,
   int maxRetries = 10,
   int millisecondsDelay = 200)
        {
            if (directoryPath == null)
                throw new ArgumentNullException(directoryPath);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {

                    Directory.CreateDirectory(directoryPath);

                    if (Directory.Exists(directoryPath))
                    {

                        return true;
                    }


                }
                catch (IOException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (UnauthorizedAccessException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
            }

            return false;
        }
        public bool TryMoveFile(
   string Origin, string Destination, bool overwrite = true,
   int maxRetries = 10,
   int millisecondsDelay = 200)
        {
            if (Origin == null)
                throw new ArgumentNullException(Origin);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {
                    if (File.Exists(Origin))
                    {
                        File.Move(Origin, Destination, overwrite);
                    }

                    return true;
                }
                catch (IOException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (UnauthorizedAccessException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
            }

            return false;
        }
        public bool TryCopyFile(
  string Origin, string Destination, bool overwrite = true,
  int maxRetries = 10,
  int millisecondsDelay = 300)
        {
            if (Origin == null)
                throw new ArgumentNullException(Origin);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {
                    if (File.Exists(Origin))
                    {
                        File.Copy(Origin, Destination, true);
                    }
                    Thread.Sleep(millisecondsDelay);

                    return true;
                }
                catch (IOException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (UnauthorizedAccessException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
            }

            return false;
        }
        public static void RegisterUriScheme()
        {
            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + UriScheme))
            {
                // Replace typeof(App) by the class that contains the Main method or any class located in the project that produces the exe.
                // or replace typeof(App).Assembly.Location by anything that gives the full path to the exe
                string applicationLocation = typeof(App).Assembly.Location;

                key.SetValue("", "URL:" + FriendlyName);
                key.SetValue("URL Protocol", "");

                using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
                {
                    defaultIcon.SetValue("", applicationLocation + ",1");
                }

                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
                }
            }
        }
        public void Send_Success_Notif(string Input_Message)
        {

            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
            Snackbar.Show("Success", Input_Message, Wpf.Ui.Common.SymbolRegular.Check24);
            //Dialog.Show("Feeel Fine", "23 Hours no sleep");

        }

        public void Send_Caution_Notif(string Input_Message)
        {
            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
            Snackbar.Show("Caution", Input_Message, Wpf.Ui.Common.SymbolRegular.ErrorCircleSettings20);

        }

        public void Send_Info_Notif(string Input_Message)
        {
            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
            Snackbar.Show("Info", Input_Message, Wpf.Ui.Common.SymbolRegular.Info24);


        }

        public void Send_Danger_Notif(string Input_Message, int time)
        {

            Snackbar.Timeout = time;
            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
            Snackbar.Show("Danger", Input_Message, Wpf.Ui.Common.SymbolRegular.Warning24);
        }


        public void Minimize()
        {
            this.WindowState = WindowState.Minimized;

        }


        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



      
        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public static string[] GetTextureName(string name)
        {
            string[] s = new string[3];
            int toname = name.LastIndexOf("\\") + 1;
            string str = name.Substring(toname, name.Length - toname);
            toname = str.IndexOf("_");
            string temp = str.Substring(toname, str.Length - toname);
            s[0] = str;
            s[1] = str.Replace(temp, "");
            s[2] = temp;
            return s;
        }
        private void Theme_Click(object sender, RoutedEventArgs e)
        {


            object Page = RootFrame.Content.GetType();











            if (Wpf.Ui.Appearance.Theme.GetAppTheme() == ThemeType)
            {

				Wpf.Ui.Appearance.Theme.Apply(
Wpf.Ui.Appearance.ThemeType.Light, // Theme type
Wpf.Ui.Appearance.BackgroundType.Mica, // Background type
true // Whether to change accents automatically
);
                Main_Win_Control.Background = Brushes.White;

            }
            else
            {

                Wpf.Ui.Appearance.Theme.Apply(
 Wpf.Ui.Appearance.ThemeType.Dark,     // Theme type
 Wpf.Ui.Appearance.BackgroundType.Mica, // Background type
 true                                  // Whether to change accents automatically
);
                Main_Win_Control.Background = Brushes.Black;
            }
        }



        private void RootNavigation_Navigated(Wpf.Ui.Controls.Interfaces.INavigation sender, Wpf.Ui.Common.RoutedNavigationEventArgs e)
        {

        }

        private void Dialog_ButtonLeftClick(object sender, RoutedEventArgs e)
        {

        }

        private void Dialog_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            //Dialog.Hide();
        }






        private void RootFrame_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void RootNavigation_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Browse_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Log_Folder_warning_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\";


                    if (Directory.Exists(path))
                {
                       

                        string pattern = "*.txt";
                        var dirInfo = new DirectoryInfo(path);
                        var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).First();
                        string p = file.FullName;
                        string args = string.Format("/e, /select, \"{0}\"", p);

                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = "explorer";
                        info.Arguments = args;
                        Process.Start(info);
                    Properties.Settings.Default.LOG_Folder_Counter = Directory.GetFiles(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\").Length;
                    Log_Folder_warning.Visibility = Visibility.Hidden;
                }
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }
    }
}
