namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class OrderControllerVM
    {
        public Order Order { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
