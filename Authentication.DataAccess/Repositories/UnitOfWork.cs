using Authentication.DataAccess.Contexts;
using Authentication.DataAccess.IRepositories;
using Authentication.Domain.Entities.User;

namespace Authentication.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuthenticationDbContext dbContext;

    public UnitOfWork(AuthenticationDbContext dbContext)
    {
        this.dbContext = dbContext;
        UserRepository = new Repository<User>(dbContext);
    }

    public IRepository<User> UserRepository { get; set; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await this.dbContext.SaveChangesAsync();
        return saved > 0;
    }
}
