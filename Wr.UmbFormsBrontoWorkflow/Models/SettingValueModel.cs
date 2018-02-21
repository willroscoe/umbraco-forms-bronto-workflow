using System.Collections.Generic;
using System.Linq;

namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Holder of a Bronto list and associated default and custom fields
    /// </summary>
    public class SettingValueModel
    {
        public SettingValueModel()
        {
            mappings = new List<FieldMappingModel>();
        }

        public string listId { get; set; }

        public List<FieldMappingModel> mappings { get; set; }
    }
}