using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : BaseController
    {
        private readonly INewsRepository _newsRepository;
        string path;
        private readonly IConfiguration _configuration;
        public NewsController(HNCDbContext dbContext, INewsRepository newsRepository, IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var obj=new NewsViewModel();
            obj.NewsModels = _newsRepository.GetAll().ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult AddNews(NewsModel newsModel)
        {
            try
            {
                _newsRepository.Insert(newsModel);
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new {Res="Unsuccessfully"});
                throw;
            }
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public IActionResult UploadFile(IFormFile formFile)
        {
            try
            {
                if(formFile.Length > 0)
                {
                    string path = CreateFilePath(formFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    return Ok(new { Res = path });
                }
                return BadRequest(new { Res = "Unsuccessfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
                throw;
            }
        }
        public string CreateFilePath(string fileName)
        {

            this.path = _configuration["NewsImgPath"];
            string path = Path.Combine(this.path, fileName);
            return path;
        }
    }
}
