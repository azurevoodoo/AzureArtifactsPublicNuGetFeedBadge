using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class PackageContent
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
    }
}