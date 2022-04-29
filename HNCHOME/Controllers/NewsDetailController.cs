using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class NewsDetailController : Controller
    {
        HNCDbContext _context;
        public NewsDetailController(HNCDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(Guid? id)
        {
            return View(_context.NewsModels.Where(m=> m.NewsId==id).FirstOrDefault());
        }
    }
}
