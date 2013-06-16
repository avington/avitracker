using System.Data.Entity;
using AviTracker.Web.DependencyResolution;
using StructureMap;

namespace AviTracker.Test
{
    public class BootstrapTest
    {
        public BootstrapTest()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new DefaultRegistry()));
            Database.SetInitializer(new TestInitializer());
        }
    }
}