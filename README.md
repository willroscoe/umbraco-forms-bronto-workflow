## <img height="64" src="assets/bronto-workflow_icon64.png " style="margin-bottom: 5px" align="middle" alt="Bronto workflow" title="Umbraco Phone Manager"> Bronto workflow for Umbraco Forms
[![Build status](https://ci.appveyor.com/api/projects/status/sbbekv4d73eghk2c?svg=true)](https://ci.appveyor.com/project/willroscoe/umbraco-forms-bronto-workflow)
[![NuGet release](https://img.shields.io/nuget/v/UmbracoFormsBrontoWorkflow.svg)](https://www.nuget.org/packages/UmbracoFormsBrontoWorkflow)
 [![Our Umbraco project page](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.org/projects/backoffice-extensions/bronto-workflow-for-umbraco-forms/)

A custom Umbraco Forms workflow to allow users to save a new marketing contact to a Bronto (https://bronto.com) contact and associated list, using the Bronto SOAP Api. The workflow allows mapping between Bronto fields and the Umbraco form fields. The 'Static value' input allows a value to be preset.

## Workflow screengrab

![Bronto workflow](/assets/bronto_screengrab.jpg?raw=true "Bronto workflow")


## Installation

Install the package through the Umbraco backoffice:
- In Developer -> Packages backoffice. Search for 'bronto workflow', in 'Backoffice extensions'
- or download the package as a zip from [**https://our.umbraco.org/projects/backoffice-extensions/bronto-workflow-for-umbraco-forms/**][OurUmbraco]. Manually install via 'Install local' in your Umbraco package backoffice.
- or download the package as a zip from this project's GitHub page [**https://github.com/willroscoe/umbraco-forms-bronto-workflow/releases**][GitHubRelease]. Manually install via 'Install local' in your Umbraco package backoffice.

or via NuGet:
- ```PM> Install-Package UmbracoFormsBrontoWorkflow```
- or manually download the [**NuGet Package**][NuGetPackage]. Install the NuGet package in your Visual Studio project.

[NuGetPackage]: https://www.nuget.org/packages/UmbracoFormsBrontoWorkflow/
[OurUmbraco]: https://our.umbraco.org/projects/backoffice-extensions/bronto-workflow-for-umbraco-forms/
[GitHubRelease]: https://github.com/willroscoe/umbraco-forms-bronto-workflow/releases


## Web.config Configuration:

In the 'appSettings' section:
```
<add key="umbFormsBrontoSoapApiToken" value="{Your Bronto A/c Soap API Token}"/>
<add key="umbFormsBrontoRestrictToListIds" value="{comma delimited list of bronto list id's or list names you want to restrict selection of. If empty, all available lists will be available }"/>  - OPTIONAL
<add key="umbFormsBrontoRestrictToFieldIds" value="{comma delimited list of bronto contact field id's or field names you want to restrict selection of. If empty, all available fields will be available }"/> - OPTIONAL
```

You can view/add a SOAP Api Token in your Bronto a/c -> Select (sub) a/c -> Home -> Settings -> Data Exchange -> SOAP Api Access Tokens
 - Note: The token will need read and write access

## Dependencies
Umbraco Forms >= 6.0.6

.Net Framework >= 4.5.1

This project makes use of the Bronto.API class https://github.com/willroscoe/BrontoSharp  


## Acknowledgements

This project is adapted from Campaign Monitor Umbraco Forms https://our.umbraco.org/projects/backoffice-extensions/campaign-monitor-umbraco-forms/
