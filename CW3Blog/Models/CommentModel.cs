using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CW3Blog.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        [Required]
        //public int PostID = BlogPostModel.GetID;
        public string AuthorName { get; set; }
        //who is logged in
        //avatar
        [Required]
        public DateTime CreatedTime { get; set; }
        //current date time see controller
        [Required]
        [StringLength(2000)]
        public string Content { get; set; }
    }
}
