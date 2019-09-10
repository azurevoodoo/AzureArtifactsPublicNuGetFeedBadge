using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index
{
    public partial class NuGetIndex
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }

        [JsonProperty("@context")]
        public Context Context { get; set; }
    }
}
