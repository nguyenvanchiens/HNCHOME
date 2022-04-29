

using HNCHOME.Properties;
using HNCHOME.Service.Repository;

namespace HNCHOME.Areas.Admin.Service.Repository
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HNCDbContext context) : base(context)
        {
        }

        public string checkDuplicate(Department department)
        {
            var result = "";
            var checkDepartmentName = _context.Department.FirstOrDefault(x => x.DepartmentName == department.DepartmentName && x.DepartmentId != department.DepartmentId);
            if (checkDepartmentName != null)
            {
                result = String.Format(Resources.checkDepartmentCode, department.DepartmentName);
            }
            return result;
        }
        public override int Insert(Department obj)
        {
            var result = checkDuplicate(obj);
            if (result != "")
            {
                throw new Exception(result);
            }
            return base.Insert(obj);
        }
        public override int Update(Department obj)
        {
            var result = checkDuplicate(obj);
            if (result != "")
            {
                throw new Exception(result);
            }
            var department = _context.Department.Where(x=>x.DepartmentId==obj.DepartmentId).First();
            department.DepartmentCode = obj.DepartmentCode;
            department.DepartmentName = obj.DepartmentName;
            department.UpdatedDate = DateTime.Now;
            _context.Department.Update(obj);
            _context.SaveChanges();
            return (int)StatusCodeRespon.UpdateSuccess;
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
