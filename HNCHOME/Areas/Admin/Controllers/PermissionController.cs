using HNCHOME.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class PermissionController : BaseController
    {
        private readonly IPermissionRepository _res;
        public PermissionController(HNCDbContext dbContext, IPermissionRepository res) : base(dbContext)
        {
            _res = res;
        }


        public IActionResult Index()
        {
            var permision = _dbContext.Permissions.Select(x => new Permission()
            {
                PermissionId = x.PermissionId,
                PermissionName = x.PermissionName,
                ParentId = x.ParentId,
                CreatedDate = x.CreatedDate,
            }).ToList();
            ViewBag.Permisions = permision;
            var result = permision.Where(a => a.ParentId == null).ToList();
            return View(result);
        }



        public JsonResult GetParentNode()
        {            
            var permission = _dbContext.Permissions.Select(x => new PerrmissionNodeTree()
            {
                PermissionId = x.PermissionId,
                PermissionName = x.PermissionName,
                ParentId = x.ParentId,
                CreatedDate = x.CreatedDate,
            }).ToList();
           

            List<PerrmissionNodeTree> result = new List<PerrmissionNodeTree>();
            result = permission
                            .Where(c => c.ParentId == null)
                            .Select(c => new PerrmissionNodeTree() { PermissionId = c.PermissionId, PermissionName = c.PermissionName, ParentId = c.ParentId, Childrent = GetChildren(permission, c.PermissionId) })
                            .ToList();
            return Json(result);
        }

        public static List<PerrmissionNodeTree> GetChildren(List<PerrmissionNodeTree> permissions, Guid parentId)
        {
            return permissions
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new PerrmissionNodeTree { PermissionId = c.PermissionId, PermissionName = c.PermissionName, ParentId = c.ParentId, Childrent = GetChildren(permissions, c.PermissionId) })
                    .ToList();
        }


        public JsonResult GetSubMenuCheck(Guid pid, Guid idEp)
        {
            List<Permission> subPermision = new List<Permission>();
            Guid pID = Guid.NewGuid();
            Guid.TryParse(pid.ToString(), out pID);

            subPermision = _dbContext.Permissions.Where(a => a.ParentId == pID).OrderBy(a => a.PermissionName).ToList();

            var value = (from e in _dbContext.Employees
                         join
                         r in _dbContext.Roles on e.EmployeeId equals r.EmployeeId
                         join p in _dbContext.Permissions on r.PermissionId equals p.PermissionId
                         where e.EmployeeId == idEp
                         where p.ParentId != null
                         select p.PermissionId).ToList();

            return Json(new { data = subPermision, checkedvalue = value, ideP = idEp });
        }
        [HttpGet]
        public Permission Get(Guid id)
        {
            var result = _res.GetById(id);
            return result;
        }
        [HttpPost]
        public JsonResult Create(Permission permission)
        {
            permission.CreatedDate = DateTime.Now;
            _res.Insert(permission);
            _res.Save();
            return Json("oke");
        }
        [HttpPost]
        public JsonResult Edit(Permission permission)
        {
            _res.Update(permission);
            _res.Save();
            return Json("oke");
        }
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _res.Delete(id);
            _res.Save();
            return Json("oke");
        }
        [HttpGet]
        public JsonResult GetAllPermission()
        {
            var result = _res.GetAll();
            return Json(result);
        }
    }
}

