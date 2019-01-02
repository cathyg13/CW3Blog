using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3Blog.Models
{
    public class BlogPostsViewModel
    {
        public BlogPostModel blogPost { get; set; }
        public List<CommentModel> comment { get; set; }
    }
}
