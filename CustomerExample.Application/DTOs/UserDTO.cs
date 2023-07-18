using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Application.DTOs
{
    public class UserDTO
    {
        [MinLength(3)]
        public required string Username { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "The password must contain at least 8 characters, including uppercase and lowercase letters, numbers, and special characters.")]
        public required string Password { get; set; }
    }
}
