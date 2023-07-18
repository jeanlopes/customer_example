using CustomerExample.Application.DTOs;

namespace CustomerExample.Application.Interfaces
{
    public interface ICustomerAppService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> GetCustomerById(int id);        
        Task CreateCustomer(CustomerDTO customerDto);
        Task UpdateCustomer(CustomerDTO customerDto);
        Task DeleteCustomer(int id);
    }
}
