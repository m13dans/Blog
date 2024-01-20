using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDotNet8.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
    }
}