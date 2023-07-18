namespace CustomerExample.Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public int CustomerId { get; set; }
    }
}
