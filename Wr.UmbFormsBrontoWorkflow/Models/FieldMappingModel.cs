namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Map Bronto contact default and custom fields to Umbraco Forms
    /// </summary>
    public class FieldMappingModel
    {
        public string BrontoFieldId { get; set; }

        public string BrontoFieldFriendlyName { get; set; }

        public string FormField { get; set; }

        public string StaticValue { get; set; }

        public string Tooltip { get; set; }
    }
}