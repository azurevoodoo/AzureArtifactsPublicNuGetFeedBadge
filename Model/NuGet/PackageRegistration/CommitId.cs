using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class CommitId
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
    }
}