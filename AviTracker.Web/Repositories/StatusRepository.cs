using AviTracker.Web.Models;

namespace AviTracker.Web.Repositories
{
    public class StatusRepository : BaseRepository<TaskStatus>, IStatusRepository
    {
        public TaskStatus Add(TaskStatus entity, bool persist)
        {
            entity = Context.TaskStatuses.Add(entity);
            if (persist)
            {
                Context.SaveChanges();
            }
            return entity;
        }
    }
}