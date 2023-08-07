using FTS.Domain.Entities;
using FTS.Data.IRepositories.Common;

namespace FTS.Data.IRepositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email);
}
