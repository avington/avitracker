using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MvcApplication1.Models;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class TaskTypeConfiguration : EntityTypeConfiguration<TaskType>
    {
        public TaskTypeConfiguration()
        {
            HasKey(x => x.TaskTypeId);
            Property(x => x.TaskTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TaskTypeName).HasMaxLength(100);
        }
    }
}