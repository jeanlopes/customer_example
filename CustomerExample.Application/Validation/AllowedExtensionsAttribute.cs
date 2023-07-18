using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Application.Validation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!_extensions.Contains(extension.ToLower()))
                {
                    var allowedExtensions = string.Join(", ", _extensions);
                    var errorMessage = $"Allowed file extensions are: {allowedExtensions}";

                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
