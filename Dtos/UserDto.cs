using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Dtos
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }
    }
}
