namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class MenuControllerVM
    {
        public Menu  Menu { get; set; }
        public IEnumerable<Menu> MenuList { get; set; }
        public IEnumerable<Language> LanguageList { get; set; }
    }
}
