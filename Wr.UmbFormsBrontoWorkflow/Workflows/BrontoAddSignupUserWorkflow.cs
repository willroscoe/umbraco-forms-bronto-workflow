using System;
using System.Collections.Generic;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Attributes;
using Umbraco.Forms.Core.Enums;
using Wr.UmbFormsBrontoWorkflow.BrontoApi;

namespace Wr.UmbFormsBrontoWorkflow.Workflows
{
    public class BrontoAddSignupUserWorkflow : WorkflowType
    {
        public BrontoAddSignupUserWorkflow()
        {
            Id = new Guid("3fcaf250-74dc-4093-8b2f-8721eb67ab4a");
            Name = "Add signup user to Bronto";
            Description = "Sends signup form to Bronto";
            Icon = "icon-settings";
        }

        [Setting("Save to Bronto List",  description = "The list the user data will save to", view= "~/App_Plugins/UmbFormsBrontoWorkflow/lists.editor.html")]
        public string ListToUse { get; set; }

        [Setting("Soap Api token override", description = "Only use if you don't want to store the token in the web.config")]
        public string SoapApiTokenOverride { get; set; }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(BrontoAppSettings.SoapApiToken) && string.IsNullOrEmpty(SoapApiTokenOverride)) || string.IsNullOrEmpty(ListToUse))
                {
                    return WorkflowExecutionStatus.NotConfigured;
                }

                // bronto login

                var bronto = new BrontoSoapClient(SoapApiTokenOverride); // prioritise token in SoapApiTokenOverride

                var contact = ParseFormToBronto.Contact(record);

                if (bronto.AddContact(contact))
                {
                    return WorkflowExecutionStatus.Completed;
                }
            }
            catch(Exception ex)
            {
                Umbraco.Core.Logging.LogHelper.Error<BrontoAddSignupUserWorkflow>("Error in Bronto Workflow for Forms", ex);
            }

            return WorkflowExecutionStatus.Failed;
        }


        public override List<Exception> ValidateSettings()
        {
            List<Exception> exceptionList = new List<Exception>();

            if (string.IsNullOrEmpty(BrontoAppSettings.SoapApiToken) && string.IsNullOrEmpty(SoapApiTokenOverride))
                exceptionList.Add(new Exception("The Bronto Soap Api Token is missing from the app settings section of the web.config"));


            if (string.IsNullOrEmpty(ListToUse))
                exceptionList.Add(new Exception("A Bronto list must be selected."));
            
            return exceptionList;
        }
    }
}