using RecordStore.Core.Entities.Identity;

namespace RecordStore.Service.Interfaces
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<IEnumerable<Role>> GetUserRolesAsync(Guid id);
    }
}