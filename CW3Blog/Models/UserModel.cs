using System;
using System.ComponentModel.DataAnnotations;

namespace CW3Blog.Models
{

    public class UserModel
    {
        //UserID
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [DataType(DataType.Upload)]
        public string Avatar { get; set; }
        //link to \images

        //would like lists for Gender Location
    }
}
