using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie_API_Project.Models
{
    public class MovieUser
    {
        [Required]
        [RegularExpression("^[A-Z]+[A-z]{1,30}$")]
        public string FirstName { set; get; }
        [Required]
        [RegularExpression("^[a-zA-Z]{2,}$")]
        public string LastName { set; get; }
        [Required]
        [RegularExpression(@"^([A-z0-9\.]{5,30})@([A-z]{5,10})\.([a-z]{2,3})$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[A-z0-9]{8,30}$")]
        public string Password { get; set; }

        public MovieUser()
        {
            FirstName = "";
            LastName = "";
        }
        public MovieUser(string email, string password, string first, string last)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            Password = password;
        }
    }
}