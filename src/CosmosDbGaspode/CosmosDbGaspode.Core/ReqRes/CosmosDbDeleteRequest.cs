using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core.ReqRes
{
    public class CosmosDbDeleteRequest
    {
        public CosmosDbOptions CosmosDbConfig { get; set; }

        public string Query { get; set; }

        public int MaxRus { get; set; }

    }
}
