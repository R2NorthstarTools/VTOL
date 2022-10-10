using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using VTOL;

using Downloader;
using Path = System.IO.Path;
using System.IO.Compression;
using Serilog;
using System.Globalization;
using System.Threading.Tasks.Dataflow;
using Threading;
using System.Windows.Threading;
using System.Diagnostics;
using ZipFile = Ionic.Zip.ZipFile;
using System.Reflection;
namespace VTOL.Pages
{
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
                        ZipFile zipFile = new ZipFile(Zip_Path);

                        zipFile.ExtractAll(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR", Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        //Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";

                    }
                    else
                    {

                        Directory.CreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR");
                        current_skin_folder = User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR";

                        ZipFile zipFile = new ZipFile(Zip_Path);

                        zipFile.ExtractAll(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR", Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

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

                        //Console.WriteLine(i);
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
                Directory.Delete(current_skin_folder);






            }
            catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }

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
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
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

        public Page_Thunderstore()
        {
            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;
            DocumentsFolder = Main.DocumentsFolder;
            SnackBar = Main.Snackbar;
            Options_List.Add("Skins");
            Options_List.Add("Mods");
            Options_List.Add("Client-side");
            Options_List.Add("Server-side");
            Options_List.Add("Custom Menus");
            Options_List.Add("Language: EN");
            Options_List.Add("Language: CN");
            Options_List.Add("DDS");

            Search_Filters.ItemsSource = Options_List;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {



                Call_Ts_Mods();


            };
            worker.RunWorkerCompleted += (sender, eventArgs) =>
            {

                Loading_Ring.Visibility = Visibility.Hidden;


            };
            worker.RunWorkerAsync();






            //Log.Logger = new LoggerConfiguration()
            //     .MinimumLevel.Debug()
            //     .WriteTo.Console()
            //     .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            //     .CreateLogger();

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
        private childItem FindVisualChild<childItem>(DependencyObject obj)
    where childItem : DependencyObject
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
            ContentPresenter myListBoxItem =
(ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
            Grid GridPanel_ = FindVisualChild<Grid>(myListBoxItem);

            if (GridPanel_.Opacity >= 1)
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
            else if (GridPanel_.Opacity < 1)
            {

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
            else
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

        private void mask_MouseLeave(object sender, MouseEventArgs e)
        {
            ContentPresenter myListBoxItem =
(ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
            Grid GridPanel_ = FindVisualChild<Grid>(myListBoxItem);
            bool mouseIsDown = System.Windows.Input.Mouse.RightButton == MouseButtonState.Pressed;
            if (mouseIsDown == true)
            {

                if (GridPanel_.Opacity >= 1)
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
                else if (GridPanel_.Opacity < 1)
                {

                    DoubleAnimation da = new DoubleAnimation
                    {
                        From = GridPanel_.Opacity,
                        To = 0,
                        Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                        AutoReverse = false
                    };
                    GridPanel_.BeginAnimation(OpacityProperty, da);
                    GridPanel_.IsEnabled = true;

                }
                else
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
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid Card;
            if (sender.GetType() == typeof(Grid))
            {
                //                ContentPresenter myListBoxItem =
                //(ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
                Card = sender as Grid;

                HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);
                Wpf.Ui.Controls.CardAction Card_Action = FindVisualChild<Wpf.Ui.Controls.CardAction>(Card);

                if (GridPanel_.Opacity < 1)
                {
                    if(Card_Action != null)
                    {
                        if(Card_Action.ToolTip.ToString().Replace("northstar-Northstar","").Count() > 1)
                        { 
                            Card_Action.IsEnabled = true;
                            Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultipleCheckmark20;
                            Card_Action.IconForeground = Brushes.LawnGreen;
                        }
                        else
                        {
                            Card_Action.IsEnabled = false;
                            Card_Action.Icon = Wpf.Ui.Common.SymbolRegular.BoxMultiple20;

                        }
                    }
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
        private void Search_Bar_Suggest_Mods_GotFocus(object sender, RoutedEventArgs e)
        {
            Search_Bar_Suggest_Mods.IsReadOnly = false;
            if (Search_Bar_Suggest_Mods.Text.Trim() == "~Search")
            {
                Search_Bar_Suggest_Mods.Text = "";
            }
        }

        private void Search_Bar_Suggest_Mods_LostFocus(object sender, RoutedEventArgs e)
        {
            //  Search_Bar_Suggest_Mods.Text = "Search";
            Search_Bar_Suggest_Mods.IsReadOnly = true;
            if (Search_Bar_Suggest_Mods.Text.Trim() == "")
            {
                Search_Bar_Suggest_Mods.Text = "~Search";
            }

        }
        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid Card;
            if (sender.GetType() == typeof(Grid))
            {
                //                ContentPresenter myListBoxItem =
                //(ContentPresenter)(Thunderstore_List.ItemContainerGenerator.ContainerFromItem(Thunderstore_List.Items.CurrentItem));
                Card = sender as Grid;

                HandyControl.Controls.SimplePanel GridPanel_ = FindVisualChild<HandyControl.Controls.SimplePanel>(Card);
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
        
        
           public async Task Call_Ts_Mods(bool hard_refresh = true, List<string> Filter_Type = null, bool Search_ = false, string SearchQuery = "#")
        {
           
            

                try
                {
               


                    DispatchIfNecessary(() => {
                        Loading_Ring.Visibility = Visibility.Visible;

                    });

                    List<Grid_> List = null;
                _updater = new Updater("https://northstar.thunderstore.io/api/v1/package/");

                var NON_UI = new Thread(() =>
                {
                        _updater.Download_Cutom_JSON();
                    if(_updater.Thunderstore != null)
                    {
                        if (_updater.Thunderstore.Count() > 0)
                        {
                            List = LoadListViewData(Filter_Type, Search_, SearchQuery.Replace(" ", "_"));

                        }
                    }
                    else //Dont Scream...i know it looks bad, but hey, now more crashing if you swap windows quick now :D.
                    {
                        _updater.Download_Cutom_JSON();
                        if (_updater.Thunderstore != null)
                        {
                            if (_updater.Thunderstore.Count() > 0)
                            {
                                List = LoadListViewData(Filter_Type, Search_, SearchQuery.Replace(" ", "_"));

                            }
                        }
                    }
                    
                });
                NON_UI.IsBackground = true;

                NON_UI.Start();
                NON_UI.Join();
                DispatchIfNecessary(() => {

                        Thunderstore_List.ItemsSource = List;
                        Thunderstore_List.Items.Refresh();
                        Loading_Ring.Visibility = Visibility.Hidden;

                    });

                   




                    init = true;





            }
                catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();


                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }
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

        private List<Grid_> LoadListViewData(List<string> Filter_Type = null, bool Search_ = false, string SearchQuery = "#")
        {

            try
            {
             

                itemsList.Clear();
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
                
              
                    if (Current_Mod_Filter_Tags != null)
                    {
                        Current_Mod_Filter_Tags = Current_Mod_Filter_Tags.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    }
                    for (int i = 0; i < _updater.Thunderstore.Length; i++)
                    {

                        if ( _updater.Thunderstore[i].FullName.Contains("r2modman") )
                        {
                            continue;
                        }

                        int rating = _updater.Thunderstore[i].RatingScore;

                        Tags = String.Join(" , ", _updater.Thunderstore[i].Categories);


                        List<versions> versions = _updater.Thunderstore[i].versions;
                        if(Current_Mod_Filter_Tags != null && Current_Mod_Filter_Tags.Count > 0)
                        {


                            if (_updater.Thunderstore[i].Categories.Select(x => x)
                             .Intersect(Current_Mod_Filter_Tags).Any()
                              )
                            {
                                if (Search_ == true)
                                {





                                    if (_updater.Thunderstore[i].Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) || _updater.Thunderstore[i].Owner.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                                    {

                                        foreach (var items in versions)


                                        {


                                            Downloads.Add(Convert.ToInt32(items.Downloads));



                                        }



                                        downloads = (Downloads.Sum()).ToString();
                                        for (var x = 0; x < versions.First().Dependencies.Count; x++)
                                        {
                                            if (versions.First().Dependencies[x].Contains("northstar-Northstar")  || versions.First().Dependencies[x].Contains("r2modman"))
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



                                        if (int.TryParse(FileSize, out int value))
                                        {
                                            FileSize = Convert_To_Size(value);
                                        }

                                        itemsList.Add(new Grid_ { Name = _updater.Thunderstore[i].Name.Replace("_", " ") + "-" + versions.First().VersionNumber, Icon = ICON, date_created = _updater.Thunderstore[i].DateCreated.ToString(), description = Descrtiption, owner = _updater.Thunderstore[i].Owner, Rating = rating, download_url = download_url + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber + "|" + Tags + "|" + Dependencies_, Webpage = _updater.Thunderstore[i].PackageUrl, File_Size = FileSize, Tag = Tags, Downloads = downloads, Dependencies = Dependencies_, FullName = _updater.Thunderstore[i].FullName });
                                    
                                    
                                    //itemsList.OrderBy(ob => ob.).ToArray();


                                }


                                }
                                else
                                {




                                    foreach (var items in versions)


                                    {
                                        Downloads.Add(Convert.ToInt32(items.Downloads));



                                    }



                                    downloads = (Downloads.Sum()).ToString();
                                    for (var x = 0; x < versions.First().Dependencies.Count; x++)
                                    {
                                        if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("r2modman"))
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


                                    if (int.TryParse(FileSize, out int value))
                                    {
                                        FileSize = Convert_To_Size(value);
                                    }
                                    itemsList.Add(new Grid_ { Name = _updater.Thunderstore[i].Name.Replace("_"," ") + "-" + versions.First().VersionNumber, Icon = ICON, date_created = _updater.Thunderstore[i].DateCreated.ToString(), description = Descrtiption, owner = _updater.Thunderstore[i].Owner, Rating = rating, download_url = download_url + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber + "|" + Tags + "|" + Dependencies_, Webpage = _updater.Thunderstore[i].PackageUrl, File_Size = FileSize, Tag = Tags, Downloads = downloads, Dependencies = Dependencies_, FullName = _updater.Thunderstore[i].FullName });

                                }
                            }
                        }
                        else
                        {

                            if (Search_ == true)
                            {





                                if (_updater.Thunderstore[i].Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) || _updater.Thunderstore[i].Owner.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                                {

                                    foreach (var items in versions)


                                    {


                                        Downloads.Add(Convert.ToInt32(items.Downloads));



                                    }



                                    downloads = (Downloads.Sum()).ToString();
                                    for (var x = 0; x < versions.First().Dependencies.Count; x++)
                                    {
                                        if (versions.First().Dependencies[x].Contains("northstar-Northstar") || versions.First().Dependencies[x].Contains("r2modman"))
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



                                    if (int.TryParse(FileSize, out int value))
                                    {
                                        FileSize = Convert_To_Size(value);
                                    }

                                    itemsList.Add(new Grid_ { Name = _updater.Thunderstore[i].Name.Replace("_", " ") + "-" + versions.First().VersionNumber, Icon = ICON, date_created = _updater.Thunderstore[i].DateCreated.ToString(), description = Descrtiption, owner = _updater.Thunderstore[i].Owner, Rating = rating, download_url = download_url + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber + "|" + Tags + "|" + Dependencies_, Webpage = _updater.Thunderstore[i].PackageUrl, File_Size = FileSize, Tag = Tags, Downloads = downloads, Dependencies = Dependencies_, FullName = _updater.Thunderstore[i].FullName });



                                }


                            }
                            else
                            {




                                foreach (var items in versions)


                                {
                                    Downloads.Add(Convert.ToInt32(items.Downloads));



                                }



                                downloads = (Downloads.Sum()).ToString();
                                for (var x = 0; x < versions.First().Dependencies.Count; x++)
                                {
                                    if (versions.First().Dependencies[x].Contains("northstar-Northstar")  || versions.First().Dependencies[x].Contains("r2modman"))
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


                                if (int.TryParse(FileSize, out int value))
                                {
                                    FileSize = Convert_To_Size(value);
                                }
                                itemsList.Add(new Grid_ { Name = _updater.Thunderstore[i].Name.Replace("_", " ") + "-" + versions.First().VersionNumber, Icon = ICON, date_created = _updater.Thunderstore[i].DateCreated.ToString(), description = Descrtiption, owner = _updater.Thunderstore[i].Owner, Rating = rating, download_url = download_url + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber + "|" + Tags + "|" + Dependencies_, Webpage = _updater.Thunderstore[i].PackageUrl, File_Size = FileSize, Tag = Tags, Downloads = downloads, Dependencies = Dependencies_, FullName = _updater.Thunderstore[i].FullName });

                            }


                        }



                       
                        


                            

                        }
                      

                    
                

                }
            catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return  itemsList;

        }
        public string Search_For_Mod_Thunderstore(string SearchQuery = "None")

        {
            try { 
            _updater = new VTOL.Updater("https://northstar.thunderstore.io/api/v1/package/");

            _updater.Download_Cutom_JSON();

            for (int i = 0; i < _updater.Thunderstore.Length; i++)
            {
                List<versions> versions = _updater.Thunderstore[i].versions;

                string[] subs = SearchQuery.Split('-');
                    Console.WriteLine(subs[1]);
                if (_updater.Thunderstore[i].FullName.Contains(subs[1], StringComparison.OrdinalIgnoreCase) || _updater.Thunderstore[i].Owner.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase))
                {

                    return versions.First().DownloadUrl + "|" + _updater.Thunderstore[i].Name + "-" + versions.First().VersionNumber;

                }
              


            }
            }
            catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_COMMON_LOG"));

            }
            return null;
        }
        class LIST_JSON
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


        }
      
        private void DownloadProgressCallback4(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            //////Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", (string)e.UserState, e.BytesReceived,e.TotalBytesToReceive,e.ProgressPercentage);

            //Mod_Progress_BAR.Value = e.ProgressPercentage;
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
        void downloader_ProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e, ProgressBar Progress_Bar)
        {

            DispatchIfNecessary(() => {

                Progress_Bar.Value = (e.ProgressPercentage);
            });

            //lblTotalBytesReceived.Text = string.Format("{0} / {1}",
            //e.TotalBytesReceived.ToHumanReadableSize(),
            //    downloader.Info.Length > 0 ? downloader.Info.Length.ToHumanReadableSize() : "Unknown");
            //lblProgress.Text = e.Progress.ToString("0.00") + "%";
            //lblSpeed.Text = e.SpeedInBytes.ToHumanReadableSize() + "/s";
            //progressBar.Value = (int)(e.Progress * 100);
        }
        
        void downloader_DownloadCompleted(object sender, AsyncCompletedEventArgs e, ProgressBar Progress_Bar, string Mod_Name, string Location, bool Skin_Install, bool NS_CANDIDATE_INSTALL)
        {
            Console.WriteLine(Location);
            if (NS_CANDIDATE_INSTALL == true)
            {

                Unpack_To_Location_Custom(Location, User_Settings_Vars.NorthstarInstallLocation + @"Northstar_TEMP_FILES\", Progress_Bar, true, false, Skin_Install, NS_CANDIDATE_INSTALL);

            }
            else
            {
                Unpack_To_Location_Custom(Location, User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\" + Mod_Name, Progress_Bar, true, false, Skin_Install, NS_CANDIDATE_INSTALL);
            }
          
        }
        async Task Download_Zip_To_Path(string url, string path, ProgressBar Progress_Bar = null, bool Skin_Install_ = false, bool NS_CANDIDATE_INSTALL = false)
        {
            await Task.Run(() =>
            {
                DispatchIfNecessary(() => {
                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {
                    string[] words = url.Split("|");

                    //HttpDownloader downloader = new HttpDownloader(url, path);
                    IDownload downloader = DownloadBuilder.New()
    .WithUrl(words[0])
    .WithDirectory(path)
    .WithFileName(words[1] + ".zip")
    .WithConfiguration(new DownloadConfiguration())

    .Build();

                    if (Progress_Bar != null)
                    {
                        Console.WriteLine("Started_To_Donwload_The_Data_At_URL__" + url);



                        //download.DownloadProgressChanged += DownloadProgressChanged;
                        //download.DownloadFileCompleted += DownloadFileCompleted;
                        //download.DownloadStarted += DownloadStarted;
                        //download.ChunkDownloadProgressChanged += ChunkDownloadProgressChanged;
                        downloader.DownloadProgressChanged += delegate (object sender2, Downloader.DownloadProgressChangedEventArgs e2)
                        {
                            
                            downloader_ProgressChanged(sender2, e2, Progress_Bar);
                    };
                    }
                    var Destinfo = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation);
                    //downloader.ErrorOccured += delegate (object sender3, ErrorEventArgs e3)
                    //{
                    //    downloader_ErrorOccured(sender3, e3);
                    //};

                    downloader.DownloadFileCompleted += delegate (object sender4, AsyncCompletedEventArgs e4)
                    {
                       

                        downloader_DownloadCompleted(sender4, e4, Progress_Bar, words[1], Destinfo.FullName + @"NS_Downloaded_Mods\" + words[1] + ".zip",Skin_Install_,NS_CANDIDATE_INSTALL);
                    };

                    downloader.StartAsync();



                        //downloader.Start();
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
        void Dependency_Download( string Dependencies_To_Find_And_Download,ProgressBar Progress_Bar = null)
        {
            Loaded_Async_Handler = true;
            try
            {

                List<string> Mods = new List<string>();
                Mods = Dependencies_To_Find_And_Download?.Split("\n").ToList();
                List<string> Links = new List<string>();

                foreach (var x in Mods)
                {

                    string URL = Search_For_Mod_Thunderstore(x);

                    if (Is_Valid_URl(URL))
                    {
                        Links.Add(URL);




                    }

                }

                var queue = new SerialQueue();


                //Console.WriteLine(String.Join("\n\n\n", Links));



                queue.Enqueue(async () =>
                {
                    foreach (var y in Links)
                    {
                        Download_Zip_To_Path(y, User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods", Progress_Bar);
                        Thread.Sleep(2500);
                    }

                });




            }
            catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            Dialog.Hide();

        }
        bool Loaded_Async_Handler = false;
        string pack = null;
      

        private void CardAction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProgressBar Progress_Bar = null;
                HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Wpf.Ui.Controls.CardAction)sender).Parent;
                Progress_Bar = FindVisualChild<ProgressBar>(_Panel);
                var Tag_Data_ = ((Wpf.Ui.Controls.CardAction)sender).ToolTip.ToString();
                var Name_Data = ((Wpf.Ui.Controls.CardAction)sender).Tag.ToString();
               
               string Tag_Data = "\n" + (Tag_Data_.Replace(",", "\n").Replace(" ", "") + "\n\n"+VTOL.Resources.Languages.Language.Page_Thunderstore_CardAction_Click_DoYouWantToInstallTheseAndTheMod+"\n" + Name_Data  +   "?").Trim();
                if (Tag_Data.Count() > 5)
            {
                Dialog.Title = Name_Data + " - Dependencies";
                
                Dialog.DialogHeight = 350;
                Dialog.Message = Tag_Data;
                Dialog.ButtonLeftName = "Yes";
                Dialog.ButtonRightName = "Cancel";
                Dialog.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                Dialog.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Caution;
                    
                     
                        Dialog.Tag = ((Tag_Data_ + " ,"+Name_Data.Trim()).Replace(",", "\n").Replace(" ", "")) ;
                    
                        Progress_Cur_Temp = Progress_Bar;
                    
                        Dialog.Show();

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
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subdirs = directory.GetDirectories();

            return (files.Length == 0 && subdirs.Length == 0);
        }
        private void Clear_Folder(string FolderName)
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
        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                if (!File.Exists(targetPath))
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath),true);

                }
                else
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

                }
            }
        }
        public async Task Unpack_To_Location_Custom(string Target_Zip, string Destination, ProgressBar Progress_Bar, bool Clean_Thunderstore = false, bool clean_normal = false, bool Skin_Install = false,bool NS_CANDIDATE_INSTALL = false)
        {
            //ToDo Check if url or zip location
            //add drag and drop

            try
            {
                string Dir_Final = null;
                if (File.Exists(Target_Zip))
                {

                    if (!Directory.Exists(Destination))
                    {
                        Directory.CreateDirectory(Destination);
                    }
                    if (Directory.Exists(Destination))
                    {
                        if (NS_CANDIDATE_INSTALL == false)
                        {
                            Clear_Folder(Destination);
                        }
                        string fileExt = System.IO.Path.GetExtension(Target_Zip);
                        ////Console.WriteLine("It only works if i have this line :(");

                        if (fileExt == ".zip")
                        {
                            ZipFile zipFile = new ZipFile(Target_Zip);

                            zipFile.ExtractAll(Destination, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                            
                            if (Clean_Thunderstore == true)
                            {



                                // Check if file exists with its full path    
                                if (File.Exists(Path.Combine(Destination, "icon.png")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "icon.png"));
                                }
                                else {/* Send_Warning_Notif(GetTextResource("NOTIF_WARN_CLEANUP_FILES_NOT_FOUND"));*/ }
                                if (File.Exists(Path.Combine(Destination, "manifest.json")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "manifest.json"));
                                }
                                else { /*Send_Warning_Notif(GetTextResource("NOTIF_WARN_CLEANUP_FILES_NOT_FOUND"));*/ }

                                if (File.Exists(Path.Combine(Destination, "README.md")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "README.md"));
                                }
                                else { /*Send_Warning_Notif(GetTextResource("NOTIF_WARN_CLEANUP_FILES_NOT_FOUND"));*/ }






                                if (Skin_Install == false)
                                {
                                    string searchQuery3 = "*" + "mod.json" + "*";

                                    //  string[] list = Directory.GetFiles(Destination, "*mod.json*",
                                    //      SearchOption.AllDirectories);
                                    var Destinfo = new DirectoryInfo(Destination);


                                    var Script = Destinfo.GetFiles(searchQuery3, SearchOption.AllDirectories);
                                    Destinfo.Attributes &= ~FileAttributes.ReadOnly;
                                    Console.WriteLine(Script.Length.ToString());
                                    //foreach(var File in Script)
                                    if (Script.Length != 0)
                                    {
                                        var File_ = Script.FirstOrDefault();


                                        FileInfo FolderTemp = new FileInfo(File_.FullName);
                                        DirectoryInfo di = new DirectoryInfo(Directory.GetParent(File_.FullName).ToString());
                                        string firstFolder = di.FullName;

                                        if (Directory.Exists(Destination))
                                        {




                                            Directory.CreateDirectory(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");
                                            if (Directory.Exists(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder"))
                                            {
                                                CopyFilesRecursively(firstFolder, Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");




                                                Clear_Folder(Destination);
                                                CopyFilesRecursively(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", Destination);
                                                Directory.Delete(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", true);

                                            }
                                            Console.WriteLine("Unpacked - " + Destination);


                                        }
                                    }
                                    else if (Script.Length > 1)
                                    {
                                        foreach (var x in Script)
                                        {

                                            Console.WriteLine(x.FullName);
                                        }
                                        Console.WriteLine("MULTIPACK - " + Destination);






                                    }
                                    else
                                    {
                                        //Too many or no mods?

                                    }
                                     DispatchIfNecessary(() => {
                                        if (Progress_Bar != null)
                                        {
                                            Progress_Bar.Value = 0;
                                        }
                                         
                                         SnackBar.Title = "SUCCESS";
                                        SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                        SnackBar.Message = "The Mod " + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                        SnackBar.Show();


                                    });

                                }

                                else if(NS_CANDIDATE_INSTALL == true)
                                {
                                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Client\Locked_Folder"))
                                    {
                                        Directory.Delete(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Client\Locked_Folder", true);

                                    }
                                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Custom\Locked_Folder"))
                                    {
                                        Directory.Delete(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.Custom\Locked_Folder", true);


                                    }
                                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\Locked_Folder"))
                                    {
                                        Directory.Delete(User_Settings_Vars.NorthstarInstallLocation  + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\Locked_Folder", true);


                                    }
                                    if (!Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder"))
                                    {
                                        Directory.CreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder");
                                    }

                                    if (do_not_overwrite_Ns_file == true)
                                    {
                                      
                                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt"))
                                            {
                                                System.IO.File.Copy(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt",User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt", true);
                                            }

                                        


                                    
                                        if (File.Exists(User_Settings_Vars.NorthstarInstallLocation +  User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg"))
                                        {

                                            System.IO.File.Copy(User_Settings_Vars.NorthstarInstallLocation +  User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg", User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg", true);



                                        }


                                    
                                        if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt"))
                                        {


                                            System.IO.File.Copy(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt", User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt", true);


                                        }

                                    }
                                    string searchQuery3 = "*" + "Northstar.dll" + "*";

                                    var Destinfo = new DirectoryInfo(Destination);
                                    var Script_ = Directory.GetFiles(Destination);
                                    Console.WriteLine(String.Join("\n", Script_));


                                    var Script = Destinfo.GetFiles(searchQuery3, SearchOption.AllDirectories);
                                    Destinfo.Attributes &= ~FileAttributes.ReadOnly;
                                    Console.WriteLine(Script.Length.ToString());


                                    if (Script.Length != 0)
                                    {
                                           var File_ = Script.FirstOrDefault();


                                        FileInfo FolderTemp = new FileInfo(File_.FullName);
                                        DirectoryInfo di = new DirectoryInfo(Directory.GetParent(File_.FullName).ToString());
                                        string firstFolder = di.FullName;
                                        Console.WriteLine(firstFolder);

                                        if (Directory.Exists(Destination))
                                        {



                                           




                                            CopyFilesRecursively(firstFolder, User_Settings_Vars.NorthstarInstallLocation);

                                            }
                                            Console.WriteLine("Unpacked - " + Destination);
                                             Directory.Delete(Destination,true);

                                        if (do_not_overwrite_Ns_file == true)
                                        {
                                          
                                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt"))
                                                {
                                                    System.IO.File.Copy(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args.txt", User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args.txt", true);
                                                }

                                            


                                       
                                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg"))
                                            {

                                                System.IO.File.Copy (User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\autoexec_ns_server.cfg",User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg",true);



                                            }


                                        
                                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt"))
                                            {


                                                System.IO.File.Copy(User_Settings_Vars.NorthstarInstallLocation + @"TempCopyFolder\ns_startup_args_dedi.txt", User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt", true);


                                            }

                                        }

                                        DispatchIfNecessary(() => {
                                            if (Progress_Bar != null)
                                            {
                                                Progress_Bar.Value = 0;
                                            }
                                            if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"NorthstarLauncher.exe"))
                                            {

                                                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(User_Settings_Vars.NorthstarInstallLocation + @"NorthstarLauncher.exe");

                                                string Current_Ver_ = myFileVersionInfo.FileVersion;

                                                User_Settings_Vars.CurrentVersion = Current_Ver_;
                                                Properties.Settings.Default.Version = Current_Ver_;
                                                Properties.Settings.Default.Save();
                                                DispatchIfNecessary(() =>
                                                {

                                                    Main.VERSION_TEXT.Text = "VTOL - " + ProductVersion + " | Northstar Version - " + Current_Ver_.Remove(0, 1);
                                                    Main.VERSION_TEXT.Refresh();
                                                });
                                            }

                                            SnackBar.Title = "SUCCESS";
                                            SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                            SnackBar.Message = "The Build " + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                            SnackBar.Show();


                                        });

                                    }

                                }
                                else if(Skin_Install == true)
                                {
                                    var ext = new List<string> { "zip" };
                                    var myFiles = Directory.EnumerateFiles(Destination, "*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));

                                    Install_Skin_Async_Starter(myFiles, Destination);
                                    DispatchIfNecessary(() =>
                                    {
                                        if (Progress_Bar != null)
                                        {
                                            Progress_Bar.Value = 0;
                                        }
                                    });
                                    }




                            }
                            else
                            {

                                string fileExts = System.IO.Path.GetExtension(Target_Zip);

                                if (fileExts == ".zip")
                                {
                                    string searchQuery3 = "*" + "mod.json" + "*";

                                   
                                    var Destinfo = new DirectoryInfo(Destination);


                                    var Script = Destinfo.GetFiles(searchQuery3, SearchOption.AllDirectories);
                                    Destinfo.Attributes &= ~FileAttributes.ReadOnly;
                                    Console.WriteLine(Script.Length.ToString());
                                    if (Script.Length != 0)
                                    {
                                        var File_ = Script.FirstOrDefault();

                                       

                                        FileInfo FolderTemp = new FileInfo(File_.FullName);
                                        DirectoryInfo di = new DirectoryInfo(Directory.GetParent(File_.FullName).ToString());
                                        string firstFolder = di.FullName;

                                        if (Directory.Exists(Destination))
                                        {




                                            Directory.CreateDirectory(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");
                                            if (Directory.Exists(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder"))
                                            {
                                                CopyFilesRecursively(firstFolder, Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");




                                                Clear_Folder(Destination);
                                                CopyFilesRecursively(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", Destination);
                                                Directory.Delete(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", true);

                                            }
                                            Console.WriteLine("Unpacked - " + Destination);


                                        }
                                    }
                                    else if (Script.Length > 1)
                                    {
                                        foreach (var x in Script)
                                        {

                                            Console.WriteLine(x.FullName);
                                        }
                                        Console.WriteLine("MULTIPACK - " + Destination);

                                       



                                    }
                                    else
                                    {
                                        //Too many or no mods?

                                    }

                                }
                                else
                                {
                                    Log.Warning("The File" + Target_Zip + "Is not a zip!!");
                                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                                    SnackBar.Content = "The File " + Target_Zip + " Is noT a zip!!";


                                }

                                DispatchIfNecessary(() => {
                                    if (Progress_Bar != null)
                                    {
                                        Progress_Bar.Value = 0;
                                    }
                                   
                                        SnackBar.Title = "SUCCESS";
                                        SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                                        SnackBar.Message = "The Mod " + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + VTOL.Resources.Languages.Language.Page_Thunderstore_Unpack_To_Location_Custom_HasBeenDownloadedAndInstalled;
                                        SnackBar.Show();

                                    

                                });
                            }

                            
                        }
                        else
                        {

                            Log.Warning("The File" + Target_Zip + "Is noT a zip!!");
                            SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            SnackBar.Content = "The File " + Target_Zip + " Is noT a zip!!";
                            DispatchIfNecessary(() =>
                            {
                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                            });
                        }



                    }

                    else
                    {

                        if (!File.Exists(Target_Zip))
                        {
                            DispatchIfNecessary(() =>
                            {
                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                            });
                            Log.Error("The Zip File" + Target_Zip + " was not found or does not exist?");


                        }
                        if (!Directory.Exists(Destination))
                        {
                            DispatchIfNecessary(() =>
                            {
                                if (Progress_Bar != null)
                                {
                                    Progress_Bar.Value = 0;
                                }
                            });
                            Log.Error("The Destination" + Destination + " is not accessible or does not exist?");


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();

                DispatchIfNecessary(() =>
                {
                    if (Progress_Bar != null)
                    {
                        Progress_Bar.Value = 0;
                    }
                });
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }
        public static String ProductVersion
        {
            get
            {
                return new Version(FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion).ToString();
            }
        }
        async Task Install_Skin_Async_Starter(IEnumerable<string> in_, string Destination = "")
        {
          
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {


                foreach (string i in in_)
                {
                    DispatchIfNecessary(() =>
                    {
                        Skin_Processor_ Skinp = new Skin_Processor_();


                         Skinp.Install_Skin_From_Path(i);

                      
                    });
                    await Task.Delay(1500);


                }

                if (Directory.Exists(Destination) && Destination != "")
                {
                    Directory.Delete(Destination, true);
                }
            });
        }
        private void ScrollViewer_MouseEnter(object sender, MouseEventArgs e)
        {

          

            }

      


    
        private void Install_Bttn_Thunderstore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button Button;
                Button = sender as Button;
                ProgressBar Progress_Bar = null;
                HandyControl.Controls.SimplePanel _Panel = (HandyControl.Controls.SimplePanel)((Button)sender).Parent;
                Progress_Bar = FindVisualChild<ProgressBar>(_Panel);
                if (Button.Tag.ToString().Contains("http"))
                {
                    Console.WriteLine(Button.Tag.ToString());
                    if (Button.ToolTip.ToString().Contains("DDS"))
                    {

                        Download_Zip_To_Path(Button.Tag.ToString(), User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods", Progress_Bar, true);

                    }
                    else if(Button.Tag.ToString().Contains("Northstar Release Candidate") || Button.Tag.ToString().Contains("NorthstarReleaseCandidate") || (Button.Tag.ToString().Contains("Northstar") && Button.ToolTip.ToString().Count() < 5))
                    {
                        Download_Zip_To_Path(Button.Tag.ToString(), User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods", Progress_Bar, true,true);


                    }
                    else
                    {
                        Download_Zip_To_Path(Button.Tag.ToString(), User_Settings_Vars.NorthstarInstallLocation + @"NS_Downloaded_Mods", Progress_Bar, false);

                    }



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

        private void Search_Bar_Suggest_Mods_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {


            
            if (init == true)
            {

                if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text.Trim() != "~Search")
                {
                    Thunderstore_List.ItemsSource = null;

                    //BackgroundWorker worker = new BackgroundWorker();

                  


                        Call_Ts_Mods(true, Search_: true, SearchQuery: Search_Bar_Suggest_Mods.Text);



                        Thunderstore_List.Refresh();


                  


                }
                else
                {
                    Thunderstore_List.ItemsSource = null;








                        Call_Ts_Mods();





                    




                }

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

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Dialog_ButtonLeftClick(object sender, RoutedEventArgs e)
        {
          
            Dependency_Download( Dialog.Tag.ToString(), Progress_Cur_Temp);

        }

        private void Search_Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
            {
                HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                Current_Mod_Filter_Tags = String.Join(",", comboBox.SelectedItems.Cast<String>()).Split(',').ToList();
                Thunderstore_List.ItemsSource = null;
                if(Search_Filters.SelectedItems != null && Search_Filters.SelectedItems.Count > 0) /*|| Options_List.Contains(Search_Filters.SelectedItem))*/
                {
                    Filter_Label.Visibility= Visibility.Hidden;
                }
                else
                {
                    Filter_Label.Visibility = Visibility.Visible;

                }
                Console.WriteLine(String.Join(",", Current_Mod_Filter_Tags));

               BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {



                Call_Ts_Mods();


            };
            worker.RunWorkerCompleted += (sender, eventArgs) =>
            {

                Thunderstore_List.Refresh();


            };
            worker.RunWorkerAsync();





               



               

                    
                }


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

                Thread.Sleep(2000);
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            });
            });
        }
        private void Auto_Scroll_Description(Canvas canMain, TextBlock tbmarquee)
        {
            double width = canMain.ActualWidth - tbmarquee.ActualWidth;
            double H = tbmarquee.ActualHeight - canMain.ActualHeight;
            Console.WriteLine(H);
            tbmarquee.Margin = new Thickness(width / 2, 0, 0, 0);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = tbmarquee.ActualHeight;
            doubleAnimation.To = tbmarquee.ActualHeight + H;
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            doubleAnimation.AutoReverse = true;
            doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            tbmarquee.BeginAnimation(Canvas.TopProperty, doubleAnimation);
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
    }
        
}
