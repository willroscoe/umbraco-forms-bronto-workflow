using Bronto.API;
using Bronto.API.BrontoService;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;
using Wr.UmbFormsBrontoWorkflow.Models;

namespace Wr.UmbFormsBrontoWorkflow.ApiControllers
{
    [IsBackOffice]
    public class BrontoApiViewController : UmbracoAuthorizedApiController
    {
        /// <summary>
        /// Return all the bronto lists for the api token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<mailListObject> GetLists()
        {
            var login = LoginSession.Create(BrontoAppSettings.SoapApiToken);
            var mailListsApi = new MailLists(login);
            var allLists = mailListsApi.Read();
            return allLists;
        }

        /// <summary>
        /// Returns all the custom bronto fields. These are global and available to all lists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<fieldObject> GetFields()
        {
            var login = LoginSession.Create(BrontoAppSettings.SoapApiToken);
            var contactsApi = new Contacts(login);
            var allFields = contactsApi.Fields;
            return allFields;
        }

        /// <summary>
        /// Returns the 'useful' standard bronto contact fields.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ContactStandardField> GetStandardFields()
        {
            return AppConstants.BrontoContactsStandardFields;
        }
    }
}