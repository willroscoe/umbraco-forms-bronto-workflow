using Bronto.API.BrontoService;
using System.Linq;

namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Model to hold the results of parsing the umbraco form data to the Bronto 'contactObject' model
    /// </summary>
    public class ParseContactResult
    {
        public contactObject contact { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(contact?.email ?? "") || !string.IsNullOrEmpty(contact?.mobileNumber ?? ""));
        }

        /// <summary>
        /// Return a string of 'contactObject', primarily for debuging purposes
        /// </summary>
        /// <returns></returns>
        public string ContactToString()
        {
            string result = "BRONTO CONTACT: ";
            if (contact.fields != null)
            {
                string lists = string.Empty;
                if (contact.listIds.Count() > 0)
                {
                    result = result + string.Format("listIds: '{0}'", string.Join(", ", contact.listIds));
                }
                result = result + string.Format(", email: {0}, mobileNumber: {1}", contact.email, contact.mobileNumber);
                if (contact.fields.Count() > 0)
                {
                    for (int i = 0; i < contact.fields.Count(); i++)
                    {
                        var thisitem = contact.fields[i];
                        result = result + string.Format(", fieldId[{0}]: {1}, content[{0}]: {2}", i, thisitem.fieldId, thisitem.content);
                    }
                }
            }
            else
            {
                result = result + "NULL";
            }
            return result;
        }
    }
}