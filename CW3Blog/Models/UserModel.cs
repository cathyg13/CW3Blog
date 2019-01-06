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
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }
        
        public string Gender { get; set; }

        public string Location { get; set; }
    }
}
