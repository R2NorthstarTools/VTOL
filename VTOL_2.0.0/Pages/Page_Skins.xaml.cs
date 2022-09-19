using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
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
using Threading;
using Hangfire;
using Serilog;
using System.Globalization;
using Path = System.IO.Path;
using Microsoft.Win32;
using ZipFile = Ionic.Zip.ZipFile;
using Ionic.Zip;
using System.Diagnostics;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Skins.xaml
    /// </summary>
    /// 
    public partial class Page_Skins : Page
    {
        private MainWindow Main = GetMainWindow();
        private List<string> Skin_List = new List<string>();
        private Wpf.Ui.Controls.Snackbar SnackBar;
        private List<string> names = new List<string>();
        User_Settings User_Settings_Vars = null;

        public Page_Skins()
        {
            SnackBar = Main.Snackbar;

            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;

        }

        public static bool ZipHasFile(string Search, string zipFullPath)
        {
            ZipFile zipFile = new ZipFile(zipFullPath);

           
                foreach (var entry in zipFile.Entries)
                {
                    if (entry.FileName.Contains(Search, StringComparison.OrdinalIgnoreCase))
                    {

                        return true;
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
        string current_skin_folder = null;

        public async Task Install_Skin_From_Path(string Zip_Path)
        {

            try
            {
                await Task.Run(() =>
                {

                    if (ZipHasFile(".dds", Zip_Path))
                {


                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"Skins_Unpack_Mod_MNGR"))
                    {

                        current_skin_folder = User_Settings_Vars.NorthstarInstallLocation+ @"Skins_Unpack_Mod_MNGR";
                            ZipFile zipFile = new ZipFile(Zip_Path);

                            zipFile.ExtractAll(User_Settings_Vars.NorthstarInstallLocation+ @"Skins_Unpack_Mod_MNGR", Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                            //Skin_Path = Current_Install_Folder + @"\Skins_Unpack_Mod_MNGR";

                        }
                    else
                    {

                        Directory.CreateDirectory(User_Settings_Vars.NorthstarInstallLocation+ @"Skins_Unpack_Mod_MNGR");
                        current_skin_folder = User_Settings_Vars.NorthstarInstallLocation+ @"Skins_Unpack_Mod_MNGR";

                            ZipFile zipFile = new ZipFile(Zip_Path);

                            zipFile.ExtractAll(User_Settings_Vars.NorthstarInstallLocation+ @"Skins_Unpack_Mod_MNGR", Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

                        }
                }
                else
                {
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SKIN_INCOMPATIBLE"));
                    Log.Error("Issue With Skin Install!");


                }




                //Block Taken From Skin Tool
                List<string> FileList = new List<string>();
                if (current_skin_folder != null)
                {
                    FindSkinFiles(current_skin_folder, FileList, ".dds");

                }
                else
                    {
                        Log.Error("Issue With Skin Install!");

                        return;
                }



                var matchingvalues = FileList.FirstOrDefault(stringToCheck => stringToCheck.Contains(""));
                for (int i = 0; i < FileList.Count; i++)
                {
                    if (FileList[i].Contains("col")) // (you use the word "contains". either equals or indexof might be appropriate)
                    {

                        //Console.WriteLine(i);
                    }
                }
                int DDSFolderExist = 0;

                DDSFolderExist = FileList.Count;
                if (DDSFolderExist == 0)
                {
                    Log.Error("Could Not Find Skins in Zip??");
                }

                foreach (var i in FileList)
                {
                    int FolderLength = current_skin_folder.Length;
                    String FileString = i.Substring(FolderLength);
                    int imagecheck = ImageCheck(i);
                    //the following code is waiting for the custom model
                    Int64 toseek = 0;
                    int tolength = 0;
                    int totype = 0;
                    switch (GetTextureType(i))
                    {
                        case 1://Weapon
                               //Need to recode weapon part

                            VTOL.Titanfall2_Requisite.WeaponData.WeaponDataControl wdc = new VTOL.Titanfall2_Requisite.WeaponData.WeaponDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(wdc.FilePath[0, 1]);
                            tolength = Convert.ToInt32(wdc.FilePath[0, 2]);
                            totype = Convert.ToInt32(wdc.FilePath[0, 3]);


                            break;
                        case 2://Pilot
                            VTOL.Titanfall2_Requisite.PilotDataControl.PilotDataControl pdc = new VTOL.Titanfall2_Requisite.PilotDataControl.PilotDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(pdc.Seek);
                            tolength = Convert.ToInt32(pdc.Length);
                            totype = Convert.ToInt32(pdc.SeekLength);
                            break;
                        case 3://Titan
                            VTOL.Titanfall2_Requisite.TitanDataControl.TitanDataControl tdc = new VTOL.Titanfall2_Requisite.TitanDataControl.TitanDataControl(i, imagecheck);
                            toseek = Convert.ToInt64(tdc.Seek);
                            tolength = Convert.ToInt32(tdc.Length);
                            totype = Convert.ToInt32(tdc.SeekLength);
                            break;

                        default:
                            Log.Error("Issue With Skin Install!");

                            break;
                    }


                    StarpakControl sc = new StarpakControl(i, toseek, tolength, totype, User_Settings_Vars.NorthstarInstallLocation, "Titanfall2", imagecheck, "Replace");


                }

                FileList.Clear();
                DirectoryInfo di = new DirectoryInfo(current_skin_folder);
                FileInfo[] files = di.GetFiles();

                DispatchIfNecessary(async () =>
                {
                    Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Success;
                    Main.Snackbar.Show("SUCCESS!", VTOL.Resources.Languages.Language.Page_Skins_Install_Skin_From_Path_TheSkin + Path.GetFileNameWithoutExtension(Zip_Path) + VTOL.Resources.Languages.Language.Page_Skins_Install_Skin_From_Path_HasBeenInstalled);
                });

                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir_ in di.GetDirectories())
                {
                    dir_.Delete(true);
                }
                Directory.Delete(current_skin_folder);

                    Task.Delay(500).Wait();


                });


            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }

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
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }




        private static int GetTextureType(string Name)
        {
            if (Name != null && Name.Length == 0)
            {
                return 0;
            }
            if (Name.Contains("Stim_") || Name.Contains("PhaseShift_") || Name.Contains("HoloPilot_")
            || Name.Contains("PulseBlade_") || Name.Contains("Grapple_") || Name.Contains("AWall_")
            || Name.Contains("Cloak_") || Name.Contains("Pilot_"))
            {
                return 2;
            }
            else if (Name.Contains("Titan_"))
            {
                return 3;
            }
            else
            {
                return 1;
            }

        }





























        private static MainWindow GetMainWindow()
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

        private void Drag_Drop_Area_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (file.Contains(".zip"))
                    {
                        if (ZipHasFile(".dds", file))
                        {

                            Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#660E6F18");
                            Skin_List.Add(file);
                            names.Add(Path.GetFileNameWithoutExtension(file));
                        }
                        else
                        {
                            Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                            Main.Snackbar.Show("ERROR", "File " + Path.GetFileName(file) + VTOL.Resources.Languages.Language.Page_Skins_Drag_Drop_Area_Drop_IsNotASkinZip);
                            Install_Queue_Label.Content = VTOL.Resources.Languages.Language.Page_Skins_Drag_Drop_Area_Drop_DragToInstall;
                            Skin_Path.Text = "Path";

                            Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
                            Skin_List.Clear();
                            names.Clear();

                            continue;

                        }

                    }
                    else
                    {
                        Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                        Main.Snackbar.Show("ERROR", "File is Not a Zip!");
                        Install_Queue_Label.Content = "Drag to Install";
                        Skin_Path.Text = "Path";

                        Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
                        Skin_List.Clear();
                        names.Clear();

                        continue;
                    }
                }
                if (Skin_List.Count() > 0)
                {
                    Skin_Path.Text = String.Join(" | ", Skin_List);

                    Install_Queue_Label.Content = String.Join(" | ", names);
                    Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    Main.Snackbar.Show("INFO", VTOL.Resources.Languages.Language.Page_Skins_Drag_Drop_Area_Drop_CompatibleSkinSFound + String.Join(" | ", names));
                }
               
            }
            if (Skin_List.Count() > 0)
            {
                clear_queue.Visibility = Visibility.Visible;
            }
            else
            {
                clear_queue.Visibility = Visibility.Hidden;

            }
            //HandleFile(file);

        }

        private void Drag_Drop_Area_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
            Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66A5B512");

        }

        private void Drag_Drop_Area_PreviewDragLeave(object sender, DragEventArgs e)
        {
            Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");

        }

        private void Grid_PreviewDragOver(object sender, DragEventArgs e)
        {

        }
        private void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        private async Task Stall_Queue()
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                int x = 100;
                int Add_Fac = x / Skin_List.Count;
                foreach (var i in Skin_List)
                {
                    await Install_Skin_From_Path(i);
                    DispatchIfNecessary(async () =>
                    {
                        Skin_Install_Progress.Value = Skin_Install_Progress.Value + Add_Fac;

                    });
                    await Task.Delay(1500);
                   

                }
                names.Clear();
                Skin_List.Clear();
                DispatchIfNecessary( () =>
                {
                    Install_Queue_Label.Content = "Drag to Install";
                    Skin_Path.Text = "Path";

                    Skin_Install_Progress.Value = 0;
                   

                        clear_queue.Visibility = Visibility.Hidden;

                    
                });
            });
        }
 
          
        private void Install_Skin_Click(object sender, RoutedEventArgs e)
        {
            Skin_Install_Progress.Value = 0;
            Stall_Queue();


            DispatchIfNecessary(async () =>
            {
                Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
                Skin_Install_Progress.Value = 0;
                Install_Queue_Label.Content = "Drag to Install";
                Skin_Path.Text = "Path";
                
            });


        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName.Contains(".zip") )
                {

                    if (ZipHasFile(".dds", openFileDialog.FileName))
                    {
                        Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;

                        Main.Snackbar.Show("INFO",VTOL.Resources.Languages.Language.Page_Skins_Browse_Click_CompatibleSkinFoundAt + openFileDialog.FileName);

                        Skin_List.Add(openFileDialog.FileName);
                        Skin_Path.Text = openFileDialog.FileName;

                        Install_Queue_Label.Content = openFileDialog.FileName;
                    }
                    else
                    {
                        Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                        Main.Snackbar.Show("ERROR", "File "+ Path.GetFileName(openFileDialog.FileName) + VTOL.Resources.Languages.Language.Page_Skins_Browse_Click_IsNotASkinZip);
                        Install_Queue_Label.Content = VTOL.Resources.Languages.Language.Page_Skins_Drag_Drop_Area_Drop_DragToInstall;
                        Skin_Path.Text = "Path";

                        Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
                        Skin_List.Clear();
                        names.Clear();

                    }
                }
            }
            else
            {
                //Main.Snackbar.Appearance = Wpf.Ui.Common.ControlAppearance.Caution;
                //Main.Snackbar.Show("ERROR", "File " + Path.GetFileName(openFileDialog.FileName) + " Not a Zip!");
                Install_Queue_Label.Content = "Drag to Install";
                Skin_Path.Text = "Path";

                Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
                Skin_List.Clear();
                names.Clear();

                return;
            }
        }

        
        async Task OPEN_WEBPAGE(string URL)
        {
            await Task.Run(() =>
            {
                DispatchIfNecessary(() => {
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Skins_OPEN_WEBPAGE_OpeningTheFollowingURL + URL;
                    SnackBar.Title = "INFO";
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                    SnackBar.Show();
                });

                Thread.Sleep(1000);
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = URL,
                    UseShellExecute = true
                });
            });
        }
        

        private void Making_Your_Own_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://titanfall-skin-group.gitbook.io/titanfall-2-skin-creation/");

        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://r2northstar.gitbook.io/r2northstar-wiki/faq");

        }

        private void clear_queue_Click(object sender, RoutedEventArgs e)
        {
            Drag_Drop_Area.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#66000000");
            Install_Queue_Label.Content = "Drag to Install";
            Skin_Path.Text = "Path";
            Skin_List.Clear();
            names.Clear();

            Skin_Install_Progress.Value = 0;
            clear_queue.Visibility = Visibility.Hidden;
            SnackBar.Hide();
        }
    }
}
