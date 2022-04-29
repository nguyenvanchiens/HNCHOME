namespace HNCHOME.Areas.Admin.Models.ViewModel
{
    public class BranchControllerVM
    {
        public Branch Branch { get; set; }
        public List<BranchViewModel> BranchList { get; set; }
        public List<Country> Country { get; set; }
        public List<Language> Languages { get; set; }
    }
}
