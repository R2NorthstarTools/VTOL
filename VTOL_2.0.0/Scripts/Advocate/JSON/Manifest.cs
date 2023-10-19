using System;

namespace VTOL.Advocate.Conversion.JSON
{
#pragma warning disable IDE1006 // Naming Styles
    internal class Manifest
    {
        public string name { get; set; }
        public string version_number { get; set; }
        public string website_url { get; set; }
        public string[] dependencies { get; set; } = Array.Empty<string>();
        public string description { get; set; }
    }
#pragma warning restore IDE1006 // Naming Styles
}
