using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Application.DTOs
{
    public class StreetDTO
    {

        [MinLength(3)]
        public required string Street { get; set; }
    }
}
