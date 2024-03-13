using BlogDotNet8.Data.Repository;
using BlogDotNet8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet8.Controllers;

[Authorize(Roles = "Admin")]
public class PanelController : Controller
{
    private IRepository _repo;
    public PanelController(IRepository repo)
    {
        _repo = repo;
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

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null)
            return View(new Post());
        else
        {
            var post = _repo.GetPost((int)id);
            return View(post);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Post post)
    {
        if (post.Id > 0)
            _repo.UpdatePost(post);
        else
            _repo.AddPost(post);
        return await _repo.SaveChangesAsync() ? RedirectToAction("index") : View();
    }

    [HttpGet]
    public async Task<IActionResult> Remove(int id)
    {
        _repo.RemovePost(id);
        await _repo.SaveChangesAsync();
        return RedirectToAction("index");
    }

}
