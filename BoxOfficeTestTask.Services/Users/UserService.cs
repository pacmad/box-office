using BoxOfficeTestTask.Models.Users;
using BoxOfficeTestTask.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BoxOfficeTestTask.Services.Users
{
    public class UserService : IUserService
    {
        private List<User> _mokedUsers = new List<Models.Users.User>()
        {
            new Models.Users.User
            {
                Id = 1,
                Login = "admin@test.com",
                Password = "P@ssw0rd",
                Role = Roles.Admin
            },
             new Models.Users.User
            {
                Id = 2,
                Login = "user@test.com",
                Password = "P@ssw0rd",
                Role = Roles.User
            },
        };

        private readonly JwtSettings _jwtSettings;
        public UserService(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public UserLoginResult Authenticate(string login, string password)
        {
            var user = _mokedUsers.SingleOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.LifetimeInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserLoginResult
            {
                User = user,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public IEnumerable<User> GetUsers()
        {
            return _mokedUsers;
        }

        public User GetById(int id)
        {
            return _mokedUsers.FirstOrDefault(x => x.Id == id);
        }
    }
}
