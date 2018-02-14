using System.Collections.Generic;
using Wr.UmbFormsBrontoWorkflow.Models;

namespace Wr.UmbFormsBrontoWorkflow
{
    public static class AppConstants
    {
        /// <summary>
        /// The web.config App settings Soap Api token key
        /// </summary>
        public static string AppSetting_BrontoSoapApiTokenKey = "umbFormsBrontoSoapApiToken";

        /// <summary>
        /// Standard Bronto contact fields which might be applicable to the workflow
        /// </summary>
        public static List<ContactStandardField> BrontoContactsStandardFields =
            new List<ContactStandardField>()
            {
                new ContactStandardField() { FieldName = ContactStandardFieldName.email, FriendlyName="Email", Tooltip="The user's email address" },
                new ContactStandardField() { FieldName = ContactStandardFieldName.mobileNumber, FriendlyName="Mobile Tel", Tooltip="The user's mobile telephone number" },
                new ContactStandardField() { FieldName = ContactStandardFieldName.customSource, FriendlyName="Marketing Source", Tooltip="The marketing source of the user" }
            };
    }
}