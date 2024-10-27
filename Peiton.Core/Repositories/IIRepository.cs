using System.Linq.Expressions;

namespace Peiton.Core.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    /*Task AddAsync(T entity);*/
    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    bool Any(Expression<Func<T, bool>> where);
    Task<bool> AnyAsync(Expression<Func<T, bool>> where);
    int Count();
    Task<int> CountAsync();
    int Count(Expression<Func<T, bool>> where);
    Task<int> CountAsync(Expression<Func<T, bool>> where);
    void Delete(Expression<Func<T, bool>> where);
    T? Get(Expression<Func<T, bool>> where);
    Task<T?> GetAsync(Expression<Func<T, bool>> where);
    IEnumerable<T> GetAll();
    Task<List<T>> GetAllAsync();
    IEnumerable<T> GetAll<TKey>(Expression<Func<T, TKey>> sort, string sortDirection);
    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> sort, string sortDirection);
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);
    IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    Task<List<T>> GetManyAsync(Expression<Func<T, bool>> where);
    IEnumerable<T> GetMany<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection);
    Task<List<T>> GetManyAsync<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection);
    IEnumerable<T> GetMany<TKey>(int startRowIndex, int maximumRows, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection);
    Task<List<T>> GetManyAsync<TKey>(int startRowIndex, int maximumRows, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> sort, string sortDirection);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    void Reload(T entity);
}
