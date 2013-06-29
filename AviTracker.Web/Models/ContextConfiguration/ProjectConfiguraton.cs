using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class ProjectConfiguraton : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguraton()
        {
            HasKey(x => x.ProjectId);
            Property(x => x.ProjectId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.Client);
        }
    }
}