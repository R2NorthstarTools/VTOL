//using System.Text.Json;
//using Utf8Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
//using Json.Net;

namespace VTOL
{
    public partial class Thunderstore_V1
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("full_name")]
        public string? FullName { get; set; }

        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("package_url")]
        public string? PackageUrl { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("date_updated")]
        public DateTime DateUpdated { get; set; }

        [JsonProperty("uuid4")]
        public string? Uuid4 { get; set; }

        [JsonProperty("rating_score")]
        public int RatingScore { get; set; }

        [JsonProperty("is_pinned")]
        public bool IsPinned { get; set; }

        [JsonProperty("is_deprecated")]
        public bool IsDeprecated { get; set; }

        [JsonProperty("has_nsfw_content")]
        public bool HasNsfwContent { get; set; }

        [JsonProperty("categories")]
        public List<string?> Categories { get; set; }

        [JsonProperty("versions")]
        public List<versions> versions { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class versions
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("full_name")]
        public string? FullName { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }

        [JsonProperty("version_number")]
        public string? VersionNumber { get; set; }

        [JsonProperty("dependencies")]
        public List<string?> Dependencies { get; set; }

        [JsonProperty("download_url")]
        public string? DownloadUrl { get; set; }

        [JsonProperty("downloads")]
        public int Downloads { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("website_url")]
        public string? WebsiteUrl { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("uuid4")]
        public string? Uuid4 { get; set; }

        [JsonProperty("file_size")]
        public int FileSize { get; set; }
    }




    public partial class Thunderstore_V1
    {



        public static Thunderstore_V1[] FromJson(string json)
        {

            Thunderstore_V1[] oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<Thunderstore_V1[]>(json);

            return oMycustomclassname;

            //return JsonSerializer.Deserialize<Thunderstore_V1[]>(json);
        }




    }

}
