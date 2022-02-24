using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using HandyControl;
using System.IO.Compression;
using System.IO;
using Path = System.IO.Path;
using System.Reflection;
using System.ComponentModel;
using Prism.Services.Dialogs;
using System.Diagnostics;
using WishLib = IWshRuntimeLibrary;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using Utils.Extensions;
using static VTOL.MainWindow;
using Microsoft.Xaml.Behaviors;
using System.Threading;
//****TODO*****//

//Migrate Release Parse to the New Updater Sys
//Migrate all the json code to the new wrapped Updater System.



//**************//
namespace VTOL
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class Server_Template_Selector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            var Item = item as Arg_Set;
            if (Item == null) { return null; }
                
            if (Item.Type == "PORT" || Item.Type == "STRING" || Item.Type=="STRINGQ")
                return
                    element.FindResource("NormalBox")
                    as DataTemplate;
           else if (Item.Type == "INT")
                return
                    element.FindResource("IntBox")
                    as DataTemplate;
            else if (Item.Type == "FLOAT")
                return
                    element.FindResource("FloatBox")
                    as DataTemplate;
            else if (Item.Type == "BOOL")
                return
                    element.FindResource("BOOLBox")
                    as DataTemplate;
            else if (Item.Type == "ONE_SELECT")
                return
                    element.FindResource("One_Select_Combo")
                    as DataTemplate;
             else
                return
                    element.FindResource("ComboBox")
                    as DataTemplate;


        }



      

    }
   
    public partial class MainWindow : Window
    {
       

        BitmapImage Vanilla = new BitmapImage(new Uri(@"/Resources/TF2_Vanilla_promo.gif", UriKind.Relative));
        BitmapImage Northstar = new BitmapImage(new Uri(@"/Resources/Northstar_Smurfson.gif", UriKind.Relative));
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        string LAST_INSTALLED_MOD = "";
        List<string> Mod_Directory_List_Active = new List<string>();
        List<string> Mod_Directory_List_InActive = new List<string>();
        private static String updaterModulePath;
        private readonly CollectionViewSource viewSource = new CollectionViewSource();
        public Server_Setup Server_Json;
        public bool Found_Install_Folder = false;
        public string Current_Install_Folder = "";
        private string NSExe;
        private bool NS_Installed;
        private WebClient webClient = null;
        string current_Northstar_version_Url;
        int failed_search_counter = 0;
        bool deep_Chk = false;
        List<string> Mod_List = new List<string>();
        bool do_not_overwrite_Ns_file = true;
        bool do_not_overwrite_Ns_file_Dedi = true;
        ArrayList itemsList = new ArrayList();
        ArrayList Mirror_Item_List = new ArrayList();
        public IEnumerable<string> Phrases { get; private set; }
        public List<string> Game_Modes_List = new List<string>();
        public List<string> Game_MAP_List = new List<string>();
        public List<string> Game_WEAPON_List = new List<string>();

        int completed_flag;
        public int pid;
        string Skin_Path = "";
        string Skin_Temp_Loc = "";
      
        public Thunderstore_V1 Thunderstore_;
        Updater Update;
        public bool Animation_Start_Northstar { get; set; }
        public bool Animation_Start_Vanilla { get; set; }
        public string Ns_dedi_File = "";
        public string Convar_File = "";
        bool Started_Selection = false;
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);

            do_not_overwrite_Ns_file = Properties.Settings.Default.Ns_Startup;
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;
            try
            {

                Phrases = new ObservableCollection<string>();


                //BG_panel_Main.BlurApply(40, new TimeSpan(0, 0, 1), TimeSpan.Zero);
              
                DataContext = this;
                Animation_Start_Northstar = false;
                Animation_Start_Vanilla = false;
                Write_To_Log("", true);
                LOG_BOX.IsReadOnly = true;
                Mod_Panel.Visibility = Visibility.Hidden;
                //  Load_Line.Visibility = Visibility.Hidden;
                skins_Panel.Visibility = Visibility.Hidden;
                Main_Panel.Visibility = Visibility.Visible;
                About_Panel.Visibility = Visibility.Hidden;
                Mod_Browse_Panel.Visibility = Visibility.Hidden;
                About_Panel.Visibility = Visibility.Hidden;
                Dedicated_Server_Panel.Visibility = Visibility.Hidden;
                Log_Panel.Visibility = Visibility.Hidden;
                Updates_Panel.Visibility = Visibility.Hidden;
                Drag_Drop_Overlay.Visibility = Visibility.Hidden;
                Drag_Drop_Overlay_Skins.Visibility = Visibility.Hidden;
                Select_Main();
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Install_Skin_Bttn.IsEnabled = false;
                Set_About();
                Badge.Visibility = Visibility.Collapsed;
                GC.Collect();
                this.VTOL.Title = String.Format("VTOL {0}", version);
                Check_For_New_Northstar_Install();
                GC.Collect();

                if (do_not_overwrite_Ns_file==true)
                {
                    Ns_Args.IsChecked = true;

                }
                else
                {

                    Ns_Args.IsChecked = false;

                }
                if (do_not_overwrite_Ns_file_Dedi == true)
                {
                    Ns_Args_Dedi.IsChecked = true;

                }
                else
                {

                    Ns_Args_Dedi.IsChecked = false;

                }





                string Header = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, @"../"));
                updaterModulePath = Path.Combine(Header, "VTOL_Updater.exe");
               
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Write_To_Log("Could Not Verify Dir" + Current_Install_Folder);
                Write_To_Log(e.StackTrace);

                HandyControl.Controls.Growl.ErrorGlobal("\nVTOL tried to check for an existing config (cfg), please manually select it.");
                //log.AppendText("\nThe Launcher Tried to Auto Check For an existing CFG, please use the manual Check to search.");



            }


            // HandyControl.Controls.Growl.InfoGlobal(Header);
            // Send_Info_Notif(Properties.Settings.Default.Version);
            try
            {
                if (Directory.Exists(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR"))
                {
                    try
                    {

                        Directory.Delete(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR", true);
                        GC.Collect();
                    }
                    catch (Exception ef)
                    {
                        Write_To_Log(ef.StackTrace);

                        Send_Fatal_Notif("a fatal error occurred, please check the logs and preferably contact us in the VTOL discord thread or create a github issue.");
                    }




                }
                if (Directory.Exists(Current_Install_Folder + @"\Thumbnails"))
                {
                    try
                    {
                        Directory.Delete(Current_Install_Folder + @"\Thumbnails", true);
                        GC.Collect();
                    }
                    catch (Exception ef)
                    {
                        Send_Fatal_Notif("a fatal error occurred, please check the logs and preferably contact us in the VTOL discord thread or create a github issue.");
                        Write_To_Log(ef.StackTrace);

                    }

                }


                if (Directory.Exists(@"C:\ProgramData\VTOL_DATA"))
                {




                    Current_Install_Folder = Read_From_TextFile_OneLine(@"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt");
                    if (Directory.Exists(Current_Install_Folder))
                    {
                        Found_Install_Folder = true;
                        Titanfall2_Directory_TextBox.Text = Current_Install_Folder;
                        // Install_Textbox.BackColor = Color.White;
                        Send_Info_Notif("\nFound installation location at" + Current_Install_Folder + "\n");
                        if (Directory.Exists(Current_Install_Folder))
                        {

                            NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                            Check_Integrity_Of_NSINSTALL();
                            if (NS_Installed == true)
                            {


                                Install_NS.Content = "Update/Repair Northstar";
                            }
                            else
                            {

                                Install_NS.Content = "Install Northstar";


                            }

                        }


                    }
                    else
                    {

                        Send_Warning_Notif("\nThe Launcher Tried to Auto Check For an existing CFG, Please Re-Install Northstar");
                    }
                }


                else
                {
                    Send_Warning_Notif("\nThe Launcher Tried to Auto Check For an existing CFG, Please Re-Install Northstar");


                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Write_To_Log("Could Not Verify Dir" + Current_Install_Folder);
                Send_Warning_Notif("\nThe Launcher Tried to Auto Check For an existing CFG, please use the manual Check to search.");
                Write_To_Log(e.StackTrace);



            }
            if (Titanfall2_Directory_TextBox.Text == null || Titanfall2_Directory_TextBox.Text == "")
            {

                Titanfall2_Directory_TextBox.Background = Brushes.Red;
            }
            else
            {
                Titanfall2_Directory_TextBox.Background = Brushes.White;


            }

            // Create Image Element

            //set image source
            //   Gif_Image.UriSource = new Uri(@"/Resources/TF2_Vanilla_promo.gif");

        }
        public void LIST_CLICK(object sender, RoutedEventArgs e)
        {

            Button btn = ((Button)sender);


        }
        private void Download_Install_Dynamic_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            //  Send_Info_Notif(button.Name);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ask Question?");
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            HandyControl.Controls.Growl.ClearGlobal();

        }

       async  Task  Thunderstore_Parse()


        {
            try
            {
                itemsList.Clear();
                Test_List.ItemsSource = null;
                Test_List.Items.Clear();
                /*
                Uri uri = new Uri("https://valheim.thunderstore.io/package/");
                string json;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.UserAgent = "GithubUpdater";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json =  reader.ReadToEnd();
                }
                Thunderstore_ = Thunderstore.FromJson(json);
                Send_Info_Notif(Thunderstore_.results.ToString());
              */




                Update = new Updater("https://gtfo.thunderstore.io/api/v1/package/");
                Update.Download_Cutom_JSON();

                // LoadListViewData();

                //Test_List.ItemsSource = null;
                //Test_List.ItemsSource = Update.Thunderstore.results;
                Test_List.ItemsSource = LoadListViewData();
            }
            catch (Exception ex)
            {
                Send_Fatal_Notif("Error Occured, Please Check Logs for details");
                Write_To_Log(ex.ToString());
            }
        }

        private void Test_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (Test_List.SelectedItem != null)
            {
                var var = (Test_List.SelectedItems.ToString());

                Send_Info_Notif(var);
            }
            */
        }


        class Button
        {
            public string Tag { get; set; }
            public string Name { get; set; }
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
        void Download_Install(object sender, RoutedEventArgs e)
        {
            try
            {


                Send_Info_Notif("Starting Download!, please do not be alarmed if there is no activity!.");
                var objname = ((System.Windows.Controls.Button)sender).Tag.ToString();
                string[] words = objname.Split("|");
                // Send_Success_Notif(words[0]);
                LAST_INSTALLED_MOD = (words[1]);

                parse_git_to_zip(words[0]);
            }catch (Exception ex)
            {
                Mod_Progress_BAR.Value = 0;
                Mod_Progress_BAR.ShowText = false;
                Send_Fatal_Notif("Error Occured, Please Check Logs for details");
                Write_To_Log(ex.ToString());
                Write_To_Log(ex.Message);

            }
        }
        void Open_Package_Webpage(object sender, RoutedEventArgs e)
        {
            var val = ((System.Windows.Controls.Button)sender).Tag.ToString();

            Send_Info_Notif("Opening - " + val);
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = val,
                UseShellExecute = true
            });
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


        private ArrayList LoadListViewData()
        {
            /*
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * ADDDDDDDDDDD DOWNLOAD PROGRES!!!!!!!!!!!!!!
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */
            // var myValue = ((Button)sender).Tag;
            string ICON = "";
            List<string> lst = new List<string> { };
            List<string> Icons = new List<string> { };
            List<string> Description = new List<string> { };
            List<string> File_Size_ = new List<string> { };
            List<int> Downloads = new List<int> { };

            string Tags = "";
            string downloads = "";
            string download_url = "";
            string Descrtiption = "";
            string FileSize = "";

            Icons.Clear();
            Description.Clear();
            lst.Clear();
            File_Size_.Clear();

            foreach (var item in Update.Thunderstore)
            {

                int rating = item.RatingScore;

                //Tag = item.Categories;
                Tags = String.Join(" , ", item.Categories);

                foreach (var items in item.versions)
                {

                    GC.Collect();

                    lst.Add(items.DownloadUrl);
                    Icons.Add(items.Icon);
                    Description.Add(items.Description);
                    File_Size_.Add(items.FileSize.ToString());
                    Downloads.Add(Convert.ToInt32(items.Downloads));

                    //   ICON = items.Icon;

                }
                lst.Sort();
                Icons.Sort();
                File_Size_.Sort();
                Description.Sort();

                download_url = (lst.Last());
                ICON = (Icons.Last());
                FileSize = (File_Size_.Last());
                Descrtiption = (Description.Last());
                downloads = (Downloads.Sum()).ToString();

                Description.Clear();
                File_Size_.Clear();
                lst.Clear();
                Icons.Clear();
                Downloads.Clear();


                if (int.TryParse(FileSize, out int value))
                {
                    FileSize = Convert_To_Size(value);
                }
                //   foreach (object o in lst)
                //     {
                //       MessageBox.Show(o.ToString());
                //  }

                //itemsList.Add(new Button {  Name = item.full_name.ToString() , Icon = item.latest.icon,date_created = item.date_created.ToString(), description = item.latest.description, owner=item.owner, Rating = rating});
                itemsList.Add(new Button { Name = item.Name, Icon = ICON, date_created = item.DateCreated.ToString(), description = Descrtiption, owner=item.Owner, Rating = rating, download_url = download_url +"|"+item.FullName.ToString(), Webpage  = item.PackageUrl, File_Size = FileSize, Tag = Tags, Downloads = downloads });
                Mirror_Item_List.Add(item.Name);

                // itemsList.Add(item.full_name.ToString());
            }

  
            return itemsList;

        }
        async Task Set_About()
        {
            About_BOX.IsReadOnly = true;
            Paragraph paragraph = new Paragraph();


            string Text = @"-This Application Installs The Northstar Launcher Created by BobTheBob and, installs the countless Mods Authored by the many Titanfall2 Modder’s.
Current Features:
*Updating Northstar Installations
*Installation of the Northstar Launcher By pulling the latest Json of the Northstar repo to access the download.
*Verifying a Titanfall 2 Northstar install
*Viewing Mods in the Mod List
*Toggling Mods On and off in the Northstar Client
*Downloading Mods from a Remote repo
*Downloading Mods from a Local Zip Download
*The ability to launch the Northstar Exe from the base.
*Install Skins From a Zip
*Launch The Dedicated Northsatar Server Client
*Browse and Install Mods From the Thunderstore Mod Repo
-Features in development:
*Intent to Create Custom Servers using this installer as a base to configure and fine tune setups


-Please Do suggest any new features and/or Improvements Through the Git issue tracker, or by sending me a personal Message.
Thank you again to all you Pilots, Hope we Wreak havoc on the Frontier for years to come.
More Instructions at this link - https://github.com/BigSpice/VTOL/blob/master/README.md

Gif image used on Northstar is from @Smurfson.

Big Thanks to - 
@Ralley#3354

@EmmaM#6474
@laundmo#7544
@E3VL#6669
Every cent counts towards feeding my baby Ticks - https://www.buymeacoffee.com/Ju1cy ";
            About_BOX.Document.Blocks.Clear();
            Run run = new Run(Text);
            paragraph.Inlines.Add(run);
            About_BOX.Document.Blocks.Add(paragraph);








        }

        private void SideMenuItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        void Select_Main()
        {


            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Visible;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = true;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = false;
            Update_Tab.IsSelected = false;

        }
        void Select_Mods()
        {
            Mod_Panel.Visibility = Visibility.Visible;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = true;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = false;
            Update_Tab.IsSelected = false;

            Call_Mods_From_Folder();
        }
        void Select_Skins()
        {
            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Visible;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = true;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = false;
            Update_Tab.IsSelected = false;

        }
        void Select_About()
        {

            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Visible;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = true;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = false;
            Update_Tab.IsSelected = false;

        }
        async Task Select_Mod_Browse()
        {
            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Visible;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = true;
            Update_Tab.IsSelected = false;
            Log.IsSelected = false;

        }
        void Select_Server()
        {
            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Visible;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = true;
            Mod_Browse.IsSelected = false;
            Update_Tab.IsSelected = false;
            Log.IsSelected = false;


        }
        void Select_Log()
        {
            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Visible;
            Updates_Panel.Visibility = Visibility.Hidden;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = true;
            Update_Tab.IsSelected = false;

        }
        void Select_Update()
        {
            Mod_Panel.Visibility = Visibility.Hidden;
            skins_Panel.Visibility = Visibility.Hidden;
            Main_Panel.Visibility = Visibility.Hidden;
            About_Panel.Visibility = Visibility.Hidden;
            Mod_Browse_Panel.Visibility = Visibility.Hidden;
            Dedicated_Server_Panel.Visibility = Visibility.Hidden;
            Log_Panel.Visibility = Visibility.Hidden;
            Updates_Panel.Visibility = Visibility.Visible;

            Skins.IsSelected = false;
            Main.IsSelected = false;
            About.IsSelected = false;
            Mods.IsSelected = false;
            Server_Configuration.IsSelected = false;
            Mod_Browse.IsSelected = false;
            Log.IsSelected = false;
            Update_Tab.IsSelected = true;
        }
        private void SideMenu_SelectionChanged(object sender, HandyControl.Data.FunctionEventArgs<object> e)
        {

            if (Main.IsSelected == true)
            {

                Select_Main();
            }
            if (Mods.IsSelected == true)
            {

                Select_Mods();

            }
            if (Skins.IsSelected == true)
            {

                Select_Skins();

            }
            if (About.IsSelected == true)
            {
                Select_About();

            }
            if (Mod_Browse.IsSelected == true)
            {

                Select_Mod_Browse();

            }
            if (Server_Configuration.IsSelected == true)
            {
                Select_Server();

            }
            if (Log.IsSelected == true)
            {
                Select_Log();

            }
            if (Update_Tab.IsSelected == true)
            {
                Select_Update();

            }


        }


        private void Mods_Selected(object sender, RoutedEventArgs e)
        {
        }
        void Send_Success_Notif(string Input_Message)
        {

            HandyControl.Controls.Growl.SuccessGlobal(Input_Message);
            Write_To_Log("\n" + Input_Message + '\n' + DateTime.Now.ToString());
        }

        void Send_Error_Notif(string Input_Message)
        {

            HandyControl.Controls.Growl.ErrorGlobal(Input_Message);
            Write_To_Log("\n" + Input_Message + '\n' + DateTime.Now.ToString());

        }

        void Send_Info_Notif(string Input_Message)
        {
            HandyControl.Controls.Growl.InfoGlobal(Input_Message);
            Write_To_Log("\n" + Input_Message + '\n' + DateTime.Now.ToString());


        }
        void Send_Warning_Notif(string Input_Message)
        {
            HandyControl.Controls.Growl.WarningGlobal(Input_Message);
            Write_To_Log("\n" + Input_Message + '\n' + DateTime.Now.ToString());

        }
        void Send_Fatal_Notif(string Input_Message)
        {


            HandyControl.Controls.Growl.FatalGlobal(Input_Message);
            Write_To_Log("\n" + Input_Message + '\n' + DateTime.Now.ToString());
        }


        private string Get_And_Set_Filepaths(string rootDir, string Filename)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@rootDir);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + Filename + "*.*");
                // Console.WriteLine(rootDir);
                // Console.WriteLine(Filename);

                foreach (FileInfo foundFile in filesInDir)
                {
                    if (foundFile.Name.Equals(Filename))
                    {
                        Console.WriteLine("Found");

                        string fullName = foundFile.FullName;
                        Console.WriteLine(fullName);
                        return fullName;



                    }
                    else
                    {

                        return "\nCould Not Find" + Filename + "\n";

                    }

                }
            }

            catch (Exception e)
            {
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                Write_To_Log("The process failed: " + e.ToString());
            }


            return "Exited with No Due to Missing Or Inaccurate Path";


        }
        private void FindNSInstall(string Search, string FolderDir)
        {
            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@FolderDir);


            if (Directory.Exists(FolderDir))
            {
                if (!IsDirectoryEmpty(rootDirs))
                {
                    WalkDirectoryTree(rootDirs, Search);

                    Console.WriteLine("Files with restricted access:");
                    foreach (string s in log)
                    {
                        Console.WriteLine(s);
                    }

                }
                else
                {

                    Send_Error_Notif("\n Directory is empty");
                    return;

                }


            }

            else

            {

                Send_Error_Notif("\n Invalid Path fed, that folder is not available or does not exist");
                failed_search_counter++;

            }



        }
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subdirs = directory.GetDirectories();

            return (files.Length == 0 && subdirs.Length == 0);
        }
        private static bool ListCheck<T>(IEnumerable<T> l1, IEnumerable<T> l2)
        {
            // TODO: Null parm checks
            if (l1.Intersect(l2).Any())
            {
                Console.WriteLine("matched");
                return true;
            }
            else
            {
                Console.WriteLine("not matched");
                return false;
            }
        }
        private static void AddShortcut(string Location_Of_Exe, string nameofshortcut)
        {
            string pathToExe = Location_Of_Exe;
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", Path.GetFileName(Location_Of_Exe));

            if (!Directory.Exists(appStartMenuPath))
                Directory.CreateDirectory(appStartMenuPath);

            string shortcutLocation = Path.Combine(appStartMenuPath, nameofshortcut + ".lnk");
            WishLib.WshShell shell = new WishLib.WshShell();
            WishLib.IWshShortcut shortcut = (WishLib.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Test App Description";
            //shortcut.IconLocation = @"C:\Program Files (x86)\TestApp\TestApp.ico"; //uncomment to set the icon of the shortcut
            shortcut.TargetPath = pathToExe;
            shortcut.Save();
        }
        private void Check_Integrity_Of_NSINSTALL()
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
                Console.WriteLine("Baseline");

                foreach (var Folder in FolderDir)
                {
                    string s = Folder.ToString().Substring(Folder.ToString().LastIndexOf("Titanfall2"));
                    Console.WriteLine(s);

                    current.Add(s);

                    //saveAsyncFile(s, @"C:\temp\NormalFolderStructure");

                }
                Console.WriteLine("current");

                foreach (var Folder in current)
                {

                    Console.WriteLine(Folder.ToString());

                }
                Console.WriteLine(Baseline.SequenceEqual(current));

                if (ListCheck(Baseline, current) == true)
                {
                    NS_Installed = true;


                }
                else
                {
                    Send_Error_Notif("\nDirectory Check Unsuccessful");
                    NS_Installed = false;


                }




            }
            else
            {

                NS_Installed = false;
            }

            if (NS_Installed == false)
            {

                Send_Error_Notif("\nNorthstar Launcher or Titanfall2 Was not found, do you want to Re-Install it by Clicking Install Northstar Launcher? (Please check the Integrity of Titanfall2 as well)");

                Install_NS_EXE_Textbox.Foreground = Brushes.Red;

            }
            else
            {

                Install_NS_EXE_Textbox.Foreground = Brushes.Green;
                Send_Success_Notif("Integrity Verified!");


            }
            Install_NS_EXE_Textbox.Text = NSExe;




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
            catch (System.IO.FileNotFoundException e)
            {
                Send_Error_Notif("Could Not find " + Filepath);
                Write_To_Log(e.StackTrace);


            }

            return line;

        }
        public List<string> Read_From_Text_File(string Filepath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (var sr = new StreamReader(Filepath))
                {
                    while (sr.Peek() >= 0)
                        lines.Add(sr.ReadLine());
                }
                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    Console.WriteLine("\t" + line);
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                Send_Error_Notif("Could Not find " + Filepath);
                Write_To_Log(e.StackTrace);


            }
            return lines;
        }
        public async Task saveAsyncFile(string Text, string Filename, bool ForceTxt = true, bool append = true)
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
                    await file.WriteLineAsync(Text);
                    file.Close();
                }
                else
                {

                    await File.WriteAllTextAsync(Filename, string.Empty);

                    await File.WriteAllTextAsync(Filename, Text);

                }
            }
            else
            {
                await File.WriteAllTextAsync(Filename, string.Empty);

                await File.WriteAllTextAsync(Filename, Text);


            }
        }
        private void Read_Latest_Release(string address, string json_name = "temp.json", bool Parse = true, bool Log_Msgs = true)
        {
            if (address != null)
            {
                if (Log_Msgs == true)
                {
                    // Send_Info_Notif("\nJson Download Started!");

                }
                WebClient client = new WebClient();
                Uri uri1 = new Uri(address);
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream data = client.OpenRead(address);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();



                s = s.Replace("[", "");
                s = s.Replace("]", "");
                if (Directory.Exists(@"C:\ProgramData\VTOL_DATA\temp"))
                {
                    saveAsyncFile(s, @"C:\ProgramData\VTOL_DATA\temp\" + json_name, false, false);
                    if (Log_Msgs == true)
                    {
                        //  Send_Info_Notif("\nJson Download completed!");
                        //  Send_Info_Notif("\nParsing Latest Release........");
                    }
                    if (Parse == true)
                    {
                        Parse_Release();
                    }

                }
                else
                {
                    Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\temp");
                    saveAsyncFile(s, @"C:\ProgramData\VTOL_DATA\temp\" + json_name, false, false);
                    if (Log_Msgs == true)
                    {
                        // Send_Info_Notif("\nJson Download completed!");
                        //    Send_Info_Notif("\nParsing Latest Release........");
                    }
                    if (Parse == true)
                    {
                        Parse_Release();
                    }
                }
                
            }
            else
            {


                Send_Error_Notif("\n Invalid Url Called");
            }

        }
        private string Parse_Custom_Release(string json_name = "temp.json")
        {

            if (File.Exists(@"C:\ProgramData\VTOL_DATA\temp\" + json_name))
            {
                var myJsonString = File.ReadAllText(@"C:\ProgramData\VTOL_DATA\temp\" + json_name);
                var myJObject = JObject.Parse(myJsonString);

                string out_ = myJObject.SelectToken("assets.browser_download_url").Value<string>();
                Properties.Settings.Default.Version = myJObject.SelectToken("tag_name").Value<string>();
                Properties.Settings.Default.Save();

                Send_Info_Notif("\nRelease Parsed! found - \n" + out_);
                File.Delete(@"C:\ProgramData\VTOL_DATA\temp\" + json_name);
                return out_;

            }
            else
            {
                Send_Error_Notif("\nRelease Not Found!!");

                return null;
            }
          

        }
        private void Parse_Release(string json_name = "temp.json")
        {
            if (File.Exists(@"C:\ProgramData\VTOL_DATA\temp\" + json_name))
            {
                var myJsonString = File.ReadAllText(@"C:\ProgramData\VTOL_DATA\temp\" + json_name);
                var myJObject = JObject.Parse(myJsonString);


                current_Northstar_version_Url = myJObject.SelectToken("assets.browser_download_url").Value<string>();
                Properties.Settings.Default.Version = myJObject.SelectToken("tag_name").Value<string>();
                Properties.Settings.Default.Save();

                Send_Info_Notif("\nRelease Parsed! found - \n" + current_Northstar_version_Url);
                File.Delete(@"C:\ProgramData\VTOL_DATA\temp\" + json_name);

            }
            else
            {
                Send_Error_Notif("\nRelease Not Found!!");


            }


        }
        private void DirectoryCopy(
              string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
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
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        private void Unpack_To_Location_Custom(string Target_Zip, string Destination, bool Clean_Thunderstore = false, bool clean_normal = false)
        {
            //ToDo Check if url or zip location
            //add drag and drop

            try
            {
                string Dir_Final = "";
                if (File.Exists(Target_Zip))
                {
                    if (!Directory.Exists(Destination))
                    {
                        Directory.CreateDirectory(Destination);
                    }
                    string fileExt = System.IO.Path.GetExtension(Target_Zip);
                    Console.WriteLine("It only works if i have this line :(");

                    if (fileExt == ".zip")
                    {
                        ZipFile.ExtractToDirectory(Target_Zip, Destination, true);
                        // Send_Success_Notif("\nUnpacking Complete!\n");
                        if (Clean_Thunderstore == true)
                        {

                            try
                            {



                                // Check if file exists with its full path    
                                if (File.Exists(Path.Combine(Destination, "icon.png")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "icon.png"));
                                }
                                else { Send_Warning_Notif("Cleanup Files not found"); }
                                if (File.Exists(Path.Combine(Destination, "manifest.json")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "manifest.json"));
                                }
                                else { Send_Warning_Notif("Cleanup Files not found"); }

                                if (File.Exists(Path.Combine(Destination, "README.md")))
                                {
                                    // If file found, delete it    
                                    File.Delete(Path.Combine(Destination, "README.md"));
                                }
                                else { Send_Warning_Notif("Cleanup Files not found"); }







                                string searchQuery3 = "*" + "mods" + "*";
                                string folderName = Destination;

                                var directory = new DirectoryInfo(folderName);
                                var Destinfo = new DirectoryInfo(Destination);


                                var Script = directory.GetDirectories(searchQuery3, SearchOption.AllDirectories);


                                foreach (var d in Script)
                                {
                                    DirectoryInfo di = new DirectoryInfo(d.FullName);
                                    DirectoryInfo[] diArr = di.GetDirectories();
                                    string firstFolder = diArr[0].FullName;

                                    if (Directory.Exists(firstFolder))
                                    {
                                        Dir_Final = Destinfo.Parent.FullName + @"\" + diArr[0].Name;
                                        if ((Destinfo.Parent.FullName + @"\" + diArr[0].Name).Contains("keyvalues") || (Destinfo.Parent.FullName + @"\" + diArr[0].Name).Contains("vpk") || (Destinfo.Parent.FullName + @"\" + diArr[0].Name).Contains("materials") || (Destinfo.Parent.FullName + @"\" + diArr[0].Name).Contains("resource") || (Destinfo.Parent.FullName + @"\" + diArr[0].Name).Contains("scripts"))
                                        {
                                            Send_Error_Notif("Mod has been Detected as incompatible!, The mod creator must be contacted to remedy this issue!");
                                            Send_Warning_Notif("If the mod is enabled please disable it immediately!");
                                            if (Directory.Exists(Current_Install_Folder + @"\NS_Downloaded_Mods"))
                                            {
                                                Directory.Delete(Current_Install_Folder + @"\NS_Downloaded_Mods", true);
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            CopyFilesRecursively(firstFolder, Destinfo.Parent.FullName + @"\" + diArr[0].Name);


                                        }
                                    }
                                    if (Directory.Exists(Destinfo.Parent.FullName + @"\" + diArr[0].Name + @"\" + "Locked_Folder"))
                                    {
                                        Directory.Delete(Destinfo.Parent.FullName + @"\" + diArr[0].Name + @"\" + "Locked_Folder", true);

                                    }
                                    //   DirectoryCopy(d.Parent.FullName,Destination, true);

                                }
                                Directory.Delete(Destination, true);
                                if (Dir_Final == "")
                                {

                                    Send_Error_Notif("Mod has been Detected as incompatible!, The mod creator must be contacted to remedy this issue!");
                                    Send_Warning_Notif("If the mod is enabled please disable it immediately!");

                                    return;
                                }
                                else
                                {
                                    Send_Info_Notif("Unpacked " + Path.GetFileName(Target_Zip) + " to " + Dir_Final);
                                    Send_Success_Notif("Installed - " + LAST_INSTALLED_MOD);

                                }
                                if (Directory.Exists(Current_Install_Folder + @"\NS_Downloaded_Mods"))
                                {
                                    Directory.Delete(Current_Install_Folder + @"\NS_Downloaded_Mods", true);
                                }

                            }
                            catch (IOException ioExp)
                            {
                                Write_To_Log(ioExp.Message);
                                Send_Warning_Notif(" Issue Detected, Please Check Logs!");

                            }


                        }
                    }
                    else
                    {
                        //Main_Window.SelectedTab = Main;

                        Send_Error_Notif("\nObject Is Not a Zip!\n");


                    }



                }
                else if (File.Exists(Target_Zip) && !Directory.Exists(Destination))
                {
                    Directory.CreateDirectory(Destination);
                    string fileExt = System.IO.Path.GetExtension(Target_Zip);

                    if (fileExt == ".zip")
                    {
                        if (clean_normal == true)
                        {
                            //TODO
                        //    string folderName = Destination;

                        //    var directory = new DirectoryInfo(folderName);
                         //   var Destinfo = new DirectoryInfo(Destination);
                            ZipFile.ExtractToDirectory(Target_Zip, Destination, true);

                        }
                        else
                        {
                            ZipFile.ExtractToDirectory(Target_Zip, Destination, true);
                            // Send_Success_Notif("\nUnpacking Complete!\n");
                        }
                        }
                    else
                    {
                        //Main_Window.SelectedTab = Main;
                        Send_Fatal_Notif("\nObject Is Not a Zip!\n");


                    }
                }
                else
                {
                    if (!File.Exists(Target_Zip))
                    {
                        Send_Error_Notif("\nTarget Zip Does Not exist!!!!!!\n");


                    }
                    if (!Directory.Exists(Destination))
                    {
                        Send_Error_Notif("\nTarget Location Does Not exist, please Double Check or Browse for the correct install location\n");

                    }
                }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.ToString());
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

            }
        }
        private void Unpack_To_Location(string Target_Zip, string Destination_Zip)
        {
            if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\Northstar.Client\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder + @"\R2Northstar\mods\Northstar.Client\Locked_Folder", true);

            }
            if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\Northstar.Custom\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder + @"\R2Northstar\mods\Northstar.Custom\Locked_Folder", true);


            }
            if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\Northstar.CustomServers\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder + @"\R2Northstar\mods\Northstar.CustomServers\Locked_Folder", true);


            }



            Send_Info_Notif("\nUnpacking " + Path.GetFileName(Target_Zip) + " to " + Destination_Zip);
            if (File.Exists(Target_Zip) && Directory.Exists(Destination_Zip))
            {
                string fileExt = System.IO.Path.GetExtension(Target_Zip);

                if (fileExt == ".zip")
                {
                    ZipFile.ExtractToDirectory(Target_Zip, Destination_Zip, true);
                    Send_Info_Notif("\nUnpacking Complete!");
                    if (File.Exists(Current_Install_Folder + @"\ns_startup_args_dedi.txt") && File.Exists(Current_Install_Folder + @"\ns_startup_args.txt"))
                    {
                        if (do_not_overwrite_Ns_file == true)
                        {
                            Send_Info_Notif("\nRestoring Files");
                            if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder\"))
                            {
                                System.IO.File.Copy(Current_Install_Folder + @"\TempCopyFolder\ns_startup_args.txt", Current_Install_Folder + @"\ns_startup_args.txt", true);

                                Send_Info_Notif("\nCleaning Residual");

                            }


                        }
                        if (do_not_overwrite_Ns_file_Dedi == true)
                        {
                            Send_Info_Notif("\nRestoring Files");
                            if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder\"))
                            {
                                System.IO.File.Copy(Current_Install_Folder + @"\TempCopyFolder\autoexec_ns_server.cfg", Current_Install_Folder + @"\R2Northstar\mods\Northstar.CustomServers\mod\cfg\autoexec_ns_server.cfg", true);

                                System.IO.File.Copy(Current_Install_Folder + @"\TempCopyFolder\ns_startup_args_dedi.txt", Current_Install_Folder + @"\ns_startup_args_dedi.txt", true);
                                Send_Info_Notif("\nCleaning Residual");

                            }


                        }
                        if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder"))
                        {
                            Directory.Delete(Current_Install_Folder + @"\TempCopyFolder", true);
                        }
                        Send_Info_Notif("\nInstall Complete!");

                    }

                }
                else
                {
                    if (!File.Exists(Target_Zip))
                    {
                        Send_Error_Notif("\nTarget Zip Does Not exist!!!!!!");


                    }
                    if (!Directory.Exists(Destination_Zip))
                    {
                        Send_Error_Notif("\nTarget Location Does Not exist, please Double Check or Browse for the correct install location");

                    }
                }
            }
            else
            {

                // Main_Window.SelectedTab = Main;
                Send_Error_Notif("\nObject Is Not a Zip!\n");

            }
        }
        private bool Template_traverse(System.IO.DirectoryInfo root, String Search)
        {


            try
            {
                System.IO.DirectoryInfo[] subDirs = null;
                subDirs = root.GetDirectories();
                var last = subDirs.Last();
                //Log_Box.AppendText(last.FullName + "sdsdsdsd");
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    if (dirInfo.Name.Contains(Search))
                    {
                        // Console.WriteLine("Found Folder");
                        Console.WriteLine(dirInfo.FullName);
                        return true;

                    }
                    else if (last.Equals(dirInfo))
                    {
                        return false;
                    }
                    else
                    {

                        Console.WriteLine("Trying again at " + dirInfo);

                    }
                    if (dirInfo == null)
                    {
                        Console.WriteLine(dirInfo.FullName + "This is not a valid Folder????!");
                        continue;

                    }
                    // Resursive call for each subdirectory.
                }

                Console.WriteLine("\nCould not Find the Install at " + root + " - Continuing Traversal");

            }
            catch (Exception e)
            {
                Write_To_Log(e.Message);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                // Log_Box.AppendText("\nCould not Find the Install at " +root+ " - Continuing Traversal");
            }


            return false;

        }
        void WalkDirectoryTree(System.IO.DirectoryInfo root, String Search)
        {
           // System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            //// First, process all the files directly under this folder
            //try
            //{
            //    files = root.GetFiles("*.*");
            //}
            //// This is thrown if even one of the files requires permissions greater
            //// than the application provides.
            //catch (UnauthorizedAccessException e)
            //{

            //    log.Add(e.Message);
            //}

            //catch (System.IO.DirectoryNotFoundException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            try
            {
                //if (files != null)
                //{
                //    if (FolderMode == false)
                //    {
                //        foreach (System.IO.FileInfo fi in files)
                //        {
                //            if (fi.Name.Contains(Search))
                //            {
                //                Console.WriteLine("Found File");
                //                Console.WriteLine(fi.FullName);
                //                Console.WriteLine(fi.Directory);

                //                Found_Install_Folder = true;
                //                Found_Install = true; 
                //                break;
                //            }
                //            else
                //            {
                //                Console.WriteLine("Trying again 2");
                //                WalkDirectoryTree(root, Search, FolderMode);

                //            }


                //        }
                //    }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();


                var last = subDirs.Last();
                //Log_Box.AppendText(last.FullName + "sdsdsdsd");
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    if (dirInfo.Name.Contains(Search))
                    {
                        // Console.WriteLine("Found Folder");
                        //  Console.WriteLine(dirInfo.FullName);
                        Found_Install_Folder = true;
                        Current_Install_Folder = (dirInfo.FullName);
                        break;

                    }
                    else if (last.Equals(dirInfo) && Found_Install_Folder == false)
                    {
                        failed_search_counter++;
                        return;
                    }
                    else
                    {

                        Console.WriteLine("Trying again at " + dirInfo);
                        if (deep_Chk == true)
                        {
                            WalkDirectoryTree(dirInfo, Search);

                        }
                    }
                    if (dirInfo == null)
                    {
                        Console.WriteLine(dirInfo.FullName + "This is not a valid Folder????!");
                        continue;

                    }
                    // Resursive call for each subdirectory.
                }

                Send_Error_Notif("\nCould not Find the Install at " + root + " - Continuing Traversal");

            }
            catch (NullReferenceException e)
            {
                Write_To_Log(e.Message);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");


            }

        }
        private void parse_git_to_zip(string address)
        {

            Mod_Progress_BAR.Value = 0;
            Mod_Progress_BAR.ShowText = true;

            if (webClient != null)
                return;
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_Mod_Browser);
            if (Directory.Exists(Current_Install_Folder + @"\NS_Downloaded_Mods"))
            {

                webClient.DownloadFileAsync(new Uri(address), Current_Install_Folder + @"\NS_Downloaded_Mods\" + LAST_INSTALLED_MOD + ".zip");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback4);

            }
            else
            {
                Directory.CreateDirectory(Current_Install_Folder + @"\NS_Downloaded_Mods");
                webClient.DownloadFileAsync(new Uri(address), Current_Install_Folder + @"\NS_Downloaded_Mods\" + LAST_INSTALLED_MOD + ".zip");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback4);


            }







            //   Active_ListBox.Refresh();
            //   Inactive_ListBox.Refresh();


        }
        private  void DownloadProgressCallback4(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...", (string)e.UserState, e.BytesReceived,e.TotalBytesToReceive,e.ProgressPercentage);

            Mod_Progress_BAR.Value = e.ProgressPercentage;
        }
        private void Auto_Install_And_verify()
        {
            failed_search_counter = 0;
            Send_Info_Notif("\nLooking For Titanfall2 Install");
            while (Found_Install_Folder == false && failed_search_counter < 1)
            {

                Send_Info_Notif("\nAutomatically Looking For The Northstar And Titandfall Install :-)");
                //  Cursor.Current = Cursors.WaitCursor;
                // Log_Box.AppendText("\nLooking Under the Directory  -" +@"C:\Program Files (x86)\Steam");
                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Steam");

                //  Log_Box.AppendText("\nLooking Under the Directory -" +@"C:\Program Files (x86)\Origin Games");
                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Origin Games");

                // Log_Box.AppendText("\nLooking Under the Directory  -" +@"C:\Program Files\EA Games");
                FindNSInstall("Titanfall2", @"C:\Program Files\EA Games");
                if (Found_Install_Folder == false && failed_search_counter >= 1)
                {
                    Titanfall2_Directory_TextBox.Background = Brushes.Red;
                    Install_NS_EXE_Textbox.Background = Brushes.Red;
                    Send_Fatal_Notif("\nCould Not Find, Please Manually Navigate to a proper Titanfall2 installation");
                    break;


                }

            }
            if (Found_Install_Folder == true)
            {
                // Install_Textbox.Text = Current_Install_Folder;
                //  Install_Textbox.BackColor = Color.White;
                Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\VARS");
                saveAsyncFile(Current_Install_Folder, @"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt", false, false);
                // Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                Send_Success_Notif("Found The install - Checking integrity Now!");
                //Checking if the path Given Returned Something Meaningful. I know i could do this better, but its 3.37am and i feel like im dying from this cold :|.
                Check_Integrity_Of_NSINSTALL();
            }

        }
        private bool IsValidPath(string path, bool allowRelativePaths = false)
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
                isValid = false;
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");
                Write_To_Log(ex.StackTrace);
            }

            return isValid;
        }
        void Call_Mods_From_Folder()
        {
            bool install_Prompt = false;
            try
            {
                Enabled_ListBox.ItemsSource = null;
                Dsiabled_ListBox.ItemsSource = null;
                Mod_Directory_List_Active.Clear();
                Mod_Directory_List_InActive.Clear();
                Console.WriteLine("In Mods!");
                if (Current_Install_Folder == null || Current_Install_Folder == "" || !Directory.Exists(Current_Install_Folder))
                {
                    HandyControl.Controls.Growl.AskGlobal("Could Not find That Install Location !!!, please renavigate to the Correct Install Path!", isConfirmed =>
                     {
                         install_Prompt = isConfirmed;
                         return true;
                     });

                    if (install_Prompt == true)
                    {
                        Select_Main();
                    }



                }
                else
                {
                    if (Directory.Exists(Current_Install_Folder))
                    {
                        if (NS_Installed == true)
                        {
                            //   label6.Text = "ACTIVE\n"+Current_Install_Folder+@"\R2Northstar\mods\";
                            //    label5.Text = "INACTIVE\n"+Current_Install_Folder+@"\R2Northstar\mods\";
                            // checkedListBox1.Items.Clear();
                            string NS_Mod_Dir = Current_Install_Folder + @"\R2Northstar\mods";
                            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
                            //Log_Box.AppendText("Current Mod Dir Found At - "+NS_Mod_Dir);
                            if (!Directory.Exists(NS_Mod_Dir))
                            {
                                Send_Fatal_Notif("\nMod Directory is Empty");
                                // Main_Window.SelectedTab = Main;
                                Send_Fatal_Notif("\nNorthstar Is Not Installed Properly!, do you want to re-install it?.");

                            }
                            else if (IsValidPath(NS_Mod_Dir) == true)
                            {

                                System.IO.DirectoryInfo[] subDirs = null;
                                subDirs = rootDirs.GetDirectories();

                                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                                {
                                    if (IsDirectoryEmpty(dirInfo))
                                    {
                                        Send_Info_Notif("No inactive Mods Found");

                                    }
                                    if (Template_traverse(dirInfo, "Locked_Folder") == true)
                                    {

                                        Console.WriteLine("Inactive - " + dirInfo.Name);
                                        Mod_Directory_List_InActive.Add(dirInfo.Name);
                                        //  Log_Box.AppendText(dirInfo.Name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Active - " + dirInfo.Name);

                                        Mod_Directory_List_Active.Add(dirInfo.Name);
                                        //  Log_Box.AppendText(dirInfo.Name);

                                    }
                                }

                                ApplyDataBinding();
                            }
                            else
                            {

                                //   Log_Box.AppendText("\nInvalid Path");
                                //   Main_Window.SelectedTab = Main;
                                Send_Fatal_Notif("\nNorthstar Is Not Installed Properly!, do you want to re-install it?.");
                            }
                        }
                        else
                        {
                            // Main_Window.SelectedTab = Main;

                            Send_Fatal_Notif("\nNorthstar Is Not Installed!, do you want to install it?.");


                        }
                    }

                    else
                    {

                        Send_Fatal_Notif("\nInvalid Path To Titanfall2!");

                    }
                }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");


            }


        }
        void Install_NS_METHOD()
        {
            try { 

            completed_flag = 0;
            Read_Latest_Release("https://api.github.com/repos/R2Northstar/Northstar/releases/latest");
            //  Is file downloading yet?

            if (webClient != null)
                return;
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            string x = "";
            if (File.Exists(Current_Install_Folder + @"\ns_startup_args_dedi.txt") && File.Exists(Current_Install_Folder + @"\ns_startup_args.txt") && File.Exists(GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First()))
            {
                x = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();

                if (do_not_overwrite_Ns_file_Dedi == true)
                {
                    if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder"))
                    {
                        Send_Info_Notif("\nBacking up arg files");
                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args.txt", true);
                        System.IO.File.Copy(x, Current_Install_Folder + @"\TempCopyFolder\autoexec_ns_server.cfg", true);

                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args_dedi.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args_dedi.txt", true);
                    }
                    else
                    {

                        Send_Info_Notif("\nCreating Directory and Backing up arg files");
                        System.IO.Directory.CreateDirectory(Current_Install_Folder + @"\TempCopyFolder");
                        System.IO.File.Copy(x, Current_Install_Folder + @"\TempCopyFolder\autoexec_ns_server.cfg", true);

                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args.txt", true);
                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args_dedi.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args_dedi.txt", true);

                    }
                }
                if (do_not_overwrite_Ns_file == true)
                {
                    if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder"))
                    {
                        Send_Info_Notif("\nBacking up arg files");

                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args.txt", true);

                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args_dedi.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args_dedi.txt", true);
                    }
                    else
                    {

                        Send_Info_Notif("\nCreating Directory and Backing up arg files");
                        System.IO.Directory.CreateDirectory(Current_Install_Folder + @"\TempCopyFolder");

                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args.txt", true);
                        System.IO.File.Copy(Current_Install_Folder + @"\ns_startup_args_dedi.txt", Current_Install_Folder + @"\TempCopyFolder\ns_startup_args_dedi.txt", true);

                    }
                    Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\Releases\");
                    webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\VTOL_DATA\Releases\Northstar_Release.zip");

                    Send_Warning_Notif("\nStarting Install procedure!");



                }
                else
                {

                    Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\Releases\");
                    webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\VTOL_DATA\Releases\Northstar_Release.zip");
                    Send_Warning_Notif("\nStarting Install procedure!");



                }



            }
            else
            {
                Send_Error_Notif("\nCould Not Find the ns_startup_args_dedi.txt & ns_startup_args.txt");

                Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\Releases\");
                webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\VTOL_DATA\Releases\Northstar_Release.zip");
                Send_Warning_Notif("\nStarting Install procedure!");

            }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");


            }
        }
        private void CheckIfModenabled(string path)
        {

            if (Directory.Exists(path + @"\Disable_Corner"))
            {

                Console.WriteLine(path + "    This Mod is Disabled");

            }
            else
            {
                Console.WriteLine(path + "    This Mod is Enabled");



            }


        }
        private void Check_Args()
        {


            if (Directory.Exists(Current_Install_Folder))
            {


                if (File.Exists(Ns_dedi_File))
                {
                    Dedicated_Server_Startup_ARGS.Text = Ns_dedi_File;
                    Dedicated_Server_Startup_ARGS.Background = Brushes.White;
                    Arg_Box_Dedi.Text = Read_From_TextFile_OneLine(Ns_dedi_File);
                    GC.Collect();


                }
                else
                {
                    Send_Error_Notif("Err, File not found , please set it in filepaths!");
                    Arg_Box_Dedi.Text = "Err, File not found - ns_startup_args_dedi.txt";
                    Dedicated_Server_Startup_ARGS.Background = Brushes.Red;

                    GC.Collect();

                }


                if (File.Exists(GetFile(Current_Install_Folder, "ns_startup_args.txt").First()))
                {
                    Arg_Box.Text = Read_From_TextFile_OneLine(Current_Install_Folder + @"\ns_startup_args.txt");

                    GC.Collect();

                }
                else
                {
                    Send_Error_Notif("Err, File not found , please create it in the folder!");
                    Arg_Box.Text = "Err, File not found - ns_startup_args.txt";
                    GC.Collect();
                }

                if (File.Exists(Convar_File))
                {

                    Dedicated_Convar_ARGS.Text = Convar_File;
                    Dedicated_Convar_ARGS.Background = Brushes.White;

                    GC.Collect();

                }
                else
                {
                    Send_Error_Notif("Err, File not found , please set it in filepaths!");
                    Dedicated_Convar_ARGS.Background = Brushes.Red;

                    Dedicated_Convar_ARGS.Text = "Err, File not found - autoexec_ns_server.cfg";
                    GC.Collect();
                }
            }


            else
            {

                Send_Error_Notif("Err, Folder not found");
                GC.Collect();


            }
        }

        private void ApplyDataBinding()
        {
            Dsiabled_ListBox.ItemsSource = null;
            Dsiabled_ListBox.ItemsSource = Mod_Directory_List_InActive.ToArray();

            Enabled_ListBox.ItemsSource = null;
            Enabled_ListBox.ItemsSource = Mod_Directory_List_Active.ToArray();
        }
        void Move_List_box_Inactive_To_Active(ListBox Inactive)
        {
            try
            {
                string selected = null;
                if (Inactive.Items.Count != 0)
                {

                    if (Inactive.SelectedValue != null || Inactive.SelectedValue != "")
                    {
                        selected = Inactive.SelectedValue.ToString();
                        int index = Inactive.SelectedIndex;
                        if (Mod_Directory_List_Active != null && Mod_Directory_List_InActive != null)
                        {
                            Mod_Directory_List_InActive.RemoveAt(index);
                            Mod_Directory_List_Active.Add(selected);
                        }
                        ApplyDataBinding();
                        //  from.Items.RemoveAt(from.Items.IndexOf(from.SelectedItem));
                        //  To.Items.Add(selected);
                        if (index >= Inactive.Items.Count)
                        {
                            index--;

                        }
                        Inactive.SelectedIndex = index;
                    }
                    else
                    {
                        Inactive.SelectedIndex = 0;

                    }
                }
                else
                {
                    Send_Warning_Notif("Cannot Move a Mod From An empty List!");
                    return;

                }
            }
            catch (NullReferenceException ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Warning_Notif("You cant move a mod you havent selected!");
                return;
            }





        }
        void Move_List_box_Active_To_Inactive(ListBox Active)
        {
            try
            {
                string selected = null;


                if (Active.Items.Count != 0)
                {

                    if (Active.SelectedValue != null || Active.SelectedValue != "")
                    {
                        selected = Active.SelectedValue.ToString();

                        int index = Active.SelectedIndex;
                        if (Mod_Directory_List_Active != null && Mod_Directory_List_InActive != null)
                        {
                            Mod_Directory_List_Active.RemoveAt(index);
                            Mod_Directory_List_InActive.Add(selected);
                        }
                        ApplyDataBinding();
                        //  from.Items.RemoveAt(from.Items.IndexOf(from.SelectedItem));
                        //  To.Items.Add(selected);
                        if (index >= Active.Items.Count)
                        {
                            index--;

                        }
                        Active.SelectedIndex = index;
                    }
                    else
                    {
                        Active.SelectedIndex = 0;

                    }
                }
                else
                {
                    Send_Warning_Notif("Cannot Move a Mod From An emppty List!");
                    return;

                }
            }
            catch (NullReferenceException ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Warning_Notif("You cant move a mod you havent selected!");
                return;
            }


        }
        private static void MoveFiles(string sourceDir, string targetDir)
        {
            IEnumerable<FileInfo> files = Directory.GetFiles(sourceDir).Select(f => new FileInfo(f));
            foreach (var file in files)
            {
                File.Move(file.FullName, Path.Combine(targetDir, file.Name));
            }
        }
        public void Move_Mods()
        {

            try
            {
                List<string> Inactive = Dsiabled_ListBox.Items.OfType<string>().ToList();
                List<string> Active = Enabled_ListBox.Items.OfType<string>().ToList();

                foreach (var val in Inactive)
                {
                    if (val != null)
                    {
                        Console.WriteLine(val);
                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder + @"\R2Northstar\mods\" + val);

                        if (!IsDirectoryEmpty(rootDirs))
                        {
                            if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder"))
                            {
                                MoveFiles(Current_Install_Folder + @"\R2Northstar\mods\" + val, Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder");


                            }
                            else
                            {

                                Directory.CreateDirectory(Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder");
                                MoveFiles(Current_Install_Folder + @"\R2Northstar\mods\" + val, Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder");
                                Apply_Btn.BorderBrush = Brushes.Transparent;

                            }
                        }
                    }

                }
                foreach (var val in Active)
                {
                    if (val != null)
                    {
                        Console.WriteLine(Current_Install_Folder + @"\R2Northstar\mods\" + val);
                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder + @"\R2Northstar\mods\" + val);

                        if (!IsDirectoryEmpty(rootDirs))
                        {
                            if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder"))
                            {

                                MoveFiles(Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder", Current_Install_Folder + @"\R2Northstar\mods\" + val);
                                Directory.Delete(Current_Install_Folder + @"\R2Northstar\mods\" + val + @"\Locked_Folder", true);
                                Apply_Btn.BorderBrush = Brushes.Transparent;

                            }
                            else
                            {

                                //What happens if theres no folder???

                            }
                        }
                    }

                }

                Send_Success_Notif("Mods Moved Successfully!");
            }
            catch (Exception ex)
            {
                Write_To_Log(ex.Message);
                Send_Warning_Notif("Please check Your Mod Folder at - " + Current_Install_Folder + @"\R2Northstar\mods\");
                // Log_Box.AppendText(ex.StackTrace);

            }


        }
        IEnumerable<string> SearchAccessibleFiles(string root, string searchTerm)
        {
            var files = new List<string>();


            foreach (var file in Directory.EnumerateFiles(root).Where(m => m.Contains(searchTerm)))
            {
                // string FolderName = file.Split(Path.DirectorySeparatorChar).Last();
                string lastFolderName = new DirectoryInfo(System.IO.Path.GetDirectoryName(file)).FullName;

                //Console.WriteLine(lastFolderName);
                files.Add(file);
            }
            foreach (var subDir in Directory.EnumerateDirectories(root))
            {
                try
                {
                    files.AddRange(SearchAccessibleFiles(subDir, searchTerm));
                }
                catch (UnauthorizedAccessException ex)
                {
                    Send_Warning_Notif("No Access to the Directory!");
                    Write_To_Log(ex.StackTrace);

                }
            }

            return files;
        }
        public static string FindFirstFile(string path, string searchPattern)
        {
            string[] files;

            try
            {
                // Exception could occur due to insufficient permission.
                files = Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
            }
            catch (Exception ex)
            {
                

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

            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return string.Empty;
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
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                Write_To_Log(ex.Message);
            }
        }
        public static bool ZipHasFile(string Search, string zipFullPath)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipFullPath))  //safer than accepted answer
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Contains(Search, StringComparison.OrdinalIgnoreCase))
                    {

                        return true;
                    }
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
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

            webClient = null;
            Send_Info_Notif("\nDownload completed!");
            Unpack_To_Location(@"C:\ProgramData\VTOL_DATA\Releases\NorthStar_Release.zip", Current_Install_Folder);
            Install_NS.IsEnabled = true;
        }
        private void Completed_t(object sender, AsyncCompletedEventArgs e)
        {

            webClient = null;
            Send_Info_Notif("\nDownload completed!");
            Unpack_To_Location_Custom(Current_Install_Folder + @"\NS_Downloaded_Mods\MOD.zip", Current_Install_Folder + @"\R2Northstar\mods");
        }

        private void Completed_Mod_Browser(object sender, AsyncCompletedEventArgs e)
        {

            webClient = null;
            Send_Info_Notif("\nDownload completed!");
            Mod_Progress_BAR.Value = 0;
            Mod_Progress_BAR.ShowText = false;


            Unpack_To_Location_Custom(Current_Install_Folder+ @"\NS_Downloaded_Mods\"+LAST_INSTALLED_MOD+".zip", Current_Install_Folder+ @"\R2Northstar\mods\"+LAST_INSTALLED_MOD, true);
        }

        private void Check_Btn_Click(object sender, RoutedEventArgs e)
        {



            Auto_Install_And_verify();

        }

        private void Titanfall_2_Btn_MouseEnter(object sender, MouseEventArgs e)
        {

           //Button Bt = (Button)sender;
           // DoubleAnimation Anim = new DoubleAnimation(0, TimeSpan.FromSeconds(2));

            Banner_Image.Visibility = Visibility.Hidden;

            Gif_Image_Northstar.Visibility = Visibility.Hidden;
            Animation_Start_Vanilla = true;
            Gif_Image_Vanilla.Visibility = Visibility.Visible;
        }

        private void Northstar_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Gif_Image_Vanilla.Visibility = Visibility.Hidden;

            Banner_Image.Visibility = Visibility.Hidden;
            Animation_Start_Northstar = true;
            Gif_Image_Northstar.Visibility = Visibility.Visible;


        }
        void Check_For_New_Northstar_Install()
        {
            try
            {

                Updater Update = new Updater("R2Northstar", "Northstar");
                Update.Force_Version = Properties.Settings.Default.Version;
                Update.Force_Version_ = true;
                if (Update.CheckForUpdate())
                {
                    Badge.Visibility = Visibility.Visible;
                    Badge.Text = "New Update Available";
                }
                else
                {

                    Badge.Visibility = Visibility.Collapsed;


                }
            }
            catch (Exception ex)
            {
                Send_Warning_Notif("Please install Northstar again To Try Remedy This Error");
                Write_To_Log(ex.ToString());
            }



        }

        private void Titanfall_2_Btn_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(Current_Install_Folder + @"\" + "Titanfall2.exe"))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = Current_Install_Folder + @"\" + "Titanfall2.exe";
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Current_Install_Folder + @"\" + "Titanfall2.exe");
                    ;

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


                }
                else
                {

                    MessageBox.Show("Could Not Find Northstar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }

        }
        
        private void Browse_For_Skin_Click(object sender, RoutedEventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (Directory.Exists(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR"))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                    bitmap.EndInit();
                    Diffuse_IMG.Source = bitmap;


                    Glow_IMG.Source = bitmap;

                    Directory.Delete(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                    Write_To_Log(ef.StackTrace.ToString());
                }




            }
            if (Directory.Exists(Current_Install_Folder + @"\Thumbnails"))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                    bitmap.EndInit();
                    Diffuse_IMG.Source = bitmap;


                    Glow_IMG.Source = bitmap;

                    Directory.Delete(Current_Install_Folder + @"\Thumbnails", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                    Write_To_Log(ef.ToString());
                }

            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                Skin_Temp_Loc = openFileDialog.FileName;
                if (Skin_Temp_Loc == null || !File.Exists(Skin_Temp_Loc))
                {

                    Send_Error_Notif("\nInvalid Mod Zip Location chosen");
                    return;

                }
                else
                {
                    Skin_Path_Box.Text = Skin_Temp_Loc;
                    // Send_Success_Notif("\nSkin Found!");
                    if (ZipHasFile(".dds", Skin_Temp_Loc))
                    {
                        Send_Success_Notif("Compatible Skin Detected");
                        Compat_Indicator.Fill = Brushes.Green;
                        Install_Skin_Bttn.IsEnabled = true;
                        //   var directory = new DirectoryInfo(root);
                        // var myFile = (from f in directory.GetFiles()orderby f.LastWriteTime descending select f).First();
                        if (Directory.Exists(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR"))
                        {
                            Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";
                            ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"), true);

                        }
                        else
                        {

                            Directory.CreateDirectory(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR");
                            Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";

                            ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"));

                        }
                    }
                    else
                    {
                        Send_Error_Notif("Incompatible Skin Detected");
                        Compat_Indicator.Fill = Brushes.Red;
                        Install_Skin_Bttn.IsEnabled = false;

                    }

                    try
                    {
                        Console.WriteLine(Skin_Temp_Loc);
                        String Thumbnail = Current_Install_Folder + @"\Thumbnails\";
                        if (Directory.Exists(Thumbnail))
                        {
                            //DirectoryInfo dir = new DirectoryInfo(Thumbnail);
                            var Serached = SearchAccessibleFiles(Skin_Path, "col");
                            var firstOrDefault_Col = Serached.FirstOrDefault();
                            if (!Serached.Any())
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                if (File.Exists(firstOrDefault_Col))
                                {
                                    String col = Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png";
                                    Console.WriteLine(firstOrDefault_Col);
                                    if (File.Exists(col))
                                    {

                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                        img_1.Save(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(col);
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;
                                    }
                                    else
                                    {
                                        Console.WriteLine(col);
                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);

                                        img_1.Save(col);

                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(col);
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;

                                    }

                                }
                                else
                                {
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    Diffuse_IMG.Source = bitmap;

                                }


                            }

                            var Serached_ = SearchAccessibleFiles(Skin_Path, "ilm");
                            var firstOrDefault_ilm = Serached_.FirstOrDefault();
                            if (!Serached.Any())
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                if (File.Exists(firstOrDefault_ilm))
                                {
                                    if (File.Exists(firstOrDefault_ilm + ".png"))
                                    {

                                        Console.WriteLine(firstOrDefault_ilm);
                                        // Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;
                                    }
                                    else
                                    {

                                        DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                        img_2.Save(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");

                                        //Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;
                                    }
                                }
                                else
                                {
                                    // Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    Glow_IMG.Source = bitmap;
                                }

                            }




                        }

                        else
                        {

                            Directory.CreateDirectory(Thumbnail);

                            //DirectoryInfo dir = new DirectoryInfo(Thumbnail);
                            var Serached = SearchAccessibleFiles(Skin_Path, "col");
                            var firstOrDefault_Col = Serached.FirstOrDefault();
                            if (!Serached.Any())
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                if (File.Exists(firstOrDefault_Col))
                                {
                                    Console.WriteLine(firstOrDefault_Col);
                                    if (File.Exists(firstOrDefault_Col + ".png"))
                                    {

                                        //   Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;
                                    }
                                    else
                                    {
                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                        img_1.Save(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        // Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;

                                    }

                                }
                                else
                                {
                                    // Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    Diffuse_IMG.Source = bitmap;

                                }


                            }

                            var Serached_ = SearchAccessibleFiles(Skin_Path, "ilm");
                            var firstOrDefault_ilm = Serached_.FirstOrDefault();
                            if (!Serached.Any())
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                if (File.Exists(firstOrDefault_ilm))
                                {
                                    if (File.Exists(firstOrDefault_ilm + ".png"))
                                    {

                                        Console.WriteLine(firstOrDefault_ilm);
                                        //    Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;
                                    }
                                    else
                                    {

                                        DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                        img_2.Save(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        // Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;
                                    }
                                }
                                else
                                {
                                    //  Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    Glow_IMG.Source = bitmap;

                                }

                            }





                        }

                        //   Import_Skin_Bttn.Enabled=false;
                    }
                    catch (Exception ex)
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                        bitmap.EndInit();
                        Diffuse_IMG.Source = bitmap;

                        Glow_IMG.Source = bitmap;
                        Write_To_Log(ex.StackTrace);
                        Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                    }

                }

            }
        }

        private void Browse_Titanfall_2_Click(object sender, RoutedEventArgs e)
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
                        Send_Error_Notif("\nInvalid Install Location chosen");


                    }
                    else
                    {
                        Console.WriteLine(path);
                        Current_Install_Folder = path;
                        Found_Install_Folder = true;
                        Titanfall2_Directory_TextBox.Background = Brushes.White;

                        Titanfall2_Directory_TextBox.Text = Current_Install_Folder;
                        // Install_Textbox.BackColor = Color.White;
                        Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\VARS");
                        saveAsyncFile(Current_Install_Folder, @"C:\ProgramData\VTOL_DATA\VARS\INSTALL.txt", false, false);
                        //Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                        NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                        Check_Integrity_Of_NSINSTALL();

                    }

                }
            }
            catch (Exception ex)
            {

                Send_Fatal_Notif("\nIssue with File path, please Rebrowse.");
                Write_To_Log(ex.Message);
            }
        }

        private void Install_NS_Click(object sender, RoutedEventArgs e)
        {
            Badge.Visibility = Visibility.Collapsed;

            Install_NS.IsEnabled = false;





            do_not_overwrite_Ns_file = Properties.Settings.Default.Ns_Startup;
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;
            Install_NS_METHOD();


        }

        private void Northstar_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = NSExe;
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);
                    

                    // procStartInfo.Arguments = args;

                    process.StartInfo = procStartInfo;

                    process.Start();
                    int id = process.Id;
                    pid = id;
                    Process tempProc = Process.GetProcessById(id);
                    WindowState = WindowState.Minimized;
                    // this.Visible = false;
                    // Thread.Sleep(5000);
                    // tempProc.WaitForExit();
                    // this.Visible = true;

                    // Process process = Process.Start(NSExe, Arg_Box.Text);
                    process.Close();


                }
                else
                {

                    MessageBox.Show("Could Not Find Northstar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }
        }

        private void Enable_Mod_Click(object sender, RoutedEventArgs e)
        {
            if (Dsiabled_ListBox.SelectedIndex == 0)
            {
                Send_Warning_Notif("No Mods in List");
            }
            Move_List_box_Inactive_To_Active(Dsiabled_ListBox);

        }

        private void Disable_Mod_Click(object sender, RoutedEventArgs e)
        {
            if (Enabled_ListBox.SelectedIndex == 0)
            {
                Send_Warning_Notif("No Mods in List");
            }
            Move_List_box_Active_To_Inactive(Enabled_ListBox);

        }

        private void Apply_Btn_Click(object sender, RoutedEventArgs e)
        {
            Move_Mods();

        }

        private void Browse_For_Mod_zip_Btn_Click(object sender, RoutedEventArgs e)
        {
            Apply_Btn.BorderBrush = Brushes.Red;
            try
            {
                var File = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();

                // Show the FolderBrowserDialog.  
                var result = File.ShowDialog();
                if (result == true)
                {
                    string path = File.FileName;
                    if (path == null || !File.CheckFileExists)
                    {

                        Send_Error_Notif("\nInvalid Mod Zip Location chosen");


                    }
                    else
                    {
                        string FolderName = path.Split(Path.DirectorySeparatorChar).Last();
                        Browse_For_MOD.Text = path;
                        Console.WriteLine(path);
                        Console.WriteLine("The Folder Name is-" + FolderName + "\n\n");
                        Unpack_To_Location_Custom(path, Current_Install_Folder + @"\R2Northstar\mods");
                        Call_Mods_From_Folder();

                        ApplyDataBinding();
                    }

                }
            }
            catch (Exception ex)
            {

                Send_Error_Notif("\nIssue with File path, please Rebrowse.");
                Write_To_Log(ex.Message);
            }
        }

        private void Install_Skin_Bttn_Click(object sender, RoutedEventArgs e)
        {
            Skin_Path_Box.Text = "";
            Compat_Indicator.Fill = Brushes.Gray;



            //Block Taken From Skin Tool
            List<string> FileList = new List<string>();
            FindSkinFiles(Skin_Path, FileList, ".dds");

            foreach (var i in FileList)
                Console.WriteLine(i);

            var matchingvalues = FileList.FirstOrDefault(stringToCheck => stringToCheck.Contains(""));
            for (int i = 0; i < FileList.Count; i++)
            {
                if (FileList[i].Contains("col")) // (you use the word "contains". either equals or indexof might be appropriate)
                {
                    Console.WriteLine(i);
                }
            }
            int DDSFolderExist = 0;

            DDSFolderExist = FileList.Count;
            if (DDSFolderExist == 0)
            {
                MessageBox.Show("Could Not Find Skins in Zip??");
                //   throw new Exception(rm.GetString("FindSkinFailed"));
            }

            foreach (var i in FileList)
            {
                int FolderLength = Skin_Path.Length;
                String FileString = i.Substring(FolderLength);
                int imagecheck = ImageCheck(i);
                //the following code is waiting for the custom model
                Int64 toseek = 0;
                int tolength = 0;
                int totype = 0;

                if (IsPilot(i))
                {

                    Titanfall2_SkinTool.Titanfall2.PilotData.PilotDataControl pdc = new Titanfall2_SkinTool.Titanfall2.PilotData.PilotDataControl(i, imagecheck);
                    toseek = Convert.ToInt64(pdc.Seek);
                    tolength = Convert.ToInt32(pdc.Length);
                    totype = Convert.ToInt32(pdc.SeekLength);
                }
                else //if(IsWeapon(i))
                {


                    Titanfall2_SkinTool.Titanfall2.WeaponData.WeaponDataControl wdc = new Titanfall2_SkinTool.Titanfall2.WeaponData.WeaponDataControl(i, imagecheck);
                    toseek = Convert.ToInt64(wdc.FilePath[0, 1]);
                    tolength = Convert.ToInt32(wdc.FilePath[0, 2]);
                    totype = Convert.ToInt32(wdc.FilePath[0, 3]);

                }

                StarpakControl sc = new StarpakControl(i, toseek, tolength, totype, Current_Install_Folder, "Titanfall2", imagecheck, "Replace");
            }

            FileList.Clear();
            Send_Success_Notif("Installed!");
            DirectoryInfo di = new DirectoryInfo(Skin_Path);
            FileInfo[] files = di.GetFiles();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
            bitmap.EndInit();
            Glow_IMG.Source = bitmap;

            Diffuse_IMG.Source = bitmap;
            try
            {
                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir_ in di.GetDirectories())
                {
                    dir_.Delete(true);
                }
                Directory.Delete(Skin_Path);



                Console.WriteLine("Files deleted successfully");
                GC.Collect();
                Install_Skin_Bttn.IsEnabled = false;



            }
            catch (Exception ef)
            {
                Write_To_Log(ef.StackTrace);

                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");
            }
        }
        void Write_To_Log(string Text, bool clear_First = false)
        {
            Paragraph paragraph = new Paragraph();

            if (clear_First == true)
            {
                LOG_BOX.Document.Blocks.Clear();

                Run run = new Run(Text);
                paragraph.Inlines.Add(run);
                LOG_BOX.Document.Blocks.Add(paragraph);

            }
            else
            {


                Run run = new Run(Text);
                paragraph.Inlines.Add(run);
                LOG_BOX.Document.Blocks.Add(paragraph);
            }
        }
        private void Save_LOG_Click(object sender, RoutedEventArgs e)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            TextRange Log_Box = new TextRange(
        // TextPointer to the start of content in the RichTextBox.
        LOG_BOX.Document.ContentStart,
        // TextPointer to the end of content in the RichTextBox.
        LOG_BOX.Document.ContentEnd
    );
            if (Directory.Exists(@"C:\ProgramData\VTOL_DATA\Logs"))
            {
                if (File.Exists(@"C:\ProgramData\VTOL_DATA\Logs\" + date + "-LOG_MODMANAGER V-" + version))
                {
                    string Accurate_Date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    saveAsyncFile("\n\n" + Accurate_Date + "\n\n", @"C:\ProgramData\VTOL_DATA\Logs\" + date + "-LOG_MODMANAGER V-" + version, true, true);
                    saveAsyncFile(Log_Box.Text, @"C:\ProgramData\VTOL_DATA\Logs\" + date + "-LOG_MODMANAGER V-" + version, true, true);
                    Send_Success_Notif("Saved Successfully to - " + @"C:\ProgramData\VTOL_DATA\Logs");
                }
                else
                {

                    saveAsyncFile(Log_Box.Text, @"C:\ProgramData\VTOL_DATA\Logs\" + date + "-LOG_MODMANAGER V-" + version, true, false);
                    Send_Success_Notif("Saved Successfully to - " + @"C:\ProgramData\VTOL_DATA\Logs");


                }



            }
            else
            {
                Directory.CreateDirectory(@"C:\ProgramData\VTOL_DATA\Logs");
                saveAsyncFile(Log_Box.Text, @"C:\ProgramData\VTOL_DATA\Logs\" + date + " -LOG_MODMANAGER" + version, true, false);
                Send_Success_Notif("Saved Successfully to - " + @"C:\ProgramData\VTOL_DATA\Logs");

            }
        }

        private void Clear_LOG_Click(object sender, RoutedEventArgs e)
        {
            Write_To_Log("", true);
        }
    
        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Dispatcher.BeginInvoke(
        new ThreadStart(() => Thunderstore_Parse()));
            }
            finally
            {
               
            }


        }

        private void Test_List_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;

        }

        private void Browse_For_MOD_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dedicated_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(Current_Install_Folder + @"\ns_startup_args_dedi.txt"))
                {
                    saveAsyncFile(Arg_Box_Dedi.Text, Current_Install_Folder + @"\ns_startup_args_dedi.txt", false, false);


                }
                else
                {
                    Console.WriteLine("Err, File not found ns_startup_args_dedi");

                }

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = Current_Install_Folder + @"\r2ds.bat";
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);


                    // procStartInfo.Arguments = "-dedicated -multiple";

                    process.StartInfo = procStartInfo;

                    process.Start();
                    // int id = process.Id;
                    //  pid = id;
                    // Process tempProc = Process.GetProcessById(id);
                    // this.Visible = false;
                    // Thread.Sleep(5000);
                    // tempProc.WaitForExit();
                    // this.Visible = true;

                    // Process process = Process.Start(NSExe, Arg_Box.Text);
                    process.Close();



                }
                else
                {

                    MessageBox.Show("Could Not Find Dedicated bat!");


                }
            }
            else
            {

                MessageBox.Show("Could Not Find Dedicated bat!");


            }

        }


        private void Launch_Northstar_Advanced_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Current_Install_Folder+@"\ns_startup_args.txt"))
            {
                saveAsyncFile(Arg_Box.Text, Current_Install_Folder + @"\ns_startup_args.txt", false, false);


            }
            else
            {
                Console.WriteLine("Err, File not found");

            }

            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = NSExe;
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);
                    ;

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


                }
                else
                {

                    MessageBox.Show("Could Not Find Northstar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }
        }

        private void Ns_Args_Unchecked(object sender, RoutedEventArgs e)
        {
            Write_To_Log("\nOVERWRITE ns_startup_args.txt ENABLED!");
            Properties.Settings.Default.Ns_Startup = false;
            Properties.Settings.Default.Save();
            do_not_overwrite_Ns_file= Properties.Settings.Default.Ns_Dedi;

        }

        private void Ns_Args_Checked(object sender, RoutedEventArgs e)
        {

            Write_To_Log("\nDo not overwrite ns_startup_args.txt ENABLED! - this will backup and restore the original ns_startup_args and from the folder");
            Properties.Settings.Default.Ns_Startup = true;
            Properties.Settings.Default.Save();
            do_not_overwrite_Ns_file= Properties.Settings.Default.Ns_Dedi;

        }

        private void Ns_Args_Dedi_Checked(object sender, RoutedEventArgs e)
        {
            Write_To_Log("\nDo not overwrite ns_startup_args_Dedi.txt ENABLED! - this will backup and restore the original ns_startup_args_dedi from the folder");
            Properties.Settings.Default.Ns_Dedi = true;
            Properties.Settings.Default.Save();
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;

        }

        private void Ns_Args_Dedi_Unchecked(object sender, RoutedEventArgs e)
        {
            Write_To_Log("\nOVERWRITE ns_startup_args_Dedi.txt ENABLED!");
            Properties.Settings.Default.Ns_Dedi = false;
            Properties.Settings.Default.Save();
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;
        }

        private void Gif_Image_Northstar_AnimationStarted(DependencyObject d, XamlAnimatedGif.AnimationStartedEventArgs e)
        {

        }

        private void Check_For_Updates_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(updaterModulePath))
            {
                //   StartSilent();
                Process process = Process.Start(updaterModulePath, "/checknow ");
                // process.Close();
            }
            else
            {
                Send_Error_Notif("Please Be Aware That your Updater Exe is not in the Home Folder Of VTOL");

            }
        }

        private void Config_Updates_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(updaterModulePath))
            {
                try
                {


                    Process[] processes = Process.GetProcessesByName(updaterModulePath);
                    if (processes.Length > 0)
                        processes[0].CloseMainWindow();
                }
                catch(Exception ex)
                {
                    Write_To_Log(ex.Message);

                }
                Process process = Process.Start(updaterModulePath, "/configure");
                process.Close();

            }
            else
            {
                Send_Error_Notif("Please Be Aware That your Updater Exe is not in the Home Folder Of the VTOL");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mirror_Item_List.Reverse();
            foreach (string element in Mirror_Item_List)
            {


                Send_Info_Notif(element);
            }// CollectionViewSource.GetDefaultView(Test_List.ItemsSource).Refresh();

        }

        private void OnKeyDownHandler_Dedi_Arg(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    if (File.Exists(Current_Install_Folder + @"\ns_startup_args_dedi.txt"))
                    {
                        saveAsyncFile(Arg_Box_Dedi.Text, Current_Install_Folder + @"\ns_startup_args_dedi.txt", false, false);

                        Send_Success_Notif("Saved to - ns_startup_args_dedi.txt");
                    }
                    else
                    {
                        Send_Fatal_Notif("\nIssue with Auto Saving the File, Please Check Logs");

                        Write_To_Log("File Location Not Found!");

                    }
                }
            }
            catch (Exception ex)
            {

                Send_Fatal_Notif("\nIssue with Auto Saving the File, Please Check Logs");
                Write_To_Log(ex.Message);
            }
        }

        private void OnKeyDownHandler_Nrml_Arg(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {

                    if (File.Exists(Current_Install_Folder + @"\ns_startup_args.txt"))
                    {
                        saveAsyncFile(Arg_Box.Text, Current_Install_Folder + @"\ns_startup_args.txt", false, false);
                        Send_Success_Notif("Saved to - ns_startup_args.txt");


                    }
                    else
                    {
                        Send_Fatal_Notif("\nIssue with Auto Saving the File, Please Check Logs");
                        Write_To_Log("File Location Not Found!");

                    }
                }
            }
            catch (Exception ex)
            {

                Send_Fatal_Notif("\nIssue with Auto Saving the File, Please Check Logs");
                Write_To_Log(ex.Message);
            }
        }
        private void Validate_Combo_Box(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Started_Selection == true)
                {

                    if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
                    {
                        HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                        var Var = ((HandyControl.Controls.CheckComboBox)sender).Tag.ToString();
                        var Description = ((HandyControl.Controls.CheckComboBox)sender).ToolTip.ToString();

                        string[] Split = Var.Split("|");
                        string type = Split[0];
                        string name = Split[1];
                        string ARG = Split[2];
                        if (ARG!= null && ARG!= "" && ARG == "CONVAR")
                        {



                            string list = String.Join(",", comboBox.SelectedItems.Cast<String>().ToArray());
                            Write_convar_To_File(name, list, Description, true, Convar_File);
                            if (list == "" || list == null)
                            {

                                Send_Error_Notif("No Selection!, Removing Item!");
                                Write_convar_To_File(name, "REMOVE", Description, true, Convar_File);

                            }
                            comboBox.Foreground = Brushes.White;


                        }

                        else if (ARG!= null && ARG!= "" && ARG == "STARTUP")

                        {
                            string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());

                            Write_Startup_Arg_To_File(name, list, false, true, Ns_dedi_File);
                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            Send_Error_Notif("Could Not UnderStand Input Type!");
                        }
                    }
                    else
                    {

                        if (sender.GetType() == typeof(ComboBox))
                        {
                            ComboBox comboBox = (ComboBox)sender;
                            var Var = comboBox.Tag.ToString();
                            var Description = ((ComboBox)sender).ToolTip.ToString();

                            string[] Split = Var.Split("|");
                            string type = Split[0];
                            string name = Split[1];
                            string ARG = Split[2];
                            if (ARG == "CONVAR")
                            {

                                if (type == "BOOL")
                                {
                                    if (comboBox.SelectedIndex != -1)
                                    {
                                        if (comboBox.SelectedIndex == 1)
                                        {
                                            Write_convar_To_File(name, "1", Description, false, Convar_File);
                                            comboBox.Foreground = Brushes.White;


                                        }
                                        else
                                        {


                                            Write_convar_To_File(name, "0", Description, false, Convar_File);
                                            comboBox.Foreground = Brushes.White;

                                        }
                                    }

                                }
                                if (type == "ONE_SELECT")
                                {
                                    if (comboBox.SelectedIndex != -1)
                                    {

                                        Write_convar_To_File(name, comboBox.SelectedValue.ToString(), Description, false, Convar_File);
                                        comboBox.Foreground = Brushes.White;
                                    }


                                }



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Error_Notif("Fatal Error Occured, Please Check Logs!");


            }
        }
        
        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                var Var = ((TextBox)sender).Tag.ToString();
                string[] Split = Var.Split("|");
                string type = Split[0];
                Regex regex = new Regex("[^0-9]+");

                switch (type)
                {

                    case "STRING":
                        // Send_Success_Notif("Found type String!");
                        break;
                    case "PORT":
                        e.Handled = regex.IsMatch(e.Text);


                        break;
                    case "INT":
                        e.Handled = regex.IsMatch(e.Text);
                        break;
                    case "FLOAT":
                        Regex Floaty = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$ or ^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$");
                        e.Handled = Floaty.IsMatch(e.Text);
                        break;
                }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");


            }
        }
        public  bool IsPort(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return false;

                Regex numeric = new Regex(@"^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (numeric.IsMatch(value))
                {
                    try
                    {
                        if (Convert.ToInt32(value) < 65535)
                            return true;
                    }
                    catch (OverflowException)
                    {
                    }
                }
            }
            catch (Exception ex)
            {

                Write_To_Log(ex.StackTrace);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");


            }
            return false;

        }
        void validate(object sender, RoutedEventArgs e) {


            


        }
        public  IEnumerable<string> GetFile(string directory,string Search)
        {
            List<string> files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(directory, Search, SearchOption.AllDirectories));
            }
            catch (Exception ex)
            {
               Send_Warning_Notif(ex.Message);
                Write_To_Log(ex.StackTrace);

            }

            return files;
        }
        void Write_convar_To_File(string Convar_Name,string Convar_Value,string Description,bool add_quotation = false, string File_Root = null)
        {
            try
            {

                // string val = Convar_Name.Trim(new Char[] { '-', '+' });


                Convar_Value = Convar_Value.Trim();
                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder  = File_Root;
                    }
                    else
                    {
                        Send_Warning_Notif("Could Not find Set path!, routing to defualt search.");
                        RootFolder  = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();

                    }
                }
                else
                {


                    RootFolder  = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);

                string[] intermid = intake;

               
                
                if (Array.Exists(intermid, element => element.StartsWith(Convar_Name)))
                {


                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(Convar_Name));
                    if (add_quotation == true)
                    {
                        var desc = intermid[index_of_var];
                        desc = desc.Substring(desc.LastIndexOf('/') + 1);
                        if(desc != null && desc != "")
                        {
                            intermid[index_of_var] = Convar_Name + " " + '\u0022'+Convar_Value+ '\u0022' +" " +"//" +desc;


                        }
                        else
                        {

                            intermid[index_of_var] = Convar_Name + " " + '\u0022'+Convar_Value+ '\u0022' +" " +"//" +desc;

                        }

                    }
                    else
                    {
                       
                        var desc = intermid[index_of_var];
                        desc = desc.Substring(desc.LastIndexOf('/') + 1);
                        intermid[index_of_var] = Convar_Name + " "+Convar_Value+" " +"//" +desc;
                        if (desc != null && desc != "")
                        {
                            intermid[index_of_var] = Convar_Name + " "+Convar_Value+" " +"//" +desc;


                        }
                        else
                        {

                            intermid[index_of_var] = Convar_Name + " "+Convar_Value+" " +"//" +Description;

                        }
                    }
                    if (Convar_Value == "REMOVE")
                    {
                        intermid =intermid.Where((source, index) => index != index_of_var).ToArray();

                    }


                    String x = String.Join("\r\n", intermid.ToArray());
                    //Send_Warning_Notif(x);
                    // x = x.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                    //ClearFile(Convar_File);
                 using (StreamWriter sw = new StreamWriter(Convar_File, false, Encoding.UTF8, 65536))
                {
                      
                     sw.WriteLine(x);
                   }
                    Send_Success_Notif("The Varible ["+ Convar_Name+"] Has been Found in the File.The value is now ["+ Convar_Value+"]");


                }
                else
                {
                   

                    string[] intake_ = File.ReadAllLines(Convar_File);

                    string[] intermid_ = intake_;
                   
                    intermid_ = AddElementToArray(intermid_, Convar_Name + " "+Convar_Value+" " +"//" +Description);

                    String x = String.Join("\r\n", intermid_.ToArray());

                    using (StreamWriter sw = new StreamWriter(Convar_File, false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(x);
                    }
                    Send_Success_Notif("The Varible ["+ Convar_Name+"] Has Not been Found in the File.The value Has Been Added and is now ["+ Convar_Value+"]");

                }
            }
            catch (Exception ex)
            {
                Send_Fatal_Notif("\nIssue with using Server Setup sys, Please Check Logs!");
                Write_To_Log(ex.Message);


            }
        }
        private T[] AddElementToArray<T>(T[] array, T element)
        {
            
            T[] newArray = new T[array.Length + 1];
            int i;
            for (i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[i] = element;
            return newArray;
        }
        private void ClearFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path);

            StreamWriter tw = new StreamWriter(path, false);
            tw.Flush();

            tw.Close();
        }
        string Read_Convar_args(string Convar_Name, string File_Root = null)
        {
            try
            {
                var pattern = @"(?=[+-])";

                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder  = File_Root;
                    }
                    else
                    {
                        Send_Warning_Notif("Could Not find Set path!, routing to defualt search.");
                        RootFolder  = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();

                    }

                }
                else
                {


                    RootFolder  = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);
                string[] intermid = null;


                 for (int i = 0; i<intake.Length; i++)
                {
                   Console.WriteLine(String.Format(" array[{0}] = {1}", i, intake[i]));
                 }
                Console.WriteLine("\n\n\n");
             //   Send_Warning_Notif(intake[Array.FindIndex(intake, element => element.Contains(Convar_Name))].ToString());

                if (Array.Exists(intake, element => element.StartsWith(Convar_Name)))
                {


                    int index_of_var = Array.FindIndex(intake, element => element.StartsWith(Convar_Name));

                    return intake[index_of_var].ToString();


                }
                else
                {
                  //  Send_Error_Notif("CONVAR NOT FOUND-"+ Convar_Name);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Send_Fatal_Notif("\nIssue with using Server Setup sys, Please Check Logs!");
                Write_To_Log(ex.Message);


            }
            return null;
        }
        string Read_Startup_args(string Convar_Name, string File_Root = null)
        {
            try
            {
                var pattern = @"(?=[+-])";

                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder  = File_Root;
                    }
                    else
                    {
                        Send_Warning_Notif("Could Not find Set path!, routing to defualt search.");
                        RootFolder  = GetFile(Current_Install_Folder, "ns_startup_args_dedi.txt").First();

                    }
                }
                else
                {


                    RootFolder  = GetFile(Current_Install_Folder, "ns_startup_args_dedi.txt").First();
                }
                string[] intake = File.ReadAllLines(Ns_dedi_File);

                string[] intermid = null;

                foreach (string line in intake)
                {
                    intermid = Regex.Split(line.Trim(' '), pattern);

                }

                if (Array.Exists(intermid, element => element.StartsWith(Convar_Name))) { 
                  
                    
                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(Convar_Name));
                    return intermid[index_of_var].ToString();


                }
                else
                {
                   // Send_Error_Notif("Did Not Find-"+ Convar_Name);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Send_Fatal_Notif("\nIssue with using Server Setup sys, Please Check Logs!");
                Write_To_Log(ex.Message);


            }
            return null;
        }
      
        void Write_Startup_Arg_To_File(string var_Name, string var_Value, bool add_quotation = false,bool Kill_If_empty = false, string File_Root = null )
        {

            try
            {

                string val = var_Name.Trim(new Char[] { '-', '+' });
                var pattern = @"(?=[+-])";
                var_Value = var_Value.Trim();
                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder  = File_Root;
                    }
                    else
                    {
                        Send_Warning_Notif("Could Not find Set path!, routing to defualt search.");
                        RootFolder  = GetFile(Current_Install_Folder, "ns_startup_args_dedi.txt").First();

                    }
                }
                else
                {


                    RootFolder  = GetFile(Current_Install_Folder, "ns_startup_args_dedi.txt").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);

                string[] intermid = null;

                foreach (string line in intake)
                {
                    intermid = Regex.Split(line.Trim(' '), pattern);
                    

                }
                for (int j = 0; j<intermid.Length; j++)
                {
                    Console.WriteLine("array[{0}] = {1}", j, intermid[j]);

                }
                if (Array.Exists(intermid, element => element.StartsWith(var_Name)))
                {

                   
                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(var_Name));
                    if(add_quotation == true)
                    {
                        intermid[index_of_var] = var_Name + " " + '\u0022'+var_Value+ '\u0022';


                    }
                    else
                    {
                        intermid[index_of_var] = var_Name + " " +var_Value;

                    }

                    if (Kill_If_empty == true)
                    {
                        if (var_Value == "" || var_Value == null)
                        {
                            intermid =intermid.Where((source, index) => index != index_of_var).ToArray();
                        }

                    }

                    String x = String.Join(" ", intermid.ToArray());
                  //  ClearFile(RootFolder +@"\" + "ns_startup_args_dedi.txt");

                    using (StreamWriter sw = new StreamWriter(RootFolder, false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(Regex.Replace(x, @"\s+", " ").Replace("+ ","+"));
                    }
                   Send_Success_Notif("The Varible "+ var_Name+" Has been Found in the File.The value is now "+ var_Value);

                    
                }
                else 
                {

                    string[] intake_ = File.ReadAllLines(Ns_dedi_File);

                    string[] intermid_ = null;
                    foreach (string line in intake_)
                    {
                        //  intermid_ = line.Split('+');
                        intermid_ = Regex.Split(line, pattern);

                    }
                    
                    intermid_ = AddElementToArray(intermid_, var_Name +" "+ var_Value);
                    
                  
                    String x = String.Join(" ", intermid_.ToArray());
                    //x.Replace(System.Environment.NewLine, "replacement text");
                    //  File.WriteAllText(RootFolder, String.Empty);
                   // ClearFile(RootFolder +@"\" + "ns_startup_args_dedi.txt");
                    using (StreamWriter sw = new StreamWriter(RootFolder , false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(Regex.Replace(x, @"\s+", " "));
                    }
                    // File.WriteAllText(GetFile(RootFolder, "ns_startup_args_dedi.txt").First(), x);
                    Send_Warning_Notif("The Varible ["+ var_Name+"] Was not Found in File. It Has Been Added Now with the value of [" + var_Value+"]");

                }
            }
            catch(Exception ex)
            {
                Send_Fatal_Notif("\nIssue with using Server Setup sys, Please Check Logs!");
                Write_To_Log(ex.Message);


            }

        }
       
    int cntr = 0;
        void Clear_Box(object sender, KeyEventArgs e)
        {
            cntr++;
           

            
            TextBox Text_Box = (TextBox)sender;
            if (cntr < 2)
            {
                string Reg2;
                Reg2= Text_Box.Text;
                if (Text_Box.Text == Reg2)
                {
                    Text_Box.Text = "";


                }

            }
            
        }
                void Save_On_Focus_(object sender, KeyEventArgs e)
        {

            try
            {
                if (sender.GetType() == typeof(TextBox))
                {





                    var val = ((TextBox)sender).Text.ToString();
                    var Tag = ((TextBox)sender).Tag.ToString();
                    var Description = ((TextBox)sender).ToolTip.ToString();

                    TextBox Text_Box = (TextBox)sender;
                    string[] Split = Tag.Split("|");
                    string type = Split[0];
                    string name = Split[1];
                    string ARG = Split[2];


                    if (val != null)
                    {

                        switch (type)
                        {

                            case "STRING":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG!= null && ARG!= "" && ARG== "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, true, Convar_File);
                                        GC.Collect();
                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else { 
                                    Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true,Ns_dedi_File);

                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;


                                    }



                                }
                                break;
                            case "STRINGQ":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG!= null && ARG!= "" && ARG== "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, true, Convar_File);
                                        Text_Box.Foreground = Brushes.White;

                                        GC.Collect();

                                    }
                                    else { 
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;



                                    }



                                }
                                break;
                            case "INT":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG!= null && ARG!= "" && ARG== "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, false, Convar_File);
                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;



                                    }



                                }
                                break;
                            case "FLOAT":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG!= null && ARG!= "" && ARG== "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, false, Convar_File);
                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, true, true,Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        GC.Collect();
                                        Text_Box.Foreground = Brushes.White;


                                    }



                                }
                                break;
                            case "PORT":
                                if (ARG!= null && ARG!= "" && ARG== "CONVAR")
                                {
                                    if (val.Count() >5)
                                    {
                                        Send_Warning_Notif("Port is larger Than Required");
                                        Text_Box.Background = Brushes.Red;
                                    }
                                    else
                                    {
                                        Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");

                                        if (e.Key == Key.Return)
                                        {

                                            if (IsPort(val) == true && val.Count() <6)
                                            {
                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                                Text_Box.Foreground = Brushes.White;
                                                Write_convar_To_File(name, val, Description, false, Convar_File);

                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                                                Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");


                                            }
                                            else
                                            {
                                                if (val == null || val == "")
                                                {

                                                    Write_convar_To_File(name, val, Description, false, Convar_File);

                                                }
                                                else
                                                {
                                                    Send_Warning_Notif("Error At ["+name+"]");
                                                    Text_Box.Background = Brushes.Red;
                                                    Text_Box.Text = null;

                                                }

                                            }
                                        }
                                    }
                                }
                                else { 
                                    if (val.Count() >5)
                                    {
                                        Send_Warning_Notif("Port is larger Than Required");
                                        Text_Box.Background = Brushes.Red;
                                    }
                                    else
                                    {
                                        Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");

                                        if (e.Key == Key.Return)
                                        {

                                            if (IsPort(val) == true && val.Count() <6)
                                            {
                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                                Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                                Text_Box.Foreground = Brushes.White;

                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                                                Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");


                                            }
                                            else
                                            {
                                                if (val == null || val == "")
                                                {

                                                    Send_Warning_Notif("An Empty Value At ["+name+"], Has been removed");
                                                    Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);

                                                }
                                                else
                                                {
                                                    Send_Warning_Notif("Error At ["+name+"]");
                                                    Text_Box.Background = Brushes.Red;
                                                    Text_Box.Text = null;

                                                }

                                            }
                                        }
                                    }
                                }
                                break;

                        }





                    }
                }
                
            }
            catch (Exception ex)
            {
                Send_Fatal_Notif("\nIssue with writing Input, Please Check Logs");
                Write_To_Log(ex.Message);

            }
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


        }
       public class Arg_Set
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Default { get; set; }
            public string Tag { get; set; }
            public string regex { get; set; }
            public string ARG { get; set; }

            public string Description { get; set; }
            public string[] List { get; set; }

        }
        bool Verify_List( List<string> Good_Words,string Input)
        {
           return Good_Words.Contains(Input);

        }
        private ArrayList Load_Args()
        {

              ArrayList Arg_List = new ArrayList();

            using (StreamReader r = new StreamReader(@"D:\Development Northstar AmVCX C++ branch 19023 ID 44\VTOL\Resources\Test_Args_1.json"))
            {
                string json = r.ReadToEnd();
               // Send_Success_Notif(json);
               Server_Json = Server_Setup.FromJson(json);
}

            foreach (var items in Server_Json.Startup_Arguments)
            {
                if (items.Type == "GAME_MODE")
                {
                    foreach (var item in items.List)
                    {

                        Game_Modes_List.Add(item);
                    }

                }

                Arg_List.Add( new Arg_Set
                {
                    Name = items.Name,
                    Type = items.Type,
                    Default = items.Default,
                    Description = items.Description_Tooltip,
                    List = items.List,
                    Tag = items.Type+"|"+items.Name+"|"+items.ARG,



                } );
                DataContext = this;

            }


return Arg_List;

}

        private ArrayList Convar_Args()
        {

            ArrayList Arg_List = new ArrayList();

            using (StreamReader r = new StreamReader(@"D:\Development Northstar AmVCX C++ branch 19023 ID 44\VTOL\Resources\Test_Args_1.json"))
            {
                string json = r.ReadToEnd();
                // Send_Success_Notif(json);
                Server_Json = Server_Setup.FromJson(json);
            }

            foreach (var items in Server_Json.Convar_Arguments)
            {
                if (items.Type == "GAME_MODE")
                {
                    foreach (var item in items.List)
                    {

                        Game_Modes_List.Add(item);
                    }

                }

                Arg_List.Add(new Arg_Set
                {
                    Name = items.Name,
                    Type = items.Type,
                    Default = items.Default,
                    Description = items.Description_Tooltip,
                    List = items.List,
                    Tag = items.Type+"|"+items.Name+"|"+items.ARG,
                    


                });
                DataContext = this;

            }
            return Arg_List;

        }

        private void Dsiabled_ListBox_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
//            Send_Error_Notif("right click");

        }

        private void Mod_Panel_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off 
                try
                {

                    foreach (string file in files)
                    {
                        string path = file;
                        if (path == null || !File.Exists(file))
                        {
                           
                            Send_Error_Notif("\nInvalid Mod Zip Location chosen");


                        }
                        else
                        {
                            string FolderName = path.Split(Path.DirectorySeparatorChar).Last();
                            Browse_For_MOD.Text = path;
                            Console.WriteLine(path);
                            Console.WriteLine("The Folder Name is-" + FolderName + "\n\n");
                            Send_Success_Notif("Recieved - " + file);

                            Unpack_To_Location_Custom(path, Current_Install_Folder + @"\R2Northstar\mods");
                            Call_Mods_From_Folder();

                            ApplyDataBinding();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Drag_Drop_Overlay_Skins.Visibility = Visibility.Hidden;

                    Send_Error_Notif("\nIssue with File path, please Rebrowse.");
                    Write_To_Log(ex.Message);
                }
            }
            Drag_Drop_Overlay.Visibility = Visibility.Hidden;

        }

        private void Mod_Panel_DragOver(object sender, DragEventArgs e)
        {

        }

        private void Mod_Panel_DragLeave(object sender, DragEventArgs e)
        {
            Drag_Drop_Overlay.Visibility = Visibility.Hidden;

        }

        private void Mod_Panel_DragEnter(object sender, DragEventArgs e)
        {
            Drag_Drop_Overlay.Visibility = Visibility.Visible;
        }

        private void skins_Panel_Drop(object sender, DragEventArgs e)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (Directory.Exists(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR"))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                    bitmap.EndInit();
                    Diffuse_IMG.Source = bitmap;


                    Glow_IMG.Source = bitmap;

                    Directory.Delete(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                    Write_To_Log(ef.StackTrace.ToString());
                }




            }
            if (Directory.Exists(Current_Install_Folder + @"\Thumbnails"))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                    bitmap.EndInit();
                    Diffuse_IMG.Source = bitmap;


                    Glow_IMG.Source = bitmap;

                    Directory.Delete(Current_Install_Folder + @"\Thumbnails", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

                    Write_To_Log(ef.ToString());
                }

            }
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {

                    // Note that you can have more than one file.
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    
                        Skin_Temp_Loc = files[0];
                        if (Skin_Temp_Loc == null || !File.Exists(Skin_Temp_Loc))
                        {

                            Send_Error_Notif("\nInvalid Mod Zip Location chosen");
                            return;

                        }
                        else
                        {
                            Skin_Path_Box.Text = Skin_Temp_Loc;
                            // Send_Success_Notif("\nSkin Found!");
                            if (ZipHasFile(".dds", Skin_Temp_Loc))
                            {
                                Send_Success_Notif("Compatible Skin Detected");
                                Compat_Indicator.Fill = Brushes.Green;
                                Install_Skin_Bttn.IsEnabled = true;
                                //   var directory = new DirectoryInfo(root);
                                // var myFile = (from f in directory.GetFiles()orderby f.LastWriteTime descending select f).First();
                                if (Directory.Exists(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR"))
                                {
                                    Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";
                                    ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"), true);

                                }
                                else
                                {

                                    Directory.CreateDirectory(Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR");
                                    Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";

                                    ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"));

                                }
                            }
                            else
                            {
                                Send_Error_Notif("Incompatible Skin Detected");
                                Compat_Indicator.Fill = Brushes.Red;
                                Install_Skin_Bttn.IsEnabled = false;

                            }


                            Console.WriteLine(Skin_Temp_Loc);
                            String Thumbnail = Current_Install_Folder + @"\Thumbnails\";
                            if (Directory.Exists(Thumbnail))
                            {
                                //DirectoryInfo dir = new DirectoryInfo(Thumbnail);
                                var Serached = SearchAccessibleFiles(Skin_Path, "col");
                                var firstOrDefault_Col = Serached.FirstOrDefault();
                                if (!Serached.Any())
                                {
                                    throw new InvalidOperationException();
                                }
                                else
                                {
                                    if (File.Exists(firstOrDefault_Col))
                                    {
                                        String col = Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png";
                                        Console.WriteLine(firstOrDefault_Col);
                                        if (File.Exists(col))
                                        {

                                            DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                            img_1.Save(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(col);
                                            bitmap.EndInit();
                                            Diffuse_IMG.Source = bitmap;
                                        }
                                        else
                                        {
                                            Console.WriteLine(col);
                                            DDSImage img_1 = new DDSImage(firstOrDefault_Col);

                                            img_1.Save(col);

                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(col);
                                            bitmap.EndInit();
                                            Diffuse_IMG.Source = bitmap;

                                        }

                                    }
                                    else
                                    {
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;

                                    }


                                }

                                var Serached_ = SearchAccessibleFiles(Skin_Path, "ilm");
                                var firstOrDefault_ilm = Serached_.FirstOrDefault();
                                if (!Serached.Any())
                                {
                                    throw new InvalidOperationException();
                                }
                                else
                                {
                                    if (File.Exists(firstOrDefault_ilm))
                                    {
                                        if (File.Exists(firstOrDefault_ilm + ".png"))
                                        {

                                            Console.WriteLine(firstOrDefault_ilm);
                                            // Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                            bitmap.EndInit();
                                            Glow_IMG.Source = bitmap;
                                        }
                                        else
                                        {

                                            DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                            img_2.Save(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");

                                            //Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                            bitmap.EndInit();
                                            Glow_IMG.Source = bitmap;
                                        }
                                    }
                                    else
                                    {
                                        // Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;
                                    }

                                }




                            }

                            else
                            {

                                Directory.CreateDirectory(Thumbnail);

                                //DirectoryInfo dir = new DirectoryInfo(Thumbnail);
                                var Serached = SearchAccessibleFiles(Skin_Path, "col");
                                var firstOrDefault_Col = Serached.FirstOrDefault();
                                if (!Serached.Any())
                                {
                                    throw new InvalidOperationException();
                                }
                                else
                                {
                                    if (File.Exists(firstOrDefault_Col))
                                    {
                                        Console.WriteLine(firstOrDefault_Col);
                                        if (File.Exists(firstOrDefault_Col + ".png"))
                                        {

                                            //   Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                            bitmap.EndInit();
                                            Diffuse_IMG.Source = bitmap;
                                        }
                                        else
                                        {
                                            DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                            img_1.Save(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                            // Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_Col) + ".png");
                                            bitmap.EndInit();
                                            Diffuse_IMG.Source = bitmap;

                                        }

                                    }
                                    else
                                    {
                                        // Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                        bitmap.EndInit();
                                        Diffuse_IMG.Source = bitmap;

                                    }


                                }

                                var Serached_ = SearchAccessibleFiles(Skin_Path, "ilm");
                                var firstOrDefault_ilm = Serached_.FirstOrDefault();
                                if (!Serached.Any())
                                {
                                    throw new InvalidOperationException();
                                }
                                else
                                {
                                    if (File.Exists(firstOrDefault_ilm))
                                    {
                                        if (File.Exists(firstOrDefault_ilm + ".png"))
                                        {

                                            Console.WriteLine(firstOrDefault_ilm);
                                            //    Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                            bitmap.EndInit();
                                            Glow_IMG.Source = bitmap;
                                        }
                                        else
                                        {

                                            DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                            img_2.Save(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                            // Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                            BitmapImage bitmap = new BitmapImage();
                                            bitmap.BeginInit();
                                            bitmap.UriSource = new Uri(Thumbnail + Path.GetFileName(firstOrDefault_ilm) + ".png");
                                            bitmap.EndInit();
                                            Glow_IMG.Source = bitmap;
                                        }
                                    }
                                    else
                                    {
                                        //  Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                        BitmapImage bitmap = new BitmapImage();
                                        bitmap.BeginInit();
                                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                                        bitmap.EndInit();
                                        Glow_IMG.Source = bitmap;

                                    }

                                }





                            }
                           

                            //   Import_Skin_Bttn.Enabled=false;

                        }
                    

                    Drag_Drop_Overlay_Skins.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/NO_TEXTURE.png");
                bitmap.EndInit();
                Diffuse_IMG.Source = bitmap;

                Glow_IMG.Source = bitmap;
                Write_To_Log(ex.StackTrace);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");
                Drag_Drop_Overlay_Skins.Visibility = Visibility.Hidden;

            }




        }

        private void skins_Panel_DragLeave(object sender, DragEventArgs e)
        {
            Drag_Drop_Overlay_Skins.Visibility = Visibility.Hidden;
        }

        private void skins_Panel_DragEnter(object sender, DragEventArgs e)
        {
            Drag_Drop_Overlay_Skins.Visibility = Visibility.Visible;

        }


        

        
        private void Help_Button_Click(object sender, RoutedEventArgs e)
        {
            string val = @"https://github.com/BigSpice/VTOL/blob/master/README.md";

            Send_Info_Notif("Opening - " + val);
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = val,
                UseShellExecute = true
            });
        }

        
        private async void CheckComboBox_Initialized(object sender, EventArgs e)
        {
            
                if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
                {
                    HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                    var Var = ((HandyControl.Controls.CheckComboBox)sender).Tag.ToString();

                    string[] Split = Var.Split("|");
                    string type = Split[0]; 
                    string name = Split[1];
                    string ARG = Split[2];
                // string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());
                if (ARG == "CONVAR")
                {
                    if (type == "LIST")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);
                            import = import.Trim();
                            string[] import_split = import.Split(",");
                            foreach (string item in import_split)
                            {
                                comboBox.SelectedItems.Add(item);
                            }

                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }
                    else
                    {


                        //   Send_Success_Notif("Convar");
                        //      Read_Convar_args(name, Convar_File);
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import =  Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);

                            string[] import_split = import.Split(" ");
                            foreach (string item in import_split)
                            {
                                comboBox.SelectedItems.Add(item);


                                Send_Error_Notif(item);
                            }
                                comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }
                    }
                }


                else
                {

                    //Send_Info_Notif(Var);

                    // string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());
                    string import = null;
                    this.Dispatcher.Invoke(() =>
                    {
                        import = Read_Startup_args(name);
                    });
                    if (import != null)
                    {
                        import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                        string[] import_split = import.Split(" ");
                        foreach (string item in import_split)
                        {
                            comboBox.SelectedItems.Add(item);

                        }

                        comboBox.Foreground = Brushes.White;

                    }
                    else
                    {
                        comboBox.Foreground = Brushes.Gray;

                    }
                }
                }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ComboBox comboBox = (ComboBox)sender;
                var Var = ((ComboBox)sender).Tag.ToString();

                string[] Split = Var.Split("|");
                string type = Split[0];
                string name = Split[1];
                string ARG = Split[2];
                if (ARG == "CONVAR")
                {
                    if (type == "BOOL")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);
                            comboBox.SelectedIndex = Convert.ToInt32(import);
                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }
                    if (type == "ONE_SELECT")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                            {
                                import = import.Substring(0, index);
                            }
                         
                            comboBox.SelectedValue = import.Trim();
                            comboBox.Foreground = Brushes.White;
                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }
                    

                }
            }

            Started_Selection = false;
        }
        
        private void TextBox_Initialized(object sender, EventArgs e)
        {
            try
            {
                var val = ((TextBox)sender).Text.ToString();
                var Tag = ((TextBox)sender).Tag.ToString();
                TextBox Text_Box = (TextBox)sender;
                string[] Split = Tag.Split("|");
                string type = Split[0];
                string name = Split[1];
                string ARG = Split[2];

                string import = null;
                if (ARG == "CONVAR")
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        import =  Read_Convar_args(name, Convar_File);

                    });
                    if (import != null)
                    {
                        Text_Box.Foreground = Brushes.White;

                        if (type == "STRING")
                        {
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);

                            Text_Box.Text = import.Trim();
                            //  Send_Warning_Notif(import);


                        }
                        else
                        {
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);


                            Text_Box.Text = import.Trim();


                        }






                    }
                    else
                    {

                        Text_Box.Foreground = Brushes.Gray;
                    }
                }
                else
                {


                    this.Dispatcher.Invoke(() =>
                    {
                        import = Read_Startup_args(name);
                    });
                    if (import != null)
                    {
                        Text_Box.Foreground = Brushes.White;

                        if (type == "STRINGQ")
                        {
                            Send_Info_Notif(import);
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");



                            Text_Box.Text = import.Trim();
                            //  Send_Warning_Notif(import);


                        }
                        else
                        {
                            import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            string[] import_split = import.Split(" ");
                            for (int i = 1; i < import_split.Length; i++)
                            {
                                Text_Box.Text = import_split[1].Trim();
                            }
                        }






                    }
                    else
                    {

                        Text_Box.Foreground = Brushes.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
               
                Write_To_Log(ex.Message);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

            }

        }

        private void UI_List_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
           
        }

        private void S(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)

            {

                Scoller.LineDown();

            }

            else

            {

                Scoller.LineUp();

            }
        }

        private void Convar_Arguments_UI_List_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)

            {

                Scoller.LineDown();

            }

            else

            {

                Scoller.LineUp();

            }
        }

        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
             Started_Selection = true;

        }

       

        private void Load_Bt_(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Current_Install_Folder))
            {
                Convar_File = GetFile(Current_Install_Folder, "autoexec_ns_server.cfg").First();
                Ns_dedi_File = GetFile(Current_Install_Folder, "ns_startup_args_dedi.txt").First();
            }
            if (File.Exists(Ns_dedi_File) && File.Exists(Convar_File)){
                Startup_Arguments_UI_List.ItemsSource = Load_Args();
                Convar_Arguments_UI_List.ItemsSource = Convar_Args();
                Started_Selection = false;

                Load_Bt.Content = "Reload Arguments";
                Check_Args();


            }
            else
            {
                Send_Error_Notif("Please rebrowse for a Correct Location!");
                return;
            }



        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists(Current_Install_Folder + @"\R2Northstar\mods\"))
                {
                    Process.Start("explorer.exe", Current_Install_Folder + @"\R2Northstar\mods\");
                }
            }
            
            catch (Exception ex)
            {

                Write_To_Log(ex.Message);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

            }

        }

        private void Cheat_Sheet_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Send_Info_Notif("Opening - R2-Northstar Wiki");
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = @"https://r2northstar.gitbook.io/r2northstar-wiki/hosting-a-server-with-northstar/dedicated-server#gamemodes",
                UseShellExecute = true
            });
            }

            catch (Exception ex)
            {

                Write_To_Log(ex.Message);
                Send_Fatal_Notif("Fatal Error Occured, Please Check Logs!");

            }
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {

        }
    }
    }
    
