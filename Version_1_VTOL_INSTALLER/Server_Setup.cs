using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL
{
    public partial class Server_Setup
    {
      
        [JsonPropertyName("Startup_Arguments")]
        public List<Startup_Arguments> Startup_Arguments { get; set; }
        [JsonPropertyName("Convar_Arguments")]
        public List<Convar_Arguments> Convar_Arguments { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Startup_Arguments
    {
        [JsonPropertyName("Display_Val")]
        public string Name { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("Default")]
        public string Default { get; set; }

        [JsonPropertyName("Description")]
        public string Description_Tooltip { get; set; }

        [JsonPropertyName("ARG")]
        public string ARG { get; set; }

        [JsonPropertyName("List")]
        public string[] List { get; set; }
    }

    public class Convar_Arguments
    {
        [JsonPropertyName("Display_Val")]
        public string Name { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("ARG")]
        public string ARG { get; set; }

        [JsonPropertyName("Default")]
        public string Default { get; set; }

        [JsonPropertyName("Description")]
        public string Description_Tooltip { get; set; }

        [JsonPropertyName("List")]
        public string[] List { get; set; }
    }


    public partial class Server_Setup
    {



        public static Server_Setup FromJson(string json)
        {
                return JsonSerializer.Deserialize<Server_Setup>(json);
        }





    }
}

