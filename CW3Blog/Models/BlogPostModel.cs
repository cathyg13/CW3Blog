using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3Blog.Models
{
    public class BlogPostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        //public List<string> CategoriesList { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Content { get; set; }
    }
}
