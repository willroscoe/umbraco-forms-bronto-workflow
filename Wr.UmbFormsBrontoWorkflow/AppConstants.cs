using System;
using System.IO;

namespace Wr.UmbFormsBrontoWorkflow
{
    public static class AppConstants
    {
        /// <summary>
        /// The web.config App settings Soap Api token key
        /// </summary>
        public static string AppSetting_BrontoSoapApiTokenKey = "umbFormsBrontoSoapApiToken";

        /// <summary>
        /// The filename of the local Soap Api token file. On the live system the Api token will be retrieved from the app setting section of the web.config
        /// </summary>
        public static string SoapApiTokenFilename = "BrontoSoapTestApiToken.txt";

        /// <summary>
        /// The path to the local copy of the Soap Api token file. Used for testing the Bronto API locally without having to commit the Api token to source control
        /// </summary>
        public static string SoapApiTokenFileLocalPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Dev\Umb\SafeFolder\" + SoapApiTokenFilename);
    }
}