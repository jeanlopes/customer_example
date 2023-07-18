using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Domain.Entities
{    
    public class Customer : Entity
    {        
        
        public required string Name { get; set; }
        
        [EmailAddress]
        public required string Email { get; set; }

        public virtual required ICollection<Address> Addresses { get; set; }
        public required string LogoPath { get; set; }
    }
}
