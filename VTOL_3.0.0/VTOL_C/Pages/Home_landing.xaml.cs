using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
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
using Page = iNKORE.UI.WPF.Modern.Controls.Page;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MathCore.Logging;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Net;
using System.Reflection;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Wpf.Ui.Common;
using Application = System.Windows.Application;
using FileMode = System.IO.FileMode;
using Path = System.IO.Path;
using Microsoft.Win32;
using Serilog;
using Log = Serilog.Log;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using Nucs.JsonSettings;

namespace VTOL_C.Pages
{
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
            string Direct_Directory_Check = FindTitanfall2Folder();
            if (Direct_Directory_Check != null)
            {

                return Direct_Directory_Check;
            }

            return string.Empty;
        }
        static string FindTitanfall2Folder()
        {
            string commonFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string[] titanfall2Paths = new string[]
            {
        Path.Combine(commonFolder, "Steam", "steamapps", "common", "Titanfall2"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Origin Games", "Titanfall2"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "EA Games", "Titanfall2")
            };

            foreach (string titanfall2Path in titanfall2Paths)
            {
                if (Directory.Exists(titanfall2Path) && File.Exists(titanfall2Path + "@/Titanfall2.exe"))
                {
                    return titanfall2Path;
                }
            }

            return null;
        }
        public static void GetInstalledApps()

        {


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
                            var st = new System.Diagnostics.StackTrace(ex, true);
                            var frame = st.GetFrame(0);
                            var line = frame.GetFileLineNumber();
                            var method = frame.GetMethod().Name;
                            var className = frame.GetMethod().DeclaringType.Name;
                            var variables = ""; // You would need to add logic to capture variable values

                            Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                                           $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                                           $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                        }
                    }
                }

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
    /// <summary>
    /// Interaction logic for Home_landing.xaml
    /// </summary>
    public partial class Home_landing : Page
    {

        //Declarations
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
        //User_Settings User_Settings_Vars = null;
        string AppDataFolder = null;
       // Wpf.Ui.Controls.Snackbar SnackBar;
        WebClient webClient;
      //  private Page_Thunderstore Page_Thunderstore;
        private bool unpack_flg = false;
        public int Admin_Warn_Flag = 0;
        System.Drawing.Point cursorPoint;
        int minutesIdle = 0;
        int showcntr = 0;
        private readonly System.Windows.Threading.DispatcherTimer _timer;
        public SeriesCollection LastHourSeries { get; set; }
        public MainWindow MainInstance;



        //Timers
        DispatcherTimer Log_Changes_Timer = new DispatcherTimer();
                DispatcherTimer UPDATES_TIMER = new DispatcherTimer();
                DispatcherTimer timer = new DispatcherTimer();
               // timer.Interval = TimeSpan.FromSeconds(2);
              //  Log_Changes_Timer.Interval = TimeSpan.FromSeconds(10);
               // UPDATES_TIMER.Interval = TimeSpan.FromSeconds(150);
               // UPDATES_TIMER.Tick += UPDATES_TIMER_Tick;
              //  timer.Tick += timer_Tick;
              //  Log_Changes_Timer.Tick += Log_Changes_Timer_Tick;

              //  timer.Start();
             //   Log_Changes_Timer.Start();
              //  UPDATES_TIMER.Start();
             //   showcntr = Properties.Settings.Default.Banner_CNTR;
                Random random_ = new Random();





        private int index = 0;
        private Random random = new Random();
        private ObservableCollection<ObservablePoint> observableValues;

      

        public ObservableCollection<ISeries> Series { get; set; }





        public MySettings Settings; //relative path to executing file.

        public void Load_Settings()
        {
            UTILS uTILS = new UTILS();
            if (uTILS.ValidateFileExists("config.json"))
            {
                Settings = JsonSettings.Load<MySettings>("config.json"); //relative path to executing file.

            }
            else
            {
                Settings = JsonSettings.Construct<MySettings>("config.json"); ; //relative path to executing file.

            }
        }








        public void AddRandomItem()
        {
            var randomValue = random.Next(1, 10);
            observableValues.Add(new ObservablePoint(index++, randomValue));
        }

        public void RemoveFirstItem()
        {
            observableValues.RemoveAt(0);
        }


        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }



        public Home_landing()
        {
            InitializeComponent();
            observableValues = new ObservableCollection<ObservablePoint>();

            Series = new ObservableCollection<ISeries>
        {
            new ColumnSeries<ObservablePoint> { Values = observableValues }
        };

            Load_Settings();
        }

        public void Load_Charts()
        {
            DispatchIfNecessary(async () =>
            {
                while (true)
                {
                    AddRandomItem();

                    RemoveFirstItem();
                    await Task.Delay(50);
                }
            });
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
                    DispatchIfNecessary(async () =>
                    {

                        //Master_Server_Card.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#B2037F10");
                       // Master_Server_Card.Icon = SymbolRegular.PlugConnected20;

                        LastHourSeries[0].Values.Add(new ObservableValue(_avgRtt));
                        LastHourSeries[0].Values.RemoveAt(0);
                    });

                    Fail_Counter_Ping = 0;
                }

                else
                {
                    DispatchIfNecessary(async () =>
                    {

                        LastHourSeries[0].Values.Add(new ObservableValue(0));
                        LastHourSeries[0].Values.RemoveAt(0);
                    });
                    Fail_Counter_Ping++;
                    return;

                }


            }

            catch (WebException wex)
            {
                Log.Error(wex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{wex.InnerException}{Environment.NewLine}");
                if (wex.Response != null)
                {
                    if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        DispatchIfNecessary(async () =>
                        {

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
                var st = new System.Diagnostics.StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                var method = frame.GetMethod().Name;
                var className = frame.GetMethod().DeclaringType.Name;
                var variables = ""; // You would need to add logic to capture variable values

                Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                               $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                               $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}"); DispatchIfNecessary(async () =>
                               {

                                   LastHourSeries[0].Values.Add(new ObservableValue(0));
                                   LastHourSeries[0].Values.RemoveAt(0);
                               });
                Fail_Counter_Ping++;
                // Discard PingExceptions and return false;
            }

            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            
            Load_Charts();
           
        }
    }
}
