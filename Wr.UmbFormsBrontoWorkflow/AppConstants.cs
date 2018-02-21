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
        /// Only allow these lists to be selected
        /// </summary>
        public static string AppSetting_RestrictToListIds = "umbFormsBrontoRestrictToListIds";

        /// <summary>
        /// Only allow these fields to be selected
        /// </summary>
        public static string AppSetting_RestrictToFieldIds = "umbFormsBrontoRestrictToFieldIds";

        /// <summary>
        /// Standard Bronto contact fields which might be applicable to the workflow
        /// </summary>
        public static List<FieldMappingModel> BrontoContactsDefaultFields =
            new List<FieldMappingModel>()
            {
                new FieldMappingModel() { brontoFieldId = ContactDefaultFieldName.email.ToString(), brontoFieldLabel="Email", isRequired=true },
                new FieldMappingModel() { brontoFieldId = ContactDefaultFieldName.mobileNumber.ToString(), brontoFieldLabel="Mobile Tel", isRequired=true },
                new FieldMappingModel() { brontoFieldId = ContactDefaultFieldName.customSource.ToString(), brontoFieldLabel="Marketing Source" }
            };
    }
}