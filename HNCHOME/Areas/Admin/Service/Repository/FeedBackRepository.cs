namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class FeedBackRepository : BaseRepository<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
