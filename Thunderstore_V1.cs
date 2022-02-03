using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL
{
    public partial class Thunderstore_V1
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("package_url")]
        public string PackageUrl { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonPropertyName("date_updated")]
        public DateTime DateUpdated { get; set; }

        [JsonPropertyName("uuid4")]
        public string Uuid4 { get; set; }

        [JsonPropertyName("rating_score")]
        public int RatingScore { get; set; }

        [JsonPropertyName("is_pinned")]
        public bool IsPinned { get; set; }

        [JsonPropertyName("is_deprecated")]
        public bool IsDeprecated { get; set; }

        [JsonPropertyName("has_nsfw_content")]
        public bool HasNsfwContent { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("versions")]
        public List<versions> versions { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class versions
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("version_number")]
        public string VersionNumber { get; set; }

        [JsonPropertyName("dependencies")]
        public List<string> Dependencies { get; set; }

        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("downloads")]
        public int Downloads { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonPropertyName("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("uuid4")]
        public string Uuid4 { get; set; }

        [JsonPropertyName("file_size")]
        public int FileSize { get; set; }
    }

   


    public partial class Thunderstore_V1
    {



        public static Thunderstore_V1[] FromJson(string json)
        {
            return JsonSerializer.Deserialize<Thunderstore_V1[]>(json);
        }





    }

}
