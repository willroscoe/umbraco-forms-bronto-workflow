using System.Collections.Generic;
using System.Linq;

namespace Wr.UmbFormsBrontoWorkflow.Models
{
    /// <summary>
    /// Holder of a Bronto list and associated default and custom fields
    /// </summary>
    public class ListMappingModel
    {
        public ListMappingModel()
        {
            Mappings = new List<FieldMappingModel>();
        }

        public string ListId { get; set; }

        public List<FieldMappingModel> Mappings { get; set; }
    }
}