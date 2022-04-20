using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class ContactController : Controller
    {
        private readonly IFeedBackRepository _res;
        public ContactController(IFeedBackRepository res)
        {
            _res = res;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(FeedBack feedBack)
        {
            if (!ModelState.IsValid)
            {              
                return View(feedBack);
            }
            else
            {
                feedBack.CreatedDate = DateTime.Now;
                var result = _res.Insert(feedBack);
                return View(feedBack);
            }
        }
    }
}
