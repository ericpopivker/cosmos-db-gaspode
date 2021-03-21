using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CosmosDbGaspode.Core
{
    public class CosmosDbClientFactory 
    {
        //From https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

        public static CosmosDbClient Create(CosmosDbOptions cosmosDbOptions)
        {
            Microsoft.Azure.Cosmos.CosmosClient cosmosClient = new Microsoft.Azure.Cosmos.CosmosClient(cosmosDbOptions.Account, cosmosDbOptions.Key);
            var cosmosDbClient = new CosmosDbClient(cosmosClient, cosmosDbOptions.DatabaseName, cosmosDbOptions.ContainerName);

            //Microsoft.Azure.Cosmos.DatabaseResponse database = cosmosClient.CreateDatabaseIfNotExistsAsync(cosmosDbOptions.DatabaseName).Result;
            //database.Database.CreateContainerIfNotExistsAsync(cosmosDbOptions.ContainerName, "/id").Wait();

            return cosmosDbClient;
        }
    }
}
