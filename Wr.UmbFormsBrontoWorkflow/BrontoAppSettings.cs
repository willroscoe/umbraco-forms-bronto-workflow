using System.Configuration;
using System.IO;
using System.Web;

namespace Wr.UmbFormsBrontoWorkflow
{
    internal static class BrontoAppSettings
    {
        /// <summary>
        /// Get the Soap Api Token. When running locally the Api token will be retrieved from a local file 
        /// </summary>
        public static string SoapApiToken { get { return GetConfigSetting(AppConstants.AppSetting_BrontoSoapApiTokenKey); } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        private static string GetConfigSetting(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];

            if (string.IsNullOrEmpty(setting) && settingName == AppConstants.AppSetting_BrontoSoapApiTokenKey)
            {
                if (File.Exists(AppConstants.SoapApiTokenFileLocalPath))
                {
                    setting = File.ReadAllText(AppConstants.SoapApiTokenFileLocalPath);
                }
            }

            return setting ?? string.Empty;
        }
    }
}