using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace AzureArtifactsPublicNuGetFeedBadge;

/// <summary>
/// An <see cref="IActionResult"/> that streams a file and sets Cache-Control for HTTP caching.
/// </summary>
public class FileStreamCacheResult : FileStreamResult
{
    /// <summary>
    /// Creates a new <see cref="FileStreamCacheResult"/> with the given stream and content type.
    /// </summary>
    /// <param name="fileStream">The stream containing the file content.</param>
    /// <param name="contentType">The Content-Type header value (e.g. image/svg+xml).</param>
    public FileStreamCacheResult(Stream fileStream, string contentType)
        : base(fileStream, contentType)
    {
    }

    /// <summary>
    /// Creates a new <see cref="FileStreamCacheResult"/> with the given stream and content type.
    /// </summary>
    /// <param name="fileStream">The stream containing the file content.</param>
    /// <param name="contentType">The Content-Type header of the response.</param>
    public FileStreamCacheResult(Stream fileStream, MediaTypeHeaderValue contentType)
        : base(fileStream, contentType)
    {
    }

    /// <inheritdoc />
    public override Task ExecuteResultAsync(ActionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.HttpContext.Response.Headers.CacheControl = "public, max-age=600";
        return base.ExecuteResultAsync(context);
    }
}