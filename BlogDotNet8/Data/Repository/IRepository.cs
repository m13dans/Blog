using BlogDotNet8.Models;

namespace BlogDotNet8.Data.Repository;

public interface IRepository
{
    public Post GetPost(int id);
    public List<Post> GetAllPost();
    public void AddPost(Post post);
    public void UpdatePost(Post post);
    public void RemovePost(int id);

    public Task<bool> SaveChangesAsync();
}