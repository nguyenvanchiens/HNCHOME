using HNCHOME.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Components
{
    public class PagingViewComponent : ViewComponent
    {
        private readonly HNCDbContext _dbContext;
        public PagingViewComponent(HNCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke(int total, int? pageSize = 2, int? currentIndex = 1)
        {
            int totalItem = total;
            var pagingItem = new PagingItem();
            pagingItem.LeftDoted = new PagingModel();
            pagingItem.RightDoted = new PagingModel();
            pagingItem.LeftDoted.Name = pagingItem.RightDoted.Name = "...";
            pagingItem.FirstPage = new PagingModel();
            pagingItem.PreviousPage = new PagingModel();
            pagingItem.LastPage = new PagingModel();
            pagingItem.NextPage = new PagingModel();
            pagingItem.pagingModels = new List<PagingModel>();
            pagingItem.PageIndex = currentIndex.Value;

            if (totalItem % pageSize == 0)
            {
                pagingItem.TotalPage = totalItem / pageSize.Value;
            }
            else
            {
                pagingItem.TotalPage = totalItem / pageSize.Value + 1;
            }

            for (int i = 1; i <= pagingItem.TotalPage; i++)
            {
                var pagingModel = new PagingModel();
                pagingModel.IsActive = true;
                pagingModel.Name = i.ToString();
                pagingModel.IsMark = false;
                if (currentIndex - 2 > int.Parse(pagingModel.Name))
                {
                    pagingModel.IsActive = false;
                }
                else
                {
                    pagingModel.IsActive = true;
                }

                if (currentIndex + 2 < int.Parse(pagingModel.Name))
                {
                    pagingModel.IsActive = false;
                }
                if (currentIndex == int.Parse(pagingModel.Name))
                {
                    pagingModel.IsMark = true;
                }
                pagingItem.pagingModels.Add(pagingModel);
            }


            pagingItem.FirstPage.Name = "1";
            pagingItem.LastPage.Name = pagingItem.TotalPage.ToString();


            if (currentIndex <= 3)
            {
                pagingItem.FirstPage.IsActive = false;
                pagingItem.PreviousPage.IsActive = false;
                pagingItem.LeftDoted.IsActive = false;
            }
            else
            {
                pagingItem.FirstPage.IsActive = true;
                pagingItem.PreviousPage.IsActive = true;

                pagingItem.LeftDoted.IsActive = true;
            }



            if (currentIndex >= pagingItem.TotalPage - 2)
            {
                pagingItem.LastPage.IsActive = false;
                pagingItem.NextPage.IsActive = false;

                pagingItem.RightDoted.IsActive = false;
            }
            else
            {
                pagingItem.LastPage.IsActive = true;
                pagingItem.NextPage.IsActive = true;

                pagingItem.RightDoted.IsActive = true;
            }
            return View("Paging", pagingItem);
        }

    }
}
