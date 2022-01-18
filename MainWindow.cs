using System.ComponentModel;
using System.Net;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using MetroSet_UI.Forms;
using System.Runtime.InteropServices;
using MetroSet_UI.Enums;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using WishLib = IWshRuntimeLibrary;
using CheckState = System.Windows.Forms.CheckState;
using System.Drawing.Imaging;
using DDSReader;
using System.Text;

namespace Northstar_Manger
{
    public partial class MainWindow : Form
    {
       
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        public ListBox.ObjectCollection Inactive_Mods_List => Inactive_List.Items;
        public ListBox.ObjectCollection Active_Mods_List => Active_List.Items;
        List<string> Mod_Directory_List_Active = new List<string>();
        List<string> Mod_Directory_List_InActive = new List<string>();

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
        bool advanced_Mode = false;
        private int completed_flag;
        public int pid;
        string current_Ver;
        string Skin_Path = "";
        string Skin_Temp_Loc = "";
        string col_path = "";
        string ilum_path = "";
        bool Auto_Client_Updates = false;
        Image Defualt_Image_Vanilla;
        Image Defualt_Image_NS;
        public MainWindow()
        {
            InitializeComponent();
            Reset_LogBox();
            do_not_overwrite_Ns_file = Properties.Settings.Default.Ns_Startup;
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;
           // Auto_Client_Updates = Properties.Settings.Default.Automatic_Client_Updates;
            advanced_Mode = Properties.Settings.Default.Advanced_Mode;
             Compatible_INDC.DisabledBackColor = Color.Gray;
            Compatible_INDC.DisabledForeColor = Color.Gray;
            Install_Skin_Bttn.Enabled = false;
            current_Ver =  Properties.Settings.Default.Version;
            Defualt_Image_Vanilla= new Bitmap(@"Titanfall2_Vanilla_Picture.jpg");
            Defualt_Image_NS  = new Bitmap(@"Titanfall2_Plus_Northstar_Picture.jpg");
            string version = System.Windows.Forms.Application.ProductVersion;
            this.Text = String.Format("NorthStar Mod Launcher Version {0}", version);

            Image myimage = new Bitmap(@"bestboy.png");
            metroSetTile1.BackgroundImage = myimage;
            Install_Skin_Bttn.DisabledBackColor = Color.DarkSlateGray;


            Image Defualt_Image = new Bitmap(@"Titanfall2_Vanilla_Picture.jpg");
            Selected_Banner.BackgroundImage =Defualt_Image;

            try
            {
                Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                Skin_Normal_Tile.BackgroundImage = Image_1;

                Image Image_2 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                Skin_Glow_Tile.BackgroundImage = Image_2;
                Import_Skin_Bttn.Enabled=true;

                if (Directory.Exists(Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR"))
                {
                    try
                    {
                      
                        Directory.Delete(Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR",true);
                        GC.Collect();
                    }
                    catch (Exception ef)
                    {
                        Log_Box.AppendText(ef.StackTrace);

                        Log_Box.AppendText(ef.ToString());
                    }
                    
                   


                }
                if (Directory.Exists(Current_Install_Folder+@"\Thumbnail"))
                {
                    try
                    {
                        Directory.Delete(Current_Install_Folder+@"\Thumbnail", true);
                        GC.Collect();
                    }
                    catch (Exception ef)
                    {
                        Log_Box.AppendText(ef.StackTrace);

                    }

                }

               
                if (Directory.Exists(@"C:\ProgramData\NorthStarModManager"))
                {




                    Current_Install_Folder =  Read_From_TextFile_OneLine(@"C:\ProgramData\NorthStarModManager\VARS\INSTALL.txt");
                    if (Directory.Exists(Current_Install_Folder))
                    {
                        Found_Install_Folder = true;
                        Install_Textbox.Text = Current_Install_Folder;
                        Install_Textbox.BackColor = Color.White;
                        Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                        if (Directory.Exists(Current_Install_Folder))
                        {
                            NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                            Check_Integrity_Of_NSINSTALL();


                        }


                    }
                    else
                    {

                        Log_Box.AppendText("\nThe Launcher Tried to Auto Check For an existing CFG, please use the manual Check to search.");
                    }
                }


                else
                {
                    Log_Box.AppendText("\nThe Launcher Tried to Auto Check For an existing CFG, please use the manual Check to search.");


                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Could Not Verify Dir" + Current_Install_Folder);
                Log_Box.AppendText("\nThe Launcher Tried to Auto Check For an existing CFG, please use the manual Check to search.");



            }
            // Start the thread that will launch the updater in silent mode with 10 second delay.
            // Thread thread = new Thread(new ThreadStart(StartSilent));
            // thread.Start();

            // Compute the updater.exe path relative to the application main module path
            string Header = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../"));




            //updaterModulePath = Path.Combine(@"D:\Development Northstar AmVCX C++ branch 19023 ID 44\Northstar Manger\bin\Release\net6.0-windows10.0.17763.0\", "Updater.exe");





            updaterModulePath = Path.Combine(Header, "NSUpdater.exe");
            Check_Args();
            if (NS_Installed == true)
            {


                Install_NS_Button.Text = "Update/Repair NorthStar";
            }
            else
            {
                Install_NS_Button.Text = "Install NorthStar";


            }
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = @"-This Application Installs The NorthStar Launcher Created by BobTheBob and, installs the countless Mods Authored by the many Titanfall2 Modder’s.
Current Features:
*Updating NorthStar Installations
*Installation of the NorthStar Launcher By pulling the latest Json of the NorthStar repo to access the download.
*Verifying a Titanfall 2 NorthStar install
*Viewing Mods in the Mod List
*Toggling Mods On and off in the NorthStar Client
*Downloading Mods from a Remote repo
*Downloading Mods from a Local Zip Download
*The ability to launch the NorthStar Exe from the base.
*Install Skins From a Zip
*Launch The Dedicated Northsatar Server Client

-Features in development:
*Intent to Create Custom Servers using this installer as a base to configure and fine tune setups


-Please Do suggest any new features and/or Improvements Through the Git issue tracker, or by sending me a personal Message.
Thank you again to all you Pilots, Hope we Wreak havoc on the Frontier for years to come.
More Instructions at this link - https://github.com/BigSpice/NorthStar-Mod-Manager-Ext-1/blob/main/README.md


Every cent counts towards feeding my baby Ticks - https://www.patreon.com/Juicy_ ";

            if (do_not_overwrite_Ns_file==true)
            {
                Ns_Args.Checked = true;

            }
            else
            {

                Ns_Args.Checked=false;

            }
            if (do_not_overwrite_Ns_file_Dedi==true)
            {
                Ns_Args_Dedi.Checked = true;

            }
            else
            {

                Ns_Args_Dedi.Checked=false;

            }
           
            if (Auto_Client_Updates==true)
            {
          //      NS_Client_Updates.Checked = true;
           //     Check_For_NewVer();


            }
            else
            {

              

            }
           

        }
        private static String updaterModulePath;
        private void FileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Check_For_NewVer()
        {
            string out_ = "";
            var s = "";
            current_Ver = Properties.Settings.Default.Version;
            Console.WriteLine(current_Ver+"s");
            Read_Latest_Release("https://api.github.com/repos/R2Northstar/Northstar/releases/latest", "temps.json", false, false);
            if (File.Exists(@"C:\ProgramData\NorthStarModManager\temp\temps.json"))
            {
                using (StreamReader sr = File.OpenText(@"C:\ProgramData\NorthStarModManager\temp\temps.json"))
                {
                    s = sr.ReadToEnd();
                    sr.Close();
                }
                
                var myJsonString = s;
                 var myJObject = JObject.Parse(myJsonString);

                out_ = myJObject.SelectToken("tag_name").Value<string>();
                //var myJsonString = File.ReadAllText(@"C:\ProgramData\NorthStarModManager\temp\temp.json");
                //   var myJObject = JObject.Parse(myJsonString);

                // out_ = myJObject.SelectToken("tag_name").Value<string>();



            }
            if (current_Ver.Equals(out_ +"sd"))
            {
                Log_Box.AppendText("\nYou are on the Latest Northstar Client Install");


            }
            else
            {
                if (Auto_Client_Updates==false)
                {
                    Log_Box.AppendText("\nNew Release Found! - "+out_);

                    Log_Box.AppendText("\nPlease Click Update to Obtain the Latest Northstar Install");

                }
                
                else
                {
                    Log_Box.AppendText("\nNew Release Found! - "+out_);


                    Log_Box.AppendText("\nAutomatically Downloading the New Release!");
                    Install_NS_METHOD();

                }

            }
   
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

                        return "\nCould Not Find"+ Filename+"\n";

                    }

                }
            }

            catch (Exception e)
            {
                MessageBox.Show("The process failed: "+ e.ToString());
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

                    Log_Box.AppendText("\n Directory is empty");
                    return;

                }


            }

            else

            {

                Log_Box.AppendText("\n Invalid Path fed, that folder is not available or does not exist");
                failed_search_counter++;

            }



        }
        public static bool IsDirectoryEmpty(DirectoryInfo directory)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] subdirs = directory.GetDirectories();

            return (files.Length == 0 && subdirs.Length == 0);
        }
        private void contextMenuStrip1_Opening(object sesnder, System.ComponentModel.CancelEventArgs e)
        {

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

                Console.WriteLine("\nCould not Find the Install at " +root+ " - Continuing Traversal");
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
               // Log_Box.AppendText("\nCould not Find the Install at " +root+ " - Continuing Traversal");
            }
            
            
            return false;

        }
        void WalkDirectoryTree(System.IO.DirectoryInfo root, String Search)
        {
            System.IO.FileInfo[] files = null;
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

                Log_Box.AppendText("\nCould not Find the Install at " +root+ " - Continuing Traversal");

            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message);


            }

        }

        private void Install_NS_Button_Click(object sender, EventArgs e)
        {

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
        private void Install_Location_Label_Click(object sender, EventArgs e)
        {

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
                // List<string> Baseline = Read_From_Text_File(@"C:\ProgramData\NorthStarModManager\NormalFolderStructure.txt");
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
                    Log_Box.AppendText("\nDirectory Check Unsuccessful");
                    NS_Installed = false;


                }




            }
            else
            {

                NS_Installed = false;
            }

            if (NS_Installed == false)
            {

                Log_Box.AppendText("\nNorthStar Launcher or Titanfall2 Was not found, do you want to Re-Install it by Clicking Install Northstar Launcher? (Please check the Integrity of Titanfall2 as well)");
                Version_TextBox.BackColor = Color.Red;
                Version_TextBox.ForeColor = Color.Black;

            }
            else
            {

                Version_TextBox.BackColor = Color.Green;
                Version_TextBox.ForeColor = Color.Black;



            }
            Version_TextBox.Text = NSExe;




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
                Console.WriteLine("Could Not find " + Filepath);


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
                Console.WriteLine("Could Not find " + Filepath);


            }
            return lines;
        }
        public static async Task saveAsyncFile(string Text, string Filename, bool ForceTxt = true, bool append = true)
        {
            if (ForceTxt == true)
            {
                if (!Filename.Contains(".txt"))
                {
                    Filename = Filename+".txt";

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
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Read_Latest_Release(string address, string json_name = "temp.json", bool Parse = true, bool Log_Msgs = true)
        {
            if (address != null)
            {
                if (Log_Msgs == true)
                {
                    Log_Box.AppendText("\nJson Download Started!");

                }
                WebClient client = new WebClient();
                Uri uri1 = new Uri(address);
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream data = client.OpenRead(address);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();



                s = s.Replace("[", "");
                s= s.Replace("]", "");
                if (Directory.Exists(@"C:\ProgramData\NorthStarModManager\temp"))
                {
                    saveAsyncFile(s, @"C:\ProgramData\NorthStarModManager\temp\"+json_name, false, false);
                    if (Log_Msgs == true)
                    {
                        Log_Box.AppendText("\nJson Download completed!");
                        Log_Box.AppendText("\nParsing Latest Release........");
                    }
                    if (Parse == true)
                    {
                        Parse_Release();
                    }

                }
                else
                {
                    Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\temp");
                    saveAsyncFile(s, @"C:\ProgramData\NorthStarModManager\temp\"+json_name, false, false);
                    if (Log_Msgs == true)
                    {
                        Log_Box.AppendText("\nJson Download completed!");
                        Log_Box.AppendText("\nParsing Latest Release........");
                    }
                    if (Parse == true)
                    {
                        Parse_Release();
                    }
                }

            }
            else
            {


                Log_Box.AppendText("\n Invalid Url Called");
            }

        }
        private string Parse_Custom_Release(string json_name = "temp.json")
        {

            if (File.Exists(@"C:\ProgramData\NorthStarModManager\temp\"+json_name))
            {
                var myJsonString = File.ReadAllText(@"C:\ProgramData\NorthStarModManager\temp\"+json_name);
                var myJObject = JObject.Parse(myJsonString);

                string out_ = myJObject.SelectToken("assets.browser_download_url").Value<string>();
                Properties.Settings.Default.Version = myJObject.SelectToken("tag_name").Value<string>();
                Properties.Settings.Default.Save();

                Log_Box.AppendText("\nRelease Parsed! found - \n"+out_);

                return out_;

            }
            else
            {
                Log_Box.AppendText("\nRelease Not Found!!");

                return null;
            }
            return null;

        }

        private void Parse_Release(string json_name = "temp.json")
        {
            if (File.Exists(@"C:\ProgramData\NorthStarModManager\temp\"+json_name))
            {
                var myJsonString = File.ReadAllText(@"C:\ProgramData\NorthStarModManager\temp\"+json_name);
                var myJObject = JObject.Parse(myJsonString);


                current_Northstar_version_Url =  myJObject.SelectToken("assets.browser_download_url").Value<string>();
                Properties.Settings.Default.Version = myJObject.SelectToken("tag_name").Value<string>();
                Properties.Settings.Default.Save();

                Log_Box.AppendText("\nRelease Parsed! found - \n"+current_Northstar_version_Url);

            }
            else
            {
                Log_Box.AppendText("\nRelease Not Found!!");


            }


        }
        private void Unpack_To_Location_Custom(string Target_Zip, string Destination)
        {



            Log_Box.AppendText("\nUnpacking " + Path.GetFileName(Target_Zip) + " to " + Destination);
            if (File.Exists(Target_Zip) && Directory.Exists(Destination))
            {
                string fileExt = System.IO.Path.GetExtension(Target_Zip);

                if (fileExt == ".zip")
                {
                    ZipFile.ExtractToDirectory(Target_Zip, Destination, true);
                    Log_Box.AppendText("\nUnpacking Complete!\n");
                }
                else
                {
                    Main_Window.SelectedTab = Main;
                    Log_Box.AppendText("\nObject Is Not a Zip!\n");


                }



            }
            else
            {
                if (!File.Exists(Target_Zip))
                {
                    Log_Box.AppendText("\nTarget Zip Does Not exist!!!!!!\n");


                }
                if (!Directory.Exists(Destination))
                {
                    Log_Box.AppendText("\nTarget Location Does Not exist, please Double Check or Browse for the correct install location\n");

                }
            }
        }

        private void Unpack_To_Location(string Target_Zip, string Destination_Zip)
        {
            if (Directory.Exists(Current_Install_Folder+@"\R2Northstar\mods\Northstar.Client\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder+@"\R2Northstar\mods\Northstar.Client\Locked_Folder", true);

            }
            if (Directory.Exists(Current_Install_Folder+@"\R2Northstar\mods\Northstar.Custom\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder+@"\R2Northstar\mods\Northstar.Custom\Locked_Folder", true);


            }
            if (Directory.Exists(Current_Install_Folder+@"\R2Northstar\mods\Northstar.CustomServers\Locked_Folder"))
            {
                Directory.Delete(Current_Install_Folder+@"\R2Northstar\mods\Northstar.CustomServers\Locked_Folder", true);


            }



            Log_Box.AppendText("\nUnpacking " + Path.GetFileName(Target_Zip) + " to " + Destination_Zip);
            if (File.Exists(Target_Zip) && Directory.Exists(Destination_Zip))
            {
                string fileExt = System.IO.Path.GetExtension(Target_Zip);

                if (fileExt == ".zip")
                {
                    ZipFile.ExtractToDirectory(Target_Zip, Destination_Zip, true);
                    Log_Box.AppendText("\nUnpacking Complete!");
                    if (File.Exists(Current_Install_Folder+@"\ns_startup_args_dedi.txt") && File.Exists(Current_Install_Folder+@"\ns_startup_args.txt"))
                    {
                        if (do_not_overwrite_Ns_file == true)
                        {
                            Log_Box.AppendText("\nRestoring Files");
                            if (Directory.Exists(Current_Install_Folder+@"\TempCopyFolder\"))
                            {
                                System.IO.File.Copy(Current_Install_Folder+@"\TempCopyFolder\ns_startup_args.txt", Current_Install_Folder+@"\ns_startup_args.txt", true);
                                Log_Box.AppendText("\nCleaning Residual");

                                Directory.Delete(Current_Install_Folder+@"\TempCopyFolder", true);
                                Log_Box.AppendText("\nInstall Complete!");
                            }
                            

                        }
                        if (do_not_overwrite_Ns_file_Dedi == true)
                        {
                            Log_Box.AppendText("\nRestoring Files");
                            if (Directory.Exists(Current_Install_Folder+@"\TempCopyFolder\"))
                            {
                                System.IO.File.Copy(Current_Install_Folder+@"\TempCopyFolder\ns_startup_args_dedi.txt", Current_Install_Folder+@"\ns_startup_args_dedi.txt", true);
                                Log_Box.AppendText("\nCleaning Residual");

                                Directory.Delete(Current_Install_Folder+@"\TempCopyFolder", true);
                                Log_Box.AppendText("\nInstall Complete!");
                            }
                            

                        }
                    }

                }
                else
                {
                    if (!File.Exists(Target_Zip))
                    {
                        Log_Box.AppendText("\nTarget Zip Does Not exist!!!!!!");


                    }
                    if (!Directory.Exists(Destination_Zip))
                    {
                        Log_Box.AppendText("\nTarget Location Does Not exist, please Double Check or Browse for the correct install location");

                    }
                }
            }
            else
            {

                Main_Window.SelectedTab = Main;
                Log_Box.AppendText("\nObject Is Not a Zip!\n");

            }
        }

        private void InstallNorthsatar_Click(object sender, EventArgs e)
        {

        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

            webClient = null;
            Log_Box.AppendText("\nDownload completed!");
            Unpack_To_Location(@"C:\ProgramData\NorthStarModManager\Releases\NorthStar_Release.zip", Current_Install_Folder);
        }
        private void Completed_t(object sender, AsyncCompletedEventArgs e)
        {

            webClient = null;
            Log_Box.AppendText("\nDownload completed!");
            Unpack_To_Location_Custom(Current_Install_Folder+ @"\NS_Downloaded_Mods\MOD.zip", Current_Install_Folder+ @"\R2Northstar\mods");
        }
        private void parse_git_to_zip(string address)
        {

            if (address.Contains(".zip"))
            {
                if (webClient != null)
                    return;
                webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_t);
                if (Directory.Exists(Current_Install_Folder+@"\NS_Downloaded_Mods"))
                {

                    webClient.DownloadFileAsync(new Uri(address), Current_Install_Folder+ @"\NS_Downloaded_Mods\MOD.zip");

                }
                else
                {
                    Directory.CreateDirectory(Current_Install_Folder+@"\NS_Downloaded_Mods");
                    webClient.DownloadFileAsync(new Uri(address), Current_Install_Folder+ @"\NS_Downloaded_Mods\MOD.zip");


                }


            }
            else
            {
                if (address.Contains("https"))
                {

                    address=address.Replace(@"https://github.com/", @"https://api.github.com/repos/");
                    address=address+@"/releases/latest";

                }
                else
                {

                    address=address.Replace(@"http://github.com/", @"https://api.github.com/repos/");
                    address=address+@"/releases/latest";
                }

                Read_Latest_Release(address, "Mod_temp.json", false);
                string retruns = Parse_Custom_Release("Mod_temp.json");
                if (retruns != null)
                {
                    if (webClient != null)
                        return;
                    webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_t);
                    if (Directory.Exists(Current_Install_Folder+@"\NS_Downloaded_Mods"))
                    {

                        webClient.DownloadFileAsync(new Uri(retruns), Current_Install_Folder+ @"\NS_Downloaded_Mods\MOD.zip");

                    }
                    else
                    {
                        Directory.CreateDirectory(Current_Install_Folder+@"\NS_Downloaded_Mods");
                        webClient.DownloadFileAsync(new Uri(retruns), Current_Install_Folder+ @"\NS_Downloaded_Mods\MOD.zip");


                    }
                }


            }
            Active_List.Refresh();
            Inactive_List.Refresh();


        }

        private void Auto_Install_And_verify()
        {
            failed_search_counter = 0;
            Log_Box.AppendText("\nLooking For Titanfall2 Install");
            while (Found_Install_Folder == false && failed_search_counter < 1)
            {

                Log_Box.AppendText("\nAutomatically Looking For The Northstar And Titandfall Install :-)");
                Cursor.Current = Cursors.WaitCursor;
                Log_Box.AppendText("\nLooking Under the Directory  -" +@"C:\Program Files (x86)\Steam");
                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Steam");

                Log_Box.AppendText("\nLooking Under the Directory -" +@"C:\Program Files (x86)\Origin Games");
                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Origin Games");

                Log_Box.AppendText("\nLooking Under the Directory  -" +@"C:\Program Files\EA Games");
                FindNSInstall("Titanfall2", @"C:\Program Files\EA Games");
                if (Found_Install_Folder == false && failed_search_counter >= 1)
                {
                    Install_Textbox.BackColor = Color.Red;
                    Log_Box.AppendText("\nCould Not Find, Please Manually Navigate to a proper Titanfall2 installation");
                    break;


                }

            }
            if (Found_Install_Folder == true)
            {
                Install_Textbox.Text = Current_Install_Folder;
                Install_Textbox.BackColor = Color.White;
                Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\VARS");
                saveAsyncFile(Current_Install_Folder, @"C:\ProgramData\NorthStarModManager\VARS\INSTALL.txt", false, false);
                Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                //Checking if the path Given Returned Something Meaningful. I know i could do this better, but its 3.37am and i feel like im dying from this cold :|.
                Check_Integrity_Of_NSINSTALL();
            }

        }

        private void Check_Ver_Click(object sender, EventArgs e)
        {


        }

        private void Browse_New_Install_Click(object sender, EventArgs e)
        {

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
            }

            return isValid;
        }
        void Call_Mods_From_Folder()
        {
            try
            {
                Active_List.Items.Clear();
                Inactive_List.Items.Clear();
                Mod_Directory_List_Active.Clear();
                Mod_Directory_List_InActive.Clear();
                Console.WriteLine("In Mods!");
                if (Current_Install_Folder == null || Current_Install_Folder == "" || !Directory.Exists(Current_Install_Folder))
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show("Could Not find That Install Location !!!, please renavigate to the Correct Install Path!", "FATAL ERROR", buttons);
                    if (result == DialogResult.OK)
                    {
                        Main_Window.SelectedTab = Main;
                        // this.Close();
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
                                Log_Box.AppendText("\nMod Directory is Empty");
                                Main_Window.SelectedTab = Main;
                                Log_Box.AppendText("\nNorthStar Is Not Installed Properly!, do you want to re-install it?.");

                            }
                            else if (IsValidPath(NS_Mod_Dir) == true)
                            {

                                System.IO.DirectoryInfo[] subDirs = null;
                                subDirs = rootDirs.GetDirectories();
                                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                                {
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

                                Active_List.Items.AddRange(Mod_Directory_List_Active.ToArray());
                                Inactive_List.Items.AddRange(Mod_Directory_List_InActive.ToArray());

                            }
                            else
                            {

                                Log_Box.AppendText("\nInvalid Path");
                                Main_Window.SelectedTab = Main;
                                Log_Box.AppendText("\nNorthStar Is Not Installed Properly!, do you want to re-install it?.");
                            }
                        }
                        else
                        {
                            Main_Window.SelectedTab = Main;

                            Log_Box.AppendText("\nNorthStar Is Not Installed!, do you want to install it?.");


                        }
                    }

                    else
                    {

                        Log_Box.AppendText("\nInvalid Path To Titanfall2!");

                    }
                }
            }
            catch (Exception ex)
            {

                Log_Box.AppendText(ex.StackTrace);


            }


        }
        private void metroSetTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Apply_Btn_Mods.ForeColor = Color.Green;
            if (Main_Window.SelectedTab == Mods)
            {
                Call_Mods_From_Folder();

            }

            if (Main_Window.SelectedTab == Skins)
            {
                if (Found_Install_Folder == false)
                {
                    Main_Window.SelectedTab = Main;
                    Log_Box.AppendText("NorthStar Install Is Corrupted, Please Re-install");
                }



            }

        }
        void Install_NS_METHOD()
        {

            completed_flag = 0;
            Read_Latest_Release("https://api.github.com/repos/R2Northstar/Northstar/releases/latest");
            //  Is file downloading yet?

            if (webClient != null)
                return;
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            if (File.Exists(Current_Install_Folder+@"\ns_startup_args_dedi.txt") && File.Exists(Current_Install_Folder+@"\ns_startup_args.txt"))
            {
                if (do_not_overwrite_Ns_file_Dedi == true)
                {
                    if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder"))
                    {
                        Log_Box.AppendText("\nBacking up arg files");

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args.txt", true);

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args_dedi.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args_dedi.txt", true);
                    }
                    else
                    {

                        Log_Box.AppendText("\nCreating Directory and Backing up arg files");
                        System.IO.Directory.CreateDirectory(Current_Install_Folder + @"\TempCopyFolder");

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args.txt", true);
                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args_dedi.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args_dedi.txt", true);

                    }
                }
                if (do_not_overwrite_Ns_file == true)
                {
                    if (Directory.Exists(Current_Install_Folder + @"\TempCopyFolder"))
                    {
                        Log_Box.AppendText("\nBacking up arg files");

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args.txt", true);

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args_dedi.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args_dedi.txt", true);
                    }
                    else
                    {

                        Log_Box.AppendText("\nCreating Directory and Backing up arg files");
                        System.IO.Directory.CreateDirectory(Current_Install_Folder + @"\TempCopyFolder");

                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args.txt", true);
                        System.IO.File.Copy(Current_Install_Folder+@"\ns_startup_args_dedi.txt", Current_Install_Folder+@"\TempCopyFolder\ns_startup_args_dedi.txt", true);

                    }
                    Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\Releases\");
                    webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\NorthStarModManager\Releases\NorthStar_Release.zip");

                    Log_Box.AppendText("\nStarting Install procedure!");



                }
                else
                {

                    Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\Releases\");
                    webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\NorthStarModManager\Releases\NorthStar_Release.zip");
                    Log_Box.AppendText("\nStarting Install procedure!");



                }



            }
            else
            {
                Log_Box.AppendText("\nCould Not Find the ns_startup_args_dedi.txt & ns_startup_args.txt");

                Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\Releases\");
                webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\ProgramData\NorthStarModManager\Releases\NorthStar_Release.zip");
                Log_Box.AppendText("\nStarting Install procedure!");

            }

        }
        private void Install_NS_Button_Click_1(object sender, EventArgs e)
        {
            do_not_overwrite_Ns_file = Properties.Settings.Default.Ns_Startup;
            do_not_overwrite_Ns_file_Dedi = Properties.Settings.Default.Ns_Dedi;
            Install_NS_METHOD();

        }

        private void Check_Bttn_Click(object sender, EventArgs e)
        {
            Auto_Install_And_verify();

        }

        private void Brows_Bttn_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = folderDlg.SelectedPath;
                    if (path == null || !Directory.Exists(path))
                    {
                        Log_Box.AppendText("\nInvalid Install Location chosen");


                    }
                    else
                    {
                        Console.WriteLine(path);
                        Current_Install_Folder = path;
                        Found_Install_Folder = true;
                        Install_Textbox.Text = Current_Install_Folder;
                        Install_Textbox.BackColor = Color.White;
                        Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\VARS");
                        saveAsyncFile(Current_Install_Folder, @"C:\ProgramData\NorthStarModManager\VARS\INSTALL.txt", false, false);
                        Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                        NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                        Check_Integrity_Of_NSINSTALL();

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("\nIssue with File path, please Rebrowse.");
                Log_Box.AppendText(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetSwitch1_SwitchedChanged(object sender)
        {


        }
        private void Reset_LogBox()
        {

            Log_Box.Text =("\nWelcome To the Northstar Mod Manager!\n");
            Log_Box.AppendText("\n ENSURE to make a backup of Titanfall2,Files and Folders Lost during the use of this software is to be accounted for by you, the User.\n\n");


        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            if (Directory.Exists(@"C:\ProgramData\NorthStarModManager\Logs"))
            {
                if (File.Exists(@"C:\ProgramData\NorthStarModManager\Logs\" + date+"-LOG_MODMANAGER V-"+version))
                {
                    string Accurate_Date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    saveAsyncFile("\n\n"+Accurate_Date+"\n\n", @"C:\ProgramData\NorthStarModManager\Logs\" + date+"-LOG_MODMANAGER V-"+version, true, true);
                    saveAsyncFile(Log_Box.Text, @"C:\ProgramData\NorthStarModManager\Logs\" + date+"-LOG_MODMANAGER V-"+version, true, true);
                    Log_Box.AppendText("\nSaved Successfully to - " + @"C:\ProgramData\NorthStarModManager\Logs");

                }
                else
                {

                    saveAsyncFile(Log_Box.Text, @"C:\ProgramData\NorthStarModManager\Logs\" + date+"-LOG_MODMANAGER V-"+version, true, false);
                    Log_Box.AppendText("\nSaved Successfully to - " + @"C:\ProgramData\NorthStarModManager\Logs");


                }



            }
            else
            {
                Directory.CreateDirectory(@"C:\ProgramData\NorthStarModManager\Logs");
                saveAsyncFile(Log_Box.Text, @"C:\ProgramData\NorthStarModManager\Logs\" + date+" -LOG_MODMANAGER"+version, true, false);
                Log_Box.AppendText("\nSaved Successfully to - " + @"C:\ProgramData\NorthStarModManager\Logs");

            }

        }

        private void metroSetButton3_Click(object sender, EventArgs e)
        {

            Reset_LogBox();
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void metroSetButton4_Click(object sender, EventArgs e)
        {
            if (File.Exists(updaterModulePath))
            {
             //   StartSilent();
                Process process = Process.Start(updaterModulePath, "/checknow");
              // process.Close();
            }
            else
            {
                Log_Box.AppendText("Please Be Aware That your Updater Exe is not in the Home Folder Of the Northstar Installer");

            }

        }
        private void StartSilent()
        {
            if (File.Exists(updaterModulePath))
            {
                Thread.Sleep(10000);

                Process process = Process.Start(updaterModulePath, "/set loglevel <Error|Off>");

                process.Close();
            }
            else
            {
                Log_Box.AppendText("Please Be Aware That your Updater Exe is not in the Home Folder Of the Northstar Installer");

            }
        }
        private void metroSetButton5_Click(object sender, EventArgs e)
        {
            if (File.Exists(updaterModulePath))
            {

                Process process = Process.Start(updaterModulePath, "/configure");
                process.Close();

            }
            else
            {
                Log_Box.AppendText("Please Be Aware That your Updater Exe is not in the Home Folder Of the Northstar Installer");

            }


        }


        private void metroSetTile1_Click(object sender, EventArgs e)
        {


        }



       
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Ns_Args_Dedi.Checked == true)
            {


                Properties.Settings.Default.Ns_Dedi = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.Ns_Dedi = false;
                Properties.Settings.Default.Save();
            }
        }


        private void CheckIfModenabled(string path)
        {

            if (Directory.Exists(path+@"\Disable_Corner"))
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

            Console.WriteLine("Called Args");
            advanced_Mode = Properties.Settings.Default.Advanced_Mode;

            if (Directory.Exists(Current_Install_Folder))
            {
                
                    if (File.Exists(Current_Install_Folder+@"\ns_startup_args_dedi.txt"))
                    {
                        Arg_Box_Dedi.Text = "";
                        Arg_Box_Dedi.Text= Read_From_TextFile_OneLine(Current_Install_Folder+@"\ns_startup_args_dedi.txt");


                    }
                    else
                    {
                        Console.WriteLine("Err, File not found");
                    Arg_Box_Dedi.Text = "Err, File not found - ns_startup_args_dedi.txt";

                }


                if (File.Exists(Current_Install_Folder+@"\ns_startup_args.txt"))
                    {
                        Arg_Box.Text = "";

                        Arg_Box.Text= Read_From_TextFile_OneLine(Current_Install_Folder+@"\ns_startup_args.txt");


                    }
                    else
                    {
                        Console.WriteLine("Err, File not found");
                         Arg_Box.Text = "Err, File not found - ns_startup_args.txt";

                }

            }

            
            else
            {

                Console.WriteLine("Err, Folder not found");


            }
        }
        private void Start_Client_Click(object sender, EventArgs e)
        {
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

                    MessageBox.Show("Could Not Find NorthStar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }

        }



        private void Arg_Box_Leave(object sender, EventArgs e)
        {

        }

        private void Arg_Box_Enter(object sender, EventArgs e)
        {
        }
        void Move_List_box(ListBox from, ListBox To)
        {
            var selected = from.SelectedItem;

            if (selected is null)
            {
                return;

            }
            else
            {

                int index = from.SelectedIndex;
                from.Items.RemoveAt(index);
                To.Items.Add(selected);
                if (index >= from.Items.Count)
                {
                    index--;

                }
                from.SelectedIndex = index;
            }



        }
        private void Make_Active_Click(object sender, EventArgs e)
        {
            Move_List_box(Inactive_List, Active_List);
        }

        private void Make_Inactive_Click(object sender, EventArgs e)
        {
            Move_List_box(Active_List, Inactive_List);

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
                List<string> Inactive = Inactive_List.Items.OfType<string>().ToList();
                List<string> Active = Active_List.Items.OfType<string>().ToList();

                foreach (var val in Inactive)
                {
                    if (val != null)
                    {
                        Console.WriteLine(val);
                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder+@"\R2Northstar\mods\"+val);

                        if (!IsDirectoryEmpty(rootDirs))
                        {
                            if (Directory.Exists(Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder"))
                            {

                                MoveFiles(Current_Install_Folder+@"\R2Northstar\mods\"+val, Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder");

                            }
                            else
                            {

                                Directory.CreateDirectory(Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder");
                                MoveFiles(Current_Install_Folder+@"\R2Northstar\mods\"+val, Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder");

                            }
                        }
                    }

                }
                foreach (var val in Active)
                {
                    if (val != null)
                    {
                        Console.WriteLine(Current_Install_Folder+@"\R2Northstar\mods\"+val);
                        System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder+@"\R2Northstar\mods\"+val);

                        if (!IsDirectoryEmpty(rootDirs))
                        {
                            if (Directory.Exists(Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder"))
                            {

                                MoveFiles(Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder", Current_Install_Folder+@"\R2Northstar\mods\"+val);
                                Directory.Delete(Current_Install_Folder+@"\R2Northstar\mods\"+val+@"\Locked_Folder", true);

                            }
                            else
                            {

                                //What happens if theres no folder???

                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Log_Box.AppendText(ex.StackTrace);

            }


        }


        private void Apply_Btn_Mods_Click(object sender, EventArgs e)
        {
            Move_Mods();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Url_box.Text != null|| Url_box.Text != "")
                {
                    if (Uri.IsWellFormedUriString(Url_box.Text, UriKind.Absolute))
                    {
                        parse_git_to_zip(Url_box.Text);
                        Active_List.Refresh();
                        Inactive_List.Refresh();
                        Call_Mods_From_Folder();

                    }
                }
            }
            catch (Exception ex)
            {
                Log_Box.AppendText(ex.StackTrace);
                MessageBox.Show("\n\n\n"+ex.Message);
                Main_Window.SelectedTab = Main;

            }
        }

        private void Browse_Local_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                if (path == null || !File.Exists(path))
                {

                    Log_Box.AppendText("\nInvalid Mod Zip Location chosen");
                    Main_Window.SelectedTab = Main;


                }
                else
                {
                    string FolderName = path.Split(Path.DirectorySeparatorChar).Last();

                    Console.WriteLine(path);
                    Console.WriteLine("The Folder Name is-"+FolderName+"\n\n");
                    Unpack_To_Location_Custom(path, Current_Install_Folder+ @"\R2Northstar\mods");
                    Call_Mods_From_Folder();

                    Active_List.Refresh();
                    Inactive_List.Refresh();
                }

            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void metroSetButton1_Click_1(object sender, EventArgs e)
        {
            GC.Collect();

            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(Current_Install_Folder+@"\Titanfall2.exe"))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = Current_Install_Folder+@"\Titanfall2.exe";
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Current_Install_Folder);
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

                    MessageBox.Show("Could Not Find NorthStar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }
        }

        private void Arg_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroSetTile2_Click(object sender, EventArgs e)
        {

        }

        private void Import_Skin_Bttn_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (Directory.Exists(Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR"))
            {
                try
                {
                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                    Skin_Normal_Tile.BackgroundImage = Image_1;
                    Image Image_2 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                    Skin_Glow_Tile.BackgroundImage = Image_2;
                    Directory.Delete(Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Log_Box.AppendText(ef.StackTrace);

                    Console.WriteLine(ef.ToString());
                }




            }
            if (Directory.Exists(Current_Install_Folder+@"\Thumbnail"))
            {
                try
                {
                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                    Skin_Normal_Tile.BackgroundImage = Image_1;
                    Image Image_2 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                    Skin_Glow_Tile.BackgroundImage = Image_2;
                    Directory.Delete(Current_Install_Folder+@"\Thumbnail", true);
                    GC.Collect();
                }
                catch (Exception ef)
                {
                    Log_Box.AppendText(ef.StackTrace);

                    Console.WriteLine(ef.ToString());
                }

            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Skin_Temp_Loc = openFileDialog.FileName;
                if (Skin_Temp_Loc == null || !File.Exists(Skin_Temp_Loc))
                {

                    Log_Box.AppendText("\nInvalid Mod Zip Location chosen");
                    Main_Window.SelectedTab = Main;


                }
                else
                {
                    Skin_Path_Box.Text = Skin_Temp_Loc;
                    Log_Box.AppendText("\nMod Found!");
                    if (ZipHasFile(".dds", Skin_Temp_Loc))
                    {
                        Console.WriteLine("Compatible");
                        Compatible_INDC.DisabledForeColor = Color.YellowGreen;
                        Compatible_INDC.DisabledBackColor = Color.YellowGreen;
                        Install_Skin_Bttn.Enabled = true;
                     //   var directory = new DirectoryInfo(root);
                       // var myFile = (from f in directory.GetFiles()orderby f.LastWriteTime descending select f).First();
                        if (Directory.Exists(Current_Install_Folder+@"\Skins_Unpack_Mod_MNGR"))
                        {
                            Skin_Path =  Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR";
                            ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"),true);

                        }
                        else
                        {

                            Directory.CreateDirectory(Current_Install_Folder+@"\Skins_Unpack_Mod_MNGR");
                            Skin_Path =  Current_Install_Folder+ @"\Skins_Unpack_Mod_MNGR";

                            ZipFile.ExtractToDirectory(Skin_Temp_Loc, Skin_Path, Encoding.GetEncoding("GBK"));

                        }
                    }
                    else
                    {
                        Console.WriteLine("Incompatible");
                        Compatible_INDC.DisabledBackColor = Color.Red;
                        Compatible_INDC.DisabledForeColor = Color.Red;
                        Install_Skin_Bttn.Enabled = false;

                    }

                    try
                    {
                        Console.WriteLine(Skin_Temp_Loc);
                        String Thumbnail = Current_Install_Folder+@"\Thumbnails\";
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
                                    String col = Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png";
                                    Console.WriteLine(firstOrDefault_Col);
                                    if (File.Exists(col))
                                    {

                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                        img_1.Save(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        Image Image_1 = new Bitmap(col);
                                        Skin_Normal_Tile.BackgroundImage = Image_1;
                                    }
                                    else
                                    {
                                        Console.WriteLine(col);
                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);

                                        img_1.Save(col);

                                        Image Image_S = new Bitmap(col);
                                        Skin_Normal_Tile.BackgroundImage = Image_S;

                                    }

                                }
                                else
                                {
                                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    Skin_Normal_Tile.BackgroundImage = Image_1;

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
                                    if (File.Exists(firstOrDefault_ilm +".png"))
                                    {

                                        Console.WriteLine(firstOrDefault_ilm);
                                        Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        Skin_Glow_Tile.BackgroundImage = Image_2;
                                    }
                                    else
                                    {

                                        DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                        img_2.Save(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");

                                        Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        Skin_Glow_Tile.BackgroundImage = Image_2;
                                    }
                                }
                                else
                                {
                                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    Skin_Glow_Tile.BackgroundImage = Image_1;

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
                                    if (File.Exists(firstOrDefault_Col +".png"))
                                    {

                                        Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        Skin_Normal_Tile.BackgroundImage = Image_1;
                                    }
                                    else
                                    {
                                        DDSImage img_1 = new DDSImage(firstOrDefault_Col);
                                        img_1.Save(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        Image Image_1 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_Col)+".png");
                                        Skin_Normal_Tile.BackgroundImage = Image_1;

                                    }

                                }
                                else
                                {
                                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    Skin_Normal_Tile.BackgroundImage = Image_1;

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
                                    if (File.Exists(firstOrDefault_ilm +".png"))
                                    {

                                        Console.WriteLine(firstOrDefault_ilm);
                                        Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        Skin_Glow_Tile.BackgroundImage = Image_2;
                                    }
                                    else
                                    {

                                        DDSImage img_2 = new DDSImage(firstOrDefault_ilm);
                                        img_2.Save(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        Image Image_2 = new Bitmap(Thumbnail+Path.GetFileName(firstOrDefault_ilm)+".png");
                                        Skin_Glow_Tile.BackgroundImage = Image_2;
                                    }
                                }
                                else
                                {
                                    Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                                    Skin_Glow_Tile.BackgroundImage = Image_1;

                                }

                            }





                        }

                        //   Import_Skin_Bttn.Enabled=false;
                    }
                    catch (Exception ex)
                    {
                        Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                        Skin_Normal_Tile.BackgroundImage = Image_1;
                        Image Image_2 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
                        Skin_Glow_Tile.BackgroundImage = Image_2;
                        Console.WriteLine(ex.StackTrace);
                        Log_Box.AppendText(ex.StackTrace);

                    }

                }

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
                    // ...
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
            catch (Exception)
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
                Log_Box.AppendText(ex.StackTrace);

                MessageBox.Show(ex.Message);
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
            temp = ImageName.LastIndexOf("\\")+1;
            ImageName = ImageName.Substring(temp, ImageName.Length-temp);
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

        private void Install_Skin_Bttn_Click(object sender, EventArgs e)
        {
            Skin_Path_Box.Text = "";
          Compatible_INDC.DisabledBackColor = Color.Gray;
            Compatible_INDC.DisabledForeColor = Color.Gray;


           
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
            MessageBox.Show("Installed!");
            DirectoryInfo di = new DirectoryInfo(Skin_Path);
            FileInfo[] files = di.GetFiles();

            Image Image_1 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
            Skin_Normal_Tile.BackgroundImage = Image_1;

            Image Image_2 = new Bitmap(Directory.GetCurrentDirectory()+@"\No_Texture.jpg");
            Skin_Glow_Tile.BackgroundImage = Image_2; 
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

            }
            catch(Exception ef)
            {
                Import_Skin_Bttn.Enabled=true;
                Log_Box.AppendText(ef.StackTrace);

                Log_Box.AppendText(ef.ToString());
            }
            Console.WriteLine("Files deleted successfully");
            GC.Collect();
            Install_Skin_Bttn.Enabled = false;
            Install_Skin_Bttn.DisabledBackColor = Color.DarkSlateGray;

            Import_Skin_Bttn.Enabled=true;

            String Thumbnail = Current_Install_Folder+@"\Thumbnails\";
            if (Directory.Exists(Thumbnail))
            {
                Directory.Delete(Thumbnail, true);


            }

            //Install_Skin_Bttn.ForeColor = Install_Skin_Bttn.DisabledBackColor;

        }
       
        private void Adv_chk_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        

        private void NS_Client_Updates_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Ns_Args.Checked == true)
            {


                Log_Box.AppendText("\nDo not overwrite ns_startup_args.txt ENABLED! - this will backup and restore the original ns_startup_args and from the folder");
                Properties.Settings.Default.Ns_Startup = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Log_Box.AppendText("\nOVERWRITE ns_startup_args.txt ENABLED!");
                Properties.Settings.Default.Ns_Startup = false;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox2_CheckedChanged_2(object sender, EventArgs e)
        {
            if (Ns_Args_Dedi.Checked == true)
            {


                Log_Box.AppendText("\nDo not overwrite ns_startup_args_Dedi.txt ENABLED! - this will backup and restore the original ns_startup_args_dedi from the folder");
                Properties.Settings.Default.Ns_Dedi = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Log_Box.AppendText("\nOVERWRITE ns_startup_args_Dedi.txt ENABLED!");
                Properties.Settings.Default.Ns_Dedi = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Launch_Northstar_Advanced_Click(object sender, EventArgs e)
        {
            if (File.Exists(Current_Install_Folder+@"\ns_startup_args.txt"))
            {
                saveAsyncFile(Arg_Box.Text, Current_Install_Folder+@"\ns_startup_args.txt", false, false);


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

                    MessageBox.Show("Could Not Find NorthStar.exe!");


                }
            }
            else
            {

                Console.WriteLine("Err, File not found");


            }
        }

        private void Dedicated_Btn_Click_1(object sender, EventArgs e)
        {
            if (Directory.Exists(Current_Install_Folder))
            {

                if (File.Exists(Current_Install_Folder+@"\ns_startup_args_dedi.txt"))
                {
                    saveAsyncFile(Arg_Box.Text, Current_Install_Folder+@"\ns_startup_args_dedi.txt", false, false);


                }
                else
                {
                    Console.WriteLine("Err, File not found ns_startup_args_dedi");

                }

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = Current_Install_Folder+@"\r2ds.bat";
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

                Console.WriteLine("Could Not Find Dedicated bat!");


            }

        }

        private void metroSetTile2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Launchvanilla_MouseHover(object sender, EventArgs e)
        {
           

            Selected_Banner.BackgroundImage =Defualt_Image_Vanilla;
        }

        private void Start_Client_MouseHover(object sender, EventArgs e)
        {
            Selected_Banner.BackgroundImage =Defualt_Image_NS;
        }

        private void Normal_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }

}