using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerExample.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        void Rollback();
    }
}
