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
        public static List<FieldMappingModel> BrontoContactsDefaultFields =
            new List<FieldMappingModel>()
            {
                new FieldMappingModel() { BrontoFieldId = ContactDefaultFieldName.email.ToString(), BrontoFieldFriendlyName="Email", Tooltip="The user's email address" },
                new FieldMappingModel() { BrontoFieldId = ContactDefaultFieldName.mobileNumber.ToString(), BrontoFieldFriendlyName="Mobile Tel", Tooltip="The user's mobile telephone number" },
                new FieldMappingModel() { BrontoFieldId = ContactDefaultFieldName.customSource.ToString(), BrontoFieldFriendlyName="Marketing Source", Tooltip="The marketing source of the user" }
            };
    }
}