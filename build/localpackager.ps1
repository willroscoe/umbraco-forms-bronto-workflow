
    tools\UmbracoTools\Wr.UmbracoTools.Packager.exe -set umbraco\package_settings.json -out "..\..\..\testing\brontoworkflow-umbracoforms-{version}.zip"

	tools\nuget.exe pack  ..\Wr.UmbFormsBrontoWorkflow\Wr.UmbFormsBrontoWorkflow.csproj -OutputDirectory ..\..\..\testing\