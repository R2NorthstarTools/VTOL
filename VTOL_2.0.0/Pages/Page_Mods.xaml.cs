using Ionic.Zip;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Common.Interfaces;
using Path = System.IO.Path;
using VTOL;

namespace VTOL.Pages
{
    public class Card_ : INotifyPropertyChanged
    {
        public string Mod_Name;
        public string Mod_Date;
        public string Label;
        public bool Is_Active;
        public string En_Di;

        public string Is_Active_Color;
        public string Size__;
        public string Mod_Path;
        public string IS_CORE_MOD;

        public string Mod_Path_
        {

            get { return Mod_Path; }
            set { Mod_Path = value; NotifyPropertyChanged("Mod_Path"); }
        }
        public string Mod_Name_
        {

            get { return Mod_Name; }
            set { Mod_Name = value; NotifyPropertyChanged("Mod_Name"); }
        }
        public string Mod_Date_
        {

            get { return Mod_Date; }
            set { Mod_Date = value; NotifyPropertyChanged("Mod_Date"); }
        }
        public string En_Di_
        {

            get { return En_Di; }
            set { En_Di = value; NotifyPropertyChanged("En_Di"); }
        }
        public string Label_
        {

            get { return Label; }
            set { Label = value; NotifyPropertyChanged("Label"); }
        }

        public bool Is_Active_
        {

            get { return Is_Active; }
            set { Is_Active = value; NotifyPropertyChanged("Is_Active"); }
        }
        public string Is_Active_Color_
        {

            get { return Is_Active_Color; }
            set { Is_Active_Color = value; NotifyPropertyChanged("Is_Active_Color"); }
        }
        public string IS_CORE_MOD_
        {

            get { return IS_CORE_MOD; }
            set { IS_CORE_MOD = value; NotifyPropertyChanged("Is_Active_Color"); }
        }
        public string Size_
        {

            get { return Size__; }
            set { Size__ = value; NotifyPropertyChanged("Size__"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string Property)
        {

            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(Property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
    public static class ExtensionMethods
    {
        private static readonly Action EmptyDelegate = delegate { };
        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
    public static class Extension
    {
        public static List<T> Join<T>(this List<T> first, List<T> second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToList();
        }
    }
    /// <summary>
    /// Interaction logic for Page_Mods.xaml
    /// </summary>
    /// 

    public partial class Page_Mods : Page
    {

        User_Settings User_Settings_Vars = null;
        public MainWindow Main = GetMainWindow();

        public List<Card_> ModList_Enabled = new List<Card_>();
        public List<Card_> ModList_Disabled = new List<Card_>();
        List<Card_> Final_List = new List<Card_>();
        public bool _Completed_Mod_call = false;
        public bool Reverse_ = false;
        Wpf.Ui.Controls.Snackbar Snackbar;
        Updater _updater;

        public Page_Mods()
        {
            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;
            Snackbar = Main.Snackbar;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                //  Call_Mods_From_Folder();
                Check_Reverse(false);



            };

            worker.RunWorkerAsync();



            _Completed_Mod_call = true;

        }

        public class Card_
        {
            public string Mod_Path_ { get; set; }

            public string Mod_Name_ { get; set; }
            public string Mod_Date_ { get; set; }
            public string En_Di { get; set; }
            public bool Is_Active_ { get; set; }
            public string Is_Active_Color { get; set; }
            public string IS_CORE_MOD { get; set; }

            public string Size__ { get; set; }
            public int Flag { get; set; }
            public string Error_Tooltip { get; set; }
            public string Label { get; set; }


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
        private void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        async void Call_Mods_From_Folder_Lite()
        {

            try
            {

                if (User_Settings_Vars.NorthstarInstallLocation != null || User_Settings_Vars.NorthstarInstallLocation != "" || Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {

                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {


                        Main.Current_Installed_Mods.Clear();

                        string NS_Mod_Dir = User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods";

                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
                        if (IsValidPath(NS_Mod_Dir) == true)
                        {

                            System.IO.DirectoryInfo[] subDirs = null;
                            subDirs = rootDirs.GetDirectories();


                            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                            {


                                Main.Current_Installed_Mods.Add(dirInfo.Name.Trim());

                            }
                            Console.WriteLine("Finished_Mod_Load");
                            DispatchIfNecessary(() =>
                            {

                                ApplyDataBinding();
                            });
                        }



                    }


                }
            }
            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }

        }
        async void Call_Mods_From_Folder()
        {
            bool install_Prompt = false;
            string IS_CORE_MOD_temp = "#00000000";
            try
            {
               

                  
                Final_List.Clear();






                if (User_Settings_Vars.NorthstarInstallLocation == null || User_Settings_Vars.NorthstarInstallLocation == "" || !Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {




                }
                else
                {
                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {

                        if (User_Settings_Vars.CurrentVersion != "NODATA")
                        {

                            string NS_Mod_Dir = User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods";

                            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
                          
                             if (IsValidPath(NS_Mod_Dir) == true)
                            {

                                System.IO.DirectoryInfo[] subDirs = null;
                                subDirs = rootDirs.GetDirectories();

                                DispatchIfNecessary(() =>
                                {

                                    Mod_Count_Label.Content = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ModCount + subDirs.Length;
                                });
                                DispatchIfNecessary(() =>
                                {
                                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                                {
                                    if (Regex.IsMatch(dirInfo.Name.Trim(), @"^Northstar\.CustomServers\w{0,2}$") || Regex.IsMatch(dirInfo.Name.Trim(), @"^Northstar\.Custom\w{0,2}$") || Regex.IsMatch(dirInfo.Name.Trim(), @"^Northstar\.Client\w{0,2}$"))
                                    {
                                        IS_CORE_MOD_temp = "#FF8C7F24";

                                    }
                                    else
                                    {
                                        IS_CORE_MOD_temp = "#00000000";

                                    }
                                    if (Page_Home.IsDirectoryEmpty(dirInfo))
                                    {
                                        if (Page_Home.IsDirectoryEmpty(new DirectoryInfo(dirInfo.FullName)) == true)
                                        {
                                            TryDeleteDirectoryAsync(dirInfo.FullName, true);

                                        }

                                    }
                                    else if (Template_traverse(dirInfo, "Locked_Folder") == true)
                                    {


                                        if (Directory.Exists(dirInfo + @"\Locked_Folder") && Page_Home.IsDirectoryEmpty(new DirectoryInfo(dirInfo + @"\Locked_Folder")))
                                        {



                                            TryDeleteDirectoryAsync(dirInfo + @"\Locked_Folder");

                                        }
                                        int Flag_mod = 0;
                                        string ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ThereIsAnIssueDetectedWithYourMod;
                                        if (!File.Exists(dirInfo.FullName + @"\Locked_Folder" + @"\mod.json"))
                                        {
                                            ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_PleaseOpenYourFolderAt + dirInfo.Parent + VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_AndManuallyRepairTheMod + dirInfo.Name;
                                            Flag_mod = 100;
                                        }
                                        
                                        Final_List.Add(new Card_ { Mod_Name_ = dirInfo.Name.Trim(), Mod_Date_ = dirInfo.CreationTime.ToString(), Is_Active_Color = "#B29A0404", Size__ = dirInfo.LastAccessTime.ToString(), En_Di = "Enable", Is_Active_ = true, Mod_Path_ = dirInfo.FullName, Flag = Flag_mod, Error_Tooltip = ToolTip_Dynamic, Label = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_Enable ,IS_CORE_MOD = IS_CORE_MOD_temp });
                                    }
                                    else
                                    {
                                        int Flag_mod = 0;
                                        string ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ThereIsAnIssueDetectedWithYourMod;

                                        if (!File.Exists(dirInfo.FullName + @"\mod.json"))
                                        {

                                            ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_PleaseOpenYourFolderAt + dirInfo.Parent + VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_AndManuallyRepairTheMod + dirInfo.Name;

                                            Flag_mod = 100;
                                        }
                                        else
                                        {
                                            //string mod_Json = (dirInfo.FullName + @"\mod.json");
                                            string mod_Icon = (dirInfo.FullName + @"\icon.png");

                                            //if (File.Exists(mod_Json))
                                            //{
                                            //    var myJsonString = File.ReadAllText(mod_Json);
                                            //    dynamic myJObject = JObject.Parse(myJsonString);
                                            //    string name = myJObject.Name;
                                            //    string version = myJObject.Version;
                                            //   // string Description = myJObject.Description;
                                            //  //  string Content = Description + Environment.NewLine + version;

                                            //    MessageBox.Show(name + version);
                                            //}



                                        }

                                        Final_List.Add(new Card_ { Mod_Name_ = dirInfo.Name.Trim(), Mod_Date_ = dirInfo.CreationTime.ToString(), Is_Active_Color = "#B2049A28", Size__ = dirInfo.LastAccessTime.ToString(), En_Di = "Disable", Is_Active_ = false, Mod_Path_ = dirInfo.FullName, Flag = Flag_mod, Error_Tooltip = ToolTip_Dynamic, Label = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_Disable_, IS_CORE_MOD = IS_CORE_MOD_temp });


                                    }
                                    Main.Current_Installed_Mods.Add(dirInfo.Name.Trim());

                                }
                            });
                                DispatchIfNecessary(() =>
                                {

                                    ApplyDataBinding();
                                });
                            }

                        }

                    }


                }
               
            }
            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }


        }

		        public async Task<bool> TryDeleteDirectoryAsync(
        string directoryPath, bool overwrite = true,
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
		        public bool TryDeleteFile(
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
        public void Check_Updates_List()
        {
            try
            {
                Main.RootFrame.Navigate(new Page_Thunderstore());
                Main.RootNavigation.SelectedPageIndex = 4;
                Main.RootNavigation.Refresh();
                //foreach (Card_ item in Mod_List_Box.Items)
                //{



                //    string Name_ = item.Mod_Name_.ToString();
                //    string pattern = @"[^!]+(?=-)";
                //    Regex rg = new Regex(pattern);



                //        BackgroundWorker worker = new BackgroundWorker();
                //        worker.DoWork += (sender, e) =>
                //        {


                //              //  string x = Search_For_Mod_Thunderstore(Name_);


                //                  //  MessageBox.Show(x);



                //            //Page_Thunderstore PP = new Page_Thunderstore();
                //            //Main.RootFrame.Navigate(PP); //FrameContent is the name given to the frame within the xaml.
                //            //PP.Search_Bar_Suggest_Mods.Text = Name_;
                //            //PP.Call_Ts_Mods(true, Search_: true, SearchQuery: Name_);
                //            //PP.Thunderstore_List.Refresh();

                //            //DispatchIfNecessary(() =>

                //            //{
                //            //});


                //        };

                //        worker.RunWorkerAsync();






                //}






            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }


        }
        public bool Template_traverse(System.IO.DirectoryInfo root, String Search)
        {

            string outt = "";
            try
            {
                System.IO.DirectoryInfo[] subDirs = null;
                subDirs = root.GetDirectories();
                var last = subDirs.Last();
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    outt = dirInfo.FullName;
                    if (dirInfo.Name.Contains(Search))
                    {

                        return true;

                    }
                    else if (last.Equals(dirInfo))
                    {
                        return false;
                    }
                    else
                    {


                    }
                    if (dirInfo == null)
                    {
                        continue;

                    }
                    // Resursive call for each subdirectory.
                }


            }
            catch (Exception e)
            {
                Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


                if (e.Message == "Sequence contains no elements")
                {
                    System.IO.DirectoryInfo Dir = new DirectoryInfo(outt);

                    if (IsDirectoryEmpty(Dir))
                    {
                        TryDeleteDirectory(outt, true);
                    }
                }
                else
                {
                    System.IO.DirectoryInfo Dir = new DirectoryInfo(outt);

                    if (IsDirectoryEmpty(Dir))
                    {
                        TryDeleteDirectory(outt, true);
                    }

                }
            }


            return false;

        }
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subdirs = directory.GetDirectories();

            return (files.Length == 0 && subdirs.Length == 0);
        }
        public bool IsValidPath(string path, bool allowRelativePaths = false)
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
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                isValid = false;
            }

            return isValid;
        }
        private void ApplyDataBinding()
        {
            try
            {
                Mod_List_Box.ItemsSource = null;

                if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text.Trim() != "~Search")
                {
                    var sorted = Keep_List_State(true, Reverse_);
                    Mod_List_Box.ItemsSource = sorted;
                    _Completed_Mod_call = true;
                }
                else
                {

                    var sorted = Keep_List_State(false, Reverse_);
                    Mod_List_Box.ItemsSource = sorted;

                    _Completed_Mod_call = true;


                }

                Mod_List_Box.Refresh();
            }
            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        public void Move_Mods(string val, bool Enable_Disable)
        {

            try
            {

                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\"))
                {



                    if (val != null)
                    {
                        DirectoryInfo rootDirs = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val);

                        if (!Page_Home.IsDirectoryEmpty(rootDirs))
                        {
                            if (Enable_Disable == true)
                            {
                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder" + @"\mod.json"))
                                {
                                    TryMoveFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder" + @"\mod.json", User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\mod.json", true);

                                    DirectoryInfo Locked = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder");
                                    if (Page_Home.IsDirectoryEmpty(Locked))
                                    {

                                        TryDeleteDirectory(Locked.FullName);

                                    }


                                }
                                else
                                {

                                    Snackbar.Title = "ERROR";
                                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                                    Snackbar.Message = "File" + val + " Could not be Edited.";
                                    Snackbar.Show();
                                }





                            }
                            else
                            {
                                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\mod.json"))
                                {
                                    TryCreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder");

                                    TryMoveFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\mod.json", User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder" + @"\mod.json", true);



                                }
                                else
                                {
                                    Snackbar.Title = "ERROR";
                                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                                    Snackbar.Message = "File" + val + " Could not be Edited.";
                                    Snackbar.Show();
                                }


                            }



                        }














                    }
                    else
                    {


                        DirectoryInfo rootDirs = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val);
                        DirectoryInfo Locked = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods\" + val + @"\Locked_Folder");

                        if (!Page_Home.IsDirectoryEmpty(rootDirs))
                        {
                            if (Directory.Exists(Locked.FullName))
                            {
                                if (Page_Home.IsDirectoryEmpty(Locked))
                                {

                                    TryDeleteDirectory(Locked.FullName);

                                }
                                TryMoveFile(Locked.FullName, rootDirs.FullName);
                                TryDeleteDirectory(Locked.FullName);

                            }

                        }



                    }


                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }


        }
        private void Mod_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender.GetType() == typeof(Wpf.Ui.Controls.Button))
                {

                    Wpf.Ui.Controls.Button Button_ = (Wpf.Ui.Controls.Button)sender;
                    string Name_ = Button_.ToolTip.ToString();
                    if (Name_ != null)
                    {

                        if (Button_.Tag.ToString() == "Enable")
                        {

                            Move_Mods(Name_, true);



                        }
                        else
                        {

                            Move_Mods(Name_, false);

                        }

                    }
                }



                Call_Mods_From_Folder();

                DispatchIfNecessary(() =>
                {

                    ApplyDataBinding();
                });

            }
            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        public void ComboBox_Actions()
        {
            try
            {
                if (Filter.SelectedItem != null)
                {
                    if (_Completed_Mod_call == true)
                    {

                        if (Reverse_ == false)
                        {

                            if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                            {


                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();

                                Mod_List_Box.ItemsSource = sorted;

                                Mod_List_Box.Refresh();


                            }
                            else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                            {

                                Search_Bar_Suggest_Mods.Text = "~Search";



                                var sorted = Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();

                                Mod_List_Box.ItemsSource = sorted;
                                Mod_List_Box.Refresh();

                            }
                            else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                            {

                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderBy(ob => ob.Is_Active_).ToArray();
                                Mod_List_Box.ItemsSource = sorted;
                                Mod_List_Box.Refresh();

                            }
                            else
                            {

                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();

                                Mod_List_Box.ItemsSource = sorted;

                                Mod_List_Box.Refresh();

                            }
                        }
                        else
                        {

                            if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                            {



                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();

                                Mod_List_Box.ItemsSource = sorted;

                                Mod_List_Box.Refresh();

                            }
                            else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                            {


                                Search_Bar_Suggest_Mods.Text = "~Search";



                                var sorted = Final_List.OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();

                                Mod_List_Box.ItemsSource = sorted;
                                Mod_List_Box.Refresh();

                            }
                            else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                            {

                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderByDescending(ob => ob.Is_Active_).ToArray();
                                Mod_List_Box.ItemsSource = sorted;
                                Mod_List_Box.Refresh();

                            }
                            else
                            {

                                Search_Bar_Suggest_Mods.Text = "~Search";


                                var sorted = Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();

                                Mod_List_Box.ItemsSource = sorted;

                                Mod_List_Box.Refresh();

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_Actions();
            if (Filter.SelectedIndex != -1)
            {
                Filter_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                Filter_Label.Visibility = Visibility.Visible;

            }

        }

        private void Search_Bar_Suggest_Mods_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Search_Bar_Suggest_Mods_GotFocus(object sender, RoutedEventArgs e)
        {
            Search_Bar_Suggest_Mods.IsReadOnly = false;
            if (Search_Bar_Suggest_Mods.Text.Trim() == "~Search")
            {
                Search_Bar_Suggest_Mods.Text = "";
            }






            Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
            Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
        }

        private void Search_Bar_Suggest_Mods_LostFocus(object sender, RoutedEventArgs e)
        {
            //  Search_Bar_Suggest_Mods.Text = "Search";
            Search_Bar_Suggest_Mods.IsReadOnly = true;
            if (Search_Bar_Suggest_Mods.Text.Trim() == "")
            {
                Search_Bar_Suggest_Mods.Text = "~Search";
            }
            Search_Bar_Suggest_Mods.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
            Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
        }

        IEnumerable<Card_> Keep_List_State(bool Searching, bool reverse = false)
        {
            try
            {

                if (Filter.SelectedItem != null)
                {
                    if (_Completed_Mod_call == true)
                    {


                        switch (Reverse_)
                        {
                            case true:
                                switch (Searching)
                                {
                                    case true:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {





                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Mod_Name_).ToArray();


                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {




                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {

                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Is_Active_).ToArray();



                                        }
                                        else
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Mod_Name_).ToArray();




                                        }
                                        break;

                                    case false:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {





                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {





                                            return Final_List.OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderByDescending(ob => ob.Is_Active_).ToArray();

                                        }
                                        else
                                        {



                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;

                                    default:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {





                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {





                                            return Final_List.OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderByDescending(ob => ob.Is_Active_).ToArray();

                                        }
                                        else
                                        {



                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;


                                }
                                break;

                            case false:
                                switch (Searching)
                                {
                                    case true:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();





                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Is_Active_).ToArray();



                                        }
                                        else
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        break;

                                    case false:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {




                                            return Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderBy(ob => ob.Is_Active_).ToArray();


                                        }
                                        else
                                        {



                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;

                                    default:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {




                                            return Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderBy(ob => ob.Is_Active_).ToArray();


                                        }
                                        else
                                        {



                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;


                                }
                                break;

                            default:
                                switch (Searching)
                                {
                                    case true:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();





                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Is_Active_).ToArray();



                                        }
                                        else
                                        {


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        break;

                                    case false:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {




                                            return Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderBy(ob => ob.Is_Active_).ToArray();


                                        }
                                        else
                                        {



                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;

                                    default:
                                        if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Name"))
                                        {











                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();




                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Date"))
                                        {




                                            return Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();



                                        }
                                        else if (Filter.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem:", "").Trim().Contains("Status"))
                                        {



                                            return Final_List.OrderBy(ob => ob.Is_Active_).ToArray();


                                        }
                                        else
                                        {



                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();



                                        }
                                        break;


                                }

                                break;

                        }

                    }
                }
                switch (Searching)
                {
                    case true:
                        return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();

                        break;
                    case false:
                        return Final_List.OrderBy(ob => ob.Mod_Name_);

                        break;

                    default:
                        return Final_List.OrderBy(ob => ob.Mod_Name_);

                        break;
                }

            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return Final_List.OrderByDescending(ob => ob.Mod_Name_);

        }
        private void Search_Bar_Suggest_Mods_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (_Completed_Mod_call == true)
                {
                    Mod_List_Box.ItemsSource = null;

                    if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text.Trim() != "~Search")
                    {

                        var sorted = Keep_List_State(true, Reverse_);

                        Mod_List_Box.ItemsSource = sorted;
                        Mod_List_Box.Refresh();
                    }
                    else if (Search_Bar_Suggest_Mods.Text.Trim() == "")
                    {

                        var sorted = Keep_List_State(false, Reverse_);

                        Mod_List_Box.ItemsSource = sorted;
                        Mod_List_Box.Refresh();

                    }
                    else
                    {


                        var sorted = Keep_List_State(false, Reverse_);

                        Mod_List_Box.ItemsSource = sorted;

                        Mod_List_Box.Refresh();


                    }
                }

            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        void Check_Reverse(bool Apply_Change = true)
        {
            try
            {
                DispatchIfNecessary(() =>
                {
                    if (Apply_Change == true)
                    {
                        if (Reverse_ == true)
                        {
                            Reverse_ = false;

                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#0FFFFFFF");

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
                            padd.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#0FFFFFFF");


                        }

                    }
                });
            }
            catch (Exception ex)
            {
              //Removed PaperTrailSystem Due to lack of reliability.

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        private void padd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mod_List_Box.ItemsSource = null;

                Check_Reverse();

                var sorted = Keep_List_State(false, Reverse_);

                Mod_List_Box.ItemsSource = sorted;
                Mod_List_Box.Refresh();

            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy-MM- dd-HH-mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Mod_List_Box_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void Check_For_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender.GetType() == typeof(Wpf.Ui.Controls.Button))
                {

                    Wpf.Ui.Controls.Button Button_ = (Wpf.Ui.Controls.Button)sender;
                    string Name_ = Button_.ToolTip.ToString();
                    string pattern = @"[^!]+(?=-)";
                    Regex rg = new Regex(pattern);

                    if (rg.IsMatch(Name_))
                    {


                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += (sender, e) =>
                        {

                            DispatchIfNecessary(() =>
                            {
                                Page_Thunderstore PP = new Page_Thunderstore();
                                Main.RootFrame.Navigate(PP); //FrameContent is the name given to the frame within the xaml.
                                PP.Search_Bar_Suggest_Mods.Text = Name_;
                                PP.Call_Ts_Mods(true, Search_: true, SearchQuery: Name_);
                                PP.Thunderstore_List.Refresh();

                            });


                        };

                        worker.RunWorkerAsync();



                    }
                    else
                    {
                        Console.WriteLine($"{Name_} does not match");
                    }

                }







            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        private string Find_Folder(string searchQuery, string folderPath)
        {
            searchQuery = "*" + searchQuery + "*";

            var directory = new DirectoryInfo(folderPath);

            var directories = directory.GetDirectories(searchQuery, SearchOption.AllDirectories);
            return directories[0].ToString();
        }
        public static string FindFirstFile(string path, string searchPattern)
        {
            TlsPaperTrailLogger logger2 = new TlsPaperTrailLogger("logs5.papertrailapp.com", 38137);

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
                    logger2.Open();
                    logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
                    logger2.Close();

                    return string.Empty;
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
                        string file = FindFirstFile(directory, searchPattern);

                        // If we found a file, return it (and break the recursion).
                        if (file != string.Empty)
                        {
                            return file;
                        }
                    }
                }
                return string.Empty;

            }



            catch (Exception ex)
            {
                logger2.Open();
                logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
                logger2.Close();
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return string.Empty;
        }
        public long GetDirectorySize(string path)
        {
            try { 
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                               .Sum(file => file.Length);
            }

            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return 0;
        }

        public  string SizeSuffix(long value)
        {
            try {
                if (value < 1024)
                    return $"{value} B";
                else if (value < 1048576)
                    return $"{value / 1024f:0.##} KB";
                else if (value < 1073741824)
                    return $"{value / 1048576f:0.00} MB";
                else
                    return $"{value / 1073741824f:0.00} GB";
            }

            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return null;
}
        void Open_Mod_Info(string Mod_name)
        {

            try
            {
                string FolderDir = Find_Folder(Mod_name, User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods");

                if (Directory.Exists(FolderDir))
                {


                    string mod_Json = FindFirstFile(FolderDir, "mod.json");


                    if (mod_Json != null && File.Exists(mod_Json))
                    {
                        var myJsonString = File.ReadAllText(mod_Json);
                        dynamic myJObject = JObject.Parse(myJsonString);
                        string name = "Name: " + myJObject.Name;
                        string version = "Version: " + myJObject.Version;
                        string Description = "Description: " + myJObject.Description;
                        long size = GetDirectorySize(FolderDir);
                        string size_str = "Mod Size on Disk: " + SizeSuffix(size);

                       
                        string Content = Description + Environment.NewLine + version + Environment.NewLine + size_str.Replace(",",".");
                        DialogF.ButtonLeftName = "Ok";
                        DialogF.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                        DialogF.ButtonRightName = VTOL.Resources.Languages.Language.Page_Mods_Open_Mod_Info_OpenFolder;

                        DialogF.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Secondary;
                        DialogF.Title = name;
                        DialogF.Message = Content;
                        DialogF.Tag = FolderDir;

                        DialogF.Show();
                    }




                }





            }

            catch (Exception ex)
            {
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        void Open_Folder(string Folder)
        {

            try
            {

                Process.Start("explorer.exe", Folder);


            }
            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
               Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }


        private void Info_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender.GetType() == typeof(Wpf.Ui.Controls.Button))
                {

                    Wpf.Ui.Controls.Button Button_ = (Wpf.Ui.Controls.Button)sender;
                    string Name_ = Button_.Tag.ToString();
                    if (Name_ != null)
                    {


                        Open_Mod_Info(Name_);

                    }
                }






            }

            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sender.GetType() == typeof(Wpf.Ui.Controls.Button))
                {

                    Wpf.Ui.Controls.Button Button_ = (Wpf.Ui.Controls.Button)sender;
                    string Name_ = Button_.Tag.ToString();
                    if (Name_ != null)
                    {


                        Delete_Mod(Name_);

                    }
                }






            }

            catch (Exception ex)
            {
               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

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

               //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return null;
        }
        string temp_Dir;
        void Delete_Mod(string Mod_name)
        {



            try
            {
                string FolderDir = Find_Folder(Mod_name, User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods");
                if (Directory.Exists(FolderDir))
                {
                    temp_Dir = FolderDir;

                    Dialog.Refresh();
                    Dialog.Message = null;
                    Dialog.ButtonLeftName = "Yes";
                    Dialog.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                    Dialog.ButtonRightName = "Cancel";

                    Dialog.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Secondary;
                    Dialog.Title = "DELETE MOD";
                    string Content = ("Are You Sure You Want To Delete The Mod - ") + Environment.NewLine + Mod_name + Environment.NewLine + "Permanentley?";
                    Dialog.Message = Content;
                    Dialog.ButtonLeftClick += new RoutedEventHandler(Delete_Action);

                    Dialog.Show();




                }



            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }

        }
        void Delete_Action(object sender, RoutedEventArgs e)
        {

            try
            {

                if (!Directory.Exists(temp_Dir))
                {
                    Dialog.Hide();

                    //Send_Success_Notif("Successfully Deleted - " + Mod);
                    Call_Mods_From_Folder();
                }
                else
                {
                    TryDeleteDirectory(temp_Dir, true);

                    Dialog.Hide();

                    //Send_Error_Notif("Could not Delete! - " + Mod);
                    Call_Mods_From_Folder();

                }
                temp_Dir = null;
            }
            catch (Exception ex)
            {
              Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }


        private void EXTRA_SETTINGS_Dock_MouseRightButtonDown(object sender, MouseButtonEventArgs e)


        {
            try
            {
                string Triggger = null;

                if (_Completed_Mod_call == true)
                {
                    Wpf.Ui.Controls.CardControl Card;
                    if (sender.GetType() == typeof(Wpf.Ui.Controls.CardControl))
                    {
                        Card = sender as Wpf.Ui.Controls.CardControl;

                        DockPanel DockPanel_ = FindVisualChild<DockPanel>(Card);
                        Triggger = DockPanel_.Tag.ToString();

                        if (Triggger != null)
                        {
                            if (Triggger == "Hidden")
                            {




                                DoubleAnimation da = new DoubleAnimation
                                {
                                    From = DockPanel_.Opacity,
                                    To = 1,
                                    Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                    AutoReverse = false
                                };
                                DockPanel_.BeginAnimation(OpacityProperty, da);
                                DockPanel_.IsEnabled = true;
                                Triggger = "Visible";
                                DockPanel_.Tag = "Visible";
                                DockPanel_.Visibility = Visibility.Visible;




                            }
                            else if (Triggger == "Visible")
                            {


                                DoubleAnimation da = new DoubleAnimation
                                {
                                    From = DockPanel_.Opacity,
                                    To = 0,
                                    Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                    AutoReverse = false
                                };
                                DockPanel_.BeginAnimation(OpacityProperty, da);
                                DockPanel_.IsEnabled = false;
                                Triggger = "Hidden";
                                DockPanel_.Tag = "Hidden";






                            }
                        }


                    }




                }
            }
            catch (Exception ex)
            {
              Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void CardControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_Completed_Mod_call == true)
                {
                    Wpf.Ui.Controls.CardControl Card;
                    if (sender.GetType() == typeof(Wpf.Ui.Controls.CardControl))
                    {
                        Card = sender as Wpf.Ui.Controls.CardControl;

                        DockPanel DockPanel_ = FindVisualChild<DockPanel>(Card);

                        DockPanel_.Visibility = Visibility.Hidden;

                        DockPanel_.Tag = "Hidden";
                        DockPanel_.IsEnabled = false;
                        DockPanel_.Opacity = 0.0;

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        private void CardControl_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void Mod_List_Box_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void CardControl_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void CardControl_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Mod_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Call_Mods_From_Folder();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Mod_Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _Completed_Mod_call = false;
        }

        private void DialogF_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            Wpf.Ui.Controls.Dialog _Dialog;
            _Dialog = sender as Wpf.Ui.Controls.Dialog;

            Open_Folder(_Dialog.Tag.ToString());

        }
        public string Search_For_Mod_Thunderstore(string SearchQuery = "None")

        {
            try
            {

                _updater = new VTOL.Updater("https://northstar.thunderstore.io/api/v1/package/");
                _updater.Download_Cutom_JSON(true);




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
               //Removed PaperTrailSystem Due to lack of reliability.

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return null;
        }
        private void DialogF_ButtonLeftClick(object sender, RoutedEventArgs e)
        {

            DialogF.Hide();

            //DispatchIfNecessary(() =>
            //{

            //    Wpf.Ui.Controls.Dialog _Dialog;
            //    _Dialog = sender as Wpf.Ui.Controls.Dialog;
            //    Page_Thunderstore p = new Page_Thunderstore();
            //    // p.InitializeComponent();
            //    p.Thunderstore_List.ItemsSource = null;





            //    p.Call_Ts_Mods(true, Search_: true, SearchQuery: _Dialog.Title);
            //    p.Search_Bar_Suggest_Mods.Text = _Dialog.Title.ToString();



            //    p.Thunderstore_List.Refresh();
            //    Main.RootNavigation.Navigate(typeof(VTOL.Pages.Page_Thunderstore));
            //});
        }

        private void Dialog_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            Dialog.Hide();

        }

        private void Mod_List_Box_PreviewDragOver(object sender, DragEventArgs e)
        {

        }

        private void Mod_List_Box_PreviewDragLeave(object sender, DragEventArgs e)
        {
            Drag_Drop_Overlay_Mods.Visibility = Visibility.Hidden;

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
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

                }
                else
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);

                }
            }
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
        void Install_Mod_Zip(string Target_Zip, string Destination)
        {


            string fileExts = System.IO.Path.GetExtension(Target_Zip);

            if (fileExts == ".zip")
            {
                if (File.Exists(Target_Zip))
                {

                    if (!Directory.Exists(Destination))
                    {
                        TryCreateDirectory(Destination);
                    }
                    if (Directory.Exists(Destination))
                    {
                        TryUnzipFile(Target_Zip, Destination);


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




                                TryCreateDirectory(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");
                                if (Directory.Exists(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder"))
                                {
                                    CopyFilesRecursively(firstFolder, Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder");




                                    Clear_Folder(Destination);
                                    CopyFilesRecursively(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", Destination);
                                    TryDeleteDirectory(Destinfo.Parent.FullName + @"\" + "Temp_Working_Folder", true);

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
                        DispatchIfNecessary(() =>
                        {
                            Log.Warning("The File" + Target_Zip + "Is not a zip!!");
                            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            Snackbar.Content = "The File " + Target_Zip + " Is noT a zip!!";
                        });


                    }

                    DispatchIfNecessary(() =>
                    {

                        Snackbar.Title = "SUCCESS";
                        Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                        Snackbar.Message = "The Mod " + Path.GetFileNameWithoutExtension(Target_Zip).Replace("_", " ") + " has been Downloaded and Installed";
                        Snackbar.Show();



                    });

                }
            }











        }
        private async Task Stall_Queue(List<string> Mod_List)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {


                foreach (var i in Mod_List)
                {
                    Console.WriteLine("Started" + i);
                    Install_Mod_Zip(i, User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\mods\" + Path.GetFileNameWithoutExtension(i));

                    await Task.Delay(1500);


                }

            });
        }
        private void Mod_List_Box_Drop(object sender, DragEventArgs e)
        {

            List<string> Mod_List = new List<string>();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {


                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var file in files)
                {
                    Mod_List.Add(file);
                    Snackbar.Title = "INFO";
                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    Snackbar.Message = "Found - " + file;
                    Snackbar.Show();
                }

            }
            Stall_Queue(Mod_List);

            Drag_Drop_Overlay_Mods.Visibility = Visibility.Hidden;


        }

        private void Mod_List_Box_PreviewDragEnter(object sender, DragEventArgs e)
        {
            e.Handled = true;
            Drag_Drop_Overlay_Mods.Visibility = Visibility.Visible;
        }

        private void Drag_Drop_Overlay_Mods_PreviewDragOver(object sender, DragEventArgs e)
        {
            Main.Activate();

        }

        private void Mod_Grid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (file.Contains(".zip"))
                    {



                    }
                }
            }

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Filter.SelectedIndex = -1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
