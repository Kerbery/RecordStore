using Microsoft.AspNetCore.Identity;

namespace RecordStore.Service.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityUser> GetUser(Guid id);
        Task<IEnumerable<IdentityUser>> GetUsers();
    }
}