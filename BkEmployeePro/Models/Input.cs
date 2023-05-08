using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BkEmployeePro.Models
{
    public class Input
    {
    }
    public class UserInput
    {
       public int EID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public int salary { get; set; }
        
    }
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}