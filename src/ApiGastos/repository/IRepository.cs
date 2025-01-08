
using System.Linq.Expressions;
using ApiGastos.Entities;

namespace ApiGastos.Repository;

public interface IRepository<T> where T : IEntity
{
    public Task<IReadOnlyCollection<T>> GetAllAsync();
    public Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    public Task<T> GetAsync(Guid id);
    public Task<T> GetAsync(Expression<Func<T, bool>> filter);
    public Task CreateAsync(T entity);
    public Task UpdatedAsync(T entity);
    public Task RemoveAsync(Guid id);
}