using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MvcApplication1.Models;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class ProjectTaskConfiguraton : EntityTypeConfiguration<ProjectTask>
    {
        public ProjectTaskConfiguraton()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}