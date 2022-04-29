using HNCHOME.ViewModel;
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

        public IActionResult Index(int? pageIndex = 1, int? pageSize = 1)
        {
            var news = _context.NewsModels.OrderByDescending(m => m.ModifiedDate).Skip(pageSize.Value * (pageIndex.Value - 1)).Take(pageSize.Value).ToList();

            foreach (var item in news)
            {
                var contentArr = item.Content.Split('.');
                if (contentArr.Length != 0 && contentArr.Length >= 2)
                {
                    item.Content = contentArr[0] + "." + contentArr[1] + ".";
                    item.Content = item.Content.Split('>')[1];
                }
            }

            var pagingNewsViewModel = new PagingNewsViewModel<NewsModel>();
            pagingNewsViewModel.PagingModels = new List<NewsModel>();
            pagingNewsViewModel.PagingModels = news;
            pagingNewsViewModel.PageIndex = pageIndex.Value;
            pagingNewsViewModel.PageSize = pageSize.Value;
            pagingNewsViewModel.Total = _context.NewsModels.Count();


            if (news.Count == 0)
            {
                return View(pagingNewsViewModel);
            }
            return View(pagingNewsViewModel);
        }
    }
}
