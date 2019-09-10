using System;
using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class ItemItem
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("catalogEntry")]
        public CatalogEntry CatalogEntry { get; set; }

        [JsonProperty("packageContent")]
        public Uri PackageContent { get; set; }

        [JsonProperty("registration")]
        public Uri Registration { get; set; }
    }
}