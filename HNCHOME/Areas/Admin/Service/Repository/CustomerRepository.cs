namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
