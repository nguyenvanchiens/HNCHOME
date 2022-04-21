using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
