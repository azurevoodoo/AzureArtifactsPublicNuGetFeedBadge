using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index
{
    public class Resource
    {
        [JsonProperty("@id")] public string Id { get; set; }

        [JsonProperty("@type")] public string Type { get; set; }

        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("clientVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientVersion { get; set; }
    }
}