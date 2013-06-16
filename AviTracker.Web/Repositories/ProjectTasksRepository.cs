﻿using AviTracker.Web.Models;
using MvcApplication1.Models;

namespace AviTracker.Web.Repositories
{
    public class ProjectTasksRepository :BaseRepository<ProjectTask>, IProjectTasksRepository
    {
        public ProjectTask Add(ProjectTask entity, bool persist)
        {
            Context.ProjectTasks.Add(entity);
            if (persist) Save();
            return entity;     
        }
    }
}