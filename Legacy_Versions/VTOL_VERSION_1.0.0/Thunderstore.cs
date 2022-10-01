using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL_DEPRECEATED
{
    public partial class Thunderstore
    {
        [JsonPropertyName("next")]

        public string next { get; set; }
        [JsonPropertyName("previous")]

        public object previous { get; set; }
        [JsonPropertyName("results")]

        public Result[] results { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("namespace")]

        public string _namespace { get; set; }
        [JsonPropertyName("name")]

        public string name { get; set; }
        [JsonPropertyName("full_name")]

        public string full_name { get; set; }
        [JsonPropertyName("owner")]

        public string owner { get; set; }
        [JsonPropertyName("package_url")]

        public string package_url { get; set; }
        [JsonPropertyName("date_created")]

        public DateTime date_created { get; set; }
        [JsonPropertyName("date_updated")]

        public DateTime date_updated { get; set; }
        [JsonPropertyName("rating_score")]

        public int rating_score { get; set; }
        [JsonPropertyName("is_pinned")]

        public bool is_pinned { get; set; }
        [JsonPropertyName("is_deprecated")]

        public bool is_deprecated { get; set; }
        [JsonPropertyName("total_downloads")]

        public int total_downloads { get; set; }
        [JsonPropertyName("latest")]

        public Latest latest { get; set; }
        [JsonPropertyName("community_listings")]

        public Community_Listings[] community_listings { get; set; }
    }

    public class Latest
    {
        [JsonPropertyName("namespace")]

        public string _namespace { get; set; }
        [JsonPropertyName("name")]

        public string name { get; set; }
        [JsonPropertyName("version_number")]

        public string version_number { get; set; }
        [JsonPropertyName("full_name")]

        public string full_name { get; set; }
        [JsonPropertyName("description")]

        public string description { get; set; }
        [JsonPropertyName("icon")]

        public string icon { get; set; }
        [JsonPropertyName("dependencies")]

        public string[] dependencies { get; set; }
        [JsonPropertyName("download_url")]

        public string download_url { get; set; }
        [JsonPropertyName("downloads")]

        public int downloads { get; set; }
        [JsonPropertyName("date_created")]

        public DateTime date_created { get; set; }
        [JsonPropertyName("website_url")]

        public string website_url { get; set; }
        [JsonPropertyName("is_active")]

        public bool is_active { get; set; }
    }

    public class Community_Listings
    {
        [JsonPropertyName("has_nsfw_content")]

        public bool has_nsfw_content { get; set; }
        [JsonPropertyName("categories")]

        public string[] categories { get; set; }

        [JsonPropertyName("community")]
        public string community { get; set; }
        [JsonPropertyName("review_status")]

        public string review_status { get; set; }
    }

    public partial class Thunderstore
    {



        public static Thunderstore FromJson(string json)
        {
            return JsonSerializer.Deserialize<Thunderstore>(json);
        }





    }
}
