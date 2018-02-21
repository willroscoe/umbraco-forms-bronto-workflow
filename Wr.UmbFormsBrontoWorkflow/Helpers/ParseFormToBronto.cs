using Bronto.API.BrontoService;
using Newtonsoft.Json;
using System;
using System.Linq;
using Umbraco.Forms.Core;
using Wr.UmbFormsBrontoWorkflow.Models;
using Wr.UmbFormsBrontoWorkflow.Workflows;

namespace Wr.UmbFormsBrontoWorkflow
{
    /// <summary>
    /// Parse the umbrco form fields to a bronto 'contactObject'
    /// </summary>
    public static class ParseFormToBronto
    {
        /// <summary>
        /// Check if a list has been selected in the backend
        /// </summary>
        /// <param name="listAndFieldMapping"></param>
        /// <returns>bool</returns>
        public static bool CheckSettings_HasListSelected(string listAndFieldMapping)
        {
            var settingValue = JsonConvert.DeserializeObject<SettingValueModel>(listAndFieldMapping);
            return (!string.IsNullOrEmpty(settingValue.listId)) ? true : false;
        }

        /// <summary>
        /// Check if the required fields have been selected in the backend. The requirement is that either 'email' or 'mobileNumber' are set
        /// </summary>
        /// <param name="listAndFieldMapping"></param>
        /// <returns>bool</returns>
        public static bool CheckSettings_HasRequiredFields(string listAndFieldMapping)
        {
            var settingValue = JsonConvert.DeserializeObject<SettingValueModel>(listAndFieldMapping);
            var map = settingValue.mappings.FirstOrDefault(m => (m.brontoFieldId == ContactDefaultFieldName.email.ToString() || m.brontoFieldId == ContactDefaultFieldName.mobileNumber.ToString()));

            return (map != null) ? true : false;
        }


        /// <summary>
        /// Parse the umbraco form values to a bronto contact 'contactObject' model
        /// </summary>
        /// <param name="record"></param>
        /// <param name="listAndFieldMapping"></param>
        /// <returns>ParseContactResult</returns>
        public static ParseContactResult Contact(Record record, string listAndFieldMapping)
        {
            var result = new ParseContactResult();

            var settingValue = JsonConvert.DeserializeObject<SettingValueModel>(listAndFieldMapping);

            // get the list id
            var listId = settingValue.listId;

            // build bronto contact
            var newContact = new contactObject();

            // process standard contact fields
            if (!string.IsNullOrEmpty(listId))
                newContact.listIds = new string[] { listId };

            var emailAddress = GetMappedFieldAsString(settingValue, record, ContactDefaultFieldName.email.ToString());
            if (!string.IsNullOrEmpty(emailAddress))
                newContact.email = emailAddress;

            var mobileTel = GetMappedFieldAsString(settingValue, record, ContactDefaultFieldName.mobileNumber.ToString());
            if (!string.IsNullOrEmpty(mobileTel))
                newContact.mobileNumber = mobileTel;

            // the marketing source of the user - this could be passed from the 'phone manager' package
            var marketingSource = GetMappedFieldAsString(settingValue, record, ContactDefaultFieldName.customSource.ToString());
            if (!string.IsNullOrEmpty(marketingSource))
                newContact.customSource = marketingSource;

            // get list of ContactStandardFieldName enum names
            var standardFields = Enum.GetNames(typeof(ContactDefaultFieldName)).ToList();

            // remove standard fields from the remaining mapping data as they are no longer required
            settingValue.mappings.RemoveAll(x => standardFields.Contains(x.brontoFieldId));

            // Add custom fields
            var customFields = settingValue.mappings.Select(m =>
                {
                    return new contactField
                    {
                        fieldId = m.brontoFieldId,
                        content = GetFieldValue(record, m)
                    };
                }).ToArray();

            if (customFields.Count() > 0)
            {
                newContact.fields = customFields;
            }

            // add new contact to result
            result.contact = newContact;

            return result;
        }

        /// <summary>
        /// Finds and return the string value of the mapped field item
        /// </summary>
        /// <param name="listMapping"></param>
        /// <param name="record"></param>
        /// <param name="listField"></param>
        /// <returns></returns>
        private static string GetMappedFieldAsString(SettingValueModel listMapping, Record record, string listField)
        {
            var map = listMapping.mappings.FirstOrDefault(m => m.brontoFieldId == listField);
            return GetFieldValue(record, map);
        }

        /// <summary>
        /// Convert a record item to mapped value
        /// </summary>
        /// <param name="record"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private static string GetFieldValue(Record record, FieldMappingModel map)
        {
            if (map == null)
            {
                return string.Empty;
            }
            var value = map.staticValue;
            Guid fieldGuid;
            if (Guid.TryParse(map.formField, out fieldGuid)) // get the id of the umbraco form field
            {
                var field = record.GetRecordField(fieldGuid);
                value = field.ValuesAsString();
            }
            return value;
        }
    }
}