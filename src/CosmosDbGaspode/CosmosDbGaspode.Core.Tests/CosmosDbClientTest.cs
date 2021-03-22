using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

namespace CosmosDbGaspode.Core.Tests
{
    public class CosmosDbClientTest
    {
        [SetUp]
        public async Task Setup()
        {
            var client = CosmosDbClientFactory.Create(Config.CosmosDbOptions);
            var bulkService =  new BulkCosmosDbService(client);
            await bulkService.DeleteAll<Customer>();
        }

        [Test]
        public async Task GetById_When_called_then_works()
        {
            var client = CosmosDbClientFactory.Create();

            var customer = new Customer { FirstName = "FN1", LastName = "LN1" };
            await client.Create(customer);

            customer = await client.GetById<Customer>("f094539f-f7d5-4b4a-a52d-c70632a2050c");

            Assert.IsNotNull(customer);
        }


        [Test]
        public async Task FindAll_When_called_then_works()
        {
            var client = CosmosDbClientFactory.Create();

            var customer = new Customer { FirstName = "FN1", LastName = "LN1" };
            await client.Create(customer);


            var customers = await client.FindAll<Customer>();

            Assert.AreEqual(1, customers.Count);
            Assert.IsNotNull(customers[0]);
        }



        [Test]
        public async Task Find_When_called_then_works()
        {
            var client = CosmosDbClientFactory.Create();

            var customer = new Customer { FirstName = "FN1", LastName = "LN1" };
            await client.Create(customer);

            customer = new Customer { FirstName = "FN2", LastName = "LN2" };
            await client.Create(customer);

            var query = client.CreateQuery<Customer>();
            var customers = await client.Find(query.Where(c => c.FirstName == "FN1"));

            //https://github.com/Azure/azure-cosmos-dotnet-v3/issues/589

            Assert.AreEqual(1, customers.Count);
            Assert.AreEqual("FN1", customers[0].FirstName);
        }
    }
}