using System;
using System.Collections.Generic;
using System.Linq;
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
using VTOL;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Threading;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Net;
using System.Timers;
using System.Windows.Threading;
using System.IO;
using Parallax.WPF;
using System.Security.Principal;
using Microsoft.Win32;
using System.Reflection;
using Path = System.IO.Path;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Octokit;
using Page = System.Windows.Controls.Page;
using FileMode = System.IO.FileMode;
using Application = System.Windows.Application;
using Serilog;
using System.Globalization;
using Ionic.Zip;
using VTOL.Scripts;
using GameFinder.StoreHandlers.Steam;
using System.Runtime.InteropServices;
using GameFinder.RegistryUtils;
using GameFinder.StoreHandlers.Origin;
using VTOL.Properties;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_Home.xaml
    /// </summary>
    /// 
   public static class Utility
    {
        static string invalidRegStr;

    public static string MakeValidFileName(this string name)
    {
        if (invalidRegStr == null)
        {
            var invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);
        }

        return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
    }
    }
    public static class FileDirectorySearch
    {
        public static IEnumerable<string> Search(string searchPath, string searchPattern)
        {
            IEnumerable<string> files = GetFileSystemEntries(searchPath, searchPattern);

            foreach (string file in files)
            {
                yield return file;
            }

            IEnumerable<string> directories = GetDirectories(searchPath);

            foreach (string directory in directories)
            {
                files = Search(directory, searchPattern);

                foreach (string file in files)
                {
                    yield return file;
                }
            }
        }

        private static IEnumerable<string> GetDirectories(string directory)
        {
            IEnumerable<string> subDirectories = null;
            try
            {
                subDirectories = Directory.EnumerateDirectories(directory, "*.*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
            }

            if (subDirectories != null)
            {
                foreach (string subDirectory in subDirectories)
                {
                    yield return subDirectory;
                }
            }
        }

        private static IEnumerable<string> GetFileSystemEntries(string directory, string searchPattern)
        {
            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFileSystemEntries(directory, searchPattern, SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
            }

            if (files != null)
            {
                foreach (string file in files)
                {
                    yield return file;
                }
            }
        }
    }
        public class InstalledApplications
    {
        public static string checkInstalled_Custom(string findByName)
        {
            string displayName;
            string InstallPath;
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            //64 bits computer
            RegistryKey key64 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64);
            RegistryKey key = key64.OpenSubKey(registryKey);

            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Contains(findByName))
                    {

                        InstallPath = subkey.GetValue("InstallLocation").ToString();

                        return InstallPath; //or displayName

                    }
                }
                key.Close();
            }

            return null;
        }

        public static string GetApplictionInstallPath(string nameOfAppToFind)
        {
            string installedPath;
            string keyName;

            // search in: CurrentUser
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.CurrentUser, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            // search in: LocalMachine_32
            keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.LocalMachine, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            // search in: LocalMachine_64
            keyName = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            installedPath = ExistsInSubKey(Registry.LocalMachine, keyName, "DisplayName", nameOfAppToFind);
            if (!string.IsNullOrEmpty(installedPath))
            {
                return installedPath;
            }

            return string.Empty;
        }
      
        public static void GetInstalledApps()

        {
            TlsPaperTrailLogger logger2 = new TlsPaperTrailLogger("logs5.papertrailapp.com", 38137);

            string x = "";
            string appPATH = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(appPATH))
            {
                 File.WriteAllTextAsync(@"C:\Users\jorda\Downloads\net6-mvvm-demo\WriteText.txt", String.Join("\n", rk.GetSubKeyNames()));

                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            //Get App Name
                            var displayName = sk.GetValue("DisplayName");
                            //Get App Size
                            var size = sk.GetValue("EstimatedSize");

                            string item;
                            if (displayName != null)
                            {
                                if (size != null)
                                    item = displayName.ToString();
                                else
                                {
                                    item = displayName.ToString();
                                    if (item.Contains(""))
                                        x = x + displayName.ToString() + "\n";

                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            logger2.Open();
                           logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
logger2.Close();
                            Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                          

                        }
                    }
                }
                //File.WriteAllText(@"C:\VTOL\ALLApps.txt",x);
            }

        }

        private static string ExistsInSubKey(RegistryKey root, string subKeyName, string attributeName, string nameOfAppToFind)
        {
            RegistryKey subkey;
            string displayName;


            using (RegistryKey key = root.OpenSubKey(subKeyName))
            {
                if (key != null)
                {

                    foreach (string kn in key.GetSubKeyNames())
                    {
                        using (subkey = key.OpenSubKey(kn))
                        {
                            displayName = subkey.GetValue(attributeName) as string;
                            if (nameOfAppToFind.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return subkey.GetValue("InstallLocation") as string;
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
    public partial class Page_Home : Page
    {

        public MainWindow Main = GetMainWindow();
        private readonly System.Windows.Threading.DispatcherTimer _timer;
        private int Fail_Counter_Ping = 0;
        private int _pingCount = 0;
        private long _avgRtt = 0;
        private bool Master_Server_Check = true;
        bool Warn_Close_EA;
        bool Origin_Client_Running = false;
        bool EAClient_Running = false;
        string EA_Location = "";
        string Origin_Location = "";

        public bool NS_Installed;
        private List<string> _Images = new List<string>();
        private string NSExe;
        string current_Northstar_version_Url;
        public string Current_Install_Folder = "";
        bool do_not_overwrite_Ns_file = true;
        public bool Found_Install_Folder = false;
        int failed_search_counter = 0;
        public int pid;
        bool deep_Chk = false;
        public bool Sort_Lists;
        private static String updaterModulePath;
        public string Current_REPO_URL;
        public string Author_Used;
        public string Repo_Used;
        public bool Auto_Update_Northstar;
        public bool Minimize_On_Launch;
        public string MasterServer_URL;
        public string MasterServer_URL_CN = "nscn.wolf109909.top";
        public string Current_REPO_URL_CN = "https://nscn.wolf109909.top/version/query";
        public bool Loaded_ = false;
        public string Current_Ver_ = "NODATA";
        User_Settings User_Settings_Vars = null;
        string AppDataFolder = null;
        Wpf.Ui.Controls.Snackbar SnackBar;
        WebClient webClient;
        private Page_Thunderstore Page_Thunderstore;
        private bool unpack_flg = false;
        public int Admin_Warn_Flag = 0;
        System.Drawing.Point cursorPoint;
        int minutesIdle = 0;
        public Page_Home()
        {

            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


           

            User_Settings_Vars = Main.User_Settings_Vars;
            AppDataFolder = Main.AppDataFolder;
            SnackBar = Main.Snackbar;
            Current_Install_Folder = User_Settings_Vars.NorthstarInstallLocation;
            DispatcherTimer Log_Changes_Timer = new DispatcherTimer();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            Log_Changes_Timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += timer_Tick;
            Log_Changes_Timer.Tick += Log_Changes_Timer_Tick;
            timer.Start();
            Log_Changes_Timer.Start();

            Random random_ = new Random();

            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(random_.Next(10,30)),
                        new ObservableValue(random_.Next(20,50)),
                        new ObservableValue(random_.Next(20,50)),
                        new ObservableValue(random_.Next(10,30)),
                        new ObservableValue(random_.Next(20,50)),
                        new ObservableValue(random_.Next(20,50)),
                        new ObservableValue(random_.Next(10,30))

                    }
                }
            };
            DirectoryInfo d = new DirectoryInfo(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).FullName + "/Resources/Backgrounds/Backgrounds_Home_Page");
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            foreach (FileInfo file in Files)
            {
                _Images.Add(@"pack://application:,,,/Resources/Backgrounds/Backgrounds_Home_Page/" + file.Name);
            }

            Random random = new Random();
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(_Images[random.Next(0, _Images.Count - 1)]);
            bitmap.EndInit();
            Image.Source = bitmap;
            //Task.Run(() =>
            //{
            //    var r = new Random();
            //    while (true)
            //    {
            //        Application.Current.Dispatcher.Invoke(() =>
            //        {
            //            Console.WriteLine();
            //            LastHourSeries[0].Values.Add(new ObservableValue(_trend));
            //            LastHourSeries[0].Values.RemoveAt(0);
            //        });
            //    }
            //});

            DataContext = this; 
            /////////////////////
            Toggle_MS_BT(Properties.Settings.Default.Master_Server_Check);
            INIT();
            if (Properties.Settings.Default.EA_APP_SUPPORT == true)
            {
                EA_ORGIGIN_Client_Card.Content = VTOL.Resources.Languages.Language.Page_Home_Page_Home_EAClientRunning;
                BitmapImage bitmapx = new BitmapImage();

                bitmapx.BeginInit();
                bitmapx.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/EA.ico");
                bitmapx.EndInit();
                CLIENT_CARD_IMAGE.Source = bitmapx;

                if (Check_Process_Running("EABackgroundService") == true)
                {
                    EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                    EA_ORGIGIN_Client_Card.IconFilled = true;

                }
                else
                {

                    EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                    EA_ORGIGIN_Client_Card.IconFilled = false;

                }

            }
            else
            {
                BitmapImage bitmapy = new BitmapImage();

                bitmapy.BeginInit();
                bitmapy.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/Origin.ico");
                bitmapy.EndInit();
                CLIENT_CARD_IMAGE.Source = bitmapy;

                EA_ORGIGIN_Client_Card.Content = VTOL.Resources.Languages.Language.Page_Home_OriginClientRunning;
                if (Check_Process_Running("OriginClientService") == true)
                {
                    EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                    EA_ORGIGIN_Client_Card.IconFilled = true;

                }
                else
                {

                    EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                    EA_ORGIGIN_Client_Card.IconFilled = false;

                }

            }
           
            if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\") && Properties.Settings.Default.LOG_Folder_Counter < 1)
            {
                Properties.Settings.Default.LOG_Folder_Counter = Directory.GetFiles(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\").Where(s => s.EndsWith(".dmp")).Count();
                Properties.Settings.Default.Save();

            }
            Check_Log_Folder();

        }
        private bool isIdle(int minutes)
        {
            return minutesIdle >= minutes;
        }

      
        public bool TryUnzipFile(
string Zip_Path, string Destination, bool overwrite = true,
int maxRetries = 10,
int millisecondsDelay = 150)
        {
            if (Zip_Path == null)
                throw new ArgumentNullException(Zip_Path);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {
                    ZipFile zipFile = new ZipFile(Zip_Path);

                    zipFile.ExtractAll(Destination, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

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
                catch (Ionic.Zip.BadReadException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (Ionic.Zip.BadCrcException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (Ionic.Zip.BadStateException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (Ionic.Zip.ZipException)
                {
                    Thread.Sleep(millisecondsDelay);
                }
                catch (Exception)
                {
                    Thread.Sleep(millisecondsDelay);
                }
            }

            return false;
        }
       
        public string[] FindFirstFiles(string path, string searchPattern)
        {
            try
            {
                string[] files;

                try
                {
                    // Exception could occur due to insufficient permission.
                    files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
                }
                catch (Exception ex)
                {
                    Main.logger2.Open();
                    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    Main.logger2.Close();
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


                    return Array.Empty<string>();
                }

                // If matching files have been found, return the first one.
                if (files.Length > 0)
                {
                    return files;
                }
                else
                {
                    // Otherwise find all directories.
                    string[] directories;

                    try
                    {
                        // Exception could occur due to insufficient permission.
                        directories = Directory.GetDirectories(path);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                        Main.logger2.Open();
                        Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        Main.logger2.Close();
                        return Array.Empty<string>();
                    }

                    // Iterate through each directory and call the method recursivly.
                    foreach (string directory in directories)
                    {
                        string[] files_ = FindFirstFiles(directory, searchPattern);

                        // If we found a file, return it (and break the recursion).
                        if (files_ != null)
                        {
                            return files_;
                        }
                    }
                }
                return Array.Empty<string>();

            }



            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }
            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return null;
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            // Log the exception, display it, etc
            Log.Error((e.ExceptionObject as Exception), $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
        }
        async Task OPEN_WEBPAGE(string URL)
        {
            await Task.Run(() =>
            {
                DispatchIfNecessary(() => {
                    SnackBar.Message = "Opening the Following URL - " + URL;
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                });

                Thread.Sleep(1000);
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = URL,
                    UseShellExecute = true
                });
            });
        }
        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        void Open_Folder(string Folder)
        {

            try
            {

                Process.Start("explorer.exe", Folder);


            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }
        }
        public string ProductVersion
        {
            get
            {
                try
                {
                    string file = (FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion).ToString();
                    return file.Substring(0, file.IndexOf("+") + 1).Replace("+", "");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                    Main.logger2.Open();
                    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    Main.logger2.Close();

                }
                return "0.0.0";

            }
        }
           

        async void Auto_Install_(bool resart_ = false)
        {
            await Install_NS_METHOD();

            if (File.Exists(Current_Install_Folder + @"NorthstarLauncher.exe") && File.Exists(Current_Install_Folder + @"Titanfall2.exe"))
            {
                NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                await Task.Delay(1500);

                // Get the file version info for the notepad.
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Current_Install_Folder + @"NorthstarLauncher.exe");

                // Print the file name and version number.
                Console.WriteLine(myFileVersionInfo.FileVersion);
                Current_Ver_ = myFileVersionInfo.FileVersion;

                User_Settings_Vars.CurrentVersion = Current_Ver_;
                Properties.Settings.Default.Version = Current_Ver_;
                Properties.Settings.Default.Save();
                DispatchIfNecessary(() =>
                {
                    Directory_Box.Text = Current_Install_Folder;
                    Main.NORTHSTAR_BUTTON.Content = "Northstar Version - " + Current_Ver_.Remove(0, 1);
                    Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";
                    Main.VERSION_TEXT.Refresh();
                    Main.NORTHSTAR_BUTTON.Refresh();

                    NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                });
                await Task.Delay(1500);

                if (resart_ == true)
                {
                    DispatchIfNecessary(() =>
                {


                    SnackBar.Appearance = ControlAppearance.Info;
                    SnackBar.Title = "INFO";
                    SnackBar.Message = VTOL.Resources.Languages.Language.PleaseWaitAsVTOLRestarts;
                    SnackBar.Show();
                });
                    await Task.Delay(1000);


                    Restart();
                }

                unpack_flg = false;

            }
            else
            {
                DispatchIfNecessary(() =>
                {
                    Current_Ver_ = "1.0.0";
                    Main.NORTHSTAR_BUTTON.Content = "Northstar Version - UNKNOWN!";
                    Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";
                    Main.VERSION_TEXT.Refresh();
                    Main.NORTHSTAR_BUTTON.Refresh();
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "WARNING!";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Auto_Install__NORTHSTARISNOTINSTALLEDANDAUTOINSTALLFAILED;
                    SnackBar.Show();
                });

                unpack_flg = false;

            }


        }
        public string Search_Using_Game_Lib()
        {
            try
            {
                //////SteamFirst///
                // use the Windows registry on Windows
                // Linux doesn't have a registry
                var handler = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? new SteamHandler(new WindowsRegistry())
                    : new SteamHandler(null);

                // method 1: iterate over the game-error result
                SteamGame? steamgame = handler.FindOneGameById(432912, out string[] errors);

                if (steamgame != null && steamgame.Name.Count() > 2)
                    {
                        return steamgame.Path;
                    }
                    else
                    {
                        /////Failed/////
                        return null;

                    }

                

                ///////Origin////
                var Origin_handler = new OriginHandler();

                // method 1: iterate over the game-error result
                foreach (var (game, error) in Origin_handler.FindAllGames())
                {
                    if (game.InstallPath.Contains("Titanfall2") || game.InstallPath.Contains("TitanFall2"))
                    {
                        return game.InstallPath;
                    }
                    else
                    {
                        /////Failed/////
                        return null;
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }
            return null;

        }
        void Restart()
        {
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();

        }
        public static string returnSafeString(string s)
        {
            foreach (char character in Path.GetInvalidFileNameChars())
            {
                s = s.Replace(character.ToString(), string.Empty);
            }

            foreach (char character in Path.GetInvalidPathChars())
            {
                s = s.Replace(character.ToString(), string.Empty);
            }

            return (s);
        }
        async void Restart_App()
        {
            await Task.Delay(500);

            DispatchIfNecessary(() =>
            {


                SnackBar.Appearance = ControlAppearance.Info;
                SnackBar.Title = "INFO";
                SnackBar.Message = VTOL.Resources.Languages.Language.PleaseWaitAsVTOLRestarts;
                SnackBar.Show();
            });

            await Task.Delay(1000);
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }
        void INIT()
        {
            try
            {
                do_not_overwrite_Ns_file = Properties.Settings.Default.Backup_arg_Files;
                Sort_Lists = Properties.Settings.Default.Sort_Mods;
                Warn_Close_EA = Properties.Settings.Default.Warning_Close_EA;
                Minimize_On_Launch = Properties.Settings.Default.Auto_Close_VTOL_on_Launch;

                DataContext = this;

                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();


                string Header = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../"));
                updaterModulePath = Path.Combine(Header, "VTOL_Updater.exe");









                if (User_Settings_Vars != null)
                {




                    Author_Used = User_Settings_Vars.Author;

                    Repo_Used = User_Settings_Vars.Repo;
                    Auto_Update_Northstar = User_Settings_Vars.Auto_Update_Northstar;

                    Current_REPO_URL = User_Settings_Vars.RepoUrl;

                    Current_Ver_ = User_Settings_Vars.CurrentVersion;

                    MasterServer_URL = User_Settings_Vars.MasterServerUrl;

                    Current_Install_Folder = User_Settings_Vars.NorthstarInstallLocation;
                    Console.WriteLine(Current_Install_Folder);

                    if (IsValidPath(Current_Install_Folder))
                    {
                        if (!Current_Install_Folder.EndsWith(@"\"))
                        {
                            string fix = Current_Install_Folder + @"\";
                            User_Settings_Vars.NorthstarInstallLocation = fix;


                            Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                            Console.WriteLine("Replaced");

                        }
                    }
                    else
                    {
                        string FINAL = "";
                       Current_Install_Folder = InstalledApplications.GetApplictionInstallPath("Titanfall2");
                        if (IsValidPath(Current_Install_Folder))
                        {
                            FINAL = Current_Install_Folder;
                            if (!Current_Install_Folder.EndsWith(@"\"))
                            {
                                string fix = Current_Install_Folder + @"\";
                                User_Settings_Vars.NorthstarInstallLocation = fix;
                                Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                            }

                        }
                        else
                        {


                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                            SnackBar.Show();

                            throw new Exception("Could Not Install Ns after all of it :(");

                            return;


                        }

                    }


                }
                else
                {
                    Console.WriteLine("Null_Settings");
                    string FINAL = "";
                    Current_Install_Folder = InstalledApplications.GetApplictionInstallPath("Titanfall2");
                    if (IsValidPath(Current_Install_Folder))
                    {
                        FINAL = Current_Install_Folder;
                        if (!Current_Install_Folder.EndsWith(@"\"))
                        {
                            string fix = Current_Install_Folder + @"\";
                            User_Settings_Vars.NorthstarInstallLocation = fix;
                            Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                            string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                            using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                            {
                                StreamWriter.WriteLine(User_Settings_Json_Strings);
                                StreamWriter.Close();
                            }
                        }

                    }
                    else
                    {

                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                        SnackBar.Show();

                        throw new Exception("Could Not Install Ns after all of it :(");

                        return;



                    }




                }
                DirectoryInfo Dir = new DirectoryInfo(Current_Install_Folder);

                if (Dir.Exists && Current_Install_Folder != "NODATA")
                {
                    Console.WriteLine("VALID_PATH");

                    if (File.Exists(Current_Install_Folder + "Titanfall2.exe"))
                    {
                        Console.WriteLine("VALID_INSTALL");


                        if (File.Exists(Current_Install_Folder + @"NorthstarLauncher.exe"))
                        {
                            Console.WriteLine("VALID_NS");

                            // Get the file version info for the notepad.
                            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Current_Install_Folder + @"NorthstarLauncher.exe");

                            // Print the file name and version number.
                            Console.WriteLine(myFileVersionInfo.FileVersion);
                            Current_Ver_ = myFileVersionInfo.FileVersion;

                            User_Settings_Vars.CurrentVersion = Current_Ver_;
                            Properties.Settings.Default.Version = Current_Ver_;
                            Properties.Settings.Default.Save();

                            Main.NORTHSTAR_BUTTON.Content = "Northstar Version - " + Current_Ver_.Remove(0, 1);
                            Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";
                            Main.VERSION_TEXT.Refresh();
                            Main.NORTHSTAR_BUTTON.Refresh();




                            NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                            Main.VERSION_TEXT.Refresh();
                            Main.User_Settings_Vars = User_Settings_Vars;
                            Directory_Box.Text = Current_Install_Folder;
                            Check_Integrity_Of_NSINSTALL();

                            if (User_Settings_Vars.Auto_Update_Northstar == true)
                            {
                                Check_For_New_Northstar_Install();



                            }
                            string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                            using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                            {
                                StreamWriter.WriteLine(User_Settings_Json_Strings);
                                StreamWriter.Close();
                            }
                        }
                        else
                        {
                            if (!Current_Install_Folder.EndsWith(@"\"))
                            {
                                string fix = Current_Install_Folder + @"\";
                                User_Settings_Vars.NorthstarInstallLocation = fix;
                                Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                                Console.WriteLine("Replaced2");

                            }
                            Console.WriteLine("INVALID_NS");

                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_NORTHSTARAUTOINSTALLWILLNOWBEGINPLEASEWAITABOUT30SECONDS;
                            SnackBar.Timeout = 8000;
                            SnackBar.Show();
                            Auto_Install_(true);






                        }
                    }
                    else
                    {

                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                        SnackBar.Show();
                        Current_Install_Folder = "NODATA";


                    }

                    Console.WriteLine(Current_Install_Folder);









                }
                else
                {

                    string FINAL;
                    Current_Install_Folder = InstalledApplications.GetApplictionInstallPath("Titanfall2");
                    string Path = Auto_Find_And_verify().Replace(@"\\", @"\").Replace("/", @"\");
                    if (IsValidPath(Current_Install_Folder))
                    {
                        FINAL = Current_Install_Folder;
                    }
                    else
                    {
                       
                        FINAL = Path;

                        

                        throw new Exception("Automated Path Finding Failed!");

                    }
                    if (IsValidPath(FINAL))
                    {

                        Console.WriteLine(Path);

                        Current_Install_Folder = Path;
                        User_Settings_Vars.NorthstarInstallLocation = Path;
                        string User_Settings_Json_Strings_ = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                        if (!Current_Install_Folder.EndsWith(@"\"))
                        {
                            string fix = Current_Install_Folder + @"\";
                            User_Settings_Vars.NorthstarInstallLocation = fix;
                            Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");

                        }
                        if (Directory.Exists(Current_Install_Folder))
                        {
                            Auto_Install_(false);
                        }
                        else
                        {

                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                            SnackBar.Show();
                        }
                        if (File.Exists(Current_Install_Folder + "Titanfall2.exe") && Current_Install_Folder != "NODATA")
                        {



                            if (!File.Exists(NSExe))
                            {
                                try
                                {

                                    NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                                    if (!File.Exists(NSExe))
                                    {
                                        SnackBar.Appearance = ControlAppearance.Danger;
                                        SnackBar.Title = "ERROR!";
                                        SnackBar.Message = "VTOL Auto Install Failed, The Folder Titanfall 2 is in may be locked or inaccasiable to VTOL";
                                        SnackBar.Show();

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                                    Main.logger2.Open();
                                    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                                    Main.logger2.Close();


                                }
                            }

                            Directory_Box.Text = Current_Install_Folder;

                            Main.User_Settings_Vars = User_Settings_Vars;

                            using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                            {
                                StreamWriter.WriteLine(User_Settings_Json_Strings_);
                                StreamWriter.Close();
                            }


                        }
                        else
                        {
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                            SnackBar.Show();

                        }
                    }
                    else
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_InvalidInstallPathPleaseManuallyLocateTheCorrectFolder;
                        SnackBar.Show();

                    }
                }

                // string[] arguments = Environment.GetCommandLineArgs();

                //Console.WriteLine("GetCommandLineArgs: {0}", string.Join(", ", arguments));












                if (Directory.Exists(Current_Install_Folder + @"Skins_Unpack_Mod_MNGR"))
                {
                    try
                    {
                        TryDeleteDirectory(Current_Install_Folder + @"Skins_Unpack_Mod_MNGR", true);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                        Main.logger2.Open();
                        Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        Main.logger2.Close();
                    }




                }


                //if (Directory.Exists(@"C:\ProgramData\VTOL_DATA"))
                //{




                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\AUTHOR.txt"))
                //    {
                //        User_Settings_Vars.Author = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\AUTHOR.txt").Trim();
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\AUTHOR.txt");
                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\REPO.txt"))
                //    {
                //        User_Settings_Vars.Repo = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\REPO.txt").Trim();
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\REPO.txt");
                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\REPO_URL.txt"))
                //    {
                //        User_Settings_Vars.RepoUrl = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\REPO_URL.txt").Trim();
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\REPO_URL.txt");
                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\MASTER_SERVERURL.txt"))
                //    {
                //        User_Settings_Vars.MasterServerUrl = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\MASTER_SERVERURL.txt").Trim();
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\MASTER_SERVERURL.txt");

                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\Current_Ver.txt"))
                //    {
                //        User_Settings_Vars.CurrentVersion = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\Current_Ver.txt").Trim();
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\Current_Ver.txt");

                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt"))
                //    {
                //        User_Settings_Vars.NorthstarInstallLocation = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt");
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt");

                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\Theme.txt"))
                //    {
                //        User_Settings_Vars.Theme = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\Theme.txt");
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\Theme.txt");

                //    }
                //    if (File.Exists(@"C:\ProgramData\VTOL_DATA\VARS\Language.txt"))
                //    {
                //        User_Settings_Vars.Language = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\Language.txt");
                //        File.Delete(@"C:\ProgramData\VTOL_DATA\VARS\Language.txt");

                //    }
                //    TryDeleteDirectory(@"C:\ProgramData\VTOL_DATA", true);

                //}
                if (User_Settings_Vars.NorthstarInstallLocation != Current_Install_Folder)
                {
                    User_Settings_Vars.NorthstarInstallLocation = Current_Install_Folder;
                }

                if (NS_Installed == true)
                {


                    Update_Northstar_Button.Content = VTOL.Resources.Languages.Language.Page_Home_UpdateNorthstar;
                }
                else
                {

                    Update_Northstar_Button.Content = VTOL.Resources.Languages.Language.Page_Home_INIT_InstallNorthstar;



                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }
        }

        public bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = false; ;

            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

                isValid = false;
                //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_COMMON_LOG"));
                //Write_To_Log(ErrorManager(ex));
            }

            return isValid;
        }
        public string Read_From_TextFile_OneLine(string Filepath)
        {
            string line = "";
            try
            {
                using (var sr = new StreamReader(Filepath))
                {
                    line = sr.ReadLine();
                    return line;
                }

            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_CANNOT_FIND") + Filepath);
                //Write_To_Log(ErrorManager(e));


            }

            return line;

        }
        private static string GetShortcutTarget(string file)
        {
            try
            {
                if (Path.GetExtension(file).ToLower() != ".lnk")
                {
                    throw new Exception("Supplied file must be a .LNK file");
                }

                FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
                using (BinaryReader fileReader = new BinaryReader(fileStream))
                {
                    fileStream.Seek(0x14, SeekOrigin.Begin);     // Seek to flags
                    uint flags = fileReader.ReadUInt32();        // Read flags
                    if ((flags & 1) == 1)
                    {                      // Bit 1 set means we have to
                                           // skip the shell item ID list
                        fileStream.Seek(0x4c, SeekOrigin.Begin); // Seek to the end of the header
                        uint offset = fileReader.ReadUInt16();   // Read the length of the Shell item ID list
                        fileStream.Seek(offset, SeekOrigin.Current); // Seek past it (to the file locator info)
                    }

                    long fileInfoStartsAt = fileStream.Position; // Store the offset where the file info
                                                                 // structure begins
                    uint totalStructLength = fileReader.ReadUInt32(); // read the length of the whole struct
                    fileStream.Seek(0xc, SeekOrigin.Current); // seek to offset to base pathname
                    uint fileOffset = fileReader.ReadUInt32(); // read offset to base pathname
                                                               // the offset is from the beginning of the file info struct (fileInfoStartsAt)
                    fileStream.Seek((fileInfoStartsAt + fileOffset), SeekOrigin.Begin); // Seek to beginning of
                                                                                        // base pathname (target)
                    long pathLength = (totalStructLength + fileInfoStartsAt) - fileStream.Position - 2; // read
                                                                                                        // the base pathname. I don't need the 2 terminating nulls.
                    char[] linkTarget = fileReader.ReadChars((int)pathLength); // should be unicode safe
                    var link = new string(linkTarget);

                    int begin = link.IndexOf("\0\0");
                    if (begin > -1)
                    {
                        int end = link.IndexOf("\\\\", begin + 2) + 2;
                        end = link.IndexOf('\0', end) + 1;

                        string firstPart = link.Substring(0, begin);
                        string secondPart = link.Substring(end);

                        return firstPart + secondPart;
                    }
                    else
                    {
                        return link;
                    }
                }
            }
            catch
            {
                return "";
            }
        }
        private string Auto_Find_And_verify()
        {

            string path = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Steam";

            if (!Directory.Exists(path) || !File.Exists(Path.Combine(path, "Steam.lnk")))
            {
                if (Directory.Exists(@"C:\Program Files (x86)\Origin Games\Titanfall2") && File.Exists(@"C:\Program Files (x86)\Origin Games\Titanfall2\Titanfall2.exe"))
                    return @"C:\Program Files (x86)\Origin Games\Titanfall2";

                try
                {
                    RegistryKey originReg = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Respawn").OpenSubKey("Titanfall2");
                    if (originReg.GetValue("Install Dir") != null) return (string)originReg.GetValue("Install Dir");
                }
                catch
                {
                    Main.logger2.Open();
                    Main.logger2.Log("A User with the install - " + Current_Install_Folder + " failed an auto install and verify.");
                    Main.logger2.Close();
                }

                //Titanfall2_Directory_TextBox.Background = Brushes.Red;
                //Install_NS_EXE_Textbox.Background = Brushes.Red;
                //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_GAME_INSTALL_NOT_FOUND"));
                return null;
            }

            // AUTOMATIC AQCUISITION
            // THE COOL SHIT:TM:

            string target = GetShortcutTarget(Path.Combine(path, "Steam.lnk"));
            string steamDir = Path.GetDirectoryName(target);

            //Console.WriteLine(target);

            List<string> folderPaths = new List<string>();

            // probably stupid, but meh
            string[] libraryFolders = File.ReadAllText(Path.Combine(steamDir, @"config\libraryfolders.vdf")).Split('\"');
            for (int i = 0; i < libraryFolders.Length; i++)
            {
                string val = libraryFolders[i];
                if (val == "path")
                {
                    Console.WriteLine(libraryFolders[i + 2]);
                    folderPaths.Add(libraryFolders[i + 2]);
                }
            }

            foreach (string folder in folderPaths)
            {
                //Console.WriteLine(folder);
                Thread.Sleep(1000);
                foreach (string dir in Directory.GetDirectories(Path.Combine(folder, @"steamapps\common")))
                {
                    //Console.WriteLine(dir);
                    if (dir.EndsWith("Titanfall2") && File.Exists(Path.Combine(dir, "Titanfall2.exe")))
                    {
                        return dir;
                    }
                }
            }

            try
            {
                RegistryKey originReg = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Respawn").OpenSubKey("Titanfall2");
                if (originReg.GetValue("Install Dir") != null) return (string)originReg.GetValue("Install Dir");
            }
            catch
            {

            }

            if (Directory.Exists(@"C:\Program Files (x86)\Origin Games\Titanfall2") && File.Exists(@"C:\Program Files (x86)\Origin Games\Titanfall2\Titanfall2.exe"))
                return @"C:\Program Files (x86)\Origin Games\Titanfall2";
            //Titanfall2_Directory_TextBox.Background = Brushes.Red;
            //Install_NS_EXE_Textbox.Background = Brushes.Red;
            //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_GAME_INSTALL_NOT_FOUND"));
            return null;

            //failed_search_counter = 0;
            //Send_Info_Notif(GetTextResource("NOTIF_INFO_FINDING_GAME"));
            //while (NS_Installed == false && failed_search_counter < 1)
            //{

            //    Send_Info_Notif(GetTextResource("NOTIF_INFO_LOOKING_FOR_INSTALL_SMILEYFACE"));
            //    FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Steam");

            //    FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Origin Games");

            //    FindNSInstall("Titanfall2", @"C:\Program Files\EA Games");
            //    if (NS_Installed == false && failed_search_counter >= 1)
            //    {
            //        Titanfall2_Directory_TextBox.Background = Brushes.Red;
            //        Install_NS_EXE_Textbox.Background = Brushes.Red;
            //        Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_GAME_INSTALL_NOT_FOUND"));
            //        break;


            //    }

            //}
            //if (NS_Installed == true)
            //{

            //    User_Settings_Vars.NorthstarInstallLocation = Current_Install_Folder;
            //    string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
            //    using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
            //    {
            //        StreamWriter.WriteLine(User_Settings_Json_Strings);
            //        StreamWriter.Close();
            //    }
            //    NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
            //    Send_Success_Notif(GetTextResource("NOTIF_SUCCESS_FOUND_INSTALL"));
            //    Check_Integrity_Of_NSINSTALL();
            //}

        }
        public bool Template_traverse(DirectoryInfo root, String Search)
        {

            string outt = "";
            try
            {
                DirectoryInfo[] subDirs = null;
                subDirs = root.GetDirectories();
                var last = subDirs.Last();
                //Log_Box.AppendText(last.FullName + "sdsdsdsd");
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    outt = dirInfo.FullName;
                    if (dirInfo.Name.Contains(Search))
                    {
                        // ////Console.WriteLine("Found Folder");
                        ////Console.WriteLine(dirInfo.FullName);
                        return true;

                    }
                    else if (last.Equals(dirInfo))
                    {
                        return false;
                    }
                    else
                    {

                        ////Console.WriteLine("Trying again at " + dirInfo);

                    }
                    if (dirInfo == null)
                    {
                        ////Console.WriteLine(dirInfo.FullName + "This is not a valid Folder????!");
                        continue;

                    }
                    // Resursive call for each subdirectory.
                }

                ////Console.WriteLine("\nCould not Find the Install at " + root + " - Continuing Traversal");

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

                if (ex.Message == "Sequence contains no elements")
                {
                    DirectoryInfo Dir = new DirectoryInfo(outt);

                    ////Console.WriteLine("Empty Folder at - "+ outt);
                    if (IsDirectoryEmpty(Dir))
                    {
                        TryDeleteDirectory(outt, true);
                    }
                    //   Delete_empty_Folders(outt);
                }
                else
                {
                    DirectoryInfo Dir = new DirectoryInfo(outt);

                    if (IsDirectoryEmpty(Dir))
                    {
                        TryDeleteDirectory(outt, true);
                    }
                    //Write_To_Log(ErrorManager(e));

                    //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_COMMON_LOG"));
                }
                // Log_Box.AppendText("\nCould not Find the Install at " +root+ " - Continuing Traversal");
            }


            return false;

        }
        void Toggle_MS_BT(bool f)
        {
            try {
                DispatchIfNecessary(() => {

                    if (f == true)
                    {
                        Master_Server_Check = true;
                        Master_Server_Check_Toggle.IsChecked = true;
                        Master_Server_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        Master_Server_Card.Icon = SymbolRegular.PlugConnected20;
                        Properties.Settings.Default.Master_Server_Check = true;
                        Properties.Settings.Default.Save();
                        if (TimePowerChart.Opacity < 1)
                        {
                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = TimePowerChart.Opacity,
                                To = 1,
                                Duration = new Duration(TimeSpan.FromSeconds(2)),
                                AutoReverse = false
                            };
                            TimePowerChart.BeginAnimation(OpacityProperty, da);

                        }

                    }
                    else
                    {
                        Fail_Counter_Ping = 0;

                        Master_Server_Check = false;
                        Master_Server_Check_Toggle.IsChecked = false;
                        Master_Server_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                        Master_Server_Card.Icon = SymbolRegular.PlugDisconnected20;
                        Properties.Settings.Default.Master_Server_Check = false;
                        Properties.Settings.Default.Save();
                        if (TimePowerChart.Opacity > 0)
                        {
                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = TimePowerChart.Opacity,
                                To = 0,
                                Duration = new Duration(TimeSpan.FromSeconds(2)),
                                AutoReverse = false
                            };
                            TimePowerChart.BeginAnimation(OpacityProperty, da);

                        }


                    }
                });



            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }
        }


        async Task Check_origin_status()
        {
            if (Properties.Settings.Default.EA_APP_SUPPORT == true)
            {
                if (Check_Process_Running("EABackgroundService") == true)
                {
                    DispatchIfNecessary(() =>
                    {
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        EA_ORGIGIN_Client_Card.IconFilled = true;
                        return;
                    });




                }
                else
                {
                    DispatchIfNecessary(() =>
                    {
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                        EA_ORGIGIN_Client_Card.IconFilled = false;

                        return;
                    });

                }
            }
            else
            {
                if (Check_Process_Running("OriginClientService") == true)
                {
                    DispatchIfNecessary(() =>
                    {
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        EA_ORGIGIN_Client_Card.IconFilled = true;
                        return;
                    });




                }
                else
                {
                    DispatchIfNecessary(() =>
                    {
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                        EA_ORGIGIN_Client_Card.IconFilled = false;

                        return;
                    });

                }
            }


        }

        void Check_Log_Folder(){
            try
            {
                DispatchIfNecessary(() => {
                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\"))
                    {

                        int Cntr = 0;

                        Cntr = Directory.GetFiles(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\").Where(s => s.EndsWith(".dmp")).Count();

                        if (Cntr != Properties.Settings.Default.LOG_Folder_Counter && Cntr != 0)
                        {
                            Main.Log_Folder_warning.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            Main.Log_Folder_warning.Visibility = Visibility.Hidden;

                        }
                    }
                    else
                    {
                        Main.Log_Folder_warning.Visibility = Visibility.Hidden;

                    }
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }
            void Log_Changes_Timer_Tick(object sender, EventArgs e)
        {
           
            BackgroundWorker worker_o = new BackgroundWorker();
            worker_o.DoWork += (sender, e) =>
            {
                Check_origin_status();
            };

            worker_o.RunWorkerAsync();
        }
        void timer_Tick(object sender, EventArgs e)
        {

            try
            {
                
               
                if (Properties.Settings.Default.Master_Server_Check == true )
                {
                    if (Main.Is_Focused == true)
                    {

                        if (Fail_Counter_Ping != 5)
                        {
                            BackgroundWorker worker = new BackgroundWorker();
                            worker.DoWork += (sender, e) =>
                            {
                                PingHost();


                            };

                            worker.RunWorkerAsync();



                            // Toggle_MS_BT(true);


                        }
                        else
                        {
                            Wpf.Ui.Controls.Snackbar D = new Wpf.Ui.Controls.Snackbar();
                            D.Title = "Warning - Home Page!";
                            D.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            D.Message = VTOL.Resources.Languages.Language.Page_Home_timer_Tick_MasterServerCheckedAndTimedOutTooMuchTurningOffMasterServerChecks;
                            D.Show();
                            Toggle_MS_BT(false);
                        }
                        BackgroundWorker worker2 = new BackgroundWorker();
                        worker2.DoWork += (sender, e) =>
                        {
                            DispatchIfNecessary(() => {

                                Check_Log_Folder();

                            });

                        };

                        worker2.RunWorkerAsync();
                    }
                }
                else
                {
                    if (Master_Server_Card.Background != (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000"))
                    {
                        Master_Server_Card.Icon = SymbolRegular.PlugDisconnected20;

                        Master_Server_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                 
                //i dont need to log this
            }
        }

        public async Task PingHost()
        {
         
            bool pingable = false;
            PingReply reply_;
            long Val;
            Ping pinger = null;
            string nameOrAddress = "https://northstar.tf/client/servers";
            try
            {

                pinger = new Ping();
                reply_ = await pinger.SendPingAsync("Northstar.tf");
                _avgRtt = reply_.RoundtripTime;

                string hostUrl = "https://northstar.tf/client/servers";

                var httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(hostUrl),
                    Method = HttpMethod.Head
                   
                };
                request.Headers.Add("VTOL", "VTOL/" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                var result = await httpClient.SendAsync(request);

                if (result.IsSuccessStatusCode == true)
                {
                    DispatchIfNecessary(() => {

                        Master_Server_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        Master_Server_Card.Icon = SymbolRegular.PlugConnected20;

                        LastHourSeries[0].Values.Add(new ObservableValue(_avgRtt));
                        LastHourSeries[0].Values.RemoveAt(0);
                    });

                    Fail_Counter_Ping = 0;
                }

                else
                {
                    DispatchIfNecessary(() => {

                        LastHourSeries[0].Values.Add(new ObservableValue(0));
                        LastHourSeries[0].Values.RemoveAt(0);
                    });
                    Fail_Counter_Ping++;
                    return;

                }


            }

            catch (WebException wex)
            {
                Log.Error(wex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 if (wex.Response != null)
                {
                    if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        DispatchIfNecessary(() => {

                            LastHourSeries[0].Values.Add(new ObservableValue(0));
                            LastHourSeries[0].Values.RemoveAt(0);
                        });
                        // error 404, do what you need to do

                        Fail_Counter_Ping++;

                    }
                }
                else
                {
                    Fail_Counter_Ping++;


                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
               
                DispatchIfNecessary(() => {

                    LastHourSeries[0].Values.Add(new ObservableValue(0));
                    LastHourSeries[0].Values.RemoveAt(0);
                });
                Fail_Counter_Ping++;
                // Discard PingExceptions and return false;
            }
            //catch (PingException ex)
            //{
            //    DispatchIfNecessary(() => {

            //        LastHourSeries[0].Values.Add(new ObservableValue(0));
            //        LastHourSeries[0].Values.RemoveAt(0);
            //    });
            //    Fail_Counter_Ping++;
            //    // Discard PingExceptions and return false;
            //}
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            //  this.Resources["Bg_Chart"] = Brushes.Red;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Send_Success_Notif("Launch");
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

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {


        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Launch_Northstar_MouseEnter(object sender, MouseEventArgs e)
        {

            if (Image.Opacity == 1)
            {


                DoubleAnimation da = new DoubleAnimation
                {
                    From = Image.Opacity,
                    To = 0.4,
                    Duration = new Duration(TimeSpan.FromSeconds(2)),
                    AutoReverse = false
                };
                Image.BeginAnimation(OpacityProperty, da);

            }

        }

        private void Launch_Northstar_MouseLeave(object sender, MouseEventArgs e)
        {



            if (Image.Opacity != 1)
            {
                DoubleAnimation da = new DoubleAnimation
                {
                    From = Image.Opacity,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    AutoReverse = false
                };
                Image.BeginAnimation(OpacityProperty, da);
                //BlurBitmapEffect.BeginAnimation(BlurBitmapEffect.RadiusProperty, da);

            }
        }
        /////Chart_Code////////
        /// <summary>
        /// 
        /// </summary>
        public SeriesCollection LastHourSeries { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        private void Profile_Selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            TimePowerChart.Update(true);
        }

        private void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {


        }

        private void TimePowerChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Master_Server_Check_Toggle_Checked(object sender, RoutedEventArgs e)
        {
            Toggle_MS_BT(true);

        }

        private void Master_Server_Check_Toggle_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void Master_Server_Check_Toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            Toggle_MS_BT(false);
        }

        private void Launch_Northstar_Click(object sender, RoutedEventArgs e)
        {
            Minimize_On_Launch = Properties.Settings.Default.Auto_Close_VTOL_on_Launch;
            DirectoryInfo Dir = new DirectoryInfo(Current_Install_Folder);

            if (Dir.Exists)
            {

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = NSExe;
                    procStartInfo.WorkingDirectory = Path.GetDirectoryName(NSExe);
                    if(Properties.Settings.Default.Hide_Console_Window == true)
                    {
                        procStartInfo.CreateNoWindow = true;

                    }
                    else
                    {
                        procStartInfo.CreateNoWindow = false;

                    }



                    process.StartInfo = procStartInfo;

                    process.Start();
                    int id = process.Id;
                    int pid = id;
                    Process tempProc = Process.GetProcessById(id);
                    if (Minimize_On_Launch == true)
                    {
                        Main.Minimize();
                    }
                    process.Close();


                }
                else
                {
                    //Dialog.ButtonRightAppearance = ControlAppearance.Danger;
                    //Dialog.ButtonLeftAppearance = ControlAppearance.Dark;
                    //Dialog.ButtonRightName = "Exit";
                    //Dialog.ButtonLeftName = "Browse";
                    //Dialog.Show("ERROR - ON INSTALL!","Could Not Find Northstar.exe!");


                }
            }
            else
            {
                Launch_Northstar.IsEnabled = false;
                SnackBar.Message = "ERROR - ON Launch, Could Not Find Northstar.exe!";
                SnackBar.Title = "FATAL - ERROR";
                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                SnackBar.Show();
                //Dialog.ButtonRightAppearance = ControlAppearance.Danger;
                //Dialog.ButtonLeftAppearance = ControlAppearance.Dark;
                //Dialog.ButtonRightName = "Exit";
                //Dialog.ButtonLeftName = "Browse";
                //Dialog.Show("ERROR - ON INSTALL!", "Could Not Find Northstar.exe!");


            }
        }
        public bool Check_Process_Running(string ProcessName, bool generic = false)
        {

            Process[] pname = Process.GetProcessesByName(ProcessName);
            if (pname.Length == 0)
            {
                if (generic == false)
                {
                    //Indicator_Origin_Client.Visibility = Visibility.Visible;
                    //Origin_Client_Status.Fill = Brushes.Red;
                }
                return false;
            }
            else
            {
                if (generic == false)
                {
                    //Indicator_Origin_Client.Visibility = Visibility.Hidden;
                    //Origin_Client_Status.Fill = Brushes.LimeGreen;
                }
                return true;
            }

        }
        private string Get_And_Set_Filepaths(string rootDir, string Filename)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@rootDir);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + Filename + "*.*");
                // //Console.WriteLine(rootDir);
                // //Console.WriteLine(Filename);

                foreach (FileInfo foundFile in filesInDir)
                {
                    if (foundFile.Name.Equals(Filename))
                    {
                        ////Console.WriteLine("Found");

                        string fullName = foundFile.FullName;
                        //////Console.WriteLine(fullName);
                        return fullName;


                    }
                    else
                    {

                        return "\nCould Not Find" + Filename + "\n";

                    }

                }
            }

            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();                
            }


            return "Exited with No Due to Missing Or Inaccurate Path";


        }
        private async System.Threading.Tasks.Task CheckGitHubNewerVersion()
        {
            //Get all releases from GitHub
            //Source: https://octokitnet.readthedocs.io/en/latest/getting-started/
            GitHubClient client = new GitHubClient(new ProductHeaderValue("SomeName"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("Username", "Repository");

            //Setup the versions
            Version latestGitHubVersion = new Version(releases[0].TagName);
            Version localVersion = new Version("X.X.X"); //Replace this with your local version. 
                                                         //Only tested with numeric values.

            //Compare the Versions
            //Source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);
            if (versionComparison < 0)
            {
                //The version on GitHub is more up to date than this local release.
            }
            else if (versionComparison > 0)
            {
                //This local version is greater than the release version on GitHub.
            }
            else
            {
                //This local Version and the Version on GitHub are equal.
            }
        }
        void WalkDirectoryTree(DirectoryInfo root, String Search)
        {

          DirectoryInfo[] subDirs = null;

            try
            {

                subDirs = root.GetDirectories();


                var last = subDirs.Last();
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    if (dirInfo.Name.Contains(Search))
                    {

                        Current_Install_Folder = (dirInfo.FullName);
                        break;

                    }
                    else if (last.Equals(dirInfo) && NS_Installed == false)
                    {
                        failed_search_counter++;
                        return;
                    }
                    else
                    {

                        if (deep_Chk == true)
                        {
                            WalkDirectoryTree(dirInfo, Search);

                        }
                    }
                    if (dirInfo == null)
                    {
                        continue;

                    }
                }

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_GROUP_DIRECTORY_TREE_CANNOT_FIND_INSTALL_AT") + root + GetTextResource("NOTIF_ERROR_GROUP_DIRECTORY_TREE_CONTINUE_TRAVERSE"));

            }
            catch (NullReferenceException ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();


            }

        }
        private void FindNSInstall(string Search, string FolderDir)
        {
            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@FolderDir);


            if (Directory.Exists(FolderDir))
            {
                if (!IsDirectoryEmpty(rootDirs))
                {
                    WalkDirectoryTree(rootDirs, Search);

                    ////Console.WriteLine("Files with restricted access:");

                }
                else
                {

                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_DIRECTORY_EMPTY"));
                    return;

                }


            }

            else

            {

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_INVALID_PATH_FED"));
                failed_search_counter++;

            }



        }
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {
            int num = Directory.GetFiles(directory.FullName).Length + Directory.GetDirectories(directory.FullName).Length;
            return num == 0;
        }
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void Origin_Client_Card_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Properties.Settings.Default.EA_APP_SUPPORT == false)
                {
                    if (Check_Process_Running("OriginClientService") == true)
                    {
                        SnackBar.Appearance = ControlAppearance.Caution;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Origin_Client_Card_Click_TheOriginClientIsAlreadyRunning;
                        SnackBar.Show();
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        EA_ORGIGIN_Client_Card.IconFilled = true;

                    }
                    else
                    {
                      
                            Run_Origin();


                      
                        

                    }
                }
                else
                {
                    if (Check_Process_Running("EABackgroundService") == true)
                    {
                        SnackBar.Appearance = ControlAppearance.Caution;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Origin_Client_Card_Click_TheEAClientIsAlreadyRunning;
                        SnackBar.Show();
                        EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                        EA_ORGIGIN_Client_Card.IconFilled = true;

                    }
                    else
                    {
                        var NON_UI = new Thread(() =>
                        {
                            Run_Origin();

                        });
                        NON_UI.IsBackground = true;

                        NON_UI.Start();
                        NON_UI.Join();

                    }
                }



            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();

            }

        }

        async void Run_Origin()
        {
            try
            {
                if (Properties.Settings.Default.EA_APP_SUPPORT == true)
                {
                    if (!File.Exists(EA_Location))
                    {
                        EA_Location = InstalledApplications.GetApplictionInstallPath("EA app") + @"\EADesktop.exe";

                        if (!File.Exists(EA_Location))
                        {
                            string searchfile = "EADesktop.exe";
                            string searchdir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                            IEnumerable<string> filesOrDirectories = FileDirectorySearch.Search(searchdir, searchfile);

                            EA_Location = filesOrDirectories.FirstOrDefault();
                        }
                    }
                    if (File.Exists(EA_Location))
                    {

                        int fail = 0;

                        ProcessStartInfo procStartInfo = new ProcessStartInfo();
                        Process process = new Process();
                        procStartInfo.FileName = EA_Location;
                        procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);


                        // procStartInfo.Arguments = args;

                        process.StartInfo = procStartInfo;

                        process.Start();
                        int id = process.Id;
                        pid = id;
                        Process tempProc = Process.GetProcessById(id);
                        // this.Visible = false;
                        // Thread.Sleep(5000);
                        // tempProc.WaitForExit();
                        // this.Visible = true;


                        // Process process = Process.Start(NSExe, Arg_Box.Text);
                        process.Close();

                        EAClient_Running = Check_Process_Running("EABackgroundService");
                        fail = 0;
                        while (!EAClient_Running && fail <= 3)
                        {


                            EAClient_Running = Check_Process_Running("EABackgroundService");

                            await Task.Delay(1000);
                            fail++;
                        }


                        if (fail >= 3)
                        {
                            DispatchIfNecessary(() =>
                            {

                                EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                                EA_ORGIGIN_Client_Card.IconFilled = false;
                            });
                            return;


                        }
                        if (EAClient_Running == true)
                        {
                            DispatchIfNecessary(() =>
                            {

                                EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                                EA_ORGIGIN_Client_Card.IconFilled = true;

                            });
                            return;
                        }


                    }
                    else
                    {
                        DispatchIfNecessary(() =>
                        {
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = "Could Not find EA install! Please re-install or switch to Origin";
                            SnackBar.Show();

                            EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                            EA_ORGIGIN_Client_Card.IconFilled = false;
                        });

                    }







                }
                else
                {


                    if (Check_Process_Running("EABackgroundService", true) == true)
                    {


                        Process[] runingProcess = Process.GetProcesses();
                        string[] origin = {
                            "QtWebEngineProcess",
                            "OriginLegacyCompatibility",
                            "EADesktop",
                            "EABackgroundService",
                            "EALauncher",
                            "Link2EA",
                            "EALocalHostSvc",
                            "EAGEP"};

                        for (int i = 0; i < runingProcess.Length; i++)
                        {
                            foreach (var x in origin)
                            {
                                // compare equivalent process by their name

                                if (runingProcess[i].ProcessName == x)
                                {
                                    try
                                    {
                                        //kill running process
                                        runingProcess[i].Kill();
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }


                        }

                    }

                    if (!File.Exists(Origin_Location))
                    {
                        Origin_Location = InstalledApplications.GetApplictionInstallPath("Origin") + @"\Origin.exe";

                        if (!File.Exists(Origin_Location))
                        {
                            string searchfile = "Origin.exe";
                            string searchdir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                            IEnumerable<string> filesOrDirectories = FileDirectorySearch.Search(searchdir, searchfile);

                            Origin_Location = filesOrDirectories.FirstOrDefault();
                        }
                    }
                    if (File.Exists(Origin_Location))
                    {
                        //Send_Success_Notif("Starting Origin Client Service!");
                        //Indicator_Origin_Client.Visibility = Visibility.Hidden;
                        int fail = 0;

                        ProcessStartInfo procStartInfo = new ProcessStartInfo();
                        Process process = new Process();
                        procStartInfo.FileName = Origin_Location;
                        procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);


                        // procStartInfo.Arguments = args;

                        process.StartInfo = procStartInfo;

                        process.Start();
                        int id = process.Id;
                        pid = id;
                        Process tempProc = Process.GetProcessById(id);
                        // this.Visible = false;
                        // Thread.Sleep(5000);
                        // tempProc.WaitForExit();
                        // this.Visible = true;


                        // Process process = Process.Start(NSExe, Arg_Box.Text);
                        process.Close();

                        
                            Origin_Client_Running = Check_Process_Running("OriginClientService");
                            fail = 0;
                            while (!Origin_Client_Running && fail <= 3)
                            {


                                Origin_Client_Running = Check_Process_Running("OriginClientService");

                            await Task.Delay(1000);
                            fail++;
                            }
                            if (fail >= 3)
                            {
                            DispatchIfNecessary(() =>
                            {

                                EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                                EA_ORGIGIN_Client_Card.IconFilled = false;
                            });


                            }
                        if (Origin_Client_Running == true)
                        {
                            DispatchIfNecessary(() =>
                            {
                                EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                            EA_ORGIGIN_Client_Card.IconFilled = true;
                        });

                            }

                    }
                    else
                    {
                        DispatchIfNecessary(() =>
                        {
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Run_Origin_CouldNotFindEAOriginInstallPleaseStartManuallyOrRepairYourInstallation;
                            SnackBar.Show();

                            EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                            EA_ORGIGIN_Client_Card.IconFilled = false;

                        });
                    }

                }

                
            }
            catch (Exception ex)
            {
                DispatchIfNecessary(() =>
                {

                    EA_ORGIGIN_Client_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#99630000");
                    EA_ORGIGIN_Client_Card.IconFilled = false;
                });
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();
            }

        }
       
        private void Browse_Titanfall_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var folderDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                var result = folderDlg.ShowDialog();
                if (result == true)
                {
                    string path = folderDlg.SelectedPath;
                    if (path == null || !Directory.Exists(path))
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "WARNING!";
                        SnackBar.Message = "Invalid Install Path!";
                        SnackBar.Show();

                        //Send_Error_Notif(GetTextResource("NOTIF_ERROR_INVALID_INSTALL_PATH"));


                    }
                    else
                    {
                        Current_Install_Folder = path+@"\";
                        DirectoryInfo Dir = new DirectoryInfo(Current_Install_Folder);

                        if (Dir.Exists && File.Exists(Current_Install_Folder + "Titanfall2.exe"))
                        {
                            if (File.Exists(Current_Install_Folder + "NorthstarLauncher.exe"))
                            {
                                Found_Install_Folder = true;
                                // Directory_Box.Background = Brushes.White;
                                Console.WriteLine("Found");
                                Console.WriteLine(Current_Install_Folder);

                                Directory_Box.Text = Current_Install_Folder;

                                User_Settings_Vars.NorthstarInstallLocation = Current_Install_Folder;
                                string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                                using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                                {
                                    StreamWriter.WriteLine(User_Settings_Json_Strings);
                                    StreamWriter.Close();
                                }

                                NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                                Check_Integrity_Of_NSINSTALL();
                                SnackBar.Appearance = ControlAppearance.Success;
                                SnackBar.Title = "SUCCESS";
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Browse_Titanfall_Button_Click_TheLocation+ Current_Install_Folder + VTOL.Resources.Languages.Language.Page_Home_Browse_Titanfall_Button_Click_IsValidAndHasBeenSet;
                                SnackBar.Show();
                                Restart_App();
                            }
                            else
                            {
                                if (!Current_Install_Folder.EndsWith(@"\"))
                                {
                                    string fix = Current_Install_Folder + @"\";
                                    User_Settings_Vars.NorthstarInstallLocation = fix;
                                    Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                                    Console.WriteLine("Replaced2");

                                }
                                SnackBar.Appearance = ControlAppearance.Danger;
                                SnackBar.Title = "WARNING!";
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_INIT_NORTHSTARAUTOINSTALLWILLNOWBEGINPLEASEWAITABOUT30SECONDS;
                                SnackBar.Timeout = 8000;
                                SnackBar.Show();

                                Auto_Install_(true);
                            }
                        }
                        else
                        {
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "WARNING!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Browse_Titanfall_Button_Click_TheLocation + Current_Install_Folder +VTOL.Resources.Languages.Language.Page_Home_Browse_Titanfall_Button_Click_IsNotValid;
                            SnackBar.Timeout = 8000;
                            SnackBar.Show();

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();

            }
        }
        private static bool ListCheck<T>(IEnumerable<T> l1, IEnumerable<T> l2)
        {
            // TODO: Null parm checks 
            if (l1.Intersect(l2).Any())
            {
                ////Console.WriteLine("matched");
                return true;
            }
            else
            {
                ////Console.WriteLine("not matched");
                return false;
            }
        }
        private async Task Check_Integrity_Of_NSINSTALL()
        {


            if (File.Exists(NSExe))
            {
                System.IO.DirectoryInfo[] FolderDir = null;
                System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder);
                FolderDir = rootDirs.GetDirectories();
                // List<string> Baseline = Read_From_Text_File(@"C:\ProgramData\NorthstarModManager\NormalFolderStructure.txt");
                List<string> Baseline = new List<string>()
                {
                    @"Titanfall2\bin",
                    @"Titanfall2\Core",
@"Titanfall2\platform",
@"Titanfall2\r2",
@"Titanfall2\R2Northstar",
@"Titanfall2\ShaderCache",
@"Titanfall2\Support",
@"Titanfall2\vpk",
@"Titanfall2\__Installer"

                };
                List<string> current = new List<string>();
                ////Console.WriteLine("Baseline");

                foreach (var Folder in FolderDir)
                {
                    string s = Folder.ToString().Substring(Folder.ToString().LastIndexOf("Titanfall2"));

                    current.Add(s);

                    //saveAsyncFile(s, @"C:\temp\NormalFolderStructure");

                }
                ////Console.WriteLine("current");

                foreach (var Folder in current)
                {

                    ////Console.WriteLine(Folder.ToString());

                }
                ////Console.WriteLine(Baseline.SequenceEqual(current));

                if (ListCheck(Baseline, current) == true)
                {
                    NS_Installed = true;


                }
                else
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "WARNING!";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Check_Integrity_Of_NSINSTALL_DirectoryCheckFailed;
                    SnackBar.Show();
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_DIRECTORY_CHECK_FAILED"));
                    NS_Installed = false;


                }




            }
            else
            {

                NS_Installed = false;
            }

            if (NS_Installed == false)
            {

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_NS_BAD_INTEGRITY"));

                //Install_NS_EXE_Textbox.Foreground = Brushes.Red;

            }
            else
            {

                //Install_NS_EXE_Textbox.Foreground = Brushes.Green;
                //Send_Success_Notif(GetTextResource("NOTIF_SUCCESS_INTEGRITY_VERIFIED"));


            }
            //Install_NS_EXE_Textbox.Text = NSExe;




        }
        void Fade_In_Fade_Out_Control(bool fade_in = false)
        {
            if (fade_in == true)
            {
                DispatchIfNecessary(() =>
                {
                    if (ProgressBar.Opacity < 1)
                    {

                        DoubleAnimation da = new DoubleAnimation
                        {
                            From = ProgressBar.Opacity,
                            To = 1,
                            Duration = new Duration(TimeSpan.FromSeconds(1)),
                            AutoReverse = false
                        };
                        ProgressBar.BeginAnimation(OpacityProperty, da);

                    }
                });
            }
            else
            {
                DispatchIfNecessary(() =>
                {
                    if (ProgressBar.Opacity > 0)
                    {

                        DoubleAnimation da = new DoubleAnimation
                        {
                            From = ProgressBar.Opacity,
                            To = 0,
                            Duration = new Duration(TimeSpan.FromSeconds(1)),
                            AutoReverse = false
                        };
                        ProgressBar.BeginAnimation(OpacityProperty, da);

                    }
                });
            }



        }
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
        private async Task Read_Latest_Release(string address, string json_name = "temp.json", bool Parse = true, bool Log_Msgs = true)
        {
            if (address != null)
            {
                if (Log_Msgs == true)
                {
                    // Send_Info_Notif("\nJson Download Started!");

                }
                WebClient client = new WebClient();
                webClient.Proxy = null;
                WebRequest.DefaultWebProxy = null;
                Uri uri1 = new Uri(address);
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream data = client.OpenRead(address);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();



                s = s.Replace("[", "");
                s = s.Replace("]", "");

                if (Directory.Exists(AppDataFolder + @"\VTOL_DATA\temp"))
                {
                    saveAsyncFile(s, AppDataFolder + @"\VTOL_DATA\temp\" + json_name, false, false);
                    FileInfo File = new FileInfo(AppDataFolder + @"\VTOL_DATA\temp\" + json_name);
                    int attempts = 0;

                    while (IsFileLocked(File) == true && attempts != 5)
                    {


                        await Task.Delay(1000);
                        attempts++;
                    }
                    Parse_Release();
                    

                }
                else
                {
                   TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\temp\");
                    saveAsyncFile(s, AppDataFolder + @"\VTOL_DATA\temp\" + json_name, false, false);
                    FileInfo File = new FileInfo(AppDataFolder + @"\VTOL_DATA\temp\" + json_name);
                    int attempts = 0;

                    while (IsFileLocked(File) == true && attempts != 5)
                    {


                        await Task.Delay(1000);
                        attempts++;
                    }
                    Parse_Release();
                    
                }

            }
            else
            {

                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR!";
                SnackBar.Message = VTOL.Resources.Languages.Language.Read_Latest_Release_InvalidReleaseDonwloadURL;
                SnackBar.Show();

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_INVALID_URL"));
            }

        }
        public async Task saveAsyncFile(string Text, string Filename, bool ForceTxt = true, bool append = true)
        {
            await Task.Run(() =>
            {
                if (ForceTxt == true)
                {
                    if (!Filename.Contains(".txt"))
                    {
                        Filename = Filename + ".txt";

                    }
                }
                if (append == true)
                {
                    if (File.Exists(Filename))
                    {

                        using StreamWriter file = new(Filename, append: true);
                        file.WriteLine(Text);
                        file.Close();
                    }
                    else
                    {

                        File.WriteAllText(Filename, string.Empty);

                        File.WriteAllText(Filename, Text);

                    }
                }
                else
                {
                    File.WriteAllText(Filename, string.Empty);

                    File.WriteAllText(Filename, Text);

                }
            });
        }
        private void Parse_Release(string json_name = "temp.json")
        {
            try
            {
                if (File.Exists(AppDataFolder + @"\VTOL_DATA\temp\" + json_name))
                {

                    var myJsonString = File.ReadAllText(AppDataFolder + @"\VTOL_DATA\temp\" + json_name);
                    var myJObject = JObject.Parse(myJsonString);


                    
                    current_Northstar_version_Url = myJObject.SelectToken("assets.browser_download_url").Value<string>();
                    Properties.Settings.Default.Version = myJObject.SelectToken("tag_name").Value<string>();
                    Properties.Settings.Default.Save();
                    User_Settings_Vars.CurrentVersion = Properties.Settings.Default.Version;
                    string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                    using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                    {
                        StreamWriter.WriteLine(User_Settings_Json_Strings);
                        StreamWriter.Close();
                    }
                    //Send_Info_Notif(GetTextResource("NOTIF_INFO_RELEASE_PARSED") + current_Northstar_version_Url);

                }
                else
                {
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_RELEASE_NOT_FOUND"));
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR!";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Parse_Release_ReleaseNotFound;
                    SnackBar.Show();


                }

                if (Directory.Exists(AppDataFolder + @"\VTOL_DATA\temp\" + json_name))
                {
                    if (File.Exists(AppDataFolder + @"\VTOL_DATA\temp\" + json_name))
                    {
                        File.Delete(AppDataFolder + @"\VTOL_DATA\temp\" + json_name);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();
                return;

            }
        }
     
        void Check_For_New_Northstar_Install()
        {
            try
            {
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Current_Install_Folder + @"NorthstarLauncher.exe");
                if (myFileVersionInfo.FileVersion.Contains("rc"))
                {
                    SnackBar.Message = VTOL.Resources.Languages.Language.Check_For_New_Northstar_Install_ReleaseCandidateDetected;
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                    return;

                }
                Updater Update = new Updater(User_Settings_Vars.Author, User_Settings_Vars.Repo);
                Update.Force_Version = User_Settings_Vars.CurrentVersion;
                Update.Force_Version_ = true;
                if (Update.CheckForUpdate(true))
                {
                   


                        SnackBar.Message = VTOL.Resources.Languages.Language.Check_For_New_Northstar_Install_UpdateAvailableDownloadingAndInstallingNow;
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                    if (!Current_Install_Folder.EndsWith(@"\"))
                    {
                        string fix = Current_Install_Folder + @"\";
                        User_Settings_Vars.NorthstarInstallLocation = fix;
                        Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");
                        Console.WriteLine("Replaced2");

                    }
                    Auto_Install_(false);
                    


                        // Get the file version info for the notepad.

                        // Print the file name and version number.
                        Console.WriteLine(myFileVersionInfo.FileVersion);
                        Current_Ver_ = myFileVersionInfo.FileVersion;

                        User_Settings_Vars.CurrentVersion = Current_Ver_;
                        Properties.Settings.Default.Version = Current_Ver_;
                        Properties.Settings.Default.Save();

                    Main.NORTHSTAR_BUTTON.Content = "Northstar Version - " + Current_Ver_.Remove(0, 1);
                    Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";
                    Main.VERSION_TEXT.Refresh();
                    Main.NORTHSTAR_BUTTON.Refresh();
                    NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                        Main.VERSION_TEXT.Refresh();
                        string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
                        using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
                        {
                            StreamWriter.WriteLine(User_Settings_Json_Strings);
                            StreamWriter.Close();
                        }
                    
                }
              
               
                    

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();

            }



        }
        async Task Install_NS_METHOD()
        {
            await Task.Run(async () =>
            {
            try
                {
                    webClient = new WebClient();
                    webClient.Proxy = null;
                    WebRequest.DefaultWebProxy = null;
                    DispatchIfNecessary(() =>
                    {

                        ProgressBar.Value = 0;
                    });
                    Fade_In_Fade_Out_Control(true);

                    if (Directory.Exists(Current_Install_Folder + @"TempCopyFolder"))
                {

                        TryDeleteDirectory(Current_Install_Folder + @"TempCopyFolder", true);
                    
                    
                }
                  await Read_Latest_Release(Current_REPO_URL);
                    //Current_File_Label.Content = GetTextResource("DOWNLOADING_NORTHSTAR_LATEST_RELEAST_TEXT") + "-" + Properties.Settings.Default.Version;

                            

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                string x = "";
                if (Directory.Exists(Current_Install_Folder)  && Current_Install_Folder != null && Current_Install_Folder != "NODATA")
                {
                    if (File.Exists(Current_Install_Folder + @"ns_startup_args_dedi.txt") && File.Exists(Current_Install_Folder + @"ns_startup_args.txt") )
                    {
                        //x = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();

                        if (do_not_overwrite_Ns_file == true)
                        {
                            if (Directory.Exists(Current_Install_Folder + @"TempCopyFolder"))
                            {
                                if (Directory.Exists(Current_Install_Folder + @"ns_startup_args.txt"))
                                {
                                   TryCopyFile(Current_Install_Folder + @"ns_startup_args.txt", Current_Install_Folder + @"TempCopyFolder\ns_startup_args.txt", true);
                                }
                                if (Directory.Exists(Current_Install_Folder + @"ns_startup_args_dedi.txt"))
                                {
                                        TryCopyFile(Current_Install_Folder + @"ns_startup_args_dedi.txt", Current_Install_Folder + @"TempCopyFolder\ns_startup_args_dedi.txt", true);
                                }
                            }
                            else
                            {

                               TryCreateDirectory(Current_Install_Folder + @"TempCopyFolder");
                                if (Directory.Exists(Current_Install_Folder + @"ns_startup_args.txt"))
                                {
                                   TryCopyFile(Current_Install_Folder + @"ns_startup_args.txt", Current_Install_Folder + @"TempCopyFolder\ns_startup_args.txt", true);
                                }
                                if (Directory.Exists(Current_Install_Folder + @"ns_startup_args_dedi.txt"))
                                {
                                    TryCopyFile(Current_Install_Folder + @"ns_startup_args_dedi.txt", Current_Install_Folder + @"TempCopyFolder\ns_startup_args_dedi.txt", true);
                                }
                            }
                           TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\Releases\");
                            webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), AppDataFolder + @"\VTOL_DATA\Releases\Northstar_Release.zip");
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback_Progress_Window);
                                while (unpack_flg == false)
                                {
                                    await Task.Delay(1000);
                                }




                            }
                            else
                        {

                           TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\Releases\");
                            webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), AppDataFolder + @"\VTOL_DATA\Releases\Northstar_Release.zip");
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback_Progress_Window);
                                while (unpack_flg == false)
                                {
                                    await Task.Delay(1000);
                                }




                            }



                        }
                    else
                    {

                       TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\Releases\");
                        webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), AppDataFolder + @"\VTOL_DATA\Releases\Northstar_Release.zip");
                        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback_Progress_Window);
                           
                            while ( unpack_flg == false)
                            {
                                await Task.Delay(1000);
                            }


                        }
                    }

            }
            catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                     Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();
                    DispatchIfNecessary(() =>
                    {
                        Fade_In_Fade_Out_Control(false);


                    });
                    if (ex.Message == "Sequence contains no elements")
                {

                }
                else
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");




                }

                return;
            }
                });
        }

        public string GetFile(string directory, string Search,
   int maxRetries = 10,
   int millisecondsDelay = 30)
        {
            if (directory == null)
                throw new ArgumentNullException(directory);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {
                try
                {
                    List<string> files = new List<string>();

                    files.AddRange(Directory.GetFiles(directory, Search, SearchOption.AllDirectories));
                    if (files.Count >= 1)
                    {
                        return files.FirstOrDefault();

                    }
                    else
                    {
                        return "";
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
                catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                    Main.logger2.Open();
                    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    Main.logger2.Close();
                }
            }

            return null;
        }
        
        private void DownloadProgressCallback_Progress_Window(object sender, DownloadProgressChangedEventArgs e)
        {

            // Displays the operation identifier, and the transfer progress.
            DispatchIfNecessary(() =>
            {
                ProgressBar.Value = e.ProgressPercentage;


            });
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                webClient = null;
                if (File.Exists(AppDataFolder + @"\VTOL_DATA\Releases\NorthStar_Release.zip"))
                {

                    DispatchIfNecessary(() =>
                    {
                        ProgressBar.IsIndeterminate = true;

                    });
                    if (!Current_Install_Folder.EndsWith(@"\"))
                    {
                        string fix = Current_Install_Folder + @"\";
                        User_Settings_Vars.NorthstarInstallLocation = fix;
                        Current_Install_Folder = fix.Replace(@"\\", @"\").Replace("/", @"\");

                    }
                   
                    if(Directory.Exists(Current_Install_Folder))
                    {
                        if (!User_Settings_Vars.NorthstarInstallLocation.EndsWith(@"\"))
                        {
                            string fix = User_Settings_Vars.NorthstarInstallLocation + @"\";
                            User_Settings_Vars.NorthstarInstallLocation = fix.Replace(@"\\", @"\").Replace("/", @"\");

                        }
                        if (User_Settings_Vars.NorthstarInstallLocation != Current_Install_Folder)
                        {
                            User_Settings_Vars.NorthstarInstallLocation = Current_Install_Folder;
                        }
                        Unpack_To_Location(AppDataFolder + @"\VTOL_DATA\Releases\NorthStar_Release.zip", User_Settings_Vars.NorthstarInstallLocation);


                    }else

                        DispatchIfNecessary(() =>
                        
                        {
                            Fade_In_Fade_Out_Control(false);

                            ProgressBar.Value = 0;
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "ERROR!";
                            SnackBar.Message = "Install Location Is Invalid";
                            SnackBar.Show();
                        });
                       
                        return;
                    }
                }

            

            catch (Exception ex)
            {
                if(ex.Message.Contains("is denied"))
                {
                    Admin_Warn_Flag++;
                }
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                 Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();
                DispatchIfNecessary(() =>
                {
                    Fade_In_Fade_Out_Control(false);
                   
                        ProgressBar.Value = 0;


                });


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
        private void Unpack_To_Location(string Target_Zip, string Destination_Zip)
        {
            try
            {
                unpack_flg = false;
                if (Directory.Exists(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Client\Locked_Folder"))
                {
                    TryDeleteDirectory(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Client\Locked_Folder", true);

                }
                if (Directory.Exists(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Custom\Locked_Folder"))
                {
                    TryDeleteDirectory(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Custom\Locked_Folder", true);



                }
                if (Directory.Exists(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\Locked_Folder"))
                {
                    TryDeleteDirectory(Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\Locked_Folder", true);


                }
                string nrml = GetFile(Current_Install_Folder, @"ns_startup_args.txt");
                string cfg = GetFile(Current_Install_Folder, @"autoexec_ns_server.cfg");
                string dedi = GetFile(Current_Install_Folder, @"ns_startup_args_dedi.txt");
                if (do_not_overwrite_Ns_file == true)
                {
                    if (!Directory.Exists(Current_Install_Folder + @"TempCopyFolder"))
                    {
                        TryCreateDirectory(Current_Install_Folder + @"TempCopyFolder");
                    }
                    if (IsValidPath(nrml))
                    {
                        if (File.Exists(nrml))
                        {
                            TryCopyFile(nrml, Current_Install_Folder + @"TempCopyFolder\ns_startup_args.txt", true);
                        }
                    }





                    if (IsValidPath(cfg))
                    {
                        if (File.Exists(cfg))
                        {
                            TryCopyFile(cfg, Current_Install_Folder + @"TempCopyFolder\autoexec_ns_server.cfg", true);


                        }
                    }



                    if (IsValidPath(dedi))
                    {
                        if (File.Exists(dedi))
                        {


                            TryCopyFile(dedi, Current_Install_Folder + @"TempCopyFolder\ns_startup_args_dedi.txt", true);
                        }

                    }

                }

                if (File.Exists(Target_Zip) && Directory.Exists(Destination_Zip))
                {
                    Console.WriteLine("Destination_E1-" + Destination_Zip);

                    string fileExt = Path.GetExtension(Target_Zip);

                    if (fileExt == ".zip")
                    {

                        TryUnzipFile(Target_Zip, Destination_Zip);


                        if (do_not_overwrite_Ns_file == true)
                        {

                            if (Directory.Exists(Current_Install_Folder + @"TempCopyFolder\"))
                            {
                                if (File.Exists(Current_Install_Folder + @"TempCopyFolder\ns_startup_args.txt"))
                                {

                                    TryCopyFile(Current_Install_Folder + @"TempCopyFolder\ns_startup_args.txt", Current_Install_Folder + @"ns_startup_args.txt", true);
                                }


                                if (File.Exists(Current_Install_Folder + @"TempCopyFolder\autoexec_ns_server.cfg"))
                                {
                                    TryCopyFile(Current_Install_Folder + @"TempCopyFolder\autoexec_ns_server.cfg", Current_Install_Folder + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg", true);
                                }
                                if (File.Exists(Current_Install_Folder + @"TempCopyFolder\ns_startup_args_dedi.txt"))
                                {
                                    TryCopyFile(Current_Install_Folder + @"TempCopyFolder\ns_startup_args_dedi.txt", Current_Install_Folder + @"ns_startup_args_dedi.txt", true);
                                }

                            }
                        }



                        if (Directory.Exists(Current_Install_Folder + @"TempCopyFolder"))
                        {
                            TryDeleteDirectory(Current_Install_Folder + @"TempCopyFolder", true);
                        }
                        DispatchIfNecessary(() =>
                        {
                            Fade_In_Fade_Out_Control(false);
                            ProgressBar.Value = 0;
                            Mouse.OverrideCursor = null;


                            unpack_flg = true;
                            SnackBar.Message = VTOL.Resources.Languages.Language.Unpack_To_Location_InstallationComplete;
                            SnackBar.Title = "SUCCESS";
                            SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                            SnackBar.Show();

                        });




                    }
                    else
                    {
                        if (!File.Exists(Target_Zip))
                        {
                            Fade_In_Fade_Out_Control(false);

                            DispatchIfNecessary(() =>
                            {
                                ProgressBar.Value = 0;

                            });
                            //Send_Error_Notif(GetTextResource("NOTIF_ERROR_ZIP_NOT_EXIST"));
                            Log.Error("The File - " + Target_Zip + "Was not Found!");
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "ERROR!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Unpack_To_Location_TheFile + Target_Zip + VTOL.Resources.Languages.Language.Unpack_To_Location_WasNotFound;
                            SnackBar.Show();

                        }
                        if (!Directory.Exists(Destination_Zip))
                        {
                            Fade_In_Fade_Out_Control(false);

                            DispatchIfNecessary(() =>
                            {
                                ProgressBar.Value = 0;

                            });
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "ERROR!";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Unpack_To_Location_TheFile + Destination_Zip + VTOL.Resources.Languages.Language.Page_Home_Unpack_To_Location_WasNotFound;
                            SnackBar.Show();
                            //Send_Error_Notif(GetTextResource("NOTIF_ERROR_ZIP_NOT_EXIST_CHECK_PATH"));
                            Log.Error("The File - " + Destination_Zip + "Was not Found!");

                        }
                    }
                }
                else
                {
                    Fade_In_Fade_Out_Control(false);

                    DispatchIfNecessary(() =>
                    {
                        ProgressBar.Value = 0;

                    });
                    Log.Error("The File - " + Target_Zip + "is not a zip!");
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR!";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Home_Unpack_To_Location_TheFile + Target_Zip + VTOL.Resources.Languages.Language.Page_Home_Unpack_To_Location_IsNotAZip;
                    SnackBar.Show();
                    // Main_Window.SelectedTab = Main;
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_OBJ_NOT_ZIP"));

                }
            }
            catch (Exception ex)
            {
                Fade_In_Fade_Out_Control(false);

                DispatchIfNecessary(() =>
                {
                    ProgressBar.Value = 0;

                });
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Main.logger2.Close();



            }

           
            
        }

        private void Update_Northstar_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                  Install_NS_METHOD();

                //InfoBar_Test_1.Message = "sdsd";
                //InfoBar_Test_1.IsOpen = true;
                //InfoBar_Test_1.Title = "Les Goo";
                //InfoBar_Test_1.Severity = Wpf.Ui.Controls.InfoBarSeverity.Success;
                //InfoBar_Test_1.Background = Brushes.Green;
            }

            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                 Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
Main.logger2.Close();



            }
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += (sender, e) =>
            //{





            //};
            //worker.RunWorkerCompleted += (sender, eventArgs) =>
            //{



            //};
            //worker.RunWorkerAsync();





        }

        private void GIT_Button_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://r2northstar.gitbook.io/r2northstar-wiki/");
        }

        private void Discord_Button_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://discord.gg/northstar");
        }

        private void Browse_Titanfall_Install_Click(object sender, RoutedEventArgs e)
        {
            Open_Folder(Current_Install_Folder);
        }

        private void EA_ORGIGIN_Client_Card_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.EA_APP_SUPPORT == true)
            {
                EA_ORGIGIN_Client_Card.Content = VTOL.Resources.Languages.Language.Page_Home_Page_Home_EAClientRunning;
                BitmapImage bitmapx = new BitmapImage();

                bitmapx.BeginInit();
                bitmapx.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/EA.ico");
                bitmapx.EndInit();
                CLIENT_CARD_IMAGE.Source = bitmapx;

              
            }
            else
            {
                BitmapImage bitmapy = new BitmapImage();

                bitmapy.BeginInit();
                bitmapy.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/Origin.ico");
                bitmapy.EndInit();
                CLIENT_CARD_IMAGE.Source = bitmapy;

                EA_ORGIGIN_Client_Card.Content = VTOL.Resources.Languages.Language.Page_Home_OriginClientRunning;
               

            }

            BackgroundWorker worker_o = new BackgroundWorker();
            worker_o.DoWork += (sender, e) =>
            {
                Check_origin_status();
            };

            worker_o.RunWorkerAsync();
        }
    }
}
