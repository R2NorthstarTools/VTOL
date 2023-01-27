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
		using System.Text.RegularExpressions;
using HandyControl.Tools;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Globalization;

namespace VTOL.Pages
		{

	/// <summary>
	/// Interaction logic for Page_Profiles.xaml
	/// </summary>
	/// 

	public partial class Page_Profiles : Page
	{


		public MainWindow Main = GetMainWindow();
		string NAME__;
		int NUMBER_MODS__;
		string SIZE;
		string VERSION;
		string SAVE_NAME__;
		string SAVE_PATH__;
		string CURRENT_FILE__;

		bool Do_Not_save_Mods = false;
		string[] Folders = new string[] { "R2Northstar", "plugins", "bin" };
		string[] Files = new string[] { "Northstar.dll", "NorthstarLauncher.exe", "r2ds.bat", "discord_game_sdk.dll" };

		bool Skip_Mods = false;
		bool processing = false;
		public CancellationTokenSource _cts = new CancellationTokenSource();
		public class PathModel
		{
			public string PathName { get; set; }
			public string Path { get; set; }
		}
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
		public void UnpackRead_BIN_INFO(string path)
		{
			try

			{
				CURRENT_FILE__ = path;
				string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

				//decompress the .vbp file
				using (FileStream sourceStream = File.Open(path, FileMode.Open))
				{


					if (sourceStream.Length == 0)
					{
						Console.WriteLine("The file is empty.");
						return;
					}
					using (var decompressionStream = new GZipStreamWithProgress(sourceStream, CompressionMode.Decompress))
					{

						if (File.Exists(appDataPath + @"\File_info.bin"))
						{
							File.Delete(appDataPath + @"\File_info.bin");
						}
						// unpack the "directory.bin" file
						using (FileStream decompressedFileStream = new FileStream(appDataPath + @"\File_info.bin", FileMode.Create))
						{
							decompressionStream.CopyTo(decompressedFileStream);
						}

						using (var stream = File.Open(appDataPath + @"\File_info.bin", FileMode.Open))
						{
							var formatter = new BinaryFormatter();
							var data = (DirectoryData)formatter.Deserialize(stream);
							string dataAsString = data.ToString();
							//string dataAsString = data.ToString();
							if (data.NAME.Length > 1 && data.NORTHSTAR_VERSION.Length > 1 && data.TOTAL_SIZE_OF_FOLDERS.Length > 1)
							{
								I_NORTHSTAR_VERSION.Content = data.NORTHSTAR_VERSION;
								I_NUMBER_OF_MODS.Content = data.MOD_COUNT;
								I_TOTAL_SIZE.Content = data.TOTAL_SIZE_OF_FOLDERS;
								NAME.Content = data.NAME;

								Console.WriteLine(data.NAME + "\n" + data.NORTHSTAR_VERSION + "\n" + data.MOD_COUNT + "\n" + data.TOTAL_SIZE_OF_FOLDERS);

							}
						}

					}
				}


				if (File.Exists(appDataPath + @"\File_info.bin"))
				{
					File.Delete(appDataPath + @"\File_info.bin");
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred: " + ex.Message);
			}
		}


		public bool UnpackDirectory(string path, string targetDirectory, CancellationToken token)
		{
			try
			{


				string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

				//decompress the bin.gz file
				using (FileStream sourceStream = File.Open(path, FileMode.Open))
				{


					if (sourceStream.Length == 0)
					{
						Console.WriteLine("The file is empty.");
						return false;
					}
					using (var decompressionStream = new GZipStreamWithProgress(sourceStream, CompressionMode.Decompress))
					{


						// unpack the "directory.bin" file
						using (FileStream decompressedFileStream = new FileStream(appDataPath + @"\directory_open.bin", FileMode.Create))
						{
							decompressionStream.CopyTo(decompressedFileStream);
						}



					}
					// unpack the "directory.bin" file
					using (var stream = File.Open(appDataPath + @"\directory_open.bin", FileMode.Open))
					{
						var formatter = new BinaryFormatter();
						var data = (DirectoryData)formatter.Deserialize(stream);
						string dataAsString = data.ToString();
						if (Skip_Mods == true)
						{
							data.Folders = data.Folders.Where(folder => !folder.Contains("R2Northstar\\mods")).ToArray();
							data.Files = data.Files.Where(file => !file.Contains("R2Northstar\\mods")).ToArray();

						}
						double totalSize = data.Folders.Count() + data.Files.Count();
						double currentSize = 0;
						string currentFile = "";


						foreach (string folder in data.Folders)
						{ string append = "";


							string foldername = System.IO.Path.GetFileName(folder);
							currentFile = foldername;
							int index = folder.LastIndexOf("Titanfall2");
							string fileNameUpToWord = folder.Substring(index + "Titanfall2".Length + 1);
							string targetFolder = System.IO.Path.Combine(targetDirectory, fileNameUpToWord);
							Directory.CreateDirectory(targetFolder);
							//	System.Threading.Thread.Sleep(50); // to simulate delay
							currentSize++;
							double progress = currentSize / totalSize * 100;
							int progressInt = (int)Math.Round(progress);
							DispatchIfNecessary(async () =>
							{
								Current_File_Tag.Content = append + currentFile;
								wave_progress.Text = progressInt + "%";
								wave_progress.Value = progressInt;

							});
							if (token.IsCancellationRequested)
							{
								return false;
							}
							Console.WriteLine("Copying... " + progressInt + "% - " + currentFile);
						}

						foreach (string file in data.Files)
						{
							string append = "";
							string fileName = System.IO.Path.GetFileName(file);
							currentFile = fileName;
							string targetFile = System.IO.Path.Combine(targetDirectory, fileName);
							string parentFolder = System.IO.Path.GetDirectoryName(file);
							int index = file.LastIndexOf("Titanfall2");
							string fileNameUpToWord = file.Substring(index + "Titanfall2".Length + 1);
							if (System.IO.Path.GetFileName(parentFolder).Contains("Titanfall2"))
							{
								TryCopyFile(file, targetFile, true);
							}
							else
							{
								TryCopyFile(file, System.IO.Path.Combine(targetDirectory, fileNameUpToWord), true);
							}
							//	System.Threading.Thread.Sleep(50); // to simulate delay
							currentSize++;
							double progress = currentSize / totalSize * 100;
							int progressInt = (int)Math.Round(progress);
							DispatchIfNecessary(async () =>
							{
								Current_File_Tag.Content = append + currentFile;
								wave_progress.Text = progressInt + "%";
								wave_progress.Value = progressInt;

							});
							if (token.IsCancellationRequested)
							{
								return false;
							}

							Console.WriteLine("Copying... " + progressInt + "% - " + currentFile);
						}
						CheckDirectory(appDataPath + @"\directory_open.bin", targetDirectory);
					}


				}
				if (File.Exists(appDataPath + @"\directory_open.bin"))
				{
					File.Delete(appDataPath + @"\directory_open.bin");
				}

				return true;

			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine("The file could not be found: " + ex.Message);
				return false;

			}
			catch (DirectoryNotFoundException ex)
			{
				Console.WriteLine("The directory could not be found: " + ex.Message);
				return false;

			}
			catch (IOException ex)
			{
				Console.WriteLine("An IO error occurred: " + ex.Message);
				return false;

			}
			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
				return false;

			}
			return false;

		}
		public async Task<bool> TryDeleteDirectoryAsync(string directoryPath, bool overwrite = true, int maxRetries = 10, int millisecondsDelay = 30)
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
		public bool TryDeleteDirectory(string directoryPath, bool overwrite = true, int maxRetries = 10, int millisecondsDelay = 300)
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
		public bool TryCreateDirectory(string directoryPath, int maxRetries = 10, int millisecondsDelay = 200)
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
		public bool TryMoveFile(string Origin, string Destination, bool overwrite = true, int maxRetries = 10, int millisecondsDelay = 200)
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
		public bool TryCopyFile(string Origin, string Destination, bool overwrite = true, int maxRetries = 10, int millisecondsDelay = 300)
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
		public class FileSizeCalculator
		{
			public static string Pack(string directoryPath, string[] folders, string[] files)
			{
				long totalSize = 0;
				// check if the directory exists
				if (Directory.Exists(directoryPath))
				{
					// get the directory info
					DirectoryInfo directory = new DirectoryInfo(directoryPath);
					// iterate through the folders array
					foreach (string folder in folders)
					{
						// check if the folder exists in the directory
						if (directory.GetDirectories(folder).Length > 0)
						{
							// get the folder info
							DirectoryInfo folderPath = directory.GetDirectories(folder)[0];
							// get the folder size
							totalSize += GetDirectorySize(folderPath);
						}
					}
					// iterate through the files array
					foreach (string file in files)
					{
						// check if the file exists in the directory
						if (directory.GetFiles(file).Length > 0)
						{
							// get the file info
							FileInfo filePath = directory.GetFiles(file)[0];
							// get the file size
							totalSize += filePath.Length;
						}
					}
				}
				return FormatSizeUnits(totalSize);
			}

			private static long GetDirectorySize(DirectoryInfo directory)
			{
				long totalSize = 0;
				// get the size of the files in the directory
				foreach (FileInfo file in directory.GetFiles())
				{
					totalSize += file.Length;
				}
				// get the size of the subdirectories
				foreach (DirectoryInfo subDirectory in directory.GetDirectories())
				{
					totalSize += GetDirectorySize(subDirectory);
				}
				return totalSize;
			}
			private static string FormatSizeUnits(long bytes)
			{
				string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
				double mod = 1024.0;
				int i = 0;
				while (bytes >= mod)
				{
					bytes /= (long)mod;
					i++;
				}
				return $"{bytes:F2} {units[i]}";
			}
		}
		public string[] CheckAndRemoveMissingFolders(string[] folderNames)
		{
			return folderNames.Where(folder => Directory.Exists(folder)).ToArray();
		}
		public string[] CheckAndRemoveMissingFilesAndFolders(string[] fileAndFolderNames)
		{
			try
			{

				var validFilesAndFolders = new List<string>();
				int totalFiles = fileAndFolderNames.Length;
				int currentFile = 0;
				//	Console.Write("Checking files and folders ---> 0%");
				//	Console.CursorVisible = false; // to hide the cursor
				foreach (string fileOrFolderName in fileAndFolderNames)
				{
					currentFile++;
					int progress = (currentFile * 100) / totalFiles;
					//		Console.SetCursorPosition(23, Console.CursorTop); // to set cursor position
					//	Console.Write(progress + "%");
					if (File.Exists(fileOrFolderName) || Directory.Exists(fileOrFolderName))
					{
						validFilesAndFolders.Add(fileOrFolderName);
					}

				}
				return validFilesAndFolders.ToArray();
			}
			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
			return null;
		}
		public  void CheckDirectory(string binFilePath, string targetPath)
		{
            try { 
			if (!Directory.Exists(binFilePath) || !Directory.Exists(targetPath)) {


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
				//MessageBox.Show(message, "Missing Folders and Files");
			}
			else
			{

				//MessageBox.Show("Files Verified Successfully!");

			}
		}
			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
		}
		public bool ListDirectory(string path, string[] includedFolders, string[] includedFiles, CancellationToken token)
		{
			try {

				if (!Directory.Exists(SAVE_PATH__))
				{

					return false;
				}

				Console.WriteLine("Starting");
				var allFolders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
				var allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
				IEnumerable<string> includedFoldersPath = Enumerable.Empty<string>();
				IEnumerable<string> includedFilesPath = Enumerable.Empty<string>();
				if (token.IsCancellationRequested)
					return false;

				if (Skip_Mods == true)
				{
					Console.WriteLine("Skipped Mods");

					includedFoldersPath = allFolders.Where(f => !f.Contains("R2Northstar\\mods") && includedFolders.Any(i => f.StartsWith(System.IO.Path.Combine(path, i))));

					includedFilesPath = allFiles.Where(f => !f.Contains("R2Northstar\\mods") && includedFiles.Contains(System.IO.Path.GetFileName(f)) || includedFoldersPath.Any(folder => f.StartsWith(folder)));

				}
				else
				{
					includedFoldersPath = allFolders.Where(f => includedFolders.Any(i => f.StartsWith(System.IO.Path.Combine(path, i))));
					includedFilesPath = allFiles.Where(f => includedFiles.Contains(System.IO.Path.GetFileName(f)) || includedFoldersPath.Any(folder => f.StartsWith(folder)));

				}
				string NS_Mod_Dir = Main.User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods";
				if (token.IsCancellationRequested)
					return false;

				var data = new DirectoryData
				{
					Folders = CheckAndRemoveMissingFilesAndFolders(includedFoldersPath.Select(f => f).ToArray()),
					Files = CheckAndRemoveMissingFilesAndFolders(includedFilesPath.Select(f => f).ToArray()),
					NORTHSTAR_VERSION = VERSION,
					NAME = SAVE_NAME__,
					MOD_COUNT = NUMBER_MODS__,
					TOTAL_SIZE_OF_FOLDERS = SIZE

				};
				if (token.IsCancellationRequested)
					return false;

				using (var stream = File.Open(SAVE_PATH__ + @"\" + EnforceWindowsStringName(SAVE_NAME__) + ".bin", FileMode.Create))
				{
					var formatter = new BinaryFormatter();
					formatter.Serialize(stream, data);
				}
				if (token.IsCancellationRequested)
					return false;
				//compress the bin file
				using (FileStream sourceStream = File.Open(SAVE_PATH__ + @"\" + EnforceWindowsStringName(SAVE_NAME__) + ".bin", FileMode.Open))
				using (FileStream targetStream = File.Create(SAVE_PATH__ + @"\" + EnforceWindowsStringName(SAVE_NAME__) + ".vbp"))
				using (GZipStreamWithProgress compressionStream = new GZipStreamWithProgress(targetStream, CompressionMode.Compress))
				{
					sourceStream.CopyTo(compressionStream);
				}





				if (File.Exists(SAVE_PATH__ + @"\" + EnforceWindowsStringName(SAVE_NAME__) + ".bin"))
				{

					File.Delete(SAVE_PATH__ + @"\" + EnforceWindowsStringName(SAVE_NAME__) + ".bin");

				}
				CancelWork();
				return true;



			}
			catch (OperationCanceledException)
			{
				Console.WriteLine("Cancelled!");
				return false;

			}
			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
				return false;
			}

			return false;

		}






		[Serializable]
		public class DirectoryData
		{
			public string[] Folders { get; set; }
			public string[] Files { get; set; }
			public string NORTHSTAR_VERSION { get; set; }
			public string NAME { get; set; }
			public int MOD_COUNT { get; set; }
			public string TOTAL_SIZE_OF_FOLDERS { get; set; }

			public override string ToString()
			{
				return string.Join(" ", Folders.Concat(Files));
			}
		}


		public string EnforceWindowsStringName(string input)
		{
			// Replace spaces with underscores
			input = input.Replace(" ", "_");

			// Remove any invalid characters
			input = Regex.Replace(input, @"[^a-zA-Z0-9_]", "");

			// Remove any leading or trailing underscores
			input = input.Trim('_');

			// Ensure the first character is a letter or number
			if (!char.IsLetterOrDigit(input[0]))
			{
				input = "_" + input;
			}

			return input;
		}
		public void FadeControl(Control control, bool fadeIn, double duration = 1)
		{
			if (fadeIn)
			{
				control.Visibility = Visibility.Visible;
				var animation = new DoubleAnimation
				{
					From = 0,
					To = 1,
					Duration = new Duration(TimeSpan.FromSeconds(duration))
				};
				control.BeginAnimation(UIElement.OpacityProperty, animation);
			}
			else
			{
				var animation = new DoubleAnimation
				{
					From = 1,
					To = 0,
					Duration = new Duration(TimeSpan.FromSeconds(duration))
				};
				animation.Completed += (sender, e) => control.Visibility = Visibility.Collapsed;
				control.BeginAnimation(UIElement.OpacityProperty, animation);
			}
		}
		private async void Pack(string target_directory, string[] folders_, string[] files_)
        {
			try
			{
				_cts = new CancellationTokenSource();
				var token = _cts.Token;

				DispatchIfNecessary(async () =>
				{
				// Perform the long-running operation on a background thread
				try
					{
						bool result = false;
						var result_ = await Task.Run(() =>
						{
							while (!token.IsCancellationRequested)
							{
							// Check the token's cancellation status
							token.ThrowIfCancellationRequested();
							// Add your long running operation here
							result = ListDirectory(target_directory, folders_, files_, token);
							}
							return result;
						}, token);
						if (result == true)
						{
							Console.WriteLine(result);
							Console.WriteLine("Complete!");
							Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
							Main.Snackbar.Show("SUCCESS!", "The Profile "+SAVE_NAME__+"Has Been Packed");
						}
						else
						{
							Console.WriteLine(result);
							Console.WriteLine("Failed!");
							Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
							Main.Snackbar.Show("ERROR", "The Profile " + SAVE_NAME__ + "Failed To Be Packed");
						}
					}
					catch (OperationCanceledException)
					{
					// Handle the cancellation
					Console.WriteLine("Cancelled!");
						Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
						Main.Snackbar.Show("ERROR", "The Profile Creation of" + SAVE_NAME__ + "Failed");
					}
					finally
					{
						wave_progress.Visibility = Visibility.Visible;
						Circe_progress.Visibility = Visibility.Hidden;
						Loading_Panel.Visibility = Visibility.Hidden;
						Options_Panel.Visibility = Visibility.Hidden;
						Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
						Export_Profile_Options_Panel.Visibility = Visibility.Hidden;
					}
				});
			}

			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
		}
		private async void PopulateListBoxWithRandomPaths()
		{

			// Turn on loading icon

			// Clear the list box
			Profile_List_Box.Items.Clear();

			// Create a list to hold the file paths
			List<string> filePaths = new List<string>();
			// Add random file paths to the list
			for (int i = 0; i < 10; i++)
			{
				filePaths.Add(System.IO.Path.GetRandomFileName());
				// Output the file paths to the console for debugging
				Profile_List_Box.Items.Add(System.IO.Path.GetRandomFileName());
				Profile_List_Box.Refresh();
				// Add the file paths to the list box
				await Task.Delay(50);

			}
			filePaths.ForEach(Console.WriteLine);

			//Profile_List_Box.ItemsSource = filePaths;


			// Turn off loading icon

		}
		private async void LoadProfiles()
		{
            try { 
			Console.WriteLine("Loading List");

			// Show loading icon
			//LoadingIcon.Visibility = Visibility.Visible;

			// Clear current listbox items
			Profile_List_Box.Items.Clear();

			// Get all .vpb files in the directory
			string[] vpbFiles = await Task.Run(() => Directory.GetFiles(Main.User_Settings_Vars.NorthstarInstallLocation + "VTOL_profiles", "*.vbp", SearchOption.AllDirectories));
			//string[] vpbFiles = Directory.GetFiles(Main.User_Settings_Vars.NorthstarInstallLocation + "VTOL_profiles", "*.vbp", SearchOption.AllDirectories);
			// Add .vpb files to listbox
			//foreach (string file in vpbFiles)
			//{
			//	Profile_List_Box.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file));
			//}
			foreach (string file in vpbFiles)
			{
				Profile_List_Box.Items.Add(file);
				Profile_List_Box.Refresh();
				await Task.Delay(50);
			}

			// Hide loading icon
			//	LoadingIcon.Visibility = Visibility.Collapsed;
			// Output the list to console
			vpbFiles.ToList().ForEach(Console.WriteLine);

		}
			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
		}
		private async void UnpackandCheck(string vtol_profiles_file_bin, string Target_Dir)
        {
            
			DispatchIfNecessary(async () =>
			{
				Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
				Console.WriteLine("Unpacking!");

				if (File.Exists(vtol_profiles_file_bin))
				{
					Console.WriteLine("Found!");

					Loading_Panel.Visibility = Visibility.Visible;
					_cts = new CancellationTokenSource();
					var token = _cts.Token;

					try
					{
						// Display a message to the user indicating that the operation has started

						// Perform the long-running operation on a background thread
						var result = await Task.Run(() =>
						{
							return UnpackDirectory(vtol_profiles_file_bin, Target_Dir, token);
						});

						if (result == true)
						{
							Console.WriteLine(result);
							Console.WriteLine("Complete!");
							Main.Snackbar.Title = "SUCCESS";
							Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
							Main.Snackbar.Message = "Operation Complete - The Profile is now active";
							Main.Snackbar.Show();
						}
						else
						{
							Main.Snackbar.Title = "ERROR";
							Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
							Main.Snackbar.Message = "Operation Failed / Cancelled";
							Main.Snackbar.Show();
							Console.WriteLine(result);
							Console.WriteLine("Failed!");
						}

						Loading_Panel.Visibility = Visibility.Hidden;
						Options_Panel.Visibility = Visibility.Hidden;

					}
					

				
					catch (OperationCanceledException)
					{
						Console.WriteLine("Cancelled!");
					}
				catch (Exception ex)
				{
					Main.logger2.Open();
					Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
					Main.logger2.Close();
				}
			}
				else
				{
					Main.Snackbar.Title = "FATAL";
					Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
					Main.Snackbar.Message = "FAILED\n Could Not Find the file - " + vtol_profiles_file_bin;
					Main.Snackbar.Show();
					Loading_Panel.Visibility = Visibility.Hidden;
					Options_Panel.Visibility = Visibility.Hidden;

				}
			});
		}

		public void CancelWork()
		{
			if (_cts != null)
			{
				_cts?.Cancel();
			}
		}
		public Page_Profiles()
		{


			InitializeComponent();


			//Load paths here
			if (!Directory.Exists(Main.User_Settings_Vars.NorthstarInstallLocation + "VTOL_profiles"))
			{

				Directory.CreateDirectory(Main.User_Settings_Vars.NorthstarInstallLocation + "VTOL_profiles");
			}
			SAVE_PATH__ = Main.User_Settings_Vars.NorthstarInstallLocation + "VTOL_profiles";
			Profile_Location.Text = SAVE_PATH__;
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
		public  void FadeControl(UIElement control, bool? show = null, double duration = 0.5)
		{
			DispatchIfNecessary(async () =>
			{
				// Determine the target visibility
				Visibility targetVisibility;
				if (show == true)
				{
					targetVisibility = Visibility.Visible;
				}
				else if (show == false)
				{
					targetVisibility = Visibility.Collapsed;
				}
				else
				{
					targetVisibility = control.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
				}

				// Check if the control is already at the target visibility
				if (control.Visibility == targetVisibility)
					return;

				// Create a DoubleAnimation to animate the control's opacity
				DoubleAnimation da = new DoubleAnimation
				{
					From = control.Opacity,
					To = targetVisibility == Visibility.Visible ? 1 : 0,
					Duration = new Duration(TimeSpan.FromSeconds(duration)),
					AutoReverse = false
				};

				// Start the animation
				control.BeginAnimation(OpacityProperty, da);

				// Update the control's visibility
				control.Visibility = targetVisibility;

				// Wait for the animation to finish
				await Task.Delay((int)(duration * 1000));
			});
		}

		public void Export(string path, string[] includedFolders, string[] includedFiles) {
            try { 
			Profile_Name.Text = SAVE_NAME__;
			Profile_Location.Text = SAVE_PATH__;
			string NS_Mod_Dir = Main.User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods";
			if (!Directory.Exists(NS_Mod_Dir))
			{
				return;
			}
			System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
			System.IO.DirectoryInfo[] subDirs = null;
			subDirs = rootDirs.GetDirectories();


			VERSION = Main.User_Settings_Vars.CurrentVersion;
			SAVE_NAME__ = Profile_Name.Text;
			NUMBER_MODS__ = subDirs.Length;
			SIZE = FileSizeCalculator.Pack(path, includedFolders, includedFiles);

			Options_Panel.Visibility = Visibility.Visible;
			Export_Profile_Options_Panel.Visibility = Visibility.Visible;
			NORTHSTAR_VERSION.Content = VERSION;
			NUMBER_OF_MODS.Content = NUMBER_MODS__;
			TOTAL_SIZE.Content = SIZE;
			Current_File_Tag.Content = "Processing the Directory - " + path;

			wave_progress.Visibility = Visibility.Hidden;
			Circe_progress.Visibility = Visibility.Visible;
			}

			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
		}


		private void Export_Profile_Click(object sender, RoutedEventArgs e)
		{
			Export(Main.User_Settings_Vars.NorthstarInstallLocation, Folders, Files);
		}

		private void Import_Profile_Click(object sender, RoutedEventArgs e)
		{


		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
		}

		private void Export_Profile_BTN(object sender, RoutedEventArgs e)
        {
            try {
				FadeControl(Loading_Panel, true, 2);

			Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
			Export_Profile_Options_Panel.Visibility = Visibility.Hidden;
				FadeControl(Options_Panel, true, 2.5);

				Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
			Main.Snackbar.Show("INFO", "Packing Profile now");
			Pack_Label.Content = "Packing the File/Folder";

			Pack(Main.User_Settings_Vars.NorthstarInstallLocation, Folders, Files);
		}

	catch (Exception ex)
{
   Main.logger2.Open();
    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
		Main.logger2.Close();
	}

}

		private void Import_BTN(object sender, RoutedEventArgs e)
		{
			Pack_Label.Content = "UnPacking the File/Folder";

			UnpackandCheck(CURRENT_FILE__, @"D:\Games\Titanfall2\R2Northstar\mods\open\directory.bin.gz");

		}

		private void I_Export_Mods_Checked(object sender, RoutedEventArgs e)
		{
			Skip_Mods = true;

		}

		private void I_Export_Mods_Unchecked(object sender, RoutedEventArgs e)
		{
			Skip_Mods = false;
		}

		private void Exit_BTN_Click(object sender, RoutedEventArgs e)
        {
            try { 
			CancelWork();
			Options_Panel.Visibility = Visibility.Hidden;
			Export_Profile_Options_Panel.Visibility = Visibility.Hidden;
				FadeControl(Loading_Panel, false, 2.5);
				Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
			}

			catch (Exception ex)
			{
				Main.logger2.Open();
				Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}
		}

		private void Add_Profile_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Extra_Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            try { 
			string path = null;
			if (Extra_Menu.SelectedIndex == 0)
			{

				var dialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
				dialog.Filter = "vbp files (*.vbp)|*.vbp"; // Only show .vbp files
				dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);


				var result = dialog.ShowDialog();
				if (result == true)
				{
					path = dialog.FileName;


				}
				if (File.Exists(path))
				{
					FadeControl(Options_Panel, true,2);



					UnpackRead_BIN_INFO(path);


					FadeControl(Add_Profile_Options_Panel, true, 1.5);

				}




			}
				Extra_Menu.Text = null;

			}

			catch (Exception ex)
{
   Main.logger2.Open();
    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
		Main.logger2.Close();
	}
}

		private void save_Lcoation_Btn_Click(object sender, RoutedEventArgs e)
		{

			var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
			//dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
			string path = null;

			var result = dialog.ShowDialog();
			if (result == true)
			{
				path = dialog.SelectedPath;


			}
			if (Directory.Exists(path))
			{
				SAVE_PATH__ = path;
				Profile_Location.Text = SAVE_PATH__;
				Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
				Main.Snackbar.Show("SUCCESS!", "The Path has been set to - " + path);
			}
		}

		private void Exit_BTN_ADD_Prfl_Click(object sender, RoutedEventArgs e)
		{
			CancelWork();
			Options_Panel.Visibility = Visibility.Hidden;
			Export_Profile_Options_Panel.Visibility = Visibility.Hidden;
			Loading_Panel.Visibility = Visibility.Hidden;
			Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
		}

		private void Export_Mods_Checked(object sender, RoutedEventArgs e)
		{
			Do_Not_save_Mods = true;

		}

		private void Export_Mods_Unchecked(object sender, RoutedEventArgs e)
		{
			Do_Not_save_Mods = false;

		}

		private void Profile_Name_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (Profile_Name.Text != "Default Profile")
			{

				Profile_Name.Foreground = Brushes.White;
			}
			SAVE_NAME__ = Profile_Name.Text;
		}

		private void Exit_BTN_ADD_Prfl_Click_1(object sender, RoutedEventArgs e)
        {
            try { 
			CancelWork();
			Options_Panel.Visibility = Visibility.Hidden;
			Export_Profile_Options_Panel.Visibility = Visibility.Hidden;
			Loading_Panel.Visibility = Visibility.Hidden;
			Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
		}

			catch (Exception ex)
		{
     Main.logger2.Open();
      Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
				Main.logger2.Close();
			}

		}

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
			_cts.Dispose();

		}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try { 
			DispatchIfNecessary(async () =>
			{
				LoadProfiles();
				//PopulateListBoxWithRandomPaths();
			});

		}

	catch (Exception ex)
{
   Main.logger2.Open();
    Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine + System.Reflection.MethodBase.GetCurrentMethod().Name);
		Main.logger2.Close();
	}
}

        private void Profile_List_Box_Loaded(object sender, RoutedEventArgs e)
        {
			
			
		}
    }
		}
