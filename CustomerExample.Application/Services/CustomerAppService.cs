using AutoMapper;
using CustomerExample.Application.DTOs;
using CustomerExample.Application.Interfaces;
using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;
using CustomerExample.Infrastructure.Interfaces;

namespace CustomerExample.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerAppService(ICustomerService customerService, IAddressService addressService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerService = customerService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _addressService = addressService;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            var customersDto = customers.Select(_mapper.Map<CustomerDTO>);

            return customersDto;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task CreateCustomer(CustomerDTO customerDTO)
        {
            
            try
            {
                var customer = _mapper.Map<Customer>(customerDTO);
                var created = await _customerService.CreateCustomer(customer);


                customerDTO.Streets.ToList().ForEach(async streetDTO =>
                {
                    var address = new Address { Street = streetDTO.Street, Customer = created };
                    await _addressService.CreateAddress(address);
                });


               await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            
        }

        public async Task UpdateCustomer(CustomerDTO customerDto)
        {            
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerService.UpdateCustomer(customer);
            await _unitOfWork.Commit();
        }

        public async Task DeleteCustomer(int id)
        {            
            await _customerService.DeleteCustomer(id);
            await _unitOfWork.Commit();
        }
    }
}
