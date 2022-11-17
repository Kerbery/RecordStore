using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Identity;
using RecordStore.Service.DTOs;

namespace RecordStore.Service.Interfaces
{
    public interface IUserServices
    {
        Task<ApplicationUser> GetUser(Guid id);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task UpdateUser(ApplicationUser user);
        Task Lockout(Guid id);
        Task RemoveLockout(Guid id);
        Task<IdentityResult> CreateUser(CreateUserDTO createUserDTO);
        Task UpdateUser(UpdateUserDTO updateUserDTO);
    }
}