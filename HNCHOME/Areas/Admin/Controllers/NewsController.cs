using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : BaseController
    {
        private readonly INewsRepository _newsRepository;
        public string path;
        private readonly IConfiguration _configuration;
        public NewsController(HNCDbContext dbContext, INewsRepository newsRepository, IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var obj = new NewsViewModel();
            obj.NewsModels = _newsRepository.GetAll().ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult AddNews(NewsModel newsModel)
        {
            try
            {
                if(newsModel == null)
                {
                    throw new Exception("Unsuccessfully");
                }
                newsModel.CreatedDate = DateTime.Now;
                newsModel.ModifiedDate = DateTime.Now;
                _newsRepository.Insert(newsModel);
                return Ok(new { Result = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Result = "Unsuccessfully" });
            }
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public IActionResult UploadFile(IFormFile formFile)
        {
            try
            {
                var extension = Path.GetExtension(formFile.FileName);
                if (formFile.Length > 0)
                {
                    if (ValidateImgExtension(extension))
                    {
                        var newName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                        path = CreateFilePath(newName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        return Ok(new { Res = newName });
                    }
                }
                throw new Exception("Unsuccessfully");
            }
            catch (Exception)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
            }
        }
        public string CreateFilePath(string fileName)
        {
            path = _configuration["NewsImgPath"];
            path = Path.Combine(path, fileName);
            return path;
        }
        public bool ValidateImgExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            else if (!Constants.FileExtension.imgExtension.Contains(fileName))
            {
                return false;
            }
            return true;
        }
        [HttpPost]
        public IActionResult DeleteNews(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new Exception("Unsuccessfully");
                }
                _newsRepository.Delete(id);
                return Ok(new { Res = "Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest("Unsuccessfully");
                throw;
            }
        }
        [HttpPost]
        public IActionResult UpdateNews(NewsModel newsModel)
        {
            try
            {
                var news = _newsRepository.GetById(newsModel.NewsId);
                if (news == null)
                {
                    throw new Exception("Unsuccessfully");
                }
                if (newsModel != null)
                {
                    if (!string.IsNullOrEmpty(newsModel.ImgUrl))
                    {
                        news.ImgUrl = newsModel.ImgUrl;
                    }
                    news.Content = newsModel.Content;
                    news.Title = newsModel.Title;
                    news.ModifiedDate = DateTime.Now;
                };
                _newsRepository.Update(news);

                return Ok(new { Res = "Successfully" });
               
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetNewsById(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    throw new Exception("Unsuccessfully");
                }
                return Ok(new { Res = _newsRepository.GetById(id) });
            }
            catch (Exception e)
            {
                return BadRequest(new { Res = "Unsuccessfully" });
            }
        }
    }
}
