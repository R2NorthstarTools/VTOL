using System.ComponentModel;
using System.Net;
using System.Collections.Generic;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json;
using Octokit;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Northstar_Manger
{
    public partial class MainWindow : Form
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        public bool Found_Install = false;
        public bool Found_Install_Folder = false;
        public string Current_Install_Folder = "";
        private string NSExe;
        private bool NS_Installed;
        private WebClient webClient = null;
        string current_Northstar_version_Url;
        int failed_search_counter =0;
        public MainWindow()
        {
            InitializeComponent();
            Log_Box.AppendText("\nWelcome To the Northstar Mod Manager!\n");
            Thread.Sleep(2000);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string Get_And_Set_Filepaths(string rootDir, string Filename)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@rootDir);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + Filename + "*.*");
                Console.WriteLine(rootDir);
                Console.WriteLine(Filename);

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
                Log_Box.AppendText("The process failed: "+ e.ToString());
            }
            return "Exited with No return";


        }
        private void FindNSInstall(string Search, string FolderDir)
        {



            System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@FolderDir);

            WalkDirectoryTree(rootDirs, Search);

            Console.WriteLine("Files with restricted access:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }



        }
        private void contextMenuStrip1_Opening(object sesnder, System.ComponentModel.CancelEventArgs e)
        {

        }
        void WalkDirectoryTree(System.IO.DirectoryInfo root, String Search)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {

                if (files != null)
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
                      
                       // WalkDirectoryTree(dirInfo, Search);
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
                log.Add(e.Message);


            }

        }

        private void Install_NS_Button_Click(object sender, EventArgs e)
        {
           
        }

        private void Install_Location_Label_Click(object sender, EventArgs e)
        {

        }
        private void Check_Integrity_Of_NSINSTALL()
        {


            if (File.Exists(NSExe))
            {
                System.IO.DirectoryInfo[] FolderDir = null;
                System.IO.DirectoryInfo rootDirs = new DirectoryInfo(Current_Install_Folder);
                FolderDir = rootDirs.GetDirectories();
                 List<string> Baseline =  Read_From_Text_File(@"C:\temp\NormalFolderStructure.txt");
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

                if (Baseline.SequenceEqual(current) == true)
                {
                    Log_Box.AppendText("\nDirectory Check Successful - File Integrity has not been Implimented yet, so be sure the files are good!");
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
        public static async Task saveAsyncFile(string Text, string Filename,bool ForceTxt = true, bool append = true)
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
                }
                else
                {

                    await File.WriteAllTextAsync(Filename, Text);

                }
            }
            else
            {

                await File.WriteAllTextAsync(Filename, Text);


            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async Task Read_Latest_Release(string address)
        {
            
            Log_Box.AppendText("\nJson Download Started!");
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead(address);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            s = s.Replace("[", "");
            s= s.Replace("]","");
            saveAsyncFile(s, @"C:\temp\temp.json",false,false);
            Log_Box.AppendText("\nJson Download completed!");
            Log_Box.AppendText("\nParsing Latest Release........");
            Parse_Release();

        }
        private void Parse_Release()
        {
            var myJsonString = File.ReadAllText(@"C:\temp\temp.json");
            var myJObject = JObject.Parse(myJsonString);


            current_Northstar_version_Url =  myJObject.SelectToken("assets.browser_download_url").Value<string>();
            Log_Box.AppendText("\nRelease Parsed! found - \n"+current_Northstar_version_Url);

        }
        private void Unpack_To_Location(string Target_Zip, string Destination_Zip)
        {
            Log_Box.AppendText("\nUnpacking " + Path.GetFileName(Target_Zip) + " to " + Destination_Zip);
            //if (File.Exists(Target_Zip) && Directory.Exists(Destination_Zip))
         //   {
               ZipFile.ExtractToDirectory(Target_Zip, Destination_Zip,true);
                Log_Box.AppendText("\nUnpacking Complete!");
          //  }
         //   else
            //{
            //    if (!File.Exists(Target_Zip))
            //    {
            //        Log_Box.AppendText("\nTarget Zip Does Not exist!!!!!!");
                    

            //    }
            //    if (!Directory.Exists(Destination_Zip))
            //    {
            //        Log_Box.AppendText("\nTarget Location Does Not exist, please Double Check or Browse for the correct install location");
                    
            //    }
            //}
        }
        private void InstallNorthsatar_Click(object sender, EventArgs e)
        {

            Read_Latest_Release("https://api.github.com/repos/R2Northstar/Northstar/releases/latest");
          //  Is file downloading yet?

            if (webClient != null)
                return;

            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            Directory.CreateDirectory(@"C:\temp\Releases\");
            webClient.DownloadFileAsync(new Uri(current_Northstar_version_Url), @"C:\temp\Releases\NorthStar_Release.zip");
            Log_Box.AppendText("\nStarting Install procedure!");
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            webClient = null;
            Log_Box.AppendText("\nDownload completed!");
            Unpack_To_Location(@"C:\temp\Releases\NorthStar_Release.zip", Current_Install_Folder);

        }
        private void Auto_Install_And_verify()
        {
            failed_search_counter = 0;
            Found_Install_Folder = false;
             Log_Box.AppendText("\nLooking For Titanfall Install");
            while (Found_Install_Folder == false && failed_search_counter < 2)
            {
                //    FindGitPath("dotnsset", ".exe", @"C:\Program Files");
                //To Do, add an optional to save the variable of the folder path once assigned!!!!!
                Log_Box.AppendText("\nAutomatically Looking For The Northstar And Titandfall Install :-)");
                Cursor.Current = Cursors.WaitCursor;
                Log_Box.AppendText("Looking Under these Directories -" +@"C:\Program Files (x86)\Steam" + " " + @"D:\Games");
                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Steam");
                FindNSInstall("Titanfall2", @"D:\Games");
                if (Found_Install_Folder == false && failed_search_counter >= 2)
                {
                    Log_Box.AppendText("\nCould Not Find, Please Manually Navigate to a proper Titanfall 2 installation");
                    break;


                }

            }
            if (Found_Install_Folder == true)
            {
                Install_Textbox.Text = Current_Install_Folder;
                Log_Box.AppendText("\nFound Install Location at " + Current_Install_Folder + "\n");
                NSExe = Get_And_Set_Filepaths(Current_Install_Folder, "NorthstarLauncher.exe");
                //Checking if the path Given Returned Something Meaningful. I know i could do this better, but its 3.37am and i feel like im dying from this cold :|.
                Check_Integrity_Of_NSINSTALL();
            }

        }

        private void Check_Ver_Click(object sender, EventArgs e)
        {
            Auto_Install_And_verify();


        }

        private void Browse_New_Install_Click(object sender, EventArgs e)
        {

        }
    }
}