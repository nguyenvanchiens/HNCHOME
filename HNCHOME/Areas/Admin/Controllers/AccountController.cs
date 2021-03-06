using HNCHOME.Properties;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HNCHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly HNCDbContext _context;
        public AccountController(HNCDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            var user = _context.Employees.Where(x => x.UserName == objLoginModel.UserName && x.PassWord == Helper.CalculateMD5Hash(objLoginModel.Password)).FirstOrDefault();
            if (user != null)
            {
                var role = (from r in _context.Roles
                            join p in _context.Permissions
                            on r.PermissionId equals p.PermissionId
                            where r.EmployeeId == user.EmployeeId
                            select p.PermissionName).ToList();
                List<Claim> claims = new List<Claim>();
                if (role.Count > 0)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.EmployeeName));
                    foreach (var item in role)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }
                }
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = objLoginModel.RememberLogin
                });
                return Redirect("/Admin");
            }
            else
            {
                ViewBag.Message = Resources.UserOrPassWordNotFind;
                return View(user);
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/Admin/Account/Login");
        }
        public IActionResult NotAuthozire()
        {
            return View();
        }
    }
}
