using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AzureArtifactsPublicNuGetFeedBadge.Model;

namespace AzureArtifactsPublicNuGetFeedBadge.Helpers
{
    public static class ShieldsIoExtensions
    {
        public static string ShieldsIoEscape(this string value)
        {
            return value
                .Aggregate(
                    new StringBuilder(),
                    (sb, c) =>
                    {
                        switch (c)
                        {
                            case '_':
                                return sb.Append("__");
                            case '-':
                                return sb.Append("--");
                            case ' ':
                                return sb.Append("_");
                            default:
                                return sb.Append(Uri.EscapeDataString(new string(c, 1)));
                        }
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
}
