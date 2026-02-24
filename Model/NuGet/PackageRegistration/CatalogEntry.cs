namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class CatalogEntry
{
    [JsonPropertyName("@id")]
    public Uri? Id { get; init; }

    [JsonPropertyName("@type")]
    public string? Type { get; init; }

    [JsonPropertyName("authors")]
    public string? Authors { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("iconUrl")]
    public Uri? IconUrl { get; init; }

    [JsonPropertyName("id")]
    public string? CatalogEntryId { get; init; }

    [JsonPropertyName("language")]
    public string? Language { get; init; }

    [JsonPropertyName("licenseUrl")]
    public Uri? LicenseUrl { get; init; }

    [JsonPropertyName("listed")]
    public bool? Listed { get; init; }

    [JsonPropertyName("minClientVersion")]
    public string? MinClientVersion { get; init; }

    [JsonPropertyName("projectUrl")]
    public Uri? ProjectUrl { get; init; }

    [JsonPropertyName("published")]
    public DateTimeOffset? Published { get; init; }

    [JsonPropertyName("requireLicenseAcceptance")]
    public bool? RequireLicenseAcceptance { get; init; }

    [JsonPropertyName("summary")]
    public string? Summary { get; init; }

    [JsonPropertyName("tags")]
    public string[] Tags { get; init; } = [];

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }
}
