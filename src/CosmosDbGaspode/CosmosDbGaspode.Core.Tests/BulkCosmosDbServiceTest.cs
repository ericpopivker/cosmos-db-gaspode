using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

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
        public async Task Create_1000_When_called_works()
        {
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

            var query = client.CreateQuery<Customer>();
            int total = query.Count();
            Assert.AreEqual(100, total);
        }
    }
}