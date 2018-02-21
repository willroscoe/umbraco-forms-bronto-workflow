namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Map Bronto contact default and custom fields to Umbraco Forms
    /// </summary>
    public class FieldMappingModel
    {
        /// <summary>
        /// The id of the bronto field
        /// </summary>
        public string brontoFieldId { get; set; }

        /// <summary>
        /// The label of the bronto field
        /// </summary>
        public string brontoFieldLabel { get; set; }

        /// <summary>
        /// The umbaco form field
        /// </summary>
        public string formField { get; set; }

        /// <summary>
        /// Holder of a static value, as opposed to a vaule from the umbraco form
        /// </summary>
        public string staticValue { get; set; }

        /// <summary>
        /// Sets whether the field is required by bronto. This is not currently implemented 100% as bronto requires either one of either 'email' or 'mobileNumber'.
        /// </summary>
        public bool isRequired { get; set; }
    }
}