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
            var model = new LanguageControllerVM();
            model.Languages = _res.GetAll().OrderBy(x=>x.SortOrder).ToList();
            return View(model);
        }
        public JsonResult GetById(Guid id)
        {
            var reuslt = _res.GetById(id);
            return Json(reuslt);
        }
        [HttpPost]
        public IActionResult AddOrUpdate(Language language, IFormFile Image)
        {
            try
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
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
            
        }
        public JsonResult Update(Language language)
        {
            try
            {
                var result = _res.Update(language);               
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
           
        }
        public JsonResult Delete(Guid id)
        {
           
            try
            {
                var result = _res.Delete(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
