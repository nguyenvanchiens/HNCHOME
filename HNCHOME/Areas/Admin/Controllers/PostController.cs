using HNCHOME.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostRepository _postRepository;
        public PostController(HNCDbContext dbContext, IPostRepository postRepository) : base(dbContext)
        {
            _postRepository = postRepository;
        }

        // GET: PostController
        public ActionResult Index(string filter)
        {
            ViewBag.Posts = _dbContext.Posts.ToList().OrderByDescending(x=>x.CreatedDate);
            return View();
        }

        // GET: PostController/Details/5
        public Post Details(Guid id)
        {
            var post = _postRepository.GetById(id);
            return post;
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PostController/Create
        [HttpPost]
        public JsonResult Create(Post post)
        {
            try
            {
                post.CreatedDate = new DateTime();
                var result = _postRepository.Insert(post);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
        // GET: PostController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var result = _postRepository.GetById(id);
            return View(result);
        }

        // POST: PostController/Edit/5
        [HttpPut]
        public JsonResult Edit(Guid id, Post post)
        {
            try
            {
                var result = _postRepository.Update(post);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        // POST: PostController/Delete/5
        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            try
            {
                var result = _postRepository.Delete(id);
                return Json(result);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }        
        }
    }
}
