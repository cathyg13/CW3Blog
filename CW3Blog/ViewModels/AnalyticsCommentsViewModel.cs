using System.ComponentModel.DataAnnotations;

namespace CW3Blog.ViewModels
{
    public class AnalyticsCommentsViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Username")]
        public string AuthorName { get; set; }

        [Display(Name = "Number of Comments")]
        public int NumComments { get; set; }
    }
}
