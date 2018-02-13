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
                const string brontoApiTokenfile = "UmbFormsBrontoApiToken.txt";

                if (string.IsNullOrEmpty(_ApiToken))
                {
                    string fullpath = GetApiTokenFilePath(new string[]
                    {
                        Path.Combine(VirtualPathUtility.ToAppRelative("~"), brontoApiTokenfile),
                        Path.Combine(Environment.CurrentDirectory, brontoApiTokenfile),
                        Path.Combine(Assembly.GetExecutingAssembly().Location, brontoApiTokenfile),
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Dev/Umb/SafeFolder/" + brontoApiTokenfile),
                        Path.Combine(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()),brontoApiTokenfile)
                    });

                    if (string.IsNullOrEmpty(fullpath))
                    {
                        throw new FileNotFoundException("Could not locate a file with the bronto Api Token", brontoApiTokenfile);
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
