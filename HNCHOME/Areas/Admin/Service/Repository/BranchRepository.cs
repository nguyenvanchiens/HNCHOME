namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
