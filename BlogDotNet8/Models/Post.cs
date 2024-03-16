using System.ComponentModel.DataAnnotations;

namespace BlogDotNet8.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image {get; set;} = "";

        public string Description { get; set; } ="";
        public string Tags { get; set; } ="";
        public string Category { get; set; } ="";
        public DateTime Created { get; set; } = DateTime.Now;
    }
}