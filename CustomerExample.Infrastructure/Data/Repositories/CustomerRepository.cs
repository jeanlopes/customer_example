using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerExample.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _dbContext.Customers.Include(c => c.Addresses).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var created = await _dbContext.Customers.AddAsync(customer);
            return created.Entity;
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
        }

        public void RemoveCustomer(Customer customer)
        {
             _dbContext.Customers.Remove(customer);
        }


        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(_dbContext => _dbContext.Email == email);
        }
    }
}
