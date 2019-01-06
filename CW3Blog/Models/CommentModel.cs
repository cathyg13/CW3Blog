using System;
using System.ComponentModel.DataAnnotations;


namespace CW3Blog.Models
{
    public class CommentModel
    {
        //CommentID
        public int ID { get; set; }

        public virtual BlogPostModel BlogPost { get; set; }

        public string AuthorName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        public DateTime CreatedTime { get; set; }


        [Required]
        [StringLength(2000)]
        public string Content { get; set; }
    }
}
