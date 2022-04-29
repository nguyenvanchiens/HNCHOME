using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentRepository _repository = null;
        public DepartmentController(HNCDbContext dbContext, IDepartmentRepository repository) : base(dbContext)
        {
            this._repository = repository;
        }

        // GET: DepartmentController
        public ActionResult Index([FromQuery] string filter)
        {
            var model = new DepartmentControllerVM();
            model.Departments = _repository.GetAll();
            return View(model);
        }

        [HttpPost]
        public JsonResult AddDepartment(Department department)
        {
            try
            {
                department.CreatedDate = DateTime.Now;
                var result = _repository.Insert(department);

                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
        }
        [HttpPost]
        public JsonResult UpdateDepartment(Department department)
        {
            try
            {
                var result = _repository.Update(department);
                return Json(result);
            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
           
        }
        [HttpGet]
        public IActionResult Get(Guid departmentId)
        {
            var entity = _repository.GetById(departmentId);
            return Ok(entity);

        }
        [HttpPost]
        public JsonResult Delete(Guid DepartmentId)
        {
            try
            {
                var result = _repository.Delete(DepartmentId);
                return Json(result);

            }
            catch (Exception e)
            {

                return Json(e.Message);
            }
           
        }
        [HttpGet]
        public string NewCodeDepartment()
        {
            var employeeLast = (from e in _dbContext.Department orderby e.DepartmentCode descending select e.DepartmentCode).FirstOrDefault();
            string newCode = "";
            string temp = "";
            int converNumberCode;
            if (employeeLast == null)
            {
                newCode = "PB01";
            }
            else
            {
                var subCode = employeeLast.Substring(0, 2);
                var lengthLastCode = employeeLast.Length;
                converNumberCode = Convert.ToInt32(employeeLast.Substring(2, lengthLastCode - 2));
                converNumberCode = converNumberCode + 1;
                if (converNumberCode < 10)
                {
                    temp += subCode + "0";
                }
                newCode = temp + converNumberCode.ToString();
            }
            return newCode;
        }
    }
}
