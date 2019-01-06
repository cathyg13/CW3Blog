﻿using CW3Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.ViewModels
{
    public class AnalyticsViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Username")]
        public string AuthorName { get; set; }

        [Display(Name = "Number of Comments")]
        public int NumComments { get; set; }
    }
}
