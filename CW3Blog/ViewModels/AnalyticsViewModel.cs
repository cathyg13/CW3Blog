using CW3Blog.Models;
using System;
using System.Collections.Generic;

namespace CW3Blog.ViewModels
{
    public class AnalyticsViewModel
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public int NumComments { get; set; }
    }
}
