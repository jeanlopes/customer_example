using CustomerExample.Domain.Entities;
using CustomerExample.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerExample.Infrastructure.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public async Task<IEnumerable<Address>> GetAddressesByCustomerId(string sql, params object[] parameters)
        {
            return await _dbContext.Addresses.FromSqlRaw(sql, parameters).ToListAsync();
        }

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await _dbContext.Addresses.ToListAsync();
        }

        public async Task<Address?> GetAddressById(int id)
        {
            return await _dbContext.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAddress(Address address)
        {
            await _dbContext.Addresses.AddAsync(address);
        }

        public void UpdateAddress(Address address)
        {
            _dbContext.Entry(address).State = EntityState.Modified;
        }

        public void RemoveAddress(Address address)
        {
            _dbContext.Addresses.Remove(address);
        }
        
    }
}
