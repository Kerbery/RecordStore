using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.ViewModels.User;

namespace RecordStore.Service.Interfaces
{
    public interface IUserServices
    {
        Task<ApplicationUser> GetUser(Guid id);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task UpdateUser(ApplicationUser user);
        Task Lockout(Guid id);
        Task RemoveLockout(Guid id);
        Task<IdentityResult> CreateUser(AddUserViewModel addUserViewModel);
        Task UpdateUser(EditUserViewModel editUserViewModel);
    }
}