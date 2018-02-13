using System;
using System.Collections.Generic;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Enums;
using Wr.UmbFormsBrontoWorkflow.BrontoApi;

namespace Wr.UmbFormsBrontoWorkflow.Workflows
{
    public class AddSignupUserWorkflow : WorkflowType
    {
        public AddSignupUserWorkflow()
        {
            Id = new Guid("3fcaf250-74dc-4093-8b2f-8721eb67ab4a");
            Name = "Add signup user to Bronto";
            Description = "Sends signup form to Bronto";
            Icon = "icon-settings";
        }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            // bronto login
            var bronto = new BrontoSoapClient(BrontoAppSettings.SoapApiToken);

            var contact = ParseFormToBronto.Contact(record);

            if (bronto.AddContact(contact))
            {
                return WorkflowExecutionStatus.Completed;
            }

            return WorkflowExecutionStatus.Failed;
        }


        public override List<Exception> ValidateSettings()
        {
            List<Exception> exceptionList = new List<Exception>();
            
            return exceptionList;
        }
    }
}