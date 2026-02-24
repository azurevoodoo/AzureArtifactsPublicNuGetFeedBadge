namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index;

public partial class NuGetIndex
{
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("resources")]
    public Resource[] Resources { get; set; } = [];

    [JsonPropertyName("@context")]
    public Context? Context { get; set; }
}
