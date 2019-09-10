[![Build Status](https://dev.azure.com/azpkgsshield/azpkgsshield/_apis/build/status/azurevoodoo.AzureArtifactsPublicNuGetFeedBadge?branchName=master)](https://dev.azure.com/azpkgsshield/azpkgsshield/_build/latest?definitionId=1&branchName=master) [![Release Status](https://vsrm.dev.azure.com/azpkgsshield/_apis/public/Release/badge/bf0c50f0-827a-4135-acbd-40b76d5735b6/1/1)](https://dev.azure.com/azpkgsshield/azpkgsshield/_release?_a=releases&view=mine&definitionId=1)
# Azure Artifacts Public NuGet Feed Badge

An C# Azure Function app to display version badges for NuGet packages hosted on a public Azure Artifacts NuGet Feed.

## Background

Currently Azure Artifacts only supply NuGet package badges for stable releases with Azure Artifacts NuGet feeds.

For open source projects alternative feeds to NuGet.org are often used just with pre-releases in mind to offer bits early in-between releases, so being able to display a badge for pre-releases versions too is essential for these projects. 

## Usage

### Route
`{org}/{project}/{feed}/{packageId}`

### Example

| Parameter | Description         | Example    |
|-----------|---------------------|------------|
| org       | Organization name   | cake-build |
| project   | Project name        | Cake       |
| feed      | Artifacts feed name | cake       |
| packageId | NuGet package id    | cake       |

#### Markdown 
```markdown
[![Azure Artifacts](https://azpkgsshield.azurevoodoo.net/cake-build/Cake/cake/cake)](https://dev.azure.com/cake-build/Cake/_packaging?_a=package&feed=cake&package=Cake&protocolType=NuGet)
```
#### Output

[![Azure Artifacts](https://azpkgsshield.azurevoodoo.net/cake-build/Cake/cake/cake)](https://dev.azure.com/cake-build/Cake/_packaging?_a=package&feed=cake&package=Cake&protocolType=NuGet)

## License

This project is licensed under the [MIT License](LICENSE).

### Shields.io

This project utilizes [Shields.io](https://shields.io) to generate badges, which is licensed under the [CC0](https://github.com/badges/shields/blob/9b5ca7d/LICENSE) license.