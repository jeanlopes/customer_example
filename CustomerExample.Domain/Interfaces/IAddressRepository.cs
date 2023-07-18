using CustomerExample.Domain.Entities;

namespace CustomerExample.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddressesByCustomerId(string sql, params object[] parameters);
        Task<IEnumerable<Address>> GetAllAddresses();
        Task<Address?> GetAddressById(int id);
        Task AddAddress(Address address);
        void UpdateAddress(Address address);
        void RemoveAddress(Address address);
    }
}
