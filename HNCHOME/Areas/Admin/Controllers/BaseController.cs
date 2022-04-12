using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BaseController : Controller
    {
        protected HNCDbContext _dbContext;
        public BaseController(HNCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
