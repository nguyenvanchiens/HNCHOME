using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class ServiceController : Controller
    {
        HNCDbContext _context;
        public ServiceController(HNCDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.ServiceInfos.ToList());
        }
        [HttpPost]
        public IActionResult ServiceRegistration(Customer customer, List<Guid> serviceId)
        {
            if (customer == null)
            {
                throw new Exception();
            }
            try
            {
                customer.CustomerId = Guid.NewGuid();
                

                customer.ModifiedBy = DateTime.Now.ToString();
                customer.CreatedDate = DateTime.Now;
                _context.Customers.Add(customer);
                foreach (var id in serviceId)
                {
                    var customerServiceRegistration = new CustomerServiceRegistration();
                    customerServiceRegistration.CustomerId = customer.CustomerId;
                    customerServiceRegistration.ServiceId = id;
                    _context.customerServiceRegistrations.Add(customerServiceRegistration);
                }
                _context.SaveChanges();
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = "Error" });
            }
        }
    }
}
