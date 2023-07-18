using System.ComponentModel.DataAnnotations;

namespace CustomerExample.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
