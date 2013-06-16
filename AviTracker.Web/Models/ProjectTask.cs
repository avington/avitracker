using System;
using System.Collections.Generic;
using MvcApplication1.Models;

namespace AviTracker.Web.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public virtual Project Project { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Hours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
    }
}