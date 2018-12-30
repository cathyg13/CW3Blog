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
        /*public enum Gender { Male = 0, Female = 1, PreferNotToSay = 3 }
            public Gender Gender { get; set; }
        public enum Location { UnitedKingdom = 0 }
            public Location Location { get; set; }*/
        public string DoB { get; set; }
        public string Avatar { get; set; }
        //link to \images
    }
}
