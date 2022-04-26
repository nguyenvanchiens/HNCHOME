using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class NewsController : Controller
    {
        private readonly HNCDbContext _context;
        public NewsController(HNCDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index(int pageIndex=1)
        {
            var news=Paging<NewsModel>.PagingModel(_context.NewsModels.OrderByDescending(m=>m.CreatedDate).ToList(), pageIndex, 1);
            return View(news);
        }
    }
}
