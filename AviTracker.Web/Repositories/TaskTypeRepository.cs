using AviTracker.Web.Models;

namespace AviTracker.Web.Repositories
{
    public class TaskTypeRepository : BaseRepository<TaskType>, ITaskTypeRepository
    {
        public TaskType Add(TaskType entity, bool persist)
        {
            Context.TaskTypes.Add(entity);
            if (persist) Context.SaveChanges();
            return entity;
        }
    }
}