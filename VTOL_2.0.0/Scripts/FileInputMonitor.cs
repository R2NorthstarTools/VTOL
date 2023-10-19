using System;
using System.IO;
using System.Threading;

namespace VTOL.Scripts
{



    public class FileInputMonitor
    {

        private FileSystemWatcher fileSystemWatcher;


        public FileInputMonitor(string folderToWatchFor)
        {

            fileSystemWatcher = new FileSystemWatcher(folderToWatchFor);
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.NotifyFilter = NotifyFilters.DirectoryName;

            fileSystemWatcher.Filter = " *.*";
            fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            // Instruct the file system watcher to call the FileCreated method
            // when there are files created at the folder.
            fileSystemWatcher.IncludeSubdirectories = true;

            fileSystemWatcher.Created += new FileSystemEventHandler(FileCreated);

        } // end FileInputMonitor()
        private void OnChanged(object source, FileSystemEventArgs e)
        {
        }

        private void FileCreated(Object sender, FileSystemEventArgs e)
        {


        } // end public void FileCreated(Object sender, FileSystemEventArgs e)

        private void ProcessFile(String fileName)
        {
            FileStream inputFileStream;
            while (true)
            {
                try
                {
                    inputFileStream = new FileStream(fileName,
                        FileMode.Open, FileAccess.ReadWrite);
                    StreamReader reader = new StreamReader(inputFileStream);
                    Console.WriteLine(reader.ReadToEnd());
                    // Break out from the endless loop
                    break;
                }
                catch (IOException)
                {
                    // Sleep for 3 seconds before trying
                    Thread.Sleep(3000);
                } // end try
            } // end while(true)
        } // end private void ProcessFile(String fileName)

    } // end public class FileInputMonitor
}
