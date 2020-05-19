using System;
using System.Net.Http;
using System.Threading.Tasks;
using AzureArtifactsPublicNuGetFeedBadge.Helpers;
using AzureArtifactsPublicNuGetFeedBadge.Model;
using AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index;
using AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace AzureArtifactsPublicNuGetFeedBadge
{
    public class Shield
    {
        private readonly HttpClient _client;

        public Shield(IHttpClientFactory httpClientFactory) 
            => _client = httpClientFactory.CreateClient(nameof(Shield));

        [FunctionName(nameof(Shield))]
        public async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, 
                "get", 
                Route = "{org}/{project}/{feed}/{packageId}"
            )] HttpRequest req,
            ILogger log,
            string org,
            string project,
            string feed,
            string packageId)
        {
            try
            {
                var indexUri =
                    $"https://pkgs.dev.azure.com/{Uri.EscapeDataString(org)}/{Uri.EscapeDataString(project)}/_packaging/{Uri.EscapeDataString(feed)}/nuget/v3/index.json";

                log.LogDebug("Requesting index from {0}", indexUri);

                var response = await _client.GetAsync(indexUri);

                if (!response.IsSuccessStatusCode)
                {
                    log.LogError("Failed to retrieve index {0} ({1})", indexUri, response.StatusCode);
                    return Shields.AzureArtifactsIndexGetFailedResult;
                }

                string semVerBaseUrl;
                try
                {
                    var index = await response.Content.ReadAsAsync<NuGetIndex>();

                    semVerBaseUrl = index.GetSemVerBaseUrl();
                }
                catch (Exception ex)
                {
                    log.LogError(ex, "Failed to parse NuGet index {0}.", indexUri);
                    return Shields.AzureArtifactsIndexParseFailedResult;
                }

                if (string.IsNullOrWhiteSpace(semVerBaseUrl))
                {
                    log.LogError("Failed to retrieve SemVer uri from index {0}", indexUri);
                    return Shields.AzureArtifactsIndexSemVerFailedResult;
                }

                var semVerUrl = $"{semVerBaseUrl}{Uri.EscapeDataString(packageId.ToLowerInvariant())}";

                var semVerResponse = await _client.GetAsync(semVerUrl);

                if (!semVerResponse.IsSuccessStatusCode)
                {
                    log.LogError("Failed to retrieve index {0} ({1})", semVerUrl, semVerResponse.StatusCode);
                    return Shields.AzureArtifactsSemVerGetFailedResult;
                }

                (SemVersion version, DateTimeOffset published)? latestVersion;
                try
                {
                    var nuGetPackageRegistration = await semVerResponse.Content.ReadAsAsync<NuGetPackageRegistration>();

                    latestVersion = nuGetPackageRegistration.GetLatestVersion();
                }
                catch (Exception ex)
                {
                    log.LogError(ex, "Failed to parse NuGet registration {0}.", semVerUrl);
                    return Shields.AzureArtifactsIndexParseFailedResult;
                }

                if (!latestVersion.HasValue)
                {
                    log.LogError("Failed to retrieve version from registration {0}", semVerUrl);
                    return Shields.AzureArtifactsSemVerFailedResult;
                }

                var shieldIoUrl = latestVersion.Value.version.GetShieldsIoUrl();

                var shieldResponse = await _client.GetAsync(shieldIoUrl);

                if (!semVerResponse.IsSuccessStatusCode)
                {
                    log.LogError("Failed to retrieve shield {0} ({1})", shieldIoUrl, shieldResponse.StatusCode);
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
                    log.LogError(ex, "Failed to download shield {0}.", shieldIoUrl);
                    return Shields.AzureArtifactsShieldIoReadFailedResult;
                }
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Unhandled Shield error.");
                return Shields.AzureArtifactsUnknownResult;
            }
        }
    }
}
