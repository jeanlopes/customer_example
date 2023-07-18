using CustomerExample.Domain.Entities;

namespace CustomerExample.Domain.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddresses();
        Task<Address?> GetAddressById(int id);
        Task CreateAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(int id);

        Task<IEnumerable<Address>> GetAddressesByCustomerId(int customerId);
    }
}
