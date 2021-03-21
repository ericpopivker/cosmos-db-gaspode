using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
