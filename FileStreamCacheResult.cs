using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace AzureArtifactsPublicNuGetFeedBadge
{
    public class FileStreamCacheResult : FileStreamResult
    {
        public FileStreamCacheResult(Stream fileStream, string contentType)
            : base(fileStream, contentType)
        {
        }

        /// <summary>
        /// Creates a new <see cref="FileStreamResult"/> instance with
        /// the provided <paramref name="fileStream"/> and the
        /// provided <paramref name="contentType"/>.
        /// </summary>
        /// <param name="fileStream">The stream with the file.</param>
        /// <param name="contentType">The Content-Type header of the response.</param>
        public FileStreamCacheResult(Stream fileStream, MediaTypeHeaderValue contentType)
            : base(fileStream, contentType)
        {
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.HttpContext.Response.Headers.Add("Cache-Control", "public, max-age=600");
            return base.ExecuteResultAsync(context);
        }
    }
}