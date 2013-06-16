using System.Data.Entity;
using MvcApplication1.Models;

namespace AviTracker.Web.Models.ContextConfiguration
{
    public class ProjectTrackerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        

        public ProjectTrackerContext() : base("name=ProjectTrackerContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
        public DbSet<TimeSheetStatus> TimeSheetStatuses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientConfiguraton());
            modelBuilder.Configurations.Add(new ProjectConfiguraton());
            modelBuilder.Configurations.Add(new ProjectTaskConfiguraton());
            modelBuilder.Configurations.Add(new TaskTypeConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
