using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class BranchesController : BaseController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILanguageRepository _languageRepository;

        public BranchesController(HNCDbContext dbContext, ICountryRepository countryRepository, ILanguageRepository languageRepository) : base(dbContext)
        {
            _countryRepository = countryRepository;
            _languageRepository = languageRepository;
        }
        public class parramGetBranchById
        {
            public string Id { get; set; }
        }


        [IgnoreAntiforgeryToken]
        [HttpPost]
        public JsonResult GetBranchById([FromBody] parramGetBranchById data)
        {
            return Json(_dbContext.Branches.Where(m=>m.CountryId.ToString() == data.Id).ToList());
        }
    }
}
