using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    //[Area("Admin")]
    public class ServiceInfoController : BaseController
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceInfoController(HNCDbContext dbContext, IServiceRepository serviceRepository) : base(dbContext)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Serviceinfo=_serviceRepository.GetAll();
            return View();
        }
        public IActionResult AddService(ServiceInfo data)
        {
            try
            {
                _serviceRepository.Insert(data);
                return Ok("Successfully");
            }
            catch (Exception e)
            {
                return BadRequest("Unsuccessfully");
                throw;
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _serviceRepository.Delete(id);
                return Ok("Successfully");
            }
            catch (Exception e)
            {
                return BadRequest("Unsuccessfully");
                throw;
            }
        }
    }
}
