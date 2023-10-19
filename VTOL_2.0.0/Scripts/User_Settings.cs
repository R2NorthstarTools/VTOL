namespace VTOL
{
    using Newtonsoft.Json;

    public partial class User_Settings
    {
        [JsonProperty("Current_Version")]
        public string CurrentVersion { get; set; }

        [JsonProperty("Theme", NullValueHandling = NullValueHandling.Ignore)]
        public string Theme { get; set; }

        [JsonProperty("Master_Server_Url", NullValueHandling = NullValueHandling.Ignore)]
        public string MasterServerUrl { get; set; }

        [JsonProperty("Repo", NullValueHandling = NullValueHandling.Ignore)]
        public string Repo { get; set; }

        [JsonProperty("Language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("Repo_Url", NullValueHandling = NullValueHandling.Ignore)]
        public string RepoUrl { get; set; }

        [JsonProperty("Profile_Path", NullValueHandling = NullValueHandling.Ignore)]
        public string Profile_Path { get; set; }

        [JsonProperty("Northstar_Install_Location", NullValueHandling = NullValueHandling.Ignore)]
        public string NorthstarInstallLocation { get; set; }

        [JsonProperty("MasterServer_URL_CN", NullValueHandling = NullValueHandling.Ignore)]
        public string MasterServerUrlCn { get; set; }

        [JsonProperty("Current_REPO_URL_CN", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentRepoUrlCn { get; set; }

        [JsonProperty("Author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }
        [JsonProperty("Auto_Close_VTOL", NullValueHandling = NullValueHandling.Ignore)]
        public bool Auto_Close_VTOL { get; set; }
        [JsonProperty("Auto_Update_Northstar", NullValueHandling = NullValueHandling.Ignore)]
        public bool Auto_Update_Northstar { get; set; }
    }


    public partial class User_Settings
    {
        public static User_Settings FromJson(string json)
        {

            User_Settings User_Vars = Newtonsoft.Json.JsonConvert.DeserializeObject<User_Settings>(json);

            return User_Vars;

        }




    }
}