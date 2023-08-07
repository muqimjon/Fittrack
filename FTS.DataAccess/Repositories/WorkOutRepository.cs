using FTS.Data.DbContexts;
using FTS.Data.IRepositories;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;

namespace FTS.DataAccess.Repositories;

public class WorkOutRepository : Repository<WorkOut>, IWorkOutRepository
{
    public WorkOutRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
