using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using System.Diagnostics;

using Serilog;
using System;

using CosmosDbGaspode.Core.ReqRes;

namespace CosmosDbGaspode.Core.Tests
{
    public class CosmosDbServiceTest
    {
        [SetUp]
        public async Task SetUp()
        {
            var bulkService = CreateCosmosDbService();
            await bulkService.DeleteAll<Customer>();
        }


        public CosmosDbService CreateCosmosDbService()
        {
            var client = CosmosDbClientFactory.Create(Config.CosmosDbOptions);
            return new CosmosDbService(client);
        }

        [Test]
        public async Task Create_100_When_called_works()
        {
            var stopwatch = Stopwatch.StartNew();

            var cosmosDbService = CreateCosmosDbService();

            await CreateCustomers(cosmosDbService, 100);

            stopwatch.Stop();

            Log.Information($"Duration to create 100 customers: {stopwatch.ElapsedMilliseconds}ms");

            Assert.AreEqual(100, await cosmosDbService.GetCountAll<Customer>());

        }

        private async Task CreateCustomers(CosmosDbService cosmosDbService, int max)
        {
            var customers = new List<Customer>();
            for (int i = 0; i < max; i++)
            {
                var customer = new Customer
                {
                    FirstName = "fn_" + i,
                    LastName = "ln_" + i,
                    Age = i,
                };

                customers.Add(customer);
            }

            await cosmosDbService.Create(customers);
        }

        [Test]
        public async Task Delete_50_out_of_100_When_called_works()
        {
            var cosmosDbService = CreateCosmosDbService();

            await CreateCustomers(cosmosDbService, 100);

            var request = new CosmosDbDeleteRequest
            {
                Query = "SELECT c.id FROM c WHERE c.Age < 50"
            };

            await cosmosDbService.Delete<Customer>(request);

            Assert.AreEqual(50, await cosmosDbService.GetCountAll<Customer>());
        }
    }

}