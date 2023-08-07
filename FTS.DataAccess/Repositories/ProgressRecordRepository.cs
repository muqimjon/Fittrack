using FTS.Data.DbContexts;
using FTS.Data.IRepositories;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;

namespace FTS.DataAccess.Repositories;

public class ProgressRecordRepository : Repository<ProgressRecord>, IProgressRecordRepository
{
    public ProgressRecordRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}
