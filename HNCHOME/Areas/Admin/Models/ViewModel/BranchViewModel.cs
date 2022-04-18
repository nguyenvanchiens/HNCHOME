namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class BranchViewModel
    {
        public Guid BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public Guid CountryId { get; set; }
        public Guid LanguageId { get; set; }
        public string CountryName { get; set; }
        public string LanguageName { get; set; }
    }
}
