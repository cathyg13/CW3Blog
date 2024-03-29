﻿using CW3Blog.Models;
using System;
using System.Collections.Generic;

namespace CW3Blog.ViewModels
{
    public class BlogPostCommentsViewModel
    {
        public BlogPostModel BlogPost { get; set; }
        public List<CommentModel> Comments { get; set; }
        public int BlogPostID { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Content { get; set; }
    }
}
