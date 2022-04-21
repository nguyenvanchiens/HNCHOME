namespace HNCHOME.Models
{
    public class ServiceInfo:BaseClass
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string ServiceTypeName { get; set; }
    }
}
