namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index;

public class Resource
{
    [JsonPropertyName("@id")]
    public string? Id { get; set; }

    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("clientVersion")]
    public string? ClientVersion { get; set; }
}
