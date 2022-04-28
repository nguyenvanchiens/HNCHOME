namespace HNCHOME.ViewModel
{
    public class PagingModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsMark { get; set; }
    }
    public class PagingItem
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public PagingModel LeftDoted { get; set; }
        public PagingModel RightDoted { get; set; }
        public PagingModel NextPage { get; set; }
        public PagingModel PreviousPage { get; set; }
        public PagingModel FirstPage { get; set; }
        public PagingModel LastPage { get; set; }
        public int TotalPage { get; set; }
        public List<PagingModel> pagingModels { get; set; }
        public string CallBackFunction { get; set; }

    }
}
