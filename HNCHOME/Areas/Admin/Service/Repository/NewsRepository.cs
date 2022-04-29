namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class NewsRepository : BaseRepository<NewsModel>, INewsRepository
    {
        public NewsRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
