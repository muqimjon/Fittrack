using FTS.Service.Helpers;

namespace FTS.Service.Interfaces;

public interface IServiceInterface<TCreate, TUpdate, TResult>
{
    Task<Response<TResult>> CreateAsync(TCreate dto);
    Task<Response<TResult>> Update(TUpdate dto);
    Task<Response<bool>> Delete(long id);
    Task<Response<TResult>> GetByIdAsync(long id);
    Response<IEnumerable<TResult>> GetAll();
}
