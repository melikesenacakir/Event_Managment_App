using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Interfaces;
using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Infra.Services.Concrete
{
    public class Middleware: IMiddlewareService
    {
        
        private readonly IConfiguration _configuration;
        private static readonly Dictionary<Guid, (string Token, DateTime Expiry)> UserTokens = new Dictionary<Guid, (string Token, DateTime Expiry)>();
        public Middleware( IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public string GenerateToken(Users users,Guid userID)
        {
            var claim=new[]{
                new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("UserID",users.ID.ToString()),
                new Claim("Username",users.Username.ToString()),
            };
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token=new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claim,
                expires:DateTime.UtcNow.AddMinutes(60),
                signingCredentials:signIn
            );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
             DateTime expiry = token.ValidTo;
             UserTokens[userID] = (tokenValue, expiry);
             return tokenValue;
        }
         public string _CheckExpired (Guid userID)
        {
            if (UserTokens.TryGetValue(userID, out var tokenInfo) && tokenInfo.Expiry > DateTime.UtcNow) //this checks if jwt token is still valid. If not it will generate a new one
            {
                return tokenInfo.Token; 
            }
            return "";
        }
    }
}