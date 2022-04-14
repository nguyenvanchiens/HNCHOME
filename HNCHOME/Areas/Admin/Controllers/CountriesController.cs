#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HNCHOME.Data;
using HNCHOME.Models;

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
            ViewBag.country = _countryRepository.GetAllPaeging(filter);
            ViewBag.language = _languageRepository.GetAll();
            return View();
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
            country.CreatedDate=DateTime.Now;
            country.Language=_languageRepository.GetById(country.LanguageId);
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
                _countryRepository.Update(country);
                return Ok("Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Unsuccessfully");
            }
        }

        // GET: Admin/Countries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult GetCountryInfo(Guid countryId)
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

        // POST: Admin/Countries/Delete/5
    }
}
