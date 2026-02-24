namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index;

public class Context
{
    [JsonPropertyName("@vocab")]
    public Uri? Vocab { get; set; }

    [JsonPropertyName("comment")]
    public Uri? Comment { get; set; }
}
