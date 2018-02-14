namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Map Bronto contact default and custom fields to Umbraco Forms
    /// </summary>
    public class FieldMappingModel
    {
        public string ListField { get; set; }

        public string Field { get; set; }

        public string StaticValue { get; set; }
    }
}