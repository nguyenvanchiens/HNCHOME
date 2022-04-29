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
            var model = new MenuControllerVM();
            model.MenuList = _dbContext.Menus.Where(x => x.ParentId == Guid.Empty)
                .Select(x => new Menu
                {
                    MenuId = x.MenuId,
                    Link = x.Link,
                    Title = x.Title,
                    ParentId = x.ParentId,
                }).ToList();
            model.LanguageList = _dbContext.Languages.ToList();
            return View(model);
        }
        public JsonResult Get(Guid id)
        {
            var menu = _menuRepository.GetById(id);
            return Json(menu);
        }
        [HttpPost]
        public JsonResult Create(Menu menu)
        {
            try
            {
                var result = _menuRepository.Insert(menu);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
           
        }
        [HttpPost]
        public JsonResult Edit(Menu menu)
        {
            try
            {
                var result = _menuRepository.Update(menu);
                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
           
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            try
            {
                var result = _menuRepository.Delete(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult GetParentNode()
        {
            var result = _menuRepository.GetParentNode();
            return Json(result);
        }
        [HttpGet]
        public JsonResult GetAllMenu()
        {
            var result = _menuRepository.GetAll();
            return Json(result);
        }
    }
}
