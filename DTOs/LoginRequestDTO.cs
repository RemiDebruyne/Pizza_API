using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_API.Validator;

namespace Pizza_API.DTOs
{

    public class LoginRequestDTO 
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        [PasswordValidator]
        public string Password { get; set; }


    }
}
