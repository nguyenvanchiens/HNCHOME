using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
