using FuzzyString;
using HandyControl.Tools.Extension;
using Ionic.Zip;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using VTOL.Advocate.Conversion.JSON;
using static VTOL.MainWindow;
using static VTOL.Pages.Page_Profiles;
using Path = System.IO.Path;

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
        string Mod_Settings_Mod_OLD_PATH;
        string Current_MOD_PATH;
        int mismatchCount = 0;
        List<string> mismatchedNames = new List<string>();
        string workingmod;
        List<NORTHSTARCOMPATIBLE_MOD> CLEANED_FORMAT_MODS;
        public Page_Mods()
        {
            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;
            Snackbar = Main.Snackbar;
           
          



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
       
      
        public class NORTHSTARCOMPATIBLE_MOD
        {
            public string Name { get; set; }
            public bool Value { get; set; }
            public DirectoryInfo DIRECTORY_INFO { get; set; }
            public bool IsValidandinstalled { get; set; }
            public bool Has_Valid_Mod { get; set; }

            public string Namespace { get; set; }

        }


        static bool CustomKeyComparer(string key1, string key2)
        {
            return string.Equals(key1, key2, StringComparison.OrdinalIgnoreCase);


            //use case code
            //JToken value = null;
            //bool containsKey = jsonObject.Properties().Any(p => CustomKeyComparer(p.Name, Mod.Name.Replace("_", " ").Trim()));

            //if (containsKey)
            //{
            //     value = jsonObject[Mod.Name.Replace("_", " ").Trim()];




        }
        public List<NORTHSTARCOMPATIBLE_MOD> READ_UPDATE_MOD_LIST(DirectoryInfo[] modsToUpdate, bool UPDATE_Folders = false)
        {
            List<NORTHSTARCOMPATIBLE_MOD> OUTPUT = new List<NORTHSTARCOMPATIBLE_MOD>();

            try//todo fix icon png left behind
            {
                if (modsToUpdate.Count() <= 0)
                {
                    return OUTPUT;
                }
                
                string Json_Path = FindFirstFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\", "enabledmods.json");

                if (File.Exists(Json_Path) == true)
                {
                  // Read the JSON file
                   string  jsonContent = File.ReadAllText(Json_Path);
                    
                 if (jsonContent.IsNullOrEmpty() == true && jsonContent.Length < 5)
                   {
                         File.WriteAllText(Json_Path, "{\t\t\n\n}");

                    foreach (var dirInfo in modsToUpdate)
                    {
                        string dirName = "";
                        NORTHSTARCOMPATIBLE_MOD Mod = new NORTHSTARCOMPATIBLE_MOD();
                        string[] Split_Name = (dirInfo.Name).Split('-');
                        if (Split_Name.Length >= 1)
                        {

                            dirName = Split_Name[1];
                        }

                       
                        // Use the regex pattern to extract the version number
                        string pattern = @"-\d+\.\d+\.\d+$";
                        Match match = Regex.Match(dirName, pattern);
                        // Remove the version number from the directory name
                        string dirNameWithoutVersion = null;

                        dirNameWithoutVersion = match.Success ? dirName.Replace(match.Value, "") : dirName;

                        if (dirNameWithoutVersion == null)
                        {

                            dirNameWithoutVersion = match.Success ? dirInfo.Name.Replace(match.Value, "") : dirInfo.Name;
                            // Handle the case where the value is null


                        }
                        // Handle the case where the value is null
                        Mod.Name = dirNameWithoutVersion;
                        Mod.Value = false; // or some other appropriate value
                            Mod.IsValidandinstalled = false; // or some other appropriate value
                            if (dirInfo.Exists)
                            {
                                Mod.DIRECTORY_INFO = dirInfo; // or some other appropriate value
                                Mod.Namespace = dirInfo.Name;

                        }
                        OUTPUT.Add(Mod);

                        }
                        // Handle case where json is null or empty
                        return OUTPUT;
                }
             else
                 {
                   
                        ////// Parse the JSON content
                        JObject jsonObject = JObject.Parse(jsonContent);

                        foreach (var dirInfo in modsToUpdate)
                        {
                            try//todo fix icon png left behind
                            {
                                NORTHSTARCOMPATIBLE_MOD Mod = new NORTHSTARCOMPATIBLE_MOD();
                                string File_found = FindFirstFile(dirInfo.FullName, "mod.json");

                                if (File.Exists(File_found))
                                {
                                    string mod_json = File.ReadAllText(File_found);

                                    if (!mod_json.IsNullOrEmpty() && mod_json.Length > 10)
                                    {

                                        JObject modjson = JObject.Parse(mod_json);
                                        Mod.Name = modjson.SelectToken("Name").Value<string>();


                                    }
                                    else
                                    {
                                        Mod.Name = (dirInfo.Name.Split('-')[1]);


                                    }

                                    if (dirInfo.Exists)
                                    {
                                        Mod.DIRECTORY_INFO = dirInfo; // or some other appropriate value
                                        Mod.Namespace = dirInfo.Name;


                                    }
                                    Mod.Has_Valid_Mod = false;

                                    if (Directory.Exists(Mod.DIRECTORY_INFO.FullName + @"\mods"))
                                    {
                                        Mod.Has_Valid_Mod = true;
                                    }


                                    if (jsonObject.TryGetValue(Mod.Name.Trim(), out JToken value))
                                    {


                                        if (value != null && value.Type == JTokenType.Boolean)
                                        {
                                            bool isValueTrue = (bool)value;
                                            Mod.Value = isValueTrue;
                                        }
                                        else
                                        {
                                            Mod.Value = false;
                                        }

                                        Mod.IsValidandinstalled = true;


                                        OUTPUT.Add(Mod);
                                    }
                                    else
                                    {
                                        // Handle the case where the value is null
                                        Mod.Value = false; // or some other appropriate value
                                        Mod.IsValidandinstalled = false; // or some other appropriate value
                                        if (dirInfo.Exists)
                                        {
                                            Mod.DIRECTORY_INFO = dirInfo; // or some other appropriate value
                                            Mod.Namespace = dirInfo.Name;

                                        }
                                        OUTPUT.Add(Mod);
                                    }

                                }
                                else
                                {

                                    Mod.IsValidandinstalled = false;

                                    string dirName = dirInfo.Name;

                                    string pattern = @"-\d+\.\d+\.\d+$";
                                    Match match = Regex.Match(dirName, pattern);
                                    // Remove the version number from the directory name
                                    string dirNameWithoutVersion = match.Success ? dirName.Replace(match.Value, "") : dirName;
                                    // Handle the case where the value is null
                                    Mod.Name = "!" + dirNameWithoutVersion + "!";

                                }


                            }
                            catch (Exception ex)
                            {
                                continue;
                                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

                            }

                        }
                       
                   
                }
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                return OUTPUT;

            }
            return OUTPUT;

        }
        public async Task Call_Mods_From_Folder()
        {
            bool install_Prompt = false;
            string IS_CORE_MOD_temp = "#00000000";
            try
            {
                Final_List.Clear();
                if (User_Settings_Vars.NorthstarInstallLocation != null || User_Settings_Vars.NorthstarInstallLocation != "" || Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {
                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {
                        if (User_Settings_Vars.CurrentVersion != "NODATA")
                        {

                            string NS_Mod_Dir = User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages";

                            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(NS_Mod_Dir);
                            System.IO.DirectoryInfo NS_Dirs = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods");
                        
                            

                            if (IsValidPath(rootDirs.FullName) == true)
                            {

                                System.IO.DirectoryInfo[] subDirs = null;
                                subDirs = rootDirs.GetDirectories().Concat(NS_Dirs.GetDirectories()).ToArray();
                                



                                    if (subDirs.Count() > 0)
                                {
                                    string Json_Path = FindFirstFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\", "enabledmods.json");


                                    if (File.Exists(Json_Path))
                                    {
                                    
                                        List<NORTHSTARCOMPATIBLE_MOD> DIRECTORY_MODS = READ_UPDATE_MOD_LIST(subDirs);

                                        CLEANED_FORMAT_MODS = DIRECTORY_MODS;

                                    }
                                    DispatchIfNecessary(async () =>

                                    {

                                        Mod_Count_Label.Content = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ModCount + CLEANED_FORMAT_MODS.Count;
                                    });

                                    foreach (var Verified_Installed_Mod in CLEANED_FORMAT_MODS)
                                    {
                                        try
                                        {
                                            if (Verified_Installed_Mod.DIRECTORY_INFO != null)
                                            {
                                               


                                                // bool Has_Manifest_or_plugins = await Check_Plugins_and_multi_mod(Verified_Installed_Mod.DIRECTORY_INFO.FullName, Verified_Installed_Mod.DIRECTORY_INFO.Name);
                                                if (Regex.IsMatch(Verified_Installed_Mod.Name.Trim(), @"^Northstar\.CustomServers\w{0,2}$") || Regex.IsMatch(Verified_Installed_Mod.Name.Trim(), @"^Northstar\.Custom\w{0,2}$") || Regex.IsMatch(Verified_Installed_Mod.Name.Trim(), @"^Northstar\.Client\w{0,2}$"))
                                                {
                                                    IS_CORE_MOD_temp = "#FF8C7F24";

                                                }
                                                else
                                                {
                                                    IS_CORE_MOD_temp = "#00000000";

                                                }

                                                if (Page_Home.IsDirectoryEmpty(new DirectoryInfo(Verified_Installed_Mod.DIRECTORY_INFO.FullName)))
                                                {

                                                    TryDeleteDirectoryAsync(Verified_Installed_Mod.DIRECTORY_INFO.FullName, true);

                                                    continue;

                                                }
                                               
                                                if (Verified_Installed_Mod.Value == false)
                                                {



                                                    int Flag_mod = 0;
                                                    string ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ThereIsAnIssueDetectedWithYourMod;

                                                    if (Verified_Installed_Mod.IsValidandinstalled == false)
                                                    {
                                                        IS_CORE_MOD_temp = "#c80815";

                                                        ToolTip_Dynamic = "The Mod Is not Registered Properly in the Backend List, Please Fix the Mod formatting or update your TF2 Mod List by Launching the Game";
                                                        Flag_mod = 100;
                                                    }
                                                    else if(Verified_Installed_Mod.Has_Valid_Mod == false && !Verified_Installed_Mod.Name.Contains("Northstar") && !Directory.Exists(Verified_Installed_Mod.DIRECTORY_INFO.FullName + @"\audio") && !Directory.Exists(Verified_Installed_Mod.DIRECTORY_INFO.FullName + @"\vpk"))
                                                    {
                                                        IS_CORE_MOD_temp = "#c80815";

                                                        ToolTip_Dynamic = "The Mod Is Not Formatted Properly. Please Fix the Mod formatting";
                                                        Flag_mod = 100;
                                                    }

                                                    Final_List.Add(new Card_ { Mod_Name_ = Verified_Installed_Mod.Name.Trim(), Mod_Date_ = Verified_Installed_Mod.DIRECTORY_INFO.CreationTime.ToString(), Is_Active_Color = "#B29A0404", Size__ = Verified_Installed_Mod.DIRECTORY_INFO.LastAccessTime.ToString(), En_Di = "Enable", Is_Active_ = true, Mod_Path_ = Verified_Installed_Mod.DIRECTORY_INFO.FullName, Flag = Flag_mod, Error_Tooltip = ToolTip_Dynamic, Label = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_Enable, IS_CORE_MOD = IS_CORE_MOD_temp });
                                                }
                                                else
                                                {
                                                    int Flag_mod = 0;
                                                    string ToolTip_Dynamic = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_ThereIsAnIssueDetectedWithYourMod;

                                                    if (Verified_Installed_Mod.IsValidandinstalled == false)
                                                    {
                                                        IS_CORE_MOD_temp = "#c80815";


                                                        ToolTip_Dynamic = "The Mod Is not Registered Properly in the Backend List, Please Fix the Mod formatting or update your TF2 Mod List";
                                                        Flag_mod = 100;
                                                    }

                                                    Final_List.Add(new Card_ { Mod_Name_ = Verified_Installed_Mod.Name.Trim(), Mod_Date_ = Verified_Installed_Mod.DIRECTORY_INFO.CreationTime.ToString(), Is_Active_Color = "#B2049A28", Size__ = Verified_Installed_Mod.DIRECTORY_INFO.LastAccessTime.ToString(), En_Di = "Disable", Is_Active_ = false, Mod_Path_ = Verified_Installed_Mod.DIRECTORY_INFO.FullName, Flag = Flag_mod, Error_Tooltip = ToolTip_Dynamic, Label = VTOL.Resources.Languages.Language.Page_Mods_Call_Mods_From_Folder_Disable_, IS_CORE_MOD = IS_CORE_MOD_temp });


                                                }
                                                DispatchIfNecessary(async () =>
                                                {
                                                    string[] parts = Verified_Installed_Mod.Namespace.Split('-');
                                                    string name = Verified_Installed_Mod.Namespace.Trim();
                                                    string author = "NA";
                                                    string ver = "NA";

                                                    if (parts.Length == 3 )
                                                    {
                                                        author = parts[0];
                                                        name = parts[1];
                                                        ver = parts[2];
                                                    }

                                                    Main.Current_Installed_Mods.Add(new GENERAL_MOD { Name = name, Version = ver, Author = author });
                                                });
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

                                        }
                                    }
                                    Main.loaded_mods = true;


                                }

                                DispatchIfNecessary(async () =>
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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{e.InnerException}{Environment.NewLine}");


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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");
                isValid = false;
            }

            return isValid;
        }
        private void ApplyDataBinding()
        {
            try
            {
                Mod_List_Box.ItemsSource = null;
                _Completed_Mod_call = true;
                var sorted = Keep_List_State(false, Reverse_);
                Mod_List_Box.ItemsSource = sorted;
                _Completed_Mod_call = true;

                if (Search_Bar_Suggest_Mods.Text.Trim() != "" && Search_Bar_Suggest_Mods.Text.Trim() != "~Search")
                {
                     sorted = Keep_List_State(true, Reverse_);

                }
                Mod_List_Box.Refresh();






            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
        }

        public void Move_Mods(string val, bool Enable_Disable)
        {

            try
            {

                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages\"))
                {


                    if (val != null)
                    {


                        string Json_Path = FindFirstFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\", "enabledmods.json");


                        if (File.Exists(Json_Path))
                        {
                            // Read the JSON file
                            string jsonContent = File.ReadAllText(Json_Path);
                            // Parse the JSON content
                            JObject jsonObject = JObject.Parse(jsonContent);
                            string Name = val;
                            if (jsonObject.TryGetValue(Name, out _))
                            {
                                if (Enable_Disable != null)
                                {
                                    // Insert a new property
                                    jsonObject[Name] = Enable_Disable;
                                }
                            }
                            // Convert back to JSON string
                            string updatedJson = jsonObject.ToString();

                            // string updatedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                            // Write back to the file
                            File.WriteAllText(Json_Path, updatedJson);

                        }
                        else
                        {

                            Snackbar.Title = VTOL.Resources.Languages.Language.ERROR;
                            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            Snackbar.Message = "File" + Json_Path + " Could not be Edited.";
                            Snackbar.Show();

                        }
                    }
                    else
                    {


                        DirectoryInfo rootDirs = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages\" + val);
                        DirectoryInfo Locked = new DirectoryInfo(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages\" + val + @"\Locked_Folder");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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

                DispatchIfNecessary(async () =>
                {

                    ApplyDataBinding();
                });

            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
            //Search_Bar_Suggest_Mods.Icon = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");
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
            // Search_Bar_Suggest_Mods.IconForeground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");
        }

        IEnumerable<Card_> Keep_List_State(bool Searching, bool reverse = false)
        {
            try
            {

                if (Filter.SelectedItem != null)
                {
                    if (_Completed_Mod_call == true)
                    {



                        string value = Convert.ToString(Filter.SelectedValue);

                        switch (Reverse_)
                        {       

                            case true:
                                if (Searching == true)
                                {
                                    
                                        switch (value)
                                        {
                                            case "Name":

                                                return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Mod_Name_).ToArray();


                                                break;
                                            case "Date":

                                                return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();

                                                break;



                                            case "Status":
                                                return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Is_Active_).ToArray();

                                                break;

                                            default:
                                                return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => ob.Mod_Name_).ToArray();
                                                break;

                                        }
                                    }
                                else {
                                    switch (value)
                                    {
                                        case "Name":

                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();

                                            break;

                                        case "Date":





                                            return Final_List.OrderBy(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();
                                            break;



                                        case "Status":



                                            return Final_List.OrderByDescending(ob => ob.Is_Active_).ToArray();
                                            break;


                                        default:



                                            return Final_List.OrderByDescending(ob => ob.Mod_Name_).ToArray();

                                            break;
                                    }

                                }

                                 


                                
                                break;

                            case false:
                                if (Searching == true)
                                {

                                    switch (value)
                                    {
                                        case "Name":
                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();
                                            break;

                                        case "Date":


                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();
                                            break;


                                        case "Status":
                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Is_Active_).ToArray();
                                            break;

                                        default:
                                            return Final_List.Where(ob => ob.Mod_Name_.ToLower().Contains(Search_Bar_Suggest_Mods.Text.ToLower())).OrderBy(ob => ob.Mod_Name_).ToArray();
                                            break;

                                    }
                                }
                                else
                                {
                                    switch (value)
                                    {
                                        case "Name":
                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();
                                            break;

                                        case "Date":
                                            return Final_List.OrderByDescending(ob => Convert.ToDateTime(ob.Mod_Date_)).ToArray();

                                            break;

                                        case "Status":
                                            return Final_List.OrderBy(ob => ob.Is_Active_).ToArray();

                                        default:
                                            return Final_List.OrderBy(ob => ob.Mod_Name_).ToArray();

                                            break;


                                    }


                                }
                                break;

                        }

                    }
                }
               

            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
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

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy-MM- dd-HH-mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
        }

        private void Mod_List_Box_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private string CleanSearchQuery(string searchQuery)
        {
            // Remove special characters, spaces, and make the query case-insensitive
            return Regex.Replace(searchQuery, @"[^\w]+", string.Empty, RegexOptions.IgnoreCase);
        }
       
        
        //private string Find_Folder(string searchQuery, string folderPath)
        //{
        //    searchQuery = CleanSearchQuery(searchQuery);
        //    Console.WriteLine(searchQuery);
        //    var directory = new DirectoryInfo(folderPath);

        //    var directories = directory
        //        .EnumerateDirectories()
        //        .FirstOrDefault(dir =>
        //        CleanSearchQuery(dir.Name.Split('-')[1]).Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

        //    if (directories != null)
        //    {
        //        return directories.FullName;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
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
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                    catch (Exception e)
                    {
                        Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{e.InnerException}{Environment.NewLine}");

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



            catch (Exception e)
            {

                Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{e.InnerException}{Environment.NewLine}");

            }
            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return string.Empty;
        }
        public long GetDirectorySize(string path)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                return directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                                   .Sum(file => file.Length);
            }

            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
            return 0;
        }

        public string SizeSuffix(long value)
        {
            try
            {
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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
            return null;
        }
        public static List<DirectoryInfo> ParseDirectoryStrings(string filePath, HashSet<string> folderNames)
        {
            List<DirectoryInfo> directoryInfoList = new List<DirectoryInfo>();
            var text = File.ReadAllLines(filePath);

            foreach (string directoryString in text)
            {
                string lastFolderName = Path.GetFileName(directoryString);

                if (folderNames.Contains(lastFolderName))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryString);
                    directoryInfoList.Add(directoryInfo);
                }
            }

            return directoryInfoList;
        }
        static string TruncatePath(string fullPath, string keyword)
        {   // Define the pattern to match "R2Northstar\" followed by any characters until the next directory separator
            string pattern = @"\\R2Northstar\\([^\\]+)";

            // Use Regex to match the pattern
            Match match = Regex.Match(fullPath, pattern, RegexOptions.IgnoreCase);

            // If a match is found, extract the captured group
            if (match.Success)
            {
                return "R2Northstar\\" + match.Groups[1].Value.Trim();
            }

            // If no match is found, return an empty string or handle it as needed
            return string.Empty;

        }

        void Open_Mod_Info(string FolderDir)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {


                try
                {
                   
                    if (Directory.Exists(FolderDir))
                    {
                        DispatchIfNecessary(async () =>
                        {
                            Current_MOD_PATH = FolderDir;
                            Dependency_Tree.Items.Clear();
                        });
                        List<string> Dependencies = new List<string> { };
                        string Dependencies_String = "";
                        string mod_Json = FindFirstFile(FolderDir, "mod.json");
                        string manifest_json = FindFirstFile(FolderDir, "manifest.json");
                        string Icon_File = FindFirstFile(FolderDir, "icon.png");
                        if (mod_Json != null && File.Exists(mod_Json))
                        {
                            var myJsonString = File.ReadAllText(mod_Json);
                            dynamic myJObject = JObject.Parse(myJsonString);
                            string name = "Name: " + myJObject.Name;
                            string version = "Version: " + myJObject.Version;
                            string Description = "Description: " + myJObject.Description;
                            long size = GetDirectorySize(FolderDir);
                            string size_str = "Mod Size on Disk: " + SizeSuffix(size);
                            string Content = Description + Environment.NewLine + version + Environment.NewLine + size_str.Replace(",", ".");


                            DispatchIfNecessary(async () =>
                            {
                                NAME.Content = myJObject.Name;
                                INFO_MOD_SIZE_SET.Content = SizeSuffix(size);
                                INFO_VERSION_MOD_SET.Content = TruncatePath(FolderDir, "packages");                                
                                INFO_VERSION_SET.Content = myJObject.Version;
                                Description_Box.Text = myJObject.Description;


                                if (Icon_File != null && File.Exists(Icon_File))
                                {
                                    BitmapImage bitmapx = new BitmapImage();

                                    bitmapx.BeginInit();
                                    bitmapx.UriSource = new Uri(Icon_File);
                                    bitmapx.EndInit();
                                    Image_BG.Source = bitmapx;

                                }
                            });
                            DispatchIfNecessary(async () =>
                            {
                                Options_Panel_Mod.Visibility = Visibility.Visible;
                            });
                            
                            if (manifest_json != null && File.Exists(manifest_json))
                            {

                                var mymanifestString = File.ReadAllText(manifest_json);
                                dynamic myMObject = JObject.Parse(mymanifestString);

                                for (var x = 0; x < myMObject.dependencies.Count; x++)
                                {
                                    if (myMObject.dependencies[x].ToString().Contains("northstar-Northstar") || myMObject.dependencies[x].ToString().Contains("ebkr-r2modman-"))
                                    {

                                        continue;
                                    }
                                    else
                                    {
                                        DispatchIfNecessary(async () =>
                                        {
                                            TreeViewItem treeViewItem = new TreeViewItem();
                                            treeViewItem.Header = VTOL.Resources.Languages.Language.REQUIRES + myMObject.dependencies[x].ToString();
                                            string[] modParts = myMObject.dependencies[x].ToString().Split('-');
                                            bool isHigherOrEqualVersion = false;
                                            // Check if the array has at least two parts (name and version)
                                            if (modParts.Length >= 1)
                                            {
                                                string modNameInMyObject = modParts[1];
                                                string modVersionInMyObject = modParts[2];
                                                GENERAL_MOD foundMod = Main.Current_Installed_Mods.FirstOrDefault(mod => string.Equals(mod.Name, modNameInMyObject, StringComparison.OrdinalIgnoreCase));
                                                  if(foundMod != null)
                                                {
                                                    isHigherOrEqualVersion = Version.Parse(foundMod.Version) >= Version.Parse(modVersionInMyObject);

                                                }
                                            }                                         
                                            // Choose the relative strength of the comparison - is it almost exactly equal? or is it just close?
                                            if (isHigherOrEqualVersion)
                                            {
                                                treeViewItem.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1F2FC132")); // Change to your desired hex value
                                            }
                                            else
                                            {
                                                treeViewItem.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#69E84040")); // Change to your desired hex value

                                            }

                                            Dependency_Tree.Items.Add(treeViewItem);
                                            SlowBlink(treeViewItem,0.7);

                                        });
                                    }

                                }




                            }
                            else
                            {
                                DispatchIfNecessary(async () =>
                                {
                                    Dependency_Tree.Items.Add(VTOL.Resources.Languages.Language.MANIFESTFILENOTFOUND);
                                });

                                //Snackbar.Title = VTOL.Resources.Languages.Language.WARNING;
                                //Snackbar.Message = "The manifest File Cannot Be accessed or Found!";
                                //Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                                //Snackbar.Show();
                            }





                        }
                        else
                        {
                            DispatchIfNecessary(async () =>
                            {
                                Snackbar.Title = VTOL.Resources.Languages.Language.ERROR;
                                Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                                Snackbar.Message = VTOL.Resources.Languages.Language.TheModInformationFileCannotBeAccessedOrFound;
                                Snackbar.Show();
                            });
                        }




                    }





                }

                catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

                }



            };

            worker.RunWorkerAsync();
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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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


                        Delete_Mod(Name_,Button_.ToolTip.ToString());

                    }
                }






            }

            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
            return null;
        }
        string temp_Dir;
        void Delete_Mod(string Mod_name, string FolderDir)
        {



            try
            {

                //string FolderDir = Find_Folder(Mod_name, User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\packages");
                if (Directory.Exists(FolderDir))
                {
                    temp_Dir = FolderDir;

                    Dialog.Refresh();
                    Dialog.Message = null;
                    Dialog.ButtonLeftName = "Yes";
                    Dialog.ButtonLeftAppearance = Wpf.Ui.Common.ControlAppearance.Success;
                    Dialog.ButtonRightName = "Cancel";

                    Dialog.ButtonRightAppearance = Wpf.Ui.Common.ControlAppearance.Secondary;
                    Dialog.Title = VTOL.Resources.Languages.Language.DELETEMOD;
                    string Content = (VTOL.Resources.Languages.Language.AreYouSureYouWantToDeleteTheMod) + Environment.NewLine + Mod_name + Environment.NewLine + VTOL.Resources.Languages.Language.Permanently;
                    Dialog.Message = Content;
                    Dialog.ButtonLeftClick += new RoutedEventHandler(Delete_Action);
                    Dialog.Tag = FolderDir;
                    Dialog.Show();
                    workingmod = Mod_name;



                }



            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }

        }
       
        protected virtual void Delete_Action(object sender, RoutedEventArgs e)
        {

            try
            {
                var btn = sender as Wpf.Ui.Controls.Dialog;

                string Json_Path = FindFirstFile(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\", "enabledmods.json");

               
                if (File.Exists(Json_Path))
                {
                    // Read the JSON file
                    string jsonContent = File.ReadAllText(Json_Path);

                    if (jsonContent.IsNullOrEmpty() != true && jsonContent.Length > 5)
                    {// Parse the JSON content


                        JObject jsonObject = JObject.Parse(jsonContent);
                        string Name = workingmod;
                        if (jsonObject.TryGetValue(Name, out _))
                        {
                            jsonObject.Remove(Name);

                        }
                        // Convert back to JSON string
                        string updatedJson = jsonObject.ToString();

                        // string updatedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

                        // Write back to the file
                        File.WriteAllText(Json_Path, updatedJson);

                    }
                    else
                    {
                        File.WriteAllText(Json_Path, "{\t\t\n\n}");

                    }


                }

                string delete_mod_path = Dialog.Tag.ToString();
                if (Directory.Exists(temp_Dir))
                {

                    TryDeleteDirectory(temp_Dir, true);

                }


                Dialog.Hide();

                Call_Mods_From_Folder();

                temp_Dir = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

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
            
        }

        private void Mod_Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            _Completed_Mod_call = false;
        }

        private void DialogF_ButtonRightClick(object sender, RoutedEventArgs e)
        {
            DialogF.Hide();


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

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
            return null;
        }
        private void DialogF_ButtonLeftClick(object sender, RoutedEventArgs e)
        {
            Mod_List_Box.Refresh();

            if (IsValidPath(Mod_Settings_Mod_OLD_PATH))
            {
                bool isValid = TryDeleteDirectoryAsync(Mod_Settings_Mod_OLD_PATH, true).Result;
                if (isValid == true)
                {


                    DialogF.Hide();


                    Snackbar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                    Snackbar.Message = VTOL.Resources.Languages.Language.TheModAt + Mod_Settings_Mod_OLD_PATH + VTOL.Resources.Languages.Language.HasBeenDeleted;
                    Snackbar.Show();
                }
                else
                {
                    Snackbar.Title = VTOL.Resources.Languages.Language.ERROR;
                    Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                    Snackbar.Message = VTOL.Resources.Languages.Language.TheModAt + Mod_Settings_Mod_OLD_PATH + VTOL.Resources.Languages.Language.CouldNotBeDeleted;
                    Snackbar.Show();
                }


            }
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
                        DispatchIfNecessary(async () =>
                        {
                            Log.Warning("The File" + Target_Zip + "Is not a zip!!");
                            Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            Snackbar.Content = "The File " + Target_Zip + " Is noT a zip!!";
                        });


                    }

                    DispatchIfNecessary(async () =>
                    {

                        Snackbar.Title = VTOL.Resources.Languages.Language.SUCCESS;
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
                    Install_Mod_Zip(i, User_Settings_Vars.NorthstarInstallLocation + User_Settings_Vars.Profile_Path + @"\packages\" + Path.GetFileNameWithoutExtension(i));

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
                    Snackbar.Title = VTOL.Resources.Languages.Language.INFO;
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

        private void Exit_BTN_ADD_Prfl_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void EXIT(object sender, RoutedEventArgs e)
        {
            if (Image_BG.Source !=null && File.Exists(Image_BG.Source.ToString()))
            {
                Console.WriteLine(Image_BG.Source.ToString());
                File.Delete(Image_BG.Source.ToString());
            }
            Image_BG.Source = null;

            Options_Panel_Mod.Collapse();
            GC.Collect();

        }

        private void Options_Panel_Mod_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Image_BG.Source != null && File.Exists(Image_BG.Source.ToString()))
            {
                Console.WriteLine(Image_BG.Source.ToString());
                File.Delete(Image_BG.Source.ToString());
            }
            Image_BG.Source = null;
            Options_Panel_Mod.Collapse();


            GC.Collect();

        }

        private void Open_Folder__Click(object sender, RoutedEventArgs e)
        {
            if (IsValidPath(Current_MOD_PATH))
            {
                Open_Folder(Current_MOD_PATH);

            }
        }
      

        private void INFO_VERSION_MOD_SET_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void INFO_VERSION_MOD_SET_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void Page_Initialized(object sender, EventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, e) =>
                {



                    Call_Mods_From_Folder();

                    Check_Reverse(false);
                    GC.Collect();


                };

                worker.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}{ex.InnerException}{Environment.NewLine}");

            }
        }
    }
}
