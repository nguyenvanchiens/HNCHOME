namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class CustomerRegistrationRepository : BaseRepository<CustomerServiceRegistration>, ICustomerServiceRegistrationRepository
    {
        public CustomerRegistrationRepository(HNCDbContext context) : base(context)
        {
        }
    }
}
