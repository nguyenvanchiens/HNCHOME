using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    public class FeedBackController : BaseController
    {
        private readonly IFeedBackRepository _res;
        public FeedBackController(HNCDbContext dbContext, IFeedBackRepository feedBack) : base(dbContext)
        {
            _res = feedBack;
        }
        public IActionResult Index()
        {
            var modal = new FeedBackControllerVM();
            modal.FeedBacks = _res.GetAll();
            return View(modal);
        }
        [HttpGet]
        public JsonResult Get(Guid feedbackId)
        {
            var result = _res.GetById(feedbackId);
            return Json(result);
        }
    }
}
