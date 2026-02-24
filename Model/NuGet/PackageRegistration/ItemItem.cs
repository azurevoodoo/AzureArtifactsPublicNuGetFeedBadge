namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class ItemItem
{
    [JsonPropertyName("@id")]
    public Uri? Id { get; set; }

    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("catalogEntry")]
    public CatalogEntry? CatalogEntry { get; set; }

    [JsonPropertyName("packageContent")]
    public Uri? PackageContent { get; set; }

    [JsonPropertyName("registration")]
    public Uri? Registration { get; set; }
}
