

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
