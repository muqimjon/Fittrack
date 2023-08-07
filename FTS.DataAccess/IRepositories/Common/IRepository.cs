using FTS.Domain.Commons;

namespace FTS.Data.IRepositories.Common;

public interface IRepository<T> where T : AudiTable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetByIdAsync(long id);
    IQueryable<T> GetAll();
}
