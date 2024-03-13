﻿using BlogDotNet8.Models;
using Microsoft.AspNetCore.Mvc;
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
            var posts = _repo.GetAllPost();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }
        
    }
}
