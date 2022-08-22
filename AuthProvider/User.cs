using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.AuthProvider
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}