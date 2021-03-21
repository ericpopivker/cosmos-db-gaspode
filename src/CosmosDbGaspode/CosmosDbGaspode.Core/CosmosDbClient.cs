using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace CosmosDbGaspode.Core
{
    //https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application

    public class CosmosDbClient 
    {
        private Container _container;

        public CosmosDbClient( CosmosClient dbClient,  string databaseName,   string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task Create<T>(T entity) where T : EntityBase
        {
            entity.Id = Guid.NewGuid().ToString();

            var response = await _container.CreateItemAsync<T>(entity, new PartitionKey(entity.Id));
        }


        public async Task<List<T>> Find<T>()
        {
            var queryIterator = _container.GetItemLinqQueryable<T>().ToFeedIterator();
            var results = new List<T>();

            while (queryIterator.HasMoreResults)
            {
                var response = await queryIterator.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<T> GetById<T>(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task Update<T>(string id, T entity) 
        {
            await _container.UpsertItemAsync<T>(entity, new PartitionKey(id));
        }

        public async Task Delete<T>(string id) 
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task DeleteAll()
        {
            var iterator =  _container.GetItemLinqQueryable<EntityBase>().Select(eb => eb.Id).ToFeedIterator();
            var ids = new List<string>();

            while (iterator.HasMoreResults)
            {
                foreach (var id in await iterator.ReadNextAsync())
                {
                    ids.Add(id);
                }
            }

            foreach (var id in ids)
            {
                await _container.DeleteItemStreamAsync(id, new PartitionKey(id));
            }

        }
    }

}
