using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using auth.Configuration;
using auth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace auth.Services {
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Get(string id);
    }

    public class UserService : IUserService
    {
        private List<User> m_users = new List<User>() {
            new User { ID = "1", Username = "admin", Password = "plain", },
        };

        private readonly Secrets m_secrets;

        public UserService(IOptions<Secrets> secrets)
        {
            m_secrets = secrets.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = m_users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(m_secrets.Jwt);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.ID),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public User Get(string id)
        {
            return m_users.FirstOrDefault(u => u.ID == id);
        }
    }
}