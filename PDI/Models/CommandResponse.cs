using Microsoft.AspNetCore.WebUtilities;

namespace PDI.Models
{
    public class CommandResponse
    {
        public string? Type { get; set; }
        public Resource? Resource { get; set; }
        public string? Method { get; set; }
        public string? Status { get; set; }
        public string? Id { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public Reason? Reason { get; set; }
    }
}


