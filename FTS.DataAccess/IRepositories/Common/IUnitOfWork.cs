namespace FTS.Data.IRepositories.Common;

public interface IUnitOfWork : IDisposable
{
    IProgressRecordRepository ProgressRecordRepository { get; }
    IUserRepository UserRepository { get; }
    INuritionPlanRepository NuritionPlanRepository { get; }
    IWorkOutRepository WorkOutRepository { get; }
    Task SaveAsync();
}
