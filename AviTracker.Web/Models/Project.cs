using System;
using System.Collections.Generic;

namespace AviTracker.Web.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ProjectTask> ProjectTasks { get; set; }
    }
}