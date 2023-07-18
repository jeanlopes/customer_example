using CustomerExample.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerExample.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }        

        public void Rollback()
        {
            //_context.Database.RollbackTransaction();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
