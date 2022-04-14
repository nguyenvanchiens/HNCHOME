using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
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
            var res = _repository.GetAll();
            ViewBag.Departments = _repository.GetAllPaeging(filter);
            return View();
        }

        [HttpPost]
        public JsonResult AddDepartment(Department department)
        {
            department.CreatedDate = DateTime.Now;
            var result = _repository.Insert(department);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult UpdateDepartment(Department department)
        {
            var result = _repository.Update(department);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
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
            var result = _repository.Delete(DepartmentId);
            if (result == (int)StatusCodeRespon.Success)
            {
                return Json(result);
            }
            return Json(result);
        }
    }
}
