using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuRepository _menuRepository;
        public MenuViewComponent (IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public IViewComponentResult Invoke()
        {
            var res = _menuRepository.GetParentNode();
            return View("Menu",res);
        }
    }
}
