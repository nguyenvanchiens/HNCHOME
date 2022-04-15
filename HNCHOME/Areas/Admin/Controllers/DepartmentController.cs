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
    }
}
