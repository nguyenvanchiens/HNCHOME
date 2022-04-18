using HNCHOME.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HNCHOME.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly HNCDbContext _dbContext;

        public HomeController(IMenuRepository menuRepository, HNCDbContext dbContext)
        {
             _menuRepository = menuRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            var menu = GetParentNode();
            return PartialView(menu);
        }


        public JsonResult GetParentNode()
        {
            var result = _menuRepository.GetParentNode();
            return Json(result);
        }
    }
}