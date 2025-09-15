using AppleWatch_Notes_app.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppleWatch_Notes_app.Auth
{
    public class JwtService
    {
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("userName", user.Name),
                new Claim("id", user.userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vbvlidfbhvldfhbvlf"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1), // token valid for 1 hour
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
