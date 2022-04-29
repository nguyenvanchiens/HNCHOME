

using HNCHOME.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace HNCHOME.Areas.Admin.Controllers
{
    
    public class HomeController : BaseController
    {
        private readonly IEmployeeRepository _res;
        public HomeController(HNCDbContext dbContext, IEmployeeRepository res) : base(dbContext)
        {
            _res = res;
        }

        public IActionResult Index([FromQuery] string filter)
        {
            ViewBag.isCreate = GetClaimAdd();

            var model = new HomeControllerVM();
            model.DepartmentList = _dbContext.Department.ToList();
            model.ListEmployeeVM = (from e in _dbContext.Employees
                               join d in _dbContext.Department
                               on e.DepartmentId equals d.DepartmentId
                               orderby e.CreatedDate ascending
                               select new EmployeeViewModel
                               {
                                   EmployeeId = e.EmployeeId,
                                   EmployeeCode = e.EmployeeCode,
                                   EmployeeName = e.EmployeeName,
                                   Address = e.Address,
                                   CreatedDate = e.CreatedDate,
                                   DateOfBirth = e.DateOfBirth,
                                   DepartmentName = d.DepartmentName
                               }).OrderByDescending(x => x.CreatedDate).ToList();            
            return View(model);
        }
        [HttpGet]
        public Employee GetEmployeeCode(Guid employeeId, string employeeCode)
        {
            var result = _dbContext.Employees.Where(x => x.EmployeeCode == employeeCode && x.EmployeeId != employeeId).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            try
            {
                employee.CreatedDate = DateTime.Now;
                employee.PassWord = Helper.CalculateMD5Hash(employee.PassWord);
                var result = _res.Insert(employee);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {                   
            try
            {
                var result = _res.Update(employee);
                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
        }
        [HttpGet]
        public Employee Get(Guid employeeId)
        {
            var entity = _res.GetById(employeeId);
            return entity;
        }

        [HttpPost]
        public JsonResult Delete(Guid EmployeeId)
        {
            try
            {
                var reuslt = _res.Delete(EmployeeId);
                return Json(reuslt);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
            
           
        }
        [HttpGet]
        public string NewCodeEmployee()
        {
            var employeeLast = (from e in _dbContext.Employees orderby e.EmployeeCode descending select e.EmployeeCode).FirstOrDefault();
            string newCode = "";
            string temp = "";
            int converNumberCode;
            if (employeeLast == null)
            {
                newCode = "NV0001";
            }
            else
            {
                var subCode = employeeLast.Substring(0, 2);
                var lengthLastCode = employeeLast.Length;
                converNumberCode = Convert.ToInt32(employeeLast.Substring(2, lengthLastCode - 2));
                converNumberCode = converNumberCode + 1;
                if (converNumberCode < 10)
                {
                    temp += subCode + "000";
                }
                else if (converNumberCode < 100)
                {
                    temp += subCode + "00";
                }
                else if (converNumberCode < 1000)
                {
                    temp += subCode + "0";
                }
                else
                {
                    temp += subCode;
                }
                newCode = temp + converNumberCode.ToString();
            }
            return newCode;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Role(Guid id)
        {
            ViewBag.Permissions = _dbContext.Permissions.Where(x => x.ParentId == null).ToList();
            ViewBag.EmployeeId = id;
            var employee = Get(id);
            ViewBag.checkedvalue = (from e in _dbContext.Employees
                                    join
                                    r in _dbContext.Roles on e.EmployeeId equals r.EmployeeId
                                    join p in _dbContext.Permissions on r.PermissionId equals p.PermissionId
                                    where e.EmployeeId == id
                                    select p.PermissionId).ToList();
            return View(employee);
        }
        [HttpPost]
        public JsonResult Role(Guid id, string[] listId)
        {
            var employee = _dbContext.Employees.Where(x => x.EmployeeId == id).First();
            List<Role> list = _dbContext.Roles.Where(x => x.EmployeeId == id).ToList();
            _dbContext.Roles.RemoveRange(list);
            _dbContext.SaveChanges();
            if (listId.Length > 0)
            {
                var role = new Role();
                for (int i = 0; i < listId.Length; i++)
                {
                    role.RoleId = Guid.NewGuid();
                    role.EmployeeId = id;
                    role.PermissionId = Guid.Parse(listId[i]);
                    role.Licensed = true;
                    _dbContext.Roles.Add(role);
                    _dbContext.SaveChanges();
                }
            }
            return Json(true);
        }
        public bool GetClaimAdmin()
        {

            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            var values = roles.Select(x => x.Value).ToList();
            bool flg = false;
            foreach (var item in values)
            {
                if (item == Resources.Admin)
                {
                    flg = true;
                }
            }
            return flg;
        }
        public bool GetClaimAdd()
        {

            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            var values = roles.Select(x => x.Value).ToList();
            bool flg = false;
            foreach (var item in values)
            {
                if (item == Resources.Admin || item == Resources.Create || item == Resources.User)
                {
                    flg = true;
                }
            }
            return flg;
        }
    }
}
