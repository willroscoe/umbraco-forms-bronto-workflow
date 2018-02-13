using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            var bronto = new BrontoSoapClient(BrontoAppSettings.ApiToken);

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
            /*if (string.IsNullOrEmpty(CookieName))
                exceptionList.Add(new Exception("’CookieName’ setting has not been set"));

            if (string.IsNullOrEmpty(CookieExpiryInDays))
                exceptionList.Add(new Exception("’CookieExpiryInDays’ setting has not been set’"));

            double expiryDays;
            if (!double.TryParse(CookieExpiryInDays, out expiryDays))
                exceptionList.Add(new Exception("’CookieExpiryInDays’ is not a valid day count’"));

            if (string.IsNullOrEmpty(OwnerEmail))
                exceptionList.Add(new Exception("'Owner Email has not been set'"));
                */
            return exceptionList;
        }
    }
}