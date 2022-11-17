using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.ViewModels;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IUserStore<ApplicationUser> _userStore;

        public UserServices( UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<ApplicationUser>)_userStore;
        }
        public async Task<ApplicationUser> GetUser(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return _userManager.Users.AsEnumerable();
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task Lockout(Guid id)
        {
            var user = await GetUser(id);
            user.LockoutEnd = DateTime.Today.AddYears(10);
            await UpdateUser(user);
        }

        public async Task RemoveLockout(Guid id)
        {
            var user = await GetUser(id);
            user.LockoutEnd = null;
            await UpdateUser(user);
        }

        public async Task<IdentityResult> CreateUser(AddUserViewModel addUserViewModel)
        {
            var user = new ApplicationUser();
            await _userStore.SetUserNameAsync(user, addUserViewModel.Username, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, addUserViewModel.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, addUserViewModel.Password);
            if (result.Succeeded)
            {
                var roles = addUserViewModel.Roles.Where(r => r.IsSelected).Select(r => r.Name);                
                var roleResult = await _userManager.AddToRolesAsync(user, roles);
                return roleResult;
            }
            return result;
        }

        public async Task UpdateUser(EditUserViewModel editUserViewModel)
        {
            var existingUser = await GetUser(editUserViewModel.Id);
            if (existingUser is null)
            {
                throw new Exception($"User with Id={{{editUserViewModel.Id}}} not found");
            }

            existingUser.Email = editUserViewModel.Email;
            existingUser.UserName = editUserViewModel.Username;
            existingUser.NormalizedEmail = editUserViewModel.Email.ToUpper();
            existingUser.NormalizedUserName = editUserViewModel.Username.ToUpper();

            if (!string.IsNullOrWhiteSpace(editUserViewModel.Password))
            {
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, editUserViewModel.Password);
            }

            await _userManager.UpdateAsync(existingUser);

            var existingUserRoles = await _userManager.GetRolesAsync(existingUser);
            var selectedRoles = editUserViewModel.Roles.Where(r => r.IsSelected).Select(r => r.Name);

            var rolesToAdd = selectedRoles.Except(existingUserRoles);
            var rolesToRemove = existingUserRoles.Except(selectedRoles);

            await _userManager.AddToRolesAsync(existingUser, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(existingUser, rolesToRemove);
        }
    }
}
