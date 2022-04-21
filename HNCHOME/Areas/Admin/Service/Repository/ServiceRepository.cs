namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class ServiceRepository:BaseRepository<ServiceInfo>, IServiceRepository
    {
        public ServiceRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
