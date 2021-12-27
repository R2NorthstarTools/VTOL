namespace Northstar_Manger
{
    public partial class MainWindow : Form
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        public bool Found_Install = false;
        public bool Found_Install_Folder = false;
        public string Current_Install_Folder = "";
        private string NSExe, Gamever;
        private bool NS_Installed;
        public MainWindow()
        {
            InitializeComponent();
            Log_Box.AppendText("\nWelcome To the Northstar Mod Manager!\n");
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
                NS_Installed = true;
                if (File.Exists(NSExe))
                {


                }
            }
            else
            {

                NS_Installed = false;
            }

            if (NS_Installed == false)
            {

                Log_Box.AppendText("OH MY!, NorthStar Launcher Was not found, do you want to Install it by Clicking Install Northstar Launcher?");
                Version_TextBox.BackColor = Color.Red;
                Version_TextBox.ForeColor = Color.Black;

            }
            else
            {

                Version_TextBox.BackColor = Color.Green;
                Version_TextBox.ForeColor = Color.Black;



            }
            Gamever= Get_And_Set_Filepaths(Current_Install_Folder, "gameversion.txt");
            Version_TextBox.Text = NSExe;




        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Browse_New_Install_Click(object sender, EventArgs e)
        {
            // Log_Box.AppendText(LookForTitanfallInstall());
            while (Found_Install_Folder == false)
            {
                //    FindGitPath("dotnsset", ".exe", @"C:\Program Files");
                Log_Box.AppendText("\nAutomatically Looking For The Northstar And Titandfall Install :-)");
                Cursor.Current = Cursors.WaitCursor;

                FindNSInstall("Titanfall2", @"C:\Program Files (x86)\Steam");
                Log_Box.AppendText("\nCould not Find the Install at C:\\Program Files (x86)\\Steam - Continuing Traversal");
                FindNSInstall("Titanfall2", @"D:\Games");
                if (Found_Install_Folder == false)
                {
                    Log_Box.AppendText("\nCould Not Find, Please Manually Navigate");


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
    }
}