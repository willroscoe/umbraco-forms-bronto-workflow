using Bronto.API;
using System;
using System.Collections.Generic;
using Umbraco.Forms.Core;
using Umbraco.Forms.Core.Attributes;
using Umbraco.Forms.Core.Enums;

namespace Wr.UmbFormsBrontoWorkflow.Workflows
{
    /// <summary>
    /// An Umbraco Forms workflow to add a contact to the Bronto marketing system, using the Bronto SOAP API
    /// </summary>
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
        public string ListAndFieldMapping { get; set; }

        public override WorkflowExecutionStatus Execute(Record record, RecordEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(BrontoAppSettings.SoapApiToken) || string.IsNullOrEmpty(ListAndFieldMapping))
                {
                    return WorkflowExecutionStatus.NotConfigured;
                }

                var parseResult = ParseFormToBronto.Contact(record, ListAndFieldMapping);

                if (parseResult.IsValid()) // i.e. the required bronto contact fields are present
                {
                    // bronto login
                    var login = LoginSession.Create(BrontoAppSettings.SoapApiToken);
                    var contactsApi = new Contacts(login);
                    var result = contactsApi.Add(parseResult.contact); // Add contact

                    if (result.Items.Count > 0)
                    {
                        if (!result.Items[0].IsError)
                        {
                            return WorkflowExecutionStatus.Completed;
                        }
                        else
                        {
                            Umbraco.Core.Logging.LogHelper.Error<BrontoAddSignupUserWorkflow>("Error in Bronto Workflow", new Exception(string.Format("Add Contact: Error: {0} for contact: {1}", result.Items[0].ErrorString, parseResult.ContactToString())));
                        }
                    }
                    else
                    {
                        Umbraco.Core.Logging.LogHelper.Error<BrontoAddSignupUserWorkflow>("Error in Bronto Workflow", new Exception(string.Format("Add Contact: No items in response: {0}", parseResult.ContactToString())));
                    }
                }
                else
                {
                    Umbraco.Core.Logging.LogHelper.Error<BrontoAddSignupUserWorkflow>("Error in Bronto Workflow", new Exception(string.Format("Parse Contact Error: {0}", parseResult.ContactToString())));
                }

            }
            catch(Exception ex)
            {
                Umbraco.Core.Logging.LogHelper.Error<BrontoAddSignupUserWorkflow>("Error in Bronto Workflow for Forms", ex);
            }

            return WorkflowExecutionStatus.Failed;
        }

        /// <summary>
        /// Validate the workflow settings
        /// </summary>
        /// <returns>List<Exception></returns>
        public override List<Exception> ValidateSettings()
        {
            List<Exception> exceptionList = new List<Exception>();

            if (string.IsNullOrEmpty(BrontoAppSettings.SoapApiToken))
                exceptionList.Add(new Exception("The Bronto Soap Api Token is missing from the app settings section of the web.config"));

            // Check if a bronto list has been selected
            if (!ParseFormToBronto.CheckSettings_HasListSelected(ListAndFieldMapping))
                exceptionList.Add(new Exception("A Bronto list must be selected."));

            // Check if the required fields for a bronto contact have been set
            if (!ParseFormToBronto.CheckSettings_HasRequiredFields(ListAndFieldMapping))
                exceptionList.Add(new Exception("Required bronto fields missing. Either 'Email' or 'Mobile Tel' must be set."));

            return exceptionList;
        }
    }
}