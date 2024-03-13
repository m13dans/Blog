namespace BlogDotNet8.Data.FileManager;

public interface IFileManager
{
    FileStream ImageStream(string image);
    Task<string> SaveImage(IFormFile file);
}
