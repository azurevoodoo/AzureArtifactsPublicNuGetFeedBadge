namespace AzureArtifactsPublicNuGetFeedBadge.Model;

/// <summary>
/// Source-generated JSON serializer context for NuGet API model types (index and package registration).
/// </summary>
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.Unspecified)]
[JsonSerializable(typeof(NuGetIndex))]
[JsonSerializable(typeof(Resource))]
[JsonSerializable(typeof(AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.Index.Context), TypeInfoPropertyName = "IndexContext")]
[JsonSerializable(typeof(NuGetPackageRegistration))]
[JsonSerializable(typeof(NuGetPackageRegistrationItem))]
[JsonSerializable(typeof(AzureArtifactsPublicNuGetFeedBadge.Model.NuGet.PackageRegistration.Context), TypeInfoPropertyName = "PackageRegistrationContext")]
[JsonSerializable(typeof(CatalogEntry))]
[JsonSerializable(typeof(ItemItem))]
[JsonSerializable(typeof(PackageContent))]
[JsonSerializable(typeof(CommitId))]
internal partial class ModelJsonContext : JsonSerializerContext
{
}
