using RecordStore.Core.Entities;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class BaseServices<T> : IBaseServices<T> where T : class, IEntity
    {

        protected readonly IRepository<T> _repository;

        public BaseServices(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}