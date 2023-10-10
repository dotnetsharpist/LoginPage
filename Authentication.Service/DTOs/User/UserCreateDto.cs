using Authentication.Domain.Enums;

namespace Authentication.Service.DTOs.Users;

public class UserCreateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set;} = string.Empty;

    public UserType Type { get; set; }

    public long ShopId { get; set; }
}
