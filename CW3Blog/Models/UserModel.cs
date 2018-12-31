using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.Models
{

    public class UserModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(10)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime DoB { get; set; }
        public string Avatar { get; set; }
        //link to \images
        //would like lists for Gender Location
    }
}
