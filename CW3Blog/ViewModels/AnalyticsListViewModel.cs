using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3Blog.ViewModels
{
    public class AnalyticsListViewModel
    {
        public int ID { get; set; }
        public List<AnalyticsViewModel> AuthorCountList {get; set;}
    }
}
