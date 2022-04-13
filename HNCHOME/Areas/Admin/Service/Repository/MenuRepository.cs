using HNCHOME.Service.Repository;

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
