using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PDI.Models
{
    public class Queue
    {
        public string Name { get; set; }

        public int? AgentsOnline { get; set; }

        public bool IsActive { get; set; }
    }
}