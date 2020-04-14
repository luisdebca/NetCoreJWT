using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWTOnNetCore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTOnNetCore.Services
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
    }
    
    public class AuthService: IAuthService
    {
        private DbContext _context;
        public IConfiguration Configuration { get; }

        public AuthService(IConfiguration configuration)
        {
            _context = new DbContext();
            Configuration = configuration;
        }

        public User Authenticate(string username, string password)
        {
            try
            {
                var user = _context.Users()
                    .SingleOrDefault(
                        u => u.Username == username && 
                             u.Password == password
                                          );
                if (user == null)
                {
                    return null;
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] 
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user.WithoutPassword();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}