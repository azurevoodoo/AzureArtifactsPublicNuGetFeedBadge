using System;
using Microsoft.Extensions.Logging;

namespace AzureArtifactsPublicNuGetFeedBadge;

/// <summary>
/// LoggerMessage source-generated logging for <see cref="Shield"/>.
/// </summary>
public partial class Shield
{
    [LoggerMessage(Level = LogLevel.Warning, Message = "Missing route values (org, project, feed, packageId).")]
    private partial void LogMissingRouteValues();

    [LoggerMessage(Level = LogLevel.Debug, Message = "Requesting index from {IndexUri}")]
    private partial void LogRequestingIndex(string indexUri);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to retrieve index {IndexUri} ({StatusCode})")]
    private partial void LogIndexGetFailed(string indexUri, int statusCode);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to parse NuGet index {IndexUri}.")]
    private partial void LogIndexParseFailed(Exception ex, string indexUri);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to retrieve SemVer uri from index {IndexUri}")]
    private partial void LogSemVerUriFailed(string indexUri);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to retrieve index {SemVerUrl} ({StatusCode})")]
    private partial void LogSemVerGetFailed(string semVerUrl, int statusCode);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to parse NuGet registration {SemVerUrl}.")]
    private partial void LogRegistrationParseFailed(Exception ex, string semVerUrl);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to retrieve version from registration {SemVerUrl}")]
    private partial void LogVersionRetrieveFailed(string semVerUrl);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to retrieve shield {ShieldIoUrl} ({StatusCode})")]
    private partial void LogShieldIoGetFailed(string shieldIoUrl, int statusCode);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to download shield {ShieldIoUrl}.")]
    private partial void LogShieldIoReadFailed(Exception ex, string shieldIoUrl);

    [LoggerMessage(Level = LogLevel.Error, Message = "Unhandled Shield error.")]
    private partial void LogUnhandledError(Exception ex);
}
