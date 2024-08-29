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
        }
        public Pages.Home_landing Page_Home = new Pages.Home_landing();
        public Pages.Modifications Page_Modifications = new Pages.Modifications();

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                page = Page_Modifications;
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