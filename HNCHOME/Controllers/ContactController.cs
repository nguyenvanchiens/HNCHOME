using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
