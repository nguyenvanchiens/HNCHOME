using HNCHOME.ViewModel;

namespace HNCHOME.Common
{
    public class Paging<T>
    {
        public static object PagingModel(List<T> li, int pageIndex, int pageSize)
        {
            if (li != null)
            {
                int pagesCount = 0;
                List<T> list = new List<T>();
                pagesCount = li.Count / pageSize;
                if (li.Count % pageSize != 0)
                {
                    pagesCount++;
                }
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                }
                list = li.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                return new PagingModel<T>
                {
                    PageCount = pagesCount,
                    ListModel = list,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
