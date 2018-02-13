using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace Wr.UmbFormsBrontoWorkflow.ApiControllers
{
    [IsBackOffice]
    public class BrontoApiViewController : UmbracoAuthorizedApiController
    {
        [HttpGet]
        public IEnumerable<KeyValuePair<string,string>> GetLists()
        {
            var bronto = new BrontoApi.BrontoSoapClient();
            return bronto.GetLists_Formatted();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> GetFields()
        {
            var bronto = new BrontoApi.BrontoSoapClient();
            return bronto.GetFields_Formatted();
        }
    }
}