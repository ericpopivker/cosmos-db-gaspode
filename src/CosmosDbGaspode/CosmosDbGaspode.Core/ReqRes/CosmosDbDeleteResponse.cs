using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core.ReqRes
{
    public class CosmosDbDeleteResponse
    {
        public string Status { get; set; }
        public OperationStats Stats { get; set; }

    }
}
