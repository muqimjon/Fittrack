using FTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FTS.Data.DbContexts;
using FTS.Data.IRepositories;
using FTS.Data.Repositories.Common;

namespace FTS.DataAccess.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext appDbContext;
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<User> GetByEmail(string email)
        => await appDbContext.Users.FirstOrDefaultAsync(c => c.Email.Equals(email));
}
