using BlogDotNet8.Models;
using Microsoft.AspNetCore.Mvc;
using BlogDotNet8.Data.Repository;
using BlogDotNet8.Data.FileManager;

namespace BlogDotNet8.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IFileManager _fileManager;

        public HomeController(IRepository repo, IFileManager fileManager)
        {
            _repo = repo;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            var posts = _repo.GetAllPost();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var ext = Path.GetExtension(image).TrimEnd('.');
            // var mime = image.Substring(image.LastIndexOf('.')) + 1;
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{ext}");
        }
        
    }
}
