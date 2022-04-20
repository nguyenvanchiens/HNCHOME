namespace HNCHOME.Models
{
    public class ServiceInfo
    {
        [Key]
        public Guid ServiceId { get; set; }
        public string ServiceTypeName { get; set; }
        public string GoodsType { get; set; }
        public float Weight { get; set; }
        public string Size { get; set; }
        public float Quantum { get; set; }
        public float Quantity { get; set; }
        public bool IsChecked { get; set; }
    }
}
