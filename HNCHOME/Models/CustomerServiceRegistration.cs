namespace HNCHOME.Models
{
    public class CustomerServiceRegistration:BaseClass
    {
        [Key]
        public Guid RegistrationId { get; set; }
        [ForeignKey("ServiceId")]
        public Guid ServiceId { get; set; }
        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
    } 
}
