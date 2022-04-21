namespace HNCHOME.Models
{
    public class ServiceInfo
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string ServiceTypeName { get; set; }
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
        public bool IsChecked { get; set; }
    }
}
