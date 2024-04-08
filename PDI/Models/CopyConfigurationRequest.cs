namespace PDI.Models
{
    public class CopyConfigurationRequest
    {
        public required string OriginTenant { get; set; }
        public required string OriginAuthorization { get; set; }
        public required string TargetTenant { get; set; }
        public required string TargetAuthorization { get; set; }
    }
}
