using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Forms.Core;
using Wr.UmbFormsBrontoWorkflow.BrontoSoapService;
using Wr.UmbFormsBrontoWorkflow.Models;

namespace Wr.UmbFormsBrontoWorkflow
{
    public static class ParseFormToBronto
    {
        public static contactObject Contact(Record record)
        {
            return new contactObject();
        }
    }
}