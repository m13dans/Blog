using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet8.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _context;

        public Repository(AppDbContext context) => _context = context;
        public void AddPost(Post post) => _context.Add(post);

        public List<Post> GetAllPost() => _context.Posts.ToList();

        public Post GetPost(int id) => _context.Posts.FirstOrDefault(x => x.Id == id);

        public void RemovePost(int id) => _context.Posts.Remove(GetPost(id));

        public void UpdatePost(Post post)
        {
            _context.Update(post);
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}