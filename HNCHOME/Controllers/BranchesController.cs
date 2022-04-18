using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly HNCDbContext _dbContext;

        public BranchesController(HNCDbContext dbContext, ICountryRepository countryRepository, ILanguageRepository languageRepository)
        {
            _countryRepository = countryRepository;
            _languageRepository = languageRepository;
            _dbContext = dbContext;
        }
        public class parramGetBranchById
        {
            public string Id { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public JsonResult GetBranchById([FromBody] parramGetBranchById data)
        {
            return Json(_dbContext.Branches.Where(m=>m.CountryId.ToString() == data.Id).ToList());
        }
    }
}
