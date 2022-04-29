namespace HNCHOME.ViewModel
{
    public class PagingNewsViewModel<T>
    {
        public List<T> PagingModels { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }
}
