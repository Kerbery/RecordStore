using RecordStore.Core.DTOs.Format;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IFormatServices : IBaseServices<Format>
    {
        Task<Format> CreateAsync(CreateFormatDTO createFormatDTO);
        Task UpdateAsync(Guid id, UpdateFormatDTO updateFormatDTO);
    }
}