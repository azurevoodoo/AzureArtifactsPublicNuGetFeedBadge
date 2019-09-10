using System;
using System.Linq;
using AzureArtifactsPublicNuGetFeedBadge.Model;
using AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index;
using AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;

namespace AzureArtifactsPublicNuGetFeedBadge.Helpers
{
    public static class NuGetExtensions
    {
        public static (SemVersion version, DateTimeOffset published)? GetLatestVersion(this NuGetPackageRegistration nuGetPackageRegistration)
        {
            return nuGetPackageRegistration
                ?.Items
                ?.SelectMany(item => item.Items)
                ?.Select(item => (
                    version: SemVersion.TryParse(item.CatalogEntry.Version, out var semVersion) ? semVersion : SemVersion.Zero,
                    published: item.CatalogEntry.Published))
                .OrderByDescending(version => version.version)
                .FirstOrDefault();
        }

        public static string GetSemVerBaseUrl(this NuGetIndex index)
        {
            return index
                ?.Resources
                .Where(resource => resource.Type == "RegistrationsBaseUrl/Versioned")
                .Select(url => url.Id)
                .FirstOrDefault();
        }
    }
}
