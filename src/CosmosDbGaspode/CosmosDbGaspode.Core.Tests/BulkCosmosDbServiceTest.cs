using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using System.Diagnostics;

using Serilog;

namespace CosmosDbGaspode.Core.Tests
{
    public class BulkCosmosDbServiceTest
    {
        [SetUp]
        public async Task SetUp()
        {
            var bulkService = CreateBulkCosmosDbService();
            await bulkService.DeleteAll<Customer>();
        }


        public BulkCosmosDbService CreateBulkCosmosDbService()
        {
            var client = CosmosDbClientFactory.Create(Config.CosmosDbOptions);
            return new BulkCosmosDbService(client);
        }

        [Test]
        public async Task Create_100_When_called_works()
        {
            var stopwatch = Stopwatch.StartNew();

            var client = CosmosDbClientFactory.Create(Config.CosmosDbOptions);
            var bulkService = new BulkCosmosDbService(client);

            var customers = new List<Customer>();
            for (int i=0; i < 100; i++)
            {
                var customer = new Customer
                {
                    FirstName = "fn_" + i,
                    LastName = "ln_" + i
                };

                customers.Add(customer);
            }

            await bulkService.Create(customers);

            stopwatch.Stop();

            Log.Information($"Duration to create 100 customers: {stopwatch.ElapsedMilliseconds}ms");

            var query = client.CreateQuery<Customer>();
            int total = await client.GetCount(query);
            Assert.AreEqual(100, total);

        }
    }
}