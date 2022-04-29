namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class CustomerControllerVM
    {
        public Customer Customer { get; set; }
        public IEnumerable<Customer> Customers  { get; set; }
    }
}
