using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using core.Identity.Entities;
using identity.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace identity.Services.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(ApplicationUser user)
    {
        var jwtConfig = _configuration.GetSection("Jwt").Get<JwtConfiguration>();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));    
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
        var token = new JwtSecurityToken(jwtConfig.Issuer,    
            jwtConfig.Issuer,    
            new Claim[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            },    
            expires: DateTime.UtcNow.AddDays(jwtConfig.ExpireInDays),    
            signingCredentials: credentials);    
    
        return new JwtSecurityTokenHandler().WriteToken(token); 
    }
}