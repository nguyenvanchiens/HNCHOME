using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    public class BranchController : BaseController
    {
        #region Constructor
        private readonly IBranchRepository _branchRepository;
        public BranchController(HNCDbContext dbContext, IBranchRepository branchRepository) : base(dbContext)
        {
            _branchRepository = branchRepository;
        }
        #endregion
        #region Method
        public IActionResult Index()
        {
            var model = new BranchControllerVM();
            model.BranchList = (from branch in _dbContext.Branches
                               join country in _dbContext.Countries
                               on branch.CountryId equals country.CountryId
                               join language in _dbContext.Languages
                               on branch.LanguageId equals language.LanguageId
                               select new BranchViewModel
                               {
                                   BrandId = branch.BrandId,
                                   BrandName = branch.BrandName,
                                   Address = branch.Address,
                                   Phone = branch.Phone,
                                   CountryId = country.CountryId,
                                   LanguageId = language.LanguageId,
                                   CountryName = country.CountryName,
                                   LanguageName = language.Name
                               }).ToList();
            model.Languages = _dbContext.Languages.ToList();
            model.Country = _dbContext.Countries.ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Add(Branch branch)
        {
            try
            {
                var result = _branchRepository.Insert(branch);
                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
        }
        [HttpPost]
        public JsonResult Update(Branch branch)
        {
            try
            {
                var result = _branchRepository.Update(branch);
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
                var result = _branchRepository.Delete(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
        [HttpGet]
        public JsonResult Get(Guid id)
        {
            try
            {
                var result = _branchRepository.GetById(id);
                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
        }
        #endregion
    }
}
