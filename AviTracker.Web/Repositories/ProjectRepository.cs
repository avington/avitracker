using AviTracker.Web.Models;

namespace AviTracker.Web.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public Project Add(Project entity, bool persist)
        {
            Context.Projects.Add(entity);
            if (persist) Save();
            return entity;
        }
    }
}