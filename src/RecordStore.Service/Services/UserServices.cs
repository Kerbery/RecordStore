using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<IdentityUser> _repository;

        public UserServices(IRepository<IdentityUser> repository)
        {
            _repository = repository;
        }
        public async Task<IdentityUser> GetUser(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateUser(IdentityUser user)
        {
            await _repository.UpdateAsync(user);
        }

        public async Task Lockout(Guid id)
        {
            var user = await _repository.GetAsync(id);
            user.LockoutEnd = DateTime.Today.AddYears(10);
            await _repository.UpdateAsync(user);
        }

        public async Task RemoveLockout(Guid id)
        {
            var user = await _repository.GetAsync(id);
            user.LockoutEnd = null;
            await _repository.UpdateAsync(user);
        }
    }
}
