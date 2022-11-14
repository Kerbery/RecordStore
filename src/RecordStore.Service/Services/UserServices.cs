using Microsoft.AspNetCore.Identity;
using RecordStore.Service.DTOs;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IUserStore<IdentityUser> _userStore;

        public UserServices( UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityUser>)_userStore;
        }
        public async Task<IdentityUser> GetUser(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            return _userManager.Users.AsEnumerable();
        }

        public async Task UpdateUser(IdentityUser user)
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

        public async Task<IdentityResult> CreateUser(CreateUserDTO createUserDTO)
        {
            var user = new IdentityUser();
            await _userStore.SetUserNameAsync(user, createUserDTO.UserName, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, createUserDTO.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, createUserDTO.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, createUserDTO.Roles);
                return roleResult;
            }
            return result;
        }

        public async Task UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var existingUser = await GetUser(updateUserDTO.Id);
            if (existingUser is null)
            {
                throw new Exception($"User with Id={{{updateUserDTO.Id}}} not found");
            }

            existingUser.Email = updateUserDTO.Email;
            existingUser.UserName = updateUserDTO.UserName;
            existingUser.NormalizedEmail = updateUserDTO.Email.ToUpper();
            existingUser.NormalizedUserName = updateUserDTO.UserName.ToUpper();

            if (!string.IsNullOrWhiteSpace(updateUserDTO.Password))
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, updateUserDTO.Password);
            }

            await _userManager.UpdateAsync(existingUser);

            var existingUserRoles = await _userManager.GetRolesAsync(existingUser);
            var selectedRoles = updateUserDTO.Roles.Where(r => r.IsInRole).Select(r => r.Name);

            var rolesToAdd = selectedRoles.Except(existingUserRoles);
            var rolesToRemove = existingUserRoles.Except(selectedRoles);

            await _userManager.AddToRolesAsync(existingUser, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(existingUser, rolesToRemove);
        }
    }
}
