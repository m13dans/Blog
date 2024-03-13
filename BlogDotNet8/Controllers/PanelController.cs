using BlogDotNet8.Data.FileManager;
using BlogDotNet8.Data.Repository;
using BlogDotNet8.Models;
using BlogDotNet8.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet8.Controllers;

[Authorize(Roles = "Admin")]
public class PanelController : Controller
{
    private IRepository _repo;
    private IFileManager _fileManager;

    public PanelController(
        IRepository repo,
        IFileManager fileManager
        )
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

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null)
            return View(new PostViewModel());
        else
        {
            var post = _repo.GetPost((int)id);
            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body
            });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel postVM)
    {
        var post = new Post
        {
            Id = postVM.Id,
            Title = postVM.Title,
            Body = postVM.Body,
            Image = await _fileManager.SaveImage(postVM.Image)
        };
        
        if (postVM.Id > 0)
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
