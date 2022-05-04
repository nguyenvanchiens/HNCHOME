using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class SearchPageController : Controller
    {
        HNCDbContext _hNCDbContext;
        public SearchPageController(HNCDbContext hNCDbContext)
        {
            _hNCDbContext = hNCDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
