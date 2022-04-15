using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Components
{
    public class BranchViewComponent : ViewComponent
    {
        private readonly HNCDbContext _dbContext;
        public BranchViewComponent(HNCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            return View("Branch", _dbContext.Branches.ToList());
        }
    }
}
