using Authentication.Domain.Common;
using Authentication.Domain.Enums;

namespace Authentication.Domain.Entities.User;

public class User : Auditable
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool EmailConfirmed { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public UserType Type { get; set; }

    public long ShopId { get; set; }
}
