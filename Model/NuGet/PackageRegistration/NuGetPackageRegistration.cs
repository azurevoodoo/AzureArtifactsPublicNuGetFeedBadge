namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class NuGetPackageRegistration
{
    [JsonPropertyName("@id")]
    public Uri? Id { get; set; }

    [JsonPropertyName("@type")]
    public string[]? Type { get; set; }

    [JsonPropertyName("count")]
    public long? Count { get; set; }

    [JsonPropertyName("items")]
    public NuGetPackageRegistrationItem[] Items { get; set; } = [];

    [JsonPropertyName("@context")]
    public Context? Context { get; set; }
}
