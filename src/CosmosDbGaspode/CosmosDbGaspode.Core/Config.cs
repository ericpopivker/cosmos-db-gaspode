using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core
{
    public static class Config
    {
        public static CosmosDbOptions CosmosDbOptions =>
           new CosmosDbOptions
           {
                Account = "https://localhost:8081",
                Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                DatabaseName = "cosmos-db-gaspode",
                ContainerName = "Customers"
           };
    };
}
