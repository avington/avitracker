using System;
using System.Collections.Generic;
using System.Data.Entity;
using AviTracker.Web.Models;
using AviTracker.Web.Models.ContextConfiguration;

namespace AviTracker.Web.App_Start
{
    public class ProjectTrackingInitializer : DropCreateDatabaseAlways<ProjectTrackerContext>
    {
        protected override void Seed(ProjectTrackerContext context)
        {
            SeedFactory.Load(context);
            base.Seed(context);
        }
    }
}