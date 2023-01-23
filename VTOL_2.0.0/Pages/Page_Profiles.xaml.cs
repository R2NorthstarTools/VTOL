using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
namespace VTOL.Pages
{
    
    /// <summary>
    /// Interaction logic for Page_Profiles.xaml
    /// </summary>
    /// 
    
    public partial class Page_Profiles : Page
    {
        public MainWindow Main = GetMainWindow();

        public class DirectoryUnpacker
        {
           
            public static void UnpackDirectory(string path, string targetDirectory)
            {
                //decompress the bin.gz file
                using (FileStream sourceStream = File.Open(path, FileMode.Open))
                using (FileStream decompressedFileStream = File.Create(@"D:\Games\Titanfall2\R2Northstar\mods\directory_open.bin"))
                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedFileStream);
                }
                using (var stream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory_open.bin", FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var data = (DirectoryData)formatter.Deserialize(stream);
                    string dataAsString = data.ToString();
                    //MessageBox.Show(dataAsString);



                    foreach (string folder in data.Folders)
                    {
                        string folderName = System.IO.Path.GetFileName(folder);

                        int index = folder.LastIndexOf("Titanfall2");
                        string fileNameUpToWord = folder.Substring(index + "Titanfall2".Length + 1);
                        string targetFolder = System.IO.Path.Combine(targetDirectory, fileNameUpToWord);

                        //MessageBox.Show(fileNameUpToWord + " --> " + targetFolder + " |----|\n");

                        Directory.CreateDirectory(targetFolder);
                    }

                   
                    foreach (string file in data.Files)
                    {
                        string fileName = System.IO.Path.GetFileName(file);
                        string targetFile = System.IO.Path.Combine(targetDirectory, fileName);
                        string parentFolder = System.IO.Path.GetDirectoryName(file);
                        int index = file.LastIndexOf("Titanfall2");
                        string fileNameUpToWord = file.Substring(index + "Titanfall2".Length + 1);
                        MessageBox.Show(fileName + " --> " + System.IO.Path.Combine(targetDirectory, fileNameUpToWord) +  " |----|\n" + fileNameUpToWord);
                        //MessageBox.Show(Directory.Exists(System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(parentFolder))).ToString());
                       
                        if (System.IO.Path.GetFileName(parentFolder).Contains("Titanfall2"))
                        {
                            File.Copy(file, targetFile, true);


                        }
                        else
                        {
                           
                            File.Copy(file, System.IO.Path.Combine(targetDirectory, fileNameUpToWord),true);

                        }

                    }
                }
            }
        }
        public class DirectoryLister
        {
            public static void ListDirectory(string path, string[] includedFolders, string[] includedFiles)
            {
                var allFolders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                var allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                var includedFoldersPath = allFolders.Where(f => includedFolders.Any(i => f.StartsWith(System.IO.Path.Combine(path, i))));
                var includedFilesPath = allFiles.Where(f => includedFiles.Contains(System.IO.Path.GetFileName(f)) || includedFoldersPath.Any(folder => f.StartsWith(folder)));
                var data = new DirectoryData
                {
                    Folders = includedFoldersPath.Select(f => f).ToArray(),
                    Files = includedFilesPath.Select(f => f).ToArray()
                };

                using (var stream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, data);
                }
                //compress the bin file
                using (FileStream sourceStream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Open))
                using (FileStream targetStream = File.Create(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz"))
                using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                {
                    sourceStream.CopyTo(compressionStream);
                }
            }

           
        }

        [Serializable]
        public class DirectoryData
        {
            public string[] Folders { get; set; }
            public string[] Files { get; set; }
            public override string ToString()
            {
                return string.Join(" ", Folders.Concat(Files));
            }
        }
        public Page_Profiles()
        {
            InitializeComponent();
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
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Extra_Menu.Text = null;
        }
        public class DirectoryReader
        {
            public static DirectoryData ReadDirectory(string path)
            {
                using (var stream = File.Open(path, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    return (DirectoryData)formatter.Deserialize(stream);

                }
            }
        }
        private void Export_Profile_Click(object sender, RoutedEventArgs e)
        {
            DirectoryLister.ListDirectory(@"D:\Games\Titanfall2", new string[] { "R2Northstar", "plugins", "bin"}, new string[] { "Northstar.dll", "NorthstarLauncher.exe", "r2ds.bat", "discord_game_sdk.dll"});
          //  DirectoryLister.ListDirectory(@"D:\Games\Titanfall2\R2Northstar\mods\");
        }

        private void Import_Profile_Click(object sender, RoutedEventArgs e)
        {
            DirectoryUnpacker.UnpackDirectory(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz", @"D:\Games\Titanfall2\R2Northstar\mods\open\directory.bin.gz");
           // DirectoryData data = DirectoryReader.ReadDirectory(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz");
         //   string dataAsString = data.ToString();
           // MessageBox.Show(dataAsString);
        }
    }
}
