using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceRepository _serviceRepository;
        public CustomerController(HNCDbContext dbContext, ICustomerRepository customerRepository, IServiceRepository serviceRepository) : base(dbContext)
        {
            _serviceRepository = serviceRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customerList=_customerRepository.GetAll();
            ViewBag.customers = customerList;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            try
            {
                if(customer == null)
                {
                    throw new Exception();
                }
                _customerRepository.Insert(customer);
                return Ok(new { Code = 200, Res = "Successfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { Code = 500, Res = "Unsuccessfully" });
            }
        }
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new Exception();
                }
                _customerRepository.Delete(id);
                return Ok(new {Res= "Successfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
            }
        }
        [HttpGet]
        public void GetCustomerDetail(Guid id)
        {
            try
            {
                if(id== Guid.Empty)
                {
                    throw new Exception();
                }
                ViewBag.customer = _customerRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
