using Microsoft.AspNetCore.Identity;
using RecordStore.Service.DTOs;

namespace RecordStore.Service.Interfaces
{
    public interface IUserServices
    {
        Task<IdentityUser> GetUser(Guid id);
        Task<IEnumerable<IdentityUser>> GetUsers();
        Task UpdateUser(IdentityUser user);
        Task Lockout(Guid id);
        Task RemoveLockout(Guid id);
        Task<IdentityResult> CreateUser(CreateUserDTO createUserDTO);
        Task UpdateUser(UpdateUserDTO updateUserDTO);
    }
}