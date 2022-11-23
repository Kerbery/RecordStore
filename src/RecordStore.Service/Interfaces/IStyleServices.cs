using RecordStore.Core.DTOs.Style;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Service.Interfaces
{
    public interface IStyleServices : IBaseServices<Style>
    {
        Task<Style> CreateAsync(CreateStyleDTO createStyleDTO);
        Task UpdateAsync(Guid id, UpdateStyleDTO updateStyleDTO);
    }
}