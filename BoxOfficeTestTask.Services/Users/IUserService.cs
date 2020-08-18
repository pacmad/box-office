using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace BoxOfficeTestTask.Services.Users
{
    public interface IUserService
    {
        UserLoginResult Authenticate(string login, string password);
        Models.Users.User GetById(int id);
        IEnumerable<Models.Users.User> GetUsers();
    }
}