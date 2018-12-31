using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW3Blog.Models
{

    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DoB { get; set; }
        public string Avatar { get; set; }
        //link to \images
        //would like lists for Gender Location
    }
}
