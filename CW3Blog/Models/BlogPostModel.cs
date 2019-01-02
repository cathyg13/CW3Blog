using System;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.Models
{
    public class BlogPostModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        
        //public List<string> CategoriesList { get; set; }

        //avatar

        public string AuthorName { get; set; }
        //who is logged in

        [Required]
        //current date time see controller
        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }
    }
}
