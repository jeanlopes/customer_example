using CustomerExample.Application.DTOs;
using CustomerExample.Domain.Entities;

namespace CustomerExample.Application.Interfaces
{
    public interface IAddressAppService
    {
        Task<IEnumerable<AddressDTO>> GetAllAddresses();
        Task<AddressDTO> GetAddressById(int id);
        Task CreateAddress(AddressDTO addressDto);
        Task UpdateAddress(AddressDTO addressDto);
        Task DeleteAddress(int id);
        Task<IEnumerable<Address>> GetAddressesByCustomerId(int customerId);
    }
}
