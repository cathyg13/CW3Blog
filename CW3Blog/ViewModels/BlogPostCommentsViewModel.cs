using CW3Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3Blog.ViewModels
{
    public class BlogPostCommentsViewModel
    {
        public BlogPostModel BlogPost { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
