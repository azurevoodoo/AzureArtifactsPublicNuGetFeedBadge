namespace AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

public class PackageContent
{
    [JsonPropertyName("@type")]
    public string? Type { get; set; }
}
