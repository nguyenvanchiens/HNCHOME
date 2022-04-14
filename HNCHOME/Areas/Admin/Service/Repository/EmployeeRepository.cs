

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HNCDbContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetAllPaeging(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
