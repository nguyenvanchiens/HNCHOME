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
            ViewBag.Departments = _repository.GetAllPaeging(filter);
            return View();
        }

        [HttpPost]
        public JsonResult AddDepartment(Department department)
        {
            department.CreatedDate = DateTime.Now;
            _repository.Insert(department);
            _repository.Save();
            return Json("oke");
        }
        [HttpPost]
        public JsonResult UpdateDepartment(Department department)
        {
            _repository.Update(department);
            _repository.Save();
            return Json("Oke");
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
            _repository.Delete(DepartmentId);
            _repository.Save();
            return Json("Oke");
        }
    }
}
