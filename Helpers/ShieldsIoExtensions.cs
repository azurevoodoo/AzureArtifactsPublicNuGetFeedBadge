using System.Text;

namespace AzureArtifactsPublicNuGetFeedBadge.Helpers;

public static class ShieldsIoExtensions
{
    public static string ShieldsIoEscape(this string value)
    {
        return value
            .Aggregate(
                new StringBuilder(),
                (sb, c) =>
                {
                    return c switch
                    {
                        '_' => sb.Append("__"),
                        '-' => sb.Append("--"),
                        ' ' => sb.Append("_"),
                        _ => sb.Append(Uri.EscapeDataString(new string(c, 1))),
                    };
                },
                sb => sb.ToString()
            );
    }

    public static string GetShieldsIoUrl(this SemVersion semVersion)
    {
        var color = semVersion.IsPreRelease ? "yellow" : "orange";
        var escapedVersion = semVersion.VersionString.ShieldsIoEscape();
        var shieldIoUrl = $"https://img.shields.io/badge/azure_artifacts-{escapedVersion}-{color}.svg";
        return shieldIoUrl;
    }
}
