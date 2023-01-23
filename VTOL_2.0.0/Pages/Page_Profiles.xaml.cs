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
using System.Threading;
using NLog.Targets;

namespace VTOL.Pages
{
    
    /// <summary>
    /// Interaction logic for Page_Profiles.xaml
    /// </summary>
    /// 
    
    public partial class Page_Profiles : Page
    {
        public MainWindow Main = GetMainWindow();
        class GZipStreamWithProgress : GZipStream
        {
            public event EventHandler<double> ProgressChanged;
            public event EventHandler<string> CurrentFileChanged;

            private long totalBytesRead;
            private string currentFile;

            public GZipStreamWithProgress(Stream stream, CompressionMode mode) : base(stream, mode) { }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int bytesRead = base.Read(buffer, offset, count);
                totalBytesRead += bytesRead;

                OnProgressChanged(totalBytesRead);
                Console.WriteLine(bytesRead);
                return bytesRead;
            }

            public void SetCurrentFile(string file)
            {
                currentFile = file;
                OnCurrentFileChanged(file);
            }

            protected void OnProgressChanged(long totalBytesRead)
            {
                double progress = (double)totalBytesRead / BaseStream.Length;
                ProgressChanged?.Invoke(this, progress);
            }

            protected void OnCurrentFileChanged(string file)
            {
                CurrentFileChanged?.Invoke(this, file);
            }
        }
        public void UnpackDirectory(string path, string targetDirectory)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                //decompress the bin.gz file
                using (FileStream sourceStream = File.Open(path, FileMode.Open))
                using (FileStream decompressedFileStream = File.Create(appDataPath+@"directory_open.bin"))
                using (var decompressionStream = new GZipStreamWithProgress(sourceStream, CompressionMode.Decompress))
                {
                decompressionStream.ProgressChanged += (sender, progress) =>
                {
                    Console.WriteLine("Decompression Progress: {0:P}", progress);
                };
                decompressionStream.CurrentFileChanged += (sender, file) =>
                {
                    Console.WriteLine("Decompressing file: {0}", file);
                };
                //...
                var currentFile = path;
                decompressionStream.SetCurrentFile(currentFile);
                decompressionStream.CopyTo(decompressedFileStream);
                }
                using (var stream = File.Open(appDataPath + @"directory_open.bin", FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var data = (DirectoryData)formatter.Deserialize(stream);
                    string dataAsString = data.ToString();         
                    foreach (string folder in data.Folders)
                    {
                        int index = folder.LastIndexOf("Titanfall2");
                        string fileNameUpToWord = folder.Substring(index + "Titanfall2".Length + 1);
                        string targetFolder = System.IO.Path.Combine(targetDirectory, fileNameUpToWord);
                        //MessageBox.Show(fileNameUpToWord + " --> " + targetFolder + " |---S-|\n");
                        Directory.CreateDirectory(targetFolder);
                    }                   
                    foreach (string file in data.Files)
                    {
                        string fileName = System.IO.Path.GetFileName(file);
                        string targetFile = System.IO.Path.Combine(targetDirectory, fileName);
                        string parentFolder = System.IO.Path.GetDirectoryName(file);
                        int index = file.LastIndexOf("Titanfall2");
                        string fileNameUpToWord = file.Substring(index + "Titanfall2".Length + 1);
                        //MessageBox.Show(fileName + " --> " + System.IO.Path.Combine(targetDirectory, fileNameUpToWord) +  " |----|\n" + fileNameUpToWord);
                        //MessageBox.Show(Directory.Exists(System.IO.Path.Combine(targetDirectory, System.IO.Path.GetFileName(parentFolder))).ToString());                       
                        if (System.IO.Path.GetFileName(parentFolder).Contains("Titanfall2"))
                        {
                             TryCopyFile(file, targetFile, true);
                        }
                        else
                        {
                            TryCopyFile(file, System.IO.Path.Combine(targetDirectory, fileNameUpToWord),true);
                        }

                    }
                    CheckDirectory(appDataPath + @"directory_open.bin", targetDirectory);
                    if (File.Exists(appDataPath + @"directory_open.bin")){ File.Delete(appDataPath + @"directory_open.bin"); }
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
        public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        public string[] CheckAndRemoveMissingFolders(string[] folderNames)
{
    return folderNames.Where(folder => Directory.Exists(folder)).ToArray();
}
        public string[] CheckAndRemoveMissingFilesAndFolders(string[] fileAndFolderNames)
        {
            var validFilesAndFolders = new List<string>();
            foreach (string fileOrFolderName in fileAndFolderNames)
            {
                if (File.Exists(fileOrFolderName) || Directory.Exists(fileOrFolderName))
                {

                    validFilesAndFolders.Add(fileOrFolderName);
                }
            }

            Console.WriteLine("Verification Completed For the group and all its subloders/files");

            return validFilesAndFolders.ToArray();
        }

        public static void CheckDirectory(string binFilePath, string targetPath)
            {
                if(!Directory.Exists(binFilePath) || !Directory.Exists(targetPath)){
                    
                    
                    return;
                }
                // Deserialize the directory data from the bin file
                DirectoryData data;
                using (var stream = File.OpenRead(binFilePath))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    data = (DirectoryData)formatter.Deserialize(stream);
                }

                var missingFolders = new List<string>();
                var missingFiles = new List<string>();
                string dataAsString = data.ToString();

                // Check if folders exist
                foreach (var folder in data.Folders)
                {

                    int index = folder.LastIndexOf("Titanfall2");
                    string fileNameUpToWord = folder.Substring(index + "Titanfall2".Length + 1);
                    var targetFolder = System.IO.Path.Combine(targetPath, fileNameUpToWord);

                    if (!Directory.Exists(targetFolder))
                    {
                        missingFolders.Add(targetFolder);
                    }
                }

                // Check if files exist
                foreach (var file in data.Files)
                {
                    int index = file.LastIndexOf("Titanfall2");
                    string fileNameUpToWord = file.Substring(index + "Titanfall2".Length + 1);
                    var targetFile = System.IO.Path.Combine(targetPath, fileNameUpToWord);

                    if (!File.Exists(targetFile))
                    {
                        missingFiles.Add(targetFile);
                    }
                }

                // Display summary of missing folders and files
                var message = "";
                if (missingFolders.Count > 0)
                {
                    message += $"Missing Folders: {string.Join(", ", missingFolders)}\n";
                }
                if (missingFiles.Count > 0)
                {
                    message += $"Missing Files: {string.Join(", ", missingFiles)}\n";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Missing Folders and Files");
                }
                else
                {

                    MessageBox.Show("Files Verified Successfully!");

                }
            }
            public  void ListDirectory(string path, string[] includedFolders, string[] includedFiles)
        {
            Console.WriteLine("starting");
            var allFolders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                var allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            
                var includedFoldersPath = allFolders.Where(f => includedFolders.Any(i => f.StartsWith(System.IO.Path.Combine(path, i))));


            var includedFilesPath = allFiles.Where(f => includedFiles.Contains(System.IO.Path.GetFileName(f)) || includedFoldersPath.Any(folder => f.StartsWith(folder)));
                var data = new DirectoryData
                {
                    Folders = CheckAndRemoveMissingFilesAndFolders(includedFoldersPath.Select(f => f).ToArray()),
                    Files = CheckAndRemoveMissingFilesAndFolders(includedFilesPath.Select(f => f).ToArray())
                };

                using (var stream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Create))
                {
                var formatter = new BinaryFormatter();
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0;
                int totalBytesRead = 0;
                var serializationStream = new MemoryStream();
                formatter.Serialize(stream, data);
                serializationStream.Seek(0, SeekOrigin.Begin);
                while ((bytesRead = serializationStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;
                    double progress = (double)totalBytesRead / serializationStream.Length;
                    Console.WriteLine("Serialization Progress: {0:P}", progress);
                }
                }
                //compress the bin file
                using (FileStream sourceStream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Open))
                using (FileStream targetStream = File.Create(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz"))
            using (GZipStreamWithProgress compressionStream = new GZipStreamWithProgress(targetStream, CompressionMode.Compress))
            {
                compressionStream.ProgressChanged += (sender, progress) =>
                {
                    Console.WriteLine("Compression Progress: {0:P}", progress);
                };
                 sourceStream.CopyTo(compressionStream);
                }


            if (File.Exists(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin")) { File.Delete(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin"); }

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
        private async void Pack(string target_directory, string[] folders_, string[] files_)
        {
            // Display a message to the user indicating that the operation has started

            DispatchIfNecessary(async () =>
            { 
                // Perform the long-running operation on a background thread
                var result = await Task.Run(() =>
                {


                ListDirectory(target_directory, folders_, files_);

                    return "Operation completed!";
                });
                Console.WriteLine(result);


            });
            // Update the UI with the result of the operation
        }
    private async void UnpackandCheck(string vtol_profiles_file_bin,string Target_Dir)
        {
            if (File.Exists(vtol_profiles_file_bin))
            {



                // Display a message to the user indicating that the operation has started
                DispatchIfNecessary(async () =>
                {
                // Perform the long-running operation on a background thread
                var result = await Task.Run(() =>
                    {
                        UnpackDirectory(vtol_profiles_file_bin, Target_Dir);
                        return "Operation completed!";
                    });

                    Console.WriteLine(result);
                });

            }
            // Update the UI with the result of the operation
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
            Pack(@"D:\Games\Titanfall2", new string[] { "R2Northstar", "plugins", "bin" },new string[] { "Northstar.dll", "NorthstarLauncher.exe", "r2ds.bat", "discord_game_sdk.dll" });
        }

        private void Import_Profile_Click(object sender, RoutedEventArgs e)
        {
            UnpackandCheck(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz", @"D:\Games\Titanfall2\R2Northstar\mods\open\directory.bin.gz");
        }
    }
}
