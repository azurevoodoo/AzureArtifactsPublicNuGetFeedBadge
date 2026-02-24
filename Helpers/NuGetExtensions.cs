using System.Linq;

namespace AzureArtifactsPublicNuGetFeedBadge.Helpers;

public static class NuGetExtensions
{
    public static (SemVersion version, DateTimeOffset? published)? GetLatestVersion(this NuGetPackageRegistration nuGetPackageRegistration)
    {
        return nuGetPackageRegistration
            ?.Items
            ?.SelectMany(item => item.Items)
            ?.Where(item => item.CatalogEntry?.Listed != false)
            ?.Select(item => (
                version: SemVersion.TryParse(item.CatalogEntry?.Version, out var semVersion) ? semVersion : SemVersion.Zero,
                published: item.CatalogEntry?.Published))
            .OrderByDescending(version => version.version)
            .FirstOrDefault();
    }

    public static string? GetSemVerBaseUrl(this NuGetIndex index)
    {
        return index
            ?.Resources
            .Where(resource => resource.Type == "RegistrationsBaseUrl/Versioned")
            .Select(url => url.Id)
            .FirstOrDefault();
    }
}
