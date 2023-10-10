using Authentication.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccess.Contexts;

public class AuthenticationDbContext : DbContext
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
    { }

    public DbSet<User> users { get; set; }
}
