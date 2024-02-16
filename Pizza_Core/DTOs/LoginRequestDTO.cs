using System.ComponentModel.DataAnnotations;
using Pizza_API.Validator;

namespace Pizza_Core.DTOs
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
