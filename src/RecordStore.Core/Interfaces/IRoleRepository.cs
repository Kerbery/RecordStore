using RecordStore.Core.Entities.Identity;

namespace RecordStore.Core.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IReadOnlyCollection<Role>> GetUserRolesAsync(Guid id);
    }
}