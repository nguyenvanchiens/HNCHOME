namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
