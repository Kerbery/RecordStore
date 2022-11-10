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
    }
}
