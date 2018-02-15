namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Useful standard contact field names, as enums
    /// </summary>
    public enum ContactDefaultFieldName
    {
        na,
        email,
        mobileNumber,
        customSource
    }

    public class ContactDefaultField
    {
        /// <summary>
        /// The field name used by Bronto
        /// </summary>
        public ContactDefaultFieldName FieldName { get; set; }

        /// <summary>
        /// The name to display to user
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Tooltip text to use
        /// </summary>
        public string Tooltip { get; set; }
    }
}