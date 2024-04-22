namespace PDI.Models
{
    public class Resource
    {
        public string? Id {  get; set; }
        public string? Total {  get; set; }
        public string? ItemType { get; set; }
        public List<Queue>? Items { get; set; }
        public string? Name { get; set; }
        public Boolean? IsActive { get; set; }
        public string? OwnerIdentity {  get; set; }

        public Resource(string name)
        {
            Name = name;
            IsActive = true;
        }
    }
}
