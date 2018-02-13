using System.Configuration;

namespace Wr.UmbFormsBrontoWorkflow
{
    internal static class BrontoAppSettings
    {
        public static string SoapApiToken { get { return GetConfigSetting("umbFormsBrontoSoapApiToken"); } }

        private static string GetConfigSetting(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            return setting ?? string.Empty;
        }
    }
}