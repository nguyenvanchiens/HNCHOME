using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceInfoController : BaseController
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceInfoController(HNCDbContext dbContext, IServiceRepository serviceRepository) : base(dbContext)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Serviceinfo = _serviceRepository.GetAll();
            return View();
        }
        public IActionResult AddService(ServiceInfo data)
        {
            try
            {
                _serviceRepository.Insert(data);
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
                throw;
            }
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _serviceRepository.Delete(id);
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
                throw;
            }
        }
        [HttpPost]
        public IActionResult UpdateServiceInfo(ServiceInfo serviceInfo)
        {
            try
            {
                var obj = _serviceRepository.GetById(serviceInfo.ServiceId);
                obj.ServiceTypeName=serviceInfo.ServiceTypeName;
                _serviceRepository.Save();
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetServiceInfoById(Guid id)
        {
            try
            {
                return Ok(new { Res = _serviceRepository.GetById(id) });
            }
            catch (Exception)
            {
                return BadRequest(new { Res = "Object was detected or modified" });
                throw;
            }
        }
    }
}
