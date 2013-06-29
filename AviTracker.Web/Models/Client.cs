using System.Collections.Generic;

namespace AviTracker.Web.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}