namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class Context
{
    [JsonPropertyName("@vocab")]
    public Uri? Vocab { get; set; }

    [JsonPropertyName("catalog")]
    public Uri? Catalog { get; set; }

    [JsonPropertyName("xsd")]
    public Uri? Xsd { get; set; }

    [JsonPropertyName("items")]
    public Dictionary<string, string> Items { get; set; } = [];

    [JsonPropertyName("commitTimeStamp")]
    public Dictionary<string, string> CommitTimeStamp { get; set; } = [];

    [JsonPropertyName("commitId")]
    public CommitId? CommitId { get; set; }

    [JsonPropertyName("count")]
    public CommitId? Count { get; set; }

    [JsonPropertyName("parent")]
    public Dictionary<string, string> Parent { get; set; } = [];

    [JsonPropertyName("tags")]
    public Dictionary<string, string> Tags { get; set; } = [];

    [JsonPropertyName("packageTargetFrameworks")]
    public Dictionary<string, string> PackageTargetFrameworks { get; set; } = [];

    [JsonPropertyName("dependencyGroups")]
    public Dictionary<string, string> DependencyGroups { get; set; } = [];

    [JsonPropertyName("dependencies")]
    public Dictionary<string, string> Dependencies { get; set; } = [];

    [JsonPropertyName("packageContent")]
    public PackageContent? PackageContent { get; set; }

    [JsonPropertyName("published")]
    public PackageContent? Published { get; set; }

    [JsonPropertyName("registration")]
    public PackageContent? Registration { get; set; }
}
