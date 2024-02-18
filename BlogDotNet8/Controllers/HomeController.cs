using BlogDotNet8.Models;
using Microsoft.AspNetCore.Mvc;
using BlogDotNet8.Data;
using BlogDotNet8.Data.Repository;

namespace BlogDotNet8.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;
        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.AddPost(post);
            return await _repo.SaveChangesAsync() ? RedirectToAction("index") : View();
        }
    }
}
