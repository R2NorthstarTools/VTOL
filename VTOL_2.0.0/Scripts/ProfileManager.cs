using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL.Scripts
{
   //RUN PROFILES AFTER
//I REPEAT
//AFTER!
//INIT();
    class Profile
    {
        public string name = "Northstar";
        public string gameDir;
        public string northstarVersion;
        public string iconPath = "/Resources/Icons/Main_UI/northstar_icon_ZfV_icon.png";
        public string repositoryUrl = "https://github.com/R2Northstar/Northstar";
        public string masterserverUrl = "https://northstar.tf";
        public string language = "en";

        // Constructor for the basic Profile type
        public Profile(string Name, string GameDir, string NorthstarVersion, string IconPath, string RepositoryUrl, string MasterserverUrl, string language)
        {
            name = Name;
            gameDir = GameDir;
            northstarVersion = Properties.Settings.Default.Version;
            iconPath = IconPath;
            repositoryUrl = RepositoryUrl;
            masterserverUrl = MasterserverUrl;
            language = language;

        }
    }




    class ProfileManager
    {
        public Profile currentProfile;
        public List<Profile> m_LoadedProfiles = new List<Profile>();
        public string DocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string[] files_p;
        JObject Config_Json = new JObject();

        public ProfileManager()
        {
            
        }
        
        // Initialize the whole thing, which accepts a predefined Default Profile for NorthstarCN maybe
        public bool InitializeProfiles(Profile FallbackProfile) 
        {
            files_p = FindFirstFiles(DocumentsFolder + @"\VTOL_DATA\Profiles\", "Profile.Json");
            //Construct a default profile here, just for testing
            //defaultprofile: the default profile for falling back when profile is out of control.
            //if profile 
            if (ProfileConfigExists())
            {
                LoadProfiles();// Just load the profile to memory if local config is found.
                return true;
            }
            else 
            {
                // Create structures for C# to not panic about folders and files not found.
                if (InitializeLocalProfileConfig())
                {
                    // If no profile is found, use the fallback profile or create a new one if no fallback specified.
                    if (FallbackProfile == null )
                    {
                        Profile defaultprofile = new Profile(
                            "Northstar",
                            "test",// Test value, should be location where the game is installed
                            Properties.Settings.Default.Version, //IDK how to get version from here, so just temporary test
                            "/Resources/Icons/Main_UI/northstar_icon_ZfV_icon.png",
                            "https://github.com/R2Northstar/Northstar",
                            "https://northstar.tf",
                            "en");

                        m_LoadedProfiles.Add(defaultprofile);
                    }
                    else {
                        m_LoadedProfiles.Add(FallbackProfile);
                    }


                    WriteProfiles();
                    return true;
                }
                else 
                {
                    // whoa harddrive go boom? how could this fail?
                }
                
            }



            return false;

        }
        public string[] FindFirstFiles(string path, string searchPattern)
        {
            try
            {
                string[] files;

                try
                {
                    // Exception could occur due to insufficient permission.
                    files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
                }
                catch (Exception ex)
                {


                    return null;
                }

                // If matching files have been found, return the first one.
                if (files.Length > 0)
                {
                    return files;
                }
                else
                {
                    // Otherwise find all directories.
                    string[] directories;

                    try
                    {
                        // Exception could occur due to insufficient permission.
                        directories = Directory.GetDirectories(path);
                    }
                    catch (Exception)
                    {
                        return null;
                    }

                    // Iterate through each directory and call the method recursivly.
                    foreach (string directory in directories)
                    {
                        string[] files_ = FindFirstFiles(directory, searchPattern);

                        // If we found a file, return it (and break the recursion).
                        if (files_ != null)
                        {
                            return files_;
                        }
                    }
                }
                return null;

            }



            catch (Exception ex)
            {

                //Log.Error(ex, $"A crash happened at {DateTime.Now.ToString("yyyy - MM - dd HH - mm - ss.ff", CultureInfo.InvariantCulture)}{Environment.NewLine}");

            }
            // If no file was found (neither in this directory nor in the child directories)
            // simply return string.Empty.
            return null;
        }
        public void SelectProfile(int profileidx) 
        {
            currentProfile = (m_LoadedProfiles[profileidx]);
            ExecuteProfile();
        }
        public void SelectProfile(string profilename) 
        {
            for (int i = 0; i < m_LoadedProfiles.Count; i++) 
            {
                if (m_LoadedProfiles[i].name == profilename) 
                {
                    currentProfile=(m_LoadedProfiles[i]);
                    ExecuteProfile();
                }
            }
            
        }

        public void ExecuteProfile() 
        {
            // Do post profile selection things with currentProfile here.
            Console.WriteLine("Do post profile selection things with currentProfile here.");

        }
        public bool ProfileConfigExists() 
        {
            // TODO: test some file structures and config file integrity.
            Console.WriteLine("Test some file structures and config file integrity");

            return false;
        }
        public bool WriteProfiles()
        {
            //if there are issues running this function , eject it from the worker thread and run it syncronously
            //And make Sure to use your "Dispatch()" on an any and all Ui calls in these functions!
            BackgroundWorker worker_o = new BackgroundWorker();
            worker_o.DoWork += (sender, e) =>
            {
                if (!Directory.Exists(DocumentsFolder + @"\VTOL_DATA\Profiles"))
                {
                    Directory.CreateDirectory(DocumentsFolder + @"\VTOL_DATA\Profiles");

                }
                string Profiles_Folder = (DocumentsFolder + @"\VTOL_DATA\Profiles\");
                foreach (var Profile in m_LoadedProfiles)
                {
                    if (!Directory.Exists(Profiles_Folder + Profile.name))
                    {
                        Directory.CreateDirectory(Profiles_Folder + Profile.name);
                    }
                    if (File.Exists(Profiles_Folder + Profile.name + @"\Profile.Json"))
                    {
                        Console.WriteLine("Already Present");


                    }
                    else
                    {
                        dynamic User_Profile_Json = new JObject();
                        User_Profile_Json.name = Profile.name;
                        User_Profile_Json.Master_Server_Url = Profile.masterserverUrl;
                        User_Profile_Json.Language = Profile.language;
                        User_Profile_Json.Northstar_Install_Location = Profile.gameDir;
                        User_Profile_Json.version = Profile.northstarVersion;
                        User_Profile_Json.Repo_Url = Profile.repositoryUrl;

                        var User_Profile_Json_String = Newtonsoft.Json.JsonConvert.SerializeObject(User_Profile_Json);

                        using (var StreamWriter = new StreamWriter(Profiles_Folder + Profile.name + @"\Profile.Json", false))
                        {
                            StreamWriter.WriteLine(User_Profile_Json_String.ToString());
                            StreamWriter.Close();
                        }
                    }
                }


            };

            worker_o.RunWorkerAsync();
            worker_o.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_o_RunWorkerCompleted);
            return true;


            // TODO: Dump all profiles from memeory to Disk
        }
        private void worker_o_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Written the profiles - " + string.Join(" , ", m_LoadedProfiles + "  - To the Disk at the Location - " + DocumentsFolder + @"\VTOL_DATA\Profiles\"));

        }
        public void LoadProfiles()
        {
            // Clear the loaded profiles from RAM, then repopulate it from disk.
            // Console.WriteLine(string.Join(",",FindFirstFiles(DocumentsFolder + @"\VTOL_DATA\Profiles\", "Profile.Json")));
            if (files_p.Count() > 0)
            {
                Console.WriteLine(string.Join(",", files_p));

                foreach (var file in files_p)
                {
                    dynamic User_Profile_Json = new JObject();
                    string User_Settings_String = System.IO.File.ReadAllText(file);
                    User_Profile_Json = User_Profile_Json.FromJson(User_Settings_String);
                    Profile New_P = new Profile(User_Profile_Json.name, User_Profile_Json.Northstar_Install_Location, User_Profile_Json.version, "", User_Profile_Json.Repo_Url, User_Profile_Json.Master_Server_Url, User_Profile_Json.Language);
                    m_LoadedProfiles.Add(New_P);
                }
            }

           // m_LoadedProfiles.Clear();
            Console.WriteLine("Loading Profiles from disk");
            Console.WriteLine(string.Join(",", m_LoadedProfiles));

            // TODO: load profiles from disk here
        }
        public bool InitializeLocalProfileConfig()
        {
            string Profiles_Folder = (DocumentsFolder + @"\VTOL_DATA\Profiles\");

            ////TODO: build Profile config
            //Console.WriteLine("build Profile config");
            //if (!File.Exists(Profiles_Folder + @"\Config.Json"))
            //{
            //    Config_Json.Add("profilelist", string.Join("\n", m_LoadedProfiles));
            //    if (files_p.Count() > 0)
            //    {
            //        Config_Json.Add("last_selected", files_p.First());

            //    }
            //    else
            //    {
            //        Config_Json.Add("last_selected", "");


            //    }


            //    var Config_Json_String = Newtonsoft.Json.JsonConvert.SerializeObject(Config_Json);

            //    foreach(string f in files_p)
            //    {
            //           var Item = new JObject
            //    {
            //        { "Path",f }
            //    };
            //        var Obj = new JObject
            //    {
            //        { Path.GetFileNameWithoutExtension(f), Item }
            //    };
            //        Config_Json.Add("Profiles", Obj);

            //    }

            //    using (var StreamWriter = new StreamWriter(Profiles_Folder  + @"\Config.Json", false))
            //    {
            //        StreamWriter.WriteLine(Config_Json_String.ToString());
            //        StreamWriter.Close();
            //    }

            //}
            //else
            //{
            //    string Config_Json_String = System.IO.File.ReadAllText(Profiles_Folder + @"\Config.Json");
            //    Config_Json = JObject.Parse(Config_Json_String);
            //     //= Config_Json.GetValue("profilelist").ToString().Split(',').ToList();

            //}
            return true;
        }
    }
}
