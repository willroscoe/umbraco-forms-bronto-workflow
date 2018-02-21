using Bronto.API;
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
        public IEnumerable<ListMappingModel> GetBrontoLists()
        {
            var results = new List<ListMappingModel>();

            var login = LoginSession.Create(BrontoAppSettings.SoapApiToken);
            var mailListsApi = new MailLists(login);
            var allLists = mailListsApi.Read();

            if (allLists.Count > 0)
            {
                var restrictToLists = BrontoAppSettings.RestrictToListIds;

                // map bronto fields to ListMappingModel
                foreach (var item in allLists)
                {
                    bool OkToUse = true;
                    if (restrictToLists.Count > 0) // there are restrictToLists added to web.config app settings
                    {
                        if (!restrictToLists.Contains(item.id) && !restrictToLists.Contains(item.name)) // this list is not in the RestrictToListIds list
                        {
                            OkToUse = false;
                        }
                    }
                    if (OkToUse)
                    {
                        results.Add(
                            new ListMappingModel()
                            {
                                listId = item.id,
                                listLabel = item.label
                            });
                    }
                }
            }
            
            return results;
        }

        /// <summary>
        /// Returns all the custom bronto fields. These are global and available to all lists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FieldMappingModel> GetBrontoFields()
        {
            var results = new List<FieldMappingModel>();
            results.AddRange(AppConstants.BrontoContactsDefaultFields);

            // get bronto custom fields
            var login = LoginSession.Create(BrontoAppSettings.SoapApiToken);
            var contactsApi = new Contacts(login);
            var allFields = contactsApi.Fields;

            if (allFields.Count > 0)
            {
                var restrictToFields = BrontoAppSettings.RestrictToFieldIds;

                // map bronto fields to FieldMappingModel
                foreach (var item in allFields)
                {
                    bool OkToUse = true;
                    if (restrictToFields.Count > 0) // there are restrictToLists added to web.config app settings
                    {
                        if (!restrictToFields.Contains(item.id) && !restrictToFields.Contains(item.name)) // this list is not in the RestrictToListIds list
                        {
                            OkToUse = false;
                        }
                    }
                    if (OkToUse)
                    {
                        results.Add(
                        new FieldMappingModel()
                        {
                            brontoFieldId = item.id,
                            brontoFieldLabel = item.label
                        });
                    }
                }
            }

            return results;
        }
    }
}