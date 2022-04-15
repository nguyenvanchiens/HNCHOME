using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HNCHOME.Controllers
{
    public class CountryViewComponent : ViewComponent
    {
        private readonly HNCDbContext _dbContext;
        public CountryViewComponent(HNCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            return View("Country",_dbContext.Countries.ToList());
        }
    }
}
