using System.Collections.Generic;
using AviTracker.Web.Models;

namespace MvcApplication1.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ProjectTask> ProjectTasks { get; set; }
    }
}