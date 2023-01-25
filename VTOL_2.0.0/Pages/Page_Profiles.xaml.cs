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
				bool Skip_Mods =false;
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
				public void UnpackRead_BIN_INFO(string path, string targetDirectory)
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


				public bool UnpackDirectory(string path, string targetDirectory)
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
								using (var stream = File.Open(appDataPath + @"\directory_open.bin", FileMode.Open))
								{
									var formatter = new BinaryFormatter();
									var data = (DirectoryData)formatter.Deserialize(stream);
									string dataAsString = data.ToString();
									foreach (string folder in data.Folders)
									{
							if (Skip_Mods == true)
							{
								if (folder.Contains(@"R2Northstar\mods"))
								{
									Console.WriteLine("\nSkipped The Mod -\n" + folder + " \nDue to a Chosen Setting.\n");

									continue;
								}
							}
										int index = folder.LastIndexOf("Titanfall2");
										string fileNameUpToWord = folder.Substring(index + "Titanfall2".Length + 1);
										string targetFolder = System.IO.Path.Combine(targetDirectory, fileNameUpToWord);
										//MessageBox.Show(fileNameUpToWord + " --> " + targetFolder + " |---S-|\n");
										Directory.CreateDirectory(targetFolder);
										System.Threading.Thread.Sleep(50); // to simulate delay

						}
						foreach (string file in data.Files)
									{
							if (Skip_Mods == true)
							{
								if (file.Contains(@"R2Northstar\mods"))
								{
									Console.WriteLine("\nSkipped The Mod -\n" + file + " \nDue to a Chosen Setting.\n");
									continue;
								}
							}
							string fileName = System.IO.Path.GetFileName(file);
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
										System.Threading.Thread.Sleep(50); // to simulate delay

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
						}
						catch (DirectoryNotFoundException ex)
						{
							Console.WriteLine("The directory could not be found: " + ex.Message);
						}
						catch (IOException ex)
						{
							Console.WriteLine("An IO error occurred: " + ex.Message);
						}
						catch (Exception ex)
						{
							Console.WriteLine("An error occurred: " + ex.Message);
						}
							return false;

				}
				public async Task<bool> TryDeleteDirectoryAsync(string directoryPath, bool overwrite = true, int maxRetries = 10,int millisecondsDelay = 30)
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
				public bool TryDeleteDirectory(string directoryPath, bool overwrite = true,	int maxRetries = 10,int millisecondsDelay = 300)
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
				public bool TryCreateDirectory(string directoryPath,int maxRetries = 10,int millisecondsDelay = 200)
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
				public bool TryMoveFile(string Origin, string Destination, bool overwrite = true,int maxRetries = 10,int millisecondsDelay = 200)
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
				public bool TryCopyFile(string Origin, string Destination, bool overwrite = true,int maxRetries = 10,int millisecondsDelay = 300)
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
					var validFilesAndFolders = new List<string>();
					int totalFiles = fileAndFolderNames.Length;
					int currentFile = 0;
					Console.Write("Checking files and folders ---> 0%");
					Console.CursorVisible = false; // to hide the cursor
					foreach (string fileOrFolderName in fileAndFolderNames)
					{
						currentFile++;
						int progress = (currentFile * 100) / totalFiles;
						Console.SetCursorPosition(23, Console.CursorTop); // to set cursor position
						Console.Write(progress + "%");
						if (File.Exists(fileOrFolderName) || Directory.Exists(fileOrFolderName))
						{
							validFilesAndFolders.Add(fileOrFolderName);
						}
						System.Threading.Thread.Sleep(50); // to simulate delay
					}
					Console.CursorVisible = true;
					Console.WriteLine("\nVerification Completed For the group and all its subfolders/files");
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
						 string NS_Mod_Dir = Main.User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods";
						System.IO.DirectoryInfo rootDirs = new DirectoryInfo(@NS_Mod_Dir);
					System.IO.DirectoryInfo[] subDirs = null;
					subDirs = rootDirs.GetDirectories();
					var data = new DirectoryData
						{
							Folders = CheckAndRemoveMissingFilesAndFolders(includedFoldersPath.Select(f => f).ToArray()),
							Files = CheckAndRemoveMissingFilesAndFolders(includedFilesPath.Select(f => f).ToArray()),
							NORTHSTAR_VERSION = Main.User_Settings_Vars.CurrentVersion,
							NAME = "PROFILE",
							MOD_COUNT = subDirs.Length,
							TOTAL_SIZE_OF_FOLDERS = FileSizeCalculator.Pack(path, includedFolders, includedFiles)

						};
						using (var stream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Create))
						{
						var formatter = new BinaryFormatter();               
						formatter.Serialize(stream, data);               
						}
			   
						//compress the bin file
						using (FileStream sourceStream = File.Open(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin", FileMode.Open))
						using (FileStream targetStream = File.Create(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz"))
						using (GZipStreamWithProgress compressionStream = new GZipStreamWithProgress(targetStream, CompressionMode.Compress))
						{            
						sourceStream.CopyTo(compressionStream);
						}
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
					Add_Profile_Options_Panel.Visibility = Visibility.Hidden;
					Console.WriteLine("Unpacking!");

					if (File.Exists(vtol_profiles_file_bin))
					{

						Console.WriteLine("Found!");

						Loading_Panel.Visibility = Visibility.Visible;

						// Display a message to the user indicating that the operation has started
						DispatchIfNecessary(async () =>
						{
						// Perform the long-running operation on a background thread
						var result = await Task.Run(() =>
							{
								return UnpackDirectory(vtol_profiles_file_bin, Target_Dir);

							});
							if(result == true)
							{
								Console.WriteLine(result);
								Console.WriteLine("Complete!");
								Loading_Panel.Visibility = Visibility.Hidden;


							}
							else
							{
								Console.WriteLine(result);
								Console.WriteLine("Failed!");

							}
							Loading_Panel.Visibility = Visibility.Hidden;
							Options_Panel.Visibility = Visibility.Hidden;

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
					Options_Panel.Visibility = Visibility.Visible;
					Export_Profile_Options_Panel.Visibility = Visibility.Visible;
		   

				}

				private void Import_Profile_Click(object sender, RoutedEventArgs e)
				{
					Options_Panel.Visibility = Visibility.Visible;

					UnpackRead_BIN_INFO(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz", @"D:\Games\Titanfall2\R2Northstar\mods\open\directory.bin.gz");

		   
					Add_Profile_Options_Panel.Visibility = Visibility.Visible;

				}

				private void Button_Click(object sender, RoutedEventArgs e)
				{
			
				}

				private void Button_Click_1(object sender, RoutedEventArgs e)
				{
				}

				private void Export_Profile_BTN(object sender, RoutedEventArgs e)
				{
					Pack(@"D:\Games\Titanfall2", new string[] { "R2Northstar", "plugins", "bin" }, new string[] { "Northstar.dll", "NorthstarLauncher.exe", "r2ds.bat", "discord_game_sdk.dll" });
					Options_Panel.Visibility = Visibility.Hidden;
					Loading_Panel.Visibility = Visibility.Hidden;

				}

				private void Import_BTN(object sender, RoutedEventArgs e)
				{
					UnpackandCheck(@"D:\Games\Titanfall2\R2Northstar\mods\directory.bin.gz", @"D:\Games\Titanfall2\R2Northstar\mods\open\directory.bin.gz");
		   
				}

        private void I_Export_Mods_Checked(object sender, RoutedEventArgs e)
        {
			Skip_Mods = true;

		}

		private void I_Export_Mods_Unchecked(object sender, RoutedEventArgs e)
        {
			Skip_Mods= false;
        }
    }
		}
