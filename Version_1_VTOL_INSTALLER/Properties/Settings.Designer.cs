﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTOL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Ns_Startup {
            get {
                return ((bool)(this["Ns_Startup"]));
            }
            set {
                this["Ns_Startup"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Ns_Dedi {
            get {
                return ((bool)(this["Ns_Dedi"]));
            }
            set {
                this["Ns_Dedi"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Advanced_Mode {
            get {
                return ((bool)(this["Advanced_Mode"]));
            }
            set {
                this["Advanced_Mode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Automatic_Client_Updates {
            get {
                return ((bool)(this["Automatic_Client_Updates"]));
            }
            set {
                this["Automatic_Client_Updates"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool Sort_Mods {
            get {
                return ((bool)(this["Sort_Mods"]));
            }
            set {
                this["Sort_Mods"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool Warning_Close_EA {
            get {
                return ((bool)(this["Warning_Close_EA"]));
            }
            set {
                this["Warning_Close_EA"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Profile_Path {
            get {
                return ((string)(this["Profile_Path"]));
            }
            set {
                this["Profile_Path"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.github.com/repos/R2Northstar/Northstar/releases/latest")]
        public string Current_REPO_URL {
            get {
                return ((string)(this["Current_REPO_URL"]));
            }
            set {
                this["Current_REPO_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double Sort_Mods_By_Date {
            get {
                return ((double)(this["Sort_Mods_By_Date"]));
            }
            set {
                this["Sort_Mods_By_Date"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("R2Northstar")]
        public string Author {
            get {
                return ((string)(this["Author"]));
            }
            set {
                this["Author"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Northstar")]
        public string Repo {
            get {
                return ((string)(this["Repo"]));
            }
            set {
                this["Repo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Northstar.tf")]
        public string MasterServer_URL {
            get {
                return ((string)(this["MasterServer_URL"]));
            }
            set {
                this["MasterServer_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PackageAsSkin {
            get {
                return ((bool)(this["PackageAsSkin"]));
            }
            set {
                this["PackageAsSkin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.7.1")]
        public string Version {
            get {
                return ((string)(this["Version"]));
            }
            set {
                this["Version"] = value;
            }
        }
    }
}
