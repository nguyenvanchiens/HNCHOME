


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

        public override int Insert(Employee obj)
        {
            var result = CheckDublicate(obj);
            if (result != "")
            {
                throw new Exception(result);
            }
            return base.Insert(obj);
        }
        public override int Update(Employee obj)
        {
            var result = CheckDublicate(obj);
            if (result != "")
            {
                throw new Exception(result);
            }
            var employee = _context.Employees.Where(x => x.EmployeeId == obj.EmployeeId).First();
            employee.EmployeeCode = obj.EmployeeCode;
            employee.EmployeeName = obj.EmployeeName;
            employee.UserName = obj.UserName;
            employee.DateOfBirth = obj.DateOfBirth;
            employee.Address = obj.Address;
            employee.Phone = obj.Phone;
            employee.DepartmentId = obj.DepartmentId;
            _context.Employees.Update(employee);
            Save();
            return (int)StatusCodeRespon.UpdateSuccess;

        }
        public string CheckDublicate(Employee employee)
        {
            string result = "";
            var employees = _context.Employees.ToList();
            var checkEmployeeCode = employees.Where(x => x.EmployeeCode == employee.EmployeeCode && x.EmployeeId != employee.EmployeeId).FirstOrDefault();
            var checkUserName = employees.Where(x => x.UserName == employee.UserName && x.EmployeeId != employee.EmployeeId).FirstOrDefault();
            if (checkEmployeeCode != null)
            {
                result = String.Format(Resources.checkEmployeeCode, employee.EmployeeCode);
            }
            if (checkUserName != null)
            {
                result = String.Format(Resources.checkUserName, employee.UserName);
            }

            return result;
        }
    }
}
