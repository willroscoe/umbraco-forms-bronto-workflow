using Bronto.API.BrontoService;
using Newtonsoft.Json;
using System;
using System.Linq;
using Umbraco.Forms.Core;
using Wr.UmbFormsBrontoWorkflow.Models;

namespace Wr.UmbFormsBrontoWorkflow
{
    public static class ParseFormToBronto
    {
        public static ParseContactResult Contact(Record record, string listAndFieldMapping)
        {
            var result = new ParseContactResult();

            var listMapping = JsonConvert.DeserializeObject<ListMappingModel>(listAndFieldMapping);

            // get the list id
            var listId = listMapping.ListId;

            // build bronto contact
            var newContact = new contactObject();

            // process standard contact fields

            if (!string.IsNullOrEmpty(listId))
                newContact.listIds = new string[] { listId };

            var emailAddress = GetMappedFieldAsString(listMapping, record, ContactDefaultFieldName.email.ToString());
            if (!string.IsNullOrEmpty(emailAddress))
                newContact.email = emailAddress;

            var mobileTel = GetMappedFieldAsString(listMapping, record, ContactDefaultFieldName.mobileNumber.ToString());
            if (!string.IsNullOrEmpty(mobileTel))
                newContact.mobileNumber = mobileTel;

            // the marketing source of the user - this could be passed from the 'phone manager' package
            var marketingSource = GetMappedFieldAsString(listMapping, record, ContactDefaultFieldName.customSource.ToString());
            if (!string.IsNullOrEmpty(marketingSource))
                newContact.customSource = marketingSource;

            // get list of ContactStandardFieldName enum names
            var standardFields = Enum.GetNames(typeof(ContactDefaultFieldName)).ToList();

            // remove standard fields from the remaining mapping data as they are no longer required
            listMapping.Mappings.RemoveAll(x => standardFields.Contains(x.BrontoFieldId));

            // Add custom fields
            var customFields = listMapping.Mappings.Select(m =>
                {
                    return new contactField
                    {
                        fieldId = m.BrontoFieldId,
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
        private static string GetMappedFieldAsString(ListMappingModel listMapping, Record record, string listField)
        {
            var map = listMapping.Mappings.FirstOrDefault(m => m.BrontoFieldId == listField);
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
            var value = map.StaticValue;
            Guid fieldGuid;
            if (Guid.TryParse(map.BrontoFieldId, out fieldGuid))
            {
                var field = record.GetRecordField(fieldGuid);
                value = field.ValuesAsString();
            }
            return value;
        }
    }
}