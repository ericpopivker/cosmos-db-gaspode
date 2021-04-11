using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core.ReqRes
{
    public class OperationStats
    {
        public int Executed { get; set; }

        public int Total { get; set; }

        public int Remaining { get; set; }


        public double RusPerSec { get; set; }

        public double AvgOperationsPerSec { get; set; }

        
        public int EstimatedRemainingDurationInSec { get; set; }

        public int EstimatedTotalDurationInSec { get; set; }

        public int RunningDurationInSec { get; set; }



    }
}
