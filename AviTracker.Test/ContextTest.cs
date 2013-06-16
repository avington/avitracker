using System.Data.Entity;
using System.Linq;
using AviTracker.Web.Models.ContextConfiguration;
using NUnit.Framework;

namespace AviTracker.Test
{
    [TestFixture]
    public class ContextTest : BootstrapTest
    {

        [Test]
        public void WhenConnectedToDatabaseShouldBeAbleToReadClientTable()
        {
            var context = new ProjectTrackerContext();
            var clients = context.Clients.ToList();

            Assert.That(clients.Count > 0,"no clients");
            Assert.That(clients[0].Projects.Count > 0,"no prjects");
            Assert.That(clients[0].Projects[0].ProjectTasks.Count > 0,"no tasks");
        }
    }
}