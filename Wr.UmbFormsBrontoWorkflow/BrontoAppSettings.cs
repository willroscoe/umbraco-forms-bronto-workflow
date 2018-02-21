using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Wr.UmbFormsBrontoWorkflow
{
    internal static class BrontoAppSettings
    {
        /// <summary>
        /// Get the Soap Api Token.
        /// </summary>
        public static string SoapApiToken { get { return GetConfigSetting(AppConstants.AppSetting_BrontoSoapApiTokenKey); } }

        /// <summary>
        /// Get any listIds (bronto id or name) to restrict the selection when added new contacts 
        /// </summary>
        public static List<string> RestrictToListIds
        {
            get
            {
                var appSettingValue = GetConfigSetting(AppConstants.AppSetting_RestrictToListIds);

                var results = appSettingValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList(); // split and trim strings

                return (results.Count > 0) ? results : new List<string>();
            }
        }

        /// <summary>
        /// Get any fieldIds (bronto id or name) to restrict the selection when added new contacts 
        /// </summary>
        public static List<string> RestrictToFieldIds
        {
            get
            {
                var appSettingValue = GetConfigSetting(AppConstants.AppSetting_RestrictToFieldIds);

                var results = appSettingValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList(); // split and trim strings

                return (results.Count > 0) ? results : new List<string>();
            }
        }

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