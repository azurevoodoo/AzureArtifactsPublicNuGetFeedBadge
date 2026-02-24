namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class NuGetPackageRegistrationItem
{
    [JsonPropertyName("count")]
    public long? Count { get; set; }

    [JsonPropertyName("items")]
    public ItemItem[] Items { get; set; } = [];

    [JsonPropertyName("@id")]
    public Uri? Id { get; set; }

    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("parent")]
    public Uri? Parent { get; set; }

    [JsonPropertyName("lower")]
    public string? Lower { get; set; }

    [JsonPropertyName("upper")]
    public string? Upper { get; set; }
}
