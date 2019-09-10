using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration
{
    public class Context
    {
        [JsonProperty("@vocab")]
        public Uri Vocab { get; set; }

        [JsonProperty("catalog")]
        public Uri Catalog { get; set; }

        [JsonProperty("xsd")]
        public Uri Xsd { get; set; }

        [JsonProperty("items")]
        public Dictionary<string, string> Items { get; set; }

        [JsonProperty("commitTimeStamp")]
        public Dictionary<string, string> CommitTimeStamp { get; set; }

        [JsonProperty("commitId")]
        public CommitId CommitId { get; set; }

        [JsonProperty("count")]
        public CommitId Count { get; set; }

        [JsonProperty("parent")]
        public Dictionary<string, string> Parent { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; }

        [JsonProperty("packageTargetFrameworks")]
        public Dictionary<string, string> PackageTargetFrameworks { get; set; }

        [JsonProperty("dependencyGroups")]
        public Dictionary<string, string> DependencyGroups { get; set; }

        [JsonProperty("dependencies")]
        public Dictionary<string, string> Dependencies { get; set; }

        [JsonProperty("packageContent")]
        public PackageContent PackageContent { get; set; }

        [JsonProperty("published")]
        public PackageContent Published { get; set; }

        [JsonProperty("registration")]
        public PackageContent Registration { get; set; }
    }
}