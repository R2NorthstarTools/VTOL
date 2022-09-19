using Microsoft.Win32;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using static VTOL.Pages.Server_Template_Selector;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using TextBox = System.Windows.Controls.TextBox;

namespace VTOL.Pages
{
    public class Server_Template_Selector : DataTemplateSelector
    {
        public class Arg_Set
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Default { get; set; }
            public string Tag { get; set; }
            public string regex { get; set; }
            public string ARG { get; set; }

            public string Description { get; set; }
            public string[] List { get; set; }

        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            var Item = item as Arg_Set;
            if (Item == null) { return null; }

            if (Item.Type == "PORT" || Item.Type == "STRING" || Item.Type == "STRINGQ")
                return
                    element.FindResource("NormalBox")
                    as DataTemplate;
            else if (Item.Type == "INT")
                return
                    element.FindResource("IntBox")
                    as DataTemplate;
            else if (Item.Type == "FLOAT")
                return
                    element.FindResource("FloatBox")
                    as DataTemplate;
            else if (Item.Type == "BOOL")
                return
                    element.FindResource("BOOLBox")
                    as DataTemplate;
            else if (Item.Type == "ONE_SELECT")
                return
                    element.FindResource("One_Select_Combo")
                    as DataTemplate;
            else
                return
                    element.FindResource("ComboBox")
                    as DataTemplate;


        }





    }

    /// <summary>
    /// Interaction logic for Page_Server.xaml
    /// </summary>
    public partial class Page_Server : Page
    {
        private List<string> Game_Modes_List = new List<string>();
        private List<string> Game_MAP_List = new List<string>();
        private List<string> Game_WEAPON_List = new List<string>();
        private Server_Setup Server_Json;
        private MainWindow Main = GetMainWindow();
        private User_Settings User_Settings_Vars = null;
        private string Ns_dedi_File = "";
        private string Convar_File = "";
        private string NS_Startup = "";
        private string Auto_exec = "";
        private bool Started_Selection = false;
        private string _filePath;
         public bool init_ = false;
        Snackbar SnackBar;
        public Page_Server()
        {
            InitializeComponent();
            User_Settings_Vars = Main.User_Settings_Vars;
            SnackBar = Main.Snackbar;
        }
        bool Verify_List(List<string> Good_Words, string Input)
        {
            return Good_Words.Contains(Input);

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
        private ArrayList Load_Args()
        {

            ArrayList Arg_List = new ArrayList();

            using (StreamReader r = new StreamReader(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).FullName + "/Resources/Resource_Static/Northstar_Server_Vals_Aug_2022.json"))
            {
                string json = r.ReadToEnd();
                // Send_Success_Notif(json);
                Server_Json = Server_Setup.FromJson(json);
            }

            foreach (var items in Server_Json.Startup_Arguments)
            {
                if (items.Type == "GAME_MODE")
                {
                    foreach (var item in items.List)
                    {

                        Game_Modes_List.Add(item);
                    }

                }

                Arg_List.Add(new Arg_Set
                {
                    Name = items.Name.Trim().ToUpper().Replace("_"," "),
                    Type = items.Type,
                    Default = items.Default,
                    Description = items.Description_Tooltip,
                    List = items.List,
                    Tag = items.Type + "|" + items.Name + "|" + items.ARG,



                });
                DataContext = this;

            }


            return Arg_List;

        }
        public async Task saveAsyncFile(string Text, string Filename, bool ForceTxt = true, bool append = true)
        {
            if (ForceTxt == true)
            {
                if (!Filename.Contains(".txt"))
                {
                    Filename = Filename + ".txt";

                }
            }
            if (append == true)
            {
                if (File.Exists(Filename))
                {

                    using StreamWriter file = new(Filename, append: true);
                    await file.WriteLineAsync(Text);
                    file.Close();
                }
                else
                {

                    await File.WriteAllTextAsync(Filename, string.Empty);

                    await File.WriteAllTextAsync(Filename, Text);

                }
            }
            else
            {
                await File.WriteAllTextAsync(Filename, string.Empty);

                await File.WriteAllTextAsync(Filename, Text);

            }
        }

        private void OnKeyDownHandler_Dedi_Arg(object sender, KeyEventArgs e)
        {
           
        }

        private void OnKeyDownHandler_Nrml_Arg(object sender, KeyEventArgs e)
        {
           
        }
        private void Validate_Combo_Box(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Started_Selection == true)
                {

                    if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
                    {
                        HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                        var Var = ((HandyControl.Controls.CheckComboBox)sender).Tag.ToString();
                        var Description = ((HandyControl.Controls.CheckComboBox)sender).ToolTip.ToString();

                        string[] Split = Var.Split("|");
                        string type = Split[0];
                        string name = Split[1];
                        string ARG = Split[2];
                        if (ARG != null && ARG != "" && ARG == "CONVAR")
                        {



                            string list = String.Join(",", comboBox.SelectedItems.Cast<String>().ToArray());
                            Write_convar_To_File(name, list, Description, true, Convar_File);
                            if (list == "" || list == null)
                            {

                                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_NO_SELECTION"));
                                Write_convar_To_File(name, "REMOVE", Description, true, Convar_File);

                            }
                            comboBox.Foreground = Brushes.White;


                        }

                        else if (ARG != null && ARG != "" && ARG == "STARTUP")

                        {
                            string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());

                            Write_Startup_Arg_To_File(name, list, false, true, Ns_dedi_File);
                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            SnackBar.Appearance = ControlAppearance.Danger;
                            SnackBar.Title = "ERROR";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Validate_Combo_Box_CannotReadInput;
                            SnackBar.Show();
                        }
                    }
                    else
                    {

                        if (sender.GetType() == typeof(ComboBox))
                        {
                            ComboBox comboBox = (ComboBox)sender;
                            var Var = comboBox.Tag.ToString();
                            var Description = ((ComboBox)sender).ToolTip.ToString();

                            string[] Split = Var.Split("|");
                            string type = Split[0];
                            string name = Split[1];
                            string ARG = Split[2];
                            if (ARG == "CONVAR")
                            {

                                if (type == "BOOL")
                                {
                                    if (comboBox.SelectedIndex != -1)
                                    {
                                        if (comboBox.SelectedIndex == 1)
                                        {
                                            Write_convar_To_File(name, "1", Description, false, Convar_File);
                                            comboBox.Foreground = Brushes.White;


                                        }
                                        else
                                        {


                                            Write_convar_To_File(name, "0", Description, false, Convar_File);
                                            comboBox.Foreground = Brushes.White;

                                        }
                                    }

                                }
                                if (type == "ONE_SELECT")
                                {
                                    if (comboBox.SelectedIndex != -1)
                                    {

                                        Write_convar_To_File(name, comboBox.SelectedValue.ToString(), Description, false, Convar_File);
                                        comboBox.Foreground = Brushes.White;
                                    }


                                }



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR";
                SnackBar.Message = "ex";
                SnackBar.Show();
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }

        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                var Var = ((TextBox)sender).Tag.ToString();
                string[] Split = Var.Split("|");
                string type = Split[0];
                Regex regex = new Regex("[^0-9]+");

                switch (type)
                {

                    case "STRING":
                        // Send_Success_Notif("Found type String!");
                        break;
                    case "PORT":
                        e.Handled = regex.IsMatch(e.Text);


                        break;
                    case "INT":
                        e.Handled = regex.IsMatch(e.Text);
                        break;
                    case "FLOAT":
                        Regex Floaty = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$ or ^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$");
                        e.Handled = Floaty.IsMatch(e.Text);
                        break;
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }
        public bool IsPort(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return false;

                Regex numeric = new Regex(@"^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (numeric.IsMatch(value))
                {
                    try
                    {
                        if (Convert.ToInt32(value) < 65535)
                            return true;
                    }
                    catch (OverflowException)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
            return false;

        }
        void validate(object sender, RoutedEventArgs e)
        {





        }
        public IEnumerable<string> GetFile(string directory, string Search)
        {
            List<string> files = new List<string>();

            try
            {
                if (Directory.Exists(directory))
                {
                    files.AddRange(Directory.GetFiles(directory, Search, SearchOption.AllDirectories));
                    if (files.Count >= 1)
                    {
                        return files;

                    }
                    else
                    {
                        return null;
                    }
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }
            return null;

        }
        void Write_convar_To_File(string Convar_Name, string Convar_Value, string Description, bool add_quotation = false, string File_Root = null)
        {
            try
            {

                // string val = Convar_Name.Trim(new Char[] { '-', '+' });


                Convar_Value = Convar_Value.Trim();
                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder = File_Root;
                    }
                    else
                    {
                        //Send_Warning_Notif(GetTextResource("NOTIF_WARN_CANNOT_SET_PATH"));
                        RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();

                    }
                }
                else
                {


                    RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);

                string[] intermid = intake;



                if (Array.Exists(intermid, element => element.StartsWith(Convar_Name)))
                {


                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(Convar_Name));
                    if (add_quotation == true)
                    {
                        var desc = intermid[index_of_var];
                        desc = desc.Substring(desc.LastIndexOf('/') + 1);
                        if (desc != null && desc != "")
                        {
                            intermid[index_of_var] = Convar_Name + " " + '\u0022' + Convar_Value + '\u0022' + " " + "//" + desc;


                        }
                        else
                        {

                            intermid[index_of_var] = Convar_Name + " " + '\u0022' + Convar_Value + '\u0022' + " " + "//" + desc;

                        }

                    }
                    else
                    {

                        var desc = intermid[index_of_var];
                        desc = desc.Substring(desc.LastIndexOf('/') + 1);
                        intermid[index_of_var] = Convar_Name + " " + Convar_Value + " " + "//" + desc;
                        if (desc != null && desc != "")
                        {
                            intermid[index_of_var] = Convar_Name + " " + Convar_Value + " " + "//" + desc;


                        }
                        else
                        {

                            intermid[index_of_var] = Convar_Name + " " + Convar_Value + " " + "//" + Description;

                        }
                    }
                    if (Convar_Value == "REMOVE")
                    {
                        intermid = intermid.Where((source, index) => index != index_of_var).ToArray();

                    }


                    String x = String.Join("\r\n", intermid.ToArray());
                    //Send_Warning_Notif(x);
                    // x = x.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
                    //ClearFile(Convar_File);
                    using (StreamWriter sw = new StreamWriter(Convar_File, false, Encoding.UTF8, 65536))
                    {

                        sw.WriteLine(x);
                    }
                    //Send_Success_Notif(GetTextResource("NOTIF_SUCCESS_GROUP_CVAR_THE_VARIABLE") + Convar_Name + GetTextResource("NOTIF_SUCCESS_GROUP_CVAR_HAS_BEEN_FOUND_VALUE") + Convar_Value + "]");


                }
                else
                {


                    string[] intake_ = File.ReadAllLines(Convar_File);

                    string[] intermid_ = intake_;

                    intermid_ = AddElementToArray(intermid_, Convar_Name + " " + Convar_Value + " " + "//" + Description);

                    String x = String.Join("\r\n", intermid_.ToArray());

                    using (StreamWriter sw = new StreamWriter(Convar_File, false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(x);
                    }
                    //Send_Success_Notif(GetTextResource("NOTIF_SUCCESS_GROUP_CVAR_THE_VARIABLE") + Convar_Name + GetTextResource("NOTIF_SUCCESS_GROUP_CVAR_NOT_FOUND_VALUE") + Convar_Value + "]");

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
        }
        private T[] AddElementToArray<T>(T[] array, T element)
        {

            T[] newArray = new T[array.Length + 1];
            int i;
            for (i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[i] = element;
            return newArray;
        }
        private void ClearFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path);

            StreamWriter tw = new StreamWriter(path, false);
            tw.Flush();

            tw.Close();
        }
        string Read_Convar_args(string Convar_Name, string File_Root = null)
        {
            try
            {

                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder = File_Root;
                    }
                    else
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message =VTOL.Resources.Languages.Language.Page_Server_Read_Convar_args_CannotSetThePath;
                        SnackBar.Show();
                        //Send_Warning_Notif(GetTextResource("NOTIF_WARN_CANNOT_SET_PATH"));

                    }

                }
                else
                {


                    RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);


                for (int i = 0; i < intake.Length; i++)
                {
                    //Console.WriteLine(String.Format(" array[{0}] = {1}", i, intake[i]));
                }
                //Console.WriteLine("\n\n\n");
                //   Send_Warning_Notif(intake[Array.FindIndex(intake, element => element.Contains(Convar_Name))].ToString());

                if (Array.Exists(intake, element => element.StartsWith(Convar_Name)))
                {


                    int index_of_var = Array.FindIndex(intake, element => element.StartsWith(Convar_Name));

                    return intake[index_of_var].ToString();


                }
                else
                {
                    //  Send_Error_Notif("CONVAR NOT FOUND-"+ Convar_Name);

                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
            return null;
        }
        string Read_Startup_args(string Convar_Name, string File_Root = null)
        {
            try
            {
                var pattern = @"(?=[+-])";

                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder = File_Root;
                    }
                    else
                    {
                        RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();

                    }
                }
                else
                {


                    RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();
                }
                string[] intake = File.ReadAllLines(Ns_dedi_File);

                string[] intermid = null;

                foreach (string line in intake)
                {
                    intermid = Regex.Split(line.Trim(' '), pattern);

                }

                if (Array.Exists(intermid, element => element.StartsWith(Convar_Name)))
                {


                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(Convar_Name));
                    return intermid[index_of_var].ToString();


                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }
            return null;
        }

        void Write_Startup_Arg_To_File(string var_Name, string var_Value, bool add_quotation = false, bool Kill_If_empty = false, string File_Root = null)
        {

            try
            {

                string val = var_Name.Trim(new Char[] { '-', '+' });
                var pattern = @"(?=[+-])";
                var_Value = var_Value.Trim();
                string RootFolder = "";
                if (File_Root != null)
                {
                    if (File.Exists(File_Root))
                    {
                        RootFolder = File_Root;
                    }
                    else
                    {
                        //Send_Warning_Notif(GetTextResource("NOTIF_WARN_CANNOT_SET_PATH"));
                        RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();

                    }
                }
                else
                {


                    RootFolder = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();
                }
                string[] intake = File.ReadAllLines(RootFolder);

                string[] intermid = null;

                foreach (string line in intake)
                {
                    intermid = Regex.Split(line.Trim(' '), pattern);


                }
                for (int j = 0; j < intermid.Length; j++)
                {
                    // //Console.WriteLine("array[{0}] = {1}", j, intermid[j]);

                }
                if (Array.Exists(intermid, element => element.StartsWith(var_Name)))
                {


                    int index_of_var = Array.FindIndex(intermid, element => element.StartsWith(var_Name));
                    if (add_quotation == true)
                    {
                        intermid[index_of_var] = var_Name + " " + '\u0022' + var_Value + '\u0022';


                    }
                    else
                    {
                        intermid[index_of_var] = var_Name + " " + var_Value;

                    }

                    if (Kill_If_empty == true)
                    {
                        if (var_Value == "" || var_Value == null)
                        {
                            intermid = intermid.Where((source, index) => index != index_of_var).ToArray();
                        }

                    }

                    String x = String.Join(" ", intermid.ToArray());
                    //  ClearFile(RootFolder +@"\" + "ns_startup_args_dedi.txt");

                    using (StreamWriter sw = new StreamWriter(RootFolder, false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(Regex.Replace(x, @"\s+", " ").Replace("+ ", "+"));
                    }
                    //Send_Success_Notif(GetTextResource("NOTIF_SUCCESS_GROUP_VAR_THE_VARIABLE") + var_Name + GetTextResource("NOTIF_SUCCESS_GROUP_VAR_HAS_BEEN_FOUND_VALUE") + var_Value);


                }
                else
                {

                    string[] intake_ = File.ReadAllLines(Ns_dedi_File);

                    string[] intermid_ = null;
                    foreach (string line in intake_)
                    {
                        //  intermid_ = line.Split('+');
                        intermid_ = Regex.Split(line, pattern);

                    }

                    intermid_ = AddElementToArray(intermid_, var_Name + " " + var_Value);


                    String x = String.Join(" ", intermid_.ToArray());
                    //x.Replace(System.Environment.NewLine, "replacement text");
                    //  File.WriteAllText(RootFolder, String.Empty);
                    // ClearFile(RootFolder +@"\" + "ns_startup_args_dedi.txt");
                    using (StreamWriter sw = new StreamWriter(RootFolder, false, Encoding.UTF8, 65536))
                    {
                        sw.WriteLine(Regex.Replace(x, @"\s+", " "));
                    }
                    // File.WriteAllText(GetFile(RootFolder, "ns_startup_args_dedi.txt").First(), x);
                    //Send_Warning_Notif(GetTextResource("NOTIF_WARN_GROUP_VAR_NOT_FOUND_INFILE") + var_Name + GetTextResource("NOTIF_WARN_GROUP_VAR_SAVED_VALUE") + var_Value + "]");

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }

        }

        int cntr = 0;
        void Clear_Box(object sender, KeyEventArgs e)
        {
            cntr++;



            TextBox Text_Box = (TextBox)sender;
            if (cntr < 2)
            {
                string Reg2;
                Reg2 = Text_Box.Text;
                if (Text_Box.Text == Reg2)
                {
                    Text_Box.Text = "";


                }

            }

        }
        void Save_On_Focus_(object sender, KeyEventArgs e)
        {

            try
            {
                if (sender.GetType() == typeof(TextBox))
                {





                    var val = ((TextBox)sender).Text.ToString();
                    var Tag = ((TextBox)sender).Tag.ToString();
                    var Description = ((TextBox)sender).ToolTip.ToString();

                    TextBox Text_Box = (TextBox)sender;
                    string[] Split = Tag.Split("|");
                    string type = Split[0];
                    string name = Split[1];
                    string ARG = Split[2];


                    if (val != null)
                    {

                        switch (type)
                        {

                            case "STRING":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG != null && ARG != "" && ARG == "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, true, Convar_File);

                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);

                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;


                                    }



                                }
                                break;
                            case "STRINGQ":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG != null && ARG != "" && ARG == "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, true, Convar_File);
                                        Text_Box.Foreground = Brushes.White;



                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;



                                    }



                                }
                                break;
                            case "INT":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG != null && ARG != "" && ARG == "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, false, Convar_File);
                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                        Text_Box.Foreground = Brushes.White;



                                    }



                                }
                                break;
                            case "FLOAT":
                                if (e.Key == Key.Return)
                                {
                                    if (ARG != null && ARG != "" && ARG == "CONVAR")
                                    {
                                        Write_convar_To_File(name, val, Description, false, Convar_File);
                                        Text_Box.Foreground = Brushes.White;

                                    }
                                    else
                                    {
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                        Write_Startup_Arg_To_File(name, val, true, true, Ns_dedi_File);
                                        Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                                        Text_Box.Foreground = Brushes.White;


                                    }



                                }
                                break;
                            case "PORT":
                                if (ARG != null && ARG != "" && ARG == "CONVAR")
                                {
                                    if (val.Count() > 5)
                                    {
                                        //Send_Warning_Notif(GetTextResource("NOTIF_WARN_PORT_TOO_lONG"));
                                        Text_Box.Background = Brushes.Red;
                                    }
                                    else
                                    {
                                        Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");

                                        if (e.Key == Key.Return)
                                        {

                                            if (IsPort(val) == true && val.Count() < 6)
                                            {
                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                                Text_Box.Foreground = Brushes.White;
                                                Write_convar_To_File(name, val, Description, false, Convar_File);

                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                                                Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");


                                            }
                                            else
                                            {
                                                if (val == null || val == "")
                                                {

                                                    Write_convar_To_File(name, val, Description, false, Convar_File);

                                                }
                                                else
                                                {
                                                    //Send_Warning_Notif(GetTextResource("NOTIF_WARN_ERROR_AT") + name + "]");
                                                    Text_Box.Background = Brushes.Red;
                                                    Text_Box.Text = null;

                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (val.Count() > 5)
                                    {
                                        //Send_Warning_Notif(GetTextResource("NOTIF_WARN_PORT_TOO_lONG"));
                                        Text_Box.Background = Brushes.Red;
                                    }
                                    else
                                    {
                                        Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");

                                        if (e.Key == Key.Return)
                                        {

                                            if (IsPort(val) == true && val.Count() < 6)
                                            {
                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

                                                Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);
                                                Text_Box.Foreground = Brushes.White;

                                                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

                                                Text_Box.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF4C4C4C");


                                            }
                                            else
                                            {
                                                if (val == null || val == "")
                                                {

                                                    //Send_Warning_Notif(GetTextResource("NOTIF_WARN_GROUP_CVAR_EMTPY_VALUE") + name + GetTextResource("NOTIF_WARN_GROUP_CVAR_REMOVED"));
                                                    Write_Startup_Arg_To_File(name, val, false, true, Ns_dedi_File);

                                                }
                                                else
                                                {
                                                    //Send_Warning_Notif(GetTextResource("NOTIF_WARN_GROUP_CVAR_ERROR_AT") + name + "]");
                                                    Text_Box.Background = Brushes.Red;
                                                    Text_Box.Text = null;

                                                }

                                            }
                                        }
                                    }
                                }
                                break;

                        }





                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }
        private void ComboBox_MouseEnter(object sender, MouseEventArgs e)
        {
            Started_Selection = true;

        }

        private ArrayList Convar_Args()
        {

            ArrayList Arg_List = new ArrayList();

            using (StreamReader r = new StreamReader(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).FullName + "/Resources/Resource_Static/Northstar_Server_Vals_Aug_2022.json"))
            {
                string json = r.ReadToEnd();
                // Send_Success_Notif(json);
                Server_Json = Server_Setup.FromJson(json);
            }

            foreach (var items in Server_Json.Convar_Arguments)
            {
                if (items.Type == "GAME_MODE")
                {
                    foreach (var item in items.List)
                    {

                        Game_Modes_List.Add(item);
                    }

                }

                Arg_List.Add(new Arg_Set
                {
                    Name = items.Name.Trim().ToUpper().ToString(),
                    Type = items.Type,
                    Default = items.Default,
                    Description = items.Description_Tooltip,
                    List = items.List,
                    Tag = items.Type + "|" + items.Name + "|" + items.ARG,



                });
                DataContext = this;

            }
            return Arg_List;

        }
        private async void CheckComboBox_Initialized(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(HandyControl.Controls.CheckComboBox))
            {
                HandyControl.Controls.CheckComboBox comboBox = (HandyControl.Controls.CheckComboBox)sender;
                var Var = ((HandyControl.Controls.CheckComboBox)sender).Tag.ToString();

                string[] Split = Var.Split("|");
                string type = Split[0];
                string name = Split[1];
                string ARG = Split[2];
                // string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());
                if (ARG == "CONVAR")
                {
                    if (type == "LIST")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);
                            import = import.Trim();
                            string[] import_split = import.Split(",");
                            foreach (string item in import_split)
                            {
                                comboBox.SelectedItems.Add(item);
                            }

                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }
                    else
                    {


                        //   Send_Success_Notif("Convar");
                        //      Read_Convar_args(name, Convar_File);
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);

                            string[] import_split = import.Split(" ");
                            foreach (string item in import_split)
                            {
                                comboBox.SelectedItems.Add(item);


                                //Send_Error_Notif(item);
                            }
                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }
                    }
                }


                else
                {

                    //Send_Info_Notif(Var);

                    // string list = String.Join(" ", comboBox.SelectedItems.Cast<String>().ToArray());
                    string import = null;
                    this.Dispatcher.Invoke(() =>
                    {
                        import = Read_Startup_args(name);
                    });
                    if (import != null)
                    {
                        import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                        string[] import_split = import.Split(" ");
                        foreach (string item in import_split)
                        {
                            comboBox.SelectedItems.Add(item);

                        }

                        comboBox.Foreground = Brushes.White;

                    }
                    else
                    {
                        comboBox.Foreground = Brushes.Gray;

                    }
                }
            }
            else if (sender.GetType() == typeof(ComboBox))
            {
                ComboBox comboBox = (ComboBox)sender;
                var Var = ((ComboBox)sender).Tag.ToString();

                string[] Split = Var.Split("|");
                string type = Split[0];
                string name = Split[1];
                string ARG = Split[2];
                if (ARG == "CONVAR")
                {
                    if (type == "BOOL")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);
                            comboBox.SelectedIndex = Convert.ToInt32(import);
                            comboBox.Foreground = Brushes.White;

                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }
                    if (type == "ONE_SELECT")
                    {
                        string import = null;
                        this.Dispatcher.Invoke(() =>
                        {
                            import = Read_Convar_args(name, Convar_File);
                        });
                        if (import != null)
                        {
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                            {
                                import = import.Substring(0, index);
                            }

                            comboBox.SelectedValue = import.Trim();
                            comboBox.Foreground = Brushes.White;
                        }
                        else
                        {
                            comboBox.Foreground = Brushes.Gray;

                        }

                    }


                }
            }

            Started_Selection = false;
        }
        private void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        private void TextBox_Initialized(object sender, EventArgs e)
        {
            try
            {
                var val = ((TextBox)sender).Text.ToString();
                var Tag = ((TextBox)sender).Tag.ToString();
                TextBox Text_Box = (TextBox)sender;
                string[] Split = Tag.Split("|");
                string type = Split[0];
                string name = Split[1];
                string ARG = Split[2];

                string import = null;
                if (ARG == "CONVAR")
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        import = Read_Convar_args(name, Convar_File);

                    });
                    if (import != null)
                    {
                        Text_Box.Foreground = Brushes.White;

                        if (type == "STRING")
                        {
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);

                            Text_Box.Text = import.Trim();
                            //  Send_Warning_Notif(import);


                        }
                        else
                        {
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");
                            int index = import.IndexOf("//");
                            if (index >= 0)
                                import = import.Substring(0, index);


                            Text_Box.Text = import.Trim();


                        }






                    }
                    else
                    {

                        Text_Box.Foreground = Brushes.Gray;
                    }
                }
                else
                {


                    this.Dispatcher.Invoke(() =>
                    {
                        import = Read_Startup_args(name);
                    });
                    if (import != null)
                    {
                        Text_Box.Foreground = Brushes.White;

                        if (type == "STRINGQ")
                        {
                            //Send_Info_Notif(import);
                            //  import = import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            import = import.Replace("\"", "").Replace(name, "");



                            Text_Box.Text = import.Trim();
                            //  Send_Warning_Notif(import);


                        }
                        else
                        {
                            import.Replace(name.Trim(new Char[] { '-', '+' }), "");
                            string[] import_split = import.Split(" ");
                            for (int i = 1; i < import_split.Length; i++)
                            {
                                Text_Box.Text = import_split[1].Trim();
                            }
                        }






                    }
                    else
                    {

                        Text_Box.Foreground = Brushes.Gray;
                    }
                }
            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }

        }
        public string Read_From_TextFile_OneLine(string Filepath)
        {
            string line = "";
            try
            {
                using (var sr = new StreamReader(Filepath))
                {
                    line = sr.ReadLine();
                    return line;
                }

            }
            catch (System.IO.FileNotFoundException e)
            {
                Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");



            }

            return line;

        }
        private void Check_Args()
        {


            if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
            {


                if (File.Exists(Ns_dedi_File))
                {
                    DispatchIfNecessary(() => {
                        //Dedicated_Server_Startup_ARGS.Background = Brushes.White;
                        Arg_Box_Dedi.Text = Read_From_TextFile_OneLine(Ns_dedi_File);

                    });
                }
                else
                    {
                        DispatchIfNecessary(() => {
                            //Send_Error_Notif(GetTextResource("NOTIF_ERROR_CANNOT_FIND_FILE_SETPATH"));
                            Arg_Box_Dedi.Text = "Err, File not found - ns_startup_args_dedi.txt";
                            //Dedicated_Server_Startup_ARGS.Background = Brushes.Red;
                        });

                }


                if (File.Exists(NS_Startup))
                        {
                            DispatchIfNecessary(() => {
                                Arg_Box.Text = Read_From_TextFile_OneLine(NS_Startup);
                            });

                }
                else
                            {
                                DispatchIfNecessary(() => {
                                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_CANNOT_FIND_FILE_CREATE"));
                                    Arg_Box.Text = "Err, File not found - ns_startup_args.txt";
                                });
                }

                if (File.Exists(Convar_File))
                {

                   // Dedicated_Convar_ARGS.Text = Convar_File;
                    //Dedicated_Convar_ARGS.Background = Brushes.White;


                }
                
                    //{
                    //    Send_Error_Notif(GetTextResource("NOTIF_ERROR_CANNOT_FIND_FILE_SETPATH"));
                    //    Dedicated_Convar_ARGS.Background = Brushes.Red;

                    //Dedicated_Convar_ARGS.Text = "Err, File not found - autoexec_ns_server.cfg";
            }
        


            else
            {

                //Send_Error_Notif(GetTextResource("NOTIF_ERROR_CANNOT_FIND_FOLDER"));
                //


            }
        }
        private void S(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)

            {

                Scoller.LineDown();

            }

            else

            {

                Scoller.LineUp();

            }
        }

        private void Convar_Arguments_UI_List_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)

            {

                Scoller.LineDown();

            }

            else

            {

                Scoller.LineUp();

            }
        }
        async Task Load_Files_()
        {

            await Task.Run(() =>
            {


                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\autoexec_ns_server.cfg"))
                {
                    File.Delete(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\autoexec_ns_server.cfg");
                }

                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                {

                    Convar_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();
                    Ns_dedi_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();
                    NS_Startup = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args.txt").First();

                }
                if (Convar_File != null || Ns_dedi_File != null)
                {
                    if (File.Exists(Ns_dedi_File) && File.Exists(Convar_File))
                    {
                        DispatchIfNecessary(() =>
                        {

                            Startup_Arguments_UI_List.ItemsSource = Load_Args();
                            Convar_Arguments_UI_List.ItemsSource = Convar_Args();
                            Started_Selection = false;
                            Check_Args();

                            Load_Files.Content = "Reload Arguments";
                        });
                       


                    }
                    else
                    {
                        //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SUGGEST_REBROWSE"));

                        return;
                    }
                }
                else
                {
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SUGGEST_REBROWSE"));
                    //Send_Error_Notif("Could Not Find Dedicated arg Files!");

                    return;
                }












            });
            }
        private void Load_Files_Click(object sender, RoutedEventArgs e)
        {
            init_ = true;

            try
            {

                Load_Files_();

            }
            catch (Exception ex)
            {

                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }
        private string Find_Folder(string searchQuery, string folderPath)
        {
            searchQuery = "*" + searchQuery + "*";

            var directory = new DirectoryInfo(folderPath);

            var directories = directory.GetDirectories(searchQuery, SearchOption.AllDirectories);
            return directories[0].ToString();
        }
        private void Import_Server_Config_Click(object sender, RoutedEventArgs e)
        {
            init_ = true;

            try
            {

                string zipPath = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == true)
                {
                    zipPath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }

                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace"))
                {
                    string extractPath = Path.GetFullPath(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace");
                    if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\autoexec_ns_server.cfg"))
                    {
                        File.Delete(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\autoexec_ns_server.cfg");
                    }

                    if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                        extractPath += Path.DirectorySeparatorChar;







                    if (zipPath != null)
                    {

                        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.EndsWith(".cfg", StringComparison.OrdinalIgnoreCase) || entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                                {
                                    // Gets the full path to ensure that relative segments are removed.
                                    string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                                    // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                    // are case-insensitive.
                                    if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                                    {
                                        string f = Find_Folder("Northstar.CustomServers", User_Settings_Vars.NorthstarInstallLocation).ToString();

                                        if (Directory.Exists(f))
                                        {
                                            string c = GetFile(f, "autoexec_ns_server.cfg").First();

                                            if (entry.FullName.EndsWith(".cfg"))
                                            {
                                                entry.ExtractToFile(c, true);


                                            }

                                        }
                                        if (File.Exists(GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First()))
                                        {
                                            string d = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();

                                            if (entry.FullName.EndsWith(".txt"))
                                            {
                                                entry.ExtractToFile(d, true);

                                            }


                                        }

                                    }
                                }
                                else
                                {

                                    //Send_Error_Notif("Error! Cannot see valid Server config files in the zip!");
                                    return;
                                }
                            }
                        }
                    }
                    Convar_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();
                    Ns_dedi_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();
                    // HandyControl.Controls.MessageBox.Show(new MessageBoxInfo { Message = "Please Select the Northstar Dedicated Import as well.", Caption = "PROMPT!", Button = MessageBoxButton.OK, IconBrushKey = ResourceToken.AccentBrush, IconKey = ResourceToken.AskGeometry, StyleKey = "MessageBoxCustom" });
                }
                else
                {
                    Directory.CreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace");
                    string extractPath = Path.GetFullPath(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace");



                    if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                        extractPath += Path.DirectorySeparatorChar;





                    if (zipPath != null)
                    {


                        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.EndsWith(".cfg", StringComparison.OrdinalIgnoreCase) || entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                                {
                                    // Gets the full path to ensure that relative segments are removed.
                                    string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                                    // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                                    // are case-insensitive.
                                    if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                                    {
                                        string f = Find_Folder("Northstar.CustomServers", User_Settings_Vars.NorthstarInstallLocation).ToString();

                                        if (Directory.Exists(f))
                                        {
                                            string c = GetFile(f, "autoexec_ns_server.cfg").First();

                                            if (entry.FullName.EndsWith(".cfg"))
                                            {
                                                entry.ExtractToFile(c, true);


                                            }

                                        }
                                        if (File.Exists(GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First()))
                                        {
                                            string d = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();

                                            if (entry.FullName.EndsWith(".txt"))
                                            {
                                                entry.ExtractToFile(d, true);

                                            }


                                        }

                                    }
                                }
                                else
                                {

                                    //Send_Error_Notif(GetTextResource("SERVER_CFG_FAILED"));
                                    return;
                                }
                            }
                        }
                    }
                    // HandyControl.Controls.MessageBox.Show(new MessageBoxInfo { Message = "Please Select the Northstar Dedicated Import as well.", Caption = "PROMPT!", Button = MessageBoxButton.OK, IconBrushKey = ResourceToken.AccentBrush, IconKey = ResourceToken.AskGeometry, StyleKey = "MessageBoxCustom" });
                    if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
                    {
                        Ns_dedi_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").First();

                        if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + @"R2Northstar\mods"))
                        {
                            Convar_File = GetFile(User_Settings_Vars.NorthstarInstallLocation, "autoexec_ns_server.cfg").First();

                        }
                    }





                }
                if (File.Exists(Ns_dedi_File) && File.Exists(Convar_File))
                {
                    Startup_Arguments_UI_List.ItemsSource = Load_Args();
                    Convar_Arguments_UI_List.ItemsSource = Convar_Args();
                    Started_Selection = false;

                    Load_Files.Content = "Reload Arguments";
                    Check_Args();
                    init_ = true;
                    //Send_Success_Notif("Imported and Applied!");
                }
                else
                {
                    //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SUGGEST_REBROWSE"));
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }
        public void ZIP_LIST(List<string> filesToZip, string sZipFileName, bool deleteExistingZip = true)
        {
            if (filesToZip.Count > 0)
            {
                if (File.Exists(filesToZip[0]))
                {

                    // Get the first file in the list so we can get the root directory
                    string strRootDirectory = Path.GetDirectoryName(filesToZip[0]);

                    // Set up a temporary directory to save the files to (that we will eventually zip up)
                    DirectoryInfo dirTemp = Directory.CreateDirectory(strRootDirectory + "/" + DateTime.Now.ToString("yyyyMMddhhmmss"));

                    // Copy all files to the temporary directory
                    foreach (string strFilePath in filesToZip)
                    {
                        if (!File.Exists(strFilePath))

                        {
                            //Send_Error_Notif("Failed!");
                            //Write_To_Log("file does not exist" + Ns_dedi_File + "   " + Convar_File);

                            return;
                            // throw new Exception(string.Format("File {0} does not exist", strFilePath));
                        }
                        string strDestinationFilePath = Path.Combine(dirTemp.FullName, Path.GetFileName(strFilePath));
                        File.Copy(strFilePath, strDestinationFilePath);
                    }

                    // Create the zip file using the temporary directory
                    if (!sZipFileName.EndsWith(".zip")) { sZipFileName += ".zip"; }
                    string strZipPath = Path.Combine(strRootDirectory, sZipFileName);
                    if (deleteExistingZip == true && File.Exists(strZipPath)) { File.Delete(strZipPath); }
                    ZipFile.CreateFromDirectory(dirTemp.FullName, strZipPath, CompressionLevel.Fastest, false);

                    // Delete the temporary directory
                    dirTemp.Delete(true);

                    _filePath = strZipPath;
                }
                else
                {
                    //Send_Error_Notif("Failed!");
                    //Write_To_Log("file does not exist" + Ns_dedi_File + "   " + Convar_File);
                    return;
                }
            }
            else
            {
                //Send_Error_Notif("You must specify at least one file to zip.");
                return;
            }
        }
        private void Export_Server_Config_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation + "VTOL_Dedicated_Workspace"))
                {
                    if (File.Exists(Ns_dedi_File) && File.Exists(Convar_File))
                    {
                        List<string> files = new List<string>();
                        files.Add(Ns_dedi_File);
                        files.Add(Convar_File);

                        ZIP_LIST(files, User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\Exported_Config.zip", true);

                        //Send_Success_Notif("Exported to " + User_Settings_Vars.NorthstarInstallLocation + @"\VTOL_Dedicated_Workspace/Exported_Config.zip" + " Sucessfully!");



                    }
                    else
                    {
                        //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SUGGEST_REBROWSE"));
                        return;
                    }
                }
                else
                {
                    Directory.CreateDirectory(User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace");

                    if (File.Exists(Ns_dedi_File) && File.Exists(Convar_File))
                    {
                        List<string> files = new List<string>();
                        files.Add(Path.GetDirectoryName(Ns_dedi_File).ToString());
                        files.Add(Path.GetDirectoryName(Convar_File).ToString());

                        ZIP_LIST(files, User_Settings_Vars.NorthstarInstallLocation + @"VTOL_Dedicated_Workspace\Exported_Config.zip", true);
                        //Send_Success_Notif("Exported to " + User_Settings_Vars.NorthstarInstallLocation + @"\VTOL_Dedicated_Workspace/Exported_Config.zip" + " Sucessfully!");





                    }
                    else
                    {
                        //Send_Error_Notif(GetTextResource("LOAD"));
                        //Send_Error_Notif(GetTextResource("NOTIF_ERROR_SUGGEST_REBROWSE"));
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }

        private void Dedicated_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
            {

                if (File.Exists(NS_Startup))
                {
                    saveAsyncFile(Arg_Box.Text, NS_Startup, false, false);


                }
                else
                {
                    //Console.WriteLine("Err, File not found ns_startup_args_dedi");

                }

                if (File.Exists(Get_And_Set_Filepaths(User_Settings_Vars.NorthstarInstallLocation, "NorthstarLauncher.exe")))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = User_Settings_Vars.NorthstarInstallLocation + @"r2ds.bat";
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Get_And_Set_Filepaths(User_Settings_Vars.NorthstarInstallLocation, "NorthstarLauncher.exe"));


                    // procStartInfo.Arguments = "-dedicated -multiple";

                    process.StartInfo = procStartInfo;

                    process.Start();
                    // int id = process.Id;
                    //  pid = id;
                    // Process tempProc = Process.GetProcessById(id);
                    // this.Visible = false;
                    // Thread.Sleep(5000);
                    // tempProc.WaitForExit();
                    // this.Visible = true;

                    // Process process = Process.Start(NSExe, Arg_Box.Text);
                    process.Close();



                }
                else
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Launch_Northstar_Dedicated_Click_CouldNotFindDedicatedBat;
                    SnackBar.Show();


                }
            }
            else
            {
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR";
                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Launch_Northstar_Dedicated_Click_CouldNotFindDedicatedBat;
                SnackBar.Show();


            }

        }
        private string Get_And_Set_Filepaths(string rootDir, string Filename)
        {
            try
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@rootDir);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + Filename + "*.*");
                // //Console.WriteLine(rootDir);
                // //Console.WriteLine(Filename);

                foreach (FileInfo foundFile in filesInDir)
                {
                    if (foundFile.Name.Equals(Filename))
                    {
                        ////Console.WriteLine("Found");

                        string fullName = foundFile.FullName;
                        //////Console.WriteLine(fullName);
                        return fullName;


                    }
                    else
                    {

                        return "\nCould Not Find" + Filename + "\n";

                    }

                }
            }

            catch (Exception e)
            {

                //Send_Fatal_Notif(GetTextResource("NOTIF_FATAL_COMMON_LOG"));

                //Write_To_Log("The process failed: " + e.ToString());
                Log.Error(e, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }


            return "Exited with No Due to Missing Or Inaccurate Path";


        }
        private void Launch_Northstar_Advanced_Click(object sender, RoutedEventArgs e)
        {
           string NSExe = Get_And_Set_Filepaths(User_Settings_Vars.NorthstarInstallLocation, "NorthstarLauncher.exe");
            if (File.Exists(NS_Startup))
            {
                saveAsyncFile(Arg_Box.Text, NS_Startup, false, false);


            }
            else
            {
                //Console.WriteLine("Err, File not found");

            }

            if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
            {

                if (File.Exists(NSExe))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = NSExe;
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(NSExe);
                    ;

                    // procStartInfo.Arguments = args;

                    process.StartInfo = procStartInfo;

                    process.Start();
                    int id = process.Id;
                    Process tempProc = Process.GetProcessById(id);
                    // this.Visible = false;
                    // Thread.Sleep(5000);
                    // tempProc.WaitForExit();
                    // this.Visible = true;

                    // Process process = Process.Start(NSExe, Arg_Box.Text);
                    process.Close();


                }
                else
                {


                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Launch_Northstar_Advanced_Click_CouldNotFindNorthstarExe;
                    SnackBar.Show();
                }
            }
            else
            {

                //Console.WriteLine("Err, File not found");


            }
        }

        private void Launch_Northstar_Dedicated_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(User_Settings_Vars.NorthstarInstallLocation))
            {

                if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt"))
                {
                    saveAsyncFile(Arg_Box_Dedi.Text, User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt", false, false);


                }
                else
                {
                    //Console.WriteLine("Err, File not found ns_startup_args_dedi");

                }

                if (File.Exists(Get_And_Set_Filepaths(User_Settings_Vars.NorthstarInstallLocation, "NorthstarLauncher.exe")))
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    Process process = new Process();
                    procStartInfo.FileName = User_Settings_Vars.NorthstarInstallLocation + @"r2ds.bat";
                    procStartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Get_And_Set_Filepaths(User_Settings_Vars.NorthstarInstallLocation, "NorthstarLauncher.exe"));


                    // procStartInfo.Arguments = "-dedicated -multiple";

                    process.StartInfo = procStartInfo;

                    process.Start();
                    // int id = process.Id;
                    //  pid = id;
                    // Process tempProc = Process.GetProcessById(id);
                    // this.Visible = false;
                    // Thread.Sleep(5000);
                    // tempProc.WaitForExit();
                    // this.Visible = true;

                    // Process process = Process.Start(NSExe, Arg_Box.Text);
                    process.Close();



                }
                else
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR";
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Launch_Northstar_Dedicated_Click_CouldNotFindDedicatedBat;
                    SnackBar.Show();


                }
            }
            else
            {
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR";
                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_Launch_Northstar_Dedicated_Click_CouldNotFindDedicatedBat;
                SnackBar.Show();


            }
        }

        private void Step_Bar_StepChanged(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            //if(Step_Bar.StepIndex == 2)
            //{
            //    DoubleAnimation da = new DoubleAnimation
            //    {
            //        From = Step_Bar.Opacity,
            //        To = 0,
            //        Duration = new Duration(TimeSpan.FromSeconds(2)),
            //        AutoReverse = false
            //    };
            //    Step_Bar.BeginAnimation(OpacityProperty, da);
            //}
        }

        private void Arg_Box_Dedi_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (init_ == true)
                {
                    if (File.Exists(User_Settings_Vars.NorthstarInstallLocation + @"ns_startup_args_dedi.txt"))
                    {
                        saveAsyncFile(Arg_Box_Dedi.Text, GetFile(User_Settings_Vars.NorthstarInstallLocation, "ns_startup_args_dedi.txt").FirstOrDefault(), false, false);


                    }
                    else
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_OnKeyDownHandler_Dedi_Arg_AutoSaveFailed;
                        SnackBar.Show();


                    }

                }
            }
            catch (Exception ex)
            {

                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR";
                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_OnKeyDownHandler_Dedi_Arg_AutoSaveFailed;
                SnackBar.Show();

            }
        }
        

        private void Arg_Box_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                if (init_ == true)
                {
                    if (File.Exists(NS_Startup))
                    {
                        saveAsyncFile(Arg_Box.Text, NS_Startup, false, false);


                    }
                    else
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_OnKeyDownHandler_Dedi_Arg_AutoSaveFailed;
                        SnackBar.Show();


                    }
                }
            }
            catch (Exception ex)
            {
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = "ERROR";
                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Server_OnKeyDownHandler_Dedi_Arg_AutoSaveFailed;
                SnackBar.Show();


            }
        }
    }
}
