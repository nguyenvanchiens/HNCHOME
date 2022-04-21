namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class CustomerServiceRegistrationViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public List<ServiceInfo> ServiceInfos { get; set; }
        public ServiceInfo ServiceInfo { get; set; }
    }
}
