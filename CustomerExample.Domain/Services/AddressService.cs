using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;

namespace CustomerExample.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;


        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task CreateAddress(Address address)
        {
            await _addressRepository.AddAddress(address);
        }

        public async Task UpdateAddress(Address address)
        {
            var existingAddress = await _addressRepository.GetAddressById(address.Id) 
                ?? throw new Exception("Address not found.");
            existingAddress.Street = address.Street;

            _addressRepository.UpdateAddress(existingAddress);
        }

        public async Task DeleteAddress(int id)
        {
            var address = await _addressRepository.GetAddressById(id) 
                ?? throw new Exception("Address not found.");
            _addressRepository.RemoveAddress(address);
        }

        public async Task<Address?> GetAddressById(int id)
        {
            return await _addressRepository.GetAddressById(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _addressRepository.GetAllAddresses();
        }

        public async Task<IEnumerable<Address>> GetAddressesByCustomerId(int customerId)
        {
            return await _addressRepository.GetAddressesByCustomerId("EXEC GetAddressesByCustomerId @p0", customerId);
        }
    }
}
