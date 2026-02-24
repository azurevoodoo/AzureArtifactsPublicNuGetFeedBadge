using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AzureArtifactsPublicNuGetFeedBadge;

/// <summary>
/// HTTP-triggered function that returns a version badge (SVG) for a NuGet package on Azure Artifacts.
/// </summary>
/// <param name="httpClientFactory">The HTTP client factory.</param>
/// <param name="logger">The logger.</param>
public partial class Shield(HttpClient client, ILogger<Shield> logger)
{
    private readonly ILogger<Shield> _logger = logger;

    /// <summary>
    /// Runs the shield function: fetches package version from Azure Artifacts and returns a shields.io badge SVG.
    /// </summary>
    /// <param name="req">The HTTP request.</param>
    /// <param name="org">Azure DevOps organization (from route).</param>
    /// <param name="project">Project name (from route).</param>
    /// <param name="feed">Artifacts feed name (from route).</param>
    /// <param name="packageId">NuGet package id (from route).</param>
    /// <returns>An <see cref="IActionResult"/> containing the badge SVG or an error badge.</returns>
    [Function(nameof(Shield))]
    public async Task<IActionResult> Run(
        [HttpTrigger(
            AuthorizationLevel.Anonymous,
            "get",
            Route = "{org}/{project}/{feed}/{packageId}"
        )] HttpRequest req,
        string org,
        string project,
        string feed,
        string packageId)
    {
        if (string.IsNullOrEmpty(org) || string.IsNullOrEmpty(project) || string.IsNullOrEmpty(feed) || string.IsNullOrEmpty(packageId))
        {
            LogMissingRouteValues();
            return Shields.AzureArtifactsUnknownResult;
        }

        try
        {
            var indexUri =
                $"https://pkgs.dev.azure.com/{Uri.EscapeDataString(org)}/{Uri.EscapeDataString(project)}/_packaging/{Uri.EscapeDataString(feed)}/nuget/v3/index.json";

            LogRequestingIndex(indexUri);

            var response = await client.GetAsync(indexUri);

            if (!response.IsSuccessStatusCode)
            {
                LogIndexGetFailed(indexUri, (int)response.StatusCode);
                return Shields.AzureArtifactsIndexGetFailedResult;
            }

            string? semVerBaseUrl;
            try	
            {
                var json = await response.Content.ReadAsStringAsync();
                var index = JsonSerializer.Deserialize(json, ModelJsonContext.Default.NuGetIndex);
                semVerBaseUrl = index?.GetSemVerBaseUrl();
            }
            catch (Exception ex)
            {
                LogIndexParseFailed(ex, indexUri);
                return Shields.AzureArtifactsIndexParseFailedResult;
            }

            if (string.IsNullOrWhiteSpace(semVerBaseUrl))
            {
                LogSemVerUriFailed(indexUri);
                return Shields.AzureArtifactsIndexSemVerFailedResult;
            }

            var semVerUrl = $"{semVerBaseUrl}{Uri.EscapeDataString(packageId.ToLowerInvariant())}";

            using var semVerResponse = await client.GetAsync(semVerUrl);

            if (!semVerResponse.IsSuccessStatusCode)
            {
                LogSemVerGetFailed(semVerUrl, (int)semVerResponse.StatusCode);
                return Shields.AzureArtifactsSemVerGetFailedResult;
            }

            (SemVersion version, DateTimeOffset? published)? latestVersion;
            try
            {
                using var json = await semVerResponse.Content.ReadAsStreamAsync();
                var nuGetPackageRegistration = await JsonSerializer.DeserializeAsync(json, ModelJsonContext.Default.NuGetPackageRegistration);
                latestVersion = nuGetPackageRegistration?.GetLatestVersion();
            }
            catch (Exception ex)
            {
                LogRegistrationParseFailed(ex, semVerUrl);
                return Shields.AzureArtifactsIndexParseFailedResult;
            }

            if (!latestVersion.HasValue)
            {
                LogVersionRetrieveFailed(semVerUrl);
                return Shields.AzureArtifactsSemVerFailedResult;
            }

            var shieldIoUrl = latestVersion.Value.version.GetShieldsIoUrl();

            var shieldResponse = await client.GetAsync(shieldIoUrl);

            if (!shieldResponse.IsSuccessStatusCode)
            {
                LogShieldIoGetFailed(shieldIoUrl, (int)shieldResponse.StatusCode);
                return Shields.AzureArtifactsShieldIoGetFailedResult;
            }

            try
            {
                return new FileStreamCacheResult(
                    await shieldResponse.Content.ReadAsStreamAsync(),
                    Shields.SvgContentType
                )
                {
                    EntityTag = new EntityTagHeaderValue($"\"{org}_{project}_{feed}_{packageId}_{latestVersion.Value.version.VersionString}\""),
                    LastModified = latestVersion.Value.published
                };
            }
            catch (Exception ex)
            {
                LogShieldIoReadFailed(ex, shieldIoUrl);
                return Shields.AzureArtifactsShieldIoReadFailedResult;
            }
        }
        catch (Exception ex)
        {
            LogUnhandledError(ex);
            return Shields.AzureArtifactsUnknownResult;
        }
    }
}
