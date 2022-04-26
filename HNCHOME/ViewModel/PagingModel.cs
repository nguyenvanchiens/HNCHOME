namespace HNCHOME.ViewModel
{
    public class PagingModel<T>
    {
        public int PageCount { get; set; }
        public List<T> ListModel { get; set; }
    }
}
