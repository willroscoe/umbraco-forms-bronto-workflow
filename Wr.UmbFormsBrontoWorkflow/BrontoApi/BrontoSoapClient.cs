using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Wr.UmbFormsBrontoWorkflow.BrontoSoapService;

namespace Wr.UmbFormsBrontoWorkflow.BrontoApi
{
    public class BrontoSoapClient
    {
        internal readonly string _sessionId;
        internal readonly sessionHeader _sessionHeader;

        public BrontoSoapClient(string ApiToken = "")
        {
            if (string.IsNullOrEmpty(ApiToken))
            {
                ApiToken = BrontoAppSettings.SoapApiToken;
            }

            _sessionId = Login(ApiToken);
            _sessionHeader = new sessionHeader();
            _sessionHeader.sessionId = _sessionId;
        }

        private string Login(string ApiToken)
        {
            using (var client = BrontoSoapClientConstructor.Initialise())
            {
                return client.login(ApiToken);
            }
        }

        /// <summary>
        /// Add a contact to the bronto contacts
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public bool AddContact(contactObject contact)
        {
            using (var client = BrontoSoapClientConstructor.Initialise())
            {
                writeResult response = client.addContacts(_sessionHeader, new contactObject[] { contact });

                if (response.results != null)
                {
                    if (response.results.Length > 0)
                    {
                        var result = response.results[0];
                        if (!result.isError)
                        {
                            return true;
                        }
                        else
                        {

                        }
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Get all bronto lists as KeyValuePairs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string,string>> GetLists_Formatted()
        {
            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in GetListsRaw())
            {
                result.Add(new KeyValuePair<string, string>(item.id, item.label)); // id and name of bronto list
            }
            return result;
        }

        /// <summary>
        /// Retrieve all available lists for this account
        /// </summary>
        /// <returns></returns>
        internal List<mailListObject> GetListsRaw()
        {
            using (var client = BrontoSoapClientConstructor.Initialise())
            {
                List<mailListObject> list = new List<mailListObject>();

                var rl = new readLists();
                rl.filter = new mailListFilter();
                rl.pageNumber = 1;

                mailListObject[] result = client.readLists(_sessionHeader, rl);
                if (result != null)
                {
                    list.AddRange(result);
                }

                while (result != null && result.Length > 0) // retrive additional pages of lists, if applicable
                {
                    rl.pageNumber += 1;
                    result = client.readLists(_sessionHeader, rl);
                    if (result != null)
                    {
                        list.AddRange(result);
                    }
                }

                return list;
            }
        }


        /// <summary>
        /// Get all bronto fields as KeyValuePairs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> GetFields_Formatted()
        {
            var result = new List<KeyValuePair<string, string>>();
            foreach (var item in GetFieldsRaw())
            {
                result.Add(new KeyValuePair<string, string>(item.id, item.label)); // id and name of bronto list
            }
            return result;
        }

        /// <summary>
        /// Retrieve all bronto fields for this account
        /// </summary>
        /// <returns></returns>
        internal List<fieldObject> GetFieldsRaw()
        {
            using (var client = BrontoSoapClientConstructor.Initialise())
            {
                List<fieldObject> list = new List<fieldObject>();

                var rf = new readFields();
                rf.filter = new fieldsFilter();
                rf.pageNumber = 1;

                fieldObject[] result = client.readFields(_sessionHeader, rf);
                if (result != null)
                {
                    list.AddRange(result);
                }

                while (result != null && result.Length > 0) // retrive additional pages of fields, if applicable
                {
                    rf.pageNumber += 1;
                    result = client.readFields(_sessionHeader, rf);
                    if (result != null)
                    {
                        list.AddRange(result);
                    }
                }

                return list;
            }
        }

        private class BrontoSoapClientConstructor
        {
            /// <summary>
            /// The Bronto API Url
            /// </summary>
            public const string BrontoApiServiceUrl = "https://api.bronto.com/v4";

            /// <summary>
            /// The default timeout setting for the Web Service
            /// </summary>
            public static TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

            /// <summary>
            /// Returns an instance of the Bronto SOAP client with the specified timeout
            /// </summary>
            /// <param name="Timeout">The timeout setting for the Bronto Web Service client. If not specified, the DefaultTimeout field is used <see cref="DefaultTimeout"/></param>
            /// <returns>A Bronto Web Service client</returns>
            public static BrontoSoapPortTypeClient Initialise(TimeSpan? Timeout = null)
            {
                return Initialise(new BasicHttpsBinding(BasicHttpsSecurityMode.Transport) { MaxReceivedMessageSize = Int32.MaxValue, ReceiveTimeout = Timeout ?? DefaultTimeout, SendTimeout = Timeout ?? DefaultTimeout }, new EndpointAddress(BrontoApiServiceUrl));
            }

            /// <summary>
            /// Returns an instance of the Bronto SOAP client with the specified binding and endpoint address
            /// </summary>
            /// <param name="binding">A valid binding for the web service. Normally the overload of this method should be used <see cref="Create(TimeSpan?)"/> </param>
            /// <param name="url">A valid Url for the Bronto web service. Normally the overload of this method should be used <see cref="Create(TimeSpan?)"/> </param>
            /// <returns>A Bronto Web Service client</returns>
            public static BrontoSoapPortTypeClient Initialise(Binding binding, EndpointAddress url)
            {
                return new BrontoSoapPortTypeClient(binding, url);
            }
        }
    }
}