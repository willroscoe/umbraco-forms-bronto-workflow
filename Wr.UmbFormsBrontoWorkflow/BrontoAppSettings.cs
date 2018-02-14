using System.Configuration;
using System.IO;
using System.Web;

namespace Wr.UmbFormsBrontoWorkflow
{
    internal static class BrontoAppSettings
    {
        /// <summary>
        /// Get the Soap Api Token.
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

            return setting ?? string.Empty;
        }
    }
}