using CustomerExample.Domain.Entities;

namespace CustomerExample.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<User> Authenticate(string username, string password);
    }
}
