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
        [HttpGet]
        public IActionResult GetInfoById(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new Exception();
                }
                var customer = _customerRepository.GetById(id);
                var registration = _repository.GetAll().Where(m=>m.CustomerId==id).ToList();
                var serviceInfos= new List<ServiceInfo>();
                foreach (var service in registration)
                {
                    var serviceInfo = _serviceRepository.GetById(service.ServiceId);
                    serviceInfos.Add(serviceInfo);
                }
                return Ok(new {Services=serviceInfos, Customer=customer});
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = e.Message });
            }
        }
    }
}
