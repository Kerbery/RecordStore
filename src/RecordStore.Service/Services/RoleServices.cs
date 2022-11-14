using Microsoft.AspNetCore.Identity;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository<IdentityRole> _roleRepository;

        public RoleServices(IRoleRepository<IdentityRole> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<IdentityRole>> GetUserRolesAsync(Guid id)
        {
            return await _roleRepository.GetUserRolesAsync(id);
        }

        public Task AddToRolesAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
