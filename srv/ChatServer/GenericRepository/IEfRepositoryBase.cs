using ChatServer.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ChatServer.GenericRepository;

public interface IEfRepositoryBase <T> where T : Entity
{
    T Get(Expression<Func<T, bool>> predicate);
      
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
       bool enableTracking = true,
       CancellationToken cancellationToken = default); 
    Task<List<T>> GetListAsync();

    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> UpdateAsyncTrackerClear(T entity);
    Task<T> DeleteAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entity);

    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);

}
