//using System.Text.Json;
//using Utf8Json;
using Newtonsoft.Json;
using System.Collections.Generic;
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

            Northstar_Json_Mods oMycustomclassname = JsonConvert.DeserializeObject<Northstar_Json_Mods>(json)!;

            return oMycustomclassname;

        }












    }
}
