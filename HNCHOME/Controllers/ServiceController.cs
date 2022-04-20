using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
