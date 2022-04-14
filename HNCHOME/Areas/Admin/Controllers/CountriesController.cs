#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HNCHOME.Areas.Admin.Controllers
{
    public class CountriesController : BaseController
    {

        public CountriesController(HNCDbContext dbContext) : base(dbContext)
        {
        }

        // GET: Admin/Countries
        public async Task<IActionResult> Index()
        {
            var hNCDbContext = _dbContext.Countries.Include(c => c.Language);
            return View(await hNCDbContext.ToListAsync());
        }

        // GET: Admin/Countries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _dbContext.Countries
                .Include(c => c.Language)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // GET: Admin/Countries/Create
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_dbContext.Languages, "LanguageId", "LanguageId");
            return View();
        }

        // POST: Admin/Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,CountryName,Description,LanguageId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Country country)
        {
            if (ModelState.IsValid)
            {
                country.CountryId = Guid.NewGuid();
                _dbContext.Add(country);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageId"] = new SelectList(_dbContext.Languages, "LanguageId", "LanguageId", country.LanguageId);
            return View(country);
        }

        // GET: Admin/Countries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _dbContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_dbContext.Languages, "LanguageId", "LanguageId", country.LanguageId);
            return View(country);
        }

        // POST: Admin/Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CountryId,CountryName,Description,LanguageId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Country country)
        {
            if (id != country.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(country);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.CountryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageId"] = new SelectList(_dbContext.Languages, "LanguageId", "LanguageId", country.LanguageId);
            return View(country);
        }

        // GET: Admin/Countries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _dbContext.Countries
                .Include(c => c.Language)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        // POST: Admin/Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(Guid id)
        {
            return _dbContext.Countries.Any(e => e.CountryId == id);
        }
    }
}
