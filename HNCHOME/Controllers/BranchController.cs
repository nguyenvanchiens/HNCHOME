using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class BranchController : Controller
    {
        private HNCDbContext _dbContext;

        public BranchController(HNCDbContext dbContext)
        {

            this._dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBranchById(Guid id)
        {
            return Json(this._dbContext.Branches.Where(m => m.CountryId == id).ToList());
        }
    }
}
