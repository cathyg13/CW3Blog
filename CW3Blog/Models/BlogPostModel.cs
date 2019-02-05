using System;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.Models
{
    public class BlogPostModel
    {
        //PostID
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }


    }
}
