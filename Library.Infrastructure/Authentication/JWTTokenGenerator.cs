using Library.Application.Interfaces.Authentication;
using Library.Application.Interfaces.Services;
using Library.Domain.Entities.User;
using Library.Infrastructure.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly IConfiguration iconfiguration;
        public JWTTokenGenerator(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public string GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
{
             new Claim(ClaimTypes.Name, user.FirstName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
