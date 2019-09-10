using System;
using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class NuGetPackageRegistrationItem
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public ItemItem[] Items { get; set; }

        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("parent")]
        public Uri Parent { get; set; }

        [JsonProperty("lower")]
        public string Lower { get; set; }

        [JsonProperty("upper")]
        public string Upper { get; set; }
    }
}