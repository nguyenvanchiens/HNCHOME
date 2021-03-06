#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountriesController : BaseController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILanguageRepository _languageRepository;

        public CountriesController(HNCDbContext dbContext, ICountryRepository countryRepository, ILanguageRepository languageRepository) : base(dbContext)
        {
            _countryRepository = countryRepository;
            _languageRepository = languageRepository;
        }

        // GET: Admin/Countries
        public IActionResult Index([FromQuery] string filter)
        {
            var model = new CountriesControllerVM();
            model.Countries = _countryRepository.GetAll();
            model.Languages = _languageRepository.GetAll();
            return View(model);
        }

        // GET: Admin/Countries/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _countryRepository.GetById(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Admin/Countries/Create
        [HttpPost]
        public IActionResult Create(Country country)
        {
            country.CreatedDate = DateTime.Now;
            try
            {
                _countryRepository.Insert(country);
                return Ok("Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            try
            {
                var res = _countryRepository.GetById(country.CountryId);
                if (country!=null)
                {
                    res.LanguageId = country.LanguageId;
                    res.CountryName = country.CountryName;
                    res.Description = country.Description;
                }
                _countryRepository.Update(res);
                return Ok("Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Unsuccessfully");
            }
        }

        // GET: Admin/Countries/Delete/5
        [HttpPost]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                _countryRepository.Delete(id);
                return Ok("Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Unsuccessfully");
            }
        }
        [HttpGet]
        public object GetCountryInfo(Guid countryId)
        {
            try
            {
                var result = _countryRepository.GetById(countryId);
                return Json(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
