using BlogDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}