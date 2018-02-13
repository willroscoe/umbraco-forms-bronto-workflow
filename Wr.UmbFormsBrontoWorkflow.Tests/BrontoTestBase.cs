using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;

namespace Wr.UmbFormsBrontoWorkflow.Tests
{
    public abstract class BrontoTestBase
    {
        private string _ApiToken = null;

        /// <summary>
        /// This loads a test Api token from a secure place. Either outsite of the project root (ie. not in source control), or if testing with CI Appveyor use 'secure-file' to encrypt the .txt file which can then be commited to source control
        /// </summary>
        protected string ApiToken
        {
            get
            {
                const string brontoSoapApiTokenfile = "BrontoSoapTestApiToken.txt";

                if (string.IsNullOrEmpty(_ApiToken))
                {
                    string fullpath = GetApiTokenFilePath(new string[]
                    {
                        Path.Combine(Environment.CurrentDirectory, @"Wr.UmbFormsBrontoWorkflow.Tests\" + brontoSoapApiTokenfile), // path to encrypted api token file for CI Appveyor testing
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Dev\Umb\SafeFolder\" + brontoSoapApiTokenfile) // local path to txt file with a test Soap Api Token. This should be outside of the project root and so not included in source control
                    });

                    if (string.IsNullOrEmpty(fullpath))
                    {
                        throw new FileNotFoundException("Could not locate a file with the bronto Api Token", brontoSoapApiTokenfile);
                    }
                    _ApiToken = File.ReadAllText(fullpath);
                }

                return _ApiToken;
            }
        }

        private static string GetApiTokenFilePath(IEnumerable<string> paths)
        {
            foreach (var item in paths)
            {
                if (File.Exists(item))
                {
                    return item;
                }
            }
            return string.Empty;
        }
    }
}
