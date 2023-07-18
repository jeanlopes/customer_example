using CustomerExample.Application.Interfaces;
using CustomerExample.Domain.Entities;

namespace CustomerExample.Application.Services
{
    public class UserAppService : IUserAppService
    {
        //private readonly IUserService _userService;

        //public UserAppService(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public async Task<User> Authenticate(string username, string password)
        {


            if (username == "admin" && password == "Password1")
            {
                return new User { Id = 1, Username = username, Password = password };
            }

            return null;
        }
    }
}
