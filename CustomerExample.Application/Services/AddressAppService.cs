using AutoMapper;
using CustomerExample.Application.DTOs;
using CustomerExample.Application.Interfaces;
using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;
using CustomerExample.Infrastructure.Interfaces;

namespace CustomerExample.Application.Services
{
    public class AddressAppService : IAddressAppService
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressAppService(IAddressService addressService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _addressService = addressService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddresses()
        {
            var addresses = await _addressService.GetAllAddresses();
            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public async Task<AddressDTO> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);
            return _mapper.Map<AddressDTO>(address);
        }

        public async Task CreateAddress(AddressDTO addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.CreateAddress(address);
            await _unitOfWork.Commit();
        }

        public async Task UpdateAddress(AddressDTO addressDto)
        {
            _ = await _addressService.GetAddressById(addressDto.Id)
                ?? throw new Exception("Address not found.");
            var address = _mapper.Map<Address>(addressDto);
            await _addressService.UpdateAddress(address);
            await _unitOfWork.Commit();
        }

        public async Task DeleteAddress(int id)
        {
            var _ = await _addressService.GetAddressById(id) ?? throw new Exception("Address not found.");
            await _addressService.DeleteAddress(id);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Address>> GetAddressesByCustomerId(int customerId)
        {
            var addresses = await _addressService.GetAddressesByCustomerId(customerId); 
            
            return addresses;
        }
    }
}
