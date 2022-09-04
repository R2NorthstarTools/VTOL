using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
using ZipFile_ = Ionic.Zip.ZipFile;

using Microsoft.Win32;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Syncfusion;
using Wpf.Ui.Common;
using Brushes = System.Windows.Media.Brushes;
using Image = SixLabors.ImageSharp.Image;
using Path = System.IO.Path;
using ZipFile = System.IO.Compression.ZipFile;
using BCnEncoder.Encoder;
using ImageMagick;
using ImageMagick.Formats;
using Serilog;
using System.Globalization;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_Tools.xaml
    /// </summary>
    /// 
    public class Item
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }
    public partial class Page_Tools : Page
    {
        Window_Tool_Image_Editor_Wizard Img_ed;
        private string Current_Output_Dir;
        private string Current_Mod_To_Pack;
        private string Mod_Icon_Path;
        Wpf.Ui.Controls.Snackbar SnackBar;
        public MainWindow Main = GetMainWindow();
        string SelectedGame = null;
        string SelectedWeapon = null;
        int ImageNumber = 0;
        public Page_Tools()
        { 
            InitializeComponent();
            SnackBar = Main.Snackbar;
            Mod_dependencies.Text = "northstar-Northstar-" + Properties.Settings.Default.Version.Remove(0, 1);
            Paragraph paragraph = new Paragraph();
            Description_Box.Document.Blocks.Clear();
            Skin_Mod_Pack_Check.IsChecked = Properties.Settings.Default.PackageAsSkin;
            Run run = new Run(@"#PLACEHOLDER_SKIN_NAME

    YOUR DESCRIPTION
//Example image, remove me before publishing!
//![Imgur](https://i.imgur.com/hdnNWZQ.jpeg)");
            paragraph.Inlines.Add(run);
            Description_Box.Document.Blocks.Add(paragraph);
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "R201", Category = "Assault Rifle" });
            items.Add(new Item() { Name = "R101", Category = "Assault Rifle" });
            items.Add(new Item() { Name = "HemlokBFR", Category = "Assault Rifle" });
            items.Add(new Item() { Name = "VK47Flatline", Category = "Assault Rifle" });
            items.Add(new Item() { Name = "G2A5", Category = "Assault Rifle" });

            items.Add(new Item() { Name = "CAR", Category = "Submachine Gun" });
            items.Add(new Item() { Name = "Alternator", Category = "Submachine Gun" });
            items.Add(new Item() { Name = "Volt", Category = "Submachine Gun" });
            items.Add(new Item() { Name = "R97", Category = "Submachine Gun" });


            items.Add(new Item() { Name = "EVA8", Category = "Shotgun" });
            items.Add(new Item() { Name = "Mastiff", Category = "Shotgun" });

            items.Add(new Item() { Name = "Kraber", Category = "Sniper" });
            items.Add(new Item() { Name = "DoubleTake", Category = "Sniper" });
            items.Add(new Item() { Name = "LongbowDMR", Category = "Sniper" });


            items.Add(new Item() { Name = "Spitfire", Category = "Light Machine Gun" });
            items.Add(new Item() { Name = "LSTAR", Category = "Light Machine Gun" });
            items.Add(new Item() { Name = "Devotion", Category = "Light Machine Gun" });
            items.Add(new Item() { Name = "Devotion clip", Category = "Light Machine Gun" });

            items.Add(new Item() { Name = "SMR", Category = "Grenadier" });
            items.Add(new Item() { Name = "EPG", Category = "Grenadier" });
            items.Add(new Item() { Name = "Softball", Category = "Grenadier" });
            items.Add(new Item() { Name = "ColdWar", Category = "Grenadier" });

            items.Add(new Item() { Name = "WingmanElite", Category = "Primary Pistol" });
            items.Add(new Item() { Name = "Mozambique", Category = "Primary Pistol" });

            items.Add(new Item() { Name = "ChargeRifle", Category = "Anti-Titan Weapon" });
            items.Add(new Item() { Name = "MGL", Category = "Anti-Titan Weapon" });
            items.Add(new Item() { Name = "Thunderbolt", Category = "Anti-Titan Weapon" });
            items.Add(new Item() { Name = "Archer", Category = "Anti-Titan Weapon" });

            items.Add(new Item() { Name = "P2020", Category = "Secondary Pistol" });
            items.Add(new Item() { Name = "RE45", Category = "Secondary Pistol" });
            items.Add(new Item() { Name = "Wingman", Category = "Secondary Pistol" });

            items.Add(new Item() { Name = "SmartPistol", Category = "Burn Card Weapon" });

            items.Add(new Item() { Name = "Broad Sword", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "Leadwall", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "Plasma Railgun", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "Predator Cannon", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "T-203 Thermite Launcher", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "40mm Tracker Cannon", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "Splitter Rifle", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "XO16", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "XO16 clip", Category = "Titan Weapon" });
            items.Add(new Item() { Name = "PrimeSword", Category = "Titan Weapon" });

            items.Add(new Item() { Name = "Pilot Sword", Category = "Melee" });
            items.Add(new Item() { Name = "Kunai", Category = "Melee" });

            items.Add(new Item() { Name = "AcogSight", Category = "Attachment" });
            items.Add(new Item() { Name = "AogSight", Category = "Attachment" });
            items.Add(new Item() { Name = "Hcog", Category = "Attachment" });
            items.Add(new Item() { Name = "HoloReflexSight", Category = "Attachment" });
            items.Add(new Item() { Name = "ProScreen", Category = "Attachment" });
            items.Add(new Item() { Name = "SniperScope", Category = "Attachment" });
            items.Add(new Item() { Name = "SniperScopeX4", Category = "Attachment" });
            items.Add(new Item() { Name = "Supressor", Category = "Attachment" });
            items.Add(new Item() { Name = "ThreatScope", Category = "Attachment" });
            items.Add(new Item() { Name = "ThreatScopeSniper", Category = "Attachment" });

            items.Add(new Item() { Name = "ION", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Legion", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Scorch", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Northstar", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Ronin", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Tone", Category = "TitanSkins" });
            items.Add(new Item() { Name = "Monarch", Category = "TitanSkins" });

            items.Add(new Item() { Name = "PrimeION", Category = "PrimeTitanSkins" });
            items.Add(new Item() { Name = "PrimeLegion", Category = "PrimeTitanSkins" });
            items.Add(new Item() { Name = "PrimeNorthstar", Category = "PrimeTitanSkins" });
            items.Add(new Item() { Name = "PrimeRonin", Category = "PrimeTitanSkins" });
            items.Add(new Item() { Name = "PrimeScorch", Category = "PrimeTitanSkins" });
            items.Add(new Item() { Name = "PrimeTone", Category = "PrimeTitanSkins" });

            items.Add(new Item() { Name = "PhaseShift_fbody", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_mbody", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_hair", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_fjumpkit", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_gear", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_helmet", Category = "PhaseShiftPilotParts" });
            items.Add(new Item() { Name = "PhaseShift_viewhand", Category = "PhaseShiftPilotParts" });

            items.Add(new Item() { Name = "Grapple_fbody", Category = "GrapplePilotParts" });
            items.Add(new Item() { Name = "Grapple_mbody", Category = "GrapplePilotParts" });
            items.Add(new Item() { Name = "Grapple_jumpkit", Category = "GrapplePilotParts" });
            items.Add(new Item() { Name = "Grapple_gear", Category = "GrapplePilotParts" });
            items.Add(new Item() { Name = "Grapple_helmet", Category = "GrapplePilotParts" });
            items.Add(new Item() { Name = "Grapple_gauntlet", Category = "GrapplePilotParts" });

            items.Add(new Item() { Name = "PulseBlade_fbody", Category = "PulseBladeParts" });
            items.Add(new Item() { Name = "PulseBlade_mbody", Category = "PulseBladeParts" });
            items.Add(new Item() { Name = "PulseBlade_jumpkit", Category = "PulseBladeParts" });
            items.Add(new Item() { Name = "PulseBlade_gear", Category = "PulseBladeParts" });
            items.Add(new Item() { Name = "PulseBlade_helmet", Category = "PulseBladeParts" });
            items.Add(new Item() { Name = "PulseBlade_gauntlet", Category = "PulseBladeParts" });

            items.Add(new Item() { Name = "HoloPilot_fbody", Category = "HoloPilotParts" });
            items.Add(new Item() { Name = "HoloPilot_mbody", Category = "HoloPilotParts" });
            items.Add(new Item() { Name = "HoloPilot_jumpkit", Category = "HoloPilotParts" });
            items.Add(new Item() { Name = "HoloPilot_gear", Category = "HoloPilotParts" });
            items.Add(new Item() { Name = "HoloPilot_helmet", Category = "HoloPilotParts" });
            items.Add(new Item() { Name = "HoloPilot_viewhands", Category = "HoloPilotParts" });

            items.Add(new Item() { Name = "Cloak_fbody", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_mbody", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_jumpkit", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_gear", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_helmet", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_gauntlet", Category = "CloakParts" });
            items.Add(new Item() { Name = "Cloak_ghillie", Category = "CloakParts" });

            items.Add(new Item() { Name = "AWall_fbody", Category = "AWallParts" });
            items.Add(new Item() { Name = "AWall_mbody", Category = "AWallParts" });
            items.Add(new Item() { Name = "AWall_jumpkit", Category = "AWallParts" });
            items.Add(new Item() { Name = "AWall_gear", Category = "AWallParts" });
            items.Add(new Item() { Name = "AWall_helmet", Category = "AWallParts" });
            items.Add(new Item() { Name = "AWall_gauntlet", Category = "AWallParts" });

            items.Add(new Item() { Name = "Stim_fbody", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_mbody", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_jumpkit", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_fjumpkit", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_gear", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_fgear", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_head", Category = "StimParts" });
            items.Add(new Item() { Name = "Stim_gauntlet", Category = "StimParts" });

            items.Add(new Item() { Name = "JackHandL", Category = "JackCooperParts" });
            items.Add(new Item() { Name = "JackHandR", Category = "JackCooperParts" });




            ListCollectionView lcv = new ListCollectionView(items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

            Items_List.ItemsSource = lcv;
            Output_Directory.Text = Environment.CurrentDirectory;
            Output_Box.Text = Environment.CurrentDirectory;

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
       
        private void Window_Closed(object sender, EventArgs e)
        {
            Mod_Icon_Path = Img_ed.Last_Saved_Skin_Path;
            if (Mod_Icon_Path != null)
            {
                if (File.Exists(Mod_Icon_Path))
                {
                    if (Path.GetExtension(Mod_Icon_Path).Contains("png"))
                    {
                        int imgwidth;
                        int imgheight;

                        using (var image = SixLabors.ImageSharp.Image.Load(Mod_Icon_Path))
                        {
                            imgwidth = image.Width;
                            imgheight = image.Height;
                        }

                        if (imgwidth == 256 && imgheight == 256)
                        {
                            Console.WriteLine("Valid Image Found at - " + Mod_Icon_Path);
                            BitmapImage Mod_Icon = new BitmapImage();
                            Mod_Icon.BeginInit();

                            Mod_Icon.UriSource = new Uri(Mod_Icon_Path);
                            Mod_Icon.EndInit();


                        }
                        else
                        {
                            Console.WriteLine("Invalid Image Size!. Must be 256x256");

                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                            bitmap.EndInit();
                            return;

                        }

                    }
                }
            }
        }

                   

        private void Locate_Zip_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    Current_Mod_To_Pack = openFileDialog.FileName;
                    if (!File.Exists(Current_Mod_To_Pack))
                    {

                         SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                        SnackBar.Message = "Invalid Zip Found";
                        SnackBar.Show();
                        Zip_Box.Background = Brushes.IndianRed;

                        return;

                    }
                    else
                    {
                        if (Path.GetExtension(Current_Mod_To_Pack).Contains("zip") || Path.GetExtension(Current_Mod_To_Pack).Contains("Zip"))
                        {
                            SnackBar.Appearance = ControlAppearance.Info;
                            SnackBar.Title = "INFO";
                            SnackBar.Message = "Valid Zip Found";
                            SnackBar.Show();
                            Zip_Box.Text = Current_Mod_To_Pack;
                            Zip_Box.Background = Brushes.Transparent;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        
        private void Output_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                Current_Output_Dir = dialog.SelectedPath;
                if (!Directory.Exists(Current_Output_Dir))
                {
                     SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                    SnackBar.Message = "Not An Output Directory";
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;

                }
                else
                {
                    Output_Box.Text = Current_Output_Dir;
                    Output_Box.Background = Brushes.Transparent;

                }
            }
        }
        void create_Manifest(string Output_Folder)
        {
            try
            {
                if (Mod_name.Text == null && Mod_name.Text == "" && Mod_version_number.Text == null && Mod_version_number.Text == "" && Mod_website_url.Text == null && Mod_website_url.Text == "" && Mod_description.Text == null && Mod_description.Text == "" && Mod_dependencies.Text == null && Mod_dependencies.Text == "")
                {
                     SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                    SnackBar.Message = "One of the Manifest Inputs are Empty";
                    SnackBar.Show();
                    return;

                }
                else
                {
                    string Output = "";
                    if (Mod_dependencies.Text != null || Mod_dependencies.Text != "")
                    {

                        Output = @"{
    ""name"": " + '\u0022' + Mod_name.Text.Trim() + '\u0022' + @",
    ""version_number"":" + '\u0022' + Mod_version_number.Text.Trim() + '\u0022' + @",
    ""website_url"": " + '\u0022' + Mod_website_url.Text.Trim() + '\u0022' + @",
    ""description"": " + '\u0022' + Mod_description.Text.Trim() + '\u0022' + @",
    ""dependencies"": [" + '\u0022' + Mod_dependencies.Text + '\u0022' + "]" +
      "\n}";
                    }
                    else
                    {
                        Output = @"{
    ""name"": " + '\u0022' + Mod_name.Text.Trim() + '\u0022' + @",
    ""version_number"":" + '\u0022' + Mod_version_number.Text.Trim() + '\u0022' + @",
    ""website_url"": " + '\u0022' + Mod_website_url.Text.Trim() + '\u0022' + @",
    ""description"": " + '\u0022' + Mod_description.Text.Trim() + '\u0022' + @",
    ""dependencies"":" + '\u0022' + "[" + '\u0022' + "northstar-Northstar-" + Properties.Settings.Default.Version.Remove(0, 1) + '\u0022' + "]" +
               "\n}";
                    }
                    saveAsyncFile(Output, Output_Folder + @"\"  + "manifest.json", false, false);

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        public async Task saveAsyncFile(string Text, string Filename, bool ForceTxt = true, bool append = true)
        {
            await Task.Run(() =>
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
                        file.WriteLineAsync(Text);
                        file.Close();
                    }
                    else
                    {

                        File.WriteAllTextAsync(Filename, string.Empty);

                        File.WriteAllTextAsync(Filename, Text);

                    }
                }
                else
                {
                    File.WriteAllTextAsync(Filename, string.Empty);

                    File.WriteAllTextAsync(Filename, Text);

                }
            });
        }
        private void Save_Mod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(Current_Mod_To_Pack))
                {
                    if (File.Exists(Mod_Icon_Path))
                    {
                        if (Directory.Exists(Current_Output_Dir))
                        {
                            FileInfo Dir = new FileInfo(Current_Mod_To_Pack);
                            Directory.CreateDirectory(Current_Output_Dir + @"\"  + Mod_name.Text.Trim());
                            if (Directory.Exists(Current_Output_Dir + @"\"  + Mod_name.Text.Trim()))
                            {
                                GenerateThumbImage(Mod_Icon_Path, Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "icon.png", 256, 256);

                               

                                create_Manifest(Current_Output_Dir + @"\"  + Mod_name.Text.Trim());
                                TextRange Description = new TextRange(
                                // TextPointer to the start of content in the RichTextBox.
                                Description_Box.Document.ContentStart,
                                // TextPointer to the end of content in the RichTextBox.
                                Description_Box.Document.ContentEnd);
                                saveAsyncFile(Description.Text, Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "README.md", false, false);
                                if (Skin_Mod_Pack_Check.IsChecked == true)
                                {
                                    if (!Directory.Exists(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\" ))
                                    {
                                        Directory.CreateDirectory(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\" );
                                    }
                                    File.Copy(Current_Mod_To_Pack, Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\"  + Dir.Name, true);


                                }
                                else
                                {
                                    if (!Directory.Exists(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\" ))
                                    {
                                        Directory.CreateDirectory(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\" );

                                    }
                                    ZipFile_ zipFile = new ZipFile_(Current_Mod_To_Pack);

                                    zipFile.ExtractAll(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + @"\"  + "mods" + @"\" , Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

                                }

                                if (File.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip"))
                                {
                                    File.Delete(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + ".zip");
                                    ZipFile_ zipFile = new ZipFile_();
                                    zipFile.AddDirectory(Current_Output_Dir + @"\"  + Mod_name.Text.Trim());
                                    zipFile.Save(Current_Output_Dir + @"\"  + Mod_name.Text.Trim() + ".zip");
                                }
                                else
                                {
                                    ZipFile_ zipFile = new ZipFile_();
                                    zipFile.AddDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim());
                                    zipFile.Save(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip");
                                }

                            }
                        }
                        else
                        {
                             SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                            SnackBar.Message = "No Valid Output Path Found";
                            SnackBar.Show();
                            Output_Box.Background = Brushes.IndianRed;

                            return;

                        }

                        if (File.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip"))
                        {
                            Directory.Delete(Current_Output_Dir + @"\" + Mod_name.Text.Trim(), true);
                        }
                        SnackBar.Appearance = ControlAppearance.Success;
                        SnackBar.Title = "SUCCESS";
                        SnackBar.Message = "Successfully Packed all items to -" + Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip";
                        SnackBar.Show();
                    }
                    else
                    {
                         SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                        SnackBar.Message = "No Valid Mod ICON Found";
                        SnackBar.Show();
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                        bitmap.EndInit();
                        return;
                    }


                }
                else
                {
                     SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                    SnackBar.Message = "No Valid Zip file to pack was found";
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Skin_Mod_Pack_Check_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PackageAsSkin = true;
            Properties.Settings.Default.Save();
        }

        private void Skin_Mod_Pack_Check_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PackageAsSkin = false;
            Properties.Settings.Default.Save();
        }

        private void Icon_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Mod_Icon_Path = openFileDialog.FileName;
                        if (!File.Exists(Mod_Icon_Path))
                        {

                             SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                            SnackBar.Message = "Not A Valid PNG Image";
                            SnackBar.Show();
                            return;

                        }
                        else
                        {
                            if (Path.GetExtension(Mod_Icon_Path).Contains("png"))
                            {
                                int imgwidth;
                                int imgheight;

                                using (var image = SixLabors.ImageSharp.Image.Load(Mod_Icon_Path))
                                {
                                    imgwidth = image.Width;
                                    imgheight = image.Height;
                                }

                                if (imgwidth == 256 && imgheight == 256)
                                {

                                    SnackBar.Appearance = ControlAppearance.Success;
                                    SnackBar.Title = "SUCCESS";
                                    SnackBar.Message = "Valid Image Found at - " + Mod_Icon_Path;
                                    SnackBar.Show();
                                    BitmapImage Mod_Icon = new BitmapImage();
                                    Mod_Icon.BeginInit();

                                    Mod_Icon.UriSource = new Uri(Mod_Icon_Path);
                                    Mod_Icon.EndInit();


                                }
                                else
                                {
                                     SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                                    SnackBar.Message = "Invalid Image Size!. Must be 256x256";
                                    SnackBar.Show();
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    return;

                                }

                            }
                            else
                            {
                                 SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger;SnackBar.Title = "ERROR";
                                SnackBar.Message = "That was not a proper PNG";
                                SnackBar.Show();
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                                bitmap.EndInit();
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

                }
            }
        }

        private void Output_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private Image<Rgba32> ResizeImage(Image<Rgba32> input, int width, int height, int x, int y)
        {
            input.Mutate(img => img.Crop(SixLabors.ImageSharp.Rectangle.FromLTRB(x, y, width + x, height + y)));
            Console.WriteLine("Cropped");

            return input;
        }
        public static void GenerateThumbImage(string originalImagePath, string thumbImagePath, int newWidth, int newHeight)
        {
            Bitmap srcBmp = new Bitmap(originalImagePath);
            float ratio = 1;
            float minSize = Math.Min(newHeight, newHeight);

            if (srcBmp.Width > srcBmp.Height)
            {
                ratio = minSize / (float)srcBmp.Width;
            }
            else
            {
                ratio = minSize / (float)srcBmp.Height;
            }

            System.Drawing.SizeF newSize = new System.Drawing.SizeF(srcBmp.Width * ratio, srcBmp.Height * ratio);
            Bitmap target = new Bitmap((int)newSize.Width, (int)newSize.Height);

            using (Graphics graphics = Graphics.FromImage(target))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(srcBmp, 0, 0, newSize.Width, newSize.Height);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    target.Save(thumbImagePath);
                }
            }
        }
        void Process_Image(string path,string dir_out_)
        {
            try
            {
               

                Console.WriteLine(path.Replace(@"file:///", ""));
                if (File.Exists(path.Replace(@"file:///", "")))
                {
                    using (var inputStream = File.OpenRead(path.Replace(@"file:///", "")))
                    using (var image = Image.Load<Rgba32>(inputStream))
                    {
                       
                        ResizeImage(image, 256, 256, 0, 0).SaveAsPng(dir_out_);
                        Console.WriteLine("Done");

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }

        }
        private void Icon_Image_ImageSelected(object sender, RoutedEventArgs e)
        {
           
        }

        private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_Icon_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Mod_Icon_Path = openFileDialog.FileName;
                        if (!File.Exists(Mod_Icon_Path))
                        {

                            SnackBar.Icon = SymbolRegular.ErrorCircle20;
                            SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                            SnackBar.Message = "Not A Valid PNG Image";
                            SnackBar.Show();
                            return;

                        }
                        else
                        {
                            if (Path.GetExtension(Mod_Icon_Path).Contains("png"))
                            {
                                int imgwidth;
                                int imgheight;

                                using (var image = SixLabors.ImageSharp.Image.Load(Mod_Icon_Path))
                                {
                                    imgwidth = image.Width;
                                    imgheight = image.Height;
                                }

                                if (imgwidth == 256 && imgheight == 256)
                                {

                                    SnackBar.Appearance = ControlAppearance.Success;
                                    SnackBar.Title = "SUCCESS";
                                    SnackBar.Message = "Valid Image Found at - " + Mod_Icon_Path;
                                    SnackBar.Show();
                                    BitmapImage Mod_Icon = new BitmapImage();
                                    Mod_Icon.BeginInit();

                                    Mod_Icon.UriSource = new Uri(Mod_Icon_Path);
                                    Mod_Icon.EndInit();

                                    Image_Icon.Background =new ImageBrush(Mod_Icon);

                                }
                                else
                                {
                                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                                    SnackBar.Message = "Invalid Image Size!. Must be 256x256";
                                    SnackBar.Show();
                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                                    bitmap.EndInit();
                                    Image_Icon.Background = new ImageBrush(null);
                                    return;

                                }

                            }
                            else
                            {
                                SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                                SnackBar.Message = "That was not a proper PNG";
                                SnackBar.Show();
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Resource_Static/NO_TEXTURE.png");
                                bitmap.EndInit();
                                Image_Icon.Background = new ImageBrush(null);
                                return;
                            }
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

                }
            }
        }

        private void Image_Icon_Drop(object sender, DragEventArgs e)
        {
            try { 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                HandyControl.Controls.DashedBorder DashedBorder = (HandyControl.Controls.DashedBorder)sender;
                Console.WriteLine(DashedBorder.Name);

                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string map_Path = files.FirstOrDefault();



                if (!File.Exists(map_Path))
                {

                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                    SnackBar.Message = "Not A Valid PNG Image";
                    SnackBar.Show();
                    return;

                }
                else
                {
                        if (Path.GetExtension(map_Path).Contains("png"))
                        {
                            int imgwidth;
                            int imgheight;

                            using (var image = SixLabors.ImageSharp.Image.Load(map_Path))
                            {
                                imgwidth = image.Width;
                                imgheight = image.Height;
                            }

                            if (imgwidth < 2048 && imgheight < 2048)
                            {



                                BitmapImage map_ = new BitmapImage();
                                map_.BeginInit();

                                map_.UriSource = new Uri(map_Path);
                                map_.EndInit();
                                switch (DashedBorder.Name)
                                {
                                    case "Color_":
                                        break;
                                    case "Specular_":
                                        break;
                                    case "Glossiness_":
                                        break;
                                    case "Normal_":
                                        break;
                                    case "Ambient_":
                                        break;
                                    case "Cavity_":
                                        break;
                                    case "Emmision_":
                                        break;

                                    default:
                                        break;

                                }
                                DashedBorder.Background = new ImageBrush(map_);
                                DashedBorder.Tag = map_Path;
                                ImageNumber++;

                            }
                            else
                            {
                                SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                                SnackBar.Message = "Invalid Image Size!. Must be smaller than 2048 x 2048";
                                SnackBar.Show();
                                DashedBorder.Background = new ImageBrush();
                                return;

                            }
                        }

                }




            }

        }
                    catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }

}

        private void Skin_Map_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender.GetType() == typeof(HandyControl.Controls.DashedBorder))
            {

                HandyControl.Controls.DashedBorder DashedBorder = (HandyControl.Controls.DashedBorder)sender;
                    Console.WriteLine(DashedBorder.Name);

                    if (e.LeftButton == MouseButtonState.Pressed)
                {
                   
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
                        openFileDialog.RestoreDirectory = true;
                        if (openFileDialog.ShowDialog() == true)
                        {
                         string map_Path = openFileDialog.FileName;
                            if (!File.Exists(map_Path))
                            {

                                SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                                SnackBar.Message = "Not A Valid PNG Image";
                                SnackBar.Show();
                                return;

                            }
                            else
                            {

                                if (Path.GetExtension(map_Path).Contains("png"))
                                {
                                    int imgwidth;
                                    int imgheight;

                                    using (var image = SixLabors.ImageSharp.Image.Load(map_Path))
                                    {
                                        imgwidth = image.Width;
                                        imgheight = image.Height;
                                    }

                                    if (imgwidth < 2048 && imgheight < 2048)
                                    {


                                        BitmapImage map_ = new BitmapImage();
                                        map_.BeginInit();

                                        map_.UriSource = new Uri(map_Path);
                                        map_.EndInit();
                                        switch (DashedBorder.Name)
                                        {
                                            case "Color_":
                                                break;
                                            case "Specular_":
                                                break;
                                            case "Glossiness_":
                                                break;
                                            case "Normal_":
                                                break;
                                            case "Ambient_":
                                                break;
                                            case "Cavity_":
                                                break;
                                            case "Emmision_":
                                                break;

                                            default:
                                                break;

                                        }
                                        DashedBorder.Background = new ImageBrush(map_);
                                        DashedBorder.Tag = map_Path;
                                        ImageNumber++;
                                    }
                                    else
                                    {
                                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                                        SnackBar.Message = "Invalid Image Size!. Must be smaller than 2048 x 2048";
                                        SnackBar.Show();
                                        DashedBorder.Background = new ImageBrush();
                                        return;

                                    }
                                }


                                }

                        }
                        

                }
                else if (e.RightButton == MouseButtonState.Pressed)

                {

                    DashedBorder.Background = new ImageBrush();



                }
                }
            }
                    catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }
        void add_Progress()
        {
            
                int f = 100 / ImageNumber;
                Output_Bt_W_Progress.Progress = Output_Bt_W_Progress.Progress + f;
           
        }
        void  ProcessSkin()
        {
            
                try
               {
                
                    if (Skin_Name.Text == "")
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = "Skin Name Not Set!";
                        SnackBar.Show();
                        return;
                    }
                    if (SelectedWeapon == null || Items_List.SelectedItem == null)
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = "Item Not Set!";
                        SnackBar.Show();
                        return;
                    }
                    if (Output_Box.Text.Length == 0 && Output_Box.Text == null)
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = "Output path is not set!";
                        SnackBar.Show();
                        return;
                    }

                    if (Color_.Tag == null && Specular_.Tag == null && Normal_.Tag == null &&
                        Glossiness_.Tag == null && Ambient_.Tag == null && Cavity_.Tag == null &&
                        Emmision_.Tag == null)
                    {
                        SnackBar.Appearance = ControlAppearance.Danger;
                        SnackBar.Title = "ERROR";
                        SnackBar.Message = "Maps Are not Set!";
                        SnackBar.Show();
                        return;
                    }
                if (File.Exists(GetSkinPackRootPath()))
                {
                    try
                    {
                        File.Delete(GetSkinPackRootPath());
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }

                ZipArchive zipArchive = ZipFile.Open(GetSkinPackRootPath(), ZipArchiveMode.Create);


                int i = 0; 
                    if (Color_.Tag != null)
                    {
                        MagickImage colorImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Color_.Tag.ToString())));
                        if (SelectedWeapon == "Archer" || SelectedWeapon == "SMR" || SelectedWeapon == "DoubleTake" || (SelectedGame == "Titanfall2" && SelectedWeapon == "Volt") || SelectedWeapon == "Jack_gauntlet" || SelectedWeapon == "BroadSword" || SelectedWeapon == "ThermiteLauncher")
                        {
                            SaveTexture(SelectedWeapon + "_Default_col.dds", colorImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc7);
                        }
                        else if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                        {
                            colorImage.SetCompression(CompressionMethod.DXT1);
                            SaveTexture(SelectedWeapon + "_col.dds", colorImage, zipArchive);
                        }
                        else
                        {
                            colorImage.SetCompression(CompressionMethod.DXT1);
                            SaveTexture(SelectedWeapon + "_Default_col.dds", colorImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Rgba);
                        }
                        add_Progress();
                    }
               
                    if (Specular_.Tag != null)
                    {
                        MagickImage specularImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Specular_.Tag.ToString())));
                        if (SelectedWeapon == "DoubleTake" || (SelectedGame == "Titanfall2" && SelectedWeapon == "Volt") || SelectedWeapon == "BroadSword" || SelectedWeapon == "ThermiteLauncher")
                        {
                            SaveTexture(SelectedWeapon + "_Default_spc.dds", specularImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc7);
                        }
                        else if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                        {
                            specularImage.SetCompression(CompressionMethod.DXT1);
                            SaveTexture(SelectedWeapon + "_spc.dds", specularImage, zipArchive);
                        }
                        else
                        {
                            specularImage.SetCompression(CompressionMethod.DXT1);
                            SaveTexture(SelectedWeapon + "_Default_spc.dds", specularImage, zipArchive);
                        }
                        add_Progress();

                    }
               
                    if (Normal_.Tag != null)
                    {
                        MagickImage normalImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Normal_.Tag.ToString())));
                        if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                        {
                            SaveTexture(SelectedWeapon + "_nml.dds", normalImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc5);
                        }
                        else
                        {
                            SaveTexture(SelectedWeapon + "_Default_nml.dds", normalImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc5);
                        }
                        add_Progress();

                    }
              

                if (Glossiness_.Tag != null)
                {
                    MagickImage glossinessImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Glossiness_.Tag.ToString())));
                    if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                    {
                        SaveTexture(SelectedWeapon + "_gls.dds", glossinessImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc4);
                    }
                    else
                    {
                        SaveTexture(SelectedWeapon + "_Default_gls.dds", glossinessImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc4);
                    }
                    add_Progress();

                }
          
          
                if (Ambient_.Tag != null)
                {
                    MagickImage aoImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Ambient_.Tag.ToString())));
                    if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                    {
                        aoImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_ao.dds", aoImage, zipArchive);
                    }
                    else if (SelectedGame == "Titanfall2")
                    {
                        aoImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_Default_ao.dds", aoImage, zipArchive);
                    }
                    else if (SelectedGame == "Titanfall2" && SelectedWeapon == "Northstar")
                    {
                        SaveTexture(SelectedWeapon + "_Default_ao.dds", aoImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc7);
                    }
                    else
                    {
                        SaveTexture(SelectedWeapon + "_Default_ao.dds", aoImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc4);
                    }
                    add_Progress();

                }
            

            
                if (Cavity_.Tag != null)
                {
                    MagickImage cavityImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Cavity_.Tag.ToString())));
                    if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                    {
                        cavityImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_cav.dds", cavityImage, zipArchive);
                    }
                    else if (SelectedGame == "Titanfall2")
                    {
                        cavityImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_Default_cav.dds", cavityImage, zipArchive);
                    }

                    else
                    {
                        SaveTexture(SelectedWeapon + "_Default_cav.dds", cavityImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc4);
                    }
                    add_Progress();

                }
           
           
                if (Emmision_.Tag != null)
                {
                    MagickImage illuminationImage = new MagickImage(ImageToByteArray(System.Drawing.Image.FromFile(Emmision_.Tag.ToString())));
                    if (SelectedWeapon == "Northstar" || SelectedWeapon == "ION")
                    {
                        SaveTexture(SelectedWeapon + "_Default_ilm.dds", illuminationImage, zipArchive, BCnEncoder.Shared.CompressionFormat.Bc7);
                    }
                    else if (SelectedWeapon == "PhaseShift_fbody" || SelectedWeapon == "PhaseShift_gear" || SelectedWeapon == "PhaseShift_helmet" || SelectedWeapon == "PhaseShift_jumpkit" || SelectedWeapon == "PhaseShift_hair" || SelectedWeapon == "PhaseShift_viewhand" || SelectedWeapon == "PhaseShift_mbody" || SelectedWeapon == "Grapple_fbody" || SelectedWeapon == "Grapple_gear" || SelectedWeapon == "Grapple_helmet" || SelectedWeapon == "Grapple_jumpkit" || SelectedWeapon == "Grapple_gauntlet" || SelectedWeapon == "Grapple_mbody" || SelectedWeapon == "PulseBlade_fbody" || SelectedWeapon == "PulseBlade_gear" || SelectedWeapon == "PulseBlade_helmet" || SelectedWeapon == "PulseBlade_jumpkit" || SelectedWeapon == "PulseBlade_gauntlet" || SelectedWeapon == "PulseBlade_mbody" || SelectedWeapon == "HoloPilot_fbody" || SelectedWeapon == "HoloPilot_gear" || SelectedWeapon == "HoloPilot_helmet" || SelectedWeapon == "HoloPilot_jumpkit" || SelectedWeapon == "HoloPilot_viewhands" || SelectedWeapon == "HoloPilot_mbody" || SelectedWeapon == "Cloak_fbody" || SelectedWeapon == "Cloak_gear" || SelectedWeapon == "Cloak_helmet" || SelectedWeapon == "Cloak_jumpkit" || SelectedWeapon == "Cloak_gauntlet" || SelectedWeapon == "Cloak_mbody" || SelectedWeapon == "Cloak_ghillie" || SelectedWeapon == "AWall_fbody" || SelectedWeapon == "AWall_gear" || SelectedWeapon == "AWall_helmet" || SelectedWeapon == "AWall_jumpkit" || SelectedWeapon == "AWall_gauntlet" || SelectedWeapon == "AWall_mbody" || SelectedWeapon == "Stim_fbody" || SelectedWeapon == "Stim_gear" || SelectedWeapon == "Stim_fgear" || SelectedWeapon == "Stim_head" || SelectedWeapon == "Stim_jumpkit" || SelectedWeapon == "Stim_fjumpkit" || SelectedWeapon == "Stim_gauntlet" || SelectedWeapon == "Stim_mbody" || SelectedWeapon == "Jack_gauntlet")
                    {
                        illuminationImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_ilm.dds", illuminationImage, zipArchive);
                    }

                    else
                    {
                        illuminationImage.SetCompression(CompressionMethod.DXT1);
                        SaveTexture(SelectedWeapon + "_Default_ilm.dds", illuminationImage, zipArchive);
                    }
                    add_Progress();

                }
            
                    SnackBar.Appearance = ControlAppearance.Success;
                    SnackBar.Title = "SUCCESS";
                    SnackBar.Message = "Generated The Skin Successfully!";
                    SnackBar.Show();
                    Zip_Box.Text = Current_Mod_To_Pack;
                zipArchive.Dispose();


            }
                catch (Exception ex)
                {
                   
                        SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = "ERROR";
                    SnackBar.Message = ex.Message;
                    SnackBar.Show();
                    Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

                }





        }
    public void DispatchIfNecessary(Action action)
        {
            if (!Dispatcher.CheckAccess())
                Dispatcher.Invoke(action);
            else
                action.Invoke();
        }
        private void Output_Bt_W_Progress_Click(object sender, RoutedEventArgs e)
        {
            
                ProcessSkin();


          
           

        }


        private string GetSkinPackRootPath()
        {
            string f = null;
            DispatchIfNecessary(() => {
                f = Output_Directory.Text + "\\" + SelectedWeapon + "_" + Skin_Name.Text + ".zip";
            });
            return f;
        }
        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (var _memorystream = new MemoryStream())
            {
                image.Save(_memorystream, image.RawFormat);
                return _memorystream.ToArray();
            }
        }

        private void SaveTexture(string filename, MagickImage image, ZipArchive archive, BCnEncoder.Shared.CompressionFormat compression = BCnEncoder.Shared.CompressionFormat.Rgba)
        {
            int[] WidthSize = new int[] {
                4096,
                2048,
                1024,
                512
            };
            int[] HeightSize = new int[] {
                4096,
                2048,
                1024,
                512,
                256
            };

            var Info = new MagickImageInfo(image.ToByteArray());
            //All set to 1 for Titanfall2
            //I forget about the APEX,but I still remember APEX have that 4096
            //May be will fix it in the future:D
            //I found that pilot texture can use it:(
            int WidthCheck = 1;
            int HightCheck = 1;
            switch (Info.Width)
            {
                case 4096:
                    WidthCheck = 0;
                    HightCheck = 0;
                    break;
                case 2048:
                    WidthCheck = 1;
                    HightCheck = 1;
                    break;
                case 1024:
                    WidthCheck = 2;
                    HightCheck = 2;
                    break;
                case 512:
                    WidthCheck = 3;
                    HightCheck = 3;
                    break;
            }
            if (Info.Width != Info.Height)
            {
                HightCheck++;
            }

            for (int i = WidthCheck, j = HightCheck; i <= 3; i++, j++)
            {
                ZipArchiveEntry entry = archive.CreateEntry("contents/" + WidthSize[i].ToString() + "/" + filename);
                using (Stream s = entry.Open())
                {
                    image.Scale(WidthSize[i], HeightSize[j]);
                    if (compression != BCnEncoder.Shared.CompressionFormat.Rgba)
                    {
                        image.Format = MagickFormat.Png32;
                        image.SetCompression(CompressionMethod.NoCompression);
                        BcEncoder encoder = new BcEncoder();
                        encoder.OutputOptions.GenerateMipMaps = false;
                        encoder.OutputOptions.Format = compression;
                        encoder.OutputOptions.FileFormat = BCnEncoder.Shared.OutputFileFormat.Dds;
                        encoder.EncodeToStream(image.ToByteArray(MagickFormat.Rgba), WidthSize[i], HeightSize[j], BCnEncoder.Encoder.PixelFormat.Rgba32, s);
                    }
                    else
                    {
                        DdsWriteDefines ddsDefines = new DdsWriteDefines();
                        ddsDefines.Compression = DdsCompression.Dxt1;
                        ddsDefines.Mipmaps = 0;

                        image.Format = MagickFormat.Dds;
                        image.Settings.SetDefines(ddsDefines);

                        image.Write(s);
                    }

                    s.Flush();
                    s.Close();
                }
            }
        }
        private void Items_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SelectedWeapon = Items_List.SelectedItem.ToString();






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (!Directory.Exists(dialog.SelectedPath))
                {
                    //Send_Error_Notif("Not An Output Directory");
                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = "ERROR";
                    SnackBar.Message = "Not An Output Directory";
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;

                }
                else
                    Output_Directory.Text = dialog.SelectedPath;

                }
            }
        }
    }
