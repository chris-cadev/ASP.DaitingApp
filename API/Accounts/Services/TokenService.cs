
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Accounts.Entities;
using API.Accounts.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Accounts.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CrateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");
        if (tokenKey.Length < 64) throw new Exception("Your token key needs to be longer or equal to 64");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var claims = new List<Claim>
        {new(ClaimTypes.NameIdentifier, user.UserName)};

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
