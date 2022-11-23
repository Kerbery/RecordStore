using RecordStore.Core.DTOs.Release;
using RecordStore.Core.Entities.Models;
using RecordStore.Core.Interfaces;
using RecordStore.Service.Interfaces;

namespace RecordStore.Service.Services
{
    public class ReleaseServices : BaseServices<Release>, IReleaseServices
    {
        public ReleaseServices(IRepository<Release> repository) : base(repository) { }

        public async Task<Release> CreateAsync(CreateReleaseDTO createReleaseDTO)
        {
            var release = new Release { Name = createReleaseDTO.Name };
            await CreateAsync(release);
            return release;
        }

        public async Task UpdateAsync(Guid id, UpdateReleaseDTO updateReleaseDTO)
        {
            var existingRelease = await GetAsync(id);
            existingRelease.Name = updateReleaseDTO.Name;

            await UpdateAsync(existingRelease);
        }
    }
}
