using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    public class CustomerServiceRegistrationController : BaseController
    {
        private readonly ICustomerServiceRegistrationRepository _repository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICustomerRepository _customerRepository;
        public CustomerServiceRegistrationController(HNCDbContext dbContext, ICustomerServiceRegistrationRepository customerServiceRegistrationRepository
            , ICustomerRepository customerRepository, IServiceRepository serviceRepository) : base(dbContext)
        {
            _repository = customerServiceRegistrationRepository;
            _serviceRepository = serviceRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var obj = new CustomerServiceRegistrationViewModel();
            obj.Customers = _customerRepository.GetAll().ToList();
            obj.ServiceInfos = _serviceRepository.GetAll().ToList();
            return View(obj);
        }
    }
}
