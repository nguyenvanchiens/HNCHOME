namespace HNCHOME.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Column(TypeName ="Nvarchar(100)")]
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int TaxCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid DeliveryType { get; set; }
        public string FirstDestination { get; set; }
        public string LastDestination { get; set; }
        public string OtherRequest { get; set; }
        public string ServiceInfos { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
