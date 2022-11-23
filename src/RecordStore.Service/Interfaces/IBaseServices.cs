using RecordStore.Core.Entities;

namespace RecordStore.Service.Interfaces
{
    public interface IBaseServices<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}