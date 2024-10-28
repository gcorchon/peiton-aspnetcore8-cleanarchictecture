using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Peiton.Core.Repositories;

namespace Peiton.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly DbSet<T> DbSet;

    protected readonly PeitonDbContext DbContext;

    protected RepositoryBase(PeitonDbContext dbContext)
    {
        this.DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    public virtual void Add(T entity)
    {
        DbSet.Add(entity);
    }

    /*public virtual Task AddAsync(T entity)
    {
        return DbSet.AddAsync(entity).AsTask();
    }*/

    public virtual void AddRange(IEnumerable<T> entities)
    {
        DbSet.AddRange(entities);
    }

    /*public virtual Task AddRangeAsync(IEnumerable<T> entities)
    {
        return DbSet.AddRangeAsync(entities);
    }*/

    public virtual void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public virtual void Delete(Expression<Func<T, bool>> where)
    {
        DbSet.RemoveRange(DbSet.Where<T>(where).AsEnumerable());
    }

    public virtual void Update(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        DbSet.Attach(entity);
    }

    public virtual T? GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual Task<T?> GetByIdAsync(int id)
    {
        return DbSet.FindAsync(id).AsTask();
    }


    public virtual IEnumerable<T> GetAll()
    {
        return DbSet.AsEnumerable();
    }

    public virtual Task<T[]> GetAllAsync()
    {
        return DbSet.ToArrayAsync();
    }

    public virtual IEnumerable<T> GetAll<TKey>(Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet;

        if (sortDirection == "DESC")
            query = query.OrderByDescending(sort);
        else
            query = query.OrderBy(sort);

        return query.AsEnumerable();
    }

    public virtual Task<T[]> GetAllAsync<TKey>(Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet;

        if (sortDirection == "DESC")
            query = query.OrderByDescending(sort);
        else
            query = query.OrderBy(sort);

        return query.ToArrayAsync();
    }

    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    {
        return DbSet.Where(where).AsEnumerable();
    }

    public virtual Task<T[]> GetManyAsync(Expression<Func<T, bool>> where)
    {
        return DbSet.Where(where).ToArrayAsync();

    }
    public virtual IEnumerable<T> GetMany<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet.Where(where);

        if (sortDirection == "DESC")
            query = query.OrderByDescending(sort);
        else
            query = query.OrderBy(sort);

        return query.AsEnumerable();
    }

    public virtual Task<T[]> GetManyAsync<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet.Where(where);

        if (sortDirection == "DESC")
            query = query.OrderByDescending(sort);
        else
            query = query.OrderBy(sort);

        return query.ToArrayAsync();
    }

    public virtual IEnumerable<T> GetMany<TKey>(int startRowIndex, int maximumRows, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet;
        if (where != null)
            query = query.Where(where);

        if (sort != null)
        {
            if (sortDirection == "DESC")
                query = query.OrderByDescending(sort);
            else
                query = query.OrderBy(sort);
        }

        return query.Skip(startRowIndex).Take(maximumRows).AsEnumerable();
    }

    public virtual Task<T[]> GetManyAsync<TKey>(int startRowIndex, int maximumRows, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection)
    {
        IQueryable<T> query = DbSet;
        if (where != null)
            query = query.Where(where);

        if (sort != null)
        {
            if (sortDirection == "DESC")
                query = query.OrderByDescending(sort);
            else
                query = query.OrderBy(sort);
        }

        return query.Skip(startRowIndex).Take(maximumRows).ToArrayAsync();
    }

    public T? Get(Expression<Func<T, bool>> where)
    {
        return DbSet.SingleOrDefault<T>(where);
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> where)
    {
        return DbSet.SingleOrDefaultAsync<T>(where);
    }


    public bool Any(Expression<Func<T, bool>> where)
    {
        return DbSet.Any(where);
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
    {
        return DbSet.AnyAsync(where);
    }

    public virtual int Count()
    {
        return this.DbSet.Count();
    }

    public virtual Task<int> CountAsync()
    {
        return this.DbSet.CountAsync();
    }

    public virtual int Count(Expression<Func<T, bool>> where)
    {
        if (where != null)
        {
            return DbSet.Count(where);
        }

        return this.Count();

    }

    public virtual Task<int> CountAsync(Expression<Func<T, bool>> where)
    {
        if (where != null)
        {
            return DbSet.CountAsync(where);
        }

        return this.CountAsync();

    }

    public virtual void Reload(T entry)
    {
        DbContext.Entry(entry).Reload();
    }
}
