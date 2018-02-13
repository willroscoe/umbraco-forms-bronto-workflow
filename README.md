# Bronto workflow for Umbraco Forms - IN DEVELOPMENT
A custom Umbraco Forms workflow to allow users to save a new marketing contact to a Bronto contact and associated list, using the Bronto SOAP Api.

[![Build status](https://ci.appveyor.com/api/projects/status/sbbekv4d73eghk2c?svg=true)](https://ci.appveyor.com/project/willroscoe/umbraco-forms-bronto-workflow)


## Live Configuration:

```
<add key="umbFormsBrontoSoapApiToken" value="{Your Bronto A/c Soap API Token}"/>
```

You can view/add a SOAP Api Token in your Bronto a/c -> Select (sub) a/c -> Home -> Settings -> Data Exchange -> SOAP Api Access Tokens
 - Note: The token will need read and write access


## Unit Test Configuration

To maintain security of your Bronto Api Token, for local testing of the project, the SOAP Api Token is stored in a text file ('BrontoSoapTestApiToken.txt') located outside of the project root. In this way it is not included in any source control. The path to the text file is set in Wr.UmbFormsBrontoWorkflow.Tests\BrontoTestBase.cs

### CI Testing
For testing with Appveyor, use the 'secure-file' program to encrypt the text file, and place in the resulting encrypted file in the root of the Wr.UmbFormsBrontoWorkflow.Tests project.

For more information on this see the Appveyor document: [**Secure Files**](https://www.appveyor.com/docs/how-to/secure-files/)