using System;
using Newtonsoft.Json;

namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index
{
    public class Context
    {
        [JsonProperty("@vocab")] public Uri Vocab { get; set; }

        [JsonProperty("comment")] public Uri Comment { get; set; }
    }
}