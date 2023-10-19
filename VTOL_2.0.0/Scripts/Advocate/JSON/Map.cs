using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VTOL.Advocate.Conversion.JSON
{
    internal class Map
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("assetsDir")]
        public string AssetsDir { get; init; }

        [JsonPropertyName("outputDir")]
        public string OutputDir { get; init; }

        [JsonPropertyName("version")]
        public int Version { get; init; } = 7; // defaults to 7 (titanfall 2)

        // this could in theory have non-texture assets, but this will do for now
        [JsonPropertyName("files")]
        public List<TextureAsset> Files { get; private set; } = new();

        public Map(string name, string assetsDir, string outputDir)
        {
            Name = name;
            AssetsDir = assetsDir;
            OutputDir = outputDir;
        }

        public void AddTextureAsset(string path, string? starpakPath = null)
        {
            TextureAsset asset = new() { Path = path, DisableStreaming = starpakPath == null };
            Files.Add(asset);
        }
    }

    internal class TextureAsset
    {
        [JsonPropertyName("$type")]
        public string Type { get; } = "txtr";

        [JsonPropertyName("path")]
        public string Path { get; init; } = "";

        [JsonPropertyName("disableStreaming")]
        public bool DisableStreaming { get; init; } = true;

        [JsonPropertyName("saveDebugName")]
        public bool SaveDebugName { get; init; } = true;
    }
}
