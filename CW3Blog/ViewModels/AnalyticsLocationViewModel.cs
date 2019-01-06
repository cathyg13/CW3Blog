using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.ViewModels
{
    public class AnalyticsLocationViewModel
    {
        public int ID { get; set; }

        public string Location { get; set; }

        [Display(Name = "Number of Users")]
        public int NumUsers { get; set; }
    }
}
