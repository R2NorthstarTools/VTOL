﻿using Downloader;
using FuzzyString;
using Lsj.Util.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reactive.Joins;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Linq;
using Threading;
using VTOL.Titanfall2_Requisite.WeaponData.Default.AntiTitan;
using Windows.Foundation.Collections;
using static VTOL.MainWindow;
using static VTOL.Pages.Page_Mods;
using static VTOL.Pages.Page_Thunderstore;
using Path = System.IO.Path;
using Timer = System.Timers.Timer;
using ZipFile = Ionic.Zip.ZipFile;

namespace VTOL.Pages
{
    class CustomStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y);
        }
        public int GetHashCode(string s)
        {
            return string.IsNullOrEmpty(s) ? 0 :
                s.Length + 273133 * (int)s[0];
        }
        private CustomStringComparer() { }
        public static readonly CustomStringComparer Default
            = new CustomStringComparer();
    }
    public static class DependencyObjectExtensions
    {
        public static T FirstOrDefaultChild<T>(this DependencyObject parent, Func<T, bool> selector)
            where T : DependencyObject
        {
            T foundChild;
            return FirstOrDefaultVisualChildWhere(parent, selector, out foundChild) ? foundChild : default(T);
        }

        private static bool FirstOrDefaultVisualChildWhere<T>(DependencyObject parent, Func<T, bool> selector,
            out T foundChild) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var tChild = child as T;
                if (tChild != null)
                {
                    if (!selector(tChild)) continue;
                    foundChild = tChild;
                    return true;
                }

                if (FirstOrDefaultVisualChildWhere(child, selector, out foundChild))
                {
                    return true;
                }
            }
            foundChild = default(T);
            return false;
        }
    }
    public class Skin_Processor_
    {

        private MainWindow Main = GetMainWindow();

        private List<string> Skin_List = new List<string>();
        private Wpf.Ui.Controls.Snackbar SnackBar;
        private List<string> names = new List<string>();
        User_Settings User_Settings_Vars = null;
        public static bool ZipHasFile(string Search, string zipFullPath)
        {
            ZipFile zipFile = new ZipFile(zipFullPath);


            foreach (var entry in zipFile.Entries)
            {
                if (entry.FileName.Contains(Search, StringComparison.OrdinalIgnoreCase))
                {

                    return true;
                }
            }

            return false;
        }

        private int ImageCheck(String ImageName)
        {
            int result = -1;
            int temp = ImageName.LastIndexOf("\\");
            ImageName = ImageName.Substring(0, temp);
            temp = ImageName.LastIndexOf("\\") + 1;
            ImageName = ImageName.Substring(temp, ImageName.Length - temp);
            switch (ImageName)
            {
                case "256x128":
                case "256x256":
                case "256":
                    //Big change,I don't want to do it:(
                    break;
                case "512x256":
                case "512x512":
                case "512":
                    result = 0;
                    break;
                case "1024x512":
                case "1024x1024":
                case "1024":
                    result = 1;
                    break;
                case "2048x1024":
                case "2048x2048":
                case "2048":
                    result = 2;
                    break;
                case "4096x2048":
                case "4096x4096":
                case "4096":
                    result = 3;
                    break;
                default:
                    result = -1;
                    break;
            }
            return result;
        }

        private bool IsPilot(string Name)
        {
            if (Name.Contains("Stim_") || Name.Contains("PhaseShift_") || Name.Contains("HoloPilot_") || Name.Contains("PulseBlade_") || Name.Contains("Grapple_") || Name.Contains("AWall_") || Name.Contains("Cloak_") || Name.Contains("Public_"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        string current_skin_folder = null;
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
                catch (IOException ex)
                {    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");Thread.Sleep(millisecondsDelay);
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
                catch (IOException ex)
                {    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");Thread.Sleep(millisecondsDelay);
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
                catch (IOException ex)
                {    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");Thread.Sleep(millisecondsDelay);
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
        public void Install_Skin_From_Path(string Zip_Path)
        {

            try
            {
                User_Settings_Vars = Main.User_Settings_Vars;
                SnackBar = Main.Snackbar;
                if (ZipHasFile(".dds", Zip_Path))
                {


                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR"))
                    {

                        current_skin_folder = User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR";

                        TryUnzipFile(Zip_Path, User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR");

                        //Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";

                    }
                    else
                    {

                        TryCreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR");
                        current_skin_folder = User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR";


                        TryUnzipFile(Zip_Path, User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR");

                    }
                }
                else
                {
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SKIN_INCOMPATIBLE"));
                    Log.Error("Issue With Skin Install!");


                }




                //Block Taken From Skin Tool
                List<string> FileList = new List<string>();
                if (current_skin_folder != null)
                {
                    FindSkinFiles(current_skin_folder, FileList, ".dds");

                }
                else
                {
                    Log.Error("Issue With Skin Install!");

                    return;
                }



                var matchingvalues = FileList.FirstOrDefault(stringToCheck => stringToCheck.Contains(""));
                for (int i = 0; i < FileList.Count; i++)
                {
                    if (FileList[i].Contains("col")) // (you use the word "contains". either equals or indexof might be appropriate)
                    {

                    }
                }
                int DDSFolderExist = 0;

                DDSFolderExist = FileList.Count;
                if (DDSFolderExist == 0)
                {
                    Log.Error("Could Not Find Skins in Zip??");
                }

                foreach (var i in FileList)
                {
                    int FolderLength = current_skin_folder.Length;
                    String FileString = i.Substring(FolderLength);
                    int imagecheck = ImageCheck(i);
                    //the following code is waiting for the custom model
                    Int64 toseek = 0;
                    int tolength = 0;
                    int totype = 0;
                    switch (GetTextureType(i))
                    {
                        case 1://Weapon
                               //Need to recode weapon part

                            VTOL.Titanfall2_Requisite.WeaponData.WeaponDataControl wdc = new VTOL.Titanfall2_Requisite.WeaponData.WeaponDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(wdc.FilePath[0, 1]);
                            tolength = Convert.ToInt32(wdc.FilePath[0, 2]);
                            totype = Convert.ToInt32(wdc.FilePath[0, 3]);


                            break;
                        case 2://Pilot
                            VTOL.Titanfall2_Requisite.PilotDataControl.PilotDataControl pdc = new VTOL.Titanfall2_Requisite.PilotDataControl.PilotDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(pdc.Seek);
                            tolength = Convert.ToInt32(pdc.Length);
                            totype = Convert.ToInt32(pdc.SeekLength);
                            break;
                        case 3://Titan
                            VTOL.Titanfall2_Requisite.TitanDataControl.TitanDataControl tdc = new VTOL.Titanfall2_Requisite.TitanDataControl.TitanDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(tdc.Seek);
                            tolength = Convert.ToInt32(tdc.Length);
                            totype = Convert.ToInt32(tdc.SeekLength);
                            break;

                        default:
                            Log.Error("Issue With Skin Install!");

                            break;
                    }


                    StarpakControl sc = new StarpakControl(i, toseek, tolength, totype, User_Settings_Vars.NorthstarInstallLocation, "Titanfall2", imagecheck, "Replace");


                }

                FileList.Clear();
                DirectoryInfo di = new DirectoryInfo(current_skin_folder);
                FileInfo[] files = di.GetFiles();


                Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                Main.Snackbar.Show("SUCCESS!", VTOL.Resources.Languages.Language.Page_Skins_Install_Skin_From_Path_TheSkin + Path.GetFileNameWithoutExtension(Zip_Path) + VTOL.Resources.Languages.Language.Page_Skins_Install_Skin_From_Path_HasBeenInstalled);

                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir_ in di.GetDirectories())
                {
                    dir_.Delete(true);
                }
                TryDeleteDirectory(current_skin_folder);






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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void FindSkinFiles(string FolderPath, List<string> FileList, string FileExtention)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(FolderPath);
                FileSystemInfo[] fi = di.GetFileSystemInfos();
                foreach (var i in fi)
                {
                    if (i is DirectoryInfo)
                    {
                        FindSkinFiles(i.FullName, FileList, FileExtention);
                    }
                    else
                    {
                        if (i.Extension == FileExtention)
                        {
                            FileList.Add(i.FullName);
                        }
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }




        private static int GetTextureType(string Name)
        {
            if (Name != null && Name.Length == 0)
            {
                return 0;
            }
            if (Name.Contains("Stim_") || Name.Contains("PhaseShift_") || Name.Contains("HoloPilot_")
            || Name.Contains("PulseBlade_") || Name.Contains("Grapple_") || Name.Contains("AWall_")
            || Name.Contains("Cloak_") || Name.Contains("Pilot_"))
            {
                return 2;
            }
            else if (Name.Contains("Titan_"))
            {
                return 3;
            }
            else
            {
                return 1;
            }

        }

        private static MainWindow GetMainWindow()
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


    }
    /// <summary>
    /// Interaction logic for Page_Thunderstore.xaml
    /// </summary>
    /// 
    public class NegatingConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                return -((double)value);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                return +(double)value;
            }
            return value;
        }
    }
    public partial class Page_Thunderstore : Page
    {
        public MainWindow Main = GetMainWindow();
        // Timer set to elapse after 750ms
        private Timer _timer = new Timer(100) { Enabled = false };
        private List<Grid_> itemsList = new List<Grid_>();
        private List<string> ListOfLink = new List<string>();
        Updater _updater;
        User_Settings User_Settings_Vars = null;
        private string DocumentsFolder = null;
        private bool init = false;
        private Wpf.Ui.Controls.Snackbar SnackBar;
        private ProgressBar Progress_Cur_Temp;
        private List<string> Current_Mod_Filter_Tags = null;
        private List<string> Options_List = new List<string>();
        bool do_not_overwrite_Ns_file = true;
        bool page_loaded = false;
        public bool Reverse_ = false;
        bool search_a_flag = false;
        public HashSet<string> Fave_Mods = new HashSet<string>();
        private int Mod_Update_Counter = 0;
        private List<Action_Card> Action_Center = new List<Action_Card>();

        public Page_Thunderstore()
        {
            InitializeComponent();
            Check_Reverse(false);
            InfoChangeEvent += new SomeInfoChangeDelegate(OnInfoChanged);
            User_Settings_Vars = Main.User_Settings_Vars;
            DocumentsFolder = Main.AppDataFolder;
            SnackBar = Main.Snackbar;
            Options_List.Add("Skins");
            Options_List.Add("Mods");
            Options_List.Add("Client-side");
            Options_List.Add("Server-side");
            Options_List.Add("Custom Menus");
            Options_List.Add("Language: EN");
            Options_List.Add("Language: CN");
            Options_List.Add("DDS");
            Options_List.Add("Maps");
            Options_List.Add("Models");

            Search_Filters.ItemsSource = Options_List;
            InitializeDownloadQueue();

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {

                CookFaveMods();
                if (Main.loaded_mods == false) {
                    Call_Mods_From_Folder_Lite();
                }
                Call_Ts_Mods();


            };
            worker.RunWorkerCompleted += (sender, eventArgs) =>
            {
                DispatchIfNecessary(async () =>
                {
                    if (_updater != null)
                    {
                        Couunter_Mods.Content = VTOL.Resources.Languages.Language.ThunderstoreModCount + ":" + _updater.Thunderstore.Count().ToString();

                    }


                    Loading_Ring.Visibility = Visibility.Hidden;
                });
                page_loaded = true;
            };
            worker.RunWorkerAsync();







        }
        // Event handler

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
        //public ObservableCollection<Grid_> ThunderstoreItems
        //{
        //    //get { return thunderstoreItems; }
        //    //set
        //    //{
        //    //    thunderstoreItems = value;
        //    //    OnPropertyChanged(nameof(ThunderstoreItems));
        //    //}
        //}
        public void CookFaveMods()
        {
            try
            {
                string folderPath = DocumentsFolder + @"\VTOL_DATA\ThunderstoreData";
                string filePath = folderPath + @"\MyFavoritedMods.csv";


                if (!Directory.Exists(folderPath))

                {
                    TryCreateDirectory(folderPath);

                }
                if (File.Exists(filePath))
                {
                    Fave_Mods = ReadHSet(filePath);
                }



            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy-MM- dd-HH-mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
    where childItem : DependencyObject
        {

            try
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is childItem)
                    {
                        return (childItem)child;
                    }
                    else
                    {
                        childItem childOfChild = FindVisualChild<childItem>(child);
                        if (childOfChild != null)
                            return childOfChild;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
            return null;

        }
        private void Ts_Image_GotFocus(object sender, RoutedEventArgs e)
        {


        }

        private void Ts_Image_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Ts_Image_MouseEnter(object sender, MouseEventArgs e)
        {


        }

        private void mask_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {


                DispatchIfNecessary(async () =>
                {

                    ContentPresenter myListBoxItem = (ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
                    Grid gridPanel = FindVisualChild<Grid>(myListBoxItem);

                    DoubleAnimation animation = new DoubleAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                        AutoReverse = false
                    };

                    if (gridPanel.Opacity >= 1)
                    {
                        animation.From = gridPanel.Opacity;
                        animation.To = 0;
                        gridPanel.BeginAnimation(OpacityProperty, animation);
                        gridPanel.IsEnabled = false;
                    }
                    else
                    {
                        animation.From = gridPanel.Opacity;
                        animation.To = 1;
                        gridPanel.BeginAnimation(OpacityProperty, animation);
                        gridPanel.IsEnabled = true;
                    }


                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
        }
        public async Task<bool> SaveHSetAsync()
        {
            try
            {
                string folderPath = DocumentsFolder + @"\VTOL_DATA\ThunderstoreData";
                string filePath = folderPath + @"\MyFavoritedMods.csv";

                HashSet<string> existingMods = new HashSet<string>();



                // Combine the existing and new mods into a single set and remove duplicates
                HashSet<string> allMods = new HashSet<string>(Fave_Mods);

                if (allMods.Count > 0)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {

                        // Write only the new mods to the file if it already exists
                        foreach (string Modname in allMods)
                        {
                            try { 
                            await writer.WriteLineAsync(Modname);
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
                    return true;
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        await writer.WriteAsync(string.Empty);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                return false;

            }
            return true;

        }

        public HashSet<string> ReadHSet(string filePath, bool checkexisting = false)
        {
            HashSet<string> result = new HashSet<string>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The file could not be found.", filePath);
                    return result;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            result.Add(line);
                        }
                    }
                }
                if (checkexisting)
                {
                    // Remove duplicate lines
                    result.RemoveWhere(string.IsNullOrWhiteSpace);
                }
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, $"File does not exist {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                //Removed PaperTrailSystem Due to lack of reliability.
                return result;
            }
            catch (IOException ex)
            {
                Log.Error(ex, $"Error reading file {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                //Removed PaperTrailSystem Due to lack of reliability.
                return result;
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");return result;

            }

            return result;
        }
        private void mask_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                DispatchIfNecessary(async () =>
                {
                    ContentPresenter myListBoxItem = (ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
                    Grid GridPanel_ = FindVisualChild<Grid>(myListBoxItem);
                    bool mouseIsDown = System.Windows.Input.Mouse.RightButton == MouseButtonState.Pressed;

                    if (mouseIsDown)
                    {
                        DoubleAnimation da = new DoubleAnimation
                        {
                            Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                            AutoReverse = false
                        };

                        if (GridPanel_.Opacity >= 1)
                        {
                            da.From = GridPanel_.Opacity;
                            da.To = 0;
                            GridPanel_.BeginAnimation(OpacityProperty, da);
                            GridPanel_.IsEnabled = false;
                        }
                        else
                        {
                            da.From = GridPanel_.Opacity;
                            da.To = 1;
                            GridPanel_.BeginAnimation(OpacityProperty, da);
                            GridPanel_.IsEnabled = true;
                        }
                    }
                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }

        private void CardExpander_MouseLeftGrid_Down(object sender, MouseButton e)
        {
            //if (sender.GetType() == typeof(Wpf.Ui.Controls.CardExpander))
            //{
            //    Wpf.Ui.Controls.CardExpander ss = new Wpf.Ui.Controls.CardExpander();
            //    ss = sender as Wpf.Ui.Controls.CardExpander;
            //       var item = Final_List.FirstOrDefault(o => o == ss.Header);
            //    if (item != null)
            //        Thunderstore_List.ScrollIntoView(item.First());
            //}
        }



        private void StackPanel_GotFocus(object sender, MouseEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {
                Grid Card;
                if (sender.GetType() == typeof(Grid))
                {
                    Card = sender as Grid;

                    HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);
                    Wpf.Ui.Controls.CardAction Card_Action = FindVisualChild<Wpf.Ui.Controls.CardAction>(Card);

                    if (Card != null && GridPanel_ != null && Card_Action != null)
                    {

                        string tooltip_string = (Card_Action.ToolTip.ToString().Replace("northstar-Northstar", "").Replace("ebkr-r2modman-", "")).Trim();

                        if (tooltip_string.Count() < 5 && tooltip_string.Length < 5 && Card_Action.ToolTip.ToString().Length < 5)
                        {

                            foreach (var storyboard in Card_Action.Resources.Values.OfType<Storyboard>())
                            {
                                storyboard.Stop();
                            }
                            Card_Action.IsEnabled = false;
                            Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultiple20;
                            Card_Action.Refresh();
                        }

                    }



                }
            });

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {

                Grid Card;
                if (sender.GetType() == typeof(Grid))
                {

                    //                ContentPresenter myListBoxItem =
                    //(ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
                    Card = sender as Grid;
                    HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);
                    Wpf.Ui.Controls.CardAction Card_Action = FindVisualChild<Wpf.Ui.Controls.CardAction>(Card);
                    if (Card_Action != null && GridPanel_ != null)
                    {
                        if (GridPanel_.Opacity < 0.2)
                        {


                            string tooltip_string = Card_Action.ToolTip.ToString().Replace("northstar-Northstar", "").Replace("ebkr-r2modman-", "");

                            if (tooltip_string.Count() > 5 && tooltip_string.Length > 5)
                            {
                                Card_Action.IsEnabled = true;
                                Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultipleCheckmark20;
                                Card_Action.IconForeground = Brushes.LawnGreen;
                                SlowBlink(Card_Action, 0.3);
                            }
                            else

                            {

                                DoubleAnimation x = new DoubleAnimation
                                {

                                };
                                Card_Action.BeginAnimation(OpacityProperty, x);

                                Card_Action.IsEnabled = false;
                                Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultiple20;

                            }
                            //  Check_Update_Tag(GridPanel_);
                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = GridPanel_.Opacity,
                                To = 1,
                                Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                AutoReverse = false
                            };
                            GridPanel_.BeginAnimation(OpacityProperty, da);
                            GridPanel_.IsEnabled = true;
                        }


                    }


                }
            });
        }
        private void Search_Bar_Suggest_Mods_GotFocus(object sender, RoutedEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {

                Search_Bar_Suggest_Mods.IsReadOnly = false;

                Sort.SelectedIndex = -1;
                Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
                // Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
                search_a_flag = false;
            });
        }

        private void Search_Bar_Suggest_Mods_LostFocus(object sender, RoutedEventArgs e)
        {
            old_text = Search_Bar_Suggest_Mods.Text;
            DispatchIfNecessary(async () =>
            {
                Search_Bar_Suggest_Mods.IsReadOnly = true;
                search_a_flag = true;
                Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
                // Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
            });
        }
        string old_text = "";

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {
                Grid Card;
                if (sender.GetType() == typeof(Grid))
                {
                    Card = sender as Grid;

                    HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);

                    if (Card != null && GridPanel_ != null)
                    {
                        if (GridPanel_.Opacity > 0)
                        {

                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = GridPanel_.Opacity,
                                To = 0,
                                Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                AutoReverse = false
                            };
                            GridPanel_.BeginAnimation(OpacityProperty, da);
                            GridPanel_.IsEnabled = false;



                        }
                    }



                }
            });
        }



        public delegate void SomeInfoChangeDelegate(object o);
        public event SomeInfoChangeDelegate InfoChangeEvent = null;
        void OnInfoChanged(object o)
        {
            DispatchIfNecessary(async () =>
            {
               // itemsList = Thunderstore_List.Items.Cast<Grid_>().ToList();
                  Reload_BTTN.Visibility = Visibility.Collapsed;
                Loading_Ring.Visibility = Visibility.Hidden;
                Thunderstore_List.Items.Refresh();
            });
        }
        protected void SomeWorkerThread(object o)
        {


            foreach (var TS_MOD in _updater.Thunderstore)
            {
                try { 
                AsyncLoadListViewItem(TS_MOD, false, "#");
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
        public async Task Call_Ts_Mods()
        {



            try
            {


                List<Grid_> List = null;
                _updater = new Updater("https://northstar.thunderstore.io/api/v1/package/");
                _updater.Download_Cutom_JSON_();
                if (_updater.Thunderstore != null)
                {
                    if (_updater.Thunderstore.Count() > 0)
                    {
                        DispatchIfNecessary(async () =>
                        {
                            itemsList.Clear();
                            Thunderstore_List.Items.Clear();
                            Thread t = new Thread(new ParameterizedThreadStart(SomeWorkerThread));
                            t.Start();


                        });


                    }
                    DispatchIfNecessary(async () =>
                    {
                        Thunderstore_List.Items.Refresh();
                    });
                }


                init = true;




            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }
        static int versionCompare(string v1, string v2)
        {
            // vnum stores each numeric

            // part of version

            int vnum1 = 0, vnum2 = 0;
            if (v1 == null || v2 == null) { return 3; }
            // loop until both string are
            // processed

            for (int i = 0, j = 0; (i < v1.Length || j < v2.Length);)

            {
                // storing numeric part of
                // version 1 in vnum1
                while (i < v1.Length && v1[i] != '.')
                {

                    vnum1 = vnum1 * 10 + (v1[i] - '0');

                    i++;
                }
                // storing numeric part of

                // version 2 in vnum2

                while (j < v2.Length && v2[j] != '.')
                {
                    vnum2 = vnum2 * 10 + (v2[j] - '0');
                    j++;
                }
                if (vnum1 > vnum2)
                    return 1;

                if (vnum2 > vnum1)
                    return -1;

                // if equal, reset variables and

                // go for next numeric part
                vnum1 = vnum2 = 0;
                i++;
                j++;
            }

            return 0;

        }
        private static Boolean findString(String baseString, String strinfToFind, String separator)
        {
            foreach (String str in baseString.Split(separator.ToCharArray()))
            {
                if (str.Equals(strinfToFind))
                {
                    return true;
                }
            }
            return false;
        }

        private void Compare_Mod_To_List(string modname, string Mod_version_current, HashSet<GENERAL_MOD> list, out string bg_color, out string label)
        {
            string res = "Install";
            string bg = "#FF005D42";
            int is_favourite_ = 0;
            try
            {


                if (list.Count() > 2)
                {


                    bool Northstar_flagged = false;
                    foreach (var item in list)
                    {
                        try { 
                        if (modname.Equals(@"Northstar") && Northstar_flagged == false)
                        {
                            if (String.Equals(item.Name.Split(".")[0], modname, StringComparison.OrdinalIgnoreCase))
                            {
                                string version = item.Version;
                                int result = versionCompare(version, Mod_version_current);
                                switch (result)
                                {
                                    case 1:
                                        res = "Re-Install";
                                        bg = "#FFAD7F1A";
                                        break;
                                    case -1:
                                        res = "Update";
                                        bg = "#FF009817";

                                        break;
                                    case 0:
                                        res = "Re-Install";
                                        bg = "#FFAD7F1A";

                                        break;
                                    default:
                                        res = "Install";
                                        bg = "#FF005D42";

                                        break;
                                }
                                label = res;
                                bg_color = bg;
                                Northstar_flagged = true;
                            }
                        }
                        if (String.Equals(item.Name, modname, StringComparison.OrdinalIgnoreCase))
                        {
                            string version = item.Version;
                            int result = versionCompare(version, Mod_version_current);
                            switch (result)
                            {
                                case 1:
                                    res = "Re-Install";
                                    bg = "#FFAD7F1A";
                                    break;
                                case -1:
                                    res = "Update";
                                    bg = "#FF009817";

                                    break;
                                case 0:
                                    res = "Re-Install";
                                    bg = "#FFAD7F1A";

                                    break;
                                default:
                                    res = "Install";
                                    bg = "#FF005D42";

                                    break;
                            }
                            label = res;
                            bg_color = bg;

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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}


            label = res;
            bg_color = bg;


        }

        public static bool ContainsAny(string stringToTest, List<string> substrings)
        {
            if (string.IsNullOrEmpty(stringToTest) || substrings == null)
                return false;

            foreach (var substring in substrings)
            {
                if (stringToTest.Contains(substring, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        private void padd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Check_Reverse();


                if (Sort.SelectedItem != null)
                {
                    //  Thunderstore_List.ItemsSource = null;

                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (sender, e) =>
                    {



                        //Call_Ts_Mods();

                        if (_updater.Thunderstore != null)
                        {
                            if (_updater.Thunderstore.Count() > 0)
                            {
                                DispatchIfNecessary(async () =>
                                {
                                    Thunderstore_List.Items.Clear();

                                    orderlistitems();
                                });
                            }
                        }


                    };
                    worker.RunWorkerCompleted += (sender, eventArgs) =>
                    {

                        //  Thunderstore_List.Items.Refresh();


                    };
                    worker.RunWorkerAsync();
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }
        void Check_Reverse(bool Apply_Change = true)
        {
            try
            {
                DispatchIfNecessary(async () =>
                {
                    if (Apply_Change == true)
                    {
                        if (Reverse_ == true)
                        {
                            Reverse_ = false;

                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#07FFFFFF");

                        }
                        else
                        {

                            Reverse_ = true;
                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4CAF50");

                        }
                    }
                    else
                    {
                        if (Reverse_ == true)
                        {
                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4CAF50");


                        }
                        else
                        {
                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#07FFFFFF");


                        }

                    }
                });
            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }

        public async Task<bool> TryDeleteDirectory(string directoryPath, bool overwrite = true,
                int maxRetries = 10, int millisecondsDelay = 30)
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
                        string[] files = Directory.GetFiles(directoryPath);
                        string[] dirs = Directory.GetDirectories(directoryPath);

                        foreach (string file in files)
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            File.Delete(file);
                        }

                        foreach (string dir in dirs)
                        {
                            await TryDeleteDirectory(dir);
                        }

                        Directory.Delete(directoryPath, false);
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
        public async Task<bool> TryCreateDirectory(
   string directoryPath,
   int maxRetries = 10,
   int millisecondsDelay = 30)
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

        public async Task<bool> TryMoveFile(
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
        public async Task<bool> TryMoveFolder(
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
                    if (Directory.Exists(Origin))
                    {
                        Directory.Move(Origin, Destination);
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
        public async Task<bool> TryCopyFile(
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
                    Thread.Sleep(2);

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

        public void orderlistitems()
        {
            Thunderstore_List.Items.Clear();

            List<Grid_> List = itemsList;
            if (Sort.SelectedItem != null && List != null)
            {
                string value = Convert.ToString(Sort.SelectedValue);

                if (Reverse_ == true)
                {
                    switch (value)
                    {
                        case "Name":
                            List = List.OrderByDescending(ob => ob.Name).ToList();

                            break;
                        case "Rating":
                            List = List.OrderBy(ob => ob.Rating).ToList();

                            break;

                        case "Date":
                            List = List.OrderBy(ob => Convert.ToDateTime(ob.raw_date)).ToList();

                            break;
                        case "File Size":
                            List = List.OrderBy(ob => Convert.ToInt32(ob.raw_size)).ToList();

                            break;
                        case "Downloads":
                            List = List.OrderBy(ob => Convert.ToInt32(ob.Downloads)).ToList();

                            break;

                        case "Installed":
                            List = List.Where(item => item.Button_label.ToString().Equals("Re-Install")).OrderByDescending(ob => ob.Name).ToList();

                            break;
                        case "Updates":
                            List = List.Where(item => item.Button_label.ToString().Equals("Update")).OrderByDescending(ob => ob.Name).ToList();
                            if (List.Count == 0)
                            {
                                DispatchIfNecessary(async () =>
                                {

                                    Mod_Updates_Available.Visibility = Visibility.Hidden;
                                    Mod_Update_Counter = 0;
                                });
                            }
                            break;
                        case "Favourites":
                            List = List.Where(item => item.is_Favourite_.ToString().Equals("1")).OrderByDescending(ob => ob.Name).ToList();
                            Main.Page_reset_ = true;

                            break;
                        case "...":
                            Main.Page_reset_ = true;

                            break;
                        default:
                            List = itemsList;
                            break;


                    }

                }
                else
                {
                    switch (value)
                    {
                        case "Name":
                            List = List.OrderBy(ob => ob.Name).ToList();

                            break;
                        case "Rating":
                            List = List.OrderByDescending(ob => ob.Rating).ToList();

                            break;

                        case "Date":
                            List = List.OrderByDescending(ob => Convert.ToDateTime(ob.raw_date)).ToList();

                            break;
                        case "File Size":
                            List = List.OrderByDescending(ob => Convert.ToInt32(ob.raw_size)).ToList();

                            break;
                        case "Downloads":
                            List = List.OrderByDescending(ob => Convert.ToInt32(ob.Downloads)).ToList();

                            break;

                        case "Installed":
                            List = List.Where(item => item.Button_label.ToString().Equals("Re-Install")).OrderBy(ob => ob.Name).ToList();

                            break;
                        case "Updates":
                            List = List.Where(item => item.Button_label.ToString().Equals("Update")).OrderBy(ob => ob.Name).ToList();
                            if (List.Count == 0)
                            {
                                DispatchIfNecessary(async () =>
                                {

                                    Mod_Updates_Available.Visibility = Visibility.Hidden;
                                    Mod_Update_Counter = 0;

                                });
                            }
                            break;
                        case "Favourites":
                            List = List.Where(item => item.is_Favourite_.ToString().Equals("1")).OrderBy(ob => ob.Name).ToList();
                            Main.Page_reset_ = true;

                            break;
                        case "...":
                            Main.Page_reset_ = true;

                            break;
                        default:
                            List = itemsList;
                            break;
                    }
                }
            }
            DispatchIfNecessary(async () =>
            {

                foreach (var TS_MOD in List)
                {

                    if (TS_MOD != null)
                    {
                        Thunderstore_List.Items.Add(TS_MOD);

                    }

                }
                DispatchIfNecessary(async () =>
                {
                    Loading_Ring.Visibility = Visibility.Hidden;
                    Thunderstore_List.Items.Refresh();
                });
            });
        }



        private void AsyncLoadListViewItem(Thunderstore_V1 updater, bool Search_ = false, string SearchQuery = "#")
        {
            Grid_ Card = new Grid_();
            string ICON = "";
            List<int> Downloads = new List<int> { };
            List<object> Temp = new List<object> { };
            List<string> Dependencies = new List<string> { };
            string Tags = "";
            string downloads = "";
            string download_url = "";
            string Descrtiption = "";
            string FileSize = "";
            string Exclude_String = "#";
            string Dependencies_ = "";
            string Update_data = "";
            string Button_label = "";
            string MOD_Name = "";

            if (updater.FullName.Contains("r2modman"))
            {
                return;
            }
            if (updater.IsDeprecated == true)
            {
                return;
            }
            int rating = updater.RatingScore;

            Tags = String.Join(" , ", updater.Categories);
            List<versions> versions = updater.versions;
            string[] Split_Name = (versions.First().FullName).Split('-');
            if (Split_Name.Length >= 2)
            {

                MOD_Name = Split_Name[1];
            }
            if (versions.Count <= 0)
            {

                return;
            }

            foreach (var items in versions)
            {

                Downloads.Add(Convert.ToInt32(items.Downloads));

            }
            //if (Current_Mod_Filter_Tags == null)
            //{
            //    Current_Mod_Filter_Tags = new List<string>();
            //}

            if (Current_Mod_Filter_Tags != null)
            {


                if (updater.Categories.Select(x => x).Intersect(Current_Mod_Filter_Tags).Any())
                {
                    if (Search_ == true && SearchQuery != "#")
                    {





                        if (MOD_Name.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) == -1 && updater.Owner.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) == -1)
                        {



                            return;
                        }

                        downloads = (Downloads.Sum()).ToString();

                        for (var x = 0; x < versions.First().Dependencies.Count; x++)
                        {
                            if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("ebkr-r2modman-"))
                            {

                                continue;
                            }
                            else
                            {
                                Dependencies.Add(versions.First().Dependencies[x]);

                            }

                        }

                        Dependencies_ = String.Join(", ", Dependencies);

                        download_url = versions.First().DownloadUrl;
                        ICON = versions.First().Icon;
                        FileSize = versions.First().FileSize.ToString();
                        Descrtiption = versions.First().Description;
                        Downloads.Clear();
                        Dependencies.Clear();


                        string raw_size = versions.First().FileSize.ToString();

                        if (int.TryParse(FileSize, out int value))
                        {
                            FileSize = Convert_To_Size(value);
                        }
                        string bg_color;
                        string label;
                        Compare_Mod_To_List(MOD_Name, versions.First().VersionNumber, Main.Current_Installed_Mods, out bg_color, out label);
                        if (bg_color == null || label == null)
                        {
                            bg_color = "#FF005D42";
                            label = "Install";



                        }
                        if (label == "Update")
                        {
                            Mod_Update_Counter++;
                        }
                        int is_favourite = 0;

                        if (Fave_Mods.Contains(MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber))
                        {
                            is_favourite = 1;
                        }
                        DispatchIfNecessary(async () =>
                        {
                            if (Card != null)
                            {
                                Card = (new Grid_ { NameSpace = Split_Name[0],
                                    Name = MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber,
                                    Icon = ICON,
                                    raw_date = updater.DateCreated.ToString(),
                                    date_created = ConvertDateToString(updater.DateCreated),
                                    description = Descrtiption,
                                    owner = updater.Owner,
                                    Rating = rating,
                                    download_url = download_url + "|" + versions.First().FullName + "|" + Tags + "|" + Dependencies_ + "|" + Split_Name[0],
                                    Webpage = updater.PackageUrl,
                                    File_Size = FileSize,
                                    Tag = Tags,
                                    Downloads = downloads,
                                    Dependencies = Dependencies_,
                                    FullName = versions.First().FullName,
                                    raw_size = raw_size,
                                    Update_data = MOD_Name + "|" + versions.First().VersionNumber, Button_label = label,
                                    Button_Color = bg_color, is_Favourite_ = is_favourite });

                                Thunderstore_List.Items.Add(Card);
                                itemsList.Add(Card);


                            }
                        });
                    }
                    else
                    {
                        downloads = (Downloads.Sum()).ToString();
                        for (var x = 0; x < versions.First().Dependencies.Count; x++)
                        {
                            if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("ebkr-r2modman-"))
                            {

                                continue;
                            }
                            else
                            {
                                Dependencies.Add(versions.First().Dependencies[x]);

                            }

                        }
                        download_url = versions.First().DownloadUrl;
                        ICON = versions.First().Icon;
                        FileSize = versions.First().FileSize.ToString();
                        Descrtiption = versions.First().Description;
                        Dependencies_ = String.Join(", ", Dependencies);
                        Dependencies.Clear();
                        Downloads.Clear();
                        string raw_size = versions.First().FileSize.ToString();
                        if (int.TryParse(FileSize, out int value))
                        {
                            FileSize = Convert_To_Size(value);
                        }
                        string bg_color;
                        string label;
                        int is_favourite = 0;
                        if (Fave_Mods.Contains(MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber))
                        {
                            is_favourite = 1;
                        }
                        Compare_Mod_To_List(MOD_Name, versions.First().VersionNumber, Main.Current_Installed_Mods, out bg_color, out label);
                        if (bg_color == null || label == null)
                        {
                            bg_color = "#FF005D42";
                            label = "Install";
                        }
                        if (label == "Update")
                        {
                            Mod_Update_Counter++;
                        }
                        DispatchIfNecessary(async () =>
                        {
                            if (Card != null)
                            {
                                Card = (new Grid_ { NameSpace = Split_Name[0],
                                    Name = MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber,
                                    Icon = ICON,
                                    raw_date = updater.DateCreated.ToString(),
                                    date_created = ConvertDateToString(updater.DateCreated),
                                    description = Descrtiption,
                                    owner = updater.Owner,
                                    Rating = rating,
                                    download_url = download_url + "|" + versions.First().FullName + "|" + Tags + "|" + Dependencies_ + "|" + Split_Name[0],
                                    Webpage = updater.PackageUrl,
                                    File_Size = FileSize,
                                    Tag = Tags,
                                    Downloads = downloads,
                                    Dependencies = Dependencies_,
                                    FullName = versions.First().FullName,
                                    raw_size = raw_size,
                                    Update_data = MOD_Name + "|" + versions.First().VersionNumber,
                                    Button_label = label,
                                    Button_Color = bg_color,
                                    is_Favourite_ = is_favourite });
                                Thunderstore_List.Items.Add(Card);
                                itemsList.Add(Card);
                            }
                        });

                    }
                }
            }


            else
            {

                if (Search_ == true && SearchQuery != "#")
                {





                    if (MOD_Name.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) == -1 && updater.Owner.IndexOf(SearchQuery, StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        DispatchIfNecessary(async () =>
                        {


                        });


                        return;
                    }

                    downloads = (Downloads.Sum()).ToString();

                    for (var x = 0; x < versions.First().Dependencies.Count; x++)
                    {
                        if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("ebkr-r2modman-"))
                        {

                            continue;
                        }
                        else
                        {
                            Dependencies.Add(versions.First().Dependencies[x]);

                        }

                    }

                    Dependencies_ = String.Join(", ", Dependencies);

                    download_url = versions.First().DownloadUrl;
                    ICON = versions.First().Icon;
                    FileSize = versions.First().FileSize.ToString();
                    Descrtiption = versions.First().Description;
                    Downloads.Clear();
                    Dependencies.Clear();


                    string raw_size = versions.First().FileSize.ToString();

                    if (int.TryParse(FileSize, out int value))
                    {
                        FileSize = Convert_To_Size(value);
                    }
                    string bg_color;
                    string label;
                    Compare_Mod_To_List(MOD_Name, versions.First().VersionNumber, Main.Current_Installed_Mods, out bg_color, out label);
                    if (bg_color == null || label == null)
                    {
                        bg_color = "#FF005D42";
                        label = "Install";



                    }
                    if (label == "Update")
                    {
                        Mod_Update_Counter++;
                    }
                    int is_favourite = 0;

                    if (Fave_Mods.Contains(MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber))
                    {
                        is_favourite = 1;
                    }

                    // is_nsfw = updater.HasNsfwContent ? 100 : 0;
                    DispatchIfNecessary(async () =>
                    {
                        // is_nsfw = updater.HasNsfwContent ? 100 : 0;
                        if (Card != null)
                        {
                            Card = (new Grid_ { NameSpace = Split_Name[0],
                                Name = MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber,
                                Icon = ICON,
                                raw_date = updater.DateCreated.ToString(),
                                date_created = ConvertDateToString(updater.DateCreated),
                                description = Descrtiption,
                                owner = updater.Owner,
                                Rating = rating,
                                download_url = download_url + "|" + versions.First().FullName + "|" + Tags + "|" + Dependencies_ + "|" + Split_Name[0],
                                Webpage = updater.PackageUrl,
                                File_Size = FileSize,
                                Tag = Tags,
                                Downloads = downloads,
                                Dependencies = Dependencies_,
                                FullName = versions.First().FullName,
                                raw_size = raw_size,
                                Update_data = MOD_Name + "|" + versions.First().VersionNumber,
                                Button_label = label,
                                Button_Color = bg_color,
                                is_Favourite_ = is_favourite });
                            Thunderstore_List.Items.Add(Card);
                            itemsList.Add(Card);

                        }
                    });





                }
                else
                {








                    downloads = (Downloads.Sum()).ToString();

                    for (var x = 0; x < versions.First().Dependencies.Count; x++)
                    {
                        if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("ebkr-r2modman-"))
                        {

                            continue;
                        }
                        else
                        {
                            Dependencies.Add(versions.First().Dependencies[x]);

                        }

                    }


                    download_url = versions.First().DownloadUrl;

                    ICON = versions.First().Icon;
                    FileSize = versions.First().FileSize.ToString();
                    Descrtiption = versions.First().Description;
                    Dependencies_ = String.Join(", ", Dependencies);
                    if (Dependencies_.Length <= 1)
                    {
                        Dependencies_ = "-";
                    }
                    Dependencies.Clear();

                    Downloads.Clear();

                    string raw_size = versions.First().FileSize.ToString();

                    if (int.TryParse(FileSize, out int value))
                    {
                        FileSize = Convert_To_Size(value);
                    }
                    string bg_color;
                    string label;
                    int is_favourite = 0;
                    //  int is_nsfw = 0;

                    if (Fave_Mods.Contains(MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber))
                    {
                        is_favourite = 1;
                    }


                    Compare_Mod_To_List(MOD_Name, versions.First().VersionNumber, Main.Current_Installed_Mods, out bg_color, out label);
                    if (bg_color == null || label == null)
                    {
                        bg_color = "#FF005D42";
                        label = "Install";



                    }
                    if (label == "Update")
                    {
                        Mod_Update_Counter++;
                    }
                    //   is_nsfw = updater.HasNsfwContent ? 100 : 0;
                    DispatchIfNecessary(async () =>
                    {
                        // is_nsfw = updater.HasNsfwContent ? 100 : 0;
                        if (Card != null)
                        {
                            Card = (new Grid_ { NameSpace = Split_Name[0],
                                Name = MOD_Name.Replace("_", " ") + "-" + versions.First().VersionNumber,
                                Icon = ICON,
                                raw_date = updater.DateCreated.ToString(),
                                date_created = ConvertDateToString(updater.DateCreated),
                                description = Descrtiption,
                                owner = updater.Owner,
                                Rating = rating,
                                download_url = download_url + "|" + versions.First().FullName + "|" + Tags + "|" + Dependencies_ + "|" + Split_Name[0],
                                Webpage = updater.PackageUrl,
                                File_Size = FileSize,
                                Tag = Tags,
                                Downloads = downloads,
                                Dependencies = Dependencies_,
                                FullName = versions.First().FullName,
                                raw_size = raw_size,
                                Update_data = MOD_Name + "|" + versions.First().VersionNumber,
                                Button_label = label,
                                Button_Color = bg_color,
                                is_Favourite_ = is_favourite });
                            Thunderstore_List.Items.Add(Card);
                            itemsList.Add(Card);
                        }
                    });
                }
            }
          




            return;







        }
        public static string ConvertDateToString(DateTime date)
        {
            TimeSpan timeSince = DateTime.Now - date;
            string output = "";

            if (timeSince.TotalHours < 1)
            {
                output = $"{Math.Max((int)timeSince.TotalMinutes, 1)} " + VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_MinutesAgo;
            }
            else if (timeSince.TotalHours < 12)
            {
                output = $"{Math.Max((int)timeSince.TotalHours, 1)} " + VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_HoursAgo;
            }
            else if (timeSince.TotalDays < 1)
            {
                output = VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_Today;
            }
            else if (timeSince.TotalDays < 2)
            {
                output = VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_Yesterday;
            }
            else if (timeSince.TotalDays < 7)
            {
                output = $"{Math.Max((int)timeSince.TotalDays, 1)} " + VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_DaysAgo;
            }
            else if (timeSince.TotalDays >= 7)
            {
                if (timeSince.TotalDays < 14)
                {
                    output = VTOL.Resources.Languages.Language.Page_Thunderstore_ConvertDateToString_1WeekAgo;
                }
                else
                {
                    output = date.ToString("yyyy-MM-dd"); // Replace with your desired date format
                }
            }

            return output;
        }

        // Function to replace the loading card with the populated data from TS_MOD

        private void loadConvertItemLazy(bool Search_ = false, string SearchQuery = "#")
        {
          
            foreach (var TS_MOD in _updater.Thunderstore)
            {
                AsyncLoadListViewItem(TS_MOD, Search_, SearchQuery.Replace(" ", "_"));

                //Legacy Grid_ Card = LoadListViewItem(TS_MOD, Search_, SearchQuery.Replace(" ", "_"));
                //    if (Card != null)
                //    {
                //    Thunderstore_List.Items.Add(Card);
                //   // ReplaceLoadingCardWithMod(Card);

                //}

            }
        }


        public string Search_For_Mod_Thunderstore(string SearchQuery = "None")

        {
            try
            {
                _updater = new VTOL.Updater("https://northstar.thunderstore.io/api/v1/package/");

                _updater.Download_Cutom_JSON();

                for (int i = 0; i < _updater.Thunderstore.Length; i++)
                {
                    List<versions> versions = _updater.Thunderstore[i].versions;

                    string[] subs = SearchQuery.Split('-');
                    if (_updater.Thunderstore[i].FullName.Contains(subs[1], StringComparison.OrdinalIgnoreCase) || _updater.Thunderstore[i].Owner.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                    {

                        return versions.First().DownloadUrl + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber;

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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
            return null;
        }

        public class Action_Card
        {
            public string Date { get; set; }
            public string URL { get; set; }

            public string Action { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Progress { get; set; }
            public string Completed { get; set; }

        }
        public class Grid_
        {
            public string Tag { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public string Icon { get; set; }
            public string owner { get; set; }
            public string description { get; set; }
            public string download_url { get; set; }
            public string Webpage { get; set; }
            public string date_created { get; set; }
            public int Rating { get; set; }
            public string File_Size { get; set; }
            public string Downloads { get; set; }
            public string Dependencies { get; set; }
            public string NameSpace { get; set; }

            public string raw_size { get; set; }
            public string raw_date { get; set; }
            public string Update_data { get; set; }

            public string Button_label { get; set; }
            public string Button_Color { get; set; }
            public int is_Favourite_ { get; set; }
            public int is_NSFW { get; set; }

        }


        string Convert_To_Size(int size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            double len = Convert.ToDouble(size);
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            string result = String.Format("{0:0.##} {1}", len, sizes[order]);                 //   ICON = items.Icon;
            return result;

        }
        private void TextBlock_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Dialog_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            Dialog.Hide();

        }
        async void downloader_ProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e, ProgressBar Progress_Bar)
        {
            DispatchIfNecessary(async () =>
            {

                Progress_Bar.Value = (e.ProgressPercentage);
            });


        }

        async void downloader_DownloadCompleted(object sender, AsyncCompletedEventArgs e, ProgressBar Progress_Bar, string Mod_Name, string NameSpace, string Location, bool Plugin_Install, bool NS_CANDIDATE_INSTALL)
        {
            if (NS_CANDIDATE_INSTALL == true)
            {
                await Unpack_To_Location_Custom(Location, User_Settings_Vars.NorthstarInstallLocation + @"Northstar_TEMP_FILES\", Progress_Bar, true, false, Plugin_Install, NS_CANDIDATE_INSTALL, Mod_Name, NameSpace);

            }
            else
            {


                await Unpack_To_Location_Custom(Location, User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\packages\" + Mod_Name, Progress_Bar, true, false, Plugin_Install, NS_CANDIDATE_INSTALL, Mod_Name, NameSpace);
            }


        }
        async Task Download_Zip_To_Path(string url, string path, ProgressBar Progress_Bar = null, bool Plugin_Install = false, bool NS_CANDIDATE_INSTALL = false, CancellationToken cancellationToken = default, DownloadQueueItem item_ = null)
        {
            await Task.Run(() =>
            {//Regex.Replace(item, @"(\d+\.)(\d+\.)(\d)", "").TrimEnd('-')
                DispatchIfNecessary(async () =>
                {
                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return;
                        }



                        string[] words = url.Split("|");
                        IDownload downloader = null;
                        string[] separatedname = null;
                        if (words.Length < 2)
                        {
                            return;
                        }

                        downloader = DownloadBuilder.New()
      .WithUrl(words[0])
      .WithDirectory(path)
      .WithFileName(item_.Name + ".zip")
      .WithConfiguration(new DownloadConfiguration())

      .Build();




                        if (Progress_Bar != null)
                        {




                            downloader.DownloadProgressChanged += delegate (object sender2, Downloader.DownloadProgressChangedEventArgs e2)
                            {

                                downloader_ProgressChanged(sender2, e2, Progress_Bar);
                            };
                        }

                        var Destinfo = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation);
                        if (!Directory.Exists(Destinfo.FullName + @"NS_Downloaded_Mods\"))

                        {
                            Directory.CreateDirectory(Destinfo.FullName + @"NS_Downloaded_Mods\");

                        }
                        else
                        {

                            Clear_Folder(Destinfo.FullName + @"NS_Downloaded_Mods\");
                        }

                        downloader.DownloadFileCompleted += delegate (object sender4, AsyncCompletedEventArgs e4)
                        {

                            downloader_DownloadCompleted(sender4, e4, Progress_Bar, item_.Name, item_.Namespace, Destinfo.FullName + @"NS_Downloaded_Mods\" + item_.Name + ".zip", Plugin_Install, NS_CANDIDATE_INSTALL);
                        };
                        downloader.StartAsync();
                        if (cancellationToken.IsCancellationRequested)
                        {
                            downloader.Stop();
                            return;
                        }



                    }
                });
            });









        }
        bool Is_Valid_URl(string uriName)
        {

            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        public class L_INFO
        {
            public string name;
            public string url;

        }
        void Dependency_Download(string Dependencies_To_Find_And_Download, ProgressBar Progress_Bar = null)
        {
            try
            {

                List<string> Mods = new List<string>();
                Mods = Dependencies_To_Find_And_Download?.Split("\n").ToList();
                List<L_INFO> Links = new List<L_INFO>();

                foreach (var x in Mods)
                {

                    string URL = Search_For_Mod_Thunderstore(x);

                    if (Is_Valid_URl(URL))
                    {
                        Links.Add(new L_INFO { name = x, url = URL });



                    }

                }
                //updated dependecies


                Progress_Bar = new ProgressBar();
                string[] names = Dependencies_To_Find_And_Download.Split(@"\");

                foreach (var y in Links)
                {
                    try { 
                    string namespace_ = y.name.Split("-")[0];

                    var item = new DownloadQueueItem
                    {
                        Name = y.name,
                        DownloadUrl = y.url,
                        DestinationPath = User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods",
                        Extract = false,
                        IsNorthstarRelease = false,
                        Progress = Progress_Bar,
                        Namespace = namespace_

                    };
                    Main._downloadQueue.Enqueue(item);
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
            //  await Download_Zip_To_Path(y, User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods", Progress_Bar);
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
            Dialog.Hide();

        }


        private void CardAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgressBar Progress_Bar = null;
                HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Wpf.Ui.Controls.CardAction)sender).Parent;
                Progress_Bar = FindVisualChild<ProgressBar>(_Panel);
                var Tag_Data_ = ((Wpf.Ui.Controls.CardAction)sender).ToolTip.ToString();
                var Name_Data = ((Wpf.Ui.Controls.CardAction)sender).Tag.ToString();

                string Tag_Data = "\n" + (Tag_Data_.Replace(",", "\n").Replace(" ", "") + "\n\n" + VTOL.Resources.Languages.Language.Page_Thunderstore_CardAction_Click_DoYouWantToInstallTheseAndTheMod + "\n" + Name_Data + "?").Trim();
                if (Tag_Data.Count() > 5)
                {

                    Dialog.Title = Name_Data + " - Dependencies";

                    Dialog.DialogHeight = 350;
                    Dialog.Message = Tag_Data;
                    Dialog.ButtonLeftName = "Yes";
                    Dialog.ButtonRightName = "Cancel";
                    Dialog.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                    Dialog.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Caution;


                    Dialog.Tag = ((Tag_Data_ + " ," + Name_Data.Trim()).Replace(",", "\n").Replace(" ", ""));

                    Progress_Cur_Temp = Progress_Bar;

                    Dialog.Show();

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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {



            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subdirs = directory.GetDirectories();

            return (files.Length == 0 && subdirs.Length == 0);


        }

        private async Task Clear_Folder(string FolderName, bool overwrite = true, int maxRetries = 10, int millisecondsDelay = 30)
        {

            if (FolderName == null)
                throw new ArgumentNullException(FolderName);
            if (maxRetries < 1)
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            if (millisecondsDelay < 1)
                throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            for (int i = 0; i < maxRetries; ++i)
            {



                try
                {
                    DirectoryInfo dir = new DirectoryInfo(FolderName);

                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }

                    foreach (DirectoryInfo di in dir.GetDirectories())
                    {
                        Clear_Folder(di.FullName);
                        di.Delete();
                    }
                }
                catch (Exception ex)
                {

                    return;

                }
            }

            return;
        }
        private async Task CopyFilesRecursively(string sourcePath, string targetPath)
        {
            await Task.Run(() =>
            {
                // Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }

                // Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    if (!File.Exists(targetPath))
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                    else
                    {
                        File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                    }
                }
            });
        }
        private async Task CopyFilesRecursivel_Async(string sourcePath, string targetPath)
        {
            // Create the target directory if it doesn't exist
            if (!Directory.Exists(targetPath))
            {
                TryCreateDirectory(targetPath);
            }

            // Copy all the files & Replaces any files with the same name
            await Task.Run(() => Parallel.ForEach(Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories), file =>
            {
                string relativePath = file.Replace(sourcePath, "");
                string targetFilePath = Path.Combine(targetPath, relativePath);

                TryCopyFile(file, targetFilePath, true);
            }));
        }

        public async Task<bool> TryUnzipFile(
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
        public async Task<bool> TryDeleteFile(
string Origin,
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
                        File.Delete(Origin);
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
        public async Task<bool> IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = true;

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
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");isValid = false;
            }

            return isValid;
        }
        async Task Call_Mods_From_Folder_Lite()
        {

            try
            {

                if (User_Settings_Vars.NorthstarInstallLocation != null || User_Settings_Vars.NorthstarInstallLocation != "" || Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {

                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {

                        Main.Current_Installed_Mods.Clear();

                        string NS_Mod_Dir = User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages";
                        System.IO.DirectoryInfo NS_Dirs = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods");

                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
                        bool result = await IsValidPath(NS_Mod_Dir);
                        if (result == true)
                        {

                            System.IO.DirectoryInfo[] subDirs = null;
                            subDirs = rootDirs.GetDirectories().Concat(NS_Dirs.GetDirectories()).ToArray();

                            bool read_NS_version = true;
                            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                            {
                                try { 
                                string[] parts = dirInfo.Name.Split('-');
                                string name = dirInfo.Name;
                                string author = null;
                                string ver = null;
                                if (parts.Length > 1)
                                {
                                    author = parts[0];
                                    name = parts[1];
                                    ver = parts[2];
                                }
                                //TODO
                                //116 - 300 ms delay, remove or improve asap
                                if (name.Contains("Northstar.") && dirInfo.Parent.Name.Equals(@"mods") && read_NS_version == true)
                                {
                                    parts = null;
                                    parts = dirInfo.Name.Split('.');
                                    author = parts[0];
                                    name = dirInfo.Name;
                                    string json = File.ReadAllText(dirInfo.FullName + @"\mod.json");
                                    // Parse the JSON
                                    dynamic data = JsonConvert.DeserializeObject(json);

                                    // Access the value
                                    ver = data["Version"];
                                    if (ver != null) { read_NS_version = false; }

                                }




                                Main.Current_Installed_Mods.Add(new GENERAL_MOD { Name = name, Version = ver, Author = author });
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
                            Main.loaded_mods = true;

                        }



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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }
        public void SlowBlink(Control control, double minimumOpacity)
        {
            DispatchIfNecessary(async () =>
            {
                // Create a DoubleAnimation to animate the control's Opacity property
                var animation = new DoubleAnimation
                {
                    From = 1.0,
                    To = minimumOpacity,
                    Duration = new Duration(TimeSpan.FromSeconds(0.6)),
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever

                };

                // Apply the animation to the control's Opacity property
                control.BeginAnimation(UIElement.OpacityProperty, animation);
            });
        }

        void Update_ActionCard_Progress(Action_Card Action_Card_, int Add_INT = 10, bool Completed = false, bool FailedEvent = false)
        {
            try
            {
                DispatchIfNecessary(async () =>
            {
                if (Action_Card_ != null)
                {

                    Main.Action_Center.ItemsSource = null;
                    Action_Card_.Progress = Math.Clamp(Action_Card_.Progress + Add_INT, 0, 100); ;
                    //Completed.ToString();
                    if (FailedEvent == true)
                    {
                        Action_Card_.Completed = "ErrorCircle20";
                        Main.Action_Center_Progress_Text.Text = null;
                        Action_Card_.Progress = 100;
                        Main.Action_Center.ItemsSource = Action_Center;
                        Main.Action_Center.Refresh();
                        return;
                    }
                    if (Completed == false)
                    {
                        Action_Card_.Completed = "Dismiss16";

                    }
                    else
                    {
                        Main.Action_Center_Progress_Text.Text = null;

                        Action_Card_.Progress = 100;
                        Action_Card_.Completed = "Checkmark48";
                    }
                    Main.Action_Center.ItemsSource = Action_Center;
                    Main.Action_Center.Refresh();
                }
            });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + " \n\n\n\n" + ex.InnerException);


            }

        }
        public static void MoveDirectory___(string source, string target)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                try { 
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
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
            Directory.Delete(source, true);
        }
        public static string FindFirstFile(string path, string searchPattern)
        {

            try
            {
                string[] files;

                try
                {
                    // Exception could occur due to insufficient permission.
                    files = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");return string.Empty;
                }

                // If matching files have been found, return the first one.
                if (files.Length > 0)
                {
                    return files[0];
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
                    catch (Exception)
                    {
                        return string.Empty;
                    }

                    // Iterate through each directory and call the method recursivly.
                    foreach (string directory in directories)
                    {
                        try { 
                        string file = FindFirstFile(directory, searchPattern);

                        // If we found a file, return it (and break the recursion).
                        if (file != string.Empty)
                        {
                            return file;
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
                return string.Empty;

            }



            catch (Exception ex)
            {

                Log.Error(ex.Message + " \n\n\n\n" + ex.InnerException);

            }
            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return string.Empty;
        }
        public static string FindFolder(string folderName, string searchPattern)
        {
            string[] folders = null;

            try
            {
                folders = Directory.GetDirectories(folderName, searchPattern);

                if (folders.Length > 0)
                {
                    return folders[0]; // Return the first matching folder
                }
                else
                {
                    return null; // No matching folder found
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + " \n\n\n\n" + ex.InnerException);
                return null; // Handle the exception as per your application's needs
            }
        }
        static bool CheckIfFolderExistsInZip(string zipFilePath, string folderName)
        {
            using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(zipFilePath))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith(folderName) && entry.FullName.EndsWith("/"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        async Task _garbage_holderAsync(string Target_Zip, string Destination)
        {

            await TryUnzipFile(Target_Zip, Destination);


        }

        public async Task Unpack_To_Location_Custom(string Target_Zip, string Destination, ProgressBar Progress_Bar, bool Clean_Thunderstore = false, bool clean_normal = false, bool plugin_install = false, bool NS_CANDIDATE_INSTALL = false, string mod_name = "~", string namespace_ = "~")
        {
            //add drag and drop
            var Action_Card_ = Action_Center.FirstOrDefault(i =>
            {

                return i.Name.ToLower().Contains(mod_name.ToLower());
            });
            try
            {
                string Dir_Final = null;
                string Old_MOD = Find_Folder(mod_name, User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages");
                if (Directory.Exists(Old_MOD))
                {
                    TryDeleteDirectory(Old_MOD);
                }



                if (!File.Exists(Target_Zip))
                {
                    DispatchIfNecessary(async () =>
                    {
                        if (Progress_Bar != null)
                        {
                            Progress_Bar.Value = 0;
                        }
                    });
                    Log.Error("The Zip File" + Target_Zip + " was not found or does not exist?");
                    return;


                }
                if (!Directory.Exists(Destination))
                {
                    await TryCreateDirectory(Destination);
                }
                if (!Directory.Exists(Destination))
                {
                    DispatchIfNecessary(async () =>
                    {
                        if (Progress_Bar != null)
                        {
                            Progress_Bar.Value = 0;
                        }
                    });
                    Log.Error("The Destination" + Destination + " is not accessible or does not exist?"); await TryDeleteDirectory(User_Settings_Vars.NorthstarInstallLocation + @"Northstar_TEMP_FILES\");
                    return;


                }
                Update_ActionCard_Progress(Action_Card_);



                await Clear_Folder(Destination);

                string fileExt = System.IO.Path.GetExtension(Target_Zip);

                if (fileExt != ".zip")
                {
                    Log.Warning("The File" + Target_Zip + "Is noT a zip!!");
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                    SnackBar.Content = "The File " + Target_Zip + " Is noT a zip!!";
                    DispatchIfNecessary(async () =>
                    {
                        if (Progress_Bar != null)
                        {
                            Progress_Bar.Value = 0;
                        }
                    }); await TryDeleteDirectory(User_Settings_Vars.NorthstarInstallLocation + @"Northstar_TEMP_FILES\");
                    return;
                }
                Update_ActionCard_Progress(Action_Card_);

                //checkling for plugins
                bool containsFolder = CheckIfFolderExistsInZip(Target_Zip, "plugins");


                if (containsFolder)
                {



                   // Console.WriteLine("Plugin Detected ------\n\n\n\n\n");

                    bool consent_TM = false;

                    DispatchIfNecessary(async () =>
                        {
                            Wpf.Ui.Controls.MessageBox Mesagebox = new Wpf.Ui.Controls.MessageBox();

                            Mesagebox.Title = VTOL.Resources.Languages.Language.PLUGINDETECTED;

                            Mesagebox.Content = VTOL.Resources.Languages.Language.PleaseChooseToInstallThisPluginOntoYourDevice + "\n" + VTOL.Resources.Languages.Language.DoBeWarnedThatPluginsCanAffectYourDeviceIn + "\n" + VTOL.Resources.Languages.Language.UnintendedWays + "\n" + VTOL.Resources.Languages.Language.PleaseEnusreYouTrustThisMod;
                            Mesagebox.ButtonLeftName = "Install";
                            Mesagebox.ButtonRightName = "Delete";
                            Mesagebox.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                            Mesagebox.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Danger;
                            Mesagebox.Closed += delegate (object sender, System.EventArgs e)
                            {

                                if (consent_TM == false)
                                {


                                    TryDeleteDirectory(Destination);
                                    Update_ActionCard_Progress(Action_Card_, 50, false);



                                    if (Progress_Bar != null)
                                    {
                                        Progress_Bar.Value = 0;
                                    }
                                    Update_ActionCard_Progress(Action_Card_, 40, false, true);

                                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                    SnackBar.Timeout = 10000;
                                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.ThePlugin + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.HasNotBeenInstalledOnYourDevice;
                                    SnackBar.Show();
                                    return;

                                }






                            };
                            Mesagebox.ButtonLeftClick += delegate (object sender, System.Windows.RoutedEventArgs e)
                            {
                                consent_TM = true;
                                TryUnzipFile(Target_Zip, Destination);

                                Update_ActionCard_Progress(Action_Card_);

                                Call_Mods_From_Folder_Lite();
                                var Destinfo1 = new DirectoryInfo(Destination);
                                Destinfo1.Attributes &= ~FileAttributes.ReadOnly;
                                string manifest_json = FindFirstFile(Destinfo1.FullName, "manifest.json");

                                if (File.Exists(manifest_json) == true)
                                {
                                    string stringmani = File.ReadAllText(manifest_json);
                                    JObject manidata = JObject.Parse(stringmani);

                                    if (manidata.SelectToken("namespace") == null)
                                    {

                                        manidata["namespace"] = namespace_;


                                        File.WriteAllText(manifest_json, manidata.ToString());

                                    }


                                }
                                Update_ActionCard_Progress(Action_Card_, 30, true);



                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                                SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                                SnackBar.Timeout = 10000;
                                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                SnackBar.Message = VTOL.Resources.Languages.Language.ThePlugin + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                SnackBar.Show();

                                Mesagebox.Close();

                                return;

                            };
                            Mesagebox.ButtonRightClick += delegate (object sender, System.Windows.RoutedEventArgs e)
                            {
                                TryDeleteDirectory(Destination);
                                Update_ActionCard_Progress(Action_Card_, 50, false);



                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                                Update_ActionCard_Progress(Action_Card_, 40, false, true);

                                SnackBar.Title = VTOL.Resources.Languages.Language.CAUTION;
                                SnackBar.Timeout = 10000;
                                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                                SnackBar.Message = VTOL.Resources.Languages.Language.ThePlugin + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.HasBeenRemovedAndCleanedFromYourDevice;
                                SnackBar.Show();

                                Mesagebox.Close();

                                return;
                            };


                            Mesagebox.Show();
                            if (Progress_Bar != null)
                            {
                                Progress_Bar.Value = 0;
                            }


                        });

                }
                else
                {

                    await TryUnzipFile(Target_Zip, Destination);

                    Update_ActionCard_Progress(Action_Card_);

                    await Call_Mods_From_Folder_Lite();

                    var Destinfo1 = new DirectoryInfo(Destination);
                    Destinfo1.Attributes &= ~FileAttributes.ReadOnly;
                    string Mod_json = FindFirstFile(Destinfo1.FullName, "mod.json");
                    string manifest_json = FindFirstFile(Destinfo1.FullName, "manifest.json");
                    string Plugins_folder = FindFolder(Destinfo1.FullName, "plugins");
                    bool mod_json = File.Exists(Mod_json);
                    if (NS_CANDIDATE_INSTALL == false && mod_json == false)
                    {

                        if (Plugins_folder != null)
                        {
                        }

                    }
                    else if (mod_json == true && NS_CANDIDATE_INSTALL == false)
                    {
                      //  Console.WriteLine("Mod Detected ------\n\n\n\n\n");

                        if (File.Exists(manifest_json) == true)
                        {
                            string stringmani = File.ReadAllText(manifest_json);
                            JObject manidata = JObject.Parse(stringmani);

                            if (manidata.SelectToken("namespace") == null)
                            {
                                // Create a new JObject for the namespace
                                Log.Information("Namespace not found - Inserting : " + namespace_.ToString());
                                //  namespaceObject[namespace__] = namespace_;
                                manidata["namespace"] = namespace_;


                                File.WriteAllText(manifest_json, manidata.ToString());

                                Log.Information("File updated and saved.");
                            }


                        }
                        if (File.Exists(Mod_json))
                        {

                            string myJsonString = File.ReadAllText(Mod_json);
                            JObject data = JObject.Parse(myJsonString);
                            string Name = data.SelectToken("Name").Value<string>();
                            string Version = data.SelectToken("Version").Value<string>();




                            string Json_Path = FindFirstFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\", "enabledmods.json");
                            if (!File.Exists(Json_Path))
                            {
                                File.WriteAllText(Json_Path, "{\t\t\n\n}");
                                DispatchIfNecessary(async () =>
                                {


                                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.File + Json_Path + VTOL.Resources.Languages.Language.CouldNotBeFoundOrHadAnErrorAndWasEdited;
                                    SnackBar.ShowAsync();
                                });
                            }



                            // Read the JSON file
                            string jsonContent = File.ReadAllText(Json_Path);

                                if (jsonContent.IsNullOrEmpty() == true || jsonContent.Length > 2 || jsonContent == "null")
                                {// Parse the JSON content


                                    jsonContent = "{\t\t\n\n}";
                                    //File.WriteAllText(Json_Path, "{\t\t\n\n}");

                                }
                                // Parse the JSON content
                                JObject jsonObject = JObject.Parse(jsonContent);

                                // Insert a new property
                                jsonObject[Name] = true;

                                // Convert back to JSON string
                                string updatedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                                // Write back to the fileorder
                                File.WriteAllText(Json_Path, updatedJson);

                            

                            Update_ActionCard_Progress(Action_Card_, 30, true);


                            DispatchIfNecessary(async () =>
                            {
                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                                Update_ActionCard_Progress(Action_Card_, 40, true);


                                SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                SnackBar.Message = VTOL.Resources.Languages.Language.TheMod + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                SnackBar.ShowAsync();


                            });




                        }
                    }
                    else
                    {
                       
                        DispatchIfNecessary(async () =>
                    {
                        Update_ActionCard_Progress(Action_Card_, 5);


                        if (Progress_Bar != null)
                        {
                            Progress_Bar.IsIndeterminate = true;
                        }

                    });


                        Update_ActionCard_Progress(Action_Card_, 5);


                        if (!Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder"))
                        {
                            await TryCreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder");
                        }
                        Update_ActionCard_Progress(Action_Card_, 10);

                        if (do_not_overwrite_Ns_file == true)
                        {

                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt"))
                            {
                                await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt", User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt", true);
                            }





                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg"))
                            {

                                await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg", User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg", true);



                            }

                            await Task.Delay(100);


                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt"))
                            {


                                await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt", User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt", true);


                            }

                        }
                        Update_ActionCard_Progress(Action_Card_, 10);
                        string searchPattern = @"Northstar.*";
                        string baseFolderPath = Path.Combine(User_Settings_Vars.NorthstarInstallLocation, User_Settings_Vars.Profile_Path + @"\mods");

                        string[] matchingFolders = Directory.GetDirectories(baseFolderPath, searchPattern, SearchOption.AllDirectories);


                        foreach (string folderPath in matchingFolders)
                        {
                            try { 
                            if (Directory.Exists(folderPath))
                            {

                                TryDeleteDirectory(folderPath, true);

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
                        string searchQuery3 = "*" + "Northstar.dll" + "*";

                        var Destinfo = new DirectoryInfo(Destination);
                        var Script_ = Directory.GetFiles(Destination);


                        var Script = Destinfo.GetFiles(searchQuery3, SearchOption.AllDirectories);
                        Destinfo.Attributes &= ~FileAttributes.ReadOnly;


                        if (Script.Length != 0)
                        {
                            var File_ = Script.FirstOrDefault();

                            Update_ActionCard_Progress(Action_Card_, 10);

                            FileInfo FolderTemp = new FileInfo(File_.FullName);
                            DirectoryInfo di = new DirectoryInfo(Directory.GetParent(File_.FullName).ToString());
                            string firstFolder = di.FullName;
                            string Northstar_VEr_Temp = null;
                            if (Directory.Exists(Destination))
                            {

                                await CopyFilesRecursively(firstFolder, User_Settings_Vars.NorthstarInstallLocation);
                                Update_ActionCard_Progress(Action_Card_, 10);

                            }




                            if (do_not_overwrite_Ns_file == true)
                            {

                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt"))
                                {
                                    await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt", User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt", true); Update_ActionCard_Progress(Action_Card_, 10);

                                }





                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg"))
                                {

                                    await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg", User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg", true);



                                }



                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt"))
                                {

                                    Update_ActionCard_Progress(Action_Card_, 10);

                                    await TryCopyFile(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt", User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt", true);


                                }

                            }

                            DispatchIfNecessary(async () =>
                            {
                                Update_ActionCard_Progress(Action_Card_, 10);

                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.IsIndeterminate = false;

                                    Progress_Bar.Value = 0;
                                }
                            });

                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"NorthstarLauncher.exe"))
                            {
                                Update_ActionCard_Progress(Action_Card_, 10);
                                DispatchIfNecessary(async () =>
                                {
                                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(User_Settings_Vars.NorthstarInstallLocation + @"NorthstarLauncher.exe");
                                    string Current_Ver_ = myFileVersionInfo.FileVersion;

                                    User_Settings_Vars.CurrentVersion = Current_Ver_;
                                    Properties.Settings.Default.Version = Current_Ver_;
                                    Properties.Settings.Default.Save();
                                    Northstar_VEr_Temp = Current_Ver_;

                                    Main.NORTHSTAR_BUTTON.Content = "Northstar Version - " + Current_Ver_.Remove(0, 1);
                                    Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " |";
                                    Main.VERSION_TEXT.Refresh();

                                });
                            }
                            await TryDeleteDirectory(User_Settings_Vars.NorthstarInstallLocation + @"Northstar_TEMP_FILES\");
                            Update_ActionCard_Progress(Action_Card_, 30, true);

                            DispatchIfNecessary(async () =>
                            {

                                SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                string temp_;
                                if (Northstar_VEr_Temp != null && Northstar_VEr_Temp.Length > 2)
                                {
                                    temp_ = "The Build " + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + Northstar_VEr_Temp.Remove(0, 1) + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;

                                }
                                else
                                {
                                    temp_ = Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                }
                                SnackBar.Message = temp_;
                                SnackBar.ShowAsync();


                            });
                            Update_ActionCard_Progress(Action_Card_, 30, true);

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                DispatchIfNecessary(async () =>
                {
                    Update_ActionCard_Progress(Action_Card_, 10, false, true);

                    //if (_downloadQueue != null)
                    //{
                    //    _downloadQueue.CancelDownload(mod_name);
                    //}
                    if (Progress_Bar != null)
                    {
                        Progress_Bar.Value = 0;
                    }
                });    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
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
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
                return "0.0.0";

            }
        }
        static double CalculateSimilarity(string str1, string str2)
        {
            int commonLength = Math.Min(str1.Length, str2.Length);
            int commonPrefix = 0;

            for (int i = 0; i < commonLength; i++)
            {
                if (str1[i] == str2[i])
                {
                    commonPrefix++;
                }
                else
                {
                    break;
                }
            }

            return (double)commonPrefix / Math.Max(str1.Length, str2.Length);
        }
        private string Find_Folder(string searchQuery, string folderPath)
        {
            try
            {
                // Get all directories in the base directory
                string[] directories = Directory.GetDirectories(folderPath);

                foreach (string directory in directories)
                {
                    try { 
                    string folderName = Path.GetFileName(directory);

                    // Check if the folder name is similar to the query folder
                    double similarity = CalculateSimilarity(folderName, searchQuery);

                    if (similarity >= 0.8)
                    {
                        return directory; // Return the first matching folder found
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
            catch (Exception ex)
            {
                Log.Error(ex.Message + " \n\n\n\n" + ex.InnerException);
            }

            return null; // Return null if no matching folder is found
        }



        public class DownloadQueueItem
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Namespace { get; set; }

            public string DownloadUrl { get; set; }
            public string DestinationPath { get; set; }
            public bool Extract { get; set; }
            public bool IsNorthstarRelease { get; set; }
            public ProgressBar Progress { get; set; }
        }

        public class DownloadQueue
        {
            private MainWindow Main = GetMainWindow();

            public List<DownloadQueueItem> _queue = new List<DownloadQueueItem>();
            public HashSet<string> _inProgress = new HashSet<string>();
            private readonly Page_Thunderstore _myClass;
            public List<DownloadQueueItem> _queue_List_Clear = new List<DownloadQueueItem>();

            public DownloadQueue(Page_Thunderstore myClass)
            {
                _myClass = myClass;
            }

            public async void Enqueue(DownloadQueueItem item)
            {


                if (_queue.Any(i => i.Name.ToLower().Contains(item.Name.ToLower())) || _inProgress.Contains(item.DownloadUrl) || _queue_List_Clear.Any(i => i.Name.ToLower().Contains(item.Name.ToLower())))
                {





                    Main.DispatchIfNecessary(async () =>
                    {
                        Main.Action_Center.ItemsSource = null;
                        _myClass.Action_Center.RemoveAll(i => i.Name.ToLower().Contains(item.Name.ToLower()));
                        Main.Action_Center.ItemsSource = _myClass.Action_Center;
                        _inProgress.Remove(item.DownloadUrl);
                        _queue.RemoveAll(item => item.Name.ToLower().Contains(item.Name.ToLower()));
                        _queue_List_Clear.RemoveAll(item => item.Name.ToLower().Contains(item.Name.ToLower()));
                        Main.Action_Center.Refresh();

                        Main.Snackbar.Message = VTOL.Resources.Languages.Language.DownloadWithTheSameURLIsWasAlreadyInProgressOrQueued;
                        Main.Snackbar.Title = VTOL.Resources.Languages.Language.INFO;
                        Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                        Main.Snackbar.ShowAsync();
                        await Task.Delay(2000);
                    });
                }

                _inProgress.Add(item.DownloadUrl);
                _queue.Add(item);
                _queue_List_Clear.Add(item);
                await ExecuteQueueAsync();


            }

            private async Task ExecuteQueueAsync()
            {
                while (_queue.Any())
                {
                    var item = _queue.First();
                    _queue.RemoveAt(0);

                    var cts = new CancellationTokenSource();

                    try
                    {
                        await DownloadZipAsync(item, cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        // Download was cancelled
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
                    finally
                    {
                        // _myClass.Action_Center.RemoveAll(card => card.Description == item.DestinationPath);

                        //  _inProgress.Remove(item.DownloadUrl);
                    }
                }
            }

            private async Task DownloadZipAsync(DownloadQueueItem item, CancellationToken cancellationToken)
            {
                try
                {
                    string name = item.Name;
                    string URl = "";

                    string[] parts = item.DownloadUrl.Split('|');
                    if (parts.Length >= 2)
                    {
                        URl = parts[0];

                    }

                    Main.DispatchIfNecessary(() =>
                    {
                        Main.Action_Center.ItemsSource = null;

                        Main.Action_Center_Progress_Text.Text = name;

                        _myClass.Action_Center.Add(new Action_Card
                        {
                            Action = VTOL.Resources.Languages.Language.DownloadingFromThunderStore,
                            Name = name,
                            Description = item.DestinationPath,
                            Progress = 0,
                            Completed = "Dismiss16",
                            Date = DateTime.Now.ToString(),
                            URL = URl
                        });
                        Main.Action_Center.ItemsSource = _myClass.Action_Center;
                        Main.Action_Center.Refresh();
                    });
                    await Task.Run(() => _myClass.Download_Zip_To_Path(item.DownloadUrl, item.DestinationPath, item.Progress, item.Extract, item.IsNorthstarRelease, cancellationToken, item));
                    Thread.Sleep(200);

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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
            }

            public void CancelDownload(string name, bool clear_all = false)
            {
                try
                {
                    if (clear_all)
                    {
                        List<Action_Card> removedCards = _myClass.Action_Center
    .Where(card => card.Completed != "Dismiss16" && card.Progress > 90)
    .ToList();

                        Main.DispatchIfNecessary(() =>
                        {
                            Main.Action_Center.ItemsSource = null;
                            Main.Action_Center_Progress_Text.Text = null;


                            _myClass.Action_Center.RemoveAll(card => card.Completed != "Dismiss16" && card.Progress > 90);



                            Main.Action_Center.ItemsSource = _myClass.Action_Center;
                            Main.Action_Center.Refresh();
                        });
                        foreach (var mod in removedCards)
                        {
                            try { 
                            _inProgress.RemoveWhere(i =>
                            {
                                return i.ToLower().Contains(name.ToLower());


                            });
                            _queue.RemoveAll(i =>
                            {
                                return i.Name.ToLower().Contains(name.ToLower());


                            });
                            _queue_List_Clear.RemoveAll(i =>
                            {

                                return i.Name.ToLower().Contains(name.ToLower());


                            });
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

                        return;
                    }
                    string name__ = "";

                    var item = _queue_List_Clear.FirstOrDefault(i =>
                    {
                        return i.Name.ToLower().Contains(name.ToLower());


                    });//todo fix clear

                    if (item != null)
                    {

                        Action_Card card = _myClass.Action_Center.FirstOrDefault(c => c.GetType() == typeof(Action_Card) && c.Name.ToLower().Contains(name__.ToLower()));
                        if (card != null)
                        {
                            if (card.Completed == "Dismiss16"
                                || card.Progress < 90)
                            {
                                return;
                            }

                            Main.DispatchIfNecessary(() =>
                            {
                                Main.Action_Center.ItemsSource = null;
                                Main.Action_Center_Progress_Text.Text = null;
                                // _myClass.Action_Center.RemoveAll(card => card.Name == item.Name);
                                _myClass.Action_Center.Remove(card);
                                Main.Action_Center.ItemsSource = _myClass.Action_Center;
                                Main.Action_Center.Refresh();
                            });

                            _inProgress.Remove(item.DownloadUrl);
                            _queue.Remove(item);
                            _queue_List_Clear.Remove(item);



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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
            }
        }

        // Inside the class containing the Install_Bttn_Thunderstore_Click method:


        public void InitializeDownloadQueue()
        {
            Main._downloadQueue = new DownloadQueue(this);
        }

        // create a new DownloadQueueItem for each download and add to the queue



        private void Install_Bttn_Thunderstore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button Button;
                Button = sender as Button;
                ProgressBar Progress_Bar = null;
                HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Button)sender).Parent;
                Progress_Bar = FindVisualChild<ProgressBar>(_Panel);
                if (Progress_Bar.Tag != Button.Tag)
                {
                    Progress_Bar = null;

                }
                string tags = Button.ToolTip.ToString();
                if (tags.Count() < 2)
                {
                    tags = "Mods";
                }
                string name = "";
                string[] parts = Button.Tag.ToString().Split('|');
                if (parts.Length >= 2) // check if there are at least two parts
                {
                    name = parts[1]; // get the second last item
                }
                Console.WriteLine(Button.Tag.ToString());

                if (name.Contains("VanillaPlus"))
                {
                    Main.Snackbar.Message = "VanillaPlus cannot be installed through VTOL";
                    Main.Snackbar.Title = VTOL.Resources.Languages.Language.INFO;
                    Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    Main.Snackbar.Show();

                    return;
                }

                DispatchIfNecessary(async () =>
                {
                    if (parts[0].Contains("http") || parts[0].Contains("https"))
                    {
                        string namespace_ = name.Split("-")[0];

                        var item = new DownloadQueueItem
                        {
                            Name = name,
                            DownloadUrl = Button.Tag.ToString(),
                            DestinationPath = User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods",
                            Extract = false,
                            IsNorthstarRelease = Button.Tag.ToString().Contains("Northstar Release Candidate") || Button.Tag.ToString().Contains("NorthstarReleaseCandidate") || (Button.Tag.ToString().Contains("Northstar") && Button.ToolTip.ToString().Count() < 5),
                            Progress = Progress_Bar,
                            Namespace = namespace_

                        };
                        Main._downloadQueue.Enqueue(item);

                    }

                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }
        async void Reload_Search()
        {






        }
        private void TextInput_OnKeyUpDone(object sender, ElapsedEventArgs e)
        {
            // If we don't stop the timer, it will keep elapsing on repeat.
            try
            {
                _timer.Stop();


                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, e) =>
                {

                    DispatchIfNecessary(async () =>
                    {
                        if (init == true)
                        {
                            if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text != null && Search_Bar_Suggest_Mods.Text.Trim() != "#")
                            {



                                if (_updater.Thunderstore != null)
                                {
                                    if (_updater.Thunderstore.Count() > 0)
                                    {
                                        DispatchIfNecessary(async () =>
                                        {
                                            Thunderstore_List.Items.Clear();

                                            loadConvertItemLazy(Search_: true, SearchQuery: Search_Bar_Suggest_Mods.Text);

                                        });
                                    }
                                }







                            }




                        }


                    });


                };

                worker.RunWorkerAsync();



            }
            catch (Exception ex)
            {

                //Removed PaperTrailSystem Due to lack of reliability.    
    var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }
        private void Search_Bar_Suggest_Mods_TextChanged(object sender, TextChangedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {

                DispatchIfNecessary(async () =>
                {
                    if (init == true)

                    {

                        if (_updater.Thunderstore != null)
                        {
                            if (_updater.Thunderstore.Count() > 0)
                            {
                                
                                    Thunderstore_List.Items.Clear();
                               
                                if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text != null && Search_Bar_Suggest_Mods.Text.Length != 0 && Search_Bar_Suggest_Mods.Text.Trim() != "#")
                                {

                                    loadConvertItemLazy(Search_: true, SearchQuery: Search_Bar_Suggest_Mods.Text);

                                }
                                else
                                {
                                    loadConvertItemLazy();


                                }
                            }

                        }

                    }








                });


            };

            worker.RunWorkerAsync();



        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Main.Page_reset_ == true)
            {

                Thunderstore_List.Items.Clear();
                itemsList.Clear();


            }
            TryDeleteDirectory(User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods");

        }

        private void Dialog_ButtonLeftClick(object sender, RoutedEventArgs e)
        {


            Dependency_Download(Dialog.Tag.ToString(), Progress_Cur_Temp);

        }

        private void Search_Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (page_loaded == true)
                {
                    if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
                    {
                        HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                        Current_Mod_Filter_Tags = null;
                        if (comboBox.SelectedItems.Count > 0)
                        {
                            DispatchIfNecessary(async () =>
                            {
                                Search_Bar_Suggest_Mods.Text = "";
                                Search_Bar_Suggest_Mods.IsReadOnly = true;
                                search_a_flag = true;
                                Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
                                // Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
                            });
                            Current_Mod_Filter_Tags = String.Join(",", comboBox.SelectedItems.Cast<String>()).Split(',').ToList();
                        }
                        if (Search_Filters.SelectedItems != null && Search_Filters.SelectedItems.Count > 0) /*|| Options_List.Contains(Search_Filters.SelectedItem))*/
                        {

                            Sort.SelectedIndex = -1;

                            Category_Label.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            Category_Label.Visibility = Visibility.Visible;

                        }

                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += (sender, e) =>
                        {


                            if (_updater.Thunderstore != null)
                            {
                                if (_updater.Thunderstore.Count() > 0)
                                {
                                    DispatchIfNecessary(async () =>
                                    {
                                        Thunderstore_List.Items.Clear();

                                        loadConvertItemLazy();

                                    });
                                }
                            }


                        };
                        worker.RunWorkerCompleted += (sender, eventArgs) =>
                        {

                            Thunderstore_List.Refresh();

                            //Trackchange
                        };
                        worker.RunWorkerAsync();












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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }
        async Task OPEN_WEBPAGE(string URL)
        {
            try
            {
                await Task.Run(() =>
                {
                    DispatchIfNecessary(async () =>
                    {
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Skins_OPEN_WEBPAGE_OpeningTheFollowingURL + URL;
                        SnackBar.Title = VTOL.Resources.Languages.Language.INFO;
                        SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                        SnackBar.Show();
                    });

                    Thread.Sleep(2000);
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = URL,
                        UseShellExecute = true
                    });
                });

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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void Open_Webpage_Click(object sender, RoutedEventArgs e)
        {



            var URL = ((System.Windows.Controls.Button)sender).Tag.ToString();
            OPEN_WEBPAGE(URL);

        }

        private void ScrollViewer_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            e2.RoutedEvent = UIElement.MouseWheelEvent;
            Thunderstore_List.RaiseEvent(e2);
            e.Handled = true;
        }
        public static Size MeasureText(string text, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize)
        {
            Typeface typeface = new Typeface(fontFamily, fontStyle, fontWeight, fontStretch);
            GlyphTypeface glyphTypeface;

            if (!typeface.TryGetGlyphTypeface(out glyphTypeface))
            {
                return MeasureTextSize(text, fontFamily, fontStyle, fontWeight, fontStretch, fontSize);
            }

            double totalWidth = 0;
            double height = 0;

            for (int n = 0; n < text.Length; n++)
            {
                ushort glyphIndex = glyphTypeface.CharacterToGlyphMap[text[n]];

                double width = glyphTypeface.AdvanceWidths[glyphIndex] * fontSize;

                double glyphHeight = glyphTypeface.AdvanceHeights[glyphIndex] * fontSize;

                if (glyphHeight > height)
                {
                    height = glyphHeight;
                }

                totalWidth += width;
            }

            return new Size(totalWidth, height);
        }

        /// <summary>
        /// Get the required height and width of the specified text. Uses FortammedText
        /// </summary>
        public static Size MeasureTextSize(string text, FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch, double fontSize)
        {
            FormattedText ft = new FormattedText(text,
                                                    CultureInfo.CurrentCulture,
                                                    FlowDirection.LeftToRight,
                                                    new Typeface(fontFamily, fontStyle, fontWeight, fontStretch),
                                                    fontSize,
                                                    Brushes.Black);
            return new Size(ft.Width, ft.Height);
        }

        private void canMain_IsVisibleChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                if (page_loaded != true)
                {
                    return;
                }
                    if (Sort.SelectedIndex == -1)
                {
                    Sort.Background = null;

                    Sort_Label.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    
                    Sort.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#4C018156");

                    Sort_Label.Visibility = Visibility.Hidden;


                    if (_updater.Thunderstore != null)
                        {
                            if (_updater.Thunderstore.Count() > 0)
                            {
                                DispatchIfNecessary(async () =>
                                {

                                    orderlistitems();
                                });
                            }
                        }

                    

                }
            }
            catch (Exception ex)
            { var st = new System.Diagnostics.StackTrace(ex, true);
    var frame = st.GetFrame(0);
    var line = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().DeclaringType.Name;
    var variables = ""; // You would need to add logic to capture variable values

    Log.Fatal(ex, $"An error occurred at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}" +
                   $" Line Number: {line}, Method Name: {method}, Class Name: {className}, Variables: {variables}" +
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void Search_Bar_Suggest_Mods_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Sort_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {


                if (page_loaded == true)
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (sender, e) =>
                    {
                        DispatchIfNecessary(async () =>
                        {

                            if (Main.Page_reset_ == true)
                            {
                                Loading_Ring.Visibility = Visibility.Hidden;
                                Search_Bar_Suggest_Mods.IsReadOnly = true;
                                search_a_flag = true;
                                Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
                                Sort.SelectedIndex = -1;
                                CookFaveMods();
                                Call_Mods_From_Folder_Lite();
                                Call_Ts_Mods();



                            }

                        });



                    };
                    worker.RunWorkerCompleted += (sender, eventArgs) =>
                    {
                        Main.Page_reset_ = false;


                    };



                    worker.RunWorkerAsync();
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {
                Search_Bar_Suggest_Mods.Text = old_text;
                    if (Main.Progress_Header.Opacity < 1)
                    

                {

                    DoubleAnimation da = new DoubleAnimation
                    {
                        From = Main.Progress_Header.Opacity,
                        To = 1,
                        Duration = new Duration(TimeSpan.FromSeconds(0.25)),
                        AutoReverse = false
                    };
                    Main.Progress_Header.BeginAnimation(OpacityProperty, da);
                    Main.Progress_Header.IsHitTestVisible = true;
                }
            });

        }

        private void Thunderstore_Grid_Panel_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DispatchIfNecessary(async () =>
                {



                    Grid Card;
                    if (sender.GetType() == typeof(Grid))
                    {
                        Card = sender as Grid;

                        HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);
                        Wpf.Ui.Controls.CardAction Card_Action = FindVisualChild<Wpf.Ui.Controls.CardAction>(Card);
                        UIElement childElement = FindVisualChild<Border>(Card);
                        if (childElement != null && childElement is Border border && border.Name == "IMG_PNL")
                        {
                            if (border.Tag.ToString() == "1")
                            {
                                border.BorderBrush = Brushes.DarkGoldenrod;                        // ...
                            }
                            border.Refresh();


                        }

                        if (Card != null && GridPanel_ != null && Card_Action != null)
                        {


                            string tooltip_string = Card_Action.ToolTip.ToString().Replace("northstar-Northstar", "").Replace("ebkr-r2modman-", "");

                            if (tooltip_string.Count() > 5 && tooltip_string.Length > 5 && Card_Action.ToolTip.ToString().Length > 5)
                            {
                                Card_Action.IsEnabled = true;
                                Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultipleCheckmark20;
                                Card_Action.IconForeground = Brushes.LawnGreen;
                                SlowBlink(Card_Action, 0.3);
                            }
                            else
                            {
                                //DoubleAnimation x = new DoubleAnimation
                                //{
                                //    From = Card_Action.Opacity,
                                //    To = 0,
                                //    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                                //    AutoReverse = false

                                //};
                                //Card_Action.BeginAnimation(OpacityProperty, x);
                                Card_Action.IsEnabled = false;
                                Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultiple20;

                            }

                        }



                    }

                    if (Mod_Update_Counter > 0)
                    {
                        Mod_Updates_Available.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Mod_Updates_Available.Visibility = Visibility.Hidden;
                    }
                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void SymbolIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {

                DispatchIfNecessary(async () =>
                {
                    Wpf.Ui.Controls.SymbolIcon Favourite_ = sender as Wpf.Ui.Controls.SymbolIcon;
                    if (Favourite_.IsManipulationEnabled == true)
                    {
                        if (Favourite_.Filled == false)
                        {
                            Favourite_.Filled = true;
                        }
                    }

                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void Favourite_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {


                DispatchIfNecessary(async () =>
                {
                    Wpf.Ui.Controls.SymbolIcon Favourite_ = sender as Wpf.Ui.Controls.SymbolIcon;
                    HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Wpf.Ui.Controls.SymbolIcon)sender).Parent;
                    if (Favourite_.IsManipulationEnabled == false)
                    {

                        Favourite_.Filled = false;

                    }


                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void SymbolIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                DispatchIfNecessary(async () =>
                {
                    Wpf.Ui.Controls.SymbolIcon Favourite_ = sender as Wpf.Ui.Controls.SymbolIcon;
                    HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Wpf.Ui.Controls.SymbolIcon)sender).Parent;
                    if (Favourite_.Tag.ToString() != null)
                    {



                        if (Favourite_.Tag.ToString() == "1" || Favourite_.IsManipulationEnabled == true)
                        {
                            Fave_Mods.RemoveWhere(name => name.Equals(Favourite_.ToolTip.ToString()));
                            Favourite_.IsManipulationEnabled = false;
                            Favourite_.Filled = false;
                            Favourite_.Tag = "0";
                            _Panel.Refresh();

                        }
                        else
                        {
                            Main.Page_reset_ = true;

                            Fave_Mods.Add(Favourite_.ToolTip.ToString());
                            Favourite_.Tag = "1";
                            Favourite_.Filled = true;
                            Favourite_.IsManipulationEnabled = true;
                            _Panel.Refresh();
                        }
                    }

                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}
        }

        private void SymbolIcon_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                DispatchIfNecessary(async () =>
                {
                    Wpf.Ui.Controls.SymbolIcon Favourite_ = sender as Wpf.Ui.Controls.SymbolIcon;
                    if (Favourite_.ToolTip != null)
                    {
                        //if(Fave_Mods.Contains(Favourite_.ToolTip.ToString()))
                        //{
                        if (Favourite_.Tag.ToString() == "1" || Favourite_.IsManipulationEnabled == true)
                        {
                            Favourite_.Filled = true;

                        }
                        else
                        {
                            Favourite_.Filled = false;
                        }

                    }
                });
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
                   $"{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");}

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DispatchIfNecessary(async () =>
            {
                if (Action_Center.Count <= 0)
                {
                    if (Main.Progress_Header.Opacity > 0.2)
                    {

                        DoubleAnimation da = new DoubleAnimation
                        {
                            From = Main.Progress_Header.Opacity,
                            To = 0,
                            Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                            AutoReverse = false
                        };
                        Main.Progress_Header.BeginAnimation(OpacityProperty, da);

                    }
                    if (Main.Action_Center_Panel.Opacity > 0.2)
                    {

                        DoubleAnimation da = new DoubleAnimation
                        {
                            From = Main.Action_Center_Panel.Opacity,
                            To = 0,
                            Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                            AutoReverse = false
                        };
                        Main.Action_Center_Panel.BeginAnimation(OpacityProperty, da);

                    }
                    Main.Progress_Header.IsHitTestVisible = false;
                    Main.Action_Center_Panel.IsHitTestVisible = false;
                    Main.Action_Center_Panel.Visibility = Visibility.Collapsed;
                    Main.Action_Center_Progress.IsChecked = false;

                }
                Thunderstore_List.Refresh();
                await SaveHSetAsync();
            });
        }
        public static async Task WriteToLogFileAsync(string Destination, string directory, string name, bool overwrite = false)
        {
            try
            {
                string fileName = name + ".mc";
                string filePath = Path.Combine(Destination, fileName);

                string fileContent = directory + Environment.NewLine;

                if (File.Exists(filePath) && !overwrite)
                {
                    fileContent = File.ReadAllText(filePath) + fileContent;
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    await writer.WriteAsync(fileContent);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message + " \n\n\n\n" + ex.InnerException);

            }
        }


        private void LIKEBTTN_SourceUpdated(object sender, DataTransferEventArgs e)
        {


        }

        private void TextInput_OnKeyUpDone(object sender, KeyEventArgs e)
        {

        }

        private void Search_Bar_Suggest_Mods_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Thunderstore_List_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reload_BTTN_Click(object sender, RoutedEventArgs e)
        {
            Loading_Ring.Visibility = Visibility.Hidden;
            Search_Bar_Suggest_Mods.IsReadOnly = true;
            search_a_flag = true;
            Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF"); 
            Sort.SelectedIndex = -1;
            CookFaveMods();
            Call_Mods_From_Folder_Lite();
            Call_Ts_Mods();

        }

        private void Thunderstore_List_LayoutUpdated(object sender, EventArgs e)
        {
            if(Thunderstore_List.Visibility != Visibility.Visible || _updater == null && itemsList.Count() ==0 ){
                Reload_BTTN.Visibility = Visibility.Visible;
                Loading_Ring.Visibility = Visibility.Visible;


            }
            else
            {
                Reload_BTTN.Visibility = Visibility.Collapsed;

            }
        }
    }

}
