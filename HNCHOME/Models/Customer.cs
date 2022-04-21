namespace HNCHOME.Models
{
    public class Customer:BaseClass
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Column(TypeName ="Nvarchar(100)")]
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int TaxCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DeliveryType { get; set; }
        public string FirstDestination { get; set; }
        public string LastDestination { get; set; }
        public string GoodsType { get; set; }
        public float Weight { get; set; }
        public string Size { get; set; }
        public float Quantum { get; set; }
        public float Quantity { get; set; }
        public string OtherRequest{ get; set; }
    }
}
