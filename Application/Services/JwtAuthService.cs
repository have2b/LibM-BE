using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly IConfiguration _configuration;

        public JwtAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, user.Username) };
            var role = nameof(user.Role);
            claims.Add(new Claim(ClaimTypes.Role, role));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}