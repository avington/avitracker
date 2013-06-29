using System;

namespace AviTracker.Web.Models
{
    public class Timesheet
    {
        public int TimesheetId { get; set; }
        public virtual ProjectTask ProjectTask { get; set; }
        public virtual UserProfile User { get; set; }
        public DateTime? StartedAt { get; set; }
        public decimal? ActualHours { get; set; }
        public string Description { get; set; }
        public string RevisionNumber { get; set; }
        
    }
}