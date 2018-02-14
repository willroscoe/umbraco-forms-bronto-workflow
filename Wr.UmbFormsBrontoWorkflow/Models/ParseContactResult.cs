using Bronto.API.BrontoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Forms.Core.Enums;

namespace Wr.UmbFormsBrontoWorkflow.Models
{
    public class ParseContactResult
    {
        public bool hasError { get; set; }
        public contactObject contact { get; set; }
    }
}