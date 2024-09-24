using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Page = iNKORE.UI.WPF.Modern.Controls.Page;
using iNKORE.UI.WPF.Modern.Controls;
using VTOL_C.Pages;
using iNKORE.UI.WPF.Modern.Media.Animation;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Wpf.Ui;
using Color = System.Windows.Media.Color;
using Nucs.JsonSettings;
using System.Text.Json.Serialization;

namespace VTOL_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class UTILS
    {

        public bool ValidateFileExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is empty or null.");
            }

            try
            {
                if (File.Exists(filePath))
                {
                    return true;
                }
                else
                {

                    return false;

                }
            }
            catch (Exception ex)
            {
                return false;

                // This catch block handles other IO exceptions like unauthorized access, etc.

            }
        }
    }

    public class MySettings : JsonSettings
    {
        //Step 2: override a default FileName or keep it empty. Just make sure to specify it when calling Load!
        //This is used for default saving and loading so you won't have to specify the filename/path every time.
        //Putting just a filename without folder will put it inside the executing file's directory.
        public override string FileName { get; set; } = "TheDefaultFilename.extension"; //for loading and saving.

        #region Settings
        public string Current_Version { get; set; }
        public string Theme { get; set; }
        public string Master_Server_Url { get; set; }
        public string Repo { get; set; }
        public string Language { get; set; }
        public string Repo_Url { get; set; }
        public string Profile_Path { get; set; }
        public string Northstar_Install_Location { get; set; }
        public string MasterServer_URL_CN { get; set; }
        public string Current_REPO_URL_CN { get; set; }
        public string Author { get; set; }
        public bool Auto_Close_VTOL { get; set; }
        public bool Auto_Update_Northstar { get; set; }
        #endregion

        //Step 3: Override parent's constructors
        public MySettings() { }
        public MySettings(string fileName) : base(fileName) { }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Threading.Thread.Sleep(3000);

            InitializeComponent();
           
            LoadBackgroundImageAsync();
            Load_Settings();


        }
        public Pages.Home_landing Page_Home = new Pages.Home_landing();
        public Pages.Mods_Local Page_Mods_Local = new Pages.Mods_Local();
        public Pages.Mods_Online Page_Mods_Remote = new Pages.Mods_Online();
        public Pages.Tools_Page Page_Tools = new Pages.Tools_Page();
        public Pages.Settings_Page Page_Settings = new Pages.Settings_Page();
        private const string ResourceFolderPath = "pack://application:,,,/Resources/Backgrounds/Backgrounds_Home_Page";
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg"};
        private static readonly Color FallbackColor = Colors.DarkGray;
        private static readonly Random Random = new Random();
        public ContentDialogService Dialog_Service;
        public ContentPresenter ContentPresenter { get; set; }

        //Step 4: Load
                                                                                   //or create a new empty
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public MySettings Settings; //relative path to executing file.

        public void Load_Settings()
        {
            UTILS uTILS = new UTILS();
            if (uTILS.ValidateFileExists("config.json"))
            {
                Settings = JsonSettings.Load<MySettings>("config.json"); //relative path to executing file.

            }
            else
            {
                Settings = JsonSettings.Construct<MySettings>("config.json"); ; //relative path to executing file.

            }
        }
    private async void LoadBackgroundImageAsync()
        {
            string directoryPath = "Resources/Backgrounds/Backgrounds_Home_Page";
            string[] supportedExtensions = { ".jpg", ".jpeg" };

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    SetFallbackBackground();
                    return;
                }

                var imageFiles = Directory.EnumerateFiles(directoryPath)
                    .Where(file => supportedExtensions.Contains(System.IO.Path.GetExtension(file).ToLower()))
                    .ToList();

                if (imageFiles.Count() == 0)
                {
                    SetFallbackBackground();
                    return;
                }
                Random random = new Random();
                string randomImageFile = imageFiles[random.Next(imageFiles.Count)];

                await SetImageBackgroundAsync(randomImageFile);
             
            }
            catch (Exception)
            {
                SetFallbackBackground();
            }
        }

        private async Task SetImageBackgroundAsync(string imagePath)
        {
            try
            {
                var image = new BitmapImage();

                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad; // Load image immediately to free up file lock
                    image.StreamSource = stream;
                    image.EndInit();
                }

                BackgroundImage.Source = image;
            }
            catch (Exception)
            {
                SetFallbackBackground();
            }
        }
        private void SetFallbackBackground()
        {
            fallback_border.Visibility = Visibility.Visible;
            fallback_border.Background = new SolidColorBrush(FallbackColor);
        }
        private void Nav_Main_SelectionChanged(iNKORE.UI.WPF.Modern.Controls.NavigationView sender, iNKORE.UI.WPF.Modern.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            var item = sender.SelectedItem;
            Page? page = null;
            if (item == Navitem_Home)
            {
                page = Page_Home;
            }
            else if (item == Navitem_Mods)
            {
                page = Page_Mods_Local;
            }
            else if (item == Navitem_Store)
            {
                page = Page_Mods_Remote;
            }
            else if (item == Navitem_Tools)
            {
                page = Page_Tools;
            }

            if (page != null)
            {
                Nav_Main.Header = page.Title;
                Frame_Main.Navigate(page, new DrillInNavigationTransitionInfo());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Nav_Main.SelectedItem = Navitem_Home;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}