using System;
using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class NuGetPackageRegistration
    {
        [JsonProperty("@id")] public Uri Id { get; set; }

        [JsonProperty("@type")] public string[] Type { get; set; }

        [JsonProperty("count")] public long Count { get; set; }

        [JsonProperty("items")] public NuGetPackageRegistrationItem[] Items { get; set; }

        [JsonProperty("@context")] public Context Context { get; set; }
    }
}