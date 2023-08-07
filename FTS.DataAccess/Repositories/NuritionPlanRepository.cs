using FTS.Data.DbContexts;
using FTS.Data.IRepositories;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;

namespace FTS.DataAccess.Repositories;

public class NuritionPlanRepository : Repository<NuritionPlan>, INuritionPlanRepository
{

    public NuritionPlanRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        appDbContext = new AppDbContext();
    }
}