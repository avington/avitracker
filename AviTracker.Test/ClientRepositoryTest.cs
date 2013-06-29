using System.Linq;
using AviTracker.Web.Models;
using AviTracker.Web.Repositories;
using NUnit.Framework;
using StructureMap;

namespace AviTracker.Test
{
    [TestFixture]
    public class ClientRepositoryTest : BootstrapTest
    {
        private IClientRepository _repository;

        [TestFixtureSetUp]
        public void Setup()
        {
            _repository = ObjectFactory.GetInstance<IClientRepository>();
        }
        [Test]
        public void ShouldBeAbleToReadClientTable()
        {

            var clients = _repository.GetAll().ToList();
            Assert.That(clients.Count > 0);
        }

        [Test]
        public void ShouldBeAbleToAddAndDeleteClient()
        {
            var client = new Client()
                {
                    ClientName = "My New Test Client",
                    ContactName = "Teddy Bear",
                    EmailAddress = "t@test.com"
                };

            Client add = _repository.Add(client, true);
            Assert.That(add.ClientId > 0,"Client Id was not returned from database");

            Client delete = _repository.Delete(add.ClientId);

            var deletedClient = _repository.Find(add.ClientId);

            Assert.That(deletedClient != null, "The client was not deleted");
        }
    }
}