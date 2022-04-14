using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace HNCHOME.Controllers
{
    public class LanguageController : BaseController
    {
        private readonly ILanguageRepository _res;
        public LanguageController(HNCDbContext dbContext, ILanguageRepository res) : base(dbContext)
        {
            _res = res;
        }
        public IActionResult Index()
        {
            ViewBag.Languages = _res.GetAll().OrderBy(x=>x.SortOrder).ToList();
            return View();
        }
        public JsonResult GetById(Guid id)
        {
            var reuslt = _res.GetById(id);
            return Json(reuslt);
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Language language, IFormFile Image)
        {
           
            if (Image != null)
            {
                //Set Key Name
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                language.Image = ImageName;
                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/languageImage", ImageName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
            }
            else
            {
                var entity = _res.GetById(language.LanguageId);
                language.Image = entity.Image;
            }
            if (language.LanguageId == Guid.Empty)
            {
                
                var result = _res.Insert(language);
                if (result == (int)StatusCodeRespon.UpdateSuccess)
                {
                    return Redirect("/Admin/Language/Index");
                }
                return BadRequest(result);
            }
            else
            {
               
                var result = _res.UpdateLanguage(language);
                if (result == (int)StatusCodeRespon.UpdateSuccess)
                {
                    return Redirect("/Admin/Language/Index");
                }
                return BadRequest(result);
            }
            
        }
        public JsonResult Update(Language language)
        {
            var result = _res.Update(language);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
        public JsonResult Delete(Guid id)
        {
            var result = _res.Delete(id);
            if (result == (int)StatusCodeRespon.UpdateSuccess)
            {
                return Json(result);
            }
            return Json(result);
        }
    }
}
