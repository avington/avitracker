using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class TimesheetConfiguration : EntityTypeConfiguration<Timesheet>
    {
        public TimesheetConfiguration()
        {
            HasKey(x => x.TimesheetId);
            Property(x => x.TimesheetId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}