using Authentication.Domain.Entities.User;
using Authentication.Service.Helpers;
using Authentication.Service.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Service.Services.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public async Task<string> GenerateToken(User user)
    {
        var identityClaims = new Claim[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("FirstName", user.FirstName),
            new Claim("Lastname", user.LastName),
            new Claim("Username", user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Type.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (tokenHandler.CanReadToken(token))
        {
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id");

            if (idClaim != null)
            {
                return idClaim.Value;
            }
        }

        return null;
    }
}
