## <img height="64" src="assets/bronto-workflow_icon64.png " style="margin-bottom: 5px" align="middle" alt="Bronto workflow" title="Umbraco Phone Manager"> Bronto workflow for Umbraco Forms
A custom Umbraco Forms workflow to allow users to save a new marketing contact to a Bronto (https://bronto.com) contact and associated list, using the Bronto SOAP Api.

[![Build status](https://ci.appveyor.com/api/projects/status/sbbekv4d73eghk2c?svg=true)](https://ci.appveyor.com/project/willroscoe/umbraco-forms-bronto-workflow)


![Bronto workflow](/assets/bronto_screengrab.jpg?raw=true "Bronto workflow")

## Web.config Configuration:

In the <appSettings> section:
```
<add key="umbFormsBrontoSoapApiToken" value="{Your Bronto A/c Soap API Token}"/>
<add key="umbFormsBrontoRestrictToListIds" value="{comma delimited list of bronto list id's or list names you want to restrict selection of. If empty, all available lists will be available }"/>  - OPTIONAL
<add key="umbFormsBrontoRestrictToFieldIds" value="{comma delimited list of bronto contact field id's or field names you want to restrict selection of. If empty, all available firelds will be available }"/> - OPTIONAL
```

You can view/add a SOAP Api Token in your Bronto a/c -> Select (sub) a/c -> Home -> Settings -> Data Exchange -> SOAP Api Access Tokens
 - Note: The token will need read and write access

 ## Acknowledgements

 This project is adaped from Campaign Monitor Umbraco Forms https://our.umbraco.org/projects/backoffice-extensions/campaign-monitor-umbraco-forms/
