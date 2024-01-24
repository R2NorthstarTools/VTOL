using Microsoft.Xaml.Behaviors;
using Newtonsoft.Json.Linq;
using Pixelmaniac.Notifications;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using VTOL.Pages;
using VTOL.Titanfall2_Requisite.WeaponData.Default.Titan;
using static VTOL.Pages.Page_Thunderstore;

namespace VTOL
{

    public class FadeInOutBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.IsVisibleChanged += OnIsVisibleChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.IsVisibleChanged -= OnIsVisibleChanged;
        }

        private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                Storyboard.SetTarget(FadeInOut, AssociatedObject);
                FadeInOut.Begin();
            }
            else
            {
                FadeInOut.Stop();
                AssociatedObject.Opacity = 0;
            }
        }

        public Storyboard FadeInOut
        {
            get { return (Storyboard)GetValue(FadeInOutProperty); }
            set { SetValue(FadeInOutProperty, value); }
        }

        public static readonly DependencyProperty FadeInOutProperty =
            DependencyProperty.Register("FadeInOut", typeof(Storyboard), typeof(FadeInOutBehavior), new PropertyMetadata(null));
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Merge Complete
        private Wpf.Ui.Appearance.ThemeType ThemeType = Wpf.Ui.Appearance.ThemeType.Dark;
        bool Profile_card = false;
        public User_Settings User_Settings_Vars = new User_Settings();
        public string AppDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

        public NotificationManager NotificationManager;
        public bool loaded_mods = false;
        public bool Is_Focused = true;
        // public List<string> Current_Installed_Mods = new List<string>();
        public HashSet<GENERAL_MOD> Current_Installed_Mods = new HashSet<GENERAL_MOD>();
        public bool Page_reset_ = false;
        bool failed_folder = false;
        public bool minimize_to_tray = false;
        public DownloadQueue _downloadQueue;

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        // Copied from dwmapi.h


        public class GENERAL_MOD
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string Author { get; set; }
        }


            public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        // Copied from dwmapi.h
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
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

                }
                return "1.0.0";

            }
        }
        private void UserInterfaceCustomScale(double customScale)
        {
            // Change scale of window content

            ScaleTransform dpiTransform = new ScaleTransform(1.5, 1.5);

            this.LayoutTransform = dpiTransform;

        }
        public MainWindow()
        {
            InitializeComponent();

            try
            {

                //win 10
                if (Environment.OSVersion.Platform == PlatformID.Win32NT && (Environment.OSVersion.Version.Build < 22000) ){

                    Main_Win_Control.AllowsTransparency = true;
                    Main_Win_Control.WindowStyle = WindowStyle.None;
                    Main_Win_Control.BorderThickness = new Thickness(0);
                }
                else
                //win 11
                {
                    IntPtr hWnd = new WindowInteropHelper(GetWindow(this)).EnsureHandle();
                    var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
                    var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
                    DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));
                    Main_Win_Control.BorderThickness = new Thickness(1);

                }


                NotificationManager = new NotificationManager();
                minimize_to_tray = Properties.Settings.Default.Minimize_to_Tray;
                Profile_TAG.Content = Properties.Settings.Default.Profile_Name;

                if (!File.Exists(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json"))
                {
                    string DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (Directory.Exists(DocumentsFolder) && Directory.Exists(AppDataFolder))
                    {
                        if (!Directory.Exists(AppDataFolder + @"\VTOL_DATA\Settings"))

                        {
                            TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\Settings");

                        }

                        if (File.Exists(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json") && !File.Exists(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json"))
                        {
                            TryCopyFile(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json", AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json");

                            if (File.Exists(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json"))
                            {
                                TryDeleteDirectory(DocumentsFolder + @"\VTOL_DATA\", true);

                            }
                        }
                    }
                }
                if (User_Settings_Vars == null)
                {

                    User_Settings_Vars = new User_Settings();
                }
                if (Directory.Exists(AppDataFolder))
                {

                    if (!File.Exists(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json"))
                    {
                        TryCreateDirectory(AppDataFolder + @"\VTOL_DATA\Settings");
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

                        using (var StreamWriter = new StreamWriter(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json", true))
                        {
                            StreamWriter.WriteLine(User_Settings_Json_String.ToString());
                            StreamWriter.Close();
                        }
                        User_Settings_Vars = User_Settings.FromJson(User_Settings_Json_String);
                    }
                    else
                    {
                        string User_Settings_String = File.ReadAllText(AppDataFolder + @"\VTOL_DATA\Settings\User_Settings.Json");

                        User_Settings_Vars = User_Settings.FromJson(User_Settings_String);



                    }

                }
                else
                {
                    failed_folder = true;
                    Send_Danger_Notif(VTOL.Resources.Languages.Language.VTOLSYSTEMSFAILEDTOFINDYOURAPPDATAFOLDERLOCATEASAVEDATAFOLDER, 10000);
                    var folderDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    // Show the FolderBrowserDialog.  
                    var result = folderDlg.ShowDialog();
                    if (result == true)
                    {
                        string path = folderDlg.SelectedPath;
                        if (path == null || !Directory.Exists(path))
                        {
                            Send_Caution_Notif("INVALID FOLDER");
                        }
                        else
                        {
                            Properties.Settings.Default.BACKUP_SAVE_DEST = path + @"\";
                            Properties.Settings.Default.Save();
                            Send_Info_Notif(VTOL.Resources.Languages.Language.RESTARTINGTOSETHARDVALUES);
                            Restart();
                        }
                    }




                }
                if (failed_folder == true)
                {
                    AppDataFolder = Properties.Settings.Default.BACKUP_SAVE_DEST;


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

                    Send_Danger_Notif(VTOL.Resources.Languages.Language.CouldNotReadUserSettingsPleaseRunAsAdminOrRepairCleanYourInstallation, 10000);

                }//todo update tools

                Wpf.Ui.Appearance.Theme.Apply(
            Wpf.Ui.Appearance.ThemeType.Unknown,
  // Theme type
  Wpf.Ui.Appearance.BackgroundType.None, // Background type
  true                                  // Whether to change accents automatically
);



                VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";

                if (IsAdministrator())
                {
                    Admin_Label.Visibility = Visibility.Visible;
                }
                else
                {

                    Admin_Label.Visibility = Visibility.Hidden;

                }
               // UserInterfaceCustomScale(1.5);
                Check_For_New_Update(true);

            }


            catch (Exception ex)
            {

                Console.WriteLine(ex+ $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }





        }
        Cursor LeadWall, Ronin;
        public void SwitchCursor(string cur)
        {
            string CursorDir = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).FullName + @"\Resources\Cursors\";
            LeadWall = new Cursor(CursorDir + "Leadwallcur.cur");
            Ronin = new Cursor(CursorDir + "NormalCurTf2.cur");
            if(Ronin == null || LeadWall == null) {
                return;
            }
            switch (cur)
            {
                case "Default":
                    this.Cursor = null;

                    break;
                case "LeadWall":
                    this.Cursor = LeadWall;

                    break;
                case "Ronin":
                    this.Cursor = Ronin;

                    break;
                default:
                    this.Cursor = null;
                    break;
            }
        }
        void Restart()
        {



            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();

        }
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
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
            Snackbar.Show(VTOL.Resources.Languages.Language.INFO, Input_Message, Wpf.Ui.Common.SymbolRegular.Info24);


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
            this.Opacity = 1;
            this.Opacity = 100;

        }
        public void Maximize()
        {
            this.WindowState = WindowState.Maximized;
            this.Opacity = 100;

        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 100;

            this.WindowState = WindowState.Minimized;
            this.Opacity = 100;

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


                    string pattern = "*.dmp";
                    var dirInfo = new DirectoryInfo(path);
                    var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).FirstOrDefault();
                    string p = file.FullName;
                    string args = string.Format("/e, /select, \"{0}\"", p);

                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "explorer";
                    info.Arguments = args;
                    Process.Start(info);
                    Properties.Settings.Default.LOG_Folder_Counter = Directory.GetFiles(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\logs\").Where(s => s.EndsWith(".dmp")).Count();
                    Properties.Settings.Default.Save();

                    Log_Folder_warning.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }

        private void Main_Win_Control_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Win_Control_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Main_Win_Control_Deactivated(object sender, EventArgs e)
        {
            Is_Focused = false;
        }


        private void Main_Win_Control_Activated(object sender, EventArgs e)
        {
            Is_Focused = true;

        }
        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        async Task OPEN_WEBPAGE(string URL)
        {
            await Task.Run(() =>
            {
                DispatchIfNecessary(async () =>
                {
                    Snackbar.Message = VTOL.Resources.Languages.Language.Page_Skins_OPEN_WEBPAGE_OpeningTheFollowingURL + URL;
                    Snackbar.Title = VTOL.Resources.Languages.Language.INFO;
                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    Snackbar.Show();
                });

                Thread.Sleep(1000);
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = URL,
                    UseShellExecute = true
                });
            });
        }
        private void NORTHSTAR_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            if (Northstar_Dialog.Visibility == Visibility.Visible)
            {

                Northstar_Dialog.Visibility = Visibility.Collapsed;

            }
            else
            {
                Northstar_Dialog.Visibility = Visibility.Visible;
            }

        }

        private void Changelog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = @"https://github.com/R2Northstar/Northstar/releases/tag/v" + NORTHSTAR_BUTTON.Content.ToString().Replace("Northstar Version", "").Replace("-", "").Trim().Replace(" ", "");

                OPEN_WEBPAGE(url);

            }


            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }
        }

        private void Troubleshoot_Click(object sender, RoutedEventArgs e)
        {

            OPEN_WEBPAGE("https://r2northstar.gitbook.io/r2northstar-wiki/installing-northstar/troubleshooting");
        }

        private void Close_Dialog_Click(object sender, RoutedEventArgs e)
        {
            Northstar_Dialog.Opacity = 0;

            Northstar_Dialog.Visibility = Visibility.Collapsed;
        }

        private void Northstar_Dialog_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Northstar_Dialog.Opacity < 1)
            {
                DoubleAnimation da = new DoubleAnimation
                {
                    From = Northstar_Dialog.Opacity,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                    AutoReverse = false
                };
                Northstar_Dialog.BeginAnimation(OpacityProperty, da);

            }
            else
            {

                if (Northstar_Dialog.Opacity == 1)
                {
                    DoubleAnimation da = new DoubleAnimation
                    {
                        From = Northstar_Dialog.Opacity,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                        AutoReverse = false
                    };
                    Northstar_Dialog.BeginAnimation(OpacityProperty, da);

                }
            }

        }

        private void RootNavigation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RootNavigation_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void RootNavigation_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Northstar_Dialog_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Northstar_Dialog_LostMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuickLaunch_Click(object sender, RoutedEventArgs e)
        {
            Page_Home Home = new Pages.Page_Home();
            Home.Launch_Northstar_();
        }

        private void Tools__Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsVisible)
            {
                this.Show();
            }

            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }

            this.Activate();
            this.Topmost = true;  // important
            this.Topmost = false; // important
            this.Focus();         // important
            RootNavigation.Navigate(typeof(Pages.Page_Tools));

        }

        private void Thunderstore_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsVisible)
            {
                this.Show();
            }

            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }

            this.Activate();
            this.Topmost = true;  // important
            this.Topmost = false; // important
            this.Focus();         // important
            RootNavigation.Navigate(typeof(Pages.Page_Thunderstore));

        }

        private void RestartNorthstar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenMods_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsVisible)
            {
                this.Show();
            }

            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }

            this.Activate();
            this.Topmost = true;  // important
            this.Topmost = false; // important
            this.Focus();         // important
            RootNavigation.Navigate(typeof(Pages.Page_Mods));

        }

        private void OpenHome_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsVisible)
            {
                this.Show();
            }

            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }

            this.Activate();
            this.Topmost = true;  // important
            this.Topmost = false; // important
            this.Focus();         // important
            RootNavigation.Navigate(typeof(Pages.Page_Home));

        }

        private void Main_Win_Control_Closed(object sender, EventArgs e)
        {

        }

        private void Main_Win_Control_StateChanged(object sender, EventArgs e)
        {

            try
            {
                if (minimize_to_tray == true)
                {


                    if (this.WindowState == WindowState.Minimized)
                    {
                        this.ShowInTaskbar = false;
                    }
                    else
                    {
                        this.ShowInTaskbar = true;

                    }
                }
                else
                {
                    this.ShowInTaskbar = true;



                }


            }

            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");




            }


        }

        private void Reload__Click(object sender, RoutedEventArgs e)
        {

            Restart();

        }
      public  bool Check_For_New_Update(bool fastcheck_ = false)
        {
            try
            {

                var thisApp = Assembly.GetExecutingAssembly();
                AssemblyName name = new AssemblyName(thisApp.FullName);
                Updater Update = new Updater("BigSpice", "VTOL");

                if (fastcheck_) {
                    string Header = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../"));

                    string updaterModulePath = Path.Combine(Header, "VTOL_Updater.exe");

                    if (File.Exists(updaterModulePath))
                    {
                        Process process = Process.Start(updaterModulePath, "/justcheck");
                        process.WaitForExit();

                        if (process.ExitCode == 0)
                        {
                            VTOL_UPDATE_BADGE.Visibility = Visibility.Visible;
                            process.Close();
                            Snackbar.Message = VTOL.Resources.Languages.Language.UpdateAvailablePleaseCheckAndDownloadTheLatestRelease;
                            Snackbar.Title = VTOL.Resources.Languages.Language.APPLICATIONUPDATEISAVAILABLE;
                            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                            Snackbar.Timeout = 10000;
                            Snackbar.Show();
                            return true;

                        }
                        else
                        {
                            VTOL_UPDATE_BADGE.Visibility = Visibility.Hidden;
                            process.Close();
                            return false;

                        }



                    }
                }
                if (Update.CheckForUpdate())
                {
                    VTOL_UPDATE_BADGE.Visibility = Visibility.Visible;

                    Snackbar.Message = VTOL.Resources.Languages.Language.UpdateAvailablePleaseCheckAndDownloadTheLatestRelease;
                    Snackbar.Title = VTOL.Resources.Languages.Language.APPLICATIONUPDATEISAVAILABLE;
                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    Snackbar.Timeout = 10000;
                    Snackbar.Show();

                    return true;

                }
                else
                {
                    VTOL_UPDATE_BADGE.Visibility = Visibility.Hidden;

                    return false;
                   
                }

                return false;


            }
            catch (Exception ex)
            {


            }

            return false;


        }
        private void Main_Win_Control_Loaded(object sender, RoutedEventArgs e)
        {
            var geometry = new RectangleGeometry();
            geometry.Rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            geometry.RadiusX = 7;
            geometry.RadiusY = 7;
            this.Clip = geometry;
        }

        private void Main_Win_Control_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Action_Center_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }

        private void Action_Center_Progress_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Action_Center_Progress_Checked(object sender, RoutedEventArgs e)
        {



            if (Action_Center_Panel.Opacity < 1)
            {

                DoubleAnimation da = new DoubleAnimation
                {
                    From = Action_Center_Panel.Opacity,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(0.3)),
                    AutoReverse = false
                };
                Action_Center_Panel.BeginAnimation(OpacityProperty, da);
                Action_Center_Panel.Visibility = Visibility.Visible;
                Action_Center_Panel.IsHitTestVisible = true;
            }
        }

        private void Action_Center_Progress_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Action_Center_Panel.Opacity > 0.2)
            {
                DoubleAnimation da = new DoubleAnimation
                {
                    From = Action_Center_Panel.Opacity,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                    AutoReverse = false
                };
                Action_Center_Panel.BeginAnimation(OpacityProperty, da);
                Action_Center_Panel.Visibility = Visibility.Collapsed;
                Action_Center_Panel.IsHitTestVisible = false;

            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DispatchIfNecessary(async () =>
                {
                    Wpf.Ui.Controls.Button Button;
                    Button = sender as Wpf.Ui.Controls.Button;



                        if (_downloadQueue != null)
                        {
                           _downloadQueue.CancelDownload(Button.Tag.ToString());
                        }
                    
                });
            }
            catch (Exception ex)
            {


            }
        }

        private void Cancel_Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Cancel_Button_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Action_Center_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Action_Center_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void SymbolIcon_LayoutUpdated(object sender, EventArgs e)
        {


        }

        private void SymbolIcon_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DispatchIfNecessary(async () =>
                {
                    Button Button;
                    Button = sender as Button;


                  //  RootNavigation.Navigate(typeof(Pages.Page_Thunderstore));

                  //  Page_Thunderstore Page = RootFrame.Content as Page_Thunderstore;
                   

                        if (_downloadQueue != null)
                        {
                            _downloadQueue.CancelDownload("", true);
                        }
                    
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }
    }
}
