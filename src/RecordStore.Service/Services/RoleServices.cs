using RecordStore.Core.Entities.Identity;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository<Role> _roleRepository;

        public RoleServices(IRoleRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid id)
        {
            return await _roleRepository.GetUserRolesAsync(id);
        }

        public Task AddToRolesAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
