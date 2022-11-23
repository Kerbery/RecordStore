using RecordStore.Core.DTOs.Release;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IReleaseServices : IBaseServices<Release>
    {
        Task<Release> CreateAsync(CreateReleaseDTO createReleaseDTO);
        Task UpdateAsync(Guid id, UpdateReleaseDTO updateReleaseDTO);
    }
}