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
            var menus = _dbContext.Menus.Select(x => new TreeNodeMenu()
            {
                MenuId = x.MenuId,
                Title = x.Title,
                Link = x.Link,
                ParentId = x.ParentId
            }).ToList();
            List<TreeNodeMenu> result = new List<TreeNodeMenu>();
            result = menus.Where(c => c.ParentId == Guid.Empty)
                          .Select(c => new TreeNodeMenu() { MenuId = c.MenuId, Title = c.Title, ParentId = c.ParentId, Link = c.Link, data = GetChildren(menus, c.MenuId) })
                          .ToList();
            return Json(result.ToArray());
        }

        public static List<TreeNodeMenu> GetChildren(List<TreeNodeMenu> menus, Guid parentId)
        {
            return menus
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new TreeNodeMenu { MenuId = c.MenuId, Title = c.Title, Link = c.Link, ParentId = c.ParentId, data = GetChildren(menus, c.MenuId) })
                    .ToList();
        }

    }
}