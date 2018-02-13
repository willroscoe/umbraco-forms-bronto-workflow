using System.Configuration;

namespace Wr.UmbFormsBrontoWorkflow
{
    internal static class BrontoAppSettings
    {
        public static string ApiToken { get { return GetConfigSetting("umbFormBrontoApiToken"); } }

        public static string AccountCode { get { return GetConfigSetting("umbFormBrontoAccountCode"); ; } }

        private static string GetConfigSetting(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            return setting ?? string.Empty;
        }
    }
}