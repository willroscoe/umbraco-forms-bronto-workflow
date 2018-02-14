namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Useful standard contact field names, as enums
    /// </summary>
    public enum ContactStandardFieldName
    {
        email,
        mobileNumber,
        customSource
    }

    public class ContactStandardField
    {
        /// <summary>
        /// The field name used by Bronto
        /// </summary>
        public ContactStandardFieldName FieldName { get; set; }

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