using JWTTemplateAPI.Models;
using JWTTemplateAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace JWTTemplateAPI.Services
{
    public class TokenService
    {
        public static string GenerateToken(User user)
        {
            var userBase = UserRepository.GetUserByEmail(user.Email);

            if (userBase != null && user.Password == userBase.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var subject = new ClaimsIdentity(
                    new GenericIdentity(user.Id.ToString(), "Login"),
                        new[]
                        {
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
                        }
                    );

                var key = Encoding.ASCII.GetBytes("b10a8db164e0754105b7a99be72e3fe5");

                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    SigningCredentials = signingCredentials,
                    Expires = DateTime.UtcNow.AddHours(1)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                throw new Exception("User invalid.");
            }
        }
    }
}
