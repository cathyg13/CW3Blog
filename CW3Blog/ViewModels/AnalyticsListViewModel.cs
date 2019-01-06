using System.Collections.Generic;

namespace CW3Blog.ViewModels
{
    public class AnalyticsListViewModel
    {
        public int ID { get; set; }
        public List<AnalyticsViewModel> AuthorCountList {get; set;}
    }
}
