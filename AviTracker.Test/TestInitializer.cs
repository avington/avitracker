using System;
using System.Collections.Generic;
using System.Data.Entity;
using AviTracker.Web.App_Start;
using AviTracker.Web.Models;
using AviTracker.Web.Models.ContextConfiguration;
using MvcApplication1.Models;

namespace AviTracker.Test
{
    public class TestInitializer : DropCreateDatabaseAlways<ProjectTrackerContext>
    {
        protected override void Seed(ProjectTrackerContext context)
        {
            SeedFactory.Load(context);
            base.Seed(context);
        }
    }
}