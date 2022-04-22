namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class CountriesControllerVM
    {
        public Country Country { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
