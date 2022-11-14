using Microsoft.AspNetCore.Identity;

namespace RecordStore.Service.Interfaces
{
    public interface IRoleServices
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<IEnumerable<IdentityRole>> GetUserRolesAsync(Guid id);
    }
}