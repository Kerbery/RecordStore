using RecordStore.Core.Entities;

namespace RecordStore.Core.Interfaces
{
    public interface IRoleRepository<T> : IRepository<T> where T: class, IEntity
    {
        Task<IReadOnlyCollection<T>> GetUserRolesAsync(Guid id);
    }
}