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
        public void AddService(ServiceInfo data)
        {
            ViewBag.Serviceinfo = _serviceRepository.Insert(data);
        }
    }
}
