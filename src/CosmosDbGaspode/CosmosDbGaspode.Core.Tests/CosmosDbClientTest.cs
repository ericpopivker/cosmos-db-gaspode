using System.Threading.Tasks;

using NUnit.Framework;

namespace CosmosDbGaspode.Core.Tests
{
    public class CosmosDbClientTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetById_When_called_locally_works()
        {
            var client = CosmosDbClientFactory.Create();

            //var customer = new Customer { FirstName = "E1", LastName = "P1" };
            //await client.Create(customer);

            var customer = await client.GetById<Customer>("f094539f-f7d5-4b4a-a52d-c70632a2050c");

            Assert.IsNotNull(customer);
        }
    }
}