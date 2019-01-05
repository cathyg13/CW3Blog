using System;
using System.ComponentModel.DataAnnotations;


namespace CW3Blog.Models
{
    public class CommentModel
    {
        //CommentID
        public int ID { get; set; }

        public virtual BlogPostModel BlogPost { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        //who is logged in

        //avatar

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public DateTime CreatedTime { get; set; }
        //current date time see controller

        [Required]
        [StringLength(2000)]
        public string Content { get; set; }
    }
}
