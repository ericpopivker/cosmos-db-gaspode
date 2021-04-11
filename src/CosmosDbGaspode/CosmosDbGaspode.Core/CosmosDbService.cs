using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CosmosDbGaspode.Core.ReqRes;

namespace CosmosDbGaspode.Core
{
    public class CosmosDbService
    {
        CosmosDbClient _cosmosDbClient;
        public CosmosDbService(CosmosDbClient cosmosDbClient)
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

            var ids = await _cosmosDbClient.Find<string>(newQuery);

            foreach (var id in ids)
            {
                await DeleteById<T>(id);
            }
        }

        public async Task DeleteById<T>(string id) where T : EntityBase
        {
            await _cosmosDbClient.Delete<T>(id);
        }


        public async Task Delete<T>(CosmosDbDeleteRequest request) where T : EntityBase
        {
            var entities = await _cosmosDbClient.Find<T>(request.Query);

            foreach (var entity in entities)
                await DeleteById<T>(entity.Id);
        }


        public async Task<int> GetCountAll<T>()
        {
            var query = _cosmosDbClient.CreateQuery<T>();
            int total = await _cosmosDbClient.GetCount(query);

            return total;
        }



    }
}
