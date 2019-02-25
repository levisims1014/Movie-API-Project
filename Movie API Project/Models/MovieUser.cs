using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie_API_Project.Models
{
    public class MovieUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public MovieUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}