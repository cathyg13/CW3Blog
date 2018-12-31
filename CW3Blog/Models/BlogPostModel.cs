using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Required]
        public DateTime CreatedTime { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
