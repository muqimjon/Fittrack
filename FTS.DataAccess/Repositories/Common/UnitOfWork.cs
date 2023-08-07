using FTS.DataAccess.Repositories;
using FTS.Data.DbContexts;
using FTS.Data.IRepositories;
using FTS.Data.IRepositories.Common;

namespace FTS.Data.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork()
    {
        appDbContext = new AppDbContext();
        ProgressRecordRepository = new ProgressRecordRepository(appDbContext);
        UserRepository = new UserRepository(appDbContext);
        WorkOutRepository = new WorkOutRepository(appDbContext);
        NuritionPlanRepository = new NuritionPlanRepository(appDbContext);
    }

    public IUserRepository UserRepository { get; }
    public IWorkOutRepository WorkOutRepository { get; }
    public INuritionPlanRepository NuritionPlanRepository { get; }
    public IProgressRecordRepository ProgressRecordRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
