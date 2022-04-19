using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
