using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Components
{
    public class LanguageViewComponent : ViewComponent
    {
        private readonly ILanguageRepository  _languageRepository;
        public LanguageViewComponent(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public IViewComponentResult Invoke()
        {
            var res = _languageRepository.GetAll();
            return View("Language",res);
        }
    }
}
