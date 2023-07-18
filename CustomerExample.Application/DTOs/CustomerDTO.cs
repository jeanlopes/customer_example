using CustomerExample.Application.Validation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Application.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Only JPG, JPEG, PNG, and GIF files are allowed.")]
        public IFormFile? Logo { get; set; }

        public string? LogoPath { get; set; }

        [MinLength(1)]
        public required List<StreetDTO> Streets { get; set; }
    }
}
