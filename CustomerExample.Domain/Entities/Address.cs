namespace CustomerExample.Domain.Entities
{
    public class Address : Entity
    {   
        public required string Street { get; set; }

        public int CustomerId { get; set; }

        public virtual required Customer Customer { get; set; }
    }
}
