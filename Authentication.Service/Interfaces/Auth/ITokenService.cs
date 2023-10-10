using Authentication.Domain.Entities.User;

namespace Authentication.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);

    public string GetUserIdFromToken(string token);
}
