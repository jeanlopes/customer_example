using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;

namespace CustomerExample.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            if (await _customerRepository.GetCustomerByEmail(customer.Email) != null)
            {
                throw new Exception("A customer with the same email already exists.");
            }

            var created = await _customerRepository.AddCustomer(customer);
            return created;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerById(customer.Id) 
                ?? throw new Exception("Customer not found.");
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.LogoPath = customer.LogoPath;

            _customerRepository.UpdateCustomer(existingCustomer);
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id) 
                ?? throw new Exception("Customer not found.");

            _customerRepository.RemoveCustomer(customer);
        }
    }
}
