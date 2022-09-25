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
using System.Threading;
using System.Globalization;
using System.Reflection;

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
            Korean,
            German,
            Russian
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

            public bool Minimize_On_Launch { get; set; }

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
            Language Lang = Language.English;
            if (User_Settings_Vars.Language != null)
            {
                switch (User_Settings_Vars.Language)
                {
                    case "en":
                        Lang = Language.English;

                        break;
                    case "fr":
                        Lang = Language.French;

                        break;
                    case "zh":
                        Lang = Language.Chinese;

                        break;
                    case "it":
                        Lang = Language.Italian;

                        break;
                    case "ko":
                        Lang = Language.Korean;

                        break;
                    case "de":
                        Lang = Language.German;

                        break;
                    case "ru":
                        Lang = Language.Russian;
                        break;
                    default:
                        Lang = Language.English;

                        break;


                }
            }
            Settings_ = new PropertyGridDemoModel
            {
                Language = Lang,
                Master_Server_Url = User_Settings_Vars.MasterServerUrl,
                Do_Not_Overwrite_Config_Files = Properties.Settings.Default.Backup_arg_Files,
                Minimize_On_Launch = Properties.Settings.Default.Auto_Close_VTOL_on_Launch,

                Repo_Url = User_Settings_Vars.RepoUrl,
                Repo = User_Settings_Vars.Repo,

                Author = User_Settings_Vars.Author,
                Auto_Update_Northstar = User_Settings_Vars.Auto_Update_Northstar,

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
            try { 
            User_Settings_Vars.MasterServerUrl = Settings_.Master_Server_Url;
            Properties.Settings.Default.Auto_Close_VTOL_on_Launch = Settings_.Minimize_On_Launch;
            Properties.Settings.Default.Save();
            switch (Settings_.Language.ToString())
            {
                case "English":
                    User_Settings_Vars.Language = "en";

                    break;
                case "French":
                    User_Settings_Vars.Language = "fr";

                    break;
                case "Chinese":
                    User_Settings_Vars.Language = "zh";

                    break;
                case "Italian":
                    User_Settings_Vars.Language = "it";

                    break;
                case "Korean":
                    User_Settings_Vars.Language = "ko";

                    break;
                        case "German":
                    User_Settings_Vars.Language = "de";

                        break;
                    case "Russian":
                        User_Settings_Vars.Language = "ru";

                        break;
                    default:
                    User_Settings_Vars.Language = "en";

                    break;


            }




            User_Settings_Vars.Auto_Close_VTOL = Settings_.Minimize_On_Launch;
            User_Settings_Vars.Author = Settings_.Author;
            User_Settings_Vars.Repo = Settings_.Repo;
            User_Settings_Vars.RepoUrl = Settings_.Repo_Url;
            User_Settings_Vars.Auto_Update_Northstar = Settings_.Auto_Update_Northstar;
            Properties.Settings.Default.Backup_arg_Files = Settings_.Do_Not_Overwrite_Config_Files;
            Properties.Settings.Default.Save();
            string User_Settings_Json_Strings = Newtonsoft.Json.JsonConvert.SerializeObject(User_Settings_Vars);
            using (var StreamWriter = new StreamWriter(DocumentsFolder + @"\VTOL_DATA\Settings\User_Settings.Json", false))
            {
                StreamWriter.WriteLine(User_Settings_Json_Strings);
                StreamWriter.Close();
            }
        }
             catch (Exception ex)
            {
                Main.logger2.Open();
                Main.logger2.Log($"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine + ex.Source +Environment.NewLine + ex.InnerException + Environment.NewLine + ex.TargetSite + Environment.NewLine + "From VERSION - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine);
Main.logger2.Close();



            }
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
           
        }
    }
}
