using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbGaspode.Core
{
    public class BulkCosmosDbService
    {
        CosmosDbClient _cosmosDbClient;
        public BulkCosmosDbService(CosmosDbClient cosmosDbClient)
        {
            _cosmosDbClient = cosmosDbClient;
        }


        public async Task Create<T>(List<T> entities) where T : EntityBase
        {
            foreach(var entity in entities)
            {
                await _cosmosDbClient.Create<T>(entity);
            }
        }


        public async Task DeleteAll<T>() where T : EntityBase
        {
            var query =_cosmosDbClient.CreateQuery<T>();
            var newQuery = query.Select(e => e.Id);

            var ids = await _cosmosDbClient.Find(newQuery);

            foreach (var id in ids)
            {
                await _cosmosDbClient.Delete<T>(id);
            }
        }

    }
}
