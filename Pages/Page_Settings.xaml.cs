using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_Settings.xaml
    /// </summary>
    public partial class Page_Settings : Page
    {
        PropertyGridDemoModel Settings_;
        public MainWindow Main = GetMainWindow();
        User_Settings User_Settings_Vars = null;
        string DocumentsFolder = null;

        public enum Language
        {
            English,
            French,
            Chinese,
            Italian,
            Korean
        }
        public class PropertyGridDemoModel
        {
            [Category("General")]
            public Language Language { get; set; }
            public string Master_Server_Url { get; set; }
            public bool Do_Not_Overwrite_Config_Files { get; set; }

            [Category("Github")]
            public string Repo_Url { get; set; }
            public string Repo { get; set; }
            public string Author { get; set; }
            public bool Auto_Update_Northstar { get; set; }

            public bool Auto_Close_VTOL { get; set; }

            //[Category("Profile")]
            //public bool Boolean { get; set; }
            //[Category("Advanced")]
            //public bool Boolean_ { get; set; }
        }
        public Page_Settings()
        {
            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;
            DocumentsFolder = Main.DocumentsFolder;

            Settings_ = new PropertyGridDemoModel
            {
                Language = Language.English,
                Master_Server_Url = User_Settings_Vars.MasterServerUrl,
                Do_Not_Overwrite_Config_Files = true,

                Repo_Url = User_Settings_Vars.RepoUrl,
                Repo = User_Settings_Vars.Repo,

                Author = User_Settings_Vars.Author,
                Auto_Update_Northstar = User_Settings_Vars.Auto_Update_Northstar,
                Auto_Close_VTOL = User_Settings_Vars.Auto_Close_VTOL

        };
            Settings.SelectedObject = Settings_;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Settings_LayoutUpdated(object sender, EventArgs e)
    {
            
        }

        private void Settings_LostFocus(object sender, RoutedEventArgs e)
        {

          
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            User_Settings_Vars.MasterServerUrl = Settings_.Master_Server_Url;
            User_Settings_Vars.Auto_Update_Northstar = Settings_.Auto_Update_Northstar;
            User_Settings_Vars.Auto_Close_VTOL = Settings_.Auto_Close_VTOL;
            User_Settings_Vars.Author = Settings_.Author;
            User_Settings_Vars.Repo = Settings_.Repo;
            User_Settings_Vars.RepoUrl = Settings_.Repo_Url;
            Properties.Settings.Default.Backup_arg_Files = Settings_.Do_Not_Overwrite_Config_Files;
            Properties.Settings.Default.Save();

            string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
            using (var StreamWriter = new StreamWriter(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
            {
                StreamWriter.WriteLine(User_Settings_Json_Strings);
                StreamWriter.Close();
            }
        }
    }
}
