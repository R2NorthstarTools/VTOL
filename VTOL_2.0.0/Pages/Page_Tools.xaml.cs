using BCnEncoder.Encoder;
using Downloader;
using ImageMagick;
using ImageMagick.Formats;
using Microsoft.Win32;
using Pfim;
using Serilog;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Wpf.Ui.Common;
using Brushes = System.Windows.Media.Brushes;
using Exception = System.Exception;
using Image = SixLabors.ImageSharp.Image;
using Path = System.IO.Path;
using PixelFormat = System.Drawing.Imaging.PixelFormat;
using ZipFile = System.IO.Compression.ZipFile;
using ZipFile_ = Ionic.Zip.ZipFile;

namespace VTOL.Pages
{
    /// <summary>
    /// Interaction logic for Page_Tools.xaml
    /// </summary>
    /// 
    public class Head
    {
        public Head()
        {
            this.Items = new ObservableCollection<Tail>();
        }

        public string Name { get; set; }
        public int SubDirCount { get; set; }

        public ObservableCollection<Tail> Items { get; set; }
    }

    public class Tail
    {
        public string Name { get; set; }
        public int size { get; set; }

    }
    internal class DdsHandler
    {
        // dds file structure
        char[] magic = new char[4];
        // header
        UInt32 size;
        UInt32 flags;
        UInt32 height;
        UInt32 width;
        UInt32 pitchOrLinearSize;
        UInt32 depth;
        UInt32 mipMapCount;
        char[] reserved = new char[44];
        // header -> pixel format
        UInt32 pixel_Size;
        UInt32 pixel_Flags;
        char[] pixel_FourCC = new char[4];
        UInt32 pixel_RGBBitCount;
        UInt32 pixel_rBitMask;
        UInt32 pixel_gBitMask;
        UInt32 pixel_bBitMask;
        UInt32 pixel_aBitMask;
        // header again
        UInt32 caps;
        UInt32 caps2;
        UInt32 caps3;
        UInt32 caps4;
        UInt32 reserved1;
        // dx10 header
        DXGI_FORMAT dxgiFormat;
        DX10ResourceDimension resourceDimension;
        UInt32 miscFlags;
        UInt32 arraySize;
        DX10AlphaMode alphaMode;

        // other variables
        bool isDX10;
        byte[] data; // just everything else thats not in the header


        public DdsHandler(string path)
        {
            BinaryReader reader = new(new FileStream(path, FileMode.Open));
            try
            {
                // read magic
                magic = reader.ReadChars(4);
                if (new string(magic) != "DDS ")
                {
                    throw new Exception("File is not a valid DDS file at path " + path);
                }
                // read header
                size = reader.ReadUInt32();
                flags = reader.ReadUInt32();
                height = reader.ReadUInt32();
                width = reader.ReadUInt32();
                pitchOrLinearSize = reader.ReadUInt32();
                depth = reader.ReadUInt32();
                mipMapCount = reader.ReadUInt32();
                reserved = reader.ReadChars(44);
                pixel_Size = reader.ReadUInt32();
                pixel_Flags = reader.ReadUInt32();
                pixel_FourCC = reader.ReadChars(4);
                pixel_RGBBitCount = reader.ReadUInt32();
                pixel_rBitMask = reader.ReadUInt32();
                pixel_gBitMask = reader.ReadUInt32();
                pixel_bBitMask = reader.ReadUInt32();
                pixel_aBitMask = reader.ReadUInt32();
                caps = reader.ReadUInt32();
                caps2 = reader.ReadUInt32();
                caps3 = reader.ReadUInt32();
                caps4 = reader.ReadUInt32();
                reserved1 = reader.ReadUInt32();
                // read extra header if needed
                isDX10 = new string(pixel_FourCC) == "DX10";
                if (isDX10)
                {
                    dxgiFormat = (DXGI_FORMAT)reader.ReadUInt32();
                    resourceDimension = (DX10ResourceDimension)reader.ReadUInt32();
                    miscFlags = reader.ReadUInt32();
                    arraySize = reader.ReadUInt32();
                    alphaMode = (DX10AlphaMode)reader.ReadUInt32();
                }
                // read rest of data
                // potentially losing data here if length > max int value?
                data = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
            }
            finally
            {
                reader.Close();
            }
        }
        public void Convert()
        {
            string str_fourCC = new(pixel_FourCC);
            // this is required by the game (and legion) to read things properly, but sometimes it isn't set
            if (pitchOrLinearSize == 0)
                pitchOrLinearSize = (uint)data.Length;

            switch (str_fourCC)
            {
                case "DXT1":
                    ToDX10(DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB);
                    break;
                case "ATI2":
                case "BC5U":
                    pixel_FourCC = new char[4] { 'B', 'C', '5', 'U' };
                    if ((flags & 0x000A0000) != 0x000A0000)
                        flags |= 0x000A0000;
                    break;
                case "BC4U":
                    //ToDX10(DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM);
                    if ((flags & 0x000A0000) != 0x000A0000)
                        flags |= 0x000A0000;
                    if ((caps & 0x00400000) != 0x00400000)
                        caps |= 0x00400000;
                    if ((caps & 0x00000008) != 0x00000008)
                        caps |= 0x00000008;
                    break;
                case "DX10":
                    break;

                default:
                    throw new NotImplementedException("DDS fourCC not supported: " + str_fourCC);
            }
        }

        public void ToDX10(DXGI_FORMAT format)
        {
            dxgiFormat = format;
            arraySize = 1;
            resourceDimension = DX10ResourceDimension.Texture2D;
            alphaMode = DX10AlphaMode.Unknown;
            miscFlags = 0;
            pixel_FourCC = new char[4] { 'D', 'X', '1', '0' };
            isDX10 = true;
        }

        public void Save(string path)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            BinaryWriter writer = new(new FileStream(path, FileMode.Create));
            try
            {
                // write magic
                writer.Write(magic);
                // write header
                writer.Write(size);
                writer.Write(flags);
                writer.Write(height);
                writer.Write(width);
                writer.Write(pitchOrLinearSize);
                writer.Write(depth);
                writer.Write(mipMapCount);
                writer.Write(reserved);
                writer.Write(pixel_Size);
                writer.Write(pixel_Flags);
                writer.Write(pixel_FourCC);
                writer.Write(pixel_RGBBitCount);
                writer.Write(pixel_rBitMask);
                writer.Write(pixel_gBitMask);
                writer.Write(pixel_bBitMask);
                writer.Write(pixel_aBitMask);
                writer.Write(caps);
                writer.Write(caps2);
                writer.Write(caps3);
                writer.Write(caps4);
                writer.Write(reserved1);
                // write dx10 header if needed
                if (isDX10)
                {
                    writer.Write((UInt32)dxgiFormat);
                    writer.Write((UInt32)resourceDimension);
                    writer.Write(miscFlags);
                    writer.Write(arraySize);
                    writer.Write((UInt32)alphaMode);
                }
                // write raw data
                writer.Write(data);
            }
            finally
            {
                writer.Close();
            }
        }


        public enum DXGI_FORMAT : UInt32
        {
            DXGI_FORMAT_UNKNOWN,
            DXGI_FORMAT_R32G32B32A32_TYPELESS,
            DXGI_FORMAT_R32G32B32A32_FLOAT,
            DXGI_FORMAT_R32G32B32A32_UINT,
            DXGI_FORMAT_R32G32B32A32_SINT,
            DXGI_FORMAT_R32G32B32_TYPELESS,
            DXGI_FORMAT_R32G32B32_FLOAT,
            DXGI_FORMAT_R32G32B32_UINT,
            DXGI_FORMAT_R32G32B32_SINT,
            DXGI_FORMAT_R16G16B16A16_TYPELESS,
            DXGI_FORMAT_R16G16B16A16_FLOAT,
            DXGI_FORMAT_R16G16B16A16_UNORM,
            DXGI_FORMAT_R16G16B16A16_UINT,
            DXGI_FORMAT_R16G16B16A16_SNORM,
            DXGI_FORMAT_R16G16B16A16_SINT,
            DXGI_FORMAT_R32G32_TYPELESS,
            DXGI_FORMAT_R32G32_FLOAT,
            DXGI_FORMAT_R32G32_UINT,
            DXGI_FORMAT_R32G32_SINT,
            DXGI_FORMAT_R32G8X24_TYPELESS,
            DXGI_FORMAT_D32_FLOAT_S8X24_UINT,
            DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,
            DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
            DXGI_FORMAT_R10G10B10A2_TYPELESS,
            DXGI_FORMAT_R10G10B10A2_UNORM,
            DXGI_FORMAT_R10G10B10A2_UINT,
            DXGI_FORMAT_R11G11B10_FLOAT,
            DXGI_FORMAT_R8G8B8A8_TYPELESS,
            DXGI_FORMAT_R8G8B8A8_UNORM,
            DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
            DXGI_FORMAT_R8G8B8A8_UINT,
            DXGI_FORMAT_R8G8B8A8_SNORM,
            DXGI_FORMAT_R8G8B8A8_SINT,
            DXGI_FORMAT_R16G16_TYPELESS,
            DXGI_FORMAT_R16G16_FLOAT,
            DXGI_FORMAT_R16G16_UNORM,
            DXGI_FORMAT_R16G16_UINT,
            DXGI_FORMAT_R16G16_SNORM,
            DXGI_FORMAT_R16G16_SINT,
            DXGI_FORMAT_R32_TYPELESS,
            DXGI_FORMAT_D32_FLOAT,
            DXGI_FORMAT_R32_FLOAT,
            DXGI_FORMAT_R32_UINT,
            DXGI_FORMAT_R32_SINT,
            DXGI_FORMAT_R24G8_TYPELESS,
            DXGI_FORMAT_D24_UNORM_S8_UINT,
            DXGI_FORMAT_R24_UNORM_X8_TYPELESS,
            DXGI_FORMAT_X24_TYPELESS_G8_UINT,
            DXGI_FORMAT_R8G8_TYPELESS,
            DXGI_FORMAT_R8G8_UNORM,
            DXGI_FORMAT_R8G8_UINT,
            DXGI_FORMAT_R8G8_SNORM,
            DXGI_FORMAT_R8G8_SINT,
            DXGI_FORMAT_R16_TYPELESS,
            DXGI_FORMAT_R16_FLOAT,
            DXGI_FORMAT_D16_UNORM,
            DXGI_FORMAT_R16_UNORM,
            DXGI_FORMAT_R16_UINT,
            DXGI_FORMAT_R16_SNORM,
            DXGI_FORMAT_R16_SINT,
            DXGI_FORMAT_R8_TYPELESS,
            DXGI_FORMAT_R8_UNORM,
            DXGI_FORMAT_R8_UINT,
            DXGI_FORMAT_R8_SNORM,
            DXGI_FORMAT_R8_SINT,
            DXGI_FORMAT_A8_UNORM,
            DXGI_FORMAT_R1_UNORM,
            DXGI_FORMAT_R9G9B9E5_SHAREDEXP,
            DXGI_FORMAT_R8G8_B8G8_UNORM,
            DXGI_FORMAT_G8R8_G8B8_UNORM,
            DXGI_FORMAT_BC1_TYPELESS,
            DXGI_FORMAT_BC1_UNORM,
            DXGI_FORMAT_BC1_UNORM_SRGB,
            DXGI_FORMAT_BC2_TYPELESS,
            DXGI_FORMAT_BC2_UNORM,
            DXGI_FORMAT_BC2_UNORM_SRGB,
            DXGI_FORMAT_BC3_TYPELESS,
            DXGI_FORMAT_BC3_UNORM,
            DXGI_FORMAT_BC3_UNORM_SRGB,
            DXGI_FORMAT_BC4_TYPELESS,
            DXGI_FORMAT_BC4_UNORM,
            DXGI_FORMAT_BC4_SNORM,
            DXGI_FORMAT_BC5_TYPELESS,
            DXGI_FORMAT_BC5_UNORM,
            DXGI_FORMAT_BC5_SNORM,
            DXGI_FORMAT_B5G6R5_UNORM,
            DXGI_FORMAT_B5G5R5A1_UNORM,
            DXGI_FORMAT_B8G8R8A8_UNORM,
            DXGI_FORMAT_B8G8R8X8_UNORM,
            DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,
            DXGI_FORMAT_B8G8R8A8_TYPELESS,
            DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
            DXGI_FORMAT_B8G8R8X8_TYPELESS,
            DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,
            DXGI_FORMAT_BC6H_TYPELESS,
            DXGI_FORMAT_BC6H_UF16,
            DXGI_FORMAT_BC6H_SF16,
            DXGI_FORMAT_BC7_TYPELESS,
            DXGI_FORMAT_BC7_UNORM,
            DXGI_FORMAT_BC7_UNORM_SRGB,
            DXGI_FORMAT_AYUV,
            DXGI_FORMAT_Y410,
            DXGI_FORMAT_Y416,
            DXGI_FORMAT_NV12,
            DXGI_FORMAT_P010,
            DXGI_FORMAT_P016,
            DXGI_FORMAT_420_OPAQUE,
            DXGI_FORMAT_YUY2,
            DXGI_FORMAT_Y210,
            DXGI_FORMAT_Y216,
            DXGI_FORMAT_NV11,
            DXGI_FORMAT_AI44,
            DXGI_FORMAT_IA44,
            DXGI_FORMAT_P8,
            DXGI_FORMAT_A8P8,
            DXGI_FORMAT_B4G4R4A4_UNORM,
            DXGI_FORMAT_P208,
            DXGI_FORMAT_V208,
            DXGI_FORMAT_V408,
            DXGI_FORMAT_FORCE_UINT,
        };

        enum DX10ResourceDimension : UInt32
        {
            Unknown = 0,
            Buffer = 1,
            Texture1D = 2,
            Texture2D = 3,
            Texture3D = 4,
        };

        enum DX10AlphaMode : UInt32
        {
            Unknown = 0,
            Straight = 1,
            PreMultiplied = 2,
            Opaque = 3,
            Custom = 4,
        };

    }
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
        public string Tools_Dir;


        public Page_Tools()
        {
            InitializeComponent();
            try
            {
                string defualt_repak = @"for %%i in (" + '\u0022' + @"%~dp0maps\*" + '\u0022' + ")  do " + '\u0022' + @"% ~dp0RePak.exe" + '\u0022' + " " + '\u0022' + "%%i" + '\u0022' + Environment.NewLine + "pause";
                if (Properties.Settings.Default.RePak_Launch_Args == "" || Properties.Settings.Default.RePak_Launch_Args == null)
                {
                    Startup_Args_RpAk.Text = defualt_repak;
                    Properties.Settings.Default.RePak_Launch_Args = defualt_repak;
                    Properties.Settings.Default.Save();
                }
                Startup_Args_RpAk.Text = Properties.Settings.Default.RePak_Launch_Args;

                SnackBar = Main.Snackbar;
                Mod_dependencies.Text = "northstar-Northstar-" + Properties.Settings.Default.Version.Remove(0, 1);
                Paragraph paragraph = new Paragraph();
                Description_Box.Document.Blocks.Clear();
                Skin_Mod_Pack_Check.IsChecked = Properties.Settings.Default.PackageAsSkin;
                Run run = new Run(@"#PLACEHOLDER_SKIN_NAME

    YOUR DESCRIPTION
//Example image, remove me before publishing!
//![Imgur](https://i.imgur.com/hdnNWZQ.jpeg)");
                Mod_Adv_Repak_Path = Properties.Settings.Default.REpak_Folder_Path;
                //Zip_Box_Advocate_Copy.Text = Mod_Adv_Repak_Path;

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


                //List<Head> Git_Items = new List<Head>();

                //Head Head_Item = new Head() { Name = "The Doe's", SubDirCount = 3 };
                //Head_Item.Items.Add(new Tail() { Name = "John Doe", size = 42 });
                //Head_Item.Items.Add(new Tail() { Name = "Jane Doe", size = 39 });
                //Head_Item.Items.Add(new Tail() { Name = "Sammy Doe", size = 13 });
                //Git_Items.Add(Head_Item);

                //Head Tail_Items = new Head() { Name = "The Moe's", SubDirCount = 2 };
                //Tail_Items.Items.Add(new Tail() { Name = "Mark Moe", size = 31 });
                //Tail_Items.Items.Add(new Tail() { Name = "Norma Moe", size = 28 });
                //Git_Items.Add(Tail_Items);

                //Git_TreeView.ItemsSource = Git_Items;


                ListCollectionView lcv = new ListCollectionView(items);
                lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));

                Items_List.ItemsSource = lcv;
                Output_Directory.Text = Environment.CurrentDirectory;
                Output_Box.Text = Environment.CurrentDirectory;
                Tools_Dir = Main.User_Settings_Vars.NorthstarInstallLocation + @"VTOL_ExternalTools\";
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
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
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Zip_Click_InvalidZipFound;
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
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Zip_Click_ValidZipFound;
                            SnackBar.Show();
                            Zip_Box.Text = Current_Mod_To_Pack;
                            Zip_Box.Background = Brushes.Transparent;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}" + ex.Message + Environment.NewLine + "From - ");
                //Removed PaperTrailSystem Due to lack of reliability.
            }
        }

        private void Output_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (!Directory.Exists(dialog.SelectedPath))
                {
                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Output_Button_Click_NotAnOutputDirectory;
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;

                }
                else
                {
                    Current_Output_Dir = dialog.SelectedPath;

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
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_create_Manifest_OneOfTheManifestInputsAreEmpty;
                    SnackBar.Show();
                    return;

                }
                else
                {
                    string Output = "";
                    if (Mod_dependencies.Text != null || Mod_dependencies.Text != "")
                    {

                        Output = @"{
    ""name"": " + '\u0022' + Mod_name.Text.Trim().Replace(" ", "_") + '\u0022' + @",
    ""version_number"":" + '\u0022' + Mod_version_number.Text.Trim() + '\u0022' + @",
    ""website_url"": " + '\u0022' + Mod_website_url.Text.Trim() + '\u0022' + @",
    ""description"": " + '\u0022' + Mod_description.Text.Trim() + '\u0022' + @",
    ""dependencies"": [" + '\u0022' + Mod_dependencies.Text + '\u0022' + "]" +
      "\n}";
                    }
                    else
                    {
                        Output = @"{
    ""name"": " + '\u0022' + Mod_name.Text.Trim().Replace(" ", "_") + '\u0022' + @",
    ""version_number"":" + '\u0022' + Mod_version_number.Text.Trim() + '\u0022' + @",
    ""website_url"": " + '\u0022' + Mod_website_url.Text.Trim() + '\u0022' + @",
    ""description"": " + '\u0022' + Mod_description.Text.Trim() + '\u0022' + @",
    ""dependencies"":" + '\u0022' + "[" + '\u0022' + "northstar-Northstar-" + Properties.Settings.Default.Version.Remove(0, 1) + '\u0022' + "]" +
               "\n}";
                    }
                    saveAsyncFile(Output, Output_Folder + @"\" + "manifest.json", false, false);

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
        public bool TryDeleteDirectory(
string directoryPath, bool overwrite = true,
int maxRetries = 10,
int millisecondsDelay = 300)
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
        public bool TryCreateDirectory(
   string directoryPath,
   int maxRetries = 10,
   int millisecondsDelay = 200)
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
        public bool TryMoveFile(
   string Origin, string Destination, bool overwrite = true,
   int maxRetries = 10,
   int millisecondsDelay = 200)
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
        public bool TryCopyFile(
  string Origin, string Destination, bool overwrite = true,
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
                            TryCreateDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim());
                            if (Directory.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim()))
                            {
                                GenerateThumbImage(Mod_Icon_Path, Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "icon.png", 256, 256);



                                create_Manifest(Current_Output_Dir + @"\" + Mod_name.Text.Trim());
                                TextRange Description = new TextRange(
                                // TextPointer to the start of content in the RichTextBox.
                                Description_Box.Document.ContentStart,
                                // TextPointer to the end of content in the RichTextBox.
                                Description_Box.Document.ContentEnd);
                                saveAsyncFile(Description.Text, Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "README.md", false, false);
                                if (Skin_Mod_Pack_Check.IsChecked == true)
                                {
                                    if (!Directory.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\"))
                                    {
                                        TryCreateDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\");
                                    }
                                    TryCopyFile(Current_Mod_To_Pack, Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\" + Dir.Name, true);


                                }
                                else
                                {
                                    if (!Directory.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\"))
                                    {
                                        TryCreateDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\");

                                    }
                                    ZipFile_ zipFile = new ZipFile_(Current_Mod_To_Pack);

                                    zipFile.ExtractAll(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + @"\" + "mods" + @"\", Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

                                }

                                if (File.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip"))
                                {
                                    File.Delete(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip");
                                    ZipFile_ zipFile = new ZipFile_();
                                    zipFile.AddDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim());
                                    zipFile.Save(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip");
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
                            SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Save_Mod_Click_NoValidOutputPathFound;
                            SnackBar.Show();
                            Output_Box.Background = Brushes.IndianRed;

                            return;

                        }

                        if (File.Exists(Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip"))
                        {
                            TryDeleteDirectory(Current_Output_Dir + @"\" + Mod_name.Text.Trim(), true);
                        }
                        SnackBar.Appearance = ControlAppearance.Success;
                        SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Save_Mod_Click_SuccessfullyPackedAllItemsTo + Current_Output_Dir + @"\" + Mod_name.Text.Trim() + ".zip";
                        SnackBar.Show();
                    }
                    else
                    {
                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Save_Mod_Click_NoValidModICONFound;
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
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Save_Mod_Click_NoValidZipFileToPackWasFound;
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                //Removed PaperTrailSystem Due to lack of reliability.
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
                            SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
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
                                    SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ValidImageFoundAt + Mod_Icon_Path;
                                    SnackBar.Show();
                                    BitmapImage Mod_Icon = new BitmapImage();
                                    Mod_Icon.BeginInit();

                                    Mod_Icon.UriSource = new Uri(Mod_Icon_Path);
                                    Mod_Icon.EndInit();


                                }
                                else
                                {
                                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_InvalidImageSizeMustBe256x256;
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
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ThatWasNotAProperPNG;
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
        void Process_Image(string path, string dir_out_)
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
                //Removed PaperTrailSystem Due to lack of reliability.
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
                            SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
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
                                    SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ValidImageFoundAt + Mod_Icon_Path;
                                    SnackBar.Show();
                                    BitmapImage Mod_Icon = new BitmapImage();
                                    Mod_Icon.BeginInit();

                                    Mod_Icon.UriSource = new Uri(Mod_Icon_Path);
                                    Mod_Icon.EndInit();

                                    Image_Icon.Background = new ImageBrush(Mod_Icon);

                                }
                                else
                                {
                                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_InvalidImageSizeMustBe256x256;
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
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ThatWasNotAProperPNG;
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
            try
            {
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
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
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

                                if (imgwidth == 256 && imgheight == 256)
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
                                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_InvalidImageSizeMustBe256x256;
                                    SnackBar.Show();
                                    DashedBorder.Background = new ImageBrush();
                                    return;

                                }
                            }
                            else
                            {
                                SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Image_Icon_Drop_InvalidImageSizeMustBeSmallerThan2048X2048;
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
                //Removed PaperTrailSystem Due to lack of reliability.
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
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
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
                                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Image_Icon_Drop_InvalidImageSizeMustBeSmallerThan2048X2048;
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
                //Removed PaperTrailSystem Due to lack of reliability.
            }
        }
        void add_Progress()
        {

            int f = 100 / ImageNumber;
            Output_Bt_W_Progress.Progress = Output_Bt_W_Progress.Progress + f;

        }
        void ProcessSkin()
        {

            try
            {

                if (Skin_Name.Text == "")
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_ProcessSkin_SkinNameNotSet;
                    SnackBar.Show();
                    return;
                }
                if (SelectedWeapon == null || Items_List.SelectedItem == null)
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_ProcessSkin_ItemNotSet;
                    SnackBar.Show();
                    return;
                }
                if (Output_Box.Text.Length == 0 && Output_Box.Text == null)
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_ProcessSkin_OutputPathIsNotSet;
                    SnackBar.Show();
                    return;
                }

                if (Color_.Tag == null && Specular_.Tag == null && Normal_.Tag == null &&
                    Glossiness_.Tag == null && Ambient_.Tag == null && Cavity_.Tag == null &&
                    Emmision_.Tag == null)
                {
                    SnackBar.Appearance = ControlAppearance.Danger;
                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_ProcessSkin_MapsAreNotSet;
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
                        Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

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
                SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_ProcessSkin_GeneratedTheSkinSuccessfully;
                SnackBar.Show();
                Zip_Box.Text = Current_Mod_To_Pack;
                zipArchive.Dispose();


            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
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
            DispatchIfNecessary(async () =>
            {
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
        //TODO Treenode
        //private void ExecuteOnDemandLoading(object obj)
        //{
        //    var node = obj as TreeViewNode;

        //    // Skip the repeated population of child items when every time the node expands.
        //    if (node.ChildNodes.Count > 0)
        //    {
        //        node.IsExpanded = true;
        //        return;
        //    }

        //    //Animation starts for expander to show progressing of load on demand
        //    node.ShowExpanderAnimation = true;
        //    var sfTreeView = Application.Current.MainWindow.FindName("sfTreeView") as SfTreeView;
        //    sfTreeView.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
        //    {
        //        currentNode = node;
        //        timer.Start();
        //    }));
        //}
        //private bool CanExecuteOnDemandLoading(object sender)
        //{
        //    var hasChildNodes = ((sender as TreeViewNode).Content as Data_Tree).HasChildNodes;
        //    if (hasChildNodes)
        //        return true;
        //    else
        //        return false;
        //}
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
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Output_Button_Click_NotAnOutputDirectory;
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;

                }
                else
                    Output_Directory.Text = dialog.SelectedPath;

            }
        }




        ///////////////////////ADVOCATE TOOL/////////////////////////////////////////////
        ///CREATED BY https://github.com/ASpoonPlaysGames?tab=repositories 
        ///Full authorazation has been given from the creator
        ///





        string Mod_Adv_Icon_Path;
        string Mod_Adv_Skin_Path;
        string Mod_Adv_Repak_Path;
        string Mod_Adv_Author_name;
        string Mod_Adv_Version_Num;
        string Mod_Adv_Skin_Name;
        string Mod_Adv_Output_Path;
        //public void Convert()
        //{
        //    try {

        //        //Mod_Adv_Version_Num = Mod_version_number_Advocate.Text;
        //        //Mod_Adv_Author_name = Mod_Author_Name_Advocate.Text;
        //        //Mod_Adv_Skin_Name = Mod_Skin_Name_Advocate.Text;

        //    if(Mod_Adv_Author_name == null || Mod_Adv_Author_name == "" || Mod_Adv_Author_name.Count() < 2)
        //    {
        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Author Name Is Minimum 2 Letters";
        //        SnackBar.Show();
        //    }
        //    if (Mod_Adv_Version_Num == null || Mod_Adv_Version_Num == "" || Mod_Adv_Version_Num.Count() < 2 || !Regex.Match(Mod_Adv_Version_Num, "^\\d+.\\d+.\\d+$").Success)
        //    {
        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Version Number Is Invalid";
        //        SnackBar.Show();
        //    }
        //    if (Mod_Adv_Skin_Name == null || Mod_Adv_Skin_Name == "" || Mod_Adv_Skin_Name.Count() < 2)
        //    {
        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Skin Name Is Is Invalid";
        //        SnackBar.Show();
        //    }

        //        //if (Description_Box_Advocate.Document.Blocks.Count < 1)
        //        //{
        //        //    SnackBar.Appearance = ControlAppearance.Danger;
        //        //    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        //    SnackBar.Message = "Description Is Invalid";
        //        //    SnackBar.Show();
        //        //}
        //        if (!File.Exists(Mod_Adv_Skin_Path))
        //    {


        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Skin Content Is Invalid!";
        //        SnackBar.Show();
        //        return;
        //    }
        //    if (!Directory.Exists(Mod_Adv_Output_Path))
        //    {



        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Output Path Is Invalid!";
        //        SnackBar.Show();
        //        return;
        //    }
        //    if (!File.Exists(Mod_Adv_Repak_Path))
        //    {




        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "RePak Path Is Invalid!";
        //        SnackBar.Show();
        //        return;
        //    }
        //    if (!File.Exists(Mod_Adv_Icon_Path))
        //    {



        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = "Icon Content Is Invalid!";
        //        SnackBar.Show();
        //        return;
        //    }

        //        // the temp path is appended with the current date and time to prevent duplicates
        //        string tempFolderPath = Path.GetTempPath() + "/Advocate/" + DateTime.Now.ToString("yyyyMMdd-THHmmss");
        //        string skinTempFolderPath = Path.GetFullPath(tempFolderPath + "/Skin");
        //        string modTempFolderPath = Path.GetFullPath(tempFolderPath + "/Mod");
        //        string repakTempFolderPath = Path.GetFullPath(tempFolderPath + "/RePak");

        //        // try convert stuff, if we get a weird exception, don't crash preferably
        //        try
        //    {
        //        /////////////////////////////
        //        // create temp directories //
        //        /////////////////////////////

        //            //
        //        // directory for unzipped file
        //       TryCreateDirectory(skinTempFolderPath);

        //        // directory for TS-compliant mod
        //       TryCreateDirectory(modTempFolderPath);

        //        // directory for RePak things
        //       TryCreateDirectory(repakTempFolderPath);


        //        ///////////////////////////////
        //        // unzip skin to temp folder //
        //        ///////////////////////////////


        //        try
        //        {
        //            ZipFile.ExtractToDirectory(Mod_Adv_Skin_Path, skinTempFolderPath, true);
        //        }
        //        catch (InvalidDataException ex)
        //            {
        //                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

        //                SnackBar.Appearance = ControlAppearance.Danger;
        //            SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //            SnackBar.Message = "Unable to unzip skin!";
        //            SnackBar.Show();
        //            return;

        //        }


        //        ////////////////////////////////////
        //        // create temp mod file structure //
        //        ////////////////////////////////////


        //       TryCreateDirectory(modTempFolderPath + "\\packages\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + "\\paks");


        //        /////////////////////
        //        // create icon.png //
        //        /////////////////////

        //        if (Mod_Adv_Icon_Path == "")
        //        {
        //            // fuck you, im using the col of the first folder i find, shouldve specified an icon path
        //            string[] skinPaths = Directory.GetDirectories(skinTempFolderPath);
        //            if (skinPaths.Length == 0)
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "No Skins found in zip!";
        //                SnackBar.Show();
        //                return;
        //            }
        //            string[] resolutions = Directory.GetDirectories(skinPaths[0]);
        //            if (resolutions.Length == 0)
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "No Skins found in zip!";
        //                SnackBar.Show();
        //                return;
        //            }
        //            // find highest resolution folder
        //            int highestRes = 0;
        //            foreach (string resolution in resolutions)
        //            {
        //                string? thing = Path.GetFileName(resolution);
        //                // check if higher than highestRes and a power of 2
        //                if (int.TryParse(thing, out int res) && res > highestRes && (highestRes & (highestRes - 1)) == 0)
        //                {
        //                    highestRes = res;
        //                }
        //            }
        //            // check that we actually found something
        //            if (highestRes == 0)
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "No valid image resolutions found in zip!";
        //                SnackBar.Show();
        //                return;
        //            }

        //            string[] files = Directory.GetFiles(skinPaths[0] + "\\" + highestRes.ToString());
        //            if (files.Length == 0)
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "No files in highest resolution folder!";
        //                SnackBar.Show();
        //                return;
        //            }
        //            // find _col file
        //            string colPath = "";
        //            foreach (string file in files)
        //            {
        //                if (file.EndsWith("_col.dds"))
        //                {
        //                    colPath = file;
        //                    break;
        //                }
        //            }
        //            if (colPath == "")
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "No _col texture found in highest resolution folder";
        //                SnackBar.Show();
        //                return;
        //            }

        //            if (!DdsToPng(colPath, modTempFolderPath + "\\icon.png"))
        //            {
        //                SnackBar.Appearance = ControlAppearance.Danger;
        //                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //                SnackBar.Message = "Failed to convert dds to png for icon!";
        //                SnackBar.Show();
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            // check that png is correct size
        //            System.Drawing.Image img = System.Drawing.Image.FromFile(Mod_Adv_Icon_Path);


        //            // copy png over
        //            TryCopyFile(Mod_Adv_Icon_Path, modTempFolderPath + "\\icon.png",true);
        //        }

        //            //    ConvertTaskComplete();

        //            //////////////////////
        //            // create README.md //
        //            //////////////////////

        //   //         if (Description_Box_Advocate.Document.Blocks.Count > 1)
        //   //     {
        //   //             TextRange textRange = new TextRange(
        //   //    // TextPointer to the start of content in the RichTextBox.
        //   //    Description_Box_Advocate.Document.ContentStart,
        //   //    // TextPointer to the end of content in the RichTextBox.
        //   //    Description_Box_Advocate.Document.ContentEnd
        //   //);

        //                // The Text property on a TextRange object returns a string
        //                // representing the plain text content of the TextRange.


        //                File.WriteAllText(modTempFolderPath + "\\README.md", textRange.Text);
        //        }
        //        else
        //        {
        //            SnackBar.Appearance = ControlAppearance.Danger;
        //            SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //            SnackBar.Message = "No files in highest resolution folder!";
        //            SnackBar.Show();

        //        }


        //        //////////////////////////
        //        // create manifest.json //
        //        //////////////////////////


        //        string manifest = string.Format("{{\n\"name\":\"{0}\",\n\"version_number\":\"{1}\",\n\"website_url\":\"\",\n\"dependencies\":[],\n\"description\":\"{2}\"\n}}", Mod_Adv_Skin_Name.Replace(' ', '_'), Mod_Adv_Version_Num, string.Format("Skin made by {0}", Mod_Adv_Author_name));
        //        File.WriteAllText(modTempFolderPath + "\\manifest.json", manifest);


        //        /////////////////////
        //        // create mod.json //
        //        /////////////////////


        //        string modJson = string.Format("{{\n\"Name\": \"{0}\",\n\"Description\": \"\",\n\"Version\": \"{1}\",\n\"LoadPriority\": 1,\n\"ConVars\":[],\n\"Scripts\":[],\n\"Localisation\":[]\n}}", Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name, Mod_Adv_Version_Num);
        //        File.WriteAllText(modTempFolderPath + "\\packages\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + "\\mod.json", modJson);


        //            //////////////////////////////////////////////////////////////////
        //            // create map.json and move textures to temp folder for packing //
        //            //////////////////////////////////////////////////////////////////

        //            Advocate.Conversion.JSON.Map map = new(Mod_Adv_Skin_Name, $"{repakTempFolderPath}/assets", $"{modTempFolderPath}/mods/{Mod_Adv_Author_name}.{Mod_Adv_Skin_Name}/paks");

        //            // this tracks the textures that we have already added to the json, so we can avoid duplicates in there
        //            List<string> textures = new();
        //            // this tracks the different skin types that we have found, for description parsing later
        //            List<string> skinTypes = new();

        //            // this keeps track of the different DDS files we are handling and combining
        //            // the key is the texture name (example: CAR_Default_col)
        //            Dictionary<string, Advocate.DDS.Manager> ddsManagers = new();
        //            /* The plan here is to:
        //             * 1. find all textures, and put them into arrays/lists of mip sizes (where 2^index == image width/height)
        //             * 2. take each dds, and rip the image data directly from it, putting them together to create as many mip levels as we can
        //             * 3. create the lower level mips from the highest resolution image that we have
        //             * (decompression and recompression harms image quality so we want to avoid this wherever we can)
        //             * 4. put the raw image data for the mips into one dds file
        //             * 
        //             * ASSUMPTIONS:
        //             * 1. the lower resolution images use the same compression format as the highest resolution image
        //             * if this is not the case, log, and skip the lower level image (this means we have to generate more mip levels, which is bad)
        //             * 
        //             */

        //            // find all DDS files within the zip folder
        //            string[] ddsImages = Directory.GetFiles(skinTempFolderPath, "*.dds", SearchOption.AllDirectories);

        //            // add all of the files to their respective DDS Managers
        //            foreach (string path in ddsImages)
        //            {
        //                string filename = Path.GetFileNameWithoutExtension(path);

        //                // create a new DDS.Manager if needed
        //                if (!ddsManagers.ContainsKey(filename))
        //                {
        //                  //  Debug($"Found new texture type '{filename}', creating Manager.");
        //                    ddsManagers.Add(filename, new Advocate.DDS.Manager());
        //                }

        //                // read the dds file into the Manager
        //              //  Debug($"Adding new image for texture type '{filename}' from path '{path}'");
        //                BinaryReader reader = new(new FileStream(path, FileMode.Open));
        //                ddsManagers[filename].LoadImage(reader);
        //                reader.Close();

        //                // add texture to skinTypes for tracking which skins are in the package
        //                string type = Path.GetFileNameWithoutExtension(path).Split("_")[0];
        //                if (!skinTypes.Contains(type))
        //                {
        //                  //  Debug($"Found new skin type for description handling ({type})");
        //                    skinTypes.Add(type);
        //                }
        //            }

        //            // save all dds images
        //            foreach (KeyValuePair<string, Advocate.DDS.Manager> pair in ddsManagers)
        //            {
        //                string texturePath = TextureNameToPath(pair.Key);
        //                if (texturePath == "")
        //                {
        //                   // Logging.Logger.Error($"Failed to find texture path for {pair.Key}");
        //                  //  return false;
        //                }
        //                string filePath = $"{repakTempFolderPath}/assets/{texturePath}.dds";
        //                // writer doesnt create directories, so do it beforehand
        //                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //                //Debug($"Saving texture (with {pair.Value.MipMapCount} mips) to path '{filePath}'");

        //                // create writer and save the image
        //                BinaryWriter writer = new(new FileStream(filePath, FileMode.Create));

        //                // generate missing mips
        //                if (pair.Value.HasMissingMips())
        //                {
        //                   // Debug($"Texture being saved to '{filePath}' has missing mip levels");
        //                   // Info($"Generating MipMaps... ({pair.Key})");















        //                    //  pair.Value.GenerateMissingMips(texconvPath);


        //                }

        //                pair.Value.Convert();
        //                pair.Value.SaveImage(writer);

        //                // close the writer
        //                writer.Close();

        //                // add asset to map file
        //                map.AddTextureAsset(texturePath);

        //                // add texturePath to tracked textures
        //                textures.Add(texturePath);
        //            }

        //            // write the map json
        //          //








        //            //File.WriteAllText($"{repakTempFolderPath}/map.json", JsonSerializer.Serialize<Advocate.Conversion.JSON.Map>(map, jsonOptions));















        //        //    string map = string.Format("{{\n\"name\":\"{0}\",\n\"assetsDir\":\"{1}\",\n\"outputDir\":\"{2}\",\n\"version\": 7,\n\"files\":[\n", Mod_Adv_Skin_Name, (repakTempFolderPath + "\\assets").Replace('\\', '/'), (modTempFolderPath + "\\packages\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + "\\paks").Replace('\\', '/'));
        //        //// this tracks the textures that we have already added to the json, so we can avoid duplicates in there
        //        //List<string> textures = new();
        //        //bool isFirst = true;
        //        //foreach (string skinPath in Directory.GetDirectories(skinTempFolderPath))
        //        //    {// some skins have random files and folders in here, like images and stuff, so I have to do sorting in an annoying way
        //        //        List<string> parsedDirs = new();
        //        //        foreach (string dir in Directory.GetDirectories(skinPath))
        //        //        {
        //        //            // only add to the list of dirs
        //        //            if (int.TryParse(Path.GetFileName(dir), out int val))
        //        //            {
        //        //                parsedDirs.Add(dir);
        //        //            }
        //        //        }
        //        //        foreach (string resolution in Directory.GetDirectories(skinPath).OrderBy(path => int.Parse(Path.GetFileName(path))))
        //        //    {
        //        //        if (int.TryParse(Path.GetFileName(resolution), out int res))
        //        //        {
        //        //            foreach (string texture in Directory.GetFiles(resolution))
        //        //            {
        //        //                // move texture to temp folder for packing
        //        //                // convert from skin tool syntax to actual texture path, gotta be hardcoded because pain
        //        //                string texturePath = TextureNameToPath(Path.GetFileNameWithoutExtension(texture));
        //        //                if (texturePath == "")
        //        //                {
        //        //                   // ConversionFailed(button, styleProperty, "Failed to convert texture '" + Path.GetFileNameWithoutExtension(texture) + "')");
        //        //                    return;
        //        //                }

        //        //                // avoid duplicate textures in the json
        //        //                if (!textures.Contains(texturePath))
        //        //                {
        //        //                    // dont add a comma on the first one
        //        //                    if (!isFirst)
        //        //                        map += ",\n";
        //        //                    map += $"{{\n\"$type\":\"txtr\",\n\"path\":\"{texturePath}\",\n\"disableStreaming\":true,\n\"saveDebugName\":true\n}}";
        //        //                    // add texture to tracked textures
        //        //                    textures.Add(texturePath);
        //        //                }
        //        //                isFirst = false;
        //        //                // copy file
        //        //               TryCreateDirectory(Directory.GetParent($"{repakTempFolderPath}\\assets\\{texturePath}.dds").FullName);

        //        //                DdsHandler handler = new(texture);
        //        //                handler.Convert();
        //        //                handler.Save($"{repakTempFolderPath}\\assets\\{texturePath}.dds");
        //        //            }
        //        //        }
        //        //    }
        //        //}

        //        //// end the json
        //        //map += "\n]\n}";
        //        //File.WriteAllText(repakTempFolderPath + "\\map.json", map);


        //        //////////////////////////
        //        // pack using RePak.exe //
        //        //////////////////////////

        //     //   Message = "Packing using RePak...";

        //        //var sb = new StringBuilder();

        //        Process P = new();

        //        //P.StartInfo.RedirectStandardOutput = true;
        //        //P.StartInfo.RedirectStandardError = true;
        //        //P.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
        //        //P.ErrorDataReceived += (sender, args) => sb.AppendLine(args.Data);
        //        //P.StartInfo.UseShellExecute = false;
        //        P.StartInfo.FileName = Mod_Adv_Repak_Path;
        //        P.StartInfo.Arguments = "\"" + repakTempFolderPath + "\\map.json\"";
        //        P.Start();
        //        //P.BeginOutputReadLine();
        //        //P.BeginErrorReadLine();
        //        P.WaitForExit();

        //        if (P.ExitCode == 1)
        //        {
        //          //  ConversionFailed(button, styleProperty, "RePak failed to pack the rpak!");
        //            return;
        //        }


        //        //////////////////////
        //        // create rpak.json //
        //        //////////////////////


        //        string rpakjson = string.Format("{{\n\"Preload\":\n{{\n\"{0}\":true\n}}\n}}", Mod_Adv_Skin_Name + ".rpak");

        //        File.WriteAllText(modTempFolderPath + "\\packages\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + "\\paks\\rpak.json", rpakjson);


        //        ///////////////////
        //        // zip up result //
        //        ///////////////////


        //        ZipFile.CreateFromDirectory(modTempFolderPath, tempFolderPath + "\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + ".zip");


        //        ////////////////////////////////////
        //        // move result out of temp folder //
        //        ////////////////////////////////////


        //        TryMoveFile(tempFolderPath + "\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + ".zip", Mod_Adv_Output_Path + "\\" + Mod_Adv_Author_name + "." + Mod_Adv_Skin_Name + ".zip", true);

        //    }
        //    catch (Exception ex)
        //    {
        //            //Removed PaperTrailSystem Due to lack of reliability.

        //            SnackBar.Appearance = ControlAppearance.Danger;
        //            SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //            SnackBar.Message = ex.Message;
        //            SnackBar.Show();
        //            Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

        //            return;
        //    }
        //    finally
        //    {
        //            /////////////
        //            // cleanup //
        //            /////////////


        //            // delete temp folders
        //            // delete temp folders
        //            try
        //            {
        //                // delete temp folders
        //                if (Directory.Exists(tempFolderPath))
        //                    Directory.Delete(tempFolderPath, true);
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }


        //    // everything is done and good
        //    SnackBar.Appearance = ControlAppearance.Success;
        //    SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
        //    SnackBar.Message = "Conversion Completed Successfully";
        //    SnackBar.Show();


        //    }
        //    catch (Exception ex)
        //    {
        //      //Removed PaperTrailSystem Due to lack of reliability.
        //        SnackBar.Appearance = ControlAppearance.Danger;
        //        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
        //        SnackBar.Message = ex.Message;
        //        SnackBar.Show();
        //        Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

        //    }


        //}

        private bool DdsToPng(string imagePath, string outputPath)
        {
            try
            {
                // yoinked from pfim usage example
                using (var image = Pfimage.FromFile(imagePath))
                {
                    PixelFormat format;

                    // Convert from Pfim's backend agnostic image format into GDI+'s image format
                    switch (image.Format)
                    {
                        case Pfim.ImageFormat.Rgba32:
                            format = PixelFormat.Format32bppArgb;
                            break;
                        default:
                            // see the sample for more details
                            throw new NotImplementedException();
                    }

                    // Pin pfim's data array so that it doesn't get reaped by GC, unnecessary
                    // in this snippet but useful technique if the data was going to be used in
                    // control like a picture box
                    var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                    try
                    {
                        var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
                        var bitmap = new Bitmap(image.Width, image.Height, image.Stride, format, data);
                        // resize the bitmap before saving it
                        var resized = new Bitmap(bitmap, new System.Drawing.Size(256, 256));
                        resized.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    finally
                    {
                        handle.Free();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //Removed PaperTrailSystem Due to lack of reliability.
                SnackBar.Appearance = ControlAppearance.Danger;
                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                SnackBar.Message = ex.Message;
                SnackBar.Show();
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            return false;
        }

        // these dictionaries have to be hardcoded because skin tool just hardcodes in offsets afaik

        // weapons
        private readonly Dictionary<string, string> weaponNameToPath = new()
        {
            // pilot weapons
            { "R201_Default", @"texture\\models\\weapons\\r101\\r101" },
            { "R101_Default", @"texture\\models\\Weapons_R2\\r101_sfp\\r101_sfp" },
            { "HemlokBFR_Default", @"texture\\models\\Weapons_R2\\hemlok_bfr_ar\\hemlok_BFR_ar" },
            { "V47Flatline_Default", @"texture\\models\\weapons\\vinson\\vinson_rifle" },
            { "G2A5_Default", @"texture\\models\\Weapons_R2\\g2a4_ar\\g2a4_ar_col" },
            { "Alternator_Default", @"texture\\models\\Weapons_R2\\alternator_smg\\alternator_smg" },
            { "CAR_Default", @"texture\\models\\Weapons_R2\\car_smg\\CAR_smg" },
            { "R97_Default", @"texture\\models\\Weapons_R2\\r97\\R97_CN" },
            { "Volt_Default", @"texture\\models\\weapons\\hemlok_smg\\hemlok_smg" },
            { "Devotion_Default", @"texture\\models\\weapons\\hemlock_br\\hemlock_br" },
            { "Devotion_clip_Default", @"texture\\models\\weapons\\hemlock_br\\hemlock_br_acc" },
            { "LSTAR_Default", @"texture\\models\\weapons\\lstar\\lstar" },
            { "Spitfire_Default", @"texture\\models\\Weapons_R2\\spitfire_lmg\\spitfire_lmg" },
            { "DoubleTake_Default", @"texture\\models\\Weapons_R2\\doubletake_sr\\doubletake" },
            { "Kraber_Default", @"texture\\models\\Weapons_R2\\kraber_sr\\kraber_sr" },
            { "LongbowDMR_Default", @"texture\\models\\Weapons_R2\\Longbow_dmr\\longbow_dmr" },
            { "EVA8_Default", @"texture\\models\\Weapons_R2\\eva8_stgn\\eva8_stgn" },
            { "Mastiff_Default", @"texture\\models\\weapons\\mastiff_stgn\\mastiff_stgn" },
            { "ColdWar_Default", @"texture\\models\\Weapons_R2\\pulse_lmg\\pulse_lmg" },
            { "EPG_Default", @"texture\\models\\Weapons_R2\\epg\\epg" },
            { "SMR_Default", @"texture\\models\\Weapons_R2\\sidewinder_at\\sidewinder_at" },
            { "Softball_Default", @"texture\\models\\weapons\\softball_at\\softball_at_skin01" },
            { "Mozambique_Default", @"texture\\models\\Weapons_R2\\pstl_sa3" },
            { "P2016_Default", @"texture\\models\\Weapons_R2\\p2011_pstl\\p2011_pstl" },
            { "RE45_Default", @"texture\\models\\Weapons_R2\\re45_pstl\\RE45" },
            { "SmartPistol_Default", @"texture\\models\\Weapons_R2\\smart_pistol\\Smart_Pistol_MK6" },
            { "Wingman_Default", @"texture\\models\\weapons\\b3_wingman\\b3_wingman" },
            { "WingmanElite_Default", @"texture\\models\\Weapons_R2\\wingman_elite\\wingman_elite" },
            { "Archer_Default", @"texture\\models\\Weapons_R2\\archer_at\\archer_at" },
            { "ChargeRifle_Default", @"texture\\models\\Weapons_R2\\charge_rifle\\charge_rifle_at" },
            { "MGL_Default", @"texture\\models\\weapons\\mgl_at\\mgl_at" },
            { "Thunderbolt_Default", @"texture\\models\\Weapons_R2\\arc_launcher\\arc_launcher" },
            // titan weapons
            { "BroadSword_Default", @"texture\\models\\weapons\\titan_sword\\titan_sword_01" },
            { "LeadWall_Default", @"texture\\models\\Weapons_R2\\titan_triple_threat\\triple_threat" },
            { "PlasmaRailgun_Default", @"texture\\models\\Weapons_R2\\titan_plasma_railgun\\plasma_railgun" },
            { "SplitterRifle_Default", @"texture\\models\\weapons\\titan_particle_accelerator\\titan_particle_accelerator" },
            { "ThermiteLauncher_Default", @"texture\\models\\Weapons_R2\\titan_thermite_launcher\\thermite_launcher" },
            { "TrackerCannon_Default", @"texture\\models\\Weapons_R2\\titan_40mm\\titan_40mm" },
            { "XO16_Default", @"texture\\models\\Weapons_R2\\xo16_shorty_titan\\xo16_shorty_titan" },
            { "XO16_clip_Default", @"texture\\models\\Weapons_R2\\xo16_a2_titan\\xo16_a2_titan" },
            // melee
            { "Sword_Default", @"texture\\models\\weapons\\bolo_sword\\bolo_sword_01" }, // also idk about this, this is a blank texture in vanilla
            { "Kunai_Default", @"texture\\models\\Weapons_R2\\shuriken_kunai\\kunai_shuriken" }, // again, not entirely sure
        };
        // pilot and titan overrides - used for weird exceptions where things share textures etc.
        private readonly Dictionary<string, string> nameToPathOverrides = new()
        {
            //////////////
            /// PILOTS ///
            //////////////
            // cloak
            // A-wall
            // phase
            { "PhaseShift_fbody_ilm", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_b_v1_skn01_ilm" },
            // stim
            // grapple
            // pulse
            // holo
            { "HoloPilot_fbody_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_female_b_v1_skn02_col" },
            { "HoloPilot_mbody_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_b_v1_skn02_col" },
            { "HoloPilot_mbody_spc", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_b_v1_skn02_spc" },
            { "HoloPilot_gear_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_g_v1_skn02_col" },
            { "HoloPilot_gear_spc", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_g_v1_skn02_spc" },
            { "HoloPilot_helmet_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_he_v1_skn02_col" },
            { "HoloPilot_helmet_spc", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_he_v1_skn02_spc" },
            { "HoloPilot_jumpkit_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_j_v1_skn02_col" },
            { "HoloPilot_viewhand_col", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_vh_v1_skn02_col" },
            { "HoloPilot_viewhand_spc", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_vh_v1_skn02_spc" },
            //////////////
            /// TITANS ///
            //////////////
            // ion
            { "ION_Default_ao", @"texture\\models\\titans_r2\\medium_ion\\warpaint\\warpaint_02\\t_m_ion_warpaint_skin02_ao" },
            { "ION_Default_cav", @"texture\\models\\titans_r2\\medium_ion\\warpaint\\warpaint_02\\t_m_ion_warpaint_skin02_cav" },
            { "ION_Default_ilm", @"texture\\models\\titans_r2\\medium_ion\\warpaint\\warpaint_02\\t_m_ion_warpaint_skin02_ilm" },
            { "ION_Default_nml", @"texture\\models\\titans_r2\\medium_ion\\warpaint\\warpaint_02\\t_m_ion_warpaint_skin02_nml" },
            // ion prime
            { "PrimeION_Default_ao", @"texture\\models\\titans_r2\\medium_ion_prime\\warpaint\\warpaint_00\\t_m_ion_prime_warpaint_skin01_ao" },
            { "PrimeION_Default_cav", @"texture\\models\\titans_r2\\medium_ion_prime\\warpaint\\warpaint_00\\t_m_ion_prime_warpaint_skin01_cav" },
            { "PrimeION_Default_ilm", @"texture\\models\\titans_r2\\medium_ion_prime\\warpaint\\warpaint_00\\t_m_ion_prime_warpaint_skin01_ilm" },
            // tone
            { "Tone_Default_ao", @"texture\\models\\titans_r2\\medium_tone\\warpaint\\warpaint_00\\t_m_tone_warpaint_skin00_ao" },
            { "Tone_Default_cav", @"texture\\models\\titans_r2\\medium_tone\\warpaint\\warpaint_00\\t_m_tone_warpaint_skin00_cav" },
            { "Tone_Default_ilm", @"texture\\models\\titans_r2\\medium_tone\\warpaint\\warpaint_00\\t_m_tone_warpaint_skin00_ilm" },
            // tone prime
            { "PrimeTone_Default_ao", @"texture\\models\\titans_r2\\medium_tone_prime\\warpaint\\warpaint_00\\t_m_tone_prime_warpaint_skin00_ao" },
            { "PrimeTone_Default_cav", @"texture\\models\\titans_r2\\medium_tone_prime\\warpaint\\warpaint_00\\t_m_tone_prime_warpaint_skin00_cav" },
            { "PrimeTone_Default_ilm", @"texture\\models\\titans_r2\\medium_tone_prime\\warpaint\\warpaint_00\\t_m_tone_prime_warpaint_skin00_ilm" },
            { "PrimeTone_Default_nml", @"texture\\models\\titans_r2\\medium_tone_prime\\warpaint\\warpaint_00\\t_m_tone_prime_warpaint_skin00_nml" },
            // northstar
            // northstar prime
            { "PrimeNorthstar_Default_ao", @"texture\\models\\titans_r2\\light_northstar_prime\\warpaint\\warpaint_00\\t_l_northstar_prime_warpaint_skin00_ao" },
            { "PrimeNorthstar_Default_cav", @"texture\\models\\titans_r2\\light_northstar_prime\\warpaint\\warpaint_00\\t_l_northstar_prime_warpaint_skin00_cav" },
            { "PrimeNorthstar_Default_ilm", @"texture\\models\\titans_r2\\light_northstar_prime\\warpaint\\warpaint_00\\t_l_northstar_prime_warpaint_skin00_ilm" },
            { "PrimeNorthstar_Default_nml", @"texture\\models\\titans_r2\\light_northstar_prime\\warpaint\\warpaint_00\\t_l_northstar_prime_warpaint_skin00_nml" },
            // ronin
            // ronin prime
            { "PrimeRonin_Default_ao", @"texture\\models\\titans_r2\\light_ronin_prime\\warpaint\\warpaint_00\\t_l_ronin_prime_warpaint_skin00_ao" },
            { "PrimeRonin_Default_cav", @"texture\\models\\titans_r2\\light_ronin_prime\\warpaint\\warpaint_00\\t_l_ronin_prime_warpaint_skin00_cav" },
            { "PrimeRonin_Default_ilm", @"texture\\models\\titans_r2\\light_ronin_prime\\warpaint\\warpaint_00\\t_l_ronin_prime_warpaint_skin00_ilm" },
            { "PrimeRonin_Default_nml", @"texture\\models\\titans_r2\\light_ronin_prime\\warpaint\\warpaint_00\\t_l_ronin_prime_warpaint_skin00_nml" },
            // scorch
            { "Scorch_Default_ao", @"texture\\models\\titans_r2\\heavy_scorch\\warpaint\\warpaint_00\\t_h_scorch_warpaint_skin00_ao" },
            { "Scorch_Default_cav", @"texture\\models\\titans_r2\\heavy_scorch\\warpaint\\warpaint_00\\t_h_scorch_warpaint_skin00_cav" },
            { "Scorch_Default_ilm", @"texture\\models\\titans_r2\\heavy_scorch\\warpaint\\warpaint_00\\t_h_scorch_warpaint_skin00_ilm" },
            // scorch prime
            { "PrimeScorch_Default_ao", @"texture\\models\\titans_r2\\heavy_scorch_prime\\warpaint\\warpaint_00\\t_h_scorch_prime_warpaint_skin00_ao" },
            { "PrimeScorch_Default_cav", @"texture\\models\\titans_r2\\heavy_scorch_prime\\warpaint\\warpaint_00\\t_h_scorch_prime_warpaint_skin00_cav" },
            { "PrimeScorch_Default_ilm", @"texture\\models\\titans_r2\\heavy_scorch_prime\\warpaint\\warpaint_00\\t_h_scorch_prime_warpaint_skin00_ilm" },
            // legion
            { "Legion_Default_ao", @"texture\\models\\titans_r2\\heavy_legion\\warpaint\\warpaint_00\\t_h_legion_warpaint_skin00_ao" },
            { "Legion_Default_cav", @"texture\\models\\titans_r2\\heavy_legion\\warpaint\\warpaint_00\\t_h_legion_warpaint_skin00_cav" },
            { "Legion_Default_ilm", @"texture\\models\\titans_r2\\heavy_legion\\warpaint\\warpaint_00\\t_h_legion_warpaint_skin00_ilm" },
            // legion prime
            { "PrimeLegion_Default_ao", @"texture\\models\\titans_r2\\heavy_legion_prime\\warpaint\\warpaint_00\\t_h_legion_prime_warpaint_skin00_ao" },
            { "PrimeLegion_Default_cav", @"texture\\models\\titans_r2\\heavy_legion_prime\\warpaint\\warpaint_00\\t_h_legion_prime_warpaint_skin00_cav" },
            { "PrimeLegion_Default_ilm", @"texture\\models\\titans_r2\\heavy_legion_prime\\warpaint\\warpaint_00\\t_h_legion_prime_warpaint_skin00_ilm" },
            { "PrimeLegion_Default_nml", @"texture\\models\\titans_r2\\heavy_legion_prime\\warpaint\\warpaint_00\\t_h_legion_prime_warpaint_skin00_nml" },
            // monarch
            { "Monarch_Default_ao", @"texture\\models\\titans_r2\\medium_vanguard\\warpaint\\warpaint_00\\t_m_vanguard_prime_warpaint_skin00_ao" },
            { "Monarch_Default_cav", @"texture\\models\\titans_r2\\medium_vanguard\\warpaint\\warpaint_00\\t_m_vanguard_prime_warpaint_skin00_cav" },
            { "Monarch_Default_ilm", @"texture\\models\\titans_r2\\medium_vanguard\\warpaint\\warpaint_00\\t_m_vanguard_prime_warpaint_skin00_ilm" },
            { "Monarch_Default_nml", @"texture\\models\\titans_r2\\medium_vanguard\\warpaint\\warpaint_00\\t_m_vanguard_prime_warpaint_skin00_nml" },
        };
        // pilots and titans
        private readonly Dictionary<string, string> nameToPath = new()
        {
            //////////////
            /// PILOTS ///
            //////////////
            // cloak
            { "Cloak_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_f_body_skin_01" },
            { "Cloak_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_m_body_skin_01" },
            { "Cloak_gauntlet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_gauntlet_skin_01" },
            { "Cloak_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_gear_skin_01" },
            { "Cloak_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_jumpkit_skin_01" },
            { "Cloak_ghillie", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_ghullie_skin_01" },// ghullie lol
            { "Cloak_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_drex\\pilot_heavy_drex_helmet_skin_01" },
            // A-wall
            { "AWall_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_hevy_roog\\pilot_hev_roog_f_body_skn_01" },
            { "AWall_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_hevy_roog\\pilot_hev_roog_m_body_skn_01" },
            { "AWall_gauntlet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_hevy_roog\\pilot_hev_roog_m_gauntlet_skn_01" },
            { "AWall_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_hevy_roog\\pilot_hev_roog_m_gear_skn_01" },
            { "AWall_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_hevy_roog\\pilot_hev_roog_m_jumpkit_skn_01" },
            { "AWall_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_heavy_helmets\\pilot_hev_helmet_v1_skn" },
            // phase
            { "PhaseShift_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_female_body_v1_skn01" },
            { "PhaseShift_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_b_v1_skn01" },
            { "PhaseShift_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_g_v1_skn01" },
            { "PhaseShift_viewhand", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_vh_v1_skn01" },
            { "PhaseShift_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_j_v1_skn01" },
            { "PhaseShift_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_g_v1_skn01" },
            { "PhaseShift_hair", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_ged\\p_l_ged_male_alpha_v1_skn01" },
            // stim
            { "Stim_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_f_body" },
            { "Stim_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_m_body" },
            { "Stim_fgear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_f_gear" },
            { "Stim_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_gear" },
            { "Stim_gauntlet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_gauntlet" },
            { "Stim_fjumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_f_jumpkit" },
            { "Stim_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_jumpkit" },
            { "Stim_head", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_light_jester\\pilot_lit_jester_head" },
            // grapple
            { "Grapple_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_f_body_skn_01" },
            { "Grapple_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_m_body_skn_02" },
            { "Grapple_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_gear_skn_02" },
            { "Grapple_gauntlet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_gauntlet_skn_02" },
            { "Grapple_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_jumpkit_skn_01" },
            { "Grapple_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_geist\\pilot_med_geist_helmet_v2_skn_01" },
            // pulse
            { "PulseBlade_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_reaper\\pilot_med_reaper_f_body_skin_01" },
            { "PulseBlade_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_reaper\\pilot_med_reaper_m_body_skin_01" },
            { "PulseBlade_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_reaper\\pilot_med_reaper_m_gear_skin_01" },
            { "PulseBlade_gauntlet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_reaper\\pilot_med_reaper_m_gauntlet1_skin_01" },
            { "PulseBlade_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_reaper\\pilot_med_reaper_jumpkit_skin_02" },
            { "PulseBlade_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_v_helmets\\pilot_med_helmet_v2_skn_02" },
            // holo
            { "HoloPilot_fbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_female_b_v1_skn01" },
            { "HoloPilot_mbody", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_b_v1_skn01" },
            { "HoloPilot_gear", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_g_v1_skn01" },
            { "HoloPilot_viewhand", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_vh_v1_skn01" },
            { "HoloPilot_jumpkit", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_j_v1_skn01" },
            { "HoloPilot_helmet", @"texture\\models\\humans\\titanpilot_gsuits\\pilot_medium_stalker\\p_m_stalker_male_he_v1_skn01" },
            // shared
            { "Cloak_head", @"texture\\models\\humans\\titanpilot_heads\\pilot_v3_head" },
            { "AWall_head", @"texture\\models\\humans\\titanpilot_heads\\pilot_v3_head" },
            { "Grapple_head", @"texture\\models\\humans\\titanpilot_heads\\pilot_v3_head" },
            { "PulseBlade_head", @"texture\\models\\humans\\titanpilot_heads\\pilot_v3_head" },
            { "HoloPilot_head", @"texture\\models\\humans\\titanpilot_heads\\pilot_v3_head" },

            //////////////
            /// TITANS ///
            //////////////
            // ion
            { "ION_Default", @"texture\\models\\titans_r2\\medium_ion\\warpaint\\warpaint_01\\t_m_ion_warpaint_skin01" },
            // ion prime
            { "PrimeION_Default", @"texture\\models\\titans_r2\\medium_ion_prime\\warpaint\\warpaint_01\\t_m_ion_prime_warpaint_skin01" },
            // tone
            { "Tone_Default", @"texture\\models\\titans_r2\\medium_tone\\warpaint\\warpaint_02\\t_m_tone_warpaint_skin02" },
            // tone prime
            { "PrimeTone_Default", @"texture\\models\\titans_r2\\medium_tone_prime\\warpaint\\warpaint_01\\t_m_tone_prime_warpaint_skin01" },
            // northstar
            { "Northstar_Default", @"texture\\models\\titans_r2\\light_northstar\\warpaint\\warpaint_01\\t_l_northstar_warpaint_skin01" },
            // northstar prime
            { "PrimeNorthstar_Default", @"texture\\models\\titans_r2\\light_northstar_prime\\warpaint\\warpaint_01\\t_l_northstar_prime_warpaint_skin01" },
            // ronin
            { "Ronin_Default", @"texture\\models\\titans_r2\\light_ronin\\warpaint\\warpaint_02\\t_l_ronin_warpaint_skin02" },
            // ronin prime
            { "PrimeRonin_Default", @"texture\\models\\titans_r2\\light_ronin_prime\\warpaint\\warpaint_01\\t_l_ronin_prime_warpaint_skin01" },
            // scorch
            { "Scorch_Default", @"texture\\models\\titans_r2\\heavy_scorch\\warpaint\\warpaint_01\\t_h_scorch_warpaint_skin01" },
            // scorch prime
            { "PrimeScorch_Default", @"texture\\models\\titans_r2\\heavy_scorch_prime\\warpaint\\warpaint_01\\t_h_scorch_prime_warpaint_skin01" },
            // legion
            { "Legion_Default", @"texture\\models\\titans_r2\\heavy_legion\\warpaint\\warpaint_01\\t_h_legion_warpaint_skin01" },
            // legion prime
            { "PrimeLegion_Default", @"texture\\models\\titans_r2\\heavy_legion_prime\\warpaint\\warpaint_01\\t_h_legion_prime_warpaint_skin01" },
            // monarch
            { "Monarch_Default", @"texture\\models\\titans_r2\\medium_vanguard\\warpaint\\warpaint_01\\t_m_vanguard_prime_warpaint_skin01" },

        };
        private string TextureNameToPath(string textureName)
        {
            int lastIndex = textureName.LastIndexOf('_');

            string txtrType = textureName.Substring(lastIndex, textureName.Length - lastIndex);
            textureName = textureName.Substring(0, lastIndex);

            if (weaponNameToPath.ContainsKey(textureName))
                return weaponNameToPath[textureName] + txtrType;

            if (nameToPathOverrides.ContainsKey(textureName + txtrType))
                return nameToPathOverrides[textureName + txtrType];
            if (nameToPath.ContainsKey(textureName))
                return nameToPath[textureName] + txtrType;

            return "";
        }
        public async Task fade_dav(bool X = true)
        {
            await Task.Run(() =>
            {
                if (X == true)
                {

                    DispatchIfNecessary(async () =>
                    {
                        if (Icon_Bg.Source.ToString().Contains("advocate_announcement_1.png"))
                        {
                            return;
                        }

                        if (Icon_Bg.Opacity > 0)
                        {
                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = Icon_Bg.Opacity,
                                To = 0,
                                Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                AutoReverse = false
                            };
                            Icon_Bg.BeginAnimation(OpacityProperty, da);

                        }
                    });

                    Thread.Sleep(420);


                    DispatchIfNecessary(async () =>
                {

                    if (Icon_Bg.Opacity == 0)
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/Main_UI/advocate_announcement_1.png");
                        bitmap.EndInit();


                        Icon_Bg.Source = bitmap;


                        DoubleAnimation da = new DoubleAnimation
                        {
                            From = Icon_Bg.Opacity,
                            To = 0.2,
                            Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                            AutoReverse = false
                        };
                        Icon_Bg.BeginAnimation(OpacityProperty, da);

                    }
                });




                }
                else
                {

                    DispatchIfNecessary(async () =>
                    {
                        if (Icon_Bg.Source.ToString().Contains("Tools-Silhouette-Transparent.png"))
                        {
                            return;
                        }

                        if (Icon_Bg.Opacity > 0)
                        {
                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = Icon_Bg.Opacity,
                                To = 0,
                                Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                AutoReverse = false
                            };
                            Icon_Bg.BeginAnimation(OpacityProperty, da);

                        }
                    });


                    Thread.Sleep(420);
                    DispatchIfNecessary(async () =>
                    {
                        if (Icon_Bg.Opacity == 0)
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(@"pack://application:,,,/Resources/Icons/Main_UI/Tools-Silhouette-Transparent.png");
                            bitmap.EndInit();



                            Icon_Bg.Source = bitmap;


                            DoubleAnimation da = new DoubleAnimation
                            {
                                From = Icon_Bg.Opacity,
                                To = 0.2,
                                Duration = new Duration(TimeSpan.FromSeconds(0.4)),
                                AutoReverse = false
                            };
                            Icon_Bg.BeginAnimation(OpacityProperty, da);

                        }
                    });


                }
            });

        }
        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(Tools_Dir))
                {

                    TryCreateDirectory(Tools_Dir);
                    if (!Directory.Exists(Tools_Dir))
                    {
                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = "Tools Directory Empty and could not be created!";
                        SnackBar.Show();
                    }

                }
                if (Tabs.SelectedItem.ToString() != null)
                {

                    if (Tabs.SelectedValue.ToString().Contains("External Tools"))
                    {
                        Check_For_Tools();
                        fade_dav(false);

                    }
                    else if (Tabs.SelectedValue.ToString().Contains("Advocate"))
                    {
                        fade_dav(true);
                        if (Directory.Exists(Tools_Dir + @"RePak") && File.Exists(Tools_Dir + @"RePak\" + "RePak.exe") && !File.Exists(Mod_Adv_Repak_Path))
                        {
                            Properties.Settings.Default.REpak_Folder_Path = Tools_Dir + @"RePak\" + "RePak.exe"; ;
                            Properties.Settings.Default.Save();
                            Mod_Adv_Repak_Path = Tools_Dir + @"RePak\" + "RePak.exe";
                            //Zip_Box_Advocate_Copy.Text = Mod_Adv_Repak_Path;
                        }


                    }
                    else
                    {
                        fade_dav(false);
                    }


                }



            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Locate_Zip_Advocate_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    if (!File.Exists(openFileDialog.FileName))
                    {

                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Zip_Click_InvalidZipFound;
                        SnackBar.Show();

                        return;

                    }
                    else
                    {
                        Mod_Adv_Skin_Path = openFileDialog.FileName;

                        if (Path.GetExtension(Mod_Adv_Skin_Path).Contains("zip") || Path.GetExtension(Mod_Adv_Skin_Path).Contains("Zip"))
                        {
                            SnackBar.Appearance = ControlAppearance.Info;
                            SnackBar.Title = "INFO";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Zip_Click_ValidZipFound;
                            SnackBar.Show();
                            //Zip_Box_Advocate.Text = Mod_Adv_Skin_Path;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }



        private void Image_Icon_Advocate_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    try
            //    {
            //        OpenFileDialog openFileDialog = new OpenFileDialog();
            //        openFileDialog.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
            //        openFileDialog.RestoreDirectory = true;
            //        if (openFileDialog.ShowDialog() == true)
            //        {
            //            Mod_Adv_Icon_Path = openFileDialog.FileName;
            //            if (!File.Exists(Mod_Adv_Icon_Path))
            //            {

            //                SnackBar.Icon = SymbolRegular.ErrorCircle20;
            //                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
            //                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
            //                SnackBar.Show();
            //                return;

            //            }
            //            else
            //            {
            //                if (Path.GetExtension(Mod_Adv_Icon_Path).Contains("png"))
            //                {
            //                    int imgwidth;
            //                    int imgheight;

            //                    using (var image = SixLabors.ImageSharp.Image.Load(Mod_Adv_Icon_Path))
            //                    {
            //                        imgwidth = image.Width;
            //                        imgheight = image.Height;
            //                    }

            //                    if (imgwidth == 256 && imgheight == 256)
            //                    {

            //                        SnackBar.Appearance = ControlAppearance.Success;
            //                        SnackBar.Title = VTOL.Resources.Languages.Language.SUCCESS;
            //                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ValidImageFoundAt + Mod_Icon_Path;
            //                        SnackBar.Show();
            //                        BitmapImage Mod_Icon = new BitmapImage();
            //                        Mod_Icon.BeginInit();

            //                        Mod_Icon.UriSource = new Uri(Mod_Adv_Icon_Path);
            //                        Mod_Icon.EndInit();

            //                        Image_Icon_Advocate.Background = new ImageBrush(Mod_Icon);

            //                    }
            //                    else
            //                    {
            //                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
            //                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
            //                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_InvalidImageSizeMustBe256x256;
            //                        SnackBar.Show();

            //                        return;

            //                    }

            //                }
            //                else
            //                {
            //                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
            //                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
            //                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_ThatWasNotAProperPNG;
            //                    SnackBar.Show();

            //                    return;
            //                }
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //       Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            //    }
            // }
        }

        private void Image_Icon_Advocate_Drop(object sender, DragEventArgs e)
        {
            try
            {
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
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_NotAValidPNGImage;
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



                            if (imgwidth == 256 && imgheight == 256)
                            {

                                BitmapImage map_ = new BitmapImage();
                                map_.BeginInit();

                                map_.UriSource = new Uri(map_Path);
                                map_.EndInit();

                                DashedBorder.Background = new ImageBrush(map_);
                                Mod_Adv_Icon_Path = map_Path;
                            }
                            else
                            {
                                SnackBar.Icon = SymbolRegular.ErrorCircle20;
                                SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                                SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Icon_Image_MouseDown_InvalidImageSizeMustBe256x256;
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
        private void Locate_Repak_Exe_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Exe files (*.Exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == true)
                {
                    Mod_Adv_Repak_Path = openFileDialog.FileName;

                    if (!File.Exists(Mod_Adv_Repak_Path))
                    {

                        SnackBar.Icon = SymbolRegular.ErrorCircle20;
                        SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Zip_Click_InvalidZipFound;
                        SnackBar.Show();

                        return;

                    }
                    else
                    {
                        if (Path.GetExtension(Mod_Adv_Repak_Path).Contains("exe"))
                        {
                            Properties.Settings.Default.REpak_Folder_Path = openFileDialog.FileName;
                            Properties.Settings.Default.Save();
                            SnackBar.Appearance = ControlAppearance.Info;
                            SnackBar.Title = "INFO";
                            SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Locate_Repak_Exe_Click_ExeLocated;
                            SnackBar.Show();
                            //Zip_Box_Advocate_Copy.Text = Mod_Adv_Repak_Path;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
        }

        private void Output_Button_Advocate_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult res = dialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (!Directory.Exists(dialog.SelectedPath))
                {
                    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Output_Button_Click_NotAnOutputDirectory;
                    SnackBar.Show();
                    Output_Box.Background = Brushes.IndianRed;

                    return;

                }
                else
                {
                    Mod_Adv_Output_Path = dialog.SelectedPath;
                    //Output_Box_Advocate.Text = Mod_Adv_Output_Path;
                    //Output_Box_Advocate.Background = Brushes.Transparent;

                }
            }
        }

        private void Save_Mod_Advocate_Click(object sender, RoutedEventArgs e)
        {
            //Convert();
        }
        async void Start_Exe(string path, string args = null)
        {
            try
            {
                await Task.Run(() =>
                {
                    string directory = Path.GetDirectoryName(path);
                    string fileName = Path.GetFileNameWithoutExtension(path);
                    string fileExtension = Path.GetExtension(path);

                    string[] files = Directory.GetFiles(directory, $"{fileName}*{fileExtension}");

                    if (files.Length > 0)
                    {
                        string filePath = files[0];
                        DispatchIfNecessary(async () =>
                        {
                            SnackBar.Message = "FOUND AND STARTING - " + fileName;
                            SnackBar.Title = "INFO";
                            SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                            SnackBar.Show();
                        });
                        if (args != null && args.Trim() != "")
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                Arguments = args,
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            }


        }
        public bool Check_Python_Installation()
        {
            string result = "";

            ProcessStartInfo pycheck = new ProcessStartInfo();
            pycheck.FileName = "@python.exe";
            pycheck.Arguments = "--version";
            pycheck.UseShellExecute = false;
            pycheck.RedirectStandardOutput = true;
            pycheck.CreateNoWindow = true;

            using (Process process = Process.Start(pycheck))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    if (result.Contains("python") || result.Contains("."))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }
        async void Start_Command_Line(string path, string working_dir, bool Custom_ = false, string args = "")
        {
            try
            {
                await Task.Run(() =>
                {
                    DispatchIfNecessary(async () =>
                    {
                        string arguments = "";
                        if (Custom_ == false)
                        {
                            arguments = @"/k python " + path;


                        }
                        else
                        {
                            arguments = @"/k " + args;
                        }


                        var startInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            WorkingDirectory = working_dir,
                            FileName = "cmd.exe",
                            Arguments = arguments,
                            RedirectStandardInput = false,
                            UseShellExecute = true
                        };
                        Process p = new Process();
                        p.StartInfo = startInfo;
                        p.Start();
                        p.WaitForExit();


                        //System.Diagnostics.Process.Start(new ProcessStartInfo
                        //{ 
                        //    FileName = @"cmd.exe",// Specify exe name.
                        //    Arguments = "python "+ path,
                        //    UseShellExecute = true
                        //});

                        // }
                        //else
                        //{
                        //    SnackBar.Icon = SymbolRegular.ErrorCircle20;
                        //    SnackBar.Appearance = ControlAppearance.Danger; SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        //    SnackBar.Message = "Python Installation Invalid, Cannot Start Script -:\n " + path;
                        //    SnackBar.Show();
                        //}


                    });

                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }



        }
        void Open_Folder(string Folder)
        {

            try
            {

                Process.Start("explorer.exe", Folder);


            }
            catch (Exception ex)
            {
                Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");


            }
        }


        public bool UrlIsValid(string url)
        {
            try
            {

                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
                request.Method = "HEAD"; //Get only the header information -- no need to download any content

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 100 && statusCode < 400) //Good requests
                    {
                        return true;
                    }
                    else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                    {

                        SnackBar.Message = String.Format("The remote server has thrown an internal error. Url is not valid: {0}", url);
                        SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                        SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                        SnackBar.Show();
                        return false;
                    }
                }

            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
                {
                    return false;
                }
                else
                {

                    SnackBar.Message = String.Format("Unhandled status [{0}] returned for url: {1}", ex.Status, url);
                    SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                    SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                    SnackBar.Show();

                }
            }
            catch (Exception ex)
            {

                SnackBar.Message = String.Format("Could not test url {0}.", url);
                SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                SnackBar.Show();

            }
            return false;
        }
        async Task Download_Zip_To_Path(string Sub_Name, string URL)
        {
            try
            {


                await Task.Run(() =>
                {
                    DispatchIfNecessary(async () =>
                    {
                        if (!UrlIsValid(URL))
                        {
                            SnackBar.Message = " Url is not valid";
                            SnackBar.Title = VTOL.Resources.Languages.Language.ERROR;
                            SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Danger;
                            SnackBar.Show();
                            return;
                        }
                        SnackBar.Message = VTOL.Resources.Languages.Language.Page_Tools_Download_Zip_To_Path_DownloadingAndInstalling + Sub_Name;
                        SnackBar.Title = "INFO";
                        SnackBar.Appearance = Wpf.Ui.Common.ControlAppearance.Info;
                        SnackBar.Show();
                        if (Directory.Exists(Tools_Dir))
                        {
                            if (!Directory.Exists(Tools_Dir + Sub_Name))
                            {
                                TryCreateDirectory(Tools_Dir + Sub_Name);
                            }
                            IDownload downloader = DownloadBuilder.New()
                .WithUrl(URL)
                .WithDirectory(Tools_Dir + Sub_Name)
                .WithFileName(Sub_Name + ".zip")
                .WithConfiguration(new DownloadConfiguration())

                .Build();
                            downloader.DownloadFileCompleted += delegate (object sender, AsyncCompletedEventArgs e)
                            {


                                downloader_DownloadCompleted(sender, e, Sub_Name, URL);
                            };

                            downloader.StartAsync();


                        }
                    });
                });


            }
            catch (Exception ex)
            {


            }
        }
        void downloader_DownloadCompleted(object sender, AsyncCompletedEventArgs e, string Sub_Name, string URL)
        {
            ZipFile_ zipFile = new ZipFile_(Tools_Dir + Sub_Name + @"\" + Sub_Name + ".zip");

            zipFile.ExtractAll(Tools_Dir, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);

            Check_For_Tools();

            if (File.Exists(Tools_Dir + Sub_Name + @"\" + Sub_Name + ".zip"))
            {

                File.Delete(Tools_Dir + Sub_Name + @"\" + Sub_Name + ".zip");
            }
        }
        async Task OPEN_WEBPAGE(string URL)
        {
            await Task.Run(() =>
            {
                DispatchIfNecessary(async () =>
                {
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
        public async void Check_For_Tools()
        {


            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                DispatchIfNecessary(async () =>
                {

                    if (Directory.Exists(Tools_Dir))
                    {
                        //Legion+
                        if (Directory.Exists(Tools_Dir + @"LEGION+") && File.Exists(Tools_Dir + @"LEGION+\" + "LegionPlus.exe"))
                        {
                            LEGION_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            LEGION_INSTALL.Icon = SymbolRegular.Open28;
                            LEGION_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            LEGION_INSTALL_FOLDER.IsEnabled = true;
                            LEGION_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            LEGION_INSTALL_FOLDER.IsEnabled = false;
                            LEGION_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");

                            LEGION_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            LEGION_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            LEGION_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //HARMONY_INSTALL
                        if (Directory.Exists(Tools_Dir + @"Harmony_VPK") && File.Exists(Tools_Dir + @"Harmony_VPK\" + "Harmony.VPK.Tool.exe"))
                        {
                            HARMONY_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            HARMONY_INSTALL.Icon = SymbolRegular.Open28;
                            HARMONY_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            HARMONY_INSTALL_FOLDER.IsEnabled = true;
                            HARMONY_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            HARMONY_INSTALL_FOLDER.IsEnabled = false;
                            HARMONY_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");

                            HARMONY_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            HARMONY_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            HARMONY_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //CROWBAR_INSTALL
                        if (Directory.Exists(Tools_Dir + @"CrowBar") && File.Exists(Tools_Dir + @"CrowBar\" + "Crowbar.exe"))
                        {
                            CROWBAR_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            CROWBAR_INSTALL.Icon = SymbolRegular.Open28;
                            CROWBAR_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            CROWBAR_INSTALL_FOLDER.IsEnabled = true;
                            CROWBAR_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            CROWBAR_INSTALL_FOLDER.IsEnabled = false;
                            CROWBAR_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");

                            CROWBAR_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            CROWBAR_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            CROWBAR_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //REPAK_INSTALL
                        if (Directory.Exists(Tools_Dir + @"RePak") && File.Exists(Tools_Dir + @"RePak\" + "RePak.exe"))
                        {
                            REPAK_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            REPAK_INSTALL.Icon = SymbolRegular.Open28;
                            REPAK_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            REPAK_INSTALL_FOLDER.IsEnabled = true;
                            REPAK_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            REPAK_INSTALL_FOLDER.IsEnabled = false;
                            REPAK_INSTALL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");

                            REPAK_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            REPAK_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            REPAK_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //VTF_EDIT_INSTALL
                        if (Directory.Exists(Tools_Dir + @"VTF_Edit") && File.Exists(Tools_Dir + @"VTF_Edit\" + "VTFEdit.exe"))
                        {
                            VTF_EDIT_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            VTF_EDIT_INSTALL.Icon = SymbolRegular.Open28;
                            VTF_EDIT_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            VTF_TOOL_FOLDER.IsEnabled = true;
                            VTF_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            VTF_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");

                            VTF_TOOL_FOLDER.IsEnabled = false;
                            VTF_EDIT_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            VTF_EDIT_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            VTF_EDIT_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //VPK_TOOL_INSTALL
                        if (Directory.Exists(Tools_Dir + @"Titanfall2_VPK_Tool") && File.Exists(Tools_Dir + @"Titanfall2_VPK_Tool\" + "TitanFall VPK Tool.exe"))
                        {
                            VPK_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            VPK_TOOL_INSTALL.Icon = SymbolRegular.Open28;
                            VPK_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            VPK_TOOL_FOLDER.IsEnabled = true;
                            VPK_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            VPK_TOOL_FOLDER.IsEnabled = false;
                            VPK_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");
                            VPK_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            VPK_TOOL_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            VPK_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //MDL_TOOL_INSTALL
                        if (Directory.Exists(Tools_Dir + @"MDL_SHIT") && File.Exists(Tools_Dir + @"MDL_SHIT\" + "mdlshit.exe"))
                        {
                            MDL_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            MDL_TOOL_INSTALL.Icon = SymbolRegular.Open28;
                            MDL_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            MDL_TOOL_FOLDER.IsEnabled = true;
                            MDL_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            MDL_TOOL_FOLDER.IsEnabled = false;
                            MDL_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");
                            MDL_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            MDL_TOOL_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            MDL_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        //ESMT
                        if (Directory.Exists(Tools_Dir + @"ESMT_Easy_sound_modding_tool") && File.Exists(Tools_Dir + @"ESMT_Easy_sound_modding_tool\" + "main.py"))
                        {
                            ESMT_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            ESMT_TOOL_INSTALL.Icon = SymbolRegular.Open28;
                            ESMT_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            ESMT_TOOL_FOLDER.IsEnabled = true;
                            ESMT_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            ESMT_TOOL_FOLDER.IsEnabled = false;
                            ESMT_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");
                            ESMT_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            ESMT_TOOL_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            ESMT_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                        if (Directory.Exists(Tools_Dir + @"ADVOCATE_TOOL") && File.Exists(Tools_Dir + @"ADVOCATE_TOOL\" + "Advocate.exe"))
                        {
                            ADV_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Launch;
                            ADV_TOOL_INSTALL.Icon = SymbolRegular.Open28;
                            ADV_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF005D42");
                            ADV_TOOL_FOLDER.IsEnabled = true;
                            ADV_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFAF7800");


                        }
                        else
                        {
                            ADV_TOOL_FOLDER.IsEnabled = false;
                            ADV_TOOL_FOLDER.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF3A3A3A");
                            ADV_TOOL_INSTALL.Content = VTOL.Resources.Languages.Language.Page_Tools_Check_For_Tools_Install;
                            ADV_TOOL_INSTALL.Icon = SymbolRegular.ArrowDown32;
                            ADV_TOOL_INSTALL.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B0606");
                        }
                    }
                    else
                    {

                        TryCreateDirectory(Tools_Dir);
                        Check_For_Tools();

                    }
                });


            });
        }


        private void LEGION_INSTALL_FOLDER_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"LEGION+"))
            {
                Open_Folder(Tools_Dir + @"LEGION+");
            }
        }

        private void HARMONY_INSTALL_FOLDER_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"Harmony_VPK"))
            {
                Open_Folder(Tools_Dir + @"Harmony_VPK");
            }

        }

        private void CROWBAR_INSTALL_FOLDER_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(Tools_Dir + @"CrowBar"))
            {
                Open_Folder(Tools_Dir + @"CrowBar");
            }
        }

        private void REPAK_INSTALL_FOLDER_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(Tools_Dir + @"RePak"))
            {
                Open_Folder(Tools_Dir + @"RePak");
            }
        }

        private void VTF_TOOL_FOLDER_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(Tools_Dir + @"VTF_Edit"))
            {
                Open_Folder(Tools_Dir + @"VTF_Edit");
            }
        }

        private void VPK_TOOL_FOLDER_Click(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(Tools_Dir + @"Titanfall2_VPK_Tool"))
            {
                Open_Folder(Tools_Dir + @"Titanfall2_VPK_Tool");
            }
        }
        private void LEGION_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"LEGION+") && File.Exists(Tools_Dir + @"LEGION+\" + "LegionPlus.exe"))
            {
                Start_Exe(Tools_Dir + @"LEGION+\" + "LegionPlus.exe");

            }
            else
            {
                Download_Zip_To_Path("LEGION+", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/LEGION%2B.zip");


            }

        }

        private void HARMONY_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"Harmony_VPK") && File.Exists(Tools_Dir + @"Harmony_VPK\" + "Harmony.VPK.Tool.exe"))
            {
                Start_Exe(Tools_Dir + @"Harmony_VPK\" + "Harmony.VPK.Tool.exe");

            }
            else
            {
                Download_Zip_To_Path("Harmony_VPK", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/Harmony_VPK.zip");


            }
        }

        private void CROWBAR_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"CrowBar") && File.Exists(Tools_Dir + @"CrowBar\" + "Crowbar.exe"))
            {
                Start_Exe(Tools_Dir + @"CrowBar\" + "Crowbar.exe");

            }
            else
            {
                Download_Zip_To_Path("CrowBar", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/CrowBar.zip");


            }
        }

        private void REPAK_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"RePak") && File.Exists(Tools_Dir + @"RePak\" + "RePak.exe"))
            {
                Start_Exe(Tools_Dir + @"RePak\" + "RePak.exe", Properties.Settings.Default.RePak_Launch_Args);
                //  Start_Command_Line(Tools_Dir + @"RePak\" + "RePak.exe", Tools_Dir + @"RePak",true, Properties.Settings.Default.RePak_Launch_Args);

            }
            else
            {
                Download_Zip_To_Path("RePak", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/RePak.zip");


            }
        }

        private void VTF_EDIT_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"VTF_Edit") && File.Exists(Tools_Dir + @"VTF_Edit\" + "VTFEdit.exe"))
            {
                Start_Exe(Tools_Dir + @"VTF_Edit\" + "VTFEdit.exe");

            }
            else
            {
                Download_Zip_To_Path("VTF_Edit", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/VTF_Edit.zip");


            }
        }

        private void VPK_TOOL_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"Titanfall2_VPK_Tool") && File.Exists(Tools_Dir + @"Titanfall2_VPK_Tool\" + "TitanFall VPK Tool.exe"))
            {
                Start_Exe(Tools_Dir + @"Titanfall2_VPK_Tool\" + "TitanFall VPK Tool.exe");

            }
            else
            {
                Download_Zip_To_Path("Titanfall2_VPK_Tool", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/Titanfall2_VPK_Tool.zip");


            }
        }

        private void LEGION_INSTALL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://wiki.modme.co/wiki/apps/Legion.html");
        }

        private void HARMONY_INSTALL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/harmonytf/HarmonyVPKTool");

        }

        private void CROWBAR_INSTALL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://steamcommunity.com/groups/CrowbarTool");

        }

        private void REPAK_INSTALL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/r-ex/RePak");

        }

        private void VTF_TOOL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://gamebanana.com/tools/95");

        }

        private void VPK_TOOL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/Wanty5883/Titanfall2/tree/master/tools");

        }
        private void MDL_TOOL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/headassbtw/mdlshit-binaries");

        }
        private void LEGION_INSTALL_STARTUP_ARGS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Create_New_Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Startup_Args_RpAk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.RePak_Launch_Args = Startup_Args_RpAk.Text;
            Properties.Settings.Default.Save();
        }

        private void Advanced_Repak_Click(object sender, RoutedEventArgs e)
        {
            if (Launch_Args_Window.Visibility == Visibility.Visible)
            {
                Launch_Args_Window.Visibility = Visibility.Hidden;
            }
            else
            {
                Launch_Args_Window.Visibility = Visibility.Visible;
            }
        }

        private void Startup_Args_RpAk_LostFocus(object sender, RoutedEventArgs e)
        {
            Startup_Args_RpAk.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#34FFFFFF");

        }

        private void Startup_Args_RpAk_GotFocus(object sender, RoutedEventArgs e)
        {
            Startup_Args_RpAk.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFFFF");

        }

        private void MDL_TOOL_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"MDL_SHIT") && File.Exists(Tools_Dir + @"MDL_SHIT\" + "mdlshit.exe"))
            {
                Start_Exe(Tools_Dir + @"MDL_SHIT\" + "mdlshit.exe");

            }
            else
            {
                Download_Zip_To_Path("MDL_SHIT", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/MDL_SHIT.zip");


            }
        }

        private void MDL_TOOL_FOLDER_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"MDL_SHIT"))
            {
                Open_Folder(Tools_Dir + @"MDL_SHIT");
            }
        }

        private void ESMT_TOOL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/Khalmee/ESMT");

        }

        private void ESMT_TOOL_FOLDER_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"ESMT_Easy_sound_modding_tool"))
            {
                Open_Folder(Tools_Dir + @"ESMT_Easy_sound_modding_tool");
            }
        }





        private void ESMT_TOOL_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"ESMT_Easy_sound_modding_tool") && File.Exists(Tools_Dir + @"ESMT_Easy_sound_modding_tool\" + "main.py"))
            {
                Start_Command_Line(Tools_Dir + @"ESMT_Easy_sound_modding_tool\" + "main.py", Tools_Dir + @"ESMT_Easy_sound_modding_tool");

            }
            else
            {
                Download_Zip_To_Path("ESMT_Easy_sound_modding_tool", "https://github.com/BigSpice/VTOL/raw/master/%5BTitanfall2_Downloadable_Tools%5D/ESMT.zip");


            }
        }

        private void ADV_TOOL_INSTALL_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"ADVOCATE_TOOL") && File.Exists(Tools_Dir + @"ADVOCATE_TOOL\" + "Advocate.exe"))
            {
                Start_Exe(Tools_Dir + @"ADVOCATE_TOOL\" + "Advocate.exe");

            }
            else
            {
                Download_Zip_To_Path("ADVOCATE_TOOL", "https://github.com/BigSpice/MISC_STORE/raw/main/ADVOCATE.zip");


            }
        }

        private void ADV_TOOL_FOLDER_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Tools_Dir + @"ADVOCATE_TOOL"))
            {
                Open_Folder(Tools_Dir + @"ADVOCATE_TOOL");
            }
        }

        private void ADV_TOOL_PAGE_Click(object sender, RoutedEventArgs e)
        {
            OPEN_WEBPAGE("https://github.com/ASpoonPlaysGames/Advocate");

        }
    }
}
