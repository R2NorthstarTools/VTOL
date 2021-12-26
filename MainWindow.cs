namespace Northstar_Manger
{
    public partial class MainWindow : Form
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        public bool Found_Install = false;
        public bool Found_Install_Folder = false;
        public MainWindow()
        {
            InitializeComponent();
            Log_Box.AppendText("\nWelcome To the Northstar Mod Manager!\n");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string LookForTitanfallInstall()
        {
            while (true)
            {
                try
                {
                    string folderName = "Titanfall2-master";
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    FileInfo[] files = null;
                    foreach (DriveInfo dir in allDrives)
                    {
                        if (dir.IsReady)
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(dir.Name);
                            files = dirInfo.GetFiles(folderName + "*.*", SearchOption.AllDirectories);
                        }
                    }
                    List<string> fileNames = new List<string>();
                    foreach (FileInfo file in files)
                    {
                        fileNames.Add(file.Name);
                    }

                    foreach (object o in fileNames)
                    {
                        Log_Box.AppendText(o.ToString());
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    //Log_Box.AppendText("\nCould Not Get"+ e.Message);
                    continue;
                }
            }
            return "\nNo Install Found!";

        }
        private void FindNSInstall(string Search)
        {

            // Start with drives if you have to search the entire computer.
            //string[] drives = System.Environment.GetLogicalDrives();

            //foreach (string dr in drives)
            //{
            //    System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
            //    if (!di.IsReady)
            //    {
            //        Console.WriteLine("The drive {0} could not be read", di.Name);
            //        continue;
            //    }

            // System.IO.DirectoryInfo rootDir = di.RootDirectory;

            // }
              //  while (Found_Install_Folder == false)
            
                System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@"C:\Program Files");

                WalkDirectoryTree(rootDirs, Search);

                Console.WriteLine("Files with restricted access:");
                foreach (string s in log)
                {
                    Console.WriteLine(s);
                }
            
           
          
        }
        public  string FindGitPath(string firstFilter, string secondFilter, string initialPath)
        {
            string gitPath = string.Empty;
            foreach (var i in Directory.GetDirectories(initialPath))
            {
                try
                {
                    foreach (var f in Directory.GetDirectories(i, firstFilter, SearchOption.AllDirectories))
                    {
                        if (f != "" || f != null || f.Contains(firstFilter))
                        {
                            Log_Box.AppendText("\n"+f);
                            Found_Install = true;

                        }else
                        {
                           Log_Box.AppendText("\nNo Install Found!");

                        }
                        //foreach (var s in Directory.GetDirectories(f))
                        //{
                        //    if (s == Path.Combine(f, secondFilter))
                        //    {
                        //        gitPath = f;
                        //        Log_Box.AppendText(gitPath);
                        //        break;
                        //    }
                        //}
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Log_Box.AppendText("Path is not accessible: {0}"+ i);
                }
            }
            return gitPath;
        }
        private void contextMenuStrip1_Opening(object sesnder, System.ComponentModel.CancelEventArgs e)
        {

        }
         void WalkDirectoryTree(System.IO.DirectoryInfo root , String Search )
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
                    Console.WriteLine("Found Folder");
                    Console.WriteLine(dirInfo.FullName);
                    Found_Install_Folder = true;
                    Found_Install = true;
                    break;

                }
                else
                {
                    Console.WriteLine("Trying again");
                    WalkDirectoryTree(dirInfo, Search);


                }
                // Resursive call for each subdirectory.
            }
                
        }
    
        private void Browse_New_Install_Click(object sender, EventArgs e)
        {
            // Log_Box.AppendText(LookForTitanfallInstall());
            while (Found_Install == false || Found_Install_Folder == false)
            {
                //    FindGitPath("dotnsset", ".exe", @"C:\Program Files");

                FindNSInstall("LycheeSlicer");

            }
        }
    }
}