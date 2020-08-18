using BoxOfficeTestTask.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace BoxOfficeTestTask.Services.Users
{
    public class UserLoginResult
    {
        public User User { get; set; }

        public string Token { get; set; }
    }
}
