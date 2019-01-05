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

        //public List<string> CategoriesList { get; set; }

        //avatar

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        //who is logged in

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time")]
        //current date time see controller
        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(10000)]
        public string Content { get; set; }


    }
}
