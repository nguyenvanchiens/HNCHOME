

using HNCHOME.Service.Repository;

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HNCDbContext context) : base(context)
        {
        }

        public IEnumerable<Department> GetAllPaeging(string filter)
        {
            IEnumerable<Department> result = new List<Department>();
            if (filter != null)
            {
                result = _context.Department.Where(x => x.DepartmentCode.Contains(filter) || x.DepartmentName.Contains(filter))
                    .ToList();
            }
            else
            {
                result = _context.Department.ToList();
            }
            return result;
        }
    }
}
