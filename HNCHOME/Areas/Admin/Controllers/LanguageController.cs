using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class LanguageController : BaseController
    {
        public LanguageController(HNCDbContext dbContext) : base(dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
