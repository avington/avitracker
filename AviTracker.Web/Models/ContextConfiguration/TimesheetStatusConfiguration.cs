using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class TimesheetStatusConfiguration : EntityTypeConfiguration<TaskStatus>
    {
        public TimesheetStatusConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}