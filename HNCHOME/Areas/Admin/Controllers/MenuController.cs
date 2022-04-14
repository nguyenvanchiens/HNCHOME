using HNCHOME.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuRepository _menuRepository;
        private List<Menu> menuList = new List<Menu>();
        public MenuController(HNCDbContext dbContext, IMenuRepository menuRepository) : base(dbContext)
        {
            _menuRepository = menuRepository;
        }

        public IActionResult Index()
        {
            var result = _dbContext.Menus.Where(x => x.ParentId == Guid.Empty)
                .Select(x => new Menu
                {
                    MenuId = x.MenuId,
                    Link = x.Link,
                    Title = x.Title,
                    ParentId = x.ParentId,
                }).ToList();
            var language = _dbContext.Languages.ToList();
            ViewBag.Menus = result;
            ViewBag.Language = language;
            return View();
        }
        public JsonResult Get(Guid id)
        {
            var menu = _menuRepository.GetById(id);
            return Json(menu);
        }
        [HttpPost]
        public JsonResult Create(Menu menu)
        {
            var result = _menuRepository.Insert(menu);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult Edit(Menu menu)
        {
            var result = _menuRepository.Update(menu);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            var result = _menuRepository.Delete(id);
            if (result == (int)StatusCodeRespon.Success)
            {
                return Json(result);
            }
            return Json(result);
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
        [HttpGet]
        public JsonResult GetAllMenu()
        {
            var result = _menuRepository.GetAll();
            return Json(result);
        }
    }
}
