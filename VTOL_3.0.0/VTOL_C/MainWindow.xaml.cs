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

namespace VTOL_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            LoadBackgroundImageAsync();
     


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
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

     
    }
}