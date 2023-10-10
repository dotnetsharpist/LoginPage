using Authentication.Domain.Entities.User;

namespace Authentication.DataAccess.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> UserRepository { get; }
    Task<bool> SaveAsync();
}
