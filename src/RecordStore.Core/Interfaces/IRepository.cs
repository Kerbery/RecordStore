using RecordStore.Core.Entities;
using System.Linq.Expressions;

namespace RecordStore.Core.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
