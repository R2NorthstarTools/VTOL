//using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Utf8Json;
using Newtonsoft.Json;
//using Json.Net;

namespace VTOL
{

    public partial class Northstar_Json_Mods
    {
        public List<bool>? Mod { get; set; }
    }

    public partial class Northstar_Json_Mods
    {



        public static Northstar_Json_Mods FromJson(string json)
        {

            // List<Northstar_Json_Mods> oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Northstar_Json_Mods>>(json);
            Northstar_Json_Mods oMycustomclassname = JsonConvert.DeserializeObject<Northstar_Json_Mods>(json)!;

            return oMycustomclassname;

            //return JsonSerializer.Deserialize<Thunderstore_V1[]>(json);
        }












    }
}
