using CustomerExample.Application.Validation;
using Microsoft.AspNetCore.Http;

namespace CustomerExample.Application.DTOs
{
    public class CustomerEditDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Only JPG, JPEG, PNG, and GIF files are allowed.")]
        public IFormFile? Logo { get; set; }
    }
}
