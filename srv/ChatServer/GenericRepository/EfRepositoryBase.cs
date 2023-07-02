using ChatServer.Models;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;  

namespace ChatServer.GenericRepository;
public class EfRepositoryBase<TEntity, TContext> : IEfRepositoryBase<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }
     
    public async Task<bool> AddRangeAsync(List<TEntity> entity)
    {
        foreach (var item in entity)
        {
            Context.Entry(item).State = EntityState.Added;
        }

        await Context.AddRangeAsync(entity);
        await Context.SaveChangesAsync();
        return true;
    } 

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity> UpdateAsyncTrackerClear(TEntity entity)
    {
        Context.ChangeTracker.Clear();
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }  

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }

    public async Task<List<TEntity>> GetListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    } 
    
}
